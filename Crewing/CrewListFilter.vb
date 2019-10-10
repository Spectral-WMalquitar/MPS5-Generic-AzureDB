Public Class CrewListFilter
    Dim dttblAdmVsl As New DataTable
    Dim sCompetenceID As String
    Public clickedApply As Boolean = False

    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        Dim tblVsl As DataTable = MPSDB.CreateTable("SELECT PKey,Name,Abbrv FROM dbo.VslList ORDER BY Name ASC")
        Dim tblStatType As DataTable = GetStatType().Select("PKey <> '2'").CopyToDataTable
        Dim dt As DataTable = MPSDB.CreateTable("SELECT PKey,Name,StatType FROM dbo.tblAdmStat WHERE StatType<>2 ORDER BY Name,SortCode ASC")
        'tony20160831
        'dttblAdmVsl = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.VesselAll, USER_INFO.RefreshMode).Select("VslStat<>2").CopyToDataTable 'tblVsl 
        Dim tmpdt As DataTable = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.VesselAll, USER_INFO.RefreshMode)
        If tmpdt.Rows.Count > 0 Then
            dttblAdmVsl = tmpdt.Select("VslStat<>2").CopyToDataTable
            Dim dv As DataView = New DataView(tmpdt)
            dv.Sort = "Name asc"
            dttblAdmVsl = dv.ToTable
        Else
            dttblAdmVsl = tmpdt
        End If
        'end tony

        With Me
            .cboStatType.Properties.DataSource = tblStatType
            .cboStatCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name,StatType FROM dbo.tblAdmStat WHERE StatType<>2 ORDER BY Name,SortCode ASC")
            .cboSOFFStat.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name,StatType FROM dbo.tblAdmStat WHERE StatType=2 ORDER BY Name,SortCode ASC")
            .cboFkeyRankCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name,Abbrv FROM dbo.RankList ORDER BY SortCode ASC")
            .cboFKeyRankTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRankType ORDER BY SortCode ASC")
            .cboFKeyRankGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRankGrp ORDER BY SortCode ASC")
            .cboCertCap.Properties.DataSource = ""
            .cboNat.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Nat FROM dbo.CntryList ORDER BY Nat ASC")   'fixed by tony20180815 - changed Name to Nat
            .cboFKeyPrinCode.Properties.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Principal, USER_INFO.RefreshMode)
            .cboFKeyAgentCode.Properties.DataSource = USER_INFO.getFilteredUserDataDT(UserDetail.FilteredUserDataTables.Agent, USER_INFO.RefreshMode)
            .cboFkeyWScaleCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmWScale ORDER BY Name ASC")
            .cboFKeyQualifcationVessel.Properties.DataSource = MPSDB.CreateTable("SELECT PKey, Name FROM dbo.tblAdmComp ORDER BY Name ASC")
            Dim prinFilter As String = IIf(GetUserFilterString(, , "PKey").Length > 0, " WHERE " & GetUserFilterString(, , "PKey"), "")
            .cboFKeyPrinCode.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.PrincipalList " & prinFilter & " ORDER BY Name ")
            'Status Type
            If Not IsNothing(cboStatType.EditValue) Then
                If cboStatType.EditValue = "1" Then
                    lciSOFFStat.Enabled = False
                Else
                    lciSOFFStat.Enabled = True
                End If

                Dim dtStatCode As DataTable = dt.Select("StatType='" & cboStatType.EditValue & "'").CopyToDataTable
                cboStatCode.Properties.DataSource = dtStatCode
            Else
                cboStatCode.Properties.DataSource = dt
                lciSOFFStat.Enabled = True
            End If

            'PLanned Vessel List
            If chkPlannedCrew.Checked Then
                cboFKeyVslCode.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.frm_PlannedVslList ORDER BY Name")
            Else
                .cboFKeyVslCode.Properties.DataSource = dttblAdmVsl
            End If
            cboFKeyVslGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslGrp ORDER BY Name")
            cboFKeyVslTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslType ORDER BY Name")
        End With

        If MAIN_CONTENT = "LTP" Then RibbonPageGroup1.Visible = False

        ArchiveFiltering()

        'txtExpDocDays.EditValue = GetUserSetting(UserSettingCode.DocExpDays, 30)
        'lblExpDueDays.Text = GetUserSetting(UserSettingCode.DueDateExpDays, 30)
        chkExpiring.Text = "Crews With Documents To Expire Within " & GetUserSetting(UserSettingCode.DocExpDays, 30) & " Days"
        chkContractEnding.Text = "Crews With Contracts To Due Within " & GetUserSetting(UserSettingCode.DueDateExpDays, 30) & " Days"

        EnableFilterByAge(chkFilterByAge.Checked)
    End Sub

    Private Sub ArchiveFiltering()
        If SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews") Then
            lciLabel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            lciArchiveNoMonths.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            FilterSeparator.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        Else
            lciLabel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            lciArchiveNoMonths.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            FilterSeparator.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        End If
    End Sub

    'Load Item Values
    Private Sub LoadItemValue(cContainer() As DevExpress.XtraLayout.LayoutControlGroup)
        Dim strFilter As String = strCrewListFilter
        Dim strItem As String = ""
        Dim sep() As String = {"AND", "OR"}
        Dim word() As String = strFilter.Split(sep, StringSplitOptions.RemoveEmptyEntries)
        Dim str As String = ""
        For x As Integer = 0 To word.Count - 1
            'strItem = Trim(word(x))
            SetControlValue(Trim(word(x)), cContainer)
            'str = str + Trim(word(x)) & "==||=="
        Next
        'MsgBox(str)
    End Sub

    Private Sub SetControlValue(strItem As String, cContainer() As DevExpress.XtraLayout.LayoutControlGroup)
        Dim ctrName As String = ""
        Dim ctrValue As String = ""
        ctrName = Trim(strItem.Substring(strItem.IndexOf("["c) + 1, strItem.IndexOf("]"c) - 1))
        ctrValue = Trim(strItem.Substring(strItem.IndexOf("="c)).Replace("'", "").Replace("=", ""))
        For Each cont As DevExpress.XtraLayout.LayoutControlGroup In cContainer
            For x As Integer = 0 To cont.Items.Count - 1
                If TypeOf (cont.Items(x)) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim cItem As DevExpress.XtraLayout.LayoutControlItem = TryCast(cont.Items(x), DevExpress.XtraLayout.LayoutControlItem)
                    If TypeOf (cItem) Is DevExpress.XtraLayout.LayoutControlItem And Not TypeOf (cItem) Is DevExpress.XtraLayout.EmptySpaceItem Then
                        Dim ctr As Control = cItem.Control
                        If ctrName.Equals("hasExpContract") Then 'HasExpDoc
                            If ctrValue.Equals("1") Then
                                chkContractEnded.Checked = True
                            Else ''If ctrValue.Equals("2") Then
                                chkContractEnding.Checked = True
                            End If
                        ElseIf ctrName.Equals("hasExpDoc") Then 'HasExpDoc
                            If ctrValue.Equals("1") Then
                                chkExpired.Checked = True
                            Else ''If ctrValue.Equals("2") Then
                                chkExpiring.Checked = True
                            End If
                        ElseIf ctrName.Equals("FKeyPlannedVsl") Then
                            If ctrValue.Equals("1") Then
                                chkPlannedCrew.Checked = True
                            Else
                                chkPlannedCrew.Checked = False
                            End If
                        Else
                            If Mid(ctr.Name, 4) = ctrName Then
                                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then
                                    If ctr.Tag = "Text" Then
                                        TryCast(ctr, DevExpress.XtraEditors.TextEdit).Text = ctrValue
                                    ElseIf ctr.Tag = "Code" Then
                                        TryCast(ctr, DevExpress.XtraEditors.TextEdit).EditValue = ctrValue
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        Next
    End Sub
    'load
    Private Sub CrewListFilter_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.LayoutControl1.AllowCustomization = False
        initControls()
        clickedApply = False
        'LoadItemValue(New DevExpress.XtraLayout.LayoutControlGroup() {Me.CrewFilter})
    End Sub

    Private Function GenerateFilterScript(cContainer As DevExpress.XtraLayout.LayoutControlGroup()) As String
        Dim strCriteria As String = ""
        For Each cont As DevExpress.XtraLayout.LayoutControlGroup In cContainer
            For x As Integer = 0 To cont.Items.Count - 1
                If TypeOf (cont.Items(x)) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim cItem As DevExpress.XtraLayout.LayoutControlItem = TryCast(cont.Items(x), DevExpress.XtraLayout.LayoutControlItem)
                    If TypeOf (cItem) Is DevExpress.XtraLayout.LayoutControlItem And Not TypeOf (cItem) Is DevExpress.XtraLayout.EmptySpaceItem Then
                        Dim ctr As Control = TryCast(cItem.Control, Control)
                        If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then
                            If Not ctr.Name.Equals(cboFKeyVslCode.Name) Then
                                If ctr.Tag = "Text" Then
                                    'use Display Text
                                    If (Not ctr.Text.Equals("")) Then
                                        strCriteria = "[" & Mid(ctr.Name, 4) & "]='" & TryCast(ctr, DevExpress.XtraEditors.TextEdit).Text.Replace("'", "''") & "' AND " & strCriteria
                                    End If
                                ElseIf ctr.Tag = "Code" Then
                                    'use Edit Value
                                    If (Not ctr.Text.Equals("")) Then
                                        strCriteria = "[" & Mid(ctr.Name, 4) & "]='" & TryCast(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''") & "' AND " & strCriteria
                                    End If
                                End If
                            Else
                                If chkPlannedCrew.Checked Then
                                    If (Not ctr.Text.Equals("")) Then
                                        strCriteria = "[FKeyPlannedVsl]='" & TryCast(ctr, DevExpress.XtraEditors.TextEdit).EditValue.Replace("'", "''") & "' AND " & strCriteria
                                    End If
                                Else
                                    If ctr.Tag = "Text" Then
                                        'use Display Text
                                        If (Not ctr.Text.Equals("")) Then
                                            strCriteria = "[" & Mid(ctr.Name, 4) & "]='" & TryCast(ctr, DevExpress.XtraEditors.TextEdit).Text.Replace("'", "''") & "' AND " & strCriteria
                                        End If
                                    ElseIf ctr.Tag = "Code" Then
                                        'use Edit Value
                                        If (Not ctr.Text.Equals("")) Then
                                            strCriteria = "[" & Mid(ctr.Name, 4) & "]='" & TryCast(ctr, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''") & "' AND " & strCriteria
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        Next
        'CONCAT EXPCONTRACT FIlTER
        If Not Trim(GetExpContractStr()).Equals("") Then
            strCriteria = GetExpContractStr() & " AND " & strCriteria
        End If
        'CONCAT EXPDOCS FIlTER
        If Not Trim(GetExpDocStr()).Equals("") Then
            strCriteria = GetExpDocStr() & " AND " & strCriteria
        End If
        'CONCAT PLANNED CREW
        If Not Trim(GetPlannedCrew()).Equals("") Then
            strCriteria = GetPlannedCrew() & " AND " & strCriteria
        End If

        Dim QualifiedFilter As String = GetCompetenceFilter()
        If Not Trim(QualifiedFilter).Equals("") Then
            strCriteria = QualifiedFilter & " AND " & strCriteria
        End If

        GetCrewMonthsAshore()

        'neil
        '<!-- edited by tony20170905
        If chkFilterByAge.Checked Then
            If Not Trim(Me.txtAgeFrom.Text).Equals("") And Not Trim(Me.txtAgeTo.Text).Equals("") Then
                strCriteria = "([Age] >= " & Me.txtAgeFrom.Text & " and [Age] <= " & Me.txtAgeTo.Text & ")" & _
                              " AND " & strCriteria
            End If
        End If
        '-->

        If strCriteria.Length > 0 Then
            If Trim(strCriteria.Substring(strCriteria.Length - 5)) = "AND" Then
                strCriteria = strCriteria.Substring(0, strCriteria.Length - 5)
            End If
        End If

        '<!-- added by tony20170914
        If Not IfNull(oQuickFilter.FilterString, "").Equals("") Then
            strCriteria = strCriteria & _
                            IIf(Not IfNull(strCriteria, "").Equals(""), " AND ", "") & _
                            oQuickFilter.FilterString
        End If
        '-->

        Return strCriteria
    End Function

    Private Function GetExpContractStr() As String
        '1 = Overdue
        '2 = About to due
        '3 = Onboard and still within contract
        Dim strEx As String = ""
        Dim strExd As String = ""
        Dim str As String = ""

        If chkNonOverdue.Checked Then
            'str = " [hasExpContract] NOT IN ('1', '2') "
            str = " [hasExpContract] = '" & 3 & "'"
        Else
            If chkContractEnded.Checked Then
                strEx = " [hasExpContract]= '" & 1 & "' "
            End If

            If chkContractEnding.Checked Then
                strExd = " [hasExpContract] = '" & 2 & "' "
            End If
        End If

        If str = "" Then
            If strEx.Equals("") And strExd.Equals("") Then
                str = ""
            ElseIf strEx.Equals("") And Not strExd.Equals("") Then
                str = strExd
            ElseIf Not strEx.Equals("") And strExd.Equals("") Then
                str = strEx
            ElseIf Not strEx.Equals("") And Not strExd.Equals("") Then
                str = "(" & strEx & " OR " & strExd & ")"
            End If
        End If

        Return str
    End Function

    Private Function GetExpDocStr() As String
        '1 = Expired
        '2 = Expiring
        '3 = Has Both Expired and Expiring
        Dim strEx As String = ""
        Dim strExd As String = ""
        Dim str As String = ""

        If chkWoExpDocs.Checked Then
            str = " [hasExpDoc] NOT IN ('1', '2', '3') "
        Else
            If chkExpired.Checked Then
                'edited by tony20170622
                'strEx = " [hasExpDoc]= '" & 1 & "' "
                strEx = " [hasExpDoc] IN ('1', '3') "
            End If

            If chkExpiring.Checked Then
                'edited by tony20170622
                'strExd = " [hasExpDoc] = '" & 2 & "' "
                strEx = " [hasExpDoc] IN ('2', '3') "
            End If
        End If

        If str = "" Then
            If strEx.Equals("") And strExd.Equals("") Then
                str = ""
            ElseIf strEx.Equals("") And Not strExd.Equals("") Then
                str = strExd
            ElseIf Not strEx.Equals("") And strExd.Equals("") Then
                str = strEx
            ElseIf Not strEx.Equals("") And Not strExd.Equals("") Then
                str = "(" & strEx & " OR " & strExd & ")"
            End If
        End If
        Return str
    End Function

    'Apply Button 
    Private Sub cmdApply_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdApply.ItemClick

        If (Me.txtAgeFrom.Text.Equals("") And Not Me.txtAgeTo.Text.Equals("")) Or
            (Not Me.txtAgeFrom.Text.Equals("") And Me.txtAgeTo.Text.Equals("")) Then
            MsgBox("Please fill-up Age values.", vbExclamation)
            Exit Sub
        ElseIf Me.txtAgeFrom.Text <> "" And Me.txtAgeTo.Text <> "" Then
            If Convert.ToInt32(Me.txtAgeTo.Text) < Convert.ToInt32(Me.txtAgeFrom.Text) Then
                MsgBox("Age values are invalid.", vbExclamation)
                Exit Sub
            End If
        End If

        SetFilterInfoString(Name, FilterInfoString)

        ShowCustomLoadScreen(GetType(MPS4.Waitform), "Loading...")
        'strCrewListFilter = GenerateFilterScript(New DevExpress.XtraLayout.LayoutControlGroup() {Me.CrewFilter}) & GetExpDocStr() & GetPlannedCrew()'oRIGINAL
        strCrewListFilter = GenerateFilterScript(New DevExpress.XtraLayout.LayoutControlGroup() {Me.CrewFilter})
        'Me.Close()
        clickedApply = True
        Me.Visible = False
        CloseCustomLoadScreen()
    End Sub

    'Cancel Button
    Private Sub cmdCancel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdCancel.ItemClick
        Me.Close()
    End Sub

    'Clear Filter
    Private Sub cmdClear_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClear.ItemClick
        ClearFilter()
    End Sub

#Region "Clear Buttons"

    Private Sub cboFKeyQualificationRankFilter_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyQualificationRankFilter.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboFKeyQualifcationVessel_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyQualifcationVessel.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboStatusCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboStatType.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboCurrentStat_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboStatCode.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboSOFFReason_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboSOFFStat.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboRankName_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFkeyRankCode.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboCertCap_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboCertCap.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboNat_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboNat.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboPrin_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyPrinCode.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboAgent_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyAgentCode.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboWageScale_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFkeyWScaleCode.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub cboFKeyVslCode_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyVslCode.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

    Private Sub ClearControl_ButtonClick(sender As System.Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboFKeyVslGrpCode.ButtonClick, cboFKeyVslTypeCode.ButtonClick, cboFKeyRankGrpCode.ButtonClick, cboFKeyRankTypeCode.ButtonClick
        If e.Button.Index = 1 Then
            TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue = Nothing
        End If
    End Sub

#End Region

    Private Sub cboFKeyQualificationRankFilter_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyQualificationRankFilter.EditValueChanged

    End Sub

    Private Sub cboFKeyQualifcationVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyQualifcationVessel.EditValueChanged
        Dim competenceType As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        sCompetenceID = competenceType.GetColumnValue("PKey")
        Dim sCompetenceRank As String = "SELECT cr.PKey, r.Name, (SELECT Name FROM tblAdmRank WHERE PKey = cr.FKeySecRank) AS 'Abbrv' " & _
                                        "FROM dbo.tblAdmCompRank cr INNER JOIN tblAdmRank r ON r.PKey = cr.FKeyRank " & _
                                        "WHERE FKeyComp = '" & sCompetenceID & "' ORDER BY r.SortCode "
        Try
            cboFKeyQualificationRankFilter.Properties.DataSource = MPSDB.CreateTable(sCompetenceRank)
        Catch exception As Exception
            MessageBox.Show("An error has been encountered in the CrewListFilter.vb : " & exception.Message)
        End Try
    End Sub

    Private Sub cboStatType_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboStatType.EditValueChanged
        Dim cboStatType As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim dt As DataTable = MPSDB.CreateTable("SELECT PKey,Name,StatType FROM dbo.tblAdmStat WHERE StatType<>2 ORDER BY Name,SortCode ASC")

        If Not IsNothing(cboStatType.EditValue) Then
            If cboStatType.EditValue = "1" Then
                lciSOFFStat.Enabled = False
            Else
                lciSOFFStat.Enabled = True
            End If

            Dim dtStatCode As DataTable = dt.Select("StatType='" & cboStatType.EditValue & "'").CopyToDataTable
            cboStatCode.Properties.DataSource = dtStatCode
        Else
            cboStatCode.Properties.DataSource = dt
            lciSOFFStat.Enabled = True
        End If
    End Sub

    Private Sub GetCrewMonthsAshore()
        Dim retVal As String = ""
        If SelectedTab.Equals("Archive") Or SelectedTab.Equals("ArchiveCrews") Then
            Dim CrewMonthsAshore As String = IIf(txtArchiveNoMonths.Text.Length > 0, txtArchiveNoMonths.Text, "0")
            retVal = MonthsAshoreCriteria & CrewMonthsAshore & " "
            MonthsAshore = CrewMonthsAshore
        End If
    End Sub

    Private Function GetCompetenceFilter() As String
        Dim retVal As String = ""
        Dim idnbrs As String = ""
        If cboFKeyQualifcationVessel.Text.Length <> 0 Then
            If cboFKeyQualificationRankFilter.Text.Length <> 0 Then

                Dim competenceID As String = cboFKeyQualifcationVessel.EditValue
                Dim rankCode As String = cboFKeyQualificationRankFilter.EditValue

                Dim getQualifiedIDNbrs As String = "SELECT FKeyIDNbr, dbo.HasLacking_Filtering(FKeyIDNbr, FKeyRankCode, '" & competenceID & "', LOC, IIF(DateSOn IS NULL, '', DateSOn),'" & rankCode & "') as 'IsNotQualified' " & _
                                                   "FROM   dbo.Current_Activites " & _
                                                   "WHERE FKeyRankCode = (SELECT FKeyRank FROM tblAdmCompRank WHERE PKey = '" & rankCode & "') "
                Dim qualifiedCrews As DataTable = MPSDB.CreateTable(getQualifiedIDNbrs)

                'Dim compliedVesselHistory As DataTable = MPSDB.CreateTable("")

                For Each crews As DataRow In qualifiedCrews.Rows
                    If (Not crews("IsNotQualified")) Then
                        idnbrs += ("'" & crews("FKeyIDNbr") & "',")
                    End If
                Next
                If idnbrs.Trim().Length <> 0 Then
                    idnbrs = idnbrs.Remove(idnbrs.LastIndexOf(","))
                End If
                retVal = " [IDNbr] IN (" & IIf(idnbrs.Length > 0, idnbrs, "''''") & ") "
            End If
        End If
        Return retVal
    End Function

    Private Function GetPlannedCrew() As String
        Dim retval As String = ""
        If chkPlannedCrew.Checked Then
            'retval = "[FKeyPlannedVsl] is not NULL"
            If Not IsNothing(cboFKeyVslCode.EditValue) Then
                'retval = "([FKeyPlannedVsl]='" & cboFKeyVslCode.EditValue & "') "
                retval = ""
            Else
                retval = "[FKeyPlannedVsl] IS NOT NULL"
            End If
        Else
            retval = ""
        End If
        Return retval
    End Function

    'Planned CheckBox
    Private Sub chkPlannedCrew_EditValueChanged(sender As Object, e As System.EventArgs) Handles chkPlannedCrew.EditValueChanged
        Dim chk As DevExpress.XtraEditors.CheckEdit = TryCast(sender, DevExpress.XtraEditors.CheckEdit)
        If chk.Checked Then
            cboStatCode.EditValue = Nothing
            cboStatCode.Enabled = False
            cboFKeyVslCode.Properties.DataSource = MPSDB.CreateTable("SELECT * FROM dbo.frm_PlannedVslList ORDER BY Name")
            lciVsl.Text = "Planned Vessel"
        Else
            cboStatCode.Enabled = True
            cboFKeyVslCode.Properties.DataSource = dttblAdmVsl
            lciVsl.Text = "Vessel"
        End If
    End Sub

    'clear Filter
    Public Sub ClearFilter()
        SetFilterInfoVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        Dim cContainer As DevExpress.XtraLayout.LayoutControlGroup() = {CrewFilter, QualificationFilter, LayoutControlGroup_ContractDue, LayoutControlGroup_ExpDocs}
        For Each cont As DevExpress.XtraLayout.LayoutControlGroup In cContainer
            For cItemCount As Integer = 0 To cont.Items.Count - 1
                Dim cItem As DevExpress.XtraLayout.LayoutControlItem = TryCast(cont.Items(cItemCount), DevExpress.XtraLayout.LayoutControlItem)
                If TypeOf (cItem) Is DevExpress.XtraLayout.LayoutControlItem And Not TypeOf (cItem) Is DevExpress.XtraLayout.EmptySpaceItem Then
                    Dim ctr As Control = TryCast(cItem.Control, Control)
                    If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then
                        TryCast(ctr, DevExpress.XtraEditors.TextEdit).EditValue = Nothing
                    ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                        TryCast(ctr, DevExpress.XtraEditors.CheckEdit).Checked = False
                    End If
                End If
            Next
        Next

        '<!-- added by tony20170905
        txtAgeFrom.Text = 1
        txtAgeTo.Text = 1
        '-->

        strCrewListFilter = GenerateFilterScript(New DevExpress.XtraLayout.LayoutControlGroup() {Me.CrewFilter})
        GetCrewMonthsAshore()
    End Sub

    Public Sub applyFilter()
        strCrewListFilter = GenerateFilterScript(New DevExpress.XtraLayout.LayoutControlGroup() {Me.CrewFilter})
    End Sub

    Private Sub RibbonControl_Click(sender As System.Object, e As System.EventArgs) Handles RibbonControl.Click

    End Sub

#Region "Filter String"
    Public Event FilterInfoStringEvent(ByVal sender As Object, ByVal Value As String)
    Protected Sub SetFilterInfoString(ByVal sender As Object, ByVal Value As String)
        RaiseEvent FilterInfoStringEvent(sender, Value)
    End Sub

    Public Event FilterInfoVisibility(ByVal sender As Object, ByVal value As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetFilterInfoVisibility(ByVal sender As Object, ByVal valueV As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent FilterInfoVisibility(sender, valueV)
    End Sub

    Public Function GenerateFilterInfoString() As String
        Dim strFilterInfo As String = String.Empty
        'Status Group
        If Not IsNothing(cboStatType.EditValue) Then
            strFilterInfo = strFilterInfo & " Status Group (" & cboStatType.Text & "),"
        End If

        'Current Status
        If Not IsNothing(cboStatCode.EditValue) Then
            Dim wPlann As String = String.Empty
            If chkPlannedCrew.Checked Then
                wPlann = " with Planned Crew "
            Else
                wPlann = String.Empty
            End If
            strFilterInfo = strFilterInfo & " Current Status(" & cboStatCode.Text & ")" & wPlann & ","
        End If

        'Sign off reason
        If Not IsNothing(cboSOFFStat.EditValue) Then
            strFilterInfo = strFilterInfo & " Sign Off Reason(" & cboSOFFStat.Text & "),"
        End If

        'rank
        If Not IsNothing(cboFkeyRankCode.EditValue) Then
            strFilterInfo = strFilterInfo & " Rank (" & cboFkeyRankCode.Text & "),"
        End If

        'nationality
        If Not IsNothing(cboNat.EditValue) Then
            strFilterInfo = strFilterInfo & " Nationality (" & cboNat.Text & "),"
        End If

        'Principal
        If Not IsNothing(cboFKeyPrinCode.EditValue) Then
            strFilterInfo = strFilterInfo & " Principal (" & cboFKeyPrinCode.Text & "),"
        End If

        'Agent
        If Not IsNothing(cboFKeyAgentCode.EditValue) Then
            strFilterInfo = strFilterInfo & " Agent (" & cboFKeyAgentCode.Text & "),"
        End If

        'Wage Scale
        If Not IsNothing(cboFkeyWScaleCode.EditValue) Then
            strFilterInfo = strFilterInfo & " Wage Scale (" & cboFkeyWScaleCode.Text & "),"
        End If

        'Vessel
        If Not IsNothing(cboFKeyVslCode.EditValue) Then
            strFilterInfo = strFilterInfo & " Vessel (" & cboFKeyVslCode.Text & "),"
        End If

        '------------------------------------------------------------------------------------
        'CONTRACT DUE
        'Crews Still Within Contract
        If chkNonOverdue.Checked Then
            strFilterInfo = strFilterInfo & " Crews Still Within Contract,"
        End If

        'Overdue Crews
        If chkContractEnded.Checked Then
            strFilterInfo = strFilterInfo & " Overdue Crews,"
        End If

        'Crews With Contracts To Due Within X Days
        If chkContractEnding.Checked Then
            strFilterInfo = strFilterInfo & " Crews With Contracts To Due Within X Days,"
        End If

        '------------------------------------------------------------------------------------
        'EXPIRED/EXPIRING DOCUMENTS
        'Crews Without Expiring or Expired Documents
        If chkWoExpDocs.Checked Then
            strFilterInfo = strFilterInfo & " w/o Expired/Expiring Docs,"
        End If

        'with Expired Doc
        If chkExpired.Checked Then
            strFilterInfo = strFilterInfo & " w/ Expired Docs,"
        End If

        'with Expiring Doc
        If chkExpiring.Checked Then
            strFilterInfo = strFilterInfo & " w/ Expiring Docs,"
        End If
        '------------------------------------------------------------------------------------

        'Qualification
        'Competence
        If Not IsNothing(cboFKeyQualifcationVessel.EditValue) Then
            strFilterInfo = strFilterInfo & " Competence (" & cboFKeyQualifcationVessel.Text & "),"
        End If
        'Competence Rank
        If Not IsNothing(cboFKeyQualificationRankFilter.EditValue) Then
            strFilterInfo = strFilterInfo & " Competence Rank (" & cboFKeyQualificationRankFilter.Text & "),"
        End If

        'Age neil 
        '<!-- edited by tony20170905
        If chkFilterByAge.Checked Then
            If Not Trim(Me.txtAgeFrom.Text).Equals("") And Not Trim(Me.txtAgeTo.Text).Equals("") Then
                If Me.txtAgeFrom.Text = Me.txtAgeTo.Text Then
                    strFilterInfo = strFilterInfo & " Age (" & Me.txtAgeFrom.Text & "),"
                Else
                    strFilterInfo = strFilterInfo & " Age Between " & Me.txtAgeFrom.Text & " and " & Me.txtAgeTo.Text & ","
                End If

            End If
        End If
        '-->

        '<!--   added by tony20170914
        If strFilterInfo.Length > 0 Then strFilterInfo = strFilterInfo.Substring(0, Len(strFilterInfo) - 1)

        'add info from quick filter
        If Not IfNull(oQuickFilter.FilterInfo, "").Equals("") Then
            strFilterInfo = oQuickFilter.FilterInfo & IIf(Not IfNull(strFilterInfo, "").Equals(""), ", ", "") & strFilterInfo
        End If
        '-->


        If strFilterInfo.Length > 0 Then
            'strFilterInfo = "Filtered By: " & strFilterInfo.Substring(0, Len(strFilterInfo) - 1)
            strFilterInfo = "Filtered By: " & strFilterInfo
            SetFilterInfoVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        Else
            strFilterInfo = String.Empty
            SetFilterInfoVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        End If

        Return strFilterInfo
    End Function

    Private _FilterInfoString As String
    Public ReadOnly Property FilterInfoString() As String
        Get
            'Return _FilterInfoString
            Return GenerateFilterInfoString()
        End Get
        'Set(ByVal value As String)
        '    _FilterInfoString = value
        'End Set
    End Property


#End Region

    Private Sub chkWoExpDocs_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkWoExpDocs.CheckedChanged
        If TryCast(sender, DevExpress.XtraEditors.CheckEdit).Checked Then
            chkExpired.Checked = False
            chkExpiring.Checked = False
        End If
    End Sub

    Private Sub chkExpired_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkExpired.CheckedChanged
        If TryCast(sender, DevExpress.XtraEditors.CheckEdit).Checked Then chkWoExpDocs.Checked = False
    End Sub

    Private Sub chkExpiring_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkExpiring.CheckedChanged
        If TryCast(sender, DevExpress.XtraEditors.CheckEdit).Checked Then chkWoExpDocs.Checked = False
    End Sub

    Private Sub chkNonOverdue_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNonOverdue.CheckedChanged
        If TryCast(sender, DevExpress.XtraEditors.CheckEdit).Checked Then
            chkContractEnded.Checked = False
            chkContractEnding.Checked = False
        End If
    End Sub

    Private Sub chkContractEnded_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkContractEnded.CheckedChanged
        If TryCast(sender, DevExpress.XtraEditors.CheckEdit).Checked Then chkNonOverdue.Checked = False
    End Sub

    Private Sub chkContractEnding_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkContractEnding.CheckedChanged
        If TryCast(sender, DevExpress.XtraEditors.CheckEdit).Checked Then chkNonOverdue.Checked = False
    End Sub

    Public ReadOnly Property GeneratedFltStr() As String
        Get
            Return GenerateFilterScript(New DevExpress.XtraLayout.LayoutControlGroup() {Me.CrewFilter})
        End Get
    End Property

    Private Sub chkFilterByAge_EditValueChanged(sender As Object, e As System.EventArgs) Handles chkFilterByAge.EditValueChanged
        EnableFilterByAge(chkFilterByAge.Checked)
    End Sub

    Private Sub EnableFilterByAge(Optional value As Boolean = True)
        txtAgeFrom.Enabled = value
        txtAgeTo.Enabled = value
    End Sub

    Private Sub cboFkeyRankCode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFkeyRankCode.EditValueChanged
        If IsNothing(cboFkeyRankCode.EditValue) Then
            cboFkeyRankCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name,Abbrv FROM dbo.RankList ORDER BY SortCode ASC")
            cboFKeyRankTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRankType ORDER BY SortCode ASC")
            cboFKeyRankGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRankGrp ORDER BY SortCode ASC")
        Else
            cboFKeyRankTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT rT.PKey,rT.Name " &
                    " FROM dbo.tblAdmRank AS r INNER JOIN dbo.tblAdmRankGrp AS rG ON r.FKeyRankGrp = rG.PKey INNER JOIN dbo.tblAdmRankType AS rT ON r.FKeyRankType = rT.PKey " &
                    " WHERE r.PKey = '" & cboFkeyRankCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyRankGrpCode.EditValue), " AND rG.PKey = '" & cboFKeyRankGrpCode.EditValue & "' ", "") &
                    " GROUP BY rT.PKey,rT.Name,rT.SortCode ORDER BY rT.SortCode ASC")
            cboFKeyRankGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT rG.PKey,rG.Name " &
                    " FROM dbo.tblAdmRank AS r INNER JOIN dbo.tblAdmRankGrp AS rG ON r.FKeyRankGrp = rG.PKey INNER JOIN dbo.tblAdmRankType AS rT ON r.FKeyRankType = rT.PKey " &
                    " WHERE r.PKey = '" & cboFkeyRankCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyRankTypeCode.EditValue), " AND rT.PKey = '" & cboFKeyRankTypeCode.EditValue & "' ", "") &
                    " GROUP BY rG.PKey,rG.Name,rG.SortCode ORDER BY rG.SortCode ASC")
        End If
    End Sub

    Private Sub cboFKeyRankTypeCode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyRankTypeCode.EditValueChanged
        If IsNothing(cboFKeyRankTypeCode.EditValue) Then
            cboFkeyRankCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name,Abbrv FROM dbo.RankList ORDER BY SortCode ASC")
            cboFKeyRankTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRankType ORDER BY SortCode ASC")
            cboFKeyRankGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRankGrp ORDER BY SortCode ASC")
        Else
            cboFkeyRankCode.Properties.DataSource = MPSDB.CreateTable("SELECT r.PKey,r.Name,r.Abbrv " &
                    " FROM dbo.tblAdmRank AS r INNER JOIN dbo.tblAdmRankGrp AS rG ON r.FKeyRankGrp = rG.PKey INNER JOIN dbo.tblAdmRankType AS rT ON r.FKeyRankType = rT.PKey " &
                    " WHERE rT.PKey = '" & cboFKeyRankTypeCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyRankGrpCode.EditValue), " AND rG.PKey = '" & cboFKeyRankGrpCode.EditValue & "' ", "") &
                    " GROUP BY r.PKey,r.Name,r.Abbrv,r.SortCode ORDER BY r.SortCode ASC")
            cboFKeyRankGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT rG.PKey,rG.Name " &
                    " FROM dbo.tblAdmRank AS r INNER JOIN dbo.tblAdmRankGrp AS rG ON r.FKeyRankGrp = rG.PKey INNER JOIN dbo.tblAdmRankType AS rT ON r.FKeyRankType = rT.PKey " &
                    " WHERE rT.PKey = '" & cboFKeyRankTypeCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFkeyRankCode.EditValue), " AND r.PKey = '" & cboFkeyRankCode.EditValue & "' ", "") &
                    " GROUP BY rG.PKey,rG.Name,rG.SortCode ORDER BY rG.SortCode ASC")
        End If
    End Sub

    Private Sub cboFKeyRankGrpCode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyRankGrpCode.EditValueChanged
        If IsNothing(cboFKeyRankGrpCode.EditValue) Then
            cboFkeyRankCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name,Abbrv FROM dbo.RankList ORDER BY SortCode ASC")
            cboFKeyRankTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRankType ORDER BY SortCode ASC")
            cboFKeyRankGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmRankGrp ORDER BY SortCode ASC")
        Else
            cboFkeyRankCode.Properties.DataSource = MPSDB.CreateTable("SELECT r.PKey,r.Name,r.Abbrv " &
                    " FROM dbo.tblAdmRank AS r INNER JOIN dbo.tblAdmRankGrp AS rG ON r.FKeyRankGrp = rG.PKey INNER JOIN dbo.tblAdmRankType AS rT ON r.FKeyRankType = rT.PKey " &
                    " WHERE rG.PKey = '" & cboFKeyRankGrpCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyRankTypeCode.EditValue), " AND rT.PKey = '" & cboFKeyRankTypeCode.EditValue & "' ", "") &
                    " GROUP BY r.PKey,r.Name,r.Abbrv,r.SortCode ORDER BY r.SortCode ASC")
            cboFKeyRankTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT rT.PKey,rT.Name " &
                    " FROM dbo.tblAdmRank AS r INNER JOIN dbo.tblAdmRankGrp AS rG ON r.FKeyRankGrp = rG.PKey INNER JOIN dbo.tblAdmRankType AS rT ON r.FKeyRankType = rT.PKey " &
                    " WHERE rG.PKey = '" & cboFKeyRankGrpCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFkeyRankCode.EditValue), " AND r.PKey = '" & cboFkeyRankCode.EditValue & "' ", "") &
                    " GROUP BY rT.PKey,rT.Name,rT.SortCode ORDER BY rT.SortCode ASC")
        End If
    End Sub


    Private Sub cboFKeyVslCode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyVslCode.EditValueChanged
        If IsNothing(cboFKeyVslCode.EditValue) Then
            cboFKeyVslCode.Properties.DataSource = dttblAdmVsl
            cboFKeyVslGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslGrp ORDER BY Name")
            cboFKeyVslTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslType ORDER BY Name")
        Else
            cboFKeyVslGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT vg.PKey,vg.Name " &
                    " FROM dbo.tblAdmVsl AS v INNER JOIN dbo.tblAdmVslType AS vt ON v.FKeyVslType = vt.PKey INNER JOIN dbo.tblAdmVslGrp AS vg ON vt.FKeyVslGrp = vg.PKey " &
                    " WHERE v.PKey = '" & cboFKeyVslCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyVslTypeCode.EditValue), " AND vt.PKey = '" & cboFKeyVslTypeCode.EditValue & "' ", "") &
                    " GROUP BY vg.PKey,vg.Name ORDER BY vg.Name")

            cboFKeyVslTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT vt.PKey,vt.Name " &
                    " FROM dbo.tblAdmVsl AS v INNER JOIN dbo.tblAdmVslType AS vt ON v.FKeyVslType = vt.PKey INNER JOIN dbo.tblAdmVslGrp AS vg ON vt.FKeyVslGrp = vg.PKey " &
                    " WHERE v.PKey = '" & cboFKeyVslCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyVslGrpCode.EditValue), " AND vg.PKey = '" & cboFKeyVslGrpCode.EditValue & "' ", "") &
                    " GROUP BY vt.PKey,vt.Name ORDER BY vt.Name")
        End If
    End Sub

    Private Sub cboFKeyVslGrpCode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyVslGrpCode.EditValueChanged
        If IsNothing(cboFKeyVslGrpCode.EditValue) Then
            cboFKeyVslCode.Properties.DataSource = dttblAdmVsl
            cboFKeyVslGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslGrp ORDER BY Name")
            cboFKeyVslTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslType ORDER BY Name")
        Else
            cboFKeyVslCode.Properties.DataSource = MPSDB.CreateTable("SELECT v.ID,v.PKey,v.Name,v.Abbrv,v.SortCode,v.FKeyVslType,v.OffNbr,v.IMONo,v.PortofReg,v.Flag,v.Classf,v.YrBuilt,v.GrossTon,v.DeadWt,v.NetTon,v.EngType,v.EngPower,v.CallSign,v.UMS,v.Phone,v.Telefax,v.Email,v.FKeyPrincipal,v.FKeyOwner,v.FKeyEmployer,v.FKeyWageScale,v.FKeyMgrTech,v.FKeyMgrFlt,v.FKeyFlt,v.BillingCode,v.FKeyCrewCmpl,v.LifeBoatCapacity,v.FKeyMinCrew,v.FKeyComp,v.VslStat,v.DateJoined,v.DateLeft,v.DateUpdated,v.LastUpdatedBy,v.ProfileFilename,v.Charterer,v.CutOff,v.SOFFCutOff " &
                    " FROM dbo.tblAdmVsl AS v INNER JOIN dbo.tblAdmVslType AS vt ON v.FKeyVslType = vt.PKey INNER JOIN dbo.tblAdmVslGrp AS vg ON vt.FKeyVslGrp = vg.PKey " &
                    " WHERE vg.PKey = '" & cboFKeyVslGrpCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyVslTypeCode.EditValue), " AND vt.PKey = '" & cboFKeyVslTypeCode.EditValue & "' ", "") &
                    " GROUP BY v.ID,v.PKey,v.Name,v.Abbrv,v.SortCode,v.FKeyVslType,v.OffNbr,v.IMONo,v.PortofReg,v.Flag,v.Classf,v.YrBuilt,v.GrossTon,v.DeadWt,v.NetTon,v.EngType,v.EngPower,v.CallSign,v.UMS,v.Phone,v.Telefax,v.Email,v.FKeyPrincipal,v.FKeyOwner,v.FKeyEmployer,v.FKeyWageScale,v.FKeyMgrTech,v.FKeyMgrFlt,v.FKeyFlt,v.BillingCode,v.FKeyCrewCmpl,v.LifeBoatCapacity,v.FKeyMinCrew,v.FKeyComp,v.VslStat,v.DateJoined,v.DateLeft,v.DateUpdated,v.LastUpdatedBy,v.ProfileFilename,v.Charterer,v.CutOff,v.SOFFCutOff ORDER BY v.Name")

            cboFKeyVslTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT vt.PKey,vt.Name " &
                    " FROM dbo.tblAdmVsl AS v INNER JOIN dbo.tblAdmVslType AS vt ON v.FKeyVslType = vt.PKey INNER JOIN dbo.tblAdmVslGrp AS vg ON vt.FKeyVslGrp = vg.PKey " &
                    " WHERE vg.PKey = '" & cboFKeyVslGrpCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyVslCode.EditValue), " AND v.PKey = '" & cboFKeyVslCode.EditValue & "' ", "") &
                    " GROUP BY vt.PKey,vt.Name ORDER BY vt.Name")
        End If
    End Sub

    Private Sub cboFKeyVslTypeCode_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboFKeyVslTypeCode.EditValueChanged
        If IsNothing(cboFKeyVslTypeCode.EditValue) Then
            cboFKeyVslCode.Properties.DataSource = dttblAdmVsl
            cboFKeyVslGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslGrp ORDER BY Name")
            cboFKeyVslTypeCode.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.tblAdmVslType ORDER BY Name")
        Else
            cboFKeyVslCode.Properties.DataSource = MPSDB.CreateTable("SELECT v.ID,v.PKey,v.Name,v.Abbrv,v.SortCode,v.FKeyVslType,v.OffNbr,v.IMONo,v.PortofReg,v.Flag,v.Classf,v.YrBuilt,v.GrossTon,v.DeadWt,v.NetTon,v.EngType,v.EngPower,v.CallSign,v.UMS,v.Phone,v.Telefax,v.Email,v.FKeyPrincipal,v.FKeyOwner,v.FKeyEmployer,v.FKeyWageScale,v.FKeyMgrTech,v.FKeyMgrFlt,v.FKeyFlt,v.BillingCode,v.FKeyCrewCmpl,v.LifeBoatCapacity,v.FKeyMinCrew,v.FKeyComp,v.VslStat,v.DateJoined,v.DateLeft,v.DateUpdated,v.LastUpdatedBy,v.ProfileFilename,v.Charterer,v.CutOff,v.SOFFCutOff " &
                    " FROM dbo.tblAdmVsl AS v INNER JOIN dbo.tblAdmVslType AS vt ON v.FKeyVslType = vt.PKey INNER JOIN dbo.tblAdmVslGrp AS vg ON vt.FKeyVslGrp = vg.PKey " &
                    " WHERE vt.PKey = '" & cboFKeyVslTypeCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyVslGrpCode.EditValue), " AND vg.PKey = '" & cboFKeyVslGrpCode.EditValue & "' ", "") &
                    " GROUP BY v.ID,v.PKey,v.Name,v.Abbrv,v.SortCode,v.FKeyVslType,v.OffNbr,v.IMONo,v.PortofReg,v.Flag,v.Classf,v.YrBuilt,v.GrossTon,v.DeadWt,v.NetTon,v.EngType,v.EngPower,v.CallSign,v.UMS,v.Phone,v.Telefax,v.Email,v.FKeyPrincipal,v.FKeyOwner,v.FKeyEmployer,v.FKeyWageScale,v.FKeyMgrTech,v.FKeyMgrFlt,v.FKeyFlt,v.BillingCode,v.FKeyCrewCmpl,v.LifeBoatCapacity,v.FKeyMinCrew,v.FKeyComp,v.VslStat,v.DateJoined,v.DateLeft,v.DateUpdated,v.LastUpdatedBy,v.ProfileFilename,v.Charterer,v.CutOff,v.SOFFCutOff ORDER BY v.Name")

            cboFKeyVslGrpCode.Properties.DataSource = MPSDB.CreateTable("SELECT vg.PKey,vg.Name " &
                    " FROM dbo.tblAdmVsl AS v INNER JOIN dbo.tblAdmVslType AS vt ON v.FKeyVslType = vt.PKey INNER JOIN dbo.tblAdmVslGrp AS vg ON vt.FKeyVslGrp = vg.PKey " &
                    " WHERE vt.PKey = '" & cboFKeyVslTypeCode.EditValue & "' " &
                        IIf(Not IsNothing(cboFKeyVslCode.EditValue), " AND v.PKey = '" & cboFKeyVslCode.EditValue & "' ", "") &
                    " GROUP BY vg.PKey,vg.Name ORDER BY vg.Name")
        End If
    End Sub

End Class