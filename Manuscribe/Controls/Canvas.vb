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
Imports System.Text.RegularExpressions

Friend Class Canvas
    'Dim installedFonts As New System.Drawing.Text.InstalledFontCollection
    'Dim fontFamilies() As FontFamily = installedFonts.Families
    '  Private _Struct As BookStructure
    Dim rt As New RichTextBox
    Private CurrentChapter As Chapter
    Dim CurrentPageID As String
    Private _isDraft As Boolean
    Private WithEvents tmr As New Timer
    Private isOutline As Boolean
    Event WordCountChanged()
    '  Private _forJustEditing As Boolean
    Private _pType As PageType

    'Public Property JustEditing As Boolean
    '    Get
    '        Return _forJustEditing
    '    End Get
    '    Set(value As Boolean)
    '        _forJustEditing = value
    '        If JustEditing Then
    '            butAddPage.Enabled = False
    '            butDeletePage.Enabled = False
    '        Else
    '            butAddPage.Enabled = True
    '            butDeletePage.Enabled = True
    '        End If
    '    End Set
    'End Property

    Public Sub RefreshStyles(Optional SelInx As Integer = 0)
        cboStyles.Items.Clear()
        For Each s As StyleSet In AllStyles.Values
            cboStyles.Items.Add(s.Name)
        Next
        If cboStyles.Items.Count > 0 Then cboStyles.SelectedIndex = 0
        If cboStyles.Items.Count > (SelInx + 1) Then cboStyles.SelectedIndex = SelInx
        tmr.Interval = 2000
    End Sub


    'Public Property Struct As BookStructure
    '    Get
    '        Return _Struct
    '    End Get
    '    Set(value As BookStructure)
    '        _Struct = value
    '        Select Case Struct
    '            Case BookStructure.FreeFlow
    '                butAddPage.Enabled = False
    '                butDeletePage.Enabled = False
    '                If CurrentBook Is Nothing Then Exit Select
    '                If bookLoading Then Exit Property


    '                For Each ch As Chapter In CurrentBook.Chapters
    '                    Dim firstPage As Page
    '                    For Each pg As Page In ch.Pages
    '                        If pg.Seq = 1 And pg.Type = PageType.Image Then
    '                            pg.Type = PageType.Document
    '                            firstPage = pg

    '                        ElseIf pg.Seq = 1 And pg.Type = PageType.Document Then

    '                            firstPage = pg
    '                            rt.Rtf = firstPage.Content
    '                        ElseIf pg.Type = PageType.Document Then
    '                            rt.SelectionStart = rt.Text.Length
    '                            rt.SelectionLength = 0
    '                            rt.SelectedRtf = "{\rtf1 \par \page}"
    '                            rt.SelectionStart = rt.Text.Length
    '                            rt.SelectionLength = 0
    '                            rt.SelectedRtf = pg.Content
    '                        Else
    '                            Continue For
    '                        End If
    '                    Next
    '                    ch.Pages.Clear()
    '                    firstPage.Content = rt.Rtf
    '                    ch.Pages.Add(firstPage)
    '                    Clear()

    '                Next
    '                For Each ch As Chapter In CurrentBook.Drafts
    '                    Dim firstPage As Page
    '                    For Each pg As Page In ch.Pages
    '                        If pg.Seq = 1 And pg.Type = PageType.Image Then
    '                            pg.Type = PageType.Document
    '                            firstPage = pg

    '                        ElseIf pg.Seq = 1 And pg.Type = PageType.Document Then

    '                            firstPage = pg
    '                            rt.Rtf = firstPage.Content
    '                        ElseIf pg.Type = PageType.Document Then
    '                            rt.SelectionStart = rt.Text.Length
    '                            rt.SelectionLength = 0
    '                            rt.SelectedRtf = "{\rtf1 \par \page}"
    '                            rt.SelectionStart = rt.Text.Length
    '                            rt.SelectionLength = 0
    '                            rt.SelectedRtf = pg.Content
    '                        Else
    '                            Continue For
    '                        End If
    '                    Next
    '                    ch.Pages.Clear()
    '                    firstPage.Content = rt.Rtf
    '                    ch.Pages.Add(firstPage)
    '                    Clear()
    '                Next
    '                If CurrentChapter Is Nothing Then Exit Select
    '                LoaDChapter()
    '            Case BookStructure.Pagified
    '                If JustEditing Then
    '                    butAddPage.Enabled = False
    '                    butDeletePage.Enabled = False
    '                Else
    '                    butAddPage.Enabled = True
    '                    butDeletePage.Enabled = False
    '                End If
    '                rtbMain.PageSet = CurrentBook.PageSet

    '        End Select
    '    End Set
    'End Property
    Public Sub Clear()
        RTFBox.Clear()
        RTFBox.ClearUndo()
        CurrentPageID = ""
        RTFBox.AutoWordSelection = True
        RTFBox.SelectedRtf = Nothing
        lblWordCount.Text = 0
        CurrentChapter = Nothing
        RTFBox.Modified = False
        isOutline = False
        For Each c As Control In pnlPageThumbs.Controls
            RemoveHandler CType(c, RadioButton).CheckedChanged, AddressOf pageTabClick

        Next
        CurrentChapter = Nothing
        CurrentPageID = -1
        pnlPageThumbs.Controls.Clear()
        tmr.Enabled = False
        pnlImageContent.BackgroundImage = Nothing
        butShowSpellChecker.Enabled = False
    End Sub
    Public Sub ShowChapter(c As Chapter, isDraft As Boolean)
        Clear()

        '  JustEditing = False
        tmr.Enabled = False
        CurrentChapter = c
        LoaDChapter()
        RTFBox.Modified = False
        butSavePage.Enabled = False
        tmr.Enabled = True
        butTypeSwitch.Enabled = True
        butAddPage.Enabled = True
        butDeletePage.Enabled = True
        Me._isDraft = isDraft
    End Sub
    Public Sub LoadOutline()

        Clear()

        isOutline = True
        tmr.Enabled = True
        '   JustEditing = True
        RTFBox.Rtf = CurrentBook.Outline
        RTFBox.Modified = False
        rtbMain.Show()
        pnlImageContent.Hide()
        butSavePage.Enabled = False
        butDeletePage.Enabled = False
        tmr.Enabled = True
        pnlTopToolbar.Enabled = True
        butTypeSwitch.Enabled = False
        butAddPage.Enabled = False
        butDeletePage.Enabled = False
        butTypeSwitch.Image = My.Resources.doctype
        tlstpIndexes.Enabled = False
        butShowSpellChecker.Enabled = True
    End Sub
    Private Sub LoaDChapter()
        Try
            pnlImageContent.Hide()

            rtbMain.Show()


            For Each pg As Page In CurrentChapter.Pages
                 
                AddPageTab(pg)
            Next
            If pnlPageThumbs.Controls.Count > 1 Then
                butDeletePage.Enabled = True
            Else
                butDeletePage.Enabled = False
            End If
            CType(pnlPageThumbs.Controls(pnlPageThumbs.Controls.Count - 1), RadioButton).Checked = True
        Catch ex As Exception
            DE(ex)
        End Try

    End Sub
    Private Function AddPageTab(pg As Page) As RadioButton
        Try
            Dim bt As New RadioButton
            With bt
                .FlatStyle = FlatStyle.Popup
                .BackColor = Color.White
                .Image = My.Resources.page
                .ImageAlign = ContentAlignment.MiddleLeft
                .Text = GetPageNameandSeq(pg)
                .Tag = pg.ID
                .Height = 30
                .Appearance = Appearance.Button
                .Dock = DockStyle.Top
                bt.TextAlign = ContentAlignment.MiddleRight
                .Font = New Font("Arial Narrow", 9, FontStyle.Bold)
                pnlPageThumbs.Controls.Add(bt)
                bt.BringToFront()
            End With

            AddHandler bt.CheckedChanged, AddressOf pageTabClick


            CurrentPageID = bt.Tag
            lblWordCount.Text = "Words: " & CurrentChapter.WordCount
            If pnlPageThumbs.Controls.Count > 1 Then
                butDeletePage.Enabled = True
            Else
                butDeletePage.Enabled = False
            End If
            Return bt
        Catch ex As Exception
            DE(ex)
        End Try
    End Function
    Private Sub pageTabMouseRightClick()


        Dim pd As New Pagedef()
        pd.txtName.Text = CurrentChapter.GetPageByID(CurrentPageID).Name
        If CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Document Then
            pd.optDocument.Checked = True

        Else
            pd.optImage.Checked = True
        End If

        If pd.ShowDialog = DialogResult.OK Then
            If CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Document And pd.optImage.Checked Or
                CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Image And pd.optDocument.Checked Then
                If MsgBox("Do you really want to change the type of page? You will loose the old content on this page", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                If CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Document Then
                    CurrentChapter.GetPageByID(CurrentPageID).Content = Nothing
                    CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Image
                    CurrentChapter.GetPageByID(CurrentPageID).Name = pd.txtName.Text
                Else
                    CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Document
                    CurrentChapter.GetPageByID(CurrentPageID).Content = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 #FONTNAME#;}}"
                    CurrentChapter.GetPageByID(CurrentPageID).Name = pd.txtName.Text
                End If
            Else
                CurrentChapter.GetPageByID(CurrentPageID).Name = pd.txtName.Text
            End If
        End If

    End Sub
    Dim curBut As RadioButton
    Dim pageLoad As Boolean
    Private Sub pageTabClick(sender As Object, e As EventArgs)
        If CType(sender, RadioButton).Checked Then
            pageLoad = True
            curBut = sender
            CType(sender, RadioButton).BackColor = Color.Gray
            CType(sender, RadioButton).FlatAppearance.BorderSize = 0
            CType(sender, RadioButton).Image = My.Resources.editnote
            If CurrentChapter.GetPageByID(CType(sender, RadioButton).Tag).Type = PageType.Document Then
                RTFBox.Clear()
                RTFBox.Rtf = CurrentChapter.GetPageByID(CType(sender, RadioButton).Tag).Content
                RTFBox.Refresh()
                rtbMain.Show()
                pnlTopToolbar.Enabled = True
                pnlImageContent.Hide()

            Else
                pnlImageContent.Show()
                rtbMain.Hide()
                pnlTopToolbar.Enabled = False
                pnlImageContent.BackgroundImage = CurrentChapter.GetPageByID(CType(sender, RadioButton).Tag).Content
                ' pnlImageContent.BackgroundImageLayout = ImageLayout.Zoom

            End If
            txtTags.Text = String.Join(",", CurrentChapter.GetPageByID(CType(sender, RadioButton).Tag).Tags.ToArray)
            RTFBox.ClearUndo()
            RTFBox.Modified = False
            CurrentPageID = CType(sender, RadioButton).Tag
            butSavePage.Enabled = False
            If CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Document Then
                butTypeSwitch.Image = My.Resources.doctype
                butShowSpellChecker.Enabled = True
            Else
                butTypeSwitch.Image = My.Resources.imagetype
                butShowSpellChecker.Enabled = False
            End If
            pageLoad = False
            tlstpIndexes.Enabled = True
        Else
            CType(sender, RadioButton).BackColor = Color.White
            CType(sender, RadioButton).FlatAppearance.BorderSize = 1
            CType(sender, RadioButton).Image = My.Resources.page
        End If
    End Sub

    Private Function GetPadddedPage(p As Integer) As String
        Dim f As String = p
        While f.Length < 3
            f = "0" & f
        End While
        Return f
    End Function
    Public Property PageSet As PageTemplate
        Get
            Return rtbMain.PageSet
        End Get
        Set(value As PageTemplate)
            rtbMain.PageSet = value
            Dim g As Graphics = pnlImageContent.CreateGraphics
            pnlImageContent.Size = New Size(value.Size.Width * g.DpiX / 100, value.Size.Height * g.DpiY / 100)
        End Set
    End Property
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For I As Integer = 6 To 100
            cboFontSize.Items.Add(I)
        Next
        Array.ForEach(fontFamilies, Sub(F) cboFontName.Items.Add(F.Name))
        cboFontName.Text = RTFBox.Font.FontFamily.Name
        cboFontSize.Text = RTFBox.Font.Size
        RTFBox.Modified = False
    End Sub

    Private Sub rtbMain_ContentModified() Handles rtbMain.ContentModified
        butSavePage.Enabled = True
    End Sub

    Private Sub rtbMain_IndexAdditionRequested(s As String) Handles rtbMain.IndexAdditionRequested
        If CurrentChapter.GetPageByID(CurrentPageID).IndexEntries.Contains(s) = False Then
            CurrentChapter.GetPageByID(CurrentPageID).IndexEntries.Add(s)
        End If
    End Sub


    Private Sub rtbMain_Resize(sender As Object, e As EventArgs) Handles rtbMain.Resize
        AdjustPage()
    End Sub
    Private Sub AdjustPage()

        If tlstpSeamlessedit.Checked Then
            If pnlContainer.ClientRectangle.Width > pnlImageContent.Width Then
                pnlImageContent.Location = New Point(pnlContainer.Width / 2 - pnlImageContent.Width / 2, pnlImageContent.Top)
            Else
                pnlImageContent.Location = New Point(0, pnlImageContent.Top)
            End If
            If pnlContainer.ClientRectangle.Height > pnlImageContent.Height Then
                pnlImageContent.Location = New Point(pnlImageContent.Left, pnlContainer.Height / 2 - pnlImageContent.Height / 2)
            Else
                pnlImageContent.Location = New Point(pnlImageContent.Left, 0)
            End If
        Else
            If pnlContainer.ClientRectangle.Width > rtbMain.Width Then
                rtbMain.Location = New Point(pnlContainer.Width / 2 - rtbMain.Width / 2, rtbMain.Top)
                pnlImageContent.Location = New Point(pnlContainer.Width / 2 - pnlImageContent.Width / 2, pnlImageContent.Top)
            Else
                rtbMain.Location = New Point(0, rtbMain.Top)
                pnlImageContent.Location = New Point(0, pnlImageContent.Top)
            End If
            If pnlContainer.ClientRectangle.Height > rtbMain.Height Then
                rtbMain.Location = New Point(rtbMain.Left, pnlContainer.Height / 2 - rtbMain.Height / 2)
                pnlImageContent.Location = New Point(pnlImageContent.Left, pnlContainer.Height / 2 - pnlImageContent.Height / 2)
            Else
                rtbMain.Location = New Point(rtbMain.Left, 0)
                pnlImageContent.Location = New Point(pnlImageContent.Left, 0)
            End If

        End If

    End Sub

    Private Sub pnlContainer_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub pnlContainer_Resize(sender As Object, e As EventArgs) Handles pnlContainer.Resize
        AdjustPage()
    End Sub
    Public ReadOnly Property RTFBox As AdvRichTextBox
        Get
            Return rtbMain.RTBox
        End Get
    End Property



    Private Sub tlstpCut_Click(sender As Object, e As EventArgs) Handles tlstpCut.Click
        On Error Resume Next
        If String.IsNullOrEmpty(RTFBox.SelectedRtf) = False Then
            Clipboard.SetData(TextDataFormat.Rtf, RTFBox.SelectedRtf)
            rtbMain.RTBox.SelectedRtf = ""
        End If
    End Sub

    Private Sub tlstpCopy_Click(sender As Object, e As EventArgs) Handles tlstpCopy.Click
        On Error Resume Next
        If String.IsNullOrEmpty(RTFBox.SelectedRtf) = False Then
            Clipboard.SetData(TextDataFormat.Rtf, RTFBox.SelectedRtf)
        End If
    End Sub

    Private Sub tlstpPaste_Click(sender As Object, e As EventArgs) Handles tlstpPaste.Click
        On Error Resume Next
        Dim RTF As String = Clipboard.GetData(TextDataFormat.Rtf)
        RTFBox.SelectedRtf = RTF
    End Sub

    Private Sub tlstpUndo_Click(sender As Object, e As EventArgs) Handles tlstpUndo.Click
        On Error Resume Next
        RTFBox.Undo()
    End Sub

    Private Sub tlstpRedo_Click(sender As Object, e As EventArgs) Handles tlstpRedo.Click
        On Error Resume Next
        RTFBox.Redo()
    End Sub

    Private Sub tlstpBold_Click(sender As Object, e As EventArgs) Handles tlstpBold.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        Dim F As Font = RTFBox.SelectionFont

        RTFBox.SelectionFont = New Font(F.Name, F.Size, F.Style Xor FontStyle.Bold)


    End Sub

    Private Sub tlstpItalic_Click(sender As Object, e As EventArgs) Handles tlstpItalic.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        Dim F As Font = RTFBox.SelectionFont

        RTFBox.SelectionFont = New Font(F.Name, F.Size, F.Style Xor FontStyle.Italic)
    End Sub

    Private Sub tlstpUnderline_Click(sender As Object, e As EventArgs) Handles tlstpUnderline.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        Dim F As Font = RTFBox.SelectionFont

        RTFBox.SelectionFont = New Font(F.Name, F.Size, F.Style Xor FontStyle.Underline)
    End Sub

    Private Sub tlstpStrikeThrough_Click(sender As Object, e As EventArgs) Handles tlstpStrikeThrough.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        Dim F As Font = RTFBox.SelectionFont

        RTFBox.SelectionFont = New Font(F.Name, F.Size, F.Style Xor FontStyle.Strikeout)
    End Sub

    Private Sub tlstpBackColor_Click(sender As Object, e As EventArgs) Handles tlstpBackColor.Click
        On Error Resume Next
        Dim cp As New VitalLogic.Controls.ColorWheel
        cp.Location = MousePosition
        cp.Color = IIf(RTFBox.SelectionBackColor = Nothing, Color.White, RTFBox.SelectionBackColor)
        If cp.ShowDialog = DialogResult.OK Then
            RTFBox.SelectionBackColor = cp.Color
        End If


    End Sub

    '
    'End Sub

    Private Sub tlstpNumbullets_Click(sender As Object, e As EventArgs) Handles tlstpNumbullets.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        RTFBox.SelectionBullet = Not RTFBox.SelectionBullet
        RTFBox.BulletIndent = 15
        If RTFBox.SelectionBullet Then
            SendKeys.Send("^+(L)")
        End If
    End Sub

    Private Sub tlstpBullets_Click(sender As Object, e As EventArgs) Handles tlstpBullets.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        RTFBox.SelectionBullet = Not RTFBox.SelectionBullet
        RTFBox.BulletIndent = 15
    End Sub

    Private Sub tlstpIndentRight_Click(sender As Object, e As EventArgs) Handles tlstpIndentRight.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        RTFBox.SelectionIndent += 30
    End Sub

    Private Sub tlstpForeColor_Click(sender As Object, e As EventArgs) Handles tlstpForeColor.Click
        On Error Resume Next
        Dim cp As New VitalLogic.Controls.ColorWheel
        cp.Color = IIf(RTFBox.SelectionColor = Nothing, Color.Black, RTFBox.SelectionColor)
        cp.Location = MousePosition
        If cp.ShowDialog = DialogResult.OK Then
            RTFBox.SelectionColor = cp.Color
        End If
    End Sub

    Private Sub tlstpLeft_Click(sender As Object, e As EventArgs) Handles tlstpLeft.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        RTFBox.SelectionIndent -= 30
        If RTFBox.SelectionIndent < 0 Then RTFBox.SelectionIndent = 0
    End Sub

    Private Sub tlstpAlignLeft_Click(sender As Object, e As EventArgs) Handles tlstpAlignLeft.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        RTFBox.SelectionAlignment = TextAlign.Left
    End Sub

    Private Sub tlstpAlignCenter_Click(sender As Object, e As EventArgs) Handles tlstpAlignCenter.Click
        On Error Resume Next
        RTFBox.SelectionAlignment = TextAlign.Center
    End Sub

    Private Sub tlstpAlignRight_Click(sender As Object, e As EventArgs) Handles tlstpAlignRight.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        RTFBox.SelectionAlignment = TextAlign.Right
    End Sub

    Private Sub tlstpJustify_Click(sender As Object, e As EventArgs) Handles tlstpJustify.Click
        On Error Resume Next
        If dontChange Then Exit Sub
        RTFBox.SelectionAlignment = TextAlign.Justify
    End Sub

    Private Sub cboFontSize_Click(sender As Object, e As EventArgs) Handles cboFontSize.Click

    End Sub

    Private Sub cboFontName_Click(sender As Object, e As EventArgs) Handles cboFontName.Click

    End Sub

    Private Sub cboFontName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFontName.SelectedIndexChanged
        On Error Resume Next
        If dontChange Then Exit Sub
        Dim f As Font
        If RTFBox.SelectionFont Is Nothing Then
            f = RTFBox.Font
        Else
            f = RTFBox.SelectionFont
        End If
        RTFBox.SelectionFont = New Font(cboFontName.Text, f.Size, f.Style)
    End Sub

    Private Sub cboFontSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFontSize.SelectedIndexChanged
        On Error Resume Next
        If dontChange Then Exit Sub
        Dim f As Font
        If RTFBox.SelectionFont Is Nothing Then
            f = New Font("Verdana", 12, FontStyle.Regular)
        Else
            f = RTFBox.SelectionFont
        End If
        RTFBox.SelectionFont = New Font(f.Name, CInt(cboFontSize.Text), f.Style)
    End Sub
    Dim dontChange As Boolean
    Private Sub rtbMain_SelectionChanged() Handles rtbMain.SelectionChanged
        If RTFBox.SelectedRtf Is Nothing Then
            tlstpBold.Checked = False
            tlstpItalic.Checked = False
            tlstpUnderline.Checked = False
            tlstpStrikeThrough.Checked = False
            cboFontName.Text = RTFBox.Font.FontFamily.Name
            cboFontSize.Text = RTFBox.Font.Size
            tlstpNumbullets.Checked = False
            tlstpBullets.Checked = False
            tlstpAlignCenter.Checked = False
            tlstpAlignLeft.Checked = False
            tlstpAlignRight.Checked = False
        Else
            Dim ft As Font = RTFBox.SelectionFont
            If ft Is Nothing Then ft = RTFBox.Font
            dontChange = True
            tlstpBold.Checked = ft.Bold
            tlstpItalic.Checked = ft.Italic
            tlstpUnderline.Checked = ft.Underline
            tlstpStrikeThrough.Checked = ft.Strikeout
            cboFontName.Text = ft.FontFamily.Name
            cboFontSize.Text = ft.Size

            tlstpBullets.Checked = RTFBox.SelectionBullet
            Select Case RTFBox.SelectionAlignment
                Case TextAlign.Left
                    tlstpAlignLeft.Checked = True
                    tlstpAlignCenter.Checked = False
                    tlstpAlignRight.Checked = False
                Case HorizontalAlignment.Center
                    tlstpAlignLeft.Checked = False
                    tlstpAlignCenter.Checked = True
                    tlstpAlignRight.Checked = False
                Case HorizontalAlignment.Right
                    tlstpAlignLeft.Checked = False
                    tlstpAlignCenter.Checked = False
                    tlstpAlignRight.Checked = True
            End Select
            dontChange = False
        End If
    End Sub

    Private Sub tlstpShowGrid_Click(sender As Object, e As EventArgs) Handles tlstpShowGrid.Click

    End Sub


    Private Sub tlstpPageBreak_Click(sender As Object, e As EventArgs) Handles tlstpPageBreak.Click


        RTFBox.SelectedRtf = "{\rtf1 \par \page}"

    End Sub

    Private Sub butAddPage_Click(sender As Object, e As EventArgs) Handles butAddPage.Click
        Try
            Dim pt As New Pagedef
            Dim ptype As PageType
            If pt.ShowDialog = DialogResult.OK Then
                If pt.optDocument.Checked Then
                    ptype = PageType.Document
                Else
                    ptype = PageType.Image
                End If
            Else
                Exit Sub
            End If
            Dim pg As New Page(ptype)
            pg.Name = pt.txtName.Text
            If ptype = PageType.Document Then pg.Content.Replace("#FONTNAME#", "Arial")
            CurrentChapter.AddPage(pg)
            Dim bt As RadioButton = AddPageTab(pg)
            'Dim bt As New RadioButton
            'With bt
            '    .FlatStyle = FlatStyle.Popup
            '    .BackColor = Color.AliceBlue
            '    .Image = My.Resources.page
            '    .ImageAlign = ContentAlignment.MiddleLeft

            '    .TextAlign = ContentAlignment.MiddleRight
            '    .Tag = pg.ID
            '    .Appearance = Appearance.Button
            '    .Dock = DockStyle.Top
            '    .Font = New Font("Arial Narrow", 9, FontStyle.Bold)

            '    bt.Text = GetPageNameandSeq(pg)
            '    pnlPageThumbs.Controls.Add(bt)
            '    If pnlPageThumbs.Controls.Count > 1 Then
            '        butDeletePage.Enabled = True
            '    Else
            '        butDeletePage.Enabled = False
            '    End If
            'End With
            ' bt.BringToFront()
            bt.Checked = True
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butDeletePage_Click(sender As Object, e As EventArgs) Handles butDeletePage.Click
        Try
            If String.IsNullOrEmpty(CurrentPageID) Then Exit Sub
            If pnlPageThumbs.Controls.Count <= 1 Then
                MsgBox("The default page cannot be removed", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("Do you want to remove the page " & CurrentChapter.GetPageByID(CurrentPageID).Seq, MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub

            CurrentChapter.RemovePage(CurrentPageID)

            For Each ctl As Control In pnlPageThumbs.Controls
                If ctl.Tag = CurrentPageID Then
                    CurrentPageID = ""
                    RTFBox.Clear()
                    RTFBox.ClearUndo()
                    RemoveHandler CType(ctl, RadioButton).CheckedChanged, AddressOf pageTabClick


                    pnlPageThumbs.Controls.Remove(ctl)
                    If pnlPageThumbs.Controls.Count > 0 Then
                        CType(pnlPageThumbs.Controls(0), RadioButton).Checked = True
                    End If
                    Exit Sub
                End If
            Next
            CType(pnlPageThumbs.Controls(0), RadioButton).Checked = True
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butSavePage_Click(sender As Object, e As EventArgs) Handles butSavePage.Click
        Try
            If isOutline Then
                If CurrentBook Is Nothing Then Exit Sub
                CurrentBook.Outline = RTFBox.Rtf

                RTFBox.Modified = False
                butSavePage.Enabled = False

                Exit Sub
            End If
            If String.IsNullOrEmpty(CurrentPageID) Then Exit Sub
            CurrentChapter.GetPageByID(CurrentPageID).Tags.Clear()
            CurrentChapter.GetPageByID(CurrentPageID).Tags.AddRange(txtTags.Text.Split(","))
            If CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Image Then
                butSavePage.Enabled = False
                CurrentChapter.GetPageByID(CurrentPageID).SampleText = "[IMAGE]"
                RaiseEvent WordCountChanged()
                Exit Sub

            End If
            CurrentChapter.GetPageByID(CurrentPageID).Content = RTFBox.Rtf
            CurrentChapter.GetPageByID(CurrentPageID).Text = RTFBox.Text
            Dim tx As String = RTFBox.Text
            If tx.Length > 100 Then
                tx = tx.Substring(0, 100) & "..."
            End If
            CurrentChapter.GetPageByID(CurrentPageID).SampleText = tx
            CurrentChapter.GetPageByID(CurrentPageID).WordCount = RTFBox.Text.Split(New Char() {" ", vbLf, vbTab, "|", ")", "(", "{", "}", "\", "/", "?", ",", ".", "@", "#", "%", "&", "*", "-", "+", "=", "[", "]", "!"}).Count
            RTFBox.Modified = False
            butSavePage.Enabled = False
            lblWordCount.Text = "Words: " & CurrentChapter.WordCount

            RaiseEvent WordCountChanged()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub butHeader_Click(sender As Object, e As EventArgs)
        If RTFBox.SelectedRtf Is Nothing Then Exit Sub
        Dim s As Style = SystemStyles(cboStyles.Text).Styles(CType(sender, ToolStripButton).Text)
        Dim f As Font = New Font(s.FName, s.FSize, s.FStyle)
        RTFBox.SelectionFont = f
        RTFBox.SelectionColor = s.FColor
    End Sub

    Private Sub tmr_Tick(sender As Object, e As EventArgs) Handles tmr.Tick
        If CurrentBook Is Nothing Then Exit Sub
        If isOutline Then
            If RTFBox.Modified Then
                CurrentBook.Outline = RTFBox.Rtf
                RTFBox.Modified = False
                butSavePage.Enabled = False
                RaiseEvent WordCountChanged()
                Exit Sub
            End If
        End If
        If CurrentChapter Is Nothing Then Exit Sub
        If String.IsNullOrEmpty(CurrentPageID) Then Exit Sub
        If CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Image Then
            CurrentChapter.GetPageByID(CurrentPageID).SampleText = "[IMAGE]"
            Exit Sub
        End If
        If RTFBox.Modified Then
            CurrentChapter.GetPageByID(CurrentPageID).Content = RTFBox.Rtf
            CurrentChapter.GetPageByID(CurrentPageID).Text = RTFBox.Text
            RTFBox.Modified = False
            butSavePage.Enabled = False
            CurrentChapter.GetPageByID(CurrentPageID).WordCount = Regex.Replace(RTFBox.Text, "\s+", " ").Trim().Split(New Char() {" ", vbLf, vbTab, "|", ")", "(", "{", "}", "\", "/", "?", ",", ".", "@", "#", "%", "&", "*", "-", "+", "=", "[", "]", "!"}).Count
            lblWordCount.Text = "Words: " & CurrentChapter.WordCount
            RaiseEvent WordCountChanged()
        End If
        CurrentChapter.GetPageByID(CurrentPageID).Tags.Clear()
        CurrentChapter.GetPageByID(CurrentPageID).Tags.AddRange(txtTags.Text.Split(","))
    End Sub

    Dim copiedStyle As Font
    Private Sub tlstpCopyStyle_Click(sender As Object, e As EventArgs) Handles tlstpCopyStyle.Click
        On Error Resume Next
        If RTFBox.SelectionFont Is Nothing Then Exit Sub
        copiedStyle = RTFBox.SelectionFont
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub


    Private Sub tlstpPasteStyle_Click(sender As Object, e As EventArgs) Handles tlstpPasteStyle.Click
        On Error Resume Next
        RTFBox.SelectionFont = copiedStyle
    End Sub

    Private Sub butMaintainStyle_Click(sender As Object, e As EventArgs) Handles butMaintainStyle.Click
        Dim sm As New StylesDef
        sm.ShowDialog()
        ClearStyleControls()
        RefreshStyles()
    End Sub

    Dim cStyleSet As StyleSet
    Private Sub cboStyles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStyles.SelectedIndexChanged
        Try
            If cboStyles.SelectedIndex = -1 Then cStyleSet = Nothing : ClearStyleControls()
            ClearStyleControls()
            cStyleSet = AllStyles(cboStyles.SelectedItem)
            AddStyleControls()
            My.Settings.StyleSet = cboStyles.SelectedIndex
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub AddStyleControls()
        If cStyleSet Is Nothing Then Exit Sub
        For Each c As String In cStyleSet.Styles.Keys
            Dim b As New Button
            b.Text = c
            b.Font = New Font("Arial", 10, FontStyle.Bold)
            b.FlatStyle = FlatStyle.Popup
            b.Width = 40
            pnlStyleControls.Controls.Add(b)
            b.Tag = c
            b.Dock = DockStyle.Top
            b.BringToFront()
            AddHandler b.Click, AddressOf StyleButtonClicked
        Next
    End Sub
    Private Sub ClearStyleControls()
        For Each b As Button In pnlStyleControls.Controls
            RemoveHandler b.Click, AddressOf StyleButtonClicked
        Next
        pnlStyleControls.Controls.Clear()
    End Sub
    Public Sub StyleButtonClicked(sender As Object, e As EventArgs)
        If cStyleSet Is Nothing Then Exit Sub
        RTFBox.SelectionFont = New Font(cStyleSet.Styles(sender.tag).FName, cStyleSet.Styles(sender.tag).FSize, cStyleSet.Styles(sender.tag).FStyle)
        RTFBox.SelectionColor = cStyleSet.Styles(sender.tag).FColor
        RTFBox.SelectionBackColor = IIf(cStyleSet.Styles(sender.tag).ApplyBackColor, cStyleSet.Styles(sender.tag).BColor, Nothing)
    End Sub

    Dim ft As New Font("Lucida Console", 24, FontStyle.Regular)
    Private Sub pnlImageContent_Paint(sender As Object, e As PaintEventArgs) Handles pnlImageContent.Paint
        If pnlImageContent.BackgroundImage Is Nothing Then

            Dim szf As SizeF = e.Graphics.MeasureString("         NO IMAGE" & vbCrLf & "Double click to add image", ft)
            Dim left, top As Integer
            If pnlImageContent.Width < szf.Width Then
                left = 0
            Else
                left = pnlImageContent.Width / 2 - szf.Width / 2
            End If
            If pnlImageContent.Height < szf.Height Then
                top = 0
            Else
                top = pnlImageContent.Height / 2 - szf.Height / 2
            End If
            e.Graphics.DrawString("         NO IMAGE" & vbCrLf & "Double click to add image", ft, Brushes.LightGray, New PointF(left, top))
        Else

        End If
    End Sub

    Private Sub pnlImageContent_DoubleClick(sender As Object, e As EventArgs) Handles pnlImageContent.DoubleClick
        Dim ofd As New OpenFileDialog
        With ofd
            .Filter = "Image files(*.jpg,*.bmp,*.png)|*.jpg;*.jpeg;*.bmp;*.png"
            If .ShowDialog = DialogResult.OK Then
                Dim IM As Image = Bitmap.FromFile((.FileName))
                CurrentChapter.GetPageByID(CurrentPageID).Content = IM
                pnlImageContent.BackgroundImage = IM
                pnlImageContent.BackgroundImageLayout = ImageLayout.Stretch
            End If
        End With
    End Sub

    Private Sub pnlContainer_Paint_1(sender As Object, e As PaintEventArgs) Handles pnlContainer.Paint

    End Sub

    Private Sub butTypeSwitch_Click(sender As Object, e As EventArgs) Handles butTypeSwitch.Click
        pageTabMouseRightClick()
        curBut.Text = GetPageNameandSeq(CurrentChapter.GetPageByID(CurrentPageID))
        If CurrentChapter.GetPageByID(CurrentPageID).Type = PageType.Image Then
            butTypeSwitch.Image = My.Resources.imagetype
            pageTabClick(curBut, Nothing)
        Else
            butTypeSwitch.Image = My.Resources.doctype
            pageTabClick(curBut, Nothing)

        End If
    End Sub
    Dim allowedLength As Integer = 20
    Private Function GetPageNameandSeq(pg As Page)
        Dim pName As String = pg.Name
        If pg.Name.Length > allowedLength Then
            pName = "(" & pName.Substring(0, allowedLength) & ")-" & GetPadddedPage(pg.Seq)
        ElseIf pName.Length > 0 Then
            pName = "(" & pName & ")-" & GetPadddedPage(pg.Seq)
        Else
            pName = GetPadddedPage(pg.Seq)
        End If
        Return pName
    End Function
    Private Sub txtTags_TextChanged(sender As Object, e As EventArgs) Handles txtTags.TextChanged
        If Not pageLoad Then
            butSavePage.Enabled = True
            tmr.Enabled = True
        End If
    End Sub

    Private Sub tlstpIndexes_Click(sender As Object, e As EventArgs) Handles tlstpIndexes.Click
        Dim ixe As New Indexes(CurrentChapter.GetPageByID(CurrentPageID))
        ixe.ShowDialog()

    End Sub

    Private Sub tlstpSeamlessedit_Click(sender As Object, e As EventArgs) Handles tlstpSeamlessedit.Click

    End Sub

    Private Sub tlstpSeamlessedit_CheckedChanged(sender As Object, e As EventArgs) Handles tlstpSeamlessedit.CheckedChanged
        rtbMain.SeamlessEditing = tlstpSeamlessedit.Checked
        AdjustPage()
        My.Settings.SeamlessEdititng = tlstpSeamlessedit.Checked
    End Sub

    Private Sub tlstpShowScroll_CheckedChanged(sender As Object, e As EventArgs) Handles tlstpShowScroll.CheckedChanged
        If tlstpShowScroll.Checked Then
            RTFBox.ScrollBars = RichTextBoxScrollBars.Vertical
        Else
            RTFBox.ScrollBars = RichTextBoxScrollBars.None
        End If
        My.Settings.ScrollBar = RTFBox.ScrollBars
    End Sub

    Private Sub tlstpShowGrid_CheckedChanged(sender As Object, e As EventArgs) Handles tlstpShowGrid.CheckedChanged
        rtbMain.ShowMargins = tlstpShowGrid.Checked
        My.Settings.ShowMargin = rtbMain.ShowMargins
    End Sub



    Private Sub butShowSpellChecker_Click(sender As Object, e As EventArgs) Handles butShowSpellChecker.Click
        rtbMain.ShowSpellChecker()
    End Sub
 
    Private Sub tlstpSpellCheck_CheckedChanged(sender As Object, e As EventArgs) Handles tlstpSpellCheck.CheckedChanged
        rtbMain.RTBox.ShowMistakes = tlstpSpellCheck.Checked
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        RTFBox.FindForm.ShowDialog()
    End Sub
End Class
