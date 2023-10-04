USE [master]
GO
/****** Object:  Database [UserInfo]    Script Date: 4/10/2023 13:02:35 ******/
CREATE DATABASE [UserInfo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UserInfo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\UserInfo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UserInfo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\UserInfo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UserInfo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UserInfo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UserInfo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UserInfo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UserInfo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UserInfo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UserInfo] SET ARITHABORT OFF 
GO
ALTER DATABASE [UserInfo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UserInfo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UserInfo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UserInfo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UserInfo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UserInfo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UserInfo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UserInfo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UserInfo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UserInfo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UserInfo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UserInfo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UserInfo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UserInfo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UserInfo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UserInfo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UserInfo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UserInfo] SET RECOVERY FULL 
GO
ALTER DATABASE [UserInfo] SET  MULTI_USER 
GO
ALTER DATABASE [UserInfo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UserInfo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UserInfo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UserInfo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UserInfo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'UserInfo', N'ON'
GO
ALTER DATABASE [UserInfo] SET QUERY_STORE = OFF
GO
USE [UserInfo]
GO
/****** Object:  User [alumno]    Script Date: 4/10/2023 13:02:35 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[UserInformation]    Script Date: 4/10/2023 13:02:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInformation](
	[Username] [varchar](50) NULL,
	[Contraseña] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Edad] [int] NULL,
	[Nombre] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[UserInformation] ([Username], [Contraseña], [Email], [Edad], [Nombre]) VALUES (N'Entunk', N'goinguptoheaven', N'valencha@gmail.com', 16, N'Valen')
GO
USE [master]
GO
ALTER DATABASE [UserInfo] SET  READ_WRITE 
GO
