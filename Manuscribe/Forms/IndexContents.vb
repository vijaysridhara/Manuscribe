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
Public Class IndexContents

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Dim lineLength As Integer = 65

    Private Sub IndexContents_Load(sender As Object, e As EventArgs) Handles Me.Load


        Dim chNo As Integer = 1
        Dim pageNo As Integer = 1
        Dim firstChapCompleted As Boolean = False
        For Each ch As Chapter In CurrentBook.Chapters
            If My.Settings.PrintalternateNumberonChapter1 And firstChapCompleted = False Then
                firstChapCompleted = True
                Continue For
            Else
                ArrangeLine(ch.Name, pageNo, 1)
                Dim firstPageCompleted As Boolean = False
                For Each p As Page In ch.Pages
                    If firstPageCompleted = False Then
                        For Each ixn As String In p.IndexEntries
                            If String.IsNullOrEmpty(ixn) Then Continue For
                            ArrangeLine(ixn, pageNo, 2)
                        Next
                        firstPageCompleted = True
                        If firstPageCompleted Then
                            pageNo += 1
                        End If
                    Else
                        For Each ixn As String In p.IndexEntries
                            If String.IsNullOrEmpty(ixn) Then Continue For
                            ArrangeLine(ixn, pageNo, 2)
                        Next
                        pageNo += 1
                    End If
                Next
                chNo += 1
            End If

        Next

    End Sub
    Private Function ArrangeLine(content As String, pageNo As String, level As String)
        Dim leftbuffer As String = Space(4)

        While pageNo.Length < 3
            pageNo = " " & pageNo
        End While
        If level = 1 Then
            content = "  " & content
        Else
            content = " " & Space(4) & content
        End If
        Dim actLen As Integer = Len(leftbuffer & content & pageNo)
        While actLen < lineLength
            content = content & " "
            actLen = Len(leftbuffer & content & pageNo)
        End While
        txtContents.AppendText(leftbuffer & content & pageNo & vbCrLf)
    End Function
End Class