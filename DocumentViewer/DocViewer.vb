Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraSplashScreen
Public Class DocViewer
    Dim FormName As String = "DMS"
    Dim rightClickMenu As New DevExpress.XtraBars.PopupMenu
    Dim barManager As New DevExpress.XtraBars.BarManager
    Dim barButtonPreview As New DevExpress.XtraBars.BarButtonItem
    Dim barButtonPrint As New DevExpress.XtraBars.BarButtonItem
    Dim barButtonReplaceFile As New DevExpress.XtraBars.BarButtonItem
    Dim barButtonEditDesc As New DevExpress.XtraBars.BarButtonItem
    Dim barButtonDeleteFile As New DevExpress.XtraBars.BarButtonItem
    Dim barButtonExtract As New DevExpress.XtraBars.BarButtonItem
    Dim addMode As String
    Dim clsSec As New clsSecurity
#Region "Declarations"
    Dim docDataSource As New DataTable
    Dim docDT As New DataTable
    Dim winXDT As New DataTable
    Dim loadCnt As Integer = 0
    Dim fileExist As Boolean = False
    Dim selectedCrews As New ArrayList
    Dim MayLaman As Boolean = False
    Dim strDocGrpFilter As String = ""
    Dim strDocFilter As String = ""
    Private tempPdf As New pdfTemplate
    Private frmUpload As New DocViewer_Add
    Private frmBulk As DocViewer_Bulk
    Private frmAttach As frmMultipleFiles
    Private fileWatcher As FileSystemWatcher
    Private WithEvents notiTimer As New System.Timers.Timer
    Dim supportingDT As New DataTable
    Dim frmAttachDT As DataTable

    Dim strDateIssueFilter As String = ""

    '<!-- added by tony20171114
    Private oDocFilter As New DocFilter()


    Private Class DocFilter
        Public Document As String = ""
        Public DocumentGroup As String = ""
        Public DateIssueFrom As Object = ""
        Public DateIssueTo As Object = ""
        Public GridViewInFocus As DevExpress.XtraGrid.Views.Grid.GridView

        Public Enum FilterParam
            Document = 1
            DocumentGroup = 2
            DateIssueFrom = 3
            DateIssueTo = 4
        End Enum

        Public Sub New()
            Clear(False)
        End Sub

        Public Sub Clear(isApplyFilterToView As Boolean)
            Document = ""
            DocumentGroup = ""
            DateIssueFrom = ""
            DateIssueTo = ""

            If isApplyFilterToView Then
                ApplyFilterToGridView()
            End If
        End Sub

        Public Sub Clear(ClearWhat As FilterParam, isApplyFilterToView As Boolean)
            Select Case ClearWhat
                Case FilterParam.Document
                    Document = ""

                Case FilterParam.DocumentGroup
                    DocumentGroup = ""

                Case FilterParam.DateIssueFrom
                    DateIssueFrom = ""

                Case FilterParam.DateIssueTo
                    DateIssueTo = ""
            End Select

            If isApplyFilterToView Then
                ApplyFilterToGridView()
            End If
        End Sub

        Public Sub SetValue(SetToWhat As FilterParam, oValue As Object, isApplyFilterToView As Boolean)
            Select Case SetToWhat
                Case FilterParam.Document
                    Document = oValue

                Case FilterParam.DocumentGroup
                    DocumentGroup = oValue

                Case FilterParam.DateIssueFrom
                    DateIssueFrom = oValue

                Case FilterParam.DateIssueTo
                    DateIssueTo = oValue
            End Select

            If isApplyFilterToView Then
                ApplyFilterToGridView()
            End If
        End Sub

        Public Sub ApplyFilterToGridView() 'ByRef oGridView As DevExpress.XtraGrid.Views.Grid.GridView)
            Dim cFilter As String = ""
            'Document
            If Not IfNull(Document, "").Equals("") Then
                cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & _
                            "FKeyDocument = '" & Document & "'"
            End If

            'Document Group
            If Not IfNull(DocumentGroup, "").Equals("") Then
                cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & _
                            "FKeyDocGroup = '" & DocumentGroup & "'"
            End If

            'DateIssue From
            If Not IsNothing(DateIssueFrom) Then
                If Not IfNull(DateIssueFrom, "").Equals("") Then
                    If Not DateIssueFrom.Equals(#12:00:00 AM#) Then
                        cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & _
                                "DateIssue >= #" & Format(DateIssueFrom, "MM/dd/yyyy") & "#"
                    End If
                End If
            End If

            'DateIssue To
            If Not IsNothing(DateIssueTo) Then
                If Not IfNull(DateIssueTo, "").Equals("") Then
                    If Not DateIssueTo.Equals(#12:00:00 AM#) Then
                        cFilter = cFilter & IIf(cFilter.Length > 0, " AND ", "") & _
                                    "DateIssue <= #" & Format(DateIssueTo, "MM/dd/yyyy") & "#"
                    End If
                End If
            End If


            'APPLY FILTER
            If Not IsNothing(GridViewInFocus) Then
                GridViewInFocus.ActiveFilterString = cFilter
            End If
        End Sub
    End Class
    '-->
#End Region

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        Me.LayoutControl1.AllowCustomization = False
        Me.LayoutControl2.AllowCustomization = False
        Me.LayoutControl3.AllowCustomization = False
        'Edit Options
        Dim expDocDays As Integer
        If GetUserSetting("DocExpDays") = "" Then expDocDays = 0 Else expDocDays = GetUserSetting("DocExpDays")
        SetEditOptionsVisibility(Name, True)
        SetAddCaption(Name, "Attach Image")
        'SplashScreenManager.ShowForm(GetType(DMS_Waitform))
        Dim dt, docGrpDT As New DataTable
        'sql = "SELECT * FROM [Crewlist_DMS]"
        'dt = DB.CreateTable(sql)
        'edited by: tony20160229; Apply user-data filtering
        Dim userdatafilterstring As String = GetUserFilterString(, "FKeyAgentCode", "FKeyPrinCode", "FKeyFlt")
        Dim expDueDateDays As Integer
        Dim sql As String = "EXEC [SP_Crewlist_Activities] @ExpDocDays = " & expDocDays & ", @ExpContractDays = " & expDueDateDays & ", @userdatafilterstring = '" & Replace(userdatafilterstring, "'", "''") & "'"
        'dt = DB.CreateTable("SELECT * FROM [Crewlist_DMS] " & _
        '                    IIf(userdatafilterstring.Length > 0, "WHERE " & userdatafilterstring, ""))
        dt = DB.CreateTable(sql)
        If dt.Rows.Count > 0 Then
            gcCrewList.DataSource = dt
            gvCrewList.FocusedRowHandle = 0
            If strCrewListFilter <> "" Then gvCrewList.ActiveFilterString = strCrewListFilter
        End If
        docDataSource = DB.CreateTable("SELECT PKey, Name, FKeyDocGroup FROM dbo.tbladmdocument ORDER BY Name")
        luDoc.Properties.DataSource = docDataSource
        docGrpDT = DB.CreateTable("SELECT PKey, Name FROM tblAdmDocGroup")
        luDocGrp.Properties.DataSource = docGrpDT
        initDocTable()
        setupSupportingDocsTbl()
        setupFrmAttachDT()
        setupRightClickMenu()
        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteCaption(Name, "Delete Files")
        SetAddCaption(Name, "Attach Image")
        AllowAddition(Name, False)
        AllowDeletion(Name, False)

        Me.dtefrom.EditValue = DateAdd("M", -6, Now())
        Me.dteTo.EditValue = Now
    End Sub

    Private Sub gvCrewList_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvCrewList.CellValueChanging
        If e.Column.FieldName = "IsSelected" Then
            If e.Value = True Then
                Dim dt As DataTable = DB.CreateTable("SELECT *, CAST(0 as bit) as IsSelected  FROM [DMS_DocList] WHERE CrewID = '" & gvCrewList.GetRowCellValue(e.RowHandle, "IDNbr").ToString & "' ORDER BY DocType")
                If Not dt Is Nothing Then
                    For Each nrow In dt.Rows
                        Dim hasFile As String = ""
                        If IfNull(checkIfExist(IfNull(nrow("Filename"), "")), False) = True Then hasFile = "Yes" Else hasFile = "No"
                        'hasFile = "No"
                        Dim xrow() As Object = {nrow("DocID"), nrow("CrewID"), nrow("CrewName"), nrow("Filename"), nrow("DocType"), nrow("Number"), nrow("DateIssue"), nrow("DateExpiry"), hasFile, nrow("IsSelected"), nrow("FKeyDocument"), nrow("FKeyDocGroup")}
                        docDT.Rows.Add(xrow)
                    Next
                    Mainview.RefreshData()
                    '<!-- edited by tony20171114
                    SetAllowAddition()
                    'If Mainview.RowCount > 0 Then
                    '    Mainview.SelectRow(0)
                    '    AllowAddition(Name, True)
                    'Else
                    '    AllowAddition(Name, False)
                    'End If
                    '-->
                End If
            Else
                For i As Integer = docDT.Rows.Count - 1 To 0 Step -1
                    If docDT.Rows(i).Item("CrewID").ToString = gvCrewList.GetRowCellValue(gvCrewList.FocusedRowHandle, "IDNbr").ToString Then
                        docDT.Rows(i).Delete()
                    End If
                Next

                Mainview.RefreshData()
                '<!-- edited by tony20171114
                SetAllowAddition()
                'If Mainview.RowCount > 0 Then
                '    Mainview.SelectRow(0)
                '    AllowAddition(Name, True)
                'Else
                '    AllowAddition(Name, False)
                'End If
                '-->
            End If

        End If
    End Sub

    '<!-- added by tony20171114
    Private Sub SetAllowAddition()
        If Mainview.RowCount > 0 Then
            Mainview.SelectRow(0)
            AllowAddition(Name, True)
        Else
            AllowAddition(Name, False)
        End If
    End Sub
    '-->

    Private Sub enableDoubleBuffer()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or _
                    ControlStyles.UserPaint Or _
                    ControlStyles.AllPaintingInWmPaint Or _
                    ControlStyles.Selectable Or _
                    ControlStyles.StandardClick _
                    , True)
        Me.UpdateStyles()
    End Sub

    Private Sub DocViewer_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        rightClickMenu.HidePopup()
    End Sub

    Private Sub DocViewer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        enableDoubleBuffer()
        notiTimer.Interval = 1000
        notiTimer.Enabled = True
        oDocFilter.GridViewInFocus = Mainview
    End Sub

    Public Overrides Sub AddData()
        Dim tempFileName As String = ""
        Dim dbFileName As String
        Dim cnt As Integer = 0

        'CHECK IF FOLDERDIRECTORY HAS A VALUE
        If IfNull(FOLDERDIRECTORY, "").Equals("") Then
            MsgBox("Images directory is not configured. Please contact your system adminitrator for assistance.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        'CHEC IF FOLDERDIRECTORY EXISTS
        If Not System.IO.Directory.Exists(FOLDERDIRECTORY) Then
            MsgBox("This function is unavailable at the moment because the system cannot connect to the images directory. Please contact your system administrator for assistance.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If IfNull(Mainview.GetFocusedRowCellValue("Filename"), "").Equals("") Then
            MsgBox("Unable to attach file to this document because there is no dateissue. Date Issue is used by the system to format the attached file's filename.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Valid Files(*.tif;*.png;*.jpg;*.docx;*.doc;*.pdf)|*.tif;*.png;*.jpg;*.docx;*.doc;*.pdf"
        OpenFileDialog1.FileName = ""   'added by tony20171114
        OpenFileDialog1.Multiselect = True
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            SplashScreenManager.ShowForm(GetType(DMS_Waitform))
            frmAttachDT.Clear()
            If supportingDocs.RowCount > 0 Then
                If supportingDocs.GetRowCellValue(0, "FilePath").ToString.Split("_").Count = 4 Then
                    cnt = Val(supportingDocs.GetRowCellValue(0, "FilePath").ToString.Split("_").GetValue(3)) + 1
                End If
            End If
            tempFileName = Mainview.GetFocusedRowCellValue("Filename").ToString()
            For i As Integer = 0 To OpenFileDialog1.FileNames.Count - 1
                dbFileName = tempFileName & "_" & cnt
                frmAttachDT.Rows.Add(New Object() {Path.GetFileNameWithoutExtension(OpenFileDialog1.FileNames(i)), OpenFileDialog1.FileNames(i), dbFileName})
                cnt = cnt + 1
            Next
            SplashScreenManager.CloseForm()
        Else
            Exit Sub
        End If
        frmAttach = New frmMultipleFiles(Mainview.GetFocusedRowCellValue("CrewName"), Mainview.GetFocusedRowCellValue("DocType"), tempFileName, frmAttachDT, Mainview.GetFocusedRowCellValue("CrewID"), Mainview.GetFocusedRowCellValue("DocID"), DB)
        frmAttach.ShowDialog()
        Mainview_FocusedRowChanged(Nothing, Nothing)
        supportingDocs_FocusedRowChanged(Nothing, Nothing)
        If supportingDocs.RowCount > 0 Then Mainview.SetFocusedRowCellValue("hasFile", "Yes")
    End Sub

    Public Overrides Sub BulkUpload()
        frmBulk = New DocViewer_Bulk(New Object() {"Bulk"})
        If gvCrewList.SelectedRowsCount > 0 Then
            With frmBulk
                .crewDocList = DB.CreateTable("SELECT Filename, CrewName, DocType FROM [DMS_DocList]")
                .ShowDialog()
                If .uploadDone = True Then
                    For i As Integer = 0 To Mainview.RowCount - 1
                        If checkIfExist(Mainview.GetRowCellValue(i, "Filename")) = True Then
                            Mainview.SetRowCellValue(i, "hasFile", "Yes")
                        End If
                    Next
                End If
            End With
        End If
    End Sub

    Public Overrides Sub DeleteData()
        Try
            If supportingDocs.RowCount > 0 Then
                If MessageBox.Show("Are you sure you want to delete files(" & supportingDocs.RowCount & ") connected to """ & Mainview.GetFocusedRowCellValue("DocType") & """?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    previewPdf.CloseDocument()
                    For i As Integer = 0 To supportingDocs.RowCount - 1
                        Dim filepath As String = GenerateCrewFilePath(supportingDocs.GetRowCellValue(i, "FilePath"))
                        Kill(filepath)
                    Next
                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblDocImage", _
                        "FKeyCrewDocumentID IN ('" & Mainview.GetFocusedRowCellValue("DocID") & "')", _
                        "<< Delete Data - " & FormName & " >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & ">", _
                        GetUserName())
                    '-->

                    If DB.RunSql("DELETE FROM tblDocImage WHERE FKeyCrewDocumentID = '" & Mainview.GetFocusedRowCellValue("DocID") & "'") Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                    End If
                    Mainview_FocusedRowChanged(Nothing, Nothing)
                    If supportingDocs.RowCount = 0 Then Mainview.SetFocusedRowCellValue("hasFile", "No")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub setupWatcher(ByVal db As SQLDB)
        Try
            fileWatcher = New FileSystemWatcher(getDocFolder(db))
            AddHandler fileWatcher.Created, AddressOf OnChanged
            fileWatcher.EnableRaisingEvents = True
        Catch ex As ArgumentException
            MsgBox("Please select folder directory.", MsgBoxStyle.Information, "MPS5 - Document Manager System")
        End Try
    End Sub

    Private Sub OnChanged(source As Object, e As IO.FileSystemEventArgs)
        MayLaman = True
    End Sub

    Private Sub Run_NotiTimer(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles notiTimer.Elapsed
        If MayLaman = True Then
            RaiseCustomEvent(Name, New Object() {"UpdateNotification", "WithNotif.png"})
        Else
            RaiseCustomEvent(Name, New Object() {"UpdateNotification", "WithoutNotif.png"})
        End If
    End Sub

    Public Overrides Sub openNotification()
        Dim dt As New DataTable
        dt = DB.CreateTable("SELECT Filename, CrewName, DocType FROM [DMS_DocList]")
        frmBulk = New DocViewer_Bulk(New Object() {"Notif", "Manual", getDocFolder(DB), dt})
        frmBulk.ShowDialog()
    End Sub

    Private Sub checkNotification()
        Dim dir As String = getDocFolder(DB)
        If dir <> "" Then
            Dim files() As String = Directory.GetFiles(dir)
            If files.Count > 0 Then
                If autoBulkOpened = False Then
                    Dim dt As New DataTable
                    dt = DB.CreateTable("SELECT Filename, CrewName, DocType FROM [DMS_DocList]")
                    frmBulk = New DocViewer_Bulk(New Object() {"Notif", "Auto", dir, dt})
                    frmBulk.ShowDialog()
                    autoBulkOpened = True
                    If frmBulk.uploadDone = True Then
                        For i As Integer = 0 To Mainview.RowCount - 1
                            If checkIfExist(Mainview.GetRowCellValue(i, "Filename")) = True Then
                                Mainview.SetRowCellValue(i, "hasFile", "Yes")
                            End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub initDocTable()
        Dim ccolumn As DataColumn

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DocID"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "CrewID"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "CrewName"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Filename"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DocType"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "Number"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateIssue"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "DateExpiry"
        ccolumn.DataType = System.Type.GetType("System.DateTime")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "hasFile"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "IsSelected"
        ccolumn.DataType = System.Type.GetType("System.Boolean")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyDocument"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        ccolumn = New DataColumn
        ccolumn.ColumnName = "FKeyDocGroup"
        ccolumn.DataType = System.Type.GetType("System.String")
        docDT.Columns.Add(ccolumn)

        Maingrid.DataSource = docDT

        genericDateEdit.EditMask = "dd-MMM-yyyy"
        genericDateEdit.Mask.UseMaskAsDisplayFormat = True

        Mainview.Columns("CrewName").Group()
    End Sub

    Private Sub Mainview_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles Mainview.FocusedRowChanged
        supportingDT = DB.CreateTable("SELECT * FROM tblDocImage WHERE FKeyCrewDocumentID = '" & Mainview.GetFocusedRowCellValue("DocID") & "' ORDER BY DateUpdated DESC")
        supportingDocsGC.DataSource = supportingDT
        supportingDocs_FocusedRowChanged(Nothing, Nothing)
    End Sub

    Private Sub Mainview_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Mainview.RowCellStyle
        If e.Column.FieldName = "hasFile" Then
            If e.CellValue = "Yes" Then
                e.Appearance.ForeColor = Color.Green
            End If
        End If
    End Sub

    Sub PrintFile(ByVal fileName As String)
        Dim myFile As New ProcessStartInfo
        Try
            With myFile
                .UseShellExecute = True
                .WindowStyle = ProcessWindowStyle.Hidden
                .CreateNoWindow = True
                .FileName = fileName
                .Verb = "Print"
            End With
            Process.Start(myFile)
        Catch ex As Exception

            MessageBox.Show("Fail to print file :" & fileName & Environment.NewLine & ex.Message, "MPS5 - Document Management System")
        End Try
    End Sub

    Private Sub luDocGrp_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles luDocGrp.ButtonClick
        '<!-- edited by tony20171114
        'neil luDocGrp.EditValue = Nothing
        'neil strDocGrpFilter = ""
        'Mainview.ClearColumnsFilter()
        'neil UpdMainviewActiveFilter()
        'luDoc.Properties.DataSource = Nothing
        'If e.Button.Kind = ButtonPredefines.Clear Then
        '    luDoc.Properties.DataSource = docDataSource
        '    luDocGrp.EditValue = Nothing 'neil
        '    strDocGrpFilter = ""            'neil

        '    UpdMainviewActiveFilter()       'neil
        'End If

        If e.Button.Kind = ButtonPredefines.Clear Then
            luDoc.Properties.DataSource = docDataSource
            luDocGrp.EditValue = Nothing 'neil
            oDocFilter.Clear(DocFilter.FilterParam.DocumentGroup, True)
        End If
        '-->
    End Sub

    Private Sub luDocGrp_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles luDocGrp.CloseUp
        '<!-- edited by tony20171114
        'If IsDBNull(e.Value) = False Then
        '    If IsNothing(e.Value) = False Then
        '        strDocGrpFilter = "FKeyDocGroup = '" & e.Value & "'"
        '        'Mainview.ActiveFilterString = strDocGrpFilter

        '        'Dim dt As New DataTable
        '        'dt = DB.CreateTable("SELECT PKey, Name FROM tblAdmDocument WHERE FKeyDocGroup = '" & e.Value & "'")
        '        'luDoc.Properties.DataSource = dt
        '        Dim dv As DataView = New DataView(docDataSource)
        '        dv.RowFilter = "FKeyDocGroup = '" & e.Value & "'"
        '        Dim dt As DataTable = dv.ToTable
        '        luDoc.Properties.DataSource = dt
        '        Dim foundrows As DataRow() = dt.Select("PKey = '" & luDoc.EditValue & "'")
        '        If foundrows.Length = 0 Then
        '            luDoc.EditValue = Nothing
        '            strDocFilter = ""
        '        End If

        '        UpdMainviewActiveFilter()
        '        Exit Sub
        '    End If
        'End If

        oDocFilter.Clear(DocFilter.FilterParam.DocumentGroup, False)
        If IsDBNull(e.Value) = False Then
            If IsNothing(e.Value) = False Then
                oDocFilter.SetValue(DocFilter.FilterParam.DocumentGroup, e.Value, False)
                strDocGrpFilter = "FKeyDocGroup = '" & e.Value & "'"

                Dim dv As DataView = New DataView(docDataSource)
                dv.RowFilter = "FKeyDocGroup = '" & e.Value & "'"
                Dim dt As DataTable = dv.ToTable
                luDoc.Properties.DataSource = dt
                Dim foundrows As DataRow() = dt.Select("PKey = '" & luDoc.EditValue & "'")
                If foundrows.Length = 0 Then
                    luDoc.EditValue = Nothing
                    strDocFilter = ""
                End If

            End If
        End If

        oDocFilter.ApplyFilterToGridView()
        '-->
    End Sub

    Private Sub luDoc_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles luDoc.ButtonClick
        '<!-- edited by tony20171114
        If e.Button.Kind = ButtonPredefines.Clear Then
            luDoc.EditValue = Nothing
            strDocFilter = ""
            oDocFilter.Clear(DocFilter.FilterParam.Document, True)
        End If

        'luDoc.EditValue = Nothing
        'strDocFilter = ""
        'UpdMainviewActiveFilter()
        ''Mainview.ActiveFilterString = strDocGrpFilter
        '-->
    End Sub

    Private Sub luDoc_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles luDoc.CloseUp
        '<!-- edited by tony20171114
        oDocFilter.Clear(DocFilter.FilterParam.Document, False)
        If Not IsNothing(e.Value) Then
            If IsDBNull(e.Value) = False Then
                oDocFilter.SetValue(DocFilter.FilterParam.Document, e.Value, False)

                'strDocFilter = " FKeyDocument = '" & e.Value & "'"
                ''Mainview.ActiveFilterString = strDocGrpFilter & IIf(strDocGrpFilter.Length > 0, " AND ", "") & strDocFilter
                ''neil UpdMainviewActiveFilter()
                ''neil Exit Sub
            End If
        End If

        oDocFilter.ApplyFilterToGridView()
        'UpdMainviewActiveFilter() 'neil
        '        Exit Sub 'neil
        'Clear_Filter:

        '        Mainview.ActiveFilterString = strDocGrpFilter
        '-->
    End Sub

    Public Overrides Sub applyCrewFilter(ByVal param() As Object)
        Select Case param(0)
            Case "SortCrew_ASC"
                With gvCrewList
                    .BeginSort()
                    Try
                        .ClearSorting()
                        .Columns("LName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                        .Columns("FName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                        .Columns("MName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    Finally
                        .EndSort()
                    End Try
                End With
            Case "SortCrew_DESC"
                With gvCrewList
                    .BeginSort()
                    Try
                        .ClearSorting()
                        .Columns("LName").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                        .Columns("FName").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                        .Columns("MName").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                    Finally
                        .EndSort()
                    End Try
                End With
            Case "SortRank_ASC"
                With gvCrewList
                    .BeginSort()
                    Try
                        .ClearSorting()
                        .Columns("RankSortCode").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                    Finally
                        .EndSort()
                    End Try
                End With
            Case "SortRank_DESC"
                With gvCrewList
                    .BeginSort()
                    Try
                        .ClearSorting()
                        .Columns("RankSortCode").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                    Finally
                        .EndSort()
                    End Try
                End With
            Case "CrewList_Filter"
                gvCrewList.ActiveFilterString = strCrewListFilter
            Case "Clear_CrewList_Filter"
                strCrewListFilter = ""
                oQuickFilter.Clear()
                gvCrewList.ActiveFilterString = strCrewListFilter
        End Select
    End Sub

    Private Sub setupSupportingDocsTbl()
        Dim clmn As DataColumn

        clmn = New DataColumn
        clmn.ColumnName = "PKey"
        clmn.DataType = System.Type.GetType("System.String")
        supportingDT.Columns.Add(clmn)

        clmn = New DataColumn
        clmn.ColumnName = "FilePath"
        clmn.DataType = System.Type.GetType("System.String")
        supportingDT.Columns.Add(clmn)

        clmn = New DataColumn
        clmn.ColumnName = "Description"
        clmn.DataType = System.Type.GetType("System.String")
        supportingDT.Columns.Add(clmn)
    End Sub

    Private Sub supportingDocs_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles supportingDocs.FocusedRowChanged
        Dim filePath As String = ""
        If supportingDocs.RowCount > 0 Then
            If supportingDocs.IsValidRowHandle(supportingDocs.FocusedRowHandle) Then
                filePath = GenerateCrewFilePath(supportingDocs.GetFocusedRowCellValue("FilePath").ToString, Mainview.GetFocusedRowCellValue("CrewID"))
            Else
                Exit Sub
            End If
        End If
        rightClickMenu.HidePopup()
        Try
            If filePath <> "" Then
                previewPdf.CloseDocument()
                previewPdf.LoadDocument(filePath)
                AllowDeletion(Name, True)
            Else
                previewPdf.CloseDocument()
                AllowDeletion(Name, False)
            End If
        Catch ex As Exception
            previewPdf.CloseDocument()
        End Try
    End Sub

    Private Sub setupRightClickMenu()
        clsSec.propSQLConnStr = DB.GetConnectionString
        rightClickMenu.Manager = barManager

        If clsSec.hasNoDeletePermission(Name, USER_ID) = 0 Then
            barButtonDeleteFile.Caption = "Delete File"
            barManager.Items.Add(barButtonDeleteFile)
            rightClickMenu.ItemLinks.Add(barButtonDeleteFile)
            AddHandler barButtonDeleteFile.ItemClick, AddressOf DeleteFile
        End If

        If clsSec.hasNoUpdatePermission(Name, USER_ID) = 0 Then
            barButtonPreview.Caption = "Preview File"
            barManager.Items.Add(barButtonPreview)

            barButtonPrint.Caption = "Print File"
            barManager.Items.Add(barButtonPrint)

            barButtonReplaceFile.Caption = "Replace File"
            barManager.Items.Add(barButtonReplaceFile)

            barButtonEditDesc.Caption = "Edit Description"
            barManager.Items.Add(barButtonEditDesc)

            barButtonExtract.Caption = "Extract File"
            barManager.Items.Add(barButtonExtract)

            rightClickMenu.ItemLinks.Add(barButtonPreview)

            rightClickMenu.ItemLinks.Add(barButtonReplaceFile)
            rightClickMenu.ItemLinks.Add(barButtonEditDesc)

            rightClickMenu.ItemLinks.Add(barButtonPrint)
            rightClickMenu.ItemLinks.Add(barButtonExtract)

            AddHandler barButtonPreview.ItemClick, AddressOf SinglePreview

            AddHandler barButtonReplaceFile.ItemClick, AddressOf ReplaceFile
            AddHandler barButtonEditDesc.ItemClick, AddressOf EditDesc
            AddHandler barButtonPrint.ItemClick, AddressOf SinglePrint
            AddHandler barButtonExtract.ItemClick, AddressOf SingleExtract
        End If


    End Sub

    Private Sub supportingDocs_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles supportingDocs.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If supportingDocs.RowCount > 0 Then
                rightClickMenu.ShowPopup(MousePosition)
            End If
        Else
            rightClickMenu.HidePopup()
        End If
    End Sub

    Private Sub setupFrmAttachDT()
        frmAttachDT = New DataTable
        Dim clmn As DataColumn

        clmn = New DataColumn
        clmn.ColumnName = "Description"
        clmn.DataType = System.Type.GetType("System.String")
        frmAttachDT.Columns.Add(clmn)

        clmn = New DataColumn
        clmn.ColumnName = "Source"
        clmn.DataType = System.Type.GetType("System.String")
        frmAttachDT.Columns.Add(clmn)

        clmn = New DataColumn
        clmn.ColumnName = "FileName"
        clmn.DataType = System.Type.GetType("System.String")
        frmAttachDT.Columns.Add(clmn)
    End Sub

    Public Overrides Sub DownloadDMSFiles()
        Dim donwloadOK As Boolean = False
        Dim filesDT As New DataTable
        Dim DLFileName As String = ""
        Dim crewFolder As String = ""
        Dim fileSrc As String = ""
        'Dim missingFiles As Integer = 0
        Try
            FolderBrowserDialog1.Description = "Please select where you want to save the selected files."
            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                Mainview.FocusedColumn = Mainview.Columns(0)
                For x As Integer = 0 To Mainview.DataRowCount - 1
                    If Mainview.GetRowCellValue(x, "IsSelected") = True Then
                        crewFolder = FOLDERDIRECTORY & "\" & Mainview.GetRowCellValue(x, "Filename").ToString.Split("_").GetValue(0).ToString & "\"
                        filesDT = DB.CreateTable("SELECT [Description], FilePath FROM tblDocImage WHERE FKeyCrewDocumentID = '" & Mainview.GetRowCellValue(x, "DocID") & "'")
                        If filesDT.Rows.Count > 0 Then
                            donwloadOK = True
                            For i As Integer = 0 To filesDT.Rows.Count - 1
                                fileSrc = crewFolder & filesDT.Rows(i).Item("FilePath") & ".pdf"
                                If File.Exists(fileSrc) Then
                                    DLFileName = FolderBrowserDialog1.SelectedPath & "\" & Mainview.GetRowCellValue(x, "DocType") & "_" & filesDT.Rows(i).Item("Description").ToString & "_" & i & ".pdf" 'FolderBrowserDialog1.SelectedPath & "\" & filename
                                    My.Computer.FileSystem.CopyFile(fileSrc, DLFileName, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                                End If
                            Next
                        End If
                    End If
                Next
                If Not donwloadOK Then
                    MessageBox.Show("There are no files to download.", "MPS5 - DMS")
                Else
                    MessageBox.Show("Download complete.", "MPS5 - DMS")
                End If
            End If
        Catch ex As System.IO.DirectoryNotFoundException
            MsgBox("MPS5 - DMS: " & ex.Message)
        End Try
    End Sub

    Public Overrides Sub PrintDMSFiles()
        Dim filename As String = ""
        Dim filesDT As New DataTable
        Mainview.FocusedColumn = Mainview.Columns(0)
        For i As Integer = 0 To Mainview.DataRowCount - 0
            If Mainview.GetRowCellValue(i, "IsSelected") = True Then
                filesDT = DB.CreateTable("SELECT [Description], FilePath FROM tblDocImage WHERE FKeyCrewDocumentID = '" & Mainview.GetRowCellValue(i, "DocID") & "'")
                If filesDT.Rows.Count > 0 Then
                    For x As Integer = 0 To filesDT.Rows.Count - 1
                        filename = GenerateCrewFilePath(filesDT.Rows(x).Item("FilePath"))
                        PrintFile(filename)
                    Next
                End If
            End If
        Next
    End Sub

#Region "Right Click Methods"

    Private Sub SinglePreview()
        If MessageBox.Show("Preview the file """ & supportingDocs.GetFocusedRowCellValue("Description") & """?", "MPS5 - DMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim filename As String = ""
            Try
                filename = GenerateCrewFilePath(supportingDocs.GetFocusedDataRow("FilePath"))
                Process.Start(filename)
            Catch ex As Exception
                MsgBox("MPS5 - DMS: " & ex.Message)
            End Try

        End If
    End Sub

    Private Sub ReplaceFile()
        Dim filePath As String
        OpenFileDialog1.Multiselect = False
        Try
            If supportingDocs.RowCount > 0 Then
                OpenFileDialog1.ShowDialog()
                filePath = OpenFileDialog1.FileName
                If Not filePath Is Nothing And filePath <> "OpenFileDialog1" Then
                    If MessageBox.Show("Are you sure you want to replace file of """ & supportingDocs.GetFocusedRowCellValue("Description").ToString & """?", GetAppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        previewPdf.CloseDocument()
                        replaceCrewDocToPdf(supportingDocs.GetFocusedRowCellValue("FilePath").ToString, filePath, supportingDocs.GetFocusedRowCellValue("FilePath").ToString)
                        MsgBox("Upload successful!", MsgBoxStyle.Information, GetAppName)
                        supportingDocs_FocusedRowChanged(Nothing, Nothing)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("MPS5 - DMS :" & ex.Message, MsgBoxStyle.Information, GetAppName)
        End Try
    End Sub

    Private Sub EditDesc()
        Dim strPrompt As String
        Dim res As String
        strPrompt = "Change Description." & Environment.NewLine & Environment.NewLine & "Description:"
        res = InputBox(strPrompt, "MPS5 - DMS", supportingDocs.GetFocusedRowCellValue("Description"), (Me.Location.X + Me.Width) / 2)
        If res <> "" Then
            DB.RunSql("Update tblDocImage SET [Description] = '" & res & "' WHERE PKey = '" & supportingDocs.GetFocusedRowCellValue("PKey") & "'")
            Mainview_FocusedRowChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub SinglePrint()
        If MessageBox.Show("Are you sure you want to print """ & supportingDocs.GetFocusedRowCellValue("Description") & """?", "MPS5 - DMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim filename As String = ""
            Try
                filename = GenerateCrewFilePath(supportingDocs.GetFocusedDataRow("FilePath"))
                PrintFile(filename)
            Catch ex As Exception
                MsgBox("MPS5 - DMS: " & ex.Message)
            End Try

        End If
    End Sub

    Private Sub SingleExtract()
        Dim DLFileName As String = ""
        Dim crewFolder As String = ""
        Dim fileSrc As String = ""
        Try
            FolderBrowserDialog1.Description = "Please select where you want to save the selected files."
            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                fileSrc = GenerateCrewFilePath(supportingDocs.GetFocusedDataRow("FilePath"))
                DLFileName = FolderBrowserDialog1.SelectedPath & "\" & Mainview.GetFocusedRowCellValue("DocType") & "_" & supportingDocs.GetFocusedRowCellValue("Description").ToString & "_" & 0 & ".pdf"
                My.Computer.FileSystem.CopyFile(fileSrc, DLFileName, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)
                MessageBox.Show("Download complete.", "MPS5 - DMS")
            End If
        Catch ex As System.IO.DirectoryNotFoundException
            MsgBox("MPS5 - DMS: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteFile()
        If MessageBox.Show("Are you sure you want to delete """ & supportingDocs.GetFocusedRowCellValue("Description") & """?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Dim filepath As String = GenerateCrewFilePath(supportingDocs.GetFocusedRowCellValue("FilePath"))
                previewPdf.CloseDocument()
                Kill(filepath)
                '<!--added by tony20180922 : Log Deletion
                oLogDeletion.Init()
                oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                    FormName, _
                    "Crewing", _
                    "tblDocImage", _
                    "FilePath IN ('" & supportingDocs.GetFocusedRowCellValue("FilePath") & "')", _
                    "<< Delete Data - " & FormName & " >>", _
                    LogDeletion.DeletionType.Manual, _
                    "Manually Deleted in <" & FormName & ">", _
                    GetUserName())
                '-->
                If DB.RunSql("DELETE FROM tblDocImage WHERE FilePath = '" & supportingDocs.GetFocusedRowCellValue("FilePath") & "'") Then
                    oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                End If
                Mainview_FocusedRowChanged(Nothing, Nothing)
                If supportingDocs.RowCount = 0 Then Mainview.SetFocusedRowCellValue("hasFile", "No")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
#End Region

#Region "Save/Load Layout"
    Public Overrides Sub SaveMainContentLayout()
        MyBase.SaveMainContentLayout()
        Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
        gvCrewList.SaveLayoutToXml(strLayoutPath & "DMS_gvCrewList_Layout.xml")
        Mainview.SaveLayoutToXml(strLayoutPath & "DMS_Mainview_Layout.xml")
        supportingDocs.SaveLayoutToXml(strLayoutPath & "DMS_supportingDocs_Layout.xml")
        Dim strSplitterPositions As String
        strSplitterPositions = SplitContainerControl1.SplitterPosition & ";" & SplitContainerControl2.SplitterPosition & ";" & SplitContainerControl3.SplitterPosition
        Dim wtr As IO.StreamWriter = System.IO.File.CreateText(strLayoutPath & "DMS_SplitterPositions.txt")
        Using wtr
            wtr.WriteLine(strSplitterPositions)
        End Using
    End Sub

    Public Overrides Sub LoadMainContentLayout()
        Try
            MyBase.LoadMainContentLayout()
            Dim strLayoutPath As String = GetAppPath() & "\Users\" & "Layouts\"
            Dim rdr As IO.StreamReader = System.IO.File.OpenText(strLayoutPath & "DMS_SplitterPositions.txt")
            Dim nSplitterPositions() As String = rdr.ReadLine().ToString.Split(";")
            gvCrewList.RestoreLayoutFromXml(strLayoutPath & "DMS_gvCrewList_Layout.xml")
            Mainview.RestoreLayoutFromXml(strLayoutPath & "DMS_Mainview_Layout.xml")
            supportingDocs.RestoreLayoutFromXml(strLayoutPath & "DMS_supportingDocs_Layout.xml")
            SplitContainerControl1.SplitterPosition = nSplitterPositions(0)
            SplitContainerControl2.SplitterPosition = nSplitterPositions(1)
            SplitContainerControl3.SplitterPosition = nSplitterPositions(2)
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Main View Filter"
    Private Sub UpdMainviewActiveFilter()
        Dim cFilter As New System.Text.StringBuilder

        If strDocFilter.Length > 0 Then
            cFilter.Append(strDocFilter)
        End If

        If strDocGrpFilter.Length > 0 Then
            If cFilter.Length > 0 Then cFilter.Append(" AND ")
            cFilter.Append(strDocGrpFilter)
        End If

        'If strDateIssueFilter.Length > 0 Then
        If cFilter.Length > 0 Then cFilter.Append(" AND ")
        cFilter.Append(" (DateIssue >= #" & Format(Me.dtefrom.EditValue, "MM/dd/yyyy") & "# and DateIssue <=#" & Format(Me.dteTo.EditValue, "MM/dd/yyyy") & "# )")
        'End If

        Mainview.ActiveFilterString = IIf(cFilter.Length > 0, cFilter.ToString, "")
        Debug.Print(cFilter.ToString)

        SetAllowAddition() 'added by tony20171114
    End Sub
#End Region

    Private Sub btnClear2_Click(sender As System.Object, e As System.EventArgs) Handles btnClear2.Click
        luDocGrp.Focus()
        docDT.Rows.Clear()
        Maingrid.DataSource = docDT

        For i As Integer = 0 To gvCrewList.RowCount - 1
            If gvCrewList.GetRowCellValue(i, "IsSelected") = True Then
                gvCrewList.SetRowCellValue(i, "IsSelected", False)
            End If
        Next
    End Sub


    Private Sub btnClearSelection_Click(sender As System.Object, e As System.EventArgs) Handles btnClearSelection.Click
        luDocGrp.Focus()
        For i As Integer = 0 To Mainview.RowCount - 1
            If Mainview.GetRowCellValue(i, "IsSelected") = True Then
                Mainview.SetRowCellValue(i, "IsSelected", False)
            End If
        Next
    End Sub

    '<!-- added by tony20171114
    Private Sub dtefrom_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles dtefrom.ButtonClick
        If e.Button.Kind = ButtonPredefines.Clear Then
            dtefrom.EditValue = Nothing
            oDocFilter.Clear(DocFilter.FilterParam.DateIssueFrom, True)
        End If
    End Sub
    '-->

    Private Sub dtefrom_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles dtefrom.CloseUp
        '<!-- edited by tony20171114
        If IsDBNull(e.Value) = False Then
            If IsNothing(e.Value) = False Then
                ' strDateIssueFilter = " DateIssue between '" & e.Value & "' and '" & Me.dteTo.EditValue & "' "

                'UpdMainviewActiveFilter()
                oDocFilter.SetValue(DocFilter.FilterParam.DateIssueFrom, dtefrom.EditValue, True)
                Exit Sub
            End If
        End If
        '-->

    End Sub

    '<!-- added by tony20171114
    Private Sub dteTo_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles dteTo.ButtonClick
        If e.Button.Kind = ButtonPredefines.Clear Then
            dteTo.EditValue = Nothing
            oDocFilter.Clear(DocFilter.FilterParam.DateIssueTo, True)
        End If
    End Sub
    '-->

    Private Sub dteTo_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles dteTo.CloseUp
        '<!-- edited by tony20171114
        If IsDBNull(e.Value) = False Then
            If IsNothing(e.Value) = False Then
                ' strDateIssueFilter = " DateIssue between '" & dtefrom.EditValue & "' and '" & e.Value & "' "

                'UpdMainviewActiveFilter()
                oDocFilter.SetValue(DocFilter.FilterParam.DateIssueFrom, dteTo.EditValue, True)
                Exit Sub
            End If
        End If
        '-->
    End Sub

    Private Sub dteTo_DateTimeChanged(sender As Object, e As System.EventArgs) Handles dteTo.DateTimeChanged
        'UpdMainviewActiveFilter()  'commented out by tony20171114
        oDocFilter.SetValue(DocFilter.FilterParam.DateIssueFrom, dteTo.EditValue, True)
    End Sub

    Private Sub dtefrom_DateTimeChanged(sender As Object, e As System.EventArgs) Handles dtefrom.DateTimeChanged
        'UpdMainviewActiveFilter()  'commented out by tony20171114
        oDocFilter.SetValue(DocFilter.FilterParam.DateIssueFrom, dtefrom.EditValue, True)
    End Sub

    Private Sub dtefrom_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtefrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            'UpdMainviewActiveFilter()  'commented out by tony20171114
        End If
    End Sub


    Private Sub dteTo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dteTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            'UpdMainviewActiveFilter()  'commented out by tony20171114
        End If
    End Sub

    '<!-- added by tony20171114
    Private Sub btnClearFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnClearFilter.Click
        luDoc.EditValue = ""
        luDocGrp.EditValue = ""
        dtefrom.EditValue = ""
        dteTo.EditValue = ""
        oDocFilter.Clear(True)
        SetAllowAddition()
    End Sub
    '-->
End Class
