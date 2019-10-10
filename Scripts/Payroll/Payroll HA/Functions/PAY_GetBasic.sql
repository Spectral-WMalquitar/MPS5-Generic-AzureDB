USE [MPS]
GO
/****** Object:  UserDefinedFunction [dbo].[PAY_GetBasic]    Script Date: 08/10/2016 3:46:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[PAY_GetBasic] 
(
	-- Add the parameters for the function here
	@FKeyIDNbr VARCHAR(15),
	@ActID VARCHAR(15)
)
RETURNS FLOAT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @RetVal AS FLOAT
	DECLARE @AdmAmt FLOAT

	-- Get Basic from Admin WageScale
	SELECT @AdmAmt =  onb.Amt
	FROM dbo.tblActivityGroup ag
		LEFT JOIN dbo.tblActivity ac ON ag.Pkey = Ac.FKeyActivityGroupID
		LEFT JOIN dbo.tblAdmWscaleRank wsRank ON wsRank.PKey = ac.FKeyWScaleRankCode
		LEFT JOIN dbo.tblAdmWscaleOnb onb on onb.FKeyWScaleRank  = ac.FKeyWScaleRankCode
	WHERE Ag.FKeyIDNbr = @FKeyIDNbr AND ac.Pkey = @ActID AND onb.FKeyWageOnb = 'SYSPAYBASIC'

	-- Get Basic From Variable Wage
	DECLARE @AmtWageONB AS FLOAT
	SELECT @AmtWageONB =SUM(onb.Amt)
	FROM dbo.tblWageOnb onb
	GROUP BY 
		onb.Amt,
		onb.FKeyWageOnbID,
		onb.FKeyActivityID,
		onb.FKeyIDNbr
	HAVING FKeyIDNbr  = @FKeyIDNbr
		AND FKeyWageOnbID = 'SYSPAYBASIC'
		AND onb.FKeyActivityID = @ActID

	-- Return the result of the function
	SET @RetVal = isnull((@AdmAmt),0)+isnull((@AmtWageONB),0)
	RETURN @RetVal

END
