Public Class AppraisalSub
    Inherits EditFormUserControl
    Protected DB As SQLDB
    Public Sub New(_DB As SQLDB)
        InitializeComponent()
        DB = _DB
        Dim tblRate As DataTable = DB.CreateTable("SELECT * FROM dbo.tblAdmRate ORDER BY SortCode ASC, Name ASC")
        Dim tblRankList As DataTable = DB.CreateTable("SELECT * FROM dbo.RankList ORDER BY SortCode ASC, Name ASC")

        Me.cboFKeyRank.Properties.DataSource = tblRankList
        Me.cboPromoteTo.Properties.DataSource = tblRankList
        Me.cboVsl.Properties.DataSource = DB.CreateTable("SELECT PKey,Name,Abbrv,SortCode FROM dbo.VslList ORDER BY Name ASC")

        'characteristics
        Dim ratingsTable As DataTable = GetRatings()
        cboPC.Properties.DataSource = ratingsTable
        cboCA.Properties.DataSource = ratingsTable
        cboAttitude.Properties.DataSource = ratingsTable
        cboJCS.Properties.DataSource = ratingsTable
        cboLeadership.Properties.DataSource = ratingsTable
        cboPP.Properties.DataSource = ratingsTable
        cboSC.Properties.DataSource = ratingsTable

    End Sub

    Private Function GetRatings() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.Int16")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {1, "Outstanding"}
        ctable.Rows.Add(crow)
        crow(0) = 2
        crow(1) = "Very Good"
        ctable.Rows.Add(crow)
        crow(0) = 3
        crow(1) = "Good"
        ctable.Rows.Add(crow)
        crow(0) = 4
        crow(1) = "Acceptable"
        ctable.Rows.Add(crow)
        crow(0) = 5
        crow(1) = "Poor"
        ctable.Rows.Add(crow)
        crow(0) = 6
        crow(1) = "Very Poor"
        ctable.Rows.Add(crow)
        crow(0) = 5
        crow(1) = "Unfit"
        ctable.Rows.Add(crow)
        Return ctable
    End Function
End Class
