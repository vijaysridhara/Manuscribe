<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoPlayer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VideoPlayer))
        Me.lstURLS = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.butPlay = New System.Windows.Forms.Button()
        Me.butDeletePage = New System.Windows.Forms.Button()
        Me.butAddPage = New System.Windows.Forms.Button()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstURLS
        '
        Me.lstURLS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstURLS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstURLS.FormattingEnabled = True
        Me.lstURLS.ItemHeight = 17
        Me.lstURLS.Location = New System.Drawing.Point(0, 91)
        Me.lstURLS.Margin = New System.Windows.Forms.Padding(2)
        Me.lstURLS.Name = "lstURLS"
        Me.lstURLS.Size = New System.Drawing.Size(206, 356)
        Me.lstURLS.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lstURLS)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(206, 447)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel2.Controls.Add(Me.txtURL)
        Me.Panel2.Controls.Add(Me.butPlay)
        Me.Panel2.Controls.Add(Me.butDeletePage)
        Me.Panel2.Controls.Add(Me.butAddPage)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(206, 91)
        Me.Panel2.TabIndex = 2
        '
        'txtURL
        '
        Me.txtURL.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtURL.Location = New System.Drawing.Point(0, 0)
        Me.txtURL.Margin = New System.Windows.Forms.Padding(2)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(206, 23)
        Me.txtURL.TabIndex = 3
        Me.txtURL.Text = "Summary:YoutubeURL"
        '
        'butPlay
        '
        Me.butPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butPlay.FlatAppearance.BorderSize = 0
        Me.butPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butPlay.Image = CType(resources.GetObject("butPlay.Image"), System.Drawing.Image)
        Me.butPlay.Location = New System.Drawing.Point(176, 66)
        Me.butPlay.Margin = New System.Windows.Forms.Padding(2)
        Me.butPlay.Name = "butPlay"
        Me.butPlay.Size = New System.Drawing.Size(26, 25)
        Me.butPlay.TabIndex = 1
        Me.butPlay.UseVisualStyleBackColor = True
        '
        'butDeletePage
        '
        Me.butDeletePage.FlatAppearance.BorderSize = 0
        Me.butDeletePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butDeletePage.Image = CType(resources.GetObject("butDeletePage.Image"), System.Drawing.Image)
        Me.butDeletePage.Location = New System.Drawing.Point(2, 25)
        Me.butDeletePage.Margin = New System.Windows.Forms.Padding(2)
        Me.butDeletePage.Name = "butDeletePage"
        Me.butDeletePage.Size = New System.Drawing.Size(26, 25)
        Me.butDeletePage.TabIndex = 1
        Me.butDeletePage.UseVisualStyleBackColor = True
        '
        'butAddPage
        '
        Me.butAddPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAddPage.FlatAppearance.BorderSize = 0
        Me.butAddPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butAddPage.Image = CType(resources.GetObject("butAddPage.Image"), System.Drawing.Image)
        Me.butAddPage.Location = New System.Drawing.Point(176, 25)
        Me.butAddPage.Margin = New System.Windows.Forms.Padding(2)
        Me.butAddPage.Name = "butAddPage"
        Me.butAddPage.Size = New System.Drawing.Size(26, 25)
        Me.butAddPage.TabIndex = 2
        Me.butAddPage.UseVisualStyleBackColor = True
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(206, 0)
        Me.Splitter1.Margin = New System.Windows.Forms.Padding(2)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(2, 447)
        Me.Splitter1.TabIndex = 3
        Me.Splitter1.TabStop = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(208, 0)
        Me.WebBrowser1.Margin = New System.Windows.Forms.Padding(2)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(15, 16)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(479, 447)
        Me.WebBrowser1.TabIndex = 4
        '
        'VideoPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "VideoPlayer"
        Me.Size = New System.Drawing.Size(687, 447)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstURLS As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents butDeletePage As System.Windows.Forms.Button
    Friend WithEvents butAddPage As System.Windows.Forms.Button
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents butPlay As System.Windows.Forms.Button

End Class
