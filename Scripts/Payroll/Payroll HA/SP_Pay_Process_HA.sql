USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_Pay_Process_HA]    Script Date: 10/4/2016 3:06:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Earlsan Villegas,Name>
-- Create date: <Create Date,20160804,>
-- Description:	<Description,Process Home Allotment,>
-- =============================================

ALTER PROCEDURE [dbo].[SP_Pay_Process_HA] 
	-- Add the parameters for the stored procedure here
	@ProcessType BIT,
	@PeriodDateStart DATE, 
	@DateCreated DATE,
	@RefNo VARCHAR(50),
	@FKeyPrincipal VARCHAR(15),
	@tblExRate Type_tblPayExRates READONLY,
	@tblPayCrew Type_tblPayCrew_HA READONLY,
	@LastUpdatedBy VARCHAR(200)
AS
BEGIN
DECLARE @PeriodDateEnd DATE = EOMONTH(@PeriodDateStart)


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

IF @ProcessType = 0
BEGIN


	/* ================ Process tblPay ================ */
	INSERT INTO dbo.tblPay(
		MCode,
		DateCreated,
		RefNo,
		FKeyVsl,
		FKeyPrincipal,
		Paytype,
		RefCurr,
		LastUpdatedBy)
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
		'HA',
		(SELECT TOP 1 PKey FROM dbo.tblAdmCurr WHERE Ref <> 0), -- Get the Referential Currency
		@LastUpdatedBy 
	FROM @tblPayCrew
	GROUP BY
		FKeyVslCode
	--SELECT * FROM @iTblPay
	/* ================ Process tblPay ================ */

	/* ================ Process tblPayExRate ================ */
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
	WHERE Paytype = 'HA' AND MCode = FORMAT(@PeriodDateStart,'yyyyMM','es-US')
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

/* INSERT PayCrew_HA */
DECLARE @iTblPayCrew_HA TABLE(
	PKey VARCHAR(15),
	FKeyPayID VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	ActGroupID VARCHAR(15),
	ActID VARCHAR(15),
	DateStart DATE,
	DateEnd DATE)
INSERT INTO dbo.tblPayCrew_HA(
		FKeyPayID,
		FKeyIDNbr,
		ActGrpID,
		ActID,
		LName,FName,MName,
		CivilStatCode,
		FKeyRank,RankName,
		FKeyStatus, [Status],
		FKeyVsl, VslName,
		FKeyAgent, AgentName,
		FKeyPrincipal,PrincipalName,
		DateStart,DateEnd,
		FKeyWScaleCode,FKeyWscalRankCode,
		FKeyCurr,
		AmtBasic,
		LastUpdatedBy)
	OUTPUT
		inserted.PKey,
		inserted.FKeyPayID,
		inserted.FKeyIDNbr,
		inserted.ActGrpID,
		inserted.ActID,
		inserted.DateStart,
		inserted.DateEnd
	INTO @iTblPayCrew_HA
SELECT 
	pay.PKey,
	ActGroup.FKeyIDNbr,
	ActGroup.Pkey,
	Act.Pkey,
	ActGroup.LName,ActGroup.FName,ActGroup.MName,
	CrewInfo.FKeyCivilStat,
	Act.FKeyRankCode, Act.RankName,
	Act.FKeyStatCode,Act.StatName,
	Act.FKeyVslCode,Act.VslName,
	Act.FKeyAgentCode,Act.AgentName,
	act.FKeyPrinCode,act.PrinName,
	@PeriodDateStart,
	(SELECT CASE WHEN ActDateEnd IS NULL THEN EOMONTH(@PeriodDateStart)
		WHEN ActDateEnd >= @PeriodDateStart AND ActDateEnd<= EOMONTH(@PeriodDateStart) THEN ActDateEnd
		ELSE EOMONTH(@PeriodDateStart) END
		FROM dbo.tblActivity WHERE Pkey = pCrew.ActID),
	Act.FkeyWScaleCode,Act.FKeyWScaleRankCode,
	ws.FKeyCurr,
	dbo.PAY_GetBasic(pCrew.FKeyIDNbr,pcrew.ActID),
	@LastUpdatedBy
FROM @tblPayCrew pCrew
	INNER JOIN @iTblPay pay ON pCrew.FKeyVslCode = pay.FKeyVsl
	INNER JOIN dbo.tblActivity Act ON pCrew.ActID = act.Pkey
	INNER JOIN dbo.tblActivityGroup ActGroup ON act.FKeyActivityGroupID = ActGroup.Pkey
	INNER JOIN dbo.tblAdmWscale ws ON pCrew.FKeyWageScale = ws.PKey
	INNER JOIN dbo.tblCrewInfo CrewInfo ON pCrew.FKeyIDNbr = CrewInfo.PKey
--SELECT * FROM @iTblPayCrew_HA

/* INSERT Pay_Allot */
/* filtered Remit Allot = "All the rem_allot to be included in the period" */
DECLARE @filtered_RemAllot TABLE(
	rc INT,
	FKeyIDNbr VARCHAR(15),
	PKey VARCHAR(15),
	FKeyRemittanceID VARCHAR(15),
	Amt FLOAT DEFAULT(0),
	FKeyCurr VARCHAR(15),
	StartPeriod INT,
	Remarks VARCHAR(200),
	DateUpdated DATETIME,
	LastUpdatedBy VARCHAR(200))
INSERT INTO @filtered_RemAllot
SELECT 
	allot.*
FROM dbo.FN_PAY_Allottee(@PeriodDateStart) allot
	INNER JOIN @tblPayCrew pcrew ON allot.FKeyIDNbr = pcrew.FKeyIDNbr
--SELECT * FROM @filtered_RemAllot

DECLARE @iTblPay_Allot TABLE(
	PKey VARCHAR(15),
	FKeyIDNbr VARCHAR(15),
	FKeyPayCrewHA VARCHAR(15),
	AllotteeID VARCHAR(15),
	isDedEeShare BIT DEFAULT(0),
	FKeyCurr VARCHAR(15))
INSERT INTO dbo.tblPay_Allot(
		FKeyPayCrewHA,
		AllotteeID,
		AcctNbr,
		AcctName,
		LName,FName,MName, 
		FKeyBank,BankName,
		FKeyBranch,BranchName,
		FKeyCntry,
		FKeyCurr,
		Allot_FKeyCurr,
		LastUpdatedBy)
	OUTPUT
		inserted.PKey,
		0,
		inserted.FKeyPayCrewHA,
		inserted.AllotteeID,
		0,
		inserted.FKeyCurr
	INTO @iTblPay_Allot
	SELECT 
		pCrew.PKey,
		rem.PKey, --Remittance ID
		rem.AcctNbr,
		rem.AcctName,
		rem.LName,rem.FName,rem.MName,
		rem.FKeyBank,bank.Name,
		rem.FKeyBranch,branch.Name AS BranchName,
		rem.FKeyCntry,
		rem.FKeyCurrency,
		remAllot.FKeyCurr,
		@LastUpdatedBy
	FROM @iTblPayCrew_HA pCrew
		INNER JOIN dbo.tblRemittance rem ON pCrew.FKeyIDNbr = rem.FKeyIDNbr
		INNER JOIN (
				SELECT *
				FROM @filtered_RemAllot
				WHERE rc=1) remAllot ON rem.PKey = remAllot.FKeyRemittanceID
		INNER JOIN dbo.tblAdmBank bank ON rem.FKeyBank=bank.PKey
		INNER JOIN dbo.FrmBranchList branch ON rem.FKeyBranch = branch.PKey
UPDATE 
	iP
SET
	iP.isDedEeShare = r.IsDedEeShare,
	iP.FKeyIDNbr = r.FKeyIDNbr
FROM @iTblPay_Allot iP
	INNER JOIN dbo.tblRemittance r ON iP.AllotteeID = r.PKey

/* Crew Amortization */
DECLARE @tblPayAsh TABLE(
		FKeyPayAllotID VARCHAR(15) NOT NULL,
		FKeyWageAsh VARCHAR(15) NOT NULL,
		WageType SMALLINT NOT NULL,
		Amt FLOAT DEFAULT(0) NOT NULL,
		RefAmt FLOAT DEFAULT(0) NOT NULL,
		FKeyCurr VARCHAR(15) NOT NULL,
		ExRate FLOAT DEFAULT(0) NOT NULL,
		DateStart DATE NOT NULL,
		DateEnd DATE NOT NULL,
		FKeyAmortID VARCHAR(15) NOT NULL,
		CAmt AS (RefAmt * ExRate) )
INSERT INTO @tblPayAsh
SELECT 
	pallot.PKey, --FKeyPayAllotID
	amort.FKeyWageAsh, --FKeyWageAsh
	2, --WageType
	dbo.FN_Pay_CrewAmort(amort.PKey), --Amt
	dbo.FN_RefAmount(@tblExRate,
		dbo.FN_Pay_CrewAmort(amort.PKey),
		amort.FKeyCurrency,
		pallot.FKeyCurr)  , --CAmt
	amort.FKeyCurrency, --FKeyCurr
	(SELECT ExRate FROM @tblExRate WHERE FKeyCurr = pallot.FKeyCurr), --ExRate
	@PeriodDateStart, --DateStart
	@PeriodDateEnd, --DateEnd
	amort.PKey --FKeyAmortID / WageRecID
FROM @iTblPayCrew_HA pcrew
	INNER JOIN @iTblPay_Allot pallot ON pcrew.PKey  = pallot.FKeyPayCrewHA
	INNER JOIN dbo.tblAmortization amort ON pallot.AllotteeID = amort.FKeyRemitAllot
WHERE amort.StartPeriod <= FORMAT(@PeriodDateStart,'yyyyMM','en-US')
--SELECT * FROM @tblPayAsh WHERE Amt > 0


/* INSERT Crew Amortization ON tblPay_Ash*/
INSERT INTO dbo.tblPay_Ash(FKeyPayAllotID,
		FKeyWageAsh,
		WageType,
		Amt,
		CAmt,
		FKeyCurr,
		ExRate,
		DateStart,
		DateEnd,
		WageRecID)
SELECT 
	FKeyPayAllotID,
	FKeyWageAsh,
	WageType,
	Amt,
	CAmt,
	FKeyCurr,
	ExRate,
	DateStart,
	DateEnd,
	FKeyAmortID
FROM @tblPayAsh WHERE Amt > 0

/* Crew Amortization */

/*INSER SYSPAYALLOT ON tblPayAsh*/
INSERT INTO dbo.tblPay_Ash(FKeyPayAllotID,
		FKeyWageAsh,
		WageType,
		Amt,
		CAmt,
		FKeyCurr,
		ExRate,
		DateStart,
		DateEnd)
SELECT 
	pa.PKey,
	'SYSPAYALLOT', --FKeyWageAsh
	1, --WageType
	ra.Amt,
	ISNULL(ra.Amt,0) * ISNULL((SELECT ExRate FROM @iExRate WHERE FKeyCurr =pa.FKeyCurr AND FKeyPay = pcha.FKeyPayID),1), --CAmt
	ra.FKeyCurr,
	ISNULL((SELECT ExRate FROM @iExRate WHERE FKeyCurr = pa.FKeyCurr AND FKeyPay = pcHA.FKeyPayID),1),
	pcha.DateStart,pcha.DateEnd
FROM @iTblPay_Allot pa 
	INNER JOIN @filtered_RemAllot ra  ON ra.FKeyRemittanceID  = pa.AllotteeID
	INNER JOIN @iTblPayCrew_HA pcha On pa.FKeyPayCrewHA = pcha.PKey
	WHERE ra.rc = 1
--SELECT * FROM dbo.tblPay_Ash ORDER BY FKeyPayAllotID
/*INSER SYSPAYALLOT ON tblPayAsh*/


/* INSERT ALLOTTEE OTHER WAGES */
INSERT INTO dbo.tblPay_Ash(
	FKeyPayAllotID,
	FKeyWageAsh,
	WageType,
	Amt,
	CAmt,
	FKeyCurr,
	ExRate,
	DateStart,
	DateEnd)
SELECT 
	pa.PKey,
	rw.FKeyWageAshID,
	rw.WageType,
	rw.Amt,
	ISNULL(rw.Amt,0) * ISNULL((SELECT ExRate FROM @iExRate WHERE FKeyCurr =pa.FKeyCurr AND FKeyPay = pcha.FKeyPayID),1), --CAmt
	pa.FKeyCurr,
	ISNULL((SELECT ExRate FROM @iExRate WHERE FKeyCurr = pa.FKeyCurr AND FKeyPay = pcHA.FKeyPayID),1), --ExRate
	rw.DateStart,
	rw.DateEnd	
FROM dbo.tblRemitOtherWage rw
	INNER JOIN @iTblPay_Allot pa ON rw.FKeyRemittanceID = pa.AllotteeID
	INNER JOIN @iTblPayCrew_HA pcha ON pa.FKeyPayCrewHA = pcha.PKey
WHERE (FORMAT(rw.DateStart,'yyyyMM','en-US') <= FORMAT(@PeriodDateStart,'yyyyMM','en-US') ) 
	AND (FORMAT(ISNULL(rw.DateEnd,@PeriodDateEnd),'yyyyMM','en-US') >= FORMAT(@PeriodDateEnd,'yyyyMM','en-US'))
/* INSERT OTHER WAGES */

/* INSERT PAYSCALE WageASH INTO tblPay_Ash */
INSERT INTO dbo.tblPay_Ash(
		FKeyPayAllotID,
		FKeyWageAsh,
		WageType,
		Amt,
		CAmt,
		FKeyCurr,
		ExRate,
		DateStart,
		DateEnd)
	SELECT 
		pAllot.PKey,
		WSAsh.FKeyWageAsh,
		WSAsh.WageType,
		CASE WHEN ISNULL(WSAsh.Amt,0)<>0 THEN ISNULL(WSAsh.Amt,0)
			ELSE dbo.PAY_HA_GetWageAshAmt(FKeyWageAsh,Amt,dbo.PAY_GetBasic(pcHA.FKeyIDNbr,pcHA.ActID),WSAsh.FKeyCurr,Formula) END,
		ISNULL((CASE WHEN ISNULL(WSAsh.Amt,0) <>0 THEN ISNULL(WSAsh.Amt,0)
			ELSE dbo.PAY_HA_GetWageAshAmt(FKeyWageAsh,Amt,dbo.PAY_GetBasic(pcHA.FKeyIDNbr,pcHA.ActID),WSAsh.FKeyCurr,Formula) END),0) * ISNULL((SELECT ExRate FROM @iExRate WHERE FKeyCurr =WSAsh.FKeyCurr AND FKeyPay = pcHA.FKeyPayID),1),
		WSAsh.FKeyCurr,
		ISNULL((SELECT ExRate FROM @iExRate WHERE FKeyCurr = WSAsh.FKeyCurr AND FKeyPay = pcHA.FKeyPayID),1),
		@PeriodDateStart,
		 (SELECT CASE WHEN ActDateEnd IS NULL THEN EOMONTH(@PeriodDateStart)
					 WHEN ActDateEnd >= @PeriodDateStart AND ActDateEnd < = EOMONTH(@PeriodDateStart) THEN ActDateEnd
					 ELSE EOMONTH(@PeriodDateStart) END
		 FROM dbo.tblActivity WHERE Pkey = pcHA.ActID)
	FROM @tblPayCrew tblpCrew 
		INNER JOIN @iTblPayCrew_HA pcHA ON tblpCrew.FKeyIDNbr = pcHA.FKeyIDNbr
		INNER JOIN @iTblPay_Allot pAllot ON pcHA.PKey = pAllot.FKeyPayCrewHA
		INNER JOIN dbo.tblAdmWscaleAsh WSAsh ON tblpCrew.FKeyWScaleRankCode= WSAsh.FKeyWScaleRank
	WHERE pAllot.isDedEeShare = 1 AND WSAsh.WageType = 2
SELECT (SELECT FKeyCurr FROM dbo.tblPay_Allot WHERE PKey = a.FKeyPayAllotID ), * FROM dbo.tblPay_Ash a ORDER BY FKeyPayAllotID

/* INSERT tblPay_AshEmp */
DECLARE @tblAshEmp TABLE(
		FKeyPayCrewHA VARCHAR(15) NOT NULL,
		FKeyWageAshEmp VARCHAR(15),
		FKeyCurr VARCHAR(15),
		ExRate FLOAT DEFAULT(0),
		Amt FLOAT DEFAULT(0),
		RefAmt FLOAT DEFAULT(0),
		DateStart DATE,
		DateEnd DATE,
		--CAmt AS (ExRate * RefAmt)
		CAmt AS (RefAmt)
)
INSERT INTO @tblAshEmp(
		FKeyPayCrewHA,
		FKeyWageAshEmp,
		FKeyCurr,
		ExRate,
		Amt,
		RefAmt,
		DateStart,
		DateEnd)
	SELECT 
		--(SELECT FKeyCurr FROM dbo.tblPay_Allot WHERE PKey = pAllot.PKey ),
		pCrewHA.PKey,
		admAshEmp.PKey,
		WSAshEmp.FKeyCurr,
		ISNULL((SELECT ExRate FROM @iExRate WHERE FKeyCurr = WSAshEmp.FKeyCurr AND FKeyPay = pCrewHA.FKeyPayID),1) AS ExRate,
		CASE WHEN WSAshEmp.Amt <>0 THEN WSAshEmp.Amt
			ELSE dbo.PAY_HA_GetWageAshAmt(FKeyWageAshEmp,Amt,dbo.PAY_GetBasic(pCrewHA.FKeyIDNbr ,pCrewHA.ActID),WSAshEmp.FKeyCurr,WSAshEmp.Formula) END As Amt,
		dbo.FN_RefAmount( @tblExRate ,
		(CASE WHEN WSAshEmp.Amt <>0 THEN WSAshEmp.Amt ELSE dbo.PAY_HA_GetWageAshAmt(FKeyWageAshEmp,Amt,dbo.PAY_GetBasic(pCrewHA.FKeyIDNbr ,pCrewHA.ActID),WSAshEmp.FKeyCurr,WSAshEmp.Formula) END),WSAshEmp.FKeyCurr,pAllot.FKeyCurr) AS RefAmt,
		@PeriodDateStart AS DateStart,
		 (SELECT CASE WHEN ActDateEnd IS NULL THEN EOMONTH(@PeriodDateStart)
					 WHEN ActDateEnd >= @PeriodDateStart AND ActDateEnd<= EOMONTH(@PeriodDateStart) THEN ActDateEnd
					 ELSE EOMONTH(@PeriodDateStart) END
		 FROM dbo.tblActivity WHERE Pkey = pCrewHA.ActID) AS DateEnd
		--@LastUpdatedBy
	FROM @iTblPayCrew_HA pCrewHA 
		INNER JOIN @tblPayCrew pcrew ON pCrewHA.ActID = pcrew.ActID
		LEFT JOIN @iTblPay_Allot pAllot ON pCrewHA.PKey = pAllot.FKeyPayCrewHA
		INNER JOIN dbo.tblAdmWscaleAshEmp WSAshEmp ON WSAshEmp.FKeyWScaleRank = pcrew.FKeyWScaleRankCode
		INNER JOIN dbo.tblAdmWageAshEmp admAshEmp ON WSAshEmp.FKeyWageAshEmp = admAshEmp.PKey
	WHERE pAllot.isDedEeShare = 1	
INSERT INTO tblPay_AshEmp(
		FKeyPayCrewHA,
		FKeyWageAshEmp,
		FKeyCurr,
		ExRate,
		Amt,
		CAmt,
		DateStart,
		DateEnd,
		LastUpdatedBy)
SELECT 
	FKeyPayCrewHA,
	FKeyWageAshEmp,
	FKeyCurr,
	ExRate,
	Amt,
	CAmt,
	DateStart,
	DateEnd,
	@LastUpdatedBy
 FROM @tblAshEmp
/* INSERT tblPay_AshEmp */
END
