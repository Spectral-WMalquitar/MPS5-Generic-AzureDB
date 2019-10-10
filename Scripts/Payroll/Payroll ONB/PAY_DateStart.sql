USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[PAY_DateStart]    Script Date: 09/08/2016 10:14:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[PAY_DateStart] 
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
	SET @DateStart =  ISNULL(@DateStart,@DateStart)
	SET @DateEnd = ISNULL(@DateEnd,@PeriodDateEnd)
	DECLARE @Period INT
	SET @Period = CONVERT(INT,FORMAT(@PeriodDateStart,'yyyyMM','en-US'))
	DECLARE @_DateStart DATE

			IF CONVERT(INT,FORMAT(@DateStart,'yyyyMM','en-US'))= @Period
		BEGIN
			IF @DateStart <> @ActDateStart
			BEGIN
				IF @DateStart < @PeriodDateStart
				BEGIN
					IF @ActDateStart < @PeriodDateStart
						SET @_DateStart = @PeriodDateStart
					ELSE IF @ActDateStart > @PeriodDateStart
						SET @_DateStart = @ActDateStart
				END
				ELSE IF @DateStart > @PeriodDateStart
				BEGIN
					IF @ActDateStart < @PeriodDateStart
						SET @_DateStart = @PeriodDateStart
					ELSE IF @ActDateStart > @PeriodDateStart
						SET @_DateStart = @ActDateStart
					ELSE IF @ActDateStart = @PeriodDateStart
						SET @_DateStart =  @ActDateStart
				END
				ELSE IF @DateStart = @PeriodDateStart
				BEGIN
					IF @ActDateStart <= @PeriodDateStart
						SET @_DateStart = @PeriodDateStart
					ELSE IF @ActDateStart > @PeriodDateStart AND @ActDateStart < @PeriodDateEnd
						SET @_DateStart = @ActDateStart
				END
			END
			ELSE
			BEGIN
				SET @_DateStart= @PeriodDateStart
			END
		END
		ELSE IF CONVERT(INT,FORMAT(@DateStart,'yyyyMM','en-US'))< @Period
		BEGIN
			IF @ActDateStart <= @PeriodDateStart
				SET @_DateStart = @PeriodDateStart
			ELSE IF @ActDateStart > @PeriodDateStart
				SET @_DateStart = @ActDateStart
				
	END
	-- Return the result of the function
	RETURN @_DateStart
END
