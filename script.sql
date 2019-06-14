USE [master]
GO
/****** Object:  Database [CourseResultDB]    Script Date: 6/12/2019 11:50:51 PM ******/
CREATE DATABASE [CourseResultDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CourseResultDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CourseResultDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CourseResultDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CourseResultDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CourseResultDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CourseResultDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CourseResultDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CourseResultDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CourseResultDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CourseResultDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CourseResultDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CourseResultDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CourseResultDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CourseResultDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CourseResultDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CourseResultDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CourseResultDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CourseResultDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CourseResultDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CourseResultDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CourseResultDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CourseResultDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CourseResultDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CourseResultDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CourseResultDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CourseResultDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CourseResultDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CourseResultDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CourseResultDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CourseResultDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CourseResultDB] SET  MULTI_USER 
GO
ALTER DATABASE [CourseResultDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CourseResultDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CourseResultDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CourseResultDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CourseResultDB]
GO
/****** Object:  Table [dbo].[AllocateClassroom]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AllocateClassroom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[FromTime] [varchar](50) NOT NULL,
	[ToTime] [varchar](50) NOT NULL,
	[Allocate] [varchar](50) NOT NULL,
	[Day] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AllocateClassroom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [decimal](3, 2) NOT NULL,
	[SemesterId] [int] NOT NULL,
	[Description] [varchar](100) NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseAssignTeacher]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseAssignTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Assign] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CourseAssignTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollCourse]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EnrollCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Grade] [varchar](50) NULL,
	[Assign] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EnrollCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](5) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [varchar](50) NULL,
	[DepartmentId] [int] NOT NULL,
	[RegNo] [varchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](100) NULL,
	[Email] [varchar](50) NULL,
	[ContactNumber] [varchar](15) NOT NULL,
	[CreditToBeTaken] [decimal](18, 2) NOT NULL,
	[RemainingCredit] [decimal](18, 2) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[CourseStaticView]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CourseStaticView]
AS
SELECT        c.Code, c.Name, s.Name AS Semester, t.Name AS AssignedTo, c.DepartmentId, cat.Assign
FROM            dbo.Course AS c INNER JOIN
                         dbo.CourseAssignTeacher AS cat ON c.Id = cat.CourseId INNER JOIN
                         dbo.Semester AS s ON c.SemesterId = s.Id INNER JOIN
                         dbo.Teacher AS t ON t.Id = cat.TeacherId

GO
/****** Object:  View [dbo].[CourseView]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CourseView]
as
SELECT        c.Code, c.Name, s.Name AS Semester, t.Name AS AssignedTo, c.DepartmentId, cat.Assign
FROM            dbo.Course AS c LEFT OUTER JOIN
                         dbo.CourseAssignTeacher AS cat ON c.Id = cat.CourseId LEFT OUTER JOIN
                         dbo.Semester AS s ON c.SemesterId = s.Id LEFT OUTER JOIN
                         dbo.Teacher AS t ON t.Id = cat.TeacherId
GO
/****** Object:  View [dbo].[StudentResultView]    Script Date: 6/12/2019 11:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentResultView]
as
SELECT c.Code, c.Name, sr.Grade FROM Course as c FULL JOIN EnrollCourse as ec on c.Id = ec.CourseId 
FULL JOIN StudentsResult as sr on c.Id = sr.CourseId
GO
SET IDENTITY_INSERT [dbo].[AllocateClassroom] ON 

INSERT [dbo].[AllocateClassroom] ([Id], [DepartmentId], [CourseId], [RoomId], [FromTime], [ToTime], [Allocate], [Day]) VALUES (8, 2017, 2004, 2, N'600', N'720', N'no', N'Sun')
INSERT [dbo].[AllocateClassroom] ([Id], [DepartmentId], [CourseId], [RoomId], [FromTime], [ToTime], [Allocate], [Day]) VALUES (9, 2018, 2007, 10, N'600', N'720', N'no', N'Thu')
SET IDENTITY_INSERT [dbo].[AllocateClassroom] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [SemesterId], [Description], [DepartmentId]) VALUES (2004, N'CSE-101', N'Computer Fundamental', CAST(3.00 AS Decimal(3, 2)), 1, N'Basic', 2017)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [SemesterId], [Description], [DepartmentId]) VALUES (2005, N'CSE-102', N'C Programming', CAST(3.00 AS Decimal(3, 2)), 2, N'Basic', 2017)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [SemesterId], [Description], [DepartmentId]) VALUES (2006, N'EEE-101', N'EEE 1', CAST(3.00 AS Decimal(3, 2)), 1, N'EEE 1 ', 2018)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [SemesterId], [Description], [DepartmentId]) VALUES (2007, N'EEE 2', N'EEE 2', CAST(3.00 AS Decimal(3, 2)), 2, N'EEE 2', 2018)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseAssignTeacher] ON 

INSERT [dbo].[CourseAssignTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assign]) VALUES (1, 2017, 1003, 2004, N'no')
INSERT [dbo].[CourseAssignTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assign]) VALUES (2, 2017, 1003, 2004, N'no')
INSERT [dbo].[CourseAssignTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assign]) VALUES (3, 2017, 1003, 2004, N'no')
INSERT [dbo].[CourseAssignTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assign]) VALUES (4, 2018, 1004, 2006, N'no')
INSERT [dbo].[CourseAssignTeacher] ([Id], [DepartmentId], [TeacherId], [CourseId], [Assign]) VALUES (1003, 2017, 1003, 2004, N'1')
SET IDENTITY_INSERT [dbo].[CourseAssignTeacher] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2017, N'CSE ', N'Computer Science & Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2018, N'EEE', N'Electrical & Electronics Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (3018, N'', N'')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (1, N'Professor')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (2, N'Associate Professor')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (3, N'Assistant Professor')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (4, N'Lecturer')
INSERT [dbo].[Designation] ([Id], [Designation]) VALUES (5, N'Assistant Lecturer')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollCourse] ON 

INSERT [dbo].[EnrollCourse] ([Id], [CourseId], [Date], [StudentId], [Grade], [Assign]) VALUES (2005, 2004, CAST(0xB13F0B00 AS Date), 3011, N'A+', N'no')
INSERT [dbo].[EnrollCourse] ([Id], [CourseId], [Date], [StudentId], [Grade], [Assign]) VALUES (2006, 2005, CAST(0xB23F0B00 AS Date), 3011, NULL, N'no')
INSERT [dbo].[EnrollCourse] ([Id], [CourseId], [Date], [StudentId], [Grade], [Assign]) VALUES (2007, 2004, CAST(0xB13F0B00 AS Date), 3013, N'B', N'no')
INSERT [dbo].[EnrollCourse] ([Id], [CourseId], [Date], [StudentId], [Grade], [Assign]) VALUES (2008, 2006, CAST(0x243F0B00 AS Date), 3015, NULL, N'no')
SET IDENTITY_INSERT [dbo].[EnrollCourse] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (1, N'A-101')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (2, N'A-102')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (3, N'A-103')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (4, N'A-104')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (5, N'A-105')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (6, N'B-101')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (7, N'B-102')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (8, N'B-103')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (9, N'B-104')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (10, N'C-101')
INSERT [dbo].[Room] ([Id], [RoomNo]) VALUES (11, N'C-102')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([Id], [Name]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3002, N'Proma', N'proma@gmail.com', N'0132312312', CAST(0x803F0B00 AS Date), N'CTG', 2017, N'CSE -2019-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3005, N'Kulsuma', N'lubna@gmail.com', N'01323232323', CAST(0x8D3F0B00 AS Date), N'CTG', 2017, N'CSE -2019-002')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3006, N'Shanto', N'shanto@gmail.com', N'34634', CAST(0x70400B00 AS Date), N'CTG', 2017, N'CSE -2019-003')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3007, N'Irfan Monir', N'irfan@gmail.com', N'01323232323', CAST(0xA33F0B00 AS Date), N'', 2017, N'CSE -2019-004')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3008, N'a', N'proma1@gmail.com', N'090', CAST(0x9B3F0B00 AS Date), N'CTG', 2017, N'CSE -2019-005')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3009, N'a', N'a@gmail.com', N'a', CAST(0xA23F0B00 AS Date), N'a', 2017, N'CSE -2019-006')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3010, N'v', N'proma12@gmail.com', N'', CAST(0x8F400B00 AS Date), N'', 2017, N'CSE -2019-007')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3011, N'Arfiz', N'arfiz@gmail.com', N'018', CAST(0xD13D0B00 AS Date), N'Chittagong', 2017, N'CSE -2018-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3012, N'Prity', N'prity@gmail.com', N'0187', CAST(0x8F400B00 AS Date), N'Halishahar', 2017, N'CSE -2019-008')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3013, N'Shazeda', N'shazeda@gmail.com', N'23', CAST(0xA23F0B00 AS Date), N'Chuna factory', 2017, N'CSE -2019-009')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3014, N'x', N'x@gmail.com', N'1', CAST(0x9C3F0B00 AS Date), N'x', 2017, N'CSE -2019-010')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNumber], [Date], [Address], [DepartmentId], [RegNo]) VALUES (3015, N'p', N'p@gmail.com', N'21', CAST(0x8F400B00 AS Date), N'df', 2018, N'EEE-2019-001')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNumber], [CreditToBeTaken], [RemainingCredit], [DesignationId], [DepartmentId]) VALUES (1002, N'Shamima Akter Proma', N'Chittagong', N'shamima.cse007@gmail.com', N'01626737532', CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), 4, 2017)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNumber], [CreditToBeTaken], [RemainingCredit], [DesignationId], [DepartmentId]) VALUES (1003, N'Arfizur Rahman', N'CTG', N'arfiz@gmail.com', N'021', CAST(20.00 AS Decimal(18, 2)), CAST(17.00 AS Decimal(18, 2)), 1, 2017)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNumber], [CreditToBeTaken], [RemainingCredit], [DesignationId], [DepartmentId]) VALUES (1004, N'Md. Kader ', N'ctg', N'kaderctg@gmail.com', N'2343', CAST(20.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), 2, 2018)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [Code_Department_Unique_Key]    Script Date: 6/12/2019 11:50:53 PM ******/
ALTER TABLE [dbo].[Department] ADD  CONSTRAINT [Code_Department_Unique_Key] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CourseAssignTeacher] ADD  CONSTRAINT [DF__CourseAss__Assig__1F63A897]  DEFAULT ((0)) FOR [Assign]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassroom_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_AllocateClassroom_Course]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassroom_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_AllocateClassroom_Department]
GO
ALTER TABLE [dbo].[AllocateClassroom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassroom_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassroom] CHECK CONSTRAINT [FK_AllocateClassroom_Room]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
ALTER TABLE [dbo].[CourseAssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTeacher_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignTeacher] CHECK CONSTRAINT [FK_CourseAssignTeacher_Course]
GO
ALTER TABLE [dbo].[CourseAssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTeacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignTeacher] CHECK CONSTRAINT [FK_CourseAssignTeacher_Department]
GO
ALTER TABLE [dbo].[CourseAssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTeacher_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[CourseAssignTeacher] CHECK CONSTRAINT [FK_CourseAssignTeacher_Teacher]
GO
ALTER TABLE [dbo].[EnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[EnrollCourse] CHECK CONSTRAINT [FK_EnrollCourse_Course]
GO
ALTER TABLE [dbo].[EnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[EnrollCourse] CHECK CONSTRAINT [FK_EnrollCourse_Student]
GO
ALTER TABLE [dbo].[Semester]  WITH CHECK ADD  CONSTRAINT [FK_Semester_Semester] FOREIGN KEY([Id])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Semester] CHECK CONSTRAINT [FK_Semester_Semester]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "cat"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 234
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "t"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 268
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseStaticView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseStaticView'
GO
USE [master]
GO
ALTER DATABASE [CourseResultDB] SET  READ_WRITE 
GO
