USE [MPS]
GO

/****** Object:  View [dbo].[frm_Pay_Crew_Advances]    Script Date: 9/30/2016 1:58:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[frm_Pay_Crew_Advances]
AS
SELECT        TOP (100) PERCENT cas.ActGroupID, cas.ActID, cas.FKeyIDNbr, dbo.AssembleName(ci.LName, ci.FName, ci.MName, 1, 1, 0, 0, 0) AS CrewName, cas.FKeyRank, 
                         cas.RankName, cas.FKeyVsl, cas.VesselName, ca.Period, FORMAT(dbo.ChangeMCodeToDate(ca.Period, 1), 'MMMM-yyyy', 'en-US') AS strPeriod, ca.FKeyCAType, 
                         admCA.Name AS CATypeName, ca.FKeyPort, port.Name AS PortName, ca.Ref, ca.DatePrepared, cas.Amt, ca.FKeyCurr, dbo.tblAdmCurr.Name AS Currency, 
                         dbo.tblAdmCurr.Symbol
FROM            dbo.tblCA AS ca INNER JOIN
                         dbo.tblCASeaman AS cas ON ca.PKey = cas.FKeyCA INNER JOIN
                         dbo.tblAdmCurr ON ca.FKeyCurr = dbo.tblAdmCurr.PKey LEFT OUTER JOIN
                         dbo.tblCrewInfo AS ci ON cas.FKeyIDNbr = ci.PKey LEFT OUTER JOIN
                         dbo.tblAdmCAType AS admCA ON ca.FKeyCAType = admCA.PKey LEFT OUTER JOIN
                         dbo.tblAdmPort AS port ON ca.FKeyPort = port.PKey
ORDER BY CrewName

GO


