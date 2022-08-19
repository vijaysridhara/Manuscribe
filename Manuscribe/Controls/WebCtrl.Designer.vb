<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebCtrl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WebCtrl))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.cboURL = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.butForward = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butBack = New System.Windows.Forms.Button()
        Me.butRefresh = New System.Windows.Forms.Button()
        Me.butStop = New System.Windows.Forms.Button()
        Me.butGo = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.cboURL)
        Me.pnlHeader.Controls.Add(Me.Panel1)
        Me.pnlHeader.Controls.Add(Me.butGo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(645, 30)
        Me.pnlHeader.TabIndex = 0
        '
        'cboURL
        '
        Me.cboURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboURL.FormattingEnabled = True
        Me.cboURL.Location = New System.Drawing.Point(161, 3)
        Me.cboURL.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cboURL.Name = "cboURL"
        Me.cboURL.Size = New System.Drawing.Size(438, 25)
        Me.cboURL.TabIndex = 3
        Me.cboURL.Text = "http:\\www.google.com"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.butForward)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.butBack)
        Me.Panel1.Controls.Add(Me.butRefresh)
        Me.Panel1.Controls.Add(Me.butStop)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 30)
        Me.Panel1.TabIndex = 2
        '
        'butForward
        '
        Me.butForward.Enabled = False
        Me.butForward.FlatAppearance.BorderSize = 0
        Me.butForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butForward.Image = CType(resources.GetObject("butForward.Image"), System.Drawing.Image)
        Me.butForward.Location = New System.Drawing.Point(34, 2)
        Me.butForward.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butForward.Name = "butForward"
        Me.butForward.Size = New System.Drawing.Size(26, 25)
        Me.butForward.TabIndex = 1
        Me.butForward.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(126, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "&URL"
        '
        'butBack
        '
        Me.butBack.Enabled = False
        Me.butBack.FlatAppearance.BorderSize = 0
        Me.butBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butBack.Image = CType(resources.GetObject("butBack.Image"), System.Drawing.Image)
        Me.butBack.Location = New System.Drawing.Point(3, 2)
        Me.butBack.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butBack.Name = "butBack"
        Me.butBack.Size = New System.Drawing.Size(26, 25)
        Me.butBack.TabIndex = 0
        Me.butBack.UseVisualStyleBackColor = True
        '
        'butRefresh
        '
        Me.butRefresh.FlatAppearance.BorderSize = 0
        Me.butRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butRefresh.Image = CType(resources.GetObject("butRefresh.Image"), System.Drawing.Image)
        Me.butRefresh.Location = New System.Drawing.Point(64, 2)
        Me.butRefresh.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butRefresh.Name = "butRefresh"
        Me.butRefresh.Size = New System.Drawing.Size(26, 25)
        Me.butRefresh.TabIndex = 2
        Me.butRefresh.UseVisualStyleBackColor = True
        '
        'butStop
        '
        Me.butStop.FlatAppearance.BorderSize = 0
        Me.butStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butStop.Image = CType(resources.GetObject("butStop.Image"), System.Drawing.Image)
        Me.butStop.Location = New System.Drawing.Point(95, 2)
        Me.butStop.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butStop.Name = "butStop"
        Me.butStop.Size = New System.Drawing.Size(26, 25)
        Me.butStop.TabIndex = 3
        Me.butStop.UseVisualStyleBackColor = True
        '
        'butGo
        '
        Me.butGo.Dock = System.Windows.Forms.DockStyle.Right
        Me.butGo.FlatAppearance.BorderSize = 0
        Me.butGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butGo.Image = CType(resources.GetObject("butGo.Image"), System.Drawing.Image)
        Me.butGo.Location = New System.Drawing.Point(603, 0)
        Me.butGo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butGo.Name = "butGo"
        Me.butGo.Size = New System.Drawing.Size(42, 30)
        Me.butGo.TabIndex = 1
        Me.butGo.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 30)
        Me.WebBrowser1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(15, 16)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(645, 349)
        Me.WebBrowser1.TabIndex = 0
        '
        'WebCtrl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.pnlHeader)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "WebCtrl"
        Me.Size = New System.Drawing.Size(645, 379)
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents butForward As System.Windows.Forms.Button
    Friend WithEvents butBack As System.Windows.Forms.Button
    Friend WithEvents butGo As System.Windows.Forms.Button
    Friend WithEvents butStop As System.Windows.Forms.Button
    Friend WithEvents butRefresh As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents cboURL As System.Windows.Forms.ComboBox

End Class
