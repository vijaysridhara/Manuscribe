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
Public Class PageTemplate
    Private _name As String = "A4"
    Private _size As Size = New Size(830, 1170) 'inhundreths of inch
    'Private _size As Size = New Size(587, 823) 'inhundreths of inch
    Private _margins As Printing.Margins = New Printing.Margins(30, 30, 30, 30)
    Private _landscape As Boolean

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Public Property Size As Size
        Get
            Return _size
        End Get
        Set(value As Size)
            _size = value
        End Set
    End Property
    Public Property Margins As Printing.Margins
        Get
            Return _margins
        End Get
        Set(value As Printing.Margins)
            _margins = value
            Dim x As New Printing.Margins()
        End Set
    End Property
    Public Property Landscape As Boolean
        Get
            Return _landscape
        End Get
        Set(value As Boolean)
            _landscape = value
        End Set
    End Property
    Public Sub New(name As String, width As Single, height As Single, left As Single, right As Single, top As Single, bottom As Single)
        Me.Name = name
        Me.Size = New Size(width * 100, height * 100)
        Me.Margins = New Printing.Margins(left * 100, right * 100, top * 100, bottom * 100)

    End Sub
    Public Sub New()

    End Sub
    Public Function Clone() As PageTemplate
        Dim pg As New PageTemplate
        pg.Name = Me.Name
        pg.Size = Me.Size
        pg.Margins = Me.Margins
        Return pg
    End Function
End Class
