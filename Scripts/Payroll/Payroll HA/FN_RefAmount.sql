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
Alter FUNCTION FN_RefAmount
(
	-- Add the parameters for the function here
	@tblExRate Type_tblPayExRates READONLY, 
	@Amount FLOAT,
	@FKeyCurrency VARCHAR(15),
	@RefCurr VARCHAR(15) --Referencial Currency
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @OutputAmount FLOAT = 0
	
	-- Add the T-SQL statements to compute the return value here
	DECLARE @RefAmount FLOAT
	SELECT @RefAmount = ExRate FROM @tblExRate WHERE FKeyCurr = @RefCurr
	
	DECLARE @ExCurr VARCHAR(15), @ExRate FLOAT
	SELECT @ExCurr = FKeyCurr, @ExRate = ExRate FROM @tblExRate WHERE FKeyCurr = @FKeyCurrency
	SET @OutputAmount = @Amount / @ExRate
	
	
	-- Return the result of the function
	RETURN @OutputAmount

END
GO

