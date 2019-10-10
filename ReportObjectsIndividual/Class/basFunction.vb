Imports Utilities
Module basFunction
#Region "Bind Procedures"
    Public Sub BindReportControls(ByRef rep As XtraReport)
        Dim type As Type
        Select Case rep.Name
            'THE BELOW OPTION BINDS THE DATA USING THE MANUALLY CODED CONTROLS
            Case "Report #1" ', "rptCompleteBiodata"
                'BindData(rep.FindControl("Control1", True), "Text", Nothing, "Field1")
                'BindData(rep.FindControl("Control2", True), "Text", Nothing, "Field2")

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

    Public Sub SetDefaultReportLabels(ByRef rep As XtraReport, ByVal db As SQLDB)
        'COMPANY NAME
        Try
            rep.FindControl("lblCompanyName", False).Text = Trim(db.GetConfig("Name"))
        Catch ex As Exception
        End Try

        'COMPANY ADDRESS
        Try
            rep.FindControl("lblCompanyAddr", False).Text = Trim(db.GetConfig("Addr"))
        Catch ex As Exception
        End Try

        'DATE PRINTED
        Try
            rep.FindControl("lblDatePrinted", False).Text = "Date Printed: " & Format(Now(), "Short Date")
        Catch ex As Exception
        End Try

    End Sub
End Module
