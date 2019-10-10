USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_PAY_CA_CrewList]    Script Date: 19/9/2016 10:31:21 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_PAY_CA_CrewList]
	-- Add the parameters for the stored procedure here
	@Period INT,
	@VslCode VARCHAR(15)
AS
BEGIN
DECLARE @temp TABLE (
	rc INT,
	ActGrpID VARCHAR(15),
	ActID VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	CrewName VARCHAR(150),
	FKeyVslCode VARCHAR(15),
	VslName VARCHAR(100),
	FKeyPrincode VARCHAR(15),
	PrinName VARCHAR(100),
	FKeyAgentCode VARCHAR(15),
	AgentName VARCHAR(100),
	FKeyRank VARCHAR(15),
	RankName VARCHAR(100))
INSERT INTO @temp
SELECT
	ROW_NUMBER() OVER(PARTITION BY a.IDNBr ORDER BY a.ActDateStart DESC),
	a.ActGrpID,
	a.ActID,
	a.IDNbr,
	CONCAT(a.Crew,' - ', a.RankName),
	a.FKeyVslCode, a.VslName,
	a.FKeyPrinCode,a.PrinName,
	a.FKeyAgentCode,a.AgentName,
	a.FKeyRankCode,a.RankName
FROM dbo.Crew_ActivityList_Complete a
WHERE FORMAT(a.DateStarted,'yyyyMM','en-US') = @Period
	AND ActivityType = 'SEA'
	AND FKeyVslCode = @VslCode
ORDER BY a.Crew ASC, a.ActDateStart ASC

SELECT * FROM @temp WHERE rc= 1

END
