Imports System.Collections
Imports System.Windows.Forms
Imports Utilities
Imports System.Data

Public Class RptVettingMatrixReportChevronTotal

    Private ReadOnly _report As New VettingMatrixReportChevronTotal

    Public Sub New(ByVal db As SQLDB, ByVal sourceQuery As String)
        Try
            Dim dt As DataTable
            Dim sql As String = ""
            Dim sIDNbrs As String = GetInCriteria(sourceQuery.Substring(sourceQuery.IndexOf("(", StringComparison.Ordinal))).Replace("('0',", "").Replace(")", "")

            GetSelectedIdNbrs(sIDNbrs, db)

            Dim hasResult As Boolean = db.RunSql("EXEC dbo.GenerateTempTableForVettingMatrix_Shell_Chevron 'temp_VettingMatrixChevron','" & Qualification.QualificationMatrix.VesselCode & "'")

            If (hasResult) Then
                sql = "SELECT * FROM view_VettingMatrixChevron WHERE IDNbr IN (''," & sIDNbrs & ")  ORDER BY SortCode"
            Else
                MessageBox.Show(String.Format("There is a problem generating the needed data for Vetting Matrix Chevron and Total. The report will not open"),
                String.Format("Vetting Matrix Report"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If (_report Is Nothing) Then
                Return
            End If

            With _report
                dt = db.CreateTable(sql)
                .DataSource = dt
                BindData(.lblCrew, "Text", Nothing, "Crew")
                BindData(.lblMSTCO_YrsCurrRank, "Text", Nothing, "MSTCO_YrsCurrRank")
                BindData(.lblCE1AE_YrsCurrRank, "Text", Nothing, "CE1AE_YrsCurrRank")
                BindData(.lblMSTCO_YrsWOperator, "Text", Nothing, "MSTCO_YrsWithOperator")
                BindData(.lblCE1AE_YrsWOperator, "Text", Nothing, "CE1AE_YrsWithOperator")
                BindData(.lblMSTCO_YrsOnTankerType, "Text", Nothing, "MSTCO_YrsOnTankerType")
                BindData(.lblCE1AE_YrsOnTankerType, "Text", Nothing, "CE1AE_YrsOnTankerType")
                .lblVessel.Text = Qualification.QualificationMatrix.VesselName.ToUpper()
                .lblDatePrinted.Text = DateTime.Now.ToString("MM/dd/yyyy")
                .ShowPreviewDialog()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, String.Format("MPS 4 Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetInCriteria(inCriteria As String) As String
        Dim returnVal As String = ""
        For i As Int32 = 0 To inCriteria.Length - 1
            returnVal += inCriteria(i)
            If inCriteria(i).ToString().Equals(")") Then
                Exit For
            End If
        Next
        Return returnVal
    End Function

    Public Sub GetSelectedIdNbrs(idnbr As String, db As SQLDB)
        Dim queries As New ArrayList()
        Dim separator As Char() = {","}
        Dim idnbrs As String() = idnbr.Split(separator)
        Dim retVal As String = ""

        For i As Int32 = 0 To idnbrs.Length - 1
            retVal += "(" & idnbrs(i) & "),"
        Next

        retVal = retVal.Substring(0, retVal.LastIndexOf(",", StringComparison.Ordinal))

        Try
            queries.Add("DELETE FROM dbo.tbl_temp_selected_IDNbrs")
            queries.Add("INSERT INTO dbo.tbl_temp_selected_IDNbrs ( idnbrs ) VALUES " & retVal)
            db.RunTransaction(queries)
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

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
