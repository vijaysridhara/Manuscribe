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
Imports System.Drawing.Printing
Imports System.IO

Imports System.Xml
Imports System.Text
Imports System.ComponentModel

Public Class MainForm

    Dim nodeHeadFont As New System.Drawing.Font("Arial", 12, FontStyle.Regular)
    Dim nodeEleFont As New System.Drawing.Font("Arial", 10, FontStyle.Regular)
    Private Ideas As New Dictionary(Of String, Idea)
    Private printtitlefont As New Font("Times New Roman", 8, FontStyle.Italic Or FontStyle.Underline)
    Private printpagenofont As New Font("Times New Roman", 8, FontStyle.Regular)

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not CurrentBook Is Nothing Then
            If CurrentBook.Modified Then
                Dim res = MsgBox("The Current book is modified, do you want to save?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                If res = MsgBoxResult.Cancel Then e.Cancel = True : Exit Sub
                If res = MsgBoxResult.Yes Then
                    tlstpSave_Click(Nothing, Nothing)

                    If CurrentBook.Modified Then e.Cancel = True : Exit Sub
                End If
            End If
        End If
        SaveIdeas()
        SaveStyles()
        SerializeRecentBooks()
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control Then

            Select Case e.KeyCode
                Case Keys.S
                    If CurrentBook Is Nothing Then Exit Select
                    If tlstpSave.Enabled Then
                        tlstpSave_Click(Nothing, Nothing)
                    End If
                Case Keys.N
                    tlstpNewBook_Click(Nothing, Nothing)
                Case Keys.O
                    tlstpOpenBook_Click(Nothing, Nothing)
                Case Keys.P
                    If CurrentBook Is Nothing Then Exit Select
                    tlstpPrint_Click(Nothing, Nothing)

            End Select
        End If
    End Sub
    Private Sub MaainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadSettings()
        DeserializeRecentBooks()
        Canvas1.tlstpShowGrid.Checked = My.Settings.ShowMargin
        Canvas1.tlstpShowScroll.Checked = My.Settings.ScrollBar
        Canvas1.tlstpSeamlessedit.Checked = My.Settings.SeamlessEdititng
        AddDefaultStyle()
        Canvas1.RefreshStyles(My.Settings.StyleSet)
        enableDisable(False)
        Dim lines() As String = My.Resources.PrinterDet.Split(vbLf)
        For Each line As String In lines
            If String.IsNullOrEmpty(line) Then Continue For
            If line.Substring(0, 1).Equals("#") Then Continue For
            Dim ele() As String = line.Split(",")
            Dim pg As New PageTemplate(ele(0).Trim, CSng(ele(1)), CSng(ele(2)), CSng(ele(3)), CSng(ele(4)), CSng(ele(5)), CSng(ele(6)))
            pageTypes.Add(pg.Name, pg)
        Next
        Canvas1.PageSet = pageTypes("A4").Clone
        BookDetailsCtl1.Show()
        BookDetailsCtl1.Dock = DockStyle.Fill
        Desk1.Hide()
        Canvas1.Hide()
        WebCtrl1.Hide()
        CoverCanvas1.Hide()
        ' LoadNotes()
        WebCtrl1.WebBrowser1.ScriptErrorsSuppressed = True
        LoadIdeas()
    End Sub
    Private Sub enableDisable(enable As Boolean)
        WhichTreeSelected = ""
        tlstpBookProps.Enabled = enable
        tlstpChapterList.Enabled = enable
        tlstpExport.Enabled = enable
        tlstpSave.Enabled = enable
        tlstpPrint.Enabled = enable
        tvwBook.Enabled = enable
        Canvas1.Enabled = enable
        tlstpPrintPreview.Enabled = enable
        tlstpPageDesign.Enabled = enable
        ctxShowIndex.Enabled = enable

        If Not enable Then selecteDChapter = Nothing : tlstpReorderPages.Enabled = False 'Only while closing disable this
        If enable = False Then Me.Text = "Manuscribe"
        If Not enable Then
            Canvas1.Clear()
            Desk1.Clear()
            tvwBook.Nodes.Clear()
            tlstpWordCount.Text = ""
        End If
    End Sub
    Private Sub BookModified()
        On Error Resume Next
        tlstpWordCount.Text = "Total Words: " & CurrentBook.WordCount
        tlstpSave.Enabled = True
    End Sub
    Private Sub BookEvent(msg As String)
        StatMessage(msg)
    End Sub
    Private Sub tlstpNewBook_Click(sender As Object, e As EventArgs) Handles tlstpNewBook.Click
        If Not CurrentBook Is Nothing Then
            If CurrentBook.Modified Then
                Dim res As MsgBoxResult = MsgBox("The current book is modified, do you want to save?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                If res = MsgBoxResult.Cancel Then Exit Sub
                If res = MsgBoxResult.Yes Then
                    tlstpSave_Click(Nothing, Nothing)
                    If CurrentBook.Modified Then Exit Sub
                End If
            Else
                RemoveHandler CurrentBook.Message, AddressOf BookEvent
                RemoveHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
                RemoveHandler CurrentBook.BookModified, AddressOf BookModified
                CurrentBook = Nothing
            End If
        End If
        enableDisable(False)
        CurrentBook = New Book
        AddLog(TaskTypes.Created)
        CurrentBook.Outline = CurrentBook.Outline.Replace("#FONTNAME#", SystemStyles("Default").Styles("N").FName)
        AddHandler CurrentBook.Message, AddressOf BookEvent
        AddHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
        AddHandler CurrentBook.BookModified, AddressOf BookModified
        Dim bd As New BookDetails()

        If bd.ShowDialog = DialogResult.OK Then
            enableDisable(True)
            Canvas1.PageSet = CurrentBook.PageSet
            ' Canvas1.Struct = CurrentBook.Struct
            CreateStructure()
            Me.Text = "Manuscribe | " & CurrentBook.Title
        Else
            RemoveHandler CurrentBook.Message, AddressOf BookEvent
            RemoveHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
            RemoveHandler CurrentBook.BookModified, AddressOf BookModified
            CurrentBook = Nothing
        End If

    End Sub
    Private Sub CreateStructure()
        Try
            StatMessage("Creating book structure...")
            tvwBook.Nodes.Clear()


            Dim tn As TreeNode = tvwBook.Nodes.Add("!ROOT!", CurrentBook.Title, 0, 0)
            tn.Tag = "!ROOT!"
            tn.NodeFont = nodeHeadFont
            tn.Text = CurrentBook.Title
            Dim drNode As TreeNode = tn.Nodes.Add("!DRFROOT!", "Drafts", 4, 4)
            drNode.Tag = "!DRFROOT!"
            drNode.NodeFont = nodeHeadFont
            drNode.Text = "Drafts"
            Dim chNode As TreeNode = tn.Nodes.Add("!CHPROOT!", "Chapters", 1, 1)
            chNode.Tag = "!CHPROOT!"
            chNode.NodeFont = nodeHeadFont
            chNode.Text = "Chapters"
            Dim tn2 As TreeNode = tn.Nodes.Add("!COVROOT!", "Covers", 16, 16)
            tn2.Tag = "!COVROOT!"
            tn2.NodeFont = nodeHeadFont
            tn2.Text = "Covers"
            Dim rchNode As TreeNode = tn.Nodes.Add("!RCHROOT!", "Research work", 6, 6)
            rchNode.Tag = "!RCHROOT!"
            rchNode.NodeFont = nodeHeadFont
            rchNode.Text = "Research work"
            Dim rchImgNode As TreeNode = rchNode.Nodes.Add("!RCHIMGROOT!", "Images", 9, 9)
            rchImgNode.Tag = "!RCHIMGROOT!"
            rchImgNode.NodeFont = nodeEleFont
            rchImgNode.Text = "Images"
            Dim rchDocNode As TreeNode = rchNode.Nodes.Add("!RCHDOCROOT!", "Documents", 10, 10)
            rchDocNode.Tag = "!RCHDOCROOT!"
            rchDocNode.NodeFont = nodeEleFont
            rchDocNode.Text = "Documents"
            Dim rchTxtNode As TreeNode = rchNode.Nodes.Add("!RCHTXTROOT!", "Text files", 11, 11)
            rchTxtNode.Tag = "!RCHTXTROOT!"
            rchTxtNode.NodeFont = nodeEleFont
            rchTxtNode.Text = "Text files"
            Dim rchVidNode As TreeNode = rchNode.Nodes.Add("!RCHVIDROOT!", "Videos", 18, 18)
            rchVidNode.Tag = "!RCHVIDROOT!"
            rchVidNode.NodeFont = nodeEleFont
            rchVidNode.Text = "Videos"

            Dim brwNode As TreeNode = tn.Nodes.Add("!BRWROOT!", "Search web", 8, 8)
            brwNode.Tag = "!BRWROOT!"
            brwNode.NodeFont = nodeHeadFont
            brwNode.Text = "Search web"

            Dim trshNode As TreeNode = tn.Nodes.Add("!TRSROOT!", "Trash", 7, 7)
            trshNode.Tag = "!TRSROOT!"
            trshNode.NodeFont = nodeHeadFont
            trshNode.Text = "Trash"
            Dim logNode As TreeNode = tn.Nodes.Add("!LOGROOT!", "Progress", 17, 17)
            logNode.Tag = "!LOGROOT!"
            logNode.NodeFont = nodeHeadFont
            logNode.Text = "Progress"

            tn.ExpandAll()
            drNode.ExpandAll()
            tvwBook.SelectedNode = chNode
            chNode.ExpandAll()


            StatMessage()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxNewChapter_Click(sender As Object, e As EventArgs) Handles ctxNewChapter.Click
        Try
            Dim nc As New NewChapter
            If nc.ShowDialog = DialogResult.OK Then
                Dim c As New Chapter(nc.txtTitle.Text.Trim, CurrentBook.Chapters.Count + 1, IIf(nc.optDocument.Checked, PageType.Document, PageType.Image))
                c.Synopsis = nc.txtSummary.Text.Trim
                CurrentBook.AddChapter(c)
                Dim chNode As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!CHPROOT!")
                Dim cNode As TreeNode = chNode.Nodes.Add(c.ID, c.Name, 2, 2)
                cNode.Tag = c.ID
                cNode.NodeFont = nodeEleFont
                c.IsDraft = False
                cNode.Text = c.Name
                chNode.ExpandAll()
                tvwBook.SelectedNode = cNode

                ' AddPagestoTree(c, cNode)
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    'Private Sub AddPagestoTree(c As Chapter, nd As TreeNode)
    '    Try
    '        For Each p As Page In c.Pages.Values
    '            Dim pnd As TreeNode = nd.Nodes.Add(p.ID, "Page-" & p.Seq, 3, 3)
    '            pnd.Tag = p.ID
    '        Next

    '    Catch ex As Exception
    '        DE(ex)
    '    End Try
    'End Sub

    Dim selecteDChapter As Chapter
    Dim WhichTreeSelected As String
    Dim WhichNodeSelected As TreeNode
    Private Sub tvwBook_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwBook.AfterSelect
        Try
            If WhichTreeSelected = "BOOK" Then
                'tHIS IS REQUIRED FOR NOT REFRESHING CONTENTS
                If e.Node.Equals(WhichNodeSelected) Then Exit Sub
            End If
            WhichTreeSelected = "BOOK"
            WhichNodeSelected = e.Node
            IdeaContainer1.Hide()
            pnlMainEditControls.Show()
            BookDetailsCtl1.Hide()
            BookCalenar1.Hide()
            ResearchContainer1.Hide()
            ResearchElementsDesk1.Hide()
            Desk1.Hide()
            CoverCanvas1.Hide()
            Canvas1.Hide()
            tlstpReorderPages.Enabled = False
            pnlMainEditControls.Dock = DockStyle.Fill
            selecteDChapter = Nothing
            WebCtrl1.Hide()
            Select Case e.Node.Tag
                'Case "!HELP!"
                '    BookDetailsCtl1.Show()
                '    BookDetailsCtl1.Dock = DockStyle.Fill
                '    Desk1.Hide()
                '    Canvas1.Hide()
                '    WebCtrl1.Hide()
                '    ResearchContainer1.Hide()
                '    CoverCanvas1.Hide()
                Case "!ROOT!"
                    Canvas1.Show()
                    Canvas1.Dock = DockStyle.Fill
                    StatMessage("Loading outline")
                    Canvas1.LoadOutline()
                    tlstpBookProps.Enabled = True
                    StatMessage()
                Case "!CHPROOT!"
                    Desk1.Show()
                    Desk1.Dock = DockStyle.Fill
                    StatMessage("Loading chapter...")
                    Desk1.LoadChapters(False)
                    StatMessage()
                Case "!DRFROOT!"
                    Desk1.Show()
                    Desk1.Dock = DockStyle.Fill
                    StatMessage("Loading drafts...")
                    Desk1.LoadChapters(True)
                    StatMessage()
                Case "!RCHROOT!"
                    ResearchContainer1.Show()
                    ResearchContainer1.Dock = DockStyle.Fill
                    ResearchContainer1.LoadResearChCategories()
                Case "!BRWROOT!"
                    WebCtrl1.Show()
                    WebCtrl1.Dock = DockStyle.Fill
                    WebCtrl1.BringToFront()
                Case "!TRSROOT!"
                    StatMessage("Loading trash...")
                    Desk1.Show()
                    Desk1.Dock = DockStyle.Fill
                    Desk1.LoadTrash()
                    StatMessage()
                Case "!COVROOT!"
                    CoverCanvas1.Show()
                    CoverCanvas1.Dock = DockStyle.Fill
                    CoverCanvas1.ShowAllCovers()
                Case "!LOGROOT!"
                    BookCalenar1.Show()
                    BookCalenar1.Dock = DockStyle.Fill
                    BookCalenar1.showLog()
                Case Else
                    Select Case e.Node.Parent.Tag
                        Case "!DRFROOT!"
                            If e.Node.ImageIndex = 5 Then
                                Canvas1.Show()
                                Canvas1.Dock = DockStyle.Fill
                                StatMessage("Loading the draft " & e.Node.Text)
                                Canvas1.ShowChapter(CurrentBook.GetDraft(e.Node.Tag), True)
                                selecteDChapter = CurrentBook.GetDraft(e.Node.Tag)
                                StatMessage()
                                tlstpReorderPages.Enabled = True
                            End If
                        Case "!CHPROOT!"
                            If e.Node.ImageIndex = 2 Then
                                Canvas1.Show()
                                Canvas1.Dock = DockStyle.Fill
                                StatMessage("Loading the chapter " & e.Node.Text)
                                Canvas1.ShowChapter(CurrentBook.GetChapter(e.Node.Tag), False)
                                selecteDChapter = CurrentBook.GetChapter(e.Node.Tag)
                                StatMessage()
                                tlstpReorderPages.Enabled = True
                            End If
                        Case "!COVROOT!"
                            StatMessage("Loading covers...")
                            CoverCanvas1.Show()
                            CoverCanvas1.ShowImage(e.Node.Tag.SPLIT(":")(0))
                            StatMessage()
                        Case "!RCHROOT!"
                            Select Case e.Node.Text
                                Case "Images"
                                    ResearchElementsDesk1.Show()
                                    ResearchElementsDesk1.Dock = DockStyle.Fill
                                    ResearchElementsDesk1.ShowRobjects("IMAGE")
                                Case "Documents"
                                    ResearchElementsDesk1.Show()
                                    ResearchElementsDesk1.Dock = DockStyle.Fill
                                    ResearchElementsDesk1.ShowRobjects("DOC")
                                Case "Text files"
                                    ResearchElementsDesk1.Show()
                                    ResearchElementsDesk1.Dock = DockStyle.Fill
                                    ResearchElementsDesk1.ShowRobjects("TEXT")
                                Case "Videos"
                                    ResearchElementsDesk1.Show()
                                    ResearchElementsDesk1.Dock = DockStyle.Fill
                                    ResearchElementsDesk1.ShowRobjects("VIDEO")
                            End Select

                        Case "!TRSROOT!"
                            If Desk1.Visible And Desk1.IsTrash Then Exit Select
                            Desk1.Show()
                            Desk1.Dock = DockStyle.Fill
                            Desk1.LoadTrash()
                    End Select


            End Select

        Catch ex As Exception
            DE(ex)
            StatMessage()
        End Try
    End Sub

    Private Sub ctxNewDraft_Click(sender As Object, e As EventArgs) Handles ctxNewDraft.Click
        Try
            Dim nc As New NewDraft
            If nc.ShowDialog = DialogResult.OK Then
                Dim c As New Chapter(nc.txtTitle.Text.Trim, CurrentBook.Drafts.Count + 1, IIf(nc.optDocument.Checked, PageType.Document, PageType.Image))
                c.Synopsis = nc.txtSummary.Text.Trim
                CurrentBook.AddDraft(c)
                Dim chNode As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!DRFROOT!")
                Dim cNode As TreeNode = chNode.Nodes.Add(c.ID, c.Name, 5, 5)
                cNode.Tag = c.ID
                cNode.NodeFont = nodeEleFont
                c.IsDraft = True
                cNode.Text = c.Name
                chNode.ExpandAll()
                tvwBook.SelectedNode = cNode
                ' AddPagestoTree(c, cNode)
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxTree_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxTree.Opening
        ctxNew.Enabled = False
        ctxNewChapter.Enabled = False
        ctxNewDraft.Enabled = False

        ctxRemove.Enabled = False
        ctxImport.Enabled = False
        ctxRestore.Enabled = False
        ctxMovetoChapters.Enabled = False
        ctxMovetoDrafts.Enabled = False
        ctxMoveToTrash.Enabled = False
        ctxEmptyTrash.Enabled = False
        ctxCovers.Enabled = False
        If tvwBook.SelectedNode Is Nothing Then
            Exit Sub
        End If
        Select Case tvwBook.SelectedNode.Tag
            Case "!ROOT!"
                ctxImport.Enabled = True
            Case "!CHPROOT!"
                ctxNew.Enabled = True
                ctxNewChapter.Enabled = True
                ctxNewDraft.Enabled = False
            Case "!DRFROOT!"
                ctxNew.Enabled = True
                ctxNewChapter.Enabled = False
                ctxNewDraft.Enabled = True
            Case "!RCHROOT!"
                ctxImport.Enabled = True
            Case "!TRSROOT!"
                ctxEmptyTrash.Enabled = True
            Case "!COVROOT!"
                ctxCovers.Enabled = True

            Case Else
                Select Case tvwBook.SelectedNode.Parent.Tag
                    Case "!CHPROOT!"
                        ctxMovetoDrafts.Enabled = True
                        ctxMoveToTrash.Enabled = True
                    Case "!DRFROOT!"
                        ctxMovetoChapters.Enabled = True
                        ctxMoveToTrash.Enabled = True
                    Case "!TRSROOT!"
                        ctxRestore.Enabled = True
                    Case "!RCHROOT!"
                        If tvwBook.SelectedNode.Tag = "!RCHTXTROOT!" Then
                            ctxNew.Enabled = True
                            ctxImport.Enabled = True
                        Else
                            ctxImport.Enabled = True
                        End If
                        ctxImport.Enabled = True
                    Case "!RCHIMGROOT!", "!RCHDOCROOT!"
                        ctxRemove.Enabled = True
                    Case "!RCHTXTROOT!"
                        ctxRemove.Enabled = True
                    Case "!COVROOT!"
                        ctxRemove.Enabled = True
                End Select
        End Select
    End Sub

    Private Sub tlstpBookProps_Click(sender As Object, e As EventArgs) Handles tlstpBookProps.Click
        Dim bp As New BookDetails

        If bp.ShowDialog = DialogResult.OK Then
            tvwBook.SelectedNode = tvwBook.Nodes("!ROOT!").Nodes("!CHPROOT!")
            'Canvas1.Struct = CurrentBook.Struct
            Canvas1.PageSet = CurrentBook.PageSet
            Me.Text = "Manuscribe | " & CurrentBook.Title

        End If
    End Sub

    Private Sub ctxImport_Click(sender As Object, e As EventArgs) Handles ctxImport.Click
        Try
            Dim ofd As New OpenFileDialog
            With ofd
                .Filter = "Image files(*.jpg,*.png,*.gif,*.tiff,*.jpeg,*.bmp)|*.jpg;*.png;*.gif;*.tiff;*.jpeg;*.bmp|" &
                    "Rich text files(*.rtf)|*.rtf|" &
                    "Text files(*.txt,*.csv)|*.txt;*.csv"
                .FilterIndex = 0
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    StatMessage("Importing file ..." & .FileName)
                    Dim rob As New RObject
                    Dim fext As String = IO.Path.GetExtension(.FileName).ToLower.Substring(1)
                    Dim fname As String = IO.Path.GetFileName(.FileName)
                    If CurrentBook.RObjects.ContainsKey(fname) Then
                        MsgBox("This file seems to be existing, please choose a different one, or consider renaming the file", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    rob.Name = fname

                    Dim items As Array
                    items = System.Enum.GetValues(GetType(RObjectTypes))
                    For Each it As Integer In items
                        If [Enum].GetName(GetType(RObjectTypes), it) = fext Then
                            rob.Type = it
                            Exit For
                        End If

                    Next
                    Select Case rob.Type
                        Case RObjectTypes.none
                            MsgBox("The file type is not allowed", MsgBoxStyle.Information)
                            Exit Select
                        Case RObjectTypes.bmp, RObjectTypes.jpg, RObjectTypes.png, RObjectTypes.tiff, RObjectTypes.gif
                            Dim readStream As FileStream
                            readStream = New FileStream(.FileName, FileMode.Open)
                            Dim readBinary As New BinaryReader(readStream)
                            Dim bytes() As Byte = readBinary.ReadBytes(readStream.Length)
                            rob.Content = bytes
                            readBinary.Close()
                            readBinary.Dispose()
                            readStream.Close()
                            readStream.Dispose()
                            CurrentBook.AddRObject(rob)
 
                            'Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHIMGROOT!").Nodes.Add(fname, fname, 12, 12)
                            'tnd.Tag = fname
                            'tnd.NodeFont = nodeEleFont
                            'tnd.Text = fname


                        Case RObjectTypes.txt, RObjectTypes.csv
                            Dim fr As New IO.StreamReader(.FileName)
                            rob.Content = fr.ReadToEnd
                            CurrentBook.AddRObject(rob)
                            fr.Close()
                            fr.Dispose()
                            'Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHTXTROOT!").Nodes.Add(fname, fname, 14, 14)
                            'tnd.NodeFont = nodeEleFont
                            'tnd.Text = fname
                            'tnd.Tag = fname
                        Case RObjectTypes.rtf
                            Dim fr As New IO.StreamReader(.FileName)
                            rob.Content = fr.ReadToEnd
                            CurrentBook.AddRObject(rob)
                            fr.Close()
                            fr.Dispose()
                            'Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHDOCROOT!").Nodes.Add(fname, fname, 13, 13)
                            'tnd.Tag = fname
                            'tnd.NodeFont = nodeEleFont
                            'tnd.Text = fname
                    End Select
                    If ResearchElementsDesk1.Visible Then
                        Select Case rob.Type
                            Case RObjectTypes.txt, RObjectTypes.csv
                                ResearchElementsDesk1.ShowRobjects("TEXT")
                            Case RObjectTypes.rtf
                                ResearchElementsDesk1.ShowRobjects("DOC")
                            Case Else
                                ResearchElementsDesk1.ShowRobjects("IMAGE")
                        End Select
                    End If

                End If

            End With
           
            StatMessage()

        Catch ex As Exception
            DE(ex)
            StatMessage()
        End Try
    End Sub

    Private Sub tvwBook_GotFocus(sender As Object, e As EventArgs) Handles tvwBook.GotFocus
        tvwBook_AfterSelect(Nothing, New TreeViewEventArgs(tvwBook.SelectedNode))
    End Sub

    Private Sub tvwBook_MouseDown(sender As Object, e As MouseEventArgs) Handles tvwBook.MouseDown
        Dim tv As TreeNode = tvwBook.HitTest(e.Location).Node
        If tv Is Nothing Then Exit Sub
        tvwBook.SelectedNode = tv
    End Sub
    Private Sub StatMessage(Optional msg As String = "Ready")
        tlstpMessage.Text = msg
        StatusStrip1.Refresh()
    End Sub

    Private Sub tlstpSave_Click(sender As Object, e As EventArgs) Handles tlstpSave.Click
        Try
            If String.IsNullOrEmpty(CurrentBook.Path) Then
                Dim sfd As New SaveFileDialog
                With sfd
                    .Filter = "Manuscribe files(*.mnsb)|*.mnsb"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        If CurrentBook.History.ContainsKey(StringDate) Then
                            CurrentBook.History(StringDate).WordCount = CurrentBook.WordCount
                        Else
                            AddLog(TaskTypes.None)
                            CurrentBook.History(StringDate).WordCount = CurrentBook.WordCount
                        End If
                        CurrentBook.Savefile(.FileName)
                        tlstpSave.Enabled = False
                        StatMessage()
                    End If
                End With
            Else
                CurrentBook.Savefile(CurrentBook.Path)
                If CurrentBook.History.ContainsKey(StringDate) Then
                    CurrentBook.History(StringDate).WordCount = CurrentBook.WordCount
                Else
                    AddLog(TaskTypes.None)
                    CurrentBook.History(StringDate).WordCount = CurrentBook.WordCount
                End If
                tlstpSave.Enabled = False
                StatMessage()
            End If

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub tlstpOpenBook_Click(sender As Object, e As EventArgs) Handles tlstpOpenBook.Click
        If Not CurrentBook Is Nothing Then
            If CurrentBook.Modified Then
                Dim res As MsgBoxResult = MsgBox("The current book is modified, do you want to save?", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.Question)
                If res = MsgBoxResult.Cancel Then Exit Sub
                If res = MsgBoxResult.Yes Then
                    tlstpSave_Click(Nothing, Nothing)
                    If CurrentBook.Modified Then Exit Sub
                End If
                RemoveHandler CurrentBook.Message, AddressOf BookEvent
                RemoveHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
                RemoveHandler CurrentBook.BookModified, AddressOf BookModified
                CurrentBook = Nothing

            Else
                RemoveHandler CurrentBook.Message, AddressOf BookEvent
                RemoveHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
                RemoveHandler CurrentBook.BookModified, AddressOf BookModified
                CurrentBook = Nothing
            End If
        End If
        enableDisable(False)

        Try

            Dim sb As New SelectBook()
            If sb.ShowDialog = DialogResult.OK Then
                If sb.IsNew Then
                    tlstpNewBook_Click(Nothing, Nothing)
                    Exit Sub
                End If
                CurrentBook = New Book

                AddHandler CurrentBook.Message, AddressOf BookEvent
                AddHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
                AddHandler CurrentBook.BookModified, AddressOf BookModified
                If CurrentBook.LoadFile(sb.FPath) Then

                    LoadBookintoTree()
                    CurrentBook.Modified = False
                    'Canvas1.Struct = CurrentBook.Struct
                    Canvas1.PageSet = CurrentBook.PageSet
                    Me.Text = "Manuscribe | " & CurrentBook.Title
                    tlstpWordCount.Text = "Total Words: " & CurrentBook.WordCount
                    tlstpSave.Enabled = False
                    SaveObjecttoRecentPath(sb.FPath, CurrentBook)
                Else
                    RemoveHandler CurrentBook.Message, AddressOf BookEvent
                    RemoveHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
                    RemoveHandler CurrentBook.BookModified, AddressOf BookModified
                    CurrentBook = Nothing
                    enableDisable(False)
                End If
            End If
            Exit Sub
            'Dim osd As New OpenFileDialog
            'osd.Filter = "Manuscribe files(*.mnsb)|*.mnsb"
            'If osd.ShowDialog = Windows.Forms.DialogResult.OK Then
            '    CurrentBook = New Book

            '    AddHandler CurrentBook.Message, AddressOf BookEvent
            '    AddHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
            '    AddHandler CurrentBook.BookModified, AddressOf BookModified
            '    If CurrentBook.LoadFile(osd.FileName) Then

            '        LoadBookintoTree()
            '        CurrentBook.Modified = False
            '        'Canvas1.Struct = CurrentBook.Struct
            '        Canvas1.PageSet = CurrentBook.PageSet
            '        Me.Text = "Manuscribe | " & CurrentBook.Title
            '        tlstpWordCount.Text = "Total Words: " & CurrentBook.WordCount
            '        tlstpSave.Enabled = False
            '    Else
            '        RemoveHandler CurrentBook.Message, AddressOf BookEvent
            '        RemoveHandler CurrentBook.ChaptersShuffled, AddressOf LoadChapters
            '        RemoveHandler CurrentBook.BookModified, AddressOf BookModified
            '        CurrentBook = Nothing

            '    End If
            'End If

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub LoadBookintoTree()
        Try
            CreateStructure()
            'Canvas1.Struct = CurrentBook.Struct
            LoadDrafts()
            LoadCovers()
            LoadChapters()
            LoadTrash()
            ' LoadResearch()
            tvwBook.SelectedNode = tvwBook.Nodes("!ROOT!").Nodes("!CHPROOT!")
            tvwBook.SelectedNode.ExpandAll()
            enableDisable(True)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub LoadDrafts()
        tvwBook.Nodes("!ROOT!").Nodes("!DRFROOT!").Nodes.Clear()
        For Each dr As Chapter In CurrentBook.Drafts
            Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!DRFROOT!").Nodes.Add(dr.ID, dr.Name, 5, 5)
            tnd.Tag = dr.ID
            tnd.NodeFont = nodeEleFont
            tnd.Text = tnd.Text
        Next
    End Sub
    Private Sub LoadTrash()
        tvwBook.Nodes("!ROOT!").Nodes("!TRSROOT!").Nodes.Clear()
        For Each dr As Chapter In CurrentBook.Trash
            If dr.IsDraft Then
                Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!TRSROOT!").Nodes.Add(dr.ID, dr.Name, 5, 5)
                tnd.Tag = dr.ID
                tnd.NodeFont = nodeEleFont
                tnd.Text = tnd.Text
            Else
                Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!TRSROOT!").Nodes.Add(dr.ID, dr.Name, 2, 2)
                tnd.Tag = dr.ID
                tnd.NodeFont = nodeEleFont
                tnd.Text = tnd.Text
            End If

        Next
    End Sub
    'Private Sub LoadResearch()
    '    tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHIMGROOT!").Nodes.Clear()
    '    tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHDOCROOT!").Nodes.Clear()
    '    tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHTXTROOT!").Nodes.Clear()
    '    For Each dr As RObject In CurrentBook.RObjects.Values
    '        Select Case dr.Type
    '            Case RObjectTypes.bmp, RObjectTypes.jpg, RObjectTypes.gif, RObjectTypes.tiff, RObjectTypes.png
    '                Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHIMGROOT!").Nodes.Add(dr.Name, dr.Name, 12, 12)
    '                tnd.NodeFont = nodeEleFont
    '                tnd.Text = tnd.Text
    '                tnd.Tag = dr.Name
    '            Case RObjectTypes.pdf, RObjectTypes.doc, RObjectTypes.docx, RObjectTypes.xls, RObjectTypes.xlsx, RObjectTypes.rtf
    '                Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHDOCROOT!").Nodes.Add(dr.Name, dr.Name, 13, 13)
    '                tnd.Tag = dr.Name
    '                tnd.NodeFont = nodeEleFont
    '                tnd.Text = tnd.Text
    '            Case RObjectTypes.txt, RObjectTypes.csv, RObjectTypes.html
    '                Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHTXTROOT!").Nodes.Add(dr.Name, dr.Name, 14, 14)
    '                tnd.Tag = dr.Name
    '                tnd.NodeFont = nodeEleFont
    '                tnd.Text = tnd.Text
    '        End Select
    '    Next
    'End Sub
    Private Sub LoadCovers()
        tvwBook.Nodes("!ROOT!").Nodes("!COVROOT!").Nodes.Clear()
        For Each cv As Cover In CurrentBook.Covers.Values

            Select Case cv.Type
                Case ImageType.FrontCoverOut
                    Dim tnCov As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!COVROOT!").Nodes.Add("Front cover out", "Front cover out", 12, 12)
                    tnCov.Tag = cv.Type & ":FCOUT"
                    tnCov.NodeFont = nodeEleFont
                    tnCov.Text = "Front cover out"
                Case ImageType.FrontCoverIn
                    Dim tnCov As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!COVROOT!").Nodes.Add("Front cover in", "Front cover in", 12, 12)
                    tnCov.Tag = cv.Type & ":FCIN"
                    tnCov.NodeFont = nodeEleFont
                    tnCov.Text = "Front cover in"
                Case ImageType.BackCoverIn
                    Dim tnCov As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!COVROOT!").Nodes.Add("Back cover in", "Back cover in", 12, 12)
                    tnCov.Tag = cv.Type & ":BCIN"
                    tnCov.NodeFont = nodeEleFont
                    tnCov.Text = "Back cover in"
                Case ImageType.BackCoverOut
                    Dim tnCov As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!COVROOT!").Nodes.Add("Back cover out", "Back cover out", 12, 12)
                    tnCov.Tag = cv.Type & ":BCOUT"
                    tnCov.NodeFont = nodeEleFont
                    tnCov.Text = "Back cover out"
            End Select
        Next
    End Sub
    Private Sub LoadChapters()
        tvwBook.Nodes("!ROOT!").Nodes("!CHPROOT!").Nodes.Clear()
        Canvas1.Clear()
        Desk1.Clear()
        For Each cr As Chapter In CurrentBook.Chapters
            Dim tnd As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!CHPROOT!").Nodes.Add(cr.ID, cr.Name, 2, 2)
            tnd.Tag = cr.ID
            tnd.NodeFont = nodeEleFont
            tnd.Text = cr.Name
        Next
    End Sub

    Private Sub ctxRemove_Click(sender As Object, e As EventArgs) Handles ctxRemove.Click
        Try
            Dim tnd As TreeNode = tvwBook.SelectedNode
            If MsgBox("Removing images and documents cannot be undone. Do you want to remove?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            If tnd Is Nothing Then Exit Sub
            Select Case tnd.Parent.Tag
                Case "!RCHIMGROOT!", "!RCHDOCROOT!", "!RCHTXTROOT!"
                    Dim rid As String = tnd.Tag
                    If CurrentBook.RObjects.ContainsKey(rid) Then
                        CurrentBook.RObjects.Remove(rid)
                        'LoadResearch()
                    End If
                Case "!COVROOT!"
                    Dim tp As ImageType = tnd.Tag.ToString.Split(":")(0)
                    If CurrentBook.Covers.ContainsKey(tp) Then
                        CurrentBook.Covers.Remove(tp)
                        LoadCovers()
                    End If

            End Select
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxRestore_Click(sender As Object, e As EventArgs) Handles ctxRestore.Click
        Try
            If tvwBook.SelectedNode Is Nothing Then Exit Sub
            Dim ch As Chapter = CurrentBook.GetTrash(tvwBook.SelectedNode.Tag)
            If ch.IsDraft Then
                CurrentBook.Trash.Remove(ch)
                CurrentBook.AddDraft(ch)
                tvwBook.SelectedNode.Remove()
                Dim chNode As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!DRFROOT!").Nodes.Add(ch.ID, ch.Name, 5, 5)
                chNode.Tag = ch.ID
                chNode.NodeFont = nodeEleFont
                chNode.Text = ch.Name
            Else
                CurrentBook.Trash.Remove(ch)
                CurrentBook.AddChapter(ch)
                tvwBook.SelectedNode.Remove()
                Dim chNode As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!CHPROOT!").Nodes.Add(ch.ID, ch.Name, 2, 2)
                chNode.Tag = ch.ID
                chNode.NodeFont = nodeEleFont
                chNode.Text = ch.Name

            End If

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxMoveToTrash_Click(sender As Object, e As EventArgs) Handles ctxMoveToTrash.Click
        Try
            If tvwBook.SelectedNode Is Nothing Then Exit Sub
            If tvwBook.SelectedNode.Parent Is Nothing Then Exit Sub
            If tvwBook.SelectedNode.Parent.Tag = "!CHPROOT!" Then
                Dim ch As Chapter = CurrentBook.RemoveChapter(tvwBook.SelectedNode.Tag, False)


                tvwBook.SelectedNode.Remove()
                Dim tnt As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!TRSROOT!").Nodes.Add(ch.ID, ch.Name, 2, 2)
                tvwBook.Nodes("!ROOT!").Nodes("!TRSROOT!").ExpandAll()
                tnt.NodeFont = nodeEleFont
                tnt.Text = ch.Name
                tnt.Tag = ch.ID

            ElseIf tvwBook.SelectedNode.Parent.Tag = "!DRFROOT!" Then

                Dim ch As Chapter = CurrentBook.RemoveDraft(tvwBook.SelectedNode.Tag, False)
                tvwBook.SelectedNode.Remove()
                Dim tnt As TreeNode = tvwBook.Nodes("!ROOT!").Nodes("!TRSROOT!").Nodes.Add(ch.ID, ch.Name, 5, 5)
                tvwBook.Nodes("!ROOT!").Nodes("!TRSROOT!").ExpandAll()
                tnt.NodeFont = nodeEleFont
                tnt.Text = ch.Name
                tnt.Tag = ch.ID
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Dim printDoc As PrintDocument
    Dim covPages As Integer
    Dim curChap As Chapter

    Dim curPage As Page

    Dim printChapNo As Integer
    Dim printPageNo As Integer
    Private Sub tlstpPrint_Click(sender As Object, e As EventArgs) Handles tlstpPrint.Click
        If CurrentBook.Chapters.Count = 0 Then
            MsgBox("Please write at least one chapter. That is tangible, isn't it?", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        StatMessage("Preparing for print...")
        Dim prd As New PrintDialog()
        'Dim pSt As New PrinterSettings
        'Dim pageSet As New PageSettings(pSt)
        'prd.AllowPrintToFile = True
        'pageSet.PaperSize = New PaperSize(CurrentBook.PageSet.Name, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)
        'pageSet.Margins = CurrentBook.PageSet.Margins
        'prd.PrinterSettings = pSt
        prd.Document = New PrintDocument
        prd.Document.DefaultPageSettings.PaperSize = New PaperSize(CurrentBook.PageSet.Name, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)
        prd.Document.DefaultPageSettings.Margins = CurrentBook.PageSet.Margins
        If prd.ShowDialog = Windows.Forms.DialogResult.OK Then

            printDoc = prd.Document
        Else
            Exit Sub
        End If
        covPages = 0

        AddHandler printDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
        AddHandler printDoc.EndPrint, AddressOf printDoc_EndPrint

        printRichText.Text = ""
        Dim start As Boolean
        defImage = New Bitmap(CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)
        Dim g As Graphics = Graphics.FromImage(defImage)
        g.FillRectangle(Brushes.Coral, 0, 0, defImage.Width, defImage.Height)
        printChapNo = 0

        curChap = CurrentBook.Chapters(printChapNo)
        printPageNo = 0

        curPage = curChap.Pages(printPageNo)
        If curPage.Type = PageType.Document Then
            printRichText.Rtf = curPage.Content

        End If

        m_nFirstCharOnPage = 0
        If CurrentBook.Covers.ContainsKey(ImageType.FrontCoverOut) Or CurrentBook.Covers.ContainsKey(ImageType.FrontCoverIn) Then
            printDoc.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
        Else
            printDoc.DefaultPageSettings.Margins = CurrentBook.PageSet.Margins
        End If
        fCout = False : fCin = False : bCin = False : bCin = False : pagesDone = False : pageNo = 0 : altPageNo = 0 : firstChap = True : bCout = False
        genPAgeNo = 0 'required for images
        printDoc.Print()
        StatMessage()
    End Sub
    Private m_nFirstCharOnPage As Integer
    Private Sub printDoc_BeginPrint(sender As Object, e As PrintEventArgs)
        m_nFirstCharOnPage = 0
    End Sub

    Dim fCout, fCin, bCin, bCout, pagesDone, firstChap As Boolean
    Dim pageNo As Integer = 0
    Dim genPAgeNo As Integer = 0
    Dim linePen As New Pen(Brushes.Black, 3)
    Dim defImage As Bitmap
    Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs)

        If fCout = False And CurrentBook.Covers.ContainsKey(ImageType.FrontCoverOut) Then
            '            e.Graphics.DrawImage(CurrentBook.Covers(ImageType.FrontCoverOut).Image, New Rectangle(0, 0, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height))
            e.Graphics.DrawImage(CurrentBook.Covers(ImageType.FrontCoverOut).Image, 0, 0, CurrentBook.PageSet.Size.Width + 1, CurrentBook.PageSet.Size.Height + 1)

            fCout = True
            If CurrentBook.Covers.ContainsKey(ImageType.FrontCoverIn) = False Then
                e.PageSettings.Margins = CurrentBook.PageSet.Margins
            End If
            e.HasMorePages = True
            Exit Sub
        End If
        If fCin = False And CurrentBook.Covers.ContainsKey(ImageType.FrontCoverIn) Then
            'e.Graphics.DrawImage(CurrentBook.Covers(ImageType.FrontCoverIn).Image, New Rectangle(0, 0, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height))
            e.Graphics.DrawImage(CurrentBook.Covers(ImageType.FrontCoverIn).Image, 0, 0, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)

            fCin = True
            e.PageSettings.Margins = CurrentBook.PageSet.Margins

            e.HasMorePages = True
            Exit Sub
        End If
        If bCin = False And CurrentBook.Covers.ContainsKey(ImageType.BackCoverIn) And pagesDone Then
            '  e.Graphics.DrawImage(CurrentBook.Covers(ImageType.BackCoverIn).Image, New Rectangle(0, 0, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height))
            e.Graphics.DrawImage(CurrentBook.Covers(ImageType.BackCoverIn).Image, 0, 0, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)

            bCin = True

            If CurrentBook.Covers.ContainsKey(ImageType.BackCoverOut) = False Then
                e.HasMorePages = False
            Else
                e.HasMorePages = True
            End If
            Exit Sub
        End If
        If bCout = False And CurrentBook.Covers.ContainsKey(ImageType.BackCoverOut) And pagesDone Then
            e.Graphics.DrawImage(CurrentBook.Covers(ImageType.BackCoverOut).Image, 0, 0, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)
            bCout = True
            e.HasMorePages = False
            Exit Sub
        End If


        e.PageSettings.PaperSize = New PaperSize(CurrentBook.PageSet.Name, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)
        e.PageSettings.Margins = CurrentBook.PageSet.Margins


        If curPage.Type = PageType.Image Then
            If My.Settings.PrintalternateNumberonChapter1 And firstChap = True Then

            Else
                pageNo += 1
            End If
            genPAgeNo += 1
            If curPage.Content Is Nothing Then
                e.Graphics.DrawImage(defImage, New Rectangle(New Point(0, 0), CurrentBook.PageSet.Size))
            Else
                e.Graphics.DrawImage(curPage.Content, New Point(0, 0))
            End If

            ShiftToNexTSet(e)
            Exit Sub
        Else

            m_nFirstCharOnPage = printRichText.FormatRange(False,
                                              e,
                                              m_nFirstCharOnPage,
                                              printRichText.TextLength)
            AddAdditionalElements(e)
            If (m_nFirstCharOnPage < printRichText.TextLength) Then
                e.HasMorePages = True
            Else
                ShiftToNexTSet(e)
            End If
        End If


    End Sub
    Dim pgFont As New Font("Arial", 8, FontStyle.Italic)
    Dim pad As Integer = 5
    Dim pageNumPad As Integer = 2

    Public Sub ShiftToNexTSet(e As PrintPageEventArgs)
        If printPageNo < curChap.Pages.Count - 1 Then
            printPageNo += 1
            curPage = curChap.Pages(printPageNo)
            If curPage.Type = PageType.Document Then
                printRichText.Rtf = curPage.Content
            End If
            m_nFirstCharOnPage = 0
            e.HasMorePages = True
        ElseIf printChapNo < CurrentBook.Chapters.Count - 1 Then
            printChapNo += 1
            firstChap = False
            curChap = CurrentBook.Chapters(printChapNo)
            printPageNo = 0
            curPage = curChap.Pages(printPageNo)
            If curPage.Type = PageType.Document Then
                printRichText.Rtf = curPage.Content
            End If
            m_nFirstCharOnPage = 0
            e.HasMorePages = True
        Else
            pagesDone = True
            If CurrentBook.Covers.ContainsKey(ImageType.BackCoverOut) Or CurrentBook.Covers.ContainsKey(ImageType.BackCoverOut) Then
                e.PageSettings.Margins = New Margins(0, 0, 0, 0)
                e.HasMorePages = True

            Else
                e.HasMorePages = False
            End If
        End If

    End Sub
    Private Sub AddAdditionalElements(e As PrintPageEventArgs)
        genPAgeNo += 1
        Select Case My.Settings.PrintFillRectangle
            Case FillRectangle.None
            Case FillRectangle.BottomOnly
                Dim pt1 As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Bottom / 2)
                Dim wid As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right
                Dim rect As New Rectangle(pt1, New Size(wid, e.PageSettings.Margins.Bottom / 2))
                e.Graphics.FillRectangle(New SolidBrush(My.Settings.PrintFillRectangleColor), rect)
            Case FillRectangle.TopAndBottom
                Dim pt1 As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Bottom / 2)
                Dim wid As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right
                Dim rect As New Rectangle(pt1, New Size(wid, e.PageSettings.Margins.Bottom / 2))
                e.Graphics.FillRectangle(New SolidBrush(My.Settings.PrintFillRectangleColor), rect)
                Dim pt3 As Point = New Point(e.PageSettings.Margins.Left, 0)

                rect = New Rectangle(pt3, New Size(wid, e.PageSettings.Margins.Top / 2))
                e.Graphics.FillRectangle(New SolidBrush(My.Settings.PrintFillRectangleColor), rect)
            Case FillRectangle.TopOnly
                Dim pt1 As Point = New Point(e.PageSettings.Margins.Left, 0)
                Dim wid As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right
                Dim rect As New Rectangle(pt1, New Size(wid, e.PageSettings.Margins.Top / 2))
                e.Graphics.FillRectangle(New SolidBrush(My.Settings.PrintFillRectangleColor), rect)
        End Select

        If (genPAgeNo Mod 2 = 0 And pageNo = 0) Or (pageNo > 0 And pageNo Mod 2 = 0) Then
            '2nd page 
            If My.Settings.PrintLeftImage And Not PrintLeftImageValue Is Nothing Then

                e.Graphics.DrawImage(PrintLeftImageValue, e.PageBounds)
            Else
                'Do nothing 
            End If

        Else
            If My.Settings.PrintRightImage And Not PrintRightImageValue Is Nothing Then
                Dim pt1 As Point = New Point(0, e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Bottom)
                e.Graphics.DrawImage(PrintRightImageValue, e.PageBounds)
            Else
                'Use the left image also on right
                If My.Settings.PrintLeftImage And Not PrintLeftImageValue Is Nothing Then

                    e.Graphics.DrawImage(PrintLeftImageValue, e.PageBounds)
                Else
                    'Do nothing 
                End If
            End If
        End If

        Select Case My.Settings.PrintBorder
            Case OutlinePattern.None
            Case OutlinePattern.BottomOnly
                Dim p1 As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Bottom)
                Dim p2 As Point = New Point(e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right, e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Bottom)
                e.Graphics.DrawLine(New Pen(New SolidBrush(My.Settings.PrintBorderColor), 1), p1, p2)
            Case OutlinePattern.Box
                Dim p3 As Point = New Point(e.PageSettings.Margins.Left - pad, e.PageSettings.Margins.Top)

                Dim rect As New Rectangle(p3, New Size(e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right + 2 * pad, e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Top - e.PageSettings.Margins.Bottom + 2 * pad))
                e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.Black), 1), rect)
            Case OutlinePattern.TopAndbottom
                Dim p1 As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Bottom)
                Dim p2 As Point = New Point(e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right, e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Bottom)
                Dim p3 As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.Margins.Top)
                Dim p4 As Point = New Point(e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right, e.PageSettings.Margins.Top)
                e.Graphics.DrawLine(New Pen(New SolidBrush(My.Settings.PrintBorderColor), 1), p1, p2)
                e.Graphics.DrawLine(New Pen(New SolidBrush(My.Settings.PrintBorderColor), 1), p3, p4)
            Case OutlinePattern.TopOnly
                Dim p1 As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.Margins.Top)
                Dim p2 As Point = New Point(e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right, e.PageSettings.Margins.Top)
                e.Graphics.DrawLine(New Pen(New SolidBrush(My.Settings.PrintBorderColor), 1), p1, p2)

        End Select


        'Numbers 
        If My.Settings.PrintalternateNumberonChapter1 And firstChap = True Then
            altPageNo += 1
            'We want to leave at least one pge blank aside from cover page
            'Back of cover =1, Next page 2, nextpagebackside=3

            If altPageNo > 2 Then
                PrintalternatePageNo(e)
            End If


        Else
            pageNo += 1
            PrintTitle(e)
            PrintPageNumber(e)
            PrintAuthor(e)
        End If

    End Sub
    Private Sub printDoc_EndPrint(sender As Object, e As PrintEventArgs)
        printRichText.FormatRangeDone()
        RemoveHandler printDoc.BeginPrint, AddressOf printDoc_BeginPrint
        RemoveHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
        RemoveHandler printDoc.EndPrint, AddressOf printDoc_EndPrint
        defImage = Nothing
    End Sub
    Private Sub PrintAuthor(e As PrintPageEventArgs)
        Dim author As String = CurrentBook.Author

        Select Case My.Settings.AuthorLoc
            Case StringLoc.None
            Case StringLoc.TopMiddle

                Dim size As SizeF = e.Graphics.MeasureString(author, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                Dim margtop As Single = e.PageSettings.Margins.Top
                Dim totWid As Single = e.PageSettings.PaperSize.Width
                Dim pgPoint As PointF = New Point(totWid / 2 - size.Width / 2, margtop - size.Height - pageNumPad)
                e.Graphics.DrawString(author, PrintMetaFont, Brushes.Black, pgPoint)
            Case StringLoc.BottomMiddle

                Dim size As SizeF = e.Graphics.MeasureString(author, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                Dim margBot As Single = e.PageSettings.Margins.Bottom
                Dim totWid As Single = e.PageSettings.PaperSize.Width
                Dim totHt As Single = e.PageSettings.PaperSize.Height
                Dim pgPoint As PointF = New Point(totWid / 2 - size.Width / 2, totHt - margBot + size.Height + pageNumPad)
                e.Graphics.DrawString(author, PrintMetaFont, Brushes.Black, pgPoint)
            Case StringLoc.TopCornerOut
                If pageNo Mod 2 = 0 Then

                    Dim size As SizeF = e.Graphics.MeasureString(author, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                    Dim pgPoint As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.Margins.Top - size.Height - pageNumPad)
                    e.Graphics.DrawString(author, PrintMetaFont, Brushes.Black, pgPoint)
                Else

                    Dim size As SizeF = e.Graphics.MeasureString(author, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                    Dim pgPoint As Point = New Point(e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - size.Width, e.PageSettings.Margins.Top - size.Height - pageNumPad)
                    e.Graphics.DrawString(author, PrintMetaFont, Brushes.Black, pgPoint)
                End If
            Case StringLoc.BottomCornerOut
                If pageNo Mod 2 = 0 Then

                    Dim size As SizeF = e.Graphics.MeasureString(author, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                    Dim pgPoint As Point = New Point(e.PageSettings.Margins.Left, e.PageBounds.Height - e.PageSettings.Margins.Bottom + size.Height + pageNumPad)
                    e.Graphics.DrawString(author, PrintMetaFont, Brushes.Black, pgPoint)
                Else

                    Dim size As SizeF = e.Graphics.MeasureString(author, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                    Dim pgPoint As Point = New Point(e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - size.Width, e.PageSettings.Bounds.Height - e.PageSettings.Margins.Bottom + size.Height + pageNumPad)
                    e.Graphics.DrawString(author, PrintMetaFont, Brushes.Black, pgPoint)

                End If
            Case StringLoc.TopCornerIn
                'have to be handled, as these are coded extra.
            Case StringLoc.BottomCornerIn
                'have to be handled, as these are coded extra.
        End Select
    End Sub
    Private Sub PrintTitle(e As PrintPageEventArgs)
        Dim titleText As String = PrintTitleText.Replace("#CHAP#", curChap.Name).Replace("#TITLE#", CurrentBook.Title)
        Select Case My.Settings.PrintTitleLoc
            Case StringLoc.None
            Case StringLoc.TopMiddle

                Dim size As SizeF = e.Graphics.MeasureString(titleText, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                Dim margtop As Single = e.PageSettings.Margins.Top
                Dim totWid As Single = e.PageSettings.PaperSize.Width
                Dim pgPoint As PointF = New Point(totWid / 2 - size.Width / 2, margtop - size.Height - pageNumPad)
                e.Graphics.DrawString(titleText, PrintMetaFont, Brushes.Black, pgPoint)
            Case StringLoc.BottomMiddle

                Dim size As SizeF = e.Graphics.MeasureString(titleText, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                Dim margBot As Single = e.PageSettings.Margins.Bottom
                Dim totWid As Single = e.PageSettings.PaperSize.Width
                Dim totHt As Single = e.PageSettings.PaperSize.Height
                Dim pgPoint As PointF = New Point(totWid / 2 - size.Width / 2, totHt - margBot + size.Height + pageNumPad)
                e.Graphics.DrawString(titleText, PrintMetaFont, Brushes.Black, pgPoint)
            Case StringLoc.TopCornerOut
                If pageNo Mod 2 = 0 Then

                    Dim size As SizeF = e.Graphics.MeasureString(titleText, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                    Dim pgPoint As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.Margins.Top - size.Height - pageNumPad)
                    e.Graphics.DrawString(titleText, PrintMetaFont, Brushes.Black, pgPoint)
                Else
                    titleText = printLeftTitleText.Replace("#CHAP#", curChap.Name).Replace("#TITLE#", CurrentBook.Title)
                    Dim size As SizeF = e.Graphics.MeasureString(titleText, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                    Dim pgPoint As Point = New Point(e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - size.Width, e.PageSettings.Margins.Top - size.Height - pageNumPad)
                    e.Graphics.DrawString(titleText, PrintMetaFont, Brushes.Black, pgPoint)
                End If
            Case StringLoc.BottomCornerOut
                If pageNo Mod 2 = 0 Then

                    Dim size As SizeF = e.Graphics.MeasureString(titleText, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                    Dim pgPoint As Point = New Point(e.PageSettings.Margins.Left, e.PageBounds.Height - e.PageSettings.Margins.Bottom + size.Height + pageNumPad)
                    e.Graphics.DrawString(titleText, PrintMetaFont, Brushes.Black, pgPoint)
                Else
                    titleText = printLeftTitleText.Replace("#CHAP#", curChap.Name).Replace("#TITLE#", CurrentBook.Title)
                    Dim size As SizeF = e.Graphics.MeasureString(titleText, PrintMetaFont, CurrentBook.PageSet.Size.Width)
                    Dim pgPoint As Point = New Point(e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - size.Width, e.PageSettings.Bounds.Height - e.PageSettings.Margins.Bottom + size.Height + pageNumPad)
                    e.Graphics.DrawString(titleText, PrintMetaFont, Brushes.Black, pgPoint)

                End If
            Case StringLoc.TopCornerIn
                'have to be handled, as these are coded extra.
            Case StringLoc.BottomCornerIn
                'have to be handled, as these are coded extra.
        End Select
    End Sub
    Dim altPageNo As Integer = 0
    Private Sub PrintalternatePageNo(e As PrintPageEventArgs)
        Dim pNo As String = GetRomanNumber(altPageNo)
        Select Case My.Settings.PrintPageNoLoc
            Case StringLoc.None
            Case StringLoc.TopMiddle

                Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                Dim margtop As Single = e.PageSettings.Margins.Top
                Dim totWid As Single = e.PageSettings.PaperSize.Width
                Dim pgPoint As PointF = New Point(totWid / 2 - size.Width / 2, margtop - size.Height - pageNumPad)
                e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
            Case StringLoc.BottomMiddle

                Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                Dim margBot As Single = e.PageSettings.Margins.Bottom
                Dim totWid As Single = e.PageSettings.PaperSize.Width
                Dim totHt As Single = e.PageSettings.PaperSize.Height
                Dim pgPoint As PointF = New Point(totWid / 2 - size.Width / 2, totHt - margBot + pageNumPad)
                e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
            Case StringLoc.TopCornerOut
                If altPageNo Mod 2 = 0 Then

                    Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                    Dim pgPoint As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.Margins.Top - size.Height - pageNumPad)
                    e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
                Else

                    Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                    Dim pgPoint As Point = New Point(e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - size.Width, e.PageSettings.Margins.Top - size.Height - pageNumPad)
                    e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
                End If
            Case StringLoc.BottomCornerOut
                If altPageNo Mod 2 = 0 Then

                    Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                    Dim pgPoint As Point = New Point(e.PageSettings.Margins.Left, e.PageBounds.Height - e.PageSettings.Margins.Bottom + size.Height + pageNumPad)
                    e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
                Else

                    Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                    Dim pgPoint As Point = New Point(e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - size.Width, e.PageSettings.Bounds.Height - e.PageSettings.Margins.Bottom + size.Height + pageNumPad)
                    e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)

                End If
            Case StringLoc.TopCornerIn
                'have to be handled, as these are coded extra.
            Case StringLoc.BottomCornerIn
                'have to be handled, as these are coded extra.
        End Select
    End Sub
    Private Sub PrintPageNumber(e As PrintPageEventArgs)
        Select Case My.Settings.PrintPageNoLoc
            Case StringLoc.None
            Case StringLoc.TopMiddle
                Dim pNo As String = PrintPageNoFormat.Replace("#PNO#", pageNo)
                Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                Dim margtop As Single = e.PageSettings.Margins.Top
                Dim totWid As Single = e.PageSettings.PaperSize.Width
                Dim pgPoint As PointF = New Point(totWid / 2 - size.Width / 2, margtop - size.Height - pageNumPad)
                e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
            Case StringLoc.BottomMiddle
                Dim pNo As String = PrintPageNoFormat.Replace("#PNO#", pageNo)
                Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                Dim margBot As Single = e.PageSettings.Margins.Bottom
                Dim totWid As Single = e.PageSettings.PaperSize.Width
                Dim totHt As Single = e.PageSettings.PaperSize.Height
                Dim pgPoint As PointF = New Point(totWid / 2 - size.Width / 2, totHt - margBot + pageNumPad)
                e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
            Case StringLoc.TopCornerOut
                If pageNo Mod 2 = 0 Then
                    Dim pNo As String = PrintPageNoFormat.Replace("#PNO#", pageNo)
                    Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                    Dim pgPoint As Point = New Point(e.PageSettings.Margins.Left, e.PageSettings.Margins.Top - size.Height - pageNumPad)
                    e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
                Else
                    Dim pNo As String = PrintPageNoFormat.Replace("#PNO#", pageNo)
                    Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                    Dim pgPoint As Point = New Point(e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - size.Width, e.PageSettings.Margins.Top - size.Height - pageNumPad)
                    e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
                End If
            Case StringLoc.BottomCornerOut
                If pageNo Mod 2 = 0 Then
                    Dim pNo As String = PrintPageNoFormat.Replace("#PNO#", pageNo)
                    Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                    Dim pgPoint As Point = New Point(e.PageSettings.Margins.Left, e.PageBounds.Height - e.PageSettings.Margins.Bottom + size.Height + pageNumPad)
                    e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)
                Else
                    Dim pNo As String = PrintPageNoFormat.Replace("#PNO#", pageNo)
                    Dim size As SizeF = e.Graphics.MeasureString(pNo, PrintMetaFont, 200)
                    Dim pgPoint As Point = New Point(e.PageSettings.Bounds.Width - e.PageSettings.Margins.Right - size.Width, e.PageSettings.Bounds.Height - e.PageSettings.Margins.Bottom + size.Height + pageNumPad)
                    e.Graphics.DrawString(pNo, PrintMetaFont, Brushes.Black, pgPoint)

                End If
            Case StringLoc.TopCornerIn
                'have to be handled, as these are coded extra.
            Case StringLoc.BottomCornerIn
                'have to be handled, as these are coded extra.
        End Select
    End Sub
    Private Sub tlstpChapterList_Click(sender As Object, e As EventArgs) Handles tlstpChapterList.Click
        Dim bl As New ChapterList
        bl.Show()
    End Sub

    Private Sub ctxMovetoChapters_Click(sender As Object, e As EventArgs) Handles ctxMovetoChapters.Click
        Try
            Dim cid As String = tvwBook.SelectedNode.Tag
            Dim ch As Chapter = CurrentBook.GetDraft(cid)
            CurrentBook.RemoveDraft(cid)
            CurrentBook.AddChapter(ch)
            tvwBook.SelectedNode.Remove()
            LoadChapters()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxMovetoDrafts_Click(sender As Object, e As EventArgs) Handles ctxMovetoDrafts.Click
        Try
            Dim cid As String = tvwBook.SelectedNode.Tag
            Dim ch As Chapter = CurrentBook.GetChapter(cid)
            CurrentBook.RemoveChapter(cid)
            CurrentBook.AddDraft(ch)
            tvwBook.SelectedNode.Remove()
            LoadDrafts()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Dim ppd As New PrintPreviewDialog

    End Sub

    Private Sub Canvas1_WordCountChanged() Handles Canvas1.WordCountChanged
        Dim totCount As Integer
        If CurrentBook Is Nothing Or CurrentBook.Chapters.Count = 0 Then
            tlstpWordCount.Text = ""
        End If
        For Each ch As Chapter In CurrentBook.Chapters
            totCount += ch.WordCount
        Next
        tlstpWordCount.Text = "Total Words: " & totCount

    End Sub


    Private Sub ctxCovers_Click(sender As Object, e As EventArgs) Handles ctxCovers.Click
        Try
            Dim ci As New CoverImages()
            ci.ShowDialog()
            LoadCovers()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxEmptyTrash_Click(sender As Object, e As EventArgs) Handles ctxEmptyTrash.Click
        Try
            If MsgBox("Do you really want to remove contents of trash?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub

            CurrentBook.Trash.Clear()
            LoadTrash()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub WebCtrl1_WebEvent(msg As String) Handles WebCtrl1.WebEvent
        StatMessage(msg)
    End Sub
    Private _lastIdeaID As Integer = 0
    Private Function GetNextIdeaID() As String
        _lastIdeaID += 1
        Dim finString As String = _lastIdeaID
        While finString.Length < 5
            finString += "0" & _lastIdeaID
        End While
        Return finString
    End Function
    Private Sub LoadIdeas()
        Try
            StatMessage("Loading ideas....")

            Dim noteFil As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\notes.xml"
            If IO.File.Exists(noteFil) = False Then
                Dim sw As New StreamWriter(noteFil)
                sw.WriteLine("<ideas version=""0.1"" lastid=""" & _lastIdeaID & """>")
                sw.WriteLine("</ideas>")
                sw.Close()
                sw.Dispose()

            End If
            Dim xmd As New Xml.XmlDocument
            xmd.Load(noteFil)
            Dim rtNod As XmlNode = xmd.FirstChild()
            Dim lastidAtt As XmlAttribute = rtNod.Attributes("lastid")
            _lastIdeaID = lastidAtt.Value
            For Each idNod As XmlNode In rtNod.ChildNodes
                Dim newnt As New Idea
                newnt.ID = idNod.Attributes("id").Value
                newnt.Content = idNod.InnerText
                newnt.Category = idNod.Attributes("category").Value
                newnt.SavedON = idNod.Attributes("savedon").Value
                Ideas.Add(newnt.ID, newnt)


            Next
            ReloadIdeas()
            StatMessage()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub ReloadIdeas()
        Dim tnd As TreeNode
        If tvwIdeas.Nodes.ContainsKey("!IDEAROOT!") Then
            tvwIdeas.Nodes("!IDEAROOT!").Nodes.Clear()
            tnd = tvwIdeas.Nodes("!IDEAROOT!")
        Else
            tnd = tvwIdeas.Nodes.Add("!IDEAROOT!", "Ideas", 0, 0)
            tnd.Tag = "!IDEAROOT!"
            tnd.NodeFont = nodeHeadFont
            tnd.Text = "Ideas"
            Dim tn1 As TreeNode = tvwIdeas.Nodes.Add("!HELP!", "Help", 3, 3)
            tn1.Tag = "!HELP!"
            tn1.NodeFont = nodeHeadFont
            tn1.Text = "Help"
            tvwIdeas.SelectedNode = tn1
        End If

        For Each newNT As Idea In Ideas.Values
            Dim catNode As TreeNode
            If tnd.Nodes.ContainsKey(newNT.Category) = False Then
                catNode = tnd.Nodes.Add(newNT.Category, newNT.Category, 1, 1)
                catNode.NodeFont = nodeHeadFont
                catNode.Text = newNT.Category
                catNode.Tag = newNT.Category
            Else
                catNode = tnd.Nodes(newNT.Category)
            End If
            Dim chNod As TreeNode = catNode.Nodes.Add(newNT.ID, newNT.Title, 2, 2)
            chNod.NodeFont = nodeEleFont
            chNod.Text = newNT.Title
            chNod.Tag = newNT.ID
        Next
        tnd.ExpandAll()
        tvwIdeas.SelectedNode = tvwIdeas.Nodes("!IDEAROOT!")
        tvwIdeas_AfterSelect(Nothing, New TreeViewEventArgs(tvwIdeas.SelectedNode))
    End Sub
    Private Sub SaveIdeas()
        Try
            StatMessage("Saving ideas...")
            Dim noteFil As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\notes.xml"
            Dim sw As New IO.StreamWriter(noteFil)
            Dim finString = "<ideas version=""0.1"" lastid=""" & _lastIdeaID & """>" & vbCrLf
            sw.Write(finString)
            For Each note As Idea In Ideas.Values
                note.WriteXML(sw)
            Next
            finString = "</ideas>"
            sw.Write(finString)
            sw.Close()
            sw.Dispose()
            StatMessage()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub ctxIdeas_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxIdeas.Opening
        Try
            Dim tvwnd As TreeNode = tvwIdeas.SelectedNode
            If tvwnd Is Nothing Then ctxIdeas.Enabled = False
            ctxIdeasNew.Enabled = False
            ctxIdeasNewCategory.Enabled = False
            ctxIdeasNewThought.Enabled = False
            ctxIdeasRemove.Enabled = False
            Select Case tvwnd.Tag
                Case "!IDEAROOT!"
                    ctxIdeasNew.Enabled = True
                    ctxIdeasNewCategory.Enabled = True
                Case "!HELP!"
                    'do nothing
                Case Else
                    Select Case tvwnd.Parent.Tag
                        Case "!IDEAROOT!"
                            ctxIdeasNew.Enabled = True
                            ctxIdeasNewThought.Enabled = True
                            ctxIdeasRemove.Enabled = True
                        Case Else
                            ctxIdeasRemove.Enabled = True
                    End Select
            End Select
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ctxIdeasNewThought_Click(sender As Object, e As EventArgs) Handles ctxIdeasNewThought.Click
        Try
            Dim id As New Idea()
            id.ID = GetNextIdeaID()
            If tvwIdeas.SelectedNode.Tag <> "!IDEAROOT!" Then
                id.Category = tvwIdeas.SelectedNode.Tag
            Else
                id.Category = "!Default"
            End If
            Ideas.Add(id.ID, id)
            ReloadIdeas()
            tvwIdeas.SelectedNode = tvwIdeas.Nodes("!IDEAROOT!").Nodes(id.Category)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub tvwIdeas_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvwIdeas.AfterSelect
        pnlMainEditControls.Hide()
        WhichTreeSelected = "IDEAS"
        Dim tvwnd As TreeNode = tvwIdeas.SelectedNode
        If tvwnd.Tag = "!HELP!" Then
            BookDetailsCtl1.Show()
            BookDetailsCtl1.Dock = DockStyle.Fill
            pnlMainEditControls.Hide()
            IdeaContainer1.Hide()
        Else
            IdeaContainer1.Show()
            IdeaContainer1.Dock = DockStyle.Fill
            BookDetailsCtl1.Hide()
            pnlMainEditControls.Hide()
        End If
        Select Case tvwnd.Tag
            Case "!IDEAROOT!"
                IdeaContainer1.LoadCategories(Ideas)
            Case "!HELP!"
                'do nothing...
            Case Else
                Select Case tvwnd.Parent.Tag
                    Case "!IDEAROOT!"
                        IdeaContainer1.LoadIdeas(tvwnd.Tag, Ideas)
                    Case Else

                End Select
        End Select

    End Sub

    Private Sub ctxIdeasNewCategory_Click(sender As Object, e As EventArgs) Handles ctxIdeasNewCategory.Click
        Try
XT:
            Dim catname As String = InputBox("Provide the category name", "Category")
            If String.IsNullOrEmpty(catname) Then Exit Sub
            If tvwIdeas.Nodes("!IDEAROOT!").Nodes.ContainsKey(catname) Then
                GoTo XT
            End If
            Dim id As New Idea()
            id.Category = catname
            id.ID = GetNextIdeaID()
            Ideas.Add(id.ID, id)
            ReloadIdeas()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub tvwIdeas_GotFocus(sender As Object, e As EventArgs) Handles tvwIdeas.GotFocus
        tvwIdeas_AfterSelect(Nothing, New TreeViewEventArgs(tvwIdeas.SelectedNode))
    End Sub

    ''' <summary>
    ''' This is required for word Export
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    'Private Sub tlstpExport_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim mW As New Microsoft.Office.Interop.Word.Application
    '        mW.Visible = True
    '        Dim wordDoc As Microsoft.Office.Interop.Word.Document = mW.Documents.Add

    '        For Each c As Chapter In CurrentBook.Chapters
    '            For Each p As Page In c.Pages
    '                If p.Type = PageType.Document Then
    '                    If p.Content Is Nothing Then
    '                        Clipboard.SetText("", TextDataFormat.Text)
    '                    Else
    '                        Clipboard.SetText(p.Content, TextDataFormat.Rtf)
    '                    End If

    '                Else
    '                    If p.Content Is Nothing Then
    '                        Clipboard.SetText("NO IMAGE", TextDataFormat.Text)
    '                    Else
    '                        Clipboard.SetImage(p.Content)
    '                    End If

    '                End If
    '                mW.Selection.Paste()
    '                mW.Selection.InsertBreak(7)
    '            Next
    '        Next

    '        wordDoc.PageSetup.PaperSize = GetWdPaperSize()
    '        With wordDoc.PageSetup
    '            .LeftMargin = CurrentBook.PageSet.Margins.Left
    '            .RightMargin = CurrentBook.PageSet.Margins.Right
    '            .TopMargin = CurrentBook.PageSet.Margins.Top
    '            .BottomMargin = CurrentBook.PageSet.Margins.Bottom
    '        End With
    '    Catch ex As Exception
    '        DE(ex)
    '    End Try

    'End Sub
    'Private Function GetWdPaperSize() As Microsoft.Office.Interop.Word.WdPaperSize
    '    Return Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA5
    'End Function

    Private Sub tlstpPrintPreview_Click(sender As Object, e As EventArgs) Handles tlstpPrintPreview.Click
        If CurrentBook.Chapters.Count = 0 Then
            MsgBox("At least one chapter must be present for a print", MsgBoxStyle.Information)
            Exit Sub
        End If
        StatMessage("Preparing for print previewdialog...")
        Dim prd As New PrintPreviewDialog
        'Dim pSt As New PrinterSettings
        'Dim pageSet As New PageSettings(pSt)
        'prd.AllowPrintToFile = True
        'pageSet.PaperSize = New PaperSize(CurrentBook.PageSet.Name, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)
        'pageSet.Margins = CurrentBook.PageSet.Margins
        'prd.PrinterSettings = pSt
        prd.Document = New PrintDocument
        prd.Document.DefaultPageSettings.PaperSize = New PaperSize(CurrentBook.PageSet.Name, CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)
        prd.Document.DefaultPageSettings.Margins = CurrentBook.PageSet.Margins
        printDoc = prd.Document
        AddHandler printDoc.BeginPrint, AddressOf printDoc_BeginPrint
        AddHandler printDoc.PrintPage, AddressOf printDoc_PrintPage
        AddHandler printDoc.EndPrint, AddressOf printDoc_EndPrint
        printRichText.Text = ""
        Dim start As Boolean
        defImage = New Bitmap(CurrentBook.PageSet.Size.Width, CurrentBook.PageSet.Size.Height)
        Dim g As Graphics = Graphics.FromImage(defImage)
        g.FillRectangle(Brushes.Coral, 0, 0, defImage.Width, defImage.Height)
        printChapNo = 0

        curChap = CurrentBook.Chapters(printChapNo)
        printPageNo = 0

        curPage = curChap.Pages(printPageNo)

        If curPage.Type = PageType.Document Then
            printRichText.Rtf = curPage.Content
        Else

        End If


        m_nFirstCharOnPage = 0
        If CurrentBook.Covers.ContainsKey(ImageType.FrontCoverOut) Or CurrentBook.Covers.ContainsKey(ImageType.FrontCoverIn) Then
            printDoc.DefaultPageSettings.Margins = New Margins(0, 0, 0, 0)
        Else
            printDoc.DefaultPageSettings.Margins = CurrentBook.PageSet.Margins
        End If
        fCout = False : fCin = False : bCin = False : bCin = False : pagesDone = False : pageNo = 0 : altPageNo = 0 : firstChap = True : bCout = False
        If prd.ShowDialog = Windows.Forms.DialogResult.OK Then
            printDoc = prd.Document
        Else
            Exit Sub
        End If
        covPages = 0




        'printDoc.Print()
        'StatMessage()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles tlstpPageDesign.Click
        Dim ps As New PrintSettings
        ps.ShowDialog()
    End Sub

    Private Sub SaveasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Desk1_ChapterNameChanged(c As Chapter, isTrash As Boolean) Handles Desk1.ChapterNameChanged
        Select Case isTrash
            Case True
                tvwBook.Nodes("!ROOT!").Nodes("!TRSROOT!").Nodes(c.ID).Text = c.Name
            Case False
                Select Case c.IsDraft
                    Case True
                        tvwBook.Nodes("!ROOT!").Nodes("!DRFROOT!").Nodes(c.ID).Text = c.Name
                    Case False
                        tvwBook.Nodes("!ROOT!").Nodes("!CHPROOT!").Nodes(c.ID).Text = c.Name
                End Select


        End Select
    End Sub

    Private Sub ctxIdeasRemove_Click(sender As Object, e As EventArgs) Handles ctxIdeasRemove.Click
        Try
            Dim tvwN As TreeNode = tvwIdeas.SelectedNode

            If tvwN.Tag = "!IDEAROOT!" Then Exit Sub
            Dim res As MsgBoxResult
            Select Case tvwN.Parent.Tag
                Case "!IDEAROOT!"
                    res = MsgBox("This will delete all ideas under this category, do you want to proceed?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
                    If res = MsgBoxResult.No Then Exit Select
                    DeleteIdeas(tvwN.Tag)
                    ReloadIdeas()
                Case Else
                    Select Case tvwN.Parent.Parent.Tag
                        Case "!IDEAROOT!"
                            res = MsgBox("Do you want to delete the selected idea?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
                            If res = MsgBoxResult.No Then Exit Select
                            DeleteIdea(tvwN.Tag)
                            ReloadIdeas()
                        Case Else

                    End Select
            End Select

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub DeleteIdeas(cat As String)
        Dim lst As New List(Of String)
        For Each id As Idea In Ideas.Values
            If id.Category = cat Then
                lst.Add(id.ID)
            End If
        Next
        For Each id As String In lst
            Ideas.Remove(id)
        Next
    End Sub
    Private Sub DeleteIdea(id As String)
        Ideas.Remove(id)
    End Sub


    Private Sub ctxNew_Click(sender As Object, e As EventArgs) Handles ctxNew.Click

    End Sub

    Private Sub ctxShowIndex_Click(sender As Object, e As EventArgs) Handles ctxShowIndex.Click
        Dim sh As New IndexContents
        sh.Show()
    End Sub

    Private Sub Canvas1_Load(sender As Object, e As EventArgs) Handles Canvas1.Load

    End Sub

    Private Sub tlstpReorderPages_Click(sender As Object, e As EventArgs) Handles tlstpReorderPages.Click
        Try
            If selecteDChapter Is Nothing Then Exit Sub
            StatMessage("Reordering pages")
            Dim pl As New PageList(selecteDChapter)
            pl.ShowDialog()
            If pl.IsChanged Then
                Canvas1.ShowChapter(selecteDChapter, selecteDChapter.IsDraft)
            End If
            StatMessage()
        Catch ex As Exception
            DE(ex)
            StatMessage()
        End Try
    End Sub

    Private Sub tlstpExport_Click(sender As Object, e As EventArgs) Handles tlstpExport.Click
        Dim sfd As New SaveFileDialog
        Dim fname As String

        With sfd
            .Filter = "Rich text files(*.rtf)|*.rtf"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                fname = .FileName
            Else
                Exit Sub
            End If
        End With
        Try



            StatMessage("Exporting content to rtf into " & fname)
            SaveRichContent(fname)

        Catch ex As Exception
            DE(ex)
            StatMessage()

        End Try
    End Sub


    Private Sub SaveRichContent(fname As String)


        Dim tx As String = Clipboard.GetText()
        Dim im As Image = Clipboard.GetImage
        '  printRichText.Show()
        '   printRichText.BringToFront()
        ' printRichText.Dock = DockStyle.Fill
        Try
            printRichText.Clear()
            printRichText.SelectionStart = 0
            For Each c As Chapter In CurrentBook.Chapters
                StatMessage("Writing chapter " & c.Name)
                Debug.Print(c.Name)
                For Each p As Page In c.Pages
                    If p.Type = PageType.Document Then
                        If p.Content Is Nothing Then
                            Clipboard.SetText("", TextDataFormat.Text) 'This casse doesn't arise.... but just kept 
                        Else
                            Clipboard.SetText(p.Content, TextDataFormat.Rtf)
                        End If

                    Else
                        If p.Content Is Nothing Then
                            Clipboard.SetText("NO IMAGE", TextDataFormat.Text)
                        Else
                            Clipboard.SetImage(p.Content)
                        End If

                    End If

                    If Clipboard.ContainsData(DataFormats.Rtf) Or Clipboard.ContainsImage Then
                        Debug.Print("[CONTAINS]" & c.Name & "Page " & p.Seq)
                        printRichText.Paste()
                        Threading.Thread.Sleep(100)
                        printRichText.SelectionStart = printRichText.Text.Length
                        printRichText.SelectedRtf = "{\rtf1 \par \page}"
                        printRichText.SelectionStart = printRichText.Text.Length
                    Else
                        Debug.Print("[DOESNT]" & c.Name & "Page " & p.Seq)
                    End If

                Next
            Next
            printRichText.SaveFile(fname)
            printRichText.Clear()
        Catch ex As Exception
            DE(ex)
        Finally
            If String.IsNullOrEmpty(tx) = False Then
                Clipboard.SetText(tx)
            End If
            If Not im Is Nothing Then
                Clipboard.SetImage(im)
            End If
        End Try

    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub


    'Private Sub tvwBook_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwBook.NodeMouseClick
    '    Try
    '        'If WhichTreeSelected = "BOOK" Then
    '        '    'tHIS IS REQUIRED FOR NOT REFRESHING CONTENTS
    '        '    If e.Node.Tag = WhichNodeSelected Then Exit Sub
    '        'End If

    '        WhichTreeSelected = "BOOK"
    '        IdeaContainer1.Hide()
    '        pnlMainEditControls.Show()
    '        BookDetailsCtl1.Hide()
    '        ResearchContainer1.Hide()
    '        ResearchElementsDesk1.Hide()
    '        tlstpReorderPages.Enabled = False
    '        pnlMainEditControls.Dock = DockStyle.Fill
    '        selecteDChapter = Nothing
    '        WhichNodeSelected = e.Node.Tag
    '        Select Case e.Node.Tag
    '            'Case "!HELP!"
    '            '    BookDetailsCtl1.Show()
    '            '    BookDetailsCtl1.Dock = DockStyle.Fill
    '            '    Desk1.Hide()
    '            '    Canvas1.Hide()
    '            '    WebCtrl1.Hide()
    '            '    ResearchContainer1.Hide()
    '            '    CoverCanvas1.Hide()
    '            Case "!ROOT!"
    '                BookDetailsCtl1.Hide()
    '                Desk1.Hide()
    '                WebCtrl1.Hide()
    '                Canvas1.Show()
    '                CoverCanvas1.Hide()
    '                ResearchContainer1.Hide()
    '                BookCalenar1.Hide()
    '                Canvas1.Dock = DockStyle.Fill
    '                StatMessage("Loading outline")
    '                Canvas1.LoadOutline()
    '                tlstpBookProps.Enabled = True
    '                ResearchElementsDesk1.Hide()
    '                StatMessage()
    '            Case "!CHPROOT!"
    '                BookDetailsCtl1.Hide()
    '                Desk1.Show()
    '                Desk1.Dock = DockStyle.Fill
    '                Canvas1.Hide()
    '                WebCtrl1.Hide()
    '                BookCalenar1.Hide()
    '                CoverCanvas1.Hide()
    '                StatMessage("Loading chapter...")
    '                Desk1.LoadChapters(False)
    '                StatMessage()
    '                ResearchElementsDesk1.Hide()
    '                ResearchContainer1.Hide()
    '            Case "!DRFROOT!"
    '                BookDetailsCtl1.Hide()
    '                Desk1.Show()
    '                Desk1.Dock = DockStyle.Fill
    '                Canvas1.Hide()
    '                WebCtrl1.Hide()
    '                CoverCanvas1.Hide()
    '                BookCalenar1.Hide()
    '                StatMessage("Loading drafts...")
    '                Desk1.LoadChapters(True)
    '                ResearchContainer1.Hide()
    '                ResearchElementsDesk1.Hide()
    '                StatMessage()
    '            Case "!RCHROOT!"
    '                BookDetailsCtl1.Hide()
    '                Desk1.Hide()
    '                ResearchContainer1.Show()
    '                BookCalenar1.Hide()
    '                ResearchContainer1.Dock = DockStyle.Fill
    '                ResearchContainer1.LoadResearChCategories()
    '                ResearchElementsDesk1.Hide()
    '                Canvas1.Hide()
    '                WebCtrl1.Hide()
    '                CoverCanvas1.Hide()
    '            Case "!BRWROOT!"
    '                BookDetailsCtl1.Hide()
    '                Desk1.Hide()
    '                Canvas1.Hide()
    '                WebCtrl1.Show()
    '                BookCalenar1.Hide()
    '                CoverCanvas1.Hide()
    '                WebCtrl1.Dock = DockStyle.Fill
    '                WebCtrl1.BringToFront()
    '                ResearchContainer1.Hide()
    '                ResearchElementsDesk1.Hide()
    '            Case "!TRSROOT!"
    '                BookDetailsCtl1.Hide()
    '                Desk1.Show()
    '                Desk1.Dock = DockStyle.Fill
    '                Desk1.LoadTrash()
    '                Canvas1.Hide()
    '                BookCalenar1.Hide()
    '                WebCtrl1.Hide()
    '                CoverCanvas1.Hide()
    '                ResearchContainer1.Hide()
    '                ResearchElementsDesk1.Hide()
    '            Case "!COVROOT!"
    '                BookDetailsCtl1.Hide()
    '                Desk1.Show()
    '                Canvas1.Hide()
    '                WebCtrl1.Hide()
    '                CoverCanvas1.Show()
    '                BookCalenar1.Hide()
    '                CoverCanvas1.Dock = DockStyle.Fill
    '                CoverCanvas1.ShowAllCovers()
    '                ResearchContainer1.Hide()
    '                ResearchElementsDesk1.Hide()
    '            Case "!LOGROOT!"
    '                BookDetailsCtl1.Hide()
    '                Desk1.Hide()
    '                Canvas1.Hide()
    '                BookCalenar1.Show()
    '                BookCalenar1.Dock = DockStyle.Fill
    '                BookCalenar1.showLog()
    '                CoverCanvas1.Hide()
    '                WebCtrl1.Hide()
    '                ResearchContainer1.Hide()
    '                ResearchElementsDesk1.Hide()
    '            Case Else
    '                Select Case e.Node.Parent.Tag
    '                    Case "!DRFROOT!"
    '                        If e.Node.ImageIndex = 5 Then
    '                            BookDetailsCtl1.Hide()
    '                            Desk1.Hide()
    '                            ResearchElementsDesk1.Hide()
    '                            WebCtrl1.Hide()
    '                            Canvas1.Show()
    '                            CoverCanvas1.Hide()
    '                            BookCalenar1.Hide()
    '                            Canvas1.Dock = DockStyle.Fill
    '                            StatMessage("Loading the draft " & e.Node.Text)
    '                            Canvas1.ShowChapter(CurrentBook.GetDraft(e.Node.Tag), True)
    '                            selecteDChapter = CurrentBook.GetDraft(e.Node.Tag)
    '                            StatMessage()
    '                            tlstpReorderPages.Enabled = True
    '                        End If
    '                    Case "!CHPROOT!"
    '                        If e.Node.ImageIndex = 2 Then
    '                            BookDetailsCtl1.Hide()
    '                            ResearchElementsDesk1.Hide()
    '                            Desk1.Hide()
    '                            WebCtrl1.Hide()
    '                            CoverCanvas1.Hide()
    '                            Canvas1.Show()
    '                            BookCalenar1.Hide()
    '                            Canvas1.Dock = DockStyle.Fill
    '                            StatMessage("Loading the chapter " & e.Node.Text)
    '                            Canvas1.ShowChapter(CurrentBook.GetChapter(e.Node.Tag), False)
    '                            selecteDChapter = CurrentBook.GetChapter(e.Node.Tag)
    '                            StatMessage()
    '                            tlstpReorderPages.Enabled = True
    '                        End If
    '                    Case "!COVROOT!"
    '                        BookDetailsCtl1.Hide()
    '                        ResearchElementsDesk1.Hide()
    '                        Desk1.Hide()
    '                        WebCtrl1.Hide()
    '                        CoverCanvas1.Show()
    '                        Canvas1.Hide()
    '                        BookCalenar1.Hide()
    '                        CoverCanvas1.ShowImage(e.Node.Tag.SPLIT(":")(0))
    '                        StatMessage()
    '                    Case "!RCHROOT!"
    '                        Select Case e.Node.Text
    '                            Case "Images"
    '                                ResearchElementsDesk1.Show()
    '                                ResearchElementsDesk1.Dock = DockStyle.Fill
    '                                ResearchElementsDesk1.ShowRobjects("IMAGE")
    '                                BookDetailsCtl1.Hide()
    '                                ResearchContainer1.Hide()
    '                                Desk1.Hide()
    '                                BookCalenar1.Hide()
    '                                WebCtrl1.Hide()
    '                                CoverCanvas1.Hide()
    '                            Case "Documents"
    '                                ResearchElementsDesk1.Show()
    '                                ResearchElementsDesk1.Dock = DockStyle.Fill
    '                                ResearchElementsDesk1.ShowRobjects("DOC")
    '                                BookDetailsCtl1.Hide()
    '                                ResearchContainer1.Hide()
    '                                Desk1.Hide()
    '                                BookCalenar1.Hide()
    '                                WebCtrl1.Hide()
    '                                CoverCanvas1.Hide()
    '                            Case "Text files"
    '                                ResearchElementsDesk1.Show()
    '                                ResearchElementsDesk1.Dock = DockStyle.Fill
    '                                ResearchElementsDesk1.ShowRobjects("TEXT")
    '                                BookDetailsCtl1.Hide()
    '                                ResearchContainer1.Hide()
    '                                Desk1.Hide()
    '                                WebCtrl1.Hide()
    '                                BookCalenar1.Hide()
    '                                CoverCanvas1.Hide()
    '                        End Select

    '                    Case "!TRSROOT!"
    '                        If Desk1.Visible And Desk1.IsTrash Then Exit Select
    '                        BookDetailsCtl1.Hide()
    '                        Desk1.Show()
    '                        Desk1.Dock = DockStyle.Fill
    '                        Desk1.LoadTrash()
    '                        Canvas1.Hide()
    '                        BookCalenar1.Hide()
    '                        WebCtrl1.Hide()
    '                        CoverCanvas1.Hide()
    '                        ResearchContainer1.Hide()
    '                        ResearchElementsDesk1.Hide()
    '                End Select


    '        End Select

    '    Catch ex As Exception
    '        DE(ex)
    '        StatMessage()
    '    End Try
    'End Sub

    Private Sub ResearchContainer1_RObjecTCategoryClicked(cat As String) Handles ResearchContainer1.RObjecTCategoryClicked
        Select Case cat
            Case "IMAGE"
                tvwBook.SelectedNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHIMGROOT!")
            Case "DOC"
                tvwBook.SelectedNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHDOCROOT!")
            Case "TEXT"
                tvwBook.SelectedNode = tvwBook.Nodes("!ROOT!").Nodes("!RCHROOT!").Nodes("!RCHTXTROOT!")
        End Select
    End Sub
End Class
