USE [MPS]
GO

/****** Object:  View [dbo].[CrewList_Activity_All_Pay]    Script Date: 07/04/2016 3:14:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[CrewList_Activity_All_Pay]
AS
SELECT        
	ag.Pkey AS ActGroupID,
	ac.Pkey AS ActID,
	ag.FKeyIDNbr AS IDNbr, 
	ag.ActivityType, 
	dbo.AssembleName(ag.LName, ag.FName, ag.MName, 1, 1, 0, 0, 0) AS Crew, 
	ag.DateDep, 
	ag.DateArr, 
	ag.PlaceDep, 
	ag.PlaceArr, 
	ag.SOFFStat, 
	ac.FKeyVslCode, 
	ac.VslName AS Vessel, 
	ac.FKeyPrinCode, 
	ac.PrinName, 
	ac.FKeyAgentCode, 
	ac.AgentName, 
	ac.FKeyFlt, 
	ac.FltName, 
	ac.FKeyStatCode,
	ac.StatName, 
	ac.ActDateStart, 
	ac.ActDateEnd, 
	ac.FKeyRankCode,
	ac.RankName,
	ac.DateSOn,
	ac.DateSOff, 
	ac.FkeyWScaleCode, 
	ac.FKeyWScaleRankCode
FROM dbo.tblActivityGroup AS ag 
	LEFT OUTER JOIN dbo.tblActivity AS ac ON ag.Pkey = ac.FKeyActivityGroupID
WHERE      
	(ag.IsCompServ = 1)
	AND ac.DateSOn is NOT NULL


GO


