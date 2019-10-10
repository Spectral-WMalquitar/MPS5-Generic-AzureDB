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
CREATE FUNCTION FN_PAY_Allottee
(	
	-- Add the parameters for the function here
	@PeriodDateStart DATE
)
RETURNS TABLE 
AS
RETURN 
(
	-- Add the SELECT statement with parameter references here
	SELECT 
		ROW_NUMBER() OVER (PARTITION BY ra.FKeyRemittanceID ORDER BY ra.StartPeriod DESC ) AS rc,
		r.FKeyIDNbr,
		ra.PKey,
		ra.FKeyRemittanceID,
		ra.Amt,
		ra.FKeyCurr,
		ra.StartPeriod,
		ra.Remarks,
		ra.DateUpdated,
		ra.LastUpdatedBy
		FROM dbo.tblRemitAllot ra
			INNER JOIN dbo.tblRemittance r ON ra.FKeyRemittanceID = r.PKey
	WHERE ra.StartPeriod <= FORMAT(@PeriodDateStart,'yyyyMM','en-US')
		AND (r.WAllot IS NOT NULL AND r.WAllot <> '')
)
GO
