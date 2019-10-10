USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[PAY_ProcessPayCrew_HA]    Script Date: 08/15/2016 4:25:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[PAY_ProcessPayCrew_HA] 
	-- Add the parameters for the stored procedure here
	@PayID VARCHAR(15),
	@PeriodDate DATE,
	@ActID VARCHAR(15), 
	@FKeyIDNbr VARCHAR(15),
	@LastUpdatedBy VARCHAR(200)

AS
BEGIN

    -- Insert statements for procedure here
	INSERT INTO dbo.tblPayCrew_HA(
			FKeyPayID,
			FKeyIDNbr,
			ActGrpID,
			ActID,
			LName,FName,MName,
			CivilStatCode,
			FKeyRank,RankName,
			FKeyStatus, [Status],
			FKeyVsl, VslName,
			FKeyAgent, AgentName,
			FKeyPrincipal,PrincipalName,
			DateStart,DateEnd,
			FKeyWScaleCode,FKeyWscalRankCode,
			FKeyCurr,
			AmtBasic,
			LastUpdatedBy)
		SELECT 
			@PayID,
			ActGroup.FKeyIDNbr,
			ActGroup.Pkey,
			Act.Pkey,
			ActGroup.LName,ActGroup.FName,ActGroup.MName,
			CrewInfo.FKeyCivilStat,
			Act.FKeyRankCode, Act.RankName,
			Act.FKeyStatCode,Act.StatName,
			Act.FKeyVslCode,Act.VslName,
			Act.FKeyAgentCode,Act.AgentName,
			act.FKeyPrinCode,act.PrinName,
			@PeriodDate,
			(SELECT CASE WHEN ActDateEnd IS NULL THEN EOMONTH(@PeriodDate)
				WHEN ActDateEnd >= @PeriodDate AND ActDateEnd<= EOMONTH(@PeriodDate) THEN ActDateEnd
				ELSE EOMONTH(@PeriodDate) END
			 FROM dbo.tblActivity WHERE Pkey = @ActID),
			Act.FkeyWScaleCode,Act.FKeyWScaleRankCode,
			ws.FKeyCurr,
			dbo.PAY_GetBasic(@FKeyIDNbr,@ActID),
			@LastUpdatedBy
		FROM dbo.tblActivityGroup ActGroup
			INNER JOIN dbo.tblActivity Act ON ActGroup.Pkey = Act.FKeyActivityGroupID
			INNER JOIN dbo.tblAdmWscale ws ON act.FkeyWScaleCode = ws.PKey
			INNER JOIN dbo.tblCrewInfo CrewInfo ON ActGroup.FKeyIDNbr = CrewInfo.PKey
			WHERE act.Pkey = @ActID AND ActGroup.FKeyIDNbr = @FKeyIDNbr
END
