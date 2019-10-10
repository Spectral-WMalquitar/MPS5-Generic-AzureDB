Imports BaseControl.BaseFunction
Public Class BaseControl

    Const NOT_ADMIN = 0 'NEIL

    Public ObjectIDContent As String = ""
    Private clsSec As New clsSecurity 'neil
    Public DB As SQLDB ' A class used to communicate with the SQL Server
    Public blList As BaseList 'Base list
    Protected strID As String = "" 'Primary key of each record.
    Protected strDesc As String 'Description of the maincontent
    Public strCaption As String 'Caption of the maincontent
    Public strHelpUrl As String
    Public TableName As String = "" 'Table name of the control
    Protected bLoaded As Boolean = False 'Utility variable will be set to true on the first call of refreshdata function.
    Public bPermission As Byte = 0 '1 View 2 Add 4 Edit/Save 8 Delete 'Max permission 15
    'Public BRECORDUPDATEDs As Boolean 'Utility variable will be set to false on RefreshData and True Field_EditValueChanged which trigger in when one of the fields is updated.
    Protected bAddMode As Boolean = False 'Utility variable will be set to true when the AddData function is called.
    Protected strFindID As String 'Utility for datasheet if this had a value on RefreshData it will look for this ID.
    Public strRequiredFields As String 'List of Required fields
    Protected SubAddMode As Boolean = False 'used for Labels of the Edit Form and Button Names
    Protected NewFile As Boolean = False 'use for DMS identifier ffir new file

    Public HasError As Boolean = False 'for required Field Validation

    Public DataToolDuplicate As Boolean = True 'For Duplicate option of the Data Tool
    Public DataToolMerge As Boolean = True 'For Mege option of the Data Tool

    Protected bCopy As Boolean = False 'Copy Replace ADMIN
    Protected CopyID As String = "" 'Copied ID ADMIN

    Private _focusedView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing 'Focused Grid View
    Protected Property focusedView() As DevExpress.XtraGrid.Views.Grid.GridView
        Get
            Return _focusedView
        End Get
        Set(ByVal value As DevExpress.XtraGrid.Views.Grid.GridView)
            'If IsNothing(value) Then
            '    AllowDeletion(Name, False)
            'Else
            '    AllowDeletion(Name, True)
            'End If
            _focusedView = value
        End Set
    End Property


    Public isEditdable As Boolean 'Edit button down or not

    Public Event RightClick(ByVal sender As String) 'Event that will fire  when the user right click the sub class data or a portion of the control.
    Public Event AllowSave(ByVal sender As String, ByVal value As Boolean) 'Event that will fire  when the user edit sub class data. This will enable the save button on main form.
    Public Event AllowAdd(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an add permission. This will enable the add button on main form.
    Public Event AllowDelete(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an delete permission. This will enable the delete button on main form.
    Public Event AllowDeleteSub(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an delete permission. This will enable the deletesub button on main form.
    Public Event AllowDataToolUtil(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an delete permission. This will enable the deletesub button on main form.
    Public Event AllowEdit(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an delete permission. This will enable the edit button on main form.
    Public Event AllowLoadT(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an delete permission. This will enable the edit button on main form.
    Public Event AllowShowHideT(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an delete permission. This will enable the edit button on main form.
    Public Event AllowUndo(ByVal sender As String, ByVal value As Boolean)
    Public Event AllowFLogout(ByVal sender As String, ByVal value As Boolean)

    Public Event ShowListVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the show list button on main form.   
    Public Event PreviewReportVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the preview (report) button on main form.   
    Public Event ShowListEnabled(ByVal sender As String, ByVal value As Boolean) 'This will enabled/disable the preview (report) button on main form.   
    Public Event PreviewReportEnabled(ByVal sender As String, ByVal value As Boolean) 'This will enabled/disable the preview (report) button on main form.   
    Public Event ViewRecordSumEnabled(ByVal sender As String, ByVal value As Boolean) 'This will enabled/disable the View Record Summary (Crew Reassignment) button on main form.   
    Public Event HideCrewReassignmentRequestEnabled(ByVal sender As String, ByVal value As Boolean) 'This will enabled/disable the Hide Request (Crew Reassignment) button on main form.

    Public Event SaveVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the save button on main form.
    Public Event AddVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the add button on main form.
    Public Event DeleteVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the delete button on main form.
    Public Event DeleteCrewVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the delete button on main form.
    Public Event EditVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the delete button on main form.
    Public Event DeleteSubVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the delete sub button on main form.
    Public Event DataToolVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the delete sub button on main form.
    Public Event EditOptionsVisibility(ByVal sender As String, ByVal value As Boolean) 'This will show/hide the save button on main form.


    Public Event UpdateProgramVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the Update Program button on main form.
    Public Event PageGroupVisibility(ByVal sender As String, ByVal pageCaption As String, ByVal pageGroupName As String, ByVal value As Boolean)

    Public Event EditDown(ByVal sender As String, ByVal value As Boolean) 'This will show/hide the delete button on main form.

    Public Event CustomSaveCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the save button on main form.
    Public Event CustomAddCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the add button on main form.
    Public Event CustomDeleteSubCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the delete sub button on main form.
    Public Event CustomDeleteCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the delete button on main form.
    Public Event CustomDataToolCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the delete button on main form.
    Public Event CustomClearFilterCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the Clear Filter button on main form.
    Public Event CustomEditCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the edit button on main form.
    Public Event CustomPrintListCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the PrintList button on main form.
    Public Event CustomStatusBarCaption(ByVal sender As String, ByVal value As String, ByVal Style As String) 'This will set the caption for the status bar static item on main form.

    Public Event OnSwitchContent(ByVal sender As String, ByVal value As String, ByVal cmd() As String) 'Event that will let to sub class to switch to another class.
    Public Event OnCustomEvent(ByVal sender As String, ByVal param() As Object) 'Event that will fire  when the user edit sub class data. This will enable the save button on main form.

    Public Event PanelVisibility(ByVal sender As String, ByVal value As DevExpress.XtraEditors.SplitPanelVisibility)
    Public Event HideCrewReassignmentRequestVisibility(ByVal sender As String, ByVal value As DevExpress.XtraEditors.SplitPanelVisibility)
    Public Event ShowRibbonPageGroup(ByVal sender As String, ByVal RibbonPageGroupName As String, ByVal value As Boolean) 'This will show/hide the Report Options Ribbon Page Group.   
    Public Event ShowRibbonPageGroup_UsingArray(ByVal sender As String, ByVal RibbonPageGroupNameList As List(Of String), ByVal value As Boolean) 'This will show/hide the Report Options Ribbon Page Group.   

    Public Event CustomGetDeleteCaption(ByVal sender As String, ByRef value As String) 'This will get the caption of the delete sub button on main form. (Neil 20170705)


#Region "frmUserSettings"
    'Caption
    Public Event CustomUserSettingResetCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the ResetButton in the FRMUSERSETTINGS
    Protected Sub SetUserSettingResetCaption(sender As String, value As String)
        RaiseEvent CustomUserSettingResetCaption(sender, value)
    End Sub

    Public Event CustomUserSettingSaveCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the Save in the FRMUSERSETTINGS
    Protected Sub SetUserSettingSaveCaption(sender As String, value As String)
        RaiseEvent CustomUserSettingSaveCaption(sender, value)
    End Sub

    Public Event CustomUserSettingCancelCaption(ByVal sender As String, ByVal value As String) 'This will set the caption of the Cancel in the FRMUSERSETTINGS
    Protected Sub SetUserSettingCancelCaption(sender As String, value As String)
        RaiseEvent CustomUserSettingCancelCaption(sender, value)
    End Sub
    Public Event CustomExportToExcelCaption(sender As String, value As String)
    Protected Sub SetExportToExcelCaption(sender As String, value As String)
        RaiseEvent CustomExportToExcelCaption(sender, value)
    End Sub

    Public Event CustomViewAttachmentCaption(sender As String, value As String)
    Protected Sub SetViewAttachmentCaption(sender As String, value As String)
        RaiseEvent CustomViewAttachmentCaption(sender, value)
    End Sub

    'Visibility
    Public Event CustomViewAttachmentVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetViewAttachmentVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent CustomViewAttachmentVisibility(sender, value)
    End Sub

    Public Event CustomExportToExcelVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the save button on main form.
    Protected Sub SetExportToExcelVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent CustomExportToExcelVisibility(sender, value)
    End Sub

    Public Event CustomUserSettingResetVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetUserSettingResetVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent CustomUserSettingResetVisibility(sender, value)
    End Sub

    Public Event CustomUserSettingSaveVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetUserSettingSaveVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent CustomUserSettingSaveVisibility(sender, value)
    End Sub

    Public Event CustomUserSettingCancelVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetUserSettingCancelVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent CustomUserSettingCancelVisibility(sender, value)
    End Sub

    Public Event HideRibbonPageGroup() 'This will show/hide the Viewing Options Group
    Protected Sub GoHideRibbonPageGroup()
        RaiseEvent HideRibbonPageGroup()
    End Sub

    'Enable
    Public Event CustomUserSettingResetEnable(sender As String, value As Boolean)
    Protected Sub AllowUserSettingReset(sender As String, value As Boolean)
        RaiseEvent CustomUserSettingResetEnable(sender, value)
    End Sub

    Public Event CustomUserSettingSaveEnable(sender As String, value As Boolean)
    Protected Sub AllowUserSettingSave(sender As String, value As Boolean)
        RaiseEvent CustomUserSettingSaveEnable(sender, value)
    End Sub

    Public Event CustomUserSettingCancelEnable(sender As String, value As Boolean)
    Protected Sub AllowUserSettingCancel(sender As String, value As Boolean)
        RaiseEvent CustomUserSettingCancelEnable(sender, value)
    End Sub

#End Region

#Region "Custom Events"
    Public Event CustomPrintBiodataVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetPrintBiodataVisiblity(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent CustomPrintBiodataVisibility(sender, value)
    End Sub

    Public Event CustomGotoForm(ByVal sender As String, ByVal FormNameByButton As String)
    Protected Sub GotoForm(sender As String, FormNameByButton As String)
        RaiseEvent CustomGotoForm(sender, FormNameByButton)
    End Sub
#End Region

#Region "MPS4"

    'Public Event HideViewColumn(ByVal sender As String, ByVal value As Boolean) 'hide a column

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'cmd - commands that maybe needed when the user right click the control.
    Protected Sub OnRightClick(ByVal sender As String)
        RaiseEvent RightClick(sender)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - string that set the .caption properties of the main forms add button.
    Protected Sub SwitchContent(ByVal sender As String, ByVal value As String, ByVal cmd() As String)
        RaiseEvent OnSwitchContent(sender, value, cmd)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - string that set the .caption properties of the main forms add button.
    Protected Sub SetAddCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomAddCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    Protected Sub SetSaveCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomSaveCaption(sender, value)
    End Sub

    Protected Sub SetSaveCaption1(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomSaveCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    Protected Sub SetDeleteCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomDeleteCaption(sender, value)
    End Sub

    Protected Sub GetDeleteCaption(ByVal sender As String, ByRef value As String)
        RaiseEvent CustomGetDeleteCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    Protected Sub SetEditCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomEditCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    Protected Sub SetPrintListCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomPrintListCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    Protected Sub SetDeleteSubCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomDeleteSubCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolean that set the .caption properties of the main forms add button.
    Protected Sub SetDataToolCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomDataToolCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    Protected Sub SetClearFilterCaption(ByVal sender As String, ByVal value As String)
        RaiseEvent CustomClearFilterCaption(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .caption properties of the main forms add button.
    'style - for style in the icon (message box like)
    Protected Sub SetStatbarTextCaption(ByVal sender As String, ByVal value As String, Optional ByVal Style As String = "INFORMATION")
        RaiseEvent CustomStatusBarCaption(sender, value, Style)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetSaveVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        If value = 1 Then 'if user have edit permission and programmer insist to hide the group control, give what the programmer wants
            RaiseEvent SaveVisibility(sender, value)
        Else
            Dim isadmin As Integer
            clsSec.isUserAdmin(USER_ID, isadmin)

            RaiseEvent SaveVisibility(sender, DevExpress.XtraBars.BarItemVisibility.Always * IIf(isadmin = 1, 0, 1))
        End If
    End Sub

    Protected Sub SetShowListVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent ShowListVisibility(sender, value)
    End Sub

    Protected Sub SetPreviewReportVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent PreviewReportVisibility(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetDeleteVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        If value = 1 Then 'if user have edit permission and programmer insist to hide the group control, give what the programmer wants
            RaiseEvent DeleteVisibility(sender, value)
        Else

            Dim isadmin As Integer
            clsSec.isUserAdmin(USER_ID, isadmin)

            RaiseEvent DeleteVisibility(sender, clsSec.hasNoDeletePermission(ObjectIDContent, USER_ID, chkRefreshRate, userPermDt) * IIf(isadmin = 1, 0, 1))
        End If
    End Sub

    Protected Sub SetDeleteCrewVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        If value = 1 Then 'if user have edit permission and programmer insist to hide the group control, give what the programmer wants
            RaiseEvent DeleteCrewVisibility(sender, value)
        Else

            Dim isadmin As Integer
            clsSec.isUserAdmin(USER_ID, isadmin)

            '<!-- edited by tony20170926
            '     should specifically point to the "DeleteCrew" object from the tblobjects table
            'RaiseEvent DeleteCrewVisibility(sender, clsSec.hasNoDeletePermission(ObjectIDContent, USER_ID, chkRefreshRate, userPermDt) * IIf(isadmin = 1, 0, 1))
            RaiseEvent DeleteCrewVisibility(sender, clsSec.hasNoDeletePermission("DeleteCrew", USER_ID, chkRefreshRate, userPermDt) * IIf(isadmin = 1, 0, 1))
            '-->
        End If
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetEditVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        If value = 1 Then 'if user have edit permission and programmer insist to hide the group control, give what the programmer wants
            RaiseEvent EditVisibility(sender, value)
        Else
            Dim isadmin As Integer
            clsSec.isUserAdmin(USER_ID, isadmin)

            RaiseEvent EditVisibility(sender, clsSec.hasNoUpdatePermission(ObjectIDContent, USER_ID, chkRefreshRate, userPermDt) * IIf(isadmin = 1, 0, 1))
        End If
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetDeleteSubVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        If value = 1 Then 'if user have edit permission and programmer insist to hide the group control, give what the programmer wants
            RaiseEvent DeleteSubVisibility(sender, value)
        Else
            Dim isadmin As Integer
            clsSec.isUserAdmin(USER_ID, isadmin)

            RaiseEvent DeleteSubVisibility(sender, DevExpress.XtraBars.BarItemVisibility.Never * IIf(isadmin = 1, 0, 1))
        End If
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetDataToolVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        If value = 1 Then 'if user have edit permission and programmer insist to hide the group control, give what the programmer wants
            RaiseEvent DataToolVisibility(sender, value)
        Else
            Dim isadmin As Integer
            clsSec.isUserAdmin(USER_ID, isadmin)

            RaiseEvent DataToolVisibility(sender, clsSec.hasNoDataToolPermission(ObjectIDContent, USER_ID, chkRefreshRate, userPermDt) * IIf(isadmin = 1, 0, 1))
        End If

    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetEditOptionsVisibility(ByVal sender As String, ByVal value As Boolean)
        If value = False Then 'if user have edit permission and programmer insist to hide the group control, give what the programmer wants
            RaiseEvent EditOptionsVisibility(sender, value)
        Else
            Dim isadmin As Integer, bViewPerm As Boolean
            clsSec.isUserAdmin(USER_ID, isadmin) ' if admin = 1 else 0
            If clsSec.hasViewOnlyPermission(ObjectIDContent, USER_ID, chkRefreshRate, userPermDt) = 0 Then 'if has view only permission 0, else 1
                bViewPerm = False
            Else
                bViewPerm = True
            End If

            RaiseEvent EditOptionsVisibility(sender, bViewPerm Or IIf(isadmin = 1, True, False))
        End If
    End Sub

    Protected Sub SetPannelVisibility(ByVal sender As String, ByVal value As DevExpress.XtraEditors.SplitPanelVisibility)
        RaiseEvent PanelVisibility(sender, value)
    End Sub

    Protected Sub SetHideCrewReassignmentRequestVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent HideCrewReassignmentRequestVisibility(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub SetAddVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        If value = 1 Then 'if user have edit permission and programmer insist to hide the group control, give what the programmer wants
            RaiseEvent AddVisibility(sender, value)
        Else
            Dim isadmin As Integer
            clsSec.isUserAdmin(USER_ID, isadmin)

            RaiseEvent AddVisibility(sender, clsSec.hasNoAddPermission(ObjectIDContent, USER_ID, chkRefreshRate, userPermDt) * IIf(isadmin = 1, 0, 1))
        End If
    End Sub

    Public Event CalulatePayVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetCalculatePayVisibility(sender As String, value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent CalulatePayVisibility(sender, value)
    End Sub

    Public Event CalculatePayCaption(sender As String, value As String)
    Protected Sub SetCalculatePayCaption(sender As String, value As String)
        RaiseEvent CalculatePayCaption(sender, value)
    End Sub

    Public Event CalclatePayAllow(sender As String, value As Boolean)
    Protected Sub AllowCalculatePay(sender As String, value As Boolean)
        RaiseEvent CalclatePayAllow(sender, value)
    End Sub

    Protected Sub SetUpdateProgramVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent UpdateProgramVisibility(sender, value)
    End Sub

    Protected Sub SetPageGroupVisibility(ByVal sender As String, ByVal pageCaption As String, ByVal pageGroupName As String, ByVal value As Boolean)
        RaiseEvent PageGroupVisibility(sender, pageCaption, pageGroupName, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .visible properties of the main forms add button.
    Protected Sub EditCheck(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent EditDown(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowAddition(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowAdd(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowSaving(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowSave(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowDeletion(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowDelete(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowLoadingTemplate(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowLoadT(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowShowHideTemplate(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowShowHideT(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowDeletionSub(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowDeleteSub(sender, value)
    End Sub

    Protected Sub SetShowListEnabled(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent ShowListEnabled(sender, value)
    End Sub
    Protected Sub SetPreviewReportEnabled(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent PreviewReportEnabled(sender, value)
    End Sub
    Protected Sub SetViewRecordSumEnabled(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent ViewRecordSumEnabled(sender, value)
    End Sub
    Protected Sub SetHideCrewReassignmentRequestEnabled(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent HideCrewReassignmentRequestEnabled(sender, value)
    End Sub
    Protected Sub SetRibbonPageGroupVisibility(ByVal sender As String, ByVal RibbonPageGroupName As String, ByVal value As Boolean)
        RaiseEvent ShowRibbonPageGroup(Name, RibbonPageGroupName, value)
    End Sub

    Protected Sub SetRibbonPageGroupVisibility(ByVal sender As String, ByVal RibbonPageGroupNameList As List(Of String), ByVal value As Boolean)
        RaiseEvent ShowRibbonPageGroup_UsingArray(Name, RibbonPageGroupNameList, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowDataTool(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowDataToolUtil(sender, value)
    End Sub

    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowEditing(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowEdit(sender, value)
    End Sub

    Protected Sub AllowFLog(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowFLogout(sender, value)
    End Sub

    Public Event FilterVisibility(ByVal sender As String, ByVal e As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub setFilterButtonVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent FilterVisibility(sender, value)
    End Sub

    Public Event SortButtonVisibility(ByVal sender As String, ByVal e As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub setSortButtonVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent SortButtonVisibility(sender, value)
    End Sub
    Public Event ClearFilterButtonVisibility(ByVal sender As Object, ByVal e As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetClearButtonVisibility(ByVal sender As String, ByVal e As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent ClearFilterButtonVisibility(sender, e)
    End Sub

    Public Event RefreshListVisibility(ByVal sender As Object, ByVal e As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetRefreshListVisibility(ByVal sender As String, ByVal e As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent RefreshListVisibility(sender, e)
    End Sub

    Public Event RibbonGroupToolVisibility(ByVal sender As Object, ByVal e As Boolean)
    Protected Sub SetRibbonGroupToolVisibility(ByVal sender As Object, ByVal e As Boolean)
        RaiseEvent RibbonGroupToolVisibility(sender, e)
    End Sub

    Public Event FocusOnMainForm(ByVal sender As String) 'This will sets the focus on the main form control
    Protected Sub SetFocusOnMainForm(ByVal sender As Object)
        RaiseEvent FocusOnMainForm(sender)
    End Sub

    'This function will be called when the user clicks the Save button on Main form. This is blank for the actual content of this function is defined on Sub classes
    Public Overridable Sub SaveData()

    End Sub

    Public Overridable Sub RefreshQuickAccess()

    End Sub


    'This function will be  called when the user clicks the Add button on Main form. This is blank for the actual content of this function is defined on Sub classes
    Public Overridable Sub AddData()
        AllowEditing(Name, False)
        AllowDeletion(Name, False)
        If Not IsNothing(blList) Then
            If blList.RecCount >= 0 Then
                AllowSaving(Name, True)
            Else
                AllowSaving(Name, False)
            End If
        Else
            AllowSaving(Name, True)
        End If
    End Sub

    'This function will be called when the user click the Edit button on Main form. This is blank for the actual content of this function is defined on the Sub Clasees
    Public Overridable Sub EditData()
        AllowDeletion(Name, False)
        AllowAddition(Name, Not isEditdable)
        'AllowSaving(Name, True)
        AllowSaving(Name, isEditdable)
    End Sub

    'This function will be  called when the user clicks the Delete button on Main form. This is blank for the actual content of this function is defined on Sub classes
    Public Overridable Sub DeleteData()
        If Not IsNothing(blList) Then
            blList.bRecordDeleted = True
        End If
    End Sub

    'Utility clear the content of all fields in a certain container.
    'param
    'cContainer - a control that holds the fields to be cleared.
    'bFormatOnly - clear only the format if set to false data will also cleared.
    Public Sub ClearFields(ByVal cContainer As System.Windows.Forms.Control, ByVal bFormatOnly As Boolean)
        'old Code from SAS
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
            If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue = System.DBNull.Value
                If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                    ctr.BackColor = REQUIRED_COLOR
                Else
                    ctr.BackColor = Drawing.Color.White
                End If
                ctr.Tag = 0
            End If
            If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked = False
                ctr.Tag = 0
            End If
        Next
    End Sub

    Public Sub ClearFields(ByVal cContainer As DevExpress.XtraLayout.LayoutControlGroup, ByVal bFormatOnly As Boolean)
        For a As Integer = 0 To cContainer.Items.Count - 1
            If TypeOf cContainer.Items(a) Is DevExpress.XtraLayout.LayoutControlItem Then
                Dim cItem As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(a), DevExpress.XtraLayout.LayoutControlItem)
                Dim ctr As System.Windows.Forms.Control = cItem.Control
                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    'If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue = System.DBNull.Value 'Original
                    If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue = Nothing
                    If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                        ctr.BackColor = REQUIRED_COLOR
                    Else
                        ctr.BackColor = Drawing.Color.White
                    End If
                    ctr.Tag = 0
                End If
                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                    If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked = False
                    ctr.Tag = 0
                End If
            ElseIf TypeOf cContainer.Items(a) Is DevExpress.XtraLayout.LayoutControlGroup Then
                ClearFields(cContainer.Items(a), bFormatOnly)
            End If
        Next
        BRECORDUPDATEDs = False 'Test
    End Sub

    Public Sub ClearFields(ByVal cContainers() As DevExpress.XtraLayout.LayoutControlGroup, ByVal bFormatOnly As Boolean)
        For Each cContainer As DevExpress.XtraLayout.LayoutControlGroup In cContainers
            For a As Integer = 0 To cContainer.Items.Count - 1
                If TypeOf cContainer.Items(a) Is DevExpress.XtraLayout.LayoutControlItem Then
                    Dim cItem As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(a), DevExpress.XtraLayout.LayoutControlItem)
                    Dim ctr As System.Windows.Forms.Control = cItem.Control
                    If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                        If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue = System.DBNull.Value
                        If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                            ctr.BackColor = REQUIRED_COLOR
                        Else
                            ctr.BackColor = Drawing.Color.White
                        End If
                        ctr.Tag = 0
                    End If
                    If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                        If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked = False
                        ctr.Tag = 0
                    End If
                End If
            Next
        Next
        BRECORDUPDATEDs = False 'Test
    End Sub

    'this section is added by tony20170328)
    'this uses a recursive approach for cases wherein there are layoutcontrolgroup/s within a layoutcontrolgroup
    Public Sub ClearFields_Recursive(ByVal cContainers() As DevExpress.XtraLayout.LayoutControlGroup, ByVal bFormatOnly As Boolean)
        For Each cContainer As DevExpress.XtraLayout.LayoutControlGroup In cContainers
            For a As Integer = 0 To cContainer.Items.Count - 1
                If TypeOf cContainer.Items(a) Is DevExpress.XtraLayout.LayoutControlItem Then
                    ClearFieldsOfLayoutControlItem(cContainer.Items(a), bFormatOnly)
                ElseIf TypeOf cContainer.Items(a) Is DevExpress.XtraLayout.LayoutControlGroup Then
                    ClearFieldsInLayoutControlGroup(cContainer.Items(a), bFormatOnly)
                End If
            Next
        Next
        BRECORDUPDATEDs = False 'Test
    End Sub

    Public Sub ClearFieldsInLayoutControlGroup(ByVal cContainer As DevExpress.XtraLayout.LayoutControlGroup, ByVal bFormatOnly As Boolean)
        For a As Integer = 0 To cContainer.Items.Count - 1
            If TypeOf cContainer.Items(a) Is DevExpress.XtraLayout.LayoutControlItem Then
                ClearFieldsOfLayoutControlItem(cContainer.Items(a), bFormatOnly)
            ElseIf TypeOf cContainer.Items(a) Is DevExpress.XtraLayout.LayoutControlGroup Then
                ClearFieldsInLayoutControlGroup(cContainer.Items(a), bFormatOnly)
            End If
        Next
    End Sub

    Public Sub ClearFieldsOfLayoutControlItem(ByVal cItem As DevExpress.XtraLayout.LayoutControlItem, ByVal bFormatOnly As Boolean)
        Dim ctr As System.Windows.Forms.Control = cItem.Control
        If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
            If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.TextEdit).EditValue = System.DBNull.Value
            If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                ctr.BackColor = REQUIRED_COLOR
            Else
                ctr.BackColor = Drawing.Color.White
            End If
            ctr.Tag = 0
        End If
        If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
            If Not bFormatOnly Then CType(ctr, DevExpress.XtraEditors.CheckEdit).Checked = False
            ctr.Tag = 0
        End If
    End Sub
    'end tony


    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub AddEditListener(ByVal cContainer As System.Windows.Forms.Control)
        'OLD CODE
        Dim ctr As System.Windows.Forms.Control
        For Each ctr In cContainer.Controls
            If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                    ctr.BackColor = REQUIRED_COLOR
                Else
                    ctr.BackColor = Drawing.Color.White
                End If
                ctr.Tag = 0
                ctr.Enabled = True
            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Or TypeOf (ctr) Is DevExpress.XtraEditors.RadioGroup Then 'Includes TextEdit, DateEdit, LookupEdit
                AddHandler CType(ctr, DevExpress.XtraEditors.BaseEdit).EditValueChanged, AddressOf Field_EditValueChanged
                ctr.Tag = 0
                ctr.Enabled = True
            End If
        Next
    End Sub

    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub AddEditListener(ByVal cContainer As DevExpress.XtraLayout.LayoutControlGroup)
        For o As Integer = 0 To cContainer.Items.Count - 1
            If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                'insert Old Process Here
                'MsgBox(ctr.Name)
                '===================================================

                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                    AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                    If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                        ctr.BackColor = REQUIRED_COLOR
                    Else
                        ctr.BackColor = Drawing.Color.White
                    End If
                    ctr.Tag = 0
                    ctr.Enabled = True
                ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Or TypeOf (ctr) Is DevExpress.XtraEditors.RadioGroup Then 'Includes TextEdit, DateEdit, LookupEdit
                    AddHandler CType(ctr, DevExpress.XtraEditors.BaseEdit).EditValueChanged, AddressOf Field_EditValueChanged
                    ctr.Tag = 0
                    ctr.Enabled = True
                End If
                '===================================================
            ElseIf TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlGroup Then
                AddEditListener(TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlGroup))
            End If
        Next
    End Sub

    Protected Sub AddEditListener(ByVal cContainers() As DevExpress.XtraLayout.LayoutControlGroup)
        For Each cContainer As DevExpress.XtraLayout.LayoutControlGroup In cContainers
            For o As Integer = 0 To cContainer.Items.Count - 1
                If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                    'insert Old Process Here
                    'MsgBox(ctr.Name)
                    '===================================================

                    If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                        AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                        AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                        AddHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                        If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                            ctr.BackColor = REQUIRED_COLOR
                        Else
                            ctr.BackColor = Drawing.Color.White
                        End If
                        ctr.Tag = 0
                        ctr.Enabled = True
                    ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Or TypeOf (ctr) Is DevExpress.XtraEditors.RadioGroup Then 'Includes TextEdit, DateEdit, LookupEdit
                        AddHandler CType(ctr, DevExpress.XtraEditors.BaseEdit).EditValueChanged, AddressOf Field_EditValueChanged
                        ctr.Tag = 0
                        ctr.Enabled = True
                    End If
                    '===================================================
                End If
            Next
        Next
    End Sub

    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub AddEditListener(ByVal ctr As DevExpress.XtraEditors.TextEdit)
        AddHandler ctr.EditValueChanged, AddressOf Field_EditValueChanged
        AddHandler ctr.GotFocus, AddressOf Field_GotFocus
        AddHandler ctr.LostFocus, AddressOf Field_LostFocus
        If InStr(1, strRequiredFields, ctr.Name) > 0 Then
            ctr.BackColor = REQUIRED_COLOR
        Else
            ctr.BackColor = Drawing.Color.White
        End If
        ctr.Tag = 0
        ctr.Enabled = True
    End Sub

    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub RemoveEditListener(ByVal cContainer As System.Windows.Forms.Control, Optional ByVal Disable As Boolean = True)
        Try
            Dim ctr As System.Windows.Forms.Control
            For Each ctr In cContainer.Controls
                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                    ctr.BackColor = DISABLED_COLOR
                    'ctr.Enabled = False
                    If Disable Then
                        ctr.BackColor = DISABLED_COLOR
                        ctr.Enabled = False
                    End If
                End If
                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf Field_EditValueChanged
                    If Disable Then ctr.Enabled = False
                End If
                ctr.ForeColor = Drawing.Color.Black
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Utility add event on fields that triggers when the field got the focus, lost the focus and updated.
    Protected Sub RemoveEditListener(ByVal cContainer As DevExpress.XtraLayout.LayoutControlGroup, Optional ByVal Disable As Boolean = True)
        Try
            For i As Integer = 0 To cContainer.Items.Count - 1
                If TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.LayoutControlGroup Then
                    Dim group As DevExpress.XtraLayout.LayoutControlGroup = TryCast(cContainer.Items(i), DevExpress.XtraLayout.LayoutControlGroup)
                    For o As Integer = 0 To group.Items.Count - 1
                        If TypeOf (group.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                            Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(group.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                            Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                            'insert Old Process Here
                            '===================================================
                            If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                                RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                                RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                                'ctr.BackColor = DISABLED_COLOR
                                'ctr.Enabled = False
                                If Disable Then
                                    ctr.BackColor = DISABLED_COLOR
                                    ctr.Enabled = False
                                End If
                            End If
                            If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf Field_EditValueChanged
                                If Disable Then ctr.Enabled = False
                            End If
                            ctr.ForeColor = Drawing.Color.Black
                            '===================================================
                        End If

                    Next

                Else
                    If TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                        Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(i), DevExpress.XtraLayout.LayoutControlItem)
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'insert Old Process Here
                        '===================================================
                        If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                            RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                            RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                            ctr.BackColor = DISABLED_COLOR
                            ctr.Enabled = False
                            If Disable Then
                                ctr.BackColor = DISABLED_COLOR
                                ctr.Enabled = False
                            End If
                        End If
                        If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf Field_EditValueChanged
                            If Disable Then ctr.Enabled = False
                        End If
                        ctr.ForeColor = Drawing.Color.Black
                        '===================================================
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub RemoveEditListener(ByVal cContainers() As DevExpress.XtraLayout.LayoutControlGroup, Optional ByVal Disable As Boolean = True)
        Try
            For Each cContainer As DevExpress.XtraLayout.LayoutControlGroup In cContainers
                For i As Integer = 0 To cContainer.Items.Count - 1
                    If TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.LayoutControlGroup Then

                        Dim group As DevExpress.XtraLayout.LayoutControlGroup = TryCast(cContainer.Items(i), DevExpress.XtraLayout.LayoutControlGroup)
                        For o As Integer = 0 To group.Items.Count - 1
                            If TypeOf (group.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (group.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                                Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(group.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                                Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                                'insert Old Process Here
                                '===================================================
                                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).GotFocus, AddressOf Field_GotFocus
                                    RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).LostFocus, AddressOf Field_LostFocus
                                    'ctr.BackColor = DISABLED_COLOR
                                    'ctr.Enabled = False
                                    If Disable Then
                                        ctr.BackColor = DISABLED_COLOR
                                        ctr.Enabled = False
                                    Else
                                        ctr.BackColor = System.Drawing.Color.White
                                        'ctr.Enabled = False
                                    End If
                                End If
                                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                    RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf Field_EditValueChanged
                                    If Disable Then ctr.Enabled = False
                                End If
                                ctr.ForeColor = Drawing.Color.Black
                                '===================================================

                            End If
                        Next
                    ElseIf TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Items(i)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                        RemoveEditListener(TryCast(cContainer.Items(i), DevExpress.XtraLayout.LayoutControlItem), Disable)
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Utility removed the event on a certain control the one you don't want to to program to edit e.t.c all readonly fields.
    Protected Sub RemoveEditListener(ByVal cCtr() As DevExpress.XtraEditors.BaseControl, Optional ByVal Disable As Boolean = True)
        Dim ctr As DevExpress.XtraEditors.BaseControl
        For Each ctr In cCtr
            If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then
                RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
                RemoveHandler ctr.GotFocus, AddressOf Field_GotFocus
                RemoveHandler ctr.LostFocus, AddressOf Field_LostFocus
                If Disable Then
                    ctr.BackColor = DISABLED_COLOR
                    ctr.Enabled = False
                    ctr.ForeColor = Drawing.Color.Black
                End If
            ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
                RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf Field_EditValueChanged
                If Disable Then ctr.Enabled = False
            End If
        Next
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="cCtr"></param>
    ''' <param name="Disable"></param>
    ''' <remarks>added by tony20180413</remarks>
    Protected Sub RemoveEditListener(ByVal cCtr As DevExpress.XtraLayout.LayoutControlItem, Optional ByVal Disable As Boolean = True)
        Dim ctr As System.Windows.Forms.Control = cCtr.Control
        If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then
            RemoveHandler CType(ctr, DevExpress.XtraEditors.TextEdit).EditValueChanged, AddressOf Field_EditValueChanged
            RemoveHandler ctr.GotFocus, AddressOf Field_GotFocus
            RemoveHandler ctr.LostFocus, AddressOf Field_LostFocus
            If Disable Then
                ctr.BackColor = DISABLED_COLOR
                ctr.Enabled = False
                ctr.ForeColor = Drawing.Color.Black
            Else
                ctr.BackColor = System.Drawing.Color.White
                ctr.ForeColor = Drawing.Color.Black
            End If
        ElseIf TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then
            RemoveHandler CType(ctr, DevExpress.XtraEditors.CheckEdit).EditValueChanged, AddressOf Field_EditValueChanged
            If Disable Then ctr.Enabled = False
        End If
    End Sub

    Protected Sub RemoveEditListener(ByVal ctr As DevExpress.XtraEditors.TextEdit, Optional ByVal Disable As Boolean = True)
        RemoveHandler ctr.EditValueChanged, AddressOf Field_EditValueChanged
        RemoveHandler ctr.GotFocus, AddressOf Field_GotFocus
        RemoveHandler ctr.LostFocus, AddressOf Field_LostFocus
        If Disable Then
            ctr.BackColor = DISABLED_COLOR
            ctr.Enabled = False
            ctr.ForeColor = Drawing.Color.Black
        End If
    End Sub

    Protected Sub RemoveEditListener(ByVal ctr As DevExpress.XtraEditors.CheckEdit, Optional ByVal Disable As Boolean = True)
        RemoveHandler ctr.EditValueChanged, AddressOf Field_EditValueChanged
        If Disable Then ctr.Enabled = False
    End Sub

    'Make the controls in the container ReadOnly
    Protected Sub MakeReadOnlyListener(ByVal cContainer As System.Windows.Forms.Control)
        Try
            Dim ctr As System.Windows.Forms.Control
            For Each ctr In cContainer.Controls
                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    CType(ctr, DevExpress.XtraEditors.TextEdit).ReadOnly = True
                    If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                        ctr.BackColor = REQUIRED_COLOR
                    End If
                End If
                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    CType(ctr, DevExpress.XtraEditors.CheckEdit).ReadOnly = True 'ctr.Enabled = False

                End If
                ctr.ForeColor = Drawing.Color.Black
            Next
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub ReadOnlyListener(ByVal cContainer As DevExpress.XtraEditors.BaseEdit, Optional value As Boolean = True)
        Try
            If TypeOf (cContainer) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                cContainer.ReadOnly = value
                If InStr(1, strRequiredFields, cContainer.Name) > 0 Then
                    cContainer.BackColor = REQUIRED_COLOR
                End If
            End If
            If TypeOf (cContainer) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                cContainer.ReadOnly = value 'ctr.Enabled = False
            End If
            cContainer.ForeColor = Drawing.Color.Black


            'Dim ctr As System.Windows.Forms.Control
            'For Each ctr In cContainer.Controls
            '    If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
            '        CType(ctr, DevExpress.XtraEditors.TextEdit).ReadOnly = True
            '        If InStr(1, strRequiredFields, ctr.Name) > 0 Then
            '            ctr.BackColor = REQUIRED_COLOR
            '        End If
            '    End If
            '    If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
            '        CType(ctr, DevExpress.XtraEditors.CheckEdit).ReadOnly = True 'ctr.Enabled = False

            '    End If
            '    ctr.ForeColor = Drawing.Color.Black
            'Next
        Catch ex As Exception
        End Try

    End Sub

    'Make the controls in the container ReadOnly
    Protected Sub MakeReadOnlyListener(ByVal cContainer As DevExpress.XtraLayout.LayoutControlGroup, Optional EditableControls As Boolean = True)
        Try
            For o As Integer = 0 To cContainer.Items.Count - 1
                If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                    'MsgBox(ctr.Name & " - " & ycntrl.Name)
                    'insert Old Process Here
                    '===================================================
                    If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                        CType(ctr, DevExpress.XtraEditors.TextEdit).ReadOnly = True
                        CType(ctr, DevExpress.XtraEditors.TextEdit).Enabled = EditableControls
                        If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                            ctr.BackColor = REQUIRED_COLOR
                        End If
                    End If
                    If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                        CType(ctr, DevExpress.XtraEditors.CheckEdit).ReadOnly = True 'ctr.Enabled = False
                        CType(ctr, DevExpress.XtraEditors.CheckEdit).Enabled = EditableControls
                    End If
                    ctr.ForeColor = Drawing.Color.Black
                    '===================================================
                ElseIf TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlGroup Then
                    MakeReadOnlyListener(cContainer.Items(o))
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Make the controls in the container ReadOnly
    Protected Sub MakeReadOnlyListener(ByVal cContainers() As DevExpress.XtraLayout.LayoutControlGroup)
        Try
            For Each cContainer As DevExpress.XtraLayout.LayoutControlGroup In cContainers
                For o As Integer = 0 To cContainer.Items.Count - 1
                    If TypeOf (cContainer.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                        Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(cContainer.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'MsgBox(ctr.Name & " - " & ycntrl.Name)
                        'insert Old Process Here
                        '===================================================
                        If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            CType(ctr, DevExpress.XtraEditors.TextEdit).ReadOnly = True
                            If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                                ctr.BackColor = REQUIRED_COLOR
                            End If
                        End If
                        If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            CType(ctr, DevExpress.XtraEditors.CheckEdit).ReadOnly = True 'ctr.Enabled = False
                        End If
                        ctr.ForeColor = Drawing.Color.Black
                        '===================================================
                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Remove the controls in the container ReadOnly
    Protected Sub RemoveReadOnlyListener(ByVal cContainer As System.Windows.Forms.Control)
        Try
            Dim ctr As System.Windows.Forms.Control
            For Each ctr In cContainer.Controls
                If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    CType(ctr, DevExpress.XtraEditors.TextEdit).ReadOnly = False
                    If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                        ctr.BackColor = REQUIRED_COLOR
                    End If
                End If
                If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    CType(ctr, DevExpress.XtraEditors.CheckEdit).ReadOnly = False 'ctr.Enabled = False
                End If
                ctr.ForeColor = Drawing.Color.Black
            Next
        Catch ex As Exception
        End Try
    End Sub
    'Remove the controls in the container ReadOnly
    Protected Sub RemoveReadOnlyListener(ByVal cContainer As DevExpress.XtraLayout.LayoutControlGroup)
        Try
            Dim group As DevExpress.XtraLayout.LayoutControlGroup = TryCast(cContainer, DevExpress.XtraLayout.LayoutControlGroup)
            For o As Integer = 0 To group.Items.Count - 1
                If TypeOf (group.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                    Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(group.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                    Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                    'insert Old Process Here
                    '===================================================
                    If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                        CType(ctr, DevExpress.XtraEditors.TextEdit).ReadOnly = False
                        If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                            ctr.BackColor = REQUIRED_COLOR
                        End If
                    End If
                    If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                        CType(ctr, DevExpress.XtraEditors.CheckEdit).ReadOnly = False 'ctr.Enabled = False
                    End If
                    ctr.ForeColor = Drawing.Color.Black
                    '===================================================
                ElseIf TypeOf (group.Items(o)) Is DevExpress.XtraLayout.LayoutControlGroup Then
                    RemoveReadOnlyListener(group.Items(o))
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub RemoveReadOnlyListener(ByVal cContainers() As DevExpress.XtraLayout.LayoutControlGroup)
        Try
            For Each cContainer As DevExpress.XtraLayout.LayoutControlGroup In cContainers
                Dim group As DevExpress.XtraLayout.LayoutControlGroup = TryCast(cContainer, DevExpress.XtraLayout.LayoutControlGroup)
                For o As Integer = 0 To group.Items.Count - 1
                    If TypeOf (group.Items(o)) Is DevExpress.XtraLayout.LayoutControlItem And Not (TypeOf (cContainer.Item(o)) Is DevExpress.XtraLayout.EmptySpaceItem) Then
                        Dim ycntrl As DevExpress.XtraLayout.LayoutControlItem = TryCast(group.Items(o), DevExpress.XtraLayout.LayoutControlItem)
                        Dim ctr As System.Windows.Forms.Control = ycntrl.Control
                        'insert Old Process Here
                        '===================================================
                        If TypeOf (ctr) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            CType(ctr, DevExpress.XtraEditors.TextEdit).ReadOnly = False
                            If InStr(1, strRequiredFields, ctr.Name) > 0 Then
                                ctr.BackColor = REQUIRED_COLOR
                            End If
                        End If
                        If TypeOf (ctr) Is DevExpress.XtraEditors.CheckEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            CType(ctr, DevExpress.XtraEditors.CheckEdit).ReadOnly = False 'ctr.Enabled = False
                        End If
                        ctr.ForeColor = Drawing.Color.Black
                        '===================================================
                    End If
                Next
            Next
        Catch ex As Exception
        End Try
    End Sub

    'Refresh the data source of the sub classes.
    'id - contains the primary key for the data source.
    'desc - description of the sub class
    Public Overridable Sub RefreshData()
        '///tony20170810 check if lost connection to db
        If Not CheckDBConnection(DB, , False) Then Return
        '////

        'set defaults
        focusedView = Nothing 'set the view nothing
        ALLOWNEXTS = False
        BRECORDUPDATEDs = False
        If Not IsNothing(blList) Then
            blList.bRecordDeleted = False
            strID = blList.GetID
            strDesc = IIf(blList.GetID = "", "New Record", blList.GetDesc)
            strFindID = ""
            bAddMode = (blList.GetID = "")
        End If

        'Put permision here
        'SetEditOptionsVisibility(Name, True) 'show editing options

        SetRibbonGroupToolVisibility(Name, True) 'Ribbon Group Toll : RefreshList and Filters


        'add button
        SetAddCaption(Name, "Add")
        AllowAddition(Name, True)
        EditCheck(Name, False)

        'save button
        SetSaveCaption(Name, "Save")
        AllowSaving(Name, False)

        'edit button
        SetEditCaption(Name, "Edit")
        'delete button
        SetDeleteCaption(Name, "Delete")

        SetPrintListCaption(Name, "Print List")

        'If Not IsNothing(blList) Then
        '    If blList.RecCount >= 0 Then

        AllowEditing(Name, True) 'Edit
        AllowDeletion(Name, True) 'Delete 


        '    Else
        '        AllowEditing(Name, False) 'Edit
        '        AllowDeletion(Name, False) 'Delete
        '    End If
        'End If

        'delete sub
        SetDeleteSubCaption(Name, "Delete Sub")
        AllowDeletionSub(Name, False)
        SetDeleteCrewVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'Delete Crew Button : Always Hide

        'data tool
        SetDataToolCaption(Name, "DataTool")
        BRECORDUPDATEDs = False

        'Hide ribbon page groups (call ShowRibbonPageGroup() to show needed group)
        GoHideRibbonPageGroup()

        clsSec.propSQLConnStr = DB.GetConnectionString 'neiltest

        'hide Export to Excel button
        SetExportToExcelVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetViewAttachmentVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'hide View Attachment Button

        'hide load template button
        SetLoadDataVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)

        'Elmer 20160404
        CheckUserSession(DB, USER_SESSION)

        Dim isadmin As Integer
        clsSec.isUserAdmin(USER_ID, isadmin)
        If isadmin = NOT_ADMIN Then

            If clsSec.hasViewOnlyPermission(ObjectIDContent, USER_ID, True, userPermDt) = 0 Then
                'SetEditVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                'SetAddVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                'SetDeleteSubVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                'SetDeleteVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                'SetSaveVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                'SetDataToolVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never)
                'SetEditOptionsVisibility(ObjectIDContent, False)

                RaiseEvent EditVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                RaiseEvent AddVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                RaiseEvent DeleteSubVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                RaiseEvent DeleteVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                RaiseEvent SaveVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                RaiseEvent DataToolVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never)
                RaiseEvent EditOptionsVisibility(ObjectIDContent, False)

            Else
                Dim userRefreshRate As String = DB.DLookUp("Value", "tblUserConfig", "", "FKeyUserID=" & USER_ID & " AND Code='RefreshRate'")
                Dim search_DT As Boolean = IIf(userRefreshRate <> "", IIf(userRefreshRate = "Automatic", False, True), True)

                'SetEditVisibility(ObjectIDContent, clsSec.hasNoUpdatePermission(ObjectIDContent, USER_ID, search_DT, userPermDt)) 'neiltest
                'SetAddVisibility(ObjectIDContent, clsSec.hasNoAddPermission(ObjectIDContent, USER_ID, search_DT, userPermDt)) 'neiltest
                ''SetDeleteSubVisibility(ObjectIDContent, clsSec.hasNoDeletePermission(ObjectIDContent, USER_ID, True, userPermDt)) 'neiltest
                'SetDeleteSubVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                'SetDeleteVisibility(ObjectIDContent, clsSec.hasNoDeletePermission(ObjectIDContent, USER_ID, search_DT, userPermDt)) 'neiltest
                'SetSaveVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
                'SetDataToolVisibility(ObjectIDContent, clsSec.hasNoDataToolPermission(ObjectIDContent, USER_ID, search_DT, userPermDt))
                'SetEditOptionsVisibility(ObjectIDContent, True)

                RaiseEvent EditVisibility(ObjectIDContent, clsSec.hasNoUpdatePermission(ObjectIDContent, USER_ID, search_DT, userPermDt)) 'neiltest
                RaiseEvent AddVisibility(ObjectIDContent, clsSec.hasNoAddPermission(ObjectIDContent, USER_ID, search_DT, userPermDt)) 'neiltest
                'SetDeleteSubVisibility(ObjectIDContent, clsSec.hasNoDeletePermission(ObjectIDContent, USER_ID, True, userPermDt)) 'neiltest
                RaiseEvent DeleteSubVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
                RaiseEvent DeleteVisibility(ObjectIDContent, clsSec.hasNoDeletePermission(ObjectIDContent, USER_ID, search_DT, userPermDt)) 'neiltest
                RaiseEvent SaveVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
                RaiseEvent DataToolVisibility(ObjectIDContent, clsSec.hasNoDataToolPermission(ObjectIDContent, USER_ID, search_DT, userPermDt))
                RaiseEvent EditOptionsVisibility(ObjectIDContent, True)
            End If
        Else
            'SetEditVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'SetAddVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'SetDeleteSubVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'SetDeleteVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'SetSaveVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'SetDataToolVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always)
            'SetEditOptionsVisibility(ObjectIDContent, True)

            'neil 20171121
            'RaiseEvent EditVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'RaiseEvent AddVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'RaiseEvent DeleteSubVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'RaiseEvent DeleteVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'RaiseEvent SaveVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            'RaiseEvent DataToolVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always)
            'RaiseEvent EditOptionsVisibility(ObjectIDContent, True)

            RaiseEvent EditVisibility(ObjectIDContent, clsSec.hasNoUpdatePermission(ObjectIDContent, USER_ID, True, userPermDt, False)) 'neiltest
            RaiseEvent AddVisibility(ObjectIDContent, clsSec.hasNoAddPermission(ObjectIDContent, USER_ID, True, userPermDt, False)) 'neiltest
            RaiseEvent DeleteSubVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            RaiseEvent DeleteVisibility(ObjectIDContent, clsSec.hasNoDeletePermission(ObjectIDContent, USER_ID, True, userPermDt, False)) 'neiltest
            RaiseEvent SaveVisibility(ObjectIDContent, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
            RaiseEvent DataToolVisibility(ObjectIDContent, clsSec.hasNoDataToolPermission(ObjectIDContent, USER_ID, True, userPermDt, False))
            RaiseEvent EditOptionsVisibility(ObjectIDContent, True)
        End If

        'Dim isadmin As Integer
        'clsSec.isUserAdmin(USER_ID, isadmin)
        'If isadmin = NOT_ADMIN Then
        '    If clsSec.hasViewOnlyPermission(Name, USER_ID, True) = 0 Then
        '        SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
        '        SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
        '        SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
        '        SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
        '        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never) 'neiltest
        '        SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        '        SetEditOptionsVisibility(Name, False)
        '    Else
        '        SetEditVisibility(Name, clsSec.hasNoUpdatePermission(Name, USER_ID, True, userPermDt)) 'neiltest
        '        SetAddVisibility(Name, clsSec.hasNoAddPermission(Name, USER_ID, True, userPermDt)) 'neiltest
        '        SetDeleteSubVisibility(Name, clsSec.hasNoDeletePermission(Name, USER_ID, True, userPermDt)) 'neiltest
        '        SetDeleteVisibility(Name, clsSec.hasNoDeletePermission(Name, USER_ID, True, userPermDt)) 'neiltest
        '        SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
        '        SetDataToolVisibility(Name, clsSec.hasNoDataToolPermission(Name, USER_ID, True, userPermDt))
        '        SetEditOptionsVisibility(Name, True)
        '    End If
        'Else
        '    SetEditVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
        '    SetAddVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
        '    SetDeleteSubVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
        '    SetDeleteVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
        '    SetSaveVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always) 'neiltest
        '    SetDataToolVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Always)
        '    SetEditOptionsVisibility(Name, True)
        'End If


        'Payroll
        SetPayrollListVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        'neil SetForceLogoutVisibility(Name, DevExpress.XtraBars.BarItemVisibility.Never)
        SetForceLogoutVisibility(Name, False)
        SetActivityDocsRpgVisibility(Name, False)
        SetActivityActivityDocsRpgVisibility(Name, False)
        'SetAuditRefreshVisibility(Name, False)
        'SetActivityActivityDocsRpgVisibility(Name, False)

        '<!-- added by tony20171213
        RaiseEvent RemoveLTPRelatedControls(Name)
        '-->
    End Sub

    Function chkRefreshRate() As Boolean
        Dim userRefreshRate As String = DB.DLookUp("Value", "tblUserConfig", "", "FKeyUserID=" & USER_ID & " AND Code='RefreshRate'")
        Dim search_DT As Boolean = IIf(userRefreshRate <> "", IIf(userRefreshRate = "Automatic", False, True), True)

        Return search_DT
    End Function
    Public Overridable Sub RefreshPlanningList()

    End Sub



    'Returns the description of the class
    Public Overridable Function GetDesc() As String
        Return ""
    End Function

    'That that will be attached to fields and fires when that field is edited.
    Protected Sub Field_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not TypeOf (sender) Is DevExpress.XtraGrid.GridControl Then
            If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
            End If
            CType(sender, System.Windows.Forms.Control).Tag = 1
            'AllowSaving(Name, (bPermission And 4) > 0) 'Has Edit permission
            BRECORDUPDATEDs = True
        End If
    End Sub

    'That that will be attached to fields and fires when that field got the focus.
    Public Sub Field_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
            If CType(sender, DevExpress.XtraEditors.TextEdit).Tag = 1 Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_FOCUSED_COLOR
            Else
                If InStr(1, strRequiredFields, CType(sender, DevExpress.XtraEditors.TextEdit).Name) > 0 Then
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = REQUIRED_SELECTED_COLOR
                Else
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = SEL_COLOR
                End If
            End If
        End If
    End Sub

    'That that will be attached to fields and fires when that field lost the focus.
    Public Sub Field_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is DevExpress.XtraEditors.TextEdit Then
            If CType(sender, DevExpress.XtraEditors.TextEdit).Tag = 1 Then
                CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = EDITED_COLOR
            Else
                If InStr(1, strRequiredFields, CType(sender, DevExpress.XtraEditors.TextEdit).Name) > 0 Then
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = REQUIRED_COLOR
                Else
                    CType(sender, DevExpress.XtraEditors.TextEdit).BackColor = Drawing.Color.White
                End If
            End If
        End If
    End Sub

    'Check if the sub classes was updated and ask prompt to save the changes.
    Public Overridable Sub CheckIFDataUpdated()

    End Sub

    'Execute custom function of the subclass that is not available on this class.
    Public Overridable Sub ExecCustomFunction(ByVal param() As Object)
        'Sample Implementation
        'Select param(0)
        '    Case "ProcedureNameOnlyNoParameter"
        '        Call ProcedureNameOnlyNoParameter()
        '    Case "ProcedureNameWithParameter"
        '        Call ProcedureNameWithParameter(param(1), param(2), param(etc))
        'End Select
    End Sub

    Public Overridable Sub DataRefresh()

    End Sub

    'Gets Object Value from MainContent
    Public Overridable Function GetObjectFromMainContent(ByVal param() As Object) As Object
        Return Nothing
    End Function

    'Raise custom event.
    Public Overridable Sub RaiseCustomEvent(ByVal sender As String, ByVal param() As Object)
        RaiseEvent OnCustomEvent(sender, param)
    End Sub

    'Copy the ID for Replace Function
    Public Overridable Function CopyData() As String
        Return ""
    End Function

    'to properly Use the msgbox
    'Add Tool tip for msg
    'Will Check the duplicates in the fields
    Public Overridable Function CheckDuplicate(ByVal domain As String, ByVal ctrs() As DevExpress.XtraEditors.BaseEdit, Optional ByVal strCriteria As String = "") As Boolean
        Dim info As Boolean = False 'Return Value
        Dim ctr As DevExpress.XtraEditors.BaseEdit
        Dim str As String = ""
        For Each ctr In ctrs
            If Not TypeOf (ctr) Is DevExpress.XtraEditors.DateEdit Then
                If TypeOf (ctr.EditValue) Is String Then
                    If Trim(ctr.EditValue) <> "" Then
                        If DB.HasDuplicate(domain, "[" & Mid(ctr.Name, 4) & "]='" & ctr.EditValue & "'" & IIf(strCriteria.Length > 0, " AND " & strCriteria, "")) Then
                            info = True
                            str = ctr.ToolTip & ": " & UCase(ctr.Text) & " is already in use." & vbCrLf
                            ctr.BackColor = INVALID_COLOR
                            MsgBox(str, MsgBoxStyle.Exclamation, GetAppName)
                            Exit For
                        Else
                            ctr.BackColor = EDITED_COLOR
                            info = False
                        End If
                    End If
                End If
            End If
        Next
        Return info
    End Function

    Public Overridable Function CheckValidateFields(Optional ByVal showMsg As Boolean = True) As Boolean

    End Function


    Private _RequiredControls As DevExpress.XtraEditors.BaseEdit()
    Public Property RequiredControls() As DevExpress.XtraEditors.BaseEdit()
        Get
            Return _RequiredControls
        End Get
        Set(ByVal value As DevExpress.XtraEditors.BaseEdit())
            strRequiredFields = ""
            For Each ctr As DevExpress.XtraEditors.BaseEdit In value
                strRequiredFields = ctr.Name & ";" & strRequiredFields
            Next
            _RequiredControls = value

        End Set
    End Property



#End Region

#Region "Qualification Matrix"
    'for cleaning as of Sir Welly
    Public Event AllowPrintQualificationMatrix(ByVal sender As String, ByVal value As Boolean) 'Event that will fire when the user has an delete permission. This will enable the edit button on main form.
    'This function will be called from sub classes to trigger the event.
    'params
    'sender - Name of the sub class trigger the event
    'value - boolen that set the .enabled properties of the main forms add button.
    Protected Sub AllowPrintPreview(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowPrintQualificationMatrix(sender, value)
    End Sub

    Public Event PrintPreviewVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the delete button on main form.
    Protected Sub PrintPreviewQualificationMatrixVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent PrintPreviewVisibility(sender, value)

    End Sub
    'end cleaning 
    Public Overridable Sub ClearData()

    End Sub

    Public Overridable Sub HideGroup(sender As String, groupName As String, isHide As Boolean)
        SetRibbonPageGroupVisibility(sender, groupName, isHide)
    End Sub

    Public Overridable Sub ShowChecklistWithFlaggedColors()

    End Sub

#End Region

#Region "Report"
    Public Event ExportVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the export button on main form.   
    Public Event ClearFilterVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the clear filter button on main form.   
    Public Event ApplyEnabled(ByVal sender As String, ByVal value As Boolean) 'This will enabled/disable the clear filter button on main form.   
    Public Event ApplyVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the clear filter button on main form.   
    Public Event ClearFilterEnabled(ByVal sender As String, ByVal value As Boolean) 'This will enabled/disable the clear filter button on main form.   
    Public Event LoadDataVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the load template button on main form.

    Public Event ForceLogoutEnabled(ByVal sender As String, ByVal value As Boolean) 'added by tony20190812

    Protected Sub SetLoadDataVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent LoadDataVisibility(sender, value)
    End Sub

    Protected Sub SetExportVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent ExportVisibility(sender, value)
    End Sub

    Protected Sub SetClearFilterVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent ClearFilterVisibility(sender, value)
    End Sub

    Protected Sub SetApplyEnabled(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent ApplyEnabled(sender, value)
    End Sub

    Protected Sub SetApplyVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent ApplyVisibility(sender, value)
    End Sub

    Protected Sub SetClearFilterEnabled(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent ClearFilterEnabled(sender, value)
    End Sub

    '<!-- added by tony20190812
    Protected Sub SetForceLogoutEnabled(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent ForceLogoutEnabled(sender, value)
    End Sub
    'end tony -->

#Region "Payroll Reports"
    'PAYROLL QUICK REPORTS
    'tony20170118
    Public Event QuickReportsVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the preview (report) button on main form.   
    Protected Sub SetQuickReportsVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent QuickReportsVisibility(sender, value)
    End Sub
    Public Event QuickReportsCaption(sender As String, value As String)
    Protected Sub SetQuickReportsCaption(sender As String, value As String)
        RaiseEvent QuickReportsCaption(sender, value)
    End Sub
    'end tony
#End Region
#End Region

#Region "Activity"
    Public Overridable Sub ActivityCommand(ByVal _activity As String)
    End Sub
#End Region

#Region "DocViewer"
    'For document viewer.
    Public Overridable Sub BulkUpload()
        AllowEditing(Name, False)
        AllowSaving(Name, True)
    End Sub

    Public Overridable Sub setDocTypeFilter(ByVal _criteria As String)

    End Sub

    Public Overridable Sub openNotification()

    End Sub

    Public Overridable Sub setVslFilter(_criteria As String)
        'gvCrewList.ActiveFilterString = _criteria
    End Sub

    Public Overridable Sub DownloadDMSFiles()

    End Sub

    Public Overridable Sub PrintDMSFiles()

    End Sub

#End Region

#Region "For Filtering"
    ''Updated by Calvhin Dec 09, 2015
    Public Overridable Sub applyCrewFilter(ByVal param() As Object)
    End Sub
#End Region

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overridable Sub SaveMainContentLayout()
        If Not System.IO.Directory.Exists(GetAppPath() & "\Users\" & "\Layouts\") Then
            System.IO.Directory.CreateDirectory(GetAppPath() & "\Users\" & "\Layouts\")
        End If
    End Sub

    Public Overridable Sub LoadMainContentLayout()

    End Sub

    Public Overridable Sub ResetMainContentLayout()

    End Sub

#Region "LTP"
    Public Overridable Sub AdjustScaleWidth(ByVal width As Integer)

    End Sub

    Public Overridable Function GetLTPFilterDS(ByVal filter As String) As DataTable
        Return GetLTPFilterDS("")
    End Function


    Public Overridable Function getColorSchemes() As DataTable
        Return getColorSchemes()
    End Function

    Public Overridable Sub FilterLTPResource(ByVal Id As String, ByVal FilterMode As String)

    End Sub

    Public Overridable Sub SortLTPResource(ByVal Id As String, ByVal SortMode As String)

    End Sub

    Public Overridable Sub LTPShowAllRecords(ByVal show As Boolean, ByVal FilterMode As String, ByVal FilterId As String)

    End Sub

    Public Overridable Sub setLTPColorScheme(ByVal indx As Integer)

    End Sub

    '<!-- added by tony20171208
    ''' <summary>
    ''' Resets the value the <c>Counter</c> field.
    ''' </summary>
    ''' <param name="cMode">Vessel; Rank</param>
    Public Overridable Function LTPShowVesselRankSelection(cMode As String) As Boolean

    End Function
    '-->

    Public Overridable Sub undoChanges()

    End Sub

    Public Overridable Sub viewCrewComments()

    End Sub

    Protected Sub AllowUndoChanges(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent AllowUndo(sender, value)
    End Sub

    Public Overridable Sub closeFrmCrewList()

    End Sub

    Public Overridable Sub copyFromCrewList(ByVal data As Object)

    End Sub

    '<!-- added by tony20171213
    ''' <summary>
    '''  Removes floating controls related to LTP
    ''' </summary>
    ''' <remarks></remarks>
    Public Event RemoveLTPRelatedControls(ByVal sender As String)
    Protected Sub DoRemoveLTPRelatedControls(ByVal sender As Object)
        RaiseEvent RemoveLTPRelatedControls(sender)
    End Sub
    '-->

#End Region

#Region "KPI"
    Public Overridable Sub KPIRefreshSelectionList(Optional cFKeyPrincipal As String = "", Optional cFKeyFleet As String = "", Optional bActiveVesselOnly As Boolean = False)

    End Sub

    Public Overridable Function KPIGetMainFormCtlObject(ByVal cControlName As String, Optional ByVal param() As Object = Nothing)
        Return Nothing
    End Function

    'SHOW/HIDE TEMPLATE
    Public Event KPIShowTemplateVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility) 'This will show/hide the show/hide templates button on main form.   

    Protected Sub SetKPIShowTemplateVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent KPIShowTemplateVisibility(sender, value)
    End Sub

    Public Event KPIShowTemplateCaption(ByVal sender As String, ByVal value As String)
    Protected Sub SetKPIShowTemplateCaption(sender As String, value As String)
        RaiseEvent KPIShowTemplateCaption(sender, value)
    End Sub

    Protected Sub SetDeleteTemplateVisibility(ByVal sender As String, ByVal value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent DeleteVisibility(sender, value)
    End Sub

    Public Event GetRibbonControlItemCaption(ByVal sender As String, ByVal ControlName As String, ByRef ReturnValue As String)
    Protected Sub GetRibbonControlItemCaptionFromCrewMain(ByVal sender As String, ByVal ControlName As String, ByRef ReturnValue As String)
        RaiseEvent GetRibbonControlItemCaption(sender, ControlName, ReturnValue)
    End Sub
#End Region


#Region "Payroll"
    Public Event PayrollListVisibility(ByVal sender As Object, ByVal Value As DevExpress.XtraBars.BarItemVisibility)
    Protected Sub SetPayrollListVisibility(ByVal sender As Object, ByVal Value As DevExpress.XtraBars.BarItemVisibility)
        RaiseEvent PayrollListVisibility(sender, Value)
    End Sub

    Public Event ProcessedPayrollListVisibility(ByVal sender As Object, ByVal Value As Boolean)
    Protected Sub SetProcessedPayrollListVisibility(ByVal sender As Object, ByVal Value As Boolean)
        RaiseEvent ProcessedPayrollListVisibility(sender, Value)
    End Sub
#End Region

    Public Event ForceLogoutVisibility(ByVal sender As Object, ByVal Value As Boolean)
    Protected Sub SetForceLogoutVisibility(ByVal sender As Object, ByVal Value As Boolean)
        RaiseEvent ForceLogoutVisibility(sender, Value)
    End Sub

    Public Event ActivityDocsVisibility(ByVal sender As String, ByVal value As Boolean)
    Protected Sub SetActivityDocsVisibility(ByVal sender As Object, ByVal Value As Boolean)
        RaiseEvent ActivityDocsVisibility(sender, Value)
    End Sub

    Public Event ActivityDocsRpgVisibility(ByVal sender As String, ByVal value As Boolean)
    Protected Sub SetActivityDocsRpgVisibility(ByVal sender As Object, ByVal Value As Boolean)
        RaiseEvent ActivityDocsRpgVisibility(sender, Value)
    End Sub

    Public Event ActivityActivityDocsRpgVisibility(ByVal sender As String, ByVal value As Boolean)
    Protected Sub SetActivityActivityDocsRpgVisibility(ByVal sender As Object, ByVal Value As Boolean)
        RaiseEvent ActivityActivityDocsRpgVisibility(sender, Value)
    End Sub

    Public Event AuditRefreshVisibility(ByVal sender As String, ByVal value As Boolean)
    Protected Sub SetAuditRefreshVisibility(ByVal sender As Object, ByVal Value As Boolean)
        RaiseEvent AuditRefreshVisibility(sender, Value)
    End Sub

End Class
