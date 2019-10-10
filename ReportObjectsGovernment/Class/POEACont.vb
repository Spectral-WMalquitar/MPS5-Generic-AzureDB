Imports Utilities
Imports MPS4

Public Class POEACont
    Public MainReport As New rptPOEACont

    Private Const CUSTOM_POEA_CONTRACT = "CUSTOM_POEA_CONTRACT"

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        If REPORT_DETAIL.ReportInfo.ObjectID = CUSTOM_POEA_CONTRACT Then
            dt = GenerateCustomPOEAReportSrc(REPORT_DETAIL)
        Else
            cSQL = "SELECT * FROM rpt_POEACont "

            If MainReportFilter.Length > 0 Then
                cSQL = cSQL & " WHERE " & MainReportFilter & " "
            End If

            If Sorting.Length > 0 Then
                cSQL = cSQL & " ORDER BY " & Sorting & " "
            End If


            dt = MPSDB.CreateTable(cSQL)
        End If

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        BindData(MainReport.celCrew, "Text", Nothing, "CrewProper")
        BindData(MainReport.celAddr, "Text", Nothing, "Addr")
        BindData(MainReport.celDOB, "Text", Nothing, "DOB", "{0:dd-MMM-yyyy}")
        BindData(MainReport.celPOB, "Text", Nothing, "POB")
        BindData(MainReport.celSIRBNo, "Text", Nothing, "SIRBNo")
        BindData(MainReport.celSRCNo, "Text", Nothing, "SRCNo")
        BindData(MainReport.celPRCNo, "Text", Nothing, "PRCNo")

        BindData(MainReport.celAgent, "Text", Nothing, "AgentName")
        BindData(MainReport.celPrinName, "Text", Nothing, "PrinName")
        BindData(MainReport.celPrinAddr, "Text", Nothing, "PrinAddr")
        BindData(MainReport.celVslName, "Text", Nothing, "VslName")
        BindData(MainReport.celVslIMO, "Text", Nothing, "IMONo")
        BindData(MainReport.celVslGRT, "Text", Nothing, "GrossTon")
        BindData(MainReport.celVslYrBuilt, "Text", Nothing, "YrBuilt")
        BindData(MainReport.celVslFlag, "Text", Nothing, "Flag")
        BindData(MainReport.celVslType, "Text", Nothing, "VslType")
        BindData(MainReport.celVslClass, "Text", Nothing, "Class")

        BindData(MainReport.celLOC, "Text", Nothing, "LOC")
        BindData(MainReport.celRank, "Text", Nothing, "Rank")
        BindData(MainReport.celBasic, "Text", Nothing, "Basic")
        BindData(MainReport.celWorkHours, "Text", Nothing, "WorkHours")
        BindData(MainReport.celOT, "Text", Nothing, "OT")
        BindData(MainReport.celLeavePay, "Text", Nothing, "LeavePay")
        BindData(MainReport.celPlaceHired, "Text", Nothing, "PlaceHired")
        BindData(MainReport.celCBA, "Text", Nothing, "CBA")
        BindData(MainReport.celOtherEarn, "Text", Nothing, "OtherEarn")

        BindData(MainReport.celCrewSign, "Text", Nothing, "CrewSign")

        If REPORT_DETAIL.ReportInfo.ObjectID = CUSTOM_POEA_CONTRACT Then
            Dim strContDate As String = REPORT_DETAIL.Params.Find("Date")
            Dim dContDate As Date
            If strContDate.Length <> 0 Then
                Try
                    dContDate = CDate(strContDate)
                    MainReport.celDay.Text = NumberToOrdinal(DatePart(DateInterval.Day, dContDate)).ToUpper
                    MainReport.celMonth.Text = Format(dContDate, "MMMM").ToUpper
                    MainReport.celYear.Text = DatePart(DateInterval.Year, dContDate)
                Catch ex As Exception
                    'do nothing
                End Try
                
            End If

            MainReport.celAgentPlace.Text = IfNull(REPORT_DETAIL.Params.Find("Place"), "").ToUpper
            MainReport.celSignatory.Text = IfNull(REPORT_DETAIL.Params.Find("Signatory"), "").ToUpper

        Else
            Dim strContDate As String = REPORT_DETAIL.FilterOption.GetFilterValue("Date")
            Dim dContDate As Date
            If strContDate.Length <> 0 Then
                dContDate = CDate(strContDate)
                MainReport.celDay.Text = NumberToOrdinal(DatePart(DateInterval.Day, dContDate)).ToUpper
                MainReport.celMonth.Text = Format(dContDate, "MMMM").ToUpper
                MainReport.celYear.Text = DatePart(DateInterval.Year, dContDate)
            End If

            MainReport.celAgentPlace.Text = REPORT_DETAIL.FilterOption.GetFilterValue("City", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToUpper
            MainReport.celSignatory.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToUpper & " / " & REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.EditValue).ToUpper
        End If
        

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
    End Sub

    Private Function GenerateCustomPOEAReportSrc(ByRef REPORT_DETAIL As Reports.ReportDetail) As DataTable
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

                sqlComm.CommandText = "RPT_CustomPOEAContract"
                sqlComm.CommandType = CommandType.StoredProcedure

                sqlComm.Parameters.AddWithValue("FKeyIDNbr", REPORT_DETAIL.Params.Find("FKeyIDNbr"))
                sqlComm.Parameters.AddWithValue("FKeyWScaleRank", REPORT_DETAIL.Params.Find("FKeyWScaleRank"))
                sqlComm.Parameters.AddWithValue("FKeyAgent", REPORT_DETAIL.Params.Find("FKeyAgent"))
                sqlComm.Parameters.AddWithValue("FKeyPrincipal", REPORT_DETAIL.Params.Find("FKeyPrincipal"))
                sqlComm.Parameters.AddWithValue("FKeyVsl", REPORT_DETAIL.Params.Find("FKeyVsl"))
                sqlComm.Parameters.AddWithValue("FKeyRank", REPORT_DETAIL.Params.Find("FKeyRank"))
                sqlComm.Parameters.AddWithValue("FKeyPort", REPORT_DETAIL.Params.Find("FKeyPort"))
                sqlComm.Parameters.AddWithValue("LOC", REPORT_DETAIL.Params.Find("LOC"))
                sqlComm.Parameters.AddWithValue("LOCDays", REPORT_DETAIL.Params.Find("LOCDays"))

                'Dim retParameter As IDbDataParameter = sqlComm.CreateParameter()
                'retParameter.ParameterName = "@ReturnValue"
                'retParameter.Direction = System.Data.ParameterDirection.Output
                'retParameter.DbType = System.Data.DbType.String
                'retParameter.Size = -1
                'sqlComm.Parameters.Add(retParameter)

                da.SelectCommand = sqlComm

                Try
                    'sqlComm.ExecuteNonQuery()
                    'returnVal = retParameter.Value
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
End Class
