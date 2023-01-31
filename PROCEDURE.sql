--======================================================
CREATE  PROCEDURE SP_GET_USER AS
SELECT * FROM EMPLOYERS

--xóa PROCEDURE
--DROP PROCEDURE SP_GET_USER

--run PROCEDURE
EXECUTE SP_GET_USER

CREATE PROCEDURE SP_GET_USER_v1
(
	@employer_id INT
) AS
SELECT * FROM EMPLOYERS where employer_id = @employer_id

--run PROCEDURE

EXECUTE SP_GET_USER_v1 @employer_id=1