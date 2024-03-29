USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_PAY_HA_CrewList]    Script Date: 9/22/2016 3:16:22 PM ******/
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
	@DateStart DATE
AS
BEGIN

DECLARE @DateEnd DATE = EOMONTH(@DateStart)


DECLARE @filtered_RemAllot TABLE(
	rc INT,
	FKeyIDNbr VARCHAR(15),
	PKey VARCHAR(15),
	FKeyRemittanceID VARCHAR(15),
	Amt FLOAT DEFAULT(0),
	FKeyCurr VARCHAR(15),
	StartPeriod INT,
	Remarks VARCHAR(200),
	DateUpdated DATETIME,
	LastUpdatedBy VARCHAR(200))
INSERT INTO @filtered_RemAllot
SELECT 
	ROW_NUMBER() OVER (PARTITION BY ra.FKeyRemittanceID ORDER BY ra.StartPeriod DESC ) AS rc,
	r.FKeyIDNbr,
	ra.PKey,
	ra.FKeyRemittanceID,
	ra.Amt,
	ra.FKeyCurr,
	ra.StartPeriod,
	ra.Remarks,
	ra.DateUpdated,
	ra.LastUpdatedBy
	FROM dbo.tblRemitAllot ra
		INNER JOIN dbo.tblRemittance r ON ra.FKeyRemittanceID = r.PKey
WHERE ra.StartPeriod <= FORMAT(@DateStart,'yyyyMM','en-US')

--SELECT * FROM @filtered_RemAllot

DECLARE @tblRemit Table (
	FKEyIDNbr VARCHAR(15),
	RemCount INT	
)
INSERT INTO @tblRemit
SELECT 
	r.FKeyIDNbr,
	COUNT(r.FKeyIDNbr) RemCount
FROM dbo.tblRemittance r
	LEFT JOIN ( SELECT * FROM @filtered_RemAllot WHERE rc= 1 )ra ON r.PKey = ra.FKeyRemittanceID
GROUP BY
	r.FKeyIDNbr,
	r.WAllot
HAVING (r.WAllot IS NOT NULL AND r.WAllot <> '')

--SELECT * FROM @tblRemit

DECLARE @temp TABLE (
	inRange VARCHAR(100),
	rc INT,
	ActGrpID VARCHAR(15),
	ActID VARCHAR(15),
	IDNbr VARCHAR(15),
	Crew VARCHAR(150),
	FKeyVslCode VARCHAR(15),
	Vessel VARCHAR(100),
	FKeyPrincode VARCHAR(15),
	PrinName VARCHAR(100),
	FKeyAgentCode VARCHAR(15),
	AgentName VARCHAR(100),
	FKeyRank VARCHAR(15),
	RankName VARCHAR(100),
	FkeyWScaleCode VARCHAR(15),
	FKeyWScaleRankCode VARCHAR(15),
	ActDateStart DATE,
	ActDateEnd DATE,
	DaysRange VARCHAR(15))
INSERT INTO @temp
SELECT
	dbo.DateIsInRange(@DateStart,@DateEnd,a.ActDateStart,a.ActDateEnd) AS inRange,
	ROW_NUMBER() OVER(PARTITION BY a.IDNBr ORDER BY a.ActDateStart DESC),
	a.ActGrpID,
	a.ActID,
	a.IDNbr,
	CONCAT(a.Crew,' - ', a.RankName),
	a.FKeyVslCode, a.VslName,
	a.FKeyPrinCode,a.PrinName,
	a.FKeyAgentCode,a.AgentName,
	a.FKeyRankCode,a.RankName,
	a.FkeyWScaleCode,
	a.FKeyWScaleRankCode,
	a.ActDateStart,
	a.ActDateEnd,
	--dbo.GetDaysONBRange(a.ActDateStart,ISNULL(a.ActDateEnd,@DateEnd),@DateStart,@DateEnd) as DaysRange
	dbo.GetDaysONBRange(@DateStart,@DateEnd,a.ActDateStart,ISNULL(a.ActDateEnd,@DateEnd)) as DaysRange
FROM dbo.Crew_ActivityList_Complete a
WHERE FORMAT(a.ActDateStart,'yyyyMM','en-US') <= FORMAT(@DateStart,'yyyyMM','en-US')
	AND ActivityType = 'SEA'
ORDER BY a.Crew ASC, a.ActDateStart ASC

--SELECT * FROM @temp WHERE inRange = 1 And rc = 1

	SELECT 
		CONCAT(
		CASE WHEN ISNULL((SELECT DISTINCT RemCount FROM @tblRemit WHERE FKeyIDNbr=car.IDNbr),0)<= 0 THEN 'Crew doesn''t have an Allottee or Allottee is not in range.' + CHAR(13) + CHAR(10) ELSE '' END,
			CASE WHEN car.FkeyWScaleCode is null 
				THEN 'Crew doesn''t have Wage Scale.' + CHAR(13) + CHAR(10) ELSE NULL END,
			CASE WHEN car.FKeyWScaleRankCode is null 
				THEN 'Crew doesn''t have Wage Scale Rank.' + CHAR(13) + CHAR(10) ELSE NULL END) AS ToolTip,
		car.*
	FROM (SELECT * FROM @temp WHERE inRange = 1 And rc = 1 )car
		LEFT JOIN (SELECT pcHA.* 
				FROM dbo.tblPayCrew_HA pcHA
					INNER JOIN dbo.tblPay pay ON pcHA.FKeyPayID = pay.PKey
				WHERE pay.MCode = FORMAT(@DateStart,'yyyyMM','en-US') 
					AND pay.Paytype = 'HA') pay ON car.ActID = pay.ActID
	WHERE inRange = 1  AND pay.ActID IS NULL
	ORDER BY Crew ASC,car.ActDateStart DESC
END
