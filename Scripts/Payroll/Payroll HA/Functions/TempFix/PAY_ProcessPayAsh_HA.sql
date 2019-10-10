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
ALTER PROCEDURE PAY_ProcessPayAsh_HA
	-- Add the parameters for the stored procedure here
	@PeriodDate DATE,
	@PayID VARCHAR(15),
	@PayAllotID VARCHAR(15),
	@FKeyIDNbr VARCHAR(15),
	@ActID VARCHAR(15),
	@FKeyWScaleCode VARCHAR(15),
	@FKeyWScaleRank VARCHAR(15),
	@tblPayExRate Type_tblPayExRate READONLY,
	@LastUpdatedBy VARCHAR(200)
AS
BEGIN
	INSERT INTO dbo.tblPay_Ash(
		FKeyPayAllotID,
		FKeyWageAsh,
		WageType,
		Amt,
		CAmnt,
		FKeyCurr,
		ExRate,
		DateStart,
		DateEnd)
	SELECT 
		@PayAllotID,
		WSAsh.FKeyWageAsh,
		WSAsh.WageType,
		CASE WHEN ISNULL(WSAsh.Amt,0)<>0 THEN ISNULL(WSAsh.Amt,0)
			ELSE dbo.PAY_HA_GetWageAshAmt(FKeyWageAsh,Amt,dbo.PAY_GetBasic(@FKeyIDNbr ,@ActID),WSAsh.FKeyCurr,Formula) END,
		ISNULL((CASE WHEN ISNULL(WSAsh.Amt,0) <>0 THEN ISNULL(WSAsh.Amt,0)
			ELSE dbo.PAY_HA_GetWageAshAmt(FKeyWageAsh,Amt,dbo.PAY_GetBasic(@FKeyIDNbr ,@ActID),WSAsh.FKeyCurr,Formula) END),0) * ISNULL((SELECT ExRate FROM @tblPayExRate WHERE FKeyCurr =WSAsh.FKeyCurr AND FKeyPay = @PayID),1),
		WSAsh.FKeyCurr,
		ISNULL((SELECT ExRate FROM @tblPayExRate WHERE FKeyCurr = WSAsh.FKeyCurr AND FKeyPay = @PayID),1),
		@PeriodDate,
		 (SELECT CASE WHEN ActDateEnd IS NULL THEN EOMONTH(@PeriodDate)
					 WHEN ActDateEnd >= @PeriodDate AND ActDateEnd < = EOMONTH(@PeriodDate) THEN ActDateEnd
					 ELSE EOMONTH(@PeriodDate) END
		 FROM dbo.tblActivity WHERE Pkey = @ActID)
	FROM 
		dbo.tblAdmWscale WScale
		LEFT JOIN dbo.tblAdmWscaleRank WSRank ON WSRank.FKeyWScale = WScale.PKey
		LEFT JOIN dbo.tblAdmWscaleAsh WSAsh ON WSAsh.FKeyWScaleRank = WSRank.PKey
		WHERE WScale.PKey = @FKeyWScaleCode AND WSRank.PKey = @FKeyWScaleRank


END
GO
