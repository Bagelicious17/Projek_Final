Imports System.Reflection

Module langkah
    Public posisiMerah() As Point = {New Point(408, 103), New Point(349, 103), New Point(349, 42), New Point(408, 42)}
    Public posisiBiru() As Point = {New Point(408, 367), New Point(349, 367), New Point(349, 310), New Point(408, 310)}
    Public posisiKuning() As Point = {New Point(616, 310), New Point(675, 310), New Point(675, 367), New Point(616, 367)}
    Public posisiHijau() As Point = {New Point(616, 103), New Point(675, 103), New Point(675, 46), New Point(616, 46)}



    Public Jalan() As Point = {New Point(333, 181), New Point(364, 181), New Point(393, 181), New Point(423, 181), New Point(452, 181),
                                New Point(482, 151), New Point(482, 122), New Point(482, 93), New Point(482, 64), New Point(482, 35), New Point(482, 2),
                                New Point(512, 2), New Point(541, 2),
                                New Point(542, 32), New Point(542, 61), New Point(542, 90), New Point(542, 119), New Point(542, 148),
                                New Point(571, 180), New Point(600, 180), New Point(629, 180), New Point(658, 180), New Point(687, 180), New Point(716, 180),
                                New Point(718, 210), New Point(718, 240),
                                New Point(690, 240), New Point(660, 240), New Point(630, 240), New Point(600, 240), New Point(570, 240),
                                New Point(541, 268), New Point(541, 298), New Point(541, 328), New Point(541, 358), New Point(541, 388), New Point(541, 418),
                                New Point(511, 418), New Point(481, 418),
                                New Point(481, 388), New Point(481, 358), New Point(481, 328), New Point(481, 298), New Point(481, 268),
                                New Point(451, 238), New Point(421, 238), New Point(391, 238), New Point(361, 238), New Point(331, 238), New Point(301, 238),
                                New Point(301, 208), New Point(301, 178)}
    Public Langkah_Menang() As Point = {New Point(511, 420), New Point(511, 390), New Point(511, 360), New Point(511, 330), New Point(511, 300), New Point(511, 270), New Point(511, 240),
                                        New Point(305, 211), New Point(335, 211), New Point(365, 211), New Point(395, 211), New Point(415, 211), New Point(445, 211), New Point(475, 211),
                                        New Point(512, 2), New Point(512, 32), New Point(512, 62), New Point(512, 92), New Point(512, 112), New Point(512, 142), New Point(512, 172),
                                        New Point(720, 210), New Point(690, 210), New Point(660, 210), New Point(630, 210), New Point(600, 210), New Point(570, 210), New Point(540, 210)}

    Public langkahMerah() As Point = getLangkah(Jalan, 0)
    Public langkahHijau() As Point = getLangkah(Jalan, 13)
    Public langkahKuning() As Point = getLangkah(Jalan, 26)
    Public langkahBiru() As Point = getLangkah(Jalan, 39)

    Public LangkahMenangBiru() As Point = getLangkahMenang(Langkah_Menang, 0)
    Public LangkahMenangMerah() As Point = getLangkahMenang(Langkah_Menang, 7)
    Public LangkahMenangHijau() As Point = getLangkahMenang(Langkah_Menang, 14)
    Public LangkahMenangKuning() As Point = getLangkahMenang(Langkah_Menang, 21)

    Function getLangkah(ByVal pnt As Point(), ByVal posisi As Integer) As Point()
        Const L = 51
        Dim value() As Point = Nothing
        Dim j As Integer = 0
        For i As Integer = posisi To L
            ReDim Preserve value(j)
            value(j) = pnt(i)
            j += 1
        Next

        If posisi < 2 Then posisi = 2
        For i As Integer = 0 To posisi - 2
            ReDim Preserve value(j)
            value(j) = pnt(i)
            j += 1
        Next

        Return value
    End Function

    Function getLangkahMenang(ByVal pnt As Point(), ByVal posisi As Integer) As Point()
        Const L = 27
        Dim value() As Point = Nothing
        Dim j As Integer = 0
        For i As Integer = posisi To L
            ReDim Preserve value(j)
            value(j) = pnt(i)
            j += 1
        Next

        If posisi < 2 Then posisi = 2
        For i As Integer = 0 To posisi - 2
            ReDim Preserve value(j)
            value(j) = pnt(i)
            j += 1
        Next

        Return value
    End Function
End Module
