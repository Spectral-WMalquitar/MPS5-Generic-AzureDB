
Public Module CrewingModule
#Region "Crew Functions"
    Private Function CleanTableInput(StrInput As Object) As String
        If Trim(IfNull(StrInput, "")).Equals("") Then
            Return "NULL"
        Else
            Return "'" & StrInput.ToString.Replace("'", "''") & "'"
        End If
    End Function

#End Region

#Region "Crewing"
    Private sqlConn As New SqlClient.SqlConnection(MPSDB.GetConnectionString)
    'For Other Sea Service: Adding and Updating
    Public Function SaveCrewOtherService(IDNbr As String, GrdView As DevExpress.XtraGrid.Views.Grid.GridView, Optional LastUpdatedBy As String = "NULL") As Boolean
        Dim hasActGroup As Boolean = False, isActInserted As Boolean = False
        Dim sqlTrans As SqlClient.SqlTransaction = Nothing 'transaction
        Dim retval As Boolean = False
        Dim strActGroupID As String = ""
        Try
            sqlConn.Open()
            sqlTrans = sqlConn.BeginTransaction()
            With GrdView
                .CloseEditForm()
                .UpdateCurrentRow()
                For cRowHandle As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(cRowHandle, "Edited") Then

                        Dim DateDep As String = ChangeToSQLDate(DBNull.Value)
                        If .GetRowCellValue(cRowHandle, "DateSOff").ToString <> "" Then
                            DateDep = ChangeToSQLDate(CDate(.GetRowCellValue(cRowHandle, "DateSOff")))
                        End If

                        Dim DateArr As String = ChangeToSQLDate(DBNull.Value)
                        If .GetRowCellValue(cRowHandle, "DateSOn").ToString <> "" Then
                            DateArr = ChangeToSQLDate(CDate(.GetRowCellValue(cRowHandle, "DateSOn")))
                        End If

                        Dim PlaceDep As String = CleanTableInput(.GetRowCellValue(cRowHandle, "PlaceSOff"))
                        Dim PlaceArr As String = CleanTableInput(.GetRowCellValue(cRowHandle, "PlaceSOn"))
                        Dim VslName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "VslName"))
                        Dim DeadWt As String = CleanTableInput(.GetRowCellValue(cRowHandle, "DeadWt"))
                        Dim GrossTon As String = CleanTableInput(.GetRowCellValue(cRowHandle, "GrossTon"))
                        Dim EngType As String = CleanTableInput(.GetRowCellValue(cRowHandle, "EngType"))
                        Dim EngPower As String = CleanTableInput(.GetRowCellValue(cRowHandle, "EngPower"))
                        Dim YrBuilt As String = CleanTableInput(.GetRowCellValue(cRowHandle, "YrBuilt"))
                        Dim Auxillaries As String = CleanTableInput(.GetRowCellValue(cRowHandle, "Auxillaries"))
                        Dim PrinName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "PrinName"))
                        Dim AgentName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "AgentName"))
                        Dim FltMgrName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "FltMgrName"))
                        Dim StatName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "StatName"))

                        Dim ActDateEnd As String = ChangeToSQLDate(DBNull.Value)
                        If .GetRowCellValue(cRowHandle, "ActDateEnd").ToString <> "" Then
                            ActDateEnd = ChangeToSQLDate(CDate(.GetRowCellValue(cRowHandle, "ActDateEnd")))
                        End If

                        Dim ActDateStart As String = ChangeToSQLDate(DBNull.Value)
                        If .GetRowCellValue(cRowHandle, "ActDateStart").ToString <> "" Then
                            ActDateStart = ChangeToSQLDate(CDate(.GetRowCellValue(cRowHandle, "ActDateStart")))
                        End If

                        Dim RankName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "RankName"))
                        Dim Remarks As String = CleanTableInput(.GetRowCellValue(cRowHandle, "Remarks"))

                        Dim SOFFStat As String = CleanTableInput(.GetRowCellValue(cRowHandle, "SOFFStat"))

                        If IfNull(.GetRowCellValue(cRowHandle, "ActGroupID"), "").Equals("") Then 'Add Activity
                            'Insert ActivityGroup
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.CommandText = "INSERT dbo.tblActivityGroup(" & _
                                    " FKeyIDNbr,ActivityType," & _
                                    " COIDNbr,LName," & _
                                    " FName,MName," & _
                                    " DOB,NatCode," & _
                                    " NatName,DateDep," & _
                                    " DateArr,PlaceDep," & _
                                    " PlaceArr," & _
                                    " LOC,LOCDays,IsCompServ)" & _
                                    " SELECT tCrew.PKey,'OTH'," & _
                                    " tCrew.COIDNo,tCrew.LName," & _
                                    " tCrew.FName,tCrew.MName," & _
                                    " tcrew.DOB,tCrew.NatCode," & _
                                    " tcntry.Name," & DateDep & "," & _
                                    " " & DateArr & "," & PlaceDep & "," & _
                                    " " & PlaceArr & ",0,0,0" & _
                                    " FROM dbo.tblCrewInfo tCrew" & _
                                    " INNER JOIN dbo.tblAdmCntry tcntry ON tcrew.NatCode = tcntry.PKey" & _
                                    " WHERE tCrew.PKey = '" & IDNbr & "'"
                                cmd.Transaction = sqlTrans
                                hasActGroup = (cmd.ExecuteNonQuery().Equals(1))
                            End Using

                            'get the id of the Inserted Row
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.CommandText = "SELECT [PKey] FROM mps.dbo.tblActivityGroup WHERE ID=IDENT_CURRENT('tblActivityGroup')"
                                cmd.Transaction = sqlTrans
                                strActGroupID = cmd.ExecuteScalar()
                            End Using

                            'insert Activity
                            If Not strActGroupID.Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlConn
                                    cmd.Transaction = sqlTrans
                                    cmd.CommandText = "INSERT INTO dbo.tblActivity( " & _
                                        " FKeyActivityGroupID,VslName," & _
                                        " DeadWt,	GrossTon," & _
                                        " EngType,EngPower," & _
                                        " YrBuilt,Auxillaries," & _
                                        " PrinName,AgentName," & _
                                        " FltMgrName,StatName," & _
                                        " ActDateEnd,ActDateStart," & _
                                        " RankName,DateSOff," & _
                                        " DateSOn,PlaceSOn," & _
                                        " PlaceSOff,	Remarks," & _
                                        " LastUpdatedBy)" & _
                                        " VALUES(" & _
                                        " '" & strActGroupID & "'," & VslName & "," & _
                                        " " & DeadWt & "," & GrossTon & "," & _
                                        " " & EngType & "," & EngPower & "," & _
                                        " " & YrBuilt & "," & Auxillaries & "," & _
                                        " " & PrinName & "," & AgentName & "," & _
                                        " " & FltMgrName & "," & StatName & "," & _
                                        " " & DateDep & "," & DateArr & "," & _
                                        " " & RankName & "," & DateDep & "," & _
                                        " " & DateArr & "," & PlaceArr & "," & _
                                        " " & PlaceDep & ",	" & Remarks & "," & _
                                        " '" & LastUpdatedBy.Replace("<TO_REPLACE>", .GetRowCellValue(cRowHandle, "VslName")).ToString.Replace("'", "''") & "')"
                                    isActInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            End If
                        Else 'Update

                            If Not IfNull(.GetRowCellValue(cRowHandle, "ActGroupID"), "").Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlConn
                                    cmd.Transaction = sqlTrans
                                    cmd.CommandText = "UPDATE dbo.tblActivityGroup" & _
                                            " SET SOFFStat=" & SOFFStat & _
                                            " WHERE PKey = '" & .GetRowCellValue(cRowHandle, "ActGroupID") & "'"
                                    isActInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            End If

                            If Not IfNull(.GetRowCellValue(cRowHandle, "ActID"), "").Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlConn
                                    cmd.Transaction = sqlTrans
                                    cmd.CommandText = "UPDATE dbo.tblActivity" & _
                                            " SET VslName=" & VslName & _
                                            " ,DeadWt=" & DeadWt & _
                                            " ,GrossTon=" & GrossTon & _
                                            " ,EngType=" & EngType & _
                                            " ,EngPower=" & EngPower & _
                                            " ,YrBuilt=" & YrBuilt & _
                                            " ,Auxillaries=" & Auxillaries & _
                                            " ,PrinName=" & PrinName & _
                                            " ,AgentName=" & AgentName & _
                                            " ,FltMgrName=" & FltMgrName & _
                                            " ,StatName=" & StatName & _
                                            " ,ActDateEnd=" & ActDateEnd & _
                                            " ,ActDateStart=" & ActDateStart & _
                                            " ,RankName=" & RankName & _
                                            " ,DateSOff=" & DateDep & _
                                            " ,DateSOn=" & DateArr & _
                                            " ,PlaceSOn=" & PlaceArr & _
                                            " ,PlaceSOff=" & PlaceDep & _
                                            " ,Remarks=" & Remarks & _
                                            " ,LastUpdatedBy='" & LastUpdatedBy.Replace("<TO_REPLACE>", .GetRowCellValue(cRowHandle, "VslName")) & "'" & _
                                            " ,DateUpdated=(getdate())" & _
                                            " WHERE PKey = '" & .GetRowCellValue(cRowHandle, "ActID") & "'"
                                    isActInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            End If
                        End If
                    End If
                Next
            End With
            If isActInserted Then
                sqlTrans.Commit()
                retval = True
            End If
        Catch ex As Exception
            sqlTrans.Rollback()
            retval = False
        Finally
            sqlConn.Close()
        End Try
        Return retval
    End Function



    Public Function SaveCrewOtherService2(IDNbr As String, GrdView As DevExpress.XtraGrid.Views.Grid.GridView, Optional LastUpdatedBy As String = "NULL") As Boolean
        Dim hasActGroup As Boolean = False, isActInserted As Boolean = False
        Dim sqlTrans As SqlClient.SqlTransaction = Nothing 'transaction
        Dim retval As Boolean = False
        Dim strActGroupID As String = ""
        Try
            sqlConn.Open()
            sqlTrans = sqlConn.BeginTransaction()
            With GrdView
                .CloseEditForm()
                .UpdateCurrentRow()
                For cRowHandle As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(cRowHandle, "Edited") Then
                        Dim DateDep As String = ChangeToSQLDate(DBNull.Value)
                        If .GetRowCellValue(cRowHandle, "DateSOff").ToString <> "" Then
                            DateDep = ChangeToSQLDate(CDate(.GetRowCellValue(cRowHandle, "DateSOff")))
                        End If
                        Dim DateArr As String = ChangeToSQLDate(DBNull.Value)
                        If .GetRowCellValue(cRowHandle, "DateSOn").ToString <> "" Then
                            DateArr = ChangeToSQLDate(CDate(.GetRowCellValue(cRowHandle, "DateSOn")))
                        End If
                        Dim PlaceDep As String = CleanTableInput(.GetRowCellValue(cRowHandle, "PlaceSOff"))
                        Dim PlaceArr As String = CleanTableInput(.GetRowCellValue(cRowHandle, "PlaceSOn"))
                        Dim VslName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "VslName"))
                        Dim DeadWt As String = CleanTableInput(.GetRowCellValue(cRowHandle, "DeadWt"))
                        Dim GrossTon As String = CleanTableInput(.GetRowCellValue(cRowHandle, "GrossTon"))
                        Dim EngType As String = CleanTableInput(.GetRowCellValue(cRowHandle, "EngType"))
                        Dim EngPower As String = CleanTableInput(.GetRowCellValue(cRowHandle, "EngPower"))
                        Dim YrBuilt As String = CleanTableInput(.GetRowCellValue(cRowHandle, "YrBuilt"))
                        Dim Auxillaries As String = CleanTableInput(.GetRowCellValue(cRowHandle, "Auxillaries"))
                        Dim PrinName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "PrinName"))
                        Dim AgentName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "AgentName"))
                        Dim FltMgrName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "FltMgrName"))
                        Dim StatName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "StatName"))

                        Dim ActDateEnd As String = ChangeToSQLDate(DBNull.Value)
                        If .GetRowCellValue(cRowHandle, "ActDateEnd").ToString <> "" Then
                            ActDateEnd = ChangeToSQLDate(CDate(.GetRowCellValue(cRowHandle, "ActDateEnd")))
                        End If

                        Dim ActDateStart As String = ChangeToSQLDate(DBNull.Value)
                        If .GetRowCellValue(cRowHandle, "ActDateStart").ToString <> "" Then
                            ActDateStart = ChangeToSQLDate(CDate(.GetRowCellValue(cRowHandle, "ActDateStart")))
                        End If

                        Dim RankName As String = CleanTableInput(.GetRowCellValue(cRowHandle, "RankName"))
                        Dim Remarks As String = CleanTableInput(.GetRowCellValue(cRowHandle, "Remarks"))

                        Dim SOFFStat As String = CleanTableInput(.GetRowCellValue(cRowHandle, "SOFFStat"))

                        If IfNull(.GetRowCellValue(cRowHandle, "ActGroupID"), String.Empty).Equals(String.Empty) Then
                            'Insert Activity Group
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.CommandText = "INSERT dbo.tblActivityGroup(" & _
                                    " FKeyIDNbr,ActivityType," & _
                                    " COIDNbr,LName," & _
                                    " FName,MName," & _
                                    " DOB,NatCode," & _
                                    " NatName,DateDep," & _
                                    " DateArr,PlaceDep," & _
                                    " PlaceArr," & _
                                    " LOC,LOCDays,IsCompServ)" & _
                                    " SELECT tCrew.PKey,'OTH'," & _
                                    " tCrew.COIDNo,tCrew.LName," & _
                                    " tCrew.FName,tCrew.MName," & _
                                    " tcrew.DOB,tCrew.NatCode," & _
                                    " tcntry.Name, @DateDep," & _
                                    " @DateArr, @PlaceDep," & _
                                    " @PlaceArr,0,0,0" & _
                                    " FROM dbo.tblCrewInfo tCrew" & _
                                    " INNER JOIN dbo.tblAdmCntry tcntry ON tcrew.NatCode = tcntry.PKey" & _
                                    " WHERE tCrew.PKey = '" & IDNbr & "'"
                            End Using


                        Else

                        End If


                        If IfNull(.GetRowCellValue(cRowHandle, "ActGroupID"), "").Equals("") Then 'Add Activity
                            'Insert ActivityGroup
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.CommandText = "INSERT dbo.tblActivityGroup(" & _
                                    " FKeyIDNbr,ActivityType," & _
                                    " COIDNbr,LName," & _
                                    " FName,MName," & _
                                    " DOB,NatCode," & _
                                    " NatName,DateDep," & _
                                    " DateArr,PlaceDep," & _
                                    " PlaceArr," & _
                                    " LOC,LOCDays,IsCompServ)" & _
                                    " SELECT tCrew.PKey,'OTH'," & _
                                    " tCrew.COIDNo,tCrew.LName," & _
                                    " tCrew.FName,tCrew.MName," & _
                                    " tcrew.DOB,tCrew.NatCode," & _
                                    " tcntry.Name," & DateDep & "," & _
                                    " " & DateArr & "," & PlaceDep & "," & _
                                    " " & PlaceArr & ",0,0,0" & _
                                    " FROM dbo.tblCrewInfo tCrew" & _
                                    " INNER JOIN dbo.tblAdmCntry tcntry ON tcrew.NatCode = tcntry.PKey" & _
                                    " WHERE tCrew.PKey = '" & IDNbr & "'"
                                cmd.Transaction = sqlTrans
                                hasActGroup = (cmd.ExecuteNonQuery().Equals(1))
                            End Using

                            'get the id of the Inserted Row
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.CommandText = "SELECT [PKey] FROM mps.dbo.tblActivityGroup WHERE ID=IDENT_CURRENT('tblActivityGroup')"
                                cmd.Transaction = sqlTrans
                                strActGroupID = cmd.ExecuteScalar()
                            End Using

                            'insert Activity
                            If Not strActGroupID.Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlConn
                                    cmd.Transaction = sqlTrans
                                    cmd.CommandText = "INSERT INTO dbo.tblActivity( " & _
                                        " FKeyActivityGroupID,VslName," & _
                                        " DeadWt,	GrossTon," & _
                                        " EngType,EngPower," & _
                                        " YrBuilt,Auxillaries," & _
                                        " PrinName,AgentName," & _
                                        " FltMgrName,StatName," & _
                                        " ActDateEnd,ActDateStart," & _
                                        " RankName,DateSOff," & _
                                        " DateSOn,PlaceSOn," & _
                                        " PlaceSOff,	Remarks," & _
                                        " LastUpdatedBy)" & _
                                        " VALUES(" & _
                                        " '" & strActGroupID & "'," & VslName & "," & _
                                        " " & DeadWt & "," & GrossTon & "," & _
                                        " " & EngType & "," & EngPower & "," & _
                                        " " & YrBuilt & "," & Auxillaries & "," & _
                                        " " & PrinName & "," & AgentName & "," & _
                                        " " & FltMgrName & "," & StatName & "," & _
                                        " " & DateDep & "," & DateArr & "," & _
                                        " " & RankName & "," & DateDep & "," & _
                                        " " & DateArr & "," & PlaceArr & "," & _
                                        " " & PlaceDep & ",	" & Remarks & "," & _
                                        " '" & LastUpdatedBy.Replace("<TO_REPLACE>", .GetRowCellValue(cRowHandle, "VslName")).ToString.Replace("'", "''") & "')"
                                    isActInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            End If
                        Else 'Update

                            If Not IfNull(.GetRowCellValue(cRowHandle, "ActGroupID"), "").Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlConn
                                    cmd.Transaction = sqlTrans
                                    cmd.CommandText = "UPDATE dbo.tblActivityGroup" & _
                                            " SET SOFFStat=" & SOFFStat & _
                                            " WHERE PKey = '" & .GetRowCellValue(cRowHandle, "ActGroupID") & "'"
                                    isActInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            End If

                            If Not IfNull(.GetRowCellValue(cRowHandle, "ActID"), "").Equals("") Then
                                Using cmd As New SqlClient.SqlCommand
                                    cmd.Connection = sqlConn
                                    cmd.Transaction = sqlTrans
                                    cmd.CommandText = "UPDATE dbo.tblActivity" & _
                                            " SET VslName=" & VslName & _
                                            " ,DeadWt=" & DeadWt & _
                                            " ,GrossTon=" & GrossTon & _
                                            " ,EngType=" & EngType & _
                                            " ,EngPower=" & EngPower & _
                                            " ,YrBuilt=" & YrBuilt & _
                                            " ,Auxillaries=" & Auxillaries & _
                                            " ,PrinName=" & PrinName & _
                                            " ,AgentName=" & AgentName & _
                                            " ,FltMgrName=" & FltMgrName & _
                                            " ,StatName=" & StatName & _
                                            " ,ActDateEnd=" & ActDateEnd & _
                                            " ,ActDateStart=" & ActDateStart & _
                                            " ,RankName=" & RankName & _
                                            " ,DateSOff=" & DateDep & _
                                            " ,DateSOn=" & DateArr & _
                                            " ,PlaceSOn=" & PlaceArr & _
                                            " ,PlaceSOff=" & PlaceDep & _
                                            " ,Remarks=" & Remarks & _
                                            " ,LastUpdatedBy='" & LastUpdatedBy.Replace("<TO_REPLACE>", .GetRowCellValue(cRowHandle, "VslName")) & "'" & _
                                            " ,DateUpdated=(getdate())" & _
                                            " WHERE PKey = '" & .GetRowCellValue(cRowHandle, "ActID") & "'"
                                    isActInserted = (cmd.ExecuteNonQuery().Equals(1))
                                End Using
                            End If
                        End If
                    End If
                Next
            End With
            If isActInserted Then
                sqlTrans.Commit()
                retval = True
            End If
        Catch ex As Exception
            sqlTrans.Rollback()
            retval = False
        Finally
            sqlConn.Close()
        End Try
        Return retval
    End Function
    'This Will check for the Crew Activity and Delete if the only Activity is Applicant
    Public Function DeleteCrew(CrewID As String) As Boolean
        Dim retval As Boolean = False
        Dim sqlTran As SqlClient.SqlTransaction = Nothing
        Dim actCount As Integer = 0, ActGrpID As String = "", isdeleted As Boolean = False
        Dim isArchived As Boolean = False
        Dim dtCascadeTbl As New DataTable
        Try
            sqlConn.Open()
            sqlTran = sqlConn.BeginTransaction()

            'Check if the Record is Related To other Table Except 
            Using cmd As New SqlClient.SqlCommand
                cmd.Connection = sqlConn
                cmd.Transaction = sqlTran
                cmd.CommandText = "SELECT * FROM dbo.FN_GetCascadeDeleteTable('tblCrewInfo')"
                Using adp As New SqlClient.SqlDataAdapter(cmd)
                    adp.Fill(dtCascadeTbl)
                End Using
            End Using
            If dtCascadeTbl.Rows.Count > 0 Then
                For Each dr As DataRow In dtCascadeTbl.Rows
                    Dim isUsed As Boolean = False
                    If Not dr(0).Equals("tblActivityGroup") Then
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "SELECT Cast(CASE WHEN EXISTS(SELECT * FROM dbo." & dr(0).ToString & " WHERE " & dr(1).ToString & " = '" & CrewID & "') THEN 1 ELSE 0 END AS BIT)"
                            retval = Not CBool(cmd.ExecuteScalar())
                        End Using
                        If Not retval Then
                            isArchived = True
                            Exit For
                        End If
                    End If
                Next
            End If

            If retval Then
                Using cmd As New SqlClient.SqlCommand
                    cmd.Connection = sqlConn
                    cmd.Transaction = sqlTran
                    cmd.CommandText = "SELECT COUNT(PKey) FROM dbo.tblActivityGroup WHERE FKeyIDNbr ='" & CrewID & "'"
                    actCount = CInt(cmd.ExecuteScalar())
                End Using
                If actCount > 0 Then
                    If actCount = 1 Then
                        Using cmd As New SqlClient.SqlCommand
                            cmd.Connection = sqlConn
                            cmd.Transaction = sqlTran
                            cmd.CommandText = "SELECT ag.PKey FROM dbo.tblActivity a " & _
                                            " INNER JOIN dbo.tblActivityGroup ag ON ag.PKey= a.FKeyActivityGroupID " & _
                                            " WHERE ag.FKeyIDNbr ='" & CrewID & "' AND a.FKeyStatCode = 'SYSAPP'"
                            ActGrpID = IfNull(cmd.ExecuteScalar(), "").ToString()
                        End Using

                        If Not ActGrpID.Equals("") Then
                            Using cmd As New SqlClient.SqlCommand
                                cmd.Connection = sqlConn
                                cmd.Transaction = sqlTran
                                cmd.CommandText = "DELETE dbo.tblActivityGroup WHERE PKey ='" & ActGrpID & "'"
                                retval = (cmd.ExecuteNonQuery().Equals(1))
                            End Using
                        End If
                    Else
                        retval = False
                        isArchived = True
                    End If
                Else
                    retval = True 'Nothing to Delete
                End If
                If retval Then
                    Using cmd As New SqlClient.SqlCommand
                        cmd.Connection = sqlConn
                        cmd.Transaction = sqlTran
                        cmd.CommandText = "DELETE dbo.tblCrewInfo WHERE PKey = '" & CrewID & "'"
                        retval = (cmd.ExecuteNonQuery().Equals(1))
                    End Using
                    If retval Then
                        sqlTran.Commit()
                    End If
                End If
            End If
        Catch ex As Exception
            sqlTran.Rollback()
            retval = False
        Finally
            If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
        End Try
        If isArchived Then
            MsgBox("Unable to delete the Crew, it has related Files, Move to archive instead.", MsgBoxStyle.Information, GetAppName())
        End If
        Return retval
    End Function

#End Region

#Region "Crew Reassignment"
    Public Sub CheckCrewReassignmentNotification(ByRef OpenCrewReassignmentConfirmationForm As Boolean)
        Dim extAssembly As System.Reflection.Assembly
        Dim oReassignCrew As Object

        extAssembly = System.Reflection.Assembly.Load("CrewReassignment")
        Try
            oReassignCrew = extAssembly.CreateInstance("CrewReassignment.ReassignCrewNotification", True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
            TryCast(oReassignCrew, Form).Refresh()
            OpenCrewReassignmentConfirmationForm = CrewReassignmentOpenConfirmation
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Documents With Grid"
    Public Sub ResetGridViewEdits(Views() As DevExpress.XtraGrid.Views.Grid.GridView)
        'Select Case TabControl.Tag
        '    Case "TravelDoc"
        '        TravelDocView.CancelUpdateCurrentRow()
        '    Case "LicCert"
        '        LicCertView.CancelUpdateCurrentRow()
        '    Case "Medical"
        '        MedicalView.CancelUpdateCurrentRow()
        'End Select
        'BRECORDUPDATEDs = False

        For Each gv As DevExpress.XtraGrid.Views.Grid.GridView In Views
            gv.CancelUpdateCurrentRow()
        Next

    End Sub
#End Region
End Module
