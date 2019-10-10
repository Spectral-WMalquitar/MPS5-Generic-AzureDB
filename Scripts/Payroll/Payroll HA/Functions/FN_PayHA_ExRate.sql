USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[FN_PayHA_ExRate]    Script Date: 14/10/2016 2:56:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[FN_PayHA_ExRate]
(
	-- Add the parameters for the function here
	@tblExRate Type_tblPayExRate READONLY,
	@FKeyPayID VARCHAR(15),
	@WageCurr VARCHAR(15),
	@BankCurr VARCHAR(15),
	@RefCurr VARCHAR(15)
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @OutExRate FLOAT = 0
	DECLARE @RefExRate FLOAT = 0
	DECLARE @BankExRate FLOAT =0
	DECLARE @ExRate FLOAT = 0

	-- Add the T-SQL statements to compute the return value here
	--SELECT @RefExRate = ExRate FROM @tblExRate  WHERE FKeyCurr = @RefCurr  AND  FKeyPay = @FKeyPayID 
	SET @RefExRate = 1
	SELECT @BankExRate = ExRate FROM @tblExRate  WHERE FKeyCurr = @BankCurr  AND  FKeyPay = @FKeyPayID 
	SELECT @ExRate = ExRate FROM @tblExRate  WHERE FKeyCurr = @WageCurr  AND  FKeyPay = @FKeyPayID 
	
	SET @OutExRate = (@RefExRate  / nullif(@ExRate,0)) * ( @BankExRate)

	--IF @WageCurr = @RefCurr
	--BEGIN
	--	SET @OutExRate = 1
	--END
	--ELSE
	--BEGIN
	--	SELECT @OutExRate = ExRate FROM @tblExRate WHERE FKeyCurr = @WageCurr AND FKeyPay = @FKeyPayID
	--END

	-- Return the result of the function
	RETURN @OutExRate

END
