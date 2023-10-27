USE [master]
GO
/****** Object:  Database [vnptauth]    Script Date: 27/10/2023 21:51:38 ******/
CREATE DATABASE [vnptauth]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'vnptauth', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\vnptauth.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'vnptauth_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\vnptauth_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [vnptauth] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [vnptauth].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [vnptauth] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [vnptauth] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [vnptauth] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [vnptauth] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [vnptauth] SET ARITHABORT OFF 
GO
ALTER DATABASE [vnptauth] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [vnptauth] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [vnptauth] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [vnptauth] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [vnptauth] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [vnptauth] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [vnptauth] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [vnptauth] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [vnptauth] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [vnptauth] SET  ENABLE_BROKER 
GO
ALTER DATABASE [vnptauth] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [vnptauth] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [vnptauth] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [vnptauth] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [vnptauth] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [vnptauth] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [vnptauth] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [vnptauth] SET RECOVERY FULL 
GO
ALTER DATABASE [vnptauth] SET  MULTI_USER 
GO
ALTER DATABASE [vnptauth] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [vnptauth] SET DB_CHAINING OFF 
GO
ALTER DATABASE [vnptauth] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [vnptauth] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [vnptauth] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [vnptauth] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'vnptauth', N'ON'
GO
ALTER DATABASE [vnptauth] SET QUERY_STORE = ON
GO
ALTER DATABASE [vnptauth] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [vnptauth]
GO
/****** Object:  Table [dbo].[categorymenu]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorymenu](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](200) NULL,
	[category_level] [int] NULL,
	[category_link] [nvarchar](500) NULL,
	[category_icon] [nvarchar](500) NULL,
	[category_note] [nvarchar](500) NULL,
	[category_active] [bit] NULL,
	[createday] [datetime] NULL,
	[position] [int] NULL,
	[category_cha_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employerpermissions]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employerpermissions](
	[role_id] [int] NULL,
	[employer_id] [int] NULL,
	[craeteday] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employers]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employers](
	[employer_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](100) NULL,
	[name_profile] [nvarchar](100) NULL,
	[job_name] [nvarchar](100) NULL,
	[company] [nvarchar](100) NULL,
	[email] [nvarchar](100) NULL,
	[number_phone] [varchar](11) NULL,
	[mobile] [varchar](11) NULL,
	[username] [nvarchar](100) NULL,
	[password] [nvarchar](100) NULL,
	[address] [nvarchar](500) NULL,
	[role_id] [int] NULL,
	[active] [bit] NULL,
	[link_website] [nvarchar](200) NULL,
	[link_git] [nvarchar](200) NULL,
	[link_facebook] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[employer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[historylogins]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[historylogins](
	[history_id] [int] IDENTITY(1,1) NOT NULL,
	[employer_id] [int] NULL,
	[datetime_login] [datetime] NULL,
	[system_login] [nvarchar](100) NULL,
	[username] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[history_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rolepermissions]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rolepermissions](
	[role_id] [int] NULL,
	[category_id] [int] NULL,
	[craeteday] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](200) NULL,
	[note] [nvarchar](500) NULL,
	[active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[employers]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([role_id])
GO
ALTER TABLE [dbo].[historylogins]  WITH CHECK ADD FOREIGN KEY([employer_id])
REFERENCES [dbo].[employers] ([employer_id])
GO
/****** Object:  StoredProcedure [dbo].[danhSachNguoiDungChuaGan]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[danhSachNguoiDungChuaGan]
(
	@role_id int

) AS
	
	SELECT  c.employer_id, c.full_name
    FROM employers c
    WHERE c.active = 1 and c.employer_id NOT IN (
        SELECT DISTINCT b.employer_id
        FROM ROLES a
        INNER JOIN employerpermissions b ON a.role_id = b.role_id
        WHERE a.role_id = @role_id
    )
GO
/****** Object:  StoredProcedure [dbo].[danhSachNguoiDungDaGan]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Lấy danh sách người dùng đã phân quyền
CREATE PROCEDURE [dbo].[danhSachNguoiDungDaGan]
(
	@role_id int

) AS

	SELECT a.role_id, b.employer_id, b.full_name 
	FROM ROLES a, employers b, employerpermissions c
	WHERE a.role_id = c.role_id
	AND c.employer_id = b.employer_id
	AND b.active = 1
	AND a.role_id = @role_id
GO
/****** Object:  StoredProcedure [dbo].[danhSachNhomQuyenChuaGan]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[danhSachNhomQuyenChuaGan]
(
	@role_id int

) AS

	SELECT c.category_id, c.category_name, c.category_icon, c.category_cha_id, c.category_level, c.category_link
    FROM CATEGORYMENU c
    WHERE c.category_id NOT IN (
        SELECT DISTINCT b.category_id
        FROM ROLES a
        INNER JOIN ROLEPERMISSIONS b ON a.role_id = b.role_id
        WHERE a.role_id = @role_id
    )
	
GO
/****** Object:  StoredProcedure [dbo].[danhSachNhomQuyenDaGan]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[danhSachNhomQuyenDaGan]
(
	@role_id int

) AS
	
	SELECT distinct a.role_id, c.category_id,c.category_name, c.category_icon, c.category_cha_id, c.category_level,c.category_link
	FROM ROLES a,
		 ROLEPERMISSIONS b,
		 CATEGORYMENU c
	WHERE a.role_id = b.role_id
	AND b.category_id = c.category_id
	AND a.role_id = @role_id


	
GO
/****** Object:  StoredProcedure [dbo].[deleteEmployPermission]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteEmployPermission]
(
	@p_role_id int,
	@p_employer_id int

) AS
	
	 BEGIN TRANSACTION;
		DELETE FROM employerpermissions where role_id = @p_role_id AND employer_id = @p_employer_id
	 COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[deleteRolePermission]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteRolePermission]
(
	@p_role_id int,
	@p_category_id int

) AS
	
	 BEGIN TRANSACTION;
		DELETE FROM rolepermissions where role_id = @p_role_id AND category_id = @p_category_id
	 COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[insertEmployPermission]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[insertEmployPermission]
(
	@p_role_id int,
	@p_employer_id int

) AS
	
	 BEGIN TRANSACTION;
		INSERT INTO employerpermissions(role_id, employer_id, craeteday) VALUES (@p_role_id, @p_employer_id, GETDATE());
	 COMMIT TRANSACTION;
GO
/****** Object:  StoredProcedure [dbo].[insertRolePermission]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[insertRolePermission]
(
	@p_role_id int,
	@p_category_id int

) AS
	
	 BEGIN TRANSACTION;
		DECLARE @category_cha_id INT;  

		SELECT @category_cha_id = category_cha_id FROM CATEGORYMENU WHERE category_id = @p_category_id; -- Tìm menu cha
		IF @category_cha_id != 0
		BEGIN
			-- Kiểm tra xem có bản ghi thỏa mãn điều kiện hay không
			IF   (SELECT COUNT(1) FROM ROLEPERMISSIONS WHERE category_id = @category_cha_id AND role_id = @p_role_id) > 0
			BEGIN
				INSERT INTO ROLEPERMISSIONS(role_id, category_id, craeteday) VALUES (@p_role_id, @p_category_id, GETDATE());
			END
			ELSE
			BEGIN
				INSERT INTO ROLEPERMISSIONS(role_id, category_id, craeteday) VALUES (@p_role_id, @p_category_id, GETDATE());
				INSERT INTO ROLEPERMISSIONS(role_id, category_id, craeteday) VALUES (@p_role_id, @category_cha_id, GETDATE()); -- Bạn có thể thêm lệnh INSERT này nếu cần
			END
		END
		ELSE
		BEGIN
			INSERT INTO ROLEPERMISSIONS(role_id, category_id, craeteday) VALUES (@p_role_id, @p_category_id, GETDATE());
		END
		COMMIT TRANSACTION;
	

GO
/****** Object:  StoredProcedure [dbo].[layDanhSachMenu]    Script Date: 27/10/2023 21:51:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[layDanhSachMenu]
(
	@p_employer_id int

) AS
	
	 SELECT distinct c.category_id, c.category_name, c.category_level, c.category_cha_id, c.category_link, c.category_icon, c.position
	FROM categorymenu c
	INNER JOIN rolepermissions b ON c.category_id = b.category_id
	INNER JOIN employerpermissions a ON b.role_id = a.role_id
	WHERE a.employer_id = @p_employer_id
	ORDER BY c.category_level, c.position


GO
USE [master]
GO
ALTER DATABASE [vnptauth] SET  READ_WRITE 
GO
