Module setting

    Public Pemain(3) As String


    Public _StatusPemain() As enumStatus = {
        enumStatus.awal,
        enumStatus.awal,
        enumStatus.awal,
        enumStatus.awal
    }

    Public _giliranPemain As Integer = 0
    Public _giliranAwalBidak As Integer = 0
    Public _hasilDadu As Integer = 1
    Public _jumlahPemain As Integer = 2
    Public _giliranMulai As Integer = 0

    Enum enumGiliranMulaiAtauSelesai
        Mulai = 0
        Selesai = 1
    End Enum

    Property GiliranMulaiAtauTidak() As enumGiliranMulaiAtauSelesai
        Get
            Return CType(_giliranMulai, enumGiliranMulaiAtauSelesai)
        End Get
        Set(ByVal value As enumGiliranMulaiAtauSelesai)
            _giliranMulai = CInt(value)
        End Set
    End Property

    Public Sub GiliranSelesai()
        _giliranMulai = enumGiliranMulaiAtauSelesai.Selesai
    End Sub

    Public Sub GiliranMulai()
        _giliranMulai = enumGiliranMulaiAtauSelesai.Mulai
    End Sub

    Public Enum enumStatus
        awal = 0
        pernahKeluar = 1
        selesai = 2
    End Enum

    Public Property JumlahPemain() As Integer
        Get
            Return _jumlahPemain
        End Get
        Set(ByVal value As Integer)
            If value > 0 AndAlso value <= 4 Then ' Validate 1-4 players
                _jumlahPemain = value
            End If
        End Set
    End Property

    Public Property HasilDadu() As Integer
        Get
            Return _hasilDadu
        End Get
        Set(ByVal value As Integer)
            If value >= 1 AndAlso value <= 6 Then ' Validate dice values
                _hasilDadu = value
            End If
        End Set
    End Property

    Sub GiliranNext()

        If _giliranPemain < 0 OrElse _giliranPemain >= _StatusPemain.Length Then
            _giliranPemain = 0
            Return
        End If

        Select Case _StatusPemain(_giliranPemain)
            Case enumStatus.awal
                _giliranAwalBidak += 1
                If _giliranAwalBidak > 0 Then
                    _giliranAwalBidak = 0
                    _giliranPemain += 1
                End If

            Case enumStatus.pernahKeluar
                If _hasilDadu <> 6 Then
                    _giliranPemain += 1
                End If

            Case enumStatus.selesai
                _giliranPemain += 1
        End Select


        If _giliranPemain >= _jumlahPemain Then
            _giliranPemain = 0
        End If
    End Sub

    Public Property GiliranPermain() As Integer
        Get
            Return _giliranPemain
        End Get
        Set(ByVal value As Integer)
            If value >= 0 AndAlso value < _jumlahPemain Then
                _giliranPemain = value
            End If
        End Set
    End Property

    Public Property StatusPemain() As enumStatus()
        Get
            Return _StatusPemain
        End Get
        Set(ByVal value() As enumStatus)
            If value IsNot Nothing AndAlso value.Length = 4 Then
                _StatusPemain = value
            End If
        End Set
    End Property
End Module