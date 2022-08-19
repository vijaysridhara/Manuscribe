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
Imports System.Xml

Friend Class Book
    Private _version As String = "0.5"
    Private _title As String = ""
    Private _subtitle As String = ""
    Private _author As String = ""
    Private _createdon As String = ""
    Private _updatedon As String = ""
    Private _defPage As PageTemplate
    'Private _Struct As BookStructure
    Private _chapters As New List(Of Chapter)
    Private _drafts As New List(Of Chapter)
    Private _rCategories As New List(Of String)
    Private _rObjects As New Dictionary(Of String, RObject)
    Private _currChapID As Integer = 0
    Private _currDraftID As Integer = 0
    Private _trash As New List(Of Chapter)
    Private _path As String
    Private _fname As String
    Public Modified As Boolean
    Private _wordCount As Long
    Event Message(msg As String)
    Event ChaptersShuffled()
    Private _YVideos As New List(Of String)
    Private _outLine As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}"
    Friend Covers As New Dictionary(Of ImageType, Cover)
    Event BookModified()
    Private _bookHistory As New Dictionary(Of String, TaskEntry)
    Public Sub RaiseChanged()
        Modified = True
        RaiseEvent BookModified()
    End Sub
    Public ReadOnly Property YVideos As List(Of String)
        Get
            Return _YVideos
        End Get
    End Property
    Public ReadOnly Property History As Dictionary(Of String, TaskEntry)
        Get
            Return _bookHistory
        End Get
    End Property
    Public Property Outline As String
        Get
            Return xmlDecode(_outLine)
        End Get
        Set(value As String)
            If bookLoading Then _outLine = value : Else _outLine = xmlEncode(value)
            RaiseEvent BookModified()
        End Set
    End Property
    Public ReadOnly Property WordCount As Long
        Get
            Return _wordCount
        End Get
    End Property
    Public Property Path As String
        Get
            Return _path
        End Get
        Set(value As String)
            _path = value
        End Set
    End Property
    Public Property Fname As String
        Get
            Return _fname
        End Get
        Set(value As String)
            _fname = value
        End Set
    End Property

    Public ReadOnly Property Version As String
        Get
            Return _version
        End Get
    End Property
    Public Property CurrentChapID As Integer
        Get
            Return _currChapID
        End Get
        Set(value As Integer)
            _currChapID = value
        End Set
    End Property
    Public ReadOnly Property Trash As List(Of Chapter)
        Get
            Return _trash
        End Get
    End Property
    Public Function AddChapter(c As Chapter) As Chapter
        c.IsDraft = False
        c.ID = GetNextChapterID()
        _chapters.Add(c)
        AddHandler c.ChapterModified, AddressOf ChapterModified
        Modified = True
        If bookLoading = False Then AddLog(TaskTypes.Chapter_added)
        RaiseEvent BookModified()
        Return c
    End Function
    Public Function AddRObject(rob As RObject) As RObject
        Try
            RObjects.Add(rob.Name, rob)
            Modified = True
            RaiseEvent BookModified()
            If bookLoading = False Then AddLog(TaskTypes.Added_research_object)
            Return rob
        Catch ex As Exception
            DE(ex)
            Return Nothing
        End Try
    End Function
    Public Function GetChapter(cid As String) As Chapter
        For Each ch As Chapter In Chapters
            If ch.ID = cid Then
                Return ch
                Exit Function
            End If
        Next
        Return Nothing
    End Function
    Public Function GetDraft(cid As String) As Chapter
        For Each ch As Chapter In Drafts
            If ch.ID = cid Then
                Return ch
                Exit Function
            End If
        Next
        Return Nothing
    End Function
    Public Function GetTrash(cid As String) As Chapter
        For Each ch As Chapter In Trash
            If ch.ID = cid Then
                Return ch
                Exit Function
            End If
        Next
        Return Nothing
    End Function
    Public Function ClearTrash()
        Try
            Trash.Clear()
            Modified = True
            If bookLoading = False Then AddLog(TaskTypes.Cleaned_trash)
            RaiseEvent BookModified()
        Catch ex As Exception
            DE(ex)
        End Try
    End Function
    Private Sub RObjectAdded(sender As Object)
        Modified = True
        If bookLoading = False Then AddLog(TaskTypes.Added_research_object)
        RaiseEvent BookModified()
    End Sub
    Private Sub ChapterModified(sender As Object)
        Modified = True
        _wordCount = 0
        For Each c As Chapter In Chapters
            _wordCount += c.WordCount
        Next
        RaiseEvent BookModified()
    End Sub
    Public Function RemoveChapter(cid As String, Optional notTrash As Boolean = True) As Chapter


        For Each ch As Chapter In Chapters
            If ch.ID = cid Then
                RemoveHandler ch.ChapterModified, AddressOf ChapterModified
                _chapters.Remove(ch)
                If notTrash Then
                    Modified = True
                    RaiseEvent BookModified()
                    Return ch
                End If
                ch.ID = ch.ID & ":C"
                Trash.Add(ch)
                Modified = True
                RaiseEvent BookModified()
                Return ch
            End If
        Next
        If bookLoading = False Then AddLog(TaskTypes.Chapter_removed)
        Return Nothing
    End Function
    Public Sub MoveUpChapter(cid As String)
        Dim i As Integer = 0
        For Each ch As Chapter In Chapters
            If ch.ID = cid Then Exit For
            i += 1

        Next
        If i = 0 Or i >= Chapters.Count Then Exit Sub
        Dim ch1 As Chapter = Chapters(i)
        Chapters.RemoveAt(i)
        Chapters.Insert(i - 1, ch1)
        i = 1
        For Each ch As Chapter In Chapters
            ch.Seq = 1
            i += 1
        Next
        If bookLoading = False Then AddLog(TaskTypes.Chapter_shuffled)
        RaiseEvent ChaptersShuffled()
    End Sub
    Public Sub MoveDownChapter(cid As String)
        Dim i As Integer = 0
        For Each ch As Chapter In Chapters
            If ch.ID = cid Then Exit For
            i += 1

        Next
        If i >= Chapters.Count Then Exit Sub
        Dim ch1 As Chapter = Chapters(i)
        Chapters.RemoveAt(i)
        Chapters.Insert(i + 1, ch1)
        For Each ch As Chapter In Chapters
            ch.Seq = 1
            i += 1
        Next
        If bookLoading = False Then AddLog(TaskTypes.Chapter_shuffled)
        RaiseEvent ChaptersShuffled()
    End Sub
    Public Sub RemoveRObject(robname As String)
        If RObjects.ContainsKey(robname) Then

            RObjects.Remove(robname)
            Modified = True
            RaiseEvent BookModified()
        End If
        If bookLoading = False Then AddLog(TaskTypes.Removed_research_object)
    End Sub
    Public Function AddDraft(c As Chapter) As Chapter
        c.ID = GetNextDraftID()
        c.IsDraft = True
        AddHandler c.ChapterModified, AddressOf ChapterModified
        _drafts.Add(c)
        Modified = True
        If bookLoading = False Then AddLog(TaskTypes.Draft_added)
        RaiseEvent BookModified()
        Return c
    End Function
    Public Function AddDraftWithoutID(c As Chapter) As Chapter
        c.IsDraft = True
        AddHandler c.ChapterModified, AddressOf ChapterModified
        _drafts.Add(c)
        RaiseEvent BookModified()
        Return c
    End Function
    Public Function AddChapteWithoutID(c As Chapter) As Chapter
        c.IsDraft = False
        AddHandler c.ChapterModified, AddressOf ChapterModified
        _chapters.Add(c)
        RaiseEvent BookModified()
        Return c
    End Function
    Public Function RemoveDraft(cid As String, Optional notTrash As Boolean = True) As Chapter


        For Each dr As Chapter In Drafts
            If dr.ID = cid Then
                RemoveHandler dr.ChapterModified, AddressOf ChapterModified
                _drafts.Remove(dr)
                If notTrash Then
                    Modified = True
                    RaiseEvent BookModified()
                    If bookLoading = False Then AddLog(TaskTypes.Draft_removed)
                    Return dr
                End If
                dr.ID = dr.ID & ":D"
                Trash.Add(dr)
                Modified = True
                RaiseEvent BookModified()
                Return dr
            End If
        Next
        Return Nothing

    End Function
    Private Function GetNextChapterID() As String
        _currChapID += 1
        Dim f As String = _currChapID
        While f.Length < 3
            f = "0" + f
        End While
        Return f
    End Function
    Public Property CurrentDraftID As Integer
        Get
            Return _currDraftID
        End Get
        Set(value As Integer)
            _currDraftID = value
        End Set
    End Property
    Private Function GetNextDraftID() As String
        _currDraftID += 1
        Dim f As String = _currDraftID
        While f.Length < 3
            f = "0" + f
        End While
        Return f
    End Function
    Public ReadOnly Property RObjects As Dictionary(Of String, RObject)
        Get
            Return _rObjects
        End Get
    End Property

    Private ReadOnly Property ResearchCategories As List(Of String)
        Get
            Return _rCategories
        End Get
    End Property
    Public ReadOnly Property Chapters As List(Of Chapter)
        Get
            Return _chapters
        End Get
    End Property
    Public ReadOnly Property Drafts As List(Of Chapter)
        Get
            Return _drafts
        End Get
    End Property
    'Public Property Struct As BookStructure
    '    Get
    '        Return _Struct
    '    End Get
    '    Set(value As BookStructure)
    '        _Struct = value
    '        RaiseEvent BookModified()
    '    End Set
    'End Property
    Public Property PageSet As PageTemplate
        Get
            Return _defPage
        End Get
        Set(value As PageTemplate)
            _defPage = value
        End Set
    End Property
    Public Sub New()
        _defPage = pageTypes("A4").Clone

    End Sub
    
    Public Property Title As String
        Get
            Return xmlDecode(_title)
        End Get
        Set(value As String)
            If bookLoading Then _title = value Else _title = xmlEncode(value)
            If bookLoading = False Then AddLog(TaskTypes.Book_title_changed)
            Modified = True
        End Set
    End Property

    Public Property Subtitle As String
        Get
            Return xmlDecode(_subtitle)
        End Get
        Set(value As String)
            If bookLoading Then _subtitle = value : Else _subtitle = xmlEncode(value)
            Modified = True
            If bookLoading = False Then AddLog(TaskTypes.Book_subtitle_changed)
            RaiseEvent BookModified()
        End Set
    End Property

    Public Property Author As String
        Get
            Return xmlDecode(_author)
        End Get
        Set(value As String)
            If bookLoading Then _author = value Else _author = xmlEncode(value)
            If bookLoading = False Then AddLog(TaskTypes.Book_author_changed)
            Modified = True
            RaiseEvent BookModified()
        End Set
    End Property

    Public Property Createdon As String
        Get
            Return _createdon
        End Get
        Set(value As String)
            _createdon = value
        End Set
    End Property

    Public Property Updatedon As String
        Get
            Return _updatedon
        End Get
        Set(value As String)
            _updatedon = value
            Modified = True
            RaiseEvent BookModified()
        End Set
    End Property

    Public Function Savefile(fPath As String) As Boolean
        Try
            SaveObjecttoRecentPath(fPath, Me)
            Dim temppath As String = fPath & ".tmp"
            Dim sw As New IO.StreamWriter(temppath)
            RaiseEvent Message("Saving to temp file " & temppath)
            ' Dim finString = "<manuscribe-book version=""" + Version + """ struct=""" & Struct & """ wordcount=""" & WordCount & """>" & vbCrLf &
            Dim finString = "<manuscribe-book version=""" + Version & """ wordcount=""" & WordCount & """>" & vbCrLf &
         "<title>" & _title & "</title>" & vbCrLf &
         "<subtitle>" & _subtitle & "</subtitle>" & vbCrLf &
         "<author>" & _author & "</author>" & vbCrLf &
            "<page type=""" & PageSet.Name & """>" & vbCrLf &
            "<size width=""" & PageSet.Size.Width & """ height=""" & PageSet.Size.Height & """ />" & vbCrLf &
            "<margins left=""" & PageSet.Margins.Left & """ right=""" & PageSet.Margins.Right & """ top=""" & PageSet.Margins.Top & """ bottom=""" & PageSet.Margins.Bottom & """ />" & vbCrLf &
            "</page>" & vbCrLf &
            "<outline>" & _outLine & "</outline>" & vbCrLf &
            "<covers>" & vbCrLf
            For Each cv As Cover In Covers.Values
                finString += cv.GetXML
            Next
            finString += "</covers>" & vbCrLf
            sw.Write(finString)

            sw.WriteLine("<drafts count=""" & Drafts.Count & """ currentDraftID=""" & _currDraftID & """>")
            Dim cnt As Integer = 0
            For Each dr As Chapter In Drafts
                cnt += 1
                RaiseEvent Message("Saving drafts " & cnt & " of " & Drafts.Count)
                dr.WritetoFile(sw)
            Next
            sw.WriteLine("</drafts>")
            sw.WriteLine("<chapters count=""" & Chapters.Count & """ currentChapterID=""" & _currChapID & """ >")
            cnt = 0
            For Each ch As Chapter In Chapters
                cnt += 1
                RaiseEvent Message("Saving chapters " & cnt & " of " & Chapters.Count)
                ch.WritetoFile(sw)
            Next
            sw.WriteLine("</chapters>")
            sw.WriteLine("<research count=""" & RObjects.Count & """>")
            cnt = 0
            For Each ro As RObject In RObjects.Values
                cnt += 1
                RaiseEvent Message("Saving research " & cnt & " of " & RObjects.Count)
                ro.WritetoFile(sw)
            Next
            sw.WriteLine("</research>")
            sw.WriteLine("<trash count=""" & Trash.Count & """>")
            cnt = 0
            For Each tr As Chapter In Trash
                RaiseEvent Message("Saving trash " & cnt & " of " & Trash.Count)
                tr.WritetoFile(sw)
            Next
            sw.WriteLine("</trash>")
            sw.WriteLine("<history>")
            For Each te As TaskEntry In History.Values
                te.WriteTask(sw)
            Next
            sw.WriteLine("</history>")
            sw.WriteLine("<videos>")
            For Each v As String In YVideos
                sw.WriteLine("<url>" & v & "</url>")
            Next
            sw.WriteLine("</videos>")
            sw.WriteLine("</manuscribe-book>")
            sw.Close()
            sw.Dispose()
            RaiseEvent Message("Copying tempfile to " & fPath)
            If IO.File.Exists(fPath) Then
                My.Computer.FileSystem.DeleteFile(fPath)
            End If
            IO.File.Copy(temppath, fPath)
            My.Computer.FileSystem.DeleteFile(temppath)
            RaiseEvent Message("Save completed")
            Modified = False
            Me.Path = fPath
            Me.Fname = IO.Path.GetFileName(Fname)
            SaveBackup(fPath)
            Return True
        Catch ex As Exception
            DE(ex)
            Return False
        End Try
    End Function
    Private Sub SaveBackup(fpath As String)
        Try
            Dim fname As String = IO.Path.GetFileNameWithoutExtension(fpath)
            Dim fp As String = IO.Path.GetDirectoryName(fpath)
            Dim backupFolder As String = fp & "\" & fname & "_backup"
            If Not IO.Directory.Exists(backupFolder) Then
                IO.Directory.CreateDirectory(backupFolder)

            End If
            Dim todaysBackupFolder As String = backupFolder & "\" & Format(Date.Now, "yyyy-MM-dd")
            If Not IO.Directory.Exists(todaysBackupFolder) Then
                IO.Directory.CreateDirectory(todaysBackupFolder)
            End If
            If Covers.ContainsKey(ImageType.FrontCoverOut) Then
                If IO.File.Exists(backupFolder & "\frontcover_out.jpg") = False Then
                    Covers(ImageType.FrontCoverOut).Image.Save(backupFolder & "\frontcover_out.jpg")
                End If

            End If
            If Covers.ContainsKey(ImageType.FrontCoverIn) Then
                If IO.File.Exists(backupFolder & "\frontcover_in.jpg") = False Then
                    Covers(ImageType.FrontCoverOut).Image.Save(backupFolder & "\frontcover_in.jpg")
                End If

            End If
            If Covers.ContainsKey(ImageType.BackCoverIn) Then
                If IO.File.Exists(backupFolder & "\backcover_in.jpg") = False Then
                    Covers(ImageType.FrontCoverOut).Image.Save(backupFolder & "\backcover_in.jpg")
                End If

            End If
            If Covers.ContainsKey(ImageType.BackCoverOut) Then
                If IO.File.Exists(backupFolder & "\backcover_out.jpg") = False Then
                    Covers(ImageType.FrontCoverOut).Image.Save(backupFolder & "\backcover_out.jpg")
                End If

            End If
            Dim sw As New IO.StreamWriter(todaysBackupFolder & "\backup.txt")
            sw.WriteLine("[DRAFT]")
            Dim IMGnO As Integer = 0
            For Each d As Chapter In Drafts
                For Each P As Page In d.Pages
                    If P.Type = PageType.Document Then
                        sw.Write(P.Text)
                    Else
                        If Not P.Content Is Nothing Then
                            IMGnO += 1
                            CType(P.Content, Image).Save(todaysBackupFolder & "\" & IMGnO & ".jpg")
                        End If
                    End If
                Next
            Next
            sw.WriteLine("---------------------------------------------" & vbCrLf)
            sw.WriteLine("[CHAPTERS]" & vbCrLf)
            For Each d As Chapter In Chapters
                For Each P As Page In d.Pages
                    If P.Type = PageType.Document Then
                        sw.Write(P.Text & vbCrLf)
                    Else
                        If Not P.Content Is Nothing Then
                            IMGnO += 1
                            CType(P.Content, Image).Save(todaysBackupFolder & "\" & IMGnO & ".jpg")
                        End If
                    End If
                Next
            Next
            sw.WriteLine("---------------------------------------------" & vbCrLf)
            sw.WriteLine("[TRASH]" & vbCrLf)
            For Each d As Chapter In Trash
                For Each P As Page In d.Pages
                    If P.Type = PageType.Document Then
                        sw.Write(P.Text & vbCrLf)
                    Else
                        If Not P.Content Is Nothing Then
                            IMGnO += 1
                            CType(P.Content, Image).Save(todaysBackupFolder & "\" & IMGnO & ".jpg")
                        End If
                    End If
                Next
            Next
            sw.WriteLine("---------------------------------------------" & vbCrLf)
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Function LoadFile(path As String) As Boolean
        Try
            bookLoading = True
            RaiseEvent Message("Loading manuscribe project " & path)
            Dim xmlDoc As New Xml.XmlDocument()
            xmlDoc.Load(path)
            Dim rootEle As XmlNode = xmlDoc.FirstChild
            Dim verAtt As XmlAttribute = rootEle.Attributes("version")
            ' Dim strAtt As XmlAttribute = rootEle.Attributes("struct")
            Dim wCntAtt As XmlAttribute = rootEle.Attributes("wordcount")

            If verAtt.Value = Version Then
                LoadCurrentVersion(rootEle)
            ElseIf (verAtt.Value = "0.1" Or verAtt.Value = "0.2" Or verAtt.Value = "0.3") And Version = "0.4" Then
                If MsgBox("There is a version mismatch Expected:" & Version & " File: " & verAtt.Value & vbCrLf & "I can still open the file. Do you want to continue?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Return False
                LoadCurrentVersion(rootEle)
            Else
                MsgBox("There is a version mismatch Expected:" & Version & " File: " & verAtt.Value)
                Return False
            End If
            _wordCount = wCntAtt.Value
            'Struct = CInt(strAtt.Value)

            Me.Path = path
            Me.Fname = IO.Path.GetFileName(path)
            bookLoading = False
            Return True
        Catch ex As Exception
            DE(ex)
            bookLoading = False
            Return False

        End Try
    End Function
    Private Sub LoadCurrentVersion(xmlNode As XmlNode)

        Dim titNode As XmlNode = xmlNode.FirstChild()
        Me.Title = titNode.InnerText
        For Each xnd As XmlNode In xmlNode.ChildNodes
            Select Case xnd.Name
                Case "title"
                    Me.Title = xnd.InnerText
                Case "subtitle"
                    Me.Subtitle = xnd.InnerText
                Case "author"
                    Me.Author = xnd.InnerText
                Case "page"
                    PageSet = pageTypes(xnd.Attributes("type").Value)
                    For Each xnd1 As XmlNode In xnd.ChildNodes
                        Select Case xnd1.Name
                            Case "size"
                                PageSet.Size = New Size(xnd1.Attributes("width").Value, xnd1.Attributes("height").Value)

                            Case "margins"
                                PageSet.Margins = New Printing.Margins(xnd1.Attributes("left").Value,
                                                                     xnd1.Attributes("right").Value,
                                                                     xnd1.Attributes("top").Value,
                                                                     xnd1.Attributes("bottom").Value)
                        End Select
                    Next
                Case "covers"
                    RaiseEvent Message("Loading covers...")
                    For Each cvNd As XmlNode In xnd.ChildNodes
                        Dim tpAt As XmlAttribute = cvNd.Attributes("type")
                        Dim fmtAt As XmlAttribute = cvNd.Attributes("format")
                        Dim cv As New Cover
                        cv.Type = CType(tpAt.Value, ImageType)
                        cv.Format = fmtAt.Value
                        Dim imBytes() As Byte = Convert.FromBase64String(cvNd.InnerText)
                        Dim memStream As New MemoryStream(imBytes)
                        cv.Image = Image.FromStream(memStream)

                        Covers.Add(cv.Type, cv)
                    Next

                Case "drafts"
                    RaiseEvent Message("Loading drafts ...")
                    Dim cnt As Integer = CInt(xnd.Attributes("count").Value)
                    Dim cnt2 As Integer = 0
                    CurrentDraftID = xnd.Attributes("currentDraftID").Value
                    For Each xndCh As XmlNode In xnd.ChildNodes
                        cnt2 += 1
                        Dim ch As Chapter
                        Dim chID As String, chSeq As Integer, chlastPageID As Integer
                        chID = xndCh.Attributes("id").Value
                        chSeq = xndCh.Attributes("seq").Value
                        chlastPageID = xndCh.Attributes("lastpageid").Value

                        For Each xndChild As XmlNode In xndCh.ChildNodes
                            Select Case xndChild.Name
                                Case "title"
                                    ch = New Chapter(xndChild.InnerText, chSeq)
                                    ch.Pages.Clear()
                                    ch.CurrPageID = chlastPageID
                                    ch.ID = chID
                                    ch.IsDraft = True
                                Case "synopsis"
                                    ch.Synopsis = xndChild.InnerText
                                Case "pages"
                                    Dim pCount As Integer = xndChild.Attributes("count").Value
                                    Dim pCount2 As Integer = 0
                                    For Each xndPage As XmlNode In xndChild.ChildNodes
                                        pCount2 += 1
                                        Dim pID As String = ""
                                        Dim pSeq As Integer = 0
                                        Dim wCount As Integer = 0
                                        Dim ptype As Short = 0
                                        Dim pName As String = ""
                                        For Each at As XmlAttribute In xndPage.Attributes
                                            Select Case at.Name
                                                Case "id"
                                                    pID = at.Value
                                                Case "seq"
                                                    pSeq = at.Value
                                                Case "wordcount"
                                                    wCount = at.Value
                                                Case "type"
                                                    ptype = at.Value
                                                Case "name"
                                                    pName = at.Value
                                            End Select
                                        Next

                                        Dim ixs() As String, tgs() As String
                                        Dim smp As String = ""
                                        Dim txt As String = ""
                                        Dim pg As New Page(ptype)
                                        For Each xpChild As XmlNode In xndPage.ChildNodes
                                            Select Case xpChild.Name
                                                Case "content"
                                                    If ptype = PageType.Image Then
                                                        Dim bytes() As Byte
                                                        bytes = Convert.FromBase64String(xpChild.InnerText)
                                                        If bytes.Length = 0 Then
                                                            pg.Content = Nothing
                                                        Else
                                                            Dim ms As New MemoryStream(bytes)
                                                            pg.Content = Image.FromStream(ms)
                                                        End If

                                                    Else
                                                        pg.Content = xpChild.InnerText
                                                    End If
                                                Case "tags"
                                                    tgs = xpChild.InnerText.Split("`")
                                                Case "index"
                                                    ixs = xpChild.InnerText.Split("`")
                                                Case "sampletext"
                                                    smp = xpChild.InnerText
                                                Case "text"
                                                    txt = xpChild.InnerText
                                            End Select
                                        Next

                                        pg.ID = pID
                                        pg.Seq = pSeq
                                        pg.Name = pName
                                        pg.SampleText = smp
                                        pg.Text = txt
                                        pg.WordCount = wCount
                                        If Not ixs Is Nothing Then pg.IndexEntries.AddRange(ixs)
                                        If Not tgs Is Nothing Then pg.Tags.AddRange(tgs)
                                        ch.AddPageWithoutID(pg)
                                    Next
                            End Select

                        Next
                        AddDraftWithoutID(ch)
                    Next
                Case "chapters"
                    RaiseEvent Message("Loading chapters ...")
                    Dim cnt As Integer = xnd.Attributes("count").Value
                    Dim cnt2 As Integer = 0
                    CurrentChapID = xnd.Attributes("currentChapterID").Value
                    For Each xndCh As XmlNode In xnd.ChildNodes
                        cnt2 += 1
                        Dim ch As Chapter
                        Dim chID As String, chSeq As Integer, chlastPageID As Integer
                        chID = xndCh.Attributes("id").Value
                        chSeq = xndCh.Attributes("seq").Value
                        chlastPageID = xndCh.Attributes("lastpageid").Value
                        For Each xndChild As XmlNode In xndCh.ChildNodes
                            Select Case xndChild.Name
                                Case "title"
                                    ch = New Chapter(xndChild.InnerText, chSeq)
                                    ch.Pages.Clear()
                                    ch.ID = chID
                                    ch.CurrPageID = chlastPageID
                                    ch.IsDraft = False
                                Case "synopsis"
                                    ch.Synopsis = xndChild.InnerText
                                Case "pages"
                                    Dim pCount As Integer = xndChild.Attributes("count").Value
                                    Dim pCount2 As Integer = 0
                                    For Each xndPage As XmlNode In xndChild.ChildNodes
                                        pCount2 += 1
                                        Dim pID As String = ""
                                        Dim pSeq As Integer = 0
                                        Dim wCount As Integer = 0
                                        Dim ptype As Short = 0
                                        Dim pName As String = ""
                                        For Each at As XmlAttribute In xndPage.Attributes
                                            Select Case at.Name
                                                Case "id"
                                                    pID = at.Value
                                                Case "seq"
                                                    pSeq = at.Value
                                                Case "wordcount"
                                                    wCount = at.Value
                                                Case "type"
                                                    ptype = at.Value
                                                Case "name"
                                                    pName = at.Value
                                            End Select
                                        Next
                                        Dim ixs() As String, tgs() As String
                                        Dim smp As String = ""
                                        Dim pg As New Page(ptype)
                                        Dim txt As String = ""
                                        For Each xpChild As XmlNode In xndPage.ChildNodes
                                            Select Case xpChild.Name
                                                Case "content"
                                                    If ptype = PageType.Image Then
                                                        Dim bytes() As Byte
                                                        bytes = Convert.FromBase64String(xpChild.InnerText)
                                                        If bytes.Length = 0 Then
                                                            pg.Content = Nothing
                                                        Else
                                                            Dim ms As New MemoryStream(bytes)
                                                            pg.Content = Image.FromStream(ms)
                                                        End If

                                                    Else
                                                        pg.Content = xpChild.InnerText
                                                    End If
                                                Case "tags"
                                                    tgs = xpChild.InnerText.Split("`")
                                                Case "index"
                                                    ixs = xpChild.InnerText.Split("`")
                                                Case "sampletext"
                                                    smp = xpChild.InnerText
                                                Case "text"
                                                    txt = xpChild.InnerText
                                            End Select
                                        Next
                                        pg.ID = pID
                                        pg.Seq = pSeq
                                        pg.SampleText = smp
                                        pg.Text = txt
                                        pg.Name = pName
                                        If Not ixs Is Nothing Then pg.IndexEntries.AddRange(ixs)
                                        If Not tgs Is Nothing Then pg.Tags.AddRange(tgs)
                                        pg.WordCount = wCount
                                      
                                        ch.AddPageWithoutID(pg)
                                    Next
                            End Select

                        Next
                        AddChapteWithoutID(ch)
                    Next
                Case "research"
                    RaiseEvent Message("Loading research ...")
                    Dim rCount As Integer = xnd.Attributes("count").Value
                    Dim rCount2 As Integer = 0
                    For Each xndRch As XmlNode In xnd.ChildNodes
                        Dim typ As RObjectTypes = xndRch.Attributes("type").Value
                        Dim cat As String = xndRch.Attributes("category").Value
                        Dim name As String = xndRch.Attributes("name").Value
                        Dim robj As New RObject()
                        robj.Type = typ
                        robj.Category = cat
                        robj.Name = name
                        Dim cntNode As XmlNode = xndRch.FirstChild()
                        Select Case robj.Type
                            Case RObjectTypes.csv, RObjectTypes.txt, RObjectTypes.rtf
                                robj.Content = cntNode.InnerText
                            Case Else
                                robj.Content = Convert.FromBase64String(cntNode.InnerText)
                        End Select
                        RObjects.Add(robj.Name, robj)
                    Next
                Case "trash"
                    RaiseEvent Message("Loading trash ...")
                    Dim trcnt As Integer = xnd.Attributes("count").Value
                    Dim trcnt2 As Integer = 0
                    For Each xndCh As XmlNode In xnd.ChildNodes
                        trcnt2 += 1
                        Dim ch As Chapter
                        Dim chID As String, chSeq As Integer, chlastPageID As Integer
                        chID = xndCh.Attributes("id").Value
                        chSeq = xndCh.Attributes("seq").Value
                        chlastPageID = xndCh.Attributes("lastpageid").Value
                        Dim chIsDraft As Boolean = IIf(chID.Split(":")(1).Equals("C"), False, True)
                        For Each xndChild As XmlNode In xndCh.ChildNodes
                            Select Case xndChild.Name
                                Case "title"
                                    ch = New Chapter(xndChild.InnerText, chSeq)
                                    ch.Pages.Clear()
                                    ch.ID = chID
                                    ch.CurrPageID = chlastPageID
                                    ch.IsDraft = chIsDraft

                                Case "synopsis"
                                    ch.Synopsis = xndChild.Value
                                Case "pages"
                                    Dim pCount As Integer = xndChild.Attributes("count").Value
                                    Dim pCount2 As Integer = 0
                                    For Each xndPage As XmlNode In xndChild.ChildNodes
                                        pCount2 += 1
                                        Dim pID As String = ""
                                        Dim pSeq As Integer = 0
                                        Dim wCount As Integer = 0
                                        Dim ptype As Short = 0
                                        Dim pName As String = ""
                                        For Each at As XmlAttribute In xndPage.Attributes
                                            Select Case at.Name
                                                Case "id"
                                                    pID = at.Value
                                                Case "seq"
                                                    pSeq = at.Value
                                                Case "wordcount"
                                                    wCount = at.Value
                                                Case "type"
                                                    ptype = at.Value
                                                Case "name"
                                                    pName = at.Value
                                            End Select
                                        Next
                                        Dim ixs() As String, tgs() As String
                                        Dim smp As String = ""
                                        Dim txt As String = ""
                                        Dim pg As New Page(ptype)
                                        For Each xpChild As XmlNode In xndPage.ChildNodes
                                            Select Case xpChild.Name
                                                Case "content"
                                                    If ptype = PageType.Image Then
                                                        Dim bytes() As Byte
                                                        bytes = Convert.FromBase64String(xpChild.InnerText)
                                                        If bytes.Length = 0 Then
                                                            pg.Content = Nothing
                                                        Else
                                                            Dim ms As New MemoryStream(bytes)
                                                            pg.Content = Image.FromStream(ms)
                                                        End If

                                                    Else
                                                        pg.Content = xpChild.InnerText
                                                    End If
                                                Case "tags"
                                                    tgs = xpChild.InnerText.Split("`")
                                                Case "index"
                                                    ixs = xpChild.InnerText.Split("`")
                                                Case "sampletext"
                                                    smp = xpChild.InnerText
                                                Case "text"
                                                    txt = xpChild.InnerText
                                            End Select
                                        Next

                                        pg.ID = pID
                                        pg.Seq = pSeq
                                        pg.Name = pName
                                        pg.SampleText = smp
                                        pg.Text = txt
                                        pg.WordCount = wCount
                                        If Not ixs Is Nothing Then pg.IndexEntries.AddRange(ixs)
                                        If Not tgs Is Nothing Then pg.Tags.AddRange(tgs)
                                        ch.Pages.Add(pg)
                                    Next
                            End Select

                        Next
                        Trash.Add(ch)

                    Next
                Case "videos"
                    RaiseEvent Message("Loading Youtube video URLS")
                    For Each xndCh As XmlNode In xnd.ChildNodes
                        YVideos.Add(xndCh.InnerText)
                    Next
                    RaiseEvent Message("Completed URLS")
                Case "history"
                    RaiseEvent Message("Loading history ...")
                    For Each xndCh As XmlNode In xnd.ChildNodes
                        Dim tk As New TaskEntry
                        Select Case xndCh.Name
                            Case "on"
                                Dim xdtAt As XmlAttribute = xndCh.Attributes("date")
                                tk.OnDate = xdtAt.Value
                                Dim xwdCAt As XmlAttribute = xndCh.Attributes("wordcount")
                                For Each xonTks As XmlNode In xndCh.ChildNodes
                                    Select Case xonTks.Name
                                        Case "task"
                                            Dim xatAt As XmlAttribute = xonTks.Attributes("at")
                                            Dim xtypAt As XmlAttribute = xonTks.Attributes("type")

                                            Dim ttype As TaskTypes = CShort(xtypAt.Value)
                                            tk.Tasks.Add(xatAt.Value, ttype)
                                            tk.WordCount = xwdCAt.Value
                                        Case Else
                                    End Select
                                Next

                            Case Else
                        End Select
                        History.Add(tk.OnDate, tk)
                    Next

            End Select
        Next
        bookLoading = False
        RaiseEvent Message("Loading completed ...")
    End Sub
End Class
