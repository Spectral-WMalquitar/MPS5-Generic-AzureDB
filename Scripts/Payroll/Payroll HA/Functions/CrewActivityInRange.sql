USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_PAY_HA_CrewList]    Script Date: 09/12/2016 3:23:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Earlsan Villegas,Name>
-- Create date: <Create Date,20160822,>
-- Description:	<Description,Crewlist For Home Allotment Process,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_PAY_HA_CrewList]
	-- Add the parameters for the stored procedure here
	@DateStart DATE, 
	@DateEnd DATE
AS
BEGIN

	DECLARE @tblRemit Table (
		FKEyIDNbr VARCHAR(15),
		--FKeyRemitID VARCHAR(15),
		RemCount INT	
	)
	INSERT INTO @tblRemit
	SELECT 
		FKeyIDNbr,
		COUNT(FKeyIDNbr) RemCount
	FROM dbo.tblRemittance r
		LEFT JOIN dbo.tblRemitAllot ra ON r.PKey = ra.FKeyRemittanceID
	GROUP BY
		FKeyIDNbr,
		r.WAllot,
		ra.StartPeriod
	HAVING (r.WAllot IS NOT NULL) AND ra.StartPeriod = FORMAT(@DateStart,'yyyyMM','en-US')

	SELECT 
		CONCAT(
		CASE WHEN ISNULL((SELECT RemCount FROM @tblRemit WHERE FKeyIDNbr=car.IDNbr),0)<= 0 THEN 'Crew doesn''t have an Allottee or Allottee is not in range.' + CHAR(13) + CHAR(10) ELSE '' END,
			CASE WHEN car.FkeyWScaleCode is null 
				THEN 'Crew doesn''t have Wage Scale.' + CHAR(13) + CHAR(10) ELSE NULL END,
			CASE WHEN car.FKeyWScaleRankCode is null 
				THEN 'Crew doesn''t have Wage Scale Rank.' + CHAR(13) + CHAR(10) ELSE NULL END) AS ToolTip,
		car.*
	FROM dbo.CrewActivityInRange(@DateStart,@DateEnd) car
		LEFT JOIN (SELECT pcHA.* 
				FROM dbo.tblPayCrew_HA pcHA
					INNER JOIN dbo.tblPay pay ON pcHA.FKeyPayID = pay.PKey
				WHERE pay.MCode = FORMAT(@DateStart,'yyyyMM','en-US') 
					AND pay.Paytype = 'HA') pay ON car.ActID = pay.ActID
	WHERE inRange = 1  AND pay.ActID IS NULL
	ORDER BY Crew ASC,car.ActDateStart DESC
END
