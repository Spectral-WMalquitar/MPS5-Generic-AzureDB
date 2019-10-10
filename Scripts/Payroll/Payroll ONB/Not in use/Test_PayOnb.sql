DECLARE	@DateStart DATE
DECLARE	@DateEnd DATE
DECLARE	@ActDateStart DATE
DECLARE	@ActDateEnd DATE
DECLARE	@PeriodDateStart DATE
DECLARE	@PeriodDateEnd DATE

SET @DateStart = '2016-07-11'
SET @DateEnd = NULL
SET @ActDateStart = '2016-07-11'
SET @ActDateEnd = '2016-08-25'
SET @PeriodDateStart = '08-01-2016'
SET @PeriodDateEnd = '08-31-2016'
--SET @DateStart =  ISNULL(@DateStart,@DateStart)
--SET @DateEnd = ISNULL(@DateEnd,@PeriodDateEnd)
--SET @ActDateStart = '2016-07-11'
--SET @ActDateEnd = '2016-08-25'
--SET @PeriodDateStart = '08-01-2016'
--SET @PeriodDateEnd = '08-31-2016'

DECLARE @RateType INT
DECLARE @DateType INT
DECLARE @Prorata BIT
DECLARE @CalendarDays INT
DECLARE @Amt FLOAT



DECLARE @DaysOFPay INT
SET @DaysOFPay = 0

DECLARE @tempTbl TABLE(
	DateStart DATE,
	DateEnd DATE,
	DaysOfPay INT)
INSERT INTO @tempTbl
SELECT 
	dbo.PAY_DateStart(@DateStart,@DateEnd,@ActDateStart,@ActDateEnd,@PeriodDateStart,@PeriodDateEnd) AS DateStart,
	dbo.PAY_DateEnd(@DateStart,@DateEnd,@ActDateStart,@ActDateEnd,@PeriodDateStart,@PeriodDateEnd)AS DateEnd,
	DATEDIFF(DAY,
		dbo.PAY_DateStart(@DateStart,@DateEnd,@ActDateStart,@ActDateEnd,@PeriodDateStart,@PeriodDateEnd),
		dbo.PAY_DateEnd(@DateStart,@DateEnd,@ActDateStart,@ActDateEnd,@PeriodDateStart,@PeriodDateEnd))+1 AS DayPeriod

SELECT TOP 1 @DaysOFPay = DaysOfPay FROM @tempTbl
DECLARE @_Amt FLOAT
SET @_Amt = 0

SET @Amt = 10
SET @RateType = 1
SET @DateType = 1
SET @Prorata = 0
SET @CalendarDays = 30

IF @RateType = 1 --IF [RateType] = 'Monthly'
BEGIN
	IF @Prorata = 1
	BEGIN
		IF @DaysOFPay >= @CalendarDays
			SET @_Amt = (@Amt ) * (@CalendarDays)
		ELSE
			SET @_Amt = (@Amt) * (@DaysOFPay)
	END
	ELSE IF @Prorata = 0
		SET @_Amt = @Amt
END
ELSE IF @RateType =2 --IF [RateType] = 'Daily'
BEGIN
	IF @Prorata = 1
	BEGIN
		IF @DaysOFPay > = @CalendarDays
			SET @_Amt = @Amt * @DaysOFPay
		ELSE
			SET @_Amt = @Amt * @CalendarDays
	END
	ELSE IF @Prorata = 0
	BEGIN
		SET @_Amt = @Amt
	END
END
SELECT @_Amt AS ConvertedAmt
