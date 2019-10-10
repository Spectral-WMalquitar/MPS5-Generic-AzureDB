DECLARE @PeriodDateStart DATE = '2016-08-01'
DECLARE @PeriodDateEnd DATE = EOMONTH(@PeriodDateStart)


DECLARE @tblPayCrew TABLE(
	ActOrder INT,
	PKey VARCHAR(15),
	FKeyPayID VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	ActID VARCHAR(15),
	RefCurr VARCHAR(15),
	PreviousBalance FLOAT DEFAULT(0),
	NetAmount FLOAT DEFAULT(0))
INSERT @tblPayCrew
SELECT 
	ROW_NUMBER() OVER (PARTITION BY pcONB.FKeyIDNbr ORDER BY a.ActDateStart DESC ) as ActOrder,
	pcONB.PKey,
	pcONB.FKeyPayID,
	pcONB.FKeyIDNbr,
	pcONB.ActID,
	pay.RefCurr, 
	pcONB.PreviousBalance,
	pcONB.NetAmount
FROM dbo.tblPay pay
	INNER JOIN dbo.tblPayCrew_ONB pcONB ON pay.PKey = pcONB.FKeyPayID
	INNER JOIN dbo.tblActivity a ON a.Pkey = pcONB.ActID
WHERE pay.Paytype = 'ONB'
	AND pay.MCode = FORMAT(@PeriodDateStart,'yyyyMM','en-US')
SELECT * FROM @tblPayCrew

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
	CAmt FLOAT DEFAULT(0),
	--RefAmount FLOAT DEFAULT(0),
	DateStart DATE,
	DateEnd DATE,
	Prorata BIT,
	Accum BIT,
	BeginBal FLOAT DEFAULT(0),
	ForwBal FLOAT DEFAULT(0),
	WageRecID VARCHAR(15)
	--CAmt AS (RefAmount)
	)
INSERT INTO @tblPayOnb
SELECT 
	pc.ActOrder,
	pc.FKeyIDNbr,
	pc.PKey,
	pONB.FKeyWageOnb,
	pONB.WageType,
	pONB.FullAmt,
	pONB.FKeyCurr,
	pONB.ExRate,
	pONB.Amt,
	pONB.CAmt,
	pONB.DateStart,
	pONB.DateEnd,
	pONB.Prorata,
	pONB.Accum,
	ponb.PreviousBalance,
	ponb.ForwardingBalance,
	pONB.WageRecID --WageRecID
FROM dbo.tblPay_ONB pONB
	INNER JOIN @tblPayCrew pc ON pONB.FKeyPayCrewONB = pc.PKey

/* SUM of Earnings and Deductions  */
DECLARE @tblNetEarnDed TABLE(
	ActOrder INT,
	FKeyCrewONB VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	NetAmt FLOAT DEFAULT(0),
	WageType SMALLINT,
	Accum BIT)
INSERT INTO @tblNetEarnDed
SELECT
	p.ActOrder,
	p.FKeyPayCrewONB,
	p.FKeyIDNbr,
	SUM(p.Amt),
	WageType,
	Accum
FROM @tblPayOnb p
GROUP BY
	p.ActOrder,
	p.FKeyIDNbr,
	FKeyPayCrewONB,
	WageType,
	Accum
--SELECT * FROM @tblNetEarnDed ORDER BY FKeyCrewONB
/* END: SUM of Earnings and Deductions  */


DECLARE @NetTbl TABLE (
	ActOrder INT,
	FKeyIDNbr VARCHAR(15),
	FKeyPayCrewONB VARCHAR(15),
	Earnings FLOAT DEFAULT(0),
	Deductions FLOAT DEFAULT(0),
	Accum_Earn FLOAT DEFAULT(0),
	Accum_Ded  FLOAT DEFAULT(0),
	NetAmt AS (Earnings - Deductions),
	NetAmt_A AS (Accum_Earn - Accum_Ded))
INSERT INTO @NetTbl
SELECT 
	pc.ActOrder,
	pc.FKeyIDNbr,
	pc.PKey,
	ISNULL((SELECT NetAmt FROM  @tblNetEarnDed WHERE FKeyCrewONB = pc.PKey AND ActOrder = pc.ActOrder AND FKeyIDNbr = pc.FKeyIDNbr AND WageType=1 AND Accum = 0),0) AS Earnings,
	ISNULL((SELECT NetAmt FROM @tblNetEarnDed WHERE FKeyCrewONB = pc.PKey AND ActOrder = pc.ActOrder AND FKeyIDNbr = pc.FKeyIDNbr AND WageType=2 AND Accum = 0),0) AS Deductions,
	ISNULL((SELECT NetAmt FROM @tblNetEarnDed WHERE FKeyCrewONB = pc.PKey AND ActOrder = pc.ActOrder AND FKeyIDNbr = pc.FKeyIDNbr AND WageType=1 AND Accum = 1),0) AS Accum_Earn,
	ISNULL((SELECT NetAmt FROM @tblNetEarnDed WHERE FKeyCrewONB = pc.PKey AND ActOrder = pc.ActOrder AND FKeyIDNbr = pc.FKeyIDNbr AND WageType=2 AND Accum = 1),0) AS Accum_Ded
	--0, --PrevBal
	--0 --Accum_Net
FROM @tblPayCrew pc
GROUP BY
	pc.ActOrder,
	pc.FKeyIDNbr,
	pc.PKey
SELECT * FROM @NetTbl

--SELECT * FROM dbo.tblPay_ONB
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
	FKeyPayCrewOnb,
	NetAmt,NetAmt_A,0
FROM @NetTbl
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
	ORDER BY ActOrder DESC
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

SELECT * FROM @PayCrew_Cur