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

Friend Class Page
    Private _id As String = ""
    Private _content As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}"
    Private _img As Image
    Private _seq As Integer
    Event PageModified(sender As Object)
    Private _wordCount As Integer
    Private _pagetype As PageType
    Private _tags As New List(Of String)
    Private _IndexEntries As New List(Of String)
    Private _sampleText As String = ""
    Private _text As String = ""
    Private _name As String = ""
    Public Property Name As String
        Get
            Return xmlDecode(_name)
        End Get
        Set(value As String)
            _name = xmlEncode(value)
            RaiseEvent PageModified(Me)
        End Set
    End Property

    Public Property SampleText As String
        Get
            Return xmlDecode(_sampleText)
        End Get
        Set(value As String)
            If bookLoading Then _sampleText = value Else _sampleText = xmlEncode(value)

        End Set
    End Property
    Public Property Text As String
        Get
            Return xmlDecode(_text)
        End Get
        Set(value As String)
            _text = xmlEncode(value)
        End Set
    End Property
    Public ReadOnly Property IndexEntries As List(Of String)
        Get
            Return _IndexEntries
        End Get
    End Property
    Public ReadOnly Property Tags As List(Of String)
        Get
            Return _tags
        End Get

    End Property
    Public Sub New(typ As PageType)
        Me._pagetype = typ
    End Sub
    Private Property Image As Image
        Get
            Return _img
        End Get
        Set(value As Image)
            _img = value
        End Set
    End Property
    Public Property Type As PageType
        Get
            Return _pagetype
        End Get
        Set(value As PageType)
            If value <> Type Then
                RaiseEvent PageModified(Me)
                AddLog(TaskTypes.Changed_page_type)
            End If
            _pagetype = value

        End Set
    End Property
    Public Property WordCount As Integer
        Get
            Return _wordCount
        End Get
        Set(value As Integer)
            _wordCount = value
        End Set
    End Property
    Public Property ID As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property
    Public Property Content As Object
        Get
            If _pagetype = PageType.Document Then
                Return xmlDecode(_content)
            Else
                If Image Is Nothing Then Return Image
                Return New Bitmap(Image, New Size(CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height))
                End If
        End Get
        Set(value As Object)
            If _pagetype = PageType.Document Then

                _content = xmlEncode(value)

            Else
                Image = value
                If bookLoading = False Then AddLog(TaskTypes.Page_image_added)
            End If
            RaiseEvent PageModified(Me)
        End Set
    End Property

    Public Property Seq As Integer
        Get
            Return _seq
        End Get
        Set(value As Integer)
            _seq = value
            RaiseEvent PageModified(Me)
        End Set
    End Property
    Public Function GetXML() As String
        Dim finString
        If Type = PageType.Document Then
            finString = "<page id=""" + _id + """ seq=""" & Seq & """ wordcount=""" & WordCount & """ type=""" & Type & """ name=""" & _name & """>" & vbCrLf &
            "<content>" + _content + "</content>" & vbCrLf &
              "<tags>" & String.Join("`", Tags.ToArray()) & "</tags>" & vbCrLf &
              "<index>" & String.Join("`", IndexEntries.ToArray) & "</index>" & vbCrLf &
                 "<sampletext>" & _sampleText & "</sampletext>" & vbCrLf &
              "<text>" & _text & "</text>" & vbCrLf &
            "</page>" & vbCrLf
        Else
            Dim bytes() As Byte
            Dim iC As New ImageConverter
            bytes = iC.ConvertTo(_img, GetType(Byte()))
            finString = "<page id=""" + _id + """ seq=""" & Seq & """ wordcount=""" & WordCount & """ type=""" & Type & """  name=""" & _name & """>" & vbCrLf &
           "<content>" + Convert.ToBase64String(bytes) + "</content>" & vbCrLf &
           "<tags>" & String.Join("`", Tags.ToArray()) & "</tags>" & vbCrLf &
             "<index>" & String.Join("`", IndexEntries.ToArray) & "</index>" & vbCrLf &
             "<sampletext>" & _sampleText & "</sampletext>" & vbCrLf &
           "</page>" & vbCrLf
        End If
        Return finString
    End Function


End Class
