Imports MPS4
Imports Utilities

Public Class frmKPIDetails

#Region "Declarations"
    Public oKPIDetail As KPIDetail
#End Region

    Public Sub New(ByVal tmpKPIDetail As KPIDetail)

        ' This call is required by the designer.
        InitializeComponent()

        oKPIDetail = tmpKPIDetail

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub InitControl()
        If oKPIDetail Is Nothing Then Exit Sub
        If oKPIDetail.KPICode Is Nothing Then Exit Sub
        If oKPIDetail.KPICode.Length = 0 Then Exit Sub

        '############################################################################################################################################################
        'KPI Name
        txtName.EditValue = oKPIDetail.Name

        '############################################################################################################################################################
        'KPI Type
        txtKPIType.EditValue = oKPIDetail.KPITypeName

        '############################################################################################################################################################
        'Description
        txtDescription.Text = oKPIDetail.KPIDescription
        txtDescription.Height = 100

        '############################################################################################################################################################
        'Formula
        LayoutControlItem_Formula.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        LayoutControlItem_FormulaImage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

        If Not IsNothing(oKPIDetail.Formula.FormulaImage) Then  'Formula Image
            Dim imageData As Byte() = DirectCast(oKPIDetail.Formula.FormulaImage, Byte())

            If Not imageData Is Nothing Then
                Using ms As New System.IO.MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    picFormulaImage.Image = System.Drawing.Image.FromStream(ms, True)
                End Using
            End If

            LayoutControlItem_FormulaImage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

        ElseIf oKPIDetail.Formula.FormulaString.Length > 0 Then   'Formula Text
            LayoutControlItem_Formula.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            txtFormula.EditValue = oKPIDetail.Formula
        End If

        If LayoutControlItem_Formula.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Or _
            LayoutControlItem_FormulaImage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then

            LayoutControlGroup_Formula.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            LayoutControlGroup_Formula.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If

        '############################################################################################################################################################
        'MinReq and Target
        If oKPIDetail.MinReq.Length > 0 Or oKPIDetail.Target.Length > 0 Then
            LayoutControlGroup_MinReqTarget.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            txtMinReq.EditValue = IfNull(oKPIDetail.MinReq, "")
            txtTarget.EditValue = IfNull(oKPIDetail.Target, "")
        Else
            LayoutControlGroup_MinReqTarget.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
        'If oKPIDetail.MinReq <> 0 Or oKPIDetail.Target <> 0 Then
        '    LayoutControlGroup_MinReqTarget.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        '    txtMinReq.EditValue = IfNull(oKPIDetail.MinReq, 0)
        '    txtTarget.EditValue = IfNull(oKPIDetail.Target, 0)
        'Else
        '    LayoutControlGroup_MinReqTarget.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        'End If

        '############################################################################################################################################################
        'Time Period
        txtTimePeriod.EditValue = oKPIDetail.PeriodName

        '############################################################################################################################################################
        'Listing
        txtListing.EditValue = oKPIDetail.SelectionListing

        '############################################################################################################################################################
        'Performance Indicators
        'Dim cSQL As String = "SELECT		map.VariableName, p.Name, p.Description, p.MPSReference, period.Name as Period, u.Name as MeasurementUnit " & _
        '                     "FROM		    dbo.tblpi p " & _
        '                     "              INNER JOIN dbo.tblkpi_map map ON p.PKey = map.FKeyPI " & _
        '                     "              LEFT JOIN dbo.tblAdmKPIPeriod period ON p.FKeyPeriod = period.PKey " & _
        '                     "              LEFT JOIN dbo.tblAdmKPIUnit u ON p.FKeyUnit = u.PKey " & _
        '                     "WHERE		    map.FKeyKPI = '" & oKPIDetail.KPICode & "' " & _
        '                     "ORDER BY	    map.Sortcode, p.Name"

        Dim cSQL As String = "SELECT		map.VariableName, p.Name, p.Description, p.MPSReference " & _
                             "FROM		    dbo.tblpi p " & _
                             "              INNER JOIN dbo.tblkpi_map map ON p.PKey = map.FKeyPI " & _
                             "WHERE		    map.FKeyKPI = '" & oKPIDetail.KPICode & "' " & _
                             "ORDER BY	    map.Sortcode, p.Name"
        Dim dt As DataTable = MPSDB.CreateTable(cSQL)

        If dt.Rows.Count = 0 Then
            LayoutControlGroup_Legend.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Else
            LayoutControlGroup_Legend.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            GridPI.DataSource = dt
        End If

        '############################################################################################################################################################
        'txtKPIType.Focus()


        'MsgBox(AppDomain.CurrentDomain.BaseDirectory)
        'PictureEdit1.Image = System.Drawing.Image.FromFile("E:\YBL_RibbonVioletH2.jpg")

        'Dim dtImg As DataTable = MPSDB.CreateTable("SELECT img FROM dbo.table_1 WHERE PKey = '1'")

        'INSERT INTO <table> (<column>)
        'SELECT BulkColumn 
        'FROM Openrowset( Bulk 'image..Path..here', Single_Blob) as img


        'Dim imageData As Byte() = DirectCast(dtImg.Rows(0).Item("img"), Byte())
        'If Not imageData Is Nothing Then
        '    Using ms As New System.IO.MemoryStream(imageData, 0, imageData.Length)
        '        ms.Write(imageData, 0, imageData.Length)
        '        '.BackgroundImage = Image.FromStream(ms, True)
        '        PictureEdit1.Image = System.Drawing.Image.FromStream(ms, True)
        '    End Using
        'End If

        'Dim dtImg As DataTable = MPSDB.CreateTable("SELECT 0xFFD8FFE000104A46494600010101006000600000FFDB0043000201010201010202020202020202030503030303030604040305070607070706070708090B0908080A0807070A0D0A0A0B0C0C0C0C07090E0F0D0C0E0B0C0C0CFFDB004301020202030303060303060C0807080C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0C0CFFC00011080041010E03012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00FDFCA28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A2AAEB5AD5A787347BBD4350BAB7B1B0B085EE6E6E6E2411C56F122967776380AAAA0924F00035E29FB0BFEDB717EDB7A3F8FEFA1F0A6A9E128BC17E2A7F0FC10EA32E6EB50B6365697B6D78F16C536E6682F227F218978C101F6BEE4521EFCA518EF15CCFC95D2BFDEF4EFADB67625EEC549ECDD97AD9BFC93FE9A3DD68A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A00F9B7F6E6F057C43FDA2FC5BE13F84BA0E93E35F0EFC3BF12C8D77E32F1F68B71A21FECF8214964874F8E0BD92491CCD3C708989B29E230B98C83E6BB45CBFF00C134FE0B7C4CF81BF1C3F68EB7F1D69FE36BDD1BC51E33B7D6FC3FE2BF125C6826E3C4B12E9B6B6524AD0E92C8911DD660A87B5818C4D116064DE17DABE35FC7DF15FC2BF155BE9FA17C11F89FF12AD26B45B87D4FC377FE1C82D6072EEA6065D4755B49BCC01558958CA6245C3960CAB9FF000B7F696F1A7C40F1DD8E91AB7ECF7F17FC0FA7DDF99E6EB7ADEA5E159AC2CB6C6CE3CC5B2D66E6E4EF65083CB85FE675DDB5773294FDC6DAEA9A7F3717F872ADB4EF77A8E6F9925DADF85FF3E677BFCAC8F60A28A2810514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451401F3BFF00C1527F6AAD7BF634FD90352F1C786358F01E89AEC7AC693A55A5CF8CA277D194DE5FC16ACD3B2DCDB18D1125695A432E1162624102B07F617FDAB7C73F1EBE3378AB48BCF147C33F8B7F0F34ED12CEFF004DF885E02D02EF49D166BF927B88E7D352496FEFE0BD78D228DDA4B7B8FDC9631C88AC573B1FB74FC20F8B5F153E237C1ED47E1E689F0F75ED13C01E2397C51AB587893C597DA0B5FDC2595C5B59C68D6DA75E028925C99C9703E6823014E4B2E8FEC5BFB3578B7E1478E7E2B7C42F1FDCF8722F19FC5FD6EDB53BCD1BC3734D3E8FA14169691D9DB431CF347149753B4510796E1A1877B32A88D562524A1F6A52EEFF0028A4BBEFCD2BAB2F755DB52B32B5B48C7B2D7CEEDBF2D925ADFE276578DD7BED14514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451400514514005145140051451401FFFD9 as img")
        'Dim dtImg As DataTable = MPSDB.CreateTable("SELECT FormulaImage as img FROM dbo.tblkpi WHERE PKey = 'SYSMPSKPI027'")

        ''Dim imageData As Byte() = DirectCast(dtImg.Rows(0).Item("img"), Byte())
        'Dim imageData As Byte() = DirectCast(oKPIDetail.FormulaImage, Byte())
        'If Not imageData Is Nothing Then
        '    Using ms As New System.IO.MemoryStream(imageData, 0, imageData.Length)
        '        ms.Write(imageData, 0, imageData.Length)
        '        '.BackgroundImage = Image.FromStream(ms, True)
        '        picFormulaImage.Image = System.Drawing.Image.FromStream(ms, True)
        '    End Using
        'End If
    End Sub

    Private Sub frmKPIDetails_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitControl()
    End Sub

    Private Sub frmKPIDetails_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtName.Focus()
        txtName.SelectionStart = 0
        txtName.SelectionLength = 0
    End Sub
End Class