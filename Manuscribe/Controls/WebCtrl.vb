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
Public Class WebCtrl
    Event WebEvent(msg As String)

    Private Sub butGo_Click(sender As Object, e As EventArgs) Handles butGo.Click
        If String.IsNullOrEmpty(cboURL.Text) Then Exit Sub
        WebBrowser1.Navigate(cboURL.Text)
        If cboURL.Items.Contains(cboURL.Text) = False Then cboURL.Items.Add(cboURL.Text)
    End Sub

    Private Sub cboURL_KeyDown(sender As Object, e As KeyEventArgs) Handles cboURL.KeyDown
        If e.KeyCode = Keys.Enter Then
            WebBrowser1.Navigate(cboURL.Text)
            If cboURL.Items.Contains(cboURL.Text) = False Then cboURL.Items.Add(cboURL.Text)
        End If
    End Sub



    Private Sub cboURL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboURL.SelectedIndexChanged

    End Sub

    Private Sub butStop_Click(sender As Object, e As EventArgs) Handles butStop.Click
        WebBrowser1.Stop()
    End Sub

    Private Sub butRefresh_Click(sender As Object, e As EventArgs) Handles butRefresh.Click
        WebBrowser1.Refresh()
    End Sub

    Private Sub butBack_Click(sender As Object, e As EventArgs) Handles butBack.Click
        WebBrowser1.GoBack()
        If WebBrowser1.CanGoBack Then
            butBack.Enabled = True
        Else
            butBack.Enabled = False
        End If
        butForward.Enabled = True
    End Sub

    Private Sub butForward_Click(sender As Object, e As EventArgs) Handles butForward.Click
        WebBrowser1.GoForward()
        If WebBrowser1.CanGoForward Then
            butForward.Enabled = True

        Else
            butForward.Enabled = False
        End If
        butBack.Enabled = True
    End Sub

    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        cboURL.Text = WebBrowser1.Url.AbsoluteUri
        If WebBrowser1.CanGoBack Then
            butBack.Enabled = True
        Else
            butBack.Enabled = False
        End If
        If WebBrowser1.CanGoForward Then
            butForward.Enabled = True

        Else
            butForward.Enabled = False
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating

    End Sub

    Private Sub WebBrowser1_StatusTextChanged(sender As Object, e As EventArgs) Handles WebBrowser1.StatusTextChanged
        RaiseEvent WebEvent(WebBrowser1.StatusText)
    End Sub
End Class
