<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResearchElementsDesk
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResearchElementsDesk))
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.picPicture = New System.Windows.Forms.PictureBox()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lstRObjects = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.butSavePage = New System.Windows.Forms.Button()
        Me.butCopy = New System.Windows.Forms.Button()
        Me.butDeletePage = New System.Windows.Forms.Button()
        Me.butImport = New System.Windows.Forms.Button()
        Me.butAddPage = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.optYouTubeLinks = New System.Windows.Forms.RadioButton()
        Me.optTextFiles = New System.Windows.Forms.RadioButton()
        Me.optDocuments = New System.Windows.Forms.RadioButton()
        Me.optImages = New System.Windows.Forms.RadioButton()
        Me.VideoPlayer1 = New VitalLogic.Applications.VideoPlayer()
        Me.rtfText = New VitalLogic.Applications.AdvRichTextBox()
        CType(Me.picPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtText
        '
        Me.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.Location = New System.Drawing.Point(216, 89)
        Me.txtText.Margin = New System.Windows.Forms.Padding(2)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(50, 76)
        Me.txtText.TabIndex = 1
        '
        'picPicture
        '
        Me.picPicture.BackColor = System.Drawing.Color.White
        Me.picPicture.Location = New System.Drawing.Point(169, 53)
        Me.picPicture.Margin = New System.Windows.Forms.Padding(2)
        Me.picPicture.Name = "picPicture"
        Me.picPicture.Size = New System.Drawing.Size(64, 64)
        Me.picPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPicture.TabIndex = 0
        Me.picPicture.TabStop = False
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.VideoPlayer1)
        Me.pnlMain.Controls.Add(Me.Panel3)
        Me.pnlMain.Controls.Add(Me.Panel2)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(754, 427)
        Me.pnlMain.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.picPicture)
        Me.Panel3.Controls.Add(Me.Splitter1)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Location = New System.Drawing.Point(122, 35)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(658, 232)
        Me.Panel3.TabIndex = 5
        Me.Panel3.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.rtfText)
        Me.Panel4.Controls.Add(Me.txtText)
        Me.Panel4.Location = New System.Drawing.Point(241, 34)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(15, 16, 15, 4)
        Me.Panel4.Size = New System.Drawing.Size(417, 198)
        Me.Panel4.TabIndex = 5
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(184, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 232)
        Me.Splitter1.TabIndex = 7
        Me.Splitter1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lstRObjects)
        Me.Panel5.Controls.Add(Me.Panel1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(184, 232)
        Me.Panel5.TabIndex = 6
        '
        'lstRObjects
        '
        Me.lstRObjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstRObjects.FormattingEnabled = True
        Me.lstRObjects.Location = New System.Drawing.Point(0, 65)
        Me.lstRObjects.Name = "lstRObjects"
        Me.lstRObjects.Size = New System.Drawing.Size(184, 167)
        Me.lstRObjects.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.butSavePage)
        Me.Panel1.Controls.Add(Me.butCopy)
        Me.Panel1.Controls.Add(Me.butDeletePage)
        Me.Panel1.Controls.Add(Me.butImport)
        Me.Panel1.Controls.Add(Me.butAddPage)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 65)
        Me.Panel1.TabIndex = 2
        '
        'butSavePage
        '
        Me.butSavePage.Enabled = False
        Me.butSavePage.FlatAppearance.BorderSize = 0
        Me.butSavePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSavePage.Image = CType(resources.GetObject("butSavePage.Image"), System.Drawing.Image)
        Me.butSavePage.Location = New System.Drawing.Point(156, 34)
        Me.butSavePage.Margin = New System.Windows.Forms.Padding(2)
        Me.butSavePage.Name = "butSavePage"
        Me.butSavePage.Size = New System.Drawing.Size(26, 25)
        Me.butSavePage.TabIndex = 1
        Me.butSavePage.UseVisualStyleBackColor = True
        '
        'butCopy
        '
        Me.butCopy.FlatAppearance.BorderSize = 0
        Me.butCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butCopy.Image = CType(resources.GetObject("butCopy.Image"), System.Drawing.Image)
        Me.butCopy.Location = New System.Drawing.Point(126, 34)
        Me.butCopy.Margin = New System.Windows.Forms.Padding(2)
        Me.butCopy.Name = "butCopy"
        Me.butCopy.Size = New System.Drawing.Size(26, 25)
        Me.butCopy.TabIndex = 2
        Me.butCopy.UseVisualStyleBackColor = True
        '
        'butDeletePage
        '
        Me.butDeletePage.FlatAppearance.BorderSize = 0
        Me.butDeletePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butDeletePage.Image = CType(resources.GetObject("butDeletePage.Image"), System.Drawing.Image)
        Me.butDeletePage.Location = New System.Drawing.Point(2, 2)
        Me.butDeletePage.Margin = New System.Windows.Forms.Padding(2)
        Me.butDeletePage.Name = "butDeletePage"
        Me.butDeletePage.Size = New System.Drawing.Size(26, 25)
        Me.butDeletePage.TabIndex = 2
        Me.butDeletePage.UseVisualStyleBackColor = True
        '
        'butImport
        '
        Me.butImport.FlatAppearance.BorderSize = 0
        Me.butImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butImport.Image = CType(resources.GetObject("butImport.Image"), System.Drawing.Image)
        Me.butImport.Location = New System.Drawing.Point(126, 2)
        Me.butImport.Margin = New System.Windows.Forms.Padding(2)
        Me.butImport.Name = "butImport"
        Me.butImport.Size = New System.Drawing.Size(26, 25)
        Me.butImport.TabIndex = 3
        Me.butImport.UseVisualStyleBackColor = True
        '
        'butAddPage
        '
        Me.butAddPage.FlatAppearance.BorderSize = 0
        Me.butAddPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butAddPage.Image = CType(resources.GetObject("butAddPage.Image"), System.Drawing.Image)
        Me.butAddPage.Location = New System.Drawing.Point(156, 2)
        Me.butAddPage.Margin = New System.Windows.Forms.Padding(2)
        Me.butAddPage.Name = "butAddPage"
        Me.butAddPage.Size = New System.Drawing.Size(26, 25)
        Me.butAddPage.TabIndex = 3
        Me.butAddPage.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel2.Controls.Add(Me.optYouTubeLinks)
        Me.Panel2.Controls.Add(Me.optTextFiles)
        Me.Panel2.Controls.Add(Me.optDocuments)
        Me.Panel2.Controls.Add(Me.optImages)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(754, 31)
        Me.Panel2.TabIndex = 4
        '
        'optYouTubeLinks
        '
        Me.optYouTubeLinks.Appearance = System.Windows.Forms.Appearance.Button
        Me.optYouTubeLinks.FlatAppearance.BorderSize = 0
        Me.optYouTubeLinks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optYouTubeLinks.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optYouTubeLinks.Location = New System.Drawing.Point(292, 2)
        Me.optYouTubeLinks.Margin = New System.Windows.Forms.Padding(2)
        Me.optYouTubeLinks.Name = "optYouTubeLinks"
        Me.optYouTubeLinks.Size = New System.Drawing.Size(96, 28)
        Me.optYouTubeLinks.TabIndex = 0
        Me.optYouTubeLinks.TabStop = True
        Me.optYouTubeLinks.Text = "Youtube"
        Me.optYouTubeLinks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optYouTubeLinks.UseVisualStyleBackColor = True
        '
        'optTextFiles
        '
        Me.optTextFiles.Appearance = System.Windows.Forms.Appearance.Button
        Me.optTextFiles.FlatAppearance.BorderSize = 0
        Me.optTextFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optTextFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optTextFiles.Location = New System.Drawing.Point(195, 2)
        Me.optTextFiles.Margin = New System.Windows.Forms.Padding(2)
        Me.optTextFiles.Name = "optTextFiles"
        Me.optTextFiles.Size = New System.Drawing.Size(96, 28)
        Me.optTextFiles.TabIndex = 0
        Me.optTextFiles.TabStop = True
        Me.optTextFiles.Text = "Text files"
        Me.optTextFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optTextFiles.UseVisualStyleBackColor = True
        '
        'optDocuments
        '
        Me.optDocuments.Appearance = System.Windows.Forms.Appearance.Button
        Me.optDocuments.FlatAppearance.BorderSize = 0
        Me.optDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optDocuments.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDocuments.Location = New System.Drawing.Point(98, 2)
        Me.optDocuments.Margin = New System.Windows.Forms.Padding(2)
        Me.optDocuments.Name = "optDocuments"
        Me.optDocuments.Size = New System.Drawing.Size(96, 28)
        Me.optDocuments.TabIndex = 0
        Me.optDocuments.TabStop = True
        Me.optDocuments.Text = "Documents"
        Me.optDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optDocuments.UseVisualStyleBackColor = True
        '
        'optImages
        '
        Me.optImages.Appearance = System.Windows.Forms.Appearance.Button
        Me.optImages.FlatAppearance.BorderSize = 0
        Me.optImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optImages.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optImages.Location = New System.Drawing.Point(2, 2)
        Me.optImages.Margin = New System.Windows.Forms.Padding(2)
        Me.optImages.Name = "optImages"
        Me.optImages.Size = New System.Drawing.Size(96, 28)
        Me.optImages.TabIndex = 0
        Me.optImages.TabStop = True
        Me.optImages.Text = "Images"
        Me.optImages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optImages.UseVisualStyleBackColor = True
        '
        'VideoPlayer1
        '
        Me.VideoPlayer1.Location = New System.Drawing.Point(16, 235)
        Me.VideoPlayer1.Margin = New System.Windows.Forms.Padding(2)
        Me.VideoPlayer1.Name = "VideoPlayer1"
        Me.VideoPlayer1.Size = New System.Drawing.Size(178, 162)
        Me.VideoPlayer1.TabIndex = 6
        Me.VideoPlayer1.Visible = False
        '
        'rtfText
        '
        Me.rtfText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtfText.Location = New System.Drawing.Point(210, 35)
        Me.rtfText.Margin = New System.Windows.Forms.Padding(2)
        Me.rtfText.Name = "rtfText"
        Me.rtfText.SelectionAlignment = VitalLogic.Applications.TextAlign.Left
        Me.rtfText.ShowMistakes = False
        Me.rtfText.Size = New System.Drawing.Size(68, 63)
        Me.rtfText.TabIndex = 3
        Me.rtfText.Text = ""
        '
        'ResearchElementsDesk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Controls.Add(Me.pnlMain)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ResearchElementsDesk"
        Me.Size = New System.Drawing.Size(754, 427)
        CType(Me.picPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picPicture As System.Windows.Forms.PictureBox
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents butSavePage As System.Windows.Forms.Button
    Friend WithEvents butDeletePage As System.Windows.Forms.Button
    Friend WithEvents butAddPage As System.Windows.Forms.Button
    Friend WithEvents rtfText As VitalLogic.Applications.AdvRichTextBox
    Friend WithEvents butImport As System.Windows.Forms.Button
    Friend WithEvents butCopy As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents optImages As System.Windows.Forms.RadioButton
    Friend WithEvents optDocuments As System.Windows.Forms.RadioButton
    Friend WithEvents optYouTubeLinks As System.Windows.Forms.RadioButton
    Friend WithEvents optTextFiles As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents VideoPlayer1 As VitalLogic.Applications.VideoPlayer
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents lstRObjects As ListBox
End Class
