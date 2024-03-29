USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_PayView_ONB]    Script Date: 09/12/2016 12:58:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>a
-- =============================================
ALTER PROCEDURE [dbo].[SP_PayView_ONB]
	-- Add the parameters for the stored procedure here
	@Period INT
AS
BEGIN
	
--tblPay
SELECT 
	p.*,
	CONCAT(p.RefNo,' - ', v.Name) AS RefVslName,
	CAST(0 AS bit) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblAdmVsl v ON p.FKeyVsl = v.PKey
WHERE MCode = @Period
	AND Paytype = 'ONB'

--tblPayCrew_ONB
SELECT 
	ponb.*,
	CONCAT(ws.Abbrv,' - ',r.Name) AS WageScaleName,
	dbo.AssembleName(ponb.LName,ponb.FName,ponb.MName,1,1,0,0,0) As CrewName,
	p.DateCreated,
	p.RefNo,
	p.MCode,
	CAST(0 AS bit) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblPayCrew_ONB ponb ON p.PKey = ponb.FKeyPayID
	INNER JOIN dbo.tblAdmWscale ws ON ponb.FKeyWScaleCode = ws.PKey
	INNER JOIN dbo.tblAdmWscaleRank wsr ON ponb.FKeyWscalRankCode = wsr.PKey
	INNER JOIN dbo.tblAdmRank r ON wsr.FKeyRank = r.PKey
WHERE p.MCode = @Period AND Paytype = 'ONB'
ORDER BY ponb.DateStart DESC

--tblPay_ONB
SELECT ponb.*,
	CAST(0 AS bit) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblPayCrew_ONB pconb ON p.PKey = pconb.FKeyPayID
	INNER JOIN dbo.tblPay_ONB ponb on pconb.PKey = ponb.FKeyPayCrewONB
WHERE p.MCode = @Period AND Paytype = 'ONB'

--tblPayInfo
SELECT pinfo.*,
	CAST(0 AS bit) AS Edited
FROM dbo.tblPay p
	INNER JOIN dbo.tblPayCrew_ONB ponb ON p.PKey = ponb.FKeyPayID
	INNER JOIN dbo.tblPayInfo pinfo ON ponb.PKey = pinfo.PayCrewONB
WHERE p.MCode = @Period AND Paytype = 'ONB'


--tblPayExRate
SELECT e.*,
	CAST(0 AS bit) AS Edited
FROM dbo.tblPay p 
	INNER JOIN dbo.tblPayExRate e ON p.PKey = e.FKeyPay
WHERE p.MCode = @Period AND Paytype = 'ONB'

END
