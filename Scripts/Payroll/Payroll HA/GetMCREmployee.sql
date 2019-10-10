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
-- Author:		<Author,Earlsan Villegas,Name>
-- Create date: <Create Date, 2016/08/01,>
-- Description:	<Description, Philhealth Table By EMPLOYEE ,>
-- =============================================
ALTER FUNCTION GetMCREmployee
(
	-- Add the parameters for the function here
	@cAmt FLOAT
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RetVal FLOAT

	-- Add the T-SQL statements to compute the return value here
	SELECT  @RetVal = MAX(MCREmployee)
	FROM dbo.tblMCR
	WHERE Salary <= @cAmt 
	-- Return the result of the function
	RETURN @RetVal
END
GO

