USE [master]
GO
/****** Object:  Database [VGTBD]    Script Date: 31.08.2020 14:08:28 ******/
CREATE DATABASE [VGTBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VGTBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VGTBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VGTBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\VGTBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VGTBD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VGTBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VGTBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VGTBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VGTBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VGTBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VGTBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [VGTBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VGTBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VGTBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VGTBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VGTBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VGTBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VGTBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VGTBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VGTBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VGTBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VGTBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VGTBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VGTBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VGTBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VGTBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VGTBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VGTBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VGTBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VGTBD] SET  MULTI_USER 
GO
ALTER DATABASE [VGTBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VGTBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VGTBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VGTBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VGTBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VGTBD] SET QUERY_STORE = OFF
GO
USE [VGTBD]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 31.08.2020 14:08:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [Users_PK] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Users] ([UserId], [Login], [Password], [Email]) VALUES (N'a1175c61-c7b4-40fd-ad8f-23acb855b1a6', N'TestLogin3', N'TestPassword', N'TestEmail3')
INSERT [dbo].[Users] ([UserId], [Login], [Password], [Email]) VALUES (N'0d878804-bc73-4901-8add-45971b0db2d6', N'TestLogin', N'TestPassword', N'TestEmail')
INSERT [dbo].[Users] ([UserId], [Login], [Password], [Email]) VALUES (N'51d25ea3-9341-4da7-846d-6381e624f0df', N'TestLogin2', N'TestPassword', N'TestEmail2')
INSERT [dbo].[Users] ([UserId], [Login], [Password], [Email]) VALUES (N'e989eb10-2958-4ea6-9f2e-9164da782345', N'Alex', N'2025', N'Testmailru')
INSERT [dbo].[Users] ([UserId], [Login], [Password], [Email]) VALUES (N'9aff4fc8-c6ce-4c2a-bbb9-ebd9b85a3277', N'Iregorik', N'2020', N'Testmailru2')
USE [master]
GO
ALTER DATABASE [VGTBD] SET  READ_WRITE 
GO
