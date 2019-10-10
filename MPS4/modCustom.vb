
Public Module modCustom

    Dim sqldb As SQLDB

    Public Function getNatWScaleRank(vslcode As String, rankcode As String, natCode As String,
                                     RecentWScaleRank As String, Optional returnOldWScale As Boolean = False) As String
        Dim strWScaleRank As String = ""

        If RecentWScaleRank = "" Or RecentWScaleRank = "SYSWSRUNDEF" Then
            If rankcode <> "" Then
                strWScaleRank = MPSDB.DLookUp("WScaleRankCode", "viewVslNatWScaleRank", "",
                                              "FKeyVslCode='" & vslcode & "' and NatCode='" & natCode & "' and RankCode ='" & rankcode & "'")
                If strWScaleRank = "" Then 'no nationality is entered.
                    'strWScaleRank = MPSDB.DLookUp("WScaleRankCode", "viewVslNatWScale", "",
                    '                         "FKeyVslCode='" & vslcode & "' and RankCode ='" & rankcode & "'")

                    strWScaleRank = getNatWScaleRank(vslcode, rankcode, RecentWScaleRank, returnOldWScale)
                End If
            End If
        Else
            If returnOldWScale Then
                strWScaleRank = RecentWScaleRank
            Else
                strWScaleRank = ""
            End If
        End If

        Return strWScaleRank

    End Function

    Public Function getNatWScaleRank(vslcode As String, rankcode As String, RecentWScaleRank As String,
                                     Optional returnOldWScale As Boolean = False) As String
        Dim strWScaleRank As String = ""

        If RecentWScaleRank = "" Or RecentWScaleRank = "SYSWSRUNDEF" Then
            If rankcode <> "" Then
                strWScaleRank = MPSDB.DLookUp("WScaleRankCode", "viewVslWScaleRank", "",
                                         "FKeyVslCode='" & vslcode & "' and RankCode ='" & rankcode & "'")
            End If
        Else
            If returnOldWScale Then
                strWScaleRank = RecentWScaleRank
            Else
                strWScaleRank = ""
            End If
        End If

        Return strWScaleRank

    End Function
End Module
