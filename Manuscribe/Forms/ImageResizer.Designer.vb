<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageResizer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.trkSize = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblOriginalSize = New System.Windows.Forms.Label()
        Me.lblNewSize = New System.Windows.Forms.Label()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(258, 270)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'trkSize
        '
        Me.trkSize.Location = New System.Drawing.Point(285, 105)
        Me.trkSize.Maximum = 100
        Me.trkSize.Minimum = 10
        Me.trkSize.Name = "trkSize"
        Me.trkSize.Size = New System.Drawing.Size(418, 56)
        Me.trkSize.TabIndex = 1
        Me.trkSize.TickFrequency = 5
        Me.trkSize.Value = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(293, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Resize percent"
        '
        'lblOriginalSize
        '
        Me.lblOriginalSize.AutoSize = True
        Me.lblOriginalSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginalSize.Location = New System.Drawing.Point(293, 43)
        Me.lblOriginalSize.Name = "lblOriginalSize"
        Me.lblOriginalSize.Size = New System.Drawing.Size(105, 20)
        Me.lblOriginalSize.TabIndex = 2
        Me.lblOriginalSize.Text = "Original Size"
        '
        'lblNewSize
        '
        Me.lblNewSize.AutoSize = True
        Me.lblNewSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewSize.Location = New System.Drawing.Point(293, 164)
        Me.lblNewSize.Name = "lblNewSize"
        Me.lblNewSize.Size = New System.Drawing.Size(80, 20)
        Me.lblNewSize.TabIndex = 2
        Me.lblNewSize.Text = "New Size"
        '
        'butOK
        '
        Me.butOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butOK.Location = New System.Drawing.Point(526, 268)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(84, 34)
        Me.butOK.TabIndex = 3
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCancel.Location = New System.Drawing.Point(628, 268)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 34)
        Me.butCancel.TabIndex = 3
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'ImageResizer
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(729, 314)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.lblNewSize)
        Me.Controls.Add(Me.lblOriginalSize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trkSize)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ImageResizer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ImageResizer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents trkSize As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblOriginalSize As System.Windows.Forms.Label
    Friend WithEvents lblNewSize As System.Windows.Forms.Label
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
End Class
