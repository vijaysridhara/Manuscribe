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
Public Class StylesDef
    ' Private styleNames As List(Of String)
    Private selectedStyleSet As StyleSet
    Private selectedStyle As Style

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'styleNames.AddRange({"H1", "H2", "H3", "H4", "Code", "Normal"})
    End Sub

    Private Sub StylesDef_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each f As FontFamily In fontFamilies
            cboFontname.Items.Add(f.Name)
        Next
        For i As Integer = 6 To 100
            cboSize.Items.Add(i)
        Next
        lstStyleSet.Items.AddRange(AllStyles.Keys.ToArray())


    End Sub

    Private Sub lstStyleSet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstStyleSet.SelectedIndexChanged
        lstStyles.Items.Clear()
        selectedStyle = Nothing
        selectedStyleSet = Nothing
        lblFontNameError.Text = ""
        If lstStyleSet.SelectedIndex = -1 Then Exit Sub
        selectedStyleSet = AllStyles(lstStyleSet.SelectedItem)

        For Each s As String In selectedStyleSet.Styles.Keys
            lstStyles.Items.Add(s)
        Next
        If lstStyles.Items.Count > 0 Then
            lstStyles.SelectedIndex = 0
        End If

    End Sub
    Dim isNew As Boolean
    Private Sub lstStyles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstStyles.SelectedIndexChanged
        lblFontNameError.Text = ""
        selectedStyle = Nothing
        If selectedStyleSet Is Nothing Then
            Exit Sub
        End If
        If lstStyles.SelectedIndex = -1 Then Exit Sub
        isNew = False
        selectedStyle = AllStyles(lstStyleSet.SelectedItem).Styles(lstStyles.SelectedItem)

        If cboFontname.Items.Contains(selectedStyle.FName) = False Then
            lblFontNameError.Text = "Missing font: " & selectedStyle.FName

        End If
        cboFontname.Text = selectedStyle.FName
        cboSize.Text = selectedStyle.FSize
        AdvRichTextBox1.SelectionStart = 0
        AdvRichTextBox1.SelectionLength = AdvRichTextBox1.TextLength
        AdvRichTextBox1.SelectionFont = New Font(selectedStyle.FName, selectedStyle.FSize, selectedStyle.FStyle)

        chkkApplyBacklor.Checked = selectedStyle.ApplyBackColor
        If selectedStyle.ApplyBackColor = False Then AdvRichTextBox1.SelectionBackColor = Nothing : Else AdvRichTextBox1.SelectionBackColor = selectedStyle.BColor
        AdvRichTextBox1.SelectionColor = selectedStyle.FColor
        txtSTyleName.Text = selectedStyle.Name
        txtSTyleName.Enabled = False

    End Sub

    Private Sub butAddStyleSet_Click(sender As Object, e As EventArgs) Handles butAddStyleSet.Click
        Dim newSt As String = InputBox("Provide a name for the Styleset", "Styleset name", "RockTimes")
        If String.IsNullOrEmpty(newSt) Then Exit Sub
        While AllStyles.ContainsKey(newSt)
            MsgBox("The name already exists", MsgBoxStyle.Information)
            newSt = InputBox("Provide a name for the Styleset", "Styleset name", newSt)
            If String.IsNullOrEmpty(newSt) Then Exit Sub
        End While
        ResetStyles()
        selectedStyleSet = New StyleSet()
        isNew = True
        selectedStyleSet.Name = newSt
        AllStyles.Add(newSt, selectedStyleSet)
        lstStyleSet.Items.Add(selectedStyleSet.Name)
        lstStyleSet.SelectedIndex = lstStyleSet.Items.Count - 1
        txtSTyleName.Enabled = True
    End Sub

    Private Sub butAddStyle_Click(sender As Object, e As EventArgs) Handles butAddStyle.Click
        If lstStyleSet.SelectedIndex = -1 Then Exit Sub
        isNew = True
        selectedStyle = Nothing

        lblFontNameError.Text = ""
        txtSTyleName.Enabled = True
        txtSTyleName.Clear()
        lstStyles.SelectedIndex = -1
    End Sub

    Private Sub butExit_Click(sender As Object, e As EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub butApply_Click(sender As Object, e As EventArgs) Handles butApply.Click
        If selectedStyleSet Is Nothing Then Exit Sub
        If selectedStyle Is Nothing Then
            If isNew Then
                selectedStyle = New Style

            End If
            With selectedStyle
                .Name = txtSTyleName.Text.Trim
                .FName = cboFontname.Text
                .FSize = cboSize.Text
                .FStyle = AdvRichTextBox1.SelectionFont.Style
                .FColor = AdvRichTextBox1.SelectionColor
                .BColor = AdvRichTextBox1.SelectionBackColor
                .ApplyBackColor = chkkApplyBacklor.Checked
            End With
            If isNew Then
                If selectedStyleSet.Styles.ContainsKey(selectedStyle.Name) Then
                    lblFontNameError.Text = "Style already exists"
                    Exit Sub
                Else
                    selectedStyleSet.Styles.Add(selectedStyle.Name, selectedStyle)
                    lstStyles.Items.Add(selectedStyle.Name)
                    isNew = False
                    lstStyles.SelectedIndex = lstStyles.Items.Count - 1
                    Exit Sub
                End If
            End If
        Else
            With selectedStyle
                .Name = txtSTyleName.Text.Trim
                .FName = cboFontname.Text
                .FSize = cboSize.Text
                .FStyle = AdvRichTextBox1.SelectionFont.Style
                .FColor = AdvRichTextBox1.SelectionColor
                .BColor = AdvRichTextBox1.SelectionBackColor
                .ApplyBackColor = chkkApplyBacklor.Checked
            End With

        End If

    End Sub
    Private Sub ResetStyles()
        lblFontNameError.Text = ""
        txtSTyleName.Clear()
        lstStyles.Items.Clear()
        isNew = False
    End Sub

    Private Sub butRemoveStyleSet_Click(sender As Object, e As EventArgs) Handles butRemoveStyleSet.Click
        Try
            If lstStyleSet.SelectedIndex = -1 Then Exit Sub
            If MsgBox("Do you really want to delete this styleset", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            AllStyles.Remove(lstStyleSet.SelectedItem)
            lstStyleSet.Items.RemoveAt(lstStyleSet.SelectedIndex)
            Reset()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butRemoveStyle_Click(sender As Object, e As EventArgs) Handles butRemoveStyle.Click
        Try
            If lstStyles.SelectedIndex = -1 Then Exit Sub
            If MsgBox("Do you really want to delete this style", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            selectedStyleSet.Styles.Remove(lstStyles.SelectedItem)
            lstStyles.Items.RemoveAt(lstStyles.SelectedIndex)
            Reset()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub cboFontname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFontname.SelectedIndexChanged

        Dim fsize As Single
        If String.IsNullOrEmpty(cboSize.Text) Then
            fsize = 10
        Else
            fsize = cboSize.Text
        End If
        Dim fname As String
        fname = IIf(String.IsNullOrEmpty(cboFontname.Text), "Arial", cboFontname.Text)
        Dim f As New Font(fname, fsize, FontStyle.Regular)
        TestStyle(f)
    End Sub
    Private Sub TestStyle(f As Font)
        AdvRichTextBox1.SelectionStart = 0
        AdvRichTextBox1.SelectionLength = AdvRichTextBox1.TextLength
        AdvRichTextBox1.SelectionFont = f
        AdvRichTextBox1.Font = f
    End Sub
    Private Sub TestBColor(b As Color)
        AdvRichTextBox1.SelectionStart = 0
        AdvRichTextBox1.SelectionLength = AdvRichTextBox1.TextLength
        AdvRichTextBox1.SelectionBackColor = b
    End Sub
    Private Sub TestFColor(f As Color)
        AdvRichTextBox1.SelectionStart = 0
        AdvRichTextBox1.SelectionLength = AdvRichTextBox1.TextLength
        AdvRichTextBox1.SelectionColor = f
    End Sub

    Private Sub cboSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSize.SelectedIndexChanged
        Dim fname As String

        Dim fSize As Single
        If String.IsNullOrEmpty(cboSize.Text) Then
            fSize = 10
        Else
            fSize = cboSize.Text
        End If
        fname = IIf(String.IsNullOrEmpty(cboFontname.Text), "Arial", cboFontname.Text)
        Dim f As New Font(fname, fSize, FontStyle.Regular)
        TestStyle(f)
    End Sub

    Private Sub butBold_Click(sender As Object, e As EventArgs) Handles butBold.Click
        Dim f As Font = AdvRichTextBox1.Font
        Dim f1 As Font

        f1 = New Font(f.Name, f.Size, f.Style Xor FontStyle.Bold)
        TestStyle(f1)
    End Sub

    Private Sub butItalic_Click(sender As Object, e As EventArgs) Handles butItalic.Click
        Dim f As Font = AdvRichTextBox1.Font
        Dim f1 As Font

        f1 = New Font(f.Name, f.Size, f.Style Xor FontStyle.Italic)
        TestStyle(f1)
    End Sub


    Private Sub butUnderline_Click(sender As Object, e As EventArgs) Handles butUnderline.Click
        Dim f As Font = AdvRichTextBox1.Font
        Dim f1 As Font

        f1 = New Font(f.Name, f.Size, f.Style Xor FontStyle.Underline)
        TestStyle(f1)
    End Sub

    Private Sub butStrikethrough_Click(sender As Object, e As EventArgs) Handles butStrikethrough.Click
        Dim f As Font = AdvRichTextBox1.Font
        Dim f1 As Font

        f1 = New Font(f.Name, f.Size, f.Style Xor FontStyle.Strikeout)
        TestStyle(f1)
    End Sub

    Private Sub butBackcolor_Click(sender As Object, e As EventArgs) Handles butBackcolor.Click
        Dim cp As New VitalLogic.Controls.ColorWheel
        cp.Color = AdvRichTextBox1.SelectionBackColor
        If cp.ShowDialog = DialogResult.OK Then
            TestBColor(cp.Color)
        End If
    End Sub

    Private Sub butForeColor_Click(sender As Object, e As EventArgs) Handles butForeColor.Click
        Dim cp As New VitalLogic.Controls.ColorWheel
        cp.Color = AdvRichTextBox1.SelectionColor
        If cp.ShowDialog = DialogResult.OK Then
            TestFColor(cp.Color)
        End If
    End Sub

    Private Sub chkkApplyBacklor_CheckedChanged(sender As Object, e As EventArgs) Handles chkkApplyBacklor.CheckedChanged
        If chkkApplyBacklor.Checked Then
            butBackcolor.Enabled = True
        Else
            butBackcolor.Enabled = False
        End If
    End Sub
End Class