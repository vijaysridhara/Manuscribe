<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StylesDef
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
        Me.components = New System.ComponentModel.Container()
        Me.lstStyleSet = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lstStyles = New System.Windows.Forms.ListBox()
        Me.cboFontname = New System.Windows.Forms.ComboBox()
        Me.AdvRichTextBox1 = New VitalLogic.Applications.AdvRichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSize = New System.Windows.Forms.ComboBox()
        Me.butBold = New System.Windows.Forms.Button()
        Me.butItalic = New System.Windows.Forms.Button()
        Me.butUnderline = New System.Windows.Forms.Button()
        Me.butStrikethrough = New System.Windows.Forms.Button()
        Me.butBackcolor = New System.Windows.Forms.Button()
        Me.butForeColor = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSTyleName = New System.Windows.Forms.TextBox()
        Me.butApply = New System.Windows.Forms.Button()
        Me.butAddStyle = New System.Windows.Forms.Button()
        Me.butRemoveStyle = New System.Windows.Forms.Button()
        Me.lblFontNameError = New System.Windows.Forms.Label()
        Me.butAddStyleSet = New System.Windows.Forms.Button()
        Me.butRemoveStyleSet = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.chkkApplyBacklor = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lstStyleSet
        '
        Me.lstStyleSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstStyleSet.FormattingEnabled = True
        Me.lstStyleSet.ItemHeight = 17
        Me.lstStyleSet.Location = New System.Drawing.Point(9, 26)
        Me.lstStyleSet.Margin = New System.Windows.Forms.Padding(2)
        Me.lstStyleSet.Name = "lstStyleSet"
        Me.lstStyleSet.Size = New System.Drawing.Size(174, 327)
        Me.lstStyleSet.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Stylesets"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(415, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fonts"
        '
        'lstStyles
        '
        Me.lstStyles.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstStyles.FormattingEnabled = True
        Me.lstStyles.ItemHeight = 17
        Me.lstStyles.Location = New System.Drawing.Point(211, 26)
        Me.lstStyles.Margin = New System.Windows.Forms.Padding(2)
        Me.lstStyles.Name = "lstStyles"
        Me.lstStyles.Size = New System.Drawing.Size(158, 327)
        Me.lstStyles.TabIndex = 0
        '
        'cboFontname
        '
        Me.cboFontname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFontname.FormattingEnabled = True
        Me.cboFontname.Location = New System.Drawing.Point(418, 71)
        Me.cboFontname.Margin = New System.Windows.Forms.Padding(2)
        Me.cboFontname.Name = "cboFontname"
        Me.cboFontname.Size = New System.Drawing.Size(92, 21)
        Me.cboFontname.TabIndex = 2
        '
        'AdvRichTextBox1
        '
        Me.AdvRichTextBox1.BackColor = System.Drawing.Color.White
        Me.AdvRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdvRichTextBox1.Location = New System.Drawing.Point(373, 156)
        Me.AdvRichTextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.AdvRichTextBox1.Name = "AdvRichTextBox1"
        Me.AdvRichTextBox1.ReadOnly = True
        Me.AdvRichTextBox1.SelectionAlignment = VitalLogic.Applications.TextAlign.Center
        Me.AdvRichTextBox1.Size = New System.Drawing.Size(381, 152)
        Me.AdvRichTextBox1.TabIndex = 3
        Me.AdvRichTextBox1.Text = "Sample Text Appearance"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(510, 52)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Size"
        '
        'cboSize
        '
        Me.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSize.FormattingEnabled = True
        Me.cboSize.Location = New System.Drawing.Point(513, 71)
        Me.cboSize.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Size = New System.Drawing.Size(64, 21)
        Me.cboSize.TabIndex = 2
        '
        'butBold
        '
        Me.butBold.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butBold.Location = New System.Drawing.Point(592, 55)
        Me.butBold.Margin = New System.Windows.Forms.Padding(2)
        Me.butBold.Name = "butBold"
        Me.butBold.Size = New System.Drawing.Size(35, 35)
        Me.butBold.TabIndex = 4
        Me.butBold.Text = "B"
        Me.butBold.UseVisualStyleBackColor = True
        '
        'butItalic
        '
        Me.butItalic.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butItalic.Location = New System.Drawing.Point(632, 55)
        Me.butItalic.Margin = New System.Windows.Forms.Padding(2)
        Me.butItalic.Name = "butItalic"
        Me.butItalic.Size = New System.Drawing.Size(35, 35)
        Me.butItalic.TabIndex = 4
        Me.butItalic.Text = "I"
        Me.butItalic.UseVisualStyleBackColor = True
        '
        'butUnderline
        '
        Me.butUnderline.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butUnderline.Location = New System.Drawing.Point(671, 55)
        Me.butUnderline.Margin = New System.Windows.Forms.Padding(2)
        Me.butUnderline.Name = "butUnderline"
        Me.butUnderline.Size = New System.Drawing.Size(35, 35)
        Me.butUnderline.TabIndex = 4
        Me.butUnderline.Text = "U"
        Me.butUnderline.UseVisualStyleBackColor = True
        '
        'butStrikethrough
        '
        Me.butStrikethrough.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butStrikethrough.Location = New System.Drawing.Point(711, 55)
        Me.butStrikethrough.Margin = New System.Windows.Forms.Padding(2)
        Me.butStrikethrough.Name = "butStrikethrough"
        Me.butStrikethrough.Size = New System.Drawing.Size(35, 35)
        Me.butStrikethrough.TabIndex = 4
        Me.butStrikethrough.Text = "S"
        Me.butStrikethrough.UseVisualStyleBackColor = True
        '
        'butBackcolor
        '
        Me.butBackcolor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.butBackcolor.Enabled = False
        Me.butBackcolor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butBackcolor.Location = New System.Drawing.Point(418, 95)
        Me.butBackcolor.Margin = New System.Windows.Forms.Padding(2)
        Me.butBackcolor.Name = "butBackcolor"
        Me.butBackcolor.Size = New System.Drawing.Size(98, 35)
        Me.butBackcolor.TabIndex = 4
        Me.butBackcolor.Text = "Highlight color"
        Me.butBackcolor.UseVisualStyleBackColor = False
        '
        'butForeColor
        '
        Me.butForeColor.BackColor = System.Drawing.Color.White
        Me.butForeColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butForeColor.Location = New System.Drawing.Point(520, 95)
        Me.butForeColor.Margin = New System.Windows.Forms.Padding(2)
        Me.butForeColor.Name = "butForeColor"
        Me.butForeColor.Size = New System.Drawing.Size(100, 35)
        Me.butForeColor.TabIndex = 4
        Me.butForeColor.Text = "Font Color"
        Me.butForeColor.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(415, 7)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Style name"
        '
        'txtSTyleName
        '
        Me.txtSTyleName.Enabled = False
        Me.txtSTyleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSTyleName.Location = New System.Drawing.Point(418, 26)
        Me.txtSTyleName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSTyleName.Name = "txtSTyleName"
        Me.txtSTyleName.Size = New System.Drawing.Size(159, 23)
        Me.txtSTyleName.TabIndex = 5
        '
        'butApply
        '
        Me.butApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butApply.Location = New System.Drawing.Point(639, 95)
        Me.butApply.Margin = New System.Windows.Forms.Padding(2)
        Me.butApply.Name = "butApply"
        Me.butApply.Size = New System.Drawing.Size(107, 35)
        Me.butApply.TabIndex = 4
        Me.butApply.Text = "Apply"
        Me.butApply.UseVisualStyleBackColor = True
        '
        'butAddStyle
        '
        Me.butAddStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butAddStyle.Location = New System.Drawing.Point(373, 77)
        Me.butAddStyle.Margin = New System.Windows.Forms.Padding(2)
        Me.butAddStyle.Name = "butAddStyle"
        Me.butAddStyle.Size = New System.Drawing.Size(25, 24)
        Me.butAddStyle.TabIndex = 4
        Me.butAddStyle.Text = "+"
        Me.butAddStyle.UseVisualStyleBackColor = True
        '
        'butRemoveStyle
        '
        Me.butRemoveStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butRemoveStyle.Location = New System.Drawing.Point(373, 105)
        Me.butRemoveStyle.Margin = New System.Windows.Forms.Padding(2)
        Me.butRemoveStyle.Name = "butRemoveStyle"
        Me.butRemoveStyle.Size = New System.Drawing.Size(25, 25)
        Me.butRemoveStyle.TabIndex = 4
        Me.butRemoveStyle.Text = "-"
        Me.butRemoveStyle.UseVisualStyleBackColor = True
        '
        'lblFontNameError
        '
        Me.lblFontNameError.AutoSize = True
        Me.lblFontNameError.ForeColor = System.Drawing.Color.Red
        Me.lblFontNameError.Location = New System.Drawing.Point(590, 31)
        Me.lblFontNameError.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFontNameError.Name = "lblFontNameError"
        Me.lblFontNameError.Size = New System.Drawing.Size(0, 13)
        Me.lblFontNameError.TabIndex = 6
        '
        'butAddStyleSet
        '
        Me.butAddStyleSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butAddStyleSet.Location = New System.Drawing.Point(184, 128)
        Me.butAddStyleSet.Margin = New System.Windows.Forms.Padding(2)
        Me.butAddStyleSet.Name = "butAddStyleSet"
        Me.butAddStyleSet.Size = New System.Drawing.Size(25, 24)
        Me.butAddStyleSet.TabIndex = 4
        Me.butAddStyleSet.Text = "+"
        Me.butAddStyleSet.UseVisualStyleBackColor = True
        '
        'butRemoveStyleSet
        '
        Me.butRemoveStyleSet.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butRemoveStyleSet.Location = New System.Drawing.Point(184, 156)
        Me.butRemoveStyleSet.Margin = New System.Windows.Forms.Padding(2)
        Me.butRemoveStyleSet.Name = "butRemoveStyleSet"
        Me.butRemoveStyleSet.Size = New System.Drawing.Size(25, 25)
        Me.butRemoveStyleSet.TabIndex = 4
        Me.butRemoveStyleSet.Text = "-"
        Me.butRemoveStyleSet.UseVisualStyleBackColor = True
        '
        'butExit
        '
        Me.butExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butExit.Location = New System.Drawing.Point(647, 312)
        Me.butExit.Margin = New System.Windows.Forms.Padding(2)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(107, 35)
        Me.butExit.TabIndex = 4
        Me.butExit.Text = "E&xit"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'chkkApplyBacklor
        '
        Me.chkkApplyBacklor.AutoSize = True
        Me.chkkApplyBacklor.Location = New System.Drawing.Point(440, 135)
        Me.chkkApplyBacklor.Name = "chkkApplyBacklor"
        Me.chkkApplyBacklor.Size = New System.Drawing.Size(105, 17)
        Me.chkkApplyBacklor.TabIndex = 7
        Me.chkkApplyBacklor.Text = "Apply back color"
        Me.chkkApplyBacklor.UseVisualStyleBackColor = True
        '
        'StylesDef
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 358)
        Me.Controls.Add(Me.chkkApplyBacklor)
        Me.Controls.Add(Me.lblFontNameError)
        Me.Controls.Add(Me.txtSTyleName)
        Me.Controls.Add(Me.butStrikethrough)
        Me.Controls.Add(Me.butUnderline)
        Me.Controls.Add(Me.butForeColor)
        Me.Controls.Add(Me.butItalic)
        Me.Controls.Add(Me.butBackcolor)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butApply)
        Me.Controls.Add(Me.butRemoveStyleSet)
        Me.Controls.Add(Me.butAddStyleSet)
        Me.Controls.Add(Me.butRemoveStyle)
        Me.Controls.Add(Me.butAddStyle)
        Me.Controls.Add(Me.butBold)
        Me.Controls.Add(Me.AdvRichTextBox1)
        Me.Controls.Add(Me.cboSize)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboFontname)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstStyles)
        Me.Controls.Add(Me.lstStyleSet)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "StylesDef"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "StylesDef"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstStyleSet As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstStyles As System.Windows.Forms.ListBox
    Friend WithEvents cboFontname As System.Windows.Forms.ComboBox
    Friend WithEvents AdvRichTextBox1 As VitalLogic.Applications.AdvRichTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSize As System.Windows.Forms.ComboBox
    Friend WithEvents butBold As System.Windows.Forms.Button
    Friend WithEvents butItalic As System.Windows.Forms.Button
    Friend WithEvents butUnderline As System.Windows.Forms.Button
    Friend WithEvents butStrikethrough As System.Windows.Forms.Button
    Friend WithEvents butBackcolor As System.Windows.Forms.Button
    Friend WithEvents butForeColor As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSTyleName As System.Windows.Forms.TextBox
    Friend WithEvents butApply As System.Windows.Forms.Button
    Friend WithEvents butAddStyle As System.Windows.Forms.Button
    Friend WithEvents butRemoveStyle As System.Windows.Forms.Button
    Friend WithEvents lblFontNameError As System.Windows.Forms.Label
    Friend WithEvents butAddStyleSet As System.Windows.Forms.Button
    Friend WithEvents butRemoveStyleSet As System.Windows.Forms.Button
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents chkkApplyBacklor As CheckBox
End Class
