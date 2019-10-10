USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[FN_CalculatePayONB]    Script Date: 08/30/2016 2:01:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[FN_CalculatePayONB] 
(
	-- Add the parameters for the function here
	@Amt FLOAT, -- Amount
	@RateType INT,-- RateType 1:Monthly; 2:Daily
	@Prorata BIT, -- Prorata 1:True; 0:False
	@Accum BIT, -- Accumulating 1:True; 0:False
	@DOP INT, -- Days of Pay (Days of pay Coverage)
	@CWD INT -- Wage Scale Calendar Days
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @OutAmt FLOAT = 0

	IF @RateType = 1
	BEGIN
		IF @Prorata = 1
		BEGIN
			IF @DOP >= @CWD
				SET @OutAmt = @Amt
			ELSE
				SET @OutAmt = (@Amt / @CWD) * @DOP
		END
		ELSE
			SET @OutAmt = @Amt
	END
	ELSE
	BEGIN
		IF @Prorata = 1
		BEGIN
			IF @DOP < = @CWD
				SET @OutAmt = @Amt * @DOP
			ELSE
				SET @OutAmt = @Amt * @CWD
		END
		ELSE
			SET @OutAmt = @Amt
	END

	-- Return the result of the function
	RETURN @OutAmt

END
