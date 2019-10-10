Public Module DBScript
    'Load default configurations.
    Public Sub SetDefaultSettings()
        Dim DB As SQLDB
        DB = New SQLDB(GetConnectionString(False))
        Dim sqls As New ArrayList
        'STIAPPVERSIONS Schema
        sqls.Add("IF NOT EXISTS (SELECT Name FROM master.dbo.sysdatabases WHERE name ='STIAPPVERSIONS') CREATE DATABASE STIAPPVERSIONS")
        'tblSTIService_config
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_config')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTIService_config]([Code] [nvarchar](50) NOT NULL,[Value] [text] NULL,CONSTRAINT [PK_tblSTIService_config] PRIMARY KEY CLUSTERED ([Code] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_email_notif')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTIService_email_notif]([Email] [varchar](100) NOT NULL,[Notif_Success] [bit] NULL, CONSTRAINT [PK_tblSTIService_email_notif] PRIMARY KEY CLUSTERED ([Email] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]")
        'tblSTIService_eventlog
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_eventlog')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTIService_eventlog]([logid] [varchar](15) NOT NULL,[logtime] [datetime] NULL,[logentry] [text] NULL,[error] [int] NULL,[logdesc] [text] NULL, CONSTRAINT [PK_tblSTIService_eventlog] PRIMARY KEY CLUSTERED ([logid] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
        'tblSTIService_internet_settings
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_internet_settings') " & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTIService_internet_settings](" & _
                 "[INET_Code] [varchar](15) NOT NULL," & _
                 "[INET_ProfileName] [varchar](50) NULL," & _
                 "[INET_User] [text] NULL," & _
                 "[INET_Pwd] [text] NULL," & _
                 "[INET_AutoRemoveFiles] [int] NULL," & _
                 "[FTP_ConnectionTimeout] [int] NULL," & _
                 "[INET_Host] [text] NULL," & _
                 "[FTP_UsePassive] [int] NULL," & _
                 "[FTP_AutoFeat] [int] NULL," & _
                 "[INET_Port] [int] NULL," & _
                 "[INET_UseSSL] [int] NULL," & _
                 "[INET_TLS] [int] NULL," & _
                 "[INET_SPA] [int] NULL," & _
                 "[INET_Type] [int] NULL," & _
                 "[SMTP_SenderEmail] [text] NULL," & _
                 "[EMAIL_TYPE] [int] NULL," & _
                 "[DateUpdated] [datetime] NULL," & _
                 "CONSTRAINT [PK_tblSTIService_internet_settings] PRIMARY KEY CLUSTERED " & _
                 "(" & _
                        "[INET_Code] Asc " & _
                 ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & _
                 ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
        'tblSTIService_profile
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_profile')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTIService_profile](" & _
                 "[PROF_Code] [varchar](15) NOT NULL," & _
                 "[PROF_Name] [varchar](50) NULL," & _
                 "[PROF_Comment] [text] NULL," & _
                 "[PROF_ExpFolder] [varchar](100) NULL," & _
                 "[DateUpdated] [datetime] NULL," & _
                 "CONSTRAINT [PK_tblSTIService_profile] PRIMARY KEY CLUSTERED" & _
                 "(" & _
                        "[PROF_Code] Asc " & _
                 ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & _
                 ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
        'tblSTIService_schedule
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_schedule')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTIService_schedule](" & _
                 "[SCHED_Code] [varchar](15) NOT NULL," & _
                 "[SCHED_Name] [varchar](50) NULL," & _
                 "[SCHED_Type] [varchar](50) NULL," & _
                 "[SCHED_Action] [varchar](15) NULL," & _
                 "[SCHED_LastRun] [varchar](50) NULL," & _
                 "[SCHED_LastRunStatus] [varchar](50) NULL," & _
                 "[SCHED_LastRunResult] [varchar](50) NULL," & _
                 "[SCHED_NextRun] [datetime] NULL," & _
                 "[SCHED_StartTime] [datetime] NULL," & _
                 "[SCHED_Days] [int] NULL," & _
                 "[SCHED_RunBefore] [varchar](50) NULL," & _
                 "[SCHED_RunAfter] [varchar](50) NULL," & _
                 "[SCHED_Active] [int] NULL," & _
                 "[SCHED_Internet_FTP_Profile] [varchar](15) NULL," & _
                 "[SCHED_Internet_FTP_Folder] [varchar](100) NULL," & _
                 "[SCHED_IncludePics] [int] NULL," & _
                 "[SCHED_Internet_Email_Profile] [varchar](50) NULL," & _
                 "[DateUpdated] [datetime] NULL," & _
                 "CONSTRAINT [PK_tblSTIService_schedule] PRIMARY KEY CLUSTERED " & _
                 "(" & _
                        "[SCHED_Code] Asc " & _
                 ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & _
                 ") ON [PRIMARY]")
        'tblSTIService_Schema
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_Schema')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTIService_Schema](" & _
                 "[ID] [int] IDENTITY(1,1) NOT NULL," & _
                 "[AppName] [varchar](50) NULL," & _
                 "[SchemaName] [varchar](50) NULL," & _
                 "[AllowRestore] [int] NULL," & _
                 "CONSTRAINT [PK_tblSTIService_Schema] PRIMARY KEY CLUSTERED " & _
                 "(" & _
                        "[ID] Asc " & _
                 ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & _
                 ") ON [PRIMARY]")
        'tblSTIService_transfers
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTIService_transfers')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTIService_transfers](" & _
                 "[Transfer_Code] [varchar](15) NOT NULL," & _
                 "[INET_Code] [varchar](15) NULL," & _
                 "[SCHED_Code] [varchar](15) NULL," & _
                 "[NextRun] [datetime] NULL," & _
                 "[SendOrReceive] [int] NULL," & _
                 "[DataFile] [varchar](100) NULL," & _
                 "[RemoteFolder] [varchar](100) NULL," & _
                 "[MainLog] [text] NULL," & _
                 "[DataFileRelation] [text] NULL," & _
                 "[TransferStatus] [int] NULL," & _
                 "[LastStatus] [varchar](100) NULL," & _
                 "CONSTRAINT [PK_tblSTIService_transfers] PRIMARY KEY CLUSTERED" & _
                 "(" & _
                        "[Transfer_Code] Asc " & _
                 ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" & _
                 ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")

        'table licensing purposes
        'tblSTI
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTI')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTI](" & _
                 "[LID] [bigint] IDENTITY(1,1) NOT NULL," & _
                 "[LAppName] [varchar](max) NULL," & _
                 "[LType] [varchar](max) NULL," & _
                 "[LNoUsers] [varchar](max) NULL," & _
                 "[LExp] [varchar](max) NULL," & _
                 "[LHID] [varchar](max) NULL," & _
                 "[LLocID] [varchar](max) NULL," & _
                 "[LSKey] [varchar](max) NULL," & _
                 "[LGPeriod] [varchar](max) NULL," & _
                 "[LNum] [varchar](max) NULL," & _
                 "[LValid] [varchar](max) NULL," & _
                 "[LGen] [varchar](max) NULL," & _
                 "[LStat] [varchar](max) NULL," & _
                 "[LMsg] [varchar](max) NULL," & _
                 "[LRem] [varchar](max) NULL," & _
                 "[DateUpdated] [datetime] NULL," & _
                 "CONSTRAINT [PK_tblSTI] PRIMARY KEY CLUSTERED" & _
                 "(" & _
                        "[LID] Asc " & _
                 ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" & _
                 ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")

        'tblSTILog
        sqls.Add("IF NOT EXISTS (SELECT * FROM STIAPPVERSIONS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='tblSTILog')" & _
                 "CREATE TABLE [STIAPPVERSIONS].[dbo].[tblSTILog](" & _
                 "[LogId] [bigint] IDENTITY(1,1) NOT NULL," & _
                 "[LogMsg] [varchar](max) NULL," & _
                 "[LoggedBy] [varchar](100) NULL," & _
                 "[LogHID] [varchar](100) NULL," & _
                 "[LoggedDateTime] [datetime] NULL," & _
                 "[DateCreated] [datetime] NULL," & _
                 "[App_Name] [varchar](50) NULL," & _
                 "CONSTRAINT [PK_tblStiLog] PRIMARY KEY CLUSTERED" & _
                 "(" & _
                        "[LogId] Asc " & _
                 ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]" & _
                 ") ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")
        'end table licensing purposes


        'add default values

        'sqls.Add("IF NOT EXISTS (SELECT * FROM [STIAPPVERSIONS].[dbo].[tblSTIService_profile] WHERE [PROF_Code] = '" & IMEX_CODE & "') INSERT INTO [STIAPPVERSIONS].[dbo].[tblSTIService_profile]([PROF_Code],[PROF_Name]) VALUES('" & IMEX_CODE & "','" & IMEX_NAME & "')")
        'sqls.Add("IF NOT EXISTS (SELECT * FROM [STIAPPVERSIONS].[dbo].[tblSTIService_schedule] WHERE [SCHED_Code] = '" & IMEX_CODE & "') INSERT INTO [STIAPPVERSIONS].[dbo].[tblSTIService_schedule]([SCHED_Code],[SCHED_Name],[SCHED_Type],[SCHED_Action],[SCHED_Active],[SCHED_StartTime],[SCHED_NextRun]) VALUES('" & IMEX_CODE & "','" & IMEX_NAME & "','2','" & IMEX_CODE & "',0,GETDATE(),GETDATE())")

        'add schema names
        sqls.Add("IF NOT EXISTS (SELECT * FROM [STIAPPVERSIONS].[dbo].[tblSTIService_Schema] WHERE [AppName] = 'MPS5' AND [SchemaName]='MPS') INSERT INTO [STIAPPVERSIONS].[dbo].[tblSTIService_Schema]([AppName],[SchemaName],[AllowRestore]) VALUES('MPS5','MPS',1)")
        sqls.Add("IF NOT EXISTS (SELECT * FROM [STIAPPVERSIONS].[dbo].[tblSTIService_Schema] WHERE [AppName] = 'MPS5' AND [SchemaName]='MPSARC') INSERT INTO [STIAPPVERSIONS].[dbo].[tblSTIService_Schema]([AppName],[SchemaName],[AllowRestore]) VALUES('MPS5','MPSARC',1)")
        sqls.Add("IF NOT EXISTS (SELECT * FROM [STIAPPVERSIONS].[dbo].[tblSTIService_Schema] WHERE [AppName] = 'MPS5' AND [SchemaName]='MPS4A') INSERT INTO [STIAPPVERSIONS].[dbo].[tblSTIService_Schema]([AppName],[SchemaName],[AllowRestore]) VALUES('MPS5','MPS4A',1)")
        sqls.Add("IF NOT EXISTS (SELECT * FROM [STIAPPVERSIONS].[dbo].[tblSTIService_Schema] WHERE [AppName] = 'APPSETTINGS' AND [SchemaName]='STIAPPVERSIONS') INSERT INTO [STIAPPVERSIONS].[dbo].[tblSTIService_Schema]([AppName],[SchemaName],[AllowRestore]) VALUES('APPSETTINGS','STIAPPVERSIONS',0)")
       
        DB.RunSqls(sqls)
    End Sub
End Module
