Public Class MainForm

    Private Shared ScheduleTimer As System.Timers.Timer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Hide()

        APP_PATH = Application.StartupPath
        ' Create and start a timer that runs every 5 seconds.
        ScheduleTimer = New System.Timers.Timer()
        ScheduleTimer.Interval = 5000
        ScheduleTimer.AutoReset = True
        AddHandler ScheduleTimer.Elapsed, AddressOf Timer_Tick
        ScheduleTimer.Start()
    End Sub

    'RSA: Each time the timer completes an interval, it executes the code found within this subprocedure.
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ScheduleTimer.Stop()
        DoNextExecution()
        ScheduleTimer.Start()
    End Sub

    Private Sub DoNextExecution()
        'SyncLock Me
        Dim isConnected As Boolean = False
        isConnected = ReportAutoEmail.ReportAutoEmail.InitConnection
        If isConnected Then
            ReportAutoEmail.ReportAutoEmail.Init()
            ReportAutoEmail.ReportAutoEmail.UpdateDLLs()
            ReportAutoEmail.ReportAutoEmail.StartAutoSendingEmail()
        End If
        'End SyncLock
    End Sub

End Class