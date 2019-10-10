Public Class rptCrewApplicants
    Dim PreviousGroupName As String = ""
    
    Private Sub celGroupName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles celGroupName.BeforePrint
        'Dim cell As XRTableCell = TryCast(sender, XRTableCell)
        'If cell.Report.CurrentRowIndex = 0 Then
        '    cell.Visible = True
        'Else
        '    cell.Visible = False
        'End If
        With celGroupName
            If PreviousGroupName <> .Text Then
                PreviousGroupName = .Text
                .Visible = True
            Else
                .Visible = False
            End If
        End With
        
    End Sub
End Class