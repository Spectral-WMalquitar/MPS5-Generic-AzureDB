Imports System.Security.AccessControl

Module UserFunctions

#Region "Ini File"
    Private Declare Ansi Function WritePrivateProfileStringIni Lib "kernel32.dll" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Ansi Function GetPrivateProfileStringIni Lib "kernel32.dll" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As System.Text.StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    'geting Values or item/s in settings.ini file
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetSettingsIni(ByVal cKey As String) As String
        Dim retval As New System.Text.StringBuilder(100)
        GetPrivateProfileStringIni("APP", cKey, "", retval, 100, GetAppFolder() & "\setting.ini")
        Return retval.ToString
    End Function

    'write or modify the value of an item in settings.ini
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function WriteSettingsIni(ByVal ckey As String, ByVal cVal As String, ByRef cErr As String) As Boolean
        Dim bReturn As Boolean = False
        cErr = ""
        Try
            WritePrivateProfileStringIni("APP", ckey, cVal, GetAppFolder() & "\setting.ini")
            bReturn = True
        Catch ex As Exception
            cErr = ex.Message
            bReturn = False
        End Try
        Return bReturn
    End Function
#End Region

#Region "IfNull"
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As String) As String
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, String)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Integer) As Integer
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Integer)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Boolean) As Boolean
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Boolean)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Date) As Date
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Date)
        End If
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function IfNull(ByVal x As Object, ByVal retval As Double) As Double
        If x Is System.DBNull.Value Or x Is Nothing Then
            Return retval
        Else
            Return CType(x, Double)
        End If
    End Function
#End Region

#Region "Custom Functions"

    Public Function GetAppFolder() As String
        Return System.Windows.Forms.Application.StartupPath
    End Function

    Public Function CreateUpdateFolder(ByVal cpath As String) As Boolean
        Dim bSuccess As Boolean = False
        If System.IO.Directory.Exists(cpath) Then
            Try
                System.IO.Directory.Delete(cpath, True)
                System.IO.Directory.CreateDirectory(cpath)
                bSuccess = True
            Catch ex As Exception
                bSuccess = False
            End Try
        Else
            Try
                System.IO.Directory.CreateDirectory(cpath)
                bSuccess = True
            Catch ex As Exception
                bSuccess = False
            End Try
        End If
        Return bSuccess
    End Function

    Public Function IsPathExist(ByVal cPath As String, ByVal isDirectory As Boolean) As Boolean
        Dim bReturn As Boolean = False
        If isDirectory Then
            bReturn = System.IO.Directory.Exists(cPath)
        Else
            bReturn = System.IO.File.Exists(cPath)
        End If
        Return bReturn
    End Function

    Public Function HasFolderPermission(_filePath As String) As Boolean
        Dim retVal As Boolean = False
        Dim writeAllow = False
        Dim writeDeny = False
        Try
            Dim accessControlList = IO.Directory.GetAccessControl(_filePath)
            If accessControlList Is Nothing Then
                retVal = False
            End If
            Dim accessRules = accessControlList.GetAccessRules(True, True, GetType(System.Security.Principal.SecurityIdentifier))
            If accessRules Is Nothing Then
                retVal = False
            End If

            For Each rule As FileSystemAccessRule In accessRules
                If (FileSystemRights.Write And rule.FileSystemRights) <> FileSystemRights.Write Then
                    Continue For
                End If

                If rule.AccessControlType = AccessControlType.Allow Then
                    writeAllow = True
                ElseIf rule.AccessControlType = AccessControlType.Deny Then
                    writeDeny = True
                End If
            Next
            retVal = writeAllow AndAlso Not writeDeny

        Catch ex As Exception
            retVal = False
        End Try
        Return retVal
    End Function

    Public Function CleanPath(ByVal cDir As String, Optional ByVal cSeparator As String = "\") As String
        Return cDir & IIf(Microsoft.VisualBasic.Right(cDir, 1) = cSeparator, "", cSeparator)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileDirectory(ByVal FullPath As String) As String
        Return System.IO.Path.GetDirectoryName(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileWithoutExtension(ByVal FullPath As String) As String
        Return System.IO.Path.GetFileNameWithoutExtension(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileExtension(ByVal FullPath As String) As String
        Return System.IO.Path.GetExtension(FullPath)
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFile(ByVal FullPath As String) As String
        Return System.IO.Path.GetFileName(FullPath)
    End Function

#End Region

#Region "Misc Functions"
    Public Function GetFileNamesFromPath(ByVal cPathDir As String, Optional ByVal cDelemiter As String = ";", Optional ByVal Filter As String = "*.*", Optional ByVal searchOption As System.IO.SearchOption = IO.SearchOption.TopDirectoryOnly) As String
        Dim cReturnStr As String = ""
        Dim oFilesFiltered() As String = getFiles(cPathDir, Filter, searchOption)
        Dim f As String
        For Each f In oFilesFiltered
            cReturnStr = cReturnStr & System.IO.Path.GetFileName(f.ToString) & cDelemiter
        Next
        Return UCase(cReturnStr)
    End Function

    Public Function getFiles(ByVal SourceFolder As String, ByVal Filter As String, _
    ByVal searchOption As System.IO.SearchOption) As String()
        ' ArrayList will hold all file names
        Dim alFiles As Collections.ArrayList = New Collections.ArrayList()

        ' Create an array of filter string
        Dim MultipleFilters() As String = Filter.Split("|")

        ' for each filter find mathing file names
        For Each FileFilter As String In MultipleFilters
            ' add found file names to array list
            alFiles.AddRange(System.IO.Directory.GetFiles(SourceFolder, FileFilter, searchOption))
        Next

        ' returns string array of relevant file names
        Return alFiles.ToArray(Type.GetType("System.String"))
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

End Module
