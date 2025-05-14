Public Class _Pemain
    Private _status As Integer = 0
    Private _urutan As Integer = 0
    Private _nama As String = ""
    Private _jumlahSelesai As Integer = 0
    Private _pionSelesai() As Integer = Nothing
    Private _gambar As Image = Nothing
    Private _picture() As PictureBox = Nothing
    Private _Score As Integer = 0
    Private i As Integer = 0
    Public Pion(3) As _Pion
    Dim _posisi() As Point
    Dim _jalan() As Point

    Sub New()
        Pion(0) = New _Pion
        Pion(0).NomorPion = 0

        Pion(1) = New _Pion
        Pion(1).NomorPion = 1

        Pion(2) = New _Pion
        Pion(2).NomorPion = 2

        Pion(3) = New _Pion
        Pion(3).NomorPion = 3
    End Sub

    Property setJalan() As Point()
        Get
            Return _jalan
        End Get
        Set(ByVal value As Point())
            _jalan = value
            _setJalan()
        End Set
    End Property

    Private Sub _setJalan()
        For j = 0 To 3
            Pion(j).Langkah = _jalan
        Next
    End Sub

    Enum enumStatus
        TidakAktif = 0
        Aktif = 1
    End Enum

    Enum enumWarna
        Biru = 0
        Merah = 1
        Hijau = 2
        Kuning = 3
    End Enum

    Property Status() As enumStatus
        Get
            Return _status
        End Get
        Set(ByVal value As enumStatus)
            _status = value
        End Set
    End Property

    Property setLokasi() As Point()
        Get
            Return _posisi
        End Get
        Set(ByVal value As Point())
            _posisi = value
            _setLokasi(_posisi)
        End Set
    End Property

    Private Sub _setLokasi(ByVal lokation As Point())
        For j As Integer = 0 To 3
            Pion(j).Lokasi = _posisi(j)
        Next
    End Sub

    Property SetPion() As PictureBox()
        Get
            Return _picture
        End Get
        Set(ByVal value() As PictureBox)
            _picture = value
            setPionPicture()
        End Set
    End Property

    Private Sub setPionPicture()
        For j As Integer = 0 To 3
            Pion(j).Pion = _picture(j)
        Next
    End Sub

    ReadOnly Property PionSelesai(ByVal pion As Integer) As Integer()
        Get
            Return _pionSelesai
        End Get
    End Property

    Sub TambahPionSelesai(ByVal j As Integer)
        ReDim Preserve _pionSelesai(i)
        _pionSelesai(i) = j
        i += 1
    End Sub

    Property Nama() As String
        Get
            If _nama = "" Then
                Return "Tidak Main"
            Else
                Return _nama
            End If
        End Get
        Set(ByVal value As String)
            _nama = value
        End Set
    End Property

    ReadOnly Property JumlahSelesai() As Integer
        Get
            Return _jumlahSelesai
        End Get
    End Property

    Property Image() As Image
        Get
            Return _gambar
        End Get
        Set(ByVal value As Image)
            _gambar = value
            _setImage()
        End Set
    End Property

    Private Sub _setImage()
        For j As Integer = 0 To 3
            Pion(j).Image = _gambar
        Next
    End Sub

End Class