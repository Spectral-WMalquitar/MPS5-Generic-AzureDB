Public Class GTRSControl_Invalid

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select Case IfNull(param(0), "")
            Case "UPDATE_DISPLAY_MESSAGE"
                Dim cMsg As String = ""
                Try
                    If param.Count >= 2 Then
                        cMsg = IfNull(param(1), "")
                    End If

                Catch ex As Exception
                    cMsg = ""
                End Try

                UpdateDisplayMessage(cMsg)
        End Select
    End Sub

    Private Sub UpdateDisplayMessage(cMsg As String)

        lblStatus1.Text = IfNull(cMsg, "")
        lblStatus2.Visible = (IfNull(cMsg, "").Length = 0)
        lblGTravelWebsite.Visible = (IfNull(cMsg, "").Length = 0)

        'Select Case Mode
        '    Case "None"
        '        lblStatus1.Text = ""
        '        lblStatus2.Visible = True
        '        lblGTravelWebsite.Visible = True

        '    Case "NotEnabled"
        '        lblStatus1.Text = "G Travel Service Feature is Not Enabled."
        '        lblStatus2.Visible = False
        '        lblGTravelWebsite.Visible = False

        '    Case "CannotConnectToTheInternet"
        '        lblStatus1.Text = "Unable to connect to the internet." & vbCrLf & "Please check your connection or consult your network administrator for assistance."
        '        lblStatus2.Visible = False
        '        lblGTravelWebsite.Visible = False

        '    Case "CannotConnectToWebService"
        '        lblStatus1.Text = "Unable to connect to G Travel's service." & vbCrLf & "Please consult your system administrator for assistance."
        '        lblStatus2.Visible = False
        '        lblGTravelWebsite.Visible = False

        '    Case "ServiceUnavailable"
        '        lblStatus1.Text = "Service Unavailable."
        '        lblStatus2.Visible = False
        '        lblGTravelWebsite.Visible = False

        '    Case "ServiceUnavailable"
        '        lblStatus1.Text = "Service Unavailable."
        '        lblStatus2.Visible = False
        '        lblGTravelWebsite.Visible = False

        '    Case "UserAuthenticationFailed"
        '        lblStatus1.Text = "Authentication Failed"
        '        lblStatus2.Visible = False
        '        lblGTravelWebsite.Visible = False
        'End Select
    End Sub

    Private Sub UpdateDisplayMessageX(Mode As String)
        Select Case Mode
            Case "None"
                lblStatus1.Text = ""
                lblStatus2.Visible = True
                lblGTravelWebsite.Visible = True

            Case "NotEnabled"
                lblStatus1.Text = "G Travel Service Feature is Not Enabled."
                lblStatus2.Visible = False
                lblGTravelWebsite.Visible = False

            Case "CannotConnectToTheInternet"
                lblStatus1.Text = "Unable to connect to the internet." & vbCrLf & "Please check your connection or consult your network administrator for assistance."
                lblStatus2.Visible = False
                lblGTravelWebsite.Visible = False

            Case "CannotConnectToWebService"
                lblStatus1.Text = "Unable to connect to G Travel's service." & vbCrLf & "Please consult your system administrator for assistance."
                lblStatus2.Visible = False
                lblGTravelWebsite.Visible = False

            Case "ServiceUnavailable"
                lblStatus1.Text = "Service Unavailable."
                lblStatus2.Visible = False
                lblGTravelWebsite.Visible = False

            Case "ServiceUnavailable"
                lblStatus1.Text = "Service Unavailable."
                lblStatus2.Visible = False
                lblGTravelWebsite.Visible = False

            Case "UserAuthenticationFailed"
                lblStatus1.Text = "Authentication Failed"
                lblStatus2.Visible = False
                lblGTravelWebsite.Visible = False
        End Select
    End Sub

End Class
