USE [master]
GO
/****** Object:  Database [CourseRegistraionManagement]    Script Date: 5/5/2024 2:26:31 PM ******/
CREATE DATABASE [CourseRegistraionManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CourseRegistraionManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQL2\MSSQL\DATA\CourseRegistraionManagement.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CourseRegistraionManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQL2\MSSQL\DATA\CourseRegistraionManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CourseRegistraionManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CourseRegistraionManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CourseRegistraionManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CourseRegistraionManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CourseRegistraionManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CourseRegistraionManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CourseRegistraionManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CourseRegistraionManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [CourseRegistraionManagement] SET  MULTI_USER 
GO
ALTER DATABASE [CourseRegistraionManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CourseRegistraionManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CourseRegistraionManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CourseRegistraionManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CourseRegistraionManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CourseRegistraionManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CourseRegistraionManagement', N'ON'
GO
ALTER DATABASE [CourseRegistraionManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [CourseRegistraionManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CourseRegistraionManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/5/2024 2:26:32 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](450) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classroom]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classroom](
	[ClassRoomId] [nvarchar](450) NOT NULL,
	[ClassroomName] [nvarchar](max) NULL,
	[MaxQuantity] [int] NOT NULL,
	[CurrentQuantity] [int] NOT NULL,
 CONSTRAINT [PK_Classroom] PRIMARY KEY CLUSTERED 
(
	[ClassRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassTime]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassTime](
	[ClassroomId] [nvarchar](450) NOT NULL,
	[TimeId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ClassTime] PRIMARY KEY CLUSTERED 
(
	[ClassroomId] ASC,
	[TimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[FacultyId] [nvarchar](450) NOT NULL,
	[FacultyName] [nvarchar](max) NULL,
	[ContactInformation] [nvarchar](max) NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVu]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVu](
	[GiaoVuId] [nvarchar](450) NOT NULL,
	[PersonId] [nvarchar](450) NULL,
 CONSTRAINT [PK_GiaoVu] PRIMARY KEY CLUSTERED 
(
	[GiaoVuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[AccountId] [nvarchar](450) NULL,
	[FacultyId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [nvarchar](450) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAccount]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAccount](
	[RoleId] [nvarchar](450) NOT NULL,
	[AccountId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_RoleAccount] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [nvarchar](450) NOT NULL,
	[PersonId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentRegisteredSubject]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentRegisteredSubject](
	[StudentId] [nvarchar](450) NOT NULL,
	[Mark3] [real] NOT NULL,
	[SubjectId] [nvarchar](450) NOT NULL,
	[RegisterDate] [datetime2](7) NOT NULL,
	[ClassroomId] [nvarchar](450) NOT NULL,
	[TeacherId] [nvarchar](450) NOT NULL,
	[TimeId] [nvarchar](450) NOT NULL,
	[Mark1] [real] NOT NULL,
	[Mark2] [real] NOT NULL,
 CONSTRAINT [PK_StudentRegisteredSubject] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[SubjectId] ASC,
	[ClassroomId] ASC,
	[TeacherId] ASC,
	[TimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectId] [nvarchar](450) NOT NULL,
	[SubjectName] [nvarchar](max) NULL,
	[Credits] [int] NOT NULL,
	[StartDay] [datetime2](7) NOT NULL,
	[EndDay] [datetime2](7) NOT NULL,
	[FacultyId] [nvarchar](450) NULL,
	[isOpen] [bit] NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectClass]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectClass](
	[SubjectId] [nvarchar](450) NOT NULL,
	[ClassroomId] [nvarchar](450) NOT NULL,
	[TimeId] [nvarchar](450) NOT NULL,
	[TeacherId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_SubjectClass] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC,
	[ClassroomId] ASC,
	[TimeId] ASC,
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [nvarchar](450) NOT NULL,
	[PersonId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubject](
	[TeacherId] [nvarchar](450) NOT NULL,
	[SubjectId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_TeacherSubject] PRIMARY KEY CLUSTERED 
(
	[SubjectId] ASC,
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Time]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Time](
	[TimeId] [nvarchar](450) NOT NULL,
	[TimeName] [nvarchar](max) NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[DayOfWeek] [int] NOT NULL,
 CONSTRAINT [PK_Time] PRIMARY KEY CLUSTERED 
(
	[TimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TruongBoMon]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruongBoMon](
	[TruongBoMonId] [nvarchar](450) NOT NULL,
	[PersonId] [nvarchar](450) NULL,
 CONSTRAINT [PK_TruongBoMon] PRIMARY KEY CLUSTERED 
(
	[TruongBoMonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TruongPhoKhoa]    Script Date: 5/5/2024 2:26:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruongPhoKhoa](
	[TruongPhoKhoaId] [nvarchar](450) NOT NULL,
	[PersonId] [nvarchar](450) NULL,
 CONSTRAINT [PK_TruongPhoKhoa] PRIMARY KEY CLUSTERED 
(
	[TruongPhoKhoaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240427083957_role1', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240427095947_full1', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240427163754_full2', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428040827_full3', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428051804_full4', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428052651_full5', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428052815_full6', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428053931_full7', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428064216_full8', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428064547_full9', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428090020_full10', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428101945_full11', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428152036_full12', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428160321_full13', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240429055041_full14', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240429095706_full15', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240429103112_full16', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240429161531_full17', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240430062609_full18', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240430115402_full19', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240430115620_full20', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240430150738_full21', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240430163710_full22', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240502055318_full23', N'8.0.4')
GO
INSERT [dbo].[Account] ([AccountId], [UserName], [PasswordHash], [PasswordSalt]) VALUES (N'19eac233-6ea4-46da-8d14-fe3d5eb8b7a2', N'test7', 0xCCAED3851306897A2FAE45134875F56A, 0x6834C205FE044F070D5344ABC1FF7AE599EC3E91C63F887AA712170C07BDAACB0CDD9871DFA03C78C3A0C37867D07BFFE8581A8995B214C91BF4106181E0490E)
INSERT [dbo].[Account] ([AccountId], [UserName], [PasswordHash], [PasswordSalt]) VALUES (N'3b5e06f5-7707-4489-8b1a-6275d79633d6', N'Test5', 0x1D2122476562133A408E7777727D0068, 0xF41296BAFF812B8ADA6C8EBE63766F33F6A2F23D5C91A3AFCD7241E85877E5E11B09B44FEFEEE0F49B17D64967E26A86E9E1A17A02C4C1611AC665B63B4682EB)
INSERT [dbo].[Account] ([AccountId], [UserName], [PasswordHash], [PasswordSalt]) VALUES (N'3b62bd60-c6a6-46a6-bd0d-66d7857d60fe', N'Test2', 0xC6D826DB25A7F5043A81A3719987B523, 0x35089A41DA01BEFCA90AFE752FF3333289F758C8E6F3183EE4FBF7443F005D046F55B138319788A6AB9CCEBB20C7B358FE22637B84D56754026647F198BF04DB)
INSERT [dbo].[Account] ([AccountId], [UserName], [PasswordHash], [PasswordSalt]) VALUES (N'71f7559d-eb4b-4f14-ac79-83fa789b1167', N'Test4', 0xEDEC10FDA703A09FC4FC55AA687583A9, 0x86EF10EB55B46A09756DED7BEA0CF3A7339B4D5505ECFAA20D4B8E45E22D3ABF6EC16213385B5147D452BA081E29E499EB8472ECAE528F2C890485EF29F1D020)
INSERT [dbo].[Account] ([AccountId], [UserName], [PasswordHash], [PasswordSalt]) VALUES (N'85e1df18-926b-4285-ad03-9528a77056e9', N'Test3', 0x388C0B89C5E7E96EE765DCF9EED8EA4E, 0xDAF274044906448FBA6CCBAB3DA99BD6FE96FD6AB354D7DCE07877085803BADC3E37C87BE08AE92A3497C1910F18BB50277B1DC68E75AD1E3EC2DBD67C9B7E93)
INSERT [dbo].[Account] ([AccountId], [UserName], [PasswordHash], [PasswordSalt]) VALUES (N'db4c2550-620b-4b42-867c-c7b9f0bebee1', N'Test1', 0x14E72B0D86001888A8D8413D4FE79D54, 0x565423B4C253841BAD1CEE7CB06AE4DD585587AE391D3A141A05A86C1609CD49EAC13E90CA2DC49E5CDC613B0F8B1B36D65B31C814C82DE45B90B1D5FF9226D0)
INSERT [dbo].[Account] ([AccountId], [UserName], [PasswordHash], [PasswordSalt]) VALUES (N'f0902610-c4ac-4e92-93e3-a0d9a6e7894d', N'test6', 0x471266864685A367911F0CE79BCE85ED, 0xA0D0A501F668F9A6E010D81392FFB23380E8276C249D261AF60CBCD8048C39EEF4EAE7BAB2B1DC3A100E45E3AD57C45BA4EBC4EE636481A55759B87FE990BF5D)
GO
INSERT [dbo].[Classroom] ([ClassRoomId], [ClassroomName], [MaxQuantity], [CurrentQuantity]) VALUES (N'007f6b65-4584-410f-a23f-0395d058c382', N'B101', 40, 2)
INSERT [dbo].[Classroom] ([ClassRoomId], [ClassroomName], [MaxQuantity], [CurrentQuantity]) VALUES (N'069fdcad-4c9d-4f2c-bd26-bf1e2528a19f', N'A302', 40, 0)
INSERT [dbo].[Classroom] ([ClassRoomId], [ClassroomName], [MaxQuantity], [CurrentQuantity]) VALUES (N'80df198d-820a-44f3-b1dc-9a5f9aaf513e', N'I102', 40, 7)
INSERT [dbo].[Classroom] ([ClassRoomId], [ClassroomName], [MaxQuantity], [CurrentQuantity]) VALUES (N'9584f63a-3610-40c6-abf2-d5f6a7c7e052', N'C201', 40, 0)
INSERT [dbo].[Classroom] ([ClassRoomId], [ClassroomName], [MaxQuantity], [CurrentQuantity]) VALUES (N'a0e5dec9-e23a-4271-8181-0634fa2e8114', N'B102', 40, 1)
GO
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'007f6b65-4584-410f-a23f-0395d058c382', N'071d53c8-1e22-41e4-a259-5ca10bdabcd4')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'a0e5dec9-e23a-4271-8181-0634fa2e8114', N'071d53c8-1e22-41e4-a259-5ca10bdabcd4')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'007f6b65-4584-410f-a23f-0395d058c382', N'1c73da2f-ee96-462f-bc72-bbcb961d7b04')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'069fdcad-4c9d-4f2c-bd26-bf1e2528a19f', N'1c73da2f-ee96-462f-bc72-bbcb961d7b04')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'9584f63a-3610-40c6-abf2-d5f6a7c7e052', N'1c73da2f-ee96-462f-bc72-bbcb961d7b04')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'80df198d-820a-44f3-b1dc-9a5f9aaf513e', N'7ea0c7c2-5df2-4cb0-a2d7-924decc30356')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'069fdcad-4c9d-4f2c-bd26-bf1e2528a19f', N'8e303083-ec60-494c-b9a4-3c7ac2aa0d29')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'80df198d-820a-44f3-b1dc-9a5f9aaf513e', N'8e303083-ec60-494c-b9a4-3c7ac2aa0d29')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'9584f63a-3610-40c6-abf2-d5f6a7c7e052', N'8e303083-ec60-494c-b9a4-3c7ac2aa0d29')
INSERT [dbo].[ClassTime] ([ClassroomId], [TimeId]) VALUES (N'a0e5dec9-e23a-4271-8181-0634fa2e8114', N'8e303083-ec60-494c-b9a4-3c7ac2aa0d29')
GO
INSERT [dbo].[Faculty] ([FacultyId], [FacultyName], [ContactInformation]) VALUES (N'46f3afdc-b02e-4d67-b71a-e50e070c0ab5', N'Khoa CNTT', N'khoacntt@hcmue.edu.vn')
INSERT [dbo].[Faculty] ([FacultyId], [FacultyName], [ContactInformation]) VALUES (N'98d9fe7d-13f6-4b11-995c-101966ae8ee0', N'Khoa Lý', N'khoaly@hcmue.edu.vn')
INSERT [dbo].[Faculty] ([FacultyId], [FacultyName], [ContactInformation]) VALUES (N'9d229b6f-3cb1-4ebf-923a-b4f30ed312ab', N'Khoa Toán', N'khoatoan@hcmue.edu.vn')
INSERT [dbo].[Faculty] ([FacultyId], [FacultyName], [ContactInformation]) VALUES (N'b45f0fb7-206a-451b-951c-367a67e9a876', N'Khoa Hóa', N'khoahoa@hcmue.edu.vn')
INSERT [dbo].[Faculty] ([FacultyId], [FacultyName], [ContactInformation]) VALUES (N'f2dcdb55-bdbd-4550-a1cc-4f5f04d13a05', N'Khoa Mầm Non', N'khoamamnon@gmail.com')
GO
INSERT [dbo].[GiaoVu] ([GiaoVuId], [PersonId]) VALUES (N'6f21d9a5-90a7-4349-9c4e-f34fc63d5911', N'71f7559d-eb4b-4f14-ac79-83fa789b1167')
GO
INSERT [dbo].[Person] ([PersonId], [FullName], [Gender], [PhoneNumber], [DateOfBirth], [Address], [AccountId], [FacultyId]) VALUES (N'0eb171ed-ddc9-4543-a79a-a1fc0390b8c1', N'Lê Thịnh Phúc', N'Nam', N'1234567890', CAST(N'2024-04-30T13:50:26.7202232' AS DateTime2), N'Tây Ning', N'db4c2550-620b-4b42-867c-c7b9f0bebee1', N'46f3afdc-b02e-4d67-b71a-e50e070c0ab5')
INSERT [dbo].[Person] ([PersonId], [FullName], [Gender], [PhoneNumber], [DateOfBirth], [Address], [AccountId], [FacultyId]) VALUES (N'21748e05-3a23-4e95-a2b3-6041e667e01b', N'Nguyễn Hoàng Nam', N'Nam', N'1234567890', CAST(N'2024-04-30T13:50:26.7204703' AS DateTime2), N'Tây Ning', N'3b62bd60-c6a6-46a6-bd0d-66d7857d60fe', N'9d229b6f-3cb1-4ebf-923a-b4f30ed312ab')
INSERT [dbo].[Person] ([PersonId], [FullName], [Gender], [PhoneNumber], [DateOfBirth], [Address], [AccountId], [FacultyId]) VALUES (N'532dfe3f-bc6e-46e9-8448-dcad1e08478e', N'Yassuo', N'Name', N'12345654', CAST(N'2024-04-28T17:05:00.2520000' AS DateTime2), N'GO VAP', N'19eac233-6ea4-46da-8d14-fe3d5eb8b7a2', N'46f3afdc-b02e-4d67-b71a-e50e070c0ab5')
INSERT [dbo].[Person] ([PersonId], [FullName], [Gender], [PhoneNumber], [DateOfBirth], [Address], [AccountId], [FacultyId]) VALUES (N'71f7559d-eb4b-4f14-ac79-83fa789b1167', N'Phạm Thanh Chiều', N'Nam', N'1234567890', CAST(N'2024-04-30T13:50:26.7206843' AS DateTime2), N'Tây Ning', N'71f7559d-eb4b-4f14-ac79-83fa789b1167', N'b45f0fb7-206a-451b-951c-367a67e9a876')
INSERT [dbo].[Person] ([PersonId], [FullName], [Gender], [PhoneNumber], [DateOfBirth], [Address], [AccountId], [FacultyId]) VALUES (N'd6fb8eac-47e2-42ff-9493-08b56ec017cf', N'Nguyễn Duy Tân', N'Nam', N'1234567890', CAST(N'2024-04-30T13:50:26.7205760' AS DateTime2), N'Tây Ning', N'85e1df18-926b-4285-ad03-9528a77056e9', N'98d9fe7d-13f6-4b11-995c-101966ae8ee0')
INSERT [dbo].[Person] ([PersonId], [FullName], [Gender], [PhoneNumber], [DateOfBirth], [Address], [AccountId], [FacultyId]) VALUES (N'df249336-dfdb-492f-bd5c-a99db7418bdb', N'Chấn bé đù', N'Nam', N'1234567890', CAST(N'2024-04-30T13:50:26.7207912' AS DateTime2), N'Tây Ning', N'3b5e06f5-7707-4489-8b1a-6275d79633d6', N'b45f0fb7-206a-451b-951c-367a67e9a876')
INSERT [dbo].[Person] ([PersonId], [FullName], [Gender], [PhoneNumber], [DateOfBirth], [Address], [AccountId], [FacultyId]) VALUES (N'f073b30f-592b-4956-8ec1-1cbe3ed45d6d', N'Phạm Thanh Chồn Liều', N'Name', N'12345654', CAST(N'2024-04-28T17:05:00.2520000' AS DateTime2), N'GO CONG', N'f0902610-c4ac-4e92-93e3-a0d9a6e7894d', N'46f3afdc-b02e-4d67-b71a-e50e070c0ab5')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'giaovien', N'Giáo Viên')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'giaovu', N'Giáo Vụ')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'sinhvien', N'Sinh Viên')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'truongbomon', N'Trưởng Bộ Môn')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'truongphokhoa', N'Trưởng Phó Khoa')
GO
INSERT [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES (N'giaovien', N'19eac233-6ea4-46da-8d14-fe3d5eb8b7a2')
INSERT [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES (N'giaovien', N'3b5e06f5-7707-4489-8b1a-6275d79633d6')
INSERT [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES (N'truongphokhoa', N'3b62bd60-c6a6-46a6-bd0d-66d7857d60fe')
INSERT [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES (N'giaovu', N'71f7559d-eb4b-4f14-ac79-83fa789b1167')
INSERT [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES (N'truongbomon', N'85e1df18-926b-4285-ad03-9528a77056e9')
INSERT [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES (N'sinhvien', N'db4c2550-620b-4b42-867c-c7b9f0bebee1')
INSERT [dbo].[RoleAccount] ([RoleId], [AccountId]) VALUES (N'sinhvien', N'f0902610-c4ac-4e92-93e3-a0d9a6e7894d')
GO
INSERT [dbo].[Student] ([StudentId], [PersonId]) VALUES (N'0eb171ed-ddc9-4543-a79a-a1fc0390b8c1', N'0eb171ed-ddc9-4543-a79a-a1fc0390b8c1')
INSERT [dbo].[Student] ([StudentId], [PersonId]) VALUES (N'f073b30f-592b-4956-8ec1-1cbe3ed45d6d', N'f073b30f-592b-4956-8ec1-1cbe3ed45d6d')
GO
INSERT [dbo].[StudentRegisteredSubject] ([StudentId], [Mark3], [SubjectId], [RegisterDate], [ClassroomId], [TeacherId], [TimeId], [Mark1], [Mark2]) VALUES (N'0eb171ed-ddc9-4543-a79a-a1fc0390b8c1', 0, N'9f54524f-0325-431b-9061-cc61b23eebb8', CAST(N'2024-05-01T14:23:08.9348211' AS DateTime2), N'007f6b65-4584-410f-a23f-0395d058c382', N'df249336-dfdb-492f-bd5c-a99db7418bdb', N'1c73da2f-ee96-462f-bc72-bbcb961d7b04', 0, 0)
INSERT [dbo].[StudentRegisteredSubject] ([StudentId], [Mark3], [SubjectId], [RegisterDate], [ClassroomId], [TeacherId], [TimeId], [Mark1], [Mark2]) VALUES (N'f073b30f-592b-4956-8ec1-1cbe3ed45d6d', 0, N'9f54524f-0325-431b-9061-cc61b23eebb8', CAST(N'2024-05-01T16:53:31.4261969' AS DateTime2), N'007f6b65-4584-410f-a23f-0395d058c382', N'df249336-dfdb-492f-bd5c-a99db7418bdb', N'1c73da2f-ee96-462f-bc72-bbcb961d7b04', 0, 0)
INSERT [dbo].[StudentRegisteredSubject] ([StudentId], [Mark3], [SubjectId], [RegisterDate], [ClassroomId], [TeacherId], [TimeId], [Mark1], [Mark2]) VALUES (N'f073b30f-592b-4956-8ec1-1cbe3ed45d6d', 0, N'a5e8f859-eec6-4e0d-8084-cb5e0029ee25', CAST(N'2024-05-02T21:25:05.3506498' AS DateTime2), N'a0e5dec9-e23a-4271-8181-0634fa2e8114', N'df249336-dfdb-492f-bd5c-a99db7418bdb', N'071d53c8-1e22-41e4-a259-5ca10bdabcd4', 0, 0)
GO
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Credits], [StartDay], [EndDay], [FacultyId], [isOpen]) VALUES (N'43b1fcd6-6f7d-4ff8-ac55-6603e995a8ef', N'Lập trình nâng cao', 3, CAST(N'2024-04-29T08:08:44.9280000' AS DateTime2), CAST(N'2024-04-29T08:08:44.9280000' AS DateTime2), N'46f3afdc-b02e-4d67-b71a-e50e070c0ab5', 1)
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Credits], [StartDay], [EndDay], [FacultyId], [isOpen]) VALUES (N'9f54524f-0325-431b-9061-cc61b23eebb8', N'Vật lý lượng tử', 3, CAST(N'2024-04-30T13:50:26.6803906' AS DateTime2), CAST(N'2024-07-30T13:50:26.6803907' AS DateTime2), N'98d9fe7d-13f6-4b11-995c-101966ae8ee0', 1)
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Credits], [StartDay], [EndDay], [FacultyId], [isOpen]) VALUES (N'a5e8f859-eec6-4e0d-8084-cb5e0029ee25', N'Giải tích 3', 3, CAST(N'2024-04-30T13:50:26.6803902' AS DateTime2), CAST(N'2024-07-30T13:50:26.6803904' AS DateTime2), N'9d229b6f-3cb1-4ebf-923a-b4f30ed312ab', 1)
INSERT [dbo].[Subject] ([SubjectId], [SubjectName], [Credits], [StartDay], [EndDay], [FacultyId], [isOpen]) VALUES (N'dc20ac05-4dd3-47d3-aaf0-77ab27d82089', N'Lập trình cơ bản', 3, CAST(N'2024-04-29T08:08:44.9280000' AS DateTime2), CAST(N'2024-04-29T08:08:44.9280000' AS DateTime2), N'46f3afdc-b02e-4d67-b71a-e50e070c0ab5', 1)
GO
INSERT [dbo].[SubjectClass] ([SubjectId], [ClassroomId], [TimeId], [TeacherId]) VALUES (N'9f54524f-0325-431b-9061-cc61b23eebb8', N'007f6b65-4584-410f-a23f-0395d058c382', N'1c73da2f-ee96-462f-bc72-bbcb961d7b04', N'df249336-dfdb-492f-bd5c-a99db7418bdb')
INSERT [dbo].[SubjectClass] ([SubjectId], [ClassroomId], [TimeId], [TeacherId]) VALUES (N'a5e8f859-eec6-4e0d-8084-cb5e0029ee25', N'a0e5dec9-e23a-4271-8181-0634fa2e8114', N'071d53c8-1e22-41e4-a259-5ca10bdabcd4', N'df249336-dfdb-492f-bd5c-a99db7418bdb')
GO
INSERT [dbo].[Teacher] ([TeacherId], [PersonId]) VALUES (N'532dfe3f-bc6e-46e9-8448-dcad1e08478e', N'532dfe3f-bc6e-46e9-8448-dcad1e08478e')
INSERT [dbo].[Teacher] ([TeacherId], [PersonId]) VALUES (N'df249336-dfdb-492f-bd5c-a99db7418bdb', N'df249336-dfdb-492f-bd5c-a99db7418bdb')
GO
INSERT [dbo].[Time] ([TimeId], [TimeName], [StartTime], [EndTime], [DayOfWeek]) VALUES (N'071d53c8-1e22-41e4-a259-5ca10bdabcd4', N'Sáng 2', CAST(N'09:15:00' AS Time), CAST(N'11:15:00' AS Time), 1)
INSERT [dbo].[Time] ([TimeId], [TimeName], [StartTime], [EndTime], [DayOfWeek]) VALUES (N'1c73da2f-ee96-462f-bc72-bbcb961d7b04', N'Chiều 1', CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), 1)
INSERT [dbo].[Time] ([TimeId], [TimeName], [StartTime], [EndTime], [DayOfWeek]) VALUES (N'7ea0c7c2-5df2-4cb0-a2d7-924decc30356', N'Chiều 2', CAST(N'15:15:00' AS Time), CAST(N'17:15:00' AS Time), 1)
INSERT [dbo].[Time] ([TimeId], [TimeName], [StartTime], [EndTime], [DayOfWeek]) VALUES (N'8e303083-ec60-494c-b9a4-3c7ac2aa0d29', N'Sáng 1', CAST(N'07:00:00' AS Time), CAST(N'09:00:00' AS Time), 1)
INSERT [dbo].[Time] ([TimeId], [TimeName], [StartTime], [EndTime], [DayOfWeek]) VALUES (N'f3425d61-b4a1-4433-9eee-ab03f4f3f7a1', N'Tối 1', CAST(N'19:00:00' AS Time), CAST(N'21:00:00' AS Time), 1)
GO
INSERT [dbo].[TruongBoMon] ([TruongBoMonId], [PersonId]) VALUES (N'd6fb8eac-47e2-42ff-9493-08b56ec017cf', N'd6fb8eac-47e2-42ff-9493-08b56ec017cf')
GO
INSERT [dbo].[TruongPhoKhoa] ([TruongPhoKhoaId], [PersonId]) VALUES (N'21748e05-3a23-4e95-a2b3-6041e667e01b', N'21748e05-3a23-4e95-a2b3-6041e667e01b')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Account_UserName]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account_UserName] ON [dbo].[Account]
(
	[UserName] ASC
)
WHERE ([UserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ClassTime_TimeId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_ClassTime_TimeId] ON [dbo].[ClassTime]
(
	[TimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_GiaoVu_PersonId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_GiaoVu_PersonId] ON [dbo].[GiaoVu]
(
	[PersonId] ASC
)
WHERE ([PersonId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Person_AccountId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Person_AccountId] ON [dbo].[Person]
(
	[AccountId] ASC
)
WHERE ([AccountId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Person_FacultyId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_Person_FacultyId] ON [dbo].[Person]
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleAccount_AccountId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleAccount_AccountId] ON [dbo].[RoleAccount]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Student_PersonId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Student_PersonId] ON [dbo].[Student]
(
	[PersonId] ASC
)
WHERE ([PersonId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StudentRegisteredSubject_ClassroomId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentRegisteredSubject_ClassroomId] ON [dbo].[StudentRegisteredSubject]
(
	[ClassroomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StudentRegisteredSubject_SubjectId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentRegisteredSubject_SubjectId] ON [dbo].[StudentRegisteredSubject]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StudentRegisteredSubject_TeacherId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentRegisteredSubject_TeacherId] ON [dbo].[StudentRegisteredSubject]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_StudentRegisteredSubject_TimeId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentRegisteredSubject_TimeId] ON [dbo].[StudentRegisteredSubject]
(
	[TimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Subject_FacultyId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_Subject_FacultyId] ON [dbo].[Subject]
(
	[FacultyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SubjectClass_ClassroomId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubjectClass_ClassroomId] ON [dbo].[SubjectClass]
(
	[ClassroomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SubjectClass_TeacherId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubjectClass_TeacherId] ON [dbo].[SubjectClass]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_SubjectClass_TimeId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_SubjectClass_TimeId] ON [dbo].[SubjectClass]
(
	[TimeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Teacher_PersonId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Teacher_PersonId] ON [dbo].[Teacher]
(
	[PersonId] ASC
)
WHERE ([PersonId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TeacherSubject_TeacherId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherSubject_TeacherId] ON [dbo].[TeacherSubject]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TruongBoMon_PersonId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TruongBoMon_PersonId] ON [dbo].[TruongBoMon]
(
	[PersonId] ASC
)
WHERE ([PersonId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TruongPhoKhoa_PersonId]    Script Date: 5/5/2024 2:26:32 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TruongPhoKhoa_PersonId] ON [dbo].[TruongPhoKhoa]
(
	[PersonId] ASC
)
WHERE ([PersonId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Classroom] ADD  DEFAULT ((0)) FOR [CurrentQuantity]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] ADD  DEFAULT (N'') FOR [SubjectId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [RegisterDate]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] ADD  DEFAULT (N'') FOR [ClassroomId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] ADD  DEFAULT (N'') FOR [TeacherId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] ADD  DEFAULT (N'') FOR [TimeId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] ADD  DEFAULT (CONVERT([real],(0))) FOR [Mark1]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] ADD  DEFAULT (CONVERT([real],(0))) FOR [Mark2]
GO
ALTER TABLE [dbo].[Subject] ADD  DEFAULT ((0)) FOR [Credits]
GO
ALTER TABLE [dbo].[Subject] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isOpen]
GO
ALTER TABLE [dbo].[SubjectClass] ADD  DEFAULT (N'') FOR [TimeId]
GO
ALTER TABLE [dbo].[SubjectClass] ADD  DEFAULT (N'') FOR [TeacherId]
GO
ALTER TABLE [dbo].[Time] ADD  DEFAULT ((0)) FOR [DayOfWeek]
GO
ALTER TABLE [dbo].[ClassTime]  WITH CHECK ADD  CONSTRAINT [FK_ClassTime_Classroom_ClassroomId] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classroom] ([ClassRoomId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassTime] CHECK CONSTRAINT [FK_ClassTime_Classroom_ClassroomId]
GO
ALTER TABLE [dbo].[ClassTime]  WITH CHECK ADD  CONSTRAINT [FK_ClassTime_Time_TimeId] FOREIGN KEY([TimeId])
REFERENCES [dbo].[Time] ([TimeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClassTime] CHECK CONSTRAINT [FK_ClassTime_Time_TimeId]
GO
ALTER TABLE [dbo].[GiaoVu]  WITH CHECK ADD  CONSTRAINT [FK_GiaoVu_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[GiaoVu] CHECK CONSTRAINT [FK_GiaoVu_Person_PersonId]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Account_AccountId]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Faculty_FacultyId] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([FacultyId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Faculty_FacultyId]
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD  CONSTRAINT [FK_RoleAccount_Account_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleAccount] CHECK CONSTRAINT [FK_RoleAccount_Account_AccountId]
GO
ALTER TABLE [dbo].[RoleAccount]  WITH CHECK ADD  CONSTRAINT [FK_RoleAccount_Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleAccount] CHECK CONSTRAINT [FK_RoleAccount_Role_RoleId]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Person_PersonId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegisteredSubject_Classroom_ClassroomId] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classroom] ([ClassRoomId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] CHECK CONSTRAINT [FK_StudentRegisteredSubject_Classroom_ClassroomId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegisteredSubject_Student_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] CHECK CONSTRAINT [FK_StudentRegisteredSubject_Student_StudentId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegisteredSubject_Subject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] CHECK CONSTRAINT [FK_StudentRegisteredSubject_Subject_SubjectId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegisteredSubject_Teacher_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] CHECK CONSTRAINT [FK_StudentRegisteredSubject_Teacher_TeacherId]
GO
ALTER TABLE [dbo].[StudentRegisteredSubject]  WITH CHECK ADD  CONSTRAINT [FK_StudentRegisteredSubject_Time_TimeId] FOREIGN KEY([TimeId])
REFERENCES [dbo].[Time] ([TimeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentRegisteredSubject] CHECK CONSTRAINT [FK_StudentRegisteredSubject_Time_TimeId]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD  CONSTRAINT [FK_Subject_Faculty_FacultyId] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculty] ([FacultyId])
GO
ALTER TABLE [dbo].[Subject] CHECK CONSTRAINT [FK_Subject_Faculty_FacultyId]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Classroom_ClassroomId] FOREIGN KEY([ClassroomId])
REFERENCES [dbo].[Classroom] ([ClassRoomId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Classroom_ClassroomId]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Subject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Subject_SubjectId]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Teacher_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Teacher_TeacherId]
GO
ALTER TABLE [dbo].[SubjectClass]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClass_Time_TimeId] FOREIGN KEY([TimeId])
REFERENCES [dbo].[Time] ([TimeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SubjectClass] CHECK CONSTRAINT [FK_SubjectClass_Time_TimeId]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Person_PersonId]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubject_Subject_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subject] ([SubjectId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK_TeacherSubject_Subject_SubjectId]
GO
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubject_Teacher_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK_TeacherSubject_Teacher_TeacherId]
GO
ALTER TABLE [dbo].[TruongBoMon]  WITH CHECK ADD  CONSTRAINT [FK_TruongBoMon_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[TruongBoMon] CHECK CONSTRAINT [FK_TruongBoMon_Person_PersonId]
GO
ALTER TABLE [dbo].[TruongPhoKhoa]  WITH CHECK ADD  CONSTRAINT [FK_TruongPhoKhoa_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[TruongPhoKhoa] CHECK CONSTRAINT [FK_TruongPhoKhoa_Person_PersonId]
GO
USE [master]
GO
ALTER DATABASE [CourseRegistraionManagement] SET  READ_WRITE 
GO
