<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BookDetailsCtl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BookDetailsCtl))
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.pnlPageThumbs = New System.Windows.Forms.Panel()
        Me.optAbout = New System.Windows.Forms.RadioButton()
        Me.optShowHelp = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblCopyRight = New System.Windows.Forms.Label()
        Me.lblAppVersion = New System.Windows.Forms.Label()
        Me.lblAppName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.optVideos = New System.Windows.Forms.RadioButton()
        Me.VideoPlayer1 = New VitalLogic.Applications.VideoPlayer()
        Me.pnlPageThumbs.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(142, 63)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(255, 373)
        Me.RichTextBox1.TabIndex = 22
        Me.RichTextBox1.Text = ""
        '
        'pnlPageThumbs
        '
        Me.pnlPageThumbs.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pnlPageThumbs.Controls.Add(Me.optAbout)
        Me.pnlPageThumbs.Controls.Add(Me.optShowHelp)
        Me.pnlPageThumbs.Controls.Add(Me.optVideos)
        Me.pnlPageThumbs.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPageThumbs.Location = New System.Drawing.Point(0, 0)
        Me.pnlPageThumbs.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlPageThumbs.Name = "pnlPageThumbs"
        Me.pnlPageThumbs.Size = New System.Drawing.Size(94, 482)
        Me.pnlPageThumbs.TabIndex = 23
        '
        'optAbout
        '
        Me.optAbout.Appearance = System.Windows.Forms.Appearance.Button
        Me.optAbout.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.optAbout.Dock = System.Windows.Forms.DockStyle.Top
        Me.optAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optAbout.Location = New System.Drawing.Point(0, 58)
        Me.optAbout.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optAbout.Name = "optAbout"
        Me.optAbout.Size = New System.Drawing.Size(94, 29)
        Me.optAbout.TabIndex = 1
        Me.optAbout.Text = "About"
        Me.optAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optAbout.UseVisualStyleBackColor = False
        '
        'optShowHelp
        '
        Me.optShowHelp.Appearance = System.Windows.Forms.Appearance.Button
        Me.optShowHelp.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.optShowHelp.Dock = System.Windows.Forms.DockStyle.Top
        Me.optShowHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optShowHelp.Location = New System.Drawing.Point(0, 29)
        Me.optShowHelp.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optShowHelp.Name = "optShowHelp"
        Me.optShowHelp.Size = New System.Drawing.Size(94, 29)
        Me.optShowHelp.TabIndex = 0
        Me.optShowHelp.Text = "Quick help"
        Me.optShowHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optShowHelp.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(94, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(44, 482)
        Me.Panel2.TabIndex = 24
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(679, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(79, 482)
        Me.Panel3.TabIndex = 25
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblDescription)
        Me.Panel1.Controls.Add(Me.lblCopyRight)
        Me.Panel1.Controls.Add(Me.lblAppVersion)
        Me.Panel1.Controls.Add(Me.lblAppName)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(164, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(594, 393)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(19, 334)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(38, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Monotype Corsiva", 10.2!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 348)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(189, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "For the most beautiful lady of my life"
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.Black
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.Lime
        Me.lblDescription.Location = New System.Drawing.Point(19, 158)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(552, 174)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "Label1"
        '
        'lblCopyRight
        '
        Me.lblCopyRight.AutoSize = True
        Me.lblCopyRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyRight.Location = New System.Drawing.Point(152, 114)
        Me.lblCopyRight.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCopyRight.Name = "lblCopyRight"
        Me.lblCopyRight.Size = New System.Drawing.Size(51, 17)
        Me.lblCopyRight.TabIndex = 1
        Me.lblCopyRight.Text = "Label1"
        '
        'lblAppVersion
        '
        Me.lblAppVersion.AutoSize = True
        Me.lblAppVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppVersion.Location = New System.Drawing.Point(148, 80)
        Me.lblAppVersion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAppVersion.Name = "lblAppVersion"
        Me.lblAppVersion.Size = New System.Drawing.Size(311, 20)
        Me.lblAppVersion.TabIndex = 1
        Me.lblAppVersion.Text = "Version: {0}.{1} Build: {2} Revision: {3}"
        '
        'lblAppName
        '
        Me.lblAppName.AutoSize = True
        Me.lblAppName.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppName.Location = New System.Drawing.Point(148, 48)
        Me.lblAppName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(72, 24)
        Me.lblAppName.TabIndex = 1
        Me.lblAppName.Text = "Label1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(19, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 124)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'optVideos
        '
        Me.optVideos.Appearance = System.Windows.Forms.Appearance.Button
        Me.optVideos.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.optVideos.Checked = True
        Me.optVideos.Dock = System.Windows.Forms.DockStyle.Top
        Me.optVideos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optVideos.Location = New System.Drawing.Point(0, 0)
        Me.optVideos.Margin = New System.Windows.Forms.Padding(2)
        Me.optVideos.Name = "optVideos"
        Me.optVideos.Size = New System.Drawing.Size(94, 29)
        Me.optVideos.TabIndex = 2
        Me.optVideos.TabStop = True
        Me.optVideos.Text = "On Youtube"
        Me.optVideos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optVideos.UseVisualStyleBackColor = False
        '
        'VideoPlayer1
        '
        Me.VideoPlayer1.IsHelp = True
        Me.VideoPlayer1.Location = New System.Drawing.Point(446, 412)
        Me.VideoPlayer1.Margin = New System.Windows.Forms.Padding(2)
        Me.VideoPlayer1.Name = "VideoPlayer1"
        Me.VideoPlayer1.Size = New System.Drawing.Size(687, 447)
        Me.VideoPlayer1.TabIndex = 26
        '
        'BookDetailsCtl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.VideoPlayer1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlPageThumbs)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "BookDetailsCtl"
        Me.Size = New System.Drawing.Size(758, 482)
        Me.pnlPageThumbs.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents pnlPageThumbs As System.Windows.Forms.Panel
    Friend WithEvents optShowHelp As System.Windows.Forms.RadioButton
    Friend WithEvents optAbout As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblCopyRight As System.Windows.Forms.Label
    Friend WithEvents lblAppName As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblAppVersion As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optVideos As RadioButton
    Friend WithEvents VideoPlayer1 As VideoPlayer
End Class
