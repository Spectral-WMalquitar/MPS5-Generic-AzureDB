USE [MPS]
GO

/****** Object:  View [dbo].[view_PayViewEdit_SA_CrewList]    Script Date: 07/14/2016 11:17:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[view_PayViewEdit_SA_CrewList]
AS
SELECT        
	m.PKey AS MpoID, 
	m.MCode, 
	m.DateCreated, 
	m.RefNo, 
	ac.FKeyRankCode AS FKeyRank, 
	ac.RankName, 
	ac.VslName, 
	ac.PrinName,
	dbo.AssembleName(ag.LName,ag.FName,ag.MName,1,1,0,0,0) AS CrewName,
	ag.COIDNbr
FROM
	dbo.tblmpo AS m
	LEFT JOIN dbo.tblAdmStat s ON 



GO


