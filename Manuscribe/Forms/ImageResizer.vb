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
Public Class ImageResizer
    Private newImg As Image

    Private Sub ImageResizer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub New(img As Image)
        InitializeComponent()
        PictureBox1.Image = img
        lblOriginalSize.Text = "Width: " & img.Size.Width & "  Height: " & img.Size.Height
        lblNewSize.Text = "Width: " & img.Size.Width & "  Height: " & img.Size.Height
        newImg = New Bitmap(CInt(PictureBox1.Image.Width * trkSize.Value / 100), CInt(PictureBox1.Image.Height * trkSize.Value / 100))
    End Sub

    Private Sub trkSize_Scroll(sender As Object, e As EventArgs) Handles trkSize.Scroll
        newImg = New Bitmap(CInt(PictureBox1.Image.Width * trkSize.Value / 100), CInt(PictureBox1.Image.Height * trkSize.Value / 100))
        lblNewSize.Text = "Width: " & newImg.Size.Width & "  Height: " & newImg.Size.Height
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        Dim G As Graphics = Graphics.FromImage(newImg)
        G.DrawImage(PictureBox1.Image, New Rectangle(0, 0, newImg.Width, newImg.Height))
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Public ReadOnly Property GetResizedImage() As Image
        Get
            Return newImg
        End Get

    End Property

    Private Sub butCancel_Click(sender As Object, e As EventArgs) Handles butCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class