<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Canvas
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim PageTemplate1 As VitalLogic.Applications.PageTemplate = New VitalLogic.Applications.PageTemplate()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Canvas))
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.pnlImageContent = New System.Windows.Forms.Panel()
        Me.rtbMain = New VitalLogic.Applications.myRTB()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tlstpCut = New System.Windows.Forms.ToolStripButton()
        Me.tlstpCopy = New System.Windows.Forms.ToolStripButton()
        Me.tlstpPaste = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpUndo = New System.Windows.Forms.ToolStripButton()
        Me.tlstpRedo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpCopyStyle = New System.Windows.Forms.ToolStripButton()
        Me.tlstpPasteStyle = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.pnlPageDet = New System.Windows.Forms.Panel()
        Me.pnlPageThumbs = New System.Windows.Forms.Panel()
        Me.pnlPageNosControl = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.butSavePage = New System.Windows.Forms.Button()
        Me.butDeletePage = New System.Windows.Forms.Button()
        Me.butTypeSwitch = New System.Windows.Forms.Button()
        Me.butAddPage = New System.Windows.Forms.Button()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tlstpBold = New System.Windows.Forms.ToolStripButton()
        Me.tlstpItalic = New System.Windows.Forms.ToolStripButton()
        Me.tlstpUnderline = New System.Windows.Forms.ToolStripButton()
        Me.tlstpStrikeThrough = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboFontName = New System.Windows.Forms.ToolStripComboBox()
        Me.cboFontSize = New System.Windows.Forms.ToolStripComboBox()
        Me.tlstpBackColor = New System.Windows.Forms.ToolStripButton()
        Me.tlstpForeColor = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpNumbullets = New System.Windows.Forms.ToolStripButton()
        Me.tlstpBullets = New System.Windows.Forms.ToolStripButton()
        Me.tlstpIndentRight = New System.Windows.Forms.ToolStripButton()
        Me.tlstpLeft = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpAlignLeft = New System.Windows.Forms.ToolStripButton()
        Me.tlstpAlignCenter = New System.Windows.Forms.ToolStripButton()
        Me.tlstpAlignRight = New System.Windows.Forms.ToolStripButton()
        Me.tlstpJustify = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlstpSeamlessedit = New System.Windows.Forms.ToolStripButton()
        Me.tlstpShowScroll = New System.Windows.Forms.ToolStripButton()
        Me.tlstpShowGrid = New System.Windows.Forms.ToolStripButton()
        Me.tlstpPageBreak = New System.Windows.Forms.ToolStripButton()
        Me.tlstpIndexes = New System.Windows.Forms.ToolStripButton()
        Me.tlstpSpellCheck = New System.Windows.Forms.ToolStripButton()
        Me.pnlTopToolbar = New System.Windows.Forms.Panel()
        Me.lblWordCount = New System.Windows.Forms.Label()
        Me.pnlRightStyles = New System.Windows.Forms.Panel()
        Me.pnlStyleControls = New System.Windows.Forms.Panel()
        Me.pnlStyleControlButtons = New System.Windows.Forms.Panel()
        Me.butShowSpellChecker = New System.Windows.Forms.Button()
        Me.butMaintainStyle = New System.Windows.Forms.Button()
        Me.cboStyles = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTags = New System.Windows.Forms.TextBox()
        Me.pnlContainer.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlPageDet.SuspendLayout()
        Me.pnlPageNosControl.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.pnlTopToolbar.SuspendLayout()
        Me.pnlRightStyles.SuspendLayout()
        Me.pnlStyleControlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContainer
        '
        Me.pnlContainer.AutoScroll = True
        Me.pnlContainer.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.pnlContainer.Controls.Add(Me.pnlImageContent)
        Me.pnlContainer.Controls.Add(Me.rtbMain)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(201, 69)
        Me.pnlContainer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(948, 624)
        Me.pnlContainer.TabIndex = 5
        '
        'pnlImageContent
        '
        Me.pnlImageContent.BackColor = System.Drawing.Color.White
        Me.pnlImageContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlImageContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlImageContent.Location = New System.Drawing.Point(139, 142)
        Me.pnlImageContent.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlImageContent.Name = "pnlImageContent"
        Me.pnlImageContent.Size = New System.Drawing.Size(142, 291)
        Me.pnlImageContent.TabIndex = 1
        '
        'rtbMain
        '
        Me.rtbMain.BackColor = System.Drawing.Color.White
        Me.rtbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbMain.Location = New System.Drawing.Point(0, 0)
        Me.rtbMain.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rtbMain.Name = "rtbMain"
        Me.rtbMain.Padding = New System.Windows.Forms.Padding(100, 10, 5, 0)
        PageTemplate1.Landscape = False
        PageTemplate1.Margins = New System.Drawing.Printing.Margins(30, 30, 30, 30)
        PageTemplate1.Name = "A4"
        PageTemplate1.Size = New System.Drawing.Size(587, 823)
        Me.rtbMain.PageSet = PageTemplate1
        Me.rtbMain.SeamlessEditing = True
        Me.rtbMain.ShowMargins = False
        Me.rtbMain.Size = New System.Drawing.Size(948, 624)
        Me.rtbMain.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlstpCut, Me.tlstpCopy, Me.tlstpPaste, Me.ToolStripSeparator1, Me.tlstpUndo, Me.tlstpRedo, Me.ToolStripSeparator2, Me.tlstpCopyStyle, Me.tlstpPasteStyle, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(397, 30)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(216, 27)
        Me.ToolStrip1.TabIndex = 4
        '
        'tlstpCut
        '
        Me.tlstpCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpCut.Image = CType(resources.GetObject("tlstpCut.Image"), System.Drawing.Image)
        Me.tlstpCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpCut.Name = "tlstpCut"
        Me.tlstpCut.Size = New System.Drawing.Size(24, 24)
        Me.tlstpCut.ToolTipText = "Cut"
        '
        'tlstpCopy
        '
        Me.tlstpCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpCopy.Image = CType(resources.GetObject("tlstpCopy.Image"), System.Drawing.Image)
        Me.tlstpCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpCopy.Name = "tlstpCopy"
        Me.tlstpCopy.Size = New System.Drawing.Size(24, 24)
        Me.tlstpCopy.Text = "ToolStripButton2"
        Me.tlstpCopy.ToolTipText = "Copy"
        '
        'tlstpPaste
        '
        Me.tlstpPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpPaste.Image = CType(resources.GetObject("tlstpPaste.Image"), System.Drawing.Image)
        Me.tlstpPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpPaste.Name = "tlstpPaste"
        Me.tlstpPaste.Size = New System.Drawing.Size(24, 24)
        Me.tlstpPaste.Text = "ToolStripButton3"
        Me.tlstpPaste.ToolTipText = "Paste"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 27)
        '
        'tlstpUndo
        '
        Me.tlstpUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpUndo.Image = CType(resources.GetObject("tlstpUndo.Image"), System.Drawing.Image)
        Me.tlstpUndo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpUndo.Name = "tlstpUndo"
        Me.tlstpUndo.Size = New System.Drawing.Size(24, 24)
        Me.tlstpUndo.Text = "ToolStripButton4"
        Me.tlstpUndo.ToolTipText = "Undo"
        '
        'tlstpRedo
        '
        Me.tlstpRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpRedo.Image = CType(resources.GetObject("tlstpRedo.Image"), System.Drawing.Image)
        Me.tlstpRedo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpRedo.Name = "tlstpRedo"
        Me.tlstpRedo.Size = New System.Drawing.Size(24, 24)
        Me.tlstpRedo.Text = "ToolStripButton5"
        Me.tlstpRedo.ToolTipText = "Redo"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'tlstpCopyStyle
        '
        Me.tlstpCopyStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpCopyStyle.Image = CType(resources.GetObject("tlstpCopyStyle.Image"), System.Drawing.Image)
        Me.tlstpCopyStyle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpCopyStyle.Name = "tlstpCopyStyle"
        Me.tlstpCopyStyle.Size = New System.Drawing.Size(24, 24)
        Me.tlstpCopyStyle.Text = "ToolStripButton1"
        Me.tlstpCopyStyle.ToolTipText = "Copy style"
        '
        'tlstpPasteStyle
        '
        Me.tlstpPasteStyle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpPasteStyle.Image = CType(resources.GetObject("tlstpPasteStyle.Image"), System.Drawing.Image)
        Me.tlstpPasteStyle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpPasteStyle.Name = "tlstpPasteStyle"
        Me.tlstpPasteStyle.Size = New System.Drawing.Size(24, 24)
        Me.tlstpPasteStyle.Text = "ToolStripButton1"
        Me.tlstpPasteStyle.ToolTipText = "Paste style"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.VitalLogic.Applications.My.Resources.Resources.search_24
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(24, 24)
        Me.ToolStripButton1.ToolTipText = "Find and Replace"
        '
        'pnlPageDet
        '
        Me.pnlPageDet.Controls.Add(Me.pnlPageThumbs)
        Me.pnlPageDet.Controls.Add(Me.pnlPageNosControl)
        Me.pnlPageDet.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPageDet.Location = New System.Drawing.Point(0, 0)
        Me.pnlPageDet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlPageDet.Name = "pnlPageDet"
        Me.pnlPageDet.Size = New System.Drawing.Size(201, 693)
        Me.pnlPageDet.TabIndex = 6
        '
        'pnlPageThumbs
        '
        Me.pnlPageThumbs.AutoScroll = True
        Me.pnlPageThumbs.BackColor = System.Drawing.Color.White
        Me.pnlPageThumbs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPageThumbs.Location = New System.Drawing.Point(0, 69)
        Me.pnlPageThumbs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlPageThumbs.Name = "pnlPageThumbs"
        Me.pnlPageThumbs.Size = New System.Drawing.Size(201, 624)
        Me.pnlPageThumbs.TabIndex = 5
        '
        'pnlPageNosControl
        '
        Me.pnlPageNosControl.Controls.Add(Me.Label3)
        Me.pnlPageNosControl.Controls.Add(Me.Label2)
        Me.pnlPageNosControl.Controls.Add(Me.butSavePage)
        Me.pnlPageNosControl.Controls.Add(Me.butDeletePage)
        Me.pnlPageNosControl.Controls.Add(Me.butTypeSwitch)
        Me.pnlPageNosControl.Controls.Add(Me.butAddPage)
        Me.pnlPageNosControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPageNosControl.Location = New System.Drawing.Point(0, 0)
        Me.pnlPageNosControl.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlPageNosControl.Name = "pnlPageNosControl"
        Me.pnlPageNosControl.Size = New System.Drawing.Size(201, 69)
        Me.pnlPageNosControl.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(156, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Img"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Doc"
        '
        'butSavePage
        '
        Me.butSavePage.Enabled = False
        Me.butSavePage.FlatAppearance.BorderSize = 0
        Me.butSavePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSavePage.Image = CType(resources.GetObject("butSavePage.Image"), System.Drawing.Image)
        Me.butSavePage.Location = New System.Drawing.Point(160, 2)
        Me.butSavePage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butSavePage.Name = "butSavePage"
        Me.butSavePage.Size = New System.Drawing.Size(35, 31)
        Me.butSavePage.TabIndex = 0
        Me.butSavePage.UseVisualStyleBackColor = True
        '
        'butDeletePage
        '
        Me.butDeletePage.FlatAppearance.BorderSize = 0
        Me.butDeletePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butDeletePage.Image = CType(resources.GetObject("butDeletePage.Image"), System.Drawing.Image)
        Me.butDeletePage.Location = New System.Drawing.Point(120, 2)
        Me.butDeletePage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butDeletePage.Name = "butDeletePage"
        Me.butDeletePage.Size = New System.Drawing.Size(35, 31)
        Me.butDeletePage.TabIndex = 0
        Me.butDeletePage.UseVisualStyleBackColor = True
        '
        'butTypeSwitch
        '
        Me.butTypeSwitch.FlatAppearance.BorderSize = 0
        Me.butTypeSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butTypeSwitch.Location = New System.Drawing.Point(64, 37)
        Me.butTypeSwitch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butTypeSwitch.Name = "butTypeSwitch"
        Me.butTypeSwitch.Size = New System.Drawing.Size(73, 30)
        Me.butTypeSwitch.TabIndex = 0
        Me.butTypeSwitch.UseVisualStyleBackColor = True
        '
        'butAddPage
        '
        Me.butAddPage.FlatAppearance.BorderSize = 0
        Me.butAddPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butAddPage.Image = CType(resources.GetObject("butAddPage.Image"), System.Drawing.Image)
        Me.butAddPage.Location = New System.Drawing.Point(80, 2)
        Me.butAddPage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butAddPage.Name = "butAddPage"
        Me.butAddPage.Size = New System.Drawing.Size(35, 31)
        Me.butAddPage.TabIndex = 0
        Me.butAddPage.UseVisualStyleBackColor = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlstpBold, Me.tlstpItalic, Me.tlstpUnderline, Me.tlstpStrikeThrough, Me.ToolStripSeparator4, Me.cboFontName, Me.cboFontSize, Me.tlstpBackColor, Me.tlstpForeColor, Me.ToolStripSeparator5, Me.tlstpNumbullets, Me.tlstpBullets, Me.tlstpIndentRight, Me.tlstpLeft, Me.ToolStripSeparator6, Me.tlstpAlignLeft, Me.tlstpAlignCenter, Me.tlstpAlignRight, Me.tlstpJustify, Me.ToolStripSeparator7, Me.tlstpSeamlessedit, Me.tlstpShowScroll, Me.tlstpShowGrid, Me.tlstpPageBreak, Me.tlstpIndexes, Me.tlstpSpellCheck})
        Me.ToolStrip2.Location = New System.Drawing.Point(67, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(740, 28)
        Me.ToolStrip2.TabIndex = 3
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tlstpBold
        '
        Me.tlstpBold.CheckOnClick = True
        Me.tlstpBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpBold.Image = CType(resources.GetObject("tlstpBold.Image"), System.Drawing.Image)
        Me.tlstpBold.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpBold.Name = "tlstpBold"
        Me.tlstpBold.Size = New System.Drawing.Size(24, 25)
        Me.tlstpBold.Text = "ToolStripButton1"
        Me.tlstpBold.ToolTipText = "Bold"
        '
        'tlstpItalic
        '
        Me.tlstpItalic.CheckOnClick = True
        Me.tlstpItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpItalic.Image = CType(resources.GetObject("tlstpItalic.Image"), System.Drawing.Image)
        Me.tlstpItalic.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpItalic.Name = "tlstpItalic"
        Me.tlstpItalic.Size = New System.Drawing.Size(24, 25)
        Me.tlstpItalic.Text = "ToolStripButton1"
        Me.tlstpItalic.ToolTipText = "Italic"
        '
        'tlstpUnderline
        '
        Me.tlstpUnderline.CheckOnClick = True
        Me.tlstpUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpUnderline.Image = CType(resources.GetObject("tlstpUnderline.Image"), System.Drawing.Image)
        Me.tlstpUnderline.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpUnderline.Name = "tlstpUnderline"
        Me.tlstpUnderline.Size = New System.Drawing.Size(24, 25)
        Me.tlstpUnderline.Text = "ToolStripButton2"
        Me.tlstpUnderline.ToolTipText = "Underline"
        '
        'tlstpStrikeThrough
        '
        Me.tlstpStrikeThrough.CheckOnClick = True
        Me.tlstpStrikeThrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpStrikeThrough.Image = CType(resources.GetObject("tlstpStrikeThrough.Image"), System.Drawing.Image)
        Me.tlstpStrikeThrough.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpStrikeThrough.Name = "tlstpStrikeThrough"
        Me.tlstpStrikeThrough.Size = New System.Drawing.Size(24, 25)
        Me.tlstpStrikeThrough.Text = "ToolStripButton3"
        Me.tlstpStrikeThrough.ToolTipText = "Strikethrough"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 28)
        '
        'cboFontName
        '
        Me.cboFontName.Name = "cboFontName"
        Me.cboFontName.Size = New System.Drawing.Size(121, 28)
        Me.cboFontName.ToolTipText = "Font name"
        '
        'cboFontSize
        '
        Me.cboFontSize.Name = "cboFontSize"
        Me.cboFontSize.Size = New System.Drawing.Size(99, 28)
        Me.cboFontSize.ToolTipText = "Font Size"
        '
        'tlstpBackColor
        '
        Me.tlstpBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpBackColor.Image = CType(resources.GetObject("tlstpBackColor.Image"), System.Drawing.Image)
        Me.tlstpBackColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpBackColor.Name = "tlstpBackColor"
        Me.tlstpBackColor.Size = New System.Drawing.Size(24, 25)
        Me.tlstpBackColor.Text = "ToolStripButton5"
        Me.tlstpBackColor.ToolTipText = "Back color"
        '
        'tlstpForeColor
        '
        Me.tlstpForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpForeColor.Image = CType(resources.GetObject("tlstpForeColor.Image"), System.Drawing.Image)
        Me.tlstpForeColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpForeColor.Name = "tlstpForeColor"
        Me.tlstpForeColor.Size = New System.Drawing.Size(24, 25)
        Me.tlstpForeColor.Text = "ToolStripButton6"
        Me.tlstpForeColor.ToolTipText = "Font color"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 28)
        '
        'tlstpNumbullets
        '
        Me.tlstpNumbullets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpNumbullets.Image = CType(resources.GetObject("tlstpNumbullets.Image"), System.Drawing.Image)
        Me.tlstpNumbullets.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpNumbullets.Name = "tlstpNumbullets"
        Me.tlstpNumbullets.Size = New System.Drawing.Size(24, 25)
        Me.tlstpNumbullets.Text = "ToolStripButton7"
        Me.tlstpNumbullets.ToolTipText = "Number bullets"
        '
        'tlstpBullets
        '
        Me.tlstpBullets.CheckOnClick = True
        Me.tlstpBullets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpBullets.Image = CType(resources.GetObject("tlstpBullets.Image"), System.Drawing.Image)
        Me.tlstpBullets.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpBullets.Name = "tlstpBullets"
        Me.tlstpBullets.Size = New System.Drawing.Size(24, 25)
        Me.tlstpBullets.Text = "ToolStripButton8"
        Me.tlstpBullets.ToolTipText = "Toggle bullets"
        '
        'tlstpIndentRight
        '
        Me.tlstpIndentRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpIndentRight.Image = CType(resources.GetObject("tlstpIndentRight.Image"), System.Drawing.Image)
        Me.tlstpIndentRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpIndentRight.Name = "tlstpIndentRight"
        Me.tlstpIndentRight.Size = New System.Drawing.Size(24, 25)
        Me.tlstpIndentRight.Text = "ToolStripButton9"
        Me.tlstpIndentRight.ToolTipText = "Indent right"
        '
        'tlstpLeft
        '
        Me.tlstpLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpLeft.Image = CType(resources.GetObject("tlstpLeft.Image"), System.Drawing.Image)
        Me.tlstpLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpLeft.Name = "tlstpLeft"
        Me.tlstpLeft.Size = New System.Drawing.Size(24, 25)
        Me.tlstpLeft.Text = "ToolStripButton10"
        Me.tlstpLeft.ToolTipText = "Indent left"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 28)
        '
        'tlstpAlignLeft
        '
        Me.tlstpAlignLeft.CheckOnClick = True
        Me.tlstpAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpAlignLeft.Image = CType(resources.GetObject("tlstpAlignLeft.Image"), System.Drawing.Image)
        Me.tlstpAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpAlignLeft.Name = "tlstpAlignLeft"
        Me.tlstpAlignLeft.Size = New System.Drawing.Size(24, 25)
        Me.tlstpAlignLeft.Text = "ToolStripButton11"
        Me.tlstpAlignLeft.ToolTipText = "Align left"
        '
        'tlstpAlignCenter
        '
        Me.tlstpAlignCenter.CheckOnClick = True
        Me.tlstpAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpAlignCenter.Image = CType(resources.GetObject("tlstpAlignCenter.Image"), System.Drawing.Image)
        Me.tlstpAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpAlignCenter.Name = "tlstpAlignCenter"
        Me.tlstpAlignCenter.Size = New System.Drawing.Size(24, 25)
        Me.tlstpAlignCenter.Text = "ToolStripButton12"
        Me.tlstpAlignCenter.ToolTipText = "Align center"
        '
        'tlstpAlignRight
        '
        Me.tlstpAlignRight.CheckOnClick = True
        Me.tlstpAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpAlignRight.Image = CType(resources.GetObject("tlstpAlignRight.Image"), System.Drawing.Image)
        Me.tlstpAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpAlignRight.Name = "tlstpAlignRight"
        Me.tlstpAlignRight.Size = New System.Drawing.Size(24, 25)
        Me.tlstpAlignRight.Text = "ToolStripButton13"
        Me.tlstpAlignRight.ToolTipText = "Align right"
        '
        'tlstpJustify
        '
        Me.tlstpJustify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpJustify.Image = CType(resources.GetObject("tlstpJustify.Image"), System.Drawing.Image)
        Me.tlstpJustify.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpJustify.Name = "tlstpJustify"
        Me.tlstpJustify.Size = New System.Drawing.Size(24, 25)
        Me.tlstpJustify.Text = "ToolStripButton14"
        Me.tlstpJustify.ToolTipText = "Justify"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 28)
        '
        'tlstpSeamlessedit
        '
        Me.tlstpSeamlessedit.CheckOnClick = True
        Me.tlstpSeamlessedit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpSeamlessedit.Image = CType(resources.GetObject("tlstpSeamlessedit.Image"), System.Drawing.Image)
        Me.tlstpSeamlessedit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpSeamlessedit.Name = "tlstpSeamlessedit"
        Me.tlstpSeamlessedit.Size = New System.Drawing.Size(24, 25)
        Me.tlstpSeamlessedit.ToolTipText = "Seamless edit"
        '
        'tlstpShowScroll
        '
        Me.tlstpShowScroll.CheckOnClick = True
        Me.tlstpShowScroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpShowScroll.Image = CType(resources.GetObject("tlstpShowScroll.Image"), System.Drawing.Image)
        Me.tlstpShowScroll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpShowScroll.Name = "tlstpShowScroll"
        Me.tlstpShowScroll.Size = New System.Drawing.Size(24, 25)
        Me.tlstpShowScroll.Text = "ToolStripButton1"
        Me.tlstpShowScroll.ToolTipText = "Show scollbar"
        '
        'tlstpShowGrid
        '
        Me.tlstpShowGrid.CheckOnClick = True
        Me.tlstpShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpShowGrid.Image = CType(resources.GetObject("tlstpShowGrid.Image"), System.Drawing.Image)
        Me.tlstpShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpShowGrid.Name = "tlstpShowGrid"
        Me.tlstpShowGrid.Size = New System.Drawing.Size(24, 25)
        Me.tlstpShowGrid.Text = "ToolStripButton15"
        Me.tlstpShowGrid.ToolTipText = "Show margins"
        '
        'tlstpPageBreak
        '
        Me.tlstpPageBreak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpPageBreak.Image = CType(resources.GetObject("tlstpPageBreak.Image"), System.Drawing.Image)
        Me.tlstpPageBreak.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpPageBreak.Name = "tlstpPageBreak"
        Me.tlstpPageBreak.Size = New System.Drawing.Size(24, 25)
        Me.tlstpPageBreak.Text = "ToolStripButton1"
        Me.tlstpPageBreak.ToolTipText = "Insert line break"
        '
        'tlstpIndexes
        '
        Me.tlstpIndexes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpIndexes.Image = CType(resources.GetObject("tlstpIndexes.Image"), System.Drawing.Image)
        Me.tlstpIndexes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpIndexes.Name = "tlstpIndexes"
        Me.tlstpIndexes.Size = New System.Drawing.Size(24, 25)
        Me.tlstpIndexes.ToolTipText = "Index entries"
        '
        'tlstpSpellCheck
        '
        Me.tlstpSpellCheck.CheckOnClick = True
        Me.tlstpSpellCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tlstpSpellCheck.Image = CType(resources.GetObject("tlstpSpellCheck.Image"), System.Drawing.Image)
        Me.tlstpSpellCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstpSpellCheck.Name = "tlstpSpellCheck"
        Me.tlstpSpellCheck.Size = New System.Drawing.Size(24, 25)
        Me.tlstpSpellCheck.ToolTipText = "Show spell errors"
        '
        'pnlTopToolbar
        '
        Me.pnlTopToolbar.Controls.Add(Me.ToolStrip2)
        Me.pnlTopToolbar.Controls.Add(Me.ToolStrip1)
        Me.pnlTopToolbar.Controls.Add(Me.lblWordCount)
        Me.pnlTopToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopToolbar.Location = New System.Drawing.Point(201, 0)
        Me.pnlTopToolbar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlTopToolbar.Name = "pnlTopToolbar"
        Me.pnlTopToolbar.Size = New System.Drawing.Size(1083, 69)
        Me.pnlTopToolbar.TabIndex = 7
        '
        'lblWordCount
        '
        Me.lblWordCount.AutoSize = True
        Me.lblWordCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWordCount.Location = New System.Drawing.Point(5, 36)
        Me.lblWordCount.Name = "lblWordCount"
        Me.lblWordCount.Size = New System.Drawing.Size(0, 17)
        Me.lblWordCount.TabIndex = 5
        '
        'pnlRightStyles
        '
        Me.pnlRightStyles.Controls.Add(Me.pnlStyleControls)
        Me.pnlRightStyles.Controls.Add(Me.pnlStyleControlButtons)
        Me.pnlRightStyles.Controls.Add(Me.cboStyles)
        Me.pnlRightStyles.Controls.Add(Me.Label1)
        Me.pnlRightStyles.Controls.Add(Me.txtTags)
        Me.pnlRightStyles.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRightStyles.Location = New System.Drawing.Point(1149, 69)
        Me.pnlRightStyles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlRightStyles.Name = "pnlRightStyles"
        Me.pnlRightStyles.Size = New System.Drawing.Size(135, 624)
        Me.pnlRightStyles.TabIndex = 8
        '
        'pnlStyleControls
        '
        Me.pnlStyleControls.AutoScroll = True
        Me.pnlStyleControls.Location = New System.Drawing.Point(0, 58)
        Me.pnlStyleControls.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlStyleControls.Name = "pnlStyleControls"
        Me.pnlStyleControls.Size = New System.Drawing.Size(135, 217)
        Me.pnlStyleControls.TabIndex = 2
        '
        'pnlStyleControlButtons
        '
        Me.pnlStyleControlButtons.AutoScroll = True
        Me.pnlStyleControlButtons.Controls.Add(Me.butShowSpellChecker)
        Me.pnlStyleControlButtons.Controls.Add(Me.butMaintainStyle)
        Me.pnlStyleControlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlStyleControlButtons.Location = New System.Drawing.Point(0, 280)
        Me.pnlStyleControlButtons.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlStyleControlButtons.Name = "pnlStyleControlButtons"
        Me.pnlStyleControlButtons.Size = New System.Drawing.Size(135, 80)
        Me.pnlStyleControlButtons.TabIndex = 2
        '
        'butShowSpellChecker
        '
        Me.butShowSpellChecker.Location = New System.Drawing.Point(9, 42)
        Me.butShowSpellChecker.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butShowSpellChecker.Name = "butShowSpellChecker"
        Me.butShowSpellChecker.Size = New System.Drawing.Size(115, 32)
        Me.butShowSpellChecker.TabIndex = 3
        Me.butShowSpellChecker.Text = "S&pell check"
        Me.butShowSpellChecker.UseVisualStyleBackColor = True
        '
        'butMaintainStyle
        '
        Me.butMaintainStyle.Location = New System.Drawing.Point(9, 5)
        Me.butMaintainStyle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butMaintainStyle.Name = "butMaintainStyle"
        Me.butMaintainStyle.Size = New System.Drawing.Size(115, 32)
        Me.butMaintainStyle.TabIndex = 3
        Me.butMaintainStyle.Text = "Maintain styles"
        Me.butMaintainStyle.UseVisualStyleBackColor = True
        '
        'cboStyles
        '
        Me.cboStyles.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboStyles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStyles.FormattingEnabled = True
        Me.cboStyles.Location = New System.Drawing.Point(0, 32)
        Me.cboStyles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboStyles.Name = "cboStyles"
        Me.cboStyles.Size = New System.Drawing.Size(135, 24)
        Me.cboStyles.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Active style"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTags
        '
        Me.txtTags.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtTags.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTags.Location = New System.Drawing.Point(0, 360)
        Me.txtTags.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTags.Multiline = True
        Me.txtTags.Name = "txtTags"
        Me.txtTags.Size = New System.Drawing.Size(135, 264)
        Me.txtTags.TabIndex = 3
        '
        'Canvas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.pnlRightStyles)
        Me.Controls.Add(Me.pnlTopToolbar)
        Me.Controls.Add(Me.pnlPageDet)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Canvas"
        Me.Size = New System.Drawing.Size(1284, 693)
        Me.pnlContainer.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlPageDet.ResumeLayout(False)
        Me.pnlPageNosControl.ResumeLayout(False)
        Me.pnlPageNosControl.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.pnlTopToolbar.ResumeLayout(False)
        Me.pnlTopToolbar.PerformLayout()
        Me.pnlRightStyles.ResumeLayout(False)
        Me.pnlRightStyles.PerformLayout()
        Me.pnlStyleControlButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Page2 As PageTemplate
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents rtbMain As VitalLogic.Applications.myRTB
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tlstpCut As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpPaste As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlstpUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpRedo As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlPageDet As System.Windows.Forms.Panel
    Friend WithEvents pnlPageThumbs As System.Windows.Forms.Panel
    Friend WithEvents pnlPageNosControl As System.Windows.Forms.Panel
    Friend WithEvents butSavePage As System.Windows.Forms.Button
    Friend WithEvents butDeletePage As System.Windows.Forms.Button
    Friend WithEvents butAddPage As System.Windows.Forms.Button
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tlstpBold As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpItalic As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpUnderline As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpStrikeThrough As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboFontName As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboFontSize As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tlstpBackColor As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpForeColor As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlstpNumbullets As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpBullets As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpIndentRight As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpLeft As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlstpAlignLeft As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpAlignCenter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpAlignRight As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpJustify As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlstpShowScroll As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpShowGrid As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlstpPageBreak As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlTopToolbar As System.Windows.Forms.Panel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblWordCount As System.Windows.Forms.Label
    Friend WithEvents tlstpCopyStyle As ToolStripButton
    Friend WithEvents tlstpPasteStyle As ToolStripButton
    Friend WithEvents pnlRightStyles As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboStyles As System.Windows.Forms.ComboBox
    Friend WithEvents pnlStyleControls As System.Windows.Forms.Panel
    Friend WithEvents butMaintainStyle As System.Windows.Forms.Button
    Friend WithEvents pnlStyleControlButtons As System.Windows.Forms.Panel
    Friend WithEvents pnlImageContent As Panel
    Friend WithEvents butTypeSwitch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTags As TextBox
    Friend WithEvents tlstpIndexes As ToolStripButton
    Friend WithEvents tlstpSeamlessedit As ToolStripButton
    Friend WithEvents butShowSpellChecker As Button
    Friend WithEvents tlstpSpellCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
