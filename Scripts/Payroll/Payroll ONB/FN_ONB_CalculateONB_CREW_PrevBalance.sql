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
ALTER FUNCTION FN_ONB_CalculateONB_CREW_PrevBalance 
(
	-- Add the parameters for the function here
	@PeriodDateStart DATE,
	@FKeyIDNbr VARCHAR(15)
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @PreviousBalance FLOAT = 0

	-- Add the T-SQL statements to compute the return value here
	SELECT TOP 1 @PreviousBalance = pconb.PreviousBalance
	--SELECT a.ActDateStart,pconb.*
	FROM dbo.tblPay p
		INNER JOIN dbo.tblPayCrew_ONB pconb ON p.PKey = pconb.FKeyPayID
		INNER JOIN dbo.tblActivity a ON a.Pkey = pconb.ActID
	WHERE MCode = FORMAT(@PeriodDateStart,'yyyyMM','en-US') -1 
		AND Paytype= 'ONB'
		AND pconb.FKeyIDNbr = @FKeyIDNbr
	ORDER BY FKeyIDNbr,a.ActDateStart DESC

	-- Return the result of the function
	RETURN ISNULL(@PreviousBalance,0)

END
GO

