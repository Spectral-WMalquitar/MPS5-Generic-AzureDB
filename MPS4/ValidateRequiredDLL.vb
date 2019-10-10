Imports System.IO
Imports System.Linq

Public Class ValidateRequiredDLL

    Private missingDLLs As String = ""

    Public Sub New()

    End Sub

    Public Sub HasAllRequiredDll()

        Dim status As Boolean = True
        Dim dlls As New ArrayList
        Dim separator As Char() = {"\\"}
        Dim currentDLLs As String() = Directory.GetFiles(Application.StartupPath, "*.dll")

        'File.WriteAllLines(Application.StartupPath + "\req_files.txt", AES_Encrypt(File.ReadAllLines(Application.StartupPath + "\req_files.txt").ToString(), "1").ToArray()) 'Sample encryption of required file.

        For counter As Integer = 0 To currentDLLs.Length - 1
            Dim contents() As String = currentDLLs(counter).Split(separator)
            dlls.Add(contents(contents.Length - 1))
        Next

        Try
            If (Not File.Exists(Application.StartupPath + "\req_files.settings")) Then Return

            Dim requiredFiles As String() = File.ReadAllLines(Application.StartupPath + "\req_files.settings") 'This is the official list of required dll files. 
            For counter As Integer = 0 To requiredFiles.Length - 1
                Dim i As Integer = counter
                Dim query = From dllName As String In dlls
                            Where dllName.Equals(requiredFiles(i))
                            Select dllName

                If (query.Count = 0) Then missingDLLs += requiredFiles(counter) + ","
            Next

            If (missingDLLs.Length <> 0) Then
                MessageBox.Show("An important file for the use of this program is missing. " + Environment.NewLine +
                                "Please consult your Administrator. " + Environment.NewLine & _
                                "Missing Files : [" + missingDLLs.Substring(0, missingDLLs.Length - 1) + "] ", "MPS5",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            missingDLLs = ""
            Return
        End Try
    End Sub

End Class
