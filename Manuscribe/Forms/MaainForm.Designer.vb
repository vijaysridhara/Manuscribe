<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim PageTemplate1 As VitalLogic.Applications.PageTemplate = New VitalLogic.Applications.PageTemplate()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tlstpNewBook = New System.Windows.Forms.ToolStripButton()
        Me.tlstpOpenBook = New System.Windows.Forms.ToolStripButton()
        Me.tlstpSave = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tlstpExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpPrintPreview = New System.Windows.Forms.ToolStripButton()
        Me.tlstpPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpReorderPages = New System.Windows.Forms.ToolStripButton()
        Me.tlstpChapterList = New System.Windows.Forms.ToolStripButton()
        Me.tlstpPageDesign = New System.Windows.Forms.ToolStripButton()
        Me.tlstpBookProps = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpWordCount = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tlstpLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tlstpMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.tvwBook = New System.Windows.Forms.TreeView()
        Me.ctxTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxNewChapter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxNewDraft = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxCovers = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxShowIndex = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMovetoChapters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMovetoDrafts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxMoveToTrash = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ctxRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEmptyTrash = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tvwIdeas = New System.Windows.Forms.TreeView()
        Me.ctxIdeas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxIdeasNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxIdeasNewThought = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxIdeasNewCategory = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxIdeasRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlMainEditControls = New System.Windows.Forms.Panel()
        Me.printRichText = New VitalLogic.Applications.AdvRichTextBox()
        Me.BookCalenar1 = New VitalLogic.Applications.BookCalenar()
        Me.ResearchElementsDesk1 = New VitalLogic.Applications.ResearchElementsDesk()
        Me.ResearchContainer1 = New VitalLogic.Applications.ResearchContainer()
        Me.WebCtrl1 = New VitalLogic.Applications.WebCtrl()
        Me.Canvas1 = New VitalLogic.Applications.Canvas()
        Me.CoverCanvas1 = New VitalLogic.Applications.CoverCanvas()
        Me.Desk1 = New VitalLogic.Applications.Desk()
        Me.IdeaContainer1 = New VitalLogic.Applications.IdeaContainer()
        Me.BookDetailsCtl1 = New VitalLogic.Applications.BookDetailsCtl()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ctxTree.SuspendLayout()
        Me.ctxIdeas.SuspendLayout()
        Me.pnlMainEditControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlstpNewBook, Me.tlstpOpenBook, Me.tlstpSave, Me.tlstpExport, Me.ToolStripSeparator1, Me.tlstpPrintPreview, Me.tlstpPrint, Me.ToolStripSeparator2, Me.tlstpReorderPages, Me.tlstpChapterList, Me.tlstpPageDesign, Me.tlstpBookProps, Me.ToolStripSeparator3, Me.tlstpWordCount})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1206, 31)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tlstpNewBook
        '
        Me.tlstpNewBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpNewBook.Image = Global.VitalLogic.Applications.My.Resources.Resources.addbook
        Me.tlstpNewBook.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpNewBook.Name = "tlstpNewBook"
        Me.tlstpNewBook.Size = New System.Drawing.Size(28, 28)
        Me.tlstpNewBook.ToolTipText = "New book"
        '
        'tlstpOpenBook
        '
        Me.tlstpOpenBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpOpenBook.Image = Global.VitalLogic.Applications.My.Resources.Resources.openbook
        Me.tlstpOpenBook.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpOpenBook.Name = "tlstpOpenBook"
        Me.tlstpOpenBook.Size = New System.Drawing.Size(28, 28)
        Me.tlstpOpenBook.ToolTipText = "Open book"
        '
        'tlstpSave
        '
        Me.tlstpSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpSave.Enabled = False
        Me.tlstpSave.Image = Global.VitalLogic.Applications.My.Resources.Resources.save
        Me.tlstpSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpSave.Name = "tlstpSave"
        Me.tlstpSave.Size = New System.Drawing.Size(37, 28)
        Me.tlstpSave.Text = "ToolStripButton4"
        Me.tlstpSave.ToolTipText = "Save book"
        '
        'tlstpExport
        '
        Me.tlstpExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpExport.Enabled = False
        Me.tlstpExport.Image = Global.VitalLogic.Applications.My.Resources.Resources.word
        Me.tlstpExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpExport.Name = "tlstpExport"
        Me.tlstpExport.Size = New System.Drawing.Size(28, 28)
        Me.tlstpExport.Text = "ToolStripButton5"
        Me.tlstpExport.ToolTipText = "Export to rtf(for Wordpad)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tlstpPrintPreview
        '
        Me.tlstpPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpPrintPreview.Enabled = False
        Me.tlstpPrintPreview.Image = Global.VitalLogic.Applications.My.Resources.Resources.preview
        Me.tlstpPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpPrintPreview.Name = "tlstpPrintPreview"
        Me.tlstpPrintPreview.Size = New System.Drawing.Size(28, 28)
        Me.tlstpPrintPreview.Text = "ToolStripButton1"
        Me.tlstpPrintPreview.ToolTipText = "Print preview"
        '
        'tlstpPrint
        '
        Me.tlstpPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpPrint.Enabled = False
        Me.tlstpPrint.Image = Global.VitalLogic.Applications.My.Resources.Resources.print
        Me.tlstpPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpPrint.Name = "tlstpPrint"
        Me.tlstpPrint.Size = New System.Drawing.Size(28, 28)
        Me.tlstpPrint.Text = "ToolStripButton2"
        Me.tlstpPrint.ToolTipText = "Print"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'tlstpReorderPages
        '
        Me.tlstpReorderPages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpReorderPages.Enabled = False
        Me.tlstpReorderPages.Image = Global.VitalLogic.Applications.My.Resources.Resources.page_shuffle
        Me.tlstpReorderPages.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpReorderPages.Name = "tlstpReorderPages"
        Me.tlstpReorderPages.Size = New System.Drawing.Size(28, 28)
        Me.tlstpReorderPages.ToolTipText = "Reorder pages in current chapter"
        '
        'tlstpChapterList
        '
        Me.tlstpChapterList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpChapterList.Enabled = False
        Me.tlstpChapterList.Image = Global.VitalLogic.Applications.My.Resources.Resources.chapterlist
        Me.tlstpChapterList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpChapterList.Name = "tlstpChapterList"
        Me.tlstpChapterList.Size = New System.Drawing.Size(28, 28)
        Me.tlstpChapterList.Text = "ToolStripButton2"
        Me.tlstpChapterList.ToolTipText = "Reorder chapters"
        '
        'tlstpPageDesign
        '
        Me.tlstpPageDesign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpPageDesign.Enabled = False
        Me.tlstpPageDesign.Image = Global.VitalLogic.Applications.My.Resources.Resources.pagedesign
        Me.tlstpPageDesign.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpPageDesign.Name = "tlstpPageDesign"
        Me.tlstpPageDesign.Size = New System.Drawing.Size(28, 28)
        Me.tlstpPageDesign.Text = "ToolStripButton1"
        Me.tlstpPageDesign.ToolTipText = "Design elements"
        '
        'tlstpBookProps
        '
        Me.tlstpBookProps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpBookProps.Enabled = False
        Me.tlstpBookProps.Image = Global.VitalLogic.Applications.My.Resources.Resources.bookprops
        Me.tlstpBookProps.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpBookProps.Name = "tlstpBookProps"
        Me.tlstpBookProps.Size = New System.Drawing.Size(28, 28)
        Me.tlstpBookProps.Text = "ToolStripButton2"
        Me.tlstpBookProps.ToolTipText = "Book settings"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'tlstpWordCount
        '
        Me.tlstpWordCount.Name = "tlstpWordCount"
        Me.tlstpWordCount.Size = New System.Drawing.Size(0, 28)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlstpLabel, Me.tlstpMessage})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 560)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1206, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tlstpLabel
        '
        Me.tlstpLabel.Name = "tlstpLabel"
        Me.tlstpLabel.Size = New System.Drawing.Size(69, 17)
        Me.tlstpLabel.Text = "Manuscribe"
        '
        'tlstpMessage
        '
        Me.tlstpMessage.Name = "tlstpMessage"
        Me.tlstpMessage.Size = New System.Drawing.Size(1126, 17)
        Me.tlstpMessage.Spring = True
        Me.tlstpMessage.Text = "Ready"
        Me.tlstpMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 31)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Splitter1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvwBook)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tvwIdeas)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlMainEditControls)
        Me.SplitContainer1.Panel2.Controls.Add(Me.IdeaContainer1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BookDetailsCtl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1206, 529)
        Me.SplitContainer1.SplitterDistance = 220
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 3
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 246)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(2)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(220, 2)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'tvwBook
        '
        Me.tvwBook.ContextMenuStrip = Me.ctxTree
        Me.tvwBook.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwBook.HideSelection = False
        Me.tvwBook.ImageIndex = 0
        Me.tvwBook.ImageList = Me.ImageList1
        Me.tvwBook.Indent = 19
        Me.tvwBook.ItemHeight = 26
        Me.tvwBook.Location = New System.Drawing.Point(0, 0)
        Me.tvwBook.Margin = New System.Windows.Forms.Padding(2)
        Me.tvwBook.Name = "tvwBook"
        Me.tvwBook.SelectedImageIndex = 0
        Me.tvwBook.ShowRootLines = False
        Me.tvwBook.Size = New System.Drawing.Size(220, 248)
        Me.tvwBook.TabIndex = 0
        '
        'ctxTree
        '
        Me.ctxTree.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ctxTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxNew, Me.ctxCovers, Me.ToolStripSeparator4, Me.ctxShowIndex, Me.ctxImport, Me.ctxMovetoChapters, Me.ctxMovetoDrafts, Me.ctxMoveToTrash, Me.ToolStripMenuItem2, Me.ctxRestore, Me.ctxRemove, Me.ctxEmptyTrash})
        Me.ctxTree.Name = "ctxTree"
        Me.ctxTree.Size = New System.Drawing.Size(169, 236)
        '
        'ctxNew
        '
        Me.ctxNew.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxNewChapter, Me.ctxNewDraft})
        Me.ctxNew.Name = "ctxNew"
        Me.ctxNew.Size = New System.Drawing.Size(168, 22)
        Me.ctxNew.Text = "&New"
        '
        'ctxNewChapter
        '
        Me.ctxNewChapter.Name = "ctxNewChapter"
        Me.ctxNewChapter.Size = New System.Drawing.Size(116, 22)
        Me.ctxNewChapter.Text = "&Chapter"
        '
        'ctxNewDraft
        '
        Me.ctxNewDraft.Name = "ctxNewDraft"
        Me.ctxNewDraft.Size = New System.Drawing.Size(116, 22)
        Me.ctxNewDraft.Text = "&Draft"
        '
        'ctxCovers
        '
        Me.ctxCovers.Name = "ctxCovers"
        Me.ctxCovers.Size = New System.Drawing.Size(168, 22)
        Me.ctxCovers.Text = "&Covers"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(165, 6)
        '
        'ctxShowIndex
        '
        Me.ctxShowIndex.Name = "ctxShowIndex"
        Me.ctxShowIndex.Size = New System.Drawing.Size(168, 22)
        Me.ctxShowIndex.Text = "Show i&ndex"
        '
        'ctxImport
        '
        Me.ctxImport.Name = "ctxImport"
        Me.ctxImport.Size = New System.Drawing.Size(168, 22)
        Me.ctxImport.Text = "&Import"
        '
        'ctxMovetoChapters
        '
        Me.ctxMovetoChapters.Name = "ctxMovetoChapters"
        Me.ctxMovetoChapters.Size = New System.Drawing.Size(168, 22)
        Me.ctxMovetoChapters.Text = "Move to &Chapters"
        '
        'ctxMovetoDrafts
        '
        Me.ctxMovetoDrafts.Name = "ctxMovetoDrafts"
        Me.ctxMovetoDrafts.Size = New System.Drawing.Size(168, 22)
        Me.ctxMovetoDrafts.Text = "Move to &Drafts"
        '
        'ctxMoveToTrash
        '
        Me.ctxMoveToTrash.Name = "ctxMoveToTrash"
        Me.ctxMoveToTrash.Size = New System.Drawing.Size(168, 22)
        Me.ctxMoveToTrash.Text = "Move to &Trash"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(165, 6)
        '
        'ctxRestore
        '
        Me.ctxRestore.Name = "ctxRestore"
        Me.ctxRestore.Size = New System.Drawing.Size(168, 22)
        Me.ctxRestore.Text = "Re&store"
        '
        'ctxRemove
        '
        Me.ctxRemove.Name = "ctxRemove"
        Me.ctxRemove.Size = New System.Drawing.Size(168, 22)
        Me.ctxRemove.Text = "&Remove"
        '
        'ctxEmptyTrash
        '
        Me.ctxEmptyTrash.Name = "ctxEmptyTrash"
        Me.ctxEmptyTrash.Size = New System.Drawing.Size(168, 22)
        Me.ctxEmptyTrash.Text = "&Empty Trash"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "MYBOOK_16.png")
        Me.ImageList1.Images.SetKeyName(1, "chapterlist_16.png")
        Me.ImageList1.Images.SetKeyName(2, "chapter_16.png")
        Me.ImageList1.Images.SetKeyName(3, "page.png")
        Me.ImageList1.Images.SetKeyName(4, "draft_16.png")
        Me.ImageList1.Images.SetKeyName(5, "notes_16.png")
        Me.ImageList1.Images.SetKeyName(6, "research1_16.png")
        Me.ImageList1.Images.SetKeyName(7, "TRASH_16.png")
        Me.ImageList1.Images.SetKeyName(8, "BROWSER.png")
        Me.ImageList1.Images.SetKeyName(9, "reesarchimagefolder.png")
        Me.ImageList1.Images.SetKeyName(10, "reesearchdocfolder.png")
        Me.ImageList1.Images.SetKeyName(11, "researchtxtfolder.png")
        Me.ImageList1.Images.SetKeyName(12, "image_16.png")
        Me.ImageList1.Images.SetKeyName(13, "doc-icon_16.png")
        Me.ImageList1.Images.SetKeyName(14, "txt-icon_16.png")
        Me.ImageList1.Images.SetKeyName(15, "help.png")
        Me.ImageList1.Images.SetKeyName(16, "bookfront.png")
        Me.ImageList1.Images.SetKeyName(17, "status.png")
        Me.ImageList1.Images.SetKeyName(18, "youtube.png")
        '
        'tvwIdeas
        '
        Me.tvwIdeas.ContextMenuStrip = Me.ctxIdeas
        Me.tvwIdeas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tvwIdeas.HideSelection = False
        Me.tvwIdeas.ImageIndex = 0
        Me.tvwIdeas.ImageList = Me.ImageList2
        Me.tvwIdeas.Indent = 19
        Me.tvwIdeas.ItemHeight = 26
        Me.tvwIdeas.Location = New System.Drawing.Point(0, 248)
        Me.tvwIdeas.Margin = New System.Windows.Forms.Padding(2)
        Me.tvwIdeas.Name = "tvwIdeas"
        Me.tvwIdeas.SelectedImageIndex = 0
        Me.tvwIdeas.ShowRootLines = False
        Me.tvwIdeas.Size = New System.Drawing.Size(220, 281)
        Me.tvwIdeas.TabIndex = 2
        '
        'ctxIdeas
        '
        Me.ctxIdeas.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ctxIdeas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxIdeasNew, Me.ctxIdeasRemove})
        Me.ctxIdeas.Name = "ctxIdeas"
        Me.ctxIdeas.Size = New System.Drawing.Size(118, 48)
        '
        'ctxIdeasNew
        '
        Me.ctxIdeasNew.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxIdeasNewThought, Me.ctxIdeasNewCategory})
        Me.ctxIdeasNew.Name = "ctxIdeasNew"
        Me.ctxIdeasNew.Size = New System.Drawing.Size(117, 22)
        Me.ctxIdeasNew.Text = "&New"
        '
        'ctxIdeasNewThought
        '
        Me.ctxIdeasNewThought.Name = "ctxIdeasNewThought"
        Me.ctxIdeasNewThought.Size = New System.Drawing.Size(122, 22)
        Me.ctxIdeasNewThought.Text = "&Thought"
        '
        'ctxIdeasNewCategory
        '
        Me.ctxIdeasNewCategory.Name = "ctxIdeasNewCategory"
        Me.ctxIdeasNewCategory.Size = New System.Drawing.Size(122, 22)
        Me.ctxIdeasNewCategory.Text = "&Category"
        '
        'ctxIdeasRemove
        '
        Me.ctxIdeasRemove.Name = "ctxIdeasRemove"
        Me.ctxIdeasRemove.Size = New System.Drawing.Size(117, 22)
        Me.ctxIdeasRemove.Text = "&Remove"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "ideas.png")
        Me.ImageList2.Images.SetKeyName(1, "idea_folder1.png")
        Me.ImageList2.Images.SetKeyName(2, "thought.png")
        Me.ImageList2.Images.SetKeyName(3, "help.png")
        '
        'pnlMainEditControls
        '
        Me.pnlMainEditControls.Controls.Add(Me.printRichText)
        Me.pnlMainEditControls.Controls.Add(Me.BookCalenar1)
        Me.pnlMainEditControls.Controls.Add(Me.ResearchElementsDesk1)
        Me.pnlMainEditControls.Controls.Add(Me.ResearchContainer1)
        Me.pnlMainEditControls.Controls.Add(Me.WebCtrl1)
        Me.pnlMainEditControls.Controls.Add(Me.Canvas1)
        Me.pnlMainEditControls.Controls.Add(Me.CoverCanvas1)
        Me.pnlMainEditControls.Controls.Add(Me.Desk1)
        Me.pnlMainEditControls.Location = New System.Drawing.Point(7, 6)
        Me.pnlMainEditControls.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMainEditControls.Name = "pnlMainEditControls"
        Me.pnlMainEditControls.Size = New System.Drawing.Size(478, 374)
        Me.pnlMainEditControls.TabIndex = 12
        '
        'printRichText
        '
        Me.printRichText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.printRichText.Location = New System.Drawing.Point(225, 28)
        Me.printRichText.Name = "printRichText"
        Me.printRichText.SelectionAlignment = VitalLogic.Applications.TextAlign.Left
        Me.printRichText.ShowMistakes = False
        Me.printRichText.Size = New System.Drawing.Size(116, 110)
        Me.printRichText.TabIndex = 15
        Me.printRichText.Text = ""
        Me.printRichText.Visible = False
        '
        'BookCalenar1
        '
        Me.BookCalenar1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BookCalenar1.Location = New System.Drawing.Point(282, 172)
        Me.BookCalenar1.Margin = New System.Windows.Forms.Padding(2)
        Me.BookCalenar1.Name = "BookCalenar1"
        Me.BookCalenar1.Size = New System.Drawing.Size(107, 114)
        Me.BookCalenar1.TabIndex = 14
        '
        'ResearchElementsDesk1
        '
        Me.ResearchElementsDesk1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ResearchElementsDesk1.Location = New System.Drawing.Point(392, 56)
        Me.ResearchElementsDesk1.Margin = New System.Windows.Forms.Padding(2)
        Me.ResearchElementsDesk1.Name = "ResearchElementsDesk1"
        Me.ResearchElementsDesk1.Size = New System.Drawing.Size(56, 54)
        Me.ResearchElementsDesk1.TabIndex = 13
        '
        'ResearchContainer1
        '
        Me.ResearchContainer1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ResearchContainer1.Location = New System.Drawing.Point(138, 119)
        Me.ResearchContainer1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.ResearchContainer1.Name = "ResearchContainer1"
        Me.ResearchContainer1.Size = New System.Drawing.Size(64, 56)
        Me.ResearchContainer1.TabIndex = 12
        '
        'WebCtrl1
        '
        Me.WebCtrl1.Location = New System.Drawing.Point(206, 160)
        Me.WebCtrl1.Margin = New System.Windows.Forms.Padding(2)
        Me.WebCtrl1.Name = "WebCtrl1"
        Me.WebCtrl1.Size = New System.Drawing.Size(255, 126)
        Me.WebCtrl1.TabIndex = 11
        '
        'Canvas1
        '
        Me.Canvas1.Location = New System.Drawing.Point(33, 209)
        Me.Canvas1.Margin = New System.Windows.Forms.Padding(4)
        Me.Canvas1.Name = "Canvas1"
        PageTemplate1.Landscape = False
        PageTemplate1.Margins = New System.Drawing.Printing.Margins(30, 30, 30, 30)
        PageTemplate1.Name = "A4"
        PageTemplate1.Size = New System.Drawing.Size(587, 823)
        Me.Canvas1.PageSet = PageTemplate1
        Me.Canvas1.Size = New System.Drawing.Size(151, 130)
        Me.Canvas1.TabIndex = 4
        '
        'CoverCanvas1
        '
        Me.CoverCanvas1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.CoverCanvas1.Location = New System.Drawing.Point(14, 13)
        Me.CoverCanvas1.Margin = New System.Windows.Forms.Padding(4)
        Me.CoverCanvas1.Name = "CoverCanvas1"
        Me.CoverCanvas1.Size = New System.Drawing.Size(101, 80)
        Me.CoverCanvas1.Style = Nothing
        Me.CoverCanvas1.TabIndex = 9
        '
        'Desk1
        '
        Me.Desk1.AutoScroll = True
        Me.Desk1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Desk1.Location = New System.Drawing.Point(14, 119)
        Me.Desk1.Name = "Desk1"
        Me.Desk1.Size = New System.Drawing.Size(103, 82)
        Me.Desk1.TabIndex = 6
        '
        'IdeaContainer1
        '
        Me.IdeaContainer1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.IdeaContainer1.Location = New System.Drawing.Point(503, 152)
        Me.IdeaContainer1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.IdeaContainer1.Name = "IdeaContainer1"
        Me.IdeaContainer1.Size = New System.Drawing.Size(164, 123)
        Me.IdeaContainer1.TabIndex = 13
        Me.IdeaContainer1.Visible = False
        '
        'BookDetailsCtl1
        '
        Me.BookDetailsCtl1.Location = New System.Drawing.Point(523, 6)
        Me.BookDetailsCtl1.Margin = New System.Windows.Forms.Padding(2)
        Me.BookDetailsCtl1.Name = "BookDetailsCtl1"
        Me.BookDetailsCtl1.Size = New System.Drawing.Size(99, 116)
        Me.BookDetailsCtl1.TabIndex = 5
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1206, 582)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manuscribe"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ctxTree.ResumeLayout(False)
        Me.ctxIdeas.ResumeLayout(False)
        Me.pnlMainEditControls.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tvwBook As System.Windows.Forms.TreeView
    Friend WithEvents tlstpNewBook As ToolStripButton
    Friend WithEvents tlstpOpenBook As ToolStripButton
    Friend WithEvents tlstpExport As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tlstpPrint As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tlstpChapterList As ToolStripButton
    Friend WithEvents tlstpBookProps As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Canvas1 As Canvas
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ctxTree As ContextMenuStrip
    Friend WithEvents ctxNew As ToolStripMenuItem
    Friend WithEvents ctxNewChapter As ToolStripMenuItem
    Friend WithEvents ctxNewDraft As ToolStripMenuItem
    Friend WithEvents ctxRemove As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ctxImport As ToolStripMenuItem
    Friend WithEvents BookDetailsCtl1 As BookDetailsCtl
    Friend WithEvents Desk1 As Desk
    Friend WithEvents ctxRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMovetoChapters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMovetoDrafts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ctxMoveToTrash As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEmptyTrash As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlstpWordCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents tlstpLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ctxCovers As ToolStripMenuItem
    Friend WithEvents CoverCanvas1 As CoverCanvas
    Friend WithEvents WebCtrl1 As WebCtrl
    Friend WithEvents tvwIdeas As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ctxIdeas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxIdeasNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxIdeasNewThought As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxIdeasNewCategory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxIdeasRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMainEditControls As System.Windows.Forms.Panel
    Friend WithEvents IdeaContainer1 As VitalLogic.Applications.IdeaContainer
    Friend WithEvents ResearchContainer1 As VitalLogic.Applications.ResearchContainer
    Friend WithEvents tlstpPageDesign As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpPrintPreview As ToolStripButton
    Friend WithEvents tlstpSave As ToolStripDropDownButton
    Friend WithEvents tlstpMessage As ToolStripStatusLabel
    Friend WithEvents ResearchElementsDesk1 As VitalLogic.Applications.ResearchElementsDesk
    Friend WithEvents BookCalenar1 As VitalLogic.Applications.BookCalenar
    Friend WithEvents ctxShowIndex As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlstpReorderPages As System.Windows.Forms.ToolStripButton
    Friend WithEvents printRichText As AdvRichTextBox
End Class
