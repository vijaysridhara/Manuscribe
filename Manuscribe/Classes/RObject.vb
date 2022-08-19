'***********************************************************************
'Copyright 2020-2022 Vijay Sridhara

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at

'http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'***********************************************************************
Imports System.IO

Friend Class RObject
    Private _name As String
    Private _type As RObjectTypes
    Private _content As Object
    Private _category As String
    Private _thumb As Image
    Public Function getThumb() As Image
        Select Case _type
            Case RObjectTypes.bmp, RObjectTypes.gif, RObjectTypes.jpg, RObjectTypes.png, RObjectTypes.tiff
                If Not _thumb Is Nothing Then Return _thumb
                Dim st As New MemoryStream(CType(Content, Byte()))
                Dim img As Image = Bitmap.FromStream(st)
                _thumb = New Bitmap(128, 128)
                Dim g As Graphics = Graphics.FromImage(_thumb)
                g.DrawImage(img, New Rectangle(New Point(0, 0), New Size(128, 128)))
                img.Dispose()
 
            Case RObjectTypes.rtf
                Return My.Resources.robjectdocument
            Case RObjectTypes.txt, RObjectTypes.csv
                Return My.Resources.robjecttext
                Return Nothing
        End Select
    End Function
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value

        End Set
    End Property
    Public Property Type As RObjectTypes

        Get
            Return _type
        End Get
        Set(value As RObjectTypes)
            _type = value

        End Set
    End Property
    Public Property Content As Object
        Get
            Select Case _type
                Case RObjectTypes.txt, RObjectTypes.csv, RObjectTypes.rtf
                    Return xmlDecode(_content)
                Case Else
                    Return _content
            End Select

        End Get
        Set(value As Object)
            Select Case _type
                Case RObjectTypes.txt, RObjectTypes.csv, RObjectTypes.rtf
                    _content = xmlEncode(value)
                Case Else
                    _content = value
                    getThumb()
            End Select



        End Set
    End Property
    Public Property Category As String
        Get
            Return _category
        End Get
        Set(value As String)
            _category = value
        End Set
    End Property
    Public Function WritetoFile(sw As StreamWriter) As Boolean
        Try
            Dim finString As String = "<robject type=""" & Type & """ category=""" & Category & """ name=""" & Name & """>" & vbCrLf &
          "<content>#CONTENT#</content>" & vbCrLf &
          "</robject>" & vbCrLf
            Dim data As String = ""
            Select Case Type
                Case RObjectTypes.bmp, RObjectTypes.bmp, RObjectTypes.gif, RObjectTypes.jpg, RObjectTypes.tiff, RObjectTypes.png
                    data = Convert.ToBase64String(Content)
           
                Case RObjectTypes.csv, RObjectTypes.rtf, RObjectTypes.txt
                    data = _content
            End Select
            finString = finString.Replace("#CONTENT#", data)
            sw.Write(finString)
            Return True
        Catch ex As Exception
            DE(ex)
            Return False
        End Try


    End Function
End Class
