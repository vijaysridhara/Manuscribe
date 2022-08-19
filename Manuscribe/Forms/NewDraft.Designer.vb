<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewDraft
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewDraft))
        Me.txtSummary = New System.Windows.Forms.TextBox()
        Me.lblSubTitle = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.butOK = New System.Windows.Forms.Button()
        Me.optImage = New System.Windows.Forms.RadioButton()
        Me.optDocument = New System.Windows.Forms.RadioButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSummary
        '
        Me.txtSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSummary.Location = New System.Drawing.Point(104, 100)
        Me.txtSummary.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSummary.Multiline = True
        Me.txtSummary.Name = "txtSummary"
        Me.txtSummary.Size = New System.Drawing.Size(416, 115)
        Me.txtSummary.TabIndex = 3
        '
        'lblSubTitle
        '
        Me.lblSubTitle.AutoSize = True
        Me.lblSubTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitle.Location = New System.Drawing.Point(100, 76)
        Me.lblSubTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubTitle.Name = "lblSubTitle"
        Me.lblSubTitle.Size = New System.Drawing.Size(80, 20)
        Me.lblSubTitle.TabIndex = 2
        Me.lblSubTitle.Text = "&Summary"
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(104, 36)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(416, 26)
        Me.txtTitle.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(100, 12)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(41, 20)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "&Title"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(7, 12)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'butCancel
        '
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(421, 246)
        Me.butCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(100, 28)
        Me.butCancel.TabIndex = 5
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(300, 246)
        Me.butOK.Margin = New System.Windows.Forms.Padding(4)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(100, 28)
        Me.butOK.TabIndex = 4
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'optImage
        '
        Me.optImage.AutoSize = True
        Me.optImage.Location = New System.Drawing.Point(211, 246)
        Me.optImage.Margin = New System.Windows.Forms.Padding(4)
        Me.optImage.Name = "optImage"
        Me.optImage.Size = New System.Drawing.Size(67, 21)
        Me.optImage.TabIndex = 6
        Me.optImage.TabStop = True
        Me.optImage.Text = "&Image"
        Me.optImage.UseVisualStyleBackColor = True
        '
        'optDocument
        '
        Me.optDocument.AutoSize = True
        Me.optDocument.Checked = True
        Me.optDocument.Location = New System.Drawing.Point(104, 246)
        Me.optDocument.Margin = New System.Windows.Forms.Padding(4)
        Me.optDocument.Name = "optDocument"
        Me.optDocument.Size = New System.Drawing.Size(93, 21)
        Me.optDocument.TabIndex = 7
        Me.optDocument.TabStop = True
        Me.optDocument.Text = "&Document"
        Me.optDocument.UseVisualStyleBackColor = True
        '
        'NewDraft
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(547, 289)
        Me.Controls.Add(Me.optImage)
        Me.Controls.Add(Me.optDocument)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.txtSummary)
        Me.Controls.Add(Me.lblSubTitle)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "NewDraft"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Draft"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtSummary As TextBox
    Friend WithEvents lblSubTitle As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents butCancel As Button
    Friend WithEvents butOK As Button
    Friend WithEvents optImage As System.Windows.Forms.RadioButton
    Friend WithEvents optDocument As System.Windows.Forms.RadioButton
End Class
