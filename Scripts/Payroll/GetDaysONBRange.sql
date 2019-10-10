USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[GetDaysONBRange]    Script Date: 26/10/2016 3:16:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[GetDaysONBRange] 
(
	-- Add the parameters for the function here
	@DateFrom AS DATETIME,
	@DateTo AS DATETIME,
	@StartDate AS DATETIME,
	@EndDate AS DATETIME
)
RETURNS VARCHAR(20)
AS
BEGIN
	-- Declare the return variable here
	-- Add the T-SQL statements to compute the return value here
	DECLARE @RetVal as VARCHAR(20)
	
	SELECT @RetVal =
	CONCAT(
		(CASE WHEN @StartDate IS NULL THEN 0
			  WHEN @StartDate <= @DateTo THEN
				--(CASE WHEN MONTH(@StartDate) = MONTH(@DateFrom) THEN DAY(@StartDate)
				--	ELSE 1
				--END)
				(CASE WHEN @StartDate >= @DateFrom THEN DAY(@StartDate)
					ELSE 1
				END)
		END)
				  , '-', 
		(CASE WHEN @EndDate IS NULL THEN DAY(EOMONTH(@DateTo))
		--(CASE WHEN @DateTo IS NULL THEN DAY(EOMONTH(@EndDate))
			  WHEN @EndDate>= @DateFrom THEN
				(CASE WHEN @DateTo >= @EndDate THEN DAY(@EndDate)
					  --WHEN MONTH(@dateTo)> MONTH(@EndDate) THEN DAY(@EndDate)
					  ELSE DAY(EOMONTH(@DateTo))
				END)
		END)
	)

	-- Return the result of the function
	RETURN @RetVal

END
