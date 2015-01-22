Imports SolidEdgeCommunity
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Text

Namespace Samples.GUI
    Public Class SampleTask
        Inherits IsolatedTaskProxy

        Public Sub InvokeSample(ByVal method As MethodInfo, ByVal breakOnStart As Boolean, ByVal consoleOut As TextWriter)
            If breakOnStart Then
                AppDomain.CurrentDomain.SetData("BreakOnStart", True)
            End If

            If consoleOut IsNot Nothing Then
                Console.SetOut(consoleOut)
            End If

            InvokeSTAThread(Of MethodInfo)(AddressOf InvokeSampleInternal, method)
        End Sub

        Private Sub InvokeSampleInternal(ByVal method As MethodInfo)
            Dim methodArgs As New List(Of Object)()
            methodArgs.Add(New String(){})

            method.Invoke(Nothing, methodArgs.ToArray())
        End Sub
    End Class
End Namespace
