Public Class frmVesselRankSelection

    '====================================================================================
    'FLAG
    Public ApplyFilter As Boolean = False
    Public CurrentSelectionChanged As Boolean = False
    Public EditedSelection As Boolean = False
    '====================================================================================

    Public _CurrentSelection As SelectionMode    'IF [Vessel] OR [Rank]
    Public Property CurrentSelection As SelectionMode

        Get
            Return _CurrentSelection
        End Get

        Set(value As SelectionMode)
            CurrentSelectionChanged = (value <> _CurrentSelection)
            _CurrentSelection = value
        End Set
    End Property


    Public DisplayMode As LTPDisplayMode = LTPDisplayMode.AllWithDataOnly
    Public LoadedDisplayMode As LTPDisplayMode

    Public Enum SelectionMode
        None = 0
        Vessel = 1
        Rank = 2
    End Enum

    Private ListOfSelectionCriteria As New List(Of SelectionCriteria)
    Private oSelectionCriteria As SelectionCriteria

    Private Class SelectionCriteria
        Public Mode As String = ""
        Public SelectedDisplayMode As LTPDisplayMode = LTPDisplayMode.AllWithDataOnly
        Public FieldNameToCompareWith As String = ""
        Public Condition As String = ""
        Public DataSource As DataTable = Nothing
    End Class
    Public ReadOnly Property Condition As String
        Get
            If DisplayMode = LTPDisplayMode.Selected Then
                Condition = ConstructCondition(oSelectionCriteria.FieldNameToCompareWith)
                If IfNull(Condition, "").Length = 0 Then
                    Condition = "'SHOW DATA' = 'NO'"
                End If
            Else
                Condition = ""
            End If
        End Get
    End Property

    Public ReadOnly Property Condition(FieldNameToCompareWith As String) As String
        Get
            If DisplayMode = LTPDisplayMode.Selected Then
                Condition = ConstructCondition(FieldNameToCompareWith)
                If IfNull(Condition, "").Length = 0 Then
                    Condition = "'SHOW DATA' = 'NO'"
                End If
            Else
                Condition = ""
            End If
        End Get
    End Property

    Public Sub LoadData(_SelectionMode As SelectionMode)
        Dim dt As DataTable


        Try
            Select Case _SelectionMode
                Case SelectionMode.Rank
                    oSelectionCriteria = InitSelectionCriteria("RANK")
                    dt = oSelectionCriteria.DataSource
                    colPKey.FieldName = "PKey"
                    colName.FieldName = "Name"

                Case SelectionMode.Vessel
                    oSelectionCriteria = InitSelectionCriteria("VESSEL")
                    dt = oSelectionCriteria.DataSource
                    colPKey.FieldName = "PKey"
                    colName.FieldName = "Name"

                Case Else
                    dt = Nothing
            End Select

            If Not IsNothing(dt) Then
                AddSelectedColumnTodDataSourceObject(dt)
            End If

            MainGrid.DataSource = dt
            MainGrid.Visible = Not IsNothing(dt)

        Catch ex As Exception
            MainGrid.DataSource = Nothing
        End Try
        'End If



    End Sub

    Private Sub PreselectItems(cCondition As String)
        Dim dv As DataView = New DataView(MainGrid.DataSource)

        If IfNull(cCondition, "").Length = 0 Then Exit Sub

        dv.RowFilter = colPKey.FieldName & " IN (" & cCondition & ")"

        Dim arr As New ArrayList


        For i As Integer = 0 To dv.Count - 1
            arr.Add(dv(i).Item(colPKey.FieldName))
        Next

        Dim Col As DevExpress.XtraGrid.Columns.GridColumn = MainView.Columns(colPKey.Name)
        For i As Integer = 0 To MainView.RowCount - 1
            If arr.Contains(MainView.GetRowCellValue(i, colPKey.FieldName)) Then
                MainView.SetRowCellValue(i, "Selected", True)

            Else
                MainView.SetRowCellValue(i, "Selected", False)
            End If
            
        Next

        EditedSelection = False

    End Sub

    Private Function InitSelectionCriteria(cMode As String) As SelectionCriteria
        Dim currSelectionCriteria As SelectionCriteria = Nothing
        Dim cCondition As String = ""
        Dim tmpDisplayMode As String


        '============================================================================================================================================
        'Get Saved User Config Condition & DisplayMode
        MPSDB.BeginReader("SELECT * FROM dbo.tblUserConfig WHERE Code IN ('LTP_SEL_" & cMode & "_DisplayMode', 'LTP_SEL_" & cMode & "_Condition') AND FKeyUserID = " & IfNull(USER_ID, 0))
        DisplayMode = LTPDisplayMode.AllWithDataOnly
        While MPSDB.Read
            If IfNull(MPSDB.ReaderItem("Code"), "").Equals("LTP_SEL_" & cMode & "_DisplayMode") Then
                tmpDisplayMode = IfNull(MPSDB.ReaderItem("Value"), "")
                If Not IsNumeric(tmpDisplayMode) Then
                    DisplayMode = LTPDisplayMode.AllWithDataOnly
                Else
                    DisplayMode = CInt(tmpDisplayMode)
                End If

            ElseIf IfNull(MPSDB.ReaderItem("Code"), "").Equals("LTP_SEL_" & cMode & "_Condition") Then
                cCondition = IfNull(MPSDB.ReaderItem("Value"), "")
            End If
        End While
        MPSDB.CloseReader()


        '============================================================================================================================================
        'CHECKS IF EXISTS IN FLOATING SOURCE
        currSelectionCriteria = ListOfSelectionCriteria.Find(Function(o As SelectionCriteria) o.Mode = cMode)
        If currSelectionCriteria Is Nothing Then
            currSelectionCriteria = New SelectionCriteria

            With currSelectionCriteria
                .Mode = cMode
                
                Select Case cMode
                    Case "RANK"
                        .DataSource = MPSDB.CreateTable("SELECT * FROM dbo.tbladmrank ORDER BY Name")
                        .FieldNameToCompareWith = "adm.PKey"

                    Case "VESSEL"
                        USER_INFO.InitFilteredUserData(UserDetail.FilteredUserDataTables.VesselActOnly)
                        .DataSource = USER_INFO.FilteredVesselActiveOnlyDT
                        .FieldNameToCompareWith = "adm.PKey"

                    Case Else
                        .DataSource = Nothing
                End Select

            End With

            ListOfSelectionCriteria.Add(currSelectionCriteria)


        End If
        currSelectionCriteria.SelectedDisplayMode = DisplayMode
        currSelectionCriteria.Condition = cCondition


        Return currSelectionCriteria

    End Function

#Region "Related to Selected Column"
    ''' <summary>
    ''' Adds 'Selected' column to datatable if does not exist.
    ''' </summary>
    Private Sub AddSelectedColumnTodDataSourceObject(ByRef DataSourceObject As DataTable)

        If DataSourceObject.Columns("Selected") Is Nothing Then
            Dim col As New DataColumn
            col.ColumnName = "Selected"
            col.DataType = System.Type.GetType("System.Boolean")
            DataSourceObject.Columns.Add(col)

            For i As Integer = 0 To DataSourceObject.Rows.Count - 1
                DataSourceObject.Rows(i).Item("Selected") = False
            Next


        End If
    End Sub

#End Region

    Public Function ConstructCondition(FieldNameToCompareWith As String) As String
        Dim returnvalue As String = ConstructCondition()

        If IfNull(returnvalue, "").Length > 0 Then
            returnvalue = FieldNameToCompareWith & " IN (" & returnvalue & ") " 'AND " & FieldNameToCompareWith & " is not null "
        End If

        Return returnvalue
    End Function


    Public Function ConstructCondition() As String
        Dim returnvalue As String = ""
        cmdSelectAllDisplayed.Focus()
        'LayoutControl_Main.Focus()
        If Not IsNothing(MainGrid.DataSource) Then
            Dim dv As DataView = New DataView(MainGrid.DataSource)
            dv.RowFilter = "Selected = true"
            If dv.Count > 0 Then
                For dvctr As Integer = 0 To dv.Count - 1
                    returnvalue = returnvalue & IIf(Len(IfNull(returnvalue, "")) > 0, ", ", "") & _
                          "'" & dv(dvctr).Item(colPKey.FieldName) & "'"
                Next

            End If
        End If

        Return returnvalue
    End Function

    Private Sub cmdSelectAllShown_Click(sender As System.Object, e As System.EventArgs) Handles cmdSelectAllDisplayed.Click
        MainView.BeginDataUpdate()
        For i As Integer = 0 To Me.MainView.DataRowCount - 1
            MainView.SetRowCellValue(i, "Selected", True)
        Next
        MainView.EndDataUpdate()
    End Sub

    Private Sub cmdDeselectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeselectAll.Click
        Dim dt As DataTable = Nothing

        Try
            dt = TryCast(MainGrid.DataSource, DataTable)
        Catch ex As Exception
            dt = Nothing
        End Try

        If Not dt Is Nothing Then
            MainView.BeginDataUpdate()
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("Selected") = False
            Next
            MainView.EndDataUpdate()
        End If

        MainGrid.DataSource = dt
    End Sub



    Public Sub RefreshForm()

        Init()

        'LOAD DATA
        If CurrentSelectionChanged Then
            LoadData(CurrentSelection)
        End If
        CurrentSelectionChanged = False

        PreselectItems(oSelectionCriteria.Condition)

        SelectDisplayMode(DisplayMode)

    End Sub

    Private Sub Init()
        ApplyFilter = False
        MainView.ApplyFindFilter("")
        MainView.ActiveFilterString = ""
        chkShowAllSelectedOnly.Checked = False
        EditedSelection = False
    End Sub

    Private Sub PressDownDisplayModeButton()
        'CHECKS WHICH BUTTON TO INITIALLY PRESS
        Select Case DisplayMode
            Case LTPDisplayMode.All
                btnShowAll.Down = True

            Case LTPDisplayMode.AllWithDataOnly
                btnShowAllWithDataOnly.Down = True

            Case LTPDisplayMode.Selected
                btnSelect.Down = True
        End Select
    End Sub

    Private Enum OptionMode
        ShowAll = 1
        ShowAllWithDataOnly = 2
        WithSelection = 3
    End Enum

    Private Sub btnShowAll_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowAll.ItemClick
        SelectDisplayMode(LTPDisplayMode.All)
    End Sub

    Private Sub btnShowAllWithDataOnly_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShowAllWithDataOnly.ItemClick
        SelectDisplayMode(LTPDisplayMode.AllWithDataOnly)
    End Sub

    Private Sub btnSelect_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSelect.ItemClick
        SelectDisplayMode(LTPDisplayMode.Selected)
    End Sub

    Private Sub cmdOK_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdOK.ItemClick
        MainView.UpdateCurrentRow()
        '====================================================================================================================================
        'validate
        If DisplayMode = LTPDisplayMode.Selected Then
            Dim dv As DataView = New DataView(MainGrid.DataSource)
            dv.RowFilter = "Selected = true"
            If dv.Count = 0 Then
                MsgBox("There are no item(s) selected.", MsgBoxStyle.Information)
                Return
            End If

            'cmdDeselectAll.Focus()
            'MainGrid.Focus()
        End If
        '====================================================================================================================================

        ApplyFilter = True
        If EditedSelection Then
            oSelectionCriteria.Condition = ConstructCondition()
            SaveUserSetting("LTP_SEL_" & oSelectionCriteria.Mode & "_Condition", oSelectionCriteria.Condition.Replace("'", "''"))
        End If
        EditedSelection = False

        '====================================================================================================================================
        'Save In UserConfig
        SaveUserSetting("LTP_SEL_" & oSelectionCriteria.Mode & "_DisplayMode", DisplayMode)

        Me.Hide()
    End Sub

    Private Sub cmdCancel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancel.ItemClick
        If EditedSelection Then
            PreselectItems(oSelectionCriteria.Condition)
        End If
        ApplyFilter = False
        EditedSelection = False
        DisplayMode = LoadedDisplayMode
        PressDownDisplayModeButton()

        Me.Hide()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(InitialSelectionMode As SelectionMode) ', InitialDisplayMode As SelectionMode)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CurrentSelection = InitialSelectionMode
        'DisplayMode = InitialDisplayMode
        RefreshForm()

    End Sub

    Private Sub SelectDisplayMode(_DisplayMode As LTPDisplayMode)
        DisplayMode = _DisplayMode

        oSelectionCriteria.SelectedDisplayMode = _DisplayMode

        LayoutControlGroupOptions.Enabled = (DisplayMode = LTPDisplayMode.Selected)

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'CHECK WHAT LAYOUTCONTROLGROUP SHOULD BE SHOWN
        LayoutControlGroupSelect.Visibility = IIf(DisplayMode = LTPDisplayMode.Selected, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
        LayoutControlGroupShowAll.Visibility = IIf(DisplayMode = LTPDisplayMode.All, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
        LayoutControlGroupShowAllWithData.Visibility = IIf(DisplayMode = LTPDisplayMode.AllWithDataOnly, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)

        If LayoutControlGroupSelect.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always Then MainGrid.Focus()

        '------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'UPDATES NOTE LABEL
        Dim cAllCaption As String = "This will show all [CurrentSelection] regardless whether there are Onboard/Planned Crews"
        Dim cAllWithDataOnlyCaption As String = "This will show all [CurrentSelection] with Onboard/Planned Crews Only"
        Dim cTextToReplace As String = "[CurrentSelection]"

        Select Case CurrentSelection
            Case SelectionMode.Vessel
                lblShowAll.Text = cAllCaption.Replace(cTextToReplace, "Vessels")
                lblShowAllWithDataOnly.Text = cAllWithDataOnlyCaption.Replace(cTextToReplace, "Vessels")

            Case SelectionMode.Rank
                lblShowAll.Text = cAllCaption.Replace(cTextToReplace, "Ranks")
                lblShowAllWithDataOnly.Text = cAllWithDataOnlyCaption.Replace(cTextToReplace, "Ranks")

            Case Else
                lblShowAll.Text = cAllCaption.Replace(" " & cTextToReplace, "")
                lblShowAllWithDataOnly.Text = cAllWithDataOnlyCaption.Replace(" " & cTextToReplace, "")
        End Select

        PressDownDisplayModeButton()
    End Sub


    Private Sub frmVesselRankSelection_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        LoadedDisplayMode = DisplayMode
        RefreshForm()
    End Sub

    Private Sub repCheckEdit_CheckStateChanged(sender As Object, e As System.EventArgs) Handles repCheckEdit.CheckStateChanged
        MainView.PostEditor()
    End Sub

    Private Sub chkShowAllSelectedOnly_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowAllSelectedOnly.CheckedChanged
        If chkShowAllSelectedOnly.Checked Then
            MainView.ActiveFilterString = "Selected = true"
        Else
            MainView.ActiveFilterString = ""
        End If
    End Sub

    Private Sub MainView_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MainView.CellValueChanged
        EditedSelection = True
    End Sub
End Class