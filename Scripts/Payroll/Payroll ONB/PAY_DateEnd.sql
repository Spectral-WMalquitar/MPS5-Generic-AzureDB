USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[PAY_DateEnd]    Script Date: 08/31/2016 3:09:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[PAY_DateEnd] 
(
	-- Add the parameters for the function here
	@DateStart DATE,
	@DateEnd DATE,
	@ActDateStart DATE,
	@ActDateEnd DATE,
	@PeriodDateStart DATE,
	@PeriodDateEnd DATE
)
RETURNS DATE
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Period INT
	SET @Period = CONVERT(INT,FORMAT(@PeriodDateStart,'yyyyMM','en-US'))
	DECLARE @_DateEnd DATE

	IF @DateEnd IS NULL
	BEGIN
		IF FORMAT(@ActDateEnd,'yyyyMM','en-US') = @Period
			SET @_DateEnd = @ActDateEnd
		ELSE IF FORMAT(@ActDateEnd,'yyyyMM','en-US') > @Period
			SET @_DateEnd = @PeriodDateEnd
	END
	ELSE IF @DateEnd IS NOT NULL
	BEGIN
		IF CONVERT(INT,FORMAT(@DateEnd,'yyyyMM','en-US'))= @Period
		BEGIN
			IF @DateEnd = @PeriodDateEnd
				SET @_DateEnd = @DateEnd
			ELSE IF @DateEnd < @PeriodDateEnd AND @DateEnd >  @PeriodDateStart
				SET @_DateEnd =  @DateEnd
		END
		ELSE IF CONVERT(INT,FORMAT(@DateEnd,'yyyyMM','en-US'))> @Period
		BEGIN
			IF @ActDateEnd <= @PeriodDateEnd AND @ActDateEnd > @PeriodDateStart
				SET @_DateEnd = @ActDateEnd
			ELSE IF @ActDateEnd > @PeriodDateEnd
				SET @_DateEnd = @PeriodDateEnd				
		END
	END
	
	-- Return the result of the function
	RETURN ISNULL(@_DateEnd,@PeriodDateEnd)
END
