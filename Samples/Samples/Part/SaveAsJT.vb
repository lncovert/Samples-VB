﻿Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Part
    ''' <summary>
    ''' Saves the active part as a JT file.
    ''' </summary>
    Friend Class SaveAsJT
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim document As SolidEdgePart.PartDocument = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Get a reference to the active document.
                document = application.GetActiveDocument(Of SolidEdgePart.PartDocument)(False)

                If document IsNot Nothing Then
                    SolidEdgeDocumentHelper.SaveAsJT(document)
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
