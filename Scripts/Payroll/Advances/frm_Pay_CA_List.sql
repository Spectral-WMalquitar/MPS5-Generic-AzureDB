USE [MPS]
GO

/****** Object:  View [dbo].[frm_Pay_CA_List]    Script Date: 19/9/2016 3:12:12 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[frm_Pay_CA_List]
AS
SELECT        ca.ID, ca.PKey, ca.DatePrepared, ca.Description, ca.FKeyCurr, ca.ExRate, ca.FKeyVsl, ca.FKeyPort, ca.FKeyCAType, ca.Period, ca.Ref, ca.isImported, 
                         ca.DateUpdated, ca.LastUpdatedBy, p.Name AS PortName, cat.Name AS TypeName, dbo.tblAdmVsl.Name AS VesselName
FROM            dbo.tblCA AS ca INNER JOIN
                         dbo.tblAdmVsl ON ca.FKeyVsl = dbo.tblAdmVsl.PKey LEFT OUTER JOIN
                         dbo.tblAdmPort AS p ON ca.FKeyPort = p.PKey LEFT OUTER JOIN
                         dbo.tblAdmCAType AS cat ON ca.FKeyCAType = cat.PKey

GO


