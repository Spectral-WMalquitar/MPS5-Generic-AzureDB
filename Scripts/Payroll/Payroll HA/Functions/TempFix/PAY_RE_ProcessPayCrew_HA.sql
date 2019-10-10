USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[PAY_RE_ProcessPayCrew_HA]    Script Date: 08/18/2016 11:57:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PAY_RE_ProcessPayCrew_HA] 
	-- Add the parameters for the stored procedure here
	@PayID VARCHAR(15),
	@PeriodDate DATE,
	@ActID VARCHAR(15), 
	@FKeyIDNbr VARCHAR(15),
	@LastUpdatedBy VARCHAR(200)

AS
BEGIN

	--DECLARE @DateStart DATE

	--SELECT @DateStart = DateStart
	--FROM dbo.tblPayCrew_HA
	--WHERE PKey = @PayCrewID

	--	-- Delete tblPayCrew_HA
	--DELETE FROM dbo.tblPayCrew_HA
	--WHERE PKey = @PayCrewID

	--DElete Allottees
	--DELETE FROM dbo.tblPay_Allot
	--WHERE FKeyPayCrewHA = @PayCrewID 

	EXEC dbo.PAY_ProcessPayCrew_HA @PayID,@PeriodDate,@ActID,@FKeyIDNbr,@LastUpdatedBy



END
