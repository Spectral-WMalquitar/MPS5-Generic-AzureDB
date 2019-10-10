Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text


Public Module mdEncryptDecrypt

    Dim path As String = "HKEY_CURRENT_USER\Software\Microsoft\sys32_sti"

    ' Call this function to remove the key from memory after it is used for security.
    <DllImport("kernel32.dll")> _
    Public Sub ZeroMemory(ByVal addr As IntPtr, ByVal size As Integer)
    End Sub

    ' Function to generate a 64-bit key.
    Function GenerateKey() As String
        ' Create an instance of a symmetric algorithm. The key and the IV are generated automatically.
        Dim desCrypto As DESCryptoServiceProvider = DESCryptoServiceProvider.Create()

        ' Use the automatically generated key for encryption. 
        Return ASCIIEncoding.ASCII.GetString(desCrypto.Key)

    End Function

    Sub EncryptFile(ByVal sInputFilename As String, _
                   ByVal sOutputFilename As String, _
                   ByVal sKey As String)

        Dim fsInput As New FileStream(sInputFilename, _
                                    FileMode.Open, FileAccess.Read)
        Dim fsEncrypted As New FileStream(sOutputFilename, _
                                    FileMode.Create, FileAccess.Write)

        Dim DES As New DESCryptoServiceProvider()

        'Set secret key for DES algorithm.
        'A 64-bit key and an IV are required for this provider.
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Set the initialization vector.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Create the DES encryptor from this instance.
        Dim desencrypt As ICryptoTransform = DES.CreateEncryptor()
        'Create the crypto stream that transforms the file stream by using DES encryption.
        Dim cryptostream As New CryptoStream(fsEncrypted, _
                                            desencrypt, _
                                            CryptoStreamMode.Write)

        'Read the file text to the byte array.
        Dim bytearrayinput(fsInput.Length - 1) As Byte
        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length)
        'Write out the DES encrypted file.
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Close()
    End Sub

    Sub DecryptFile(ByVal sInputFilename As String, _
        ByVal sOutputFilename As String, _
        ByVal sKey As String)

        Dim DES As New DESCryptoServiceProvider()
        'A 64-bit key and an IV are required for this provider.
        'Set the secret key for the DES algorithm.
        DES.Key() = ASCIIEncoding.ASCII.GetBytes(sKey)
        'Set the initialization vector.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Create the file stream to read the encrypted file back.
        Dim fsread As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)
        'Create the DES decryptor from the DES instance.
        Dim desdecrypt As ICryptoTransform = DES.CreateDecryptor()
        'Create the crypto stream set to read and to do a DES decryption transform on incoming bytes.
        Dim cryptostreamDecr As New CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read)
        'Print out the contents of the decrypted file.
        Dim fsDecrypted As New StreamWriter(sOutputFilename)
        fsDecrypted.Write(New StreamReader(cryptostreamDecr).ReadToEnd)
        fsDecrypted.Flush()
        fsDecrypted.Close()
    End Sub

    'Public Sub Main()
    '    'Must be 64 bits, 8 bytes.
    '    Dim sSecretKey As String

    '    ' Get the key for the file to encrypt.
    '    ' You can distribute this key to the user who will decrypt the file.
    '    sSecretKey = GenerateKey()

    '    ' For additional security, pin the key.
    '    Dim gch As GCHandle = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned)


    '    ' Encrypt the file.        
    '    EncryptFile("%USERPROFILE%\MyData.txt", _
    '                    "%USERPROFILE%\Encrypted.txt", _
    '                    sSecretKey)

    '    ' Decrypt the file.
    '    DecryptFile("%USERPROFILE%\Encrypted.txt", _
    '                "%USERPROFILE%\Decrypted.txt", _
    '                sSecretKey)

    '    ' Remove the key from memory. 
    '    ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2)
    '    gch.Free()
    'End Sub



    'text encrypt/decrypt
    Public Function EncodeText(ByVal text As String) As String
        Dim sb64 As String
        Try
            ' convert to byte array
            Dim bArry() As Byte = System.Text.Encoding.UTF8.GetBytes(text)
            ' convert bytes to Base64:
            sb64 = System.Convert.ToBase64String(bArry)
        Catch ex As Exception
            sb64 = ""
        End Try

        Return sb64
    End Function

    Public Function DecodeText(ByVal text As String) As String
        Dim sOut As String
        Try
            ' Base64 -> Byte Array
            Dim bOut() As Byte = System.Convert.FromBase64String(text)
            ' Byte Arry -> clear text
            sOut = System.Text.Encoding.UTF8.GetString(bOut)
        Catch ex As Exception
            sOut = ""
        End Try

        Return sOut
    End Function


    '================================= Registry Concern Functions==================================='

    'Write the data and the value
    Public Sub WriteReg(ByVal ckey As String, ByVal cVal As String, Optional ByVal useEncryption As Boolean = True)
        Try
            'If My.Computer.Registry.GetValue(path, ckey, Nothing) Then
            If useEncryption Then
                My.Computer.Registry.SetValue(path, ckey, AES_Encrypt(cVal, "LICENSING"))
            Else
                My.Computer.Registry.SetValue(path, ckey, cVal)
            End If

            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'get the Data from the Registry
    Public Function GetReg(ByVal ckey As String, Optional ByVal useEncryption As Boolean = True) As String
        'Dim path As String = "HKEY_CURRENT_USER\Software\MPS4"
        Dim data As String
        Dim decData As String
        data = My.Computer.Registry.GetValue(path, ckey, Nothing)
        If data <> "" Or data <> Nothing Then
            If useEncryption Then
                decData = AES_Decrypt(data, "LICENSING")
            Else
                decData = data
            End If
            Return decData
        Else
            decData = ""
        End If
        Return decData
    End Function

    'Delete Registry Current_User
    Public Function DeleteRegistry(ByVal cKey As String, ByVal cValue As String) As Boolean
        Dim retB As Boolean = False
        Try
            Dim key As Microsoft.Win32.RegistryKey
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(cKey, True)
            key.DeleteValue(cValue)
            retB = True
        Catch ex As Exception
            retB = False
        End Try

        Return retB
    End Function

    '================================= AES_Encryption\Decryption Concern Functions==================================='

    ''' <summary>
    ''' AES Encrypt a Password
    ''' </summary>
    ''' <param name="input">item To be Encrypted</param>
    ''' <param name="pass">Password to be Encrypt</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
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
            MsgBox(ex.Message)
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
    Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
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
            MsgBox(ex.Message)
        End Try
        Return decrypted
    End Function

    'Create Registry File
    Public Function CreateReg() As Boolean
        Dim bReturn As Boolean = False
        Dim regFile As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path)
        If regFile Is Nothing Then 'check if the regFile Exist
            Try
                My.Computer.Registry.CurrentUser.CreateSubKey(path)
                bReturn = True
            Catch ex As Exception
                bReturn = False
            End Try
        End If
        Return bReturn
    End Function

    '================================log file encryption=============================

    'A simple encryption functions that just shuffle the characters to prevents the increase of file size.
    Public ReadOnly EXPIMPCHARACTERS As String = "d3]c)Q-I|@%^&*_+=efghij0k:lno(p8qrs`tuv}w{[;'x2yzAB>C9.,<?DbEF!G6$H5J KL#MN/O7PaR""STUVWXYZ~1\m4"

    Public Function Shuffle(ByVal str As String, ByVal bExp As Boolean) As String
        Dim OrigString As String = EXPIMPCHARACTERS.Substring(0, 90), NewString As New System.Text.StringBuilder, nSlice As Integer, cnt As Integer
        Dim RetvalBuilder As New System.Text.StringBuilder, RetVal As String
        Dim any_int_val As Int16
        If bExp Then
            Randomize()
            any_int_val = CType(1 + Int(Rnd() * 9), Integer)
            nSlice = CType(2 + Int(Rnd() * 5), Integer)
            If nSlice = 4 Then nSlice = 9 '90 is not divisible by 4
            RetvalBuilder.Append(String.Format("{0}{1}", EXPIMPCHARACTERS.Substring(any_int_val, 1), EXPIMPCHARACTERS.Substring(nSlice, 1)))
            While OrigString.Length > 0
                NewString.Append(StrReverse(OrigString.Substring(0, nSlice)))
                OrigString = OrigString.Remove(0, nSlice)
            End While
            NewString.Append(EXPIMPCHARACTERS.Substring(90, 5))
            OrigString = EXPIMPCHARACTERS
            For cnt = 0 To str.Length - 1
                Dim nPos As Integer = -1
                nPos = OrigString.IndexOf(str.Substring(cnt, 1))
                If nPos >= 0 Then
                    RetvalBuilder.Append(NewString.Chars(nPos))
                Else
                    RetvalBuilder.Append(str.Substring(cnt, 1))
                End If
            Next
            RetvalBuilder.Append(10 - any_int_val)
            RetVal = StrReverse(RetvalBuilder.ToString)
        Else
            str = StrReverse(str)
            nSlice = CType(EXPIMPCHARACTERS.IndexOf(str.Substring(1, 1)), Integer)
            str = str.Substring(2, str.Length - 3)
            While OrigString.Length > 0
                NewString.Append(StrReverse(OrigString.Substring(0, nSlice)))
                OrigString = OrigString.Remove(0, nSlice)
            End While
            NewString.Append(EXPIMPCHARACTERS.Substring(90, 5))
            OrigString = EXPIMPCHARACTERS
            For cnt = 0 To str.Length - 1
                Dim nPos As Integer = -1
                nPos = NewString.ToString.IndexOf(str.Substring(cnt, 1))
                If nPos >= 0 Then
                    RetvalBuilder.Append(OrigString.Chars(nPos))
                Else
                    RetvalBuilder.Append(str.Substring(cnt, 1))
                End If
            Next
            RetVal = RetvalBuilder.ToString
        End If
        Return RetVal
    End Function


    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function ZipFile(ByVal cSourceFile As String, ByVal cDestFile As String) As Boolean
        Try
            Dim zip As New Chilkat.Zip()
            zip.UnlockComponent("SPCTASZIP_4gpKXqstjEuf")
            zip.NewZip(cDestFile)
            zip.AppendOneFileOrDir(cSourceFile, False)
            Return zip.WriteZipAndClose()
        Catch ex As Exception
            Return False
        End Try
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileDir(ByVal FullPath As String) As String
        Return System.IO.Path.GetDirectoryName(FullPath) & "\"
    End Function

    <System.Diagnostics.DebuggerStepThrough()> _
    Public Function GetFileNameWithoutExtension(ByVal FullPath As String) As String
        Return System.IO.Path.GetFileNameWithoutExtension(FullPath)
    End Function

End Module
