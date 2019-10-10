
'/// In Crewlist screen press Ctrl + Alt + Shift + f. For me to pop up. OK

Public Class frmFeatureID

    Dim clsfeat As New clsFeatureMod
    Public dtFeat As DataTable
    Dim clientID As String
    'Public DB As SQLDB

    Dim sFeatures() As String

    Private Sub frmFeatureID_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Dim dtObjects As New DataTable
        'DB.FillTable("SELECt objectid , 'O' as Type " & _
        '            " FROM dbo.tblObjects " & _
        '            " union " & _
        '            " SELECT objectid ,'R' as Type " & _
        '            " FROM  dbo.msystblreports ", dtObjects)

        'Dim list As New DataTable

        'With list
        '    .Columns.Add("ID", System.Type.GetType("System.String"))
        '    .Columns.Add("Name", System.Type.GetType("System.String"))
        'End With

        'Dim row As DataRow = list.NewRow
        'row("ID") = "a"
        'row("Name") = .ReaderItem("Name") 'UserName
        'list.Rows.Add(row)



        'Me.lkuObjects.Properties.DataSource = dtObjects

        Dim dtObjects As New DataTable
        'MPSDB.FillTable("SELECt objectid , 'O' as Type " & _
        '            " FROM dbo.tblObjects " & _
        '            " union " & _
        '            " SELECT objectid ,'R' as Type " & _
        '            " FROM  dbo.msystblreports ", dtObjects)

        dtObjects = MPSDB.CreateTable("SELECt ObjectID , 'Object' as Type, FID, '' as Feature " & _
                  " FROM dbo.tblObjects " & _
                  " union " & _
                  " SELECT ObjectID ,'Report' as Type, FID, '' as Feature " & _
                  " FROM  dbo.msystblreports ")

        Dim dtFeatureList As DataTable
        Try
            dtFeatureList = clsfeat.getFeaturelist
            For Each row As DataRow In dtObjects.Rows
                row("Feature") = IfNull(Reports.ReportConfig.GetFeatureNameFromFID(row("FID"), dtFeatureList), "")
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        

        lkuObjects.Properties.DataSource = dtObjects
        lkuObjects.Properties.BestFit()
        lkuObjects.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup

        mmoCompanyFeatID.ReadOnly = True
        Me.txtObjFeatID.ReadOnly = True
        clientID = MPSDB.GetConfig("COMPANYID")
        Me.txtCompanyID.Text = clientID
        'Me.cboFeature.Properties.Items.Add("test")

        Call loadFeatfromDT()

    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Dim featureLetter As String, errmsg As String = ""
        Dim generatedid As String

        'Select Case Me.cboFeature.Text
        '    Case "Activity"
        '        featureLetter = "a"
        '    Case "Graphical Planning"
        '        featureLetter = "b"
        '    Case "Planning"
        '        featureLetter = "c"
        '    Case "Travel"
        '        featureLetter = "d"
        '    Case "CheckList"
        '        featureLetter = "e"
        '    Case "Qualification"
        '        featureLetter = "f"
        '    Case "DMS"
        '        featureLetter = "g"
        '    Case "Reports"
        '        featureLetter = "h"
        '    Case "KPI"
        '        featureLetter = "i"
        '    Case "Payroll"
        '        featureLetter = "j"
        '    Case "Archive"
        '        featureLetter = "k"
        '    Case "Government"
        '        featureLetter = "l"
        '    Case "Default"
        '        featureLetter = "m"
        '    Case "Audit"
        '        featureLetter = "n"
        '    Case "Security"
        '        featureLetter = "o"
        '    Case Else
        '        featureLetter = ""

        'End Select

        featureLetter = Me.lkuFeature.GetColumnValue("Value").ToString()

        If Me.lkuObjects.Text <> "" And featureLetter <> "" Then
            generatedid = AES_Encrypt(Trim(Me.lkuObjects.Text) & "_" & featureLetter, "spectral")
            Me.txtObjFeatID.Text = generatedid

            If updateObjFeatID(lkuObjects.Text, generatedid, Me.lkuObjects.GetColumnValue("Type").ToString(), errmsg) Then
                MsgBox("Update Done", MsgBoxStyle.Information, "Generate Feature ID")
            Else
                MsgBox("Error! " & errmsg, MsgBoxStyle.Critical, "Generate Feature ID")
            End If
        Else
            MsgBox("Think before you click!. hahaha", vbCritical, "Generate Feature ID")
        End If

    End Sub

    Function updateObjFeatID(ObjID As String, FeatID As String, ObjType As String, Optional ByRef errmsg As String = "") As Boolean
        Dim tblname As String = ""

        ObjID = "'" & ObjID & "'"

        Select Case ObjType
            Case "Report"
                tblname = "msystblreports"
            Case "Object"
                tblname = "tblObjects"
            Case Else

        End Select

        Try

            MPSDB.RunSql("Update dbo." & tblname & " set FID ='" & FeatID & "' where ObjectID in(" & ObjID & ")")

            Return True
        Catch ex As Exception
            errmsg = ex.Message
            Return False
        End Try


    End Function


    Private Sub cmdGenCoyFeatures_Click(sender As System.Object, e As System.EventArgs) Handles cmdGenCoyFeatures.Click
        Dim lst As String = ""

        If Me.txtCompanyID.Text = "" Then
            MsgBox("Please Enter Company ID.", MsgBoxStyle.Exclamation, "Generate Feature ID")
            Exit Sub
        End If

        For i As Integer = 0 To Me.chkListFeature.ItemCount - 1
            If Me.chkListFeature.GetItemChecked(i) Then
                lst = lst & ";" & (Me.chkListFeature.GetItemValue(i).ToString)
            End If
        Next

        If lst = "" Then
            MsgBox("Please Select Feature(s).", MsgBoxStyle.Exclamation, "Generate Feature ID")
            Exit Sub
        End If

        Dim gnrtdCompanyFeatID As String

        gnrtdCompanyFeatID = AES_Encrypt(Me.txtCompanyID.Text & lst, "spectral")

        Me.mmoCompanyFeatID.Text = gnrtdCompanyFeatID

    End Sub

    Function all_generateFeatID() As Boolean
        Try
            Dim objObjects As DataTable
            Dim encrypted As String

            objObjects = MPSDB.CreateTable("SELECt ObjectID,Feature,FID FROM dbo.tblObjects ")
            For Each rowboat In objObjects.Rows
                encrypted = AES_Encrypt(Trim(rowboat("ObjectID")) & "_" & Trim(rowboat("Feature")), "spectral")
                MPSDB.RunSql("Update dbo.tblObjects set FID ='" & encrypted & "' where ObjectID in('" & Trim(rowboat("ObjectID")) & "')")
            Next

            objObjects = Nothing

            objObjects = MPSDB.CreateTable("SELECt ObjectID, Feature, FID FROM dbo.msystblreports ")
            For Each rowboat In objObjects.Rows
                encrypted = AES_Encrypt(Trim(rowboat("ObjectID")) & "_" & Trim(rowboat("Feature")), "spectral")
                MPSDB.RunSql("Update dbo.msystblreports set FID ='" & encrypted & "' where ObjectID in('" & Trim(rowboat("ObjectID")) & "')")
            Next

            Return True
        Catch ex As Exception
            MsgBox("Error!. " & ex.Message, vbCritical, "Generate Feature ID")
            Return False
        End Try
    End Function

    Sub loadFeatfromDT()


        ' dtFeat = clsfeat.getFeaturelist

        Me.chkListFeature.DataSource = dtFeat
        Me.lkuFeature.Properties.DataSource = dtFeat
    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        If MsgBox("This will generate and update all Objects Feature IDs. If you know what you are doing, then continue.", vbCritical + vbYesNo, "Generate Feature ID") = vbYes Then
            Call all_generateFeatID()
        Else
            MsgBox("I know. Hahahah", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton2.Click
        MsgBox(AES_Decrypt(IfNull(InputBox("Test the ID"), ""), "spectral"))
    End Sub

    Private Sub SimpleButton3_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton3.Click
        Dim dt As New DataTable
        dt = clsfeat.getClientFeatures(clientID, COMPANYID)
    End Sub

    Private Sub lkuObjects_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles lkuObjects.EditValueChanged
        Dim decFeat As String, arr() As String

        If IfNull(lkuObjects.GetColumnValue("FID"), "") <> Nothing Then

            decFeat = AES_Decrypt(Me.lkuObjects.GetColumnValue("FID").ToString, "spectral")
            arr = decFeat.Split("_")

            'MsgBox(AES_Decrypt(Me.lkuObjects.GetColumnValue("FID").ToString, "spectral"))
            Me.lkuFeature.EditValue = arr(arr.GetUpperBound(0))
        End If
        Me.txtObjFeatID.Text = Nothing
    End Sub

    Private Sub btnShowObjectsList_Click(sender As System.Object, e As System.EventArgs) Handles btnShowObjectsList.Click
        Dim f As New frmFeatureID_Objects
        f.RefreshData()
        f.ShowDialog()
        Me.Close()
    End Sub
End Class