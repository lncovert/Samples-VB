﻿Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.SheetMetal
    ''' <summary>
    ''' 
    ''' </summary>
    Friend Class ReportFileProperties
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Get a reference to the active assembly document.
                Dim document = application.GetActiveDocument(Of SolidEdgePart.SheetMetalDocument)(False)

                If document IsNot Nothing Then
                    Dim propertySets = DirectCast(document.Properties, SolidEdgeFramework.PropertySets)

                    Samples.Common.FileProperties.ReportAllProperties(propertySets)
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
