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
Public Class IdeaContainer
    Private _isCat As Boolean
    Private _ideas As Dictionary(Of String, Idea)

    Public Sub Clear()
        _isCat = False
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is Label Then
                RemoveHandler ctl.DoubleClick, AddressOf CatClicked
            End If
        Next
        Me.Controls.Clear()
    End Sub
    Dim sortedCatList As New Dictionary(Of String, Integer)
    Public Sub LoadCategories(ideas As Dictionary(Of String, Idea))
        Clear()
        Me._ideas = ideas
        sortedCatList.Clear()
        For Each id As Idea In ideas.Values
            If sortedCatList.ContainsKey(id.Category) Then
                sortedCatList(id.Category) += 1
            Else
                sortedCatList.Add(id.Category, 1)
            End If
        Next
        For Each key As String In sortedCatList.Keys
            Dim lbl As New Label()
            With lbl
                .BackColor = Color.Transparent
                .AutoSize = False
                .Image = My.Resources.ideasfolder_big
                .ImageAlign = ContentAlignment.MiddleCenter
                .Text = key & " [" & sortedCatList(key) & "]"
                .TextAlign = ContentAlignment.MiddleCenter
                .Size = New Size(256, 200)
                AddHandler lbl.DoubleClick, AddressOf CatClicked
                lbl.Tag = key
                Me.Controls.Add(lbl)
            End With
        Next
        _isCat = True
        AlignControls()
    End Sub
    Dim catWidth As Integer = 256
    Dim catHeight As Integer = 200
    Dim notWidth As Integer = 256
    Dim notHeight As Integer = 200
    Private Sub AlignControls()
        If _isCat Then
            Dim rowNum, colNum As Integer
            rowNum = 0 : colNum = 0
            Dim spacing As Integer = 50
            For Each ctl As Control In Me.Controls
                ctl.Location = New Point(colNum * catWidth + (colNum + 1) * spacing, rowNum * catHeight + (rowNum + 1) * spacing)
                colNum += 1
                If colNum = 4 Then
                    rowNum += 1
                    colNum = 0
                End If
            Next
        Else
            Dim rowNum, colNum As Integer
            rowNum = 0 : colNum = 0
            Dim spacing As Integer = 50
            For Each ctl As Control In Me.Controls
                ctl.Location = New Point(colNum * notWidth + (colNum + 1) * spacing, rowNum * notHeight + (rowNum + 1) * spacing)
                colNum += 1
                If colNum = 4 Then
                    rowNum += 1
                    colNum = 0
                End If
            Next
        End If

    End Sub
    Private Sub CatClicked(sender As Object, e As EventArgs)

        LoadIdeas(CType(sender, Label).Tag, _ideas)
    End Sub
    Public Sub LoadIdeas(cat As String, ideas As Dictionary(Of String, Idea))
        Clear()
        _isCat = False
        If Me._ideas Is Nothing Then
            Me._ideas = ideas
        End If
        Dim sortedList As New List(Of Idea)
        For Each id As Idea In _ideas.Values
            If id.Category = cat Then
                sortedList.Add(id)
            End If
        Next
        For Each id As Idea In sortedList
            Dim idactl As New IdeaCtl(id)
            idactl.Tag = id.ID
            Me.Controls.Add(idactl)
        Next
        AlignControls()
    End Sub
End Class
