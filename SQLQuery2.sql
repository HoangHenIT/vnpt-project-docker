	SELECT a.role_id, c.category_id,c.category_name, c.category_icon, c.category_cha_id, c.category_level,c.category_link
	FROM ROLES a,
		 ROLEPERMISSIONS b,
		 CATEGORYMENU c
	WHERE a.role_id = b.role_id
	AND b.category_id = c.category_id
	AND a.role_id = 1
	

	SELECT * 
	FROM ROLES a, employers b, employerpermissions c
	WHERE a.role_id = c.role_id
	AND c.employer_id = b.employer_id
	AND a.role_id = 1


		select * from CATEGORYMENU


SELECT a.role_id, c.category_id, c.category_name, c.category_icon, c.category_cha_id, c.category_level, c.category_link
FROM ROLES a
LEFT JOIN ROLEPERMISSIONS b ON a.role_id = b.role_id
LEFT JOIN CATEGORYMENU c ON b.category_id = c.category_id;
	
	
	SELECT c.category_id, c.category_name, c.category_icon, c.category_cha_id, c.category_level, c.category_link
    FROM CATEGORYMENU c
    WHERE c.category_id NOT IN (
        SELECT DISTINCT b.category_id
        FROM ROLES a
        INNER JOIN ROLEPERMISSIONS b ON a.role_id = b.role_id
        WHERE a.role_id = 1
    )
	union all 
	SELECT c.category_id, c.category_name, c.category_icon, c.category_cha_id, c.category_level, c.category_link
    FROM CATEGORYMENU c WHERE category_level = 0