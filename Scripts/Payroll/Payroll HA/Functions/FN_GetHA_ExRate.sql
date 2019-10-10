USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[FN_GetHA_ExRate]    Script Date: 24/10/2016 10:46:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION [dbo].[FN_GetHA_ExRate]
(	
	-- Add the parameters for the function here
	@DateStart DATE,
	@tblPayCrew Type_tblPayCrew_HA READONLY
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT DISTINCT
		curr.FKeyCurr, 
		CAST(CASE WHEN curr.FKeyCurr = (SELECT PKey FROM dbo.tblAdmCurr WHERE Ref <> 0) THEN 1.0	ELSE 0.0 END AS FLOAT) AS ExRate
	FROM (
		SELECT DISTINCT ws.FKeyCurr
		FROM @tblPayCrew car
			INNER JOIN dbo.tblAdmWscale ws ON car.FKeyWageScale = ws.PKey
		--/*Remittance*/
		UNION
		SELECT DISTINCT r.FKeyCurrency AS FKeyCurr
		FROM @tblPayCrew car
			INNER JOIN dbo.tblRemittance r ON car.FKeyIDNbr = r.FKeyIDNbr
		WHERE LEN(rtrim(ltrim(r.WAllot))) > 0
	
		/*Remit Allot*/
		UNION
		SELECT DISTINCT
			ra.FKeyCurr
		FROM @tblPayCrew car
			INNER JOIN dbo.tblRemittance r ON Car.FKeyIDNbr = r.FKeyIDNbr
			INNER JOIN dbo.tblRemitAllot ra ON r.PKey =ra.FKeyRemittanceID

		/* Remit OTHER Wages */
		UNION
		SELECT DISTINCT
			ra.FKeyCurr
		FROM @tblPayCrew car
			INNER JOIN dbo.tblRemittance r ON Car.FKeyIDNbr = r.FKeyIDNbr
			INNER JOIN dbo.tblRemitOtherWage ra ON r.PKey = ra.FKeyRemittanceID

		/*Wage Scale*/
		UNION
		SELECT DISTINCT
			w.FKeyCurr
		FROM @tblPayCrew car
			INNER JOIN dbo.tblAdmWscale w ON car.FKeyWageScale = w.PKey
		/*Wage Scale Ash*/
		UNION
		SELECT DISTINCT
			wr.FKeyCurr
		FROM @tblPayCrew car
			INNER JOIN dbo.tblAdmWscaleAsh wr ON car.FKeyWScaleRankCode = wr.PKey
		/*Wage AshEmp */
		UNION
		SELECT DISTINCT
			ashemp.FKeyCurr
		FROM @tblPayCrew car
			INNER JOIN dbo.tblAdmWscaleAshEmp ashemp ON car.FKeyWageScale = FKeyWageScale
	) curr
)
