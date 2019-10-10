Imports System.IO
Imports System.IO.Compression

Public Class Crew
    Dim clsAudit As New clsAudit 'neil
    Dim FormName As String = "CrewList"

    Public Overrides Sub RefreshData()
        MyBase.RefreshData()
        SetDeleteCrewVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
        SetEditOptionsVisibility(Name, False)
        SetExportToExcelVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetPrintListCaption(Name, "Print Biodata")
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        'MyBase.ExecCustomFunction(param)
        Select Case param(0)
            Case "Print"
                'Case for Printing.
            Case "PREVIEWREPORT"
                OpenReport("rptChecklistReport", "")
        End Select

    End Sub

    Private Sub OpenReport(reportClassName As String, sourceQuery As String)
        Try
            'This raise event will call the constructor of 'reportClassName', supplied with optional 'sourceQuery' for the report. 
            RaiseCustomEvent(Name, New Object() {"Preview", reportClassName, "ReportObjectsManPower", sourceQuery})
        Catch ex As Exception
            Debug.WriteLine("Error encountered while generating the report: " & ex.Message)
        End Try
    End Sub
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        Dim info As Boolean = True
        Dim deleteCrew As Boolean = False
        Dim extractFiles As Boolean = False
        Dim frmDel As New frmPopUpDeleteCrew

        'Dim crewStat As String = DB.DLookUp("FKeyStatCode", "dbo.Current_Activites", "", "FKeyIDNbr='" & blList.GetID & "'")
        'If crewStat = "SYSONB" Then
        '    MsgBox("Cannot delete Onboard crew.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, GetAppName)
        '    Exit Sub
        'End If
        Dim ValidToDelete As Boolean = False
        DB.BeginReader("SELECT ca.*, plandet.PlannedVslName FROM dbo.Current_Activites ca LEFT JOIN (SELECT TOP 1 * FROM dbo.PlannedCrewDetails WHERE CrewID = '" & blList.GetID & "' AND PlannedDateSON >= GETDATE() ORDER BY PlannedDateSON) plandet ON ca.FKeyIDNbr = plandet.CrewID WHERE ca.FKeyIDNbr = '" & blList.GetID & "'")
        DB.Read()
        If DB.ReaderItemCount > 0 Then
            If IfNull(DB.ReaderItem("FKeyStatCode"), "").Equals("SYSONB") Then
                MsgBox("Cannot delete Onboard crew.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, GetAppName)
            ElseIf IfNull(DB.ReaderItem("PlannedVslName"), "").Length > 0 Then
                MsgBox("Cannot delete Planned Crew.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, GetAppName)
            Else
                ValidToDelete = True
            End If
        Else
            MsgBox("Unable to verify crew record for deletion. Please try again.", MsgBoxStyle.Exclamation)
        End If
        DB.CloseReader()


        If Not ValidToDelete Then Exit Sub
        'Else
        '    DB.BeginReader("SELECT TOP 1 * FROM dbo.PlannedCrewDetails WHERE CrewID = 'EMSINA4Y8VQ18L' AND PlannedDateSON >= GETDATE() ORDER BY PlannedDateSON")
        '    DB.Read()
        '    If DB.ReaderItemCount > 0 Then
        '        MsgBox("Cannot delete Planned crew.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, GetAppName)
        '    End If
        '    DB.CloseReader()
        'End If

        frmDel.Text = GetAppName()
        frmDel.lblCrewName.Text = blList.GetDesc
        Try
            frmDel.PhotoaPath = GetCrewBiodataPhoto(blList.GetID)
        Catch ex As Exception
            MsgBox("Failed to load up crew photo. " & vbNewLine & "Error: " & ex.Message)
        End Try
        frmDel.ShowDialog(Me.Parent)
        deleteCrew = frmDel.GoDeleteCrew
        extractFiles = frmDel.GoExtractFiles

        ShowCustomLoadScreen(GetType(Waitform), "Deleting crew...")
        If deleteCrew Then
            Dim bSuccess_ExtractFiles As Boolean = False
            If extractFiles Then
                'tony20180131
                'info = ExtractCrewFiles(blList.GetID, blList.GetDesc)
                If Not ExtractCrewFiles(blList.GetID, blList.GetDesc) Then
                    MsgBox("Failed to extract documents/images. Please try again.", MsgBoxStyle.Information)
                    CloseCustomLoadScreen()
                    Return
                End If
                bSuccess_ExtractFiles = True
            End If

            If extractFiles And bSuccess_ExtractFiles Then
                CloseCustomLoadScreen()
                MsgBox("Crew files extracted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, GetAppName)
                ShowCustomLoadScreen(GetType(Waitform), "Deleting crew...")
            End If

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete Crew", 0, System.Environment.MachineName, "Crew : " & blList.GetDesc, FormName) 'neil
            clsAudit.saveAuditPreDelDetails("tblcrewinfo", blList.GetID, LastUpdatedBy)
            info = DeleteCrewBiodata(blList.GetID)
            If info Then
                CloseCustomLoadScreen()
                'tony20180131 MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
                MsgBox("Crew Record Successfully Deleted.", MsgBoxStyle.Information, GetAppName)
                blList.ExecCustomFunction(New Object() {"ForceRefresh"})
                ClearDtCrewList()
                RefreshData()
                blList.RefreshData()
                BRECORDUPDATEDs = False
            Else
                CloseCustomLoadScreen()
                'tony20180131 MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
                MsgBox("Failed to Delete Crew Record.", MsgBoxStyle.Critical, GetAppName)
                BRECORDUPDATEDs = False
            End If

        Else
            CloseCustomLoadScreen()
            MsgBox("Crew deletion canceled.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, GetAppName)
            BRECORDUPDATEDs = False
        End If

        'Change by tony20180131
        '    If info = True Then
        '        If extractFiles And bSuccess_ExtractFiles Then
        '            CloseCustomLoadScreen()
        '            MsgBox("Crew files extracted.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, GetAppName)
        '            ShowCustomLoadScreen(GetType(Waitform), "Deleting crew...")
        '        End If

        '        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete Crew", 0, System.Environment.MachineName, "Crew : " & blList.GetDesc, FormName) 'neil
        '        clsAudit.saveAuditPreDelDetails("tblcrewinfo", blList.GetID, LastUpdatedBy)
        '        info = DeleteCrewBiodata(blList.GetID)
        '        If info Then
        '            CloseCustomLoadScreen()
        '            MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
        '            blList.ExecCustomFunction(New Object() {"ForceRefresh"})
        '            ClearDtCrewList()
        '            RefreshData()
        '            blList.RefreshData()
        '            BRECORDUPDATEDs = False
        '        Else
        '            CloseCustomLoadScreen()
        '            MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
        '            BRECORDUPDATEDs = False
        '        End If
        '    Else
        '        CloseCustomLoadScreen()
        '        MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
        '        BRECORDUPDATEDs = False
        '    End If
        'Else
        '    CloseCustomLoadScreen()
        '    MsgBox("Crew deletion canceled.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, GetAppName)
        '    BRECORDUPDATEDs = False
        'End If


    End Sub

    Private Function GetDeleteType(CrewIDNbr As String) As Integer
        Dim retVal As Integer = 0
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Try
            sqlConn.Open()
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_GetDeleteCrewType"
                With cmd.Parameters
                    .AddWithValue("@CrewID", CrewIDNbr)
                End With
                retVal = cmd.ExecuteScalar()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        Return retVal
    End Function

    Private Function DeleteCrewAndRecords(CrewIDNbr As String) As Boolean
        Dim retVal As Boolean = False
        Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "SP_DeleteCrewRecord"
                cmd.Parameters.AddWithValue("@CrewID", CrewIDNbr)
                'commented out by tony20190716 : Stored Procedure no longer have the LastUpdatedBy field
                'cmd.Parameters.AddWithValue("@LastUpdatedBy", GetUserName())
                cmd.ExecuteNonQuery()
            End Using
            sqlTran.Commit()
            retVal = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
            sqlTran.Rollback()
            retVal = False
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try

        Return retVal
    End Function

    Private Function DeleteCrewBiodata(CrewIDNbr As String) As Boolean
        Dim DelType As Integer = GetDeleteType(CrewIDNbr)
        Dim info As Boolean = False

        If DelType = 2 Then
            info = False
            MsgBox("The crew " & blList.GetDesc & " has a processed payroll. Move the crew to archive instead.")
            'ElseIf DelType = 1 Then
            '    If MsgBox("The crew " & blList.GetDesc & " has related files and sea services. Do you want to delete crew?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Exclamation, GetAppPath()) = MsgBoxResult.Yes Then
            '        'Delete Crew
            '        info = DeleteCrewAndRecords(CrewIDNbr)
            '    Else
            '        info = False
            '    End If
        ElseIf DelType = 0 Or DelType = 1 Then
            info = DeleteCrewAndRecords(CrewIDNbr)
        End If
        Return info
    End Function

    Private Function ExtractCrewFiles(crewIDNbr As String, fileName As String) As Boolean
        Dim info As Boolean = False
        Dim err As Boolean = False
        Dim crewPath As String = FOLDERDIRECTORY & "\" & crewIDNbr
        Dim saveLoc As String = ""
        Dim saveDialog As New SaveFileDialog()

        If Not Directory.Exists(crewPath) Then
            If MsgBox("Nothing to extract." & vbNewLine & "Continue to delete crew?",
                      MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, GetAppName) = MsgBoxResult.Yes Then
                Return True
            Else
                Return False
            End If
        End If

        saveDialog.Filter = "ZIP File (*.zip)|*.zip"
        saveDialog.Title = "Select file location"
        saveDialog.FileName = fileName

        If saveDialog.ShowDialog() = DialogResult.OK Then
            If Not saveDialog.FileName.Trim().Equals("") Then
                saveLoc = saveDialog.FileName
                Try
                    Dim zip As New Chilkat.Zip()
                    zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
                    zip.NewZip(saveLoc)
                    zip.AppendFiles(crewPath & "\*.*", True)
                    info = zip.WriteZipAndClose()
                Catch ex As Exception
                    info = False
                    err = True
                    LogErrors("ExtractCrewFiles : " & ex.Message)
                End Try
            End If
        End If

        If err = True Then
            MsgBox("An error occurred while extracting files of the crew. Deletion of crew was cancelled." & vbNewLine &
                   "Refer to error log in Errors folder.",
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, GetAppName)
        End If

        Return info
    End Function


End Class

