Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Application
    ''' <summary>
    ''' Closes all open documents.
    ''' </summary>
    Friend Class CloseAllDocuments
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim documents As SolidEdgeFramework.Documents = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(False)

                If application IsNot Nothing Then
                    ' Get a reference to the documents collection.
                    documents = application.Documents

                    ' Close all documents.
                    documents.Close()
                End If
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
