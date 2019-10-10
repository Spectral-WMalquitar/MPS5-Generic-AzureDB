-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,20160826 ,>
-- Description:	<Description, Will Calculate Pay Amout ,>
-- =============================================
ALTER FUNCTION PAY_ONB_Amt
(
	-- Add the parameters for the function here
	@Amt FLOAT, 
	@RateType INT,
	@Prorata BIT,
	@DaysOFPay INT,
	@CalendarDays INT
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @_Amt FLOAT

	-- Add the T-SQL statements to compute the return value here

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

	-- Return the result of the function
	RETURN @_Amt

END
GO

