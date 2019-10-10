Imports System.IO.File

Public Class DBConnectionFile

    Private dbconn As SQLDB.DBConnectionParameter

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()

        If Not bLoaded Then
            SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetEditOptionsVisibility(Name, False)

            RefreshControls(True)
            ClearFields(Me, False)
            bLoaded = True
        End If
    End Sub

    Private Sub RefreshControls(UseCurrentConnection As Boolean)
        chkUseCurrentConnection.Checked = UseCurrentConnection

        txtHost.Enabled = Not UseCurrentConnection
        txtUsername.Enabled = Not UseCurrentConnection
        txtPassword.Enabled = Not UseCurrentConnection
    End Sub

    Private Sub chkUseCurrentConnection_EditValueChanged(sender As Object, e As System.EventArgs) Handles chkUseCurrentConnection.EditValueChanged
        RefreshControls(chkUseCurrentConnection.Checked)
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        'check if textServer is null
        Me.Cursor = Cursors.WaitCursor

        GenerateDBConnectionObj()

        If dbconn.Host = "" Or dbconn.UID = "" Or dbconn.Pwd = "" Then
            MsgBox("Please Complete the Details", MsgBoxStyle.Information, GetAppName())
        Else
            Dim db As New SQLDB(CreateConnectionString(dbconn.Host, dbconn.UID, dbconn.Pwd))
            If db.Connect Then
                MsgBox("Test Connection Successful!", MsgBoxStyle.Information, GetAppName)
            Else
                MsgBox("Test Connection Failed.", MsgBoxStyle.Exclamation, GetAppName)
                If db.GetLastErrorMessage().ToString.Length > 0 Then LogErrors("(Login) Test Connection: " & db.GetLastErrorMessage())
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Sub GenerateDBConnectionObj()
        dbconn = New SQLDB.DBConnectionParameter
        If chkUseCurrentConnection.Checked Then
            With dbconn
                .Host = SQLServer
                .UID = SQLID
                .Pwd = SQLPW
            End With
        Else
            With dbconn
                .Host = txtHost.EditValue
                .UID = txtUsername.EditValue
                .Pwd = txtPassword.EditValue
            End With
        End If
    End Sub

    Private Sub GenerateDBConnectionFile(_dbconn As SQLDB.DBConnectionParameter)
        If IsNothing(_dbconn) Then
            MsgBox("Failed. DBConnection object is not initialized.")
            Exit Sub
        End If

        If _dbconn.Host = "" Or _dbconn.UID = "" Or _dbconn.Pwd = "" Then
            MsgBox("Cannot initialized database connection object. Connection parameters are not provided.", MsgBoxStyle.Information)
            Exit Sub
        End If

        Dim cConnString = _dbconn.Host & SQLDB.DBConnFileSeparator & _dbconn.UID & SQLDB.DBConnFileSeparator & _dbconn.Pwd
        Dim cConnStringEnc = sysMpsUserPassword("ENCRYPT", cConnString)
        MsgBox("Choose where you want to save the file.", MsgBoxStyle.Information)

SAVE_DIALOG:
        Dim oSaveFileDialog As New SaveFileDialog()
        'oSaveFileDialog.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif"
        oSaveFileDialog.Filter = "MPS Database Connection|*.mdc"
        oSaveFileDialog.Title = "Save MPS Database Connection File"
        oSaveFileDialog.ShowDialog()

        ' If the file name is not an empty string open it for saving.  
        If oSaveFileDialog.FileName <> "" Then

            If My.Computer.FileSystem.FileExists(oSaveFileDialog.FileName) Then
                Kill(oSaveFileDialog.FileName)
            End If

            Dim objWriter As New System.IO.StreamWriter(oSaveFileDialog.FileName)

            objWriter.Write(cConnStringEnc)
            objWriter.Close()

            MsgBox("MPS Database Connection file [" & oSaveFileDialog.FileName & "] successfully created.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As System.EventArgs) Handles btnGenerate.Click
        GenerateDBConnectionObj()
        GenerateDBConnectionFile(dbconn)
    End Sub


End Class



