USE [master]
GO
/****** Object:  Database [StudentInfoDb]    Script Date: 31-03-2020 3.54.48 PM ******/
CREATE DATABASE [StudentInfoDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StudentInfoDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\StudentInfoDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StudentInfoDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\StudentInfoDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [StudentInfoDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StudentInfoDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StudentInfoDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StudentInfoDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StudentInfoDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StudentInfoDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StudentInfoDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [StudentInfoDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StudentInfoDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StudentInfoDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StudentInfoDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StudentInfoDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StudentInfoDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StudentInfoDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StudentInfoDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StudentInfoDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StudentInfoDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StudentInfoDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StudentInfoDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StudentInfoDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StudentInfoDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StudentInfoDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StudentInfoDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StudentInfoDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StudentInfoDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StudentInfoDb] SET  MULTI_USER 
GO
ALTER DATABASE [StudentInfoDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StudentInfoDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StudentInfoDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StudentInfoDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StudentInfoDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StudentInfoDb] SET QUERY_STORE = OFF
GO
USE [StudentInfoDb]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 31-03-2020 3.54.50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NOT NULL,
	[StudentEmailId] [varchar](50) NOT NULL,
	[StudentMobileNumber] [varchar](10) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 31-03-2020 3.54.50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
	[CourseFee] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrolls]    Script Date: 31-03-2020 3.54.50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrolls](
	[EnrollId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[FeeStatus] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Enrolls] PRIMARY KEY CLUSTERED 
(
	[EnrollId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vEnroll]    Script Date: 31-03-2020 3.54.50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vEnroll]
AS
SELECT dbo.Students.StudentId, dbo.Students.StudentName, dbo.Courses.CourseName, dbo.Courses.CourseFee, dbo.Enrolls.FeeStatus
FROM     dbo.Students INNER JOIN
                  dbo.Enrolls ON dbo.Students.StudentId = dbo.Enrolls.StudentId INNER JOIN
                  dbo.Courses ON dbo.Enrolls.CourseId = dbo.Courses.CourseId
GO
ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_Enrolls_Courses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO
ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_Enrolls_Courses]
GO
ALTER TABLE [dbo].[Enrolls]  WITH CHECK ADD  CONSTRAINT [FK_Enrolls_Students] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([StudentId])
GO
ALTER TABLE [dbo].[Enrolls] CHECK CONSTRAINT [FK_Enrolls_Students]
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
         Begin Table = "Students"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 295
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Courses"
            Begin Extent = 
               Top = 7
               Left = 343
               Bottom = 148
               Right = 537
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Enrolls"
            Begin Extent = 
               Top = 7
               Left = 585
               Bottom = 170
               Right = 779
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vEnroll'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vEnroll'
GO
USE [master]
GO
ALTER DATABASE [StudentInfoDb] SET  READ_WRITE 
GO
