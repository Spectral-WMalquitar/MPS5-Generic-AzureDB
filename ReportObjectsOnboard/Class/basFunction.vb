Module basFunction
#Region "Bind Procedures"
    Public Sub BindReportControls(ByRef rep As XtraReport)
        Dim type As Type
        Select Case rep.Name.ToUpper
            'THE BELOW OPTION BINDS THE DATA USING THE MANUALLY CODED CONTROLS
            Case "rptCrewlist".ToUpper
                rep.FindControl("celCompanyName", True).Text = "SPECTRAL TECHNOLOGIES INC."
                rep.FindControl("celDatePrinted", True).Text = Format(Now, "dd-MMM-yyyy").ToString
                BindData(rep.FindControl("lblVessel", True), "Text", Nothing, "VslName")
                BindData(rep.FindControl("celCrewName", True), "Text", Nothing, "Crew")
                BindData(rep.FindControl("celRank", True), "Text", Nothing, "RankName")
                BindData(rep.FindControl("celNationality", True), "Text", Nothing, "Nat")
                BindData(rep.FindControl("celAge", True), "Text", Nothing, "Age")
                BindData(rep.FindControl("celDepart", True), "Text", Nothing, "DateSOn", "{0:dd-MMM-yyyy}")
                BindData(rep.FindControl("celDue", True), "Text", Nothing, "DueDate", "{0:dd-MMM-yyyy}")
                BindData(rep.FindControl("celLOC", True), "Text", Nothing, "LOC")
                BindData(rep.FindControl("celDays", True), "Text", Nothing, "DaysLeft")
                BindData(rep.FindControl("celFormerVsl", True), "Text", Nothing, "FormerVsl")
                BindData(rep.FindControl("celHireStat", True), "Text", Nothing, "HireStat")
                BindData(rep.FindControl("celTotalOnb", True), "Text", Nothing, "Crew")
                BindData(rep.FindControl("celAvgAge", True), "Text", Nothing, "Age")
                TryCast(rep.FindControl("GroupHeader1", True), DevExpress.XtraReports.UI.GroupHeaderBand).GroupFields.Add(New GroupField("VslName"))

            Case ("rptCrewlist_wNotify".ToUpper)
                rep.FindControl("celCompanyName", True).Text = "SPECTRAL TECHNOLOGIES INC."
                rep.FindControl("celDatePrinted", True).Text = Format(Now, "dd-MMM-yyyy").ToString
                BindData(rep.FindControl("lblVessel", True), "Text", Nothing, "VslName")
                BindData(rep.FindControl("celCrewName", True), "Text", Nothing, "Crew")
                BindData(rep.FindControl("celRank", True), "Text", Nothing, "RankName")
                BindData(rep.FindControl("celAgent", True), "Text", Nothing, "AgentName")
                BindData(rep.FindControl("celToNotify", True), "Text", Nothing, "Allottee")
                BindData(rep.FindControl("celRelation", True), "Text", Nothing, "Relation")
                BindData(rep.FindControl("celAddr", True), "Text", Nothing, "Addr")
                BindData(rep.FindControl("celCntry", True), "Text", Nothing, "Cntry")
                BindData(rep.FindControl("celTel", True), "Text", Nothing, "Tel")
                BindData(rep.FindControl("celTotalContacts", True), "Text", Nothing, "Allottee")
                TryCast(rep.FindControl("GroupHeader1", True), DevExpress.XtraReports.UI.GroupHeaderBand).GroupFields.Add(New GroupField("VslName"))
                TryCast(rep.FindControl("GroupHeader2", True), DevExpress.XtraReports.UI.GroupHeaderBand).GroupFields.Add(New GroupField("Crew"))

            Case "rptCrewlist_Wages".ToUpper
                rep.FindControl("lblCompanyName", True).Text = "SPECTRAL TECHNOLOGIES INC."
                rep.FindControl("celDatePrinted", True).Text = Format(Now, "dd-MMM-yyyy").ToString
                BindData(rep.FindControl("celVslName", True), "Text", Nothing, "VslName")
                BindData(rep.FindControl("celCrewName", True), "Text", Nothing, "Crew")
                BindData(rep.FindControl("celRank", True), "Text", Nothing, "RankName")
                BindData(rep.FindControl("celWS", True), "Text", Nothing, "WS")
                BindData(rep.FindControl("celBasic", True), "Text", Nothing, "Basic")
                BindData(rep.FindControl("celShipPay", True), "Text", Nothing, "ShipPay")
                BindData(rep.FindControl("celAllot", True), "Text", Nothing, "Allot")
                BindData(rep.FindControl("celOT", True), "Text", Nothing, "OT")
                'BindData(rep.FindControl("celOTrate", True), "Text", Nothing, "OTrate")
                BindData(rep.FindControl("celOTrate", True), "Text", Nothing, "")
                BindData(rep.FindControl("celLPay", True), "Text", Nothing, "LPay")
                'BindData(rep.FindControl("celOtherPay", True), "Text", Nothing, "OtherPay")
                BindData(rep.FindControl("celOtherPay", True), "Text", Nothing, "")
                BindData(rep.FindControl("celTotalWages", True), "Text", Nothing, "TotalWage")
                TryCast(rep.FindControl("GroupHeader1", True), DevExpress.XtraReports.UI.GroupHeaderBand).GroupFields.Add(New GroupField("VslName"))

            Case Else
                'THE BELOW OPTION BINDS THE DATA BY LOOPING TO ALL CONTROLS IN THE REPORT
                'THE CONTROL TO BIND MUST HAVE A TAG VALUE THAT HAS THE FF FORMAT:
                '           sample format: "BIND_" + <field name>
                '           sample:        "BIND_LName"
                '                          "BIND_CrewName"
                'IF THE CONTROL IS XRTABLE, ASSIGN "BIND" TO TAG PROPERTY

                For Each band As DevExpress.XtraReports.UI.Band In rep.Bands

                    For Each control As DevExpress.XtraReports.UI.XRControl In band

                        'MsgBox(control.Name)
                        If control.Tag.ToString.Length > 0 Then

                            If control.Tag.ToString = "BIND" Then

                                type = control.GetType()

                                Select Case type.Name
                                    Case "XRTable"  'if control is an XRTable
                                        Dim table As DevExpress.XtraReports.UI.XRTable = TryCast(control, DevExpress.XtraReports.UI.XRTable)

                                        For Each row As DevExpress.XtraReports.UI.XRTableRow In table

                                            For Each cell As DevExpress.XtraReports.UI.XRTableCell In row

                                                If cell.Tag.ToString.Length > 0 Then
                                                    If cell.Tag.ToString.Substring(0, 5) = "BIND_" Then
                                                        BindData(rep.FindControl(cell.Name, True), "Text", Nothing, cell.Tag.ToString.Substring(5))
                                                    End If
                                                End If
                                            Next
                                        Next
                                End Select

                            Else 'if .Tag is not "BIND"
                                If control.Tag.ToString.Substring(0, 5) = "BIND_" Then
                                    Try
                                        BindData(rep.FindControl(control.Name, True), "Text", Nothing, control.Tag.ToString.Substring(5))
                                    Catch ex As Exception
                                        Try
                                            rep.FindControl(control.Name, True).Text = "BIND FAILED"
                                        Catch ex2 As Exception
                                            'do nothing
                                        End Try
                                    End Try
                                End If
                            End If
                        End If

                    Next
                Next

        End Select
    End Sub

    '<System.Diagnostics.DebuggerStepThrough()> 
    Public Sub BindData(ByVal sender As Object, ByVal nProperty As String, ByVal DbSource As String, ByVal nFieldName As String, Optional ByVal nFormat As String = "")
        Try
            Dim nType As Type = sender.GetType
            Select Case nType.Name
                Case "XRLabel"
                    TryCast(sender, DevExpress.XtraReports.UI.XRLabel).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
                Case "XRTableCell"
                    TryCast(sender, DevExpress.XtraReports.UI.XRTableCell).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
                Case "XRPictureBox"
                    TryCast(sender, DevExpress.XtraReports.UI.XRPictureBox).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, DbSource, nFieldName, nFormat))
            End Select
        Catch ex As Exception
            Throw (New Exception(ex.Message))
        End Try
    End Sub
#End Region

End Module
