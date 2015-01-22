﻿Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Assembly
    ''' <summary>
    ''' Creates a new assembly and adds an occurrence by filename.
    ''' </summary>
    Friend Class AddOccurrenceByFilename
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim documents As SolidEdgeFramework.Documents = Nothing
            Dim assemblyDocument As SolidEdgeAssembly.AssemblyDocument = Nothing
            Dim occurrences As SolidEdgeAssembly.Occurrences = Nothing
            Dim occurrence As SolidEdgeAssembly.Occurrence = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Get a reference to the documents collection.
                documents = application.Documents

                ' Create a new assembly document.
                assemblyDocument = documents.AddAssemblyDocument()

                ' Always a good idea to give SE a chance to breathe.
                application.DoIdle()

                ' Get a reference to the Occurrences collection.
                occurrences = assemblyDocument.Occurrences

                ' Build path to file.
                Dim filename As String = System.IO.Path.Combine(SolidEdgeCommunity.SolidEdgeUtils.GetTrainingFolderPath(), "Coffee Pot.par")

                ' Add the base feature at 0 (X), 0 (Y), 0 (Z).
                occurrence = occurrences.AddByFilename(filename)

                ' Switch to ISO view.
                application.StartCommand(SolidEdgeConstants.AssemblyCommandConstants.AssemblyViewISOView)
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
