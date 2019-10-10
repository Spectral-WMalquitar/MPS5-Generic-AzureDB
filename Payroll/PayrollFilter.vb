Public Class PayrollFilter

#Region "Properties"
    Private _Period As Integer = 0
    'Private _Period As Integer = String.Empty
    Public Property PayPeriod() As Integer
        Get
            Return _Period
        End Get
        Set(ByVal value As Integer)
            _Period = value
        End Set
    End Property

    Private _PrincipalCode As String = String.Empty 'MPS4.FKeyPrinCode
    'Private _PrincipalCode As String = String.Empty
    Public Property PayPrincipal() As String
        Get
            Return _PrincipalCode
        End Get
        Set(ByVal value As String)
            _PrincipalCode = value
        End Set
    End Property

    Private _VesselCode As String = String.Empty 'MPS4.FKeyVslCode
    'Private _VesselCode As String = String.Empty
    Public Property PayVessels() As String
        Get
            Return _VesselCode
        End Get
        Set(ByVal value As String)
            _VesselCode = value
        End Set
    End Property

    Private _RefNum As String = String.Empty
    Public Property ReferenceNumbers() As String
        Get
            Return _RefNum
        End Get
        Set(ByVal value As String)
            _RefNum = value
        End Set
    End Property

    Private _PayID As String = String.Empty
    Public Property PayPayIDCodes() As String
        Get
            Return _PayID
        End Get
        Set(ByVal value As String)
            _PayID = value
        End Set
    End Property



#End Region

#Region "Events"

    Public Event cboPeriodChanged(ByVal sender As Object, ByVal e As EventArgs)
    Protected Sub PeriodChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent cboPeriodChanged(sender, e)
    End Sub

    Public Event cboPrinCode(ByVal sender As Object, ByVal e As EventArgs)
    Protected Sub PrincipalChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent cboPrinCode(sender, e)
    End Sub

    Public Event cboVslChanged(ByVal sender As Object, ByVal e As EventArgs)
    Protected Sub VslChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent cboVslChanged(sender, e)
    End Sub

    Public Event cboRefNumChanged(ByVal sender As Object, ByVal e As EventArgs)
    Protected Sub RefNumChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent cboRefNumChanged(sender, e)
    End Sub

#End Region

#Region "Declarations"
    Dim tblVsl As New DataTable, tblPay As New DataTable
    Dim _strPayType As String = String.Empty
#End Region

    Public Sub New(PayType As String)

        ' This call is required by the designer.
        InitializeComponent()
        _strPayType = PayType
        InitControls()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub InitControls()
        cboPeriod.Properties.DataSource = GetPeriods()
        LoadPrincipalDT()
        LoadVesselDT()
        getStrPayListQuery()
        FilterPayList()
        tblPay = MPSDB.CreateTable(getStrPayListQuery)
        cboRefNum.Properties.DataSource = GenerateRefNumDT()
    End Sub

    Private Sub LoadPrincipalDT()
        Dim strPrinFilter As String = IIf(GetUserFilterString(, , "PKey").Length > 0, " WHERE " & GetUserFilterString(, , "PKey"), "")
        cboPrincipal.Properties.DataSource = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.PrincipalList " & strPrinFilter & " ORDER BY Name")
    End Sub

    Private Sub LoadVesselDT()
        Dim strVslFilter As String = IIf(GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt").Length > 0, " WHERE " & GetUserFilterString(, , "FKeyPrincipal", "FKeyFlt"), "")
        'tblVsl = MPSDB.CreateTable("SELECT PKey,Name FROM dbo.VslList " & strVslFilter & "ORDER BY Name")
        tblVsl = MPSDB.CreateTable("SELECT * FROM dbo.VslList " & strVslFilter & "ORDER BY Name")
        cboVessel.Properties.DataSource = tblVsl
    End Sub

    Private Sub cboPrincipal_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPrincipal.ButtonPressed
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            LookUpEd.EditValue = Nothing
        End If
    End Sub

    Private Sub cboPrincipal_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPrincipal.EditValueChanged
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        cboVessel.Properties.DataSource = tblVsl
        If Not IsNothing(LookUpEd.EditValue) Then
            'Load Vessel
            If tblVsl.Select("FKeyPrincipal='" & IfNull(LookUpEd.EditValue, "") & "'").Length > 0 Then
                Dim dv As New DataView(tblVsl.Select("FKeyPrincipal='" & IfNull(LookUpEd.EditValue, "") & "'").CopyToDataTable)
                cboVessel.Properties.DataSource = dv
                cboVessel.Properties.DropDownRows = 10
            End If
        End If
        PayPrincipal = LookUpEd.EditValue
        cboRefNum.Properties.DataSource = GenerateRefNumDT()
        PrincipalChanged(sender, e)
    End Sub

    Public Function getStrPayListQuery() As String
        'Dim strQuery As String = "SELECT * FROM dbo.view_PayrollFilterList WHERE PayType = '" & _strPayType & "' ORDER BY MCode DESC,AdmVslName ASC, DateCreated DESC"
        'tblPay = MPSDB.CreateTable(strQuery)
        Select Case _strPayType
            Case "ONB", "HA"
                Return "SELECT * FROM dbo.view_PayrollFilterList WHERE PayType = '" & _strPayType & "' ORDER BY MCode DESC,AdmVslName ASC, DateCreated DESC"
            Case "MPO"
                Return "SELECT * FROM dbo.view_PayrollFilterList_MPO  ORDER BY MCode DESC,AdmVslName ASC, DateCreated DESC"
            Case Else
                Return String.Empty
        End Select
    End Function

    Private Function FilterPayList() As String
        'Dim strVslFilter As String = IIf(Trim(strGetSelectedVsl()).Length > 0, "  " & strGetSelectedVsl() & " ", String.Empty)
        'Dim strPrinFilter As String = String.Empty

        'If Trim(strVslFilter).Length > 0 Then
        '    If Trim(IfNull(cboPrincipal.EditValue, "")).Length > 0 Then
        '        strPrinFilter = "AND FKeyPrincipal ='" & cboPrincipal.EditValue & "'"
        '    Else
        '        strPrinFilter = String.Empty
        '    End If
        'Else
        '    If Trim(IfNull(cboPrincipal.EditValue, "")).Length > 0 Then
        '        'strPrinFilter = "WHERE FKeyPrincipal ='" & cboPrincipal.EditValue & "'"
        '        strPrinFilter = " FKeyPrincipal ='" & cboPrincipal.EditValue & "'"
        '    Else
        '        strPrinFilter = String.Empty
        '    End If
        'End If
        'Return strVslFilter & " " & strPrinFilter

        Dim retVal As String = String.Empty
        Dim strPeriod As String = IIf(cboPeriod.EditValue <= 0, String.Empty, cboPeriod.EditValue),
            strPrincipal As String = cboPrincipal.EditValue,
            strVslCode As String = strGetSelectedVsl(),
            strRefNo As String = strGetSelectRefNo()

        If Trim(strPeriod).Length > 0 Then
            strPeriod = " MCode = " & cboPeriod.EditValue
        Else
            strPeriod = String.Empty
        End If
        If Trim(strPrincipal).Length > 0 Then
            strPrincipal = " FKeyPrincipal = '" & cboPrincipal.EditValue & "' "
        Else
            strPrincipal = String.Empty
        End If
        If Trim(strVslCode).Length > 0 Then
            strVslCode = strGetSelectedVsl()
        End If
        If Trim(strRefNo).Length > 0 Then
            strRefNo = strGetSelectRefNo()
        End If

        If Trim(strPeriod).Length > 0 Then
            retVal = strPeriod & _
                IIf(Trim(strPrincipal).Length > 0, " AND " & strPrincipal, String.Empty) & _
                IIf(Trim(strVslCode).Length > 0, " AND " & strVslCode, String.Empty) & _
                IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
        Else
            If Trim(strPrincipal).Length > 0 Then
                retVal = IIf(Trim(strPrincipal).Length > 0, strPrincipal, String.Empty) & _
                       IIf(Trim(strVslCode).Length > 0, " AND " & strVslCode, String.Empty) & _
                       IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
            Else
                If Trim(strVslCode).Length > 0 Then
                    retVal = IIf(Trim(strVslCode).Length > 0, strVslCode, String.Empty) & _
                        IIf(Trim(strRefNo).Length > 0, " AND " & strRefNo, String.Empty)
                Else
                    If Trim(strRefNo).Length > 0 Then
                        retVal = IIf(Trim(strRefNo).Length > 0, strRefNo, String.Empty)
                    Else
                        retVal = String.Empty
                    End If
                End If
            End If
        End If
        Return retVal
    End Function

    'Private Function FilterPayList() As String
    '    'Dim strVslFilter As String = IIf(Trim(strGetSelectedVsl()).Length > 0, " WHERE " & strGetSelectedVsl() & " ", String.Empty)
    '    Dim strVslFilter As String = IIf(Trim(strGetSelectedVsl()).Length > 0, "  " & strGetSelectedVsl() & " ", String.Empty)
    '    'Dim strPrinFilter As String = IIf(Trim(strVslFilter).Length > 0 And Trim(IfNull(cboPrincipal.EditValue, "")).Length > 0, " AND FKeyPrincipal='" & cboPrincipal.EditValue & "'", " WHERE FKeyPrincipal='" & cboPrincipal.EditValue & "'")
    '    Dim strPrinFilter As String = String.Empty
    '    If Trim(strVslFilter).Length > 0 Then
    '        If Trim(IfNull(cboPrincipal.EditValue, "")).Length > 0 Then
    '            strPrinFilter = "AND FKeyPrincipal ='" & cboPrincipal.EditValue & "'"
    '        Else
    '            strPrinFilter = String.Empty
    '        End If
    '    Else
    '        If Trim(IfNull(cboPrincipal.EditValue, "")).Length > 0 Then
    '            'strPrinFilter = "WHERE FKeyPrincipal ='" & cboPrincipal.EditValue & "'"
    '            strPrinFilter = " FKeyPrincipal ='" & cboPrincipal.EditValue & "'"
    '        Else
    '            strPrinFilter = String.Empty
    '        End If
    '    End If
    '    Return strVslFilter & " " & strPrinFilter

    'End Function

    Private Sub cboPeriod_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboPeriod.ButtonPressed
        Dim LookUpEd As DevExpress.XtraEditors.LookUpEdit = TryCast(sender, DevExpress.XtraEditors.LookUpEdit)
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            LookUpEd.EditValue = Nothing
        End If
    End Sub

    Private Sub cboPeriod_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboPeriod.EditValueChanged
        cboRefNum.Properties.DataSource = GenerateRefNumDT()
        PayPeriod = IfNull(TryCast(sender, DevExpress.XtraEditors.LookUpEdit).EditValue, 0)
        PeriodChanged(sender, e)
    End Sub

    Private Function GenerateRefNumDT() As DataTable
        Dim cTbl As New DataTable
        cTbl = tblPay
        If cTbl.Select(FilterPayList).Length > 0 Then
            cTbl = cTbl.Select(FilterPayList).CopyToDataTable
            Dim dv As New DataView(cTbl)
            cTbl = dv.ToTable(True, New String() {"PKey", "VslRef"})
        Else
            cTbl = cTbl.Clone
        End If

        Return cTbl
    End Function

    Private Sub cboVessel_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboVessel.ButtonPressed
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ClearCheckLookUp(sender)
        End If
    End Sub

    Private Sub cboVessel_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboVessel.EditValueChanged
        cboRefNum.Properties.DataSource = GenerateRefNumDT()
        VslChanged(sender, e)
    End Sub

    Public Function strGetSelectedVsl() As String
        Dim retVal As String = ""
        For index = 0 To cboVessel.Properties.Items.Count - 1
            If cboVessel.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                retVal = "'" & cboVessel.Properties.Items(index).Value & "'," & retVal
            End If
        Next
        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            PayVessels = retVal 'String of Selected Vessels
            retVal = "FKeyVsl IN( " & retVal & " )"
        Else
            retVal = String.Empty
        End If
        Return retVal
    End Function

    Public Function strGetSelectRefNo() As String
        Dim retVal As String = ""
        For index = 0 To cboRefNum.Properties.Items.Count - 1
            If cboRefNum.Properties.Items(index).CheckState = Windows.Forms.CheckState.Checked Then
                retVal = "'" & cboRefNum.Properties.Items(index).Value & "'," & retVal
            End If
        Next
        If Trim(retVal.Length) > 0 Then
            retVal = retVal.Substring(0, Len(retVal) - 1)
            PayPayIDCodes = retVal 'All the Selected PayIDs
            retVal = "PKey IN( " & retVal & " )"
        Else
            retVal = String.Empty
        End If
        Return retVal
    End Function

    Private Sub cboRefNum_ButtonPressed(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cboRefNum.ButtonPressed
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            ClearCheckLookUp(sender)
        End If
    End Sub

    Private Sub cboRefNum_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles cboRefNum.EditValueChanged
        RefNumChanged(sender, e)
    End Sub

    Private Sub ClearCheckLookUp(sender As Object)
        Dim ctr As DevExpress.XtraEditors.CheckedComboBoxEdit = TryCast(sender, DevExpress.XtraEditors.CheckedComboBoxEdit)
        For index = 0 To ctr.Properties.Items.Count - 1
            ctr.Properties.Items(index).CheckState = Windows.Forms.CheckState.Unchecked
        Next
    End Sub

    Public Sub ClearFilterControls()
        cboPeriod.EditValue = Nothing
        cboPrincipal.EditValue = Nothing
        ClearCheckLookUp(cboVessel)
        ClearCheckLookUp(cboRefNum)
    End Sub

End Class
