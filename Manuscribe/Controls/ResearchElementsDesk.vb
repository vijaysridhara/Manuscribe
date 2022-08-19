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
Imports System.IO

Friend Class ResearchElementsDesk
    Private currentDisplay As String = "None"
    Public Sub ShowRobjects(Typ As String)
        Panel4.Enabled = False
        Select Case Typ
            Case "IMAGE"
                optImages.Checked = True
            Case "VIDEO"
                optYouTubeLinks.Checked = True
            Case "DOC"
                optDocuments.Checked = True
            Case "TEXT"
                optTextFiles.Checked = True
        End Select

    End Sub
    Private Sub LoadContent()
        Select Case currentDisplay
            Case "VIDEO"
                VideoPlayer1.Show()
                VideoPlayer1.Dock = DockStyle.Fill
                VideoPlayer1.LoadURLS()
                Panel3.Hide()
            Case "IMAGE"

                Panel3.Show()
                VideoPlayer1.Hide()
                Panel3.Dock = DockStyle.Fill
                picPicture.Dock = DockStyle.Fill
                picPicture.BringToFront()
                picPicture.Show()
                picPicture.Image = Nothing
                Panel4.Hide()

                lstRobjects.Items.Clear()
                butSavePage.Enabled = False
                butCopy.Enabled = True
                butAddPage.Enabled = False
                For Each rb As RObject In CurrentBook.RObjects.Values
                    Select Case rb.Type
                        Case RObjectTypes.bmp, RObjectTypes.jpg, RObjectTypes.gif, RObjectTypes.tiff, RObjectTypes.png
                            lstRObjects.Items.Add(rb.Name.Trim)
                    End Select
                Next
                If lstRobjects.Items.Count > 0 Then lstRobjects.SelectedIndex = 0
            Case "DOC"
                Panel3.Show()
                VideoPlayer1.Hide()
                Panel3.Dock = DockStyle.Fill
                txtText.Hide()
                rtfText.Show()
                picPicture.Hide()
                rtfText.Dock = DockStyle.Fill
                rtfText.Clear()
                lstRobjects.Items.Clear()
                Panel4.Show()
                Panel4.BringToFront()
                Panel4.Dock = DockStyle.Fill
                butSavePage.Enabled = True
                butCopy.Enabled = False
                butAddPage.Enabled = True
                For Each rb As RObject In CurrentBook.RObjects.Values
                    Select Case rb.Type
                        Case RObjectTypes.rtf
                            lstRObjects.Items.Add(rb.Name.Trim)
                    End Select
                Next
                If lstRobjects.Items.Count > 0 Then lstRobjects.SelectedIndex = 0
                If lstRobjects.SelectedIndex = -1 Then Panel4.Enabled = False
            Case "TEXT"
                Panel3.Show()
                VideoPlayer1.Hide()
                rtfText.Hide()
                picPicture.Hide()
                Panel3.Dock = DockStyle.Fill
                txtText.Show()
                txtText.Clear()
                txtText.Dock = DockStyle.Fill
                butSavePage.Enabled = True
                butCopy.Enabled = False
                butAddPage.Enabled = True
                lstRobjects.Items.Clear()
                Panel4.Show()
                Panel4.BringToFront()
                Panel4.Dock = DockStyle.Fill
                For Each rb As RObject In CurrentBook.RObjects.Values
                    Select Case rb.Type
                        Case RObjectTypes.txt
                            lstRObjects.Items.Add(rb.Name.Trim)
                    End Select
                Next
                If lstRobjects.Items.Count > 0 Then lstRobjects.SelectedIndex = 0
                If lstRobjects.SelectedIndex = -1 Then Panel4.Enabled = False
        End Select
    End Sub
    Private Sub Reload(typ As String)
        Select Case typ
            Case "IMAGE"
                'pnlPreviewPane.Show()
                LoadImageObjects()
                ' picPicture.Show()
                ' txtText.Hide()
            Case "DOC"
                LoadDocObjects()
                ' pnlPreviewPane.Hide()
            Case "TEXT"
                ' pnlPreviewPane.Show()
                LoadTexTObjects()
                '  txtText.Show()
                ' picPicture.Hide()
        End Select
    End Sub
    Private Sub LoadImageObjects()
        'Dim row, column As Integer
        'Dim spacing As Integer = 20
        'row = 0 : column = 0
        'Dim leftandTop As Integer = 30
        'For Each rb As RObject In CurrentBook.RObjects.Values
        '    Select Case rb.Type
        '        Case RObjectTypes.bmp, RObjectTypes.jpg, RObjectTypes.gif, RObjectTypes.tiff, RObjectTypes.png
        '            Dim rIm As New IntrinsicRObject(IntrinsicObjType.Image, rb.Name)
        '            rIm.Left = leftandTop + column * (spacing + rIm.Width)
        '            rIm.Top = leftandTop + row * (spacing + rIm.Height)
        '            pnlMain.Controls.Add(rIm)
        '            AddHandler rIm.Click, AddressOf RObjecTClicked
        '            column += 1
        '            If column >= 8 Then
        '                column = 0
        '                row += 1
        '            End If
        '        Case Else
        '    End Select
        'Next
      
      
    End Sub
    'Private Sub RObjecTClicked(sender As Object, e As EventArgs)
    '    Dim ro As RObject = CType(sender, IntrinsicRObject).GetRObject
    '    If ro Is Nothing Then Exit Sub
    '    Select Case ro.Type
    '        Case RObjectTypes.txt, RObjectTypes.csv
    '            txtText.Text = ro.Content
    '        Case RObjectTypes.jpg, RObjectTypes.png, RObjectTypes.tiff, RObjectTypes.bmp, RObjectTypes.gif
    '            picPicture.Image = Bitmap.FromStream(New MemoryStream(CType(ro.Content, Byte())))
    '    End Select
    'End Sub
    Private Sub LoadDocObjects()
        'Dim row, column As Integer
        'Dim spacing As Integer = 20
        'row = 0 : column = 0
        'Dim leftandTop As Integer = 30
        'For Each rb As RObject In CurrentBook.RObjects.Values
        '    Select Case rb.Type
        '        Case RObjectTypes.doc, RObjectTypes.docx, RObjectTypes.xls, RObjectTypes.xlsx, RObjectTypes.pdf, RObjectTypes.rtf
        '            Dim rIm As New IntrinsicRObject(IntrinsicObjType.Document, rb.Name)
        '            rIm.Left = leftandTop + column * (spacing + rIm.Width)
        '            rIm.Top = leftandTop + row * (spacing + rIm.Height)
        '            pnlMain.Controls.Add(rIm)
        '            column += 1
        '            If column >= 8 Then
        '                column = 0
        '                row += 1
        '            End If
        '        Case Else
        '    End Select
        'Next
        lstRobjects.Items.Clear()
        butAddPage.Enabled = True
        butSavePage.Enabled = True
        butCopy.Enabled = False
        txtText.Hide()
        rtfText.Show()
        picPicture.Hide()
        rtfText.Dock = DockStyle.Fill
      
    End Sub
    Private Sub LoadTexTObjects()
        'Dim row, column As Integer
        'Dim spacing As Integer = 20
        'row = 0 : column = 0
        'Dim leftandTop As Integer = 30
        'For Each rb As RObject In CurrentBook.RObjects.Values
        '    Select Case rb.Type
        '        Case RObjectTypes.csv, RObjectTypes.txt, RObjectTypes.html
        '            Dim rIm As New IntrinsicRObject(IntrinsicObjType.Text, rb.Name)
        '            rIm.Left = leftandTop + column * (spacing + rIm.Width)
        '            rIm.Top = leftandTop + row * (spacing + rIm.Height)
        '            pnlMain.Controls.Add(rIm)
        '            AddHandler rIm.Click, AddressOf RObjecTClicked
        '            column += 1
        '            If column >= 8 Then
        '                column = 0
        '                row += 1
        '            End If
        '        Case Else
        '    End Select
        'Next
        lstRobjects.Items.Clear()
        txtText.Show()
        rtfText.Hide()
        butAddPage.Enabled = True
        butSavePage.Enabled = True
        butCopy.Enabled = False
        picPicture.Hide()
        txtText.Dock = DockStyle.Fill
     
    End Sub
    'Private Sub ClearObjects()
    '    For Each c As Control In pnlMain.Controls
    '        If TypeOf c Is IntrinsicRObject Then
    '            RemoveHandler c.Click, AddressOf RObjecTClicked
    '        End If
    '    Next
    '    pnlMain.Controls.Clear()
    'End Sub

    Private Sub butAddPage_Click(sender As Object, e As EventArgs) Handles butAddPage.Click
        Try

            Dim fname As String = "Untitled"
Checkhere:
            fname = InputBox("Provide a unique name for this entry", fname)
            If String.IsNullOrEmpty(fname) Then Exit Sub
            If CurrentBook.RObjects.ContainsKey(fname) Then
                MsgBox("This name exists", MsgBoxStyle.Information)
                GoTo Checkhere
            End If

            Select Case currentDisplay
                Case "IMAGE"
                    'No new image can be added directly
                Case "DOC"
                    Dim rob As New RObject()
                    rob.Name = fname
                    rob.Type = RObjectTypes.rtf
                    CurrentBook.AddRObject(rob)
                    lstRobjects.Items.Add(rob.Name)
                    lstRobjects.SelectedItem = rob.Name

                Case "TEXT"
                    Dim rob As New RObject()
                    rob.Name = fname
                    rob.Type = RObjectTypes.txt
                    CurrentBook.AddRObject(rob)
                    lstRobjects.Items.Add(rob.Name)
                    lstRobjects.SelectedItem = rob.Name
            End Select
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub lstRobjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRObjects.SelectedIndexChanged
        If lstRObjects.SelectedIndex = -1 Then Exit Sub
        Select Case currentDisplay
            Case "IMAGE"
                picPicture.Image = Bitmap.FromStream(New MemoryStream(CType(CurrentBook.RObjects(lstRObjects.SelectedItem).Content, Byte())))
                picPicture.SizeMode = PictureBoxSizeMode.Zoom
            Case "DOC"
                rtfText.Rtf = CurrentBook.RObjects(lstRObjects.SelectedItem).Content
                rtfText.ScrollBars = RichTextBoxScrollBars.Both


                butSavePage.Enabled = True

                If lstRObjects.SelectedIndex = -1 Then Panel4.Enabled = False Else : Panel4.Enabled = True

            Case "TEXT"
                txtText.Text = CurrentBook.RObjects(lstRObjects.SelectedItem).Content
                txtText.ScrollBars = ScrollBars.Vertical
                txtText.WordWrap = True

                butSavePage.Enabled = True
                If lstRObjects.SelectedIndex = -1 Then Panel4.Enabled = False : Else : Panel4.Enabled = True
        End Select
    End Sub

    Private Sub butHandles_Click(sender As Object, e As EventArgs) Handles butImport.Click
        Try
            Dim ofd As New OpenFileDialog
            With ofd
                Select Case currentDisplay
                    Case "IMAGE"
                        .Filter = "Image files(*.jpg,*.png,*.gif,*.tiff,*.jpeg,*.bmp)|*.jpg;*.png;*.gif;*.tiff;*.jpeg;*.bmp"
                    Case "DOC"
                        .Filter = "Rich text files(*.rtf)|*.rtf"
                    Case "TEXT"
                        .Filter = "Text files(*.txt,*.csv)|*.txt;*.csv"
                End Select

                .FilterIndex = 0
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim rob As New RObject
                    Dim fext As String = IO.Path.GetExtension(.FileName).ToLower.Substring(1)
                    Dim fname As String = IO.Path.GetFileName(.FileName)
                    If CurrentBook.RObjects.ContainsKey(fname) Then
                        MsgBox("This file already exists, please select a different file, or consider renaming file", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    rob.Name = fname
                    Dim items As Array
                    items = System.Enum.GetValues(GetType(RObjectTypes))
                    For Each it As Integer In items
                        If [Enum].GetName(GetType(RObjectTypes), it) = fext Then
                            rob.Type = it
                            Exit For
                        End If

                    Next
                    Select Case rob.Type
                        Case RObjectTypes.none
                            MsgBox("The file type is not allowed", MsgBoxStyle.Information)
                            Exit Select
                        Case RObjectTypes.bmp, RObjectTypes.jpg, RObjectTypes.png, RObjectTypes.tiff, RObjectTypes.gif
                            Dim readStream As FileStream
                            readStream = New FileStream(.FileName, FileMode.Open)
                            Dim readBinary As New BinaryReader(readStream)
                            Dim bytes() As Byte = readBinary.ReadBytes(readStream.Length)
                            rob.Content = bytes
                            readBinary.Close()
                            readBinary.Dispose()
                            readStream.Close()
                            readStream.Dispose()
                            CurrentBook.AddRObject(rob)




                        Case RObjectTypes.txt, RObjectTypes.csv
                            Dim fr As New IO.StreamReader(.FileName)
                            rob.Content = fr.ReadToEnd
                            CurrentBook.AddRObject(rob)
                            fr.Close()
                            fr.Dispose()

                        Case RObjectTypes.rtf
                            rtfText.LoadFile(.FileName)
                            rob.Content = rtfText.Rtf
                            CurrentBook.AddRObject(rob)

                    End Select
                    lstRobjects.Items.Add(rob.Name)
                    CurrentBook.Modified = True
                End If

            End With

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butSavePage_Click(sender As Object, e As EventArgs) Handles butSavePage.Click
        Try
            If lstRobjects.SelectedIndex = -1 Then Exit Sub
            Select Case currentDisplay
                Case "TEXT"
                    CurrentBook.RObjects(lstRobjects.SelectedItem).Content = txtText.Text
                Case "DOC"
                    CurrentBook.RObjects(lstRobjects.SelectedItem).Content = rtfText.Rtf
            End Select
            CurrentBook.RaiseChanged()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butDeletePage_Click(sender As Object, e As EventArgs) Handles butDeletePage.Click
        Try
            If lstRobjects.SelectedIndex = -1 Then Exit Sub
            If MsgBox("Do you really want to remove this object?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
            CurrentBook.RemoveRObject(lstRobjects.SelectedItem)
            Select Case currentDisplay
                Case "IMAGE"
                    picPicture.Image = Nothing
                Case "TEXT"
                    txtText.Clear()
                Case "DOC"
                    rtfText.Clear()
            End Select
            Debug.Print(lstRobjects.SelectedIndex)
            lstRobjects.Items.Remove(lstRobjects.SelectedItem)
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub

    Private Sub butCopy_Click(sender As Object, e As EventArgs) Handles butCopy.Click
        If lstRobjects.SelectedIndex = -1 Then Exit Sub
        Dim ms As New MemoryStream(CType(CurrentBook.RObjects(lstRObjects.SelectedItems(0)).Content, Byte()))
        Dim img As Image = Bitmap.FromStream(ms)
        Clipboard.SetImage(img)
    End Sub

    Private Sub optImages_CheckedChanged(sender As Object, e As EventArgs) Handles optImages.CheckedChanged
        If optImages.Checked Then
            currentDisplay = "IMAGE"
            LoadContent()
        End If
    End Sub

    Private Sub optDocuments_CheckedChanged(sender As Object, e As EventArgs) Handles optDocuments.CheckedChanged
        If optDocuments.Checked Then
            currentDisplay = "DOC"
            LoadContent()
        End If
    End Sub

    Private Sub optTextFiles_CheckedChanged(sender As Object, e As EventArgs) Handles optTextFiles.CheckedChanged
        If optTextFiles.Checked Then
            currentDisplay = "TEXT"
            LoadContent()
        End If
    End Sub

    Private Sub optYouTubeLinks_CheckedChanged(sender As Object, e As EventArgs) Handles optYouTubeLinks.CheckedChanged
        If optYouTubeLinks.Checked Then
            currentDisplay = "VIDEO"
            LoadContent()
        End If
    End Sub

    Private Sub rtfText_TextChanged(sender As Object, e As EventArgs) Handles rtfText.TextChanged

    End Sub

    Private Sub VideoPlayer1_Load(sender As Object, e As EventArgs) Handles VideoPlayer1.Load

    End Sub
End Class
