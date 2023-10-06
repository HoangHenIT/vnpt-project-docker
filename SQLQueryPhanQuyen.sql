USE [vnptauth]
GO

/****** Object:  StoredProcedure [dbo].[danhSachNguoiDungChuaGan]    Script Date: 06/10/2023 22:03:13 ******/
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



/****** Object:  StoredProcedure [dbo].[danhSachNguoiDungDaGan]    Script Date: 06/10/2023 22:03:45 ******/
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



/****** Object:  StoredProcedure [dbo].[danhSachNhomQuyenChuaGan]    Script Date: 06/10/2023 22:04:02 ******/
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


/****** Object:  StoredProcedure [dbo].[danhSachNhomQuyenDaGan]    Script Date: 06/10/2023 22:04:27 ******/
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

USE [vnptauth]
GO

/****** Object:  StoredProcedure [dbo].[insertRolePermission]    Script Date: 06/10/2023 22:04:45 ******/
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

		SELECT category_cha_id FROM CATEGORYMENU WHERE category_id = 3;
		SELECT COUNT(1) FROM ROLEPERMISSIONS WHERE category_id = 3 AND role_id = 1
	
GO






