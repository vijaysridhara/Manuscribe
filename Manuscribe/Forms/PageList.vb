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
Friend Class PageList
    Dim curChap As Chapter
    Dim reordList As New List(Of String)
    Private _isChanged As Boolean
    Public Property IsChanged() As Boolean
        Get
            Return _isChanged
        End Get
        Set(value As Boolean)
            _isChanged = value
        End Set
    End Property
    Public Sub New(chp As Chapter)
        InitializeComponent()
        Me.curChap = chp
        LoadPageContents()
    End Sub
    Private Sub PageList_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub

    Private Sub LoadPageContents()
        Try
            For Each pg As Page In curChap.Pages
                Dim lv As New ListViewItem(pg.Seq)
                lv.SubItems.Add(pg.Name)
                lv.SubItems.Add(pg.SampleText)
                lv.SubItems.Add(pg.WordCount)
                lv.Tag = pg.ID
                ListView1.Items.Add(lv)

            Next
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub PageList_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout

    End Sub
    Private Sub PageList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub butUp_Click(sender As Object, e As EventArgs) Handles butUp.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If ListView1.SelectedItems(0).Index = 0 Then Exit Sub
        Dim IX As Integer = ListView1.SelectedItems(0).Index
        butUp.Enabled = False
        Dim IXItm As ListViewItem = ListView1.SelectedItems(0)
        ListView1.Items.Remove(IXItm)
        ListView1.Items.Insert(IX - 1, IXItm)
        Dim pg1 As Page = curChap.GetPageByID(IXItm.Tag)
        curChap.RemovePage(pg1.ID)
        curChap.Pages.Insert(IX - 1, pg1)
        IsChanged = True
        Dim seq As Integer = 1
        For Each pg As Page In curChap.Pages
            pg.Seq = seq
            seq += 1
        Next
        ListView1_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub butDown_Click(sender As Object, e As EventArgs) Handles butDown.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        If ListView1.SelectedItems(0).Index = ListView1.Items.Count - 1 Then Exit Sub
        Dim IX As Integer = ListView1.SelectedItems(0).Index
        butDown.Enabled = False
        Dim IXItm As ListViewItem = ListView1.SelectedItems(0)
        ListView1.Items.Remove(IXItm)
        ListView1.Items.Insert(IX + 1, IXItm)
        Dim pg1 As Page = curChap.GetPageByID(IXItm.Tag)
        curChap.RemovePage(pg1.ID)
        curChap.Pages.Insert(IX + 1, pg1)
        IsChanged = True
        Dim seq As Integer = 1
        For Each pg As Page In curChap.Pages
            pg.Seq = seq
            seq += 1
        Next
        ListView1_SelectedIndexChanged(Nothing, Nothing)
    End Sub
End Class