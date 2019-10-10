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
ALTER FUNCTION FN_isCA_Exist 
(
	-- Add the parameters for the function here
	@FKeyVsl VARCHAR(15),
	@FKeyPort VARCHAR(15),
	@FKeyCAType VARCHAR(15),
	@Period INT
)
RETURNS BIT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @OutVar BIT = 0

	-- Add the T-SQL statements to compute the return value here
	SELECT @OutVar = ( CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END)
	FROM dbo.tblCA
	WHERE FKeyCAType = @FKeyCAType
		AND FKeyPort = @FKeyPort
		AND Period = @Period
		AND FKeyVsl = @FKeyVsl
		AND isImported = 0

	-- Return the result of the function
	RETURN @OutVar

END
GO

