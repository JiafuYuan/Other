if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.m_Case')
            and   type = 'U')
   drop table dbo.m_Case
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.m_SecurityIncident')
            and   type = 'U')
   drop table dbo.m_SecurityIncident
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.m_WarningInformation')
            and   type = 'U')
   drop table dbo.m_WarningInformation
go


/*==============================================================*/
/* Table: m_Case                                                */
/*==============================================================*/
create table dbo.m_Case (
   ID                   int                  not null,
   vc_Code              varchar(500)         collate Chinese_PRC_CI_AS not null,
   vc_Name              varchar(500)         collate Chinese_PRC_CI_AS not null,
   vc_Development       varchar(Max)         not null,
   dt_AboutTime         datetime             null,
   vc_UrgencyLevel      varchar(500)         null,
   vc_Hazard            text                 null,
   vc_InformationKnownRange varchar(500)         null,
   vc_Solutions         text                 null,
   vc_Example           varchar(500)         null,
   vc_AnalysisReport    text                 null,
   constraint PK_m_Case primary key (ID)
         on "PRIMARY"
)
on "PRIMARY"
textimage_on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', 'dbo', 'table', 'm_Case', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_Code'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_Name'
go

execute sp_addextendedproperty 'MS_Description', 
   '���͵�λ����',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_Development'
go

execute sp_addextendedproperty 'MS_Description', 
   '��֪ʱ��',
   'user', 'dbo', 'table', 'm_Case', 'column', 'dt_AboutTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����̶�',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_UrgencyLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   'Σ������',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_Hazard'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ϣ֪����Χ',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_InformationKnownRange'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ��ȡ��Ӧ�Դ�ʩ������',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_Solutions'
go

execute sp_addextendedproperty 'MS_Description', 
   '������ѹ���ļ���',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_Example'
go

execute sp_addextendedproperty 'MS_Description', 
   '������������',
   'user', 'dbo', 'table', 'm_Case', 'column', 'vc_AnalysisReport'
go

/*==============================================================*/
/* Table: m_SecurityIncident                                    */
/*==============================================================*/
create table dbo.m_SecurityIncident (
   ID                   int                  not null,
   vc_Source            varchar(500)         not null,
   vc_Name              varchar(500)         not null,
   vc_Level             varchar(500)         null,
   vc_Type              varchar(500)         not null,
   vc_ChildType         varchar(500)         null,
   dt_RecTime           datetime             null,
   vc_Url               varchar(500)         null,
   vc_IP                varchar(500)         null,
   vc_DomainName        varchar(500)         null,
   vc_InjuredPartyName  varchar(500)         null,
   vc_InjuredPartyType  varchar(500)         null,
   vc_Cisborder         varchar(500)         null,
   vc_Country           varchar(500)         null,
   vc_Tel               varchar(500)         null,
   vc_City              varchar(500)         null,
   vc_Describe          text                 null,
   vc_Accessory         varchar(500)         null,
   constraint PK_m_SecurityIncident primary key (ID)
         on "PRIMARY"
)
on "PRIMARY"
textimage_on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼���Դ',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Source'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼�����',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Name'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����̶�',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Level'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼�����',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Type'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼�������',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_ChildType'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼�����ʱ��',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'dt_RecTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼�URl',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Url'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼�IP',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_IP'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼�����',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_DomainName'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ܺ�������',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_InjuredPartyName'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ܺ�������',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_InjuredPartyType'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ܺ�������������',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Cisborder'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ܺ�������ʡ�ݹ���',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Country'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ܺ�����ϵ��ʽ',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Tel'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ܺ�����������',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_City'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ϸ������Ϣ',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Describe'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'm_SecurityIncident', 'column', 'vc_Accessory'
go

/*==============================================================*/
/* Table: m_WarningInformation                                  */
/*==============================================================*/
create table dbo.m_WarningInformation (
   ID                   int                  not null,
   vc_Type              varchar(500)         not null,
   vc_Level             varchar(500)         not null,
   dt_AboutTime         datetime             null,
   m_Describe           text                 not null,
   vc_AffectUser        varchar(500)         null,
   vc_Hazard            text                 null,
   vc_InformationKnownRange varchar(500)         null,
   vc_Solutions         text                 null,
   vc_Example           varchar(500)         null,
   constraint PK_M_WARNINGINFORMATION primary key (ID)
)
on "PRIMARY"
textimage_on "PRIMARY"
go

execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'ID'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'vc_Type'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'vc_Level'
go

execute sp_addextendedproperty 'MS_Description', 
   '��֪ʱ��',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'dt_AboutTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ϣ����',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'm_Describe'
go

execute sp_addextendedproperty 'MS_Description', 
   '����Ӱ����û�����Χ',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'vc_AffectUser'
go

execute sp_addextendedproperty 'MS_Description', 
   'Σ������',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'vc_Hazard'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Ϣ֪����Χ',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'vc_InformationKnownRange'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ��ȡ��Ӧ�Դ�ʩ������',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'vc_Solutions'
go

execute sp_addextendedproperty 'MS_Description', 
   '������ѹ���ļ���',
   'user', 'dbo', 'table', 'm_WarningInformation', 'column', 'vc_Example'
go
