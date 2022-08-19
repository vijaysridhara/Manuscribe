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
Public Class IdeaCtl
    Inherits Control
    Dim pnlFooter As New Label
    Private WithEvents pnlContent As New Label
    Private WithEvents txtContent As New TextBox
    Private _idea As Idea
    Public Sub New(ide As Idea)
        Me.SuspendLayout()
        pnlFooter.Height = 20
        pnlFooter.AutoSize = False
        pnlFooter.Text = ide.SavedON
        Me.Controls.Add(pnlFooter)
        pnlFooter.Dock = DockStyle.Bottom
        pnlContent.AutoSize = False
        pnlContent.Font = New Font("Arial", 10, FontStyle.Regular)
        pnlContent.Text = ide.Content
        pnlContent.Dock = DockStyle.Fill
        Me.Controls.Add(pnlContent)
        txtContent.Dock = DockStyle.Fill
        txtContent.BorderStyle = BorderStyle.None
        Me.Controls.Add(txtContent)
        txtContent.Hide()
        pnlContent.Padding = New Padding(10)

        txtContent.Font = New Font("Arial", 10, FontStyle.Regular)
        Me.BackColor = Color.LightYellow
        pnlContent.BackColor = Color.Transparent
        txtContent.BackColor = Color.LightYellow
        txtContent.Multiline = True
        Me.Size = New Size(256, 200)
        Me.ResumeLayout()
        Me._idea = ide
    End Sub

    Private Sub pnlContent_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles pnlContent.DoubleClick
        Debug.Print(Clipboard.GetText)
        pnlContent.Hide()
        txtContent.Text = pnlContent.Text
        txtContent.Show()
        Debug.Print(Clipboard.GetText)
    End Sub

    Private Sub txtContent_Leave(sender As Object, e As EventArgs) Handles txtContent.LostFocus
        txtContent.Hide()
        pnlContent.Show()
        pnlContent.Text = txtContent.Text

        _idea.Content = txtContent.Text

    End Sub
End Class
