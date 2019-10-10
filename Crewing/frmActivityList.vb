Public Class frmActivityList
    Dim strCrewID As String = ""
    Dim sql As String = ""
    Dim dt As New DataTable
    Dim Default_FirstActBGColor As System.Drawing.Color = EDITED_COLOR
    Dim Default_FirstActTextColor As System.Drawing.Color = System.Drawing.Color.Black

    Dim FirstActBGColor As System.Drawing.Color = Default_FirstActBGColor
    Dim FirstActTextColor As System.Drawing.Color = Default_FirstActTextColor

    Public Sub New(ByVal IDNbr As String)
        InitializeComponent()
        strCrewID = IDNbr

        FirstActBGColor = System.Drawing.Color.FromArgb(GetUserSetting("FirstActBGColor", CStr(FirstActBGColor.ToArgb)))
        btiBGActColor.EditValue = FirstActBGColor
        FirstActTextColor = System.Drawing.Color.FromArgb(GetUserSetting("FirstActTextColor", CStr(FirstActTextColor.ToArgb)))
        beiActTextColor.EditValue = FirstActTextColor

        btnPlanDetails.Down = False

        Dim images As DevExpress.Utils.ImageCollection = New DevExpress.Utils.ImageCollection()
        images.ImageSize = New System.Drawing.Size(12, 12)
        images.AddImage(My.Resources.Extended_Contract_v2_16x16)
        images.AddImage(Nothing)
        RepositoryItemImageComboBox1.SmallImages = images
        RepositoryItemImageComboBox1.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 0))
        RepositoryItemImageComboBox1.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, 1))

        btnActivities_ItemClick(Nothing, Nothing)
    End Sub

    Private Sub btnActivities_DownChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnActivities.DownChanged
        If btnActivities.Down Then
            RibbonPageGroup2.Visible = True
        Else
            RibbonPageGroup2.Visible = False
        End If
    End Sub

    Private Sub btnActivities_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnActivities.ItemClick
        dt = New DataTable

        'sql = "SELECT caa.[ActivityType],caa.[Status],caa.[Vessel],caa.[Rank],caa.[DateStarted],caa.[DateEnded],caa.[DueDate],caa.[LOC],caa.[StartingPlace],caa.[EndingPlace],ws.[WageScale],caa.[AgentName],caa.[PrinName],caa.[Remarks],caa.[rn] " & _
        '"From [Crewlist_Activities_All] caa LEFT JOIN dbo.WAGESCALE ws ON caa.FKeyWScaleRankCode = ws.WScaleRankCode " & _
        '"WHERE IDNbr = '" & strCrewID & "'  " & _
        '"ORDER BY [DateStarted] DESC"

        sql = "SELECT caa.[ActivityType],caa.[Status],caa.[Vessel],caa.[Rank],caa.[DateStarted],caa.[DateEnded],dbo.GET_EXTDATEDUE(caa.ActGrpID) AS DueDate,caa.[LOC],caa.[StartingPlace],caa.[EndingPlace],ws.[WageScale],caa.[AgentName],caa.[PrinName],caa.[Remarks],caa.[rn],caa.[ActDateDep],caa.[ActDateArr],caa.[ActDateSOn],caa.[ActDateSOff],caa.[ActID], " &
        "CASE WHEN (SELECT COUNT(*) FROM tblContractExt WHERE FKeyActivityID = caa.[ActID]) > 0 THEN 1 ELSE 0 END AS IsExtended " & _
        "From [Crewlist_Activities_All] caa LEFT JOIN dbo.WAGESCALE ws ON caa.FKeyWScaleRankCode = ws.WScaleRankCode " & _
        "WHERE IDNbr = '" & strCrewID & "'  " & _
        "ORDER BY [DateStarted] DESC"

        dt = MPSDB.CreateTable(sql)
        Maingrid.DataSource = dt
        lcgLeaveDay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lciPlan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lciAct.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        RibbonPageGroup2.Visible = True
        btnPlanDetails.Down = False
        btnLDHistory.Down = False
    End Sub

    Private Sub btnPlanDetails_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPlanDetails.ItemClick
        dt = New DataTable

        sql = "SELECT [Rank],[Vessel],[PlannedDateSON],[PlannedPlaceSON] " & _
        "From [Crew_Planning_All]  " & _
        "WHERE IDNbr = '" & strCrewID & "'  " & _
        "ORDER BY [PlannedDateSON] ASC"

        dt = MPSDB.CreateTable(sql)
        PlanGrid.DataSource = dt

        lciPlan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        lciAct.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcgLeaveDay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        btnActivities.Down = False
        btnLDHistory.Down = False
        RibbonPageGroup2.Visible = False
    End Sub

    Private Sub btnLDHistory_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnLDHistory.ItemClick
        dt = New DataTable

        dt = MPSDB.CreateTable("SELECT * FROM [frmLeaveDays_Datasource] WHERE IDNbr = '" & strCrewID & "' ORDER BY ActDateStart DESC")
        LDGrid.DataSource = dt

        If dt.Rows.Count > 0 Then
            txtTotalDays.EditValue = dt.Compute("SUM(LDEarn)", "")
            txtTotalPay.EditValue = dt.Compute("SUM(LPEarn)", "")
            txtConsumedDays.EditValue = dt.Compute("SUM(LDConsumed)", "")
            txtConsumedPay.EditValue = dt.Compute("SUM(LPConsumed)", "")
            txtRemainingDays.EditValue = (txtTotalDays.EditValue - txtConsumedDays.EditValue)
            txtRemainingPay.EditValue = (txtTotalPay.EditValue - txtConsumedPay.EditValue)
        End If

        lciPlan.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lciAct.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        lcgLeaveDay.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        btnActivities.Down = False
        btnPlanDetails.Down = False
        RibbonPageGroup2.Visible = False
    End Sub


    Private Sub btnClose_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
        Me.Close()
    End Sub

    Private Sub Mainview_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles Mainview.PopupMenuShowing
        If Not IsNothing(e.Menu) Then
            Dim mItem As New DevExpress.Utils.Menu.DXMenuItem("Contract Extensions", AddressOf ShowContractExtensions)
            e.Menu.Items.Add(mItem)
        End If
    End Sub

    Private Sub Mainview_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles Mainview.RowCellClick
        If e.Column.FieldName = "IsExtended" Then
            If e.CellValue <> 0 Then
                ShowContractExtensions()
            End If
        End If
    End Sub

    Private Sub Mainview_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Mainview.RowCellStyle
        ViewRowCellStyle(sender, e)

        Dim v As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If v.GetRowCellValue(e.RowHandle, "rn").Equals(CLng(1)) Then
            e.Appearance.BackColor = FirstActBGColor
            e.Appearance.ForeColor = FirstActTextColor
        End If
    End Sub

    Private Sub btiActColor_EditValueChanged(sender As Object, e As System.EventArgs) Handles btiBGActColor.EditValueChanged
        FirstActBGColor = btiBGActColor.EditValue
        SaveUserSetting("FirstActBGColor", FirstActBGColor.ToArgb)
        Mainview.LayoutChanged()
    End Sub

    Private Sub beiActTextColor_EditValueChanged(sender As Object, e As System.EventArgs) Handles beiActTextColor.EditValueChanged
        FirstActTextColor = beiActTextColor.EditValue
        SaveUserSetting("FirstActTextColor", FirstActTextColor.ToArgb)
        Mainview.LayoutChanged()
    End Sub

    Private Sub repBGColor_ButtonPressed(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repBGColor.ButtonPressed
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            btiBGActColor.EditValue = Default_FirstActBGColor
            'SaveUserSetting("FirstActBGColor", Nothing) 'BackGround Color
        End If
    End Sub

    Private Sub repTextColor_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles repTextColor.ButtonPressed
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            beiActTextColor.EditValue = Default_FirstActTextColor
            'SaveUserSetting("FirstActTextColor", Nothing) 'Text Color
        End If
    End Sub

    Private Sub ShowContractExtensions()
        Dim contExt As New frmContractExtensions(Mainview.GetFocusedRowCellValue("ActID"))
        If contExt.hasData Then
            contExt.StartPosition = FormStartPosition.CenterParent
            contExt.ShowDialog()
        Else
            MsgBox("The selected activity has no contract extension.", vbInformation + vbOKOnly, GetAppName)
        End If
    End Sub

End Class