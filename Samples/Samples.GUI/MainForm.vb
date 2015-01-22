Imports ClariusLabs.NuDoc
Imports SolidEdgeCommunity
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Reflection
Imports System.Text
Imports System.Windows.Forms

Namespace Samples.GUI
    Partial Public Class MainForm
        Inherits Form

        Private _samplesList As New List(Of MethodInfo)()
        Private _textBoxConsole As TextBoxConsole
        Private _assemblyMembers As AssemblyMembers
        Private _samplesAssembly As System.Reflection.Assembly

        Public Sub New()
            Me.Font = SystemFonts.MessageBoxFont
            InitializeComponent()
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Try
                ' Force load of SolidEdge.Samples.dll.
                Dim type = GetType(Samples.Program)
                _samplesAssembly = type.Assembly

                _textBoxConsole = New TextBoxConsole(outputTextBox)
                _assemblyMembers = DocReader.Read(type.Assembly)

                LoadTreeView()
            Catch ex As System.Exception
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub closeAllDocumentsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeAllDocumentsToolStripMenuItem.Click
            Dim type = _samplesAssembly.GetType("Samples.Application.CloseAllDocuments")
            Dim method As MethodInfo = type.GetMethod("Main")

            If method Is Nothing Then
                method = type.GetMethod("Main", BindingFlags.Static Or BindingFlags.NonPublic)
            End If

            Dim arguments() As Object = { method, buttonBreakpoint.Checked }
            backgroundWorker.RunWorkerAsync(arguments)
        End Sub

        Private Sub closeAllDocumentsSilentToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeAllDocumentssilentToolStripMenuItem.Click
            Dim type = _samplesAssembly.GetType("Samples.Application.CloseAllDocumentsSilent")

            Dim method As MethodInfo = type.GetMethod("Main")

            If method Is Nothing Then
                method = type.GetMethod("Main", BindingFlags.Static Or BindingFlags.NonPublic)
            End If

            Dim arguments() As Object = { method, buttonBreakpoint.Checked }
            backgroundWorker.RunWorkerAsync(arguments)
        End Sub

        Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
            Close()
        End Sub

        Private Sub buttonRun_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonRun.Click
            If listView.SelectedItems.Count = 1 Then
                Dim listViewItem As ListViewItem = listView.SelectedItems(0)
                Dim method As MethodInfo = TryCast(listViewItem.Tag, MethodInfo)

                If method IsNot Nothing Then
                    'List<object> parameters = new List<object>();

                    '// Set breakOnStart parameter.
                    'parameters.Add(buttonBreakpoint.Checked);

                    Dim arguments() As Object = { method, buttonBreakpoint.Checked }
                    backgroundWorker.RunWorkerAsync(arguments)
                End If
            End If
        End Sub

        Private Sub buttonBreakpoint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonBreakpoint.Click
            buttonBreakpoint.Checked = Not buttonBreakpoint.Checked
        End Sub

        Private Sub LoadTreeView()
            For Each type As Type In _samplesAssembly.GetTypes()

                Dim methodInfo = type.GetMethod("Main")

                If methodInfo Is Nothing Then
                    methodInfo = type.GetMethod("Main", BindingFlags.Static Or BindingFlags.NonPublic)
                End If

                If methodInfo IsNot Nothing Then
                    _samplesList.Add(methodInfo)
                End If
            Next type

            _samplesList.Sort(Function(x As MethodInfo, y As MethodInfo)
                If x.DeclaringType.Namespace.Equals(y.DeclaringType.Namespace) Then
                    Return (x.DeclaringType.Name.CompareTo(y.DeclaringType.Name))
                Else
                    Return (x.DeclaringType.Namespace.CompareTo(y.DeclaringType.Namespace))
                End If
            End Function)

            Dim defaultNamespace = "SolidEdgeCommunity.Samples"
            Dim groups = _samplesList.GroupBy(Function(x) x.DeclaringType.Namespace)

            For Each group As IGrouping(Of String, MethodInfo) In groups
                Dim keys() As String = group.Key.Replace(defaultNamespace, String.Empty).Split("."c)
                Dim treeNode As TreeNode = Nothing

                For i As Integer = 1 To keys.Length - 1
                    Dim key As String = keys(i).Replace("_", String.Empty)

                    Dim Nodes As TreeNodeCollection

                    If treeNode Is Nothing Then
                        Nodes = treeView.Nodes
                    Else
                        Nodes = treeNode.Nodes
                    End If

                    treeNode = Nodes(key)
                    If treeNode Is Nothing Then
                        treeNode = Nodes.Add(key, key)
                    End If

                Next i

                If treeNode IsNot Nothing Then
                    treeNode.Tag = group.ToArray()
                End If
            Next group
        End Sub

        Private Sub treeView_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles treeView.AfterSelect
            listView.Items.Clear()
            sampleRichTextBox.Clear()

            If e.Node IsNot Nothing Then
                Dim methods() As MethodInfo = TryCast(e.Node.Tag, MethodInfo())

                If methods IsNot Nothing Then
                    For Each method As MethodInfo In methods
                        Dim listViewItem As New ListViewItem(method.DeclaringType.Name)
                        listViewItem.ImageIndex = 2
                        listViewItem.Tag = method
                        listView.Items.Add(listViewItem)
                    Next method
                End If
            End If

            If listView.Items.Count > 0 Then
                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
            Else
                listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        End Sub

        Private Sub listView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listView.SelectedIndexChanged
            sampleRichTextBox.Clear()

            If listView.SelectedItems.Count = 1 Then
                Dim listViewtiem As ListViewItem = listView.SelectedItems(0)
                Dim method As MethodInfo = TryCast(listViewtiem.Tag, MethodInfo)

                If method IsNot Nothing Then
                    sampleRichTextBox.AppendText(method.DeclaringType.FullName, FontStyle.Bold)
                    sampleRichTextBox.AppendText(Environment.NewLine)

                    Dim id As String = _assemblyMembers.IdMap.FindId(method.DeclaringType)
                    Dim elements = _assemblyMembers.Elements.ToArray().OfType(Of ClariusLabs.NuDoc.Class)()
                    Dim classElement = elements.Where(Function(x) x.Id.Equals(id)).FirstOrDefault()

                    If classElement IsNot Nothing Then
                        Dim summary = classElement.Elements.OfType(Of ClariusLabs.NuDoc.Summary)().FirstOrDefault()
                        Dim remarks = classElement.Elements.OfType(Of ClariusLabs.NuDoc.Remarks)().FirstOrDefault()

                        If summary IsNot Nothing Then
                            sampleRichTextBox.AppendText(Environment.NewLine)
                            sampleRichTextBox.AppendText("Summary:", FontStyle.Bold)
                            sampleRichTextBox.AppendText(Environment.NewLine)
                            sampleRichTextBox.AppendText(summary.ToText())
                            sampleRichTextBox.AppendText(Environment.NewLine)
                        End If

                        If remarks IsNot Nothing Then
                            sampleRichTextBox.AppendText(Environment.NewLine)
                            sampleRichTextBox.AppendText("Remarks:", FontStyle.Bold)
                            sampleRichTextBox.AppendText(Environment.NewLine)
                            sampleRichTextBox.AppendText(remarks.ToText())
                            sampleRichTextBox.AppendText(Environment.NewLine)
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub backgroundWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles backgroundWorker.DoWork
            ' Signal start of background worker.
            backgroundWorker.ReportProgress(0)

            ' Unwrap arguments.
            Dim arguments() As Object = DirectCast(e.Argument, Object())
            Dim method As MethodInfo = DirectCast(arguments(0), MethodInfo)
            Dim breakOnStart As Boolean = DirectCast(arguments(1), Boolean)

            _textBoxConsole.WriteLine("Begin '{0}'", method.DeclaringType.Name)
            _textBoxConsole.WriteLine()

            Using task = New IsolatedTask(Of SampleTask)()
                task.Proxy.InvokeSample(method, breakOnStart, _textBoxConsole)
            End Using

            _textBoxConsole.WriteLine()
            _textBoxConsole.WriteLine("End '{0}'", method.DeclaringType.Name)
        End Sub

        Private Sub backgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles backgroundWorker.ProgressChanged
            If e.ProgressPercentage = 0 Then
                fileToolStripMenuItem.Enabled = False
                buttonRun.Enabled = False
                buttonBreakpoint.Enabled = False
                outputTextBox.Clear()
            End If
        End Sub

        Private Sub backgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted
            fileToolStripMenuItem.Enabled = True
            buttonRun.Enabled = True
            buttonBreakpoint.Enabled = True
        End Sub
    End Class
End Namespace
