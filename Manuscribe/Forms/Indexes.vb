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
Friend Class Indexes
    Private curPage As Page
    Private Sub Tags_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub New(currentPage As Page)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.curPage = currentPage
        txtIndexes.Text = String.Join(vbCrLf, curPage.IndexEntries.ToArray)
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        Try
            curPage.IndexEntries.Clear()
            curPage.IndexEntries.AddRange(txtIndexes.Text.Split(vbCrLf))
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
End Class