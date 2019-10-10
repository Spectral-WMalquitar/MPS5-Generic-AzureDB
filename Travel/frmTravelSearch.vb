Public Class frmTravelSearch
    Dim strFilter As String = ""
    Dim strTravelType As String = ""
    Dim db As SQLDB
    Public param() As Object

    Public Sub New(ByVal sqldb As SQLDB, ByVal TravelType As String)
        InitializeComponent()
        db = sqldb
        strTravelType = TravelType
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        If Trim(txtLName.Text).Length = 0 And Trim(txtFName.Text).Length = 0 And Trim(txtMName.Text).Length = 0 Then
            MsgBox("Please input lastname, firstname or middle name.", MsgBoxStyle.Information = MsgBoxStyle.OkOnly, GetAppName() & " - Search")
        Else
            Dim sql As String = "SELECT  te.FKeyReferenceID as RefID, dbo.AssembleName(ci.LName,ci.FName,ci.MName,0,1,0,0,0) AS Crew, te.PKey, te.ReqArrDate, te.DepPlace, te.ArrPlace FROM tblTravelEvent te INNER JOIN tblTravelEventCrew pec ON pec.FKeyTravelEvent = te.Pkey " & _
                                "LEFT JOIN tblCrewinfo ci ON ci.PKey = pec.FKeyCrewID " & _
                                "WHERE pec.FKeyCrewID IN (SELECT PKey FROM tblCrewInfo WHERE " & strCrewFilter() & ") AND te.TravelEventType = '" & strTravelType & "' AND te.FKeyReferenceID IS NOT NULL"
            Dim dt As DataTable = db.CreateTable(sql)
            Maingrid.DataSource = dt
        End If
    End Sub

    Private Function strCrewFilter() As String
        Dim strRet As String = ""

        If Trim(txtLName.Text).Length > 0 Then
            strRet = " LName LIKE '%" & txtLName.Text & "%'"
        End If

        If Trim(txtFName.Text).Length > 0 Then
            If strRet.Length > 0 Then strRet = strRet & " AND FName LIKE '%" & txtFName.Text & "%' " Else strRet = " FName LIKE '%" & txtFName.Text & "%' "
        End If

        If Trim(txtMName.Text).Length > 0 Then
            If strRet.Length > 0 Then strRet = strRet & " AND MName LIKE '%" & txtMName.Text & "%' " Else strRet = " MName LIKE '%" & txtMName.Text & "%' "
        End If

        Return strRet
    End Function

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtFName.Text = ""
        txtLName.Text = ""
        txtMName.Text = ""
        Maingrid.DataSource = Nothing
    End Sub

    Private Sub btnView_Click(sender As System.Object, e As System.EventArgs) Handles btnView.Click
        If Mainview.DataRowCount > 0 Then
            'param(0) PlanID
            'param(1) Travel Event PKey
            param = New Object() {Mainview.GetFocusedRowCellValue("RefID"), Mainview.GetFocusedRowCellValue("PKey")}
        Else
            param = Nothing
        End If
        Me.Hide()
    End Sub

End Class