USE [MPS]
GO

/****** Object:  StoredProcedure [dbo].[SP_PAY_MPOSummary]    Script Date: 27/07/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,Earlsan,Name>
-- Create date: <Create Date,07/20/2016,>
-- Description:	<Description,Returns Summary of the Special Allotment Based on the Reference Number and Period,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_PAY_MPOSummary]
	-- Add the parameters for the stored procedure here
	 @Period INT, 
	 @RefNo VARCHAR(50)
AS
BEGIN

DECLARE @tblMPO TABLE(
	MPOID VARCHAR(15),
	RefNo VARCHAR(50),
	MCode INT,
	DateCreated DATE,
	PrinCode VARCHAR(15),
	PrinName VARCHAR(100),
	VslCode VARCHAR(15),
	VslName VARCHAR(100),
	FKeyMPOAllot VARCHAR(15),
	AllotName Varchar(150),
	FKeyIDNbr VARCHAR(15),
	CrewName VARCHAR(300),
	AcctName VARCHAR(100),
	AcctNbr VARCHAR(100),
	FKeyBank VARCHAR(15),
	BankName VARCHAR(100),
	BankAbbrv VARCHAR(15),
	FKeyBranch VARCHAR(15), 
	BranchName VARCHAR(100),
	BranchCntryCode VARCHAR(15),
	BankCurr VARCHAR(15),
	WageType SMALLINT,
	WageCurrency VARCHAR(15),
	FKeyWages VARCHAR(15),
	Amt FLOAT,
	cAmt FLOAT,
	ExRate FLOAT
	)
INSERT INTO @tblMPO 
SELECT
	m.PKey AS MPOID,
	m.RefNo,
	m.MCode,
	m.DateCreated,
	ma.FKeyPrincipal,
	a.PrinName,
	ma.FKeyVsl,
	a.VslName,
	ma.PKey AS FKeyMPOAllot,
	ma.AllotName,
	ma.FKeyIDNbr,
	a.RankName +' - '+ dbo.AssembleName(ci.LName,ci.FName,ci.MName,1,1,0,0,0)  AS CrewName,
	ma.AcctName,
	ma.AcctNbr,
	ma.FKeyBank,
	bank.Name,
	bank.Abbrv,
	ma.FKeyBranch,
	branch.Name,
	ma.BranchCntryCode,
	ma.FKeyCurr AS BankCurr,
	mw.WageType,
	mw.FKeyCurr AS WageCurrency,
	mw.FKeyWages,
	mw.Amt,
	mw.cAmt,
	mw.ExRate
FROM dbo.tblmpo m
	LEFT JOIN dbo.tblmpo_allot ma ON m.PKey = ma.FKeyMPO
	LEFT JOIN dbo.tblmpo_wage mw ON ma.PKey = mw.FKeyMPOAllot
	LEFT JOIN dbo.tblCrewInfo ci ON ma.FKeyIDNbr = ci.PKey
	LEFT JOIN dbo.tblActivity a ON ma.ActID = a.Pkey
	LEFT JOIN dbo.tbladmbank bank ON ma.FKeyBank = bank.PKey
	LEFT JOIN dbo.FrmBranchList branch ON ma.FKeyBranch = branch.PKey
GROUP BY 
	m.PKey,m.RefNo,m.MCode,m.DateCreated
	,ma.PKey,ma.FKeyIDNbr,ma.AcctName,
	ma.AcctNbr,ma.FKeyBank,ma.FKeyBank,ma.FKeyBranch
	,ma.BranchCntryCode,ma.FKeyCurr,mw.WageType,mw.FKeyWages,
	mw.FKeyCurr,mw.Amt, mw.cAmt, mw.ExRate,
	ma.FKeyPrincipal,
	ma.FKeyVsl,ma.AllotName,
	a.RankName,a.PrinName,a.VslName,
	ci.LName, ci.FName,ci.MName,
	bank.Name,branch.Name,bank.Abbrv
HAVING  m.MCode = @Period AND m.[RefNo]=@RefNo
ORDER BY ma.PKey, mw.WageType
--SELECT * FROM @tblMPO

--Eanings Total  Per Allottee
DECLARE @EarnAllotTable TABLE(
		FKeyMPOAllot VARCHAR(15),
		FKeyCurr VARCHAR(15),
		WageType SMALLINT,
		TAmt FLOAT,
		TcAmt FLOAT,
		ExRate FLOAT
	)
INSERT INTO @EarnAllotTable
	SELECT
		mpo.FKeyMPOAllot,
		mpo.WageCurrency,
		mpo.WageType,
		SUM(mpo.Amt),
		SUM(mpo.cAmt),
		mpo.ExRate
	FROM @tblMPO mpo
	GROUP BY
		mpo.FKeyMPOAllot,
		mpo.WageCurrency,
		mpo.WageType,
		mpo.ExRate
	HAVING WageType = 1
--SELECT * FROM @EarnAllotTable

--Deduction Total Per Allottee
DECLARE @DedAllotTable TABLE(
		FKeyMPOAllot VARCHAR(15),
		FKeyCurr VARCHAR(15),
		WageType SMALLINT,
		TAmt FLOAT,
		TcAmt FLOAT,
		ExRate FLOAT
	)
INSERT INTO @DedAllotTable
	SELECT
		mpo.FKeyMPOAllot,
		mpo.WageCurrency,
		mpo.WageType,
		SUM(mpo.Amt),
		SUM(mpo.cAmt),
		mpo.ExRate
	FROM @tblMPO mpo
	GROUP BY
		mpo.FKeyMPOAllot,
		mpo.WageCurrency,
		mpo.WageType,
		mpo.ExRate
	HAVING WageType = 2
--SELECT * FROM @DedAllotTable

SELECT 
	 mpo.MPOID,
	 mpo.RefNo,
	 mpo.VslCode,
	 mpo.VslName,
	 mpo.DateCreated,
	 mpo.FKeyIDNbr,
	 dbo.AssembleName(crewInfo.LName,crewInfo.FName,crewInfo.MName,1,1,0,0,0) AS CrewName,
	 mpo.AllotName,
	 bank.Abbrv + ' - ' + branch.Name AS Bank,
	 mpo.AcctName,
	 mpo.AcctNbr,
	 mpo.WageCurrency,
	 curr.Name AS Currency,
	 mpo.ExRate,
	 ISNULL((SELECT ISNULL(SUM(TAmt),0) FROM @EarnAllotTable ea WHERE FKeyMPOAllot= mpo.FKeyMPOAllot AND FKeyCurr = mpo.WageCurrency AND ea.WageType =1  GROUP BY FKeyCurr ),0) AS TEarn,
	 ISNULL((SELECT ISNULL(SUM(TcAmt),0) FROM  @EarnAllotTable ea WHERE FKeyMPOAllot= mpo.FKeyMPOAllot AND FKeyCurr = mpo.WageCurrency AND ea.WageType =1 GROUP BY FKeyCurr ),0) AS TcEarn,
	 ISNULL((SELECT ISNULL(SUM(TAmt),0) FROM @DedAllotTable da WHERE FKeyMPOAllot= mpo.FKeyMPOAllot AND FKeyCurr = mpo.WageCurrency AND da.WageType =2  GROUP BY FKeyCurr ),0) AS TDed,
	 ISNULL((SELECT ISNULL(SUM(TcAmt),0) FROM @DedAllotTable da WHERE FKeyMPOAllot= mpo.FKeyMPOAllot AND FKeyCurr = mpo.WageCurrency AND da.WageType =2  GROUP BY FKeyCurr ),0) AS TcDed,
	 ISNULL( ISNULL((SELECT ISNULL(SUM(TAmt),0) FROM @EarnAllotTable ea WHERE FKeyMPOAllot= mpo.FKeyMPOAllot AND FKeyCurr = mpo.WageCurrency AND ea.WageType =1  GROUP BY FKeyCurr  ),0) - ISNULL((SELECT ISNULL(SUM(TAmt),0) FROM @DedAllotTable da WHERE FKeyMPOAllot= mpo.FKeyMPOAllot AND FKeyCurr = mpo.WageCurrency AND da.WageType =2  GROUP BY FKeyCurr),0) ,0) AS TotalMPOAmt,
	 ISNULL(ISNULL((SELECT ISNULL(SUM(TcAmt),0) FROM @EarnAllotTable ea WHERE FKeyMPOAllot= mpo.FKeyMPOAllot AND FKeyCurr = mpo.WageCurrency AND ea.WageType =1  GROUP BY FKeyCurr ),0) - ISNULL((SELECT ISNULL(SUM(TcAmt),0) FROM @DedAllotTable da WHERE FKeyMPOAllot= mpo.FKeyMPOAllot AND FKeyCurr = mpo.WageCurrency AND da.WageType =2  GROUP BY FKeyCurr),0) ,0) TotalMPOcAmt

FROM @tblMPO mpo 
	LEFT JOIN dbo.tblCrewInfo crewInfo ON  mpo.FKeyIDNbr =  crewInfo.PKey
	LEFT JOIN dbo.tblAdmBank bank ON mpo.FKeyBank = bank.PKey
	LEFT JOIN dbo.FrmBranchList branch ON mpo.FKeyBranch = branch.PKey
	LEFT JOIN dbo.tblAdmCurr curr ON curr.PKey = mpo.WageCurrency
GROUP BY
	 mpo.MPOID,
	 mpo.RefNo,
	 mpo.VslCode,
	 mpo.VslName,
	 mpo.DateCreated,
	 mpo.FKeyIDNbr,
	 crewInfo.LName,crewInfo.FName,crewInfo.MName,
	 mpo.AllotName,
	 bank.Abbrv, branch.Name,
	 mpo.AcctName,
	 mpo.AcctNbr,
	 curr.Name,
	 mpo.ExRate,
	 mpo.WageCurrency,
	 mpo.FKeyMPOAllot

END


GO


