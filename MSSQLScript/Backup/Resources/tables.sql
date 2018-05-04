
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

declare @crlf char(2)
SET @crlf=char(13)+char(10)

;WITH ColumnDefs as
(
  select TableObj=c.[object_id]
        ,ColSeq=c.column_id
        ,ColumnDef=quotename(c.Name)+' '
                  +case 
                     when c.is_computed=1 then 'as '+coalesce(k.[definition],'')
                         +case when k.is_persisted=1 then ' PERSISTED'+case when k.is_nullable=0 then ' NOT NULL' else '' end else '' end
                     else DataType
                         +case
                            when DataType in ('decimal','numeric') then '('+cast(c.precision as varchar(10))+case when c.scale<>0 then ','+cast(c.scale as varchar(10)) else '' end +')'
                            when DataType in ('char','varchar','nchar','nvarchar','binary','varbinary') then '('+case when c.max_length=-1 then 'max' else case when DataType in ('nchar','nvarchar') then cast(c.max_length/2 as varchar(10)) else cast(c.max_length as varchar(10)) end end +')'
                            when DataType='float' and c.precision<>53 then '('+cast(c.precision as varchar(10))+')'
                            when DataType in ('time','datetime2','datetimeoffset') and c.scale<>7 then '('+cast(c.scale as varchar(10))+')'
                            else ''
                          end
                   end
                  +case when c.is_identity=1 then ' IDENTITY('+cast(IDENT_SEED(quotename(object_schema_name(c.[object_id]))+'.'+quotename(object_name(c.[object_id]))) as varchar(30))+','+cast(ident_incr(quotename(object_schema_name(c.[object_id]))+'.'+quotename(object_name(c.[object_id]))) as varchar(30))+')' else '' end
                  +case when c.is_rowguidcol=1 then ' ROWGUIDCOL' else '' end
                  +case when c.xml_collection_id>0 THEN ' (CONTENT '+QUOTENAME(SCHEMA_NAME(x.SCHEMA_ID))+'.'+ QUOTENAME(x.name)+')' ELSE '' end
                  +case 
                     when c.is_computed=0 and UserDefinedFlag=0
                     then case
                            when c.collation_name<>cast(databasepropertyex(db_name() ,'collation') as nvarchar(128))
                            then ' COLLATE '+c.collation_name
                            else ''
                          end
                     else ''
                   end
                  +case when c.is_computed=0 then case when c.is_nullable=0 then ' NOT' else '' end+' NULL' else '' end
                  +case 
                     when c.default_object_id>0
                     then ' CONSTRAINT '+quotename(d.name)+' DEFAULT '+coalesce(d.[definition],'')
                     else ''
                   end
                 
  from sys.columns c
  cross apply (  
    select DataType=type_name(c.user_type_id)
          ,UserDefinedFlag=case
                             when c.system_type_id=c.user_type_id 
                               then 0
                               else 1
                             end) F1
  left join sys.default_constraints d ON c.default_object_id=d.[object_id]
  left join sys.computed_columns k ON c.[object_id]=k.[object_id] 
                                   and c.column_id=k.column_id
   left join  sys.xml_schema_collections x ON c.xml_collection_id = x.xml_collection_id                            
)
,IndexDefs as
(
  select TableObj=i.[object_id]
        ,IxName=quotename(i.name) 
        ,IxPKFlag=i.is_primary_key 
        ,IxType=case when i.is_primary_key=1 then 'PRIMARY KEY ' when i.is_unique=1 then 'UNIQUE ' else '' end
               +lower(type_desc)
        ,IxDef='('+IxColList+')'
              +coalesce(' INCLUDE ('+IxInclList+')','')
        ,IxOpts=IxOptList        
  from sys.indexes i
  left join sys.stats s ON i.index_id=s.stats_id and i.[object_id]=s.[object_id]
  cross apply (  
    select stuff((select case when i.is_padded=1 then ', PAD_INDEX=ON' else '' end
                        +case when i.fill_factor<>0 then ', FILLFACTOR='+cast(i.fill_factor as varchar(10)) else '' end
                        +case when i.ignore_dup_key=1 then ', IGNORE_DUP_KEY=ON' else '' end
                        +case when s.no_recompute=1 then ', STATISTICS_RECOMPUTE=ON' else '' end
                        +case when i.allow_row_locks=0 then ', ALLOW_ROW_LOCKS=OFF' else '' end
                        +case when i.allow_page_locks=0 then ', ALLOW_PAGE_LOCKS=OFF' else '' end)
                 ,1,2,'')) F_IxOpts(IxOptList)
  cross apply (  
    select stuff((select ','+quotename(c.name)
                        +case
                          when ic.is_descending_key=1 AND i.type<>3
                           then ' DESC'
                           WHEN ic.is_descending_key=0 AND i.type<>3 
                           THEN ' ASC'
                           ELSE ''
                         end
                  from sys.index_columns ic
                  join sys.columns c ON ic.[object_id]=c.[object_id]
                                     and ic.column_id=c.column_id 
                  where ic.[object_id]=i.[object_id] 
                    and ic.index_id=i.index_id 
                    and ic.is_included_column=0
                  order by ic.key_ordinal 
                  FOR xml path(''),type).value('.','nvarchar(max)')
                ,1,1,'')) F_IxCols(IxColList)
  cross apply (  
    select stuff((select ','+quotename(c.name)
                  from sys.index_columns ic
                  join sys.columns c ON ic.[object_id]=c.[object_id]
                                     and ic.column_id=c.column_id 
                  where ic.[object_id]=i.[object_id] 
                    and ic.index_id=i.index_id 
                    and ic.is_included_column=1
                  order by ic.key_ordinal 
                  FOR xml path(''),type).value('.','nvarchar(max)')
                ,1,1,'')) F_IxIncl(IxInclList)
  where i.type_desc<>'HEAP'
)
,FKDefs as
(
  select TableObj=f.parent_object_id 
        ,FKName=quotename(f.name)
        ,FKRef=quotename(object_schema_name(f.referenced_object_id))+'.'
              +quotename(object_name(f.referenced_object_id))
        ,FKColList=ParentColList
        ,FKRefList=RefColList 
        ,FKDelOpt=case f.delete_referential_action
                    when 1 then 'CASCADE'
                    when 2 then 'SET NULL'
                    when 3 then 'SET DEFAULT'
                  end
        ,FKUpdOpt=case f.update_referential_action
                    when 1 then 'CASCADE'
                    when 2 then 'SET NULL'
                    when 3 then 'SET DEFAULT'
                  end
        ,FKNoRepl=f.is_not_for_replication 
  from sys.foreign_keys f
  cross apply (  
    select stuff((select ','+quotename(c.name)
                  from sys.foreign_key_columns k 
                  join sys.columns c ON k.parent_object_id=c.[object_id] 
                                        and k.parent_column_id=c.column_id
                  where k.constraint_object_id=f.[object_id]
                  order by constraint_column_id 
                  FOR xml path(''),type).value('.','nvarchar(max)')
                ,1,1,'')) F_Parent(ParentColList)
  cross apply ( 
    select stuff((select ','+quotename(c.name)
                  from sys.foreign_key_columns k 
                  join sys.columns c ON k.referenced_object_id=c.[object_id] 
                                        and k.referenced_column_id=c.column_id
                  where k.constraint_object_id=f.[object_id]
                  order by constraint_column_id 
                  FOR xml path(''),type).value('.','nvarchar(max)')
                ,1,1,'')) F_Ref(RefColList)
)
select TableName
      ,[definition]
from sys.tables t
cross apply (  
  select TableName=quotename(object_schema_name(t.[object_id]))+'.'
                  +quotename(object_name(t.[object_id]))) F_Name
cross apply ( 
  select stuff((select @crlf+'  ,'+ColumnDef
                from ColumnDefs
                where TableObj=t.[object_id]
                order by ColSeq
                FOR xml path(''),type).value('.','nvarchar(max)')
              ,1,5,'')) F_Cols(ColumnList)
cross apply ( 
  select stuff((select @crlf+'  ,CONSTRAINT '+quotename(name)+' CHECK '
                      +case when is_not_for_replication=1 then 'NOT FOR REPLICATION ' else '' end
                      +coalesce([definition],'')
                from sys.check_constraints 
                where parent_object_id=t.[object_id]
                FOR xml path(''),type).value('.','nvarchar(max)')
              ,1,2,'')) F_Const(ChkConstList)
cross apply ( 
  select stuff((select @crlf+'  ,CONSTRAINT '+IxName+' '+IxType+' '+IxDef+coalesce(' WITH ('+IxOpts+')','')
                from IndexDefs
                where TableObj=t.[object_id]
                  and IxPKFlag=1
                FOR xml path(''),type).value('.','nvarchar(max)')
              ,1,2,'')) F_IxConst(IxConstList)
cross apply ( 
  select stuff((select @crlf+'  ,CONSTRAINT '+FKName+' FOREIGN KEY '+'('+FKColList+')'+' REFERENCES '+FKRef+' ('+FKRefList+')'
                      +case when FKDelOpt is NOT NULL then ' ON DELETE '+FKDelOpt else '' end
                      +case when FKUpdOpt is NOT NULL then ' ON UPDATE '+FKUpdOpt else '' end
                      +case when FKNoRepl=1 then ' NOT FOR REPLICATION' else '' end
                from FKDefs
                where TableObj=t.[object_id]
                FOR xml path(''),type).value('.','nvarchar(max)')
              ,1,2,'')) F_Keys(FKConstList)
cross apply ( 
  select stuff((select @crlf+'CREATE '+IxType+' INDEX '+IxName+' ON '+TableName+' '+IxDef+coalesce(' WITH ('+IxOpts+')','')
                from IndexDefs
                where TableObj=t.[object_id]
                  and IxPKFlag=0
                FOR xml path(''),type).value('.','nvarchar(max)')
              ,1,2,'')) F_Indexes(IndexList)
cross apply ( 
  select [definition]=(select 'CREATE TABLE '+TableName+@crlf+'('+@crlf+'   '+ColumnList+coalesce(@crlf+ChkConstList,'')+coalesce(@crlf+IxConstList,'')+coalesce(@crlf+FKConstList,'')+@crlf+')'+coalesce(@crlf+IndexList,'')+@crlf
  FOR xml path(''),type).value('.','nvarchar(max)')) F_Link
