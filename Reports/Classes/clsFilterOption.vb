Public Class clsFilterOption
    Public Function Create(oReportInfo As ReportInfo, Optional UsedBy As BaseFilterOption.ReportFilterOptionUser = BaseFilterOption.ReportFilterOptionUser.Report) As BaseFilterOption
        '### Description: Creates a Filter Option Object
        Dim retvalFilterOption As New BaseFilterOption

        '####################################################################################################################################################################################################################################
        'Load Filter Option Control
        Dim cReportDll As String = ""
        Dim cReportClass As String = ""

        '####################################################################################################################################################################################################################################
        'IDENTIFIES THE DLL AND CLASS TO BE LOADED
        If oReportInfo.ReportFilterOptionClass.Length > 0 And oReportInfo.ReportFilterOptionDLL.Length > 0 Then
            'IF REPORT USES CUSTOM FORM AS FILTER OPTIONS

            '--------------------------------------------------------------------------------------------------
            'This checks if the Filter Option User Control has been already loaded and stored on the saved filter option repository
            'it will be reloaded it is in the saved filter option repository
            retvalFilterOption = FindFilterOptionFromSavedFilterOptionValues(oReportInfo)
            If Not IsNothing(retvalFilterOption) Then GoTo RETURN_VALUE
            '--------------------------------------------------------------------------------------------------

            cReportDll = oReportInfo.ReportFilterOptionDLL
            cReportClass = oReportInfo.ReportFilterOptionClass
        Else
            'IF REPORT USES PRE-DEFINED FILTER OPTIONS
            cReportDll = DefaultFilterOptionControlDLL
            cReportClass = DefaultFilterOptionControl
        End If

        '####################################################################################################################################################################################################################################
        'Load the FilterOption Object from Class and DLL
        retvalFilterOption = LoadFilterOptionAssembly(oReportInfo, cReportDll, cReportClass)

RETURN_VALUE:
        Return retvalFilterOption
    End Function

    Public Function Create(cReportGroup As String, cReportObjectID As String, Optional UsedBy As BaseFilterOption.ReportFilterOptionUser = BaseFilterOption.ReportFilterOptionUser.Report) As BaseFilterOption
        '### Description: Creates a Filter Option Object
        Dim retvalFilterOption As New BaseFilterOption

        '####################################################################################################################################################################################################################################
        'Load the FilterOption Object from Class and DLL
        retvalFilterOption = LoadFilterOptionAssembly(cReportObjectID, cReportGroup, DefaultFilterOptionControlDLL, DefaultFilterOptionControl)

RETURN_VALUE:
        Return retvalFilterOption
    End Function

    Function LoadFilterOptionAssembly(oReportInfo As ReportInfo, cReportDll As String, cReportClass As String) As BaseFilterOption
        'Load the FilterOption Object from Class and DLL
        Dim ReturnValue As BaseFilterOption = Nothing
        If cReportDll.Length > 0 And cReportClass.Length > 0 Then
            'LOADS THE FILTER OPTION FOR THE REPORT
            Dim extAssembly As System.Reflection.Assembly

            extAssembly = System.Reflection.Assembly.Load(cReportDll)
            ReturnValue = extAssembly.CreateInstance(cReportDll & "." & cReportClass, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)

            If Not ReturnValue Is Nothing Then
                With ReturnValue
                    .ReportObjectID = oReportInfo.ObjectID
                    .ReportGroup = oReportInfo.ReportGroup
                    .ControlObject.ObjectDLL = cReportDll
                    .ControlObject.ObjectClass = cReportClass
                    .RefreshData()
                End With
            End If

            If ReturnValue.ContentType = BaseFilterOption.ContentTypeEnum.UserControl Then
                SavedFilterOptionValues.SavedUserControlValues.Save(ReturnValue.Clone)
            End If
        End If

        Return ReturnValue
    End Function

    Function LoadFilterOptionAssembly(cReportObjectID As String, cReportGroup As String, cReportDll As String, cReportClass As String) As BaseFilterOption
        'Load the FilterOption Object from Class and DLL
        Dim ReturnValue As BaseFilterOption = Nothing
        If cReportDll.Length > 0 And cReportClass.Length > 0 Then
            'LOADS THE FILTER OPTION FOR THE REPORT
            Dim extAssembly As System.Reflection.Assembly

            extAssembly = System.Reflection.Assembly.Load(cReportDll)
            ReturnValue = extAssembly.CreateInstance(cReportDll & "." & cReportClass, True, Reflection.BindingFlags.Default, Nothing, Nothing, Nothing, Nothing)

            If Not ReturnValue Is Nothing Then
                With ReturnValue
                    .ReportObjectID = cReportObjectID
                    .ReportGroup = cReportGroup
                    .ControlObject.ObjectDLL = cReportDll
                    .ControlObject.ObjectClass = cReportClass
                    .RefreshData()
                End With
            End If

            If ReturnValue.ContentType = BaseFilterOption.ContentTypeEnum.UserControl Then
                SavedFilterOptionValues.SavedUserControlValues.Save(ReturnValue.Clone)
            End If
        End If

        Return ReturnValue
    End Function

    Public Function CreateWithCustomValues(_keys As String, _values As String) As Reports.BaseFilterOption
        Dim filterOption As New Reports.BaseFilterOption
        Dim layoutControl As New DevExpress.XtraLayout.LayoutControl
        For cnt As Integer = 0 To _keys.Split(";").Length - 1
            Dim control As New DevExpress.XtraEditors.TextEdit
            control.Name = _keys.Split(";").GetValue(cnt)
            control.EditValue = _values.Split(";").GetValue(cnt)
            layoutControl.Controls.Add(control)
        Next cnt
        filterOption.Controls.Add(layoutControl)
        Return filterOption
    End Function

    Private Function FindFilterOptionFromSavedFilterOptionValues(oReportInfo As ReportInfo) As BaseFilterOption
        'This Finds the Filter Option User Control from the Saved Filter Option Values
        Dim ReturnValue As BaseFilterOption = Nothing
        Dim _tmp As BaseFilterOption = SavedFilterOptionValues.SavedUserControlValues.GetValue(oReportInfo.ReportFilterOptionDLL, oReportInfo.ReportFilterOptionClass)
        If Not IsNothing(_tmp) Then
            ReturnValue = _tmp
        End If

        Return ReturnValue
    End Function
End Class
