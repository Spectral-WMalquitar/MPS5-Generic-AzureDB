USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[PAY_HA_CrewList]    Script Date: 08/19/2016 10:37:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Earlsan,Name>
-- Create date: <Create Date,June 14, 2016,>
-- Description:	<Description,Gets the Crew Activity Within Range if Range = 1,>
-- =============================================
ALTER FUNCTION [dbo].[PAY_HA_CrewList] 
(	
	-- Add the parameters for the function here
	@DateFrom AS DATETIME, 
	@DateTo AS DATETIME
)
RETURNS TABLE 
AS
RETURN 
(

SELECT 
	--	car.*,
	--	r.WAllot
	--	,concat(CASE WHEN ISNULL(r.allotteecount,0)<= 0 THEN 'Crew doesn''t have an Allottee.' + CHAR(13) + CHAR(10) ELSE '' END,
	--			CASE WHEN car.FkeyWScaleCode is null 
	--				THEN 'Crew doesn''t have Wage Scale.' + CHAR(13) + CHAR(10) ELSE NULL END,
	--			CASE WHEN car.FKeyWScaleRankCode is null 
	--				THEN 'Crew doesn''t have Wage Scale Rank.' + CHAR(13) + CHAR(10) ELSE NULL END,
	--			CASE WHEN ra.StartPeriod IS NULL THEN 'Crew Allottee is not in range.'  + CHAR(13) + CHAR(10)
	--				WHEN isnull(ra.StartPeriod,0) < FORMAT(@DateFrom,'yyyyMM','en-US')
	--				THEN 'Crew Allottee is not in range.' + CHAR(13) + CHAR(10) ELSE NULL END) AS ToolTip,
	--	ra.StartPeriod
	--	-- ============================================ --
	--FROM CrewActivity_All_InRange(@DateFrom,@DateTo) car
	--	LEFT JOIN (SELECT PKey,FKeyIDNbr,WAllot, count(pkey) as allotteecount FROM dbo.tblRemittance WHERE WAllot is not null GROUP BY PKey,FKeyIDNbr,WAllot) r ON car.IDNbr = r.FKeyIDNbr
	--	INNER JOIN dbo.tblRemitAllot ra ON r.PKey = ra.FKeyRemittanceID
	--WHERE inRange= 1
	--SELECT 
	--	--r.LName,r.FName,r.MName,
	--	car.*
	--	,r.WAllot
	--	,ra.Amt
	--	,ra.FKeyCurr AS RemitAllotCurr
	--	,ra.StartPeriod,
	--	-- For Validations --
	--	CAST(CASE WHEN r.WAllot IS  NULL THEN isnull(r.WAllot,0) 
	--		ELSE 1 END AS BIT) AS HasWAllot,
	--	CAST(CASE WHEN car.FkeyWScaleCode IS NULL THEN ISNULL(car.FkeyWScaleCode,0)
	--		ELSE 1 END AS BIT) As HasFkeyWScale,
	--	CAST(CASE WHEN car.FKeyWScaleRankCode IS NULL THEN ISNULL(car.FKeyWScaleRankCode,0)
	--		ELSE 1 END AS BIT) As HasFKeyWScaleRankCode,
	--	CAST(CASE WHEN ra.StartPeriod IS NULL THEN ISNULL(ra.StartPeriod,0)
	--		WHEN FORMAT(ra.StartPeriod,'yyyyMM','en-US') >= FORMAT(@DateFrom,'yyyyMM','en-US') THEN 1
	--		ELSE 0 END AS BIT) As inRangeStartPeriod
	--	-- ============================================ --
	--FROM CrewActivity_All_InRange(@DateFrom,@DateTo) car
	--	LEFT JOIN dbo.tblRemittance r ON car.IDNbr = r.FKeyIDNbr
	--	LEFT JOIN dbo.tblRemitAllot ra ON r.PKey = ra.FKeyRemittanceID
	--WHERE inRange= 1
)

