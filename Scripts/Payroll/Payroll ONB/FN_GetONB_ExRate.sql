USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[FN_GetONB_ExRate]    Script Date: 9/27/2016 5:27:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION [dbo].[FN_GetONB_ExRate]
(	
	-- Add the parameters for the function here
	@DateStart DATE,
	@tblPayCrew Type_tblPayCrew_ONB READONLY
)
RETURNS TABLE 
AS
RETURN 
(

	/*Wage Scale*/
	SELECT 
		curr.FKeyCurr, 
		CAST(CASE WHEN curr.FKeyCurr = (SELECT PKey FROM dbo.tblAdmCurr WHERE Ref <> 0) THEN 1.0	ELSE 0.0 END AS FLOAT) AS ExRate
	FROM (
		SELECT DISTINCT ws.FKeyCurr
		FROM @tblPayCrew pc
			INNER JOIN dbo.tblAdmWscale ws ON pc.FKeyWageScale = ws.PKey
	/*Remittance*/
	UNION
	SELECT DISTINCT
		ra.FKeyCurr AS FKeyCurr
	FROM @tblPayCrew pc
		INNER JOIN dbo.tblRemittance r ON pc.FKeyIDNbr = r.FKeyIDNbr
		INNER JOIn dbo.tblRemitAllot ra ON r.PKey = ra.FKeyRemittanceID
	/*Wage Scale ONB*/
	UNION
	SELECT DISTINCT
		wsonb.FKeyCurr
	FROM @tblPayCrew pc
		INNER JOIN dbo.tblAdmWscaleOnb  wsonb ON pc.FKeyWScaleRankCode =wsonb.FKeyWScaleRank
	UNION 
	/* Variable Wages */
	SELECT DISTINCT wONB.FKeyCurr
		FROM @tblPayCrew pc
			INNER JOIN dbo.tblWageOnb wONB ON pc.FKeyIDNbr = wONB.FKeyIDNbr
	WHERE FORMAT(wONB.DateStart,'yyyyMM','en-US') <= FORMAT(EOMONTH(@DateStart),'yyyyMM','en-US')
	AND FORMAT(wONB.DateStart,'yyyyMM','en-US') >= FORMAT(@DateStart,'yyyyMM','en-US')
	AND  FORMAT(ISNULL(wONB.DateEnd,EOMONTH(@DateStart)),'yyyyMM','en-US') >=FORMAT(@DateStart,'yyyyMM','en-US')
	/*Cash Advances*/
	--UNION
	--SELECT 
	--	ca.FKeyCurr
	--FROM @tblPayCrew pc
	--	INNER JOIN dbo.tblCASeaman cas ON pc.ActID = cas.ActID
	--	INNER JOIn dbo.tblCA CA ON cas.FKeyCA = ca.PKey
	--WHERE ca.Period = FORMAT(@DateStart,'yyyyMM','en-US')
	) curr 

)
