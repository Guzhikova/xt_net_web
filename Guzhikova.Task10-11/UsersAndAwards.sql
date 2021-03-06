USE [master]
GO
/****** Object:  Database [UsersAndAwards]    Script Date: 24.02.2020 5:20:44 ******/
CREATE DATABASE [UsersAndAwards]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UsersAndAwards', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\UsersAndAwards.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UsersAndAwards_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\UsersAndAwards_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [UsersAndAwards] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UsersAndAwards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ARITHABORT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UsersAndAwards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UsersAndAwards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UsersAndAwards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UsersAndAwards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UsersAndAwards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UsersAndAwards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UsersAndAwards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UsersAndAwards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UsersAndAwards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UsersAndAwards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UsersAndAwards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UsersAndAwards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UsersAndAwards] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UsersAndAwards] SET  MULTI_USER 
GO
ALTER DATABASE [UsersAndAwards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UsersAndAwards] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UsersAndAwards] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UsersAndAwards] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UsersAndAwards] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UsersAndAwards] SET QUERY_STORE = OFF
GO
USE [UsersAndAwards]
GO
/****** Object:  UserDefinedTableType [dbo].[intTable]    Script Date: 24.02.2020 5:20:44 ******/
CREATE TYPE [dbo].[intTable] AS TABLE(
	[id] [int] NULL
)
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Date_of_birth] [date] NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users_awards]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users_awards](
	[user_ID] [int] NOT NULL,
	[awardID] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[users_awards]  WITH CHECK ADD  CONSTRAINT [FK_AwardID_users_awards] FOREIGN KEY([awardID])
REFERENCES [dbo].[Awards] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[users_awards] CHECK CONSTRAINT [FK_AwardID_users_awards]
GO
ALTER TABLE [dbo].[users_awards]  WITH CHECK ADD  CONSTRAINT [FK_UserID_users_awards] FOREIGN KEY([user_ID])
REFERENCES [dbo].[Users] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[users_awards] CHECK CONSTRAINT [FK_UserID_users_awards]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward] (@title nvarchar(50), @image varbinary(max), @id INT OUTPUT)

AS
BEGIN

INSERT INTO Awards (Title, Image)
Values (@title, @image)

SET @id = SCOPE_IDENTITY();

END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser](
	@name NVARCHAR(50),
	@date_of_birth DATE,
	@image VARBINARY(MAX),
	@id INT OUTPUT)
AS
BEGIN
	INSERT INTO Users (Name, Date_of_birth, Image)
	Values (@name, @date_of_birth, @image)

	set @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[AddUsersIdToAward]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUsersIdToAward] 
	@id_award INT,
	@id_user INT
AS
BEGIN
	INSERT INTO users_awards(user_ID, awardID)
	VALUES (@id_user, @id_award)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAllUsersForAward]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAllUsersForAward] 
	(@awardId int) 
	
AS
BEGIN
	DELETE FROM users_awards 
	WHERE awardID = @awardId 

	END
GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardById]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAwardById](@id int) 
	
AS
BEGIN
	DELETE FROM Awards 
	WHERE ID = @id 

	END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUserById]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUserById] (@id int) 
	
AS
BEGIN
	DELETE FROM Users 
	WHERE ID = @id 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardById] 
	@id INT,
	@title NVARCHAR(50) OUTPUT,
	@image VARBINARY(MAX) OUTPUT

AS
BEGIN


	SET @title = (SELECT Title FROM Awards WHERE ID = @id);
	SET @image = (SELECT Image FROM Awards WHERE ID = @id);

	SELECT user_ID 
	FROM users_awards  WHERE awardID = @id;

END

GO
/****** Object:  StoredProcedure [dbo].[GetAwards]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwards]
	
AS
BEGIN
SELECT ID, Title, Image, user_ID FROM Awards  as aw
LEFT JOIN users_awards as ua
ON ua.awardID = aw.ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetAwardWithoutUsersById]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardWithoutUsersById] 
@id INT
AS
BEGIN
	SELECT Title, Image FROM Awards WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById] 
	@id INT

AS
BEGIN
	
	SELECT Name, Date_of_birth, Image
	FROM Users WHERE (ID = @id)

END
GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsers] 
	
AS
BEGIN

	SELECT ID, Name, Date_of_birth, Image
	FROM Users
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersIdForAward]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsersIdForAward] 
	@id INT
AS
BEGIN
SELECT user_ID 
	FROM users_awards  WHERE awardID = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAward]
	@id INT,
	@title NVARCHAR(50),
	@image VARBINARY(MAX)
AS
BEGIN

UPDATE Awards 
	SET Title = @title, Image = @image
	WHERE ID = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 24.02.2020 5:20:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser] 
	@id INT,
	@name NVARCHAR(50),
	@date_of_birth DATE,
	@image VARBINARY(MAX)
	
AS
BEGIN
	
	UPDATE Users 
	SET Name = @name, Date_of_birth = @date_of_birth, Image = @image
	WHERE ID = @id

END
GO
USE [master]
GO
ALTER DATABASE [UsersAndAwards] SET  READ_WRITE 
GO
