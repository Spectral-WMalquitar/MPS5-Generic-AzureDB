Public Class RecordSum

    'Initialize Controls
    Dim is_clicked As Boolean = False, photo_changed As Boolean = False, photo_path As String
    Dim FormName As String = "Record Summary"
    Dim clsAudit As New clsAudit 'neil
    Private LastUpdatedBy As String = clsAudit.AssembleLastUBy(USER_NAME, "", 0, System.Environment.MachineName, "", FormName) 'neil
    Dim isLoadedFromCrewReassignment As Boolean = False 'Added by Tony20161025
    Dim strFocusedID As String = ""

    Dim hasDeleteCrewPermission As Boolean

#Region "Data Loading"

    Public Overrides Sub RefreshData()
        If bLoaded = False Then
            MyBase.RefreshData()
            SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
            SetPrintBiodataVisiblity(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            SetPrintListCaption(Name, "Print Biodata")
            SetEditOptionsVisibility(Name, False)
            MakeReadOnlyListener(Me.CrewInfo)
            repAddrStat.DataSource = GetAddStat()
            '<!-- added by tony20170926
            'commented out by tony20190515
            'SetDeleteCrewVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
            '-->

            'added by tony20190515
            SetRibbonPageGroupVisibility(Me.Name, "rpgViewArchivedReport", False)
            bLoaded = True
        End If

        Me.header.Text = IIf(strDesc = "New Record", strDesc, "Record Summary - " & strDesc)

        If MAIN_CONTENT = "ReassignCrewRequest" Or MAIN_CONTENT = "ReassignCrewConfirm" Or MAIN_CONTENT = "ReassignCrewHistory" Then
            lcgAddress.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never     'hide address
            lcgRelatives.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never    'hide relatives
            lcgActivity.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            TabControl.SelectedTabPage = lcgActivity
        Else
            strFocusedID = blList.GetID()
        End If

        If strFocusedID <> "" Then
            Dim tblNameRank As New DataTable
            Dim DTSizes As New DataTable    'added by tony20171125

            If (SelectedTab.Equals("ArchiveCrews")) Then
                ClearData()
                tblNameRank = DB.CreateTable("SELECT COIDNo, Height, Weight,TeleFax, Phone, Email, Airport, Nat, RankName, AgentName,LName,FName, MName,DOB, StatName,VslName FROM dbo.view_RecordSum_Arc WHERE FKeyIDNbr='" & strFocusedID & "'")
                DTSizes = DB.CreateTable("SELECT ShoeSize, CoverallSize, PoloSize, PantsSize FROM mpsarc.dbo.tblcrewinfo WHERE PKey = '" & strFocusedID & "'")  'added by tony20171125
                frmCrewMain.rpgViewArchivedReport.Visible = False
                'commented out by tony20170926  frmCrewMain.DeleteCrew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Else
                tblNameRank = DB.CreateTable("SELECT COIDNo, Height, Weight,TeleFax, Phone, Email, Airport, Nat, RankName, AgentName,LName,FName, MName,DOB, StatName,VslName FROM dbo.frm_RecordSum WHERE FKeyIDNbr='" & strFocusedID & "'")
                DTSizes = DB.CreateTable("SELECT ShoeSize, CoverallSize, PoloSize, PantsSize FROM mps.dbo.tblcrewinfo WHERE PKey = '" & strFocusedID & "'")  'added by tony20171125
                frmCrewMain.DeleteCrew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            End If
            Try
                If IsNothing(tblNameRank) = False Then
                    With tblNameRank.Rows(0)
                        Me.txtCOIDNo.Text = Trim(IfNull(.Item("COIDNo"), ""))
                        Me.txtHeight.EditValue = Trim(IfNull(.Item("Height"), ""))
                        Me.txtWeight.EditValue = Trim(IfNull(.Item("Weight"), ""))
                        Me.txtTeleFax.Text = Trim(IfNull(.Item("TeleFax"), ""))
                        Me.txtPhone.Text = Trim(IfNull(.Item("Phone"), ""))
                        Me.txtEmail.Text = Trim(IfNull(.Item("Email"), ""))
                        Me.txtAirport.Text = Trim(IfNull(.Item("Airport"), ""))

                        '<!--tony20160409
                        Me.txtNatCode.Text = Trim(IfNull(.Item("Nat"), ""))

                        Me.txtRank.Text = Trim(IfNull(.Item("RankName"), ""))
                        Me.txtManAgent.EditValue = Trim(IfNull(.Item("AgentName"), ""))
                        GetCrewPhoto(Me.CrewPhoto, strFocusedID)
                        Me.txtLName.Text = Trim(IfNull(.Item("LName"), ""))
                        Me.txtFName.Text = Trim(IfNull(.Item("FName"), ""))
                        Me.txtMName.Text = Trim(IfNull(.Item("MName"), ""))
                        Me.txtDOB.Text = Trim(IfNull(.Item("DOB"), ""))

                        Me.txtStatus.Text = Trim(IfNull(.Item("StatName"), ""))
                        Me.txtVsl.Text = Trim(IfNull(.Item("VslName"), ""))
                    End With

                    '<!-- added by tony20171125
                    If DTSizes.Rows.Count > 0 Then
                        With DTSizes.Rows(0)
                            Me.txtShoeSize.Text = Trim(IfNull(.Item("ShoeSize"), ""))
                            Me.txtCoverallSize.Text = Trim(IfNull(.Item("CoverallSize"), ""))
                            Me.txtPoloSize.Text = Trim(IfNull(.Item("PoloSize"), ""))
                            Me.txtPantsSize.Text = Trim(IfNull(.Item("PantsSize"), ""))
                        End With
                    End If
                    '-->

                    TabControl_SelectedPageChanged(Nothing, Nothing)
                Else
                    ClearDataFields()
                End If
            Catch ex As Exception
                'An error is that there is no rows in 0 index of this DataTable
                LogErrors("--Error Generated in RefreshData() method in RecordSum.vb - Start --")
                LogErrors(ex.Message)
                LogErrors("--Error Generated in RefreshData() method in RecordSum.vb - End--")
            End Try
        Else
            'added by tony20170629
            ClearDataFields()
            TabControl_SelectedPageChanged(Nothing, Nothing)
            'end tony
        End If
    End Sub

    Public Overrides Sub DeleteData()
        MyBase.DeleteData()
        'If SelectedTab.Equals("ArchiveCrews") Then
        '    Dim info As Boolean = False
        '    If MsgBox("Are you sure, you want to delete Crew '" & blList.GetDesc & "'?", MsgBoxStyle.Question + vbYesNo + vbDefaultButton2, GetAppName) = MsgBoxResult.Yes Then
        '        LastUpdatedBy = clsAudit.AssembleLastUBy(USER_NAME, "Delete Crew", 0, System.Environment.MachineName, "", FormName) 'neil
        '        clsAudit.saveAuditPreDelDetails(Me.TableName, blList.GetID, LastUpdatedBy)



        '        info = DeleteCrewBiodata(blList.GetID)
        '        If info Then
        '            MsgBox(GetMessage("Deleted", True), MsgBoxStyle.Information, GetAppName)
        '            blList.ExecCustomFunction(New Object() {"ForceRefresh"})
        '            ClearDtCrewList()
        '            RefreshData()
        '            blList.RefreshData()
        '            BRECORDUPDATEDs = False
        '        Else
        '            MsgBox(GetMessage("Deleted", False), MsgBoxStyle.Critical, GetAppName)
        '            BRECORDUPDATEDs = False
        '        End If

        '    End If
        'End If
    End Sub

    'Private Function DeleteCrewBiodata(CrewIDNbr As String) As Boolean
    '    If GetDeleteType(CrewIDNbr) = 2 Then

    '    End If
    '    Dim DelType As Integer = GetDeleteType(CrewIDNbr)
    '    Dim info As Boolean = False

    '    If DelType = 2 Then
    '        info = False
    '        MessageBox.Show("The crew " & blList.GetDesc & " has a processed payroll. "
    '        MsgBox("The crew " & blList.GetDesc & " has a processed payroll. Move the crew to archive instead.")
    '        'ElseIf DelType = 0 Then
    '        '    info = DeleteCrewAndRecords(CrewIDNbr)
    '    End If
    '    Return info
    'End Function

    'Private Function GetDeleteType(CrewIDNbr As String) As Integer
    '    Dim retVal As Integer = 0
    '    Dim sqlConn As New SqlClient.SqlConnection(DB.GetConnectionString)
    '    Try
    '        sqlConn.Open()
    '        Using cmd As New SqlClient.SqlCommand
    '            cmd.Connection = sqlConn
    '            cmd.CommandType = CommandType.StoredProcedure
    '            cmd.CommandText = "SP_GetDeleteCrewType"
    '            With cmd.Parameters
    '                .AddWithValue("@CrewID", CrewIDNbr)
    '            End With
    '            retVal = cmd.ExecuteScalar()
    '        End Using

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Exclamation, GetAppName)
    '    Finally
    '        If sqlConn.State = ConnectionState.Open Then sqlConn.Close()
    '    End Try
    '    Return retVal
    'End Function


    Private Sub TabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraLayout.LayoutTabPageChangedEventArgs) Handles TabControl.SelectedPageChanged
        Select Case Me.TabControl.SelectedTabPage.Tag
            Case "Comments"
                'Comments
                Me.CommentGrid.DataSource = DB.CreateTable("SELECT PKey, Comment, ComBy, ComDate FROM " & IIf(SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "") & "dbo.tblComment WHERE FKeyIDNbr = '" & strFocusedID & "' ORDER BY DateUpdated DESC")
            Case "TravelDoc"
                'Travel Documents
                Me.TravelDocGrid.DataSource = DB.CreateTable("SELECT PKey, Document, Number, DateIssue, DateExpiry, Country, IssuedBy, Remarks FROM dbo.frmCrew_TravelDoc" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strFocusedID & "' ORDER BY DateIssue DESC,Document ASC")
            Case "LicCert"
                'Certificates
                Me.CertGrid.DataSource = DB.CreateTable("SELECT Document, Number, DateIssue, DateExpiry, CertRegulation, Country, IssuedPlace, CertAuthority, IssuedBy FROM dbo.frmCrew_LicCert" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strFocusedID & "'  ORDER BY DateIssue DESC,Document ASC")
            Case "MedCert"
                'Medical Certificates
                Me.MedCertGrid.DataSource = DB.CreateTable("SELECT Document, Number, DateIssue, DateExpiry, IssuedBy, isActive, Country, Remarks FROM dbo.frmCrew_MedCert" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strFocusedID & "'  ORDER BY DateIssue DESC,Document ASC")
            Case "Course"
                Me.TrainingView.Focus()
                CreateTrainingSubGrid()
            Case "NatInfo"
                'National Information
                Me.NatInfoGrid.DataSource = DB.CreateTable("SELECT Document, Number, DateIssue, DateExpiry, Country, Remarks FROM dbo.frmCrew_NatInfo" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strFocusedID & "'  ORDER BY DateIssue DESC,Document ASC")
            Case "Addr"
                Me.AddrGrid.DataSource = DB.CreateTable("SELECT Bldg, St, PartofCity, CityName, ProvinceName, Country, PostCode, AddrStat, PayAddr FROM dbo.frmCrew_Addr" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strFocusedID & "'")
            Case "Relatives"
                Me.RelativeGrid.DataSource = DB.CreateTable("SELECT LName, FName, Sex, DOB, Relationship, Country, Addr, Notify, Beneficiary, Phone, Telefax FROM dbo.frmCrew_Allottee" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr='" & strFocusedID & "'")
            Case "Activity"
                Me.ActivityGrid.DataSource = DB.CreateTable("SELECT [Status], SOffReason, Vessel, [Rank],ActDateStart,ActDateEnd,PlaceStart,PlaceEnd,LOC,ActivityType,AgentName,PrinName FROM dbo.frmCrew_Activity" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr = '" & strFocusedID & "'")
            Case "SeaService"
                Me.SeaServGrid.DataSource = DB.CreateTable("SELECT Vessel, [Rank], WageScale, DateStarted, DateEnded, StartingPlace, EndingPlace, LOC, [Status], SignOffStatusName, AgentName, PrinName, Remarks,CAST(0 AS BIT) AS Edited FROM Crewlist_Activities_All" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE  IDNbr='" & strFocusedID & "' AND ActivityType='SEA' " & _
                                           "ORDER BY DateStarted DESC")
            Case "OtherSeaService"
                Me.OtherGrid.DataSource = DB.CreateTable("SELECT SOFFStatName,LOC,LOCDays,VslName,IMONo,VslTypeName,DeadWt,GrossTon,EngType,EngPower,YrBuilt,Auxillaries,PrinName,AgentName,FltMgrName,StatName,ActDateStart,ActDateEnd,RankName,DateSOff,DateSOn,PlaceSOffName,PlaceSOnName,Remarks,FltName,CAST(0 as BIT) AS Edited FROM Crewlist_Activities_Other WHERE IDNbr='" & strFocusedID & "' ORDER BY ActDateStart DESC")
            Case "AshoreActivity"
                Me.AshGrid.DataSource = DB.CreateTable("SELECT *,CAST(0 AS BIT) AS Edited FROM Crewlist_Activities_All" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE  IDNbr='" & strFocusedID & "' AND ActivityType='ASHORE' " & _
                                                       "ORDER BY DateStarted DESC")
            Case "MedicalHistory"
                MPS4Functions.AttachDocument.LoadViewWithDocImage(MedHisGrid, MedHisView, MedHisImgView, _
                                  "SELECT *, 0 as Edited FROM " & IIf(SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "") & "dbo.tblMedHistory WHERE FKeyIDNbr = '" & strFocusedID & "' ORDER BY DateStatus DESC", _
                                  "SELECT sub.*, 0 as Edited, '' AS tempFilePath FROM dbo.tblAttachDoc sub INNER JOIN " & IIf(SelectedTab.Equals("ArchiveCrews"), "MPSARC.", "") & "dbo.tblMedHistory main ON main.PKey COLLATE DATABASE_DEFAULT = sub.FKeyParent WHERE main.FKeyIDNbr COLLATE DATABASE_DEFAULT = '" & strFocusedID & "' AND sub.TableName = 'tblMedHistory'", _
                                  "PKey", "FKeyParent")
        End Select
    End Sub

#End Region

    Private Sub GetCrewPhoto(_PictureEdit As DevExpress.XtraEditors.PictureEdit, _CrewIDNbr As String)
        Try
            'CrewPhoto.Image = New System.Drawing.Bitmap(Trim(IfNull(Items("PhotoPath"), "")))
            Dim _path = GetCrewPhotoPath(_CrewIDNbr)
            If Not IsNothing(_path) Then
                _PictureEdit.Image = ImageFromStream(_path)
            Else
                _PictureEdit.Image = Nothing
            End If
        Catch ex As Exception
            _PictureEdit.Image = Nothing
        End Try
    End Sub

    Private Function GetCrewPhotoPath(_CrewIDNbr As String)
        Dim retval As String = Nothing
        Try
            Dim ImagePath As String = FOLDERDIRECTORY & "\" & _CrewIDNbr & "\" & _CrewIDNbr & "_IMAGE"
            'Dim FileName As String = _CrewIDNbr & "_IMAGE"
            If System.IO.File.Exists(ImagePath & ".jpg") Then
                ImagePath = ImagePath & ".jpg"
            ElseIf System.IO.File.Exists(ImagePath & ".png") Then
                ImagePath = ImagePath & ".png"
            Else
                ImagePath = Nothing
            End If
            retval = ImagePath
        Catch ex As Exception
            retval = Nothing
        End Try
        Return retval
    End Function

    Private Sub ClearDataFields()
        Me.txtCOIDNo.Text = ""
        'added by tony20170629
        Me.txtLName.Text = ""
        Me.txtFName.Text = ""
        Me.txtMName.Text = ""
        Me.txtRank.Text = ""
        Me.txtManAgent.Text = ""
        Me.txtDOB.Text = ""
        Me.txtStatus.Text = ""
        Me.txtVsl.Text = ""
        GetCrewPhoto(Me.CrewPhoto, strFocusedID)
        'end tony
        Me.txtNatCode.Text = ""
        Me.txtHeight.EditValue = ""
        Me.txtWeight.EditValue = ""
        Me.txtTeleFax.Text = ""
        Me.txtPhone.Text = ""
        Me.txtEmail.Text = ""
        Me.txtAirport.Text = ""
    End Sub

    Dim dtMain As New DataTable 'Main Table (Course)
    Dim dtSub As New DataTable 'Sub Table (LicCert)
    'Create Sub Grid
    Private Sub CreateTrainingSubGrid()
        Dim ds2 As New DataSet
        Try
            dtMain = DB.CreateTable("SELECT PKey, Course, CourseStatus, CourseType, Institution, Country, DateIssue, DateExpiry, STCWRef, PlannedStart, InstCost, ExRate, CurrName ,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_Training" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr='" & strFocusedID & "' ORDER BY Course ASC")
            dtSub = DB.CreateTable("SELECT PKey, FKeyCrewCourse, DocumentName, Number, DateIssue, DateExpiry, IssuedBy, IssuedPlace, Country, isActive, CertAuthority,CertCapacity,CertRegulation,CertLimit, Remarks,CAST(0 AS BIT) AS Edited FROM dbo.frmCrew_Training_SubDoc" & IIf(SelectedTab.Equals("ArchiveCrews"), "_Arc", "") & " WHERE FKeyIDNbr='" & strFocusedID & "'")

            ds2.Tables.Add(dtMain)
            ds2.Tables.Add(dtSub)

            ds2.Tables(0).TableName = "dtMain"
            ds2.Tables(1).TableName = "dtSub"

            If IsNothing(ds2.Relations("TrainingRel")) Then
                ds2.Relations.Add("TrainingRel", ds2.Tables("dtMain").Columns("PKey"), ds2.Tables("dtSub").Columns("FKeyCrewCourse"))
            End If

            Me.TrainingGrid.DataSource = ds2.Tables("dtMain")
            Me.TrainingGrid.ForceInitialize()
            Me.TrainingView.OptionsDetail.AllowExpandEmptyDetails = True

            Me.TrainingGrid.LevelTree.Nodes.Add("TrainingRel", Me.TrainingSub)
            Me.TrainingSub.ViewCaption = "Training Certificates"
            Me.TrainingSub.OptionsView.ShowGroupPanel = False
            Me.TrainingSub.OptionsCustomization.AllowFilter = False

        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return
        End Try
    End Sub

    Public Overrides Sub ExecCustomFunction(param() As Object)
        Select Case param(0)
            Case "LoadData"
                strFocusedID = param(1)
        End Select
    End Sub

    Private Sub RecordSum_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub

    Private Sub RecordSum_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
