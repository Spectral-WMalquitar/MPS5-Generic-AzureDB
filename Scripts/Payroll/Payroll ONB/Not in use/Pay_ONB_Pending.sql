DECLARE @DateStart DATE
DECLARE @DateEnd DATE
SET @DateStart = '08-01-2016'
SET @DateEnd = '08-31-2016'

--EXEC SP_PAY_ONB_CrewList @DateStart,@DateEnd
DECLARE @tblPayOnb TABLE(
	FKeyWageOnb VARCHAR(15),
	Prorate BIT,
	Accum BIT,
	Amt FLOAT,
	DateType INT,
	RateType INT,
	DateStart DATE,
	DateEnd DATE,
	DaysOfPay INT,
	CalWageDays INT)
INSERT INTO @tblPayOnb
SELECT
	admWS_ONB.FKeyWageOnb,
	admW_ONB.Prorata,
	admW_ONB.Accum,
	admWS_ONB.Amt,
	admWS_ONB.DateType,
	admws.RateType,
	--DateDep, DateArr,ActDateStart,ActDateEnd,DateSOn,DateSOff,
	(CASE WHEN admWS_ONB.DateType =1 THEN
		dbo.PAY_DateStart(DateDep,DateArr,ActDateStart,ActDateEnd,@DateStart,@DateEnd)
		ELSE  
		dbo.PAY_DateStart(DateSOn,DateSOff,ActDateStart,ActDateEnd,@DateStart,@DateEnd) 
		END) AS PAYDateStart,
	(CASE WHEN admWS_ONB.DateType =1 THEN
		dbo.PAY_DateEnd(DateDep,DateArr,ActDateStart,ActDateEnd,@DateStart,@DateEnd)
		ELSE  
		dbo.PAY_DateEnd(DateSOn,DateSOff,ActDateStart,ActDateEnd,@DateStart,@DateEnd) 
		END) AS PAYDateEnd,
	(DATEDIFF(day,	(CASE WHEN admWS_ONB.DateType =1 THEN
		dbo.PAY_DateStart(DateDep,DateArr,ActDateStart,ActDateEnd,@DateStart,@DateEnd)
		ELSE  
		dbo.PAY_DateStart(DateSOn,DateSOff,ActDateStart,ActDateEnd,@DateStart,@DateEnd) 
		END),
		(CASE WHEN admWS_ONB.DateType =1 THEN
		dbo.PAY_DateEnd(DateDep,DateArr,ActDateStart,ActDateEnd,@DateStart,@DateEnd)
		ELSE  
		dbo.PAY_DateEnd(DateSOn,DateSOff,ActDateStart,ActDateEnd,@DateStart,@DateEnd) 
		END))+1) AS DaysOfPay,
	dbo.FN_GetPayCalDays(@DateStart,cpay.FkeyWScaleCode) AS DaysOfWScale
FROM dbo.CrewList_Activity_All_Pay cPay
	INNER JOIN dbo.tblAdmWscale admWS ON admWS.PKey = cPay.FkeyWScaleCode
	INNER JOIN dbo.tblAdmWscaleRank admWSR ON cPay.FKeyWScaleRankCode = admWSR.PKey
	INNER JOIN dbo.tblAdmWscaleOnb admWS_ONB ON admWSr.PKey = admWS_ONB.FKeyWScaleRank
	INNER JOIN dbo.tblAdmWageOnb AdmW_ONB ON admWS_ONB.FKeyWageOnb = AdmW_ONB.PKey
WHERE ActID = 'SPECT0000020467'

SELECT 
	*,
	dbo.FN_CalculatePayONB(Amt,RateType,Prorate,Accum,DaysOfPay,CalWageDays) AS CalculatePayAmt
FROM @tblPayOnb