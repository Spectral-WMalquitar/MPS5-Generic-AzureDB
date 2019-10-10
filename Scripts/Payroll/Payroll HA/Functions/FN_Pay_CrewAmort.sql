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
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION FN_Pay_CrewAmort 
(
	-- Add the parameters for the function here
	@FKeyAmortID VARCHAR(15)
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE	@MonthlyDedAmt FLOAT
	DECLARE @TotalLoanAmount FLOAT
	SELECT
		@MonthlyDedAmt = MonthlyDed,
		@TotalLoanAmount = (LoanAmt + LoanInterest + OtherCharge)
	FROM dbo.tblAmortization
	WHERE PKey = @FKeyAmortID

	DECLARE @Amt FLOAT = 0--OUTPUT
	DECLARE @TotalPayment FLOAT
	-- Add the T-SQL statements to compute the return value here
	
	SELECT @TotalPayment =  ISNULL(SUM(Amt),0)
	FROM dbo.tblPay_Ash WHERE WageRecID = @FKeyAmortID
	
	IF @TotalPayment < @TotalLoanAmount
	BEGIN
		--SET @Amt = @MonthlyDedAmt
		IF (@TotalLoanAmount - @TotalPayment) < @MonthlyDedAmt
		BEGIN
			SET @Amt = (@TotalLoanAmount - @TotalPayment)
		END
		ELSE IF (@TotalLoanAmount - @TotalPayment) >= @MonthlyDedAmt
		BEGIN
			SET @Amt = @MonthlyDedAmt
		END
	END
	ELSE
	BEGIN
		SET @Amt = 0.0
	END

	-- Return the result of the function
	RETURN @Amt

END
GO

