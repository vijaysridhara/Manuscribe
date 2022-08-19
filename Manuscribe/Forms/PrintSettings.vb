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
Public Class PrintSettings

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBorder.SelectedIndexChanged
        My.Settings.PrintBorder = cboBorder.SelectedIndex
    End Sub

    Private Sub PrintSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With My.Settings
            cboPageNo.SelectedIndex = .PrintPageNoLoc
            cboBorder.SelectedIndex = .PrintBorder
            txtPageNoFormat.Text = .PrintPageNoFormat
            chkRightImage.Checked = .PrintRightImage
            cboAlterNateNumberingtoChapter1.Checked = .PrintalternateNumberonChapter1
            chkLeftImage.Checked = .PrintLeftImage
            cboFillRectangle.SelectedIndex = .PrintFillRectangle
            butBorderColor.BackColor = .PrintBorderColor
            butFillRectangle.BackColor = .PrintFillRectangleColor
            cboTitleLoc.SelectedIndex = .PrintTitleLoc
            butFont.Text = PrintMetaFont.Name & ":" & PrintMetaFont.SizeInPoints
            butFont.Font = PrintMetaFont
            cboAuthorLoc.SelectedIndex = .AuthorLoc

        End With

    End Sub

    Private Sub chkTopImage_CheckedChanged(sender As Object, e As EventArgs) Handles chkLeftImage.CheckedChanged
        If chkLeftImage.Checked Then
            butTopImage.Enabled = True

        Else
            butTopImage.Enabled = False
        End If
        My.Settings.PrintLeftImage = chkLeftImage.Checked

    End Sub

    Private Sub chkBottomImage_CheckedChanged(sender As Object, e As EventArgs) Handles chkRightImage.CheckedChanged
        If chkRightImage.Checked Then
            butBottomImage.Enabled = True
        Else
            butBottomImage.Enabled = False
        End If
        My.Settings.PrintRightImage = chkRightImage.Checked
    End Sub

    Private Sub butTopImage_Click(sender As Object, e As EventArgs) Handles butTopImage.Click
        Dim sfd As New OpenFileDialog
        With sfd
            .Filter = "JPG Files(*.jpg)|*.jpg|PNG FileS(*.png)|*.png"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintLeftImageValue = Bitmap.FromFile(.FileName)
            End If
        End With
    End Sub

    Private Sub butBottomImage_Click(sender As Object, e As EventArgs) Handles butBottomImage.Click
        Dim sfd As New OpenFileDialog
        With sfd
            .Filter = "JPG Files(*.jpg)|*.jpg|PNG FileS(*.png)|*.png"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintRightImageValue = Bitmap.FromFile(.FileName)
            End If
        End With
    End Sub


    Private Sub cboFillRectangle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFillRectangle.SelectedIndexChanged
        My.Settings.PrintFillRectangle = cboFillRectangle.SelectedIndex
    End Sub

    Private Sub butBorderColor_Click(sender As Object, e As EventArgs) Handles butBorderColor.Click
        Dim cp As New VitalLogic.Controls.ColorWheel
        cp.Color = butBorderColor.BackColor
        If cp.ShowDialog = DialogResult.OK Then
            butBorderColor.BackColor = cp.Color
            My.Settings.PrintBorderColor = cp.Color
        End If
    End Sub

    Private Sub cboPageNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPageNo.SelectedIndexChanged
        My.Settings.PrintPageNoLoc = cboPageNo.SelectedIndex
    End Sub

    Private Sub txtPageNoFormat_TextChanged(sender As Object, e As EventArgs) Handles txtPageNoFormat.TextChanged
        My.Settings.PrintPageNoFormat = txtPageNoFormat.Text

    End Sub

    Private Sub chkNoPageNosonChap1_CheckedChanged(sender As Object, e As EventArgs) Handles cboAlterNateNumberingtoChapter1.CheckedChanged
        My.Settings.PrintalternateNumberonChapter1 = cboAlterNateNumberingtoChapter1.Checked
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.Save()
        LoadSettings()
        Me.Close()
    End Sub

    Private Sub butFillRectangle_Click(sender As Object, e As EventArgs) Handles butFillRectangle.Click
        Dim cp As New VitalLogic.Controls.ColorWheel
        cp.Color = butFillRectangle.BackColor
        If cp.ShowDialog = DialogResult.OK Then
            butFillRectangle.BackColor = cp.Color
            My.Settings.PrintFillRectangleColor = cp.Color
        End If
    End Sub

    Private Sub cboTitleLoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTitleLoc.SelectedIndexChanged
        My.Settings.PrintTitleLoc = cboTitleLoc.SelectedIndex
        If cboTitleLoc.SelectedIndex > 0 Then
            chkBookTitle.Enabled = True
            chkChaptername.Enabled = True
            txtDelimiter.Enabled = True
        Else
            chkBookTitle.Enabled = False
            chkChaptername.Enabled = False
            txtDelimiter.Enabled = False
        End If
    End Sub

    Private Sub chkChaptername_CheckedChanged(sender As Object, e As EventArgs) Handles chkChaptername.CheckedChanged
        If chkChaptername.Checked Then
            If chkBookTitle.Checked Then
                PrintTitleText = "#CHAP#" & txtDelimiter.Text & "#TITLE#"
                printLeftTitleText = "#TITLE#" & txtDelimiter.Text & "#CHAP#"
            Else
                PrintTitleText = "#CHAP#"
                printLeftTitleText = "#CHAP#"
            End If
        Else
            If chkBookTitle.Checked Then
                PrintTitleText = "#TITLE#"
                printLeftTitleText = "#TITLE#"
            Else
                PrintTitleText = ""
                printLeftTitleText = ""
            End If
        End If
    End Sub

    Private Sub chkBookTitle_CheckedChanged(sender As Object, e As EventArgs) Handles chkBookTitle.CheckedChanged
        If chkChaptername.Checked Then
            If chkBookTitle.Checked Then
                PrintTitleText = "#CHAP#" & txtDelimiter.Text & "#TITLE#"
                printLeftTitleText = "#TITLE#" & txtDelimiter.Text & "#CHAP#"
            Else
                PrintTitleText = "#CHAP#"
                printLeftTitleText = "#CHAP#"
            End If
        Else
            If chkBookTitle.Checked Then
                PrintTitleText = "#TITLE#"
                printLeftTitleText = "#TITLE#"
            Else
                PrintTitleText = ""
                printLeftTitleText = ""
            End If
        End If
    End Sub

    Private Sub txtDelimiter_TextChanged(sender As Object, e As EventArgs) Handles txtDelimiter.TextChanged
        If chkChaptername.Checked Then
            If chkBookTitle.Checked Then
                PrintTitleText = "#CHAP#" & txtDelimiter.Text & "#TITLE#"
                printLeftTitleText = "#TITLE#" & txtDelimiter.Text & "#CHAP#"
            Else
                PrintTitleText = "#CHAP#"
                printLeftTitleText = "#CHAP#"
            End If
        Else
            If chkBookTitle.Checked Then
                PrintTitleText = "#TITLE#"
                printLeftTitleText = "#TITLE#"
            Else
                PrintTitleText = ""
                printLeftTitleText = ""
            End If
        End If
    End Sub

    Private Sub butFont_Click(sender As Object, e As EventArgs) Handles butFont.Click
        Dim pd As New FontDialog
        pd.Font = butFont.Font
        If pd.ShowDialog = Windows.Forms.DialogResult.OK Then
            butFont.Font = pd.Font
            PrintMetaFont = pd.Font
            My.Settings.PrintMetaFont = pd.Font
            My.Settings.Save()
        End If
    End Sub

    Private Sub cboAuthorLoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAuthorLoc.SelectedIndexChanged
        My.Settings.AuthorLoc = cboAuthorLoc.SelectedIndex
    End Sub
End Class