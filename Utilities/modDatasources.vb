Public Module modDatasources
#Region "Datasource Datatable Declarations"
    Dim dtCrewlist As New DataTable
    Dim _strCLFilter As String = String.Empty
#End Region

#Region "Datasource Last Update Dates Declarations"
    Dim crewlistLastUpdateDate As New DateTime
#End Region

    Public Function CrewList_Datasource(ByVal db As SQLDB, ByVal expDocDays As Integer, ByVal expDueDateDays As Integer, ByVal userdatafilter As String) As DataTable

        If Not _strCLFilter.Equals(userdatafilter) Then
            _strCLFilter = userdatafilter
            ClearDtCrewList()
        End If

        If dtCrewlist.Rows.Count = 0 Then
            dtCrewlist = db.CreateTable("EXEC [SP_Crewlist_Activities] @ExpDocDays = " & expDocDays & ", @ExpContractDays = " & expDueDateDays & ", @userdatafilterstring = '" & userdatafilter & "'")
            dtCrewlist.PrimaryKey = New DataColumn() {dtCrewlist.Columns("IDNbr")}
            crewlistLastUpdateDate = Now
        Else
            Try
                Dim dt As New DataTable
                dt = db.CreateTable("EXEC [SP_Crewlist_Activities] @ExpDocDays = " & expDocDays & ", @ExpContractDays = " & expDueDateDays & ", @userdatafilterstring = '" & userdatafilter & "', @lastUpdateDate = " & ChangeToSQLDate(crewlistLastUpdateDate) & "")
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim drFound As DataRow = dtCrewlist.Rows.Find(dt.Rows(i)("IDNbr"))
                        'Dim drNew As DataRow = dt.Rows(i)
                        Dim drNew As DataRow = dtCrewlist.NewRow
                        drNew.ItemArray = dt.Rows(i).ItemArray.Clone

                        Dim index As Integer = -1
                        Try
                            index = dtCrewlist.Rows.IndexOf(drFound)
                        Catch
                            index = -1
                        End Try
                        If drFound IsNot Nothing Then
                            dtCrewlist.Rows.Remove(drFound)
                        End If
                        If index >= 0 Then
                            dtCrewlist.Rows.InsertAt(drNew, index)
                        Else
                            dtCrewlist.ImportRow(drNew)
                        End If

                    Next
                    crewlistLastUpdateDate = Now
                End If
            Catch ex As Exception
                MsgBox("Error in Loading Crewlist Data: " & ex.Message)
            End Try
        End If

        If dtCrewlist.Rows.Count > 0 Then
            dtCrewlist.Select("", "LName, FName, MName").CopyToDataTable()
        Else
            dtCrewlist = dtCrewlist.Clone
        End If

        Return dtCrewlist
    End Function

    Public Sub ClearDtCrewList()
        dtCrewlist.Clear()
    End Sub

End Module
