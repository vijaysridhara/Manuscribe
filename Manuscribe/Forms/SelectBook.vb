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
Public Class SelectBook

    Private _fPathSelected As String
    Private _createnew As Boolean
    Public ReadOnly Property IsNew As Boolean
        Get
            Return _createnew
        End Get
    End Property
    Public ReadOnly Property FPath As String
        Get
            Return _fPathSelected
        End Get
    End Property
    Private Sub SelectBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRBooks()
    End Sub
    Private Sub LoadRBooks()
        Try
            Dim rowNum, colNum As Integer
            rowNum = 0
            colNum = 0
            Dim eleW As Integer = 126
            Dim eleH As Integer = 166
            Dim spacing = 2
            Dim noFiles As Integer = 0
            For Each rk As String In rBooks.Keys
                Dim rb As RecentBook = rBooks(rk)
                If IO.File.Exists(rb.Path) = True Then
                    noFiles += 1
                    Dim rbc As New RecentBookCtl(rb)
                    rbc.Left = colNum * eleW + (colNum + 1) * spacing
                    rbc.Top = rowNum * eleH + (rowNum + 1) * spacing
                    rbc.Size = New Size(eleW, eleH)
                    pnlRecentBook.Controls.Add(rbc)
                    AddHandler rbc.BookSelected, AddressOf BookSelected
                    AddHandler rbc.BookClicked, AddressOf BookClicked
                    If noFiles Mod 4 = 0 Then
                        rowNum += 1
                        colNum = 0
                    Else
                        colNum = colNum + 1
                    End If
                End If
            Next
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Private Sub BookClicked(sender As RecentBookCtl, rbook As RecentBook)
        Me._fPathSelected = rbook.Path
        lblPath.Text = rbook.Path
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub BookSelected(sender As RecentBookCtl, rbook As RecentBook)
        For Each ctl As RecentBookCtl In pnlRecentBook.Controls
            If Not ctl Is sender Then
                ctl.IsSelected = False
            End If
        Next
        _fPathSelected = rbook.Path
        lblPath.Text = rbook.Path
    End Sub
    Private Sub butOpenDifferent_Click(sender As Object, e As EventArgs) Handles butOpenDifferent.Click
        Try
            Dim osd As New OpenFileDialog
            osd.Filter = "Manuscribe files(*.mnsb)|*.mnsb"
            If osd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me._fPathSelected = osd.FileName
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        If _createnew Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
            Exit Sub
        End If
        For Each ctl As RecentBookCtl In pnlRecentBook.Controls
            If ctl.IsSelected Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
                Exit Sub
            End If
        Next
        Me.DialogResult = DialogResult.None
    End Sub

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub optOpenExisting_CheckedChanged(sender As Object, e As EventArgs) Handles optOpenExisting.CheckedChanged
        If optOpenExisting.Checked Then
            butOpenDifferent.Enabled = True
            pnlRecentBook.Enabled = True
            _createnew = False
        End If
    End Sub

    Private Sub optCreateNew_CheckedChanged(sender As Object, e As EventArgs) Handles optCreateNew.CheckedChanged
        If optCreateNew.Checked Then
            butOpenDifferent.Enabled = False
            pnlRecentBook.Enabled = False
            _fPathSelected = ""
            _createnew = True
        End If
    End Sub
End Class