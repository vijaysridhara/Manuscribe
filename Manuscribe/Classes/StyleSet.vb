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

Public Class StyleSet
    Private _name As String
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Private _styles As New Dictionary(Of String, Style)
    Public ReadOnly Property Styles As Dictionary(Of String, Style)
        Get
            Return _styles
        End Get
    End Property
    Public Function WriteStyleset(sw As StreamWriter) As Boolean
        Try
            sw.WriteLine("[" & Name & "]")
            For Each s As Style In Styles.Values
                s.writeStyle(sw)
            Next
            Return True
        Catch ex As Exception
            DE(ex)
            Return False
        End Try
    End Function

End Class
