'***********************************************************************
'Copyright 2020-2022 Vijay Sridhara

'Licensed under the Apache License, Version 2.0 (the "License");
'you may not use this file except in compliance with the License.
'You may obtain a copy of the License at

'http://www.apache.org/licenses/LICENSE-2.0

'Unless required by applicable law or agreed to in writing, software
'distributed under the License is distributed on an "AS IS" BASIS,
'WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'See the License for the specific language governing permissions and
'limitations under the License.
'***********************************************************************
Friend Class SynopControl
    Inherits Control
    Private WithEvents txtEdit As New TextBox
    Private WithEvents lblTitle As New Label
    Private WithEvents lblContent As New Label
    Private _c As Chapter
    Event ChapterNameChanged(c As Chapter)
    Public Property Chapter As Chapter
        Get
            Return _c
        End Get
        Set(value As Chapter)
            _c = value
            lblTitle.Text = _c.Name
            lblContent.Text = _c.Synopsis
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        lblTitle.Dock = DockStyle.Top
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Arial", 11, FontStyle.Bold)
        Me.BackColor = Color.Transparent
        Me.BackgroundImage = My.Resources.butterfly
        lblTitle.Text = "Synopsis"
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        lblContent.Text = "Content"
        lblContent.Dock = DockStyle.Fill
        lblContent.AutoSize = False
        lblTitle.AutoSize = False
        lblTitle.BorderStyle = BorderStyle.None
        lblContent.BorderStyle = BorderStyle.None
        lblTitle.Height = 40
        lblTitle.Padding = New Padding(10, 10, 0, 0)

        lblContent.Font = New Font("Ariaal", 10, FontStyle.Regular)
        lblContent.BackColor = Color.Transparent
        txtEdit.Multiline = True
        Me.Controls.Add(lblTitle)
        Me.Controls.Add(lblContent)
        Me.Controls.Add(txtEdit)
        txtEdit.Hide()
        lblContent.BringToFront()
    End Sub

    Private Sub lblContent_DoubleClick(sender As Object, e As EventArgs) Handles lblContent.DoubleClick
        txtEdit_LostFocus(Nothing, Nothing)
        txtEdit.Text = lblContent.Text
        txtEdit.Font = lblContent.Font
        txtEdit.Size = lblContent.Size

        txtEdit.Location = lblContent.Location
        ' txtEdit.Dock = DockStyle.Fill
        txtEdit.Tag = "C"
        ' lblContent.Hide()
        txtEdit.Show()
        txtEdit.BringToFront()
        txtEdit.SelectionStart = txtEdit.TextLength
        txtEdit.Focus()
    End Sub

    Private Sub txtEdit_Leave(sender As Object, e As EventArgs) Handles txtEdit.Leave
        txtEdit_LostFocus(sender, e)
    End Sub

    Private Sub txtEdit_LostFocus(sender As Object, e As EventArgs) Handles txtEdit.LostFocus
        If txtEdit.Visible Then
            If txtEdit.Tag = "T" Then
                lblTitle.Text = txtEdit.Text
                Chapter.Name = lblTitle.Text
                RaiseEvent ChapterNameChanged(Chapter)
                txtEdit.Hide()
                lblTitle.Show()
            Else
                lblContent.Text = txtEdit.Text
                Chapter.Synopsis = lblContent.Text
                txtEdit.Hide()
                lblContent.Show()
            End If
        End If
    End Sub

    Private Sub lblTitle_DoubleClick(sender As Object, e As EventArgs) Handles lblTitle.DoubleClick
        txtEdit_LostFocus(Nothing, Nothing)
        txtEdit.Text = lblTitle.Text
        txtEdit.Font = lblTitle.Font
        txtEdit.Size = lblTitle.Size
        txtEdit.Location = New Point(0, 0)

        txtEdit.Tag = "T"
        'lblTitle.Hide()
        txtEdit.Show()
        txtEdit.BringToFront()
        txtEdit.SelectionStart = txtEdit.TextLength
        txtEdit.Focus()
    End Sub
End Class
