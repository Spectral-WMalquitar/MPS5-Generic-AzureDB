USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[PAY_HA_GetWageAshAmt]    Script Date: 9/23/2016 1:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[PAY_HA_GetWageAshAmt]
(
	-- Add the parameters for the function here
	@FKeyWageAsh VARCHAR(15),
	@Amt FLOAT,
	@BasicAmt FLOAT,
	@FKeyCurr VARCHAR(15),
	@Formula VARCHAR(200)
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RetVal FLOAT

	---- Convert the Basic Amount
	--IF @FKeyCurr = 'SYSCUUSD'
	--BEGIN
	--	SET @BasicAmt = @BasicAmt
	--END
	--ELSE
	--BEGIN
	--	SET @BasicAmt = @BasicAmt
	--END


	-- Add the T-SQL statements to compute the return value here
	SELECT @RetVal = (
		CASE WHEN @FKeyWageAsh = 'SYSPAYSSS' THEN
				dbo.GetSSSTableEmployee(@BasicAmt)  --Get SSS
			WHEN @FKeyWageAsh = 'SYSPAYMCR' THEN
				dbo.GetMCREmployee(@BasicAmt) -- Philhealth
			ELSE
				@Amt
		END)
	-- Return the result of the function
	RETURN ISNULL(@RetVal,0)

END
