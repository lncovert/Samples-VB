Imports SolidEdgeCommunity.Extensions ' Enabled extension methods from SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text

Namespace Samples.Draft
    ''' <summary>
    ''' Copies the 1st parts list of the active draft to the clipboard and pastes it into Excel.
    ''' </summary>
    Friend Class CopyPartsListsToClipboardAndPasteIntoExcel
        <STAThread> _
        Shared Sub Main(ByVal args() As String)
            If StartupHelper.ShouldBreak() Then
                System.Diagnostics.Debugger.Break()
            End If

            Dim application As SolidEdgeFramework.Application = Nothing
            Dim draftDocument As SolidEdgeDraft.DraftDocument = Nothing
            Dim partsLists As SolidEdgeDraft.PartsLists = Nothing
            Dim partsList As SolidEdgeDraft.PartsList = Nothing
'INSTANT VB NOTE: In the following line, Instant VB substituted 'Object' for 'dynamic' - this will work in VB with Option Strict Off:
            Dim excelApplication As Object = Nothing
'INSTANT VB NOTE: In the following line, Instant VB substituted 'Object' for 'dynamic' - this will work in VB with Option Strict Off:
            Dim excelWorkbooks As Object = Nothing
'INSTANT VB NOTE: In the following line, Instant VB substituted 'Object' for 'dynamic' - this will work in VB with Option Strict Off:
            Dim excelWorkbook As Object = Nothing
'INSTANT VB NOTE: In the following line, Instant VB substituted 'Object' for 'dynamic' - this will work in VB with Option Strict Off:
            Dim excelWorksheet As Object = Nothing

            Try
                ' Register with OLE to handle concurrency issues on the current thread.
                SolidEdgeCommunity.OleMessageFilter.Register()

                ' Connect to or start Solid Edge.
                application = SolidEdgeCommunity.SolidEdgeUtils.Connect(False)

                ' Get a reference to the active draft document.
                draftDocument = application.GetActiveDocument(Of SolidEdgeDraft.DraftDocument)(False)

                If draftDocument IsNot Nothing Then
                    ' Get a reference to the PartsLists collection.
                    partsLists = draftDocument.PartsLists

                    If partsLists.Count > 0 Then
                        ' Get a reference to the 1st parts list.
                        partsList = partsLists.Item(1)

                        ' Copy parts list to clipboard.
                        partsList.CopyToClipboard()

                        Try
                            excelApplication = Marshal.GetActiveObject("Excel.Application")
                        Catch
                            excelApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"))
                        End Try

                        If excelApplication IsNot Nothing Then
                            excelApplication.Visible = True
                            excelWorkbooks = excelApplication.Workbooks
                            excelWorkbook = excelWorkbooks.Add()
                            excelWorksheet = excelWorkbook.ActiveSheet
                            excelWorksheet.Paste()
                        End If
                    Else
                        Throw New System.Exception(Resources.NoPartsListsInDraftDocument)
                    End If
                Else
                    Throw New System.Exception(Resources.NoActiveDraftDocument)
                End If
            Catch ex As System.Exception
                Console.WriteLine(ex.Message)
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub
    End Class
End Namespace
