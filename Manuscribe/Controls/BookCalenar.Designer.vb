<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookCalenar
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.colHSNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHWordCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colHWCDifference = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colHSNo, Me.colHDate, Me.colHWordCount, Me.colHWCDifference})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(225, 43)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(386, 366)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'colHSNo
        '
        Me.colHSNo.Text = "S.No"
        Me.colHSNo.Width = 77
        '
        'colHDate
        '
        Me.colHDate.Text = "On date"
        Me.colHDate.Width = 100
        '
        'colHWordCount
        '
        Me.colHWordCount.Text = "Word Count"
        Me.colHWordCount.Width = 115
        '
        'colHWCDifference
        '
        Me.colHWCDifference.Text = "Delta"
        Me.colHWCDifference.Width = 81
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(830, 44)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Progress"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BookCalenar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "BookCalenar"
        Me.Size = New System.Drawing.Size(830, 411)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents colHSNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colHDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colHWordCount As ColumnHeader
    Friend WithEvents colHWCDifference As ColumnHeader
End Class
