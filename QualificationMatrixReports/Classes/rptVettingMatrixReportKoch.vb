Imports System.Windows.Forms
Imports Utilities
Imports System.Data
Imports System.Collections

Public Class rptVettingMatrixReportKoch

    Private ReadOnly _report As New VettingMatrixReportKoch

    Public Sub New(ByVal db As SQLDB, ByVal sourceQuery As String)
        Try
            Dim dt As DataTable
            Dim sql As String = sourceQuery
            Dim sIDNbrs As String = GetInCriteria(sourceQuery.Substring(sourceQuery.IndexOf("(", StringComparison.Ordinal))).Replace("('0',", "").Replace(")", "")

            OpenWaitForm()

            GetSelectedIdNbrs(sIDNbrs, db)

            Dim hasResult As Boolean = db.RunSql("EXEC dbo.GenerateTempTableForVettingMatrix 'temp_VettingMatrixKoch','" & Qualification.QualificationMatrix.VesselCode & "'")

            If (hasResult) Then
                sql = "SELECT * FROM dbo.VettingMatrixKoch() WHERE IDNbr IN " & sourceQuery.Substring(sourceQuery.IndexOf("(", StringComparison.Ordinal))
            Else
                MessageBox.Show(String.Format("There is a problem generating the needed data for Vetting Matrix Chevron and Total. The report will not open"),
                                String.Format("Vetting Matrix Report"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If (_report Is Nothing) Then
                CloseWaitForm()
                Return
            End If

            With _report
                dt = db.CreateTable(sql)
                If (dt.Rows.Count <= 0) Or (dt Is Nothing) Then
                    CloseWaitForm()
                    MessageBox.Show(String.Format("There is no record found!"), String.Format("Qualifcation Matrix"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                .DataSource = dt
                BindData(.lblCrewName, "Text", Nothing, "Abbrv")
                BindData(.lblTimeInCurrentRank, "Text", Nothing, "MonthsInRank")
                BindData(.lblTimeOnTankers, "Text", Nothing, "MonthsInTanker")
                .lblVessel.Text = Qualification.QualificationMatrix.VesselName.ToUpper()
                .lblDatePrinted.Text = DateTime.Now.ToString("dd-MMM-yyyy")
                CloseWaitForm()
                .ShowPreviewDialog()
            End With
        Catch ex As Exception
            CloseWaitForm()
            MessageBox.Show(ex.Message, String.Format(GetAppName() & " Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GetSelectedIdNbrs(idnbr As String, db As SQLDB)
        Dim queries As New ArrayList()
        Dim separator As Char() = {","}
        Dim idnbrs As String() = idnbr.Split(separator)
        'Dim retVal As String = ""

        Dim query As New System.Text.StringBuilder("")

        For i As Int32 = 0 To idnbrs.Length - 1
            'retVal += "(" & idnbrs(i) & "),"
            query.Append("(" & idnbrs(i) & "),")
        Next

        'retVal = retVal.Substring(0, retVal.LastIndexOf(",", StringComparison.Ordinal))
        query = New System.Text.StringBuilder(query.ToString().Substring(0, query.ToString().LastIndexOf(",", StringComparison.Ordinal)))
        Try
            queries.Add("DELETE FROM dbo.tbl_temp_selected_IDNbrs")
            queries.Add("INSERT INTO dbo.tbl_temp_selected_IDNbrs ( idnbrs ) VALUES " & query.ToString())
            db.RunSqls(queries)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        Finally
            queries = Nothing
            separator = Nothing
            idnbrs = Nothing
            query = Nothing
        End Try
    End Sub

    Public Function GetInCriteria(inCriteria As String) As String
        'Dim returnVal As String = ""
        Dim query As New System.Text.StringBuilder("")
        For i As Int32 = 0 To inCriteria.Length - 1
            'returnVal += inCriteria(i)
            query.Append(inCriteria(i))
            If inCriteria(i).ToString().Equals(")") Then
                Exit For
            End If
        Next
        Return query.ToString()
    End Function

    Sub New()

    End Sub

    Public Sub BindData(ByVal sender As Object, ByVal nProperty As String, ByVal dbSource As String, ByVal nFieldName As String, Optional ByVal nFormat As String = "")
        Try
            Dim nType As Type = sender.GetType
            Select Case nType.Name
                Case "XRLabel"
                    TryCast(sender, DevExpress.XtraReports.UI.XRLabel).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, dbSource, nFieldName, nFormat))
                Case "XRTableCell"
                    TryCast(sender, DevExpress.XtraReports.UI.XRTableCell).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, dbSource, nFieldName, nFormat))
                Case "XRPictureBox"
                    TryCast(sender, DevExpress.XtraReports.UI.XRPictureBox).DataBindings.Add(New DevExpress.XtraReports.UI.XRBinding(nProperty, dbSource, nFieldName, nFormat))
            End Select
        Catch ex As Exception
            Throw (New Exception(ex.Message))
        End Try
    End Sub

End Class
