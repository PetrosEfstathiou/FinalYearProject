USE [master]
GO
/****** Object:  Database [DentistToolDB]    Script Date: 6/9/2022 3:51:30 PM ******/
CREATE DATABASE [DentistToolDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DentistToolDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DentistToolDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DentistToolDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DentistToolDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DentistToolDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DentistToolDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DentistToolDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DentistToolDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DentistToolDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DentistToolDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DentistToolDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DentistToolDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DentistToolDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DentistToolDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DentistToolDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DentistToolDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DentistToolDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DentistToolDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DentistToolDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DentistToolDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DentistToolDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DentistToolDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DentistToolDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DentistToolDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DentistToolDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DentistToolDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DentistToolDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DentistToolDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DentistToolDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DentistToolDB] SET  MULTI_USER 
GO
ALTER DATABASE [DentistToolDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DentistToolDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DentistToolDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DentistToolDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DentistToolDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DentistToolDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DentistToolDB] SET QUERY_STORE = OFF
GO
USE [DentistToolDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/9/2022 3:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 6/9/2022 3:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cancelled] [bit] NOT NULL,
	[CancelReason] [nvarchar](max) NOT NULL,
	[dateTime] [datetime2](7) NOT NULL,
	[mduration] [int] NOT NULL,
	[AppReason] [nvarchar](max) NOT NULL,
	[patient] [int] NOT NULL,
	[doctor] [int] NOT NULL,
	[treatment] [int] NOT NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 6/9/2022 3:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[specialty] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[telnum] [nvarchar](max) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 6/9/2022 3:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[telnum] [nvarchar](max) NOT NULL,
	[nation] [nvarchar](max) NOT NULL,
	[dob] [nvarchar](max) NOT NULL,
	[bloodtype] [nvarchar](max) NOT NULL,
	[address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TreatmentCosts]    Script Date: 6/9/2022 3:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TreatmentCosts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Cost] [int] NOT NULL,
 CONSTRAINT [PK_TreatmentCosts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Treatments]    Script Date: 6/9/2022 3:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Treatments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[appointment] [int] NOT NULL,
	[timage] [varbinary](max) NOT NULL,
	[treatment] [nvarchar](max) NOT NULL,
	[cost] [int] NOT NULL,
	[patient] [int] NOT NULL,
 CONSTRAINT [PK_Treatments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/9/2022 3:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[UserMacHash] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Xrays]    Script Date: 6/9/2022 3:51:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Xrays](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[patient] [int] NOT NULL,
	[xrname] [nvarchar](max) NOT NULL,
	[xrimage] [varbinary](max) NOT NULL,
	[xrcreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Xrays] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Treatments] ADD  DEFAULT ((0)) FOR [cost]
GO
ALTER TABLE [dbo].[Treatments] ADD  DEFAULT ((0)) FOR [patient]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Doctors] FOREIGN KEY([doctor])
REFERENCES [dbo].[Doctors] ([Id])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Doctors]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Patients] FOREIGN KEY([patient])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Patients]
GO
ALTER TABLE [dbo].[Treatments]  WITH CHECK ADD  CONSTRAINT [FK_Treatments_Treatments] FOREIGN KEY([id])
REFERENCES [dbo].[Treatments] ([id])
GO
ALTER TABLE [dbo].[Treatments] CHECK CONSTRAINT [FK_Treatments_Treatments]
GO
ALTER TABLE [dbo].[Xrays]  WITH CHECK ADD  CONSTRAINT [FK_Xrays_Patients] FOREIGN KEY([patient])
REFERENCES [dbo].[Patients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Xrays] CHECK CONSTRAINT [FK_Xrays_Patients]
GO
USE [master]
GO
ALTER DATABASE [DentistToolDB] SET  READ_WRITE 
GO
