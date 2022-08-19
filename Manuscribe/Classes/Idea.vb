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
Public Class Idea
    Private _id As String
    Private _content As String = ""
    Private _savedon As String
    Private _category As String
    Public Property Category As String
        Get
            Return _category
        End Get
        Set(value As String)
            _category = value
        End Set
    End Property
    Public Property ID As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property
    Public Property Content As String
        Get
            Return _content
        End Get
        Set(value As String)
            _content = value
        End Set
    End Property
    Public Property SavedON As String
        Get
            Return _savedon
        End Get
        Set(value As String)
            _savedon = value
        End Set
    End Property
    Public Sub WriteXML(sw As IO.StreamWriter)
        Try
            Me._savedon = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
            Dim finString = "<idea savedon=""" & SavedON & """ id=""" & ID & """ category=""" & Category & """>" & Content & "</idea>" & vbCrLf
            sw.Write(finString)

        Catch ex As Exception
            DE(ex)
        End Try
    End Sub
    Public ReadOnly Property Title As String
        Get
            If String.IsNullOrEmpty(Content) Then
                Return "Empty"
            End If
            If Content.Trim.Length < 10 Then
                Dim finString As String = Content.Trim
                Return finString
            Else
                Return Content.Trim.Substring(0, 10) & " ..."
            End If
        End Get
    End Property
End Class
