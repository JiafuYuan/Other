;WITH TypeDef AS(
  SELECT TypeName=QUOTENAME( SCHEMA_NAME(t.schema_id))+'.'+QUOTENAME(t.name)
        ,ParentName=TYPE_NAME(t.system_type_id)+''
                 +case
                    when DataType in ('decimal','numeric') then '('+cast(t.precision as varchar(10))+case when t.scale<>0 then ','+cast(t.scale as varchar(10)) else '' end +')'
                    when DataType in ('char','varchar','nchar','nvarchar','binary','varbinary') then '('+case when t.max_length=-1 then 'max' else case when DataType in ('nchar','nvarchar') then cast(t.max_length/2 as varchar(10)) else cast(t.max_length as varchar(10)) end end +')'
                    when DataType='float' and t.precision<>53 then '('+cast(t.precision as varchar(10))+')'
                    when DataType in ('time','datetime2','datetimeoffset') and t.scale<>7 then '('+cast(t.scale as varchar(10))+')'
                    else ''
                  end
             +case when t.is_nullable=0 then ' NOT' else '' end+' NULL' 
  from sys.types t
  cross apply (  
    select DataType=type_name(t.system_type_id)
          ) F1
  WHERE t.is_user_defined=1
  )
  SELECT TypeName,'CREATE TYPE '+TypeName+' FROM ' +ParentName AS definition FROM TypeDef
