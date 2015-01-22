Namespace BOM
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
            Me.imlListView = New System.Windows.Forms.ImageList(Me.components)
            Me.chQuantity = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.chTitle = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.chRevision = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.chDocumentNumber = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.chLevel = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.lvBOM = New System.Windows.Forms.ListView()
            Me.chFileName = (CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader))
            Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
            Me.buttonRefresh = New System.Windows.Forms.ToolStripButton()
            Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
            Me.refreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.viewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
            Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
            Me.toolStrip1.SuspendLayout()
            Me.menuStrip1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' imlListView
            ' 
            Me.imlListView.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
            Me.imlListView.ImageSize = New System.Drawing.Size(16, 16)
            Me.imlListView.TransparentColor = System.Drawing.Color.Transparent
            ' 
            ' chQuantity
            ' 
            Me.chQuantity.Text = "Quantity"
            ' 
            ' chTitle
            ' 
            Me.chTitle.Text = "Title"
            ' 
            ' chRevision
            ' 
            Me.chRevision.Text = "Revision"
            ' 
            ' chDocumentNumber
            ' 
            Me.chDocumentNumber.Text = "Document Number"
            ' 
            ' chLevel
            ' 
            Me.chLevel.Text = "Level"
            ' 
            ' lvBOM
            ' 
            Me.lvBOM.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.chLevel, Me.chDocumentNumber, Me.chRevision, Me.chTitle, Me.chQuantity, Me.chFileName})
            Me.lvBOM.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lvBOM.FullRowSelect = True
            Me.lvBOM.HideSelection = False
            Me.lvBOM.Location = New System.Drawing.Point(0, 49)
            Me.lvBOM.Name = "lvBOM"
            Me.lvBOM.Size = New System.Drawing.Size(663, 370)
            Me.lvBOM.SmallImageList = Me.imlListView
            Me.lvBOM.TabIndex = 7
            Me.lvBOM.UseCompatibleStateImageBehavior = False
            Me.lvBOM.View = System.Windows.Forms.View.Details
            ' 
            ' chFileName
            ' 
            Me.chFileName.Text = "File Name"
            ' 
            ' statusStrip1
            ' 
            Me.statusStrip1.Location = New System.Drawing.Point(0, 419)
            Me.statusStrip1.Name = "statusStrip1"
            Me.statusStrip1.Size = New System.Drawing.Size(663, 22)
            Me.statusStrip1.TabIndex = 6
            Me.statusStrip1.Text = "statusStrip1"
            ' 
            ' buttonRefresh
            ' 
            Me.buttonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.buttonRefresh.Image = My.Resources.Refresh_16x16
            Me.buttonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.buttonRefresh.Name = "buttonRefresh"
            Me.buttonRefresh.Size = New System.Drawing.Size(23, 22)
            Me.buttonRefresh.Text = "Refresh"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            ' 
            ' toolStrip1
            ' 
            Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.buttonRefresh})
            Me.toolStrip1.Location = New System.Drawing.Point(0, 24)
            Me.toolStrip1.Name = "toolStrip1"
            Me.toolStrip1.Size = New System.Drawing.Size(663, 25)
            Me.toolStrip1.TabIndex = 5
            Me.toolStrip1.Text = "toolStrip1"
            ' 
            ' refreshToolStripMenuItem
            ' 
            Me.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem"
            Me.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
            Me.refreshToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.refreshToolStripMenuItem.Text = "&Refresh"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            ' 
            ' viewToolStripMenuItem
            ' 
            Me.viewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.refreshToolStripMenuItem})
            Me.viewToolStripMenuItem.Name = "viewToolStripMenuItem"
            Me.viewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
            Me.viewToolStripMenuItem.Text = "&View"
            ' 
            ' selectAllToolStripMenuItem
            ' 
            Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
            Me.selectAllToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys))
            Me.selectAllToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
            Me.selectAllToolStripMenuItem.Text = "Select &All"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            ' 
            ' toolStripMenuItem1
            ' 
            Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
            Me.toolStripMenuItem1.Size = New System.Drawing.Size(161, 6)
            ' 
            ' copyToolStripMenuItem
            ' 
            Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
            Me.copyToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys))
            Me.copyToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
            Me.copyToolStripMenuItem.Text = "&Copy"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            ' 
            ' editToolStripMenuItem
            ' 
            Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.copyToolStripMenuItem, Me.toolStripMenuItem1, Me.selectAllToolStripMenuItem})
            Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
            Me.editToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
            Me.editToolStripMenuItem.Text = "&Edit"
            ' 
            ' exitToolStripMenuItem
            ' 
            Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
            Me.exitToolStripMenuItem.ShortcutKeys = (CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys))
            Me.exitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
            Me.exitToolStripMenuItem.Text = "&Exit"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            ' 
            ' fileToolStripMenuItem
            ' 
            Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.exitToolStripMenuItem})
            Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
            Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
            Me.fileToolStripMenuItem.Text = "&File"
            ' 
            ' menuStrip1
            ' 
            Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.viewToolStripMenuItem})
            Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
            Me.menuStrip1.Name = "menuStrip1"
            Me.menuStrip1.Size = New System.Drawing.Size(663, 24)
            Me.menuStrip1.TabIndex = 4
            Me.menuStrip1.Text = "menuStrip1"
            ' 
            ' MainForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(663, 441)
            Me.Controls.Add(Me.lvBOM)
            Me.Controls.Add(Me.statusStrip1)
            Me.Controls.Add(Me.toolStrip1)
            Me.Controls.Add(Me.menuStrip1)
            Me.Name = "MainForm"
            Me.Text = "Assembly BOM"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.MainForm_Load);
            Me.toolStrip1.ResumeLayout(False)
            Me.toolStrip1.PerformLayout()
            Me.menuStrip1.ResumeLayout(False)
            Me.menuStrip1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private imlListView As System.Windows.Forms.ImageList
        Private chQuantity As System.Windows.Forms.ColumnHeader
        Private chTitle As System.Windows.Forms.ColumnHeader
        Private chRevision As System.Windows.Forms.ColumnHeader
        Private chDocumentNumber As System.Windows.Forms.ColumnHeader
        Private chLevel As System.Windows.Forms.ColumnHeader
        Private lvBOM As System.Windows.Forms.ListView
        Private chFileName As System.Windows.Forms.ColumnHeader
        Private statusStrip1 As System.Windows.Forms.StatusStrip
        Private WithEvents buttonRefresh As System.Windows.Forms.ToolStripButton
        Private toolStrip1 As System.Windows.Forms.ToolStrip
        Private WithEvents refreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private viewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
        Private WithEvents copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Private menuStrip1 As System.Windows.Forms.MenuStrip
    End Class
End Namespace

