Public Class MonthlyR1A
    Public MainReport As New rptMonthlyR1A

    Private MCode As Integer
    Private MCodeDesc As String
    Private ExRate As Double = 0

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable = Nothing
        Dim cSQL As String = ""
        Dim strExRate = REPORT_DETAIL.FilterOption.GetFilterValue("PHP to USD Ex Rate", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False)

        If REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False) = "" Then
            MsgBox("Please select period.", MsgBoxStyle.OkOnly, GetAppName)
            Exit Sub
        End If

        MCode = REPORT_DETAIL.FilterOption.GetFilterValue("Period", BaseFilterOption.GetFilterReturnWhat.EditValue, False)

        If IsNumeric(strExRate) Then
            ExRate = CDbl(strExRate)
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        ShowCustomLoadScreen(GetType(MPS4.Waitform), "Building Data...")
        'cSQL = "SELECT		 " & _
        '       "            ci.PKey CrewID, " & _
        '       "            ci.lname, " & _
        '       "            ci.FName, " & _
        '       "            ci.MName, " & _
        '       "            ci.DOB, " & _
        '       "            acts.RankName, " & _
        '       "            acts.DateSOn, " & _
        '                    IIf(ExRate <> 0, "isnull([basic].amt,0) * " & ExRate & " Gross ", "") & _
        '                    IIf(ExRate = 0, "isnull([basic].amt,0) Gross ", "") & _
        '       "FROM		dbo.tblcrewinfo ci INNER JOIN " & _
        '       "            (SELECT ag.FKeyIDNbr, a.* FROM dbo.tblActivity a INNER JOIN dbo.tblActivityGroup ag ON a.FKeyActivityGroupID = ag.PKey WHERE ag.IsCompServ <> 0 AND ag.ActivityType = 'SEA' AND dateson is not null AND format(dateson, 'yyyyMM') = " & IfNull(MCode, 0) & " AND a.FKeyStatCode <> 'SYSPROMOTE') acts ON acts.FKeyIDNbr = ci.PKey LEFT JOIN " & _
        '       "            (SELECT * FROM dbo.tblAdmWscaleOnb WHERE FKeyWageOnb = 'SYSPAYBASIC') [basic] ON [basic].FKeyWScaleRank = acts.FKeyWScaleRankCode"

        'dt = MPSDB.CreateTable(cSQL)
        dt = GenerateReportDataSource_MCRSSS(REPORT_DETAIL)
        CloseCustomLoadScreen()

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        With MainReport
            .DataSource = dt
            .Name = REPORT_DETAIL.ReportObjectID

            'Header
            BindData(.celEmployerName, "Text", Nothing, "EmployerName")

            'SSS
            'Dim SSNo As String = MPSDB.GetConfig("SSSNBR")
            'If IfNull(SSNo, "").Length > 0 Then
            '    .celEmployerSSNumber1.Text = Mid(SSNo, 1, 1)
            '    .celEmployerSSNumber2.Text = Mid(SSNo, 2, 1)
            '    .celEmployerSSNumber3.Text = Mid(SSNo, 3, 1)
            '    .celEmployerSSNumber4.Text = Mid(SSNo, 4, 1)
            '    .celEmployerSSNumber5.Text = Mid(SSNo, 5, 1)
            '    .celEmployerSSNumber6.Text = Mid(SSNo, 6, 1)
            '    .celEmployerSSNumber7.Text = Mid(SSNo, 7, 1)
            '    .celEmployerSSNumber8.Text = Mid(SSNo, 8, 1)
            '    .celEmployerSSNumber9.Text = Mid(SSNo, 9, 1)
            '    .celEmployerSSNumber10.Text = Mid(SSNo, 10, 1)
            '    .celEmployerSSNumber11.Text = Mid(SSNo, 11, 1)
            '    .celEmployerSSNumber12.Text = Mid(SSNo, 12, 1)
            '    .celEmployerSSNumber13.Text = Mid(SSNo, 13, 1)
            'End If
            BindData(.celEmployerSSNumber1, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber1.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber2, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber2.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber3, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber3.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber4, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber4.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber5, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber5.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber6, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber6.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber7, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber7.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber8, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber8.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber9, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber9.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber10, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber10.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber11, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber11.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber12, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber12.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            BindData(.celEmployerSSNumber13, "Text", Nothing, "PrinSSSNo")
            AddHandler MainReport.celEmployerSSNumber13.BeforePrint, AddressOf PrinSSSNoLabel_BeforePrint

            'TelNo
            Dim TelNo As String = GetNumbersOnly(MPSDB.GetConfig("PHONE"))

            If IfNull(TelNo, "").Length > 0 Then
                .celTelNo1.Text = Mid(TelNo, 1, 1)
                .celTelNo2.Text = Mid(TelNo, 2, 1)
                .celTelNo3.Text = Mid(TelNo, 3, 1)
                .celTelNo4.Text = Mid(TelNo, 4, 1)
                .celTelNo5.Text = Mid(TelNo, 5, 1)
                .celTelNo6.Text = Mid(TelNo, 6, 1)
                .celTelNo7.Text = Mid(TelNo, 7, 1)
                .celTelNo8.Text = Mid(TelNo, 8, 1)
                .celTelNo9.Text = Mid(TelNo, 9, 1)
                .celTelNo10.Text = Mid(TelNo, 10, 1)
            End If

            .celEmployerAddr.Text = MPSDB.GetConfig("Addr")

            'Detail
            BindData(.celLName, "Text", Nothing, "LName")
            BindData(.celFName, "Text", Nothing, "FName")
            BindData(.celMName, "Text", Nothing, "MName")
            BindData(.celDOB, "Text", Nothing, "DOB", "{0:MM/dd/yyyy}")
            BindData(.celDateOfEmployment, "Text", Nothing, "DateSOn", "{0:MM/dd/yyyy}")
            BindData(.celMonthlyEarning, "Text", Nothing, "Gross", "{0:n2}")
            BindData(.celPosition, "Text", Nothing, "RankName")
            BindData(.celSSNumber, "Text", Nothing, "SSSNo")

            'Footer
            .celTotalEmployees.Text = dt.Rows.Count
            BindData(.celTotalEmployees, "Text", Nothing, "CrewID")
            .celDate.Text = Format(getServerDateTime(), "dd/MMM/yyyy")

            'Signatory
            .celSignatory.Text = IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue, False), "").ToString.ToUpper
            .celSignatoryPosition.Text = IfNull(REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue, False), "").ToString.ToUpper

            AddFieldsToGroupHeaderBand(.GroupHeaderMain, "EmployerName", FieldSortOrder.Ascending)
            AddSortFieldsToDetailBandFromDT(.Detail, "LName", FieldSortOrder.Ascending)
            AddSortFieldsToDetailBandFromDT(.Detail, "FName", FieldSortOrder.Ascending)
            AddSortFieldsToDetailBandFromDT(.Detail, "MName", FieldSortOrder.Ascending)
        End With


        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport

        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

#Region "Generate Data Source"
    Private Function GenerateReportDataSource_MCRSSS(ByRef REPORT_DETAIL As Reports.ReportDetail) As DataTable
        Dim ReturnValue As DataTable = Nothing
        Dim sqlConn As New SqlClient.SqlConnection

        Using sqlConn
            sqlConn.ConnectionString = MPSDB.GetConnectionString
            Try
                sqlConn.Open()
            Catch ex As Exception
                MsgBox("Failed to build report data source." & vbNewLine & "Error: " & ex.Message, MsgBoxStyle.Critical)
                Return Nothing
            End Try

            If sqlConn.State <> ConnectionState.Open Then
                MsgBox("Failed to build report data source.", MsgBoxStyle.Critical)
                Return Nothing
            Else
                Dim sqlComm As New System.Data.SqlClient.SqlCommand
                Dim da As New System.Data.SqlClient.SqlDataAdapter

                sqlComm.Connection = sqlConn

                sqlComm.CommandText = "RPT_MonthlyR1A"
                sqlComm.CommandType = CommandType.StoredProcedure
                sqlComm.CommandTimeout = 1000

                sqlComm.Parameters.AddWithValue("Period", MCode)
                sqlComm.Parameters.AddWithValue("PrintSelection", REPORT_DETAIL.PresentRecord.Table)
                sqlComm.Parameters.AddWithValue("ExRate", ExRate)

           
                da.SelectCommand = sqlComm

                Try
                    Dim dt As New DataTable
                    da.Fill(dt)

                    ReturnValue = dt

                Catch SqlEx As System.Data.SqlClient.SqlException
                    Dim myError As System.Data.SqlClient.SqlError
                    Debug.WriteLine("Errors Count:" & SqlEx.Errors.Count)
                    Dim returnErr As String = ""
                    For Each myError In SqlEx.Errors
                        returnErr = returnErr & " / " & (myError.Number & " - " & myError.Message)
                    Next

                    MsgBox("Failed to build report data source." & vbNewLine & "Error: " & returnErr, MsgBoxStyle.Critical)
                    Return Nothing
                End Try

            End If
            sqlConn.Close()
        End Using
        Return ReturnValue

        Exit Function
    End Function

#End Region

    Private Function GetNumbersOnly(strval As String) As String
        Dim ReturnValue As String = ""

        Try
            Dim myChars() As Char = strval.ToCharArray()
            For Each ch As Char In myChars
                If Char.IsDigit(ch) Then
                    ReturnValue = ReturnValue & ch.ToString
                End If
            Next
        Catch ex As Exception
            ReturnValue = ""
        End Try


        Return ReturnValue
    End Function


    Private Sub PrinSSSNoLabel_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        Dim xrl As DevExpress.XtraReports.UI.XRLabel = CType(sender, DevExpress.XtraReports.UI.XRLabel)
        Dim startPos As Integer = 20 'the prior 19 letters spell the colletive control name "celEmployerSSNumber"

        Dim newValue As String = ""
        Try
            Dim nNo As Object = Mid(xrl.Name, startPos)

            If IsNumeric(nNo) Then
                If nNo > 0 Then
                    newValue = Mid(IfNull(xrl.Text, ""), CInt(nNo), 1)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        xrl.Text = newValue
    End Sub
End Class

