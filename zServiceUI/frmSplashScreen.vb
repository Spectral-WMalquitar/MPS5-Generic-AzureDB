Imports zBusiness
Imports zUtil

Public Class frmSplashScreen
    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub frmSplashScreen1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblAppName.Parent = PictureEditBG
        lblAppName.BackColor = System.Drawing.Color.Transparent
        lblAppName.Text = Application.ProductName

        lblVersion.Parent = PictureEditBG
        lblVersion.BackColor = System.Drawing.Color.Transparent
        lblVersion.Text = "Version " & Application.ProductVersion

        lblCopyright.Text = "Copyright " & Application.CompanyName

    End Sub

    Private Sub frmSplashScreen_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        'show splashscreen for X seconds, then move on...
        If Debugger.IsAttached Then
            'RSA: running in design mode?
            'do not delay programming activities too much
            'show splash screen for to 500ms only
            Timer1.Interval = 500 '0.5 seconds
            Timer1.Start()
            'Proceed()
        Else
            'let user see our beautiful splashscreen for several seconds
            Timer1.Interval = 3000 '3 seconds
            Timer1.Start()
        End If

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Proceed()
    End Sub

    Private Sub Proceed()
        Me.Hide()
        If SpectralService_Init() Then
            'go to login form
            'frmLogin.Show()
            frmMain.Show()
        Else
            'stop application
            End
        End If
    End Sub

End Class
