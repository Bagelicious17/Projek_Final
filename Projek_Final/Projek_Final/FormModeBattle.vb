Imports System.IO

Public Class FormModeBattle
    Dim dadu As New Random
    Dim a As Integer = 1
    Dim c As Integer = 3
    Dim m As Integer = 6
    Dim ludo As New Ludo
    Dim collisionPieces As New Dictionary(Of Point, List(Of Tuple(Of Integer, Integer)))()
    Dim saveFilePath As String = "ludo_save.txt"
    Private eliminatedPlayers As New List(Of Integer)
    Private finishedPlayers As New List(Of Integer)


    Sub acakDadu()
        Dim x As Integer = dadu.Next(1, 7)
        For i As Integer = 0 To 10
            Application.DoEvents()
            x = dadu.Next(1, 7)
            pbDadu.Image = imglistDadu.Images(x - 1)
            System.Threading.Thread.Sleep(50)
        Next
        HasilDadu = x
    End Sub

    Function giliran(ByVal i As Integer) As String
        Dim warna As String = ""
        Select Case i
            Case 0
                warna = "Biru"
            Case 1
                warna = "Merah"
            Case 2
                warna = "Hijau"
            Case 3
                warna = "Kuning"
        End Select
        Return warna
    End Function

    Private Sub btnAcak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcak.Click
        If IsGameOver() Then
            ShowFinalRankings()
            btnAcak.Enabled = False
            DisableAllPionButtons()
            Return
        End If

        If finishedPlayers.Contains(GiliranPermain) OrElse eliminatedPlayers.Contains(GiliranPermain) Then
            Dim nextPlayer As Integer = FindNextActivePlayer(GiliranPermain)
            If nextPlayer <> -1 Then
                GiliranPermain = nextPlayer
                txtInformasi.Text = "Pemain " & giliran(GiliranPermain) & " sudah selesai/tereliminasi. Giliran beralih ke Pemain " & giliran(nextPlayer)
                GiliranSelesai()
            Else
                ShowFinalRankings()
                btnAcak.Enabled = False
                DisableAllPionButtons()
            End If
            Return
        End If

        If GiliranMulaiAtauTidak = enumGiliranMulaiAtauSelesai.Selesai Then
            acakDadu()
            If StatusPemain(GiliranPermain) = enumStatus.awal Then
                If HasilDadu <> 6 Then
                    GiliranSelesai()
                    GiliranNext()
                    txtInformasi.Text = "Acak Dadu Lagi" & vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
                Else
                    GiliranMulai()
                    txtInformasi.Text = "Pilih Bidak Ingin Dikeluarkan" & vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
                End If
            Else
                GiliranMulai()

                Dim hasActivePawns As Boolean = False
                Dim hasPiecesInKurung As Boolean = False
                For i As Integer = 0 To 3
                    If ludo.Pemain(GiliranPermain).Pion(i).Status = _Pion.enumStatus.keluar Then
                        hasActivePawns = True
                    End If
                    If ludo.Pemain(GiliranPermain).Pion(i).Status = _Pion.enumStatus.kurung Then
                        hasPiecesInKurung = True
                    End If
                Next

                If hasActivePawns Then
                    txtInformasi.Text = "Giliran Pemain " & giliran(GiliranPermain) & ". Silakan pilih pion yang akan digerakkan."
                ElseIf hasPiecesInKurung AndAlso HasilDadu = 6 Then
                    txtInformasi.Text = "Giliran Pemain " & giliran(GiliranPermain) & ". Silakan keluarkan pion."
                Else
                    txtInformasi.Text = "Anda butuh angka 6 untuk mengeluarkan bidak. Giliran selesai."
                    GiliranSelesai()
                    GiliranNext()
                    txtInformasi.Text &= vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
                End If
            End If
        End If
    End Sub

    Private Sub FormModeBattle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        eliminatedPlayers.Clear()
        finishedPlayers.Clear()

        Dim posisi()() As Point = {posisiBiru, posisiMerah, posisiHijau, posisiKuning}
        Dim langkah()() As Point = {langkahBiru, langkahMerah, langkahHijau, langkahKuning}
        Dim pctBiru() As PictureBox = {Pion1, Pion2, Pion3, Pion4}
        Dim pctMerah() As PictureBox = {Pion5, Pion6, Pion7, Pion8}
        Dim pctHijau() As PictureBox = {Pion9, Pion10, Pion11, Pion12}
        Dim pctKuning() As PictureBox = {Pion13, Pion14, Pion15, Pion16}
        Dim allpion()() As PictureBox = {pctBiru, pctMerah, pctHijau, pctKuning}
        Dim gbr() As Image = {imgBidak.Images(0), imgBidak.Images(1), imgBidak.Images(2), imgBidak.Images(3)}

        ludo.NamaPemain = Pemain
        ludo.Picture = allpion
        ludo.PosisiPemain = posisi
        ludo.Gambar = gbr
        ludo.Langkah = langkah

        isiNamaPemain()

        txtInformasi.Text = "Giliran Pemain " & giliran(GiliranPermain)
        GiliranSelesai()
    End Sub

    Sub isiNamaPemain()
        ludo.NamaPemain = Pemain

        lblPemain1.Text = ludo.Pemain(0).Nama
        lblPemain2.Text = ludo.Pemain(1).Nama

        If JumlahPemain >= 3 Then
            lblPemain3.Text = ludo.Pemain(2).Nama
            lblPemain3.Visible = True
        Else
            lblPemain3.Visible = False
        End If

        If JumlahPemain = 4 Then
            lblPemain4.Text = ludo.Pemain(3).Nama
            lblPemain4.Visible = True
        Else
            lblPemain4.Visible = False
        End If
    End Sub

    Private Sub btnTestPath_Click(sender As Object, e As EventArgs) Handles btnTestPath.Click
        For playerIndex As Integer = 0 To 3
            For pieceIndex As Integer = 0 To 3
                Dim pion = ludo.Pemain(playerIndex).Pion(pieceIndex)

                Select Case playerIndex
                    Case 0
                        pion.Langkah = LangkahMenangBiru
                    Case 1
                        pion.Langkah = LangkahMenangMerah
                    Case 2
                        pion.Langkah = LangkahMenangHijau
                    Case 3
                        pion.Langkah = LangkahMenangKuning
                End Select

                pion.Status = _Pion.enumStatus.keluar
                pion.Lokasi = pion.Langkah(0)
                pion.Pion.Location = pion.Langkah(0)
                pion.Posisi = 0

                StatusPemain(playerIndex) = enumStatus.pernahKeluar
            Next
            Dim goalIndex As Integer = playerIndex * 6
            txtInformasi.Text = "Testing " & giliran(playerIndex) & " path. Goal at index " & goalIndex
            System.Threading.Thread.Sleep(1000)
        Next
        txtInformasi.Text = "Path testing complete! All pieces are on their winning paths."
    End Sub

    Private Sub Pion1_Click(sender As Object, e As EventArgs) Handles Pion1.Click
        JalankanBidak(Pion1, 0, 0)
    End Sub

    Private Sub Pion2_Click(sender As Object, e As EventArgs) Handles Pion2.Click
        JalankanBidak(Pion2, 0, 1)
    End Sub

    Private Sub Pion3_Click(sender As Object, e As EventArgs) Handles Pion3.Click
        JalankanBidak(Pion3, 0, 2)
    End Sub

    Private Sub Pion4_Click(sender As Object, e As EventArgs) Handles Pion4.Click
        JalankanBidak(Pion4, 0, 3)
    End Sub

    Private Sub Pion5_Click(sender As Object, e As EventArgs) Handles Pion5.Click
        JalankanBidak(Pion5, 1, 0)
    End Sub

    Private Sub Pion6_Click(sender As Object, e As EventArgs) Handles Pion6.Click
        JalankanBidak(Pion6, 1, 1)
    End Sub

    Private Sub Pion7_Click(sender As Object, e As EventArgs) Handles Pion7.Click
        JalankanBidak(Pion7, 1, 2)
    End Sub

    Private Sub Pion8_Click(sender As Object, e As EventArgs) Handles Pion8.Click
        JalankanBidak(Pion8, 1, 3)
    End Sub

    Private Sub Pion9_Click(sender As Object, e As EventArgs) Handles Pion9.Click
        JalankanBidak(Pion9, 2, 0)
    End Sub

    Private Sub Pion10_Click(sender As Object, e As EventArgs) Handles Pion10.Click
        JalankanBidak(Pion10, 2, 1)
    End Sub

    Private Sub Pion11_Click(sender As Object, e As EventArgs) Handles Pion11.Click
        JalankanBidak(Pion11, 2, 2)
    End Sub

    Private Sub Pion12_Click(sender As Object, e As EventArgs) Handles Pion12.Click
        JalankanBidak(Pion12, 2, 3)
    End Sub

    Private Sub Pion13_Click(sender As Object, e As EventArgs) Handles Pion13.Click
        JalankanBidak(Pion13, 3, 0)
    End Sub

    Private Sub Pion14_Click(sender As Object, e As EventArgs) Handles Pion14.Click
        JalankanBidak(Pion14, 3, 1)
    End Sub

    Private Sub Pion15_Click(sender As Object, e As EventArgs) Handles Pion15.Click
        JalankanBidak(Pion15, 3, 2)
    End Sub

    Private Sub Pion16_Click(sender As Object, e As EventArgs) Handles Pion16.Click
        JalankanBidak(Pion16, 3, 3)
    End Sub

    Private Sub btnCollisionTest_Click(sender As Object, e As EventArgs) Handles btnCollisionTest.Click
        If ludo.Pemain(0).Pion(0).Status = _Pion.enumStatus.kurung Then
            ludo.Pemain(0).Pion(0).Keluar()
        End If
        If ludo.Pemain(1).Pion(0).Status = _Pion.enumStatus.kurung Then
            ludo.Pemain(1).Pion(0).Keluar()
        End If

        Dim testPosition As Point = ludo.Pemain(0).Pion(0).Langkah(5)

        ludo.Pemain(0).Pion(0).Pion.Location = testPosition
        ludo.Pemain(0).Pion(0).Lokasi = testPosition
        ludo.Pemain(0).Pion(0).Status = _Pion.enumStatus.keluar

        Dim offsetPosition As New Point(testPosition.X + 0, testPosition.Y + 0)
        ludo.Pemain(1).Pion(0).Pion.Location = offsetPosition
        ludo.Pemain(1).Pion(0).Lokasi = offsetPosition
        ludo.Pemain(1).Pion(0).Status = _Pion.enumStatus.keluar

        StatusPemain(0) = enumStatus.pernahKeluar
        StatusPemain(1) = enumStatus.pernahKeluar

        txtInformasi.Text = "tes berhasil"
    End Sub

    Public Sub SaveGame()
        Try
            Using writer As New StreamWriter(saveFilePath)
                writer.WriteLine(JumlahPemain)

                For i As Integer = 0 To Pemain.Length - 1
                    writer.WriteLine(Pemain(i))
                Next

                writer.WriteLine(GiliranPermain)

                For i As Integer = 0 To 3
                    writer.WriteLine(StatusPemain(i))
                Next

                For playerIndex As Integer = 0 To 3
                    For pieceIndex As Integer = 0 To 3
                        Dim pion = ludo.Pemain(playerIndex).Pion(pieceIndex)
                        writer.WriteLine(pion.Status)
                        writer.WriteLine(pion.Lokasi.X & "," & pion.Lokasi.Y)

                        Dim currentStep As Integer = pion.Posisi
                        writer.WriteLine(currentStep)
                    Next
                Next
            End Using
            txtInformasi.Text = "Game Berhasil Disimpan!"
        Catch ex As Exception
            txtInformasi.Text = "Error saving game: " & ex.Message
        End Try
    End Sub

    Public Sub LoadGame()
        Try
            If Not File.Exists(saveFilePath) Then
                txtInformasi.Text = "No saved game found!"
                Return
            End If

            Using reader As New StreamReader(saveFilePath)
                JumlahPemain = Integer.Parse(reader.ReadLine())

                Dim playerNames As New List(Of String)
                For i As Integer = 0 To JumlahPemain - 1
                    playerNames.Add(reader.ReadLine())
                Next
                Pemain = playerNames.ToArray()

                GiliranPermain = Integer.Parse(reader.ReadLine())

                For i As Integer = 0 To 3
                    StatusPemain(i) = Integer.Parse(reader.ReadLine())
                Next

                For playerIndex As Integer = 0 To 3
                    For pieceIndex As Integer = 0 To 3
                        Dim pion = ludo.Pemain(playerIndex).Pion(pieceIndex)
                        pion.Status = Integer.Parse(reader.ReadLine())

                        Dim posStr = reader.ReadLine().Split(",")
                        Dim pos As New Point(Integer.Parse(posStr(0)), Integer.Parse(posStr(1)))

                        Dim savedStep = Integer.Parse(reader.ReadLine())

                        pion.Lokasi = pos
                        pion.Pion.Location = pos
                        pion.Posisi = savedStep

                        If pion.Status = _Pion.enumStatus.kurung Then
                            pion.Masuk()
                        ElseIf pion.Status = _Pion.enumStatus.keluar Then

                        ElseIf pion.Status = _Pion.enumStatus.dalam Then

                        End If
                    Next
                Next
            End Using

            isiNamaPemain()
            txtInformasi.Text = "Selamat Datang Kembali! Giliran: " & giliran(GiliranPermain)
        Catch ex As Exception
            txtInformasi.Text = "Error loading game: " & ex.Message
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveGame()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Application.Exit()
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Application.Exit()
    End Sub

    Private Sub HandlePieceMovement(noPemain As Integer, noBidak As Integer)
        Dim pion = ludo.Pemain(noPemain).Pion(noBidak)

        Dim currentStep = pion.Posisi
        Dim totalSteps = pion.Langkah.Length

        If currentStep + HasilDadu >= totalSteps Then
            Dim stepsOnRegularPath = totalSteps - 1 - currentStep

            For i As Integer = 1 To stepsOnRegularPath
                pion.Pion.Location = pion.Langkah(currentStep + i)
                pion.Lokasi = pion.Langkah(currentStep + i)
                pion.Posisi = currentStep + i
                Application.DoEvents()
                Threading.Thread.Sleep(300)
            Next




            txtInformasi.Text = "Bidak masuk ke jalur kemenangan!"
            Application.DoEvents()
            Threading.Thread.Sleep(300)


        Else
            For i As Integer = 1 To HasilDadu
                pion.Pion.Location = pion.Langkah(currentStep + i)
                pion.Lokasi = pion.Langkah(currentStep + i)
                pion.Posisi = currentStep + i
                Application.DoEvents()
                Threading.Thread.Sleep(300)
            Next

            CheckForCollisionAt(pion.Lokasi, noPemain, noBidak)

            GiliranNext()
            txtInformasi.Text = "Giliran Pemain " & giliran(GiliranPermain)
            GiliranSelesai()
        End If
    End Sub

    Private Sub CheckForCollisionAt(position As Point, attackerPlayerIndex As Integer, attackerPieceIndex As Integer)
        Dim pawnsAtPosition As New List(Of Tuple(Of Integer, Integer))()

        For playerIndex As Integer = 0 To JumlahPemain - 1
            If eliminatedPlayers.Contains(playerIndex) Then Continue For

            For pieceIndex As Integer = 0 To 3
                If playerIndex = attackerPlayerIndex AndAlso pieceIndex = attackerPieceIndex Then
                    Continue For
                End If

                Dim pion = ludo.Pemain(playerIndex).Pion(pieceIndex)
                If pion.Status = _Pion.enumStatus.keluar AndAlso pion.Lokasi = position Then
                    pawnsAtPosition.Add(New Tuple(Of Integer, Integer)(playerIndex, pieceIndex))
                End If
            Next
        Next

        If pawnsAtPosition.Count > 0 Then
            For Each defender In pawnsAtPosition
                Dim defenderPlayerIndex = defender.Item1
                Dim defenderPieceIndex = defender.Item2

                If defenderPlayerIndex = attackerPlayerIndex Then
                    Continue For
                End If

                Dim capturedPion = ludo.Pemain(defenderPlayerIndex).Pion(defenderPieceIndex)
                capturedPion.Status = _Pion.enumStatus.kurung
                capturedPion.Posisi = 0
                capturedPion.Lokasi = ludo.PosisiPemain(defenderPlayerIndex)(defenderPieceIndex)
                capturedPion.Pion.Location = ludo.PosisiPemain(defenderPlayerIndex)(defenderPieceIndex)
                capturedPion.Masuk()

                txtInformasi.Text = "Pemain " & giliran(attackerPlayerIndex) & " memakan pion " & giliran(defenderPlayerIndex) & "!" & vbCrLf
                txtInformasi.Text &= "Pion " & giliran(defenderPlayerIndex) & " kembali ke rumah!"
                Application.DoEvents()
                Threading.Thread.Sleep(500)

                Dim defenderHasActivePieces As Boolean = False
                For i As Integer = 0 To 3
                    If ludo.Pemain(defenderPlayerIndex).Pion(i).Status = _Pion.enumStatus.keluar Then
                        defenderHasActivePieces = True
                        Exit For
                    End If
                Next

                If Not defenderHasActivePieces AndAlso Not finishedPlayers.Contains(defenderPlayerIndex) Then
                    If Not eliminatedPlayers.Contains(defenderPlayerIndex) Then
                        eliminatedPlayers.Add(defenderPlayerIndex)
                        txtInformasi.Text &= vbCrLf & "Pemain " & giliran(defenderPlayerIndex) & " telah tereliminasi dari permainan!"
                        CheckGameEndConditions()
                    End If
                End If
            Next
        End If
    End Sub

    Private Function GetLastPlayerStanding() As Integer
        Dim activePlayers As New List(Of Integer)
        For i As Integer = 0 To JumlahPemain - 1
            If Not eliminatedPlayers.Contains(i) AndAlso Not finishedPlayers.Contains(i) Then
                activePlayers.Add(i)
            End If
        Next
        If activePlayers.Count = 1 Then
            Return activePlayers(0)
        Else
            Return -1
        End If
    End Function

    Private Sub HandleLastPlayerStanding(winnerIndex As Integer)
        If Not finishedPlayers.Contains(winnerIndex) Then
            finishedPlayers.Add(winnerIndex)
        End If
        CheckGameEndConditions()
    End Sub

    Private Function FindNextActivePlayer(currentPlayer As Integer) As Integer
        For i As Integer = 1 To JumlahPemain - 1
            Dim nextPlayer = (currentPlayer + i) Mod JumlahPemain

            If Not eliminatedPlayers.Contains(nextPlayer) AndAlso Not finishedPlayers.Contains(nextPlayer) Then
                Dim hasMovablePieces As Boolean = False
                For j As Integer = 0 To 3
                    If ludo.Pemain(nextPlayer).Pion(j).Status = _Pion.enumStatus.keluar OrElse
                       ludo.Pemain(nextPlayer).Pion(j).Status = _Pion.enumStatus.kurung Then
                        hasMovablePieces = True
                        Exit For
                    End If
                Next

                If hasMovablePieces Then
                    Return nextPlayer
                End If
            End If
        Next
        Return -1
    End Function

    Private Sub ShowFinalRankings()
        Dim finalText As String = "=== PERMAINAN SELESAI ===" & vbCrLf & vbCrLf
        finalText &= "Hasil Akhir:" & vbCrLf & vbCrLf

        For i As Integer = 0 To finishedPlayers.Count - 1
            finalText &= (i + 1) & ". " & Pemain(finishedPlayers(i)) & " (" & giliran(finishedPlayers(i)) & ") - Selesai" & vbCrLf
        Next

        If eliminatedPlayers.Count > 0 Then
            finalText &= vbCrLf & "Pemain Tereliminasi:" & vbCrLf
            For Each eliminatedPlayer As Integer In eliminatedPlayers
                finalText &= Pemain(eliminatedPlayer) & " (" & giliran(eliminatedPlayer) & ")" & vbCrLf
            Next
        End If

        txtInformasi.Text = finalText
    End Sub

    Sub JalankanBidak(ByVal pct As PictureBox, ByVal noPemain As Integer, ByVal noBidak As Integer)
        If noPemain <> GiliranPermain Then
            txtInformasi.Text = "Maaf Bukan Giliran Pemain Ini" & vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
            Return
        End If

        If GiliranMulaiAtauTidak <> enumGiliranMulaiAtauSelesai.Mulai Then
            txtInformasi.Text = "Maaf Belum Mulai Giliran" & vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
            Return
        End If

        Dim pion = ludo.Pemain(noPemain).Pion(noBidak)

        Select Case pion.Status
            Case _Pion.enumStatus.kurung
                Dim hasActivePawns As Boolean = False
                For i As Integer = 0 To 3
                    If ludo.Pemain(noPemain).Pion(i).Status = _Pion.enumStatus.keluar Then
                        hasActivePawns = True
                        Exit For
                    End If
                Next

                If HasilDadu = 6 Then
                    pion.Keluar()
                    StatusPemain(noPemain) = enumStatus.pernahKeluar
                    GiliranNext()
                    txtInformasi.Text = "Pion berhasil dikeluarkan! Giliran Pemain " & giliran(GiliranPermain)
                    GiliranSelesai()
                ElseIf hasActivePawns Then
                    txtInformasi.Text = "Anda sudah punya pion di luar. Silakan pilih pion yang sudah di luar atau gulir 6 untuk mengeluarkan pion ini."
                Else
                    txtInformasi.Text = "Anda butuh angka 6 untuk mengeluarkan bidak dari rumah!"
                    GiliranNext()
                    GiliranSelesai()
                End If

            Case _Pion.enumStatus.keluar
                HandlePieceMovement(noPemain, noBidak)

            Case _Pion.enumStatus.dalam
                txtInformasi.Text = "Bidak ini sudah di rumah. Pilih bidak lain atau tunggu giliran."
                Dim hasMovablePieces As Boolean = False
                For i As Integer = 0 To 3
                    If ludo.Pemain(noPemain).Pion(i).Status = _Pion.enumStatus.keluar Then
                        hasMovablePieces = True
                        Exit For
                    End If
                Next
                If Not hasMovablePieces AndAlso HasilDadu <> 6 Then
                    GiliranNext()
                    txtInformasi.Text = "Giliran Pemain " & giliran(GiliranPermain)
                    GiliranSelesai()
                End If
        End Select
        If IsGameOver() Then
            ShowFinalRankings()
            btnAcak.Enabled = False
            DisableAllPionButtons()
            Return
        End If
    End Sub



    Private Function ArraysMatch(array1 As Point(), array2 As Point()) As Boolean
        If array1 Is Nothing OrElse array2 Is Nothing Then Return False
        If array1.Length <> array2.Length Then Return False
        Return (array1(0).Equals(array2(0)) AndAlso array1(array1.Length - 1).Equals(array2(array2.Length - 1)))
    End Function

    Private Sub HandlePlayerFinishedAllPieces(ByVal playerIndex As Integer)
        If Not finishedPlayers.Contains(playerIndex) Then
            finishedPlayers.Add(playerIndex)
            txtInformasi.Text = "Pemain " & giliran(playerIndex) & " telah menyelesaikan semua bidak!" & vbCrLf
            CheckGameEndConditions()
        End If
    End Sub


    Private Sub CheckPlayerAllPiecesHome(playerIndex As Integer)
        Dim allPiecesHome As Boolean = True
        For i As Integer = 0 To 3
            If ludo.Pemain(playerIndex).Pion(i).Status <> _Pion.enumStatus.dalam Then
                allPiecesHome = False
                Exit For
            End If
        Next

        If allPiecesHome Then
            HandlePlayerFinishedAllPieces(playerIndex)
        Else
            GiliranNext()
            GiliranSelesai()
            txtInformasi.Text &= vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
        End If
    End Sub

    Private Sub CheckGameEndConditions()
        Dim activePlayersCount As Integer = 0
        For i As Integer = 0 To JumlahPemain - 1
            If Not eliminatedPlayers.Contains(i) AndAlso Not finishedPlayers.Contains(i) Then
                activePlayersCount += 1
            End If
        Next

        If activePlayersCount <= 1 Then
            Dim lastActivePlayer As Integer = GetLastPlayerStanding()
            If lastActivePlayer <> -1 Then
                If Not finishedPlayers.Contains(lastActivePlayer) AndAlso Not eliminatedPlayers.Contains(lastActivePlayer) Then
                    finishedPlayers.Add(lastActivePlayer)
                End If
            End If
            ShowFinalRankings()
            btnAcak.Enabled = False
            DisableAllPionButtons()
        Else
            GiliranNext()
            GiliranSelesai()
            txtInformasi.Text &= vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
        End If
    End Sub

    Private Function IsGameOver() As Boolean
        Dim remainingPlayablePlayers As Integer = 0
        For i As Integer = 0 To JumlahPemain - 1
            If Not eliminatedPlayers.Contains(i) AndAlso Not finishedPlayers.Contains(i) Then
                remainingPlayablePlayers += 1
            End If
        Next
        Return remainingPlayablePlayers <= 1
    End Function

    Private Sub DisableAllPionButtons()
        For Each pionBox In {Pion1, Pion2, Pion3, Pion4, Pion5, Pion6, Pion7, Pion8,
                                 Pion9, Pion10, Pion11, Pion12, Pion13, Pion14, Pion15, Pion16}
            pionBox.Enabled = False
        Next
    End Sub

End Class