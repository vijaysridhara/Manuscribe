<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Indexes
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
        Me.txtIndexes = New System.Windows.Forms.TextBox()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtIndexes
        '
        Me.txtIndexes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIndexes.Location = New System.Drawing.Point(1, 4)
        Me.txtIndexes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIndexes.Multiline = True
        Me.txtIndexes.Name = "txtIndexes"
        Me.txtIndexes.Size = New System.Drawing.Size(579, 251)
        Me.txtIndexes.TabIndex = 0
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(373, 263)
        Me.butOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(100, 28)
        Me.butOK.TabIndex = 1
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(481, 263)
        Me.butCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(100, 28)
        Me.butCancel.TabIndex = 1
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'Indexes
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(588, 300)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.txtIndexes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Indexes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Index entries"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtIndexes As TextBox
    Friend WithEvents butOK As Button
    Friend WithEvents butCancel As Button
End Class
