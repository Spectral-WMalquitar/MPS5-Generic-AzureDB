Imports System.Reflection
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo

Public Class MPS4Splash_Admin
    Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum
End Class
