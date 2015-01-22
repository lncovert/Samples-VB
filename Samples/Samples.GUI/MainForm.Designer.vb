﻿Namespace Samples.GUI
    Partial Public Class MainForm
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
            Me.toolStrip = New System.Windows.Forms.ToolStrip()
            Me.buttonRun = New System.Windows.Forms.ToolStripButton()
            Me.buttonBreakpoint = New System.Windows.Forms.ToolStripButton()
            Me.statusStrip = New System.Windows.Forms.StatusStrip()
            Me.menuStrip = New System.Windows.Forms.MenuStrip()
            Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.closeAllDocumentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.closeAllDocumentssilentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
            Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.codePlexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.samplesForSolidEdgeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.interopForSolidEdgeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.spyForSolidEdgeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
            Me.solidEdgeST6SDKToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.imageList = New System.Windows.Forms.ImageList(Me.components)
            Me.backgroundWorker = New System.ComponentModel.BackgroundWorker()
            Me.splitContainerOuter = New System.Windows.Forms.SplitContainer()
            Me.splitContainerInner = New System.Windows.Forms.SplitContainer()
            Me.treeView = New System.Windows.Forms.TreeView()
            Me.splitContainerListView = New System.Windows.Forms.SplitContainer()
            Me.listView = New Samples.GUI.Forms.ListViewEx()
            Me.columnHeader3 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.sampleRichTextBox = New Samples.GUI.Forms.RichTextBoxEx()
            Me.outputTextBox = New System.Windows.Forms.TextBox()
            Me.columnHeader1 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.columnHeader2 = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.toolStrip.SuspendLayout()
            Me.menuStrip.SuspendLayout()
            DirectCast(Me.splitContainerOuter, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerOuter.Panel1.SuspendLayout()
            Me.splitContainerOuter.Panel2.SuspendLayout()
            Me.splitContainerOuter.SuspendLayout()
            DirectCast(Me.splitContainerInner, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerInner.Panel1.SuspendLayout()
            Me.splitContainerInner.Panel2.SuspendLayout()
            Me.splitContainerInner.SuspendLayout()
            DirectCast(Me.splitContainerListView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerListView.Panel1.SuspendLayout()
            Me.splitContainerListView.Panel2.SuspendLayout()
            Me.splitContainerListView.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' toolStrip
            ' 
            Me.toolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonRun, Me.buttonBreakpoint})
            Me.toolStrip.Location = New System.Drawing.Point(0, 24)
            Me.toolStrip.Name = "toolStrip"
            Me.toolStrip.Size = New System.Drawing.Size(620, 25)
            Me.toolStrip.TabIndex = 5
            ' 
            ' buttonRun
            ' 
            Me.buttonRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.buttonRun.Image = (DirectCast(resources.GetObject("buttonRun.Image"), System.Drawing.Image))
            Me.buttonRun.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.buttonRun.Name = "buttonRun"
            Me.buttonRun.Size = New System.Drawing.Size(23, 22)
            Me.buttonRun.Text = "Run"
            Me.buttonRun.ToolTipText = "Run the selected sample."
            '            Me.buttonRun.Click += New System.EventHandler(Me.buttonRun_Click)
            ' 
            ' buttonBreakpoint
            ' 
            Me.buttonBreakpoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.buttonBreakpoint.Image = (DirectCast(resources.GetObject("buttonBreakpoint.Image"), System.Drawing.Image))
            Me.buttonBreakpoint.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.buttonBreakpoint.Name = "buttonBreakpoint"
            Me.buttonBreakpoint.Size = New System.Drawing.Size(23, 22)
            Me.buttonBreakpoint.Text = "Breakpoint"
            Me.buttonBreakpoint.ToolTipText = "Break at start of sample."
            '            Me.buttonBreakpoint.Click += New System.EventHandler(Me.buttonBreakpoint_Click)
            ' 
            ' statusStrip
            ' 
            Me.statusStrip.Location = New System.Drawing.Point(0, 401)
            Me.statusStrip.Name = "statusStrip"
            Me.statusStrip.Size = New System.Drawing.Size(620, 22)
            Me.statusStrip.TabIndex = 4
            Me.statusStrip.Text = "statusStrip1"
            ' 
            ' menuStrip
            ' 
            Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.helpToolStripMenuItem})
            Me.menuStrip.Location = New System.Drawing.Point(0, 0)
            Me.menuStrip.Name = "menuStrip"
            Me.menuStrip.Size = New System.Drawing.Size(620, 24)
            Me.menuStrip.TabIndex = 3
            Me.menuStrip.Text = "menuStrip1"
            ' 
            ' fileToolStripMenuItem
            ' 
            Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.closeAllDocumentsToolStripMenuItem, Me.closeAllDocumentssilentToolStripMenuItem, Me.toolStripMenuItem1, Me.exitToolStripMenuItem})
            Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
            Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
            Me.fileToolStripMenuItem.Text = "&File"
            ' 
            ' closeAllDocumentsToolStripMenuItem
            ' 
            Me.closeAllDocumentsToolStripMenuItem.Name = "closeAllDocumentsToolStripMenuItem"
            Me.closeAllDocumentsToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
            Me.closeAllDocumentsToolStripMenuItem.Text = "Close all documents"
            '            Me.closeAllDocumentsToolStripMenuItem.Click += New System.EventHandler(Me.closeAllDocumentsToolStripMenuItem_Click)
            ' 
            ' closeAllDocumentssilentToolStripMenuItem
            ' 
            Me.closeAllDocumentssilentToolStripMenuItem.Name = "closeAllDocumentssilentToolStripMenuItem"
            Me.closeAllDocumentssilentToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
            Me.closeAllDocumentssilentToolStripMenuItem.Text = "Close all documents (silent)"
            '            Me.closeAllDocumentssilentToolStripMenuItem.Click += New System.EventHandler(Me.closeAllDocumentsSilentToolStripMenuItem_Click)
            ' 
            ' toolStripMenuItem1
            ' 
            Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
            Me.toolStripMenuItem1.Size = New System.Drawing.Size(217, 6)
            ' 
            ' exitToolStripMenuItem
            ' 
            Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
            Me.exitToolStripMenuItem.Size = New System.Drawing.Size(220, 22)
            Me.exitToolStripMenuItem.Text = "&Exit"
            '            Me.exitToolStripMenuItem.Click += New System.EventHandler(Me.exitToolStripMenuItem_Click)
            ' 
            ' helpToolStripMenuItem
            ' 
            Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.codePlexToolStripMenuItem, Me.toolStripMenuItem2, Me.solidEdgeST6SDKToolStripMenuItem})
            Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
            Me.helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
            Me.helpToolStripMenuItem.Text = "&Help"
            ' 
            ' codePlexToolStripMenuItem
            ' 
            Me.codePlexToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.samplesForSolidEdgeToolStripMenuItem, Me.interopForSolidEdgeToolStripMenuItem, Me.spyForSolidEdgeToolStripMenuItem})
            Me.codePlexToolStripMenuItem.Name = "codePlexToolStripMenuItem"
            Me.codePlexToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
            Me.codePlexToolStripMenuItem.Text = "&CodePlex"
            ' 
            ' samplesForSolidEdgeToolStripMenuItem
            ' 
            Me.samplesForSolidEdgeToolStripMenuItem.Name = "samplesForSolidEdgeToolStripMenuItem"
            Me.samplesForSolidEdgeToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
            Me.samplesForSolidEdgeToolStripMenuItem.Text = "Samples for Solid Edge"
            ' 
            ' interopForSolidEdgeToolStripMenuItem
            ' 
            Me.interopForSolidEdgeToolStripMenuItem.Name = "interopForSolidEdgeToolStripMenuItem"
            Me.interopForSolidEdgeToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
            Me.interopForSolidEdgeToolStripMenuItem.Text = "Interop for Solid Edge"
            ' 
            ' spyForSolidEdgeToolStripMenuItem
            ' 
            Me.spyForSolidEdgeToolStripMenuItem.Name = "spyForSolidEdgeToolStripMenuItem"
            Me.spyForSolidEdgeToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
            Me.spyForSolidEdgeToolStripMenuItem.Text = "Spy for Solid Edge"
            ' 
            ' toolStripMenuItem2
            ' 
            Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
            Me.toolStripMenuItem2.Size = New System.Drawing.Size(172, 6)
            ' 
            ' solidEdgeST6SDKToolStripMenuItem
            ' 
            Me.solidEdgeST6SDKToolStripMenuItem.Name = "solidEdgeST6SDKToolStripMenuItem"
            Me.solidEdgeST6SDKToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
            Me.solidEdgeST6SDKToolStripMenuItem.Text = "&Solid Edge ST6 SDK"
            ' 
            ' imageList
            ' 
            Me.imageList.ImageStream = (DirectCast(resources.GetObject("imageList.ImageStream"), System.Windows.Forms.ImageListStreamer))
            Me.imageList.TransparentColor = System.Drawing.Color.Transparent
            Me.imageList.Images.SetKeyName(0, "FolderClosed_16x16.png")
            Me.imageList.Images.SetKeyName(1, "FolderOpen_16x16.png")
            Me.imageList.Images.SetKeyName(2, "Method_16x16.png")
            ' 
            ' backgroundWorker
            ' 
            Me.backgroundWorker.WorkerReportsProgress = True
            Me.backgroundWorker.WorkerSupportsCancellation = True
            '            Me.backgroundWorker.DoWork += New System.ComponentModel.DoWorkEventHandler(Me.backgroundWorker_DoWork)
            '            Me.backgroundWorker.ProgressChanged += New System.ComponentModel.ProgressChangedEventHandler(Me.backgroundWorker_ProgressChanged)
            '            Me.backgroundWorker.RunWorkerCompleted += New System.ComponentModel.RunWorkerCompletedEventHandler(Me.backgroundWorker_RunWorkerCompleted)
            ' 
            ' splitContainerOuter
            ' 
            Me.splitContainerOuter.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerOuter.Location = New System.Drawing.Point(0, 49)
            Me.splitContainerOuter.Name = "splitContainerOuter"
            Me.splitContainerOuter.Orientation = System.Windows.Forms.Orientation.Horizontal
            ' 
            ' splitContainerOuter.Panel1
            ' 
            Me.splitContainerOuter.Panel1.Controls.Add(Me.splitContainerInner)
            ' 
            ' splitContainerOuter.Panel2
            ' 
            Me.splitContainerOuter.Panel2.Controls.Add(Me.outputTextBox)
            Me.splitContainerOuter.Size = New System.Drawing.Size(620, 352)
            Me.splitContainerOuter.SplitterDistance = 262
            Me.splitContainerOuter.TabIndex = 6
            ' 
            ' splitContainerInner
            ' 
            Me.splitContainerInner.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerInner.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
            Me.splitContainerInner.Location = New System.Drawing.Point(0, 0)
            Me.splitContainerInner.Name = "splitContainerInner"
            ' 
            ' splitContainerInner.Panel1
            ' 
            Me.splitContainerInner.Panel1.Controls.Add(Me.treeView)
            ' 
            ' splitContainerInner.Panel2
            ' 
            Me.splitContainerInner.Panel2.Controls.Add(Me.splitContainerListView)
            Me.splitContainerInner.Size = New System.Drawing.Size(620, 262)
            Me.splitContainerInner.SplitterDistance = 175
            Me.splitContainerInner.TabIndex = 4
            ' 
            ' treeView
            ' 
            Me.treeView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.treeView.HideSelection = False
            Me.treeView.ImageIndex = 0
            Me.treeView.ImageList = Me.imageList
            Me.treeView.Location = New System.Drawing.Point(0, 0)
            Me.treeView.Name = "treeView"
            Me.treeView.SelectedImageIndex = 0
            Me.treeView.Size = New System.Drawing.Size(175, 262)
            Me.treeView.TabIndex = 0
            '            Me.treeView.AfterSelect += New System.Windows.Forms.TreeViewEventHandler(Me.treeView_AfterSelect)
            ' 
            ' splitContainerListView
            ' 
            Me.splitContainerListView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerListView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
            Me.splitContainerListView.Location = New System.Drawing.Point(0, 0)
            Me.splitContainerListView.Name = "splitContainerListView"
            Me.splitContainerListView.Orientation = System.Windows.Forms.Orientation.Horizontal
            ' 
            ' splitContainerListView.Panel1
            ' 
            Me.splitContainerListView.Panel1.Controls.Add(Me.listView)
            ' 
            ' splitContainerListView.Panel2
            ' 
            Me.splitContainerListView.Panel2.Controls.Add(Me.sampleRichTextBox)
            Me.splitContainerListView.Size = New System.Drawing.Size(441, 262)
            Me.splitContainerListView.SplitterDistance = 163
            Me.splitContainerListView.TabIndex = 4
            ' 
            ' listView
            ' 
            Me.listView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader3})
            Me.listView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.listView.FullRowSelect = True
            Me.listView.HideSelection = False
            Me.listView.Location = New System.Drawing.Point(0, 0)
            Me.listView.MultiSelect = False
            Me.listView.Name = "listView"
            Me.listView.Size = New System.Drawing.Size(441, 163)
            Me.listView.SmallImageList = Me.imageList
            Me.listView.TabIndex = 4
            Me.listView.UseCompatibleStateImageBehavior = False
            Me.listView.View = System.Windows.Forms.View.Details
            '            Me.listView.SelectedIndexChanged += New System.EventHandler(Me.listView_SelectedIndexChanged)
            ' 
            ' columnHeader3
            ' 
            Me.columnHeader3.Text = "Sample"
            Me.columnHeader3.Width = 207
            ' 
            ' sampleRichTextBox
            ' 
            Me.sampleRichTextBox.BackColor = System.Drawing.Color.White
            Me.sampleRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.sampleRichTextBox.Font = New System.Drawing.Font("Segoe UI", 9.75F)
            Me.sampleRichTextBox.Location = New System.Drawing.Point(0, 0)
            Me.sampleRichTextBox.Name = "sampleRichTextBox"
            Me.sampleRichTextBox.ReadOnly = True
            Me.sampleRichTextBox.Size = New System.Drawing.Size(441, 95)
            Me.sampleRichTextBox.TabIndex = 1
            Me.sampleRichTextBox.Text = ""
            ' 
            ' outputTextBox
            ' 
            Me.outputTextBox.AcceptsReturn = True
            Me.outputTextBox.AcceptsTab = True
            Me.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.outputTextBox.Font = New System.Drawing.Font("Consolas", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
            Me.outputTextBox.Location = New System.Drawing.Point(0, 0)
            Me.outputTextBox.MaxLength = 0
            Me.outputTextBox.Multiline = True
            Me.outputTextBox.Name = "outputTextBox"
            Me.outputTextBox.ReadOnly = True
            Me.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.outputTextBox.Size = New System.Drawing.Size(620, 86)
            Me.outputTextBox.TabIndex = 2
            Me.outputTextBox.WordWrap = False
            ' 
            ' columnHeader1
            ' 
            Me.columnHeader1.Text = "Sample"
            Me.columnHeader1.Width = 207
            ' 
            ' columnHeader2
            ' 
            Me.columnHeader2.Text = "Sample"
            Me.columnHeader2.Width = 207
            ' 
            ' MainForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(620, 423)
            Me.Controls.Add(Me.splitContainerOuter)
            Me.Controls.Add(Me.toolStrip)
            Me.Controls.Add(Me.statusStrip)
            Me.Controls.Add(Me.menuStrip)
            Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
            Me.Name = "MainForm"
            Me.Text = "Solid Edge API Samples"
'            Me.Load += New System.EventHandler(Me.MainForm_Load)
            Me.toolStrip.ResumeLayout(False)
            Me.toolStrip.PerformLayout()
            Me.menuStrip.ResumeLayout(False)
            Me.menuStrip.PerformLayout()
            Me.splitContainerOuter.Panel1.ResumeLayout(False)
            Me.splitContainerOuter.Panel2.ResumeLayout(False)
            Me.splitContainerOuter.Panel2.PerformLayout()
            DirectCast(Me.splitContainerOuter, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerOuter.ResumeLayout(False)
            Me.splitContainerInner.Panel1.ResumeLayout(False)
            Me.splitContainerInner.Panel2.ResumeLayout(False)
            DirectCast(Me.splitContainerInner, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerInner.ResumeLayout(False)
            Me.splitContainerListView.Panel1.ResumeLayout(False)
            Me.splitContainerListView.Panel2.ResumeLayout(False)
            DirectCast(Me.splitContainerListView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerListView.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private toolStrip As System.Windows.Forms.ToolStrip
        Private WithEvents buttonRun As System.Windows.Forms.ToolStripButton
        Private WithEvents buttonBreakpoint As System.Windows.Forms.ToolStripButton
        Private statusStrip As System.Windows.Forms.StatusStrip
        Private menuStrip As System.Windows.Forms.MenuStrip
        Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents closeAllDocumentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents closeAllDocumentssilentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private codePlexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private samplesForSolidEdgeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private interopForSolidEdgeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private spyForSolidEdgeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
        Private solidEdgeST6SDKToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private imageList As System.Windows.Forms.ImageList
        Private WithEvents backgroundWorker As System.ComponentModel.BackgroundWorker
        Private splitContainerOuter As System.Windows.Forms.SplitContainer
        Private splitContainerInner As System.Windows.Forms.SplitContainer
        Private WithEvents treeView As System.Windows.Forms.TreeView
        Private splitContainerListView As System.Windows.Forms.SplitContainer
        Private outputTextBox As System.Windows.Forms.TextBox
        Private columnHeader1 As System.Windows.Forms.ColumnHeader
        Private columnHeader2 As System.Windows.Forms.ColumnHeader
        Private WithEvents listView As Samples.GUI.Forms.ListViewEx
        Private columnHeader3 As System.Windows.Forms.ColumnHeader
        Private sampleRichTextBox As Samples.GUI.Forms.RichTextBoxEx
    End Class
End Namespace

