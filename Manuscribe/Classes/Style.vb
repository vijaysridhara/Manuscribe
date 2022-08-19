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

Public Class Style
    Private _fname As String = "Arial"
    Private _fsize As Single = 10.0F
    Private _fstyle As FontStyle = FontStyle.Regular
    Private _fColor As Color = Color.Black
    Private _bColor As Color = Color.Transparent
    Private _applyBackColor As Boolean
    Private _name As String
    Public Property ApplyBackColor As Boolean
        Get
            Return _applyBackColor
        End Get
        Set(value As Boolean)
            _applyBackColor = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Public Property FName As String
        Get
            Return _fname
        End Get
        Set(value As String)
            _fname = value
        End Set
    End Property
    Public Property FSize As Single
        Get
            Return _fsize
        End Get
        Set(value As Single)
            _fsize = value
        End Set
    End Property
    Public Property FStyle As FontStyle
        Get
            Return _fstyle
        End Get
        Set(value As FontStyle)
            _fstyle = value
        End Set
    End Property
    Public Property FColor As Color
        Get
            Return _fColor
        End Get
        Set(value As Color)
            _fColor = value
        End Set
    End Property
    Public Property BColor As Color
        Get
            Return _bColor
        End Get
        Set(value As Color)
            _bColor = value
        End Set
    End Property
    Public Function writeStyle(sw As StreamWriter) As Boolean
        Try
            Dim finSTring As String
            finSTring = Name & ";" & FName & ";" & FSize & ";" & FStyle & ";" & FColor.ToArgb & ";" & ApplyBackColor & ";" & BColor.ToArgb
            sw.WriteLine(finSTring)
            Return True
        Catch ex As Exception
            DE(ex)
            Return False
        End Try
    End Function
End Class
