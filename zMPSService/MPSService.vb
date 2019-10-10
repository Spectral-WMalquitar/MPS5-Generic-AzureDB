Imports System.Diagnostics
Imports zBusiness
Public Class MPSService

    Public ScheduleTimer As System.Timers.Timer
    Public IsRunning As Boolean

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        'RSA: Event Logging
        '====================================================================
        Try
            If Not System.Diagnostics.EventLog.SourceExists(cLogSource) Then
                System.Diagnostics.EventLog.CreateEventSource(cLogSource, cLogName)
            End If
        Catch ex As Exception
        End Try

        EventLog1.Source = cLogSource
        EventLog1.Log = cLogName

        'RSA: Timer
        '====================================================================
        ' Set initial variable values.
        Me.IsRunning = False

        ' Create and start a timer that runs every 5 seconds.
        ScheduleTimer = New System.Timers.Timer()
        ScheduleTimer.Interval = 5000
        ScheduleTimer.AutoReset = True
        AddHandler ScheduleTimer.Elapsed, AddressOf Timer_Tick
        ScheduleTimer.Start()
        zBusiness.Service_RunAutoEmail(True)
    End Sub

    'RSA: Each time the timer completes an interval, it executes the code found within this subprocedure.
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DoNextExecution()
    End Sub

    'RSA: Execute code every interval
    Public Sub DoNextExecution()
        SyncLock Me
            ' Another execution cycle begins.
            zBusiness.Service_DoWork(ServiceCallingModule.Service)
        End SyncLock
    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        EventLog1.WriteEntry(cServiceName & " Started", EventLogEntryType.Information)
        If Not ScheduleTimer.Enabled Then
            ScheduleTimer.Start()
            zBusiness.Service_RunAutoEmail(True)
        End If
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        EventLog1.WriteEntry(cServiceName & " Stopped", EventLogEntryType.Information)
        If ScheduleTimer.Enabled Then
            ScheduleTimer.Stop()
            zBusiness.Service_RunAutoEmail(False)
        End If
        SetLiveStatus(ServiceCallingModule.Service & "||") 'hide live service status
    End Sub

End Class
