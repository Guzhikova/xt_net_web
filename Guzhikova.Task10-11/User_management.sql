USE [master]
GO
/****** Object:  Database [User_management]    Script Date: 25.02.2020 1:41:00 ******/
CREATE DATABASE [User_management]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'User_management', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\User_management.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'User_management_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\User_management_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [User_management] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [User_management].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [User_management] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [User_management] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [User_management] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [User_management] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [User_management] SET ARITHABORT OFF 
GO
ALTER DATABASE [User_management] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [User_management] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [User_management] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [User_management] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [User_management] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [User_management] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [User_management] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [User_management] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [User_management] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [User_management] SET  DISABLE_BROKER 
GO
ALTER DATABASE [User_management] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [User_management] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [User_management] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [User_management] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [User_management] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [User_management] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [User_management] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [User_management] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [User_management] SET  MULTI_USER 
GO
ALTER DATABASE [User_management] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [User_management] SET DB_CHAINING OFF 
GO
ALTER DATABASE [User_management] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [User_management] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [User_management] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [User_management] SET QUERY_STORE = OFF
GO
USE [User_management]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](30) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](32) NOT NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users_roles]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users_roles](
	[id_user] [int] NULL,
	[id_role] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[users_roles]  WITH CHECK ADD  CONSTRAINT [FK_users_roles_Roles] FOREIGN KEY([id_role])
REFERENCES [dbo].[Roles] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[users_roles] CHECK CONSTRAINT [FK_users_roles_Roles]
GO
ALTER TABLE [dbo].[users_roles]  WITH CHECK ADD  CONSTRAINT [FK_users_roles_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[users_roles] CHECK CONSTRAINT [FK_users_roles_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
	@login NVARCHAR(30),
	@password NVARCHAR(32),
	@email NVARCHAR(50),
	@id INT OUTPUT
AS
BEGIN
	INSERT INTO Users (Login, Password, Email)
	Values (@login, @password, @email)

	set @id = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUsersAdminRole]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUsersAdminRole]
AS
BEGIN
DELETE FROM users_roles 
	WHERE id_role = 1
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]

AS
BEGIN
	SELECT ID, Login, Password, Email FROM Users
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserRoles]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserRoles] 
@login NVARCHAR(30)
AS
BEGIN
DECLARE @userID varchar(16);

SET @userID = (SELECT ID FROM Users where Login = @login);

	SELECT ID, Title FROM Roles  as r
JOIN users_roles as u_r
ON u_r.id_user = @userID
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersByLogin]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetUsersByLogin]
@login NVARCHAR(30)
AS
BEGIN
	SELECT ID, Login, Password, Email FROM Users WHERE Login = @login
END
GO
/****** Object:  StoredProcedure [dbo].[SetUserAsAdmin]    Script Date: 25.02.2020 1:41:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SetUserAsAdmin]
@id_user INT
AS
BEGIN

INSERT INTO users_roles (id_user, id_role)
VALUES(@id_user, 1)

END
GO
USE [master]
GO
ALTER DATABASE [User_management] SET  READ_WRITE 
GO
