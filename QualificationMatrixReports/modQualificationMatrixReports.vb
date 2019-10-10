Public Module modQualificationMatrixReports

    Public Sub OpenWaitForm()
        Try
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(WaitForm1))
        Catch
            'do nothing
        End Try
    End Sub

    Public Sub CloseWaitForm()
        Try
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()
        Catch
            'do nothing
        End Try
    End Sub

End Module
