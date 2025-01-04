<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChargeCodeReference
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChargeCodeReference))
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.ContextMenuStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'DataGridView1
		'
		Me.DataGridView1.AllowUserToDeleteRows = False
		Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
		Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.Size = New System.Drawing.Size(788, 313)
		Me.DataGridView1.TabIndex = 0
		'
		'ContextMenuStrip1
		'
		Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
		Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
		Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
		'
		'DeleteToolStripMenuItem
		'
		Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
		Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
		Me.DeleteToolStripMenuItem.Text = "Delete"
		'
		'ChargeCodeReference
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(788, 313)
		Me.Controls.Add(Me.DataGridView1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ChargeCodeReference"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Charge Code Reference"
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ContextMenuStrip1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
	Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
End Class
