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
Public Class BookDetailsCtl

    Private Sub BookDetailsCtl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ShowDetails()


        RichTextBox1.Rtf = My.Resources.Welcome_to_Manuscribe
        RichTextBox1.Dock = DockStyle.Fill
        RichTextBox1.ReadOnly = True
        Panel2.Show()
        Panel3.Show()
        Panel1.Hide()
        VideoPlayer1.Hide()
        RichTextBox1.Show()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblAppName.Text = My.Application.Info.ProductName
        lblAppVersion.Text = String.Format(lblAppVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        lblCopyRight.Text = My.Application.Info.Copyright
        lblDescription.Text = My.Application.Info.Description
    End Sub

    'Private Sub BookDetailsCtl_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
    '    ShowDetails()
    'End Sub

    Private Sub optShowHelp_CheckedChanged(sender As Object, e As EventArgs) Handles optShowHelp.CheckedChanged
        If optShowHelp.Checked Then
            ShowDetails()
        End If

    End Sub

    Private Sub optShowDetails_CheckedChanged(sender As Object, e As EventArgs) Handles optAbout.CheckedChanged
        If optAbout.Checked Then
            Panel1.Show()
            Panel2.Hide()
            Panel3.Hide()
            RichTextBox1.Hide()
            VideoPlayer1.Hide()
        End If
    End Sub

    Private Sub BookDetailsCtl_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel1.Location = New Point(Me.Width / 2 - Panel1.Width / 2 + pnlPageThumbs.Width, Me.Height / 2 - Panel1.Height / 2)
    End Sub

    Private Sub BookDetailsCtl_TabStopChanged(sender As Object, e As EventArgs) Handles Me.TabStopChanged

    End Sub

    Private Sub optVideos_CheckedChanged(sender As Object, e As EventArgs) Handles optVideos.CheckedChanged
        If optVideos.Checked Then
            Panel1.Show()
            Panel2.Hide()
            Panel3.Hide()
            RichTextBox1.Hide()
            VideoPlayer1.Show()
            VideoPlayer1.Dock = DockStyle.Fill
        End If
    End Sub
End Class
