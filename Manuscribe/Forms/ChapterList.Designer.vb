<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChapterList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChapterList))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.colHChapSeq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cholHTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSynopsis = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHPages = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHWords = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.butUp = New System.Windows.Forms.Button()
        Me.butDown = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHChapSeq, Me.cholHTitle, Me.colSynopsis, Me.colHPages, Me.colHWords})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 22)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(948, 351)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'colHChapSeq
        '
        Me.colHChapSeq.Text = "Seq"
        Me.colHChapSeq.Width = 61
        '
        'cholHTitle
        '
        Me.cholHTitle.Text = "Title"
        Me.cholHTitle.Width = 150
        '
        'colSynopsis
        '
        Me.colSynopsis.Text = "Synopsis"
        Me.colSynopsis.Width = 366
        '
        'colHPages
        '
        Me.colHPages.Text = "Pgs"
        Me.colHPages.Width = 46
        '
        'colHWords
        '
        Me.colHWords.Text = "Words"
        Me.colHWords.Width = 76
        '
        'butUp
        '
        Me.butUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butUp.Enabled = False
        Me.butUp.Image = CType(resources.GetObject("butUp.Image"), System.Drawing.Image)
        Me.butUp.Location = New System.Drawing.Point(967, 134)
        Me.butUp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butUp.Name = "butUp"
        Me.butUp.Size = New System.Drawing.Size(43, 41)
        Me.butUp.TabIndex = 1
        Me.butUp.UseVisualStyleBackColor = True
        '
        'butDown
        '
        Me.butDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butDown.Enabled = False
        Me.butDown.Image = CType(resources.GetObject("butDown.Image"), System.Drawing.Image)
        Me.butDown.Location = New System.Drawing.Point(967, 181)
        Me.butDown.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butDown.Name = "butDown"
        Me.butDown.Size = New System.Drawing.Size(43, 41)
        Me.butDown.TabIndex = 1
        Me.butDown.UseVisualStyleBackColor = True
        '
        'ChapterList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 385)
        Me.Controls.Add(Me.butDown)
        Me.Controls.Add(Me.butUp)
        Me.Controls.Add(Me.ListView1)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "ChapterList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ChapterList"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents colHChapSeq As System.Windows.Forms.ColumnHeader
    Friend WithEvents cholHTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSynopsis As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHPages As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHWords As System.Windows.Forms.ColumnHeader
    Friend WithEvents butUp As System.Windows.Forms.Button
    Friend WithEvents butDown As System.Windows.Forms.Button
End Class
