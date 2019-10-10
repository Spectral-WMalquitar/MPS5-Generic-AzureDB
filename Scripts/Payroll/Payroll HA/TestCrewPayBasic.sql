-- Declare the return variable here
	DECLARE @PeriodDateStart Date = '2016-08-01'
	DECLARE @PeriodDateEnd Date = EOMONTH(@PeriodDateStart)
	DECLARE @FKeyIDNbr VARCHAR(15) = 'SPECT0000012121'
	DECLARE @ActID VARCHAR(15) = 'SPECT0000030476'
	DECLARE @RetVal AS FLOAT
	DECLARE @AdmAmt FLOAT

	--SELECT @AdmAmt = SUM(admWS_ONB.Amt)
	SELECT dbo.FN_CalculatePayONB(SUM(admWS_ONB.Amt),RateType,admWS_ONB.Prorata,admWS_ONB.Accum,DaysOfPay,CalWageDays)
	--FROM dbo.CrewList_Activity_All_Pay cPay
	FROM dbo.CrewActivity_All_InRange(@PeriodDateStart,@PeriodDateEnd) cpay
	INNER JOIN dbo.tblAdmWscale admWS ON admWS.PKey = cPay.FkeyWScaleCode
	INNER JOIN dbo.tblAdmWscaleRank admWSR ON cPay.FKeyWScaleRankCode = admWSR.PKey
	INNER JOIN dbo.tblAdmWscaleOnb admWS_ONB ON admWSr.PKey = admWS_ONB.FKeyWScaleRank
	INNER JOIN dbo.tblAdmWageOnb AdmW_ONB ON admWS_ONB.FKeyWageOnb = AdmW_ONB.PKey
	WHERE cPay.IDNbr = @FKeyIDNbr
		AND cpay.inRange = 1

	-- Get Basic from Admin WageScale
	--SELECT @AdmAmt =  onb.Amt
	--dbo.FN_CalculatePayONB(FullAmt,RateType,Prorata,Accum,DaysOfPay,CalWageDays)
	--FROM dbo.tblActivityGroup ag
	--	INNER JOIN dbo.tblActivity ac ON ag.Pkey = Ac.FKeyActivityGroupID
	--	INNER JOIN dbo.tblAdmWscaleRank wsRank ON wsRank.PKey = ac.FKeyWScaleRankCode
	--	INNER JOIN dbo.tblAdmWscaleOnb onb on onb.FKeyWScaleRank  = ac.FKeyWScaleRankCode
	--WHERE Ag.FKeyIDNbr = @FKeyIDNbr AND ac.Pkey = @ActID AND onb.FKeyWageOnb = 'SYSPAYBASIC'

	-- Get Basic From Variable Wage
	DECLARE @AmtWageONB AS FLOAT
	SELECT @AmtWageONB =SUM(onb.Amt)
	FROM dbo.tblWageOnb onb
	GROUP BY 
		onb.Amt,
		onb.FKeyWageOnbID,
		onb.FKeyActivityID,
		onb.FKeyIDNbr
	HAVING FKeyIDNbr  = @FKeyIDNbr
		AND FKeyWageOnbID = 'SYSPAYBASIC'
		AND onb.FKeyActivityID = @ActID

	-- Return the result of the function
	SET @RetVal = isnull((@AdmAmt),0)+isnull((@AmtWageONB),0)
	SELECT @RetVal