USE [MPS]
GO

/****** Object:  UserDefinedFunction [dbo].[CrewActivity_All_InRange]    Script Date: 07/04/2016 3:23:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Earlsan,Name>
-- Create date: <Create Date,June 14, 2016,>
-- Description:	<Description,Gets the Crew Activity Within Range if Range = 1,>
-- =============================================
ALTER FUNCTION [dbo].[CrewActivity_All_InRange] 
(	
	-- Add the parameters for the function here
	@DateFrom AS DATETIME, 
	@DateTo AS DATETIME
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT 
		ca.*,
		dbo.DateIsInRange(@DateFrom,@DateTo,ca.ActDateStart,ca.ActDateEnd) AS inRange, 
		dbo.GetDaysONBRange(@DateFrom,@DateTo,ca.ActDateStart,ca.ActDateEnd) AS DaysRange 
	FROM dbo.CrewList_Activity_All_Pay ca 
		LEFT JOIN dbo.tblCrewInfo ci ON ca.IDNbr = ci.PKey
)

GO


