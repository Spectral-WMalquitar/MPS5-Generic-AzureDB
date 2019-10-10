USE [MPS]
GO

/****** Object:  View [dbo].[view_PayViewEdit_SA_CrewList]    Script Date: 07/13/2016 2:35:00 PM ******/
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
	ma.PKey AS AllotID, 
	ma.FKeyIDNbr, 
	ma.ActID, 
	ma.FKeyVsl, 
	ma.FKeyPrincipal, 
	ma.AllotName,
	ma.FKeyRemittanceID, 
	ma.AcctName, 
	ma.AcctNbr, 
	ma.FKeyCurr, 
	ma.FKeyBank, 
	ma.FKeyBranch, 
	ma.BranchCntryCode, 
	ac.FKeyStatCode AS FKeyStatus,
	ac.StatName AS StatusName, 
	ac.FKeyRankCode AS FKeyRank, 
	ac.RankName, 
	ac.VslName, 
	ac.PrinName,
	dbo.AssembleName(ag.LName,ag.FName,ag.MName,1,1,0,0,0) AS CrewName,
	ag.COIDNbr
FROM
	dbo.tblmpo AS m 
	LEFT OUTER JOIN dbo.tblmpo_allot AS ma ON m.PKey = ma.FKeyMPO 
	LEFT OUTER JOIN dbo.tblActivity AS ac ON ma.ActID = ac.Pkey
	LEFT OUTER JOIN dbo.tblActivityGroup ag ON ac.FKeyActivityGroupID = ag.Pkey

GO


