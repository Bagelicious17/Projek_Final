Imports Projek_Final.setting
Imports Projek_Final.langkah
Imports System.IO

Public Class FormUtama
    Dim dadu As New Random
    Dim a As Integer = 1
    Dim c As Integer = 3
    Dim m As Integer = 6
    Dim ludo As New Ludo
    Dim collisionTimer As New Timer()
    Dim collisionPieces As New Dictionary(Of Point, List(Of Tuple(Of Integer, Integer)))() ' Stores pieces at each position
    Dim saveFilePath As String = "ludo_save.txt"

    Sub acakDadu()
        Dim x As Integer = dadu.Next(1, 7) ' Start with a random number between 1 and 6
        For i As Integer = 0 To 10 ' Increase number of shakes
            Application.DoEvents()
            x = dadu.Next(1, 7) ' Generate new random number
            pbDadu.Image = imglistDadu.Images(x - 1) ' Subtract 1 since array is 0-based
            System.Threading.Thread.Sleep(50) ' Increase delay for better visibility
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
                warna = "HIjau"
            Case 3
                warna = "Kuning"
        End Select
        Return warna
    End Function
    Private Sub btnAcak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcak.Click
        If GiliranMulaiAtauTidak = enumGiliranMulaiAtauSelesai.Selesai Then
            acakDadu()
            If StatusPemain(GiliranPermain) = enumStatus.awal Then
                If HasilDadu <> 6 Then
                    GiliranSelesai()
                    GiliranNext()
                    txtInformasi.Text = "Acak Dadu Lagi" & vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
                Else
                    GiliranMulai()
                    txtInformasi.Text = "Pilih Dadu Ingin Dikeluarkan" & vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
                End If
            Else
                GiliranMulai()
                txtInformasi.Text = "Giliran Pemain " & giliran(GiliranPermain)
            End If
        End If
    End Sub

    Private Sub FormUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        collisionTimer.Interval = 1000
        AddHandler collisionTimer.Tick, AddressOf CheckCollisions
        collisionTimer.Start()

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
        ' Test each player's winning path
        For playerIndex As Integer = 0 To 3
            ' Test all pieces for each player
            For pieceIndex As Integer = 0 To 3
                Dim pion = ludo.Pemain(playerIndex).Pion(pieceIndex)

                ' Reset piece to start of winning path
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

                ' Move piece to start of winning path and set status
                pion.Status = _Pion.enumStatus.keluar
                pion.Lokasi = pion.Langkah(0)
                pion.Pion.Location = pion.Langkah(0)
                pion.Posisi = 0

                ' Update player status to pernahKeluar
                StatusPemain(playerIndex) = enumStatus.pernahKeluar
            Next

            ' Show message with goal position
            Dim goalIndex As Integer = playerIndex * 6
            txtInformasi.Text = "Testing " & giliran(playerIndex) & " path. Goal at index " & goalIndex
            System.Threading.Thread.Sleep(1000)
        Next

        txtInformasi.Text = "Path testing complete! All pieces are on their winning paths."
    End Sub

    Private Sub CheckCollisions(sender As Object, e As EventArgs)
        collisionPieces.Clear()

        ' First, collect all pieces' positions
        For playerIndex As Integer = 0 To 3
            For pieceIndex As Integer = 0 To 3
                If ludo.Pemain(playerIndex).Pion(pieceIndex).Status = _Pion.enumStatus.keluar Then
                    Dim currentPos As Point = ludo.Pemain(playerIndex).Pion(pieceIndex).Lokasi

                    If Not collisionPieces.ContainsKey(currentPos) Then
                        collisionPieces.Add(currentPos, New List(Of Tuple(Of Integer, Integer)))
                    End If
                    collisionPieces(currentPos).Add(New Tuple(Of Integer, Integer)(playerIndex, pieceIndex))
                End If
            Next
        Next

        ' Check for collisions and handle them
        For Each pos In collisionPieces.Keys
            If collisionPieces(pos).Count > 1 Then
                ' Get the current player's piece at this position
                Dim currentPlayerPiece As Tuple(Of Integer, Integer) = Nothing
                Dim otherPieces As New List(Of Tuple(Of Integer, Integer))

                For Each piece In collisionPieces(pos)
                    If piece.Item1 = GiliranPermain Then
                        currentPlayerPiece = piece
                    Else
                        otherPieces.Add(piece)
                    End If
                Next

                ' If we found the current player's piece and there are other pieces
                If currentPlayerPiece IsNot Nothing AndAlso otherPieces.Count > 0 Then
                    ' Send all other pieces home and reset their player's state
                    For Each piece In otherPieces
                        Dim playerIndex = piece.Item1
                        Dim pieceIndex = piece.Item2

                        ' Send the piece home
                        ludo.Pemain(playerIndex).Pion(pieceIndex).Status = _Pion.enumStatus.kurung
                        ludo.Pemain(playerIndex).Pion(pieceIndex).Lokasi = ludo.PosisiPemain(playerIndex)(pieceIndex)
                        ludo.Pemain(playerIndex).Pion(pieceIndex).Pion.Location = ludo.PosisiPemain(playerIndex)(pieceIndex)

                        ' Only reset the status of this specific piece, not the player's overall status
                        ' This allows other pieces that were already out to continue moving
                        If StatusPemain(playerIndex) = enumStatus.pernahKeluar Then
                            ' Check if any other pieces are still out
                            Dim hasOtherPiecesOut As Boolean = False
                            For i As Integer = 0 To 3
                                If i <> pieceIndex AndAlso ludo.Pemain(playerIndex).Pion(i).Status = _Pion.enumStatus.keluar Then
                                    hasOtherPiecesOut = True
                                    Exit For
                                End If
                            Next
                            ' Only reset to awal if no other pieces are out
                            If Not hasOtherPiecesOut Then
                                StatusPemain(playerIndex) = enumStatus.awal
                            End If
                        End If
                    Next

                    ' Set next turn to the current player (they get another turn after capturing)
                    GiliranMulaiAtauTidak = enumGiliranMulaiAtauSelesai.Mulai
                    txtInformasi.Text = "Pemain " & giliran(GiliranPermain) & " dapat giliran lagi setelah menangkap!"
                End If
            End If
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

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


                        Dim currentStep As Integer = 0
                        For i As Integer = 0 To pion.Langkah.Length - 1
                            If pion.Lokasi = pion.Langkah(i) Then
                                currentStep = i
                                Exit For
                            End If
                        Next
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


                        If pion.Status = _Pion.enumStatus.keluar Then

                            For i As Integer = 0 To pion.Langkah.Length - 1
                                If pos = pion.Langkah(i) Then

                                    pion.Posisi = i
                                    Exit For
                                End If
                            Next
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

    Sub JalankanBidak(ByVal pct As PictureBox, ByVal noPemain As Integer, ByVal noBidak As Integer)
        If GiliranMulaiAtauTidak = enumGiliranMulaiAtauSelesai.Mulai Then
            If noPemain = GiliranPermain Then
                If ludo.Pemain(noPemain).Pion(noBidak).Status = _Pion.enumStatus.kurung Then
                    If HasilDadu = 6 Then
                        ludo.Pemain(noPemain).Pion(noBidak).Keluar()
                        StatusPemain(noPemain) = enumStatus.pernahKeluar
                        GiliranNext()
                        txtInformasi.Text = "Giliran Pemain " & giliran(GiliranPermain)
                        GiliranSelesai()
                    End If
                ElseIf ludo.Pemain(noPemain).Pion(noBidak).Status = _Pion.enumStatus.keluar Then
                    Dim pion = ludo.Pemain(noPemain).Pion(noBidak)
                    Dim currentStep = pion.Posisi
                    Dim totalSteps = pion.Langkah.Length

                    ' Check if piece is on winning path
                    Dim isOnWinningPath As Boolean = False
                    Select Case noPemain
                        Case 0
                            isOnWinningPath = (pion.Langkah Is LangkahMenangBiru)
                        Case 1
                            isOnWinningPath = (pion.Langkah Is LangkahMenangMerah)
                        Case 2
                            isOnWinningPath = (pion.Langkah Is LangkahMenangHijau)
                        Case 3
                            isOnWinningPath = (pion.Langkah Is LangkahMenangKuning)
                    End Select

                    If isOnWinningPath Then
                        ' On winning path - check remaining steps to goal
                        Dim goalIndex As Integer = noPemain * 6
                        Dim remainingSteps As Integer = goalIndex - currentStep

                        ' If dice number is greater than remaining steps, can't move
                        If HasilDadu > remainingSteps Then
                            txtInformasi.Text = "Dadu terlalu besar! Butuh " & remainingSteps & " untuk mencapai finish"
                            GiliranNext()
                            txtInformasi.Text &= vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
                            GiliranSelesai()
                            Return
                        End If

                        ' Move piece if steps are valid
                        pion.Jalankan(HasilDadu)

                        ' Check if reached goal
                        If pion.Posisi = goalIndex Then
                            pion.Status = _Pion.enumStatus.dalam
                            txtInformasi.Text = "Pemain " & giliran(noPemain) & " telah mencapai finish!"
                        End If
                    Else
                        ' On normal path - check if should switch to winning path
                        If currentStep + HasilDadu >= totalSteps Then
                            ' Calculate how many steps into winning path
                            Dim stepsIntoWinningPath = (currentStep + HasilDadu) - totalSteps

                            ' Switch to winning path
                            Select Case noPemain
                                Case 0
                                    pion.Langkah = LangkahMenangBiru
                                Case 1
                                    pion.Langkah = LangkahMenangMerah
                                Case 2
                                    pion.Langkah = LangkahMenangHijau
                                Case 3
                                    pion.Langkah = LangkahMenangKuning
                            End Select

                            ' Reset position to start of winning path
                            pion.Posisi = 0
                            pion.Lokasi = pion.Langkah(0)
                            pion.Pion.Location = pion.Langkah(0)

                            ' Move the calculated steps on winning path
                            If stepsIntoWinningPath > 0 Then
                                pion.Jalankan(stepsIntoWinningPath)
                            End If

                            ' Check if reached goal
                            Dim goalIndex As Integer = noPemain * 6
                            If pion.Posisi = goalIndex Then
                                pion.Status = _Pion.enumStatus.dalam
                                txtInformasi.Text = "Pemain " & giliran(noPemain) & " telah mencapai finish!"
                            End If
                        Else
                            ' Normal movement
                            pion.Jalankan(HasilDadu)
                        End If
                    End If

                    ' Check for collisions after movement
                    CheckCollisions(Nothing, Nothing)

                    ' Only advance turn if no collision occurred and it's still the same player's turn
                    If StatusPemain(GiliranPermain) <> enumStatus.awal AndAlso GiliranPermain = noPemain Then
                        GiliranNext()
                        txtInformasi.Text = "Giliran Pemain " & giliran(GiliranPermain)
                        GiliranSelesai()
                    End If
                ElseIf ludo.Pemain(noPemain).Pion(noBidak).Status = _Pion.enumStatus.dalam Then
                    MsgBox("Bidak Sudah Aman !")
                End If
            Else
                txtInformasi.Text = "Maaf Bukan Giliran Pemain Ini" & vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
            End If
        Else
            txtInformasi.Text = "Maaf Belum Mulai Giliran" & vbCrLf & "Giliran Pemain " & giliran(GiliranPermain)
        End If
    End Sub
End Class
