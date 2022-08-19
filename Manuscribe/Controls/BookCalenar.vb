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
Public Class BookCalenar
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub showLog()
        ListView1.Items.Clear()
        Dim rowNo As Integer = 0
        Dim prevWordCount As Integer = 0
        For Each te As TaskEntry In CurrentBook.History.Values
            rowNo += 1
            Dim lv As New ListViewItem(rowNo)
            lv.SubItems.Add(te.OnDate)
            lv.SubItems.Add(te.WordCount)
            lv.SubItems.Add(te.WordCount - prevWordCount)
            If te.WordCount < prevWordCount Then
                lv.BackColor = Color.Red
            End If
            prevWordCount = te.WordCount
            ListView1.Items.Add(lv)
        Next
    End Sub

    Private Sub BookCalenar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BookCalenar_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ListView1.Left = Me.Width / 2 - ListView1.Width / 2
        ListView1.Height = Me.Height - Label1.Height - 4
    End Sub
End Class
