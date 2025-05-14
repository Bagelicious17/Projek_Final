Public Class _Pion
    Private _gambar As Image
    Private _pion As PictureBox
    Private _lokasi As New Point
    Private _nomorPion As Integer = 0
    Private _aktif As Integer = 0
    Private _posisi As Integer = 0
    Private _jalan As Point()
    Private _status As Integer = 0

    Enum enumStatus
        kurung = 0
        keluar = 1
        dalam = 2
    End Enum

    Property Status() As enumStatus
        Get
            Return _status
        End Get
        Set(ByVal value As enumStatus)
            _status = value
        End Set
    End Property

    Public Sub Keluar()
        _pion.Location = _jalan(0)
        Status = enumStatus.keluar
    End Sub

    Public Sub Masuk()
        _pion.Location = _lokasi
        Status = enumStatus.kurung
    End Sub

    Property Langkah() As Point()
        Get
            Return _jalan
        End Get
        Set(ByVal value As Point())
            _jalan = value
        End Set
    End Property

    Sub Jalankan(ByVal langkah As Integer)
        For i As Integer = 1 To langkah
            If (_posisi + i) >= _jalan.Length Then Exit For
            _pion.Location = _jalan(_posisi + i)
            Application.DoEvents()
            Threading.Thread.Sleep(300)
        Next
        _posisi = Math.Min(_posisi + langkah, _jalan.Length - 1)
        _lokasi = _jalan(_posisi)
        If _posisi >= _jalan.Length - 1 Then
            Status = enumStatus.dalam ' Reached home
        End If
    End Sub

    Property Pion() As PictureBox
        Get
            Return _pion
        End Get
        Set(ByVal value As PictureBox)
            _pion = value
        End Set
    End Property

    Property NomorPion() As Integer
        Get
            Return _nomorPion
        End Get
        Set(ByVal value As Integer)
            _nomorPion = value
        End Set
    End Property

    Property Image() As Image
        Get
            Return _gambar
        End Get
        Set(ByVal value As Image)
            _gambar = value
            _pion.Image = value
        End Set
    End Property

    Property Lokasi() As Point
        Get
            Return _lokasi
        End Get
        Set(ByVal value As Point)
            _lokasi = value
            _aturLokasi()
        End Set
    End Property

    Property Posisi() As Integer
        Get
            Return _posisi
        End Get
        Set(ByVal value As Integer)
            _posisi = value
        End Set
    End Property

    Private Sub _aturLokasi()
        _pion.Location = _lokasi
    End Sub

End Class