Public Class BaseGTRSControl

    'Public Response As Object
    Public WithEvents bContent As BaseControl.BaseControl

    Public Structure StatusLabelColor
        Public Shared Warning As System.Drawing.Color = System.Drawing.Color.Red
        Public Shared OK As System.Drawing.Color = System.Drawing.Color.Green
    End Structure

    Protected _BookedWithGTravel As Boolean
    Public Overridable Property BookedWithGTravel As Boolean

        Get
            Return _BookedWithGTravel
        End Get
        Set(value As Boolean)
            _BookedWithGTravel = value
        End Set
    End Property

    Protected _HasUnsentUpdates As Boolean
    Public Overridable Property HasUnsentUpdates As Boolean

        Get
            Return _HasUnsentUpdates
        End Get
        Set(value As Boolean)
            _HasUnsentUpdates = value
        End Set
    End Property

    'Public Overridable Sub Init()

    'End Sub

    Public Overridable Sub RefreshData()
        'tonytest 
        Select Case oGTRS.MyStatus
            Case GTRSServiceStatus.NotEnabled
                SetStatusText("Service is not available.")

            Case GTRSServiceStatus.NotOkay
                SetStatusText(oGTRS.MyStatusDesc)

        End Select
        'Select Case oGTRS.Initialized
        '    Case ServiceObjectState.CannotConnnectToInternet
        '        SetStatusText("Cannot Connect to the Internet")

        '    Case ServiceObjectState.CannotConnnectToWebService
        '        SetStatusText("Cannot Connect to GTRS Web Service")

        '    Case ServiceObjectState.NotEnabled
        '        SetStatusText("GTRS Service Not Enabled")

        '    Case ServiceObjectState.NotInitialized
        '        SetStatusText("GTRS Service Not Initialized")
        'End Select
    End Sub

    Public Overridable Sub AddData()
        SetStatusText("")
        'tonytest SetTravelRequestID("")
    End Sub

    Public Overridable Sub EditData()

    End Sub

    Public Overridable Sub ExecCustomFunction(ByVal param() As Object)

    End Sub

    Public Overridable Sub SetStatusText(status As String)

    End Sub

    Public Overridable Sub SetStatusText(status As String, LabelColor As System.Drawing.Color)

    End Sub

    Public Overridable Sub EnableCreateRequest(Optional isEnable As Boolean = True)

    End Sub
End Class
