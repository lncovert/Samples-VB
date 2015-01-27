Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace Samples.Assembly
    ''' <summary>
    ''' Reports the BOM of the active assembly.
    ''' </summary>
    Friend Class ReportBOM
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim assemblyDocument As SolidEdgeAssembly.AssemblyDocument = Nothing
            Dim occurrences As SolidEdgeAssembly.Occurrences = Nothing

            ' Dictionary to hold BomItem(s).  Key is the full path to the SolidEdgeDocument.
            Dim bomItems As New Dictionary(Of String, BomItem)()

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True, True)

                ' Get the active document.
                assemblyDocument = application.GetActiveDocument(Of SolidEdgeAssembly.AssemblyDocument)(False)

                If assemblyDocument IsNot Nothing Then
                    ' Start walking the assembly tree.
                    ProcessAssembly(0, assemblyDocument, bomItems)

                    For Each bomItem As BomItem In bomItems.Values.ToArray()
                        Console.WriteLine("Level: {0}", bomItem.Level)
                        Console.WriteLine("DocumentNumber: {0}", bomItem.DocumentNumber)
                        Console.WriteLine("Revision: {0}", bomItem.Revision)
                        Console.WriteLine("Title: {0}", bomItem.Title)
                        Console.WriteLine("Quantity: {0}", bomItem.Quantity)
                        Console.WriteLine("FileName: {0}", bomItem.FileName)
                        Console.WriteLine()
                    Next bomItem
                Else
                    Throw New System.Exception(Resources.NoActiveAssemblyDocument)
                End If
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub

        Private Shared Sub ProcessAssembly(ByVal level As Integer, ByVal assemblyDocument As SolidEdgeAssembly.AssemblyDocument, ByVal bomItems As Dictionary(Of String, BomItem))
            ' Increment level (depth).
            level += 1

            ' Loop through the Occurrences.
            For Each occurrence As SolidEdgeAssembly.Occurrence In assemblyDocument.Occurrences
                ' Filter out certain occurrences.
                If Not occurrence.IncludeInBom Then
                    Continue For
                End If
                If occurrence.IsPatternItem Then
                    Continue For
                End If
                If occurrence.OccurrenceDocument Is Nothing Then
                    Continue For
                End If

                ' Get a reference to the SolidEdgeDocument.
                Dim document As SolidEdgeFramework.SolidEdgeDocument = CType(occurrence.OccurrenceDocument, SolidEdgeFramework.SolidEdgeDocument)

                ' Add the BomItem.
                AddBomItem(level, document, bomItems)

                If occurrence.Subassembly Then
                    ' Sub Assembly. Recurisve call to drill down.
                    ProcessAssembly(level, CType(occurrence.OccurrenceDocument, SolidEdgeAssembly.AssemblyDocument), bomItems)
                End If
            Next occurrence
        End Sub

        Private Shared Sub AddBomItem(ByVal level As Integer, ByVal document As SolidEdgeFramework.SolidEdgeDocument, ByVal bomItems As Dictionary(Of String, BomItem))
            Dim bomItem As New BomItem(document.FullName)
            Dim summaryInfo As SolidEdgeFramework.SummaryInfo = Nothing

            If Not bomItems.ContainsKey(document.FullName) Then
                summaryInfo = CType(document.SummaryInfo, SolidEdgeFramework.SummaryInfo)
                bomItem.Level = level
                bomItem.DocumentNumber = summaryInfo.DocumentNumber
                bomItem.Title = summaryInfo.Title
                bomItem.Revision = summaryInfo.RevisionNumber
                bomItem.IsSubassembly = document.Type = SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument
                bomItems.Add(bomItem.FullName, bomItem)
            Else
                bomItems(bomItem.FullName).Quantity += 1
            End If
        End Sub
    End Class

    ''' <summary>
    ''' Class to hold BOM item information.
    ''' </summary>
    Public Class BomItem
        Public Sub New(ByVal fullName As String)
            Me.FullName = fullName
            FileName = System.IO.Path.GetFileName(fullName)
            Quantity = 1
        End Sub

        Public Property Level() As Integer
        Public Property DocumentNumber() As String
        Public Property Revision() As String
        Public Property Title() As String
        Public Property Quantity() As Integer
        Public Property FullName() As String
        Public Property FileName() As String
        Public Property IsSubassembly() As Boolean
    End Class
End Namespace