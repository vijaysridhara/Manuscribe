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
Public Class Findform
    Private myTextBox As AdvRichTextBox

    Private Sub optReplace_CheckedChanged(sender As Object, e As EventArgs) Handles optReplace.CheckedChanged
        If optReplace.Checked Then
            txtReplace.Enabled = True
            Label2.Enabled = True
            butReplace.Enabled = True
            butReplaceAll.Enabled = True

        End If
    End Sub
    Public Sub New(adv As AdvRichTextBox)
        InitializeComponent()
        Me.myTextBox = adv

    End Sub
    Private Sub optFind_CheckedChanged(sender As Object, e As EventArgs) Handles optFind.CheckedChanged
        If optFind.Enabled Then
            txtReplace.Enabled = False
            Label2.Enabled = False
            butReplace.Enabled = False
            butReplaceAll.Enabled = False
        End If
    End Sub

    Private Sub butClose_Click(sender As Object, e As EventArgs) Handles butClose.Click
        Me.Hide()
    End Sub
    Public Overloads Function ShowDialog() As DialogResult
        curIx = 0
        findString = ""
        replString = ""
        mtchCase = False
        wordWrap = False
        dirUp = False
        prevFind = False
        lblMessage.Text = ""
        cntReplaces = 0
        If String.IsNullOrEmpty(myTextBox.SelectedText) = False Then
            txtFind1.Text = myTextBox.SelectedText
            curIx = myTextBox.SelectionStart
        End If
        Return MyBase.ShowDialog()
    End Function

    Dim curIx As Integer = 0
    Dim findString As String = ""
    Dim replString As String = ""
    Dim mtchCase As Boolean
    Dim wordWrap As Boolean
    Dim dirUp As Boolean
    Dim prevFind As Boolean
    Private Sub butFindNext_Click(sender As Object, e As EventArgs) Handles butFindNext.Click
        If findString = "" Then Exit Sub
        Dim rtF As RichTextBoxFinds
        If chkMatchCase.Checked Then
            rtF = RichTextBoxFinds.MatchCase
        End If
        If chkWholeword.Checked Then
            rtF = rtF Or RichTextBoxFinds.WholeWord

        End If


        If curIx > myTextBox.TextLength Then
            curIx = 0
        Else
            curIx += 1
        End If
        curIx = myTextBox.Find(findString, curIx, rtF)
        If curIx > 0 Then
            prevFind = True
            lblMessage.Text = "Found occurence at " & curIx
        Else
            prevFind = False
            lblMessage.Text = "No occurence found"
            curIx = 0
        End If


    End Sub

    Private Sub txtFind1_TextChanged(sender As Object, e As EventArgs) Handles txtFind1.TextChanged
        findString = txtFind1.Text
    End Sub

    Private Sub txtReplace_TextChanged(sender As Object, e As EventArgs) Handles txtReplace.TextChanged
        replString = txtReplace.Text
    End Sub

    Private Sub Findform_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtFind1.Focus()
        txtFind1.SelectAll()
    End Sub

    Private Sub Findform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        curIx = 0
        findString = ""
        replString = ""
        mtchCase = False
        wordWrap = False
        dirUp = False
        prevFind = False
        lblMessage.Text = ""
        cntReplaces = 0
        If String.IsNullOrEmpty(myTextBox.SelectedText) = False Then
            txtFind1.Text = myTextBox.SelectedText
            curIx = myTextBox.SelectionStart
        End If
    End Sub

    Private Sub butReplace_Click(sender As Object, e As EventArgs) Handles butReplace.Click
        If findString = "" Then Exit Sub
        If myTextBox.SelectedText = findString Then
            myTextBox.SelectedText = replString
            butFindNext_Click(Nothing, Nothing)
        End If
    End Sub
    Dim cntReplaces As Integer = 0

    Private Sub butReplaceAll_Click(sender As Object, e As EventArgs) Handles butReplaceAll.Click
        cntReplaces = 0
        Dim rtF As RichTextBoxFinds
        If chkMatchCase.Checked Then
            rtF = RichTextBoxFinds.MatchCase
        End If
        If chkWholeword.Checked Then
            rtF = rtF Or RichTextBoxFinds.WholeWord

        End If
        curIx = myTextBox.Find(findString, curIx, rtF)
        While curIx >= 0
            cntReplaces += 1
            myTextBox.SelectedText = replString
            curIx = myTextBox.Find(findString, curIx, rtF)
        End While
        lblMessage.Text = "Replaced " & cntReplaces & " occurances"
    End Sub
End Class