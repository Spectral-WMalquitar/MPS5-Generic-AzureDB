DELETE FROM dbo.tblPay
DECLARE @DateStart DATE = '2016-08-01'
DECLARE @DateEnd DATE =  EOMONTH(@DateStart)
DECLARE @LastUpdatedBy VARCHAR(200) = 'LastUpdatedBy'
DECLARE @FKeyPrincipal VARCHAR(15) = 'SPECT0000000005'
DECLARE @tblPayCrew Type_tblPayCrew_ONB
INSERT INTO @tblPayCrew VALUES
('SPECT0000020467','SPECT0000012121','SPECT0000000238','SPECT0000000002','SPECT0000000031'),
('SPECT0000020468','SPECT0000012121','SPECT0000000238','SPECT0000000002','SPECT0000000026'),
('SPECT0000030476','SPECT0000012121','SPECT0000000238','SPECT0000000002','SPECT0000000039'),
('SPECT0000030477','SPECT0000012147','SPECT0000000238','SPECT0000000002','SPECT0000000026')
--SELECT * FROM @tblPayCrew

DECLARE @tblExRate Type_tblPayExRates
INSERT INTO @tblExRate VALUES
('SYSCUUSD',10)

DECLARE @tblPay Type_tblPayONB
INSERT INTO @tblPay VALUES
('201608',GETDATE(),'1','SPECT0000000005','SPECT0000000238')

DECLARE @RefNo VARCHAR(50)= 'RefNo1'
DECLARE @DateCreated DATE = GetDATE()

/* ==================== tblPay ==================== */
DECLARE @iTblPay TABLE(
	 PKey VARCHAR(15),
	 MCode INT,
	 DateCreated DATE,
	 RefNo VARCHAR(50),
	 FKeyPrincipal VARCHAR(15),
	 FKeyVsl VARCHAR(15))
INSERT INTO dbo.tblPay(
	MCode,
	DateCreated,
	RefNo,
	FKeyVsl,
	FKeyPrincipal,
	Paytype,
	LastUpdatedBy)
OUTPUT 
	inserted.PKey,
	inserted.MCode,
	inserted.DateCreated,
	inserted.RefNo,
	inserted.FKeyPrincipal,
	inserted.FKeyVsl
INTO @iTblPay
SELECT 
	FORMAT(@DateStart,'yyyyMM','en-US'),
	@DateCreated,
	@RefNo,
	FKeyVslCode,
	@FKeyPrincipal,
	'ONB',
	@LastUpdatedBy 
FROM @tblPayCrew
GROUP BY
	FKeyVslCode
--SELECT * FROM @iTblPay
/* ==================== tblPay ==================== */

/* =================== tblPayExRate ================== */
DECLARE @iExRate TABLE(
	FKeyPay VARCHAR(15),
	FKeyCurr VARCHAR(15),
	ExRate FLOAT)
INSERT INTO dbo.tblPayExRate(
	FKeyPay,
	FKeyCurr,
	ExRate,
	LastUpdatedBy)
OUTPUT
	inserted.FKeyPay,
	inserted.FKeyCurr,
	inserted.ExRate
INTO @iExRate
SELECT 
	pay.PKey,
	e.FKeyCurr,
	e.ExRate,
	@LastUpdatedBy
FROM @iTblPay pay,@tblExRate e
--SELECT * FROM @iExRate
/* =================== tblPayExRate ================== */


/* ==================== tblPayCrew_ONB ==================== */
DECLARE @iTblPayCrewOnb TABLE(
	--ID INT IDENTITY,
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
	(dbo.PAY_DateStart(a.ActDateStart,a.ActDateEnd,a.ActDateStart,a.ActDateEnd,@DateStart,@DateEnd)) AS DateStart,
	(dbo.PAY_DateEnd(a.ActDateStart,a.ActDateEnd,a.ActDateStart,a.ActDateEnd,@DateStart,@DateEnd)) AS DateEnd,
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
/* ==================== tblPayCrew_ONB ==================== */


/* ==================== tblPayONB ==================== */
DECLARE @iTemp_TblPayCrewOnb TABLE(
	ID INT,
	PKey VARCHAR(15),
	FKeyPayID VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	ActGroupID VARCHAR(15),
	ActID VARCHAR(15),
	DateStart DATE,
	DateEnd DATE)
INSERT INTO @iTemp_TblPayCrewOnb
SELECT
	ROW_NUMBER() OVER (PARTITION BY p.FKeyIDNbr ORDER BY a.ActDateStart ASC ) AS rn,
	p.*
FROM @iTblPayCrewOnb p
	INNER JOIN dbo.tblActivity a ON p.ActID = a.Pkey
ORDER BY 
	p.FKeyIDNbr,
	a.ActDateStart ASC
--SELECT * FROM @iTemp_TblPayCrewOnb


DECLARE @tblPayOnb TABLE(
	rn INT,
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
INSERT INTO @tblPayOnb(
	rn,
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
SELECT
	ROW_NUMBER() OVER (PARTITION BY payCrew.PKey ORDER BY cPay.ActDateStart ASC ) AS rn,
	payCrew.ID,
	cpay.IDNbr,
	payCrew.PKey,
	admWS_ONB.FKeyWageOnb,
	AdmW_ONB.WageType,
	admWS_ONB.Amt, --Full Amount
	admWS_ONB.FKeyCurr,
	(SELECT ExRate FROM @iExRate WHERE FKeyPay = paycrew.FKeyPayID AND FKeyCurr = admWS_ONB.FKeyCurr) AS ExRate,
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
	admWS_ONB.Prorata,
	admWS_ONB.Accum,
	0, --Previous Bal
	0, --Previous Bal
	admws.RateType,
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
	dbo.FN_GetPayCalDays(@DateStart,cpay.FkeyWScaleCode),
	cPay.ActDateStart 
FROM dbo.CrewList_Activity_All_Pay cPay
	INNER JOIN dbo.tblAdmWscale admWS ON admWS.PKey = cPay.FkeyWScaleCode
	INNER JOIN dbo.tblAdmWscaleRank admWSR ON cPay.FKeyWScaleRankCode = admWSR.PKey
	INNER JOIN dbo.tblAdmWscaleOnb admWS_ONB ON admWSr.PKey = admWS_ONB.FKeyWScaleRank
	INNER JOIN dbo.tblAdmWageOnb AdmW_ONB ON admWS_ONB.FKeyWageOnb = AdmW_ONB.PKey
	INNER JOIN @iTemp_TblPayCrewOnb payCrew ON cPay.ActID = paycrew.ActID
ORDER BY cPay.ActDateStart ASC
--SELECT * FROM @tblPayOnb

/* ===== CALCULATE Accumulating on tblPayONB ====== */
/* its a shame i have to use cursors! if you have a better idea, goodluck! */

DECLARE @rn1 INT
DECLARE @payCrewID_T INT
DECLARE @BeginBal FLOAT
DECLARE @ForwBal FLOAT
DECLARE @Amt FLOAT
DECLARE @Accum BIT
DECLARE @FKeyPayCrewONB VARCHAR(15)
DECLARE @FKeyWageONB VARCHAR(15)
DECLARE @FKeyIDNbr VARCHAR(15)
DECLARE C_Cur CURSOR FOR	
	SELECT 
		rn,
		ForwBal,
		BeginBal,
		dbo.FN_CalculatePayONB(FullAmt,RateType,Prorata,Accum,DaysOfPay,CalWageDays),
		FKeyPayCrewONB,
		Accum,
		FKeyWageOnb,
		FKeyIDNbr,
		Temp_PayActID
	FROM @tblPayOnb
	ORDER BY ActDateStart ASC
OPEN C_Cur
FETCH NEXT FROM C_Cur INTO @rn1,@ForwBal,@BeginBal,@Amt,@FKeyPayCrewONB,@Accum,@FKeyWageONB,@FKeyIDNbr,@payCrewID_T
WHILE @@FETCH_STATUS  = 0
BEGIN
	IF @rn1 <= 1
	BEGIN
		/* GET THE PREVIOUS MONTH BALANCE OF THE SAME WAGE ONB */
		IF @Accum = 1
		BEGIN
			DECLARE @PrevMonthForwBal FLOAT
			SELECT @PrevMonthForwBal =  dbo.FN_ONB_CalculateONB_AccumBalance(@DateStart,@FKeyIDNbr,@Accum,@FKeyWageONB)
			UPDATE @tblPayOnb SET 
				ForwBal = @PrevMonthForwBal + @Amt,
				BeginBal = @PrevMonthForwBal
			WHERE 
				rn = @rn1 
				AND FKeyPayCrewONB = @FKeyPayCrewONB
				AND FKeyWageOnb = @FKeyWageONB
				AND FKeyIDNbr = @FKeyIDNbr
		END
	END
	ELSE
	BEGIN
		IF @Accum =1
		BEGIN
			DECLARE @fb1 FLOAT = 0
			DECLARE @bb1 FLOAT = 0
			SELECT 
				@fb1 = ForwBal,
				@bb1 = BeginBal 
			FROM @tblPayOnb 
			WHERE 
				Temp_PayActID = @payCrewID_T -1
				AND rn = @rn1
				AND FKeyWageOnb = @FKeyWageONB
				AND FKeyIDNbr = @FKeyIDNbr

			UPDATE @tblPayOnb SET
				ForwBal = @fb1 + @Amt,
				BeginBal = @fb1
			WHERE rn = @rn1 
				AND FKeyPayCrewONB = @FKeyPayCrewONB
				AND FKeyWageOnb = @FKeyWageONB
		END
	END
	FETCH NEXT FROM C_Cur INTO @rn1,@ForwBal,@BeginBal,@Amt,@FKeyPayCrewONB,@Accum,@FKeyWageONB,@FKeyIDNbr,@payCrewID_T
END
CLOSE C_Cur
DEALLOCATE C_Cur

--SELECT * FROM @tblPayOnb
--ORDER BY FKeyIDNbr,
--ActDateStart ASC

/* ===== END CALCULATE Accumulating ON tblPayONB ====== */

DECLARE @iTblpayONB TABLE(
	FKeyPayCrewONB VARCHAR(15),
	FKeyWageOnb VARCHAR(15),
	WageType SMALLINT,
	Amt FLOAT,
	ForwBal FLOAT)
--SELECT 
--	FKeyPayCrewONB,
--	FKeyWageOnb,
--	WageType
--FROM @tblPayOnb

SELECT * FROM @tblPayOnb

--Insert INTO MAIN TABLE
INSERT INTO dbo.tblPay_ONB(
	FKeyPayCrewONB,
	FKeyWageOnb,
	WageType,
	FullAmt,
	FKeyCurr,
	ExRate,
	Amt,
	CAmt,
	DateStart,
	DateEnd,
	Prorata,
	Accum,
	PreviousBalance,
	ForwardingBalance,
	LastUpdatedBy)
OUTPUT
	inserted.FKeyPayCrewONB,
	inserted.FKeyWageOnb,
	inserted.WageType,
	inserted.Amt,
	inserted.ForwardingBalance
INTO @iTblpayONB
SELECT 
	p.FKeyPayCrewONB,
	p.FKeyWageOnb,
	p.WageType,
	p.FullAmt,
	p.FKeyCurr,
	p.ExRate,
	dbo.FN_CalculatePayONB(FullAmt,RateType,Prorata,Accum,DaysOfPay,CalWageDays),
	(dbo.FN_CalculatePayONB(FullAmt,RateType,Prorata,Accum,DaysOfPay,CalWageDays) * p.ExRate),
	p.DateStart,
	p.DateEnd,
	p.Prorata,
	p.Accum,
	p.BeginBal,
	p.ForwBal,
	@LastUpdatedBy
FROM @tblPayOnb p
SELECT * FROM @iTblpayONB



-- WITHOUT Accumulating BALANCE
DECLARE @PayCrewNet TABLE(
	FKeyPayCrewONB VARCHAR(15),
	Earnings FLOAT,
	Deduction FLOAT,
	NetAmt AS (Earnings - Deduction),
	ForwBalEarn FLOAT,
	ForwBalDed FLOAT,
	NetForwBal AS (ForwBalEarn - ForwBalDed))
INSERT INTO @PayCrewNet
SELECT 
	a.PKey,
	ISNULL((SELECT SUM(Amt) FROM @iTblpayONB GROUP BY FKeyPayCrewONB, WageType HAVING FKeyPayCrewONB = a.PKey AND WageType = 1 AND Accum = 0),0),
	ISNULL((SELECT SUM(Amt) FROM @iTblpayONB GROUP BY FKeyPayCrewONB, WageType HAVING FKeyPayCrewONB = a.PKey AND WageType = 2),0),
	ISNULL((SELECT SUM(ForwBal) FROM @iTblpayONB GROUP BY FKeyPayCrewONB, WageType HAVING FKeyPayCrewONB = a.PKey AND WageType = 1),0),
	ISNULL((SELECT SUM(ForwBal) FROM @iTblpayONB GROUP BY FKeyPayCrewONB, WageType HAVING FKeyPayCrewONB = a.PKey AND WageType = 2),0)
FROM @iTblPayCrewOnb a
SELECT * FROM @PayCrewNet
/* ==================== tblPayONB ==================== */

/* ===== CALCULATE Accumulating ON tblPayCrewONB ====== */
DECLARE @tblEarnDed TABLE(
	SortAct INT,
	FKeyWageONB VARCHAR(15),
	Amt FLOAT,
	WageType SMALLINT)
--INSERT INTO @tblEarnDed


DECLARE @tblPayCrew_ONB_FB TABLE(
	Temp_ActSort INT,
	FKeyIDNbr VARCHAR(15),
	FKeyPayCrewONB VARCHAR(15),
	NetAmt FLOAT DEFAULT(0),
	Upd_PrevBal FLOAT DEFAULT(0))
INSERT INTO @tblPayCrew_ONB_FB(
	Temp_ActSort ,
	FKeyIDNbr,
	FKeyPayCrewONB,
	NetAmt)
SELECT 
	p.Temp_PayActID,
	p.FKeyIDNbr,
	p.FKeyPayCrewONB,
	n.NetAmt
FROM @tblPayOnb p
	INNER JOIN @PayCrewNet n ON p.FKeyPayCrewONB = n.FKeyPayCrewONB
GROUP BY
	p.Temp_PayActID,
	p.FKeyIDNbr,
	p.FKeyPayCrewONB,
	n.NetAmt
ORDER BY FKeyIDNbr
SELECT * FROM @tblPayCrew_ONB_FB

--DECLARE @tempPCrewONT TABLE(
--	FKeyPayCrewONB VARCHAR(15),
--	FKeyIDNbr VARCHAR(15),
--	NetAmt FLOAT DEFAULT(0),
--	PrevBal FLOAT DEFAULT(0))

DECLARE @SortAct INT, @iFKeyIDNbr VARCHAR(15),@iFKeyCrewONB VARCHAR(15)
DECLARE @sFullAmt FLOAT,@sNetAmt FLOAT
DECLARE PayCrew_Cur CURSOR FOR
	SELECT
		Temp_ActSort,
		FKeyIDNbr,
		FKeyPayCrewONB,
		NetAmt
	FROM @tblPayCrew_ONB_FB
	ORDER BY FKeyIDNbr ASC,Temp_ActSort ASC
OPEN PayCrew_Cur
FETCH NEXT FROM PayCrew_Cur INTO @SortAct,@iFKeyIDNbr,@iFKeyCrewONB,@sNetAmt
WHILE @@FETCH_STATUS = 0
BEGIN
	IF @SortAct <= 1
	BEGIN
		DECLARE @prvBal FLOAT
		SELECT @prvBal = ISNULL(dbo.FN_ONB_CalculateONB_CREW_PrevBalance(@DateStart,@iFKeyIDNbr),0)
		UPDATE @tblPayCrew_ONB_FB SET
			-- = @prvBal,
			Upd_PrevBal = @prvBal + @sNetAmt,
			NetAmt = @sNetAmt
		WHERE
			FKeyPayCrewONB = @iFKeyCrewONB
			AND FKeyIDNbr = @iFKeyIDNbr
			AND Temp_ActSort = @SortAct
	END
	ELSE
	BEGIN
		DECLARE @nPB FLOAT,@nFB FLOAT, @nNetAmt FLOAT
		SELECT 
			@nPB = Upd_PrevBal,
			@nNetAmt = NetAmt
		FROM @tblPayCrew_ONB_FB
		WHERE Temp_ActSort = @SortAct - 1
			AND FKeyIDNbr = @iFKeyIDNbr

		UPDATE @tblPayCrew_ONB_FB SET
			Upd_PrevBal = @nPB,
			NetAmt = @nPB + @sNetAmt
		WHERE 
			FKeyPayCrewONB = @iFKeyCrewONB
			AND FKeyIDNbr = @iFKeyIDNbr
			AND Temp_ActSort = @SortAct
	END

	FETCH NEXT FROM PayCrew_Cur INTO @SortAct,@iFKeyIDNbr,@iFKeyCrewONB,@sNetAmt
END
CLOSE PayCrew_Cur
DEALLOCATE PayCrew_Cur
SELECT * FROM @tblPayCrew_ONB_FB

/* ===== END CALCULATE Accumulating ON tblPayCrewONB ====== */





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
