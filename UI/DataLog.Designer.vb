<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataLog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBarSave = New System.Windows.Forms.ProgressBar()
        Me.DataGridViewDataLog = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStripDataLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridViewDataLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripDataLog.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.DataGridViewDataLog)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(447, 237)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.Panel2.Controls.Add(Me.ProgressBarSave)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(447, 34)
        Me.Panel2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DHT11 Temperature dan Humidity Data Log"
        '
        'ProgressBarSave
        '
        Me.ProgressBarSave.Location = New System.Drawing.Point(290, 10)
        Me.ProgressBarSave.Maximum = 10
        Me.ProgressBarSave.Name = "ProgressBarSave"
        Me.ProgressBarSave.Size = New System.Drawing.Size(154, 13)
        Me.ProgressBarSave.Step = 1
        Me.ProgressBarSave.TabIndex = 1
        Me.ProgressBarSave.Visible = False
        '
        'DataGridViewDataLog
        '
        Me.DataGridViewDataLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridViewDataLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDataLog.ContextMenuStrip = Me.ContextMenuStripDataLog
        Me.DataGridViewDataLog.Location = New System.Drawing.Point(15, 49)
        Me.DataGridViewDataLog.Name = "DataGridViewDataLog"
        Me.DataGridViewDataLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewDataLog.Size = New System.Drawing.Size(417, 171)
        Me.DataGridViewDataLog.TabIndex = 1
        '
        'ContextMenuStripDataLog
        '
        Me.ContextMenuStripDataLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveToExcelToolStripMenuItem})
        Me.ContextMenuStripDataLog.Name = "ContextMenuStripDataLog"
        Me.ContextMenuStripDataLog.Size = New System.Drawing.Size(153, 76)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh "
        '
        'SaveToExcelToolStripMenuItem
        '
        Me.SaveToExcelToolStripMenuItem.Name = "SaveToExcelToolStripMenuItem"
        Me.SaveToExcelToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveToExcelToolStripMenuItem.Text = "Save to Excel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(139, 6)
        '
        'DataLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 261)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "DataLog"
        Me.Text = "DataLog"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridViewDataLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripDataLog.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ProgressBarSave As ProgressBar
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridViewDataLog As DataGridView
    Friend WithEvents ContextMenuStripDataLog As ContextMenuStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
