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
Public Class RecentBookCtl
    Inherits Control
    Dim rbook As RecentBook
    Private WithEvents lblTitle As New Label
    Private WithEvents bookCovCtl As New Control
    Dim _isselected As Boolean
    Event BookSelected(sender As RecentBookCtl, rbook As RecentBook)
    Event BookClicked(sender As RecentBookCtl, rbook As RecentBook)
    Public Sub New(rbook As RecentBook)
        Me.rbook = rbook
        lblTitle.AutoSize = False
        lblTitle.Font = New Font("Arial", 8, FontStyle.Regular)
        Me.BackColor = Color.White
        Me.Size = New Size(116, 175)
        bookCovCtl.BackgroundImage = rbook.Cover
        bookCovCtl.BackgroundImageLayout = ImageLayout.Zoom
        bookCovCtl.Size = New Size(108, 140)
        bookCovCtl.Location = New Point(11, 5)
        bookCovCtl.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        Me.Controls.Add(bookCovCtl)
        Me.Controls.Add(lblTitle)
        lblTitle.Text = rbook.Name
        lblTitle.Dock = DockStyle.Bottom
        lblTitle.BackColor = Color.Transparent
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' lblTitle.BorderStyle = BorderStyle.FixedSingle

        lblTitle.BringToFront()
        lblTitle.Height = 30
    End Sub
    Public Property IsSelected As Boolean
        Get
            Return _isselected
        End Get
        Set(value As Boolean)
            _isselected = value
            If value Then
                Me.BackColor = Color.Cyan
                RaiseEvent BookSelected(Me, rbook)
            Else
                Me.BackColor = Color.White
            End If
        End Set
    End Property

    Private Sub bookCovCtl_Click(sender As Object, e As EventArgs) Handles bookCovCtl.Click
        IsSelected = True
    End Sub

    Private Sub RecentBookCtl_Click(sender As Object, e As EventArgs) Handles Me.Click
        IsSelected = True
    End Sub

    Private Sub lblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        IsSelected = True
    End Sub

    Private Sub RecentBookCtl_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        RaiseEvent BookClicked(Me, rbook)
    End Sub

    Private Sub bookCovCtl_DoubleClick(sender As Object, e As EventArgs) Handles bookCovCtl.DoubleClick
        RaiseEvent BookClicked(Me, rbook)
    End Sub

    Private Sub lblTitle_DoubleClick(sender As Object, e As EventArgs) Handles lblTitle.DoubleClick
        RaiseEvent BookClicked(Me, rbook)
    End Sub
End Class
