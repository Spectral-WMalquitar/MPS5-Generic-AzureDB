Imports System.Data.SqlClient


Public Class clsActivityDocs_temptbl
    Dim dtDocImage As DataTable
    Dim MPSDB As SQLDB
    Dim clsdoc As New clsDocumentViewer_Functions
    Dim actname As String

    Dim var_crewid As String
    Dim var_dateissue_s As String, var_dateexpire_s As String
    Dim var_dateissue As Date, var_dateexpire As Date
    Dim var_vslname As String = ""
    Dim clsAudit As New clsAudit
    Dim sqlConn As New SqlClient.SqlConnection
    'Dim clsSec As New clsSecurity

    'THESE CONST ARE FROM DATABASE
    Const CONST_FILETAG = "ACTD"
    Const CONST_DOCGROUP = "SYSACTIVITYDOC"
    Const CONST_ACTDOCUMENT = "SYSACTIVITYDOCD"

    Public Function saveDocsToDt(FKeyIDNbr As String, Description As String, FilePath As String, dateissue As Date, vslname As String,
                            LastUpdatedBy As String,
                            Optional dateexpire As Date = Nothing,
                            Optional ByRef errmsg As String = "") As Boolean

        ' Optional activityKey As String = "DUMMY_KEY",
        Dim ret As Boolean = True

        Dim workRow As DataRow = dtDocImage.NewRow()


        workRow("FKeyIDNbr") = FKeyIDNbr
        workRow("DocImgPKey") = "DUMMY"
        workRow("Description") = Description
        workRow("FilePath") = FilePath
        workRow("DateIssue") = dateissue
        workRow("VslName") = vslname
        'workRow("LastUpdatedBy") = LastUpdatedBy

        dtDocImage.Rows.Add(workRow)

        Return ret
    End Function

    Public Function updateDateIssue(FKeyIDNbr As String, dateissue As Date) As Boolean
        Dim ret As Boolean = True

        Try
            'For Each row In dtDocImage.Rows
            '    If row("FKeyIDNbr") = FKeyIDNbr And row("Description") = Description Then
            '        dtDocImage.Rows(dtDocImage.Rows.IndexOf(row)).Delete()
            '    End If
            'Next

            For i As Integer = dtDocImage.Rows.Count - 1 To 0 Step -1
                If dtDocImage.Rows(i)("FKeyIDNbr") = FKeyIDNbr Then
                    dtDocImage.Rows(i)("DateIssue") = dateissue
                End If
            Next

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    Public Function deleteDocs(FKeyIDNbr As String) As Boolean '\\ run to clean the datatable by IDNbr
        Dim ret As Boolean = True ', cnt As Integer

        Try
            'For Each row In dtDocImage.Rows
            '    If row("FKeyIDNbr") = FKeyIDNbr Then
            '        dtDocImage.Rows(dtDocImage.Rows.IndexOf(row)).Delete()
            '    End If
            'Next

            'cnt = dtDocImage.Rows.Count - 1

            'While cnt <> -1

            '    If dtDocImage.Rows(cnt)("FKeyIDNbr") = FKeyIDNbr Then
            '        dtDocImage.Rows(cnt).Delete()
            '    End If

            '    cnt = cnt - 1
            'End While

            For i As Integer = dtDocImage.Rows.Count - 1 To 0 Step -1
                If dtDocImage.Rows(i)("FKeyIDNbr") = FKeyIDNbr Then
                    dtDocImage.Rows(i).Delete()
                End If
            Next
        Catch ex As Exception
            ret = False
        End Try


        Return ret
    End Function

    Public Function deleteDocs(FKeyIDNbr As String, Description As String) As Boolean '\\ run to clean the datatable by IDNbr
        Dim ret As Boolean = True

        Try
            'For Each row In dtDocImage.Rows
            '    If row("FKeyIDNbr") = FKeyIDNbr And row("Description") = Description Then
            '        dtDocImage.Rows(dtDocImage.Rows.IndexOf(row)).Delete()
            '    End If
            'Next

            For i As Integer = dtDocImage.Rows.Count - 1 To 0 Step -1
                If dtDocImage.Rows(i)("FKeyIDNbr") = FKeyIDNbr And dtDocImage.Rows(i)("Description") = Description Then
                    dtDocImage.Rows(i).Delete()
                End If
            Next

        Catch ex As Exception
            ret = False
        End Try


        Return ret
    End Function

    Public Function getDocs(Optional FKeyIDNbr As String = Nothing) As DataTable
        Dim retdt As New DataTable, rowsfiltered() As DataRow

        If Not FKeyIDNbr Is Nothing Then
            rowsfiltered = dtDocImage.Select("FKeyIDNbr = '" & FKeyIDNbr & "'")

            If rowsfiltered.Length > 0 Then
                retdt = rowsfiltered.CopyToDataTable()
            Else
                retdt = dtDocImage.Clone
            End If
        Else
            retdt = dtDocImage.Copy
        End If

        Return (retdt)
    End Function

    Public Function saveDtToDb(activityKey As String, FKeyIDNbr As String) As DataTable
        Dim retdt As New DataTable

        Call saveImage(activityKey, getDocs(FKeyIDNbr))

        Return retdt
    End Function

    Private Function saveImage(activityKey As String, filtDT As DataTable, Optional par_errmsg As String = Nothing) As Boolean
        Dim ret As Boolean = True
        Dim query As New ArrayList
        Dim LastUpdatedBy As String = ""
        Dim count As Integer = 0, editedcount As Integer = 0
        Dim strID As String = ""
        Dim sql As String, prefiletag As String = ""
        Dim docPKey As String = "", errmsg As String = ""
        Dim previousIDNBr As String = "" 'newIDNbrEncountered As Boolean = True,
        Dim retmsg As String = ""

        ' Try

        For Each row In filtDT.Rows


            'With Me.viewImages


            'If Not isThereAChange() Then
            '    MsgBox("No Record(s) to save.", vbInformation)
            '    Return ret
            'End If

            Dim intmo As Integer = filtDT.Rows.IndexOf(row) ', existingActKey As String


            var_crewid = row("FKeyIDNbr")
            var_dateissue_s = IfNull(Format(row("DateIssue"), "yyyyMMdd") & "_", "")
            var_dateissue = row("DateIssue")
            ' var_dateexpire = dateexpire
            ' var_dateexpire_s = dateexpire
            var_vslname = row("VslName")
            ' ShowCustomLoadScreen(GetType(MPS4.Waitform), , "Saving Document...")

            '    For intmo = 0 To .RowCount - 1


            prefiletag = var_crewid & "_" & CONST_FILETAG & "_" & var_dateissue_s & intmo

            'MsgBox(.ActiveEditor.OldEditValue() & " " & .ActiveEditor.EditValue)
            ' MsgBox(row("FilePath") & " _ " & .GetRowCellDisplayText(intmo, "FilePath"))

            ' If row("Edited") And Not viewImagesrow("Description").Equals(System.DBNull.Value) Then

            LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Activity Documents", 0, System.Environment.MachineName, var_vslname & " \ " & var_dateissue & " \ " & _
                                                 row("Description"), actname & " - Activity Document", var_crewid)

            'Insert
            'If row("FPathEdited") Then
            ' Dim errmsg As String = ""


            'If clsdoc.LinkDocument(row("FilePath"), var_crewid, CONST_FILETAG, var_dateissue_s & intmo, errmsg) Then
            'LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Activity Documents", 0, System.Environment.MachineName, row("VslName") & " \ " & var_dateissue & " \ " &
            '                                         row("Description")).ToString.Replace("'", "''"), "Activity Document", var_crewid)
            ' If IfNull(row("DocImgPKey"), "") = "" Then
            ' existingActKey = MPSDB.DLookUp("PKey", "tbldocument", "", "FKeyActivity ='" & var_actkey & "'")
            'If existingActKey = "" Then

            If previousIDNBr <> row("FKeyIDNbr") Then
                previousIDNBr = row("FKeyIDNbr")
                retmsg = insertActivityDoc(activityKey, var_crewid, var_dateissue, var_dateexpire,
                                          CONST_FILETAG, docPKey, , )
            Else
                retmsg = ""
            End If

            If retmsg <> "" Then
                'MsgBox(errmsg)
            Else
                'MsgBox(docPKey)
                If clsdoc.LinkDocument(row("FilePath"), var_crewid, CONST_FILETAG, var_dateissue_s & intmo, errmsg) Then
                    'Call clsdoc.LinkDocument(row("FilePath"), var_crewid, CONST_FILETAG, var_dateissue_s & intmo)

                    sql = "INSERT INTO dbo.tblDocImage(FKeyIDNbr,FKeyCrewDocumentID,Description,FilePath,LastUpdatedBy)" & _
                              "VALUES(" & _
                              "'" & var_crewid & "'" & _
                              ",'" & docPKey & "'" & _
                              ",'" & row("Description") & "'" & _
                              ",'" & prefiletag & "'" & _
                              ",'" & LastUpdatedBy & "')"
                    'MPSDB.RunSql(sql)
                    query.Add(sql)
                Else
                    ' MsgBox("Something went wrong. Cannot save the Document." & vbCrLf & errmsg, vbExclamation)
                    errmsg = errmsg & " \ " & "Cannot link document :" & var_crewid & "\" & row("FilePath")
                End If
            End If

            'End If

            ' End If

            'Else

            'End If

            'If (Not IfNull(row("FilePath"), "").ToString.Equals(IfNull(row("FileName"), ""))) And Not IfNull(row("FilePath"), "").ToString.Equals("") Then
            '    DocStr = IfNull(row("FilePath"), "") & "|" & _
            '             IfNull(row("FileName"), "")
            '    count = count + 1
            '    DocumentList.Add(New Dictionary(Of Integer, String)() From {{count, DocStr}})
            'End If


            'If row("FPathEdited") Then
            'Call LinkDocument(row("FilePath"), var_crewid, CONST_FILETAG, var_dateissue_s & intmo)
            'End If
            'End If
        Next

        Try
            If query.Count > 0 Then
                MPSDB.RunSqls(query)
            End If
        Catch ex As Exception
            errmsg = errmsg & " \ " & ex.Message
            ret = False
        End Try

        ' CloseCustomLoadScreen()
        'End With

        'Next

        'MsgBox("Record(s) saved.", vbInformation)
        'repBtnBrowse.Buttons(0).Enabled = False
        'closeConn()
        'Catch ex As Exception
        '    ret = False
        'End Try

        Return ret
    End Function

    'Private Function LinkDocument(_SourceFile As String, _IDNbr As String, _FileTag As String,
    '                            _DateIssue As String, Optional ByRef errmsg As String = "") As Boolean

    '    Dim ret As Boolean = True
    '    Dim strDir As String = ""
    '    Dim fileName As String = ""
    '    Dim fileExt As String = ""
    '    Dim fName As String = ""

    '    Try
    '        strDir = FOLDERDIRECTORY & "\" & _IDNbr & "\"
    '        fileExt = System.IO.Path.GetExtension(_SourceFile)
    '        fileName = _IDNbr & "_" & _FileTag & "_" & _DateIssue & fileExt
    '        fName = _IDNbr & "_" & _FileTag & "_" & _DateIssue

    '        If (Not System.IO.Directory.Exists(strDir)) Then
    '            System.IO.Directory.CreateDirectory(strDir)
    '        End If

    '        If (System.IO.File.Exists(strDir & "\" & fileName)) Then
    '            replaceCrewDoc(_SourceFile, fName)
    '        Else
    '            Dim fP As String = ""
    '            fP = GenerateCrewFilePath(fName)
    '            If System.IO.File.Exists(fP) Then
    '                Kill(fP)
    '            End If
    '            clsdoc.ExportCrewDocToPdf(_SourceFile, _IDNbr, _FileTag, _DateIssue)
    '        End If
    '    Catch ex As Exception
    '        ret = False
    '        errmsg = ex.Message ' MsgBox(ex.Message, MsgBoxStyle.Critical, GetAppName)
    '    End Try

    '    Return ret
    'End Function

    Public Sub New(activityName As String, db As SQLDB) '// activityName = {SignOn, SignOff, Transfer, Promote etc}
        MPSDB = db

        dtDocImage = New DataTable("DocImage")

        dtDocImage.Columns.Add("FKeyIDNbr", Type.GetType("System.String"))
        dtDocImage.Columns.Add("DocImgPKey", Type.GetType("System.String"))
        dtDocImage.Columns.Add("ActivityPKey", Type.GetType("System.String"))
        dtDocImage.Columns.Add("FKeyDocument", Type.GetType("System.String"))
        dtDocImage.Columns.Add("Description", Type.GetType("System.String"))
        dtDocImage.Columns.Add("FilePath", Type.GetType("System.String"))
        dtDocImage.Columns.Add("DateIssue", Type.GetType("System.DateTime"))
        dtDocImage.Columns.Add("VslName", Type.GetType("System.String"))
        dtDocImage.Columns.Add("Edited", Type.GetType("System.String"))
        dtDocImage.Columns.Add("FPathEdited", Type.GetType("System.String"))
        dtDocImage.Columns.Add("LastUpdatedBy", Type.GetType("System.String"))

        actname = activityName

        'var_actkey = activityKey


        'clsSec.propSQLConnStr = MPSDB.GetConnectionString
    End Sub

    Public Function insertActivityDoc(FKeyActivity As String,
                                      FKeyIDNbr As String,
                                      DateIssue As Date,
                                      DateExpiry As Date,
                                      FileTag As String,
                                      ByRef sRetLogPKey As String,
                                      Optional dDateUpdated As Date = Nothing,
                                      Optional LastUpdatedBy As String = "",
                                      Optional closeconn As Boolean = False
                                                              ) As String

        Dim sRetString As String = ""
        'Dim sqlConn As New SqlClient.SqlConnection

        Dim sqlComm As New SqlCommand()

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            'dbconn.closeconn()
            sqlConn.Open()

            If sqlConn.State <> ConnectionState.Open Then
                sRetString = "sql connection is nothing"
            Else

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "SP_addActivityDoc"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("FKeyActivity", FKeyActivity)
                sqlComm.Parameters.AddWithValue("FKeyIDNbr", FKeyIDNbr)
                If DateIssue = Nothing Then
                    'sqlComm.Parameters.AddWithValue("DateIssue", DBNull.Value)
                Else
                    sqlComm.Parameters.AddWithValue("DateIssue", DateIssue)
                End If
                If DateExpiry = Nothing Then
                    'sqlComm.Parameters.AddWithValue("DateExpiry", DBNull.Value)
                Else
                    sqlComm.Parameters.AddWithValue("DateExpiry", DateExpiry)
                End If
                sqlComm.Parameters.AddWithValue("FileTag", FileTag)
                If dDateUpdated = Nothing Then
                    ' sqlComm.Parameters.AddWithValue("DateUpdated", DBNull.Value)
                Else
                    sqlComm.Parameters.AddWithValue("DateUpdated", dDateUpdated)
                End If

                If LastUpdatedBy = Nothing Then
                    sqlComm.Parameters.AddWithValue("LastUpdatedBy", DBNull.Value)
                Else
                    sqlComm.Parameters.AddWithValue("LastUpdatedBy", LastUpdatedBy)
                End If

                sqlComm.Parameters.Add("insertedID", SqlDbType.NVarChar, 20)
                sqlComm.Parameters("insertedID").Direction = ParameterDirection.Output

                Try
                    sqlComm.ExecuteNonQuery()
                    sRetLogPKey = sqlComm.Parameters("insertedID").Value
                Catch SqlEx As SqlException
                    Dim myError As SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    For Each myError In SqlEx.Errors
                        sRetString = sRetString & " / " & (myError.Number & " - " & myError.Message)
                    Next
                End Try


            End If

            If closeconn Then
                sqlConn.Close()
            Else
            End If

        End Using

        Return sRetString
    End Function

    Protected Overrides Sub Finalize()
        If sqlConn.State = ConnectionState.Open Then
            sqlConn.Close()
        End If
        MyBase.Finalize()
    End Sub
End Class
