USE [MPS]
GO

/****** Object:  View [dbo].[CrewCashAdvance_Activitylist]    Script Date: 09/13/2016 1:47:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[CrewCashAdvance_Activitylist]
AS
SELECT        TOP (100) PERCENT caa.Crew, caa.IDNbr, caa.ActGrpID, caa.ActID, caa.Vessel, caa.Rank, caa.FKeyRankCode, caa.WageScale, caa.Seniority, caa.DateStarted, 
                         caa.DateEnded, caa.DueDate, caa.StartingPlace, caa.EndingPlace, caa.LOC, caa.Status, caa.PlaceSOn, caa.PlaceSOff, caa.Remarks, caa.ActivityType, caa.rn, 
                         caa.FKeyAgentCode, caa.FKeyPrinCode, caa.FKeyFlt, caa.SOFFStat, caa.FkeyWScaleCode, caa.FKeyWScaleRankCode, caa.AgentName, caa.PrinName, 
                         ws.Name + ' - ' + r.Name AS WSRank
FROM            dbo.Crewlist_Activities_All AS caa LEFT OUTER JOIN
                         dbo.tblAdmWscaleRank AS wsr ON caa.FKeyWScaleRankCode = wsr.PKey LEFT OUTER JOIN
                         dbo.tblAdmRank AS r ON wsr.FKeyRank = r.PKey LEFT OUTER JOIN
                         dbo.tblAdmWscale AS ws ON caa.FkeyWScaleCode = ws.PKey
ORDER BY caa.Crew, caa.rn

GO


