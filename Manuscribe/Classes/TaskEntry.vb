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

Friend Class TaskEntry
    Private _onDate As String
    Private _wordCount As Integer
    Private _events As New SortedList(Of String, TaskTypes)
    Public ReadOnly Property Tasks As SortedList(Of String, TaskTypes)
        Get
            Return _events
        End Get

    End Property
    Public Property OnDate As String
        Get
            Return _onDate
        End Get
        Set(value As String)
            _onDate = value
        End Set
    End Property
    Public Property WordCount As Integer
        Get
            Return _wordCount
        End Get
        Set(value As Integer)
            _wordCount = value
        End Set
    End Property
    Public Function WriteTask(sw As StreamWriter) As Boolean
        Try
            Dim finString As String = "<on date=""" & OnDate & """ wordcount=""" & WordCount & """>" & vbCrLf
            For Each k As String In Tasks.Keys
                finString += "<task at=""" & k & """ type=""" & Tasks(k) & """>" & [Enum].Parse(GetType(TaskTypes), Tasks(k)).ToString & "</task>" & vbCrLf
            Next
            finString += "</on>" & vbCrLf
            sw.Write(finString)
            Return True
        Catch ex As Exception
            DE(ex)
            Return False
        End Try
    End Function

End Class
