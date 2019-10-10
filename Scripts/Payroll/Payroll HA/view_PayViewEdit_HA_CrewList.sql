USE [MPS]
GO

/****** Object:  View [dbo].[view_PayViewEdit_SA_CrewList]    Script Date: 08/12/2016 4:24:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[view_PayViewEdit_HA_CrewList]
AS

SELECT 
	p.PKey PayID,
	p.MCode,
	p.RefNo,
	p.DateCreated,
	p.FKeyVsl,
	p.FKeyPrincipal,
	ha.FKeyIDNbr,crew.COIDNo,
	ha.ActID,
	dbo.AssembleName(ha.LName,ha.FName,ha.MName,1,1,0,0,0) as CrewName,
	ha.LName,ha.FName,ha.MName,
	ha.FKeyRank,ha.RankName,
	FKeyStatus, ha.[Status] AS StatusName,
	ha.FKeyAgent,ha.AgentName,
	ha.DateStart,ha.DateEnd,
	ha.FKeyWScaleCode,ha.FKeyWscalRankCode
FROM dbo.tblPay p
	LEFT JOIN dbo.tblPayCrew_HA ha ON p.PKey = ha.FKeyPayID
	LEFT JOIN dbo.tblCrewInfo crew ON ha.FKeyIDNbr = crew.PKey
	LEFT JOIN dbo.tblPay_Allot pAllot ON ha.PKey = pAllot.FKeyPayCrewHA
	LEFT JOIN dbo.tblPayExRate eExRate ON p.PKey = eExRate.FKeyPay
WHERE p.Paytype = 'HA'
GO


