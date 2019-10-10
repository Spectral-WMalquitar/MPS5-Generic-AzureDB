DECLARE @Period INT
DECLARE @RefNo VARCHAR(50)
SET @RefNo = 1
SET @Period = 201707

DECLARE @tblMPO TABLE(
	MPOID VARCHAR(15),
	RefNo VARCHAR(50),
	MCode INT,
	DateCreated DATE,
	PrinCode VARCHAR(15),
	VslCode VARCHAR(15),
	FKeyMPOAllot VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	AcctName VARCHAR(100),
	AcctNbr VARCHAR(100),
	FKeyBank VARCHAR(15),
	FKeyBranch VARCHAR(15), 
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
	ma.FKeyVsl,
	ma.PKey AS FKeyMPOAllot,
	ma.FKeyIDNbr,
	ma.AcctName,
	ma.AcctNbr,
	ma.FKeyBank,
	ma.FKeyBranch,
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
GROUP BY 
	m.PKey,m.RefNo,m.MCode,m.DateCreated
	,ma.PKey,ma.FKeyIDNbr,ma.AcctName,
	ma.AcctNbr,ma.FKeyBank,ma.FKeyBank,ma.FKeyBranch
	,ma.BranchCntryCode,ma.FKeyCurr,mw.WageType,mw.FKeyWages,
	mw.FKeyCurr,mw.Amt, mw.cAmt, mw.ExRate,
	ma.FKeyPrincipal,
	ma.FKeyVsl
HAVING  m.MCode = @Period AND m.[RefNo]=@RefNo
ORDER BY ma.PKey, mw.WageType

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


--OUTPUT

SELECT 
	mpo.MPOID,
	mpo.RefNo,
	mpo.DateCreated,
	mpo.PrinCode,
	mpo.VslCode,
	mpo.FKeyIDNbr,
	mpo.AcctName,
	mpo.AcctNbr,
	mpo.FKeyBank,
	mpo.FKeyBranch,
	mpo.BranchCntryCode,
	mpo.BankCurr,
	earn.TAmt AS AmtEarn,
	earn.TcAmt AS cAmtEarn,
	ded.TAmt AS AmtDed,
	ded.TcAmt AS cAmtDed,
	earn.TAmt - ded.TAmt AS TotalAmtMPO,
	earn.TcAmt - ded.TcAmt As TotalcAmtMPO
FROM @tblMPO mpo
	LEFT OUTER JOIN @EarnAllotTable earn ON earn.FKeyMPOAllot =  mpo.FKeyMPOAllot	
	LEFT OUTER JOIN @DedAllotTable ded ON ded.FKeyMPOAllot =  mpo.FKeyMPOAllot 
GROUP BY
	mpo.MPOID,
	mpo.RefNo,
	mpo.DateCreated,
	mpo.PrinCode,
	mpo.VslCode,
	mpo.FKeyMPOAllot,
	mpo.FKeyIDNbr,
	mpo.AcctName,
	mpo.AcctNbr,
	mpo.FKeyBank,
	mpo.FKeyBranch,
	mpo.BranchCntryCode,
	mpo.BankCurr,
	earn.TAmt,
	earn.TcAmt,
	ded.TAmt,
	ded.TcAmt
ORDER BY mpo.DateCreated

