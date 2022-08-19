<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectBook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectBook))
        Me.pnlRecentBook = New System.Windows.Forms.Panel()
        Me.butOpenDifferent = New System.Windows.Forms.Button()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.optCreateNew = New System.Windows.Forms.RadioButton()
        Me.optOpenExisting = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'pnlRecentBook
        '
        Me.pnlRecentBook.AutoScroll = True
        Me.pnlRecentBook.BackColor = System.Drawing.Color.White
        Me.pnlRecentBook.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlRecentBook.Location = New System.Drawing.Point(-1, 96)
        Me.pnlRecentBook.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlRecentBook.Name = "pnlRecentBook"
        Me.pnlRecentBook.Size = New System.Drawing.Size(540, 217)
        Me.pnlRecentBook.TabIndex = 0
        '
        'butOpenDifferent
        '
        Me.butOpenDifferent.Location = New System.Drawing.Point(195, 372)
        Me.butOpenDifferent.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butOpenDifferent.Name = "butOpenDifferent"
        Me.butOpenDifferent.Size = New System.Drawing.Size(75, 30)
        Me.butOpenDifferent.TabIndex = 1
        Me.butOpenDifferent.Text = "..."
        Me.butOpenDifferent.UseVisualStyleBackColor = True
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(378, 372)
        Me.butOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(75, 30)
        Me.butOK.TabIndex = 1
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(464, 372)
        Me.butCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(75, 30)
        Me.butCancel.TabIndex = 1
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 379)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Not listed above? Click here"
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(4, 317)
        Me.lblPath.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(535, 47)
        Me.lblPath.TabIndex = 2
        '
        'optCreateNew
        '
        Me.optCreateNew.Appearance = System.Windows.Forms.Appearance.Button
        Me.optCreateNew.Image = CType(resources.GetObject("optCreateNew.Image"), System.Drawing.Image)
        Me.optCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.optCreateNew.Location = New System.Drawing.Point(7, 6)
        Me.optCreateNew.Name = "optCreateNew"
        Me.optCreateNew.Size = New System.Drawing.Size(205, 85)
        Me.optCreateNew.TabIndex = 3
        Me.optCreateNew.Text = "Create new"
        Me.optCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optCreateNew.UseVisualStyleBackColor = True
        '
        'optOpenExisting
        '
        Me.optOpenExisting.Appearance = System.Windows.Forms.Appearance.Button
        Me.optOpenExisting.Checked = True
        Me.optOpenExisting.Image = CType(resources.GetObject("optOpenExisting.Image"), System.Drawing.Image)
        Me.optOpenExisting.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optOpenExisting.Location = New System.Drawing.Point(341, 6)
        Me.optOpenExisting.Name = "optOpenExisting"
        Me.optOpenExisting.Size = New System.Drawing.Size(187, 85)
        Me.optOpenExisting.TabIndex = 3
        Me.optOpenExisting.TabStop = True
        Me.optOpenExisting.Text = "Open existing"
        Me.optOpenExisting.UseVisualStyleBackColor = True
        '
        'SelectBook
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(540, 409)
        Me.Controls.Add(Me.optOpenExisting)
        Me.Controls.Add(Me.optCreateNew)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.butOpenDifferent)
        Me.Controls.Add(Me.pnlRecentBook)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MinimizeBox = False
        Me.Name = "SelectBook"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelectBook"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlRecentBook As System.Windows.Forms.Panel
    Friend WithEvents butOpenDifferent As System.Windows.Forms.Button
    Friend WithEvents butOK As System.Windows.Forms.Button
    Friend WithEvents butCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblPath As Label
    Friend WithEvents optCreateNew As RadioButton
    Friend WithEvents optOpenExisting As RadioButton
End Class
