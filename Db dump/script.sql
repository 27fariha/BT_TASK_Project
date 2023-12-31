USE [master]
GO
/****** Object:  Database [inventory_schema]    Script Date: 10/4/2023 6:00:58 PM ******/
CREATE DATABASE [inventory_schema]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'inventory_schema', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\inventory_schema.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'inventory_schema_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\inventory_schema_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [inventory_schema] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [inventory_schema].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [inventory_schema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [inventory_schema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [inventory_schema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [inventory_schema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [inventory_schema] SET ARITHABORT OFF 
GO
ALTER DATABASE [inventory_schema] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [inventory_schema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [inventory_schema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [inventory_schema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [inventory_schema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [inventory_schema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [inventory_schema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [inventory_schema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [inventory_schema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [inventory_schema] SET  DISABLE_BROKER 
GO
ALTER DATABASE [inventory_schema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [inventory_schema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [inventory_schema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [inventory_schema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [inventory_schema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [inventory_schema] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [inventory_schema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [inventory_schema] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [inventory_schema] SET  MULTI_USER 
GO
ALTER DATABASE [inventory_schema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [inventory_schema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [inventory_schema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [inventory_schema] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [inventory_schema] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [inventory_schema] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [inventory_schema] SET QUERY_STORE = OFF
GO
USE [inventory_schema]
GO
/****** Object:  Table [dbo].[u01_items]    Script Date: 10/4/2023 6:01:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[u01_items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Uuid] [varchar](225) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Amount] [varchar](20) NOT NULL,
	[Quantity] [bigint] NOT NULL,
	[Category] [varchar](20) NOT NULL,
	[Added_on] [datetime] NOT NULL,
	[Updated_on] [datetime] NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[u01_sers]    Script Date: 10/4/2023 6:01:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[u01_sers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Uuid] [varchar](225) NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Salt] [varchar](255) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastLoginTimestamp] [datetime] NULL,
	[Status] [int] NOT NULL,
	[AddedBy] [bigint] NULL,
	[username] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [inventory_schema] SET  READ_WRITE 
GO
