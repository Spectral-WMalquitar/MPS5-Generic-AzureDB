/* TEST DATA */
DELETE FROM dbo.tblPay WHERE PayType='ONB'
DECLARE @ProcessType BIT = 0
DECLARE @PeriodDateStart DATE = '2016-06-01'
DECLARE @PeriodDateEnd DATE =  EOMONTH(@PeriodDateStart)
DECLARE @LastUpdatedBy VARCHAR(200) = 'LastUpdatedBy'
DECLARE @tblPayCrew Type_tblPayCrew_ONB
INSERT INTO @tblPayCrew VALUES
--('SPECT0000030481','SPECT0000012117','SPECT0000000239','SPECT0000000002','SPECT0000000032'),
--('SPECT0000030482','SPECT0000012117','SPECT0000000239','SPECT0000000002','SPECT0000000038')

('SPECT0000030476','SPECT0000012121','SPECT0000000238','SPECT0000000002','SPECT0000000039'),
('SPECT0000020468','SPECT0000012121','SPECT0000000238','SPECT0000000002','SPECT0000000026'),
('SPECT0000020467','SPECT0000012121','SPECT0000000238','SPECT0000000002','SPECT0000000031')

--('SPECT0000019985','SPECT0000012062','SPECT0000000257','SPECT0000000023','SPECT0000000134') --Alfanta

DECLARE @tblExRate Type_tblPayExRates
INSERT INTO @tblExRate VALUES
('SYSCUUSD',1),('SYSCUPHP',45),('SYSCUSNG',2)
--('SYSCUUSD',1)
--,('SYSCUPHP',45)
--('SYSCUUSD',10),

DECLARE @tblPay Type_tblPayONB
INSERT INTO @tblPay VALUES
('201608',GETDATE(),'1','SPECT0000000005','SPECT0000000238')

DECLARE @RefNo VARCHAR(50)= 'RefNo1'
DECLARE @DateCreated DATE = GetDATE()
DECLARE @FKeyPrincipal VARCHAR(15) = 'SPECT0000000005'
/* TEST DATA */


/* INSERTED tblPay ITEMS */
DECLARE @iTblPay TABLE(
		PKey VARCHAR(15),
		MCode INT,
		DateCreated DATE,
		RefNo VARCHAR(50),
		FKeyPrincipal VARCHAR(15),
		FKeyVsl VARCHAR(15),
		RefCurr VARCHAR(15))

/* ExChange Rates */
DECLARE @iExRate TABLE(
	FKeyPay VARCHAR(15),
	FKeyCurr VARCHAR(15),
	ExRate FLOAT)
/* NOTE: @ProcessType 0: New Payroll;1: Add New Crew To existing */
IF @ProcessType = 0 -- new PayCrew
BEGIN
	DECLARE @RefCurr AS VARCHAR(15)
	SELECT @RefCurr = PKey FROM dbo.tblAdmCurr WHERE Ref <> 0
	/* ================ Process tblPay ================ */
	INSERT INTO dbo.tblPay(
		MCode,
		DateCreated,
		RefNo,
		FKeyVsl,
		FKeyPrincipal,
		Paytype,
		LastUpdatedBy,
		RefCurr)
	OUTPUT 
		inserted.PKey,
		inserted.MCode,
		inserted.DateCreated,
		inserted.RefNo,
		inserted.FKeyPrincipal,
		inserted.FKeyVsl,
		inserted.RefCurr
	INTO @iTblPay
	SELECT 
		FORMAT(@PeriodDateStart,'yyyyMM','en-US'),
		@DateCreated,
		@RefNo,
		FKeyVslCode,
		@FKeyPrincipal,
		'ONB',
		@LastUpdatedBy ,
		@RefCurr
	FROM @tblPayCrew
	GROUP BY
		FKeyVslCode
	--SELECT * FROM @iTblPay
	/* ================ Process tblPay ================ */


	/* ================ Process tblPayExRate ================ */

	INSERT INTO dbo.tblPayExRate(
		FKeyPay,
		FKeyCurr,
		ExRate)
	OUTPUT
		inserted.FKeyPay,
		inserted.FKeyCurr,
		inserted.ExRate
	INTO @iExRate
	SELECT 
		iPay.PKey,
		er.FKeyCurr,
		er.ExRate
	FROM @iTblPay iPay, @tblExRate er
	--SELECT * FROM @iExRate
	/* ================ Process tblPayExRate ================ */
END
ELSE
BEGIN
/* ================ Process tblPay ================ */
	INSERT INTO @iTblPay(
		PKey,
		MCode,
		DateCreated,
		RefNo,
		FKeyPrincipal,
		FKeyVsl,
		RefCurr)
	SELECT 
		PKey,
		MCode,
		DateCreated,
		RefNo,
		FKeyPrincipal,
		FKeyVsl,
		RefCurr
	FROM dbo.tblPay
	WHERE Paytype = 'ONB' AND MCode = FORMAT(@PeriodDateStart,'yyyyMM','es-US')
/* ================ Process tblPayExRate ================ */
	INSERT INTO @iExRate(
		FKeyPay,
		FKeyCurr,
		ExRate)
	SELECT
		FKeyPay,
		FKeyCurr,
		ExRate
	FROM dbo.tblPayExRate er
		INNER JOIN @iTblPay p ON er.FKeyPay = p.PKey
	WHERE p.MCode = FORMAT(@PeriodDateStart,'yyyyMM','en-US')

END

/* ================ Process tblPayCrew_ONB ================ */
DECLARE @iTblPayCrewOnb TABLE(
	PKey VARCHAR(15),
	FKeyPayID VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	ActGroupID VARCHAR(15),
	ActID VARCHAR(15),
	DateStart DATE,
	DateEnd DATE)
INSERT INTO dbo.tblPayCrew_ONB(
	FKeyPayID,
	FKeyIDNbr,
	ActGrpID,
	ActID,
	LName,FName,MName,
	CivilStatCode,
	FKeyRank,RankName,
	FKeyStatus,[Status],
	FKeyVsl,[VslName],
	FKeyAgent,AgentName,
	FKeyPrincipal,PrincipalName,
	DateStart,DateEnd,
	FKeyWScaleCode,FKeyWscalRankCode,
	PreviousBalance,NetAmount,
	LastUpdatedBy)
OUTPUT
	inserted.PKey,
	inserted.FKeyPayID,
	inserted.FKeyIDNbr,
	inserted.ActGrpID,
	inserted.ActID,
	inserted.DateStart,
	inserted.DateEnd
INTO @iTblPayCrewOnb
SELECT 
	pONB.PKey,
	pCrew.FKeyIDNbr,
	a.FKeyActivityGroupID,
	pCrew.ActID,
	ag.LName,ag.FName,ag.MName,
	ci.FKeyCivilStat,
	a.FKeyRankCode,a.RankName,
	a.FKeyStatCode,a.StatName,
	pCrew.FKeyVslCode,a.VslName,
	a.FKeyAgentCode, a.AgentName,
	a.FKeyPrinCode,a.PrinName,
	CASE WHEN a.ActDateStart < @PeriodDateStart THEN @PeriodDateStart ELSE a.ActDateStart END,
	CASE WHEN ISNULL(a.ActDateEnd,@PeriodDateEnd) >= @PeriodDateEnd THEN @PeriodDateEnd ELSE a.ActDateEnd END,
	pCrew.FKeyWageScale,pCrew.FKeyWScaleRankCode,
	0,0,
	@LastUpdatedBy
FROM dbo.tblActivity a
	INNER JOIN dbo.tblActivityGroup ag ON a.FKeyActivityGroupID = ag.Pkey
	INNER JOIN @tblPayCrew pCrew ON a.Pkey = pCrew.ActID
	INNER JOIN @iTblPay pONB ON pCrew.FKeyVslCode = pONB.FKeyVsl
	INNER JOIN dbo.tblCrewInfo ci ON ci.PKey = ag.FKeyIDNbr
ORDER BY a.ActDateStart ASC
--SELECT * FROM @iTblPayCrewOnb
/* ================ Process tblPayCrew_ONB ================ */


/* ================ Process tblPay_ONB ================ */
DECLARE @iTemp_TblPayCrewOnb TABLE(
	Act_ORDER INT,
	PKey VARCHAR(15),
	FKeyPayID VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	ActGroupID VARCHAR(15),
	ActID VARCHAR(15),
	DateStart DATE,
	DateEnd DATE)
INSERT INTO @iTemp_TblPayCrewOnb
SELECT
	ROW_NUMBER() OVER (PARTITION BY p.FKeyIDNbr ORDER BY a.ActDateStart ASC ), -- Activity ORDER BY
	p.PKey,
	p.FKeyPayID,
	p.FKeyIDNbr,
	p.ActGroupID,
	p.ActID,
	p.DateStart,
	p.DateEnd
FROM @iTblPayCrewOnb p
	INNER JOIN dbo.tblActivity a ON p.ActID = a.Pkey
ORDER BY 
	p.FKeyIDNbr,
	a.ActDateStart ASC
--SELECT * FROM @iTemp_TblPayCrewOnb


-- without the Computed Amount
/* With Variable Wages*/
DECLARE @temp_tblPayOnb TABLE(
	Temp_PayActID INT,
	FKeyIDNbr VARCHAR(15),
	FKeyPayCrewONB VARCHAR(15),
	FKeyWageOnb VARCHAR(15),
	WageType SMALLINT,
	FullAmt FLOAT,
	FKeyCurr VARCHAR(15),
	ExRate FLOAT,
	DateStart DATE,
	DateEnd DATE,
	Prorata BIT,
	Accum BIT,
	BeginBal FLOAT DEFAULT(0),
	ForwBal FLOAT DEFAULT(0),
	RateType INT,
	DaysOfPay INT,
	CalWageDays INT,
	ActDateStart DATE)
INSERT INTO @temp_tblPayOnb(
	Temp_PayActID,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	DateStart,
	DateEnd,
	Prorata,
	Accum,
	BeginBal,
	ForwBal,
	RateType,
	DaysOfPay,
	CalWageDays,
	ActDateStart)
/* Items From PayScale*/
SELECT
	--ROW_NUMBER() OVER (PARTITION BY payCrew.PKey ORDER BY cPay.ActDateStart ASC ) AS rn,
	payCrew.Act_ORDER,
	cpay.IDNbr,
	payCrew.PKey,
	admWS_ONB.FKeyWageOnb,
	AdmW_ONB.WageType,
	admWS_ONB.Amt, --Full Amount
	admWS_ONB.FKeyCurr,
	--(SELECT ExRate FROM @iExRate WHERE FKeyPay = paycrew.FKeyPayID AND FKeyCurr = admWS_ONB.FKeyCurr) AS ExRate,
	(SELECT ExRate FROM @tblExRate WHERE /*FKeyPay = paycrew.FKeyPayID AND*/ FKeyCurr = admWS_ONB.FKeyCurr) AS ExRate,
	(CASE WHEN admWS_ONB.DateType =1 THEN
		dbo.PAY_DateStart(DateDep,DateArr,ActDateStart,ActDateEnd,@PeriodDateStart,@PeriodDateEnd)
		ELSE  
		dbo.PAY_DateStart(DateSOn,DateSOff,ActDateStart,ActDateEnd,@PeriodDateStart,@PeriodDateEnd) 
		END) AS PAYDateStart,
	(CASE WHEN admWS_ONB.DateType =1 THEN
		dbo.PAY_DateEnd(DateDep,DateArr,ActDateStart,ActDateEnd,@PeriodDateStart,@PeriodDateEnd)
		ELSE  
		dbo.PAY_DateEnd(DateSOn,DateSOff,ActDateStart,ActDateEnd,@PeriodDateStart,@PeriodDateEnd) 
		END) AS PAYDateEnd,
	admWS_ONB.Prorata,
	admWS_ONB.Accum,
	0, --Net Amount
	0, --Forwarding Bal
	admws.RateType,
	(DATEDIFF(day,	(CASE WHEN admWS_ONB.DateType =1 THEN
		dbo.PAY_DateStart(DateDep,DateArr,ActDateStart,ActDateEnd,@PeriodDateStart,@PeriodDateEnd)
		ELSE  
		dbo.PAY_DateStart(DateSOn,DateSOff,ActDateStart,ActDateEnd,@PeriodDateStart,@PeriodDateEnd) 
		END),
		(CASE WHEN admWS_ONB.DateType =1 THEN
		dbo.PAY_DateEnd(DateDep,DateArr,ActDateStart,ActDateEnd,@PeriodDateStart,@PeriodDateEnd)
		ELSE  
		dbo.PAY_DateEnd(DateSOn,DateSOff,ActDateStart,ActDateEnd,@PeriodDateStart,@PeriodDateEnd) 
		END))+1) AS DaysOfPay,
	dbo.FN_GetPayCalDays(@PeriodDateStart,admws.FKeyWScalCalendar),
	cPay.ActDateStart 
FROM dbo.CrewList_Activity_All_Pay cPay
	INNER JOIN dbo.tblAdmWscale admWS ON admWS.PKey = cPay.FkeyWScaleCode
	INNER JOIN dbo.tblAdmWscaleRank admWSR ON cPay.FKeyWScaleRankCode = admWSR.PKey
	INNER JOIN dbo.tblAdmWscaleOnb admWS_ONB ON admWSr.PKey = admWS_ONB.FKeyWScaleRank
	INNER JOIN dbo.tblAdmWageOnb AdmW_ONB ON admWS_ONB.FKeyWageOnb = AdmW_ONB.PKey
	INNER JOIN @iTemp_TblPayCrewOnb payCrew ON cPay.ActID = paycrew.ActID
ORDER BY cPay.ActDateStart ASC
--SELECT * FROM @temp_tblPayOnb ORDER BY FKeyIDNbr

-- WITH COMPUTED AMOUNT
DECLARE @tblPayOnb TABLE(
	ActOrder INT,
	FKeyIDNbr VARCHAR(15),
	FKeyPayCrewONB VARCHAR(15),
	FKeyWageOnb VARCHAR(15),
	WageType SMALLINT,
	FullAmt FLOAT,
	FKeyCurr VARCHAR(15),
	ExRate FLOAT,
	Amt FLOAT DEFAULT(0),
	RefAmount FLOAT DEFAULT(0),
	DateStart DATE,
	DateEnd DATE,
	Prorata BIT,
	Accum BIT,
	BeginBal FLOAT DEFAULT(0),
	ForwBal FLOAT DEFAULT(0),
	WageRecID VARCHAR(15),
	CAmt AS (RefAmount))
/*  Start :  Variable  Wages*/
DECLARE @tblPayOnb_Variable TABLE(
	ActOrder INT,
	FKeyIDNbr VARCHAR(15),
	FKeyPayCrewONB VARCHAR(15),
	FKeyWageOnb VARCHAR(15),
	WageType SMALLINT,
	FullAmt FLOAT,
	FKeyCurr VARCHAR(15),
	ExRate FLOAT,
	Amt FLOAT DEFAULT(0),
	RefAmount FLOAT DEFAULT(0),
	DateStart DATE,
	DateEnd DATE,
	Prorata BIT,
	Accum BIT,
	BeginBal FLOAT DEFAULT(0),
	ForwBal FLOAT DEFAULT(0),
	WageRecID VARCHAR(15),
	CAmt AS (RefAmount))
/* Temp For Variable Wages*/
INSERT INTO @tblPayOnb_Variable(
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	RefAmount,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal)
/* PayScale Wages */
SELECT 
	p.Temp_PayActID,
	p.FKeyIDNbr,
	p.FKeyPayCrewONB,
	p.FKeyWageOnb,
	p.WageType,
	p.FullAmt,
	p.FKeyCurr,
	p.ExRate,
	dbo.FN_CalculatePayONB(FullAmt,RateType,Prorata,Accum,DaysOfPay,CalWageDays) AS Amt, --Amt
	dbo.FN_RefAmount(@tblExRate,dbo.FN_CalculatePayONB(FullAmt,RateType,Prorata,Accum,DaysOfPay,CalWageDays),p.FKeyCurr,p.FKeyCurr) AS RefAmt, --RefAmt
	p.DateStart,
	p.DateEnd,
	p.Prorata,
	p.Accum,
	p.BeginBal,
	p.ForwBal
FROM @temp_tblPayOnb p
UNION
SELECT /* Variable Wages */
	pcONB.Act_ORDER,
	wgONB.FKeyIDNbr,
	pcONB.PKey AS FKeyPayCrewONB,
	wgONB.FKeyWageOnbID,
	wgONB.WageType,
	wgONB.Amt AS FullAmt,--FullAmt
	wgONB.FKeyCurr,
	(SELECT ExRate FROM @tblExRate WHERE FKeyCurr = wgONB.FKeyCurr) AS ExRate,
	wgONB.Amt AS Amt,
	--dbo.FN_CalculatePayONB( wgOnb.Amt , .RateType, pcONB.Prorata,wgONB.Accum,DaysOfPay,pcONB.CalWageDays) AS Amt,
	dbo.FN_RefAmount(@tblExRate,wgONB.Amt,wgONB.FKeyCurr,p.RefCurr) AS RefAmount, --RefAmt
	dbo.PAY_DateStart(pcONB.DateStart,pcONB.DateEnd,wgONB.DateStart,wgONB.DateEnd,@PeriodDateStart,@PeriodDateEnd) AS DateStart,
	dbo.PAY_DateEnd(pcONB.DateStart,pcONB.DateEnd,wgONB.DateStart,wgONB.DateEnd,@PeriodDateStart,@PeriodDateEnd) AS DateEnd,
	--0 AS Prorata,
	ISNULL((SELECT Prorata FROM @temp_tblPayOnb WHERE FKeyIDNbr = wgONB.FKeyIDNbr AND ActID = wgONB.FKeyActivityID AND FKeyWageOnb = wgONB.FKeyWageOnbID AND FKeyCurr = wgONB.FKeyCurr AND FKeyPayCrewONB = pcONB.PKey),0) AS Prorata,
	ISNULL((SELECT Accum FROM @temp_tblPayOnb WHERE FKeyIDNbr = wgONB.FKeyIDNbr AND ActID = wgONB.FKeyActivityID AND FKeyWageOnb = wgONB.FKeyWageOnbID AND FKeyCurr = wgONB.FKeyCurr  AND FKeyPayCrewONB = pcONB.PKey),0) AS Accum,
	0 AS BeginBal, 0 As ForwBal
FROM dbo.tblWageOnb wgONB 
	LEFT JOIN @iTemp_TblPayCrewOnb  pcONB  ON wgONB.FKeyActivityID = pcONB.ActID
	INNER JOIN @iTblPay p ON pcONB.FKeyPayID = p.PKey
WHERE  FORMAT(wgONB.DateStart,'yyyyMM','en-US') <= FORMAT(@PeriodDateEnd,'yyyyMM','en-US')
	AND FORMAT(wgONB.DateStart,'yyyyMM','en-US') >= FORMAT(@PeriodDateStart,'yyyyMM','en-US')
	AND  FORMAT(ISNULL(wgONB.DateEnd,@PeriodDateEnd),'yyyyMM','en-US') >=FORMAT(@PeriodDateEnd,'yyyyMM','en-US')
/* INSERT VARiable Wages MERGE WITH PAY */

DECLARE @tblPayOnbTemp TABLE(
	ActOrder INT,
	FKeyIDNbr VARCHAR(15),
	FKeyPayCrewONB VARCHAR(15),
	FKeyWageOnb VARCHAR(15),
	WageType SMALLINT,
	FullAmt FLOAT,
	FKeyCurr VARCHAR(15),
	ExRate FLOAT,
	Amt FLOAT DEFAULT(0),
	RefAmount FLOAT DEFAULT(0),
	DateStart DATE,
	DateEnd DATE,
	Prorata BIT,
	Accum BIT,
	BeginBal FLOAT DEFAULT(0),
	ForwBal FLOAT DEFAULT(0),
	WageRecID VARCHAR(15),
	CAmt FLOAT DEFAULT(0))
INSERT INTO @tblPayOnbTemp(
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	RefAmount,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal,
	CAmt)
SELECT 
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	SUM(FullAmt) AS FullAmt,
	FKeyCurr,
	ExRate,
	SUM(Amt) AS Amt,
	SUM(RefAmount) AS RefAmount,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal,
	Sum(CAmt)
FROM @tblPayOnb_Variable
GROUP BY
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FKeyCurr,
	ExRate,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal
INSERT INTO @tblPayOnb(
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	RefAmount,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal)
SELECT 
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	RefAmount,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal
 FROM @tblPayOnbTemp
/* END:   Variable  Wages*/

/* LATEST Activity of the Processed Period */
DECLARE @iPayCrew_Latest_Act TABLE(
	ActOrder_ASC INT,
	Latest_Act INT,
	PKey VARCHAR(15),
	FKeyPayID VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	ActGroupID VARCHAR(15),
	ActID VARCHAR(15),
	DateStart DATE,
	DateEnd DATE)
INSERT INTO @iPayCrew_Latest_Act
SELECT 
	p.Act_ORDER,
	ROW_NUMBER() OVER (PARTITION BY p.FKeyIDNbr ORDER BY p.Act_ORDER DESC ),
	p.PKey,
	p.FKeyPayID,
	p.FKeyIDNbr,
	p.ActGroupID,
	p.ActID,
	p.DateStart,
	p.DateEnd
FROM @iTemp_TblPayCrewOnb p
--SELECT * FROM @iPayCrew_Latest_Act WHERE Latest_Act = 1


/* CALCULATE FOR PAY_ONB FORWARDING AND BEGINING BALANCE */
DECLARE @ActOrder INT
DECLARE @payCrewID_T INT
DECLARE @BeginBal FLOAT
DECLARE @ForwBal FLOAT
DECLARE @Amt FLOAT
DECLARE @Accum BIT
DECLARE @FKeyPayCrewONB VARCHAR(15)
DECLARE @FKeyWageONB VARCHAR(15)
DECLARE @FKeyIDNbr VARCHAR(15)
DECLARE @isProrata BIT
DECLARE @isAccum BIT
DECLARE C_Cur CURSOR FOR	
	SELECT 
		ActOrder,
		ForwBal,
		BeginBal,
		Amt,
		FKeyPayCrewONB,
		Accum,
		FKeyWageOnb,
		FKeyIDNbr
		--Prorata,
		--Accum
	FROM @tblPayOnb
	--ORDER BY ActDateStart ASC
OPEN C_Cur
FETCH NEXT FROM C_Cur INTO @ActOrder,@ForwBal,@BeginBal,@Amt,@FKeyPayCrewONB,@Accum,@FKeyWageONB,@FKeyIDNbr
WHILE @@FETCH_STATUS  = 0
BEGIN
	IF @ActOrder <= 1
	BEGIN
		/* GET THE PREVIOUS MONTH BALANCE OF THE SAME WAGE ONB */
		DECLARE @PrevMonthForwBal FLOAT
		SELECT @PrevMonthForwBal =  dbo.FN_ONB_CalculateONB_AccumBalance(@PeriodDateStart,@FKeyIDNbr,@Accum,@FKeyWageONB)
		UPDATE @tblPayOnb SET 
			ForwBal = @PrevMonthForwBal + @Amt,
			BeginBal = @PrevMonthForwBal
		WHERE 
			ActOrder = @ActOrder 
			AND FKeyPayCrewONB = @FKeyPayCrewONB
			AND FKeyWageOnb = @FKeyWageONB
			AND FKeyIDNbr = @FKeyIDNbr
			AND Accum =0
	END
	ELSE
	BEGIN
		DECLARE @fb1 FLOAT = 0
		DECLARE @bb1 FLOAT = 0
		SELECT 
			@fb1 = ForwBal,
			@bb1 = BeginBal 
		FROM @tblPayOnb 
		WHERE 
			ActOrder = @ActOrder -1
			AND FKeyWageOnb = @FKeyWageONB
			AND FKeyIDNbr = @FKeyIDNbr
			AND Accum = 1

		UPDATE @tblPayOnb SET
			ForwBal = CASE WHEN Accum <> 0 THEN @fb1 + @Amt ELSE 0 END,
			Amt = CASE WHEN @fb1 > 0 THEN Amt + @fb1 ELSE @Amt END,
			BeginBal = @fb1
		WHERE ActOrder = @ActOrder 
			AND FKeyPayCrewONB = @FKeyPayCrewONB
			AND FKeyWageOnb = @FKeyWageONB
			AND Accum =0
	END
	FETCH NEXT FROM C_Cur INTO @ActOrder,@ForwBal,@BeginBal,@Amt,@FKeyPayCrewONB,@Accum,@FKeyWageONB,@FKeyIDNbr
END
CLOSE C_Cur
DEALLOCATE C_Cur

/* CASH ADVANCE */
INSERT INTO @tblPayOnb(
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	RefAmount,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal,
	WageRecID)
SELECT 
	pcONB.Act_ORDER,
	cas.FKeyIDNbr, 
	pcONB.PKey, --PayCrewONB ID
	ca.FKeyCAType, --Wage Onboard ID (Advance Type)
	2, --Wage Type (DEDUCTION)
	cas.Amt,
	ca.FKeyCurr,
	ca.ExRate,
	cas.Amt,
	cas.Amt / nullif(ca.ExRate,0), --RefAmt
	@PeriodDateStart,
	@PeriodDateEnd,
	0,0,0.0,0.0,
	cas.PKey --WageRecID
FROM @iTemp_TblPayCrewOnb pcONB
	INNER JOIN  dbo.tblCASeaman cas ON pcONB.ActID = cas.ActID
	INNER JOIN dbo.tblCA ca ON cas.FKeyCA = ca.PKey
WHERE ca.Period = FORMAT(@PeriodDateStart,'yyyyMM','en-US')
--SELECT * FROM @tblPayOnb
/* CASH ADVANCE */

/* INSERT INTO tblPay_ONB */
/* Add Allotment tblONB */
DECLARE @tblHA TABLE(
	ActID VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	FKeyWageAsh VARCHAR(15),
	WageType SMALLINT,
	Amt FLOAT DEFAULT(0),
	RefAmount FLOAT DEFAULT(0),
	FKeyCurr VARCHAR(15),
	ExRate FLOAT DEFAULT(0),
	DateStart DATE, DateEnd DATE,
	CAmt AS(RefAmount * ExRate))
INSERT INTO @tblHA
SELECT DISTINCT
	(SELECT ActID  FROM @iPayCrew_Latest_Act WHERE Latest_Act = 1) AS ActID,
	pcha.FKeyIDNbr,
	pAsh.FKeyWageAsh,
	2,
	pAsh.Amt,
	dbo.FN_RefAmount(@tblExRate,pAsh.Amt,pAsh.FKeyCurr,pay.RefCurr) AS RefAmount,
	pAsh.FKeyCurr,
	(SELECT ExRate FROM @tblExRate WHERE FKeyCurr = pAsh.FKeyCurr),
	pAsh.DateStart,
	pash.DateEnd
FROM dbo.tblPay pay 
	INNER JOIN dbo.tblPayCrew_HA pcHA ON pay.PKey = pcHA.FKeyPayID
	INNER JOIN dbo.tblPay_Allot pAllot ON pcHA.PKey = pAllot.FKeyPayCrewHA
	INNER JOIN (SELECT *  FROM @iPayCrew_Latest_Act WHERE Latest_Act = 1) HA ON pcHA.ActID = ha.ActID
	INNER JOIN dbo.tblPay_Ash pAsh ON pAllot.PKey = pAsh.FKeyPayAllotID
WHERE pay.MCode =  FORMAT(@PeriodDateStart,'yyyyMM','en-US')
	AND pash.FKeyWageAsh = 'SYSPAYALLOT'
	AND pay.Paytype = 'HA'
--SELECT * FROM @tblHA

INSERT INTO @tblPayOnb(
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	RefAmount,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal)
SELECT 
	payONB.ActOrder_ASC,
	rem.FKeyIDNbr,
	payONB.PKey,
	rem.FKeyWageAsh,
	2,
	rem.Amt,
	rem.FKeyCurr,
	--(SELECT ExRate FROM @iExRate WHERE FKeyPay = payONB.FKeyPayID AND FKeyCurr = rem.FKeyCurr),
	(SELECT ExRate FROM @tblExRate WHERE  FKeyCurr = rem.FKeyCurr),
	rem.Amt,
	--ISNULL(rem.Amt,0 )* ISNULL((SELECT ExRate FROM @iExRate WHERE FKeyPay = payONB.FKeyPayID AND FKeyCurr = rem.FKeyCurr),0),
	dbo.FN_RefAmount(@tblExRate,rem.Amt,rem.FKeyCurr,pay.RefCurr),
	rem.DateStart,
	rem.DateEnd,
	0,0,0,0
--FROM dbo.tblPay pay
FROM @iTblPay pay
	INNER JOIN @iTemp_TblPayCrewOnb pcHA ON pay.PKey = pcHA.FKeyPayID
	INNER JOIN(SELECT * FROM @iPayCrew_Latest_Act WHERE Latest_Act =1) payONB ON pcHA.FKeyIDNbr = payONB.FKeyIDNbr
	INNER JOIN @tblHA rem  ON pcHA.ActID = rem.ActID
--SELECT * FROM @tblPayOnb
/* Add Allotment tblONB */

/* Special Allotment */
INSERT INTO @tblPayOnb(
	ActOrder,
	FKeyIDNbr,
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	RefAmount,
	DateStart,
	DateEnd,
	Prorata,
	Accum ,
	BeginBal,
	ForwBal)
SELECT 
	pcONB.ActOrder_ASC,
	pcONB.FKeyIDNbr,
	pcONB.PKey,
	mwage.FKeyWages,
	2,--Wage Type
	mWage.Amt, --Full Amt
	mwage.FKeyCurr,
	mwage.ExRate,
	mWage.Amt, --Amt
	dbo.FN_RefAmount(@TblExRate,mwage.amt,mWage.FKeyCurr,@RefCurr), --RefAmt
	@PeriodDateStart,
	@PeriodDateEnd,
	admONB.Prorata,
	admONB.Accum,
	0, --Begin Balance
	0  --Forwarding Balance
FROM @iPayCrew_Latest_Act pcONB
	INNER JOIN dbo.tblmpo_allot mAllot ON pcONB.FKeyIDNbr = mAllot.FKeyIDNbr
	INNER JOIN dbo.tblmpo mpo ON mAllot.FKeyMPO = mpo.PKey
	INNER JOIN dbo.tblmpo_wage mWage ON mAllot.PKey = mWage.FKeyMPOAllot
	INNER JOIN dbo.tblAdmWageOnb admONB ON admONB.PKey = mWage.FKeyWages
WHERE mWage.FKeyWages IN ('SYSPAYMPO')
	AND mpo.MCode = FORMAT(@PeriodDateStart,'yyyyMM','en-US')
	AND pcONB.Latest_Act = 1
--SELECT * FROM @tblPayOnb

--FROM dbo.tblmpo m
--	INNER JOIN dbo.tblmpo_allot mAllot ON m.PKey = mAllot.FKeyMPO
--	INNER JOIN dbo.tblmpo_wage mWage ON mAllot.PKey = mWage.FKeyMPOAllot
--WHERE m.MCode = @PeriodDateStart
--	AND mWage.FKeyWages IN('SYSPAYMPO')

/* Special Allotment */

--SELECT * FROM @tblPayONB
/* INSERT INTO tblPay_ONB */
INSERT INTO dbo.tblPay_ONB(
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	CAmt,
	DateStart,DateEnd,
	Prorata, Accum,
	PreviousBalance,ForwardingBalance,
	WageRecID,
	LastUpdatedBy)
SELECT
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,CAmt,
	DateStart,DateEnd,
	Prorata,Accum,
	BeginBal,ForwBal,
	WageRecID,
	@LastUpdatedBy
FROM @tblPayOnb
/* INSERT INTO tblPay_ONB */


/* CREW ONB FORWARDING / NET AMOUNT */
DECLARE @temp_onbNetPay TABLE(
	ActOrder INT,
	FKeyCrewONB VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	NetAmt FLOAT DEFAULT(0),
	WageType SMALLINT,
	Accum BIT)
INSERT INTO @temp_onbNetPay
SELECT 
	p.ActOrder,
	p.FKeyPayCrewONB,
	p.FKeyIDNbr,
	SUM(Amt),
	WageType,
	Accum
FROM @iTemp_TblPayCrewOnb pc
	INNER JOIN @tblPayOnb p ON pc.PKey = p.FKeyPayCrewONB
GROUP BY
	p.ActOrder,
	p.FKeyIDNbr,
	FKeyPayCrewONB,
	WageType,
	Accum
--SELECT * FROM @temp_onbNetPay

DECLARE @onbNetPay TABLE(
	ActOrder INT,
	FKeyCrewONB VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	Earnings FLOAT DEFAULT(0),
	Deduction FLOAT DEFAULT(0),
	Accum_Earn FLOAT DEFAULT(0),
	Accum_Ded FLOAT DEFAULT(0),
	NetAmt AS (Earnings - Deduction),
	Accum_Net AS (Accum_Earn + Accum_Ded))
INSERT INTO @onbNetPay
SELECT 
	a.Act_ORDER,
	a.PKey,
	a.FKeyIDNbr,
	ISNULL((SELECT NetAmt FROM @temp_onbNetPay WHERE FKeyCrewONB = a.PKey AND ActOrder = a.Act_ORDER AND FKeyIDNbr = a.FKeyIDNbr AND WageType=1 AND Accum = 0),0) AS Earnings,
	ISNULL((SELECT NetAmt FROM @temp_onbNetPay WHERE FKeyCrewONB = a.PKey AND ActOrder = a.Act_ORDER AND FKeyIDNbr = a.FKeyIDNbr AND WageType=2 AND Accum = 0),0) AS Deductions,
	ISNULL((SELECT NetAmt FROM @temp_onbNetPay WHERE FKeyCrewONB = a.PKey AND ActOrder = a.Act_ORDER AND FKeyIDNbr = a.FKeyIDNbr AND WageType=1 AND Accum = 1),0) AS Accum_Earn,
	ISNULL((SELECT NetAmt FROM @temp_onbNetPay WHERE FKeyCrewONB = a.PKey AND ActOrder = a.Act_ORDER AND FKeyIDNbr = a.FKeyIDNbr AND WageType=2 AND Accum = 1),0) AS Accum_Ded
FROM @iTemp_TblPayCrewOnb a
--SELECT * FROM @onbNetPay

/* CALCULATE FOR NET AMOUNT AND FORWARDING AMOUNT */
DECLARE @PayCrew_Cur TABLE(
	ActOrder INT,
	FKeyIDNbr VARCHAR(15),
	FKeyPayCrewOnb VARCHAR(15),
	NetAmt FLOAT DEFAULT(0),
	Accum_Net FLOAT DEFAULT(0),
	PrevBal FLOAT DEFAULT(0),
	ForwBal AS (NetAmt + PrevBal))
	--ForwBal FLOAT DEFAULT(0))
INSERT INTO @PayCrew_Cur
SELECT 
	ActOrder,
	FKeyIDNbr,
	FKeyCrewONB,
	NetAmt,Accum_Net,0
FROM @onbNetPay
--SELECT * FROM @PayCrew_Cur
DECLARE @SortAct INT
DECLARE @iFKeyIDNbr VARCHAR(15)
DECLARE @iFKeyCrewONB VARCHAR(15)
DECLARE @sFullAmt FLOAT
DECLARE @iNetAmt FLOAT
DECLARE @PrevBal FLOAT
DECLARE @Accum_Net FLOAT
DECLARE PayCrew_Cur CURSOR FOR
	SELECT
		ActOrder,
		FKeyIDNbr,
		FKeyPayCrewOnb,
		NetAmt,
		PrevBal,
		Accum_Net
	FROM @PayCrew_Cur
	ORDER BY ActOrder
OPEN PayCrew_Cur
FETCH NEXT FROM PayCrew_Cur INTO @SortAct,@iFKeyIDNbr,@iFKeyCrewONB,@iNetAmt,@PrevBal,@Accum_Net
WHILE @@FETCH_STATUS = 0
BEGIN
	IF @SortAct <= 1
	BEGIN
		DECLARE @A_prvBal FLOAT
		SELECT @A_prvBal = ISNULL(dbo.FN_ONB_CalculateONB_CREW_PrevBalance(@PeriodDateStart,@iFKeyIDNbr),0)
		UPDATE @PayCrew_Cur SET
			NetAmt = @iNetAmt
			,PrevBal =  @A_prvBal
		WHERE
			FKeyPayCrewONB = @iFKeyCrewONB
			AND FKeyIDNbr = @iFKeyIDNbr
			AND ActOrder = @SortAct
	END
	ELSE
	BEGIN
		DECLARE @PrevBal_Pc FLOAT
		DECLARE @Accum_NET_BAL FLOAT
		DECLARE @Prev_NET_BAL FLOAT
		SELECT 
			@PrevBal_Pc = PrevBal,
			@Accum_NET_BAL = Accum_Net,
			@Prev_NET_BAL = NetAmt
		FROM @PayCrew_Cur
		WHERE ActOrder = @SortAct - 1
			AND FKeyIDNbr = @iFKeyIDNbr

		UPDATE @PayCrew_Cur SET
			NetAmt = @iNetAmt 
			,PrevBal =  @Prev_NET_BAL + @PrevBal_Pc
		WHERE 
			FKeyPayCrewONB = @iFKeyCrewONB
			AND FKeyIDNbr = @iFKeyIDNbr
			AND ActOrder = @SortAct
	END

	FETCH NEXT FROM PayCrew_Cur INTO @SortAct,@iFKeyIDNbr,@iFKeyCrewONB,@iNetAmt,@PrevBal,@Accum_Net
END
CLOSE PayCrew_Cur
DEALLOCATE PayCrew_Cur
/* UPDATE tblPayCrew_ONB  NetAmt and Forwarding Amount */
UPDATE 
	a
SET
	a.NetAmount = b.NetAmt + b.PrevBal,
	a.PreviousBalance = b.PrevBal
FROM
	tblPayCrew_ONB a
		INNER JOIN @PayCrew_Cur b ON a.PKey = b.FKeyPayCrewOnb
/* ================ Process tblPay_ONB ================ */

/* ====================== tblPayInfo ========================= */
INSERT INTO dbo.tblPayInfo(
	PayCrewONB,
	FKeyWageInfo,
	[Int],
	Den,
	Prd,
	DateStart,
	DateEnd,
	LastUpdatedBy)
SELECT 
	pcOnb.PKey,
	wi.FKeyWageInfo,
	wi.[Int],
	wi.Den,
	wi.Prd,
	pcOnb.DateStart,
	pcOnb.DateEnd,
	@LastUpdatedBy
FROM @iTblPayCrewOnb pcOnb 
	INNER JOIN @tblPayCrew pCrew ON pcOnb.ActID = pCrew.ActID
	INNER JOIN dbo.tblAdmWScaleInfo wi ON pcrew.FKeyWScaleRankCode = wi.FKeyWScaleRank
/* ====================== tblPayInfo ========================= */

