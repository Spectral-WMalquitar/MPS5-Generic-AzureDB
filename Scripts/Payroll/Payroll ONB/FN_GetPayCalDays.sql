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
ALTER FUNCTION FN_GetPayCalDays
(
	-- Add the parameters for the function here
	@Period DATE,
	@FKeyCalendarID VARCHAR(15)
)
RETURNS INT
AS
BEGIN
	DECLARE @MonthCol INT
	SET @MonthCol = FORMAT(@Period,'MM','en-US')
	DECLARE @RetVal INT
	SELECT @RetVal = (CASE WHEN Type <>1 THEN
		CASE 
			WHEN @MonthCol = 1 THEN [Jan]
			WHEN @MonthCol = 2 THEN [Feb]
			WHEN @MonthCol = 3 THEN [Mar]
			WHEN @MonthCol = 4 THEN [Apr]
			WHEN @MonthCol = 5 THEN [May]
			WHEN @MonthCol = 6 THEN [Jun]
			WHEN @MonthCol = 7 THEN [Jul]
			WHEN @MonthCol = 8 THEN [Aug]
			WHEN @MonthCol = 9 THEN [Sep]
			WHEN @MonthCol = 10 THEN [Oct]
			WHEN @MonthCol = 11 THEN [Nov]
			WHEN @MonthCol = 12 THEN [Dec]
		END
	 ELSE
		 DAY(EOMONTH(@Period))
	END)
FROM dbo.tblAdmWScaleCalendar WHERE PKey = @FKeyCalendarID
RETURN @RetVal
END
GO

