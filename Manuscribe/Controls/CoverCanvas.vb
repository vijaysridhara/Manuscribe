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
Friend Class CoverCanvas
    Private ps As PageTemplate
    Private totControlWidth As Integer
    Private totControlHEight As Integer
    Public Property Style As PageTemplate
        Get
            Return ps
        End Get
        Set(value As PageTemplate)
            ps = value
            ResizePAge()
        End Set
    End Property
    Public Sub Clear()
        For Each c As PictureBox In Me.Controls
            RemoveHandler c.Click, AddressOf picBoxClicked
        Next
        Me.Controls.Clear()

    End Sub
    Public Sub ShowImage(ft As ImageType)
        On Error Resume Next
        Clear()
        Dim picCover As New PictureBox

        picCover.SizeMode = PictureBoxSizeMode.StretchImage
        AddHandler picCover.Click, AddressOf picBoxClicked
        picCover.BackColor = Color.White
        picCover.Image = CurrentBook.Covers(ft).Image
        Me.Controls.Add(picCover)
        ResizePAge()

    End Sub
    Private Sub ResizePAge()
        If Me.Controls.Count = 1 Then
            Me.Controls(0).Size = CurrentBook.PageSet.Size
            AdjustPage()
        ElseIf Me.Controls.Count = 2 Then
            Dim MaxWidth As Integer = Me.ClientRectangle.Width / 2 - 3 * 20 'With spacing between 4 panels
            Dim maxHeight As Integer = Me.ClientRectangle.Height - 2 * 40
            Dim panlRat As Single = CurrentBook.PageSet.Size.Width / CurrentBook.PageSet.Size.Height
            Dim panW, panH As Integer
            If panlRat > 1 Then 'Which means panel is wide
                panH = maxHeight
                panW = panlRat * panH

            Else

                panW = MaxWidth
                panH = MaxWidth / panlRat

            End If
            totControlWidth = 0
            For Each picC As PictureBox In Me.Controls
                picC.Size = New Size(panW, panH)
                totControlWidth += panW + 20
            Next
            If totControlWidth > 20 Then
                totControlWidth -= 20 'Last 20 is to be removed
            End If
            totControlHEight = panH
            AdjustPage()
        ElseIf Me.Controls.Count > 2 Then
            Dim MaxWidth As Integer = Me.ClientRectangle.Width / 4 - 5 * 20 'With spacing between 4 panels
            Dim maxHeight As Integer = Me.ClientRectangle.Height - 2 * 40
            Dim panlRat As Single = CurrentBook.PageSet.Size.Width / CurrentBook.PageSet.Size.Height
            Dim panW, panH As Integer
            If panlRat > 1 Then 'Which means panel is wide
                panH = maxHeight
                panW = panlRat * panH

            Else

                panW = MaxWidth
                panH = MaxWidth / panlRat

            End If
            totControlWidth = 0
            For Each picC As PictureBox In Me.Controls
                picC.Size = New Size(panW, panH)
                totControlWidth += panW + 20
            Next
            If totControlWidth > 20 Then
                totControlWidth -= 20 'Last 20 is to be removed
            End If
            totControlHEight = panH
            AdjustPage()
        End If
    End Sub
    Private Sub picBoxClicked(sender As Object, e As EventArgs)

    End Sub
    Public Sub ShowAllCovers()
        Clear()

        For Each cv As Cover In CurrentBook.Covers.Values
            Dim picC As New PictureBox
            AddHandler picC.Click, AddressOf picBoxClicked
            picC.SizeMode = PictureBoxSizeMode.StretchImage
            picC.BackColor = Color.White
            picC.Image = cv.Image

            Me.Controls.Add(picC)
        Next
        ResizePAge()

    End Sub

    Private Sub CoverCanvas_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        AdjustPage()
    End Sub
    Private Sub AdjustPage()
        If Me.Controls.Count = 1 Then
            Dim picCover As PictureBox = Me.Controls(0)
            If Me.Width > picCover.Width Then
                picCover.Location = New Point(Me.Width / 2 - picCover.Width / 2, picCover.Top)
            Else
                picCover.Location = New Point(0, picCover.Top)
            End If
            If Me.Height > picCover.Height Then
                picCover.Location = New Point(picCover.Left, Me.Height / 2 - picCover.Height / 2)
            Else
                picCover.Location = New Point(picCover.Left, 0)
            End If
        Else
            Dim colNo As Integer = 0
            Dim hspacing As Integer = 20
            Dim StartHLoc As Integer = Me.ClientRectangle.Width / 2 - totControlWidth / 2
            Dim StartVLoc As Integer = Me.ClientRectangle.Height / 2 - totControlHEight / 2
            For Each ct As PictureBox In Me.Controls
                ct.Location = New Point(StartHLoc + colNo * (hspacing + ct.Width), StartVLoc)
                colNo += 1

            Next

        End If

    End Sub
    Private Sub picCover_SizeChanged(sender As Object, e As EventArgs)
        AdjustPage()

    End Sub

    Private Sub CoverCanvas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CoverCanvas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ResizePAge()
    End Sub
End Class
