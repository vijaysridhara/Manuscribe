<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PageList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PageList))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.colHPageSeq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSampleText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHWords = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.butDown = New System.Windows.Forms.Button()
        Me.butUp = New System.Windows.Forms.Button()
        Me.colHName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHPageSeq, Me.colHName, Me.colSampleText, Me.colHWords})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(2, 4)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(698, 374)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'colHPageSeq
        '
        Me.colHPageSeq.Text = "Seq"
        Me.colHPageSeq.Width = 61
        '
        'colSampleText
        '
        Me.colSampleText.Text = "Sample content"
        Me.colSampleText.Width = 400
        '
        'colHWords
        '
        Me.colHWords.Text = "Words"
        Me.colHWords.Width = 76
        '
        'butDown
        '
        Me.butDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butDown.Enabled = False
        Me.butDown.Image = CType(resources.GetObject("butDown.Image"), System.Drawing.Image)
        Me.butDown.Location = New System.Drawing.Point(715, 162)
        Me.butDown.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butDown.Name = "butDown"
        Me.butDown.Size = New System.Drawing.Size(43, 41)
        Me.butDown.TabIndex = 3
        Me.butDown.UseVisualStyleBackColor = True
        '
        'butUp
        '
        Me.butUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butUp.Enabled = False
        Me.butUp.Image = CType(resources.GetObject("butUp.Image"), System.Drawing.Image)
        Me.butUp.Location = New System.Drawing.Point(715, 107)
        Me.butUp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butUp.Name = "butUp"
        Me.butUp.Size = New System.Drawing.Size(43, 41)
        Me.butUp.TabIndex = 4
        Me.butUp.UseVisualStyleBackColor = True
        '
        'colHName
        '
        Me.colHName.Text = "Name"
        Me.colHName.Width = 150
        '
        'PageList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 384)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.butDown)
        Me.Controls.Add(Me.butUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "PageList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PageList"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents colHPageSeq As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSampleText As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHWords As System.Windows.Forms.ColumnHeader
    Friend WithEvents butDown As System.Windows.Forms.Button
    Friend WithEvents butUp As System.Windows.Forms.Button
    Friend WithEvents colHName As System.Windows.Forms.ColumnHeader
End Class
