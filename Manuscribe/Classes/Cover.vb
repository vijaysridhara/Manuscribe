Imports System.IO

Friend Class Cover
    Private _type As ImageType
    Private _img As Image
    Private _fmt As String
    Public Property Format As String
        Get
            Return _fmt
        End Get
        Set(value As String)
            _fmt = value
        End Set
    End Property

    Public Property Type As ImageType
        Get
            Return _type
        End Get
        Set(value As ImageType)
            _type = value
        End Set
    End Property
    Public Property Image As Image
        Get
            Return _img
        End Get
        Set(value As Image)
            _img = value
        End Set
    End Property
    Public Function GetXML()
        If _img Is Nothing Then Return ""
        Dim finString As String = "<cover type=""" & Type & """ format=""" & Format & """>" & vbCrLf
        Dim memStream As New MemoryStream
        _img.Save(memStream, ImageFormatfromString(Format))
        Dim imBytes() As Byte = memStream.ToArray
        memStream.Close()
        memStream.Dispose()
        finString += Convert.ToBase64String(imBytes) + vbCrLf & "</cover>"
        Return finString
    End Function
End Class
