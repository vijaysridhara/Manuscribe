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
Friend Class Desk
    Inherits Panel
    Event ChapterNameChanged(c As Chapter, istrash As Boolean)
    Private _isTrash As Boolean = False
    Public Sub New()

        ' This call is required by the designer.


        ' Add any initialization after the InitializeComponent() call.
        Me.BackColor = SystemColors.ControlDarkDark
        Me.BackgroundImage = Nothing
        'SetStyle(ControlStyles.ContainerControl, True)
        AutoScroll = True
    End Sub
    Public ReadOnly Property IsTrash() As Boolean
        Get
            Return _isTrash
        End Get
    End Property
    Public Sub Clear()
        For Each c As Control In Me.Controls
            RemoveHandler CType(c, SynopControl).ChapterNameChanged, AddressOf ChapterChanged
        Next
        Me.Controls.Clear()
    End Sub
    Public Sub LoadChapters(isDrafts As Boolean)
        Clear()
        _isTrash = False
        Dim rowNum As Integer = 0
        Dim colNum As Integer = 0
        Dim spacing As Integer = 20
        Dim cnt As Integer = 0
        Dim values As List(Of Chapter)
        If isDrafts Then
            values = CurrentBook.Drafts
        Else
            values = CurrentBook.Chapters
        End If
        For Each c As Chapter In values
            Dim s As New SynopControl()
            s.Chapter = c
            With s
                .Width = 282
                .Height = 172
            End With

            s.Location = New Point((colNum + 1) * spacing + colNum * s.Width, (rowNum + 1) * spacing + rowNum * s.Height)
            colNum += 1
            If colNum = 4 Then
                colNum = 0
                rowNum += 1
            End If
            AddHandler s.ChapterNameChanged, AddressOf ChapterChanged
            Me.Controls.Add(s)
        Next
    End Sub
    Public Sub LoadTrash()
        Clear()
        _isTrash = True
        Dim rowNum As Integer = 0
        Dim colNum As Integer = 0
        Dim spacing As Integer = 20
        Dim cnt As Integer = 0
        Dim values As List(Of Chapter)
        values = CurrentBook.Trash
        For Each c As Chapter In values
            Dim s As New SynopControl()
            s.Chapter = c
            With s
                .Width = 282
                .Height = 172
            End With

            s.Location = New Point((colNum + 1) * spacing + colNum * s.Width, (rowNum + 1) * spacing + rowNum * s.Height)
            colNum += 1
            If colNum = 4 Then
                colNum = 0
                rowNum += 1
            End If
            AddHandler s.ChapterNameChanged, AddressOf ChapterChanged
            Me.Controls.Add(s)
        Next
    End Sub
    Private Sub ChapterChanged(c As Chapter)
        RaiseEvent ChapterNameChanged(c, _isTrash)
    End Sub
End Class
