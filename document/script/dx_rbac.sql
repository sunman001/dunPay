USE [dun_base]
GO
/****** Object:  Table [dbo].[DxModule]    Script Date: 2017/11/24 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DxModule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentifyCode] [nvarchar](20) NULL,
	[Name] [nvarchar](80) NULL,
	[Code] [nvarchar](80) NULL,
	[ParentIdentifyCode] [nvarchar](20) NULL,
	[RequestUrl] [nvarchar](255) NULL,
	[Icon] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[ChildCount] [int] NULL,
	[ChildLevel] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [int] NULL,
	[CreatedByUserName] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedByUserName] [nvarchar](50) NULL,
	[PlatformId] [int] NULL,
	[PlatformName] [nvarchar](50) NULL,
	[IsEnabled] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_DxModule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DxModuleAction]    Script Date: 2017/11/24 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DxModuleAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ModuleIdentifyCode] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[IsEnabled] [bit] NULL,
	[Sort] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_DxModuleAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DxPermission]    Script Date: 2017/11/24 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DxPermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentifyCode] [nvarchar](20) NOT NULL,
	[ModuleIdentifyCode] [nvarchar](20) NOT NULL,
	[RoleIdentifyCode] [nvarchar](50) NOT NULL,
	[IsEnabled] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_DxModuleRoleMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DxPermissionAction]    Script Date: 2017/11/24 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DxPermissionAction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PermissionIdentifyCode] [nvarchar](20) NULL,
	[Code] [nvarchar](80) NULL,
	[IsEnabled] [bit] NULL,
 CONSTRAINT [PK_DxPermissionAction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DxRole]    Script Date: 2017/11/24 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DxRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdentifyCode] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[IsBuiltin] [bit] NULL,
	[Description] [nvarchar](255) NULL,
	[PlatformId] [int] NULL,
	[PlatformName] [nvarchar](50) NULL,
	[IsEnabled] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_DxRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DxUserRoleMapping]    Script Date: 2017/11/24 17:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DxUserRoleMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleIdentifyCode] [nvarchar](20) NULL,
	[UserId] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedByUserId] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_DxUserRoleMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DxModule] ON 

INSERT [dbo].[DxModule] ([Id], [IdentifyCode], [Name], [Code], [ParentIdentifyCode], [RequestUrl], [Icon], [Sort], [ChildCount], [ChildLevel], [Description], [CreatedOn], [CreatedByUserId], [CreatedByUserName], [ModifiedOn], [ModifiedByUserName], [PlatformId], [PlatformName], [IsEnabled], [IsDeleted]) VALUES (1, N'mEs5xWqN8', N'首页', N'1_HOME', N'0', N'home/index', N'', 0, 0, 0, N'', CAST(N'2017-11-13T10:07:04.183' AS DateTime), 0, N'', NULL, NULL, 1, N'运营', 1, 0)
SET IDENTITY_INSERT [dbo].[DxModule] OFF
SET IDENTITY_INSERT [dbo].[DxModuleAction] ON 

INSERT [dbo].[DxModuleAction] ([Id], [ModuleIdentifyCode], [Name], [Code], [IsEnabled], [Sort], [CreatedOn], [CreatedByUserId], [CreatedBy]) VALUES (1, N'mEs5xWqN8', N'浏览', N'VIEW', 1, 0, CAST(N'2017-11-13T10:11:31.060' AS DateTime), 0, N'')
SET IDENTITY_INSERT [dbo].[DxModuleAction] OFF
SET IDENTITY_INSERT [dbo].[DxPermission] ON 

INSERT [dbo].[DxPermission] ([Id], [IdentifyCode], [ModuleIdentifyCode], [RoleIdentifyCode], [IsEnabled], [CreatedOn], [CreatedByUserId], [CreatedBy]) VALUES (1, N'pUs5xWqN8', N'mEs5xWqN8', N'rUs5xWqk6', 1, CAST(N'2017-11-13T10:13:54.747' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [dbo].[DxPermission] OFF
SET IDENTITY_INSERT [dbo].[DxPermissionAction] ON 

INSERT [dbo].[DxPermissionAction] ([Id], [PermissionIdentifyCode], [Code], [IsEnabled]) VALUES (1, N'pUs5xWqN8', N'VIEW', 1)
SET IDENTITY_INSERT [dbo].[DxPermissionAction] OFF
SET IDENTITY_INSERT [dbo].[DxRole] ON 

INSERT [dbo].[DxRole] ([Id], [IdentifyCode], [Name], [CreatedOn], [CreatedByUserId], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsBuiltin], [Description], [PlatformId], [PlatformName], [IsEnabled], [IsDeleted]) VALUES (1, N'rUs5xWqk6', N'管理员', CAST(N'2017-11-13T10:13:20.513' AS DateTime), 0, N'', NULL, N'', 1, N'', 1, N'运营', 1, 0)
SET IDENTITY_INSERT [dbo].[DxRole] OFF
SET IDENTITY_INSERT [dbo].[DxUserRoleMapping] ON 

INSERT [dbo].[DxUserRoleMapping] ([Id], [RoleIdentifyCode], [UserId], [CreatedOn], [CreatedByUserId], [CreatedBy]) VALUES (1, N'rUs5xWqk6', 1, CAST(N'2017-11-13T10:12:58.857' AS DateTime), 0, N'')
SET IDENTITY_INSERT [dbo].[DxUserRoleMapping] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DxModule_IdentifyCode]    Script Date: 2017/11/24 17:51:38 ******/
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [IX_DxModule_IdentifyCode] UNIQUE NONCLUSTERED 
(
	[IdentifyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DxPermission_IdentifyCode]    Script Date: 2017/11/24 17:51:38 ******/
ALTER TABLE [dbo].[DxPermission] ADD  CONSTRAINT [IX_DxPermission_IdentifyCode] UNIQUE NONCLUSTERED 
(
	[IdentifyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DxRole_IdentifyCode]    Script Date: 2017/11/24 17:51:38 ******/
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [IX_DxRole_IdentifyCode] UNIQUE NONCLUSTERED 
(
	[IdentifyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_No]  DEFAULT ('') FOR [IdentifyCode]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_ParentCode]  DEFAULT ('') FOR [ParentIdentifyCode]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_Url]  DEFAULT ('') FOR [RequestUrl]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_Icon]  DEFAULT ('') FOR [Icon]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_Sort]  DEFAULT ((0)) FOR [Sort]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_ChildCount]  DEFAULT ((0)) FOR [ChildCount]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_ChildLevel]  DEFAULT ((0)) FOR [ChildLevel]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_CreatedByUserId]  DEFAULT ((0)) FOR [CreatedByUserId]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_CreatedByUserName]  DEFAULT ('') FOR [CreatedByUserName]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_PlatformId]  DEFAULT ((0)) FOR [PlatformId]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_PlatformName]  DEFAULT ('') FOR [PlatformName]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[DxModule] ADD  CONSTRAINT [DF_DxModule_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[DxModuleAction] ADD  CONSTRAINT [DF_DxModuleAction_ModuleCode]  DEFAULT ('') FOR [ModuleIdentifyCode]
GO
ALTER TABLE [dbo].[DxModuleAction] ADD  CONSTRAINT [DF_DxModuleAction_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[DxModuleAction] ADD  CONSTRAINT [DF_DxModuleAction_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[DxModuleAction] ADD  CONSTRAINT [DF_DxModuleAction_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[DxModuleAction] ADD  CONSTRAINT [DF_DxModuleAction_Sort]  DEFAULT ((0)) FOR [Sort]
GO
ALTER TABLE [dbo].[DxModuleAction] ADD  CONSTRAINT [DF_DxModuleAction_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[DxModuleAction] ADD  CONSTRAINT [DF_DxModuleAction_CreatedByUserId]  DEFAULT ((0)) FOR [CreatedByUserId]
GO
ALTER TABLE [dbo].[DxModuleAction] ADD  CONSTRAINT [DF_DxModuleAction_CreatedBy]  DEFAULT ('') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[DxPermission] ADD  CONSTRAINT [DF_DxPermission_IdentifyCode]  DEFAULT ('') FOR [IdentifyCode]
GO
ALTER TABLE [dbo].[DxPermission] ADD  CONSTRAINT [DF_DxModuleRoleMapping_ModuleCode]  DEFAULT ('') FOR [ModuleIdentifyCode]
GO
ALTER TABLE [dbo].[DxPermission] ADD  CONSTRAINT [DF_DxModuleRoleMapping_RoleCode]  DEFAULT ('') FOR [RoleIdentifyCode]
GO
ALTER TABLE [dbo].[DxPermission] ADD  CONSTRAINT [DF_DxModuleRoleMapping_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[DxPermission] ADD  CONSTRAINT [DF_DxModuleRoleMapping_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[DxPermission] ADD  CONSTRAINT [DF_DxPermission_CreatedByUserId]  DEFAULT ((0)) FOR [CreatedByUserId]
GO
ALTER TABLE [dbo].[DxPermissionAction] ADD  CONSTRAINT [DF_DxPermissionAction_PermissionId]  DEFAULT ('') FOR [PermissionIdentifyCode]
GO
ALTER TABLE [dbo].[DxPermissionAction] ADD  CONSTRAINT [DF_DxPermissionAction_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[DxPermissionAction] ADD  CONSTRAINT [DF_DxPermissionAction_IsEnabled]  DEFAULT ((0)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_IdentifyCode]  DEFAULT ('') FOR [IdentifyCode]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_Name]  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_CreatedAt]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_CreatedByUserId]  DEFAULT ((0)) FOR [CreatedByUserId]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_CreatedByUserName]  DEFAULT ('') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_ModifiedByUserName]  DEFAULT ('') FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_IsBuiltin]  DEFAULT ((0)) FOR [IsBuiltin]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_Description]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_PlatformId]  DEFAULT ((0)) FOR [PlatformId]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_PlatformName]  DEFAULT ('') FOR [PlatformName]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO
ALTER TABLE [dbo].[DxRole] ADD  CONSTRAINT [DF_DxRole_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[DxUserRoleMapping] ADD  CONSTRAINT [DF_DxUserRoleMapping_RoleId]  DEFAULT ('') FOR [RoleIdentifyCode]
GO
ALTER TABLE [dbo].[DxUserRoleMapping] ADD  CONSTRAINT [DF_DxUserRoleMapping_UserId]  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[DxUserRoleMapping] ADD  CONSTRAINT [DF_DxUserRoleMapping_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[DxUserRoleMapping] ADD  CONSTRAINT [DF_DxUserRoleMapping_CreatedByUserId]  DEFAULT ((0)) FOR [CreatedByUserId]
GO
ALTER TABLE [dbo].[DxUserRoleMapping] ADD  CONSTRAINT [DF_DxUserRoleMapping_CreatedBy]  DEFAULT ('') FOR [CreatedBy]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块惟一标识码[由系统自动生成,不能重复]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'IdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块编码[平台内的编码不能重复]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父节点识别码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'ParentIdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'RequestUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序[从小到大]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子节点数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'ChildCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单级数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'ChildLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'CreatedOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'CreatedByUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'CreatedByUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'ModifiedOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'PlatformId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'PlatformName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用[0:否,1:是],默认值:1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已被删除[0:否,1:是],默认值:0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块惟一标识码[关联DxModule表]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction', @level2type=N'COLUMN',@level2name=N'ModuleIdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序[从小到大]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction', @level2type=N'COLUMN',@level2name=N'CreatedOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction', @level2type=N'COLUMN',@level2name=N'CreatedByUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction', @level2type=N'COLUMN',@level2name=N'CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块-操作信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxModuleAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限惟一识别码[由系统自动生成,不能重复]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission', @level2type=N'COLUMN',@level2name=N'IdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块惟一标识码[关联DxModule表]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission', @level2type=N'COLUMN',@level2name=N'ModuleIdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission', @level2type=N'COLUMN',@level2name=N'RoleIdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission', @level2type=N'COLUMN',@level2name=N'CreatedOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission', @level2type=N'COLUMN',@level2name=N'CreatedByUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission', @level2type=N'COLUMN',@level2name=N'CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块-角色关系映射表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermission'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限识别码,关联[DxPermission]表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermissionAction', @level2type=N'COLUMN',@level2name=N'PermissionIdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermissionAction', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermissionAction', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限-操作关系映射表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxPermissionAction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色惟一识别码[由系统自动生成,不能重复]' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'IdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'CreatedOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'CreatedByUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'ModifiedOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最近修改者姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'ModifiedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否为系统内置[0:否,1:是],默认值:0,如果是系统内置,则不允许删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'IsBuiltin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'PlatformId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'PlatformName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用[0:否,1:是],默认值:1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'IsEnabled'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否已被删除[0:否,1:是],默认值:0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxUserRoleMapping', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色识别码,关联[DxRole]表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxUserRoleMapping', @level2type=N'COLUMN',@level2name=N'RoleIdentifyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxUserRoleMapping', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxUserRoleMapping', @level2type=N'COLUMN',@level2name=N'CreatedOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxUserRoleMapping', @level2type=N'COLUMN',@level2name=N'CreatedByUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建者姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxUserRoleMapping', @level2type=N'COLUMN',@level2name=N'CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户-角色关系映射表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DxUserRoleMapping'
GO
