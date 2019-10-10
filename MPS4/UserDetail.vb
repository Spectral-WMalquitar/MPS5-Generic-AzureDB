Public Class UserDetail

    Enum FilteredUserDataTables
        All = 0
        Agent = 1
        Principal = 2
        Fleet = 3
        VesselAll = 4
        VesselActOnly = 5
    End Enum

    Public Sub New()
        RefreshMode = getUserRefreshRate()
    End Sub

#Region "User Details"
    'Refresh Mode : Automatic; Manual;
    Private _RefreshMode As String = "Automatic"
    Public Property RefreshMode() As String
        Get
            Return _RefreshMode
        End Get
        Set(ByVal value As String)
            _RefreshMode = value
        End Set
    End Property


    'Expiring Documents
    Private _ExpDocDays As Integer
    Public Property ExpDocDays() As Integer
        Get
            Return _ExpDocDays
        End Get
        Set(ByVal value As Integer)
            _ExpDocDays = value
        End Set
    End Property

    'Show Crew Activity Table
    Private _ShowCrewAct As Boolean
    Public Property ShowCrewAct() As Boolean
        Get
            Return _ShowCrewAct
        End Get
        Set(ByVal value As Boolean)
            _ShowCrewAct = value
        End Set
    End Property

    'Show Crew Expiring Document
    Private _ShowCrewExpDoc As Boolean
    Public Property ShowCrewExpDoc() As Boolean
        Get
            Return _ShowCrewExpDoc
        End Get
        Set(ByVal value As Boolean)
            _ShowCrewExpDoc = value
        End Set
    End Property
#End Region

#Region "Functions"
    'Get User RefreshRate
    Private Function getUserRefreshRate() As String
        Dim retval As String = ""
        retval = GetUserSetting("RefreshRate")

        If retval.Equals("") Then
            retval = RefreshMode 'Default RefreshRate
        End If

        Return retval
    End Function
#End Region

#Region "User-Data Filter"
    'Filter Type
    Private _FilterType As Integer
    Public Property FilterType() As Integer
        Get
            Return _FilterType
        End Get
        Set(ByVal value As Integer)
            _FilterType = value
        End Set
    End Property

    'Filtered Agent DataTable
    Private _FilteredAgentDT As DataTable
    Public Property FilteredAgentDT() As DataTable
        Get
            Return _FilteredAgentDT
        End Get
        Set(ByVal value As DataTable)
            _FilteredAgentDT = value
        End Set
    End Property

    ''Agent Filter String
    'Private _AgentFilterString As String
    'Public Property AgentFilterString() As String
    '    Get
    '        Return _AgentFilterString
    '    End Get
    '    Set(ByVal value As String)
    '        _AgentFilterString = value
    '    End Set
    'End Property

    'Filtered Principal DataTable
    Private _FilteredPrinDT As DataTable
    Public Property FilteredPrinDT() As DataTable
        Get
            Return _FilteredPrinDT
        End Get
        Set(ByVal value As DataTable)
            _FilteredPrinDT = value
        End Set
    End Property

    'Principal Filter String
    'Private _PrincipalFilterString As String
    'Public Property PrincipalFilterString() As String
    '    Get
    '        Return _PrincipalFilterString
    '    End Get
    '    Set(ByVal value As String)
    '        _PrincipalFilterString = value
    '    End Set
    'End Property

    'Filtered Fleet DataTable
    Private _FilteredFleetDT As DataTable
    Public Property FilteredFleetDT() As DataTable
        Get
            Return _FilteredFleetDT
        End Get
        Set(ByVal value As DataTable)
            _FilteredFleetDT = value
        End Set
    End Property

    ''Fleet Filter String
    'Private _FleetFilterString As String
    'Public Property FleetFilterString() As String
    '    Get
    '        Return _FleetFilterString
    '    End Get
    '    Set(ByVal value As String)
    '        _FleetFilterString = value
    '    End Set
    'End Property

    'Filtered Vessel DataTable
    Private _FilteredVesselDT As DataTable
    Public Property FilteredVesselDT() As DataTable
        Get
            Return _FilteredVesselDT
        End Get
        Set(ByVal value As DataTable)
            _FilteredVesselDT = value
        End Set
    End Property

    'Filtered Vessel (Active Vessels) DataTable
    Private _FilteredVesselActiveOnlyDT As DataTable
    Public Property FilteredVesselActiveOnlyDT() As DataTable
        Get
            Return _FilteredVesselActiveOnlyDT
        End Get
        Set(ByVal value As DataTable)
            _FilteredVesselActiveOnlyDT = value
        End Set
    End Property

    ''Vessel Filter String
    'Private _VesselFilterString As String
    'Public Property VesselFilterString() As String
    '    Get
    '        Return _VesselFilterString
    '    End Get
    '    Set(ByVal value As String)
    '        _VesselFilterString = value
    '    End Set
    'End Property

#End Region

#Region "User-Data Filter Functions/Procedures"
    Sub InitFilteredUserData(ByVal WhatData As FilteredUserDataTables)
        Try

            'AGENT
            If WhatData = FilteredUserDataTables.All Or WhatData = FilteredUserDataTables.Agent Then
                FilteredAgentDT = New DataTable
                'FilteredAgentDT = getPredefDataSource("AGENT_BYNAME")
                FilteredAgentDT = createFilteredData("SELECT * FROM dbo.tbladmcompany WHERE isManAgent <> 0", FilteredDataObjectType.SQL, "Name", , "PKey")
                If WhatData <> FilteredUserDataTables.All Then Exit Try
            End If

            'PRINCIPAL
            If WhatData = FilteredUserDataTables.All Or WhatData = FilteredUserDataTables.Principal Then
                FilteredPrinDT = New DataTable
                'FilteredPrinDT = getPredefDataSource("PRINCIPAL_BYNAME")
                FilteredPrinDT = createFilteredData("SELECT * FROM dbo.tbladmcompany WHERE isPrincipal <> 0", FilteredDataObjectType.SQL, "Name", , , "PKey")
                If WhatData <> FilteredUserDataTables.All Then Exit Try
            End If

            'FLEET
            If WhatData = FilteredUserDataTables.All Or WhatData = FilteredUserDataTables.Fleet Then
                FilteredFleetDT = New DataTable
                'FilteredFleetDT = getPredefDataSource("FLEET_BYNAME")
                FilteredFleetDT = createFilteredData("SELECT * FROM dbo.tbladmflt", FilteredDataObjectType.SQL, "Name", , , , "PKey")
                If WhatData <> FilteredUserDataTables.All Then Exit Try
            End If

            'VESSEL
            If WhatData = FilteredUserDataTables.All Or WhatData = FilteredUserDataTables.VesselAll Or WhatData = FilteredUserDataTables.VesselActOnly Then
                FilteredVesselDT = New DataTable
                FilteredVesselActiveOnlyDT = New DataTable
                'FilteredVesselDT = getPredefDataSource("VESSEL_ALL")
                'FilteredVesselActiveOnlyDT = getPredefDataSource("VESSEL_ALL_ACTIVE")
                FilteredVesselDT = createFilteredData("SELECT * FROM dbo.tbladmvsl", FilteredDataObjectType.SQL, "Name", , , "FKeyPrincipal", "FKeyFlt")
                FilteredVesselActiveOnlyDT = createFilteredData("SELECT * FROM dbo.tbladmvsl WHERE VslStat = 1", FilteredDataObjectType.SQL, "Name", , , "FKeyPrincipal", "FKeyFlt")
                If WhatData <> FilteredUserDataTables.All Then Exit Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public CREW_DATATABLE As DataTable
    Public AGENT_DATATABLE As DataTable
    Public PRIN_DATATABLE As DataTable
    Public FLEET_DATATABLE As DataTable
    Public VSL_DATATABLE As DataTable
    Public VSL_ACTIVEONLY_DATATABLE As DataTable

    Function getFilteredUserDataDT(getWhat As UserDetail.FilteredUserDataTables, Optional _RefreshList As String = "Automatic") As DataTable
        'getWhat =  AGENT
        '           PRINCIPAL
        '           FLEET
        '           VESSEL_ALL
        '           VESSEL_ACTONLY

        Dim retTable As New DataTable
        Dim bRefreshDT As Boolean = False

        If _RefreshList.Equals("Automatic") Then
            bRefreshDT = True
        Else
            bRefreshDT = IsNothing(CREW_DATATABLE)
        End If

        If bRefreshDT Then
            USER_INFO.InitFilteredUserData(getWhat)
            retTable = USER_INFO.getFilteredUserDataDTsub(getWhat)

            'ASSIGN GENERATED DATATABLE TO GLOBAL VARIABLE
            Select Case getWhat
                Case UserDetail.FilteredUserDataTables.Agent
                    AGENT_DATATABLE = retTable
                Case UserDetail.FilteredUserDataTables.Principal
                    PRIN_DATATABLE = retTable
                Case UserDetail.FilteredUserDataTables.Fleet
                    FLEET_DATATABLE = retTable
                Case UserDetail.FilteredUserDataTables.VesselAll
                    VSL_DATATABLE = retTable
                Case UserDetail.FilteredUserDataTables.VesselActOnly
                    VSL_ACTIVEONLY_DATATABLE = retTable
            End Select
            '--------------------------------------------------------------------------------------------
        Else
            'GET FROM TO GLOBAL DATATABLE VARIABLE
            Select Case getWhat
                Case UserDetail.FilteredUserDataTables.Agent
                    retTable = AGENT_DATATABLE
                Case UserDetail.FilteredUserDataTables.Principal
                    retTable = PRIN_DATATABLE
                Case UserDetail.FilteredUserDataTables.Fleet
                    retTable = FLEET_DATATABLE
                Case UserDetail.FilteredUserDataTables.VesselAll
                    retTable = VSL_DATATABLE
                Case UserDetail.FilteredUserDataTables.VesselActOnly
                    retTable = VSL_ACTIVEONLY_DATATABLE
            End Select
            '--------------------------------------------------------------------------------------------
        End If

        Return retTable

    End Function

    Private Function getFilteredUserDataDTsub(ByVal WhatData As FilteredUserDataTables) As DataTable
        Dim retval As New DataTable
        Select Case WhatData
            Case FilteredUserDataTables.Agent
                retval = FilteredAgentDT
            Case FilteredUserDataTables.Principal
                retval = FilteredPrinDT
            Case FilteredUserDataTables.Fleet
                retval = FilteredFleetDT
            Case FilteredUserDataTables.VesselAll
                retval = FilteredVesselDT
            Case FilteredUserDataTables.VesselActOnly
                retval = FilteredVesselActiveOnlyDT
        End Select
        Return retval
    End Function

#End Region
  End Class
