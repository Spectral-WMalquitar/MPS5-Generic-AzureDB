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
ALTER FUNCTION FN_ONB_CalculateONB_AccumBalance 
(
	-- Add the parameters for the function here
	@PeriodDateStart DATE,
	@FKeyIDNbr VARCHAR(15),
	@Accum BIT,
	@FKeyWageONB VARCHAR(15)
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @PreviousBalance FLOAT

	-- Add the T-SQL statements to compute the return value here
	IF @Accum <> 1
	BEGIN
		SET @PreviousBalance = 0
	END
	ELSE
	BEGIN
		SELECT TOP 1 @PreviousBalance = pONB.PreviousBalance
		FROM dbo.tblPay p
			INNER JOIN dbo.tblPayCrew_ONB pconb ON p.PKey = pconb.FKeyPayID
			INNER JOIN dbo.tblPay_ONB  pONB ON pconb.PKey = pONB.FKeyPayCrewONB
		WHERE MCode = FORMAT(@PeriodDateStart,'yyyyMM','en-US') -1 
			AND Paytype= 'ONB'
			AND pconb.FKeyIDNbr = @FKeyIDNbr
			AND pONB.FKeyWageOnb = @FKeyWageONB
		ORDER BY pconb.DateStart ASC
	END


	-- Return the result of the function
	RETURN ISNULL(@PreviousBalance,0)

END
GO

