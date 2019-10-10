Imports Microsoft.VisualBasic
Imports DevExpress
Imports System.Drawing
Imports System.IO
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraEditors

Public Module Util
    Public MAIN_CONTENT, CURR_ACT As String 'Added By Calvhin
    Public copiedApt As Appointment = Nothing
    Public SelectedTab As String
    Public MainCrewFormRibbonControl As RibbonControl
    Public ShowShortcutOnRibbon As Boolean = False
    Public HasShortcutIsUpdated As Boolean = False

    Public Enum DocumentExpiryTag
        Expired = 1
        Expiring = 2
        ExpiredAndExpiring = 3
    End Enum

    Public Enum TransferType
        TransferToArchive
        TransferBackToActive
    End Enum

    Public Structure TransferTypeTableValue
        Public Const TransferToArchive = "ARC"
        Public Const TransferBackToActive = "ACT"
    End Structure

#Region "Generic Messages"
    Public Function GetMessage(ByVal _Transact As String, Optional ByVal _Stat As Boolean = True) As String
        Dim str As String = ""
        Select Case UCase(_Transact)
            Case UCase("Saved")
                If _Stat Then
                    str = "Record(s) Saved."
                Else
                    str = "Failed to Saved the Record(s)."
                End If
            Case UCase("Inserted")
                If _Stat Then
                    str = "Record Inserted."
                Else
                    str = "Failed to insert the Record."
                End If
            Case UCase("Updated")
                If _Stat Then
                    str = "Record Updated."
                Else
                    str = "Failed to update the Record."
                End If
            Case UCase("Deleted")
                If _Stat Then
                    str = "Record Deleted."
                Else
                    str = "Unable to delete the selected item: The Item is already in use or a System Data."
                End If
            Case UCase("Sub")
                If _Stat Then
                    'modified by tony20170628
                    'str = "Invalid Record Entry."
                    str = "Invalid Record Entry." & vbNewLine & vbNewLine & "Please complete the required fields and/or correct the fields with incorrect value/s."
                End If
        End Select
        Return str
    End Function


#End Region

#Region "MPS4"

#Region "MPS4 Declarations"
    Public CREWINFO As CrewDetail 'Class of Crew
    Public USER_SESSION As MPSSession ' A class used to store user Session
    Public MPS_LicenseStatus As MyLicenseStatus ' A class used to store License status
    Public autoBulkOpened As Boolean = False
    Public GlobalGridView As XtraGrid.Views.Grid.GridView
    Public selectedID As String 'Get Selected ID
    Public IsHasRec As Boolean = False
    Public Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Public GRID_ROW_SEP As Int16 = 0
    Public SEL_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(200, 247, 200)
    Public MAINFONTFAMILY As String = "Tahoma" 'Font FamilyS
    Public MAINFONTSTYLE As Integer = System.Drawing.FontStyle.Regular 'Font Style {Regular,Bold,Italic}
    Public MAINFONTSIZE As Integer = 8 'Font Style {Regular,Bold,Italic}
    Public GRID_SELFONTCOLOR As System.Drawing.Color = System.Drawing.Color.Black
    Public GRID_ROWFONTCOLOR As System.Drawing.Color = System.Drawing.Color.Black
    Public GRID_EVENODD_VIEW As Boolean = False
    Public GRID_EVENCOLOR As System.Drawing.Color, GRID_EVENFONT As System.Drawing.Color
    Public GRID_ODDCOLOR As System.Drawing.Color, GRID_ODDFONT As System.Drawing.Color
    Public GRID_ROWFONTSIZE As Single
    Public THEME_NAME As String = "Office 2013 White"
    Public MAIN_FONT As System.Drawing.Color = System.Drawing.Color.Black
    Public EDITED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(87, 191, 200)
    Public INVALID_COLOR As System.Drawing.Color = System.Drawing.Color.MistyRose
    Public EDITED_FOCUSED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(144, 219, 200)
    Public DISABLED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(230, 230, 230) 'System.Drawing.Color.FromArgb(235, 236, 239)
    Public DISABLED_SELECTED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(215, 238, 215)
    Public REQUIRED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(253, 249, 234)
    Public REQUIRED_SELECTED_COLOR As System.Drawing.Color = System.Drawing.Color.FromArgb(226, 248, 217)
    Public USER_NAME As String = "ADMIN", USER_ID As Integer = 0, DEFAULT_PASSWORD As String = "12345", USER_PASSWORD As String, USER_NOTIFY As String
    Public LOCATION_ID As String = "SPECT"
    Public DEFAULT_CURRENCY As String = "SYSCUUSD", DEFAULT_CURRENCY_NAME As String = "USD", PAYROLL_PERIOD As Integer, CASH_PERIOD As Integer, INIT_PERIOD As Integer, PAYROLL_IDPrefix As String, PAYROLL_PAYDAY As Integer, CURRENT_PAY As Boolean = True, CURRENT_CASH As Boolean = True, INIT_PAY As Byte
    Public VESSEL_CODE As String, APP_PATH As String, IMO_NUMBER As String, IMP_COUNT As Integer
    Public ReadOnly EXPIMPCHARACTERS As String = "d3]c)Q-I|@%^&*_+=efghij0k:lno(p8qrs`tuv}w{[;'x2yzAB>C9.,<?DbEF!G6$H5J KL#MN/O7PaR""STUVWXYZ~1\m4"
    Public SMTP_SERVER As String, POP_SERVER As String, SMTP_PORT As Integer, POP_PORT As Integer, MAIL_USER_NAME As String, MAIL_PASSWORD As String, MAIL_SPA As Boolean, EMAIL_ADDRESS As String, CONN_TIMEOUT As Integer = 60000, SAS_AUTO_EMAIL As Int16, SM_EMAIL As String
    Public FOLDERDIRECTORY As String = "" 'folder Directory
    Public userPermDt As New DataTable 'neil
    Public IsPlanningChecklistFirstLoad As Boolean = True
    Public HasShowFlaggedColorsInJoiningChecklist As Boolean = True
    Public PlanningChecklistDataSource As New DataTable
    Public TempChecklistDocuments As New DataTable
    Public competenceTemplateDataTable As New DataTable
    Public vesselTypeTemplateDataTable As New DataTable

    Public clsFeature As New clsFeatureMod
    Public COMPANYID As String
    Public FEATUREKEY As String

    Public ENABLE_ADJUST_DEMO_DATES As Boolean = True
#End Region

#Region "Enum Declarations"
    Enum VesselStatus
        Active = 1
        Inactive = 2
    End Enum
#End Region


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetUserName() As String
        'FORMAT: <UserName><LocationID><ComputerName><ModuleCode>
        Return "<" & USER_NAME & "><" & System.Environment.MachineName & "><" & LOCATION_ID & "><" & ModuleCode & ">"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetAppName() As String
        Return "MPS 5"
    End Function


    Public Sub SetMinMaxDateValidation(sender As Object, e As System.EventArgs, dateStartName As String, dateEndName As String)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If (view.FocusedColumn.FieldName.Equals(dateStartName)) Then
            If IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, dateEndName)) Then Return
            Dim maxDate As DateTime = Convert.ToDateTime(view.GetRowCellValue(view.FocusedRowHandle, dateEndName))
            If (maxDate <> DateTime.MinValue) Then
                '<!-- commented out by tony20170918
                '       dateissue should retain as is. Max Date should not be set. 
                '       Otherwise, for example originally date isssue is around 2013 with a validity of 3 years.
                '       What will happen is that the max date for the issue will be set to current date + validity, which means based on the example up to 2016 only. Therefore, no way to update the record if renewed.
                'TryCast(view.ActiveEditor, DateEdit).Properties.MaxValue = maxDate
                '-->
            End If
        ElseIf (view.FocusedColumn.FieldName.Equals(dateEndName)) Then

            If IsDBNull(view.GetRowCellValue(view.FocusedRowHandle, dateStartName)) Then Return

            Dim minDate As DateTime = Convert.ToDateTime(view.GetRowCellValue(view.FocusedRowHandle, dateStartName))
            If (minDate <> DateTime.MinValue) Then
                TryCast(view.ActiveEditor, DateEdit).Properties.MinValue = minDate
            End If
        End If
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetAppPath() As String
        Return APP_PATH
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub SetAppPath(ByVal nPath As String)
        'FOLDERDIRECTORY = nPath & "\Images\CrewDocs\"
        APP_PATH = nPath
    End Sub

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function NumCodeToDate(ByVal mCode As Integer, ByVal cDay As Integer) As Date
        Return DateSerial(mCode \ 100, mCode Mod 100, cDay)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DateCodeToDate(ByVal nDateCode As Long) As Date
        Dim nYear As Integer = nDateCode \ 10000
        Dim nMonth As Integer = (nDateCode Mod 10000) \ 100
        Dim nDay As Integer = (nDateCode Mod 10000) Mod 100
        Return DateSerial(nYear, nMonth, nDay)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DatetoDateCode(ByVal dDate As Date) As Long
        Return CLng(Format(Year(dDate), "0000") & Format(Month(dDate), "00") & Format(Day(dDate), "00"))
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function QCodeToQDesc(ByVal mCode As Integer) As String
        Dim ReturnValue As String = ""
        Select Case mCode Mod 100
            Case 1
                ReturnValue = mCode \ 100 & " 1st Quarter"
            Case 2
                ReturnValue = mCode \ 100 & " 2nd Quarter"
            Case 3
                ReturnValue = mCode \ 100 & " 3rd Quarter"
            Case 4
                ReturnValue = mCode \ 100 & " 4th Quarter"
        End Select

        Return ReturnValue
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DateToNumCode(ByVal nDaTe As Date) As Int32
        Return CType(nDaTe.Year.ToString("0000") & nDaTe.Month.ToString("00"), Int32)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function DateToQCode(ByVal nDaTe As Date) As Int32
        Select Case nDaTe.Month
            Case 1, 2, 3
                Return CType(nDaTe.Year.ToString("0000") & "01", Int32)
            Case 4, 5, 6
                Return CType(nDaTe.Year.ToString("0000") & "02", Int32)
            Case 7, 8, 9
                Return CType(nDaTe.Year.ToString("0000") & "03", Int32)
            Case 10, 11, 12
                Return CType(nDaTe.Year.ToString("0000") & "04", Int32)
            Case Else
                Return 0
        End Select
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function QCodeToDate(ByVal QCode As Int32, ByVal MonthOfQuarter As MonthOfQuarter, ByVal nDay As Integer) As Date

        'Return DateSerial(QCode \ 100, QCode Mod 100, QCode)

        Dim nMonth As Integer = (((QCode Mod 100) - 1) * 3) + MonthOfQuarter

        Return DateSerial(QCode \ 100, nMonth, nDay)

    End Function

    Public Enum MonthOfQuarter
        First = 1
        Second = 2
        Last = 3
    End Enum

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeLongDateStrToDate(ByVal nStrDate As String) As Date
        Dim xYear As Integer, xMonth As Integer, xDay As Integer, xHour As Integer, xMinute As Integer, xSeconds As Integer
        nStrDate = nStrDate.Replace("'", "").Replace(" ", "").Replace("-", "").Replace(":", "")
        xYear = CInt(nStrDate.Substring(0, 4))
        nStrDate = nStrDate.Substring(4, nStrDate.Length - 4)
        xMonth = CInt(nStrDate.Substring(0, 2))
        nStrDate = nStrDate.Substring(2, nStrDate.Length - 2)
        xDay = CInt(nStrDate.Substring(0, 2))
        nStrDate = nStrDate.Substring(2, nStrDate.Length - 2)
        xHour = CInt(nStrDate.Substring(0, 2))
        nStrDate = nStrDate.Substring(2, nStrDate.Length - 2)
        xMinute = CInt(nStrDate.Substring(0, 2))
        nStrDate = nStrDate.Substring(2, nStrDate.Length - 2)
        xSeconds = CInt(nStrDate.Substring(0, 2))
        Return New Date(xYear, xMonth, xDay, xHour, xMinute, xSeconds)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeSQLDateStrToDate(ByVal StrDate As String) As Date
        Dim xYear As Integer, xMonth As Integer, xDay As Integer
        StrDate = StrDate.Replace("'", "").Trim
        xYear = CInt(StrDate.Substring(0, 4))
        StrDate = StrDate.Substring(5, StrDate.Length - 5)
        xMonth = CInt(StrDate.Substring(0, InStr(StrDate, "-") - 1))
        StrDate = StrDate.Substring(InStr(StrDate, "-"), StrDate.Length - InStr(StrDate, "-") - 1)
        If StrDate.Length > 2 Then
            xDay = CInt(StrDate.Substring(0, InStr(StrDate, " ") - 1))
        Else
            xDay = CInt(StrDate)
        End If
        Return DateSerial(xYear, xMonth, xDay)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToSQLDate(ByVal nDate As Date) As String
        Return "'" & nDate.Year.ToString("0000") & "-" & nDate.Month.ToString("00") & "-" & nDate.Day.ToString("00") & " " & nDate.Hour.ToString("00") & ":" & nDate.Minute.ToString("00") & ":" & nDate.Second.ToString("00") & "'"
    End Function

    ''<System.Diagnostics.DebuggerStepThrough()> _
    'Public Function ChangeToSQLDate(ByVal nDate As Object) As String
    '    Try
    '        If IsDate(nDate) Then
    '            Return "'" & CType(nDate, Date).Year.ToString("0000") & "-" & CType(nDate, Date).Month.ToString("00") & "-" & CType(nDate, Date).Day.ToString("00") & " " & CType(nDate, Date).Hour.ToString("00") & ":" & CType(nDate, Date).Minute.ToString("00") & ":" & CType(nDate, Date).Second.ToString("00") & "'"
    '        Else
    '            Return "''"
    '        End If

    '    Catch ex As Exception
    '        Return "''"
    '    End Try
    'End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToSQLDate(ByVal nDate As String) As String
        If nDate.ToString().Equals("") Then
            Return "''"
        Else
            Return "'" & CDate(nDate).Year.ToString("0000") & "-" & CDate(nDate).Month.ToString("00") & "-" & CDate(nDate).Day.ToString("00") & " " & CDate(nDate).Hour.ToString("00") & ":" & CDate(nDate).Minute.ToString("00") & ":" & CDate(nDate).Second.ToString("00") & "'"
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToSQLDate(ByVal nDate As DBNull) As String
        Return "NULL"
    End Function


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToSQLDate(ByVal mCode As Integer, ByVal cDay As Integer) As String
        Return "'" & (mCode \ 100).ToString("0000") & "-" & (mCode Mod 100).ToString("00") & "-" & cDay.ToString("00") & "'"
    End Function

    Public Function ChangeToSQLDate(ByVal nDate As Date, ByVal cTime As DateTime) As String
        Return "'" & nDate.Year.ToString("0000") & "-" & nDate.Month.ToString("00") & "-" & nDate.Day.ToString("00") & " " & cTime.Hour.ToString("00") & ":" & cTime.Minute.ToString("00") & ":" & cTime.Second.ToString("00") & "'"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToDateSerial(ByVal nDate As Date) As String
        Return "DateSerial(" & nDate.Year.ToString("0000") & "," & nDate.Month.ToString("00") & "," & nDate.Day.ToString("00") & ")"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ChangeToDateSerial(ByVal mCode As Integer, ByVal cDay As Integer) As String
        Return "DateSerial(" & (mCode \ 100).ToString("0000") & "," & (mCode Mod 100).ToString("00") & "," & cDay.ToString("00") & ")"
    End Function

    Public Function ChangeToSQLString(ByVal Value As Object, Optional ValueIfNull As Object = "NULL") As String
        If IsNothing(Value) Then
            Return ValueIfNull
        Else
            If IsDBNull(Value) Then
                Return ValueIfNull
            Else
                If Not IfNull(Value, "").Equals("") Then
                    Dim ReturnValue As String = IfNull(Value, "").ToString
                    ReturnValue = ReturnValue.Replace("'", "''")
                    Return "'" & Value & "'"
                Else
                    Return ValueIfNull
                End If
            End If
        End If
    End Function

    Public Function GetDaysOfMonth(ByVal dDate As Date) As Integer
        dDate = DateAdd(DateInterval.Month, 1, dDate)
        Return Day(DateAdd(DateInterval.Day, -1, NumCodeToDate(CType(Year(dDate).ToString("0000") & Month(dDate).ToString("00"), Integer), 1)))
    End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    'Public Function MultiString(ByVal _Number As Integer, ByVal _Char As Char)
    '    Dim RetVal As String = "", cnt
    '    For cnt = 1 To _Number
    '        RetVal = RetVal & _Char
    '    Next
    '    Return RetVal
    'End Function

    Public Function ValidateFields(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView, ByVal strReqFields As String) As Boolean
        Dim xrow As DataRowView, i As Integer, c As Integer
        For i = 0 To view.RowCount - 1
            xrow = view.GetRow(i)
            For c = 0 To view.Columns.Count - 1
                If (xrow.Item(view.Columns(c).Name) Is System.DBNull.Value Or xrow.Item(view.Columns(c).Name) Is Nothing) And InStr(1, strReqFields, ";" & view.Columns(c).Name & ";") > 0 Then
                    MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Public Function ValidateFields(ByVal ctrs() As DevExpress.XtraEditors.BaseEdit, Optional ByVal showMsg As Boolean = True) As Boolean
        Dim ctr As DevExpress.XtraEditors.BaseEdit
        For Each ctr In ctrs
            If ctr.EditValue Is System.DBNull.Value Or IfNull(ctr.EditValue, "").Equals("") Then
                ctr.BackColor = INVALID_COLOR
                If showMsg Then
                    MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                End If
                Return False
            Else
                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If Not CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        ctr.BackColor = INVALID_COLOR
                        If showMsg Then
                            MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                        End If
                        Return False
                    Else
                        ctr.BackColor = REQUIRED_COLOR
                    End If
                ElseIf Not TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then
                    If IsNothing(ctr.EditValue) Then
                        MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical)
                        Return False
                    ElseIf TypeOf (ctr.EditValue) Is String Then
                        If Trim(ctr.EditValue) = "" Then
                            ctr.BackColor = INVALID_COLOR
                            If showMsg Then
                                MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                            End If
                            Return False
                        Else
                            ctr.BackColor = REQUIRED_COLOR
                        End If
                    ElseIf ctr.EditValue = 0 Then
                        ctr.BackColor = INVALID_COLOR
                        If showMsg Then
                            MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical, GetAppName)
                        End If
                        Return False
                    Else
                        ctr.BackColor = REQUIRED_COLOR
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then

                    If TypeOf (ctr.EditValue) Is String Then
                        If Trim(ctr.EditValue) = "" Then
                            MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical)
                            Return False
                        End If
                    ElseIf IsNothing(ctr.EditValue) Then
                        MsgBox("Please fill in all the (*)required fields.", MsgBoxStyle.Critical)
                        Return False
                    End If
                End If
            End If
        Next
        Return True
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Object) As Object
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Date)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As String) As String
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, String)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Integer) As Integer
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Integer)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Boolean) As Boolean
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Boolean)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Date) As Date
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Date)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Double) As Double
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Double)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal rettrue As Integer, ByVal retfalse As Integer) As Double
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return rettrue
        Else
            Return retfalse
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetPeriods() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        Dim cnt As Int32, cmons As Integer
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Period"
        ccolumn.DataType = System.Type.GetType("System.Int32")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PeriodDesc"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        For cnt = Year(Now) + 1 To Year(Now) - 1 Step -1
            For cmons = 12 To 1 Step -1
                Dim crow() As String = {cnt.ToString("0000") & cmons.ToString("00"), DateSerial(cnt, cmons, 1).ToString("MMMM-yyyy")}
                ctable.Rows.Add(crow)
            Next
        Next
        Return ctable
    End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    'Public Function ZipFile(ByVal cSourceFiles() As String, ByVal cDestFile As String) As Boolean
    '    Try
    '        Dim zip As New Chilkat.Zip(), cFile As String
    '        zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
    '        zip.NewZip(cDestFile)
    '        For Each cFile In cSourceFiles
    '            zip.AppendOneFileOrDir(cFile, AcceptRejectRule.Cascade)
    '        Next
    '        Return zip.WriteZipAndClose()
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    'Public Function ZipFile(ByVal cSourceFile As String, ByVal cDestFile As String) As Boolean
    '    Try
    '        Dim zip As New Chilkat.Zip()
    '        zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
    '        zip.NewZip(cDestFile)
    '        zip.AppendOneFileOrDir(cSourceFile, False)
    '        Return zip.WriteZipAndClose()
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    'Public Function ZipFileWithPwd(ByVal cSourceFile As String, ByVal cDestFile As String) As Boolean
    '    Try
    '        Dim zip As New Chilkat.Zip()
    '        zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
    '        zip.PasswordProtect = True
    '        zip.SetPassword("SPCTASZIP_4gpKXqstjEuf")
    '        zip.NewZip(cDestFile)
    '        zip.AppendOneFileOrDir(cSourceFile, False)
    '        Return zip.WriteZipAndClose()
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function ZipFileWithPwdArr(ByVal cSourceFiles As ArrayList, ByVal cDestFile As String) As Boolean
    '    Try
    '        Dim zip As New Chilkat.Zip()
    '        zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
    '        zip.PasswordProtect = True
    '        zip.SetPassword("SPCTASZIP_4gpKXqstjEuf")
    '        zip.NewZip(cDestFile)
    '        For i As Integer = 0 To cSourceFiles.Count - 1
    '            zip.AppendOneFileOrDir(cSourceFiles(i).ToString, False)
    '        Next
    '        Return zip.WriteZipAndClose()
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function


    '<System.Diagnostics.DebuggerStepThrough()> _
    'Public Function UnzipFile(ByVal cSourceFile As String, ByVal cDestFile As String) As Boolean
    '    Try
    '        Dim zip As New Chilkat.Zip
    '        zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
    '        zip.OpenZip(cSourceFile)
    '        zip.Unzip(cDestFile)
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    'Public Function UnzipFile(ByVal cSourceFile As String, ByVal cDestFile As String, ByVal OverwriteExisting As Boolean) As Boolean
    '    Try
    '        Dim zip As New Chilkat.Zip
    '        zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
    '        zip.OverwriteExisting = OverwriteExisting
    '        zip.OpenZip(cSourceFile)
    '        zip.Unzip(cDestFile)
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetTempFolder() As String
        Dim cDir As String = System.IO.Path.GetTempPath & "mps_temp"
        If Not System.IO.Directory.Exists(cDir) Then
            MkDir(cDir)
        End If
        Return cDir & "\"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileNameWithoutExtension(ByVal FullPath As String) As String
        Return System.IO.Path.GetFileNameWithoutExtension(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileNameExtension(ByVal FullPath As String) As String
        Return System.IO.Path.GetExtension(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileName(ByVal FullPath As String) As String
        Return System.IO.Path.GetFileName(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileDir(ByVal FullPath As String) As String
        Return System.IO.Path.GetDirectoryName(FullPath) & "\"
    End Function

    Public Function GetAge(ByVal bday As Date) As Integer
        Return Now.Year - bday.Year - IIf(Now.Month < bday.Month OrElse (Now.Month = bday.Month And Now.Day < bday.Day), 1, 0)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetSortCode(ByVal DB As SQLDB, ByVal _tbl As String, Optional ByVal _condition As String = "") As Double
        Return CType(DB.DLookUp("Max(SortCode)", "dbo." & _tbl, "0", IIf(_condition = "", "", _condition).ToString), Double) + 10
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GenerateID(ByVal DB As SQLDB, ByVal _Key As String, ByVal _table As String) As String
        Dim ValidChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim cnt As Integer, ctemp As String = "", prefix As String = DB.DLookUp("TextValue", "MPS.dbo.tblConfig", "", "CODE='LOCATION_ID'")
        Randomize()
        Do
            For cnt = 1 To 10
                ctemp = ctemp & ValidChars.Substring(Int(ValidChars.Length * Rnd()), 1)
            Next
        Loop While DB.DLookUp(_Key, "dbo." & _table, "", _Key & "='" & prefix & ctemp & "'") <> ""
        Return prefix & ctemp
    End Function

    Public Function GetLastPayID(ByVal DB As SQLDB, ByVal _Key As String) As Integer
        Return CType(DB.DLookUp("MAX(RIGHT(" & _Key & "ID,5))", "dbo.tbl" & _Key, "0", "LEFT(" & _Key & "ID,10)='" & PAYROLL_IDPrefix & "'"), Integer)
    End Function

    'Utility disable all the controls in a certain container.
    'param
    '_container - a control that holds the fields to be disabled.
    Public Sub DisableFields(ByVal _container As System.Windows.Forms.Control)
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In _container.Controls
            ctr.Enabled = False
        Next
    End Sub

    'Utility create an update sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on Update statement.
    '_criteria - the criteria that will be used on Update statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.
    Public Function GenerateUpdateScript(ByVal _container As System.Windows.Forms.Control, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _criteria As String)
        Dim ctr As System.Windows.Forms.Control, retval As String = ""
        For Each ctr In _container.Controls
            '******************Added And ctr.Name <> "txtArticleNo" And ctr.Name <> "txtCompIDNbr" By Calvhin******************
            If ctr.Tag = 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                    If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                    ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                    ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                    End If
                End If
            End If
        Next
        If retval = "" Then
            Return ""
        Else
            Return "Update dbo." & _tbl & " set " & retval.Substring(0, retval.Length - 2) & " Where " & _criteria
        End If

    End Function

    'Utility create an update sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on Update statement.
    '_criteria - the criteria that will be used on Update statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.
    Public Function GenerateUpdateScript(ByVal _container As DevExpress.XtraLayout.LayoutControlGroup, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _criteria As String)
        Dim retval As String = ""
        For o As Integer = 0 To _container.Items.Count - 1
            If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                    Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                    'insert Old Process Here
                    '===================================================
                    '******************Added And ctr.Name <> "txtArticleNo" And ctr.Name <> "txtCompIDNbr" By Calvhin******************
                    If ctr.Tag = 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" Then
                        If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                            If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                            Else
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                            End If
                        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                            ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                            ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                            Else
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                            End If
                        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                            If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                            Else
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                            End If
                        End If
                    End If
                    '===================================================
                End If
            End If
        Next
        If retval = "" Then
            Return ""
        Else
            Return "Update dbo." & _tbl & " set " & retval.Substring(0, retval.Length - 2) & " Where " & _criteria
        End If

    End Function

    Public Function GenerateUpdateScript(ByVal _containers() As DevExpress.XtraLayout.LayoutControlGroup, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _criteria As String)
        Dim retval As String = ""
        For Each _container As DevExpress.XtraLayout.LayoutControlGroup In _containers
            For o As Integer = 0 To _container.Items.Count - 1
                If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'insert Old Process Here
                        '===================================================
                        '******************Added And ctr.Name <> "txtArticleNo" And ctr.Name <> "txtCompIDNbr" By Calvhin******************
                        If ctr.Tag = 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" Then
                            If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                                If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                                End If
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                                ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                                ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                                End If
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                                If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                                End If
                            End If
                        End If
                        '===================================================
                    End If
                End If
            Next
        Next
        If retval = "" Then
            Return ""
        Else
            Return "Update dbo." & _tbl & " set " & retval.Substring(0, retval.Length - 2) & " Where " & _criteria
        End If

    End Function

    'Utility create an update sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on Update statement.
    '_criteria - the criteria that will be used on Update statement.
    '_additionalfield - field you want to add on the insert statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.    
    Public Function GenerateUpdateScript(ByVal _container As System.Windows.Forms.Control, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _criteria As String)
        'OLD CODE
        Dim ctr As System.Windows.Forms.Control, retval As String = ""
        For Each ctr In _container.Controls

            If ctr.Tag = 1 Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                    If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                    End If
                    'inserted by elmer 20150104 for timeedit controls
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TimeEdit Then
                    If CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is Nothing Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date), CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date)) & ", "
                    End If
                    'end elmer
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                    ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                    ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                    End If
                End If
            End If
        Next
        If retval = "" Then
            Return "Update dbo." & _tbl & " set " & _additionalfield & " Where " & _criteria
        Else
            Return "Update dbo." & _tbl & " set " & retval & _additionalfield & " Where " & _criteria
        End If
    End Function

    'Utility create an update sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on Update statement.
    '_criteria - the criteria that will be used on Update statement.
    '_additionalfield - field you want to add on the insert statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.    
    Public Function GenerateUpdateScript(ByVal _container As DevExpress.XtraLayout.LayoutControlGroup, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _criteria As String)
        Dim retval As String = ""

        For o As Integer = 0 To _container.Items.Count - 1
            If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                    Dim ctr As System.Windows.Forms.Control = ycntrl.Control

                    'insert Old Process Here
                    '===================================================
                    '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
                    If ctr.Tag = 1 Then
                        If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                            If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                            Else
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                            End If
                            'inserted by elmer 20150104 for timeedit controls
                        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TimeEdit Then
                            If CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is Nothing Then
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                            Else
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date), CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date)) & ", "
                            End If
                            'end elmer
                        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                            ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                            ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                            Else
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                            End If
                        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                            If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                            Else
                                retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                            End If
                        End If
                    End If
                    '===================================================
                End If
            End If
        Next

        If retval = "" Then
            Return "Update dbo." & _tbl & " set " & _additionalfield & " Where " & _criteria
        Else
            Return "Update dbo." & _tbl & " set " & retval & _additionalfield & " Where " & _criteria
        End If
    End Function

    Public Function GenerateUpdateScript_Recursive(ByVal _container As DevExpress.XtraLayout.LayoutControlGroup, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _criteria As String)
        Dim retval As String = ""
        For o As Integer = 0 To _container.Items.Count - 1
            If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                AssembleUpdateScript(retval, ycntrl, _trimstr, _tbl, _additionalfield, _criteria)
            ElseIf TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlGroup Then
                Dim ycntrlgrp As DevExpress.XtraLayout.LayoutControlGroup = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlGroup)
                AssembleUpdateScript(retval, ycntrlgrp, _trimstr, _tbl, _additionalfield, _criteria)
            End If
        Next

        If retval = "" Then
            Return "Update dbo." & _tbl & " set " & _additionalfield & " Where " & _criteria
        Else
            Return "Update dbo." & _tbl & " set " & retval & _additionalfield & " Where " & _criteria
        End If
    End Function

    Private Sub AssembleUpdateScript(ByRef retval As String, ByVal container As DevExpress.XtraLayout.LayoutControlGroup, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _criteria As String)
        For o As Integer = 0 To container.Items.Count - 1
            If TypeOf (container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                AssembleUpdateScript(retval, TryCast(container.Items(o), DevExpress.XtraLayout.LayoutControlItem), _trimstr, _tbl, _additionalfield, _criteria)
            ElseIf TypeOf (container.Items(o)) Is DevExpress.XtraLayout.LayoutControlGroup Then
                AssembleUpdateScript(retval, TryCast(container.Items(o), DevExpress.XtraLayout.LayoutControlGroup), _trimstr, _tbl, _additionalfield, _criteria)
            End If
        Next
    End Sub

    Private Sub AssembleUpdateScript(ByRef retval As String, ByVal containerItem As DevExpress.XtraLayout.LayoutControlItem, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _criteria As String)
        If TypeOf (containerItem.Control) Is System.Windows.Forms.Control Then
            Dim ctr As System.Windows.Forms.Control = containerItem.Control

            'insert Old Process Here
            '===================================================
            '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
            If ctr.Tag = 1 Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                    If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                    End If
                    'inserted by elmer 20150104 for timeedit controls
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TimeEdit Then
                    If CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is Nothing Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date), CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date)) & ", "
                    End If
                    'end elmer
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                    ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                    ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                    Else
                        retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                    End If
                End If
            End If
            '===================================================
        End If
    End Sub

    Public Function GenerateUpdateScript(ByVal _containers() As DevExpress.XtraLayout.LayoutControlGroup, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _criteria As String)
        Dim retval As String = ""
        For Each _container As DevExpress.XtraLayout.LayoutControlGroup In _containers
            For o As Integer = 0 To _container.Items.Count - 1
                If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'insert Old Process Here
                        '===================================================
                        '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
                        If ctr.Tag = 1 Then
                            If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                                If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                                End If
                                'inserted by elmer 20150104 for timeedit controls
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TimeEdit Then
                                If CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is Nothing Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date), CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date)) & ", "
                                End If
                                'end elmer
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                                ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                                ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                                End If
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                                If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                                End If
                            End If
                        End If
                        '===================================================
                    End If
                End If
            Next
        Next

        If retval = "" Then
            Return "Update dbo." & _tbl & " set " & _additionalfield & " Where " & _criteria
        Else
            Return "Update dbo." & _tbl & " set " & retval & _additionalfield & " Where " & _criteria
        End If
    End Function

    Public Function GenerateUpdateScript(ByVal _containers As List(Of DevExpress.XtraLayout.LayoutControlGroup), ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _criteria As String, Optional ControlExcemptions As String() = Nothing)
        Dim retval As String = ""
        For Each _container As DevExpress.XtraLayout.LayoutControlGroup In _containers
            For o As Integer = 0 To _container.Items.Count - 1
                If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'insert Old Process Here
                        '===================================================
                        '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
                        If Not IsNothing(ControlExcemptions) Then           'added by tony20170418
                            If ControlExcemptions.Contains(ctr.Name) Then ctr.Tag = 0
                        End If
                        If ctr.Tag = 1 Then
                            If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                                If CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue Is Nothing Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                                End If
                                'inserted by elmer 20150104 for timeedit controls
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TimeEdit Then
                                If CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is System.DBNull.Value Or CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue Is Nothing Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & " Null, "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date), CType(CType(ctr, DevExpress.XtraEditors.TimeEdit).EditValue, Date)) & ", "
                                End If
                                'end elmer
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=NULL, "
                                ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                                ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & If(ISUnicode(str), "N", "") & "'" & str & "', "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=" & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                                End If
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                                If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=1, "
                                Else
                                    retval = retval & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "]=0, "
                                End If
                            End If
                        End If
                        '===================================================
                    End If
                End If
            Next
        Next

        If retval = "" Then
            Return "Update dbo." & _tbl & " set " & _additionalfield & " Where " & _criteria
        Else
            Return "Update dbo." & _tbl & " set " & retval & _additionalfield & " Where " & _criteria
        End If
    End Function

    'Utility create an insert sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on insert statement.
    '_additionalfield - field you want to add on the insert statement.
    '_additionalfieldval - value of the field you want to add on the insert statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.
    Public Function GenerateInsertScript(ByVal _container As System.Windows.Forms.Control, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _additionalfieldval As String)
        'old Code
        Dim ctr As System.Windows.Forms.Control, fields As String = "", values As String = ""
        For Each ctr In _container.Controls
            '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
            If ctr.Tag = 1 Then
                If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                    values = values & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                        values = values & "NULL, "
                    ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                        values = values & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                    ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                        values = values & If(ISUnicode(str), "N", "") & "'" & str & "', "
                    Else
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        values = values & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                    End If
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        values = values & "1, "
                    Else
                        fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                        values = values & "0, "
                    End If
                End If
            End If
        Next
        If fields = "" Then
            Return ""
        Else
            Return "Insert Into dbo." & _tbl & "(" & _additionalfield & ", " & fields.Substring(0, fields.Length - 2) & ") values(" & _additionalfieldval & ", " & values.Substring(0, values.Length - 2) & ")"
        End If
    End Function

    'Utility create an insert sql statement from a certain contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on insert statement.
    '_additionalfield - field you want to add on the insert statement.
    '_additionalfieldval - value of the field you want to add on the insert statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.
    Public Function GenerateInsertScript(ByVal _container As DevExpress.XtraLayout.LayoutControlGroup, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _additionalfieldval As String)
        Dim fields As String = "", values As String = ""

        For o As Integer = 0 To _container.Items.Count - 1
            If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                    Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                    'insert Old Process Here
                    '===================================================
                    '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
                    If ctr.Tag = 1 Then
                        If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                            fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                            values = values & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                                values = values & "NULL, "
                            ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                values = values & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                            ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                values = values & If(ISUnicode(str), "N", "") & "'" & str & "', "
                            Else
                                fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                values = values & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                            End If
                        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                            If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                                fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                values = values & "1, "
                            Else
                                fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                values = values & "0, "
                            End If
                        End If
                    End If
                    '===================================================
                End If
            End If
        Next
        If fields = "" Then
            Return ""
        Else
            Return "Insert Into dbo." & _tbl & "(" & _additionalfield & ", " & fields.Substring(0, fields.Length - 2) & ") values(" & _additionalfieldval & ", " & values.Substring(0, values.Length - 2) & ")"
        End If

    End Function

    Public Function GenerateInsertScript(ByVal _containers As List(Of DevExpress.XtraLayout.LayoutControlGroup), ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _additionalfieldval As String, Optional ControlExcemptions As String() = Nothing)
        Dim fields As String = "", values As String = ""

        For Each _container As DevExpress.XtraLayout.LayoutControlGroup In _containers
            For o As Integer = 0 To _container.Items.Count - 1
                If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'insert Old Process Here
                        '===================================================
                        '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
                        If Not IsNothing(ControlExcemptions) Then           'added by tony20170418
                            If ControlExcemptions.Contains(ctr.Name) Then ctr.Tag = 0
                        End If
                        If ctr.Tag = 1 Then
                            If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                                fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                values = values & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                                    values = values & "NULL, "
                                ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                    values = values & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                                ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                    values = values & If(ISUnicode(str), "N", "") & "'" & str & "', "
                                Else
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    values = values & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                                End If
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                                If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    values = values & "1, "
                                Else
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    values = values & "0, "
                                End If
                            End If
                        End If
                        '===================================================
                    End If
                End If
            Next
        Next
        If fields = "" Then
            Return ""
        Else
            Return "Insert Into dbo." & _tbl & "(" & _additionalfield & ", " & fields.Substring(0, fields.Length - 2) & ") values(" & _additionalfieldval & ", " & values.Substring(0, values.Length - 2) & ")"
        End If

    End Function


    'Utility create an insert sql statement from Two or more contnainer
    '_container - source of the controls, all of the controls that has an AddListener will be added.
    '_trimstr number of prefix to be removed on controls name. e.t.c txtLName the _trimstr will be set to 3 it will remove txt the leaves LName on the fields.
    '_tbl - the table name that will be used on insert statement.
    '_additionalfield - field you want to add on the insert statement.
    '_additionalfieldval - value of the field you want to add on the insert statement.

    'Additional notes
    'If you intend to used this function make sure you properly set the control's name similar on the datasource. e.t.c data source LName you the name would be txtLName, cboLName, chkLName e.t.c and set the _trimstr to the number of prefix.
    'If you're using DevExpress's TextEdit make sure you set the Masking property. This adds validation to the user's input also set what's the proper data type for the control. If this is unset to program will use the default data type which is string.
    Public Function GenerateInsertScript(ByVal _containers() As DevExpress.XtraLayout.LayoutControlGroup, ByVal _trimstr As Integer, ByVal _tbl As String, ByVal _additionalfield As String, ByVal _additionalfieldval As String)
        Dim fields As String = "", values As String = ""

        For Each _container As DevExpress.XtraLayout.LayoutControlGroup In _containers
            For o As Integer = 0 To _container.Items.Count - 1
                If TypeOf (_container.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(_container.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    If TypeOf (ycntrl.Control) Is System.Windows.Forms.Control Then
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'insert Old Process Here
                        '===================================================
                        '******************Added And ctr.Name <> "txtArticleNo" By Calvhin****************** 1 And ctr.Name <> "txtArticleNo" And ctr.Name <> "chkMedOff" And ctr.Name <> "txtTransTime" 
                        If ctr.Tag = 1 Then
                            If TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                                fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                values = values & ChangeToSQLDate(CType(CType(ctr, DevExpress.XtraEditors.DateEdit).EditValue, Date)) & ", "
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                If HasNoData(CType(ctr, DevExpress.XtraEditors.TextEdit)) Then
                                    values = values & "NULL, "
                                ElseIf CType(ctr, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                    values = values & "'" & sysMpsUserPassword("ENCRYPT", str) & "', "
                                ElseIf TypeOf (CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    Dim str As String = CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                    values = values & If(ISUnicode(str), "N", "") & "'" & str & "', "
                                Else
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    values = values & CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue & ", "
                                End If
                            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                                If CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked Then
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    values = values & "1, "
                                Else
                                    fields = fields & "[" & ctr.Name.Substring(_trimstr, ctr.Name.Length - _trimstr) & "], "
                                    values = values & "0, "
                                End If
                            End If
                        End If
                        '===================================================
                    End If
                End If
            Next
        Next

        If fields = "" Then
            Return ""
        Else
            Return "Insert Into dbo." & _tbl & "(" & _additionalfield & ", " & fields.Substring(0, fields.Length - 2) & ") values(" & _additionalfieldval & ", " & values.Substring(0, values.Length - 2) & ")"
        End If

    End Function

    Public Function FormatVersion(ByVal bToString As Boolean, ByVal value As Object) As Object
        If bToString Then
            Dim prefix As Integer = CType(value, Integer)
            Return prefix.ToString("00") & "-" & ((CType(value, Double) - prefix) * 100).ToString("00")
        Else
            Return CType(value.ToString.Substring(0, 2), Double) + (CType(value.ToString.Substring(3, 2), Double) / 100)
        End If
        Return 0
    End Function

    'A simple encryption functions that just shuffle the characters to prevents the increase of file size.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function Shuffle(ByVal str As String, ByVal bExp As Boolean) As String
        Dim OrigString As String = EXPIMPCHARACTERS.Substring(0, 90), NewString As New System.Text.StringBuilder, nSlice As Integer, cnt As Integer
        Dim RetvalBuilder As New System.Text.StringBuilder, RetVal As String
        Dim any_int_val As Int16
        If bExp Then
            Randomize()
            any_int_val = CType(1 + Int(Rnd() * 9), Integer)
            nSlice = CType(2 + Int(Rnd() * 5), Integer)
            If nSlice = 4 Then nSlice = 9 '90 is not divisible by 4
            RetvalBuilder.Append(String.Format("{0}{1}", EXPIMPCHARACTERS.Substring(any_int_val, 1), EXPIMPCHARACTERS.Substring(nSlice, 1)))
            While OrigString.Length > 0
                NewString.Append(StrReverse(OrigString.Substring(0, nSlice)))
                OrigString = OrigString.Remove(0, nSlice)
            End While
            NewString.Append(EXPIMPCHARACTERS.Substring(90, 5))
            OrigString = EXPIMPCHARACTERS
            For cnt = 0 To str.Length - 1
                Dim nPos As Integer = -1
                nPos = OrigString.IndexOf(str.Substring(cnt, 1))
                If nPos >= 0 Then
                    RetvalBuilder.Append(NewString.Chars(nPos))
                Else
                    RetvalBuilder.Append(str.Substring(cnt, 1))
                End If
            Next
            RetvalBuilder.Append(10 - any_int_val)
            RetVal = StrReverse(RetvalBuilder.ToString)
        Else
            str = StrReverse(str)
            nSlice = CType(EXPIMPCHARACTERS.IndexOf(str.Substring(1, 1)), Integer)
            str = str.Substring(2, str.Length - 3)
            While OrigString.Length > 0
                NewString.Append(StrReverse(OrigString.Substring(0, nSlice)))
                OrigString = OrigString.Remove(0, nSlice)
            End While
            NewString.Append(EXPIMPCHARACTERS.Substring(90, 5))
            OrigString = EXPIMPCHARACTERS
            For cnt = 0 To str.Length - 1
                Dim nPos As Integer = -1
                nPos = NewString.ToString.IndexOf(str.Substring(cnt, 1))
                If nPos >= 0 Then
                    RetvalBuilder.Append(OrigString.Chars(nPos))
                Else
                    RetvalBuilder.Append(str.Substring(cnt, 1))
                End If
            Next
            RetVal = RetvalBuilder.ToString
        End If
        Return RetVal
    End Function


    Public Function ISUnicode(ByVal str As String) As Boolean
        Dim c As Integer
        For c = 0 To str.Length - 1
            If AscW(str.Chars(c)) > 255 Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub LogErrors(ByVal ErrMsg As String)
        Dim strFileName As String
        If Not System.IO.Directory.Exists(GetAppPath() & "\Errors") Then
            MkDir(GetAppPath() & "\Errors")
        End If
        strFileName = GetAppPath() & "\Errors" & "\Error_" & Now.ToString("yyyyMMdd") & ".txt"
        Using sw As New System.IO.StreamWriter(strFileName, True)
            Dim cMAIN_CONTENT As String = ""
            If MAIN_CONTENT Is Nothing Then
                cMAIN_CONTENT = "<MainContent:n/a>"
            Else
                cMAIN_CONTENT = MAIN_CONTENT.ToUpper
            End If

            'edited by tony20170328
            'sw.WriteLine(vbNewLine & Date.Now.ToString("hh:mm:ss") & vbTab & " | " & MAIN_CONTENT.ToUpper & " | " & ErrMsg)
            sw.WriteLine(vbNewLine & Date.Now.ToString("hh:mm:ss") & vbTab & " | " & cMAIN_CONTENT & " | " & ErrMsg)
        End Using
    End Sub

    Public Sub LogEvent(ByVal EventMsg As String)
        Dim strFileName As String
        If Not System.IO.Directory.Exists(GetAppPath() & "\Event_Log") Then
            MkDir(GetAppPath() & "\Event_Log")
        End If
        strFileName = GetAppPath() & "\Event_Log" & "\Event_Log_" & Now.ToString("yyyyMMdd") & ".txt"
        Using sw As New System.IO.StreamWriter(strFileName, True)
            Dim cMAIN_CONTENT As String = ""
            If MAIN_CONTENT Is Nothing Then
                cMAIN_CONTENT = "<MainContent:n/a>"
            Else
                cMAIN_CONTENT = MAIN_CONTENT.ToUpper
            End If

            sw.WriteLine(vbNewLine & Date.Now.ToString("hh:mm:ss") & vbTab & " | " & cMAIN_CONTENT & " | " & EventMsg)
        End Using
    End Sub

    'Public Function SendEmail(ByVal recepient As String, ByVal subject As String, ByVal body As String, ByVal attachment As String) As Boolean
    '    Try
    '        Dim smtp As New Chilkat.MailMan, email As New Chilkat.Email
    '        smtp.UnlockComponent("spctasmailq_8962dbbgnc9s")
    '        smtp.SmtpHost = SMTP_SERVER
    '        smtp.SmtpPort = SMTP_PORT
    '        smtp.ReadTimeout = CONN_TIMEOUT
    '        smtp.SmtpUsername = MAIL_USER_NAME
    '        smtp.SmtpPassword = sysMpsUserPassword("DECRYPT", MAIL_PASSWORD)
    '        smtp.ConnectTimeout = CONN_TIMEOUT
    '        email.AddTo(recepient, recepient)
    '        email.From = EMAIL_ADDRESS
    '        email.Subject = subject
    '        email.Body = body
    '        email.AddFileAttachment(attachment)
    '        Dim flag As Boolean = smtp.SendEmail(email)
    '        smtp.CloseSmtpConnection()
    '        Return flag
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Return MaxSlots and FreeSlots based on current MPS License
    Public Function oGenerateUserSlots(ByVal DB As SQLDB) As MPSUserSlots
        Dim cErr As String = ""
        Dim oReturnslots As New MPSUserSlots
        oReturnslots.MaxSlots = 0
        oReturnslots.FreeSlots = 0
        oReturnslots.ErrMsg = "Invalid."
        Try
            '<---- added by tony20170930
            Dim isInDebugMode As Boolean = False
            Try
                isInDebugMode = System.Diagnostics.Debugger.IsAttached
            Catch ex As Exception
                isInDebugMode = False
            End Try

            If isInDebugMode Then
                oReturnslots.MaxSlots = 20
                oReturnslots.ErrMsg = ""
                GoTo SKIPPED_LICENSE_CHECK
            End If
            '-->

            If MPS_LicenseStatus.LicenseType = "MPSLICENSE" And MPS_LicenseStatus.StrLicenseMsg = "" Then
                Try
                    oReturnslots.MaxSlots = CInt(MPS_LicenseStatus.NoOfUsers)
                Catch ex As Exception
                    oReturnslots.MaxSlots = 0
                    oReturnslots.ErrMsg = "Invalid value (No. of allowed users)"
                End Try

            ElseIf MPS_LicenseStatus.LicenseType = "TRIAL" And MPS_LicenseStatus.StrLicenseMsg = "" Then
                oReturnslots.MaxSlots = 20
            Else
                oReturnslots.ErrMsg = "Invalid. Please check MPS license."
            End If

SKIPPED_LICENSE_CHECK:
            'Get Free Users
            If oReturnslots.MaxSlots > 0 Then
                Dim nUsersActive As Integer = 0

                'get active users (5 mins)
                'Dim dtUsersLogin As DataTable = DB.CreateTable("SELECT FKeyUserID FROM MSysSec_Users_Log WHERE (NOT (UserToken IS NULL)) AND (NOT (LastCheck IS NULL)) AND (NOT (CompName IS NULL)) AND (LastCheck > DATEADD(minute, - " & DB.DLookUp("TextValue", "tblConfig", "", "CODE = 'REFRESH_RATE'") & " , GETDATE())) GROUP BY FKeyUserID")

                'no mins checking
                Dim dtUsersLogin As DataTable = DB.CreateTable("SELECT FKeyUserID FROM MSysSec_Users_Log WHERE (NOT (UserToken IS NULL)) AND (NOT (LastCheck IS NULL)) AND (NOT (CompName IS NULL)) GROUP BY FKeyUserID")
                nUsersActive = dtUsersLogin.Rows.Count

                If oReturnslots.MaxSlots >= nUsersActive Then
                    'set Free Slots
                    oReturnslots.FreeSlots = oReturnslots.MaxSlots - nUsersActive
                    oReturnslots.ErrMsg = Nothing
                Else
                    oReturnslots.FreeSlots = 0
                    oReturnslots.ErrMsg = "The connection pool has reached the maximum number of users." & _
                        vbNewLine & vbNewLine & "Max Users: " & oReturnslots.MaxSlots.ToString
                End If
            End If

        Catch ex As Exception
            oReturnslots.MaxSlots = 0
            oReturnslots.FreeSlots = 0
            oReturnslots.ErrMsg = "An error occured generating user session."
        End Try
        Return oReturnslots
    End Function

    'check the user session.
    'if valid: will update the user session
    'else: mps will restart
    Public Sub CheckUserSession(ByVal oDB As SQLDB, ByVal oUSer_Session As MPSSession)
        Exit Sub
        'Dim bSuccess As Boolean = False
        If oUSer_Session.IsUserLoggedIn(oDB) Then
            Call oUSer_Session.UpdateSession(oDB)
        Else
            Dim f As Windows.Forms.Form
            f = New Windows.Forms.Form
            f.BackColor = Color.Black
            f.WindowState = Windows.Forms.FormWindowState.Maximized
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            f.Opacity = 0.6
            f.ShowIcon = False
            f.ShowInTaskbar = False
            f.Show()
            If Windows.Forms.MessageBox.Show("Due to inactivity. Your session has been closed." & vbNewLine & vbNewLine & "Restart MPS?", "Session Expired", Windows.Forms.MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = MsgBoxResult.Yes Then
                Call USER_SESSION.Dispose(oDB)
                f.Close()
                f.Dispose()
                Windows.Forms.Application.Restart()
            Else
                Call USER_SESSION.Dispose(oDB)
                f.Close()
                f.Dispose()
            End If
            Process.GetCurrentProcess.Kill()
        End If
    End Sub

#End Region

#Region "DMS"
    'Added By Calvhin

    'Check if file exist in the DMS folder or not
    'Returns True if File Exist
    Public Function checkIfExist(ByVal filename As String) As Boolean
        Dim res As Boolean = False
        Dim files() As String
        Try
            files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & filename.Split("_").GetValue(0).ToString)
            For i As Integer = 0 To files.Length - 1
                'If files(i).Contains(filename) Then
                If files(i) = filename & System.IO.Path.GetExtension(files(i)) Then
                    res = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            res = False
        End Try
        Return res
    End Function

    'Sets the Default folder Directory Set in the Admin
    Public Function getDocFolder(ByVal db As SQLDB) As String
        FOLDERDIRECTORY = IfNull(db.GetConfig("DefaultFolder"), "")
        Return FOLDERDIRECTORY
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetCrewDocsPath() As String
        Return FOLDERDIRECTORY
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetDefaultImagesPath() As String
        Return FOLDERDIRECTORY
    End Function

    ' <System.Diagnostics.DebuggerStepThrough()> _

    Public Function GenerateCrewFilePath(ByVal fileName As String, Optional ByVal idnbr As String = "") As String
        Dim files() As String
        Dim res As String = ""
        Try
            '<!-- edited by tony20170928
            'If idnbr = "" Then files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & fileName.Split("_").GetValue(0).ToString) Else files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & idnbr)

            Dim cPath As String
            If idnbr = "" Then cPath = GetCrewDocsPath() & "\" & fileName.Split("_").GetValue(0).ToString Else cPath = GetCrewDocsPath() & "\" & idnbr

            If System.IO.Directory.Exists(cPath) Then
                files = System.IO.Directory.GetFiles(cPath)

                For i As Integer = 0 To files.Count - 1
                    'If System.IO.Path.GetFileName(files(i)).Contains(fileName) Then
                    If System.IO.Path.GetFileName(files(i)) = fileName & System.IO.Path.GetExtension(files(i)) Then
                        res = files(i)
                        Exit For
                    End If
                Next
            End If
            '-->

        Catch ex As System.IO.DirectoryNotFoundException
            res = ""
        End Try
        Return res 'APP_PATH & "\Images\CrewDocs\" & fileName
    End Function
    Public Function GenerateCrewFilePathDocument(ByVal strID As String, ByVal fileName As String) As String
        'Dim files() As String
        Dim res As String = ""
        Dim ImagePath As String = ""
        Try
            'files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & fileName.Split("_").GetValue(0).ToString)
            'For i As Integer = 0 To files.Count - 1
            '    If System.IO.Path.GetFileName(files(i)).Contains(fileName) Then
            '        res = files(i)
            '        Exit For
            '    End If
            'Next
            'If System.IO.Path.GetExtension(GetCrewDocsPath() & "\" & fileName) Then
            'res = GetCrewDocsPath() & "\" & strID & "\" & fileName & "." & System.IO.Path.GetExtension(GetCrewDocsPath() & "\" & strID & "\" & fileName)
            'res = GetCrewDocsPath() & "\" & strID & "\" & fileName & ".pdf"
            ImagePath = GetCrewDocsPath() & "\" & strID & "\" & fileName
            Select Case System.IO.Path.GetExtension(ImagePath)
                Case ""
                    res = GetCrewDocsPath() & "\" & strID & "\" & fileName & ".pdf"
                Case Else
                    res = GetCrewDocsPath() & "\" & strID & "\" & fileName & System.IO.Path.GetExtension(ImagePath)
            End Select
            'End If

        Catch ex As System.IO.DirectoryNotFoundException
            res = ""
        End Try
        Return res 'APP_PATH & "\Images\CrewDocs\" & fileName
    End Function

    '<System.Diagnostics.DebuggerStepThrough()> _
    Public Function CopyCrewDoc(ByVal srcFilePath As String, ByVal compID As String, ByVal DocType As String, ByVal issueDate As String) As String
        Dim strDir As String = ""
        Dim fileName As String = ""
        Dim fileExt As String = ""
        Try
            strDir = FOLDERDIRECTORY & "\" & compID & "\"
            fileExt = System.IO.Path.GetExtension(srcFilePath)
            fileName = compID & "_" & DocType & "_" & issueDate & fileExt

            If (Not System.IO.Directory.Exists(strDir)) Then
                System.IO.Directory.CreateDirectory(strDir)
            End If

            My.Computer.FileSystem.CopyFile(srcFilePath, strDir & fileName, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

        Catch ex As Exception
            'MsgBox("insert error message here:" & ex.Message, , GetAppName)
            MsgBox(ex.Message, , GetAppName)

        End Try
        Return fileName
    End Function

    Public Function CopyCrewImage(_filePath As String, _IDNbr As String) As String
        Dim strDir As String = ""
        Dim fileName As String = ""
        Dim fileExt As String = ""
        Try
            strDir = FOLDERDIRECTORY & "\" & _IDNbr & "\"
            fileExt = System.IO.Path.GetExtension(_filePath)
            fileName = _IDNbr & "_IMAGE" & fileExt
            If (Not System.IO.Directory.Exists(strDir)) Then
                System.IO.Directory.CreateDirectory(strDir)
            End If
            'My.Computer.FileSystem.CopyFile(_filePath, strDir & fileName, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
            My.Computer.FileSystem.CopyFile(_filePath, strDir & fileName, True)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, GetAppName)
        End Try
        Return fileName
        'Return strDir & fileName

    End Function

    Public Sub ReplaceCrewImage(_SourceFilePath As String, _fileName As String)
        Dim files() As String
        Dim res As String = ""
        Try
            files = System.IO.Directory.GetFiles(GetCrewDocsPath() & _fileName.Split("_").GetValue(0).ToString)
            For i As Integer = 0 To files.Count - 1
                'If files(i).Contains(_fileName) Then
                If files(i) = _fileName & System.IO.Path.GetExtension(files(i)) Then
                    Kill(files(i))
                    CopyCrewDoc(files(0), "", "", "")
                    Exit Sub
                End If
            Next
        Catch ex As System.IO.DirectoryNotFoundException
            res = ""
        End Try

    End Sub

    Public Sub replaceCrewDoc(ByVal fileName As String, ByVal compID As String, ByVal DocType As String, ByVal issueDate As String)
        Dim files() As String
        Dim res As String = ""
        Try
            files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & fileName.Split("_").GetValue(0).ToString)
            For i As Integer = 0 To files.Count - 1
                'If files(i).Contains(fileName) Then
                If files(i) = fileName & System.IO.Path.GetExtension(files(i)) Then
                    Kill(files(i))
                    CopyCrewDoc(files(0), "", "", "")
                    Exit Sub
                End If
            Next
        Catch ex As System.IO.DirectoryNotFoundException
            res = ""
        End Try
    End Sub

    Public Function replaceCrewDoc(ByVal sourcefile As String, ByVal fileName As String) As String
        Dim files() As String
        Dim res As String = ""
        Dim returnName As String = ""
        Try
            files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & fileName.Split("_").GetValue(0).ToString)
            For i As Integer = 0 To files.Count - 1
                'If Left(files(i), Len(files(i)) - 4).Contains(fileName) Then
                'If Left(files(i), Len(files(i)) - 4) = fileName Then
                If files(i) = fileName & System.IO.Path.GetExtension(files(i)) Then
                    Kill(files(i))
                    returnName = CopyCrewDoc(sourcefile, fileName.Split("_").GetValue(0).ToString, fileName.Split("_").GetValue(1).ToString, fileName.Split("_").GetValue(2).ToString)
                    Return returnName
                    Exit Function
                End If
            Next
        Catch ex As System.IO.DirectoryNotFoundException
            res = ""
        End Try
        Return returnName
    End Function

    Public Function ImageFromStream(ByVal filepath As String)
        Dim img As Image = Nothing
        Try
            Using Str As Stream = File.OpenRead(filepath)
                img = Image.FromStream(Str)
            End Using
        Catch ex As Exception
            If File.Exists(GetDefaultImagesPath() & "DefaultImage.png") Then
                img = Image.FromFile(GetDefaultImagesPath() & "DefaultImage.png")
            End If
        End Try
        Return img
    End Function

#End Region

#Region "String-related Functions"
    Public Function ConcatWithSpaces(ByVal arrStrList() As Object)
        Dim cRetval As String = ""
        Dim cTemp As String
        For i As Integer = 0 To arrStrList.GetUpperBound(0)
            If Not arrStrList(i) Is Nothing Then
                cTemp = arrStrList(i).ToString & " "
                cRetval = cRetval & Trim(cTemp)
            End If
        Next

        Return cRetval
    End Function

    Public Function AssembleName(LName As String, FName As String, Optional MName As String = "", Optional MiddleInitialOnly As Boolean = True, Optional LNameFirst As Boolean = True, Optional CapitalizeInitials As Boolean = True, Optional AllUpperCase As Boolean = False, Optional AllLowerCase As Boolean = False) As String
        'created by tony20170522
        Dim ReturnValue As String = ""
        Dim tempLName As String = IfNull(LName, "")
        Dim tempFName As String = IfNull(FName, "")
        Dim tempMName As String = IfNull(MName, "")

        If tempMName.Length > 0 And MiddleInitialOnly Then
            tempMName = Left(tempMName, 1) & "."
        End If

        'fixed by tony20180427
        'If LNameFirst Then
        '    ReturnValue = tempFName
        '    ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " ", "") & tempMName
        '    ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " ", "") & tempLName

        'Else
        '    ReturnValue = tempLName & IIf(tempLName.Length > 0, ", ", "")
        '    ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " ", "") & tempFName
        '    ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " ", "") & tempMName
        'End If
        If LNameFirst Then
            ReturnValue = tempLName & IIf(tempLName.Length > 0, ", ", "")
            ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " ", "") & tempFName
            ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " ", "") & tempMName

        Else

            ReturnValue = tempFName
            ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " ", "") & tempMName
            ReturnValue = ReturnValue & IIf(ReturnValue.Length > 0, " ", "") & tempLName

        End If
        'end tony

        If CapitalizeInitials Then
            Dim tempValue As String = ""
            Dim prevStr As String = ""

            For i As Integer = 1 To ReturnValue.Length

                If i > 1 Then
                    prevStr = Mid(ReturnValue, i - 1, 1)
                End If

                tempValue = tempValue & IIf(i = 1 Or prevStr = " ", Mid(ReturnValue, i, 1).ToUpper, Mid(ReturnValue, i, 1))
            Next

            ReturnValue = tempValue

        ElseIf AllUpperCase Then
            ReturnValue = ReturnValue.ToUpper

        ElseIf AllLowerCase Then
            ReturnValue = ReturnValue.ToLower
        End If
        Return ReturnValue
    End Function

    Public Function ToTitleCase(cString As String) As String
        Dim ReturnValue As String = ""

        Try
            Dim nCtr As Integer
            If Len(cString) = 0 Then
                ReturnValue = ""
            Else
                cString = UCase$(Left(Trim$(cString), 1)) & Right(cString, Len(cString) - 1)
                nCtr = 2
                ReturnValue = UCase$(Left(Trim$(cString), 1))
                Do While nCtr <= Len(cString)
                    ReturnValue = ReturnValue & IIf(Mid$(cString, nCtr - 1, 1) = " ", UCase$(Mid$(cString, nCtr, 1)), LCase$(Mid$(cString, nCtr, 1)))
                    nCtr = nCtr + 1
                Loop

            End If

        Catch ex As Exception
            ReturnValue = cString
        End Try

        Return ReturnValue

    End Function


#Region "Custom Dialog-Related"
    Public Function SaveAsDialog(Optional DefaultFileName As String = "", Optional Filter As String = "All Files|*.*", Optional Title As String = "Select file location") As String
        Dim returnvalue As String = ""
        Dim saveDialog As New System.Windows.Forms.SaveFileDialog()
        'saveDialog.Filter = "Excel Workbook (*.xls)|*.xls"
        saveDialog.Filter = Filter
        saveDialog.Title = Title
        If Not IfNull(DefaultFileName, "").Equals("") Then saveDialog.FileName = DefaultFileName
        If saveDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If Not saveDialog.FileName.Trim().Equals("") Then
                returnvalue = saveDialog.FileName
            End If
        End If

        Return returnvalue
    End Function
#End Region

#End Region

    Public Sub ExecMyFunction()

    End Sub

    Function HasNoData(textEdit As DevExpress.XtraEditors.TextEdit) As Boolean
        If textEdit.EditValue Is Nothing Then
            HasNoData = True
        Else
            HasNoData = False
        End If
    End Function

#Region "Date related Funtions"
    Public Function getLOC(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal retType As String) As Integer
        Dim res As Integer
        Select Case retType
            Case "D"
                Dim nFBaseDays, nTBaseDays As Integer
                nFBaseDays = Date.DaysInMonth(dateTo.Year, DateAdd(DateInterval.Month, -1, dateTo).Month)
                nTBaseDays = Date.DaysInMonth(dateTo.Year, dateTo.Month)
                If dateFrom.Day > dateTo.Day Then
                    Dim nCnt As Integer = nFBaseDays - dateFrom.Day
                    res = nCnt + dateTo.Day
                ElseIf dateFrom.Day < dateTo.Day Then
                    res = dateTo.Day - dateFrom.Day
                Else
                    res = 0
                End If
            Case "M"
                If Month(dateFrom) <> Month(dateTo) Then
                    res = DateDiff(DateInterval.Month, dateFrom, dateTo)
                Else
                    res = 0
                End If

                If (dateFrom.Day) > (dateTo.Day) Then res = Val(res) - 1
        End Select
        Return res
    End Function

    Public oTimeElapsed As New TimeElapsed
    Public Class TimeElapsed
        Dim start_time As DateTime
        Dim stop_time As DateTime
        Dim elapsed_time As TimeSpan
        Public TimeElapsed As String

        Public Sub New()
            start_time = Nothing
            stop_time = Nothing
        End Sub

        Public Sub _Start()
            start_time = Date.Now
        End Sub

        Public Sub _Stop(Optional ShowTimeElapsedInMsgbox As Boolean = False)
            stop_time = Now
            ComputeElapsedTime()

            If ShowTimeElapsedInMsgbox Then MsgBox("Time Elapsed: " & TimeElapsed)
        End Sub

        Public Function GetTimeElapsed(Optional cLabel As String = "") As String
            Return IIf(cLabel.Length > 0, cLabel & ": ", "Time Elapsed: ") & TimeElapsed
        End Function

        Private Sub ComputeElapsedTime()
            If Not IsNothing(start_time) And Not IsNothing(stop_time) Then
                elapsed_time = stop_time.Subtract(start_time)
                TimeElapsed = (elapsed_time.TotalSeconds.ToString("0.000000")).ToString
            Else
                TimeElapsed = "not available"
            End If

        End Sub
    End Class
#End Region

#Region "Reports and KPI"
    Public Class DateRangeClass
        'Public Fields As New DateRangeFields
        Public Values As New DateRangeValues
        Public Period As New DateRangePeriod
    End Class

    'Public Class DateRangeFields
    '    Public _From As String = ""
    '    Public _To As String = ""
    'End Class

    Public Class DateRangeValues
        Public _From As Date = Nothing
        Public _To As Date = Nothing
    End Class

    Public Class DateRangePeriod
        Public _From As Integer = 0
        Public _To As Integer = 0
    End Class

    Public Class AutoEmailClass
        Public Enabled As Boolean = False
        Public DateRange As New DateRangeClass
        Public Condition As String = ""
        Public ConditionTitle As String = ""

    End Class
#End Region

#Region "ItemDelimited"

    'RETURNS: <nItemNo> value item in <cPairedList> being delimited by <cPairSet>
    '   example:
    '                             "[]"  <--- <cPairSet>
    '       "[item1][item2]...[itemN]"   <--- <cPairedList>
    '
    '
    '       ** setting <nItemNo> parameter to 2 will make the function return the text "item2"
    '
    Public Function usrGetPairedValue(ByVal cPairedList As String, ByVal cPairSet As String, ByVal nItemNo As Integer) As String
        Dim cDelimiter As String, nItemCnt As Integer
        Dim cRetVal As String

        If Len(cPairSet) <> 2 Then
            'Msgbox("<cPairSet> parameter must be 2 characters in length. This will denote the starting and ending delimiter for each item in <cPairedList> parameter.", vbCritical, "usrGetPairedValue()")
            Return ""
            Exit Function
        End If

        cDelimiter = Right$(cPairSet, 1) & Left$(cPairSet, 1) 'reverse pair set
        nItemCnt = CountItemDelimited(cPairedList, cDelimiter)
        cRetVal = GetItemDelimited(cPairedList, nItemNo, cDelimiter)

        If nItemNo = 1 Then
            cRetVal = Mid$(cRetVal, 2, IIf(nItemCnt = 1, Len(cRetVal) - 2, Len(cRetVal) - 1))
        ElseIf nItemNo = nItemCnt Then
            If Len(cRetVal) > 0 Then
                cRetVal = Left$(cRetVal, Len(cRetVal) - 1)
            Else
                cRetVal = ""
            End If
        End If

        usrGetPairedValue = cRetVal

    End Function
    'RETURNS: item index of cSearchStr in cItemList
    '
    'NOTES:
    'Search is CASE-SENSITIVE
    '
    Public Function SearchItemDelimited(ByVal cItemList, ByVal cDelimitedBy, ByVal cSearchStr)
        Dim nPos As Integer

        cItemList = cDelimitedBy & cItemList & cDelimitedBy
        nPos = InStr(cItemList, cDelimitedBy & cSearchStr & cDelimitedBy)
        If nPos > 1 Then
            nPos = nPos - 1
        End If
        SearchItemDelimited = IndexItemDelimited(cItemList, cDelimitedBy, nPos) 'get index number

    End Function

    Public Function CountItemDelimited(ByVal cItemList, ByVal cDelimitedBy)
        Dim nCount As Integer
        nCount = CountStr(cItemList, cDelimitedBy)
        If nCount > 0 Then
            nCount = nCount + 1
        ElseIf Len(cItemList) > 0 Then
            nCount = 1
        End If
        CountItemDelimited = nCount
    End Function


    Public Function DeleteItemDelimited(ByVal cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer, bAppended As Integer
        Dim cNewItemList As String

        DeleteItemDelimited = cItemList

        If nItemNo > 0 Then

            bAppended = False

            If CountStr(cItemList, cDelimitedBy) < nItemNo Then
                cItemList = cItemList & cDelimitedBy
                bAppended = True
            End If
            nStart = 1
            nCount = 0
            nPlace = InStr(nStart, cItemList, cDelimitedBy)
            Do While nPlace
                nCount = nCount + 1
                If nCount = nItemNo Then
                    cNewItemList = Mid$(cItemList, 1, nStart - 1) & Mid$(cItemList, nPlace + Len(cDelimitedBy))
                    If bAppended And Len(cNewItemList) > 0 Then
                        cNewItemList = Left$(cNewItemList, Len(cNewItemList) - Len(cDelimitedBy))
                    End If
                    DeleteItemDelimited = cNewItemList
                    Exit Do
                Else
                    nStart = nPlace + Len(cDelimitedBy)
                    nPlace = InStr(nStart, cItemList, cDelimitedBy)
                End If
            Loop

        End If

    End Function

    Public Function GetItemDelimited(ByVal cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer
        Dim bAppended

        GetItemDelimited = ""

        If CountStr(cItemList, cDelimitedBy) < nItemNo Then
            cItemList = cItemList & cDelimitedBy
            bAppended = True
        End If
        nStart = 1
        nCount = 0
        nPlace = InStr(nStart, cItemList, cDelimitedBy)
        Do While nPlace
            nCount = nCount + 1
            If nCount = nItemNo Then
                GetItemDelimited = Mid$(cItemList, nStart, (nPlace) - nStart)
                Exit Do
            Else
                nStart = nPlace + Len(cDelimitedBy)
                nPlace = InStr(nStart, cItemList, cDelimitedBy)
            End If
        Loop

    End Function

    'FUNCTION: Returns the Index of the item occupied by
    'a certain character position
    '
    '
    Public Function IndexItemDelimited(ByVal cItemList, ByVal cDelimitedBy, ByVal nCharPos)
        Dim nTotItems As Integer, nEndCount As Integer
        If nCharPos <= Len(cItemList) And Len(cItemList) <> 0 And nCharPos <> 0 Then
            nTotItems = CountItemDelimited(cItemList, cDelimitedBy)
            cItemList = Mid$(cItemList, nCharPos)
            nEndCount = CountItemDelimited(cItemList, cDelimitedBy)
            IndexItemDelimited = nTotItems - nEndCount + 1
        Else
            IndexItemDelimited = 0
        End If
    End Function


    Public Function SaveItemDelimited(ByRef cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String, ByVal cSaveStr As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer
        Dim cNewItemList As String
        Dim bFound As Boolean = False, nCtr As Integer

        SaveItemDelimited = False

        If CountItemDelimited(cItemList, cDelimitedBy) = 1 And nItemNo = 1 Then
            cItemList = cSaveStr
        Else
            If CountStr(cItemList, cDelimitedBy) < nItemNo Then
                For nCtr = 1 To (nItemNo - CountItemDelimited(cItemList, cDelimitedBy))
                    cItemList = cItemList & cDelimitedBy & "?"
                Next
            End If
            nStart = 1
            nCount = 0
            nPlace = InStr(nStart, cItemList, cDelimitedBy)

            Do While nPlace
                nCount = nCount + 1
                If nCount = nItemNo Then
                    'first position to (last position - 1)
                    cNewItemList = Mid$(cItemList, 1, nStart - 1) & cSaveStr & Mid$(cItemList, nPlace)
                    SaveItemDelimited = True
                    cItemList = cNewItemList
                    bFound = True
                    Exit Do
                Else
                    nStart = nPlace + Len(cDelimitedBy)
                    nPlace = InStr(nStart, cItemList, cDelimitedBy)
                    If nPlace = 0 And nCount = (nItemNo - 1) Then
                        'last position
                        cNewItemList = Mid$(cItemList, 1, nStart - 1) & cSaveStr
                        SaveItemDelimited = True
                        cItemList = cNewItemList
                        bFound = True
                        Exit Do
                    End If
                End If
            Loop
        End If

    End Function
    'FUNCTION: Counts the occurence of cCountWhat in cCount string
    '
    '
    Public Function CountStr(ByVal cCount, ByVal cCountWhat) As Integer
        Dim nCount As Integer, nnCtr As Integer
        If Not IsNull(cCount) And Not IsNull(cCountWhat) Then
            cCount = UCase(cCount)
            cCountWhat = UCase(cCountWhat)
            nCount = 0
            For nnCtr = 1 To Len(cCount)
                If Len(cCount) - nnCtr + 1 >= Len(cCountWhat) Then
                    If Mid$(cCount, nnCtr, Len(cCountWhat)) = cCountWhat Then
                        nCount = nCount + 1
                    End If
                End If
            Next
        End If
        CountStr = nCount
    End Function

    Private Function IsNull(ByVal xItem) As Boolean
        If xItem Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function




#End Region

#Region "Admin Documents"
    Public Function GenerateFileTag(ByVal DB As SQLDB) As String
        Dim ReturnValue As String = ""
        Dim ErrorReturn As String = ""

        Dim sqlComm As New SqlClient.SqlCommand()
        Dim sqlConn As New SqlClient.SqlConnection


        Using sqlConn
            sqlConn.ConnectionString = DB.GetConnectionString()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                ErrorReturn = "sql connection is nothing"
            Else

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "GenerateFileTag"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.Add("ReturnValue", SqlDbType.VarChar, 5)
                sqlComm.Parameters("ReturnValue").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    ReturnValue = IfNull(sqlComm.Parameters("ReturnValue").Value, "")
                Catch SqlEx As SqlClient.SqlException
                    Dim myError As SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        ErrorReturn = ErrorReturn & " / " & (myError.Number & " - " & myError.Message)
                    Next

                    LogErrors(ErrorReturn)
                End Try

            End If

            sqlConn.Close()
        End Using
        Return ReturnValue
    End Function
#End Region

#Region "Directory Concern Functions"

    Public Function CleanDirPath(ByVal cDir As String, Optional ByVal cSeparator As String = "\") As String
        Return cDir & IIf(Microsoft.VisualBasic.Right(cDir, 1) = cSeparator, "", cSeparator)
    End Function

    Public Function GetAdminDir(Optional CreateIfNotExist As Boolean = True) As String
        Dim ReturnValue As String = ""

        ReturnValue = FOLDERDIRECTORY & "\ADMIN\"
        If (Not System.IO.Directory.Exists(ReturnValue)) And CreateIfNotExist Then
            System.IO.Directory.CreateDirectory(ReturnValue)
        End If

        Return ReturnValue
    End Function

#End Region

#Region "Logo and Header"
    Public Function GetLogoAndHeaderAdminDir(Optional CreateIfNotExist As Boolean = True) As String
        Dim ReturnValue As String = ""

        ReturnValue = GetAdminDir()

        'ReturnValue = FOLDERDIRECTORY & "\ADMIN\ADMGARMENT\"
        ReturnValue = ReturnValue & IIf(Right(ReturnValue, 1) = "\", "", "\") & "LOGOANDHEADER\"
        If (Not System.IO.Directory.Exists(ReturnValue)) And CreateIfNotExist Then
            System.IO.Directory.CreateDirectory(ReturnValue)
        End If
        Return ReturnValue
    End Function
#End Region

#Region "KPI"
    'Public KPISelectionList As New List(Of SelectedKPIDataCollection)

    'Public Class SelectedKPIDataCollection
    '    Public Name As String = ""
    '    Public isMultiSelection As Boolean
    '    'Public SelectedData As New KPISelectedData
    '    Public SelectedData As New SelectedKPIData
    'End Class

    'Public Class KPISelectedData
    '    Dim ListOfSelectedData As DataTable = Nothing

    '    Sub New()
    '        'initialize the ListOfSelectedData Datatable
    '        ListOfSelectedData = New DataTable
    '        ListOfSelectedData.Columns.Add("Value")
    '    End Sub

    '    Public Sub Add(cValue)
    '        Dim row() As DataRow

    '        row = ListOfSelectedData.Select("Value = '" & cValue & "'")
    '        If row.Count > 0 Then
    '            For i As Integer = 0 To row.Count - 1
    '                Remove(cValue)
    '            Next
    '        End If

    '        ListOfSelectedData.Rows.Add(New Object() {cValue})
    '    End Sub

    '    Public Sub Remove(cValue)
    '        Dim row() As DataRow

    '        row = ListOfSelectedData.Select("Value = '" & cValue & "'")
    '        If row.Count > 0 Then
    '            For i As Integer = 0 To row.Count - 1
    '                row(i).Delete()
    '            Next
    '        End If
    '    End Sub

    '    Public Sub ClearAll()
    '        ListOfSelectedData.Clear()
    '    End Sub

    '    Public Function GetListOfSelectedData() As DataTable
    '        Return ListOfSelectedData
    '    End Function

    'End Class
#End Region

#Region "Payroll"
    Public Const PAYROLL_UNLOCK_KEY As String = "P_Key_Payroll" 'This is the String Key Used In tblConfic for Key of PayrollLocking

    Public Enum LockType
        Locked = 1
        Unlocked = 2
        BDOBankExport = 3
        BPIBankExport = 4
    End Enum

    'Public Function GetLoctType(Type As LockType) As String
    '    Select Case Type
    '        Case LockType.Locked
    '            Return 1
    '        Case LockType.Unlocked
    '            Return 2
    '        Case LockType.BankExport
    '            Return 3
    '        Case Else
    '            Return Nothing
    '    End Select
    'End Function
#End Region

#Region "Uniform/Garment"
    Public Function GetGarmentPhotoPath(PKey As String, FileName As String)
        Dim retval As String = Nothing
        Try
            Dim ImagePath As String = GetGarmentPhotoAdminDir() & PKey & "\" & FileName
            retval = ImagePath
        Catch ex As Exception
            retval = Nothing
        End Try
        Return retval
    End Function

    Public Function GetGarmentPhotoAdminDir(Optional CreateIfNotExist As Boolean = True) As String
        Dim ReturnValue As String = ""

        ReturnValue = FOLDERDIRECTORY & "\ADMIN\"
        If (Not System.IO.Directory.Exists(ReturnValue)) And CreateIfNotExist Then
            System.IO.Directory.CreateDirectory(ReturnValue)
        End If

        'strDir = FOLDERDIRECTORY & "\" & "ADMIN & " \ "" & 
        ReturnValue = FOLDERDIRECTORY & "\ADMIN\ADMGARMENT\"
        If (Not System.IO.Directory.Exists(ReturnValue)) And CreateIfNotExist Then
            System.IO.Directory.CreateDirectory(ReturnValue)
        End If
        Return ReturnValue
    End Function

    Public Function CopyAdmGarmentPhoto(ByVal srcFilePath As String, ByVal PKey As String) As String
        Dim strDir As String = ""
        Dim fileName As String = ""
        Dim fileExt As String = ""

        Dim ctr As Integer = 0
        Try
            strDir = GetGarmentPhotoAdminDir() & PKey & "\"
            If (Not System.IO.Directory.Exists(strDir)) Then
                System.IO.Directory.CreateDirectory(strDir)
            End If

            fileExt = System.IO.Path.GetExtension(srcFilePath)

GENERATE_FILENAME:
            fileName = PKey & IIf(ctr > 0, "(" & ctr & ")", "") & fileExt
            ctr = ctr + 1

            If My.Computer.FileSystem.FileExists(strDir & fileName) Then GoTo GENERATE_FILENAME

            My.Computer.FileSystem.CopyFile(srcFilePath, strDir & fileName, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

        Catch ex As Exception
            'MsgBox("insert error message here:" & ex.Message, , GetAppName)
            MsgBox(ex.Message, , GetAppName)

        End Try
        Return fileName
    End Function
#End Region

#Region "Windows Process"
    Public Sub KillCurrentProcess()
        Dim process As System.Diagnostics.Process = process.GetCurrentProcess
        process.Kill()
    End Sub
#End Region

#Region "Load Screen"
    Public Sub ShowCustomLoadScreen(type As System.Type, Optional caption As String = "Please Wait", Optional desc As String = "")
        Try
            'IF added by calvhin 20170118
            If DevExpress.XtraSplashScreen.SplashScreenManager.Default Is Nothing Then
                'DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(type, True, True)
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(System.Windows.Forms.Application.OpenForms("frmCrewMain"), type, True, True, DevExpress.XtraSplashScreen.ParentFormState.Locked)
                If type.BaseType.Name.ToUpper = "WaitForm".ToUpper Then
                    DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption(caption)
                    DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription(desc)
                End If
            Else
                If type.BaseType.Name.ToUpper = "WaitForm".ToUpper Then
                    DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption(caption)
                    DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription(desc)
                End If
            End If
        Catch ex As Exception
            'MsgBox("Splash Screen Open : " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GetAppName())
            LogErrors("Splash Screen Open : " & ex.Message)
        End Try
    End Sub

    Public Sub CloseCustomLoadScreen()
        Try
            'if added by calvhin 20170118
            If DevExpress.XtraSplashScreen.SplashScreenManager.Default IsNot Nothing Then
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
            End If
        Catch ex As Exception
            'MsgBox("Splash Screen Close : " & ex.Message, MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GetAppName())
            LogErrors("Splash Screen Close : " & ex.Message)
        End Try
    End Sub
#End Region

#Region "Database Connection Check"
    Public Function CheckDBConnection(ByRef DB As SQLDB, Optional ExitProgramIfFails As Boolean = True, Optional OpenWaitForm As Boolean = True, Optional ShowMsg As Boolean = True) As Boolean
        If OpenWaitForm Then ShowCustomLoadScreen(GetType(Utilities.Waitform), , "Checking database connection...")

        If DB.CheckConnection Then
            If OpenWaitForm Then CloseCustomLoadScreen()
            Return True
        Else

            System.Windows.Forms.Application.DoEvents()
            If ShowMsg Then MsgBox("MPS5 has lost connection to the database. Check your connection or consult your system administrator for assistance." & IIf(ExitProgramIfFails, vbNewLine & vbNewLine & "This program will exit.", ""), MsgBoxStyle.Critical)
            If ExitProgramIfFails Then KillCurrentProcess()
            If OpenWaitForm Then CloseCustomLoadScreen()
            Return False
        End If
    End Function
#End Region

#Region "Connectivity"
    ''' <summary>
    ''' Checks if internet connection is available.
    ''' Uses www.google.com as reference check
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckForInternetConnection() As Boolean
        Try
            Using client = New System.Net.WebClient
                Using Stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

#Region "Graphical Planning"
    Public Enum LTPDisplayMode
        None = 0
        All = 1
        AllWithDataOnly = 2
        Selected = 3
    End Enum
#End Region

    Public Declare Function GetForegroundWindow Lib "user32" () As IntPtr
    Public Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As IntPtr) As Long

#Region "Progress Bar"
    Public Class MPS5ProgressBar
        Private f As New frmProgressBar

        Private oProgressMajor As DevExpress.XtraEditors.ProgressBarControl

        Public Property Status As String
            Get
                Try
                    Return f.lblStatus.Text
                Catch ex As Exception
                    Return ""
                End Try
            End Get
            Set(value As String)
                Try
                    f.lblStatus.Text = value
                Catch ex As Exception
                    f.lblStatus.Text = "Status"
                End Try
            End Set
        End Property

        Public Property ProgressMaxValue As Integer
            Get
                Return oProgressMajor.Properties.Maximum
            End Get
            Set(value As Integer)
                oProgressMajor.Properties.Maximum = value
            End Set
        End Property

        Public Property ProgressMinValue As Integer
            Get
                Return oProgressMajor.Properties.Minimum
            End Get
            Set(value As Integer)
                oProgressMajor.Properties.Minimum = value
            End Set
        End Property

        Public Property ProgressCurrentValue As Integer
            Get
                Return oProgressMajor.EditValue
            End Get
            Set(value As Integer)
                oProgressMajor.EditValue = value
            End Set
        End Property

        Sub New(MajorMaxValue As Integer, Optional _Status As String = "")

            oProgressMajor = f.progressBar_Main
            ProgressMaxValue = MajorMaxValue
            ProgressMinValue = 0

            If IfNull(_Status, "").Length > 0 Then
                Status = _Status
            End If

        End Sub

        Sub New()
            ' TODO: Complete member initialization 
            oProgressMajor = f.progressBar_Main
            ProgressMinValue = 0

        End Sub

        Public Sub Show()

            For Each frm As Windows.Forms.Form In Windows.Forms.Application.OpenForms
                If frm.Name = "frmProgressBar" Then
                    frm.Close()
                    frm.Dispose()
                    Exit For
                End If
            Next

            f.Show()
        End Sub

        Public Sub Update(Optional MoveMajor As Boolean = True, Optional MoveMinor As Boolean = True)
            If MoveMajor Then
                Try
                    oProgressMajor.PerformStep()
                Catch ex As Exception
                    'do nothing
                End Try
            End If
        End Sub

        Public Sub Close()
            If Not IsNothing(f) Then
                f.Close()
                f.Dispose()
            End If
        End Sub

        Public Sub Finish(Optional MoveMajorProgressToEnd As Boolean = True)
            Try
                If MoveMajorProgressToEnd Then
                    oProgressMajor.EditValue = oProgressMajor.Properties.Maximum
                    Windows.Forms.Application.DoEvents()
                End If

                System.Threading.Thread.Sleep(500)

                f.Close()
                f.Dispose()

            Catch ex As Exception
                f.Close()
                f.Dispose()
            End Try

        End Sub

    End Class
#End Region

End Module

