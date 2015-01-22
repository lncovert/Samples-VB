Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace BOM
    <Serializable> _
    Public Class BomItem
        Public Sub New(ByVal fullName As String)
            Me.FullName = fullName
            FileName = System.IO.Path.GetFileName(fullName)
            Quantity = 1
        End Sub

        Public Property Level() As Integer
        Public Property DocumentNumber() As String
        Public Property Revision() As String
        Public Property Title() As String
        Public Property Quantity() As Integer
        Public Property FullName() As String
        Public Property FileName() As String
        Public Property IsSubassembly() As Boolean
    End Class
End Namespace
