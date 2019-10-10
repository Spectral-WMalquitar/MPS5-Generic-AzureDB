Public Module MPSFunctions

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

End Module