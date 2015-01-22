﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Application
    ''' <summary>
    ''' Creates a new draft document.
    ''' </summary>
    Friend Class CreateDraftDocument
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim documents As SolidEdgeFramework.Documents = Nothing
            Dim draftDocument As SolidEdgeDraft.DraftDocument = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Get a reference to the documents collection.
                documents = application.Documents

                ' Create a new draft document.
                draftDocument = DirectCast(documents.Add(SolidEdgeSDK.PROGID.SolidEdge_DraftDocument), SolidEdgeDraft.DraftDocument)
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
