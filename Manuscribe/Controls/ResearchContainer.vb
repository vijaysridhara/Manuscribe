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
Friend Class ResearchContainer
    Private _iscat As Boolean
    Event RObjecTCategoryClicked(cat As String)
    Public Sub Clear()
        _iscat = False
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is Label Then
                RemoveHandler ctl.DoubleClick, AddressOf CatClicked
            End If
        Next
        Me.Controls.Clear()
    End Sub
    Private Sub CatClicked(sender As Object, e As EventArgs)
        RaiseEvent RObjecTCategoryClicked(CType(sender, Label).Tag)
    End Sub
    Public Sub LoadResearChCategories()
        Clear()
        _iscat = True
        Dim lbl1, lbl2, lbl3 As New Label
        Dim cnt1, cnt2, cnt3 As Integer
        For Each r As RObject In CurrentBook.RObjects.Values
            Select Case r.Type
                Case RObjectTypes.bmp, RObjectTypes.jpg, RObjectTypes.tiff, RObjectTypes.png, RObjectTypes.gif
                    cnt1 += 1
                Case RObjectTypes.rtf
                    cnt2 += 1
                Case RObjectTypes.txt, RObjectTypes.csv
                    cnt3 += 1
            End Select

        Next
        With lbl1
            .AutoSize = False
            .Text = "Images [" & cnt1 & "]"
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = New Font("Arial", 11, FontStyle.Regular)
            .Image = My.Resources.images_big
            .Size = New Size(256, 200)
            .Tag = "IMAGE"
            AddHandler .DoubleClick, AddressOf CatClicked
        End With
        With lbl2
            .AutoSize = False
            .Text = "Documents [" & cnt2 & "]"
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = New Font("Arial", 11, FontStyle.Regular)
            .Image = My.Resources.documents_big
            .Size = New Size(256, 200)
            lbl2.Tag = "DOC"
            AddHandler .DoubleClick, AddressOf CatClicked
        End With
        With lbl3
            .AutoSize = False
            .Text = "Text files [" & cnt3 & "]"
            .BackColor = Color.Transparent
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = New Font("Arial", 11, FontStyle.Regular)
            .Image = My.Resources.textfiles_big
            .Size = New Size(256, 200)
            .Tag = "TEXT"
            AddHandler .DoubleClick, AddressOf CatClicked
        End With
        Me.Controls.AddRange(New Control() {lbl1, lbl2, lbl3})
        ArrangEControls()
    End Sub
    Private Sub ArrangEControls()
        If _iscat Then
            Dim spacing As Integer = 50
            Dim left As Integer = Me.Width / 2 - (600 + 2 * spacing) / 2
            If left < 0 Then left = 0
            Dim top As Integer = Me.Height / 2 - 256 / 2
            If top < 0 Then top = 0

            For Each ctl As Control In Me.Controls
                ctl.Left = left
                ctl.Top = top
                left += 256 + spacing
            Next
        Else
        End If
    End Sub
    Public Sub UpdateCount(type As String)
        Dim cnt1, cnt2, cnt3 As Integer
        For Each r As RObject In CurrentBook.RObjects.Values
            Select Case r.Type
                Case RObjectTypes.bmp, RObjectTypes.jpg, RObjectTypes.tiff, RObjectTypes.png, RObjectTypes.gif
                    cnt1 += 1
                Case RObjectTypes.rtf
                    cnt2 += 1
                Case RObjectTypes.txt, RObjectTypes.csv
                    cnt3 += 1
            End Select

        Next
        For Each CTL As Label In Me.Controls
            If CTL.Tag = type Then
                Select Case type
                    Case "IMAGE"
                        CTL.Text = "Images [" & cnt1 & "]"
                    Case "DOC"
                        CTL.Text = "Documents [" & cnt2 & "]"
                    Case "TEXT"
                        CTL.Text = "Text files [" & cnt3 & "]"
                End Select
            End If
        Next

    End Sub
    Public Sub LoadObjects(typ As RObjectTypes)
        _iscat = False
    End Sub
    Private Sub ResearchContainer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ArrangEControls()
    End Sub
End Class
