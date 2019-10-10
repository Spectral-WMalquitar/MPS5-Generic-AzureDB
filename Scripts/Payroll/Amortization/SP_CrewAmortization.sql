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
ALTER PROCEDURE SP_CrewAmortization 
	-- Add the parameters for the stored procedure here
	@FKeyIDNbr VARCHAR(15)
AS
BEGIN
	--Crew Amortization
	SELECT 
		amort.[PKey],
		[FKeyWageAsh],
		[RefNo],
		[LoanAmt],
		[LoanDate],
		[DateGranted],
		dbo.periodToDate([StartPeriod]) as StartPeriod,
		[MonthlyDed],
		[LoanInterest],
		[OtherCharge],
		[FKeyCurrency],
		[FKeyRemitAllot],
		[Remarks],
		ISNULL(AmtPd,0) AS AmtPd,
		ISNULL((LoanAmt + LoanInterest + OtherCharge) - AmtPd,0) AS RemBal
	FROM [dbo].[tblAmortization] amort
		LEFT JOIN (
			SELECT 
				SUM(AmtPd) AS AmtPd,
				PKey
			FROM dbo.frm_Pay_CrewAmort_distrib 
			GROUP BY PKey) dist ON amort.PKey = dist.PKey
	WHERE FKeyIDNbr = @FKeyIDNbr

	--Amortization Distribution
	SELECT * 
	FROM dbo.frm_Pay_CrewAmort_distrib 
	WHERE FKeyIDNbr = @FKeyIDNbr
	ORDER BY MCode ASC

	--RemitAllot
	SELECT LName + ', ' + FName + ' ' + ISNULL(MName, '') as Name, PKey 
	FROM tblRemittance 
	WHERE FKeyIDNbr = @FKeyIDNbr 
	ORDER BY Name

END
GO
