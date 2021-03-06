USE [master]
GO
/****** Object:  Database [ProjectManagerDB]    Script Date: 07-12-2018 23:07:51 ******/
CREATE DATABASE [ProjectManagerDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectManagerDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProjectManagerDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectManagerDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ProjectManagerDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectManagerDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectManagerDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectManagerDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectManagerDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectManagerDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectManagerDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectManagerDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectManagerDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectManagerDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectManagerDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectManagerDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectManagerDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectManagerDB', N'ON'
GO
USE [ProjectManagerDB]
GO
/****** Object:  StoredProcedure [dbo].[GetProjecTask]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[GetProjecTask]
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @completedtask TABLE (projectid int,status bit)
INSERT  INTO @completedtask (projectid, status)
       select p. Project_ID,count(t.Status) as completedtask  from Task t 
 inner join  project p on t.Project_ID = p.Project_ID where t.Status =1 group by p.Project_ID,t.Status

SELECT p.[Project_ID],[ProjectName],p.[Start_Date],p.[End_Date],p.[Priority],COUNT(t.TaskName)as NoofTasks,count(c.status) as completedtask
  FROM [dbo].[Project] p 
       inner join Task t on p.Project_ID = t.Project_ID
	   left join @completedtask c on c.projectid= p.Project_ID
	    group by p.Project_ID,p.ProjectName,p.Priority,p.Start_Date,p.End_Date,c.status
END

GO
/****** Object:  StoredProcedure [dbo].[GetProjectReport]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProjectReport]
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @completedtask TABLE (projectid int,status bit)
INSERT  INTO @completedtask (projectid, status)
       select p. Project_ID,count(t.Status) as completedtask  from Task t 
 inner join  project p on t.Project_ID = p.Project_ID where t.Status =1 group by p.Project_ID,t.Status

SELECT p.[Project_ID],[ProjectName],p.[Start_Date],p.[End_Date],p.[Priority],COUNT(t.TaskName)as NoofTasks,count(c.status) as completedtask
  FROM [dbo].[Project] p 
       inner join Task t on p.Project_ID = t.Project_ID
	   left join @completedtask c on c.projectid= p.Project_ID
	    group by p.Project_ID,p.ProjectName,p.Priority,p.Start_Date,p.End_Date,c.status
END

GO
/****** Object:  StoredProcedure [dbo].[GetProjects]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetProjects]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

SELECT [Project_ID]
      ,ProjectName
      ,[Start_Date]
      ,[End_Date]
      ,[Priority]
      ,[Status]
  FROM [dbo].[Project]



END


GO
/****** Object:  StoredProcedure [dbo].[GetTaskDetails]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTaskDetails]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	
SELECT [Task_ID],[TaskName],Parent_Task,[Start_Date],[End_Date],[Priority] FROM [dbo].[Task] t
inner join ParentTask pt on pt.Parent_ID = t.Parent_ID



END



GO
/****** Object:  StoredProcedure [dbo].[GetTasks]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTasks]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


SELECT [Task_ID]
      ,[Parent_ID]
      ,[Project_ID]
      ,[TaskName]
      ,[Start_Date]
      ,[End_Date]
      ,[Priority]
      ,[Status]
  FROM [dbo].[Task]


END

GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetUsers]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT [userId]
      ,[firstName]
      ,[lastName]
      ,[employeeId]
      
  FROM [dbo].[User]



END


GO
/****** Object:  Table [dbo].[ParentTask]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParentTask](
	[Parent_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Task] [varchar](100) NULL,
 CONSTRAINT [PK_ParentTask] PRIMARY KEY CLUSTERED 
(
	[Parent_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[Project_ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](100) NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Priority] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Task]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Task](
	[Task_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_ID] [int] NULL,
	[Project_ID] [int] NULL,
	[TaskName] [varchar](100) NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[Priority] [int] NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 07-12-2018 23:07:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](100) NULL,
	[lastName] [varchar](100) NULL,
	[employeeId] [int] NULL,
	[projectId] [int] NULL,
	[taskId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ParentTask] ON 

INSERT [dbo].[ParentTask] ([Parent_ID], [Parent_Task]) VALUES (1, N'ParentTask1')
INSERT [dbo].[ParentTask] ([Parent_ID], [Parent_Task]) VALUES (2, N'ParentTask2')
SET IDENTITY_INSERT [dbo].[ParentTask] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Project_ID], [ProjectName], [Start_Date], [End_Date], [Priority], [Status]) VALUES (1, N'Project1', CAST(0x0000A9AC00000000 AS DateTime), CAST(0x0000A9BC00000000 AS DateTime), 15, 0)
INSERT [dbo].[Project] ([Project_ID], [ProjectName], [Start_Date], [End_Date], [Priority], [Status]) VALUES (2, N'Project2', CAST(0x0000A9AD00000000 AS DateTime), CAST(0x0000A9AE00000000 AS DateTime), 25, 0)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[Task] ON 

INSERT [dbo].[Task] ([Task_ID], [Parent_ID], [Project_ID], [TaskName], [Start_Date], [End_Date], [Priority], [Status]) VALUES (1, 2, 1, N'Task1', CAST(0x0000A9AD00000000 AS DateTime), CAST(0x0000A9B400000000 AS DateTime), 15, 1)
INSERT [dbo].[Task] ([Task_ID], [Parent_ID], [Project_ID], [TaskName], [Start_Date], [End_Date], [Priority], [Status]) VALUES (2, 2, 2, N'Task2', CAST(0x0000A9AD00000000 AS DateTime), CAST(0x0000A9AE00000000 AS DateTime), 15, 0)
INSERT [dbo].[Task] ([Task_ID], [Parent_ID], [Project_ID], [TaskName], [Start_Date], [End_Date], [Priority], [Status]) VALUES (3, 2, 2, N'Task3', CAST(0x0000A9AD00000000 AS DateTime), CAST(0x0000A9AE00000000 AS DateTime), 15, 0)
INSERT [dbo].[Task] ([Task_ID], [Parent_ID], [Project_ID], [TaskName], [Start_Date], [End_Date], [Priority], [Status]) VALUES (4, 1, 1, N'Task4', CAST(0x0000A9AD00000000 AS DateTime), CAST(0x0000A9AE00000000 AS DateTime), 15, 0)
SET IDENTITY_INSERT [dbo].[Task] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([userId], [firstName], [lastName], [employeeId], [projectId], [taskId]) VALUES (1, N'Bapiraju', N'Uddaraju', 227004, 2, 4)
INSERT [dbo].[User] ([userId], [firstName], [lastName], [employeeId], [projectId], [taskId]) VALUES (2, N'Ajay', N'Abbaraju', 227005, 1, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Project] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Task] ADD  DEFAULT ((0)) FOR [Status]
GO
USE [master]
GO
ALTER DATABASE [ProjectManagerDB] SET  READ_WRITE 
GO
