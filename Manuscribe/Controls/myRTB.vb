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
Imports System.Runtime.InteropServices
Imports i00SpellCheck
Public Class myRTB
    Inherits Panel
    Private WithEvents inrich As New AdvRichTextBox
    Private _showMargins As Boolean
    Private marginPen As New Pen(Brushes.Gray, 1)
    Private components As System.ComponentModel.IContainer
    Private ps As PageTemplate = New PageTemplate() 'Defaults to A5
    Event SelectionChanged()
    Event ContentModified()
    Event IndexAdditionRequested(s As String)
    Private _seamlessEdit As Boolean
    Public Property SeamlessEditing As Boolean
        Get
            Return _seamlessEdit
        End Get
        Set(value As Boolean)
            _seamlessEdit = value
            ResizePage()
        End Set
    End Property

    Public Property ShowMargins As Boolean
        Get
            Return _showMargins
        End Get
        Set(value As Boolean)

            _showMargins = value
            Me.Invalidate()
        End Set
    End Property
    Public Property PageSet As PageTemplate
        Get
            Return ps
        End Get
        Set(value As PageTemplate)
            ps = value
            ResizePage()
        End Set
    End Property
    Public Sub New()
        inrich.BorderStyle = Windows.Forms.BorderStyle.None
        inrich.HideSelection = False
        inrich.Dock = DockStyle.Fill
        inrich.Font = New Font("Verdana", 10, FontStyle.Regular)
        inrich.ScrollBars = RichTextBoxScrollBars.None
        Me.Controls.Add(inrich)
        marginPen.DashStyle = Drawing2D.DashStyle.DashDot

        Me.BackColor = Color.White
        ResizePage()
     
    End Sub

    Private Sub ResizePage()
        Dim g As Graphics = inrich.CreateGraphics
        'Me.Size = New Size(ps.Size.Width / 100 * 96, ps.Size.Height / 100 * 96)
        'Me.Size = New Size(ps.Size.Width, ps.Size.Height)
        'Debug.Print("Me.width" & Me.Width)
        'Debug.Print("Me.clientwodth" & Me.ClientRectangle.Width)
        'Debug.Print("inrich width" & inrich.Width)
        'Debug.Print("inrich.clientwidth" & inrich.ClientRectangle.Width)
        If SeamlessEditing Then
            Me.Padding = New Padding(100, 10, 5, 0)
            Me.Dock = DockStyle.Fill
        Else
            Me.Dock = DockStyle.None
            Me.Size = New Size(ps.Size.Width * g.DpiX / 100, ps.Size.Height * g.DpiY / 100)
            If CurrentBook Is Nothing Then
                Me.Padding = New Padding(ps.Margins.Left * g.DpiX / 100, ps.Margins.Top * g.DpiY / 100, ps.Margins.Right * g.DpiX / 100, ps.Margins.Bottom * g.DpiY / 100)

            Else
                Me.Padding = New Padding(ps.Margins.Left * g.DpiX / 100, ps.Margins.Top * g.DpiY / 100, ps.Margins.Right * g.DpiX / 100, ps.Margins.Bottom * g.DpiY / 100)

            End If
        End If


        Me.Invalidate()
    End Sub
    Dim leftTop1, leftBottom1, rightTop1, rightBottom1 As Point
    Dim leftTop2, leftBottom2, rightTop2, rightBottom2 As Point

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub

    Private Sub myRTB_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        If ShowMargins Then

            leftTop1 = New Point(Me.Padding.Left - 1, 0)
                leftBottom1 = New Point(Me.Padding.Left - 1, Me.Height)
                rightTop1 = New Point(Me.Width - Me.Padding.Right, 0)
                rightBottom1 = New Point(Me.Width - Me.Padding.Right, Me.Height)
                leftTop2 = New Point(0, Me.Padding.Top - 1)
                leftBottom2 = New Point(0, Me.Height - Me.Padding.Bottom)
                rightTop2 = New Point(Me.Width, Me.Padding.Top - 1)
                rightBottom2 = New Point(Me.Width, Me.Height - Me.Padding.Bottom)
                e.Graphics.DrawLine(marginPen, leftTop1, leftBottom1)
                e.Graphics.DrawLine(marginPen, rightTop1, rightBottom1)
                e.Graphics.DrawLine(marginPen, leftTop2, rightTop2)
                e.Graphics.DrawLine(marginPen, leftBottom2, rightBottom2)



        End If
    End Sub
    Public ReadOnly Property RTBox As AdvRichTextBox
        Get
            Return inrich
        End Get
    End Property

    Private Sub inrich_IndexAdditionRequested(s As String) Handles inrich.IndexAdditionRequested
        RaiseEvent IndexAdditionRequested(s)
    End Sub

    


    Private Sub inrich_SelectionChanged(sender As Object, e As EventArgs) Handles inrich.SelectionChanged
        RaiseEvent SelectionChanged()
    End Sub

    Private Sub inrich_TextChanged(sender As Object, e As EventArgs) Handles inrich.TextChanged
        RaiseEvent ContentModified()
    End Sub


    Public Sub ShowSpellChecker()
        inrich.showSpellChecker()
    End Sub
End Class
