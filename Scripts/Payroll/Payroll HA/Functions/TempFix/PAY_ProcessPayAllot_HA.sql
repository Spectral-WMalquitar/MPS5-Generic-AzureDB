USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[PAY_ProcessPayAllot_HA]    Script Date: 08/17/2016 3:45:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PAY_ProcessPayAllot_HA]
	-- Add the parameters for the stored procedure here
	@PayID VARCHAR(15), 
	@PayCrewID VARCHAR(15),
	@FKeyIDNbr VARCHAR(15),
	@ActID VARCHAR(15),
	@Period INTEGER,
	@LastUpdatedBy VARCHAR(200)
AS
BEGIN

	-- Insert tblPay_Allot
	INSERT INTO 
		dbo.tblPay_Allot(
			FKeyPayCrewHA,
			AllotteeID,
			AcctNbr,
			AcctName,
			LName,FName,MName, 
			FKeyBank,BankName,
			FKeyBranch,BranchName,
			FKeyCntry,
			FKeyCurr,
			LastUpdatedBy)
		SELECT 
			@PayCrewID,
			rem.PKey, --Allot ID
			rem.AcctNbr,
			rem.AcctName,
			rem.LName,rem.FName,rem.MName,
			rem.FKeyBank,bank.Name,
			rem.FKeyBranch,branch.Name AS BranchName,
			rem.FKeyCntry,
			rem.FKeyCurrency,
			@LastUpdatedBy
		FROM dbo.tblRemittance rem
			INNER JOIN dbo.tblRemitAllot remAllot ON rem.PKey = remAllot.FKeyRemittanceID
			INNER JOIN dbo.tblAdmBank bank ON rem.FKeyBank=bank.PKey
			INNER JOIN dbo.FrmBranchList branch ON rem.FKeyBranch = branch.PKey
		WHERE remAllot.StartPeriod = @Period
			AND rem.FKeyIDNbr = @FKeyIDNbr
END
