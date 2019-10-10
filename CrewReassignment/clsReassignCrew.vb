Imports System.Drawing

Public Class clsReassignCrew

#Region "Declarations"
    Public Enum CrewReassignmentStatus
        Pending = 0
        Approved = 1
        Rejected = 2
    End Enum
#End Region

    Public Sub CheckCrewReassignmentNotification()
        Dim f As New ReassignCrewNotification
        f.Refresh()
    End Sub

    Public Shared Sub changeCrewReassignmentStatusColor(nStatus As Integer, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Select Case nStatus
            Case CrewReassignmentStatus.Pending, -1
                e.Appearance.BackColor = Color.White
                e.Appearance.ForeColor = Color.Black
            Case CrewReassignmentStatus.Approved
                e.Appearance.BackColor = Color.Green
                e.Appearance.ForeColor = Color.White
            Case CrewReassignmentStatus.Rejected
                e.Appearance.BackColor = Color.Red
                e.Appearance.ForeColor = Color.White
        End Select
    End Sub

    Public Shared Sub ViewRecordSum(ByVal cIDNbr As String)
        If cIDNbr.Length > 0 Then
            Try

                Dim frmRecordSum As New Crewing.frmRecordSum

                frmRecordSum.IDNbr = cIDNbr
                frmRecordSum.ShowDialog()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("No crew selected.", vbInformation)
        End If
    End Sub
End Class
