
Public Class frmUserSetting
    Dim extAssembly As System.Reflection.Assembly
    Public WithEvents maincontent As New BaseControl.BaseControl
    Dim loading As Boolean = False
    Private Const strDLL As String = "MPS4"
    Dim _Content As String = ""

#Region "Button Configurations"

#Region "Caption"
    Private Sub CaptionResetDefaultButton(sender As String, value As String) Handles maincontent.CustomUserSettingResetCaption
        cmdReset.Caption = value
    End Sub

    Private Sub CaptionSaveButton(sender As String, value As String) Handles maincontent.CustomUserSettingSaveCaption
        cmdSave.Caption = value
    End Sub

    Private Sub CaptionCancelButton(sender As String, value As String) Handles maincontent.CustomUserSettingCancelCaption
        cmdCancel.Caption = value
    End Sub
#End Region 'Caption

#Region "Visibility"
    Private Sub VisibilityResetButton(sender As String, value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.CustomUserSettingResetVisibility
        cmdReset.Visibility = value
    End Sub
    Private Sub VisibilitySaveButton(sender As String, value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.CustomUserSettingSaveVisibility
        cmdSave.Visibility = value
    End Sub
    Private Sub VisibilityCancelButton(sender As String, value As DevExpress.XtraBars.BarItemVisibility) Handles maincontent.CustomUserSettingCancelVisibility
        cmdCancel.Visibility = value
    End Sub
#End Region 'Visibility

#Region "Enable"
    Private Sub EnableResetButton(sender As String, value As Boolean) Handles maincontent.CustomUserSettingResetEnable
        cmdReset.Enabled = value
    End Sub

    Private Sub EnableSaveButton(sender As String, value As Boolean) Handles maincontent.CustomUserSettingSaveEnable
        cmdSave.Enabled = value
    End Sub

    Private Sub EnableCancelButton(sender As String, value As Boolean) Handles maincontent.CustomUserSettingCancelEnable
        cmdCancel.Enabled = value
    End Sub
#End Region 'Enable

#End Region 'Button Configuration

    Private Sub LoadContent(cContent As String)
        loading = True
        Me.Cursor = Cursors.WaitCursor
        If cContent <> "" And maincontent.Name <> cContent Then
            Me.MainPanel.Controls.Clear()
            maincontent.Dispose()
            extAssembly = System.Reflection.Assembly.Load(strDLL)
            maincontent = extAssembly.CreateInstance(strDLL & "." & cContent, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)
            maincontent.Dock = DockStyle.Fill
            MainPanel.Controls.Add(maincontent)
            maincontent.DB = MPSDB
            maincontent.Name = cContent
            maincontent.RefreshData()
            If cContent.Equals("QuickAccessButtons") Then
                GetShowRibbon()
            End If
        ElseIf maincontent.Name = cContent Then
            'neil - do nothing
        Else
            Me.MainPanel.Controls.Clear()
            maincontent.Dispose()
            maincontent.Name = ""
        End If
        Me.Cursor = Cursors.Arrow
        loading = False
    End Sub

    'Form Closing
    Private Sub frmUserSetting_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not loading Then
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(THEME_NAME)
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                AllowN = maincontent.CheckValidateFields()
                If AllowN Then
                    e.Cancel = False
                Else
                    If ALLOWNEXTS Then
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                End If
            Else
                e.Cancel = False
            End If
        End If
    End Sub


    Private Sub frmUserSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadContent(getcContent)
    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As System.EventArgs) Handles RibbonControl.SelectedPageChanged
        LoadContent(getcContent)
    End Sub

    Private Function getcContent() As String
        Dim retval As String = ""
        Select Case RibbonControl.SelectedPage.Tag
            Case "Theme"
                retval = "ThemeControl"
            Case "Preferences"
                retval = "UserPreference"
            Case "Shortcuts"
                retval = "QuickAccessButtons"
            Case "Legends"
                retval = "Legends"
            Case "Connection"
                retval = "Connection"
        End Select
        Return retval
    End Function

    Private Sub cmdSave_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdSave.ItemClick
        maincontent.SaveData()

        SAVE_EVENT_FIRED = True
    End Sub

    Private Sub cmdCancel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Me.Close()
    End Sub

    Private Sub cmdReset_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdReset.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ResetDefault"})
    End Sub

    Private Sub RibbonControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs) Handles RibbonControl.SelectedPageChanging
        If Not loading Then
            Dim AllowN As Boolean
            If BRECORDUPDATEDs Then
                AllowN = maincontent.CheckValidateFields()
                If AllowN Then
                    e.Cancel = False
                Else
                    If ALLOWNEXTS Then
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                End If
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub GetShowRibbon()
        Try
            Dim result As String = MPSDB.DLookUp("Value", "tblUserConfig", "False", "FKeyUserID = '" & USER_ID & "' AND Code = 'ShowFavoriteButtons'")
            If result.Equals("True") Then
                bbiShowOnRibbon.EditValue = True
            Else
                bbiShowOnRibbon.EditValue = False
            End If
            ShowShortcutOnRibbon = bbiShowOnRibbon.EditValue
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub bbiShowOnRibbon_ItemPress(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiShowOnRibbon.ItemPress
        Me.Focus()
        If bbiShowOnRibbon.EditValue = False Then
            bbiShowOnRibbon.EditValue = True
        Else
            bbiShowOnRibbon.EditValue = False
        End If

        ShowShortcutOnRibbon = bbiShowOnRibbon.EditValue
        BRECORDUPDATEDs = True
    End Sub

    Private Sub cmdClearSelectedShortcuts_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdClearSelectedShortcuts.ItemClick
        maincontent.ClearData()
    End Sub

    Private Sub cmdResetConn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdResetConn.ItemClick
        maincontent.ExecCustomFunction(New Object() {"ResetConn"})
    End Sub
End Class