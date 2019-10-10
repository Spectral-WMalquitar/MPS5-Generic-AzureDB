DECLARE @RefCurr VARCHAR(15)
DECLARE @RefAmt FLOAT

DECLARE @FKeyCurr VARCHAR(15)
DECLARE @ExRate FLOAT

--Get Referential ExRate
SELECT 
	@RefCurr = PKey,
	@RefAmt = 1
FROM dbo.tblAdmCurr
WHERE Ref = 1
SELECT @RefCurr AS RefCurr, @RefAmt AS RefAmt

DECLARE @tblPayExRate dbo.Type_tblPayExRates
INSERT INTO @tblPayExRate
SELECT FKeyCurr,ExRate  FROM dbo.tblPayExRate WHERE FKeyPay = 'SPECT0000010725'

SELECT * FROM @tblPayExRate

DECLARE @tbl TABLE(
	Amt FLOAT,
	FKeyCurr VARCHAR(15),
	RefAmt FLOAT
)
INSERT INTO @tbl
SELECT 
	Amt,FKeyCurr,
	isnull(a.Amt / nullif((SELECT ExRate FROM @tblPayExRate WHERE FKeyCurr = a.FKeyCurr),0),0) AS RefAmt
FROM dbo.tblRemitAllot a

SELECT
	Amt,
	FKeyCurr,
	RefAmt,
	Amt * (SELECT ExRate FROM @tblPayExRate WHERE FKeyCurr = a.FKeyCurr),
	(SELECT ExRate FROM @tblPayExRate WHERE FKeyCurr = a.FKeyCurr)
FROM @tbl a


