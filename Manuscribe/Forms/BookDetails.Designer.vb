<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookDetails
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.lblSubTitle = New System.Windows.Forms.Label()
        Me.txtSubtitle = New System.Windows.Forms.TextBox()
        Me.lblCreatedTime = New System.Windows.Forms.Label()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.lblAuthor = New System.Windows.Forms.Label()
        Me.cbopageName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMBottom = New System.Windows.Forms.TextBox()
        Me.txtMRight = New System.Windows.Forms.TextBox()
        Me.txtMTop = New System.Windows.Forms.TextBox()
        Me.txtMLeft = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.butOK = New System.Windows.Forms.Button()
        Me.butCancel = New System.Windows.Forms.Button()
        Me.lblUpdatedon = New System.Windows.Forms.Label()
        Me.gpbPageDefinition = New System.Windows.Forms.GroupBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gpbPageDefinition.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.VitalLogic.Applications.My.Resources.Resources.book_64
        Me.PictureBox1.Location = New System.Drawing.Point(16, 27)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(120, 36)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(41, 20)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "&Title"
        '
        'txtTitle
        '
        Me.txtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.Location = New System.Drawing.Point(124, 59)
        Me.txtTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(416, 26)
        Me.txtTitle.TabIndex = 1
        '
        'lblSubTitle
        '
        Me.lblSubTitle.AutoSize = True
        Me.lblSubTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTitle.Location = New System.Drawing.Point(120, 100)
        Me.lblSubTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubTitle.Name = "lblSubTitle"
        Me.lblSubTitle.Size = New System.Drawing.Size(65, 20)
        Me.lblSubTitle.TabIndex = 2
        Me.lblSubTitle.Text = "&Subtitle"
        '
        'txtSubtitle
        '
        Me.txtSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtitle.Location = New System.Drawing.Point(124, 123)
        Me.txtSubtitle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubtitle.Name = "txtSubtitle"
        Me.txtSubtitle.Size = New System.Drawing.Size(416, 26)
        Me.txtSubtitle.TabIndex = 3
        '
        'lblCreatedTime
        '
        Me.lblCreatedTime.AutoSize = True
        Me.lblCreatedTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatedTime.Location = New System.Drawing.Point(103, 277)
        Me.lblCreatedTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCreatedTime.Name = "lblCreatedTime"
        Me.lblCreatedTime.Size = New System.Drawing.Size(101, 20)
        Me.lblCreatedTime.TabIndex = 9
        Me.lblCreatedTime.Text = "Created on: "
        '
        'txtAuthor
        '
        Me.txtAuthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthor.Location = New System.Drawing.Point(124, 188)
        Me.txtAuthor.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(416, 26)
        Me.txtAuthor.TabIndex = 5
        '
        'lblAuthor
        '
        Me.lblAuthor.AutoSize = True
        Me.lblAuthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthor.Location = New System.Drawing.Point(120, 165)
        Me.lblAuthor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuthor.Name = "lblAuthor"
        Me.lblAuthor.Size = New System.Drawing.Size(58, 20)
        Me.lblAuthor.TabIndex = 4
        Me.lblAuthor.Text = "&Author"
        '
        'cbopageName
        '
        Me.cbopageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbopageName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbopageName.FormattingEnabled = True
        Me.cbopageName.Location = New System.Drawing.Point(18, 43)
        Me.cbopageName.Margin = New System.Windows.Forms.Padding(4)
        Me.cbopageName.Name = "cbopageName"
        Me.cbopageName.Size = New System.Drawing.Size(217, 28)
        Me.cbopageName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Page"
        '
        'txtWidth
        '
        Me.txtWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWidth.Location = New System.Drawing.Point(18, 107)
        Me.txtWidth.Margin = New System.Windows.Forms.Padding(4)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(81, 26)
        Me.txtWidth.TabIndex = 3
        '
        'txtHeight
        '
        Me.txtHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(154, 107)
        Me.txtHeight.Margin = New System.Windows.Forms.Padding(4)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(81, 26)
        Me.txtHeight.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 84)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Width"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(150, 84)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "&Height"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMBottom)
        Me.GroupBox1.Controls.Add(Me.txtMRight)
        Me.GroupBox1.Controls.Add(Me.txtMTop)
        Me.GroupBox1.Controls.Add(Me.txtMLeft)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(-3, 149)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(257, 156)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "&Margins"
        '
        'txtMBottom
        '
        Me.txtMBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMBottom.Location = New System.Drawing.Point(153, 106)
        Me.txtMBottom.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMBottom.Name = "txtMBottom"
        Me.txtMBottom.Size = New System.Drawing.Size(81, 26)
        Me.txtMBottom.TabIndex = 7
        '
        'txtMRight
        '
        Me.txtMRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMRight.Location = New System.Drawing.Point(157, 48)
        Me.txtMRight.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMRight.Name = "txtMRight"
        Me.txtMRight.Size = New System.Drawing.Size(81, 26)
        Me.txtMRight.TabIndex = 3
        '
        'txtMTop
        '
        Me.txtMTop.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMTop.Location = New System.Drawing.Point(21, 106)
        Me.txtMTop.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMTop.Name = "txtMTop"
        Me.txtMTop.Size = New System.Drawing.Size(81, 26)
        Me.txtMTop.TabIndex = 5
        '
        'txtMLeft
        '
        Me.txtMLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMLeft.Location = New System.Drawing.Point(21, 48)
        Me.txtMLeft.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMLeft.Name = "txtMLeft"
        Me.txtMLeft.Size = New System.Drawing.Size(81, 26)
        Me.txtMLeft.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(153, 23)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "&Right"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(149, 82)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "&Bottom"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 82)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "&Top"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "&Left"
        '
        'butOK
        '
        Me.butOK.Location = New System.Drawing.Point(587, 391)
        Me.butOK.Margin = New System.Windows.Forms.Padding(4)
        Me.butOK.Name = "butOK"
        Me.butOK.Size = New System.Drawing.Size(100, 28)
        Me.butOK.TabIndex = 11
        Me.butOK.Text = "O&K"
        Me.butOK.UseVisualStyleBackColor = True
        '
        'butCancel
        '
        Me.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancel.Location = New System.Drawing.Point(708, 391)
        Me.butCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.butCancel.Name = "butCancel"
        Me.butCancel.Size = New System.Drawing.Size(100, 28)
        Me.butCancel.TabIndex = 12
        Me.butCancel.Text = "&Cancel"
        Me.butCancel.UseVisualStyleBackColor = True
        '
        'lblUpdatedon
        '
        Me.lblUpdatedon.AutoSize = True
        Me.lblUpdatedon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdatedon.Location = New System.Drawing.Point(103, 308)
        Me.lblUpdatedon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUpdatedon.Name = "lblUpdatedon"
        Me.lblUpdatedon.Size = New System.Drawing.Size(90, 20)
        Me.lblUpdatedon.TabIndex = 10
        Me.lblUpdatedon.Text = "Updted on:"
        '
        'gpbPageDefinition
        '
        Me.gpbPageDefinition.Controls.Add(Me.GroupBox1)
        Me.gpbPageDefinition.Controls.Add(Me.cbopageName)
        Me.gpbPageDefinition.Controls.Add(Me.txtHeight)
        Me.gpbPageDefinition.Controls.Add(Me.txtWidth)
        Me.gpbPageDefinition.Controls.Add(Me.Label3)
        Me.gpbPageDefinition.Controls.Add(Me.Label2)
        Me.gpbPageDefinition.Controls.Add(Me.Label1)
        Me.gpbPageDefinition.Location = New System.Drawing.Point(547, 14)
        Me.gpbPageDefinition.Name = "gpbPageDefinition"
        Me.gpbPageDefinition.Size = New System.Drawing.Size(262, 314)
        Me.gpbPageDefinition.TabIndex = 8
        Me.gpbPageDefinition.TabStop = False
        Me.gpbPageDefinition.Text = "Page  size"
        '
        'BookDetails
        '
        Me.AcceptButton = Me.butOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancel
        Me.ClientSize = New System.Drawing.Size(821, 444)
        Me.Controls.Add(Me.gpbPageDefinition)
        Me.Controls.Add(Me.butCancel)
        Me.Controls.Add(Me.butOK)
        Me.Controls.Add(Me.txtAuthor)
        Me.Controls.Add(Me.lblUpdatedon)
        Me.Controls.Add(Me.lblCreatedTime)
        Me.Controls.Add(Me.txtSubtitle)
        Me.Controls.Add(Me.lblAuthor)
        Me.Controls.Add(Me.lblSubTitle)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BookDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BookDetails"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpbPageDefinition.ResumeLayout(False)
        Me.gpbPageDefinition.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtTitle As TextBox
    Friend WithEvents lblSubTitle As Label
    Friend WithEvents txtSubtitle As TextBox
    Friend WithEvents lblCreatedTime As Label
    Friend WithEvents txtAuthor As TextBox
    Friend WithEvents lblAuthor As Label
    Friend WithEvents cbopageName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtWidth As TextBox
    Friend WithEvents txtHeight As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtMBottom As TextBox
    Friend WithEvents txtMRight As TextBox
    Friend WithEvents txtMTop As TextBox
    Friend WithEvents txtMLeft As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents butOK As Button
    Friend WithEvents butCancel As Button
    Friend WithEvents lblUpdatedon As Label
    Friend WithEvents gpbPageDefinition As System.Windows.Forms.GroupBox
End Class
