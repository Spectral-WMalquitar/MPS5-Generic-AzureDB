Public Class clsFeatureMod
    Public Function getFeaturelist() As DataTable
        Dim table As New DataTable

        table.Columns.Add("Value", GetType(String))
        table.Columns.Add("Feature", GetType(String))
        table.Columns.Add("Checked", GetType(Boolean)) 'value for checkbox,

        table.Rows.Add("a", "A. Activity", False)
        table.Rows.Add("b", "B. Graphical Planning", False)
        table.Rows.Add("c", "C. Planning", False)
        table.Rows.Add("d", "D. Travel", False)
        table.Rows.Add("e", "E. Check List", False)
        table.Rows.Add("f", "F. Qualification", False)
        table.Rows.Add("g", "G. DMS", False)
        table.Rows.Add("h", "H. Report s", False)
        table.Rows.Add("i", "I. KPI", False)
        table.Rows.Add("j", "J. Payroll", False)
        table.Rows.Add("k", "K. Archive", False)
        table.Rows.Add("l", "L. Government", False)
        table.Rows.Add("m", "M. Default", True)
        table.Rows.Add("n", "N. Audit", False)
        table.Rows.Add("o", "O. Security", False)
        table.Rows.Add("p", "P. Career Planning", False)
        table.Rows.Add("q", "Q. BDO Remittance System", False)
        table.Rows.Add("r", "R. BPI Exporting", False)
        table.Rows.Add("s", "S. GTRS (G Travel Service)", False)
        '///table.Rows.Add("", "", False) - Add new feature here

        'added by tony20190712
        table.Rows.Add("t", "T. Query Builder", False)
        table.Rows.Add("u", "U. Scheduled Emailing", False)
        table.Rows.Add("z", "Z. Disabled Feature", False)
        'end tony

        Return table
    End Function

    Public Function getClientFeatures(CompanyIDFromConfig As String, CoyFeatKey As String) As DataTable
        'Dim featureID As String = "X7YCTze+CVZuAWrMitsJHxT8uiET5fQ9UZY2nW4dMHw=" 'to be replaced
        'Dim featureID As String = "Tu/UD3wEWNGi9i681yDpmg==" 'to be replaced
        'Dim featureID As String = "AwiJogGSQFm48kTJRARNwg==" 'test with wrong company ID
        Dim dt As New DataTable, decryptedID As String, arrayDecrypt() As String
        Dim dectryptErrMsg As String = ""

        decryptedID = AES_Decrypt(CoyFeatKey, "spectral", dectryptErrMsg)

        If dectryptErrMsg = "" Then

            arrayDecrypt = decryptedID.Split(";")

            dt.Columns.Add("fFeatLetter", GetType(String))

            For i As Integer = 1 To arrayDecrypt.Count - 1
                dt.Rows.Add(arrayDecrypt(i))
            Next

            If arrayDecrypt(0) = CompanyIDFromConfig Then
                Return dt
            Else
                dt.Reset()
                dt.Columns.Add("fFeatLetter", GetType(String))
                dt.Rows.Add("m") 'If Company ID is not equal to the one on the key, give them Default feature
                Return dt
            End If
        Else
            dt.Reset()
            dt.Columns.Add("fFeatLetter", GetType(String))
            dt.Rows.Add("m") 'If Company ID is not equal to the one on the key, give them Default feature
            Return dt
        End If
    End Function

    Function filterTableByFeature(ByRef ObjectReportsTbl As DataTable, CompanyIDFromConfig As String,
                                  Optional CompanyFeatKey As String = "vK3rPWiEIz7gS172dmVwyrZbNMj1lqzl7PCGTRYy7/0SV1+9uMqXdF5f5NUj51px") As String
        '// the default CompanyFeatKey value above will give the company with company ID of '0001' with all the feature.
        '// function is use to filter datatable(of objects/reports) data by clients licensed features
        '// Param ObjectReportsTbl => table contains the list of objects or reports. 
        '//                        => must have the columns ObjectID and FID 
        '// Function is use with conjunction to functions clsSecurity.get_permissions_all or clsSecurity.get_Reports
        '// Sample use:
        '//         sql_reportlist = clsSec.get_reports(USER_ID, ReportsTable, "ONBOARD PAYROLL (QUICK VIEW)")
        '//         ReportsTable = clsFeature.filterTableByFeature(ReportsTable, COMPANYID, FEATUREKEY)

        Dim res As String = "", dtfilter As New DataTable, dtObjecsDecrypted As New DataTable, dt As New DataTable

        Try
            If ObjectReportsTbl.Rows.Count > 0 Then

                dtfilter = getClientFeatures(CompanyIDFromConfig, CompanyFeatKey)
                If dtfilter.Rows.Count > 0 Then

                    res = decryptTable(ObjectReportsTbl)

                    If res <> "" Then
                        ObjectReportsTbl.Rows.Clear()
                        Exit Try
                    End If

                    'dtObjecsDecrypted = ObjectReportsTbl

                    For i As Integer = 0 To ObjectReportsTbl.Rows.Count - 1
                        If dtfilter.Select("fFeatLetter = '" & ObjectReportsTbl.Rows(i)("oFeatLetter") & "'").Count = 0 Then
                            ObjectReportsTbl.Rows(i).Delete() 'delete objects not in the feature list
                        End If
                    Next

                    ObjectReportsTbl.AcceptChanges()
                    'dt = ObjectReportsTbl
                Else
                    ObjectReportsTbl.Rows.Clear()
                    ' dt = ObjectReportsTbl
                End If
                'ObjectReportsTbl = view.ToTable()
            Else
                ObjectReportsTbl.Rows.Clear()
                'dt = ObjectReportsTbl
            End If

            'ObjectReportsTbl = dtObjecsDecrypted.GetChanges
            'dt = dtObjecsDecrypted.GetChanges
        Catch ex As Exception
            res = ex.Message
        End Try

        Return res
    End Function

    Function decryptTable(ByRef dt As DataTable) As String
        Dim sret As String = ""
        Dim dectryptErrMsg As String = "", arr() As String

        Try
            If dt.Rows.Count > 0 Then
                Dim temps As String
                dt.Columns.Add("oFeatLetter", GetType(String))

                For Each row In dt.Rows
                    If Not IsDBNull(row("FID")) Then
                        temps = AES_Decrypt(row("FID"), "spectral", dectryptErrMsg)
                        arr = temps.Split("_")
                        Debug.Print(temps)
                        If dectryptErrMsg = "" Then
                            'If Left(temps, temps.Length - 2) = Trim(row("ObjectID")) Then
                            If Left(temps, temps.Length - ((arr(arr.GetUpperBound(0)).Length) + 1)) = Trim(row("ObjectID")) Then
                                'row("oFeatLetter") = Right(temps, 1)
                                row("oFeatLetter") = arr(arr.GetUpperBound(0))
                            Else
                                row("oFeatLetter") = "MM"
                            End If
                        Else
                            row("oFeatLetter") = "ERROR"
                        End If
                        dectryptErrMsg = ""
                    Else
                        row("oFeatLetter") = "ERROR"
                    End If
                Next

            Else

            End If
        Catch ex As Exception
            sret = ex.Message
        End Try

        Return sret
    End Function

    Public Function isObjectInFeature(ObjectID As String, dt As DataTable) As Boolean
        '// example use
        '// Ret = clsfeat.isObjectInFeature("Activity_Docs", userPermDt) '/// userPermDt is a global object. You can already pass this object
        Dim ret As Boolean = False

        If Not IsNothing(dt) Then
            If dt.Select("Objectid='" & ObjectID & "'").Count > 0 Then
                ret = True
            End If
        End If

        Return ret
    End Function

    Public Function HasFeature(COMPANYID As String, FEATUREKEY As String, FeatureLetter As String) As Boolean
        Try
            Dim dt As DataTable = getClientFeatures(COMPANYID, FEATUREKEY)
            Dim row As DataRow()
            row = dt.Select("fFeatLetter = '" & FeatureLetter & "'")
            Return row.Count > 0
        Catch ex As Exception
            Return False
        End Try
        

    End Function
End Class
