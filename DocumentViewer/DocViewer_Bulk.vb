Imports DevExpress.XtraSplashScreen
Public Class DocViewer_Bulk
    Private dt As DataTable
    Public crewDocList As DataTable
    Public uploadDone As Boolean = False
    Dim initiated As Boolean = False
    Dim Auto As Boolean = False

    Public Sub New(ByVal param() As Object)
        InitializeComponent()
        If param(0) = "Notif" Then
            If param(2) <> "" Then
                Dim files() As String = System.IO.Directory.GetFiles(param(2))
                If files.Count > 0 Then
                    For i As Integer = 0 To files.Count - 1
                        crewDocList = param(3)
                        initDatatable()
                        supplyData(files(i))
                    Next
                    If param(1) = "Auto" Then
                        Auto = True
                        cmdLink_Click(Nothing, Nothing)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GridControl1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridControl1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        If files.Count > 0 Then
            For i As Integer = 0 To files.Count - 1
                If files(i).Contains(GetAppPath()) Then
                    MsgBox("Please select another folder, this folder and sub folders are reserved for " & GetAppName() & ".")
                    Exit Sub
                Else
                    supplyData(files(i))
                End If
            Next
        End If
    End Sub

    Private Sub GridControl1_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles GridControl1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub DocViewer_Bulk_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        initDatatable()
        GridControl1.DataSource = dt
    End Sub

    Private Sub initDatatable()
        If initiated = False Then
            dt = New DataTable
            dt.Columns.Add("Document")
            dt.Columns.Add("Filename")
            dt.Columns.Add("Remarks")
            dt.Columns.Add("Valid")
            dt.Columns.Add("CrewName")
            initiated = True
        End If
    End Sub

    Private Sub supplyData(ByVal filepath As String)
        Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(filepath).ToString
        Dim reqFile As New ArrayList
        Dim param() As String = filename.Split("_")
        Dim doc As String = ""
        Dim rmks As String = ""
        Dim vld As String = ""
        Dim cName As String = ""

        If param.Count = 3 Then
            reqFile = validateFile(filename)
            If reqFile.Count > 0 Then
                cName = reqFile(0)
                doc = reqFile(1)
                rmks = reqFile(2)
                vld = reqFile(3)
                'dateIss = param(2).Substring(6) & " " & MonthName(param(2).Substring(4, 2)) & " " & param(2).Substring(0, 4)
            End If
        ElseIf param.Count < 3 Then
            doc = ""
            rmks = "Please make sure that the filename follows the format: CompanyIDNo_Filetag_DateIssue(ex. 001_PP_20150601.jpg)."
            vld = "Invalid File."
        End If

        Dim dr As DataRow = dt.NewRow()
        dr("Document") = doc
        dr("Filename") = filepath
        dr("Remarks") = rmks
        If vld = "" Then dr("Valid") = "Invalid File." Else dr("Valid") = vld
        dr("CrewName") = cName
        dt.Rows.Add(dr)
        GridControl1.DataSource = dt
    End Sub


    Private Function validateFile(ByVal filename As String) As ArrayList
        Dim res As New ArrayList
        Dim rowCnt As Integer
        Dim hits As Integer = 0
        Dim noHits As Integer = 0

        For i As Integer = 0 To crewDocList.Rows.Count - 1
            If filename = crewDocList.Rows(i).Item("Filename").ToString Then
                hits += 1
                rowCnt = i
            Else
                If noHits = 0 Then
                    If IsDBNull(crewDocList.Rows(i).Item("Filename")) = False Then
                        If crewDocList.Rows(i).Item("Filename").ToString.Split("_").GetValue(1) = filename.Split("_").GetValue(1) Then
                            res.Add(crewDocList.Rows(i).Item("CrewName").ToString)
                            res.Add(crewDocList.Rows(i).Item("DocType").ToString)
                            res.Add("Document dont exist.")
                            res.Add("Invalid File.")
                            noHits += 1
                        End If
                    End If
                End If
            End If
        Next

        If hits > 0 Then
            res.Clear()
            res.Add(crewDocList.Rows(rowCnt).Item("CrewName").ToString)
            res.Add(crewDocList.Rows(rowCnt).Item("DocType").ToString)
            If checkIfExist(filename) Then
                res.Add("A link already exists. Remove if you don't want to replace the existing link.")
            Else
                res.Add("File ready for linking.")
            End If
            res.Add("Valid File.")
        End If

        Return res
    End Function

    Private Function checkIfExist(ByVal filename As String) As Boolean
        Dim res As Boolean = False
        Dim files() As String
        If System.IO.Directory.Exists(GetCrewDocsPath() & "\" & filename.Split("_").GetValue(0).ToString) = False Then
            System.IO.Directory.CreateDirectory(GetCrewDocsPath() & "\" & filename.Split("_").GetValue(0).ToString)
        End If
        files = System.IO.Directory.GetFiles(GetCrewDocsPath() & "\" & filename.Split("_").GetValue(0).ToString)
        For i As Integer = 0 To files.Length - 1
            If files(i).Contains(filename) Then
                res = True
                Exit For
            End If
        Next
        Return res
    End Function

    Private Sub cmdRemoveAll_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemoveAll.ItemClick
        For i As Integer = Mainview.RowCount - 1 To 0 Step -1
            If Mainview.GetRowCellValue(i, "Valid").ToString = "Invalid File." Then
                Mainview.DeleteRow(i)
            End If
        Next
    End Sub

    Private Sub cmdRemove_Click(sender As System.Object, e As System.EventArgs) Handles cmdRemove.ItemClick
        Mainview.DeleteSelectedRows()
    End Sub

    Private Sub cmdLink_Click(sender As System.Object, e As System.EventArgs) Handles cmdLink.ItemClick
        Try
            SplashScreenManager.ShowForm(GetType(DMS_Waitform))
            Dim filename As String = ""
            Dim param() As String
            For i As Integer = 0 To Mainview.RowCount - 1
                If Mainview.GetRowCellValue(i, "Valid").ToString = "Valid File." Then
                    filename = System.IO.Path.GetFileNameWithoutExtension(Mainview.GetRowCellValue(i, "Filename").ToString)
                    param = filename.Split("_")
                    Try
                        If Auto = False Then
                            If Mainview.GetRowCellValue(i, "Remarks").ToString = "A link already exists. Remove if you don't want to replace the existing link." Then
                                replaceCrewDocToPdf(filename, Mainview.GetRowCellValue(i, "Filename").ToString)
                                Mainview.SetRowCellValue(i, "Remarks", "Replace Link Successful.")
                                Continue For
                            End If
                        Else
                            If Mainview.GetRowCellValue(i, "Remarks").ToString = "A link already exists. Remove if you don't want to replace the existing link." Then
                                Continue For
                            End If
                        End If
                        ExportCrewDocToPdf(Mainview.GetRowCellValue(i, "Filename").ToString, param(0), param(1), param(2))
                        Mainview.SetRowCellValue(i, "Remarks", "Link Successful.")
                    Catch ex As Exception
                        Mainview.SetRowCellValue(i, "Remarks", "Linking Failed.: " & ex.Message)
                    End Try
                End If
            Next
            'SplashScreenManager.Default.SetWaitFormCaption("Bulk Link Successful.")
            SplashScreenManager.Default.SetWaitFormDescription("")
            Threading.Thread.Sleep(2000)
            SplashScreenManager.CloseForm()
            'MsgBox("Upload successful!")
            uploadDone = True
        Catch ex As Exception
            MsgBox(GetAppName() & " Error:" & ex.Message)
            SplashScreenManager.Default.SetWaitFormDescription("")
            Threading.Thread.Sleep(2000)
            SplashScreenManager.CloseForm()
        End Try
    End Sub

    Private Sub cmdBrowse_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdBrowse.ItemClick
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub Mainview_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles Mainview.RowCellStyle
        If e.CellValue = "Link Successful." Or e.CellValue = "Replace Link Successful." Then
            e.Appearance.BackColor = System.Drawing.Color.LightGreen
            e.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        ElseIf e.CellValue = "Invalid File." Then
            e.Appearance.ForeColor = System.Drawing.Color.DarkRed
        ElseIf e.CellValue = "Valid File." Then
            e.Appearance.ForeColor = System.Drawing.Color.Green
        End If
    End Sub

End Class