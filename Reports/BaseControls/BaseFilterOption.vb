Imports DevExpress.XtraLayout
Imports DevExpress.XtraEditors

Public Class BaseFilterOption

    '**********************************************************************************************************
    'Notes:
    '   1. To clear the value of ALL filter options, call ClearFilterValueAll()
    '   2. To clear the value of SPECIFIC filter options control, call ClearFilterValue(<Control Name>)
    '
#Region "Declarations"
    Public ReportObjectID As String = ""
    Public ReportGroup As String = ""
    Public DB As SQLDB = MPSDB
    Public FilterOptionGrouping As String = ""
    Public bIsLoaded As Boolean = False
    Public UsedBy As ReportFilterOptionUser = ReportFilterOptionUser.Report
    Public ControlObject As New ControlObjectClass
    Public ContentType As ContentTypeEnum
    Public AdditionalFilterOptions As New ReportObjectInfo

    Dim bIsReapplyFilterAfterClearAll As Boolean = True

    Public Enum ReportFilterOptionUser
        Report = 1
        KPI = 2
    End Enum

    Public Enum GetFilterReturnWhat
        DisplayValue = 1
        EditValue = 2
    End Enum

    Structure FilterOptionFilterFields
        'Const OptionsObjectID = "OptionsObjectID"
        'Const FieldName = "TableFieldName"
        'Const FieldType = "TableFieldType"
        'Const Caption = "Caption"
        'Const Value = "Value"
        'Const DisplayValue = "DisplayValue"
        'Const ControlType = "ControlType"
        'Const RowSource = "RowSource"
        'Const RowSourceType = "RowSourceType"
        'Const RowSourceDisplayField = "RowSourceDisplayField"
        'Const RowSourceValueField = "RowSourceValueField"
        'Const Operator$ = "Operator"
        'Const DefaultValue = "DefaultValue"
        'Const LoadDefaultValueCustomFunction = "LoadDefaultValueCustomFunction"
        'Const SaveDefaultValueCustomFunction = "SaveDefaultValueCustomFunction"
        'Const ApplyToReportSource = "ApplyToReportSource"

        Const OptionsObjectID = "PKey"
        Const FKeyFilterOption = "FKeyFilterOption"
        Const FieldName = "ReportKeyFilterField"
        Const FieldType = "ValueFieldType"
        Const Caption = "Caption"
        Const Value = "Value"
        Const DisplayValue = "DisplayValue"
        Const ControlType = "ControlType"
        Const RowSource = "RowSource"
        Const RowSourceType = "RowSourceType"
        Const RowSourceDisplayField = "RowSourceDisplayField"
        Const RowSourceValueField = "RowSourceValueField"
        Const RowSourceSortField = "RowSourceSortField"
        Const ComboBoxCustomRowSource = "ComboBoxCustomRowSource"
        Const Operator$ = "Operator"
        Const ApplyToReportSource = "ApplyToReportSource"
        Const isRowSourceHasUserDataFilter = "isRowSourceHasUserDataFilter"

        Const AgentFieldName = "AgentFieldName"
        Const PrinFieldName = "PrinFieldName"
        Const FleetFieldName = "FleetFieldName"
        Const VslFieldName = "VslFieldName"

    End Structure

    Structure FilterOptionControlType
        Const ComboBox = "COMBOBOX"
        Const TextBox = "TEXTBOX"
        Const DateEdit = "DATEEDIT"
        Const CheckBox = "CHECKBOX"
    End Structure

    Structure FilterOptionDataType
        Const String$ = "STRING"
        Const Numeric = "NUMERIC"
        Const Bool = "BOOLEAN"
        Const DateTime = "DATETIME"
        Const Date$ = "DATE"
    End Structure

    Public Enum ContentTypeEnum
        UserControl = 1
        GridControl = 2
    End Enum

#End Region

#Region "Main"

    Public Overridable Sub RefreshData()
        Me.BackColor = Color.White
    End Sub

    Public Overridable Sub RefreshData(ByVal StringDelimitedItemList As String)
        Me.BackColor = Color.White
    End Sub

    Public Overridable Sub ExecCustomFunction(ByVal param() As Object)
        Select Case param(0)
            Case "1"

            Case "2"

            Case "3"

        End Select
    End Sub

    Public Overridable Function GetWhereString(Optional param() As Object = Nothing, Optional ListOfExcemptedFilterOptionsByCaption As List(Of String) = Nothing) As String
        '####################################################################################################################################################################################################################################
        '### Description: Gets the complete where clause string based on the values selected from the GridFilter
        Dim cRetval As String = ""
        Return cRetval
    End Function
#End Region

#Region "Report Selection Events"
    Public Event _ApplyFilterToPrintSelectionByFieldName(ByVal sender As String, ByVal cFieldName As String, ByVal cCriteria As String) 'This will apply the print selection based on the field name and criteria parameters
    Public Event _CallClearSelectionListFilter(ByVal sender As String)
    Public Event _isFieldInSelectionGridView(ByVal sender As String, ByVal cPrintSelectionFieldName As String, ByRef bReturnValue As Boolean)

    Public Overridable Sub CallClearSelectionListFilter()
        '####################################################################################################################################################################################################################################
        '### Description: Clears the Selection from the parent user control
        RaiseEvent _CallClearSelectionListFilter(Name)
    End Sub

    Public Overridable Sub ApplyFilterToPrintSelection()
        '####################################################################################################################################################################################################################################
        '### Description: Applies filter to the Print Selection
        'THIS CODE APPLIES ALL FILTER INTO THE PRINT SELECTION
        'code may vary depending on your code.
        'you can loop through each content of your user control and generate the condition/criteria
        'on each loop, call the ApplyFilterToPrintSelectionByFieldName(FieldName, Criteria) to apply each filter to the selection

    End Sub

    Public Sub ApplyFilterToPrintSelectionByFieldName(ByVal cPrintSelectionFieldName As String, ByVal cCriteria As String)
        '####################################################################################################################################################################################################################################
        '### Description: Applies filter to the Print Selection by Field Name
        RaiseEvent _ApplyFilterToPrintSelectionByFieldName(Name, cPrintSelectionFieldName, cCriteria)
    End Sub

    Public Overridable Sub isFieldInSelectionGridView(ByVal cPrintSelectionFieldName As String, ByRef bReturnValue As Boolean)
        RaiseEvent _isFieldInSelectionGridView(Name, cPrintSelectionFieldName, bReturnValue)
    End Sub

    Public Overridable Function HasFilterValuesToSave() As Boolean
        '####################################################################################################################################################################################################################################
        '### Description: Checks if there are any selection made
        Dim bSuccess As Boolean = False
        Try
            For Each ctl As Control In Me.Controls
                If TypeOf ctl Is DevExpress.XtraLayout.LayoutControl Then
                    Dim oCtl As DevExpress.XtraLayout.LayoutControl = TryCast(ctl, DevExpress.XtraLayout.LayoutControl)
                    For Each oControl As Control In oCtl.Controls
                        Dim cOptionsObjectID = oControl.Name
                        Dim cOptionValue = Nothing
                        If TypeOf (oControl) Is DevExpress.XtraEditors.DateEdit Then
                            cOptionValue = ChangeToSQLDate(CType(CType(oControl, DevExpress.XtraEditors.DateEdit).EditValue, Date))
                        ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            If CType(oControl, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                Dim str As String = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                cOptionValue = sysMpsUserPassword("ENCRYPT", str)
                            ElseIf TypeOf (CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                Dim str As String = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                cOptionValue = str
                            Else
                                cOptionValue = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue
                            End If
                        ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.CheckEdit Then
                            If CType(oControl, DevExpress.XtraEditors.CheckEdit).Checked Then
                                cOptionValue = 1
                            Else
                                cOptionValue = 0
                            End If
                        End If

                        '####################################################################################################################################################################################################################################
                        'IF JUST ONLY ONE FILTER OPTION HAS A VALUE, IT MEANS THERE IS A FILTER VALUE TO SAVE
                        If Not cOptionValue Is Nothing Then
                            bSuccess = True
                            GoTo RETURN_AND_EXIT
                        End If

                    Next
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function

    Public Overridable Function GetFilterValue(ByVal cControlName As String, Optional ByVal ReturnWhat As GetFilterReturnWhat = GetFilterReturnWhat.EditValue, Optional ByVal quoted As Boolean = False) As Object
        '####################################################################################################################################################################################################################################
        '### Description: Gets the filter value from the form controls based on the control name parameter
        Dim objValue = Nothing
        Dim ReturnValue = Nothing
        Dim oControl As New Control

        Try
            For Each ctl As Control In Me.Controls
                If Not ctl Is Nothing Then
                    If TypeOf ctl Is DevExpress.XtraLayout.LayoutControl Then
                        Dim oCtl As DevExpress.XtraLayout.LayoutControl = TryCast(ctl, DevExpress.XtraLayout.LayoutControl)
                        Dim obj As Object = oCtl.Controls(cControlName)

                        If Not obj Is Nothing Then
                            oControl = obj
                            GoTo GET_VALUE
                        Else
                            GoTo NEXT_CONTROL
                        End If
                    End If

                    oControl = ctl

GET_VALUE:
                    If oControl.Name = cControlName Then
                        If TypeOf (oControl) Is DevExpress.XtraEditors.DateEdit Then
                            'Always Return EditValue, DisplayValue Does notApply
                            ReturnValue = CType(CType(oControl, DevExpress.XtraEditors.DateEdit).EditValue, Date)
                        ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                            If CType(oControl, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                Dim str As String = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                ReturnValue = sysMpsUserPassword("ENCRYPT", str)
                            ElseIf TypeOf (CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                Dim str As String = String.Empty
                                'If InStr(CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString, "','") > 0 Then
                                '    str = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                'Else
                                'str = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''") ' Old Code
                                str = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                'End If
                                If quoted Then
                                    str = str.Replace(" ", "").Replace(",", "','")
                                    str = IIf(str.Length <> 0, "'" & str & "'", "")
                                End If
                                ReturnValue = str
                            Else
                                ReturnValue = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue
                            End If
                        ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.CheckEdit Then
                            If CType(oControl, DevExpress.XtraEditors.CheckEdit).Checked Then
                                ReturnValue = 1
                            Else
                                ReturnValue = 0
                            End If
                        End If
                        Exit For
                    End If
                End If
NEXT_CONTROL:
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            GoTo RETURN_AND_EXIT
        End Try
        'If CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue Is Nothing Then
        '    Return ""
        '    Exit Function
        'End If
        If ReturnValue Is Nothing Then
            ReturnValue = ""
        End If
        Return ReturnValue
        Exit Function
RETURN_AND_EXIT:
        'If CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue Is Nothing Then
        '    Return ""
        '    Exit Function
        'End If
        If ReturnValue Is Nothing Then
            ReturnValue = ""
        End If
        Return ReturnValue
    End Function

    Public Overridable Function GetFilterValue(ByVal cCaption As String, ByVal cFieldName As String) As Object
        'This is used by FilterControlDefault.vb class when accessing a field that is neither the editvalue nor the displaymember
        Return Nothing
    End Function

    Public Overridable Sub SetFilterValue(ByVal cControlName As String, ByVal value As Object)
        Dim ctl As Control = Nothing
        Dim oControl As New Control
        Try
            ctl = Me.Controls(cControlName)
        Catch ex As Exception

        End Try

        If Not ctl Is Nothing Then
            If TypeOf ctl Is DevExpress.XtraLayout.LayoutControl Then
                Dim oCtl As DevExpress.XtraLayout.LayoutControl = TryCast(ctl, DevExpress.XtraLayout.LayoutControl)
                Dim obj As Object = oCtl.Controls(cControlName)

                If Not obj Is Nothing Then
                    oControl = obj
                    GoTo SET_VALUE
                End If

            End If

            oControl = ctl

SET_VALUE:
            If oControl.Name = cControlName Then
                If TypeOf (oControl) Is DevExpress.XtraEditors.DateEdit Then
                    CType(oControl, DevExpress.XtraEditors.DateEdit).EditValue = value
                ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                    CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue = value
                ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.CheckEdit Then
                    CType(oControl, DevExpress.XtraEditors.CheckEdit).Checked = value
                End If
            End If
        End If
    End Sub

    Public Overridable Sub ClearFilterValueAll(Optional isReapplyFilter As Boolean = True)
        '####################################################################################################################################################################################################################################
        '### Description: Clears the value of all rows/filter options
        Dim oControl As New Control
        bIsReapplyFilterAfterClearAll = isReapplyFilter
        Try
            For Each ctl As Control In Me.Controls
                If Not ctl Is Nothing Then
                    If TypeOf ctl Is LayoutControl Then
                        For Each item As BaseLayoutItem In CType(ctl, LayoutControl).Items
                            If TypeOf item Is LayoutControlItem Then
                                ClearControl((CType(item, LayoutControlItem).Control))
                            End If
                        Next
                    Else
                        ClearControl(ctl)
                    End If
                End If
NEXT_CONTROL:
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        bIsReapplyFilterAfterClearAll = True
    End Sub

    Private Sub ClearControl(ByVal ctl As Control)
        Try
            If TypeOf (ctl) Is CheckEdit Then
                CType(ctl, CheckEdit).Checked = 0

            Else
                CType(ctl, TextEdit).EditValue = Nothing
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Overridable Sub ClearFilterValue(ByVal cControlName As String)
        '####################################################################################################################################################################################################################################
        '### Description: Clears the Filter Option (Control) Value based on control name
        Dim oControl As New Control

        Try
            For Each ctl As Control In Me.Controls
                If Not ctl Is Nothing Then
                    If TypeOf ctl Is DevExpress.XtraLayout.LayoutControl Then
                        Dim oCtl As DevExpress.XtraLayout.LayoutControl = TryCast(ctl, DevExpress.XtraLayout.LayoutControl)
                        Dim obj As Object = oCtl.Controls(cControlName)

                        If Not obj Is Nothing Then
                            oControl = obj
                            GoTo CLEAR_VALUE
                        Else
                            GoTo NEXT_CONTROL
                        End If
                    End If

                    oControl = ctl

CLEAR_VALUE:
                    If oControl.Name = cControlName Then
                        ClearControl(oControl)
                        Exit For
                    End If
                End If
NEXT_CONTROL:
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "For KPI"
    Public Overridable Function GetConditionDescForKPI() As String
        Return ""
    End Function
#End Region

#Region "Templates-Related"
    Public Overridable Function SaveFilterOptionValuesToTemplate(ByVal cTemplatePKey As String) As Boolean
        '####################################################################################################################################################################################################################################
        'Description: Saves the Filter values to the templates
        Dim bSuccess As Boolean = False
        Try
            '####################################################################################################################################################################################################################################
            'IF THERE IS A PASSED TEMPLATE PKEY PARAMETER
            If cTemplatePKey.Length > 0 Then
                For Each ctl As Control In Me.Controls
                    If TypeOf ctl Is DevExpress.XtraLayout.LayoutControl Then
                        Dim oCtl As DevExpress.XtraLayout.LayoutControl = TryCast(ctl, DevExpress.XtraLayout.LayoutControl)
                        For Each oControl As Control In oCtl.Controls
                            Dim cOptionsObjectID = oControl.Name
                            Dim cOptionValue = Nothing
                            If TypeOf (oControl) Is DevExpress.XtraEditors.DateEdit Then
                                cOptionValue = ChangeToSQLDate(CType(CType(oControl, DevExpress.XtraEditors.DateEdit).EditValue, Date))
                            ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                If CType(oControl, DevExpress.XtraEditors.TextEdit).Properties.UseSystemPasswordChar Then
                                    Dim str As String = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString
                                    cOptionValue = sysMpsUserPassword("ENCRYPT", str)
                                ElseIf TypeOf (CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue) Is String Then
                                    Dim str As String = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue.ToString.Replace("'", "''")
                                    cOptionValue = str
                                Else
                                    cOptionValue = CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue
                                End If
                            ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.CheckEdit Then
                                If CType(oControl, DevExpress.XtraEditors.CheckEdit).Checked Then
                                    cOptionValue = 1
                                Else
                                    cOptionValue = 0
                                End If
                            End If

                            '####################################################################################################################################################################################################################################
                            'INSERT INTO FILTER OPTION VALUES TEMPLATES IF CONTROL HAS A VALUE
                            If Not cOptionValue Is Nothing Then
                                Try
                                    bSuccess = MPSDB.RunSql("INSERT INTO dbo." & tblNameTemplateValues & " ([FKeyTemplate], [OptionsObjectID], [OptionsType], [Value], [SortCode]) " & _
                                                            "VALUES ('" & cTemplatePKey & "', '" & cOptionsObjectID & "', 'FILTER', '" & cOptionValue & "',0)")
                                Catch ex As Exception
                                    LogErrors("Inserting filter [" & cOptionsObjectID & " = " & cOptionValue & "] into report template with key [" & cTemplatePKey & "] failed.")
                                    LogErrors("Error: " & ex.Message)
                                End Try
                            End If

                        Next
                    End If
                Next

            Else
                '####################################################################################################################################################################################################################################
                'IF THERE IS NO PASSED TemplatePKey PARAMETER
                bSuccess = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            bSuccess = False
        End Try

RETURN_AND_EXIT:
        Return bSuccess
    End Function

    Public Overridable Function HasFilterOptionTemplateValues(ByVal TemplateKey As String) As Boolean
        Dim ReturnVavlue As Boolean = False
        Try
            MPSDB.BeginReader("SELECT * FROM dbo.MSystblRepOptTemplateValues WHERE FKeyTemplate = '" & TemplateKey & "' AND OptionsType = '" & ReportTemplateContentType.Filter & "'")
            ReturnVavlue = MPSDB.HasRows
        Catch ex As Exception
            ReturnVavlue = False
        End Try

        Return ReturnVavlue
    End Function

    Public Overridable Sub LoadFilterOptionTemplateValues(ByVal TemplateKey As String)
        '####################################################################################################################################################################################################################################
        'Description: Loads the Filter values from the selected template
        Dim oControl As New Control
        Dim templateItems As DataTable = CreateReportTemplateValuesDT(TemplateKey, ReportTemplateContentType.Filter)
        If templateItems.Rows.Count = 0 Then Exit Sub

        For Each row As DataRow In templateItems.Rows
            Try
                For Each ctl As Control In Me.Controls
                    If Not ctl Is Nothing Then
                        If TypeOf ctl Is DevExpress.XtraLayout.LayoutControl Then
                            Dim oCtl As DevExpress.XtraLayout.LayoutControl = TryCast(ctl, DevExpress.XtraLayout.LayoutControl)
                            Dim obj As Object = oCtl.Controls(row("OptionsObjectID"))

                            If Not obj Is Nothing Then
                                oControl = obj
                                GoTo GET_VALUE
                            Else
                                GoTo NEXT_CONTROL
                            End If
                        End If

                        oControl = ctl
GET_VALUE:
                        If oControl.Name = row("OptionsObjectID") Then
                            If TypeOf (oControl) Is DevExpress.XtraEditors.DateEdit Then
                                CType(oControl, DevExpress.XtraEditors.DateEdit).EditValue = CType(row("Value"), Date)
                            ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.TextEdit Then 'Includes TextEdit, DateEdit, LookupEdit
                                CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue = CType(row("Value"), String)
                            ElseIf TypeOf (oControl) Is DevExpress.XtraEditors.CheckEdit Then
                                CType(oControl, DevExpress.XtraEditors.TextEdit).EditValue = CType(row("Value"), Integer)
                            End If
                            Exit For
                        End If
                    End If
NEXT_CONTROL:
                Next
            Catch ex As Exception

            End Try
        Next
    End Sub
#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ContentType = ContentTypeEnum.UserControl
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function Clone() As BaseFilterOption
        Dim temp = DirectCast(Me.MemberwiseClone(), BaseFilterOption)
        Return temp
    End Function
End Class
