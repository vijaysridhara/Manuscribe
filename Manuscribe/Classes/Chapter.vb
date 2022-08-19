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
Friend Class Chapter
    Private _pages As New List(Of Page)
    Private _name As String
    Private _id As String
    Private _seq As Integer
    Private _currPageID As Integer = 0
    Private _synopsis As String
    Private _isDraft As Boolean
    Event ChapterModified(sender As Object)

    Public ReadOnly Property WordCount As Integer
        Get
            Dim wCnt As Integer
            For Each pg As Page In Pages
                wCnt += pg.WordCount
            Next
            Return wCnt
        End Get

    End Property
    Public Property IsDraft As Boolean
        Get
            Return _isDraft
        End Get
        Set(value As Boolean)
            _isDraft = value
            RaiseEvent ChapterModified(Me)

        End Set
    End Property
    Public Property Synopsis As String
        Get
            Return xmlDecode(_synopsis)
        End Get
        Set(value As String)
            If bookLoading Then _synopsis = value Else _synopsis = xmlEncode(value)
            If bookLoading = False Then AddLog(TaskTypes.Edited_synopsis)
            RaiseEvent ChapterModified(Me)
        End Set
    End Property
    Public Property CurrPageID As Integer
        Get
            Return _currPageID
        End Get
        Set(value As Integer)
            _currPageID = value
        End Set
    End Property
    Private Function GetNextID() As String
        _currPageID += 1
        Dim f As String = _currPageID
        While f.Length < 3
            f = "0" + f
        End While
        Return f
    End Function
    Public Property ID As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value

        End Set
    End Property
    Public Sub New(name As String, seq As Integer, Optional typ As PageType = PageType.Document)
        Dim pg As New Page(typ)
        pg.Seq = Pages.Count + 1
        Me.Name = name
        pg.ID = GetNextID()
        Me._seq = seq
        _pages.Add(pg)
        AddLog(TaskTypes.Chapter_added)

    End Sub
    Public ReadOnly Property Pages As List(Of Page)
        Get
            Return _pages
        End Get
    End Property
    Public Sub AddPage(p As Page)
        p.ID = GetNextID()
        p.Seq = Pages.Count + 1
        Pages.Add(p)
        AddHandler p.PageModified, AddressOf pageModified
        AddLog(TaskTypes.Page_added)
        RaiseEvent ChapterModified(Me)
    End Sub
    ''' <summary>
    ''' REquired for loading from file
    ''' </summary>
    ''' <param name="p"></param>
    ''' <remarks></remarks>
    Public Sub AddPageWithoutID(p As Page)
        Pages.Add(p)
        AddHandler p.PageModified, AddressOf pageModified
    End Sub
    Private Sub pageModified(p As Page)
        RaiseEvent ChapterModified(Me)
        If Not bookLoading Then AddLog(TaskTypes.Page_edited)
    End Sub
    Public Property Name As String
        Get
            Return xmlDecode(_name)
        End Get
        Set(value As String)
            If bookLoading Then _name = value Else _name = xmlEncode(value)
            If Not bookLoading Then AddLog(TaskTypes.Edited_chapter_name)
            RaiseEvent ChapterModified(Me)
        End Set
    End Property
    Public Function GetPageByID(id As String) As Page
        For Each pg As Page In Pages
            If pg.ID = id Then Return pg
        Next
        Return Nothing
    End Function
    Public Property Seq As Integer
        Get
            Return _seq
        End Get
        Set(value As Integer)
            _seq = value
            RaiseEvent ChapterModified(Me)
        End Set
    End Property
    Private Function GetXML() As String
        Dim pgString As String = ""
        For Each pg As Page In Me.Pages
            pgString += pg.GetXML
        Next
        Dim finstring = "<chapter id=""" + ID + """ seq=""" & Seq & """ lastpageid=""" & CurrPageID & """>" & vbCrLf &
            "<title>" + _name + "</title>" & vbCrLf &
            "<synopsis>" + _synopsis + "</synopsis>" & vbCrLf &
             "<pages count=""" & Me.Pages.Count & """>" & vbCrLf &
              pgString &
             "</pages>" & vbCrLf &
            "</chapter>" & vbCrLf
        Return finstring
    End Function
    Public Function WritetoFile(sw As IO.StreamWriter) As Boolean
        Try
            sw.Write(GetXML)
            Return True
        Catch ex As Exception
            DE(ex)
            Return False
        End Try
    End Function
    Public Sub RemovePage(pageid As String)
        For Each pg As Page In Pages
            If pg.ID = pageid Then
                Pages.Remove(pg)
                Exit For
            End If
        Next

        RaiseEvent ChapterModified(Me)
        AddLog(TaskTypes.Page_removed)
    End Sub


End Class
