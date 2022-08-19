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
Public Class VideoPlayer

    Dim html1 = "https://www.youtube.com/embed/{0}"
    Private _ishelp As Boolean
    Public Property IsHelp As Boolean
        Get
            Return _ishelp
        End Get
        Set(value As Boolean)
            _ishelp = value
            If _ishelp Then
                butAddPage.Hide()
                butDeletePage.Hide()
                Panel2.Height = 30
                lstURLS.Items.AddRange(My.Resources.TutorialVideos.Split(vbCrLf))
                txtURL.Hide()
            Else
                butAddPage.Show()
                butDeletePage.Show()
                Panel2.Height = 90
                txtURL.Show()
            End If
        End Set
    End Property
    Public Sub LoadURLS()
        Try
            If lstURLS.Items.Count > 0 Then Exit Sub
            lstURLS.Items.Clear()
            Dim html = "<html> <head><meta http-equiv=""X-UA-Compatible"" content=""IE=edge""> </head><body><iframe id=""video""  width=""" & WebBrowser1.Width & """ height=""" & WebBrowser1.Height & """ src=""https://www.youtube.com/embed/{0}"" frameborder=""0"" allow=""autoplay; encrypted-media"" fs=""1"" modestBranding=""1"" rel=""0"" allowfullscreen></iframe></body></html>"

            WebBrowser1.DocumentText = String.Format(html, My.Settings.ReleaseVideo.Split("=")(1))
            WebBrowser1.Update()
            For Each url In CurrentBook.YVideos
                lstURLS.Items.Add(url)
            Next
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butPlay_Click(sender As Object, e As EventArgs) Handles butPlay.Click
        Try
            If String.IsNullOrEmpty(txtURL.Text) Then Exit Sub
            If txtURL.Text.Contains("=") = False Then
                MsgBox("The video lacks id, or the URL is not valid", MsgBoxStyle.Information)
                Exit Sub
            End If
            ' WebBrowser1.Navigate(txtURL.Text)
            Dim html = "<html> <head><meta http-equiv=""X-UA-Compatible"" content=""IE=edge""> </head><body><iframe id=""video""  width=""" & WebBrowser1.Width & """ height=""" & WebBrowser1.Height & """ src=""https://www.youtube.com/embed/{0}"" frameborder=""0"" allow=""autoplay; encrypted-media"" fs=""1"" modestBranding=""1"" rel=""0"" allowfullscreen></iframe></body></html>"

            WebBrowser1.DocumentText = String.Format(html, txtURL.Text.Split("=")(1))
            WebBrowser1.Update()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub lstURLS_DoubleClick(sender As Object, e As EventArgs) Handles lstURLS.DoubleClick
        If lstURLS.SelectedIndex = -1 Then Exit Sub
        butPlay_Click(Nothing, Nothing)
    End Sub


    Private Sub lstURLS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstURLS.SelectedIndexChanged
        If lstURLS.SelectedIndex = -1 Then Exit Sub
        txtURL.Text = lstURLS.Text
    End Sub

    Private Sub txtURL_GotFocus(sender As Object, e As EventArgs) Handles txtURL.GotFocus
        txtURL.SelectAll()
    End Sub

    Private Sub txtURL_TextChanged(sender As Object, e As EventArgs) Handles txtURL.TextChanged

    End Sub

    Private Sub butAddPage_Click(sender As Object, e As EventArgs) Handles butAddPage.Click
        If lstURLS.Items.Contains(txtURL.Text) Then
            lstURLS.SelectedItem = txtURL.Text
            Exit Sub
        End If
        If txtURL.Text.Contains("https://www.youtube.com/watch?v=") = False Then
            MsgBox("The URL must be of the form " & vbCrLf & "Brief:https://www.youtube.com/watch?v=VIDEO_ID", MsgBoxStyle.Information)
            Exit Sub
        End If
        CurrentBook.YVideos.Add(txtURL.Text)
        CurrentBook.RaiseChanged()
        lstURLS.Items.Add(txtURL.Text)
        txtURL.Clear()
    End Sub

    Private Sub butDeletePage_Click(sender As Object, e As EventArgs) Handles butDeletePage.Click
        If lstURLS.SelectedIndex = -1 Then Exit Sub
        CurrentBook.YVideos.Remove(lstURLS.SelectedItem)
        CurrentBook.RaiseChanged()
        lstURLS.Items.Remove(lstURLS.SelectedItem)
        txtURL.Clear()
    End Sub


End Class
