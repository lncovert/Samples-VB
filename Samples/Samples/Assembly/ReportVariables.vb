﻿Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Assembly
    ''' <summary>
    ''' Reports the variables of the active assembly.
    ''' </summary>
    Friend Class ReportVariables
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim document As SolidEdgeAssembly.AssemblyDocument = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Start()

                ' Get a reference to the active document.
                document = application.GetActiveDocument(Of SolidEdgeAssembly.AssemblyDocument)(False)

                ' Make sure we have a document.
                If document IsNot Nothing Then
                    VariablesHelper.ReportVariables(document)
                Else
                    Throw New System.Exception(Resources.NoActiveAssemblyDocument)
                End If
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
