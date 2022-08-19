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
Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports i00SpellCheck

Public Class AdvRichTextBox
    Inherits RichTextBox
    <StructLayout(LayoutKind.Sequential)>
    Private Structure STRUCT_RECT
        Public left As Int32
        Public top As Int32
        Public right As Int32
        Public bottom As Int32
    End Structure
    <StructLayout(LayoutKind.Sequential)>
    Private Structure STRUCT_CHARRANGE
        Public cpMin As Int32
        Public cpMax As Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Private Structure STRUCT_FORMATRANGE
        Public hdc As IntPtr
        Public hdcTarget As IntPtr
        Public rc As STRUCT_RECT
        Public rcPage As STRUCT_RECT
        Public chrg As STRUCT_CHARRANGE
    End Structure
    <DllImport("user32.dll")>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr,
                                    ByVal msg As Int32,
                                    ByVal wParam As Int32,
                                    ByVal lParam As IntPtr) As Int32
    End Function
    Event IndexAdditionRequested(s As String)

    Private Const WM_USER As Int32 = &H400&

    Friend WithEvents ctxRich As ContextMenuStrip
    Private components As System.ComponentModel.IContainer
    Friend WithEvents butSep1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butTable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butArt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAddtoIndex As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxShowSpellCheker As System.Windows.Forms.ToolStripMenuItem
    Private Const EM_FORMATRANGE As Int32 = WM_USER + 57
    Private WithEvents findF As Findform
    Public Sub BeginUpdate()
        updating += 1
        If updating > 1 Then Return
        oldEventMask = SendMessage(New HandleRef(Me, Handle), EM_SETEVENTMASK, 0, 0)
        SendMessage(New HandleRef(Me, Handle), WM_SETREDRAW, 0, 0)
    End Sub

    Public Sub EndUpdate()
        updating -= 1
        If updating > 0 Then Return
        SendMessage(New HandleRef(Me, Handle), WM_SETREDRAW, 1, 0)
        SendMessage(New HandleRef(Me, Handle), EM_SETEVENTMASK, 0, oldEventMask)
    End Sub

    Public Overloads Property SelectionAlignment As TextAlign
        Get
            Dim fmt As PARAFORMAT = New PARAFORMAT()
            fmt.cbSize = Marshal.SizeOf(fmt)
            SendMessage(New HandleRef(Me, Handle), EM_GETPARAFORMAT, SCF_SELECTION, fmt)
            If (fmt.dwMask And PFM_ALIGNMENT) = 0 Then Return TextAlign.Left
            Return CType(fmt.wAlignment, TextAlign)
        End Get
        Set(ByVal value As TextAlign)
            Dim fmt As PARAFORMAT = New PARAFORMAT()
            fmt.cbSize = Marshal.SizeOf(fmt)
            fmt.dwMask = PFM_ALIGNMENT
            fmt.wAlignment = CShort(value)
            SendMessage(New HandleRef(Me, Handle), EM_SETPARAFORMAT, SCF_SELECTION, fmt)
        End Set
    End Property

    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)
        SendMessage(New HandleRef(Me, Handle), EM_SETTYPOGRAPHYOPTIONS, TO_ADVANCEDTYPOGRAPHY, TO_ADVANCEDTYPOGRAPHY)
    End Sub

    Private updating As Integer = 0
    Private oldEventMask As Integer = 0
    Private Const EM_SETEVENTMASK As Integer = 1073
    Private Const EM_GETPARAFORMAT As Integer = 1085
    Private Const EM_SETPARAFORMAT As Integer = 1095
    Private Const EM_SETTYPOGRAPHYOPTIONS As Integer = 1226
    Private Const WM_SETREDRAW As Integer = 11
    Private Const TO_ADVANCEDTYPOGRAPHY As Integer = 1
    Private Const PFM_ALIGNMENT As Integer = 8
    Private Const SCF_SELECTION As Integer = 1

    <StructLayout(LayoutKind.Sequential)>
    Private Structure PARAFORMAT
        Public cbSize As Integer
        Public dwMask As UInteger
        Public wNumbering As Short
        Public wReserved As Short
        Public dxStartIndent As Integer
        Public dxRightIndent As Integer
        Public dxOffset As Integer
        Public wAlignment As Short
        Public cTabCount As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
        Public rgxTabs As Integer()
        Public dySpaceBefore As Integer
        Public dySpaceAfter As Integer
        Public dyLineSpacing As Integer
        Public sStyle As Short
        Public bLineSpacingRule As Byte
        Public bOutlineLevel As Byte
        Public wShadingWeight As Short
        Public wShadingStyle As Short
        Public wNumberingStart As Short
        Public wNumberingStyle As Short
        Public wNumberingTab As Short
        Public wBorderSpace As Short
        Public wBorderWidth As Short
        Public wBorders As Short
    End Structure

    <DllImport("user32", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    End Function
    <DllImport("user32", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByRef lp As PARAFORMAT) As Integer

    End Function
    ' Calculate or render the contents of our RichTextBox for printing
    '
    ' Parameter "measureOnly": If true, only the calculation is performed,
    '                          otherwise the text is rendered as well
    ' Parameter "e": The PrintPageEventArgs object from the PrintPage event
    ' Parameter "charFrom": Index of first character to be printed
    ' Parameter "charTo": Index of last character to be printed
    ' Return value: (Index of last character that fitted on the page) + 1
    Public Function FormatRange(ByVal measureOnly As Boolean,
                                ByVal e As Printing.PrintPageEventArgs,
                                ByVal charFrom As Integer,
                                ByVal charTo As Integer) As Integer
        ' Specify which characters to print
        Dim cr As STRUCT_CHARRANGE
        cr.cpMin = charFrom
        cr.cpMax = charTo

        ' Specify the area inside page margins
        Dim rc As STRUCT_RECT
        rc.top = HundredthInchToTwips(e.MarginBounds.Top)
        rc.bottom = HundredthInchToTwips(e.MarginBounds.Bottom)
        rc.left = HundredthInchToTwips(e.MarginBounds.Left)
        rc.right = HundredthInchToTwips(e.MarginBounds.Right)

        ' Specify the page area
        Dim rcPage As STRUCT_RECT
        rcPage.top = HundredthInchToTwips(e.PageBounds.Top)
        rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom)
        rcPage.left = HundredthInchToTwips(e.PageBounds.Left)
        rcPage.right = HundredthInchToTwips(e.PageBounds.Right)

        ' Get device context of output device
        Dim hdc As IntPtr
        hdc = e.Graphics.GetHdc()

        ' Fill in the FORMATRANGE structure
        Dim fr As STRUCT_FORMATRANGE
        fr.chrg = cr
        fr.hdc = hdc
        fr.hdcTarget = hdc
        fr.rc = rc
        fr.rcPage = rcPage

        ' Non-Zero wParam means render, Zero means measure
        Dim wParam As Int32
        If measureOnly Then
            wParam = 0
        Else
            wParam = 1
        End If

        ' Allocate memory for the FORMATRANGE struct and
        ' copy the contents of our struct to this memory
        Dim lParam As IntPtr
        lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr))
        Marshal.StructureToPtr(fr, lParam, False)

        ' Send the actual Win32 message
        Dim res As Integer
        res = SendMessage(Handle, EM_FORMATRANGE, wParam, lParam)

        ' Free allocated memory
        Marshal.FreeCoTaskMem(lParam)

        ' and release the device context
        e.Graphics.ReleaseHdc(hdc)

        Return res
    End Function
    ' Convert between 1/100 inch (unit used by the .NET framework)
    ' and twips (1/1440 inch, used by Win32 API calls)
    '
    ' Parameter "n": Value in 1/100 inch
    ' Return value: Value in twips
    Private Function HundredthInchToTwips(ByVal n As Integer) As Int32
        Return Convert.ToInt32(n * 14.4)
    End Function
    ' Free cached data from rich edit control after printing
    Public Sub FormatRangeDone()
        Dim lParam As New IntPtr(0)
        SendMessage(Me.Handle, EM_FORMATRANGE, 0, lParam)
    End Sub
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)


        EnableControlExtensions()
        EnableSpellCheck()
        SpellCheck.Settings.ShowMistakes = False
        DirectCast(SpellCheck(), SpellCheckTextBox).RenderCompatibility = True
        findF = New Findform(Me)

    End Sub
    Public Overloads Function FindForm() As Form
        Return findF
    End Function
    Public Property ShowMistakes As Boolean
        Get
            Return SpellCheck.Settings.ShowMistakes
        End Get
        Set(value As Boolean)
            SpellCheck.Settings.ShowMistakes = value
            'Me.SpellCheck.RepaintControl()
            Me.Invalidate(Me.Bounds)
        End Set
    End Property

    Private Sub AdvRichTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.A
                    SelectAll()
                Case Keys.B
                    Dim ft As Font = SelectionFont
                    If ft Is Nothing Then Exit Select
                    ft = New Font(ft.FontFamily, ft.Size, ft.Style Xor FontStyle.Bold)
                    SelectionFont = ft
                Case Keys.F
                    'FindForm.ShowDialog()
                    findF.optFind.Checked = True
                    findF.ShowDialog()
                Case Keys.H
                    findF.optReplace.Checked = True
                    findF.ShowDialog()
                Case Keys.T
                    Dim ft As Font = SelectionFont
                    If ft Is Nothing Then Exit Select
                    ft = New Font(ft.FontFamily, ft.Size, ft.Style Xor FontStyle.Italic)
                    SelectionFont = ft
                Case Keys.U
                    Dim ft As Font = SelectionFont
                    If ft Is Nothing Then Exit Select
                    ft = New Font(ft.FontFamily, ft.Size, ft.Style Xor FontStyle.Underline)
                    SelectionFont = ft
                Case Keys.S
                    'LEave it for saving the file
                Case Keys.X

                Case Keys.V

                Case Keys.C

                Case Keys.N



            End Select
        End If
    End Sub

    Private Sub AdvRichTextBox_SelectionChanged(sender As Object, e As EventArgs) Handles Me.SelectionChanged

    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ctxRich = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.butArt = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAddtoIndex = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxShowSpellCheker = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxRich.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctxRich
        '
        Me.ctxRich.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ctxRich.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butArt, Me.ctxAddtoIndex, Me.ctxShowSpellCheker})
        Me.ctxRich.Name = "ContextMenuStrip1"
        Me.ctxRich.Size = New System.Drawing.Size(200, 76)
        '
        'butArt
        '
        Me.butArt.Name = "butArt"
        Me.butArt.Size = New System.Drawing.Size(199, 24)
        Me.butArt.Text = "Insert art"
        '
        'ctxAddtoIndex
        '
        Me.ctxAddtoIndex.Name = "ctxAddtoIndex"
        Me.ctxAddtoIndex.Size = New System.Drawing.Size(199, 24)
        Me.ctxAddtoIndex.Text = "Add to index"
        '
        'ctxShowSpellCheker
        '
        Me.ctxShowSpellCheker.Name = "ctxShowSpellCheker"
        Me.ctxShowSpellCheker.Size = New System.Drawing.Size(199, 24)
        Me.ctxShowSpellCheker.Text = "&Show spellchecker"
        '
        'AdvRichTextBox
        '
        Me.ContextMenuStrip = Me.ctxRich
        Me.ctxRich.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub





    Private Sub butArt_Click(sender As Object, e As EventArgs) Handles butArt.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .Filter = "Image files(*.jpg, *.png, *.gif, *.tiff, *.bmp)|*.jpg;*.png;*.gif;*.tiff;*.bmp"
            If .ShowDialog = DialogResult.OK Then
                Dim img As Image = Bitmap.FromFile(.FileName)
                Dim imr As New ImageResizer(img)
                If imr.ShowDialog = DialogResult.OK Then
                    Dim xt As Image = Clipboard.GetImage
                    Clipboard.SetImage(imr.GetResizedImage)
                    Paste()
                    If Not xt Is Nothing Then Clipboard.SetImage(xt)
                End If

            End If
        End With
    End Sub

    Private Sub ctxRich_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxRich.Opening
        If String.IsNullOrEmpty(SelectedText) Then
            ctxAddtoIndex.Enabled = False
        Else
            ctxAddtoIndex.Enabled = True
        End If


    End Sub

    Private Sub ctxAddtoIndex_Click(sender As Object, e As EventArgs) Handles ctxAddtoIndex.Click
        Dim txt As String = SelectedText
        If String.IsNullOrEmpty(txt) Then Exit Sub
        RaiseEvent IndexAdditionRequested(txt)
    End Sub
    Public Sub ShowSpellChecker()
        Dim iSpellCheckDialog = TryCast(SpellCheck(), i00SpellCheck.SpellCheckControlBase.iSpellCheckDialog)
        If iSpellCheckDialog IsNot Nothing Then
            iSpellCheckDialog.ShowDialog()
        End If
    End Sub

    Private Sub ctxShowSpellCheker_Click(sender As Object, e As EventArgs) Handles ctxShowSpellCheker.Click
        ShowSpellChecker()
    End Sub
End Class

Public Enum TextAlign
    Left = 1
    Right = 2
    Center = 3
    Justify = 4
End Enum
