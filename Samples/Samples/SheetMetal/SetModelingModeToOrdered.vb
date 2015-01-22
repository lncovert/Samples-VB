﻿Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.SheetMetal
    ''' <summary>
    ''' Sets the ModelingMode of the active sheetmetal to ordered.
    ''' </summary>
    Friend Class SetModelingModeToOrdered
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim sheetMetalDocument As SolidEdgePart.SheetMetalDocument = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Bring Solid Edge to the foreground.
                application.Activate()

                ' Get a reference to the active sheetmetal document.
                sheetMetalDocument = application.GetActiveDocument(Of SolidEdgePart.SheetMetalDocument)(False)

                If sheetMetalDocument IsNot Nothing Then
                    sheetMetalDocument.ModelingMode = SolidEdgePart.ModelingModeConstants.seModelingModeOrdered
                Else
                    Throw New System.Exception(Resources.NoActiveSheetMetalDocument)
                End If
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
