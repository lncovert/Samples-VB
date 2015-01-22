﻿Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Assembly
    ''' <summary>
    ''' Reports all configurations of the active assembly.
    ''' </summary>
    Friend Class ReportConfigurations
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim assemblyDocument As SolidEdgeAssembly.AssemblyDocument = Nothing
            Dim configurations As SolidEdgeAssembly.Configurations = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Get a reference to active assembly document.
                assemblyDocument = application.GetActiveDocument(Of SolidEdgeAssembly.AssemblyDocument)(False)

                If assemblyDocument IsNot Nothing Then
                    ' Get a reference tot he Configurations collection.
                    configurations = assemblyDocument.Configurations

                    ' Iterate through all of the configurations.
                    For Each configuration As SolidEdgeAssembly.Configuration In configurations.OfType(Of SolidEdgeAssembly.Configuration)()
                        Console.WriteLine("Configuration Name: '{0}' | Configuration Type: {1}.", configuration.Name, configuration.ConfigurationType)
                    Next configuration
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
