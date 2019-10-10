Imports DevExpress.XtraSplashScreen
Public Class frmMultipleFiles
    Dim sourceDT As New DataTable
    Dim fileName As String
    Dim idCREW, idDOC As String
    Dim db As SQLDB
    Dim compID As String

    Public Sub New(ByVal crewName As String, ByVal Doc As String, ByVal dbFileName As String, ByVal dt As DataTable, ByVal crewID As String, ByVal docID As String, ByVal mpsdb As SQLDB)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblCrewName.Caption = "Crew: " & crewName
        lblDocument.Caption = "Document: " & Doc
        fileName = dbFileName
        compID = fileName.Split("_").GetValue(0).ToString
        idCREW = crewID
        idDOC = docID
        db = mpsdb
        setupDT(dt)
    End Sub

    Private Sub setupDT(ByVal dt As DataTable)
        Dim clmn As DataColumn

        clmn = New DataColumn
        clmn.ColumnName = "Description"
        clmn.DataType = System.Type.GetType("System.String")
        sourceDT.Columns.Add(clmn)

        clmn = New DataColumn
        clmn.ColumnName = "Source"
        clmn.DataType = System.Type.GetType("System.String")
        sourceDT.Columns.Add(clmn)

        clmn = New DataColumn
        clmn.ColumnName = "FileName"
        clmn.DataType = System.Type.GetType("System.String")
        sourceDT.Columns.Add(clmn)

        sourceDT = dt
        Maingrid.DataSource = sourceDT
    End Sub

    Private Sub btnSaveFile_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSaveFile.ItemClick
        Try
            Dim nFailed As Integer = 0
            If MainView.RowCount > 0 Then
                SplashScreenManager.ShowForm(GetType(DMS_Waitform))
                RibbonControl1.Focus()
                For i As Integer = 0 To MainView.RowCount - 1
                    ExportCrewDocToPdf(MainView.GetRowCellValue(i, "Source"), compID, "", "", MainView.GetRowCellValue(i, "FileName"))
                    db.RunSql("INSERT INTO tblDocImage(FKeyIDNbr, FKeyCrewDocumentID, [Description], FilePath) " & _
                              "VALUES('" & idCREW & "','" & idDOC & "','" & MainView.GetRowCellValue(i, "Description") & "','" & MainView.GetRowCellValue(i, "FileName") & "')")
                Next
                MsgBox("Upload successful!", MsgBoxStyle.Information, GetAppName)
                Me.Hide()
            End If
        Catch ex As Exception
            MsgBox("MPS5 - DMS :" & ex.Message, MsgBoxStyle.Information, GetAppName)
        Finally
            SplashScreenManager.CloseForm()
        End Try
    End Sub

    Private Sub btnRemoveFile_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRemoveFile.ItemClick
        MainView.DeleteSelectedRows()
    End Sub
End Class