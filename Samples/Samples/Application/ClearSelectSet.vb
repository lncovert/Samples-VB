Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Application
    ''' <summary>
    ''' Clears the application active select set.
    ''' </summary>
    Friend Class ClearSelectSet
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim selectSet As SolidEdgeFramework.SelectSet = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Start()

                ' Get a reference to the active select set.
                selectSet = application.ActiveSelectSet

                ' Clear the SelectSet.
                selectSet.RemoveAll()
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
