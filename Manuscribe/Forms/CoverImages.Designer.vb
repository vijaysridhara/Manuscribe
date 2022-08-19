<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CoverImages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CoverImages))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.butBrowse = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.lblDesiredSize = New System.Windows.Forms.Label()
        Me.butDeleteCover = New System.Windows.Forms.Button()
        Me.butSavePage = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Frontout", "Frontin", "Backin", "Backout"})
        Me.ComboBox1.Location = New System.Drawing.Point(200, 28)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(193, 24)
        Me.ComboBox1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(196, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Image type"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(13, 9)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(167, 169)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'butBrowse
        '
        Me.butBrowse.Location = New System.Drawing.Point(413, 28)
        Me.butBrowse.Margin = New System.Windows.Forms.Padding(4)
        Me.butBrowse.Name = "butBrowse"
        Me.butBrowse.Size = New System.Drawing.Size(64, 28)
        Me.butBrowse.TabIndex = 2
        Me.butBrowse.Text = "..."
        Me.butBrowse.UseVisualStyleBackColor = True
        '
        'butExit
        '
        Me.butExit.Location = New System.Drawing.Point(373, 151)
        Me.butExit.Margin = New System.Windows.Forms.Padding(4)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(91, 28)
        Me.butExit.TabIndex = 6
        Me.butExit.Text = "O&K"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'lblDesiredSize
        '
        Me.lblDesiredSize.AutoSize = True
        Me.lblDesiredSize.Location = New System.Drawing.Point(196, 75)
        Me.lblDesiredSize.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDesiredSize.Name = "lblDesiredSize"
        Me.lblDesiredSize.Size = New System.Drawing.Size(0, 17)
        Me.lblDesiredSize.TabIndex = 3
        '
        'butDeleteCover
        '
        Me.butDeleteCover.FlatAppearance.BorderSize = 0
        Me.butDeleteCover.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butDeleteCover.Image = CType(resources.GetObject("butDeleteCover.Image"), System.Drawing.Image)
        Me.butDeleteCover.Location = New System.Drawing.Point(199, 150)
        Me.butDeleteCover.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butDeleteCover.Name = "butDeleteCover"
        Me.butDeleteCover.Size = New System.Drawing.Size(35, 31)
        Me.butDeleteCover.TabIndex = 5
        Me.butDeleteCover.UseVisualStyleBackColor = True
        '
        'butSavePage
        '
        Me.butSavePage.FlatAppearance.BorderSize = 0
        Me.butSavePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.butSavePage.Image = CType(resources.GetObject("butSavePage.Image"), System.Drawing.Image)
        Me.butSavePage.Location = New System.Drawing.Point(199, 115)
        Me.butSavePage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butSavePage.Name = "butSavePage"
        Me.butSavePage.Size = New System.Drawing.Size(35, 31)
        Me.butSavePage.TabIndex = 4
        Me.butSavePage.UseVisualStyleBackColor = True
        '
        'CoverImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 194)
        Me.Controls.Add(Me.butSavePage)
        Me.Controls.Add(Me.butDeleteCover)
        Me.Controls.Add(Me.lblDesiredSize)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butBrowse)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CoverImages"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CoverImages"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents butBrowse As Button
    Friend WithEvents butExit As Button
    Friend WithEvents lblDesiredSize As Label
    Friend WithEvents butDeleteCover As System.Windows.Forms.Button
    Friend WithEvents butSavePage As System.Windows.Forms.Button
End Class
