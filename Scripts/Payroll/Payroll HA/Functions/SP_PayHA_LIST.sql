USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_PayHA_LIST]    Script Date: 9/28/2016 10:51:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_PayHA_LIST] 
	-- Add the parameters for the stored procedure here
	@MCode INT
AS
BEGIN
--tblPay
SELECT 
	p.*,
	CONCAT(p.RefNo,' - ',v.Name) AS RefNoVsl
FROM dbo.tblPay p
	LEFT JOIN dbo.tblAdmVsl v ON p.FKeyVsl = v.PKey
WHERE p.MCode = @MCode AND p.Paytype = 'HA'


-- tblPayCrew_HA
SELECT 
	ha.*,
	dbo.AssembleName(ha.LName,ha.FName,ha.MName,1,1,0,0,0) AS CrewName,
	isnull(p.MCode,'') AS MCode,
	isnull(p.DateCreated,'') AS DateCreated,
	isnull(p.RefNo,'') AS RefNo,
	isnull(ci.COIDNo,'') AS COIDNo ,
	CAST(0 AS BIT) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblPayCrew_HA ha ON p.PKey = ha.FKeyPayID
	INNER JOIN dbo.tblCrewInfo ci ON ha.FKeyIDNbr = ci.PKey
	--INNER JOIN dbo.tblPay_Allot pAllot ON ha.PKey = pAllot.FKeyPayCrewHA
WHERE p.MCode =@MCode AND p.Paytype = 'HA'

--tblPayAllot
SELECT
	pAllot.*,
	ha.AmtBasic,
	CAST(0 AS BIT) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblPayCrew_HA ha ON p.PKey = ha.FKeyPayID
	INNER JOIN dbo.tblPay_Allot pAllot ON ha.PKey = pAllot.FKeyPayCrewHA
WHERE p.MCode =@MCode AND p.Paytype = 'HA'


--tblPayAsh
SELECT 
	PayAsh.*,
	CAST(0 AS BIT) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblPayCrew_HA ha ON p.PKey = ha.FKeyPayID
	INNER JOIN dbo.tblPay_Allot pAllot ON ha.PKey = pAllot.FKeyPayCrewHA
	INNER JOIN dbo.tblPay_Ash PayAsh ON pAllot.PKey = PayAsh.FKeyPayAllotID
WHERE p.MCode =@MCode AND p.Paytype = 'HA'

--tblPay_AshEmp
SELECT  
	PayAshEmp.*,
	CAST(0 AS BIT) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblPayCrew_HA ha ON p.PKey = ha.FKeyPayID
	INNER JOIN dbo.tblPay_AshEmp PayAshEmp ON ha.PKey = PayAshEmp.FKeyPayCrewHA
WHERE p.MCode = @MCode AND p.Paytype = 'HA'

SELECT 
	ERate.*,
	CAST(0 AS BIT) AS Edited
FROM dbo.tblPay p 
	INNER JOIN dbo.tblPayExRate ERate ON p.PKey = ERate.FKeyPay
WHERE p.MCode = @MCode AND p.Paytype = 'HA'

END
