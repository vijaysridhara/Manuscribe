<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Findform
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
        Me.butReplace = New System.Windows.Forms.Button()
        Me.txtFind1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReplace = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.optFind = New System.Windows.Forms.RadioButton()
        Me.optReplace = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.butClose = New System.Windows.Forms.Button()
        Me.butFindNext = New System.Windows.Forms.Button()
        Me.butReplaceAll = New System.Windows.Forms.Button()
        Me.chkWholeword = New System.Windows.Forms.CheckBox()
        Me.chkMatchCase = New System.Windows.Forms.CheckBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'butReplace
        '
        Me.butReplace.Enabled = False
        Me.butReplace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butReplace.Location = New System.Drawing.Point(208, 104)
        Me.butReplace.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butReplace.Name = "butReplace"
        Me.butReplace.Size = New System.Drawing.Size(88, 27)
        Me.butReplace.TabIndex = 7
        Me.butReplace.Text = "&Replace"
        Me.butReplace.UseVisualStyleBackColor = True
        '
        'txtFind1
        '
        Me.txtFind1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFind1.Location = New System.Drawing.Point(10, 22)
        Me.txtFind1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtFind1.Name = "txtFind1"
        Me.txtFind1.Size = New System.Drawing.Size(377, 23)
        Me.txtFind1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fi&nd what"
        '
        'txtReplace
        '
        Me.txtReplace.Enabled = False
        Me.txtReplace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReplace.Location = New System.Drawing.Point(10, 73)
        Me.txtReplace.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.Size = New System.Drawing.Size(377, 23)
        Me.txtReplace.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 55)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Re&place with"
        '
        'optFind
        '
        Me.optFind.Appearance = System.Windows.Forms.Appearance.Button
        Me.optFind.AutoSize = True
        Me.optFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optFind.Location = New System.Drawing.Point(4, 4)
        Me.optFind.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optFind.Name = "optFind"
        Me.optFind.Size = New System.Drawing.Size(45, 27)
        Me.optFind.TabIndex = 0
        Me.optFind.Text = "Find"
        Me.optFind.UseVisualStyleBackColor = True
        '
        'optReplace
        '
        Me.optReplace.Appearance = System.Windows.Forms.Appearance.Button
        Me.optReplace.AutoSize = True
        Me.optReplace.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optReplace.Location = New System.Drawing.Point(49, 4)
        Me.optReplace.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.optReplace.Name = "optReplace"
        Me.optReplace.Size = New System.Drawing.Size(70, 27)
        Me.optReplace.TabIndex = 1
        Me.optReplace.Text = "Replace"
        Me.optReplace.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtFind1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtReplace)
        Me.Panel1.Controls.Add(Me.chkWholeword)
        Me.Panel1.Controls.Add(Me.butClose)
        Me.Panel1.Controls.Add(Me.butFindNext)
        Me.Panel1.Controls.Add(Me.butReplaceAll)
        Me.Panel1.Controls.Add(Me.butReplace)
        Me.Panel1.Controls.Add(Me.chkMatchCase)
        Me.Panel1.Location = New System.Drawing.Point(5, 31)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(394, 148)
        Me.Panel1.TabIndex = 2
        '
        'butClose
        '
        Me.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butClose.Location = New System.Drawing.Point(10, 104)
        Me.butClose.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(89, 27)
        Me.butClose.TabIndex = 9
        Me.butClose.Text = "&Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'butFindNext
        '
        Me.butFindNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butFindNext.Location = New System.Drawing.Point(120, 104)
        Me.butFindNext.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butFindNext.Name = "butFindNext"
        Me.butFindNext.Size = New System.Drawing.Size(83, 27)
        Me.butFindNext.TabIndex = 6
        Me.butFindNext.Text = "&Find next"
        Me.butFindNext.UseVisualStyleBackColor = True
        '
        'butReplaceAll
        '
        Me.butReplaceAll.Enabled = False
        Me.butReplaceAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butReplaceAll.Location = New System.Drawing.Point(300, 104)
        Me.butReplaceAll.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.butReplaceAll.Name = "butReplaceAll"
        Me.butReplaceAll.Size = New System.Drawing.Size(86, 27)
        Me.butReplaceAll.TabIndex = 8
        Me.butReplaceAll.Text = "Replace &all"
        Me.butReplaceAll.UseVisualStyleBackColor = True
        '
        'chkWholeword
        '
        Me.chkWholeword.AutoSize = True
        Me.chkWholeword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWholeword.Location = New System.Drawing.Point(183, 48)
        Me.chkWholeword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.chkWholeword.Name = "chkWholeword"
        Me.chkWholeword.Size = New System.Drawing.Size(101, 21)
        Me.chkWholeword.TabIndex = 2
        Me.chkWholeword.Text = "W&hole word"
        Me.chkWholeword.UseVisualStyleBackColor = True
        '
        'chkMatchCase
        '
        Me.chkMatchCase.AutoSize = True
        Me.chkMatchCase.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMatchCase.Location = New System.Drawing.Point(288, 48)
        Me.chkMatchCase.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.chkMatchCase.Name = "chkMatchCase"
        Me.chkMatchCase.Size = New System.Drawing.Size(99, 21)
        Me.chkMatchCase.TabIndex = 3
        Me.chkMatchCase.Text = "&Match case"
        Me.chkMatchCase.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Enabled = False
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(9, 167)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 17)
        Me.lblMessage.TabIndex = 4
        '
        'Findform
        '
        Me.AcceptButton = Me.butFindNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butClose
        Me.ClientSize = New System.Drawing.Size(400, 190)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.optReplace)
        Me.Controls.Add(Me.optFind)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Findform"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Find and Replace"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFind1 As System.Windows.Forms.TextBox
    Friend WithEvents butReplace As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReplace As System.Windows.Forms.TextBox
    Friend WithEvents optFind As System.Windows.Forms.RadioButton
    Friend WithEvents optReplace As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents butFindNext As System.Windows.Forms.Button
    Friend WithEvents butReplaceAll As System.Windows.Forms.Button
    Friend WithEvents chkMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents butClose As System.Windows.Forms.Button
    Friend WithEvents chkWholeword As System.Windows.Forms.CheckBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
End Class
