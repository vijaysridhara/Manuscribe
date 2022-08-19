<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pagedef
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
        Me.optDocument = New System.Windows.Forms.RadioButton()
        Me.optImage = New System.Windows.Forms.RadioButton()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCanel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'optDocument
        '
        Me.optDocument.AutoSize = True
        Me.optDocument.Checked = True
        Me.optDocument.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDocument.Location = New System.Drawing.Point(30, 60)
        Me.optDocument.Margin = New System.Windows.Forms.Padding(4)
        Me.optDocument.Name = "optDocument"
        Me.optDocument.Size = New System.Drawing.Size(107, 24)
        Me.optDocument.TabIndex = 2
        Me.optDocument.TabStop = True
        Me.optDocument.Text = "&Document"
        Me.optDocument.UseVisualStyleBackColor = True
        '
        'optImage
        '
        Me.optImage.AutoSize = True
        Me.optImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optImage.Location = New System.Drawing.Point(145, 60)
        Me.optImage.Margin = New System.Windows.Forms.Padding(4)
        Me.optImage.Name = "optImage"
        Me.optImage.Size = New System.Drawing.Size(75, 24)
        Me.optImage.TabIndex = 3
        Me.optImage.TabStop = True
        Me.optImage.Text = "&Image"
        Me.optImage.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butOK.Location = New System.Drawing.Point(4, 90)
        Me.butOK.Margin = New System.Windows.Forms.Padding(4)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(108, 38)
        Me.butOK.TabIndex = 4
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCanel
        '
        Me.butCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butCanel.Location = New System.Drawing.Point(120, 90)
        Me.butCanel.Margin = New System.Windows.Forms.Padding(4)
        Me.butCanel.Name = "butCanel"
        Me.butCanel.Size = New System.Drawing.Size(100, 38)
        Me.butCanel.TabIndex = 5
        Me.butCanel.Text = "&Cancel"
        Me.butCanel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Name"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(4, 26)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(217, 27)
        Me.txtName.TabIndex = 1
        '
        'Pagedef
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCanel
        Me.ClientSize = New System.Drawing.Size(237, 139)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butCanel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.optImage)
        Me.Controls.Add(Me.optDocument)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Pagedef"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PageType"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents optDocument As RadioButton
    Friend WithEvents optImage As RadioButton
    Friend WithEvents butOK As Button
    Friend WithEvents butCanel As Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
End Class
