Imports SolidEdgeCommunity
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace BOM
    Partial Public Class MainForm
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            imlListView.Images.Add(My.Resources.SubAssembly_16x16)
            imlListView.Images.Add(My.Resources.SubPart_16x16)
        End Sub

        Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
            Close()
        End Sub

        Private Sub copyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles copyToolStripMenuItem.Click
            Clipboard.Clear()
            Dim buffer As New StringBuilder()

            ' Column Headers
            For i As Integer = 0 To lvBOM.Columns.Count - 1
                buffer.Append(lvBOM.Columns(i).Text)
                buffer.Append(ControlChars.Tab)
            Next i

            buffer.Append(Environment.NewLine)

            ' Rows
            For i As Integer = 0 To lvBOM.Items.Count - 1
                If lvBOM.Items(i).Selected Then
                    For j As Integer = 0 To lvBOM.Columns.Count - 1
                        buffer.Append(lvBOM.Items(i).SubItems(j).Text)
                        buffer.Append(ControlChars.Tab)
                    Next j
                    buffer.Append(Environment.NewLine)
                End If
            Next i

            Clipboard.SetText(buffer.ToString())
        End Sub

        Private Sub selectAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles selectAllToolStripMenuItem.Click
            lvBOM.BeginUpdate()

            For Each item As ListViewItem In lvBOM.Items
                item.Selected = True
            Next item

            lvBOM.EndUpdate()
        End Sub

        Private Sub refreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles refreshToolStripMenuItem.Click
            RefreshListView()
        End Sub

        Private Sub buttonRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonRefresh.Click
            RefreshListView()
        End Sub

        Private Sub RefreshListView()
            Dim bomItems() As BomItem = { }

            Try
                Using task = New IsolatedTask(Of ExtractBomTask)()
                    bomItems = task.Proxy.GetBomItems()
                End Using

                Dim listViewItems As New List(Of ListViewItem)()

                For Each bomItem As BomItem In bomItems
                    Dim listViewItem As New ListViewItem(String.Format("{0}", bomItem.Level))
                    listViewItem.SubItems.Add(bomItem.DocumentNumber)
                    listViewItem.SubItems.Add(bomItem.Revision)
                    listViewItem.SubItems.Add(bomItem.Title)
                    listViewItem.SubItems.Add(String.Format("{0}", bomItem.Quantity))
                    listViewItem.SubItems.Add(bomItem.FileName)
                    listViewItem.ImageIndex = If(bomItem.IsSubassembly, 0, 1)
                    listViewItems.Add(listViewItem)
                Next bomItem

                lvBOM.Items.Clear()
                lvBOM.Items.AddRange(listViewItems.ToArray())
                lvBOM.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            Catch ex As System.Exception
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
