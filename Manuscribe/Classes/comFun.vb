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
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary

Friend Class CovImage
    Friend typ As ImageType
    Friend img As Image
End Class
Enum PageType
    Document
    Image
End Enum

Enum TaskTypes
    None
    Created
    Book_title_changed
    Book_subtitle_changed
    Book_author_changed
    Book_size_changed
    Outline_added
    Draft_added
    Draft_removed
    Chapter_added
    Chapter_shuffled
    Chapter_removed
    Draft_moved_to_chapters
    Rename_chapter
    Rename_draft
    Edited_synopsis
    Edited_chapter_name
    Added_cover_image

    Added_research_object
    Removed_research_object
    Changed_page_type
    Page_added
    Page_removed
    Page_image_added
    Page_edited
    Cleaned_trash
End Enum


Enum IntrinsicObjType
    None
    Image
    Document
    Text
End Enum
Enum StringLoc
    None
    TopMiddle
    BottomMiddle
    TopCornerOut
    BottomCornerOut
    TopCornerIn
    BottomCornerIn
End Enum

Enum FillRectangle
    None
    TopAndBottom
    TopOnly
    BottomOnly
End Enum
Enum OutlinePattern
    None
    Box
    TopAndbottom
    TopOnly
    BottomOnly
End Enum
Enum ImagePattern
    None
    LeftImage
    RightImage
End Enum
Module comFun
    Enum RObjectTypes
        none
        rtf
        txt
        csv
        jpg
        png
        bmp
        gif
        tiff
    End Enum
    Enum ImageType
        FrontCoverOut
        FrontCoverIn
        BackCoverIn
        BackCoverOut
    End Enum
    'Enum BookStructure
    '    FreeFlow
    '    Pagified
    'End Enum
    Friend Function StringDate() As String
        Return Format(Date.Now, "yyyy-MM-dd")
    End Function
    Private rint() As String = New String() {"i", "ii", "iii", "iv", "v", "vi", "vii", "viii", "ix", "x"}
    Private timelock As New Object
    Dim prevTime As DateTime
    Friend rBooks As New RecentBooks
    Dim recentFilesPath As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\recentfilelist.dat"
    Friend Function GetRomanNumber(int As Integer)
        Dim hundreds As Integer = Math.Truncate(int / 100)
        Dim balTens As Integer = int Mod 100
        Dim finString As String = ""
        For i As Integer = 1 To hundreds
            finString += "c"
        Next
        Dim balUnits As Integer
        If balTens >= 90 Then
            balUnits = balTens Mod 90
            finString += "xc"
            If balUnits > 0 Then finString += GetRomanNumber(balUnits)
        ElseIf balTens >= 50 Then
            balUnits = balTens Mod 50
            finString += "l"
            If balUnits > 0 Then finString += GetRomanNumber(balUnits)
        ElseIf balTens >= 40 Then
            balUnits = balTens Mod 40
            finString += "xl"
            If balUnits > 0 Then finString += GetRomanNumber(balUnits)
        ElseIf balTens >= 10 Then
            Dim noTens As Integer = Math.Truncate(balTens / 10)
            balUnits = balTens Mod 10
            For i As Integer = 1 To noTens
                finString += "x"
            Next
            If balUnits > 0 Then finString += GetRomanNumber(balUnits)
        Else
            If balTens > 0 Then finString += rint(balTens - 1)
        End If
        Return finString
    End Function
    Friend Sub SaveObjecttoRecentPath(fpath As String, cbook As Book)
        Try
            If rBooks.ContainsKey(fpath) Then
                rBooks(fpath).ModTime = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")
                rBooks(fpath).Name = cbook.Title
                If cbook.Covers.ContainsKey(ImageType.FrontCoverOut) Then
                    Dim newimg As Image = New Bitmap(108, 140)
                    Dim g As Graphics = Graphics.FromImage(newimg)
                    g.DrawImage(cbook.Covers(ImageType.FrontCoverOut).Image, New Rectangle(0, 0, 108, 140))
                    rBooks(fpath).Cover = newimg
                End If

            Else
                Dim rb As New RecentBook
                rb.ModTime = Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")
                rb.Name = cbook.Title
                rb.Path = fpath
                If cbook.Covers.ContainsKey(ImageType.FrontCoverOut) Then
                    Dim newimg As Image = New Bitmap(108, 140)
                    Dim g As Graphics = Graphics.FromImage(newimg)
                    g.DrawImage(cbook.Covers(ImageType.FrontCoverOut).Image, New Rectangle(0, 0, 108, 140))
                    rb.Cover = newimg
                Else
                    rb.Cover = My.Resources.bookcover.Clone
                End If
                rBooks.Add(fpath, rb)
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Friend Function StringTimestamp() As String
        SyncLock timelock
            Dim curTime As DateTime = DateTime.Now
            While prevTime = curTime
                Threading.Thread.Sleep(10)
                curTime = DateTime.Now
            End While
            prevTime = curTime

            Return Format(curTime, "yyyy-MM-dd HH:mm:ss fffffff")
        End SyncLock
    End Function
    Friend Sub AddLog(ttype As TaskTypes)
        If bookLoading Then Exit Sub
        Dim dt As String = StringDate()
        Dim tme As String = StringTimestamp()
        Dim te As TaskEntry
        If ttype = TaskTypes.Created Then
            CurrentBook.Createdon = tme
        End If
        If CurrentBook.History.ContainsKey(dt) Then
            te = CurrentBook.History(dt)
        Else
            te = New TaskEntry
            te.OnDate = dt
            CurrentBook.History.Add(dt, te)
        End If


        te.Tasks.Add(tme, ttype)
        te.WordCount = CurrentBook.WordCount
        CurrentBook.Updatedon = tme
    End Sub
    Friend Sub SerializeRecentBooks()
        Try
            If rBooks.Count > 0 Then
                Dim st As Stream = File.Open(recentFilesPath, FileMode.Create)
                Dim spF As New BinaryFormatter
                spF.Serialize(st, rBooks)
                st.Close()
                rBooks = Nothing


            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Friend Sub DeserializeRecentBooks()
        Try
            If File.Exists(recentFilesPath) = False Then Exit Sub
            Dim st As Stream = File.Open(recentFilesPath, FileMode.Open)
            Dim spf As New BinaryFormatter
            rBooks = spf.Deserialize(st)
            st.Close()
            Dim nonExKeys As New List(Of String)
            For Each k As String In rBooks.Keys
                If File.Exists(k) = False Then
                    nonExKeys.Add(k)
                End If
            Next
            For Each k As String In nonExKeys
                rBooks.Remove(k)
            Next
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
  
    Friend Function ImageFormatfromString(fmt As String) As Imaging.ImageFormat
        Select Case fmt.ToLower
            Case "jpg", "jpeg"
                Return Imaging.ImageFormat.Jpeg
            Case "bmp"
                Return Imaging.ImageFormat.Bmp
            Case "png"
                Return Imaging.ImageFormat.Png
            Case "gif"
                Return Imaging.ImageFormat.Gif
            Case "tiff"
                Return Imaging.ImageFormat.Tiff

        End Select

    End Function
    Friend availableFonts As New List(Of String)
    Friend SystemStyles As New Dictionary(Of String, StyleSet)
    Friend pageTypes As New Dictionary(Of String, PageTemplate)
    Friend defaultFont = New Font("Arial", 10, FontStyle.Regular)
    Friend CurrentBook As Book
    Dim installedFonts As New System.Drawing.Text.InstalledFontCollection
    Friend fontFamilies() As FontFamily = installedFonts.Families
    'Friend PrintBorder As OutlinePattern

    Friend PrintPageNoFormat As String

    Friend PrintLeftImageValue As Image
    Friend PrintRightImageValue As Image

    Friend PrintTitleText As String = "#CHAP#"
    Friend printLeftTitleText As String = "#CHAP#"
    Friend PrintMetaFont As Font
    Friend bookLoading As Boolean = False 'Required for stopping XMLEncoding Decoding while loading book (removing &lt; &gt etc)
    Friend AllStyles As New SortedList(Of String, StyleSet)

    Public Function xmlEncode(st As String) As String
        On Error Resume Next
        If st Is Nothing Then
            st = ""
        Else
            st = st.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("""", "&quot;").Replace("'", "&apos;").Replace(Chr(12), "")

        End If
        Return st
    End Function
    Public Function xmlDecode(st As String) As String
        On Error Resume Next
        If String.IsNullOrEmpty(st) Then
            Return ""
        Else
            st = st.Replace("&amp;", "&").Replace("&lt;", "<").Replace("&gt;", ">").Replace("&quot;", """").Replace("&apos;", "'")

        End If
        Return st
    End Function
    Friend Sub LoadSettings()
        'For i As Integer = 1 To 200
        '    Debug.Print(i & " " & GetRomanNumber(i))
        'Next
        'With My.Settings
        '    PrintBorder = .PrintBorder

        '    PrintBorderColor = .PrintBorderColor
        '    PrintFillRectangle = .PrintFillRectangle
        '    PrintFillRectangleColor = .PrintFillRectangleColor
        '    PrintRightImage = .PrintRightImage
        '    PrintLeftImage = .PrintLeftImage
        PrintPageNoFormat = My.Settings.PrintPageNoFormat
        '    PrintPageNoLoc = .PrintPageNoLoc
        '    PrintNoNumberonChapter1 = .PrintNoNumberonChapter1
        '    PrintTitleLoc = .PrintTitleLoc
        PrintMetaFont = My.Settings.PrintMetaFont

        'End With
        LoadStyles()
    End Sub
    Private Sub LoadStyles()
        Try
            Dim stPath As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\styles.dat"
            If IO.File.Exists(stPath) = False Then
                IO.File.Create(stPath).Close()
            End If
            Dim sr As New StreamReader(stPath)
            AllStyles.Clear()
            Dim lines() As String = sr.ReadToEnd.Split(vbLf)
            sr.Close()
            sr.Dispose()
            Dim sSet As StyleSet

            Dim curSet As String
            For Each line As String In lines
                line = line.Trim
                If line.Length = 0 Then Continue For
                If line.Substring(0, 1) = "#" Then Continue For
                If line.Substring(0, 1) = "[" And line.Substring(line.Length - 1, 1) = "]" Then
                    curSet = line.Trim(New Char() {"[", "]"})
                    If Not sSet Is Nothing Then
                        AllStyles.Add(sSet.Name, sSet)
                    End If
                    sSet = New StyleSet()
                    sSet.Name = curSet
                    Continue For
                Else
                    Dim s As New Style()
                    Dim eles() As String = line.Split(";")
                    s.Name = eles(0)
                    s.FName = eles(1)
                    s.FSize = CSng(eles(2))
                    s.FStyle = CInt(eles(3))
                    s.FColor = Color.FromArgb(CInt(eles(4)))
                    s.ApplyBackColor = CBool(eles(5))
                    s.BColor = Color.FromArgb(CInt(eles(6)))
                    If Not sSet Is Nothing Then
                        sSet.Styles.Add(s.Name, s)
                    End If
                End If
            Next
            If Not sSet Is Nothing Then
                AllStyles.Add(sSet.Name, sSet)
            End If
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Sub SaveStyles()
        Try
            Dim stPath As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\styles.dat"
            Dim sw As New StreamWriter(stPath)
            For Each sSet As StyleSet In AllStyles.Values
                sSet.WriteStyleset(sw)
            Next
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public Sub DE(ex As Exception)
        MsgBox(ex.Message, MsgBoxStyle.Critical)
    End Sub
    Friend Sub AddDefaultStyle()

        Dim h1Font As New Font("Arial", 32, FontStyle.Bold)
        Dim h2Font As New Font("Arial", 24, FontStyle.Bold)
        Dim h3Font As New Font("Arial", 20, FontStyle.Bold)
        Dim h4Font As New Font("Arial", 16, FontStyle.Bold)
        Dim h5Font As New Font("Arial", 12, FontStyle.Bold)
        Dim codFont As New Font("Lucida Console", 10, FontStyle.Regular)
        Dim norFont As New Font("Arial", 10, FontStyle.Regular)
        addStyles(h1Font, h2Font, h3Font, h4Font, h5Font, codFont, norFont, "Default")
        h1Font = New Font("Times New Roman", 32, FontStyle.Bold)
        h2Font = New Font("Times New Roman", 24, FontStyle.Bold)
        h3Font = New Font("Times New Roman", 20, FontStyle.Bold)
        h4Font = New Font("Arial", 16, FontStyle.Bold)
        h5Font = New Font("Arial", 12, FontStyle.Bold)
        codFont = New Font("Courier New", 10, FontStyle.Regular)
        norFont = New Font("Times New Roman", 10, FontStyle.Regular)
        addStyles(h1Font, h2Font, h3Font, h4Font, h5Font, codFont, norFont, "Times")
        h1Font = New Font("Algerian", 32, FontStyle.Bold)
        h2Font = New Font("Arial Black", 24, FontStyle.Regular)
        h3Font = New Font("Arial Black", 20, FontStyle.Regular)
        h4Font = New Font("Arial", 16, FontStyle.Bold)
        h5Font = New Font("Arial", 12, FontStyle.Bold)
        codFont = New Font("Lucida Console", 10, FontStyle.Regular)
        norFont = New Font("Calibiri", 10, FontStyle.Regular)
        addStyles(h1Font, h2Font, h3Font, h4Font, h5Font, codFont, norFont, "AlCal")
        h1Font = New Font("Algerian", 32, FontStyle.Bold)
        h2Font = New Font("Algerian", 24, FontStyle.Regular)
        h3Font = New Font("Arial Black", 20, FontStyle.Regular)
        h4Font = New Font("Impact", 16, FontStyle.Bold)
        h5Font = New Font("Impact", 12, FontStyle.Italic)
        codFont = New Font("Courier New", 10, FontStyle.Regular)
        norFont = New Font("Bookman Old Style", 10, FontStyle.Regular)
        addStyles(h1Font, h2Font, h3Font, h4Font, h5Font, codFont, norFont, "AlBookman")
        h1Font = New Font("Script MT Bold", 32, FontStyle.Bold)
        h2Font = New Font("Script MT Bold", 24, FontStyle.Regular)
        h3Font = New Font("Script MT Bold", 20, FontStyle.Regular)
        h4Font = New Font("Script MT Bold", 16, FontStyle.Bold)
        h5Font = New Font("Script MT Bold", 12, FontStyle.Italic)
        codFont = New Font("Courier New", 10, FontStyle.Regular)
        norFont = New Font("Lucida Calligraphy", 10, FontStyle.Regular)
        addStyles(h1Font, h2Font, h3Font, h4Font, h5Font, codFont, norFont, "ScripLu")
    End Sub
    Private Sub addStyles(h1Font, h2Font, h3Font, h4Font, h5Font, codFont, norFont, styleSetName)
        Dim h1, h2, h3, h4, h5, cod, nor As New Style
        With h1Font
            h1.Name = "H1"
            h1.FName = .Name
            h1.FSize = .Size
            h1.FColor = Color.Black
            h1.FStyle = .Style
        End With
        With h2Font
            h2.Name = "H2"
            h2.FName = .Name
            h2.FSize = .Size
            h2.FColor = Color.Black
            h2.FStyle = .Style
        End With
        With h3Font
            h3.Name = "H3"
            h3.FName = .Name
            h3.FSize = .Size
            h3.FColor = Color.Black
            h3.FStyle = .Style
        End With
        With h4Font
            h4.Name = "H4"
            h4.FName = .Name
            h4.FSize = .Size
            h4.FColor = Color.Black
            h4.FStyle = .Style
        End With
        With h5Font
            h5.Name = "H5"
            h5.FName = .Name
            h5.FSize = .Size
            h5.FColor = Color.Black
            h5.FStyle = .Style
        End With
        With codFont
            cod.Name = "<int>"
            cod.FName = .Name
            cod.FSize = .Size
            cod.FColor = Color.Black
            cod.FStyle = .Style
        End With
        With norFont
            nor.Name = "N"
            nor.FName = .Name
            nor.FSize = .Size
            nor.FColor = Color.Black
            nor.FStyle = .Style
        End With
        Dim defStyleset As New StyleSet()
        defStyleset.Name = styleSetName
        defStyleset.Styles.Add(h1.Name, h1)
        defStyleset.Styles.Add(h2.Name, h2)
        defStyleset.Styles.Add(h3.Name, h3)
        defStyleset.Styles.Add(h4.Name, h4)
        defStyleset.Styles.Add(h5.Name, h5)
        defStyleset.Styles.Add(cod.Name, cod)
        defStyleset.Styles.Add(nor.Name, nor)
        SystemStyles.Add(styleSetName, defStyleset)
    End Sub
End Module

