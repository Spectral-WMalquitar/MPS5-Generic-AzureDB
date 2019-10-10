Public Class frmAddFromPlanningEvent

    Public AddIsClicked As Boolean = False

    Public VesselCode As String
    Public PlaceSOnCode As String
    Public PlanningEventKey As String

    Private FormIsLoaded As Boolean = False
    Dim dtPlanningEvent As DataTable

    Public Property PlanningEventDataSource As DataTable

        Get
            Return dtPlanningEvent
        End Get
        Set(value As DataTable)
            dtPlanningEvent = value
            cboPlanningEvent.Properties.DataSource = dtPlanningEvent
        End Set
    End Property



    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        InitControls()
        InitLookupEdits()
        SetupPlanningEventLookupEdit()


    End Sub

    Private Sub InitControls()
        txtPlanningEvent.Properties.ReadOnly = True
        txtVessel.Properties.ReadOnly = True
        txtPlannedDateSOn.Properties.ReadOnly = True
        txtPlannedPlaceSOn.Properties.ReadOnly = True
        txtRemarks.Properties.ReadOnly = True
        MainView.OptionsBehavior.ReadOnly = True
        cboPlanningEvent.BackColor = System.Drawing.Color.White
    End Sub

    Private Sub InitLookupEdits()
        'Dim dt As New DataTable
        'Dim cSQL As String

        ''Planning Event
        'cSQL = "SELECT pe.PKey, concat(vsl.name, ' / ', format(pe.planneddateson, 'dd-MMM-yyyy')) as PlanningEventLabel, pe.PlanningEvent, pe.FKeyVessel, vsl.Name as Vessel, format(pe.PlannedDateSON,'dd-MMM-yyyy') as PlannedDateSignOn, pe.PlannedPlaceSON, port.Name as PlannedPlaceSignOn, pe.Remarks " & _
        '       "FROM	dbo.tblPlanningEvent pe INNER JOIN " & _
        '       "        (SELECT FKeyPlanningEvent FROM dbo.tblPlanningEventCrew WHERE FKeyActivity is null GROUP BY FKeyPlanningEvent) pendingPEvent ON pendingPEvent.FKeyPlanningEvent = pe.PKey INNER JOIN " & _
        '       "        dbo.tbladmvsl vsl ON pe.FKeyVessel = vsl.PKey LEFT JOIN " & _
        '       "        dbo.tbladmport port ON pe.PlannedPlaceSON = port.PKey " & _
        '       "ORDER BY vsl.Name, pe.planneddateson desc "

        'dtPlanningEvent = New DataTable
        'dtPlanningEvent = MPSDB.CreateTable(cSQL)
        cboPlanningEvent.Properties.DataSource = dtPlanningEvent
    End Sub

    Public Sub LoadPlanningEvent(PlanningEventKey As String)
        ClearFields()

        If IfNull(cboPlanningEvent.EditValue, "").Length > 0 Then
            Dim dv As DataView = New DataView(dtPlanningEvent)
            dv.RowFilter = "PKey = '" & PlanningEventKey & "'"
            If dv.Count > 0 Then
                Dim dt As DataTable = Nothing
                Try
                    PlanningEventKey = dv(0).Item("PKey")
                    VesselCode = dv(0).Item("FKeyVessel")
                    PlaceSOnCode = IfNull(dv(0).Item("PlannedPlaceSON"), String.Empty)
                    txtPlanningEvent.EditValue = IfNull(dv(0).Item("PlanningEvent"), String.Empty)
                    txtVessel.EditValue = IfNull(dv(0).Item("Vessel"), String.Empty)
                    txtPlannedDateSOn.EditValue = IfNull(dv(0).Item("PlannedDateSignOn"), "")
                    txtPlannedPlaceSOn.EditValue = IfNull(dv(0).Item("PlannedPlaceSignOn"), String.Empty)
                    txtRemarks.EditValue = IfNull(dv(0).Item("Remarks"), String.Empty)

                    Dim cSQL As String
                    cSQL = "SELECT	dbo.AssembleName(ci.lname, ci.fname, ci.mname, 1, 1, 0, 0, 0) CrewName, " & _
                                                            "       pec.* " & _
                                                            "FROM	dbo.tblPlanningEventCrew pec INNER JOIN " & _
                                                            "       dbo.tblCrewInfo ci ON pec.CrewID = ci.PKey " & _
                                                            "WHERE	pec.FKeyPlanningEvent = '" & PlanningEventKey & "' AND pec.FKeyActivity is null"
                    dt = MPSDB.CreateTable(cSQL)

                Catch ex As Exception
                    LogErrors(ex.Message)
                    MsgBox("Failed to get list of planned crews.", MsgBoxStyle.Exclamation)
                    dt = Nothing
                End Try

                MainGrid.DataSource = dt
                MainView.Columns("CrewName").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            Else
                MsgBox("Failed to retrieve details of the selecte planning event [" & cboPlanningEvent.Text & "].", MsgBoxStyle.Exclamation)
                cboPlanningEvent.EditValue = ""
            End If
        End If

    End Sub

    Private Sub LoadPlanningEventCrews(PlanningEventKey As String)
        Dim dt As DataTable

        Try
            dt = MPSDB.CreateTable("SELECT		dbo.AssembleName(ci.lname, ci.fname, ci.mname, 1, 1, 0, 0, 0) CrewName, Rank " & _
                                   "FROM		dbo.tblPlanningEventCrew pc INNER JOIN " & _
                                   "            dbo.tblCrewInfo ci ON pc.CrewID = ci.PKey " & _
                                   "WHERE		pc.FKeyPlanningEvent = '" & PlanningEventKey & "' AND pc.FKeyActivity is null " & _
                                   "ORDER BY    ci.lname, ci.fname, ci.mname")
        Catch ex As Exception
            dt = Nothing
        End Try

        MainGrid.DataSource = dt
    End Sub

    Private Sub ClearFields()
        txtPlanningEvent.EditValue = String.Empty
        txtVessel.EditValue = String.Empty
        txtPlannedDateSOn.EditValue = String.Empty
        txtPlannedPlaceSOn.EditValue = String.Empty
        txtRemarks.EditValue = String.Empty
        VesselCode = String.Empty
        PlanningEventKey = String.Empty
        PlaceSOnCode = String.Empty
        MainGrid.DataSource = Nothing
    End Sub

    Private Sub btnAddPlanningEvent_Click(sender As System.Object, e As System.EventArgs) Handles btnAddPlanningEvent.Click
        If IfNull(cboPlanningEvent.EditValue, "").Equals("") Then
            MsgBox("You must select a planning event.", MsgBoxStyle.Exclamation)
            cboPlanningEvent.Focus()
            Exit Sub
        End If

        If MsgBox("Do you want to continue to add from this planning event?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            AddIsClicked = True
            Me.Close()
        End If
        
    End Sub

    Private Sub cboPlanningEvent_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPlanningEvent.EditValueChanged
        If FormIsLoaded Then
            If Not IfNull(cboPlanningEvent.EditValue, "").Equals("") Then
                LoadPlanningEvent(cboPlanningEvent.EditValue)
            End If
        End If
    End Sub

    Private Sub frmAddFromPlanningEvent_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        FormIsLoaded = True
    End Sub

    Private Sub SetupPlanningEventLookupEdit()
        Dim repCtl As DevExpress.XtraEditors.SearchLookUpEdit = cboPlanningEvent
        Dim gcol As DevExpress.XtraGrid.Columns.GridColumn
        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "PKey"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "PlanningEventLabel"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = False
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "Vessel"
        gcol.FieldName = gcol.Name
        gcol.Caption = gcol.Name
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "PlannedDateSignOn"
        gcol.Caption = "Planned Date"
        gcol.FieldName = gcol.Name
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        gcol = New DevExpress.XtraGrid.Columns.GridColumn
        gcol.Name = "PlannedPlaceSignOn"
        gcol.Caption = "Place Sign On"
        gcol.FieldName = gcol.Name
        gcol.Visible = True
        repCtl.Properties.View.Columns.Add(gcol)

        With repCtl.Properties
            .ValueMember = "PKey"
            .DisplayMember = "PlanningEventLabel"
            .NullText = String.Empty
            .ShowFooter = False
            .AppearanceFocused.BackColor = EDITED_FOCUSED_COLOR
        End With
    End Sub

    Private Sub txtPlannedDateSOn_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPlannedDateSOn.QueryPopUp
        Dim dateedit As DevExpress.XtraEditors.DateEdit = TryCast(sender, DevExpress.XtraEditors.DateEdit)
        e.Cancel = dateedit.Enabled Or dateedit.Properties.ReadOnly
    End Sub
End Class