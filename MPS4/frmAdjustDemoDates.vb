Imports System.Text
Imports DevExpress.XtraSplashScreen

Public Class frmAdjuctDemoDates
    Private DB As SQLDB
    Dim sbLog As New StringBuilder("")
    Public Sub New(ByVal paramDB As SQLDB)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DB = paramDB

    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdProceed_Click(sender As System.Object, e As System.EventArgs) Handles cmdProceed.Click
        If txtYear.Text = "" Or txtMonth.Text = "" Or txtDays.Text = "" Then
            MsgBox("Please fill up required fields(*).", MsgBoxStyle.Exclamation, GetAppName)
            Exit Sub
        ElseIf Not chkAdjustAll.Checked And Not chkAdjustActivities.Checked And Not chkAdjustDocuments.Checked Then
            MsgBox("Please select which data to update.", MsgBoxStyle.Exclamation, GetAppName)
            Exit Sub
        Else
            'proceed to procedure
            If HasFutureDatesWhenUpdated() Then
                If MsgBox("MPS detected that the entered figure will cause some date fields to be a future date." & _
                          vbCrLf & vbCrLf & "MPS will skip updating those concern field(s)." & _
                          vbCrLf & vbCrLf & "Click Yes to proceed.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = vbNo Then
                    Exit Sub
                End If
            Else
                If MsgBox("All date fields in the database will be adjusted to " & txtYear.EditValue & " Yr, " & _
                          txtMonth.EditValue & " Mo, " & txtDays.EditValue & " Dy." & _
                          vbCrLf & vbCrLf & "Proceed Anyway?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, GetAppName) = vbNo Then
                    Exit Sub
                End If
            End If

            Try
                'start adjust demo dates

                Dim bSuccess As Boolean = False
                Dim dtDateCols As DataTable = DB.CreateTable("EXEC [dbo].[getDateColumns]")
                Dim nAffected As Integer = 0
                Dim n As Integer = 0
                Log_Append(StrDup(100, "*"))
                Log_Append("Starting Adjust Demo Dates")
                Log_Append(StrDup(100, "*"))
                Log_Append("No. of Year(s): " & txtYear.EditValue)
                Log_Append("No. of Month(s): " & txtMonth.EditValue)
                Log_Append("No. of Day(s): " & txtDays.EditValue)
                Log_Append("Database Server: " & SQLServer)
                Log_Append("")

                'Create Temp table of crew which Current activities will not be future date if updated
                Try

                    Log_Append("Creating temp_table for Valid Crew Activities..")
                    Log_Append("")
                    bSuccess = DB.RunSql("IF NOT EXISTS (SELECT * FROM MPS.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='temp_CrewValidActivities')" & _
                            "CREATE TABLE [MPS].[dbo].[temp_CrewValidActivities]([IDNbr] [varchar](15) NULL) ON [PRIMARY]")
                    bSuccess = DB.RunSql("TRUNCATE TABLE dbo.temp_CrewValidActivities")
                    bSuccess = DB.RunSql("INSERT INTO dbo.temp_CrewValidActivities SELECT [FKeyIDNbr] FROM [MPS].[dbo].[Current_Activites] WHERE dbo.fnDateAdd([ActDateStart]," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") <=GETDATE()", , nAffected)
                    Log_Append("No of Valid Crew(s): ".PadRight(50) & nAffected.ToString)
                Catch ex As Exception
                End Try


                For n = 0 To dtDateCols.Rows.Count - 1
                    Dim tblname As String = dtDateCols(n)("TableName")
                    Dim colname As String = dtDateCols(n)("ColumnName")
                    Dim cSql As String = ""
                    Dim cValColID As String


                    Select Case UCase(tblname)
                        Case UCase("tblActivity")
                            If chkAdjustActivities.Checked Then 'added by tony20170516
                                cSql = "UPDATE  TBLACT SET TBLACT." & colname & "=dbo.fnDateAdd(TBLACT." & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") FROM [dbo].[" & tblname & "] AS TBLACT INNER JOIN" & _
                                        " dbo.tblActivityGroup AS TBLACTGRP ON TBLACT.FKeyActivityGroupID = TBLACTGRP.Pkey INNER JOIN" & _
                                        " dbo.temp_CrewValidActivities AS TBLVALCREW ON TBLACTGRP.FKeyIDNbr = TBLVALCREW.IDNbr" & _
                                        " WHERE TBLACT." & colname & " IS NOT NULL"
                            End If

                        Case UCase("tblActivityGroup")
                            If chkAdjustActivities.Checked Then 'added by tony20170516
                                cSql = "UPDATE TBLACTGRP SET TBLACTGRP." & colname & "=dbo.fnDateAdd(TBLACTGRP." & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") FROM [dbo].[" & tblname & "] AS TBLACTGRP" & _
                                        " INNER JOIN dbo.temp_CrewValidActivities AS TBLVALCREW ON TBLACTGRP.FKeyIDNbr = TBLVALCREW.IDNbr" & _
                                        " WHERE TBLACTGRP." & colname & " IS NOT NULL"
                            End If

                        Case UCase("tblCourse")
                            If UCase(colname) = UCase("DateIssue") Then
                                If chkAdjustDocuments.Checked Then 'added by tony20170516
                                    cSql = "UPDATE [dbo].[" & tblname & "] SET " & colname & "=dbo.fnDateAdd(" & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ")" & _
                                        ",PlannedStart=CASE WHEN PlannedStart IS NULL THEN NULL ELSE dbo.fnDateAdd(PlannedStart," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") END" & _
                                        ",DateExpiry=CASE WHEN DateExpiry IS NULL THEN NULL ELSE dbo.fnDateAdd(DateExpiry," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") END" & _
                                        " WHERE " & colname & " IS NOT NULL And dbo.fnDateAdd(" & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") <=GETDATE()"
                                End If
                            End If

                        Case UCase("tblDocument")
                            If UCase(colname) = UCase("DateIssue") Then
                                If chkAdjustDocuments.Checked Then 'added by tony20170516
                                    cSql = "UPDATE [dbo].[" & tblname & "] SET " & colname & "=dbo.fnDateAdd(" & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ")" & _
                                        ",DateExpiry=CASE WHEN DateExpiry IS NULL THEN NULL ELSE dbo.fnDateAdd(DateExpiry," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") END" & _
                                        " WHERE " & colname & " IS NOT NULL And dbo.fnDateAdd(" & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") <=GETDATE()"
                                End If
                            End If
                        Case Else
                            'validate column if can have future date
                            cValColID = DB.DLookUp("ID", "[dbo].[tblValidateCols_DemoDates]", "", "TableName='" & tblname & "' And ColumnName='" & colname & "'")

                            If chkAdjustAll.Checked Then 'added by tony20170516
                                If cValColID <> "" Then
                                    cSql = "UPDATE [dbo].[" & tblname & "] SET " & colname & "=dbo.fnDateAdd(" & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") WHERE " & colname & " IS NOT NULL And dbo.fnDateAdd(" & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") <=GETDATE()"
                                Else
                                    cSql = "UPDATE [dbo].[" & tblname & "] SET " & colname & "=dbo.fnDateAdd(" & colname & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") WHERE " & colname & " IS NOT NULL"
                                End If
                            End If
                    End Select

                    If cSql <> "" Then
                        Log_Append("Table Name: ".PadRight(50) & tblname)
                        Log_Append("Column Name: ".PadRight(50) & colname)
                        Log_Append("Script: ".PadRight(50) & cSql)

                        'run update query
                        nAffected = 0
                        bSuccess = DB.RunSql(cSql, , nAffected)
                        Log_Append("Affected Row(s): ".PadRight(50) & nAffected.ToString)
                        Log_Append("")
                        Log_Append("")
                    End If

                Next
                Log_Append(StrDup(100, "*"))
                Log_Append("End Adjust Demo Dates")
                Log_Append(StrDup(100, "*"))

                Dim strFile As String = ""
                bSuccess = Log_Write(sbLog, strFile)
                If bSuccess Then
                    MsgBox("Successfully Adjust dates!", MsgBoxStyle.Information, GetAppName)
                    Try
                        System.Diagnostics.Process.Start(strFile)
                        Me.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
                    End Try
                Else
                    MsgBox("Error occurred creating a log file!", MsgBoxStyle.Critical, GetAppName)
                End If
            Catch ex As Exception
                MsgBox("Error Msg : " & ex.Message, MsgBoxStyle.Exclamation, GetAppName)
            End Try

        End If
    End Sub

    'This function checks if there will be future date will be updated based on the list defined in (tblValidateCols_DemoDates)
    'if true: will notify user if he/she wish to continue the date updates
    Private Function HasFutureDatesWhenUpdated() As Boolean
        Dim breturn As Boolean = False
        Dim dtValsCols As DataTable = DB.CreateTable("SELECT * FROM [dbo].[tblValidateCols_DemoDates]")

        Dim x As Integer = 0
        For x = 0 To dtValsCols.Rows.Count - 1
            Dim tblName As String = dtValsCols(x)("TableName")
            Dim colName As String = dtValsCols(x)("ColumnName")
            Dim cSelectSql As String = "SELECT TOP 1 " & colName & " FROM " & tblName & " WHERE " & colName & " IS NOT NULL And dbo.fnDateAdd(" & colName & "," & txtYear.EditValue & "," & txtMonth.EditValue & "," & txtDays.EditValue & ") > GETDATE() Order by " & colName & " DESC"
            Dim nRows As Integer = 0

            nRows = DB.CreateTable(cSelectSql).Rows.Count
            If nRows > 0 Then
                breturn = True
                GoTo ReturnLine
            End If
        Next

ReturnLine:
        Return breturn
    End Function

    Public Sub Log_Append(ByVal sbTmpLog As String)
        sbLog = sbLog.Append(Format(Now, "hh:mm:ss tt | ") & sbTmpLog & vbCrLf)
    End Sub

    Private Function Log_Write(ByVal sLog As StringBuilder, ByRef strFileName As String) As Boolean
        Dim breturn As Boolean = False
        If Not System.IO.Directory.Exists(GetAppPath() & "\logs") Then
            MkDir(GetAppPath() & "\logs")
        End If
        strFileName = GetAppPath() & "\logs" & "\AdjustDemoDates_" & Now.ToString("yyyyMMdd.HHmmss") & ".txt"
        Try
            'write log.txt
            System.IO.File.WriteAllText(strFileName, sLog.ToString)
            breturn = True
        Catch ex As Exception
            breturn = False
        End Try
        Return breturn
    End Function
End Class