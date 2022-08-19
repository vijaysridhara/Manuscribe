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
Public Class ChapterList

    Private Sub ChapterList_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ChapterList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For Each chp As Chapter In CurrentBook.Chapters
                Dim lsv As New ListViewItem
                lsv.Text = chp.Seq
                lsv.SubItems.AddRange(New String() {chp.Name, chp.Synopsis, chp.Pages.Count, chp.WordCount})
                lsv.Tag = chp.ID
                ListView1.Items.Add(lsv)
            Next
            ReNumber()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub ReNumber()
        Dim i As Integer = 0
        For Each lv As ListViewItem In ListView1.Items
            i += 1
            lv.Text = i
        Next
        ListView1_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    Private Sub butUp_Click(sender As Object, e As EventArgs) Handles butUp.Click
        Try
            If ListView1.SelectedItems.Count = 0 Then Exit Sub
            If ListView1.SelectedItems(0).Index = 0 Then Exit Sub
            Dim lv1 As ListViewItem = ListView1.SelectedItems(0)
            Dim ix As Integer = lv1.Index
            ListView1.Items.Remove(lv1)
            ListView1.Items.Insert(ix - 1, lv1)
            CurrentBook.MoveUpChapter(lv1.Tag)
            lv1.Selected = True
            ReNumber()

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butDown_Click(sender As Object, e As EventArgs) Handles butDown.Click
        Try
            If ListView1.SelectedItems.Count = 0 Then Exit Sub
            If ListView1.SelectedItems(0).Index = ListView1.Items.Count - 1 Then Exit Sub
            Dim lv1 As ListViewItem = ListView1.SelectedItems(0)
            Dim ix As Integer = lv1.Index
            ListView1.Items.Remove(lv1)
            ListView1.Items.Insert(ix + 1, lv1)
            CurrentBook.MoveDownChapter(lv1.Tag)
            lv1.Selected = True
            ReNumber()

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 0 Or ListView1.Items.Count = 1 Then
            butUp.Enabled = False
            butDown.Enabled = False

        ElseIf ListView1.SelectedItems(0).Index = 0 Then
            butUp.Enabled = False
            butDown.Enabled = True
        ElseIf ListView1.SelectedItems(0).Index = ListView1.Items.Count - 1 Then
            butDown.Enabled = False
            butUp.Enabled = True
        Else
            butDown.Enabled = True
            butUp.Enabled = True
        End If
    End Sub
End Class