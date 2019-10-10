Public Class ReportDetail

#Region "Declarations"

    Public DB As SQLDB
    Public ReportInfo As New ReportInfo
    Public PresentRecord As New PresentRecord
    Public FieldSorting As String = ""
    Public FilterOption As New BaseFilterOption
    Public SortOption As New BaseSortOption
    Public Output As New ReportOutputClass
    Public MainReport As DevExpress.XtraReports.UI.XtraReport = Nothing
    Public dtMainSource As New DataTable

    Public Params As New Parameters

    'THIS FIELD IS USED BY AUTO-EMAIL REPORT TO EXCEMPT THE DATE FIELDS THAT ARE AVAILABLE IN THE 
    '   FILTER OPTION AND IS PROVIDED WITH A VALUE BY THE USER
    'Public FieldExcemptList As New List(Of String)
    Public AutoEmail As New AutoEmailClass
    Public ShowMsgBox As Boolean = True
    
    Public Class ReportOutputClass
        Public Mode As ReportOutputMode = ReportOutputMode.Preview
        Public ExportType As ReportExportType = ReportExportType.None
        Public Path As String = ""
    End Class

#Region "Signatories"
    Public PreparedBy As New Signatory
    Public NotedBy As New Signatory
    Public ReceivedBy As New Signatory

    Public Class Signatory
        Public Position As String = ""
        Public Name As String = ""
        Public NameAndPosition As String = ""
    End Class

#End Region

#End Region

#Region "Properties"

    Public ReadOnly Property ReportObjectID As String
        Get
            Return ReportInfo.ObjectID
        End Get
    End Property
    Public ReadOnly Property hasDllAndClass() As Boolean
        Get
            Return (ReportInfo.ReportClass.Length > 0 And ReportInfo.DLL.Length > 0)
        End Get
    End Property

    

#End Region

#Region "Report Selection Events"
    Public Event ApplyFilter(ByVal sender As String, ByVal cFieldName As String, ByVal cCriteria As String) 'This will apply the print selection based on the field name and criteria parameters

    Public Sub ApplyFilterToPrintSelection(ByVal sender As String, ByVal cFieldName As String, ByVal cCriteria As String)
        RaiseEvent ApplyFilter(sender, cFieldName, cCriteria)
    End Sub
#End Region

#Region "Main"

    Public Function GetMainReportFilter(Optional cUserDataFilterString As String = "", Optional ListOfExcemptedFilterOptionsByCaption As List(Of String) = Nothing) As String ', Optional isGetAutoEmailReportCondition As Boolean = False) As String
        Dim cRetval As String = ""

        '####################################################################################################################################################################################################################################
        'This checks if the ReportDetail has a FilterOption object.
        '   FilterOption = control where you can filter records in the Report Selection form
        '
        '   if it has FilterOption, the condition string will be collected from the FilterOption 
        '   object via the GetWhereString function

        If Not FilterOption Is Nothing Then
            cRetval = FilterOption.GetWhereString(, ListOfExcemptedFilterOptionsByCaption)
        End If
        cRetval = IIf(cRetval.Length > 0, "(" & cRetval & ")", cRetval)

        '####################################################################################################################################################################################################################################
        'This gets the list of selected records as a condition
        '   value format is: <field name> IN ('value1', 'value2', 'value3', 'valueN')
        If PresentRecord.ConditionString.Length > 0 Then
            cRetval = cRetval & IIf(cRetval.Length > 0, " AND ", "") & "(" & PresentRecord.ConditionString & ")"
        End If

        '####################################################################################################################################################################################################################################
        'This concatenates the user-data filter string from the passed parameter, cUserDataFilterString
        '   the user-data filter string is used to filter data based on the filter assignment assigned
        '   to a user (by-agent, by-principal or by-fleet
        If cUserDataFilterString.ToString.Length > 0 Then
            cRetval = cRetval & IIf(cRetval.Length > 0, " AND ", "") & "(" & cUserDataFilterString & ")"
        End If

        Return cRetval
    End Function

    'Public Sub InitExcemptFields(cMode)
    '    Select Case cMode
    '        Case "DATERANGE_AUTOEMAIL"
    '            'FROM
    '            If Not IsNothing(AutoEmail.DateRange.Fields._From) Then
    '                If Not IsDBNull(AutoEmail.DateRange.Fields._From) Then
    '                    If AutoEmail.DateRange.Fields._From.ToString.Length > 0 Then
    '                        FieldExcemptList.Add(AutoEmail.DateRange.Fields._From)
    '                    End If
    '                End If
    '            End If

    '            'To
    '            If Not IsNothing(AutoEmail.DateRange.Fields._To) Then
    '                If Not IsDBNull(AutoEmail.DateRange.Fields._To) Then
    '                    If AutoEmail.DateRange.Fields._To.ToString.Length > 0 Then
    '                        FieldExcemptList.Add(AutoEmail.DateRange.Fields._To)
    '                    End If
    '                End If
    '            End If
    '    End Select
    'End Sub

#End Region

    Public Sub RetrieveFilterDate(filterFieldFrom As String, filterFieldTo As String, ByRef dateFrom As Object, ByRef dateTo As Object)
        Dim DateValueFrom As Object = Nothing
        Dim DateValueTo As Object = Nothing
        Dim tmpDateFrom As String = ""
        Dim tmpDateTo As String = ""

        If AutoEmail.Enabled Then
            Try
                If Not IsNothing(AutoEmail.DateRange.Values._From) Then
                    If IsDate(AutoEmail.DateRange.Values._From) Then
                        DateValueFrom = AutoEmail.DateRange.Values._From
                    End If
                End If
            Catch ex As Exception
                DateValueFrom = Nothing
            End Try

            Try
                If Not IsNothing(AutoEmail.DateRange.Values._To) Then
                    If IsDate(AutoEmail.DateRange.Values._To) Then
                        DateValueTo = AutoEmail.DateRange.Values._To
                    End If
                End If
            Catch ex As Exception
                DateValueTo = Nothing
            End Try

        Else
            tmpDateFrom = FilterOption.GetFilterValue(filterFieldFrom)
            If tmpDateFrom.Length > 0 Then
                Try
                    DateValueFrom = CDate(tmpDateFrom)
                Catch ex As Exception
                    DateValueFrom = Nothing
                End Try
            Else
                DateValueFrom = Nothing
            End If

            tmpDateTo = FilterOption.GetFilterValue(filterFieldTo)
            If tmpDateTo.Length > 0 Then
                Try
                    DateValueTo = CDate(tmpDateTo)
                Catch ex As Exception
                    DateValueTo = Nothing
                End Try
            Else
                DateValueTo = Nothing
            End If

        End If

        dateFrom = DateValueFrom
        dateTo = DateValueTo

    End Sub

    ''' <summary>
    ''' replace template fields in stringCondition by field value specified
    ''' </summary>
    ''' <param name="stringCondition">sql condition for date coverage that contains tempFieldFrom and/or tempFieldTo. Disregards field values on auto email</param>
    ''' <param name="tempFieldFrom">to be replaced in stringCondition. Empty string if not applicable</param>
    ''' <param name="tempFieldTo">to be replaced in stringCondition. Empty string if not applicable</param>
    ''' <param name="fieldValFrom">to be assigned in tempFieldFrom</param>
    ''' <param name="fieldValTo">to be assigned in tempFieldTo</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ConstructCoverageCondition(stringCondition As String, tempFieldFrom As String, tempFieldTo As String, fieldValFrom As Object, fieldValTo As Object) As String
        Dim retVal As String = stringCondition

        Dim DateFrom As Object = Nothing
        Dim DateTo As Object = Nothing

        If AutoEmail.Enabled Then
            Try
                If Not IsNothing(AutoEmail.DateRange.Values._From) Then
                    If IsDate(AutoEmail.DateRange.Values._From) Then
                        DateFrom = AutoEmail.DateRange.Values._From
                    End If
                End If
            Catch ex As Exception
                DateFrom = Nothing
            End Try

            Try
                If Not IsNothing(AutoEmail.DateRange.Values._To) Then
                    If IsDate(AutoEmail.DateRange.Values._To) Then
                        DateTo = AutoEmail.DateRange.Values._To
                    End If
                End If
            Catch ex As Exception
                DateTo = Nothing
            End Try

        Else
            DateFrom = fieldValFrom
            DateTo = fieldValTo

        End If

        If Not IsNothing(DateFrom) Then
            If DateFrom.Equals(#12:00:00 AM#) Then DateFrom = Nothing
        End If
        If Not IsNothing(DateTo) Then
            If DateTo.Equals(#12:00:00 AM#) Then DateTo = Nothing
        End If

        'Validate Dates 
        If Not IsNothing(DateFrom) And Not IsNothing(DateTo) Then
            If IsDate(DateFrom) And IsDate(DateTo) Then
                If DateTo < DateFrom Then
                    If ShowMsgBox Then MsgBox("Ending date must be later than the starting date", MsgBoxStyle.Information)
                End If
            End If
        End If


        Dim tmpDateFrom As String = "Null", tmpDateTo As String = "Null"
        If Not IsNothing(DateFrom) Then
            If IsDate(DateFrom) Then tmpDateFrom = ChangeToSQLDate(DateFrom).ToString
        End If

        If Not IsNothing(DateTo) Then
            If IsDate(DateTo) Then tmpDateTo = ChangeToSQLDate(DateTo).ToString
        End If

        If tempFieldFrom.Length <> 0 Then
            retVal = retVal.Replace(tempFieldFrom, tmpDateFrom)
        End If
        If tempFieldTo.Length <> 0 Then
            retVal = retVal.Replace(tempFieldTo, tmpDateTo)
        End If

        Return retVal
    End Function

#Region "Param"
    'Added by tony ON 20180713
    'Can be used to contain a collection of parameters
    Public Class Parameters

        Private ParamList As New List(Of KeyValuePair(Of String, Object))

        Public Sub Add(ParamName As String, Value As Object)
            ParamList.Add(New KeyValuePair(Of String, Object)(ParamName, Value))
        End Sub

        Public Function Find(ParamName As String) As Object
            Try
                Dim ReturnValue As New KeyValuePair(Of String, Object)
                ReturnValue = ParamList.Find(Function(c) c.Key = ParamName)
                Return ReturnValue.Value
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

    End Class
#End Region
End Class
