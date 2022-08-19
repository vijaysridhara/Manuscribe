<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintSettings))
        Me.cboPageNo = New System.Windows.Forms.ComboBox()
        Me.butBorderColor = New System.Windows.Forms.Button()
        Me.cboAlterNateNumberingtoChapter1 = New System.Windows.Forms.CheckBox()
        Me.cboBorder = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFillRectangle = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.butFillRectangle = New System.Windows.Forms.Button()
        Me.chkLeftImage = New System.Windows.Forms.CheckBox()
        Me.butTopImage = New System.Windows.Forms.Button()
        Me.chkRightImage = New System.Windows.Forms.CheckBox()
        Me.butBottomImage = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPageNoFormat = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTitleLoc = New System.Windows.Forms.ComboBox()
        Me.chkBookTitle = New System.Windows.Forms.CheckBox()
        Me.chkChaptername = New System.Windows.Forms.CheckBox()
        Me.txtDelimiter = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboAuthorLoc = New System.Windows.Forms.ComboBox()
        Me.butFont = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cboPageNo
        '
        Me.cboPageNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPageNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPageNo.FormattingEnabled = True
        Me.cboPageNo.Items.AddRange(New Object() {"None", "TopMiddle", "BottomMiddle", "TopCornerOut", "BottomCornerOut", "TopCornerIn", "BottomCornerIn"})
        Me.cboPageNo.Location = New System.Drawing.Point(157, 125)
        Me.cboPageNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboPageNo.Name = "cboPageNo"
        Me.cboPageNo.Size = New System.Drawing.Size(159, 28)
        Me.cboPageNo.TabIndex = 12
        '
        'butBorderColor
        '
        Me.butBorderColor.BackColor = System.Drawing.Color.Black
        Me.butBorderColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butBorderColor.Location = New System.Drawing.Point(323, 46)
        Me.butBorderColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butBorderColor.Name = "butBorderColor"
        Me.butBorderColor.Size = New System.Drawing.Size(41, 28)
        Me.butBorderColor.TabIndex = 3
        Me.butBorderColor.UseVisualStyleBackColor = False
        '
        'cboAlterNateNumberingtoChapter1
        '
        Me.cboAlterNateNumberingtoChapter1.AutoSize = True
        Me.cboAlterNateNumberingtoChapter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlterNateNumberingtoChapter1.Location = New System.Drawing.Point(16, 11)
        Me.cboAlterNateNumberingtoChapter1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboAlterNateNumberingtoChapter1.Name = "cboAlterNateNumberingtoChapter1"
        Me.cboAlterNateNumberingtoChapter1.Size = New System.Drawing.Size(606, 24)
        Me.cboAlterNateNumberingtoChapter1.TabIndex = 0
        Me.cboAlterNateNumberingtoChapter1.Text = "Chap 1 Alternate numbering(If you choose to make Preface etc on Chapter 1)"
        Me.cboAlterNateNumberingtoChapter1.UseVisualStyleBackColor = True
        '
        'cboBorder
        '
        Me.cboBorder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBorder.FormattingEnabled = True
        Me.cboBorder.Items.AddRange(New Object() {"None", "Box", "TopAndBottom", "TopOnly", "BottomOnly"})
        Me.cboBorder.Location = New System.Drawing.Point(157, 47)
        Me.cboBorder.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboBorder.Name = "cboBorder"
        Me.cboBorder.Size = New System.Drawing.Size(159, 28)
        Me.cboBorder.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Border"
        '
        'cboFillRectangle
        '
        Me.cboFillRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFillRectangle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFillRectangle.FormattingEnabled = True
        Me.cboFillRectangle.Items.AddRange(New Object() {"None", "TopAndBottom", "TopOnly", "BottomOnly"})
        Me.cboFillRectangle.Location = New System.Drawing.Point(530, 46)
        Me.cboFillRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboFillRectangle.Name = "cboFillRectangle"
        Me.cboFillRectangle.Size = New System.Drawing.Size(159, 28)
        Me.cboFillRectangle.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(385, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fill Rectangle"
        '
        'butFillRectangle
        '
        Me.butFillRectangle.BackColor = System.Drawing.Color.Black
        Me.butFillRectangle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butFillRectangle.Location = New System.Drawing.Point(696, 45)
        Me.butFillRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butFillRectangle.Name = "butFillRectangle"
        Me.butFillRectangle.Size = New System.Drawing.Size(41, 28)
        Me.butFillRectangle.TabIndex = 6
        Me.butFillRectangle.UseVisualStyleBackColor = False
        '
        'chkLeftImage
        '
        Me.chkLeftImage.AutoSize = True
        Me.chkLeftImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLeftImage.Location = New System.Drawing.Point(16, 87)
        Me.chkLeftImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkLeftImage.Name = "chkLeftImage"
        Me.chkLeftImage.Size = New System.Drawing.Size(110, 24)
        Me.chkLeftImage.TabIndex = 7
        Me.chkLeftImage.Text = "&Left Image"
        Me.chkLeftImage.UseVisualStyleBackColor = True
        '
        'butTopImage
        '
        Me.butTopImage.Enabled = False
        Me.butTopImage.Location = New System.Drawing.Point(157, 88)
        Me.butTopImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butTopImage.Name = "butTopImage"
        Me.butTopImage.Size = New System.Drawing.Size(56, 23)
        Me.butTopImage.TabIndex = 8
        Me.butTopImage.Text = "..."
        Me.butTopImage.UseVisualStyleBackColor = True
        '
        'chkRightImage
        '
        Me.chkRightImage.AutoSize = True
        Me.chkRightImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRightImage.Location = New System.Drawing.Point(389, 87)
        Me.chkRightImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkRightImage.Name = "chkRightImage"
        Me.chkRightImage.Size = New System.Drawing.Size(120, 24)
        Me.chkRightImage.TabIndex = 9
        Me.chkRightImage.Text = "&Right Image"
        Me.chkRightImage.UseVisualStyleBackColor = True
        '
        'butBottomImage
        '
        Me.butBottomImage.Enabled = False
        Me.butBottomImage.Location = New System.Drawing.Point(530, 87)
        Me.butBottomImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butBottomImage.Name = "butBottomImage"
        Me.butBottomImage.Size = New System.Drawing.Size(56, 23)
        Me.butBottomImage.TabIndex = 10
        Me.butBottomImage.Text = "..."
        Me.butBottomImage.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Location = New System.Drawing.Point(623, 352)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 42)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "E&xit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Page no loc"
        '
        'txtPageNoFormat
        '
        Me.txtPageNoFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtPageNoFormat.Location = New System.Drawing.Point(530, 133)
        Me.txtPageNoFormat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPageNoFormat.Name = "txtPageNoFormat"
        Me.txtPageNoFormat.Size = New System.Drawing.Size(153, 26)
        Me.txtPageNoFormat.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(385, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Page no format"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 20)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Title loc"
        '
        'cboTitleLoc
        '
        Me.cboTitleLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTitleLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTitleLoc.FormattingEnabled = True
        Me.cboTitleLoc.Items.AddRange(New Object() {"None", "TopMiddle", "BottomMiddle", "TopCornerOut", "BottomCornerOut", "TopCornerIn", "BottomCornerIn"})
        Me.cboTitleLoc.Location = New System.Drawing.Point(157, 168)
        Me.cboTitleLoc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboTitleLoc.Name = "cboTitleLoc"
        Me.cboTitleLoc.Size = New System.Drawing.Size(159, 28)
        Me.cboTitleLoc.TabIndex = 16
        '
        'chkBookTitle
        '
        Me.chkBookTitle.AutoSize = True
        Me.chkBookTitle.Enabled = False
        Me.chkBookTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBookTitle.Location = New System.Drawing.Point(626, 178)
        Me.chkBookTitle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkBookTitle.Name = "chkBookTitle"
        Me.chkBookTitle.Size = New System.Drawing.Size(101, 24)
        Me.chkBookTitle.TabIndex = 19
        Me.chkBookTitle.Text = "Book &title"
        Me.chkBookTitle.UseVisualStyleBackColor = True
        '
        'chkChaptername
        '
        Me.chkChaptername.AutoSize = True
        Me.chkChaptername.Checked = True
        Me.chkChaptername.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkChaptername.Enabled = False
        Me.chkChaptername.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkChaptername.Location = New System.Drawing.Point(389, 176)
        Me.chkChaptername.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkChaptername.Name = "chkChaptername"
        Me.chkChaptername.Size = New System.Drawing.Size(136, 24)
        Me.chkChaptername.TabIndex = 17
        Me.chkChaptername.Text = "Chapter name"
        Me.chkChaptername.UseVisualStyleBackColor = True
        '
        'txtDelimiter
        '
        Me.txtDelimiter.Enabled = False
        Me.txtDelimiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDelimiter.Location = New System.Drawing.Point(530, 176)
        Me.txtDelimiter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDelimiter.Name = "txtDelimiter"
        Me.txtDelimiter.Size = New System.Drawing.Size(67, 26)
        Me.txtDelimiter.TabIndex = 18
        Me.txtDelimiter.Text = " | "
        Me.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 20)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Author Loc"
        '
        'cboAuthorLoc
        '
        Me.cboAuthorLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAuthorLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAuthorLoc.FormattingEnabled = True
        Me.cboAuthorLoc.Items.AddRange(New Object() {"None", "TopMiddle", "BottomMiddle", "TopCornerOut", "BottomCornerOut", "TopCornerIn", "BottomCornerIn"})
        Me.cboAuthorLoc.Location = New System.Drawing.Point(157, 213)
        Me.cboAuthorLoc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboAuthorLoc.Name = "cboAuthorLoc"
        Me.cboAuthorLoc.Size = New System.Drawing.Size(159, 28)
        Me.cboAuthorLoc.TabIndex = 21
        '
        'butFont
        '
        Me.butFont.Location = New System.Drawing.Point(389, 212)
        Me.butFont.Name = "butFont"
        Me.butFont.Size = New System.Drawing.Size(338, 31)
        Me.butFont.TabIndex = 22
        Me.butFont.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(539, 153)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = resources.GetString("Label7.Text")
        '
        'PrintSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button3
        Me.ClientSize = New System.Drawing.Size(747, 405)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.butFont)
        Me.Controls.Add(Me.txtDelimiter)
        Me.Controls.Add(Me.txtPageNoFormat)
        Me.Controls.Add(Me.cboAlterNateNumberingtoChapter1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cboAuthorLoc)
        Me.Controls.Add(Me.cboTitleLoc)
        Me.Controls.Add(Me.cboPageNo)
        Me.Controls.Add(Me.butBottomImage)
        Me.Controls.Add(Me.butTopImage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFillRectangle)
        Me.Controls.Add(Me.cboBorder)
        Me.Controls.Add(Me.butFillRectangle)
        Me.Controls.Add(Me.chkChaptername)
        Me.Controls.Add(Me.chkBookTitle)
        Me.Controls.Add(Me.chkRightImage)
        Me.Controls.Add(Me.butBorderColor)
        Me.Controls.Add(Me.chkLeftImage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "PrintSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PrintSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPageNo As System.Windows.Forms.ComboBox
    Friend WithEvents butBorderColor As System.Windows.Forms.Button
    Friend WithEvents cboAlterNateNumberingtoChapter1 As System.Windows.Forms.CheckBox
    Friend WithEvents cboBorder As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFillRectangle As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents butFillRectangle As System.Windows.Forms.Button
    Friend WithEvents chkLeftImage As System.Windows.Forms.CheckBox
    Friend WithEvents butTopImage As System.Windows.Forms.Button
    Friend WithEvents chkRightImage As System.Windows.Forms.CheckBox
    Friend WithEvents butBottomImage As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPageNoFormat As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboTitleLoc As ComboBox
    Friend WithEvents chkBookTitle As CheckBox
    Friend WithEvents chkChaptername As CheckBox
    Friend WithEvents txtDelimiter As TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboAuthorLoc As System.Windows.Forms.ComboBox
    Friend WithEvents butFont As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
