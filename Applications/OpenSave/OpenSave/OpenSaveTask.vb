Imports log4net
Imports SolidEdgeCommunity
Imports SolidEdgeCommunity.Extensions
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace SolidEdge.OpenSave
    Public Class OpenSaveTask
        Inherits IsolatedTaskProxy

        Private Shared _log As ILog = LogManager.GetLogger(GetType(OpenSaveTask))

        Public Sub DoOpenSave(ByVal filePath As String, ByVal openSaveSettings As OpenSaveSettings)
            InvokeSTAThread(Of String, OpenSaveSettings)(AddressOf DoOpenSaveInternal, filePath, openSaveSettings)
        End Sub

        Private Sub DoOpenSaveInternal(ByVal filePath As String, ByVal openSaveSettings As OpenSaveSettings)
            ' Register with OLE to handle concurrency issues on the current thread.
            SolidEdgeCommunity.OleMessageFilter.Register()

            Try
                Dim application As SolidEdgeFramework.Application = SolidEdgeCommunity.SolidEdgeUtils.Connect(True)
                Dim documents As SolidEdgeFramework.Documents = Nothing
                Dim document As SolidEdgeFramework.SolidEdgeDocument = Nothing

                application.DisplayAlerts = openSaveSettings.Application.DisplayAlerts
                application.Visible = openSaveSettings.Application.Visible

                If openSaveSettings.Application.DisableAddins = True Then
                    DisableAddins(application)
                End If

                ' Disable (most) prompts.
                application.DisplayAlerts = False

                ' Get a reference to the documents collection.
                documents = application.Documents

                ' Close any documents that may be left open for whatever reason.
                documents.Close()

                ' Open the file.
                document = documents.Open(Of SolidEdgeFramework.SolidEdgeDocument)(filePath)

                application.DoIdle()

                If document IsNot Nothing Then
                    ' Environment specific routines.
                    If TypeOf document Is SolidEdgeAssembly.AssemblyDocument Then
                        DoOpenSave(DirectCast(document, SolidEdgeAssembly.AssemblyDocument), openSaveSettings.Assembly)
                    ElseIf TypeOf document Is SolidEdgeDraft.DraftDocument Then
                        DoOpenSave(DirectCast(document, SolidEdgeDraft.DraftDocument), openSaveSettings.Draft)
                    ElseIf TypeOf document Is SolidEdgePart.PartDocument Then
                        DoOpenSave(DirectCast(document, SolidEdgePart.PartDocument), openSaveSettings.Part)
                    ElseIf TypeOf document Is SolidEdgePart.SheetMetalDocument Then
                        DoOpenSave(DirectCast(document, SolidEdgePart.SheetMetalDocument), openSaveSettings.SheetMetal)
                    ElseIf TypeOf document Is SolidEdgePart.WeldmentDocument Then
                        DoOpenSave(DirectCast(document, SolidEdgePart.WeldmentDocument), openSaveSettings.Weldment)
                    End If

                    ' Save document.
                    document.Save()

                    ' Close document.
                    document.Close()

                    application.DoIdle()
                End If
            Finally
                SolidEdgeCommunity.OleMessageFilter.Unregister()
            End Try
        End Sub

        Private Sub DoOpenSave(ByVal assemblyDocument As SolidEdgeAssembly.AssemblyDocument, ByVal assemblySettings As AssemblySettings)
        End Sub

        Private Sub DoOpenSave(ByVal draftDocument As SolidEdgeDraft.DraftDocument, ByVal draftSettings As DraftSettings)
            Dim sections As SolidEdgeDraft.Sections = Nothing
            Dim section As SolidEdgeDraft.Section = Nothing
            Dim sectionSheets As SolidEdgeDraft.SectionSheets = Nothing
            Dim sheet As SolidEdgeDraft.Sheet = Nothing
            Dim drawingViews As SolidEdgeDraft.DrawingViews = Nothing
            Dim drawingView As SolidEdgeDraft.DrawingView = Nothing

            If draftSettings.UpdateDrawingViews Then
                sections = draftDocument.Sections
                section = sections.WorkingSection

                sectionSheets = section.Sheets

                For i As Integer = 1 To sectionSheets.Count
                    sheet = sectionSheets.Item(i)
                    drawingViews = sheet.DrawingViews

                    For j As Integer = 1 To drawingViews.Count
                        drawingView = drawingViews.Item(j)
                        drawingView.Update()
                    Next j
                Next i
            End If
        End Sub

        Private Sub DoOpenSave(ByVal partDocument As SolidEdgePart.PartDocument, ByVal partSettings As PartSettings)
        End Sub

        Private Sub DoOpenSave(ByVal sheetMetalDocument As SolidEdgePart.SheetMetalDocument, ByVal sheetMetalSettings As SheetMetalSettings)
        End Sub

        Private Sub DoOpenSave(ByVal weldmentDocument As SolidEdgePart.WeldmentDocument, ByVal weldmentSettings As WeldmentSettings)
        End Sub

        Private Sub DisableAddins(ByVal application As SolidEdgeFramework.Application)
            Dim addins As SolidEdgeFramework.AddIns = Nothing
            Dim addin As SolidEdgeFramework.AddIn = Nothing

            addins = application.AddIns

            For i As Integer = 1 To addins.Count
                addin = addins.Item(i)
                addin.Connect = False
            Next i
        End Sub
    End Class
End Namespace
