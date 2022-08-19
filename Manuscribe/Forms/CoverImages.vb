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
Public Class CoverImages

    Private Sub butBrowse_Click(sender As Object, e As EventArgs) Handles butBrowse.Click
        Try
            Dim ofd As New OpenFileDialog
            With ofd
                .Filter = "Image files(*.jpg,*.png,*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
                If .ShowDialog = DialogResult.OK Then
                    Dim img As Image
                    img = Bitmap.FromFile(.FileName)
                    PictureBox1.Image = img
                    If CurrentBook.Covers.ContainsKey(ComboBox1.SelectedIndex) Then
                        Dim cv As New Cover
                        cv.Type = ComboBox1.SelectedIndex
                        CurrentBook.Covers(ComboBox1.SelectedIndex).Format = IO.Path.GetExtension(.FileName).Substring(1).ToLower
                        CurrentBook.Covers(ComboBox1.SelectedIndex).Image = img
                        AddLog(TaskTypes.Added_cover_image)
                    Else
                        Dim cI As New Cover
                        cI.Type = ComboBox1.SelectedIndex
                        cI.image = img
                        cI.Format = IO.Path.GetExtension(.FileName).Substring(1).ToLower
                        CurrentBook.Covers.Add(ComboBox1.SelectedIndex, cI)
                        AddLog(TaskTypes.Added_cover_image)
                    End If
                End If
            End With
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub CoverImages_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Enter Then
            Me.Close()
        End If
    End Sub

    Private Sub CoverImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        lblDesiredSize.Text = "Desired size:" & CurrentBook.PageSet.Size.ToString
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butExit.Click

        Me.Close()
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If CurrentBook.Covers.ContainsKey(ComboBox1.SelectedIndex) Then
            PictureBox1.Image = CurrentBook.Covers(ComboBox1.SelectedIndex).Image
        Else
            PictureBox1.Image = Nothing

        End If
    End Sub

    Private Sub butDeleteCover_Click(sender As Object, e As EventArgs) Handles butDeleteCover.Click
        If CurrentBook.Covers.ContainsKey(ComboBox1.SelectedIndex) Then Exit Sub
        If MsgBox("Do you really want to remove this cover?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
        CurrentBook.Covers.Remove(ComboBox1.SelectedIndex)
        ComboBox1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub butSavePage_Click(sender As Object, e As EventArgs) Handles butSavePage.Click
        If CurrentBook.Covers.ContainsKey(ComboBox1.SelectedIndex) Then Exit Sub
        Dim sfd As New SaveFileDialog
        With sfd
            .Filter = "Image files(*.jpg)|*.jpg"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim bmp As Bitmap = CurrentBook.Covers(ComboBox1.SelectedIndex).Image
                bmp.Save(.FileName, ImageFormatfromString(CurrentBook.Covers(ComboBox1.SelectedIndex).Format))
                bmp.Dispose()
            End If
        End With
    End Sub
End Class