-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE SP_GedPayCalendarDays 
	-- Add the parameters for the stored procedure here
	@Period DATE,
	@FKeyWageScaleCalendarID VARCHAR(15)
AS
BEGIN
DECLARE @strParam NVARCHAR(Max)
DECLARE @MonthCol VARCHAR(50)
DECLARE @DaysOfCal INT
DECLARE @CalType SMALLINT

--SET @DaysOfCal = 0
--SET @CalType = 0

SET @MonthCol = FORMAT(@Period,'MMM','en-US')

	SET @strParam = 'SELECT @DaysOfCal = ['+ @MonthCol +'],@CalType = [Type] FROM dbo.tblAdmWScaleCalendar WHERE PKey='''+ @FKeyWageScaleCalendarID +''''
	EXEC sp_executesql @strParam,N'@DaysOfCal INT OUTPUT,@CalType SMALLINT OUTPUT', @DaysOfCal OUTPUT,@CalType OUTPUT
	
	SELECT @DaysOfCal AS DaysOfMonth, @CalType AS CalendarType
END
GO
