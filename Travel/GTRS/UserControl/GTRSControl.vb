Public Class GTRSControl

    Public Overrides Property BookedWithGTravel As Boolean

        Get
            Return _BookedWithGTravel
        End Get
        Set(value As Boolean)
            _BookedWithGTravel = value

            If value Then
                lblBookedWithGTravel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciBookWithGTravel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciCancelBooking.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciGetBookingDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciSendUpdates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

            Else
                lblBookedWithGTravel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciBookWithGTravel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                lciCancelBooking.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciGetBookingDetails.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                lciSendUpdates.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            End If

            lciSendUpdates.Enabled = False
        End Set
    End Property

    Public Overrides Property HasUnsentUpdates As Boolean

        Get
            Return _HasUnsentUpdates
        End Get
        Set(value As Boolean)
            _HasUnsentUpdates = value

            lciSendUpdates.Enabled = value
            
        End Set
    End Property

    'Public Overrides Sub Init()
    '    MyBase.Init()
    '    EnableButtons(False)
    'End Sub

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()

        EnableButtons(False)
    End Sub

    Public Overrides Sub AddData()
        EnableButtons(True)
    End Sub

    Public Overrides Sub EditData()
        EnableButtons(True)
    End Sub

    Private Sub EnableButtons(Optional enable As Boolean = True)
        btnBookWithGTravel.Enabled = enable
        btnCancelBooking.Enabled = enable
        btnGetBookingDetails.Enabled = enable
        btnSendUpdates.Enabled = enable
    End Sub

    Private Sub btnBookWithGTravel_Click(sender As System.Object, e As System.EventArgs) Handles btnBookWithGTravel.Click
        bContent.ExecCustomFunction(New Object() {"CREATE_TRAVEL_REQUEST"})
    End Sub

    Private Sub btnCancelBooking_Click(sender As Object, e As System.EventArgs) Handles btnCancelBooking.Click
        bContent.ExecCustomFunction(New Object() {"CANCEL_TRAVEL_REQUEST"})
    End Sub

    Private Sub btnGetBookingDetails_Click(sender As System.Object, e As System.EventArgs) Handles btnGetBookingDetails.Click
        bContent.ExecCustomFunction(New Object() {"GET_TRAVEL_REQUEST_UPDATE"})
    End Sub

    Public Overrides Sub ExecCustomFunction(ByVal param() As Object)
        Select param(0)
            Case "ENABLE_SEND_TRAVEL_REQUEST_UPDATES"
                btnSendUpdates.Enabled = True
                '    If BRECORDUPDATEDs Then
                '        If MsgBox("Would you like to save the changes first?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                '            If Not isValidForCreateTravelRequest() Then
                '                Exit Sub
                '            End If

                '            SaveData()
                '        Else
                '            Exit Sub
                '        End If
                '    End If

                '    If Not isValidForCreateTravelRequest() Then
                '        Exit Sub
                '    End If
        End Select
    End Sub

    Private Sub btnSendUpdates_Click(sender As System.Object, e As System.EventArgs) Handles btnSendUpdates.Click
        bContent.ExecCustomFunction(New Object() {"UPDATE_TRAVEL_REQUEST"})
    End Sub
End Class
