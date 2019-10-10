Imports Utilities
Imports MPS4
Imports DevExpress.XtraReports.Parameters

Public Class RetirementSumm
    Public MainReport As New rptRetirementSumm

    Dim body As String = MainReport.txtBodySrc.Rtf

    Public Sub New(ByRef REPORT_DETAIL As Reports.ReportDetail)
        Dim dt As DataTable
        Dim cSQL As String
        Dim MainReportFilter As String = REPORT_DETAIL.GetMainReportFilter(GetUserFilterString(, "FKeyAgent", "FKeyPrin", "FKeyFlt"))
        Dim WhereList As String = REPORT_DETAIL.PresentRecord.SelectionList
        Dim Sorting As String = REPORT_DETAIL.FieldSorting

        '---------------------------------------------------------------------------------------------------------------------------------------
        'CONSTRUCT REPORT DATA SOURCE
        cSQL = "SELECT isLocked, VslName, RankSort, CrewName, MIN(PeriodFrom) AS PeriodFrom, MAX(PeriodTo) AS PeriodTo, SUM(Amount) AS Amount, Curr, CurrStr FROM rpt_RetirementSumm "

        If MainReportFilter.Length > 0 Then
            cSQL = cSQL & " WHERE " & MainReportFilter & " "
        End If

        cSQL = cSQL & " GROUP BY isLocked, VslName, RankSort, CrewName, Curr, CurrStr "

        If Sorting.Length > 0 Then
            cSQL = cSQL & " ORDER BY " & Sorting & " "
        End If

        dt = MPSDB.CreateTable(cSQL)

        '---------------------------------------------------------------------------------------------------------------------------------------
        'VALIDATE REPORT DATA SOURCE, EXIT IF REPORT IS NOTHING OR HAS NO DATA
        If Not validateReportDataSource(dt, REPORT_DETAIL.ShowMsgBox) Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------

        MainReport.DataSource = dt
        MainReport.Name = REPORT_DETAIL.ReportObjectID

        With MainReport
            .celDate.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Date", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToString.ToUpper

            .celToName.Text = MPSDB.GetConfig("LETTER_ToName").ToUpper
            .celToPos.Text = MPSDB.GetConfig("LETTER_ToPos")
            .celToComp.Text = MPSDB.GetConfig("LETTER_ToComp").ToUpper
            .celToDept.Text = MPSDB.GetConfig("LETTER_ToDept")
            .celToAddr1.Text = MPSDB.GetConfig("LETTER_ToAddr1")
            .celToAddr2.Text = MPSDB.GetConfig("LETTER_ToAddr2")

            .txtBody.Rtf = body

            BindData(.celVslName, "Text", Nothing, "VslName")
            BindData(.celPeriodFrom, "Text", Nothing, "PeriodFrom", "{0:dd-MMM-yyyy}")
            BindData(.celPeriodTo, "Text", Nothing, "PeriodTo", "{0:dd-MMM-yyyy}")
            BindData(.celCurr, "Text", Nothing, "Curr")
            BindData(.celCurrTotal, "Text", Nothing, "Curr")
            BindData(.celAmount, "Text", Nothing, "Amount", "{0:#,##0.00}")
            BindData(.celAmountTotal, "Text", Nothing, "Amount", "{0:#,##0.00}")

            AddHandler .txtBody.BeforePrint, AddressOf ctrl_BeforePrint
            AddHandler .celPeriodTo.BeforePrint, AddressOf ctrl_BeforePrint

            AddFieldsToGroupHeaderBand(.GroupHeader1, "CrewName", REPORT_DETAIL.SortOption.GetSortValueCode("CrewName"))
            AddSortFieldsToDetailBandFromDT(.Detail, REPORT_DETAIL.SortOption.SortDataSource)
            AddSortFieldToDetailBand(.Detail, "PeriodFrom", FieldSortOrder.Descending)

            .celCompany.Text = MPS4.MPSDB.GetConfig("Name").ToUpper
            .celSignName.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory", BaseFilterOption.GetFilterReturnWhat.DisplayValue).ToString.ToUpper
            .celSignPos.Text = REPORT_DETAIL.FilterOption.GetFilterValue("Signatory")
        End With

        '---------------------------------------------------------------------------------------------------------------------------------------
        REPORT_DETAIL.MainReport = MainReport
        '---------------------------------------------------------------------------------------------------------------------------------------
    End Sub

    Private Sub ctrl_BeforePrint(sender As System.Object, e As System.Drawing.Printing.PrintEventArgs)
        Dim control As Object = sender
        Dim rpt As New rptRetirementSumm
        Dim crew As String
        Dim dt As DataTable

        If sender.Name = rpt.txtBody.Name Then
            control = CType(sender, DevExpress.XtraReports.UI.XRRichText)
        ElseIf sender.Name = rpt.celPeriodTo.Name Then
            control = CType(sender, DevExpress.XtraReports.UI.XRTableCell)
        End If

        rpt = control.Report

        If control.Name = rpt.txtBody.Name Then
            crew = IIf(IsDBNull(rpt.GetCurrentColumnValue("CrewName")), "", rpt.GetCurrentColumnValue("CrewName"))
            dt = rpt.DataSource
            dt = dt.Select("CrewName = '" & crew & "'").CopyToDataTable
            Dim val As Double = dt.Compute("SUM(Amount)", "")
            Dim curr As String = dt.Rows(0).Item("Curr").ToString.ToUpper
            Dim currStr As String = dt.Rows(0).Item("CurrStr").ToString.ToUpper

            rpt.txtBody.Rtf = body
            rpt.txtBody.Rtf = rpt.txtBody.Rtf.Replace("[CREW]", crew)
            rpt.txtBody.Rtf = rpt.txtBody.Rtf.Replace("[AMT]", _
                                                      New clsConversion().ConvertNumberToWords(val, currStr).ToUpper & _
                                                      " (" & curr & " " & FormatNumber(val, 2, TriState.False, TriState.True, TriState.True) & ")")

        ElseIf control.Name = rpt.celPeriodTo.Name Then
            If IsDBNull(rpt.GetCurrentColumnValue("PeriodTo")) Then
                control.Text = "Present"
            End If

        End If

    End Sub

    Public Class clsConversion

        Dim mOnesArray(8) As String
        Dim mOneTensArray(9) As String
        Dim mTensArray(7) As String
        Dim mPlaceValues(4) As String

        Public Sub New()

            mOnesArray(0) = "one"
            mOnesArray(1) = "two"
            mOnesArray(2) = "three"
            mOnesArray(3) = "four"
            mOnesArray(4) = "five"
            mOnesArray(5) = "six"
            mOnesArray(6) = "seven"
            mOnesArray(7) = "eight"
            mOnesArray(8) = "nine"

            mOneTensArray(0) = "ten"
            mOneTensArray(1) = "eleven"
            mOneTensArray(2) = "twelve"
            mOneTensArray(3) = "thirteen"
            mOneTensArray(4) = "fourteen"
            mOneTensArray(5) = "fifteen"
            mOneTensArray(6) = "sixteen"
            mOneTensArray(7) = "seventeen"
            mOneTensArray(8) = "eightteen"
            mOneTensArray(9) = "nineteen"

            mTensArray(0) = "twenty"
            mTensArray(1) = "thirty"
            mTensArray(2) = "forty"
            mTensArray(3) = "fifty"
            mTensArray(4) = "sixty"
            mTensArray(5) = "seventy"
            mTensArray(6) = "eighty"
            mTensArray(7) = "ninety"

            mPlaceValues(0) = "hundred"
            mPlaceValues(1) = "thousand"
            mPlaceValues(2) = "million"
            mPlaceValues(3) = "billion"
            mPlaceValues(4) = "trillion"

        End Sub

        Protected Function GetOnes(ByVal OneDigit As Integer) As String

            GetOnes = ""

            If OneDigit = 0 Then
                Exit Function
            End If

            GetOnes = mOnesArray(OneDigit - 1)

        End Function

        Protected Function GetTens(ByVal TensDigit As Integer) As String

            GetTens = ""

            If TensDigit = 0 Or TensDigit = 1 Then
                Exit Function
            End If

            GetTens = mTensArray(TensDigit - 2)

        End Function

        Public Function ConvertNumberToWords(ByVal NumberValue As String, Optional ByVal Currency As String = "") As String

            Dim Delimiter As String = " "
            Dim TensDelimiter As String = "-"
            Dim mNumberValue As String = ""
            Dim mNumbers As String = ""
            Dim mNumWord As String = ""
            Dim mFraction As String = ""
            Dim mNumberStack() As String = Nothing
            Dim j As Integer = 0
            Dim i As Integer = 0
            Dim mOneTens As Boolean = False

            ConvertNumberToWords = ""

            ' validate input
            Try
                j = CDbl(NumberValue)
            Catch ex As Exception
                ConvertNumberToWords = "(invalid input)"
                Exit Function
            End Try

            ' get fractional part {if any}
            If InStr(NumberValue, ".") = 0 Then
                ' no fraction
                mNumberValue = NumberValue
            Else
                mNumberValue = Microsoft.VisualBasic.Left(NumberValue, InStr(NumberValue, ".") - 1)
                mFraction = Mid(NumberValue, InStr(NumberValue, ".")) ' + 1)
                mFraction = Math.Round(CSng(mFraction), 2) * 100

                If CInt(mFraction) = 0 Then
                    mFraction = ""
                Else
                    mFraction = "& " & mFraction & "/100 ONLY"
                End If
            End If
            mNumbers = mNumberValue.ToCharArray

            ' move numbers to stack/array backwards
            For j = mNumbers.Length - 1 To 0 Step -1
                ReDim Preserve mNumberStack(i)

                mNumberStack(i) = mNumbers(j)
                i += 1
            Next

            For j = mNumbers.Length - 1 To 0 Step -1
                Select Case j
                    Case 0, 3, 6, 9, 12
                        ' ones  value
                        If Not mOneTens Then
                            mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter
                        End If

                        Select Case j
                            Case 3
                                ' thousands
                                mNumWord &= mPlaceValues(1) & Delimiter

                            Case 6
                                ' millions
                                mNumWord &= mPlaceValues(2) & Delimiter

                            Case 9
                                ' billions
                                mNumWord &= mPlaceValues(3) & Delimiter

                            Case 12
                                ' trillions
                                mNumWord &= mPlaceValues(4) & Delimiter
                        End Select


                    Case Is = 1, 4, 7, 10, 13
                        ' tens value
                        If Val(mNumberStack(j)) = 0 Then
                            mNumWord &= GetOnes(Val(mNumberStack(j - 1))) & Delimiter
                            mOneTens = True
                            Exit Select
                        End If

                        If Val(mNumberStack(j)) = 1 Then
                            mNumWord &= mOneTensArray(Val(mNumberStack(j - 1))) & Delimiter
                            mOneTens = True
                            Exit Select
                        End If

                        mNumWord &= GetTens(Val(mNumberStack(j)))

                        ' this places the tensdelimiter; check for succeeding 0
                        If Val(mNumberStack(j - 1)) <> 0 Then
                            mNumWord &= TensDelimiter
                        End If
                        mOneTens = False

                    Case Else
                        ' hundreds value 
                        mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter

                        If Val(mNumberStack(j)) <> 0 Then
                            mNumWord &= mPlaceValues(0) & Delimiter
                        End If
                End Select
            Next

            Return mNumWord & " " & Currency & " " & mFraction

        End Function

    End Class
End Class
