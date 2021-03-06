USE [master]
GO
/****** Object:  Database [SimpleForum]    Script Date: 03/14/2020 10:26:40 PM ******/
CREATE DATABASE [SimpleForum]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimpleForum', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SimpleForum.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SimpleForum_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SimpleForum_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SimpleForum] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimpleForum].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimpleForum] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SimpleForum] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SimpleForum] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SimpleForum] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SimpleForum] SET ARITHABORT OFF 
GO
ALTER DATABASE [SimpleForum] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SimpleForum] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SimpleForum] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SimpleForum] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SimpleForum] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SimpleForum] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SimpleForum] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SimpleForum] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SimpleForum] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SimpleForum] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SimpleForum] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SimpleForum] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SimpleForum] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SimpleForum] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SimpleForum] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SimpleForum] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SimpleForum] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SimpleForum] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SimpleForum] SET  MULTI_USER 
GO
ALTER DATABASE [SimpleForum] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SimpleForum] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SimpleForum] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SimpleForum] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SimpleForum] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SimpleForum] SET QUERY_STORE = OFF
GO
USE [SimpleForum]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 03/14/2020 10:26:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArtID] [int] IDENTITY(1,1) NOT NULL,
	[ArtTittle] [varchar](300) NOT NULL,
	[ArtContent] [varchar](3000) NOT NULL,
	[ArtPostTime] [datetime] NOT NULL,
	[ArtAuthor] [varchar](50) NOT NULL,
	[ArtUsername] [varchar](20) NOT NULL,
	[ArtStatus] [varchar](30) NOT NULL,
 CONSTRAINT [PK__Article__3FB70A8601593CB5] PRIMARY KEY CLUSTERED 
(
	[ArtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 03/14/2020 10:26:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommID] [int] IDENTITY(1,1) NOT NULL,
	[CommContent] [varchar](300) NOT NULL,
	[CommPostTime] [datetime] NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[ArtID] [int] NOT NULL,
 CONSTRAINT [PK__Comment__AF8CE2B9EBDA2581] PRIMARY KEY CLUSTERED 
(
	[CommID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 03/14/2020 10:26:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccount](
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[Role] [bit] NOT NULL,
 CONSTRAINT [PK__Account__536C85E5006AA75E] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([ArtID], [ArtTittle], [ArtContent], [ArtPostTime], [ArtAuthor], [ArtUsername], [ArtStatus]) VALUES (6, N'Hello World', N'Xin chao  asd a d asd321a a3s2d1 aa3sd2 13as1 32a1s3d2 1a32s13 2a1s32d13 213a2s1 a3s', CAST(N'2020-03-10T00:00:00.000' AS DateTime), N'taint', N'tai', N'Active')
INSERT [dbo].[Article] ([ArtID], [ArtTittle], [ArtContent], [ArtPostTime], [ArtAuthor], [ArtUsername], [ArtStatus]) VALUES (12, N'asd', N'123  as da3w2e1 3a2s1d 32a1s3dq513r 5w1 351rg3sdf13 1fs3 1gs3 f21d 3f21 3d2 13y2dr13  g21 32', CAST(N'2020-03-13T22:04:33.783' AS DateTime), N'taint', N'tai', N'Active')
INSERT [dbo].[Article] ([ArtID], [ArtTittle], [ArtContent], [ArtPostTime], [ArtAuthor], [ArtUsername], [ArtStatus]) VALUES (13, N'123', N' a3 21a3r t1321d h32f1t321g321x32 13s21 32s1321 e32r1 32d1321 3 s21e  t32s1ey32s1d321 3s2f1 3a2s1', CAST(N'2020-03-14T00:01:23.447' AS DateTime), N'taint', N'tai', N'Active')
SET IDENTITY_INSERT [dbo].[Article] OFF
INSERT [dbo].[UserAccount] ([Username], [Password], [FullName], [Status], [Role]) VALUES (N'tai', N'123456', N'taint', N'New', 0)
INSERT [dbo].[UserAccount] ([Username], [Password], [FullName], [Status], [Role]) VALUES (N'tai2', N'123', N'Tai2', N'Active', 0)
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_UserAccount] FOREIGN KEY([ArtUsername])
REFERENCES [dbo].[UserAccount] ([Username])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_UserAccount]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Article] FOREIGN KEY([ArtID])
REFERENCES [dbo].[Article] ([ArtID])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Article]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_UserAccount] FOREIGN KEY([Username])
REFERENCES [dbo].[UserAccount] ([Username])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_UserAccount]
GO
/****** Object:  Trigger [dbo].[trg_SetAuthorInArticle]    Script Date: 03/14/2020 10:26:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_SetAuthorInArticle] ON [dbo].[Article] AFTER INSERT AS
BEGIN
	UPDATE dbo.Article SET ArtAuthor = (SELECT FullName FROM dbo.UserAccount 
										WHERE Username = (SELECT Inserted.ArtUsername FROM Inserted))
	WHERE ArtID = (SELECT Inserted.ArtID FROM Inserted)
	
	;

END
GO
ALTER TABLE [dbo].[Article] ENABLE TRIGGER [trg_SetAuthorInArticle]
GO
USE [master]
GO
ALTER DATABASE [SimpleForum] SET  READ_WRITE 
GO
