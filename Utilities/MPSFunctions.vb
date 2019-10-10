Public Module MPSFunctions

#Region "Contants"
    Public Const ModuleCode As String = "MPS5"
    'Public Const LocationID As String 
#End Region

    <System.Diagnostics.DebuggerStepThrough()> _
    Function usrRailFence(ByVal cMode As String, ByVal nInterval As Integer, ByVal cDocument As String) As String
        Dim nCtr As Integer, cTopSum As String = "", cBottomSum As String = ""
        Dim cTempSum As String = "", nCutPos As Integer

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

                Return cTopSum & cBottomSum

            Case "DECRYPT"

                'split top & bottom sums
                Do While Len(cDocument) > 0
                    cTopSum = cTopSum & Left$(cDocument, nInterval)
                    cDocument = Mid(cDocument, nInterval + 1)
                    If Len(cDocument) > 0 Then
                        cBottomSum = Right$(cDocument, CType(IIf(Len(cDocument) >= nInterval, nInterval, Len(cDocument)), Integer)) & cBottomSum
                        cDocument = Mid$(cDocument, 1, CType(Len(cDocument) - CType(IIf(Len(cDocument) >= nInterval, nInterval, Len(cDocument)), Integer), Integer))
                    End If
                Loop

                nCutPos = Len(cTopSum)

                'do railfence decryption
                For nCtr = 1 To nCutPos Step nInterval
                    cTempSum = cTempSum & Mid$(cTopSum, nCtr, nInterval) & CType(IIf((Len(cDocument) Mod (nInterval + 1)) = 0 Or nCtr < nCutPos, Mid$(cBottomSum, nCtr, nInterval), ""), String)
                Next

                Return cTempSum
            Case Else
                Return ""
        End Select

    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
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
                Return usrRailFence("ENCRYPT", 1, cCheckSum)

            Case "DECRYPT"
                cOrigString = ""

                cTempSum = usrRailFence("DECRYPT", 1, cDocument)
                'convert to ascii
                For nCtr = 1 To Len(cTempSum) Step 3
                    cOrigString = cOrigString & Chr(CType(Mid$(cTempSum, nCtr, 3), Integer))
                Next

                Return cOrigString
            Case Else
                Return ""
        End Select

    End Function

    'for sysMPSUSER PASSWORD
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function sysMpsUserPassword(ByVal cMode As String, ByVal cPassword As String) As String
        Dim cRetVal As String, x() As String

        Select Case UCase(cMode)
            Case "ENCRYPT"
                Randomize()
                cPassword = Format(Rnd() * 999, "000") & "|" & cPassword & "|" & Format(Rnd() * 999, "000")
                cRetVal = usrRailFence("encrypt", 1, cPassword)
                Return usrCryptography("encrypt", cRetVal)
            Case "DECRYPT"
                cRetVal = usrCryptography("decrypt", cPassword)
                x = Split(usrRailFence("decrypt", 1, cRetVal), "|")
                Try
                    Return x(1)
                Catch ex As Exception
                    Return ""
                End Try
            Case Else
                Return ""
        End Select

    End Function

    'Encryption used in Security in USERS
    ''' <summary>
    ''' AES Encrypt a Password
    ''' </summary>
    ''' <param name="input">item To be Encrypted</param>
    ''' <param name="pass">Password to be Encrypt</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String, Optional ByRef ermsg As String = "") As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
            'MsgBox(ex.Message, , GetAppName)
            ermsg = ex.Message
        End Try
        Return encrypted
    End Function

    'Decryption used in Security in USERS
    ''' <summary>
    ''' AES Decrypt a password
    ''' </summary>
    ''' <param name="input"> item to be decrypted</param>
    ''' <param name="pass"> password used to decrypt</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String, Optional ByRef ermsg As String = "") As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(input)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            'MsgBox(ex.Message, , GetAppName)
            ermsg = ex.Message
        End Try
        Return decrypted
    End Function




End Module

