-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE SP_GetMPO_LIST 
	-- Add the parameters for the stored procedure here
	@MCode INT
AS
BEGIN
--MPO
 SELECT  * FROM tblmpo
 WHERE MCode = @MCode

 --MPO Allot
 SELECT * ,CAST(0 AS BIT) AS Edited
 FROM tblmpo_allot ma
	LEFT JOIN tblmpo m ON ma.FKeyMPO = m.PKey
WHERE m.MCode = @MCode

--MPO Wages
SELECT * ,CAST(0 AS BIT) AS Edited
FROM tblmpo_wage mw
	LEFT JOIN tblmpo_allot ma ON mw.FKeyMPOAllot = ma.PKey
	LEFT JOIN tblmpo m ON ma.FKeyMPO = m.PKey
WHERE m.MCode = @MCode
END
GO
