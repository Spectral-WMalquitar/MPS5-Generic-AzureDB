Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms

Public Class ExcelFile
    Private ExcelConn As OleDb.OleDbConnection

    Public Sub New(Str_FilePath As String, JetVersion As String)
        strFilePath = Str_FilePath
        ExcelConn.ConnectionString = StrConnString(JetVersion)

    End Sub

    Private _strFilePath As String = ""
    Public Property strFilePath() As String
        Get
            Return _strFilePath
        End Get
        Set(ByVal value As String)
            _strFilePath = value
        End Set
    End Property

    Private _StrConnString As String = ""
    Public ReadOnly Property StrConnString(Optional JetVersion As String = "4.0", Optional strFile_Path As String = "") As String
        Get
            Dim strFPath As String = String.Empty
            If strFile_Path.Trim.Length > 0 Then
                strFPath = strFile_Path
            Else
                strFPath = strFilePath()
            End If
            Dim str As String = String.Empty
            If JetVersion = "4.0" Then
                str = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                                "Data Source= " & strFPath & _
                                ";Extended Properties=""Excel 8.0;"""
            ElseIf JetVersion = "12.0" Then
                str = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                                "Data Source= " & strFPath & _
                                ";Extended Properties=""Excel 12.0 Xml;HDR=YES;"""
            Else
                str = ""
            End If
            _StrConnString = str
            Return _StrConnString
        End Get
    End Property

    Private Function TestConnection() As Boolean
        Dim retval As Boolean = False
        Try
            ExcelConn.Open()
            retval = True
            Return retval
        Catch ex As Exception
            retval = False
            Return retval
        Finally
            If ExcelConn.State() = ConnectionState.Open Then
                ExcelConn.Close()
            End If
        End Try
    End Function


    Public Function CreateTable(strSheet As String) As DataTable
        Dim retVal As New DataTable

        Try
            ExcelConn.Open()
            Using cmd As New OleDb.OleDbCommand
                cmd.Connection = ExcelConn
                cmd.CommandText = "SELECT * FROM [" & strSheet & "$]"
                Using adp As New OleDb.OleDbDataAdapter(cmd)
                    adp.Fill(retVal)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If ExcelConn.State = ConnectionState.Open Then ExcelConn.Close()
        End Try
        Return retVal
    End Function

    Public Function CreateTable(strFPath As String, strSheet As String, JetVersion As String) As DataTable
        Dim retVal As New DataTable
        Dim exConn As New OleDb.OleDbConnection(StrConnString(JetVersion, strFPath))
        Try
            exConn.Open()
            Using cmd As New OleDb.OleDbCommand
                cmd.Connection = exConn
                cmd.CommandText = "SELECT * FROM [" & strSheet & "$]"
                Using adp As New OleDb.OleDbDataAdapter(cmd)
                    adp.Fill(retVal)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If exConn.State = ConnectionState.Open Then exConn.Close()
        End Try
        Return retVal
    End Function

    Public Sub CreateWorkbook()
        Dim xlApp As Excel.Application = New Excel.Application()
        If IsNothing(xlApp) Then
            MsgBox("Excell is not properly installed!!")
            Exit Sub
        End If

        Dim xlWorkBook As New Excel.Workbook
        Dim xlWorkSheet As New Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlWorkBook = xlApp.Workbooks.Add(misValue)
        'xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        'xlWorkSheet = xlWorkBook.Sheets("Sheet2")
        'xlWorkSheet = xlWorkBook.Sheets("Sheet3")

        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls"
        sfd.Title = "Save Template To"
        sfd.ShowDialog()



    End Sub
End Class
