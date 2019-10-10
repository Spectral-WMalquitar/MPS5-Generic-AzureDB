Public Class frmContractExtensions
    Private _hasData As Boolean = False

    Public Function hasData() As Boolean
        Return _hasData
    End Function

    Public Sub New(actID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim dt As DataTable = MPSDB.CreateTable("SELECT dbo.AssembleName(ag.LName, ag.FName, ag.MName, 1, 1, 0, 0, 0) AS Crew, a.RankName, " & _
                                "ag.LOC, ag.LOCDays, ag.DateDue, ag.EXTLOC, ag.EXTLOCDays, dbo.GET_EXTDATEDUE(ag.Pkey) AS DateDueExt, ce.LOCExt, ce.LOCDaysExt, ce.DateEffect, ce.Remarks " &
                                "FROM tblActivityGroup ag " &
                                    "INNER JOIN tblActivity a ON ag.Pkey = a.FKeyActivityGroupID " &
                                    "INNER JOIN tblContractExt ce ON a.Pkey = ce.FKeyActivityID " &
                                "WHERE a.PKey = '" & actID & "' " &
                                "ORDER BY ce.DateEffect DESC")
        If dt.Rows.Count > 0 Then
            _hasData = True
            txtCrew.EditValue = IfNull(dt(0)("Crew"), "")
            txtRank.EditValue = IfNull(dt(0)("RankName"), "")
            txtLOC.EditValue = IfNull(dt(0)("LOC"), 0)
            txtLOCDays.EditValue = IfNull(dt(0)("LOCDays"), 0)
            If Not IsDBNull(IfNull(dt(0)("DateDue"), DBNull.Value)) Then
                txtDateDue.EditValue = dt(0)("DateDue")
            End If
            txtLOCExt.EditValue = IfNull(dt(0)("EXTLOC"), 0)
            txtLOCDaysExt.EditValue = IfNull(dt(0)("EXTLOCDays"), 0)
            If Not IsDBNull(IfNull(dt(0)("DateDueExt"), DBNull.Value)) Then
                txtDateDueExt.EditValue = dt(0)("DateDueExt")
            End If
            gcMain.DataSource = dt
        Else
            _hasData = False
        End If

    End Sub

    Public Sub New(crew As String, rank As String,
                   loc As Integer, locDays As Integer, DateDue As Date,
                   locExt As Integer, locDaysExt As Integer, dateDueExt As Date,
                   dtContractExtentions As DataTable)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtCrew.EditValue = crew
        txtRank.EditValue = rank
        txtLOC.EditValue = loc
        txtLOCDays.EditValue = locDays
        If Not IsDBNull(DateDue) Then
            txtDateDue.EditValue = DateDue
        End If
        txtLOCExt.EditValue = locExt
        txtLOCDaysExt.EditValue = locDaysExt
        If Not IsDBNull(dateDueExt) Then
            txtDateDueExt.EditValue = dateDueExt
        End If
        gcMain.DataSource = dtContractExtentions
    End Sub

End Class