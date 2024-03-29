USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_PAY_ONB_CrewList]    Script Date: 9/21/2016 8:56:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_PAY_ONB_CrewList]
	-- Add the parameters for the stored procedure here
	@DateStart DATE
AS
BEGIN
DECLARE @DateEnd DATE = EOMONTH(@DateStart)
	SELECT car.*
	FROM CrewActivity_All_InRange(@DateStart, @DateEnd) car
		LEFT JOIN(
			SELECT pcrew.*
			FROM dbo.tblPay p
				INNER JOIN dbo.tblPayCrew_ONB pcrew ON p.PKey = pcrew.FKeyPayID
			WHERE p.Paytype = 'ONB' AND P.MCode = FORMAT(@DateStart,'yyyyMM','en-US'))pONB ON car.ActID = pONB.ActID
	WHERE car.inRange = 1 AND UPPER(ActivityType) = 'SEA' AND pONB.ActID IS NULL
	ORDER BY Crew ASC, ActDateStart DESC

END
