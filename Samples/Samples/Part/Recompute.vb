﻿Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Part
    ''' <summary>
    ''' Recomputes the active part.
    ''' </summary>
    Friend Class Recompute
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim partDocument As SolidEdgePart.PartDocument = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Bring Solid Edge to the foreground.
                application.Activate()

                ' Get a reference to the active part document.
                partDocument = application.GetActiveDocument(Of SolidEdgePart.PartDocument)(False)

                If partDocument IsNot Nothing Then
                    partDocument.Recompute()
                Else
                    Throw New System.Exception(Resources.NoActivePartDocument)
                End If
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
