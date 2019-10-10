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
ALTER PROCEDURE PAY_ProcessPayAshEmp_HA
	-- Add the parameters for the stored procedure here
	@PayCrewID VARCHAR(15),
	@PayID VARCHAR(15),
	@PeriodDate DATE,
	@FKeyIDNbr VARCHAR(15),
	@ActID VARCHAR(15),
	@FKeyWScaleCode VARCHAR(15),
	@FKeyWScaleRank VARCHAR(15),
	@tblPayExRate Type_tblPayExRate READONLY,
	@LastUpdatedBy VARCHAR(200)
AS
BEGIN
	INSERT INTO tblPay_AshEmp(
			FKeyPayCrewHA,
			FKeyWageAshEmp,
			FKeyCurr,
			ExRate,
			Amt,
			CAmt,
			DateStart,
			DateEnd,
			LastUpdatedBy)
	SELECT 
		@PayCrewID,
		admAshEmp.PKey,
		WSAshEmp.FKeyCurr,
		ISNULL((SELECT ExRate FROM @tblPayExRate WHERE FKeyCurr = WSAshEmp.FKeyCurr AND FKeyPay = @PayID),1),
		CASE WHEN WSAshEmp.Amt <>0 THEN WSAshEmp.Amt
			ELSE dbo.PAY_HA_GetWageAshAmt(FKeyWageAshEmp,Amt,dbo.PAY_GetBasic(@FKeyIDNbr ,@ActID),WSAshEmp.FKeyCurr,WSAshEmp.Formula) END,
		ISNULL((CASE WHEN WSAshEmp.Amt <>0 THEN WSAshEmp.Amt
			ELSE dbo.PAY_HA_GetWageAshAmt(FKeyWageAshEmp,Amt,dbo.PAY_GetBasic(@FKeyIDNbr ,@ActID),WSAshEmp.FKeyCurr,WSAshEmp.Formula) END),0) * ISNULL((SELECT ExRate FROM @tblPayExRate WHERE FKeyCurr =WSAshEmp.FKeyCurr AND FKeyPay = @PayID),1),
		@PeriodDate,
		 (SELECT CASE WHEN ActDateEnd IS NULL THEN EOMONTH(@PeriodDate)
					 WHEN ActDateEnd >= @PeriodDate AND ActDateEnd<= EOMONTH(@PeriodDate) THEN ActDateEnd
					 ELSE EOMONTH(@PeriodDate) END
		 FROM dbo.tblActivity WHERE Pkey = @ActID),
		@LastUpdatedBy
	FROM dbo.tblAdmWscale WScale
		INNER JOIN dbo.tblAdmWscaleRank WSRank ON WSRank.FKeyWScale = WScale.PKey
		INNER JOIN dbo.tblAdmWscaleAshEmp WSAshEmp ON WSAshEmp.FKeyWScaleRank = WSRank.PKey
		INNER JOIN dbo.tblAdmWageAshEmp admAshEmp ON WSAshEmp.FKeyWageAshEmp  = admAshEmp.PKey

	WHERE WScale.PKey = @FKeyWScaleCode AND WSRank.PKey = @FKeyWScaleRank
END
GO
