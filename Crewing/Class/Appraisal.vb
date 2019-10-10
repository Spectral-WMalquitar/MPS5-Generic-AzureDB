Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Class Appraisal

    Dim selectedCrewAppraisal As New HashSet(Of CrewAppraisal)


    Dim FormName As String = "Crew Appraisal"
    Dim clickCounter As Integer = 0
    Public Shared containerID As String = "New Container"
    Public Shared hasAppraisalUpdated As Boolean = False
    Dim selectedAppraisalID As String = ""

    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 10, System.Environment.MachineName, "", FormName) 'neil

    Private Sub initControls()
        Me.LayoutControl1.AllowCustomization = False
        clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
    End Sub

    Private Sub LoadSub()
        Dim appraisalTable As DataTable = MPSDB.CreateTable("SELECT * FROM GetCrewAppraisal('" & strID & "') ORDER BY DateUpdated DESC ")               '--> Get Crew Appraisals
        Me.RepServices.DataSource = MPSDB.CreateTable("SELECT PKey AS FKeyActivity, Name FROM GetCrewService('" & strID & "') ORDER BY DateSon DESC;")  '--> Get Sea Service

        Me.AppraisalGrid.DataSource = appraisalTable
        PopulateSelectedCrewAppraisal(appraisalTable)
        If AppraisalView.DataRowCount = 0 Then
            frmCrewMain.cmdDelete.Enabled = False
            frmCrewMain.cmdPreviewReport.Enabled = False
        Else
            frmCrewMain.cmdPreviewReport.Enabled = True
            frmCrewMain.cmdDelete.Enabled = True
        End If
    End Sub

    Private Sub PopulateSelectedCrewAppraisal(table As DataTable)
        'Based on the given datatable, copy its cotents to a local object CrewAppraisal for processing.
        Try
            selectedCrewAppraisal.Clear()
            For Each row As DataRow In table.Rows
                Dim crewAppraisal As New CrewAppraisal
                With crewAppraisal
                    .AppraisalID = row("PKey").ToString()
                    .FKeyIDNbr = row("FKeyIDNbr").ToString()
                    .AppraisalDate = row("AppraisalDate").ToString()
                    .FKeyActivityID = row("FKeyActivity").ToString()
                    .Service = row("Service").ToString()
                    .OccasionForReport = row("OccasionForReport").ToString()
                    .OverallScore = IIf(row("OverallScore").ToString().Equals(""), 0, row("OverallScore").ToString())
                    .Reemployed = IIf(row("Reemployed").ToString().Equals("True"), True, False)
                    .Promotion = IIf(row("Promotion").ToString().Equals("True"), True, False)
                    .SailAgain = IIf(row("SailAgain").ToString().Equals("True"), True, False)
                    .Remarks = row("Remarks").ToString()
                    .Master = row("FKeyMstrID").ToString()
                    .ChiefOfficer = row("FKeyCOId").ToString()
                    .ChiefEngineer = row("FKeyCEId").ToString()
                    .Strength = row("Strength").ToString()
                    .Weaknesses = row("Weakneses").ToString()
                    .OfficerComment = row("OfficerComment").ToString()
                    .OfficerName = row("OfficerName").ToString()
                    .CommentDate = Convert.ToDateTime(IIf(row("CommentDate").ToString().Equals(""), DateTime.Now, row("CommentDate").ToString()))
                    .CommentFromOfficer1 = row("CommentFromOffice1").ToString()
                    .ShipFleetManager = row("ShipFleetManager").ToString()
                    .CommentFromOfficer2 = row("CommentFromOffice2").ToString()
                    .SafetyOperationsManager = row("SafetyOperationsManager").ToString()
                    .Reemploy = IIf(row("Reemploy").ToString().Equals("True"), True, False)
                    .Promote = IIf(row("Promote").ToString().Equals("True"), True, False)
                    .PromoteReemployWhen = row("PromoteReemployWhen").ToString()
                    .AdditionalRemarks = row("AdditionalRemarks").ToString()
                    .TrainingRequirements = row("TrainingRequirements").ToString()
                    .OverallAssessment = row("OverallAssessment").ToString()
                    .AppraisalFactorsGrades = GetAppraisalDetails(row("PKey").ToString())
                    .DataRemarks = "EDIT"
                End With
                selectedCrewAppraisal.Add(crewAppraisal)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Function GetCrewAppraisal(appraisalID As String) As CrewAppraisal
        '--> Find the CrewAppraisal object. 
        For Each obj As CrewAppraisal In selectedCrewAppraisal
            If obj.AppraisalID.Equals(appraisalID) Then
                Return obj
            End If
        Next
        Return Nothing
    End Function
    Private Function GetAppraisalDetails(appraisalId As String) As HashSet(Of CrewAppraisalDetails)
        'Get the appraisal details (grades and comments) for the selected appraisal. 
        Dim details As New HashSet(Of CrewAppraisalDetails)

        Dim table As DataTable = MPSDB.CreateTable("SELECT cad.FKeyCrewAppraisal, cad.FKeyAppraisalFactors, cad.Comments, cad.Grades, aaf.GroupName " & _
                                                   "FROM tblCrewAppraisalDetails cad INNER JOIN tblAdmAppraisalFactors aaf ON cad.FKeyAppraisalFactors = aaf.PKey " & _
                                                   "WHERE FKeyCrewAppraisal = '" & appraisalId & "'")
        For Each row As DataRow In table.Rows
            Dim d As New CrewAppraisalDetails
            d.AppraisalID = row("FKeyCrewAppraisal").ToString()
            d.AppraisalFactorID = row("FKeyAppraisalFactors").ToString()
            d.AppraisalComment = row("Comments").ToString()
            d.AppraisalGrade = row("Grades").ToString()
            d.AppraisalGroup = row("GroupName").ToString()
            details.Add(d)      '--> Add it on a local object CrewAppraisalDetails
        Next

        Return details  '--> Return a HashSet object.

    End Function

    Public Overrides Sub RefreshData()
        TableName = "tblCrewAppraisal"
        MyBase.RefreshData()
        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Crew Appraisals - " & strDesc)

        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

        SetDeleteCaption(Name, "Delete Appraisal")
        'commented out by tony20170927 SetPrintListCaption(Name, "Print Appraisal")
        AllowDeletion(Name, True)
        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        SetEditCaption(Name, "Add/Edit")
        If blList.GetID() = "" Then
            'commented out by tony20190712 : adding must be disabled if blList (crew list) does not have any record
            'AddData()
            AllowEditing(Name, False)
            AllowDeletion(Name, False)
        Else
            LoadSub()
        End If
    End Sub

    Public Overrides Sub EditData()
        MyBase.EditData()
        AllowDeletion(Name, True)
        EditSubAllowGrid(Me.AppraisalView, isEditdable)
    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()

        Try
            If AppraisalView.DataRowCount > 0 Then
                If DialogResult.Yes = MessageBox.Show("Are you sure you want to delete the selected Appraisal for " & strDesc & "?", "Delete Appraisal",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    Dim query As String = "DELETE FROM tblCrewAppraisal WHERE PKey = '" & AppraisalView.GetRowCellValue(AppraisalView.FocusedRowHandle, "PKey") & "'"

                    clsAudit.propSQLConnStr = DB.GetConnectionString 'neil
                    LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Crew Aprraisals", 0, System.Environment.MachineName, strDesc & _
                                                             " - " & AppraisalView.GetRowCellDisplayText(AppraisalView.FocusedRowHandle, "AppraisalDate") & " - " & _
                                                                AppraisalView.GetRowCellDisplayText(AppraisalView.FocusedRowHandle, "OverallScore"), FormName, strID) 'neil
                    clsAudit.saveAuditPreDelDetails("tblCrewAppraisal", AppraisalView.GetRowCellValue(AppraisalView.FocusedRowHandle, "PKey"), LastUpdatedBy) 'neil

                    '<!--added by tony20180922 : Log Deletion
                    oLogDeletion.Init()
                    oLogDeletion.CreateLogEntry(LogDeletion.CallingApp.Crewing,
                        FormName, _
                        "Crewing", _
                        "tblCrewAppraisal", _
                        "PKey IN ('" & AppraisalView.GetRowCellValue(AppraisalView.FocusedRowHandle, "PKey") & "')", _
                        "<< Delete Crew Data - " & FormName & " >>", _
                        LogDeletion.DeletionType.Manual, _
                        "Manually Deleted in <" & FormName & ">", _
                        GetUserName())
                    '-->

                    If MPSDB.RunSql(query) Then
                        oLogDeletion.AddLogEntryToDatabase()    'added by tony20180922 : Log Deletion
                        MessageBox.Show("Appraisal successfully deleted. ", "Delete Appraisal", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadSub()
                    End If
                Else
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("There is an error while deleting the Appraisal : " & ex.Message)
        End Try
    End Sub

    Private Sub tmrResetClickCounter_Tick(sender As System.Object, e As System.EventArgs) Handles tmrResetClickCounter.Tick
        clickCounter = 0
    End Sub

    Private Sub AppraisalView_RowClick(sender As System.Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles AppraisalView.RowClick
        '--> Simulate the double-click event by using a counter variable and a timer to restart the the count accordingly. 
        clickCounter = clickCounter + 1
        If clickCounter = 2 Then
            Dim appraisalPopup As New frmAppraisalPopup(strID, strDesc, isEditdable, GetCrewAppraisal(AppraisalView.GetRowCellValue(AppraisalView.FocusedRowHandle, "PKey")))
            appraisalPopup.ShowDialog(Me)
        End If

        If hasAppraisalUpdated Then
            LoadSub()
            hasAppraisalUpdated = False
        End If
    End Sub

    Private Sub AppraisalView_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles AppraisalView.RowCellStyle
        If e.RowHandle = AppraisalView.FocusedRowHandle Then
            e.Appearance.BackColor = SEL_COLOR
        End If
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        MyBase.ExecCustomFunction(param)
        If param(0).ToString().Equals("PREVIEWREPORT") Then
            If AppraisalView.RowCount > 0 Then
                ''RaiseCustomEvent(Name, New Object() {"Preview", "rptAppraisalReport", "MPS4", "Query"})
                Dim report As New AppraisalReport(GetCrewAppraisal(AppraisalView.GetRowCellValue(AppraisalView.FocusedRowHandle, "PKey")))
            Else
                MessageBox.Show("Crew does not have any appraisal. To add an appraisal, click the Add/Edit button.", "Appraisal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub
End Class
