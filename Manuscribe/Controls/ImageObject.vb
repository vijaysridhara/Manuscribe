Imports System.IO

Friend Class IntrinsicRObject
    Inherits Control
    Private nameLabel As New Label
    Private iobjType As IntrinsicObjType
    Private WithEvents svebut As New Button
    Private WithEvents cpyBut As Button
    Private WithEvents pnlTop As New Panel
    Private filename As String
    Public Function GetRObject() As RObject
        If String.IsNullOrEmpty(filename) Then Return Nothing
        Return CurrentBook.RObjects(filename)
    End Function
    Public Sub New(typ As IntrinsicObjType, name As String)
        nameLabel.AutoSize = False
        nameLabel.BackColor = Color.White

        nameLabel.Text = name
        nameLabel.TextAlign = ContentAlignment.MiddleCenter
        nameLabel.Font = New Font("Arial", 8, FontStyle.Regular)
        nameLabel.Height = 30
        nameLabel.Dock = DockStyle.Bottom
        Me.Controls.Add(nameLabel)
        Me.iobjType = typ
        pnlTop.Height = 18
        svebut.Dock = DockStyle.Left
        svebut.BackColor = Color.Transparent
        svebut.FlatStyle = FlatStyle.Flat
        svebut.Image = My.Resources.savesmall
        svebut.ImageAlign = ContentAlignment.MiddleCenter
        svebut.Size = New Size(16, 16)
        pnlTop.Controls.Add(svebut)
        If typ = IntrinsicObjType.Image Then
            cpyBut = New Button
            cpyBut.Dock = DockStyle.Right
            cpyBut.FlatStyle = FlatStyle.Flat
            cpyBut.BackColor = Color.Transparent
            cpyBut.Image = My.Resources.copysmall
            cpyBut.ImageAlign = ContentAlignment.MiddleCenter
            cpyBut.Size = New Size(16, 16)
            pnlTop.Controls.Add(cpyBut)
        End If
        pnlTop.Dock = DockStyle.Top
        pnlTop.BackColor = Color.Transparent
        pnlTop.Hide()
        Me.Controls.Add(pnlTop)
        Me.filename = name
        Me.BackgroundImage = CurrentBook.RObjects(name).getThumb
        Me.Size = New Size(130, 130)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub

    Private Sub IntrinsicRObject_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover

    End Sub

    Private Sub IntrinsicRObject_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If e.X < Me.Width And e.Y < 40 Then
            pnlTop.Show()
        Else
            pnlTop.Hide()
        End If
    End Sub

    Private Sub svebut_Click(sender As Object, e As EventArgs) Handles svebut.Click
        Dim sfd As New SaveFileDialog
        With sfd
            Select Case iobjType
                Case IntrinsicObjType.Image
                    .Filter = "Image files(*.jpg,*.png,*.gif,*.tiff,*.jpeg,*.bmp)|*.jpg;*.png;*.gif;*.tiff;*.jpeg;*.bmp"

                Case IntrinsicObjType.Document
                    .Filter = "Document files(*.rtf,*.doc,*.docx,*.xls,*.xlsx,*.pdf)|*.rtf;*.doc;*.docx;*.xls;*.xlsx;*.pdf"

                Case IntrinsicObjType.Text
                    .Filter = "Text files(*.txt,*.csv)|*.txt;*.csv"
            End Select
            .FileName = filename
            If .ShowDialog = DialogResult.OK Then
                If iobjType = IntrinsicObjType.Document Or iobjType = IntrinsicObjType.Image Then
                    Dim fstream As New FileStream(.FileName, FileMode.Create)
                    Dim bw As New BinaryWriter(fstream)
                    bw.Write(CurrentBook.RObjects(filename).Content)
                    bw.Close()
                    bw.Dispose()
                Else
                    Dim sw As New StreamWriter(.FileName)
                    sw.Write(CurrentBook.RObjects(filename).Content)
                    sw.Close()
                    sw.Dispose()
                End If
                If MsgBox("Do you want to open the saved file?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.No Then Exit Sub
                Shell(.FileName, AppWinStyle.NormalFocus, False)
            End If
        End With
    End Sub

    Private Sub cpyBut_Click(sender As Object, e As EventArgs) Handles cpyBut.Click
        Try
            Dim ms As New MemoryStream(CType(CurrentBook.RObjects(filename).Content, Byte()))
            Dim img As Image = Bitmap.FromStream(ms)
            Clipboard.SetImage(img)
        Catch ex As Exception

        End Try
    End Sub
End Class
