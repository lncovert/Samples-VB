Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Reflection
Imports System.Text

Namespace Samples
    Public Class Program
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            AppDomain.CurrentDomain.SetData("BreakOnStart", True)

            Dim type = GetType(Samples.Application.StartSolidEdge)
            Dim method = type.GetMethod("Main", BindingFlags.Static Or BindingFlags.NonPublic)

            Dim methodArgs As New List(Of Object)()
            methodArgs.Add(New String(){})

            method.Invoke(Nothing, methodArgs.ToArray())
        End Sub
    End Class
End Namespace
