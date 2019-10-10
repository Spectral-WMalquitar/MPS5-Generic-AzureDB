USE [MPS]
GO

/****** Object:  View [dbo].[frm_Pay_CrewAmort_distrib]    Script Date: 9/30/2016 3:56:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[frm_Pay_CrewAmort_distrib]
AS
SELECT 
	cAmort.FKeyIDNbr,
	cAmort.PKey,
	cAmort.StartPeriod,
	pcha.FKeyVsl,VslName,
	AmortPaid.AmtPd,
	AmortPaid.MCode,
	AmortPaid.Period
FROM dbo.tblAmortization cAmort 
	LEFT JOIN dbo.tblPay_Ash pAsh ON cAmort.PKey = pAsh.WageRecID
	LEFT JOIN dbo.tblPay_Allot pAllot ON pAsh.FKeyPayAllotID = pAllot.PKey
	LEFT JOIN dbo.tblPayCrew_HA pcHA ON pAllot.FKeyPayCrewHA = pcHA.PKey
	LEFT JOIN (
		SELECT 
			Pay.MCode,
			FORMAT(dbo.ChangeMCodeToDate(pay.MCode,1),'MMMM-yyyy','en-US') AS Period,
			pAsh.PKey AS PayAshID,
			pAsh.WageRecID,
			SUM(Amt) AS AmtPd
		FROM dbo.tblPay_Ash pAsh
			INNER JOIN dbo.tblPay_Allot pAllot ON pAsh.FKeyPayAllotID = pAllot.PKey
			INNER JOIN dbo.tblPayCrew_HA pcHA  ON pAllot.FKeyPayCrewHA = pcHA.PKey
			INNER JOIN dbo.tblPay pay ON pcHA.FKeyPayID = pay.PKey
		WHERE WageRecID IS NOT NULL
		GROUP BY
			WageRecID,
			pAsh.PKey,
			Pay.MCode,
			pAsh.DateStart) AmortPaid ON pAsh.PKey = AmortPaid.PayAshID  
--WHERE cAmort.FKeyIDNbr = @FKeyIDNbr

GO


