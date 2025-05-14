Imports System.IO

Public Class FormAwal
    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        ' Get player names from textboxes
        Dim total As Integer = Val(cbJmlPemain.Text)
        Dim namaList As New List(Of String)

        If tbPemain1.Text = "" Or tbPemain2.Text = "" Or (total >= 3 And tbPemain3.Text = "") Or (total = 4 And tbPemain4.Text = "") Then
            MessageBox.Show("Maaf., Nama Harus Diisi!", "WARNING !!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        namaList.Add(tbPemain1.Text)
        namaList.Add(tbPemain2.Text)
        If total >= 3 Then namaList.Add(tbPemain4.Text)
        If total = 4 Then namaList.Add(tbPemain3.Text)

        ' Set the global variables
        Pemain = namaList.ToArray()
        JumlahPemain = total

        ' Show FormUtama
        Dim formUtama As New FormUtama()
        formUtama.Show()
        Me.Hide()
    End Sub

    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        Dim formUtama As New FormUtama()
        formUtama.Show()
        formUtama.LoadGame() ' Load the saved game
        Me.Hide()
    End Sub

    Private Sub FormAwal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isiJumlahPemain()
        gbPemain3.Visible = False
        gbPemain4.Visible = False
        cbJmlPemain.Text = "2"
        ' Check if there's a saved game
        If File.Exists("ludo_save.txt") Then
            btnResume.Enabled = True
        Else
            btnResume.Enabled = False
        End If
    End Sub

    Sub isiJumlahPemain()
        cbJmlPemain.Items.Clear()
        For i As Integer = 2 To 4
            cbJmlPemain.Items.Add(i)
        Next
    End Sub

    Private Sub cbJmlPemain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbJmlPemain.SelectedIndexChanged
        Select Case cbJmlPemain.Text
            Case "2"
                gbPemain3.Visible = False
                gbPemain4.Visible = False
            Case "3"
                gbPemain3.Visible = True
                gbPemain4.Visible = False
            Case "4"
                gbPemain3.Visible = True
                gbPemain4.Visible = True
        End Select
    End Sub


End Class