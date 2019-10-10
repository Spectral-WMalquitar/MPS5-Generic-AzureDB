USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_PayHA_LIST]    Script Date: 08/16/2016 7:23:49 AM ******/
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
	p.* 
FROM dbo.tblPay p
WHERE p.MCode = @MCode AND p.Paytype = 'HA'


-- tblPayCrew_HA
SELECT 
	ha.*,
	dbo.AssembleName(ha.LName,ha.FName,ha.MName,1,1,0,0,0) AS CrewName,
	p.MCode,
	p.DateCreated,
	p.RefNo,
	ci.COIDNo,
	CAST(0 AS BIT) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblPayCrew_HA ha ON p.PKey = ha.FKeyPayID
	INNER JOIN dbo.tblCrewInfo ci ON ha.FKeyIDNbr = ci.PKey
WHERE p.MCode =@MCode AND p.Paytype = 'HA'

--tblPayAllot
SELECT
	pAllot.*,
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
