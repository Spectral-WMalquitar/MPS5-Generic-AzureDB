Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Security.Cryptography
Imports System.Text.RegularExpressions
Imports System.IO

Public Module Util
    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Const MAX_ENTRY As Integer = 32768

    Public Const AppAcronym As String = "BRS"

    Public SERVER_AUTH As String, SQL_SERVER As String, SQL_USER_NAME As String, SQL_PASSWORD As String, SQL_DATABASE As String

    Public Function GetConnectionString(Optional ByVal hasDB As Boolean = True)
        If SERVER_AUTH = "STISQLSERVER" Then
            SQL_SERVER = SQL_SERVER.Replace("\STISQLSERVER", "")
            Return "Data Source=" & SQL_SERVER & "\STISQLSERVER" & IIf(hasDB, ";Database=" & SQL_DATABASE, "") & ";Persist Security Info=True;User ID=sa;Password=sffSDfsdfdfSDFsdffDFSF2164564DFSD2Df2345ABCSTFS"
        ElseIf SERVER_AUTH = "SQLSERVER_AUTH" Then
            Return "Server=" & SQL_SERVER & IIf(hasDB, ";Database=" & SQL_DATABASE, "") & ";User Id=" & SQL_USER_NAME & ";Password=" & SQL_PASSWORD & ";"
        ElseIf SERVER_AUTH = "WIN_AUTH" Then
            Return "Server=" & SQL_SERVER & IIf(hasDB, ";Database=" & SQL_DATABASE, "") & ";Trusted_Connection=True;"
        Else
            Return ""
        End If
    End Function

#Region "Error Handling"
    Public Sub TryCatch(ByVal cModule As String, ex As Exception)
        MsgBox(cModule & "()" & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "A problem occured")
    End Sub

    Public Sub LogErrors(ErrMsg As String)
        Dim strFileName As String, strDir As String
        strFileName = CleanPath(GetAppPath()) & "Errors" & "\Error_" & Now.ToString("yyyyMMdd") & ".txt"
        strDir = ExtractFileDirOnly(strFileName)

        If Not System.IO.Directory.Exists(strDir) Then
            Try
                System.IO.Directory.CreateDirectory(strDir)
            Catch ex As Exception

            End Try
        End If

        Using sw As New System.IO.StreamWriter(strFileName, True)
            sw.WriteLine(ErrMsg)
        End Using
    End Sub
#End Region

#Region "Misc Functions"
    Function GetAppName() As String
        Return "MPS Service App"
    End Function

    Function GetAppPath() As String
        Return My.Application.Info.DirectoryPath
    End Function
#End Region

#Region "INI"
    Public Function INI_GetConfig(ByVal cApplication As String, ByVal cKey As String, Optional ByVal cINIFile As String = "") As String
        Dim sb As New StringBuilder(MAX_ENTRY)
        If NullToString(cINIFile) = "" Then
            cINIFile = GetAppPath() & "\Config.ini"
        ElseIf InStr(cINIFile, "\") = 0 Then
            cINIFile = GetAppPath() & "\" & cINIFile
        End If
        Dim Ret As Integer = GetPrivateProfileString(cApplication, cKey, "", sb, MAX_ENTRY, cINIFile)
        INI_GetConfig = sb.ToString()
    End Function

    Public Function INI_SaveConfig(ByVal cApplication As String, ByVal cKey As String, ByVal cValue As String, Optional ByVal cINIFile As String = "")
        Dim bRetVal As Boolean = False
        Try
            If NullToString(cINIFile) = "" Then
                cINIFile = GetAppPath() & "\Config.ini"
            Else
                cINIFile = GetAppPath() & "\" & cINIFile
            End If
            If WritePrivateProfileString(cApplication, cKey, cValue, cINIFile) = 0 Then
                'inform user of error saving in INI file. This may be a problem with the file being read only or the user having
                'no permissions on the folder
                MsgBox("Error saving '" & cKey & "'. Check file permissions on " & cINIFile)
                bRetVal = False
            Else
                bRetVal = True
            End If
            Return bRetVal
        Catch ex As Exception
            MsgBox("Error saving '" & cKey & "'. Check file permissions on " & cINIFile)
            Return False
        End Try
    End Function

#End Region

#Region "String Functions"
    ' VB.NET to convert a string to a byte array
    Public Function StrToByteArray(str As String) As Byte()
        ' Convert String to Byte array.
        Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(str)
        Return array
    End Function 'StrToByteArray

    Public Function ByteArrayToString(ByVal dBytes As Byte()) As String
        Dim str As String = System.Text.ASCIIEncoding.ASCII.GetString(dBytes)
        Return str
    End Function

    Public Function ByteArrayToHex(ByVal bytes_Input As Byte()) As String
        Dim strTemp As New StringBuilder(bytes_Input.Length * 2)
        For Each b As Byte In bytes_Input
            strTemp.Append(Conversion.Hex(b))
        Next
        Return strTemp.ToString()
    End Function

    Public Function UppercaseFirst(ByVal s) As String
        Dim cVal As String = NullToString(s)
        ' Check for empty string.
        If cVal.Length > 0 Then
            cVal = UCase(Left(cVal, 1)) & LCase(Mid(cVal, 2))
            ' Return char and concat substring. 
        End If
        Return cVal
    End Function

    'returns a 1 dimensional string array based on a string list
    Public Function MakeArray(ByVal cList As String, ByVal cDelimitedby As String) As String()
        Dim nCtr As Integer
        Dim nCount As Integer = CountItemDelimited(cList, cDelimitedby)
        Dim cRetVal As String() = New String() {}

        On Error Resume Next

        ReDim cRetVal(nCount - 1)

        For nCtr = 1 To nCount
            cRetVal(nCtr - 1) = Trim$(GetItemDelimited(cList, nCtr, cDelimitedby))
        Next

        Return cRetVal

    End Function

    Public Sub AddErr(ByRef cErr As String, ByVal cNewErr As String)
        If cNewErr.Length > 0 Then
            cErr = cErr & IIf(cErr.Length > 0, vbCrLf, "") & "- " & cNewErr
        End If
    End Sub

    Public Function DispErr(ByVal cErr As String) As String
        Dim cErrMsg As String
        cErrMsg = "Attention:" & vbCrLf
        cErrMsg = cErrMsg & cErr
        Return cErrMsg
    End Function

    'generates random code 
    Public Function GetAutoCode(Optional ByVal nLen As Integer = 15, Optional ByVal cSysValidIDChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890") As String
        Dim nCtr As Integer, cCode As String
        Dim cAlphaNum As String

        cAlphaNum = cSysValidIDChars

        cCode = ""

        Randomize(Timer)

        For nCtr = 1 To nLen
            cCode = cCode & Mid$(cAlphaNum, Int(Len(cAlphaNum) * Rnd() + 1), 1)
        Next

        Return cCode

    End Function

    'FUNCTION: Trims down <cStringValue> to <nNumChars> long and appends "..." when trimming has been done.
    Public Function TrimString(ByVal cStringValue As String, ByVal nNumChars As Integer) As String
        Dim cRetVal As String
        cRetVal = cStringValue
        If Len(cStringValue) > nNumChars Then
            cRetVal = Left(cRetVal, nNumChars) & "..."
        End If
        Return cRetVal
    End Function

    'RSA: function to remove any illlegal path redirection 
    Public Function RemovePathRedirection(ByVal cPath As String) As String
        Dim cRetVal As String
        cRetVal = NullToString(cPath)
        cRetVal = Replace(cRetVal, "~/", "")
        cRetVal = Replace(cRetVal, "../", "")
        cRetVal = Replace(cRetVal, "./", "")
        cRetVal = Replace(cRetVal, "//", "")

        cRetVal = Replace(cRetVal, "~\", "")
        cRetVal = Replace(cRetVal, "..\", "")
        cRetVal = Replace(cRetVal, ".\", "")
        cRetVal = Replace(cRetVal, "\\", "")
        Return cRetVal
    End Function

    'RSA: FUNCTION: Retains only the characters specified in  
    '               <cRegCode>, bydefault is "[^A-Za-z0-9 ]" (alphanumeric and a ' ' SPACE character)
    Public Function RemoveIllegalCharacters(ByVal input As String, Optional ByVal cRegCode As String = "[^A-Za-z0-9 ]") As String
        Dim reg As Regex = New Regex(cRegCode)
        Dim output As String = reg.Replace(input, String.Empty)
        Return output
    End Function

    'trims down input for possible sql injection code
    Public Function RemoveInject(ByVal Value As String, Optional ByVal cEscapeChar As String = "\") As String
        Dim retVal As String

        retVal = Value

        'forward slash
        retVal = Replace(retVal, "\", cEscapeChar & "\")
        'single quote
        retVal = Replace(retVal, "'", cEscapeChar & "'")
        'double quote
        retVal = Replace(retVal, Chr(34), cEscapeChar & Chr(34))

        Return NullToString(retVal)

    End Function

    'Removes double and single quotes
    Public Function RemoveQuotes(ByVal Value As String) As String
        Dim retVal As String

        retVal = Value

        'single quote
        retVal = Replace(retVal, "'", "")
        'double quote
        retVal = Replace(retVal, Chr(34), "")

        Return NullToString(retVal)

    End Function
#End Region

#Region "Disk IO Functions"
    'RETURNS : a nice foldername <cDir> with "\" appended at the end
    Public Function CleanPath(ByVal cDir As String, Optional ByVal cSeparator As String = "\") As String
        Return cDir & IIf(Right(cDir, 1) = cSeparator, "", cSeparator)
    End Function

    ' Calculates a file's hash value and returns it as a byte array.
    'RSA: Taken from http://www.dreamincode.net/forums/blog/114/entry-2853-using-hashes-to-check-if-a-file-changed-in-vbnet/
    Public Function ComputeFileHash(ByVal fileName As String) As Byte()
        Dim ourHash(0) As Byte
        ' If file exists, create a HashAlgorithm instance based off of MD5 encryption
        ' You could use a variant of SHA or RIPEMD160 if you like with larger hash bit sizes.
        If File.Exists(fileName) Then
            Try
                Dim ourHashAlg As HashAlgorithm = HashAlgorithm.Create("MD5")
                Dim fileToHash As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read)
                'Compute the hash to return using the Stream we created.
                ourHash = ourHashAlg.ComputeHash(fileToHash)
                fileToHash.Close()
            Catch ex As IOException
            End Try
        End If
        Return ourHash
    End Function


    ' Return true/false if the two hashes are the same.
    'RSA: Taken from http://www.dreamincode.net/forums/blog/114/entry-2853-using-hashes-to-check-if-a-file-changed-in-vbnet/
    Public Function CompareByteHashes(ByVal newHash As Byte(), ByVal oldHash As Byte()) As Boolean
        ' If any of these conditions are true, the hashes are definitely not the same.
        If newHash Is Nothing Or oldHash Is Nothing Or newHash.Length <> oldHash.Length Then
            Return False
        End If
        ' Compare each byte of the two hashes. Any time they are not the same, we know there was a change.
        For i As Integer = 0 To newHash.Length - 1
            If newHash(i) <> oldHash(i) Then
                Return False
            End If
        Next i
        Return True
    End Function


    Public Function ExtractFileDirOnly(ByVal cFileSpec)
        On Error GoTo ErrDir
        Dim nCtr As Long, cFileName As String
        For nCtr = Len(cFileSpec) To 1 Step -1
            If Mid$(cFileSpec, nCtr, 1) = "\" Then Exit For
        Next
        If Mid$(cFileSpec, 1, nCtr) = "" Then
            'relative path was given
            For nCtr = 1 To Len(cFileSpec)
                If Mid$(cFileSpec, nCtr, 1) = ":" Then Exit For
            Next
        End If
        If nCtr > Len(cFileSpec) Then
            ExtractFileDirOnly = ""
        Else
            ExtractFileDirOnly = Mid$(cFileSpec, 1, nCtr)
        End If
        Exit Function
ErrDir:
        ExtractFileDirOnly = ""
    End Function


    Public Function ExtractFileNameOnly(ByVal cFileSpec)
        Dim nnCtr As Long, cFileName As String
        If cFileSpec Is Nothing Then
            cFileSpec = ""
        End If
        cFileName = ""
        For nnCtr = Len(cFileSpec) To 1 Step -1
            If Mid$(cFileSpec, nnCtr, 1) <> "\" Then
                cFileName = Mid$(cFileSpec, nnCtr, 1) & cFileName
            Else
                Exit For
            End If
        Next
        ExtractFileNameOnly = cFileName
    End Function

    Public Function FileExists(ByVal FileFullPath As String) As Boolean
        Dim bRetVal As Boolean = False

        Try
            'Dim f2 As New Security.Permissions.FileIOPermission(Security.Permissions.FileIOPermissionAccess.Read, FileFullPath)
            'f2.AddPathList(Security.Permissions.FileIOPermissionAccess.Write Or Security.Permissions.FileIOPermissionAccess.Read, FileFullPath)
            'f2.Demand()

            Dim f As New IO.FileInfo(FileFullPath)
            bRetVal = f.Exists
        Catch ex As Exception
        End Try
        Return bRetVal
    End Function

    Public Function FolderExists(ByVal FolderPath As String) As Boolean
        Dim f2 As New Security.Permissions.FileIOPermission(Security.Permissions.FileIOPermissionAccess.Read, FolderPath)
        f2.AddPathList(Security.Permissions.FileIOPermissionAccess.Write Or Security.Permissions.FileIOPermissionAccess.Read, FolderPath)
        f2.Demand()

        Dim f As New IO.DirectoryInfo(FolderPath)
        Return f.Exists
    End Function
#End Region

#Region "Null Functions"
    Public Function NullToDouble(ByVal nValue) As Double
        On Error Resume Next
        If String.IsNullOrEmpty(nValue) Then
            Return 0
        Else
            Return nValue
        End If
    End Function

    Public Function NullToDBDate(ByVal oDate As Object) As Object
        On Error Resume Next
        Dim oRetVal As Object = DBNull.Value

        If String.IsNullOrEmpty(oDate) Then
            Return DBNull.Value
        Else
            If IsDate(oDate) Then
                oRetVal = DirectCast(oDate, Date)
            End If
        End If

        Return oRetVal
    End Function

    Public Function NullToDate(ByVal oDate As Object) As Date
        On Error Resume Next
        Dim dRetVal As Date

        If String.IsNullOrEmpty(oDate) Then
            Return Nothing
        Else
            If IsDate(oDate) Then
                dRetVal = DirectCast(oDate, Date)
            End If
        End If

        Return dRetVal
    End Function

    Public Function NullToZero(ByVal nValue) As Long
        On Error Resume Next
        If String.IsNullOrEmpty(nValue) Then
            Return 0
        Else
            Return nValue
        End If
    End Function

    Public Function NullToString(ByVal cValue) As String
        On Error Resume Next
        If String.IsNullOrEmpty(cValue) Then
            Return ""
        Else
            Return cValue
        End If
    End Function

    Public Function NullToAny(ByVal xValue As Object) As Object
        On Error Resume Next
        If String.IsNullOrEmpty(xValue) Then
            Return Nothing
        Else
            Return xValue
        End If
    End Function

    Public Function DateToLong(ByVal dDateVal As Object) As Long
        On Error Resume Next
        If String.IsNullOrEmpty(dDateVal) Then
            Return 0
        Else
            Return Format(dDateVal, "yyyyMMdd")
        End If
    End Function

    'FUNCTION: Returns NOTHING when <xValue> is NULL or Empty or the value is contained in the semi-colon delimited list <cInvalidValues>
    Public Function InvalidValueToNothing(ByVal xValue As Object, ByVal cInvalidValues As String) As Object
        On Error Resume Next
        If String.IsNullOrEmpty(xValue) OrElse InStr(";" & cInvalidValues & ";", ";" & xValue & ";") > 0 Then
            Return Nothing
        Else
            Return xValue
        End If
    End Function

#End Region

#Region "Date Functions"

    Public Function LogDate(Optional ByVal bIncludeDate As Boolean = True) As String
        Dim cLogDesc As String = ""
        cLogDesc = Format(Now, IIf(bIncludeDate, "yyyy-MMM-dd ", "") & "hh:mm tt")
        Return cLogDesc
    End Function

    Public Function FindEarliestDate(oFindDay As DayOfWeek, Optional ByVal dStartDate As Date? = Nothing)
        Dim dDate As Date
        If dStartDate.HasValue Then
            dDate = dStartDate
        Else
            dDate = Now
        End If

        Do While dDate.DayOfWeek <> oFindDay
            dDate = dDate.AddDays(1)
        Loop
        Return dDate
    End Function

    'Find Earlist DAY starting from TODAY
    Public Function FindEarliestDay(nValue As Integer, Optional ByVal dStartDate As Date? = Nothing) As DayOfWeek
        Dim nStartDay As Integer
        Dim oDay As DayOfWeek = Nothing
        Dim nDay As Integer = 0
        Dim nBinValue As Double
        Dim bFound As Boolean = False

        If dStartDate.HasValue Then
            nStartDay = dStartDate.Value.DayOfWeek
        Else
            nStartDay = Now.DayOfWeek
        End If

        'MPSDE DB               VB.NET
        ' 0 - monday - 1          1
        ' 1 - tue    - 2          2
        ' 2 - wed    - 4          3
        ' 3 - thu    - 8          4
        ' 4 - fri    - 16         5
        ' 5 - sat    - 32         6
        ' 6 - sun    - 64         0

        If nStartDay = 0 Then
            nStartDay = 7
        End If

        'start with the current day
        For nDay = nStartDay - 1 To 6
            nBinValue = Math.Pow(2, nDay)
            If (nValue And nBinValue) = nBinValue Then
                oDay = DirectCast(IIf((nDay + 1) = 7, 0, nDay + 1), DayOfWeek)
                bFound = True
                Exit For
            End If
        Next

        If Not bFound Then
            'find earliest day in selection
            For nDay = 0 To 6
                nBinValue = Math.Pow(2, nDay)
                If (nValue And nBinValue) = nBinValue Then
                    oDay = DirectCast(IIf((nDay + 1) = 7, 0, nDay + 1), DayOfWeek)
                    Exit For
                End If
            Next
        End If

        Return oDay
    End Function

    Public Function MySQLDateFormatNullable(ByVal dValue As Date?, Optional ByVal bWithTime As Boolean = True, Optional ByVal bWithQuotes As Boolean = True) As String
        Dim cRetVal As String = "null"
        Try
            If dValue.HasValue Then
                If IsDate(dValue) Then
                    cRetVal = IIf(bWithQuotes, "'", "") & Format(dValue, "yyyy-MM-dd" & IIf(bWithTime, " HH:mm:ss", "")) & IIf(bWithQuotes, "'", "")
                    'when there is ONLY TIME information VB.NET returns YEAR 0001, BUT MySQL only accepts YEARS starting 1000
                    cRetVal = cRetVal.Replace("0001-", "1000-")
                End If
            Else
                cRetVal = "null"
            End If
        Catch ex As Exception
            cRetVal = "null"
        End Try
        Return cRetVal
    End Function

    Public Function MySQLDateFormat(ByVal dValue As Date, Optional ByVal bWithTime As Boolean = True) As String
        Dim cRetVal As String = ""
        Try
            If IsDate(dValue) Then
                cRetVal = Format(dValue, "yyyy-MM-dd" & IIf(bWithTime, " HH:mm:ss", ""))
            End If
        Catch ex As Exception
            cRetVal = ""
        End Try
        Return cRetVal
    End Function

    Public Function MySQLDateValueNullable(ByVal dValue As Date?)
        If (Not dValue.HasValue) OrElse IsNull(dValue) OrElse IsNothing(dValue) Then
            Return DBNull.Value
        Else
            Return dValue
        End If
    End Function

    Public Function NumToDate(ByVal cNumber As String, Optional ByVal bWithTime As Boolean = False) As Date
        Dim dRetDate As Date
        Try
            If bWithTime Then
                dRetDate = New Date(Left(cNumber, 4), Mid(cNumber, 5, 2), Mid(cNumber, 7, 2), Mid(cNumber, 9, 2), Mid(cNumber, 11, 2), Mid(cNumber, 13, 2))
            Else
                dRetDate = DateSerial(Left(cNumber, 4), Mid(cNumber, 5, 2), Right(cNumber, 2))
            End If

        Catch ex As Exception
            dRetDate = Nothing
        End Try
        Return dRetDate
    End Function


    'RSA: 20100120 (converted from MPS3 function of same name)
    'RETURNS:
    '(1) RETURN VALUE: Date difference in months (w/ decimals)
    '(2) BYREF VARIABLES: Date difference in separate units: <nYears>, <nMonths>, <nDays>
    '
    '<nYears> - number of years in between <dStartDate> and <dEndDate>
    '<nMonths>- number of months in between <dStartDate> and <dEndDate> (excluding years already counted)
    '<nDays>  - number of days in between <dStartDate> and <dEndDate>   (excluding months/years already counted)
    '<nLastMonthNumDays> - total number of days in the month where <nDays> falls.
    '                      this info may be useful in calculating the number of days
    '                      remaining before <nDays> turns to a full month.
    'SEE ALSO: usrDateDiff
    '
    Public Function usrDateDiffSpecial(ByVal dStartDate As Date, ByVal dEndDate As Date, ByRef nRetYears As Integer, ByRef nRetMonths As Integer, ByRef nRetDays As Integer, ByRef nRetLastMonthNumDays As Integer) As Double
        On Error Resume Next
        Dim nMonths As Integer, dTemp As Date, nDays As Integer, nDaysPerMonth As Integer
        Dim nYears As Integer
        Dim nPLen As Double

        nYears = DateDiff(DateInterval.Month, dStartDate, dEndDate)
        nYears = nYears \ 12
        dTemp = DateAdd(DateInterval.Year, nYears, dStartDate)

        nMonths = DateDiff(DateInterval.Month, dTemp, dEndDate)
        dTemp = DateAdd(DateInterval.Month, nMonths, dTemp)
        nDays = -1

        Do While nDays < 0
            nDays = DateDiff(DateInterval.Day, dTemp, dEndDate)
            If nDays < 0 Then
                nMonths = nMonths - 1
                If nMonths < 0 Then
                    nMonths = 11
                    nYears = nYears - 1
                End If
                dTemp = DateAdd(DateInterval.Month, -1, dTemp)
            End If
        Loop

        nDaysPerMonth = DateDiff(DateInterval.Day, dTemp, DateAdd(DateInterval.Month, 1, dTemp))

        'get period length
        nPLen = nYears * 12 + nMonths + (nDays / nDaysPerMonth)
        'set return values
        nRetYears = nYears
        nRetMonths = nMonths
        nRetDays = nDays
        nRetLastMonthNumDays = nDaysPerMonth
        Return nPLen
    End Function
#End Region

#Region "ItemDelimited"

    'RETURNS: <nItemNo> value item in <cPairedList> being delimited by <cPairSet>
    '   example:
    '                             "[]"  <--- <cPairSet>
    '       "[item1][item2]...[itemN]"   <--- <cPairedList>
    '
    '
    '       ** setting <nItemNo> parameter to 2 will make the function return the text "item2"
    '
    Public Function usrGetPairedValue(ByVal cPairedList As String, ByVal cPairSet As String, ByVal nItemNo As Integer) As String
        Dim cDelimiter As String, nItemCnt As Integer
        Dim cRetVal As String

        If Len(cPairSet) <> 2 Then
            'Msgbox("<cPairSet> parameter must be 2 characters in length. This will denote the starting and ending delimiter for each item in <cPairedList> parameter.", vbCritical, "usrGetPairedValue()")
            Return ""
            Exit Function
        End If

        cDelimiter = Right$(cPairSet, 1) & Left$(cPairSet, 1) 'reverse pair set
        nItemCnt = CountItemDelimited(cPairedList, cDelimiter)
        cRetVal = GetItemDelimited(cPairedList, nItemNo, cDelimiter)

        If nItemNo = 1 Then
            cRetVal = Mid$(cRetVal, 2, IIf(nItemCnt = 1, Len(cRetVal) - 2, Len(cRetVal) - 1))
        ElseIf nItemNo = nItemCnt Then
            If Len(cRetVal) > 0 Then
                cRetVal = Left$(cRetVal, Len(cRetVal) - 1)
            Else
                cRetVal = ""
            End If
        End If

        usrGetPairedValue = cRetVal

    End Function
    'RETURNS: item index of cSearchStr in cItemList
    '
    'NOTES:
    'Search is CASE-SENSITIVE
    '
    Public Function SearchItemDelimited(ByVal cItemList, ByVal cDelimitedBy, ByVal cSearchStr)
        Dim nPos As Integer

        cItemList = cDelimitedBy & cItemList & cDelimitedBy
        nPos = InStr(cItemList, cDelimitedBy & cSearchStr & cDelimitedBy)
        If nPos > 1 Then
            nPos = nPos - 1
        End If
        SearchItemDelimited = IndexItemDelimited(cItemList, cDelimitedBy, nPos) 'get index number

    End Function

    Public Function CountItemDelimited(ByVal cItemList, ByVal cDelimitedBy)
        Dim nCount As Integer
        nCount = CountStr(cItemList, cDelimitedBy)
        If nCount > 0 Then
            nCount = nCount + 1
        ElseIf Len(cItemList) > 0 Then
            nCount = 1
        End If
        CountItemDelimited = nCount
    End Function


    Public Function DeleteItemDelimited(ByVal cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer, bAppended As Integer
        Dim cNewItemList As String

        DeleteItemDelimited = cItemList

        If nItemNo > 0 Then

            bAppended = False

            If CountStr(cItemList, cDelimitedBy) < nItemNo Then
                cItemList = cItemList & cDelimitedBy
                bAppended = True
            End If
            nStart = 1
            nCount = 0
            nPlace = InStr(nStart, cItemList, cDelimitedBy)
            Do While nPlace
                nCount = nCount + 1
                If nCount = nItemNo Then
                    cNewItemList = Mid$(cItemList, 1, nStart - 1) & Mid$(cItemList, nPlace + Len(cDelimitedBy))
                    If bAppended And Len(cNewItemList) > 0 Then
                        cNewItemList = Left$(cNewItemList, Len(cNewItemList) - Len(cDelimitedBy))
                    End If
                    DeleteItemDelimited = cNewItemList
                    Exit Do
                Else
                    nStart = nPlace + Len(cDelimitedBy)
                    nPlace = InStr(nStart, cItemList, cDelimitedBy)
                End If
            Loop

        End If

    End Function

    Public Function GetItemDelimited(ByVal cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer
        Dim bAppended

        GetItemDelimited = ""

        If CountStr(cItemList, cDelimitedBy) < nItemNo Then
            cItemList = cItemList & cDelimitedBy
            bAppended = True
        End If
        nStart = 1
        nCount = 0
        nPlace = InStr(nStart, cItemList, cDelimitedBy)
        Do While nPlace
            nCount = nCount + 1
            If nCount = nItemNo Then
                GetItemDelimited = Mid$(cItemList, nStart, (nPlace) - nStart)
                Exit Do
            Else
                nStart = nPlace + Len(cDelimitedBy)
                nPlace = InStr(nStart, cItemList, cDelimitedBy)
            End If
        Loop

    End Function

    'FUNCTION: Returns the Index of the item occupied by
    'a certain character position
    '
    '
    Public Function IndexItemDelimited(ByVal cItemList, ByVal cDelimitedBy, ByVal nCharPos)
        Dim nTotItems As Integer, nEndCount As Integer
        If nCharPos <= Len(cItemList) And Len(cItemList) <> 0 And nCharPos <> 0 Then
            nTotItems = CountItemDelimited(cItemList, cDelimitedBy)
            cItemList = Mid$(cItemList, nCharPos)
            nEndCount = CountItemDelimited(cItemList, cDelimitedBy)
            IndexItemDelimited = nTotItems - nEndCount + 1
        Else
            IndexItemDelimited = 0
        End If
    End Function


    Public Function SaveItemDelimited(ByRef cItemList As String, ByVal nItemNo As Integer, ByVal cDelimitedBy As String, ByVal cSaveStr As String)
        Dim nPlace As Integer, nCount As Integer, nStart As Integer
        Dim cNewItemList As String
        Dim bFound As Boolean = False, nCtr As Integer

        SaveItemDelimited = False

        If CountItemDelimited(cItemList, cDelimitedBy) = 1 And nItemNo = 1 Then
            cItemList = cSaveStr
        Else
            If CountStr(cItemList, cDelimitedBy) < nItemNo Then
                For nCtr = 1 To (nItemNo - CountItemDelimited(cItemList, cDelimitedBy))
                    cItemList = cItemList & cDelimitedBy & "?"
                Next
            End If
            nStart = 1
            nCount = 0
            nPlace = InStr(nStart, cItemList, cDelimitedBy)

            Do While nPlace
                nCount = nCount + 1
                If nCount = nItemNo Then
                    'first position to (last position - 1)
                    cNewItemList = Mid$(cItemList, 1, nStart - 1) & cSaveStr & Mid$(cItemList, nPlace)
                    SaveItemDelimited = True
                    cItemList = cNewItemList
                    bFound = True
                    Exit Do
                Else
                    nStart = nPlace + Len(cDelimitedBy)
                    nPlace = InStr(nStart, cItemList, cDelimitedBy)
                    If nPlace = 0 And nCount = (nItemNo - 1) Then
                        'last position
                        cNewItemList = Mid$(cItemList, 1, nStart - 1) & cSaveStr
                        SaveItemDelimited = True
                        cItemList = cNewItemList
                        bFound = True
                        Exit Do
                    End If
                End If
            Loop
        End If

    End Function
    'FUNCTION: Counts the occurence of cCountWhat in cCount string
    '
    '
    Public Function CountStr(ByVal cCount, ByVal cCountWhat) As Integer
        Dim nCount As Integer, nnCtr As Integer
        If Not IsNull(cCount) And Not IsNull(cCountWhat) Then
            cCount = UCase(cCount)
            cCountWhat = UCase(cCountWhat)
            nCount = 0
            For nnCtr = 1 To Len(cCount)
                If Len(cCount) - nnCtr + 1 >= Len(cCountWhat) Then
                    If Mid$(cCount, nnCtr, Len(cCountWhat)) = cCountWhat Then
                        nCount = nCount + 1
                    End If
                End If
            Next
        End If
        CountStr = nCount
    End Function

    Private Function IsNull(ByVal xItem) As Boolean
        If xItem Is Nothing Then
            Return True
        Else
            Return False
        End If
    End Function




#End Region

#Region "Cryptography and Compression"
    Public Class Compression
        '****************************************************************
        ' Name: LZW (Lempel, Ziv, Welch) Dictionary Compression
        ' Description:The Lempel, Ziv, Welch compression algorithm i
        '     s considered the most efficcient all purpose compression alg
        '     orithm there is.
        ' By: Asgeir Bjarni Ingvarsson
        '
        ' Inputs:None
        ' Returns:None
        ' Assumes:None
        ' Side Effects:None
        '
        'Code provided by Planet Source Code(tm) 'as is', without
        '     warranties as to performance, fitness, merchantability,
        '     and any other warranty (whether expressed or implied).
        '****************************************************************

        '     ' -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        '     '| LZW - Compression/Uncompression|
        '     '|-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-|
        '     '|Author: Asgeir B. Ingvarsson |
        '     '| |
        '     '|E-Mail: abi@islandia.is |
        '     '| |
        '     '|Address: Hringbraut 119 |
        '     '| IS-107, Reykjavik|
        '     '| ICELAND |
        '     '|-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-|
        '     '|For any comments or questions, please contact me |
        '     '|using either of the above measures. |
        '     '|-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-|
        '     '|This code has one flaw, it can't process characters |
        '     '|higher than 127. |
        '     '|For the code that can compress all 256 ascii chars. |
        '     '|please e-mail me.|
        '     '|If you use this code or modify it, I would appreciate|
        '     '|it if you would mention my name somewhere and send me|
        '     '|a copy of the code (if it has been modified).|
        '     '|-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-|
        '     '|LZW is property of Unisys and is free for|
        '     '|noncommercial software. |
        '     ' -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        Private Dict(255) As String
        Private Count As Integer

        Private Sub Init()
            Dim i As Integer

            For i = 0 To 127
                Dict(i) = Chr(i)
            Next

        End Sub


        Private Function Search(ByVal inp As String) As Integer
            Dim i As Integer

            For i = 0 To 255

                If Dict(i) = inp Then Search = i : Exit Function
            Next

            Search = 256
        End Function


        Private Sub Add(ByVal inp As String)
            If Count = 256 Then Wipe()
            Dict(Count) = inp
            Count = Count + 1
        End Sub


        Private Sub Wipe()
            Dim i As Integer
            For i = 128 To 255
                Dict(i) = ""
            Next

            Count = 128
        End Sub


        Public Function Deflate(ByVal inp As String) As String
            Dim i, p, c, temp, o As Integer
            '     'Begin Error Checking

            o = ""
            If Len(inp) = 0 Then
                Deflate = ""
                Exit Function
            End If


            For i = 1 To Len(inp)

                If Asc(Mid(inp, i, 1)) > 127 Then
                    MsgBox("Illegal Character Value", vbCritical, "Error:")
                    Deflate = ""
                    Exit Function
                End If

            Next

            '     'End Error Checking
            Init()
            Wipe()
            p = ""
            i = 1

            Do Until i > Len(inp)
                c = Mid(inp, i, 1)
                i = i + 1
                temp = p & c

                If Not Search(CStr(temp)) = 256 Then
                    p = temp
                Else
                    o = o & Chr(Search(CStr(p)))
                    Add(CStr(temp))
                    p = c
                End If

            Loop

            o = o & Chr(Search(CStr(p)))
            Deflate = o
        End Function


        Public Function Inflate(ByVal inp As String) As String
            Dim cW, i, pW, c, o, p As Integer

            If Len(inp) = 0 Then
                Inflate = ""
                Exit Function
            End If

            Init()
            Wipe()
            cW = Asc(Mid(inp, 1, 1))
            o = Dict(cW)
            i = 2

            Do Until i > Len(inp)
                pW = cW
                cW = Asc(Mid(inp, i, 1))
                i = i + 1

                If Not Dict(cW) = "" Then
                    o = o & Dict(cW)
                    p = Dict(pW)
                    c = Mid(Dict(cW), 1, 1)
                    Add(CStr(p) & CStr(c))
                ElseIf Dict(cW) = "" Then
                    p = Dict(pW)
                    c = Mid(Dict(pW), 1, 1)
                    o = o & p & c
                    Add(CStr(p) & CStr(c))
                End If

            Loop

            Inflate = o
        End Function
    End Class

    Public Class Cryptography

        Public Class DESCryptography
            ' Function to generate a 64-bit key.
            Public Function GenerateKey() As String
                ' Create an instance of a symmetric algorithm. The key and the IV are generated automatically.
                Dim desCrypto As DESCryptoServiceProvider = DESCryptoServiceProvider.Create()

                ' Use the automatically generated key for encryption. 
                Return ASCIIEncoding.ASCII.GetString(desCrypto.Key)

            End Function
        End Class


        Public Class HashFunctions
            Public Function GetEncryptedData(ByVal Data As String) As String
                Dim shaM As New SHA1Managed
                Convert.ToBase64String(shaM.ComputeHash(Encoding.ASCII.GetBytes(Data)))
                Dim eNC_data() As Byte = ASCIIEncoding.ASCII.GetBytes(Data)
                Dim eNC_str As String = Convert.ToBase64String(eNC_data)
                GetEncryptedData = eNC_str
            End Function

            Public Function GetDecryptedData(ByVal Data As String) As String
                Dim dEC_data() As Byte = Convert.FromBase64String(Data)
                Dim dEC_Str As String = ASCIIEncoding.ASCII.GetString(dEC_data)
                GetDecryptedData = dEC_Str
            End Function
        End Class

        Public Class RailFenceCryptography
            'FUNCTION: "ENCRYPT"  or "DECRYPT" documents using modified railfence code
            '
            '
            Public Function usrCryptography2(ByVal cMode As String, ByVal cDocument As String) As String
                On Error Resume Next
                Dim comp As New Compression
                Dim nCtr As Integer, cCheckSum As String, cOrigString As String
                Dim nCutPos As Integer, cTopSum As String, cBottomSum As String, cTempSum As String

                cDocument = Trim$(cDocument)

                Select Case UCase(cMode)

                    Case "ENCRYPT"

                        cDocument = Format$(Int((Rnd(Timer) * 255) + 1), "000") & cDocument & Format$(Int((Rnd(Timer) * 255) + 1), "000")
                        cTopSum = ""
                        cBottomSum = ""
                        cCheckSum = ""

                        'get ascii value
                        For nCtr = 1 To Len(cDocument)
                            cCheckSum = cCheckSum & Format$(Asc(Mid$(cDocument, nCtr, 1)), "000")
                        Next

                        'do railfence encryption
                        For nCtr = 1 To Len(cCheckSum)
                            If (nCtr Mod 2) = 1 Then
                                'odd positions on top
                                cTopSum = cTopSum & Mid$(cCheckSum, nCtr, 1)
                            Else
                                'even positions on bottom
                                cBottomSum = cBottomSum & Mid$(cCheckSum, nCtr, 1)
                            End If
                        Next

                        usrCryptography2 = comp.Deflate(cTopSum & cBottomSum) 'compress string

                    Case "DECRYPT"

                        cCheckSum = comp.Inflate(cDocument) 'expand string
                        nCutPos = IIf((Len(cCheckSum) Mod 2) = 1, Fix(Len(cCheckSum) / 2) + 1, Len(cCheckSum) / 2)
                        cTopSum = Mid$(cCheckSum, 1, nCutPos)
                        cBottomSum = Mid$(cCheckSum, nCutPos + 1)
                        cTempSum = ""
                        cOrigString = ""

                        'do railfence decryption
                        For nCtr = 1 To nCutPos
                            cTempSum = cTempSum & Mid$(cTopSum, nCtr, 1) & IIf((Len(cCheckSum) Mod 2) = 0 Or nCtr < nCutPos, Mid$(cBottomSum, nCtr, 1), "")
                        Next

                        'convert to ascii
                        For nCtr = 1 To Len(cTempSum) Step 3
                            cOrigString = cOrigString & Chr(Val(Mid(cTempSum, nCtr, 3)))
                        Next

                        usrCryptography2 = Mid$(cOrigString, 4, Len(cOrigString) - 6)

                    Case Else

                        usrCryptography2 = ""

                End Select

            End Function

            'RETURNS: <cDocument> text encrypted using the railfence coding method
            'SEE ALSO: usrCryptography()
            'ex: when <nInterval>=1, "SPECTRAL" will become...
            '
            '[1]              [2]
            '   S E T A    ==>    SETAPCRL   <=== RETURNED STRING
            '    P C R L
            '
            Function usrRailFence(ByVal cMode As String, ByVal nInterval As Integer, ByVal cDocument As String) As String
                Dim nCtr As Integer, cTopSum As String, cBottomSum As String
                Dim cTempSum, nCutPos As String

                cBottomSum = ""
                cTempSum = ""
                cTopSum = ""

                Select Case UCase(cMode)
                    Case "ENCRYPT"
                        'do railfence encryption
                        nCtr = 1
                        Do
                            If (nCtr Mod 2) = 1 Then
                                'odd positions on top
                                cTopSum = cTopSum & Mid$(cDocument, ((nCtr - 1) * nInterval) + 1, nInterval)
                            Else
                                cBottomSum = cBottomSum & Mid$(cDocument, ((nCtr - 1) * nInterval) + 1, nInterval)
                            End If

                            If (nCtr * nInterval) > Len(cDocument) Then
                                Exit Do
                            End If

                            nCtr = nCtr + 1

                        Loop

                        usrRailFence = cTopSum & cBottomSum

                    Case "DECRYPT"

                        cTopSum = ""
                        cBottomSum = ""

                        'split top & bottom sums
                        Do While Len(cDocument) > 0
                            cTopSum = cTopSum & Left$(cDocument, nInterval)
                            cDocument = Mid$(cDocument, nInterval + 1)
                            If Len(cDocument) > 0 Then
                                cBottomSum = Right$(cDocument, IIf(Len(cDocument) >= nInterval, nInterval, Len(cDocument))) & cBottomSum
                                cDocument = Mid$(cDocument, 1, Len(cDocument) - IIf(Len(cDocument) >= nInterval, nInterval, Len(cDocument)))
                            End If
                        Loop

                        nCutPos = Len(cTopSum)

                        'do railfence decryption
                        For nCtr = 1 To nCutPos Step nInterval
                            cTempSum = cTempSum & Mid$(cTopSum, nCtr, nInterval) & IIf((Len(cDocument) Mod (nInterval + 1)) = 0 Or nCtr < nCutPos, Mid$(cBottomSum, nCtr, nInterval), "")
                        Next

                        usrRailFence = cTempSum

                    Case Else

                        usrRailFence = ""

                End Select

            End Function


            Function usrCryptography(ByVal cMode As String, ByVal cDocument As String) As String
                On Error Resume Next
                Dim nCtr As Integer, cCheckSum As String, cOrigString As String
                Dim nCutPos As Integer, cTopSum As String, cBottomSum As String, cTempSum As String

                Select Case UCase(cMode)
                    Case "ENCRYPT"
                        cTopSum = ""
                        cBottomSum = ""
                        cCheckSum = ""

                        'get ascii value
                        For nCtr = 1 To Len(cDocument)
                            cCheckSum = cCheckSum & Format$(Asc(Mid$(cDocument, nCtr, 1)), "000")
                        Next

                        'do railfence encryption
                        usrCryptography = usrRailFence("ENCRYPT", 1, cCheckSum)

                        '            For nCtr = 1 To Len(cCheckSum)
                        '                If (nCtr Mod 2) = 1 Then
                        '                    'odd positions on top
                        '                    cTopSum = cTopSum & Mid$(cCheckSum, nCtr, 1)
                        '                Else
                        '                    'even positions on bottom
                        '                    cBottomSum = cBottomSum & Mid$(cCheckSum, nCtr, 1)
                        '                End If
                        '            Next
                        '            usrCryptography = cTopSum & cBottomSum

                    Case "DECRYPT"
                        '            cCheckSum = cDocument
                        '            nCutPos = IIf((Len(cCheckSum) Mod 2) = 1, Fix(Len(cCheckSum) / 2) + 1, Len(cCheckSum) / 2)
                        '            cTopSum = Mid$(cCheckSum, 1, nCutPos)
                        '            cBottomSum = Mid$(cCheckSum, nCutPos + 1)
                        '            cTempSum = ""
                        cOrigString = ""

                        'do railfence decryption
                        cTempSum = usrRailFence("DECRYPT", 1, cDocument)

                        '            For nCtr = 1 To nCutPos
                        '                cTempSum = cTempSum & Mid$(cTopSum, nCtr, 1) & IIf((Len(cCheckSum) Mod 2) = 0 Or nCtr < nCutPos, Mid$(cBottomSum, nCtr, 1), "")
                        '            Next

                        'convert to ascii
                        For nCtr = 1 To Len(cTempSum) Step 3
                            cOrigString = cOrigString & Chr(Val(Mid$(cTempSum, nCtr, 3)))
                        Next

                        usrCryptography = cOrigString

                    Case Else

                        usrCryptography = ""

                End Select
            End Function

        End Class

        Public Class EnigmaCryptography
            Private LCW As Integer                 'Length of CodeWord
            Private LS2E As Integer                 'Length of String to be Encrypted
            Private LAM As Integer                 'Length of Array Matrix
            Private MP As Integer                    'Matrix Position
            Private Matrix As String                  'Starting Matrix
            Private mov1 As String                    'First Part of Replacement String
            Private mov2 As String                    'Second Part of Replacement String
            Private CodeWord As String            'CodeWord
            Private CWL As String                    'CodeWord Letter
            Private EncryptedString As String     'String to Return for Encrypt or String to UnEncrypt for UnEncrypt
            Private EncryptedLetter As String     'Storage Variable for Character just Encrypted
            Private strCryptMatrix(97) As String 'Matrix Array

            Public WriteOnly Property KeyString() As String
                Set(ByVal Value As String)
                    CodeWord = Value
                End Set
            End Property

            Public Function Decrypt(ByVal mstext As String) As String
                Return Encrypt(mstext)
            End Function

            Public Function Encrypt(ByVal mstext As String) As String
                Dim X As Integer                    ' Loop Counter
                Dim Y As Integer                    'Loop Counter
                Dim Z As Integer                     'Loop Counter
                Dim C2E As String                   'Character to Encrypt
                Dim Str2Encrypt As String        'Text from TextBox

                Str2Encrypt = mstext
                LS2E = Len(mstext)
                LCW = Len(CodeWord)
                EncryptedLetter = ""
                EncryptedString = ""

                Y = 1
                For X = 1 To LS2E
                    C2E = Mid(Str2Encrypt, X, 1)
                    MP = InStr(1, Matrix, C2E, 0)
                    CWL = Mid(CodeWord, Y, 1)
                    For Z = 1 To LAM
                        If Mid(strCryptMatrix(Z), MP, 1) = CWL Then
                            EncryptedLetter = Left(strCryptMatrix(Z), 1)
                            EncryptedString = EncryptedString + EncryptedLetter
                            Exit For
                        End If
                    Next Z
                    Y = Y + 1
                    If Y > LCW Then Y = 1
                Next X
                Encrypt = EncryptedString

            End Function

            Sub New()

                Dim W As Integer 'Loop Counter to set up Matrix
                Dim X As Integer     'Loop through Matrix

                Matrix = "8x3p5BeabcdfghijklmnoqrstuvwyzACDEFGHIJKLMNOPQRSTUVWXYZ 1246790-.#/\!@$<>&*()[]{}';:,?=+~`^|%_"
                Matrix = Matrix + Chr(13)  'Add Carriage Return to Matrix
                Matrix = Matrix + Chr(10)  'Add Line Feed to Matrix
                Matrix = Matrix + Chr(34)  'Add "
                ' Unique String used to make Matrix - 8x3p5Be
                ' Unique String can be any combination that has a character only ONCE.
                ' EACH Letter in the Matrix is Input ONLY once.
                W = 1
                LAM = Len(Matrix)
                strCryptMatrix(1) = Matrix

                For X = 2 To LAM ' LAM = Length of Array Matrix
                    mov1 = Left(strCryptMatrix(W), 1)   'First Character of strCryptMatrix
                    mov2 = Right(strCryptMatrix(W), (LAM - 1))   'All but First Character of strCryptMatrix
                    strCryptMatrix(X) = mov2 + mov1  'Makes up each row of the Array
                    W = W + 1
                Next X
            End Sub

        End Class

    End Class


    Public Class EnigmaCryptography
        Private LCW As Integer                 'Length of CodeWord
        Private LS2E As Integer                 'Length of String to be Encrypted
        Private LAM As Integer                 'Length of Array Matrix
        Private MP As Integer                    'Matrix Position
        Private Matrix As String                  'Starting Matrix
        Private mov1 As String                    'First Part of Replacement String
        Private mov2 As String                    'Second Part of Replacement String
        Private CodeWord As String            'CodeWord
        Private CWL As String                    'CodeWord Letter
        Private EncryptedString As String     'String to Return for Encrypt or String to UnEncrypt for UnEncrypt
        Private EncryptedLetter As String     'Storage Variable for Character just Encrypted
        Private strCryptMatrix(97) As String 'Matrix Array

        Public WriteOnly Property KeyString() As String
            Set(ByVal Value As String)
                CodeWord = Value
            End Set
        End Property

        Public Function Decrypt(ByVal mstext As String) As String
            Return Encrypt(mstext)
        End Function

        Public Function Encrypt(ByVal mstext As String) As String
            Dim X As Integer                    ' Loop Counter
            Dim Y As Integer                    'Loop Counter
            Dim Z As Integer                     'Loop Counter
            Dim C2E As String                   'Character to Encrypt
            Dim Str2Encrypt As String        'Text from TextBox

            Str2Encrypt = mstext
            LS2E = Len(mstext)
            LCW = Len(CodeWord)
            EncryptedLetter = ""
            EncryptedString = ""

            Y = 1
            For X = 1 To LS2E
                C2E = Mid(Str2Encrypt, X, 1)
                MP = InStr(1, Matrix, C2E, 0)
                CWL = Mid(CodeWord, Y, 1)
                For Z = 1 To LAM
                    If Mid(strCryptMatrix(Z), MP, 1) = CWL Then
                        EncryptedLetter = Left(strCryptMatrix(Z), 1)
                        EncryptedString = EncryptedString + EncryptedLetter
                        Exit For
                    End If
                Next Z
                Y = Y + 1
                If Y > LCW Then Y = 1
            Next X
            Encrypt = EncryptedString

        End Function

        Sub New()

            Dim W As Integer 'Loop Counter to set up Matrix
            Dim X As Integer     'Loop through Matrix

            Matrix = "8x3p5BeabcdfghijklmnoqrstuvwyzACDEFGHIJKLMNOPQRSTUVWXYZ 1246790-.#/\!@$<>&*()[]{}';:,?=+~`^|%_"
            Matrix = Matrix + Chr(13)  'Add Carriage Return to Matrix
            Matrix = Matrix + Chr(10)  'Add Line Feed to Matrix
            Matrix = Matrix + Chr(34)  'Add "
            ' Unique String used to make Matrix - 8x3p5Be
            ' Unique String can be any combination that has a character only ONCE.
            ' EACH Letter in the Matrix is Input ONLY once.
            W = 1
            LAM = Len(Matrix)
            strCryptMatrix(1) = Matrix

            For X = 2 To LAM ' LAM = Length of Array Matrix
                mov1 = Left(strCryptMatrix(W), 1)   'First Character of strCryptMatrix
                mov2 = Right(strCryptMatrix(W), (LAM - 1))   'All but First Character of strCryptMatrix
                strCryptMatrix(X) = mov2 + mov1  'Makes up each row of the Array
                W = W + 1
            Next X
        End Sub

    End Class
#End Region

#Region "Logs"
    Public Sub LogImage(ByVal xfromTable As String, ByVal xfileName As String, ByVal xIDNbr As String)
        Dim xpath As String = CleanPath(My.Application.Info.DirectoryPath) & "imagelogs"
        Try
            WriteLog(xfromTable & vbTab & xIDNbr & vbTab & xfileName, xpath)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub WriteLog(ByVal strLog As String, Optional ByVal path As String = "C:\Spectral\FTPFILES\logs")

        Dim strLogF As String = ""
        strLogF = Date.Today.ToString("MMMM-dd-yyyy")
        If Not Directory.Exists(path) Then
            Directory.CreateDirectory(path)
        End If
        Dim FILE_NAME As String = path & "\log_" & strLogF & ".txt"

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)


        objWriter.WriteLine(DateTime.Now.ToString & ":      " & strLog)

        objWriter.Close()
    End Sub
#End Region

#Region "Misc datasources"
    Public Function GetAuth() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {"STISQLSERVER", "STI SQL Server Authentication"}
        ctable.Rows.Add(crow)
        crow(0) = "SQLSERVER_AUTH"
        crow(1) = "SQL Server Authentication"
        ctable.Rows.Add(crow)
        crow(0) = "WIN_AUTH"
        crow(1) = "Windows Authentication"
        ctable.Rows.Add(crow)
        Return ctable
    End Function

    Public Function GetAuthDesc(ByVal cAuthCode As String) As String
        If cAuthCode = "STISQLSERVER" Then
            GetAuthDesc = "STI SQL Server Authentication"
        ElseIf cAuthCode = "SQLSERVER_AUTH" Then
            GetAuthDesc = "SQL Server Authentication"
        ElseIf cAuthCode = "WIN_AUTH" Then
            GetAuthDesc = "Windows Authentication"
        Else
            GetAuthDesc = "Cannot Identify"
        End If
    End Function

    Public Function GetLicenseTroubleShooterActions() As DataTable
        Dim ctable As New DataTable, ccolumn As DataColumn
        ccolumn = New DataColumn
        ccolumn.ColumnName = "PKey"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        ccolumn = New DataColumn
        ccolumn.ColumnName = "Name"
        ccolumn.DataType = System.Type.GetType("System.String")
        ctable.Columns.Add(ccolumn)
        Dim crow() As Object = {"GEN_LIC_INFO", "Generate License Information"}
        ctable.Rows.Add(crow)
        crow(0) = "REP_LIC"
        crow(1) = "Repair my License"
        ctable.Rows.Add(crow)
        crow(0) = "GEN_LIC_REP"
        crow(1) = "Generate License Report"
        ctable.Rows.Add(crow)
        Return ctable
    End Function
#End Region

End Module
