Public Class BaseList

    Public DB As SQLDB ' A class used to communicate with the SQL Server
    Protected bAddMode As Boolean = False 'Utility variable will be set to true when the AddData function is called.
    Protected bLoaded As Boolean = False 'Utility variable will be set to true on the first call of refreshdata function.   'added by tony20170926
    'Test
    '====================================
    'Public BRECORDUPDATEDs As Boolean
    'Public AllowNext As Boolean = False
    Public bContent As BaseControl
    Public bRecordDeleted As Boolean = False
    '====================================

    Public dtCrewList As New DataTable

    Protected bCopy As Boolean = False
    Protected copID As String = "" 'copied ID for Copy and Replace
    Public TableName As String = "" 'Table name of the control
    Public bDisableSelectionEvent As Boolean = False
    Protected bDraggable As Boolean = False
    Public LayoutFileName As String
    Public PicView As Integer = 0 'Biodata PicView
    Public bListSelect As String = "" 'List Select Statement

    Public allowSave As Boolean = True


    Public BaseControl As String = "" 'Base control Name

    'Event that will fire  when the user edit sub class data. This will enable the save button on main form.
    Public Event OnCustomEvent(ByVal sender As String, ByVal param() As Object)
    'Event that will fire when the sub classes Gridview cell was right clicked.
    Public Event OnCellRightClick(ByVal sender As String)

    'Event that will fire when the sub classes Gridview selection was changed.
    Public Event OnSelectionChange(ByVal sender As String)

    'Try Before Selection Change
    Public Event BeforeSelectionChange(ByVal sender As String)

    'Event that will fire when the sub classes Gridview accepted object via drag and drop.
    Public Event AcceptedDragObject(ByVal sender As String)

    'Filter of the list.
    Public strFilter As String = ""

    Public NoRecAllowBtn As Boolean = True 'will Disable the button/s if the list has no record
    Public RecCount As Integer = 0 'BaseList Record Count

    Public isRefreshingData As Boolean = False      'Added by Tony20161017
    '                                                Used by function GetSelectedID

    Public bSkipGetSelectedID As Boolean = False    'Added by Tony20161017

    'Raise custom event.
    Public Overridable Sub RaiseCustomEvent(ByVal sender As String, ByVal param() As Object)
        RaiseEvent OnCustomEvent(sender, param)
    End Sub

    'Called from the sub classes to trigger the CellRightClick Event
    Protected Sub CellRightClick(ByVal sender As String)
        RaiseEvent OnCellRightClick(sender)
    End Sub

    'Called from the sub classes to trigger the CellRightClick Event
    Protected Sub AcceptDragObject(ByVal sender As String)
        RaiseEvent AcceptedDragObject(sender)
    End Sub

    'Called from the sub classes to trigger the SelectionChange Event
    Protected Sub SelectionChange(ByVal sender As String)
        If Not bDisableSelectionEvent Then
            RaiseEvent OnSelectionChange(sender)
        End If
    End Sub

    'Refresh the datasource of the sub classes
    Public Overridable Function GetFocusedRowData(ByVal _columnname As String) As Object
        Return System.DBNull.Value
    End Function

    'Refresh the datasource of the sub classes
    Public Overridable Sub RefreshData()
        '///tony20170810 check if lost connection to db
        If Not CheckDBConnection(DB, , False) Then Return
        '////
    End Sub

    'Hides the selection to the datagrid of sub classes
    Public Overridable Sub HideSelection()

    End Sub

    'Set the filter on the datagrid
    Public Overridable Sub SetFilter(ByVal _criteria As String)

    End Sub

    'Remove the filter on the datagrid
    Public Overridable Sub ClearFilter()

    End Sub

    'Set selection to a certain record
    Public Overridable Sub SetSelection(ByVal id As String)

    End Sub

    'Set selection to a certain record
    Public Overridable Sub SetSelection(ByVal id As String, ByVal column As String)

    End Sub

    'Added by tony20170628
    'Set selection to a certain record
    Public Overridable Sub SetSelection(ByVal id As String, ByVal setSelectedAsTopIndex As Boolean)

    End Sub

    'Returns the primary key of the data source
    Public Overridable Function GetID() As String
        Return ""
    End Function

    'Returns the description of the class
    Public Overridable Function GetDesc() As String
        Return ""
    End Function

    Public Overridable Sub SaveLayout()

    End Sub


    'Returns the primary key of the data source
    Public Overridable Sub Draggable(ByVal value As Boolean)

    End Sub

    'Execute custom function of the subclass that is not available on this class.
    Public Overridable Sub ExecCustomFunction(ByVal param() As Object)
        'Sample Implementation
        'Select Case param(0)
        '    Case "ProcedureNameOnlyNoParameter"
        '        Call ProcedureNameOnlyNoParameter()
        '    Case "ProcedureNameWithParameter"
        '        Call ProcedureNameWithParameter(param(1), param(2), param(etc))
        'End Select
    End Sub

    'copy ID for Replace Function
    Public Overridable Function CopyID() As String
        Return ""
    End Function

    'Initialize the List
    'columns to be displayed and the Layout based on the UserLogged in
    Public Overridable Sub initList(ByVal _USERID As Integer, ByVal _ObjectID As String)

    End Sub

    'get and sets the layout of the Base List
    Public Overridable Sub SetListLayout(ByVal _ObjectID As String)

    End Sub

    Public Overridable Function getBListDatasource()
        Return ""
    End Function
#Region "Archive"
    Public Overridable Sub SetAllSelected(status As Boolean)

    End Sub

    Public Overridable Sub RunSetToArchiveProcess()

    End Sub

    Public Overridable Sub ActivateArchive()

    End Sub

    Public Overridable Sub RunSetToActiveProcess()

    End Sub

    Public Overridable Sub DeleteArchivedCrew()

    End Sub

#End Region

    Public Overridable Sub clearFind()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializeDtCrewList() 'Currently Used in Expiring Docs Crewlist
    End Sub

    'Currently Used in Expiring Docs Crewlist
    Private Sub InitializeDtCrewList()
        dtCrewList.Columns.Add("FKeyIDNbr", GetType(String))
    End Sub

    Public Event EnableFLogout(ByVal sender As String, ByVal value As Boolean)

    Protected Sub AllowFLog(ByVal sender As String, ByVal value As Boolean)
        RaiseEvent EnableFLogout(sender, value)
    End Sub
End Class
