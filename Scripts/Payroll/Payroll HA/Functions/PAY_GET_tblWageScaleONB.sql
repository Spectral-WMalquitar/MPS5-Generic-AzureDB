-- ================================================
-- Template generated from Template Explorer using:
-- Create Inline Function (New Menu).SQL
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
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER FUNCTION PAY_GET_tblWageScaleONB 
(	
	-- Add the parameters for the function here
	@FKeyWageScaleRank AS VARCHAR(15), 
	@WageONBCode AS VARCHAR(15)
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT wONB.* 
	FROM dbo.tblAdmWscaleOnb wONB
		LEFT JOIN dbo.tblAdmWscaleRank wRank On wRank.PKey = wONB.FKeyWScaleRank
		LEFT JOIN dbo.tblAdmWscale wScale  ON wRank.FKeyWScale = wScale.PKey
	WHERE FKeyWageOnb = @WageONBCode
		AND wRank.PKey  = @FKeyWageScaleRank
		AND wONB.WageType = 1
)
GO
