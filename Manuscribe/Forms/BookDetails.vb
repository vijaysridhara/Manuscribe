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
Public Class BookDetails

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtTitle.Text = CurrentBook.Title
        txtSubtitle.Text = CurrentBook.Subtitle
        txtAuthor.Text = CurrentBook.Author

        cbopageName.Items.AddRange(pageTypes.Keys.ToArray)
        'cboStructure.SelectedIndex = CurrentBook.Struct
        cbopageName.Text = CurrentBook.PageSet.Name
        txtWidth.Text = CurrentBook.PageSet.Size.Width
        txtHeight.Text = CurrentBook.PageSet.Size.Height
        txtMLeft.Text = CurrentBook.PageSet.Margins.Left
        txtMRight.Text = CurrentBook.PageSet.Margins.Right
        txtMTop.Text = CurrentBook.PageSet.Margins.Top
        txtMBottom.Text = CurrentBook.PageSet.Margins.Bottom
        lblCreatedTime.Text = "Created on: " & CurrentBook.Createdon
        lblUpdatedon.Text = "Updated on: " & CurrentBook.Updatedon
        If cbopageName.Text <> "Custom" Then
            txtWidth.Enabled = False
            txtHeight.Enabled = False
        Else
            txtWidth.Enabled = True
            txtHeight.Enabled = True
        End If

    End Sub



    Private Sub cbopageName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbopageName.SelectedIndexChanged
        If cbopageName.SelectedIndex = -1 Then Exit Sub

        txtWidth.Text = pageTypes(cbopageName.Text).Size.Width
        txtHeight.Text = pageTypes(cbopageName.Text).Size.Height
        txtMLeft.Text = pageTypes(cbopageName.Text).Margins.Left
        txtMRight.Text = pageTypes(cbopageName.Text).Margins.Right
        txtMTop.Text = pageTypes(cbopageName.Text).Margins.Top
        txtMBottom.Text = pageTypes(cbopageName.Text).Margins.Bottom
        If cbopageName.Text <> "Custom" Then
            txtWidth.Enabled = False
            txtHeight.Enabled = False
        Else
            txtWidth.Enabled = True
            txtHeight.Enabled = True
        End If
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        If String.IsNullOrEmpty(txtTitle.Text) Or
                String.IsNullOrEmpty(txtAuthor.Text) Then
            MsgBox("Either Title or Author is empty", MsgBoxStyle.Information)
            Exit Sub
        End If
        CurrentBook.Title = txtTitle.Text.Trim
        CurrentBook.Subtitle = txtSubtitle.Text.Trim
        CurrentBook.Author = txtAuthor.Text.Trim

        Dim p As PageTemplate = pageTypes(cbopageName.Text).Clone
        p.Size = New Size(CInt(txtWidth.Text), CInt(txtHeight.Text))
        p.Margins = New Printing.Margins(CInt(txtMLeft.Text), CInt(txtMRight.Text), CInt(txtMTop.Text), CInt(txtMBottom.Text))
        CurrentBook.PageSet = p
        'CurrentBook.Struct = cboStructure.SelectedIndex
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class