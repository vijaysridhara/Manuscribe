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
<Serializable>
Public Class RecentBook
    Private _modTime As String

    Private _name As String
    Private _cover As Image
    Private _path As String
    Public Sub New()
        _cover = My.Resources.bookcover.Clone
    End Sub
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Public Property Cover As Image
        Get
            Return _cover
        End Get
        Set(value As Image)
            _cover = value
        End Set
    End Property
    Public Property Path As String
        Get
            Return _path
        End Get
        Set(value As String)
            _path = value
        End Set
    End Property
    Public Property ModTime As String
        Get
            Return _modTime
        End Get
        Set(value As String)
            _modTime = value
        End Set
    End Property
End Class
