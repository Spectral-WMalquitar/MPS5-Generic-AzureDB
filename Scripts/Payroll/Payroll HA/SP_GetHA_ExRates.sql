USE [MPS]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetHA_ExRates]    Script Date: 09/16/2016 12:45:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Earlsan Villegas,Name>
-- Create date: <Create Date,20160822,>
-- Description:	<Description,Get all the Currency in the Selected Period,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_GetHA_ExRates] 
	-- Add the parameters for the stored procedure here
	@DateStart DATE

AS
BEGIN

DECLARE @DateEnd DATE = EOMONTH(@DateStart)

	DECLARE @tblWageScale TABLE(
		FKeyCurr VARCHAR(15)
	)
	INSERT INTO @tblWageScale
	SELECT ws.FKeyCurr
	FROM CrewActivity_All_InRange(@DateStart,@DateEnd) car
		INNER JOIN dbo.tblAdmWscale ws ON car.FkeyWScaleCode = ws.PKey
	GROUP BY 
		ws.FKeyCurr,
		inRange
	HAVING inRange =1
	--SELECT * FROM @tblWageScale

	DECLARE @tblRemitAllot TABLE(
		FKeyCurr VARCHAR(15)
	)
	INSERT INTO @tblRemitAllot
	SELECT ra.FKeyCurr
	FROM CrewActivity_All_InRange(@DateStart,@DateEnd) car
		--INNER JOIN dbo.tblAdmWscaleRank wr ON car.FKeyRankCode = wr.PKey
		INNER JOIN dbo.tblRemittance r ON car.IDNbr = r.FKeyIDNbr
		INNER JOIN dbo.tblRemitAllot ra ON r.PKey = ra.FKeyRemittanceID
	GROUP BY ra.FKeyCurr
	--SELECT * FROM @tblRemitAllot 

	DECLARE @tblRemOthWage TABLE(
		FKeyCurr VARCHAR(15)
	)
	INSERT INTO @tblRemOthWage
	SELECT rw.FKeyCurr
	FROM CrewActivity_All_InRange(@DateStart,@DateEnd) car
		--INNER JOIN dbo.tblAdmWscaleRank wr ON car.FKeyRankCode = wr.PKey
		INNER JOIN dbo.tblRemittance r ON car.IDNbr = r.FKeyIDNbr
		INNER JOIN dbo.tblRemitOtherWage rw ON r.PKey = rw.FKeyRemittanceID
		INNER JOIN dbo.tblRemitAllot ra ON r.PKey = ra.FKeyRemittanceID
	GROUP BY rw.FKeyCurr,
		ra.StartPeriod
	HAVING FORMAT(ra.StartPeriod,'yyyyMM','en-US') = FORMAT(@DateStart,'yyyyMM','en-US')
	--SELECT * FROM @tblRemOthWage

	SELECT *,CAST(0 AS float) AS ExRate FROM @tblRemitAllot 
	UNION SELECT *,CAST(0 AS float) AS ExRate FROM @tblRemOthWage
	UNION SELECT *,CAST(0 AS float) AS ExRate FROM @tblWageScale
END
