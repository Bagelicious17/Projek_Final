Public Class Ludo

    Private _status As Integer = 0
    Private _posisiPemain(3)() As Point
    Private _langkahPemain(3)() As Point
    Private _picturePemain(3)() As PictureBox
    Private _gambarPemain() As Image = Nothing
    Private _nama() As String = Nothing

    Public Pemain(3) As _Pemain

    Private _score As Integer = 0

    Property NamaPemain() As String()
        Get
            Return _nama
        End Get
        Set(ByVal value As String())
            _nama = value
            setNamaPemain()
        End Set
    End Property

    Private Sub setNamaPemain()
        For i As Integer = 0 To _nama.Length - 1
            Pemain(i).Nama = _nama(i)
        Next
    End Sub

    Property Langkah() As Point()()
        Get
            Return _langkahPemain
        End Get
        Set(ByVal value As Point()())
            _langkahPemain = value
            _langkah()
        End Set
    End Property

    Private Sub _langkah()
        For i As Integer = 0 To 3
            Pemain(i).setJalan = _langkahPemain(i)
        Next
    End Sub

    Property Picture() As PictureBox()()
        Get
            Return _picturePemain
        End Get
        Set(ByVal value As PictureBox()())
            _picturePemain = value
            _picture()
        End Set
    End Property

    Private Sub _picture()
        For i As Integer = 0 To 3
            Pemain(i).SetPion = _picturePemain(i)
        Next
    End Sub

    Property Gambar() As Image()
        Get
            Return _gambarPemain
        End Get
        Set(ByVal value As Image())
            _gambarPemain = value
            _gambar()
        End Set
    End Property

    Private Sub _gambar()
        For i = 0 To 3
            Pemain(i).Image = _gambarPemain(i)
        Next
    End Sub

    Sub New()
        Pemain(0) = New _Pemain

        Pemain(1) = New _Pemain

        Pemain(2) = New _Pemain

        Pemain(3) = New _Pemain
    End Sub

    Property PosisiPemain() As Point()()
        Get
            Return _posisiPemain
        End Get
        Set(ByVal value As Point()())
            _posisiPemain = value
            _posisi()
        End Set
    End Property

    Private Sub _posisi()
        For i As Integer = 0 To 3
            Pemain(i).setLokasi = _posisiPemain(i)
        Next
    End Sub

    Property Score() As Integer
        Get
            Return _score
        End Get
        Set(ByVal value As Integer)
            _score = value
        End Set
    End Property
End Class