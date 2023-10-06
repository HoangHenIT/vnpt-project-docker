--lấy danh sách nhóm quyền đã gán cho nhóm

CREATE PROCEDURE danhSachNhomQuyenDaGan
(
	@role_id int

) AS

	SELECT a.role_id, c.category_id,c.category_name, c.category_icon, c.category_cha_id, c.category_level,c.category_link
	FROM ROLES a,
		 ROLEPERMISSIONS b,
		 CATEGORYMENU c
	WHERE a.role_id = b.role_id
	AND b.category_id = c.category_id
	AND a.role_id = @role_id
	UNION ALL 
	SELECT '' as role_id, category_id, category_name,category_icon, category_cha_id, category_level,category_link 
	FROM CATEGORYMENU where category_cha_id = 0
	
EXECUTE danhSachNhomQuyenDaGan @role_id = 1

--Lấy danh sách nhóm quyền chưa gán
CREATE PROCEDURE danhSachNhomQuyenChuaGan
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
	union all 
	SELECT c.category_id, c.category_name, c.category_icon, c.category_cha_id, c.category_level, c.category_link
    FROM CATEGORYMENU c WHERE category_level = 0
	
EXECUTE danhSachNhomQuyenChuaGan @role_id = 1


--Lấy danh sách người dùng đã phân quyền
CREATE PROCEDURE danhSachNguoiDungDaGan
(
	@role_id int

) AS

	SELECT a.role_id, b.employer_id, b.full_name 
	FROM ROLES a, employers b, employerpermissions c
	WHERE a.role_id = c.role_id
	AND c.employer_id = b.employer_id
	AND b.active = 1
	AND a.role_id = @role_id
	
EXECUTE danhSachNguoiDungDaGan @role_id = 1

--Lấy danh sách người dùng Chưa phân quyền
CREATE PROCEDURE danhSachNguoiDungChuaGan
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


	ALTER PROCEDURE [dbo].[danhSachNhomQuyenChuaGan]
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
	
EXECUTE [danhSachNhomQuyenChuaGan] @role_id = 1