Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Module PayrollModule
    ''' <summary>
    ''' Get the Referencial Currency
    ''' </summary>
    ''' <param name="Mode"> 0: PKey; 1: Sysmbol; 2: Name </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRefCurrency(Optional Mode As Integer = 0) As String
        Select Case Mode
            Case 0 'Returns the Key
                Return MPSDB.DLookUp("PKey", "tblAdmCurr", "", "Ref <> 0")
            Case 1 'Returns the Symbol
                Return MPSDB.DLookUp("Symbol", "tblAdmCurr", "", "Ref <> 0")
            Case 2 'Returns the Name
                Return MPSDB.DLookUp("Name", "tblAdmCurr", "", "Ref <> 0")
            Case Else
                Return MPSDB.DLookUp("PKey", "tblAdmCurr", "", "Ref <> 0")
        End Select
    End Function

    Public Function GetPayPeriods(Interval As String, MinValue As Integer, MaxValue As Integer) As DataTable
        Dim cTbl As New DataTable
        cTbl = MPSDB.CreateTable("EXEC dbo.GetPeriodsInterval '" & Interval & "' , " & MinValue & "," & MaxValue)
        Return cTbl
    End Function

    Public Function CalculateConvertedAmount(tblExRate As DataView, Amt As Double, AmtCurr As String, RefCurr As String) As Double
        Dim retVal As Double = 0
        Dim RefExRate As Double = IfNull((From dr As DataRowView In tblExRate Where dr("FKeyCurr") = RefCurr Select dr("ExRate")).FirstOrDefault(), CDbl(0))
        Dim AmtExRate As Double = IfNull((From dr As DataRowView In tblExRate Where dr("FKeyCurr") = AmtCurr Select dr("ExRate")).FirstOrDefault(), CDbl(0))

        retVal = (Amt / AmtExRate) * RefExRate

        Return retVal
    End Function

#Region "Report Signatory in View Forms"
    Public oSignatoryCtrl As New Reports.BaseFilterOption

    Public Structure PayrollSignatory
        Const PreparedBy As String = "Prepared By"
        Const NotedBy As String = "Noted By"
        Const ReceivedBy As String = "Received By"
    End Structure

    Public Enum PayrollSignatoryField
        Name = 1
        Position = 2
        NameAndPosition = 3
    End Enum

    Public Sub LoadSignatoryControl(ByRef oPanelControl As DevExpress.XtraEditors.PanelControl)

        'Dim REPORT_DETAIL As New Reports.ReportDetail

        extAssembly = System.Reflection.Assembly.Load(Reports.DefaultFilterOptionControlDLL)
        oSignatoryCtrl = extAssembly.CreateInstance(Reports.DefaultFilterOptionControlDLL & "." & Reports.DefaultFilterOptionControl, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)

        If Not oSignatoryCtrl Is Nothing Then
            'ADDS THE FILTER OPTION OBJECT IN THE PRINT SELECTION FORM
            'Dim FilterOptionParam As String = MPSDB.DLookUp("CriteriaFieldValue", "MSysRptDataMapping", "", "PKey = 'PAY_SIGNATORIES'")
            'If FilterOptionParam.Length > 0 Then
            '    oSignatoryCtrl.FilterOptionsParam = FilterOptionParam
            'End If

            oSignatoryCtrl.ReportObjectID = "PAY_SIGNATORIES"
            oSignatoryCtrl.ReportGroup = "PAY_SIGNATORIES"


            oPanelControl.Controls.Add(oSignatoryCtrl)
            oSignatoryCtrl.Dock = Windows.Forms.DockStyle.Fill
            oSignatoryCtrl.RefreshData()
        End If

    End Sub

    Function getPayrollSignatory(ByVal GetWhatSignatory As String, ByVal GetWhatField As PayrollSignatoryField) As String
        Dim cReturnValue As String = ""

        If GetWhatSignatory.ToString.Length > 0 And GetWhatField.ToString.Length > 0 Then

            If Not oSignatoryCtrl Is Nothing Then
                cReturnValue = oSignatoryCtrl.GetFilterValue(GetWhatSignatory.ToString, GetWhatField.ToString).ToString
            End If
        End If

        Return cReturnValue

    End Function

    Sub PassPayrollSignatoryToReportDetail(ByRef REPORT_DETAIL As Reports.ReportDetail)

        '####################################################################################################################################
        'Prepared By
        Try
            With REPORT_DETAIL.PreparedBy
                .Name = getPayrollSignatory(PayrollSignatory.PreparedBy, PayrollSignatoryField.Name)
                .Position = getPayrollSignatory(PayrollSignatory.PreparedBy, PayrollSignatoryField.Position)
                .NameAndPosition = getPayrollSignatory(PayrollSignatory.PreparedBy, PayrollSignatoryField.NameAndPosition)
            End With
        Catch ex As Exception
            'CALL ERROR LOG
        End Try

        '####################################################################################################################################
        'Noted By
        Try
            With REPORT_DETAIL.NotedBy
                .Name = getPayrollSignatory(PayrollSignatory.NotedBy, PayrollSignatoryField.Name)
                .Position = getPayrollSignatory(PayrollSignatory.NotedBy, PayrollSignatoryField.Position)
                .NameAndPosition = getPayrollSignatory(PayrollSignatory.NotedBy, PayrollSignatoryField.NameAndPosition)
            End With
        Catch ex As Exception
            'CALL ERROR LOG
        End Try

        '####################################################################################################################################
        'Received By
        Try
            With REPORT_DETAIL.ReceivedBy
                .Name = getPayrollSignatory(PayrollSignatory.ReceivedBy, PayrollSignatoryField.Name)
                .Position = getPayrollSignatory(PayrollSignatory.ReceivedBy, PayrollSignatoryField.Position)
                .NameAndPosition = getPayrollSignatory(PayrollSignatory.ReceivedBy, PayrollSignatoryField.NameAndPosition)
            End With
        Catch ex As Exception
            'CALL ERROR LOG
        End Try
    End Sub

#End Region

    Public Sub SetSelectedVessel(cboVsl As DevExpress.XtraEditors.CheckedComboBoxEdit, VslCodes As String)
        For Each itM As DevExpress.XtraEditors.Controls.CheckedListBoxItem In cboVsl.Properties.GetItems
            If InStr(VslCodes, itM.Value.ToString()) > 0 Then
                itM.CheckState = Windows.Forms.CheckState.Checked
            End If
        Next
    End Sub

    Public Sub SetSelectedPay(cboRefNo As DevExpress.XtraEditors.CheckedComboBoxEdit, PayIDS As String)
        For Each itM As DevExpress.XtraEditors.Controls.CheckedListBoxItem In cboRefNo.Properties.GetItems
            If InStr(PayIDS, itM.Value.ToString()) > 0 Then
                itM.CheckState = Windows.Forms.CheckState.Checked
            End If
        Next
    End Sub

    'Public Function GridFilterString(sPeriod As String, sPrincipal As String, sVslCode As String, sRefNo As String) As String
    '    Dim retVal As String = String.Empty
    '    'Dim strPeriod As String = IIf(UCFilter.PayPeriod <= 0, String.Empty, UCFilter.PayPeriod),
    '    '    strPrincipal As String = UCFilter.PayPrincipal,
    '    '    strVslCode As String = UCFilter.strGetSelectedVsl,
    '    '    strRefNo As String = UCFilter.strGetSelectRefNo
    '    Dim strPeriod As String = IIf(sPeriod <= 0, String.Empty, sPeriod),
    '        strPrincipal As String = sPrincipal,
    '        strVslCode As String = sVslCode,
    '        strRefNo As String = sRefNo

    '    If Trim(strPeriod).Length > 0 Then
    '        strPeriod = " MCode = " & sPeriod
    '    Else
    '        strPeriod = String.Empty
    '    End If
    '    If Trim(strPrincipal).Length > 0 Then
    '        strPrincipal = " FKeyPrincipal = '" & sPrincipal & "' "
    '    Else
    '        strPrincipal = String.Empty
    '    End If
    '    If Trim(strVslCode).Length > 0 Then
    '        strVslCode = sVslCode
    '    End If
    '    If Trim(strRefNo).Length > 0 Then
    '        strRefNo = sRefNo
    '    End If

    '    If Trim(strPeriod).Length > 0 Then
    '        retVal = strPeriod & _
    '            IIf(Trim(strPrincipal).Length > 0, " AND " & strPrincipal, String.Empty) & _
    '            IIf(Trim(strVslCode).Length > 0, " AND " & strVslCode, String.Empty) & _
    '            IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
    '    Else
    '        If Trim(strPrincipal).Length > 0 Then
    '            retVal = IIf(Trim(strPrincipal).Length > 0, strPrincipal, String.Empty) & _
    '                   IIf(Trim(strVslCode).Length > 0, " AND " & strVslCode, String.Empty) & _
    '                   IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
    '        Else
    '            If Trim(strVslCode).Length > 0 Then
    '                retVal = IIf(Trim(strVslCode).Length > 0, strVslCode, String.Empty) & _
    '                    IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
    '            Else
    '                If Trim(strRefNo).Length > 0 Then
    '                    retVal = IIf(Trim(strRefNo).Length > 0, strRefNo, String.Empty)
    '                Else
    '                    retVal = String.Empty
    '                End If
    '            End If
    '        End If
    '    End If
    '    Return retVal
    'End Function



#Region "Import /export to Excel"
#Region "Cash Advances"
    Public Sub ImportCAFromExcel()
        ShowCustomLoadScreen(GetType(MPS4.Waitform))
        Dim FileDiag As New OpenFileDialog
        FileDiag.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls|All files|*.*"
        FileDiag.ShowDialog()
        Dim strFilePath As String = FileDiag.FileName
        If strFilePath.Trim().Length <= 0 Then
            CloseCustomLoadScreen()
            Exit Sub
        End If
        Dim xlApp As New clsExcelFunction(strFilePath, "MainDetails")
        Dim dt As DataTable = xlApp.CreateTable("Select [COMPANY_ID],[Amount],[Item] FROM [CrewDetails$] ")
        'MsgBox(xlApp.ReadRowCellValue("MainDetails", 3, 2))
        Dim SheetName As String = "MainDetails"
        Dim Period As Integer = IfNull(xlApp.ReadRowCellValue(SheetName, 1, 2), Date.Now).ToString("yyyyMM")
        Dim RefNo As String = IfNull(xlApp.ReadRowCellValue(SheetName, 1, 4), String.Empty)
        Dim IMONo As String = IfNull(xlApp.ReadRowCellValue(SheetName, 2, 2), String.Empty)
        Dim VslName As String = IfNull(xlApp.ReadRowCellValue(SheetName, 2, 4), String.Empty)
        Dim CATypeName As String = IfNull(xlApp.ReadRowCellValue(SheetName, 3, 2), String.Empty)
        Dim CAPortName As String = IfNull(xlApp.ReadRowCellValue(SheetName, 3, 4), String.Empty)
        Dim FKeyCurrName As String = IfNull(xlApp.ReadRowCellValue(SheetName, 4, 2), String.Empty)
        Dim ExRate As Double = IfNull(xlApp.ReadRowCellValue(SheetName, 4, 4), 0.0)
        Dim DatePrepared As Date = IfNull(xlApp.ReadRowCellValue(SheetName, 5, 2), Date.Now).ToString("yyyy-MM-dd")
        Dim strDescription As String = IfNull(xlApp.ReadRowCellValue(SheetName, 6, 2), String.Empty)
        xlApp.CloseExcelFile() 'Close Excel App
        If SaveCAtoDBImportData(DatePrepared, strDescription, FKeyCurrName, ExRate, VslName, CAPortName, CATypeName, Period, RefNo, True, dt) Then
            CloseCustomLoadScreen()
            MsgBox("Import data successful.", MsgBoxStyle.Information, GetAppName())
            Exit Sub
        Else
            CloseCustomLoadScreen()
            MsgBox("Unable to import data to database", MsgBoxStyle.Exclamation, GetAppName())
        End If
        CloseCustomLoadScreen()
    End Sub

    Private Function SaveCAtoDBImportData(DatePrepared As Date, strDescription As String, FKeyCurrName As String, ExRate As Double, FKeyVslName As String, FKeyPortName As String, _
                                        FKeyCATypeName As String, Period As Integer, Ref As String, isImported As Boolean, CASeaman As DataTable) As Boolean
        Dim retVal As Boolean = False
        Dim LastUpdatedBy As String = "LastUpdatedBy"
        Dim sqlCon As New SqlClient.SqlConnection(MPSDB.GetConnectionString)
        If CASeaman.Rows.Count <= 0 Then
            Return False
        End If
        Try
            sqlCon.Open()
            Dim dvCASeaman As New DataView(CASeaman)
            If dvCASeaman.Count > 0 Then
                CASeaman = dvCASeaman.ToTable(True, New String() {"COMPANY_ID", "Amount", "Item"})
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlCon
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "SP_PAY_Process_CA"
                    With cmd.Parameters
                        .AddWithValue("@DatePrepared", CDate(DatePrepared).ToString("yyyy-MM-dd"))
                        .AddWithValue("@strDescription", IfNull(strDescription, String.Empty))
                        .AddWithValue("@FKeyCurrName", FKeyCurrName)
                        .AddWithValue("@ExRate", CDbl(ExRate))
                        .AddWithValue("@FKeyVslName", FKeyVslName)
                        .AddWithValue("@FKeyPortName", FKeyPortName)
                        .AddWithValue("@FKeyCATypeName", FKeyCATypeName)
                        .AddWithValue("@Period", Period)
                        .AddWithValue("@Ref", Ref)
                        .AddWithValue("@isImported", isImported)
                        .AddWithValue("@CASeaman", CASeaman)
                        .AddWithValue("@LastUpdatedBy", LastUpdatedBy)
                    End With
                    retVal = (cmd.ExecuteNonQuery() > 0)
                End Using
            Else
                retVal = False
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            retVal = False
        Finally
            If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
        End Try

        Return retVal
    End Function

    Public Sub GenerateCAExcelTemplate()
        ShowCustomLoadScreen(GetType(MPS4.Waitform))
        'Dim FileDiag As New OpenFileDialog
        'FileDiag.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls|All files|*.*"
        'FileDiag.ShowDialog()
        'Dim strFilePath As String = FileDiag.FileName
        'If strFilePath.Trim().Length <= 0 Then
        '    Cursor = Cursors.Default
        '    CloseCustomLoadScreen()
        '    Exit Sub
        'End If

        Dim strFilePath As String = IfNull(MPSDB.Settings("TEMPLATE_FOLDER"), String.Empty) & "\CashAdvance_Template.xlsx"

        Dim xlApp As clsExcelFunction = New clsExcelFunction(strFilePath, "Cash Advance Template " + Date.Now.ToString("yyyMMdd").ToString, "MainDetails")

        If Not IsNothing(xlApp.FilePath) Then

            '--------------- Cash Advance ----------------------
            Dim dtCAType As DataTable = MPSDB.CreateTable("SELECT Name FROM dbo.tblAdmCAType ORDER BY Name ASC")
            For index = 0 To dtCAType.Rows.Count - 1
                xlApp.SetExcelValue("F" & index + 1, dtCAType.Rows(index).Item(0).ToString, SheetName:="Sheet3")
            Next
            xlApp.HideColumn("F1:F" & dtCAType.Rows.Count - 1, True, SheetName:="Sheet3")
            xlApp.AddLookValidationDropDown("B3", "CAType", "F"c, 1, "F"c, dtCAType.Rows.Count, SheetToName:="MainDetails", DataSheetFromName:="Sheet3")
            '--------------- End Cash Advance ----------------------

            '--------------- Vessel ----------------------
            Dim strVslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, " WHERE " & GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
            Dim dtVsl As DataTable = MPSDB.CreateTable("SELECT Name FROM dbo.VslList " & strVslFilter & " ORDER BY Name ASC")
            For index = 0 To dtVsl.Rows.Count - 1
                xlApp.SetExcelValue("E" & index + 1, dtVsl.Rows(index).Item(0).ToString, SheetName:="Sheet3")
            Next
            xlApp.HideColumn("E1:E" & dtVsl.Rows.Count - 1, True, SheetName:="Sheet3")
            xlApp.AddLookValidationDropDown("D2", "CAVsl", "E"c, 1, "E"c, dtVsl.Rows.Count, SheetToName:="MainDetails", DataSheetFromName:="Sheet3")
            '--------------- End Vessel ----------------------


            '--------------- Currency ----------------------
            Dim dtCACurr As DataTable = MPSDB.CreateTable("SELECT Name FROM dbo.tblAdmCurr ORDER BY Ref DESC , Name ASC")
            For index = 0 To dtCACurr.Rows.Count - 1
                xlApp.SetExcelValue("G" & index + 1, dtCACurr.Rows(index).Item(0).ToString, SheetName:="Sheet3")
            Next
            xlApp.HideColumn("G1:G" & dtCACurr.Rows.Count - 1, True, SheetName:="Sheet3")
            xlApp.AddLookValidationDropDown("B4", "CACurr", "G"c, 1, "G"c, dtCACurr.Rows.Count, SheetToName:="MainDetails", DataSheetFromName:="Sheet3")
            '--------------- End Currency ----------------------



            '--------------- Port ----------------------
            Dim dtPort As DataTable = MPSDB.CreateTable("SELECT Name FROM dbo.tblAdmPort ORDER BY Name ASC")
            For index = 0 To dtPort.Rows.Count - 1
                xlApp.SetExcelValue("H" & index + 1, dtPort.Rows(index).Item(0).ToString, SheetName:="Sheet3")
            Next
            xlApp.HideColumn("H1:H" & dtPort.Rows.Count - 1, True, SheetName:="Sheet3")
            xlApp.AddLookValidationDropDown("D3", "CAPort", "H"c, 1, "H"c, dtPort.Rows.Count, SheetToName:="MainDetails", DataSheetFromName:="Sheet3")
            '--------------- End Port ----------------------

            xlApp.HideSheet("Sheet3", Excel.XlSheetVisibility.xlSheetVeryHidden)
            CloseCustomLoadScreen()
            If xlApp.SaveExcelFile() Then
                MsgBox("Generate template successful.", MsgBoxStyle.Information, GetAppName)
            Else
                MsgBox("Unable to generate template.", MsgBoxStyle.Exclamation, GetAppName)
            End If
            ShowCustomLoadScreen(GetType(MPS4.Waitform))

            xlApp.CloseExcelFile() 'Close the Excel File
        Else
            MsgBox("Invalid excel file.", MsgBoxStyle.Exclamation, GetAppName)
        End If
        CloseCustomLoadScreen()
    End Sub
#End Region
#End Region


#Region "Currency Conversion"
    Function ConvertAmount(ByVal Amount As Double, ByVal FKeyCurrFrom As String, ByVal FKeyCurrTo As String, dtExRate As DataTable, NameOfKeyField As String, NameOfValueField As String) As Double
        Dim ReturnValue As Double = 0
        Dim ExRate As Double = 0
        Dim foundrows() As DataRow

        'VALIDATE PARAMETERS
        If dtExRate Is Nothing Then
            Return 0

        Else
            If dtExRate.Rows.Count = 0 Then
                Return 0
            End If

            If NameOfKeyField = "" Or NameOfValueField = "" Then
                Return 0
            End If

        End If

        'START CONVERTING
        If FKeyCurrFrom = FKeyCurrTo Then                   'If Base Currency and Currency to Convert to are the same
            Return Amount

        Else                                                'If Base Currency and Currency to Convert to are DIFFERENT
            Dim RefCurr As String = GetRefCurrency()        'Get Referential Currency

            If FKeyCurrFrom = RefCurr Or FKeyCurrTo = RefCurr Then      'If Base Currency or Currency to Convert to is the Referential currency
                Select Case RefCurr
                    Case FKeyCurrTo                         'If currency to convert to is the referential amount
                        foundrows = dtExRate.Select(NameOfKeyField & " = '" & FKeyCurrFrom & "'")
                        If foundrows.Count > 0 Then
                            ExRate = foundrows(0).Item(NameOfValueField)
                            Return Amount / ExRate
                        Else
                            Return 0
                        End If

                    Case FKeyCurrFrom                         'If base currency is the referential amount
                        foundrows = dtExRate.Select(NameOfKeyField & " = '" & FKeyCurrTo & "'")
                        If foundrows.Count > 0 Then
                            ExRate = foundrows(0).Item(NameOfValueField)
                            Return Amount * ExRate
                        Else
                            Return 0
                        End If

                    Case Else
                        Return 0
                End Select

            Else                                            'If both currencies are not referential
                Dim ConvertedToRefCurr As Double = ConvertAmount(Amount, FKeyCurrFrom, RefCurr, dtExRate, NameOfKeyField, NameOfValueField)
                Return ConvertAmount(ConvertedToRefCurr, RefCurr, FKeyCurrTo, dtExRate, NameOfKeyField, NameOfValueField)

            End If
        End If


    End Function
#End Region
End Module
