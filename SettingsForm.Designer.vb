<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
		Me.ConfigWatcher = New System.IO.FileSystemWatcher()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.ReloadConfigButton = New System.Windows.Forms.ToolStripSplitButton()
		Me.ServiceRestartReqd = New System.Windows.Forms.ToolStripStatusLabel()
		Me.ResetValueButton = New System.Windows.Forms.ToolStripMenuItem()
		Me.PropertiesContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
		Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.ShowConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		CType(Me.ConfigWatcher, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.StatusStrip1.SuspendLayout()
		Me.PropertiesContextMenu.SuspendLayout()
		Me.SuspendLayout()
		'
		'ConfigWatcher
		'
		Me.ConfigWatcher.EnableRaisingEvents = True
		Me.ConfigWatcher.SynchronizingObject = Me
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReloadConfigButton, Me.ServiceRestartReqd})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 547)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.ShowItemToolTips = True
		Me.StatusStrip1.Size = New System.Drawing.Size(441, 22)
		Me.StatusStrip1.SizingGrip = False
		Me.StatusStrip1.TabIndex = 8
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'ReloadConfigButton
		'
		Me.ReloadConfigButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
		Me.ReloadConfigButton.DropDownButtonWidth = 0
		Me.ReloadConfigButton.Image = Global.TimeTracker.My.Resources.Resources.refresh
		Me.ReloadConfigButton.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ReloadConfigButton.Margin = New System.Windows.Forms.Padding(0, 2, 2, 0)
		Me.ReloadConfigButton.Name = "ReloadConfigButton"
		Me.ReloadConfigButton.Size = New System.Drawing.Size(21, 20)
		Me.ReloadConfigButton.Text = "Refresh"
		Me.ReloadConfigButton.Visible = False
		'
		'ServiceRestartReqd
		'
		Me.ServiceRestartReqd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ServiceRestartReqd.ForeColor = System.Drawing.Color.Firebrick
		Me.ServiceRestartReqd.Name = "ServiceRestartReqd"
		Me.ServiceRestartReqd.Size = New System.Drawing.Size(130, 17)
		Me.ServiceRestartReqd.Text = "RESTART REQUIRED"
		Me.ServiceRestartReqd.Visible = False
		'
		'ResetValueButton
		'
		Me.ResetValueButton.Enabled = False
		Me.ResetValueButton.Name = "ResetValueButton"
		Me.ResetValueButton.Size = New System.Drawing.Size(102, 22)
		Me.ResetValueButton.Text = "Reset"
		'
		'PropertiesContextMenu
		'
		Me.PropertiesContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetValueButton})
		Me.PropertiesContextMenu.Name = "ContextMenuStrip1"
		Me.PropertiesContextMenu.Size = New System.Drawing.Size(103, 26)
		'
		'PropertyGrid1
		'
		Me.PropertyGrid1.ContextMenuStrip = Me.PropertiesContextMenu
		Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PropertyGrid1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
		Me.PropertyGrid1.Name = "PropertyGrid1"
		Me.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized
		Me.PropertyGrid1.SelectedItemWithFocusBackColor = System.Drawing.SystemColors.GradientActiveCaption
		Me.PropertyGrid1.SelectedItemWithFocusForeColor = System.Drawing.SystemColors.ControlText
		Me.PropertyGrid1.Size = New System.Drawing.Size(441, 547)
		Me.PropertyGrid1.TabIndex = 10
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(441, 24)
		Me.MenuStrip1.TabIndex = 11
		Me.MenuStrip1.Text = "MenuStrip1"
		Me.MenuStrip1.Visible = False
		'
		'ShowConsoleToolStripMenuItem
		'
		Me.ShowConsoleToolStripMenuItem.Name = "ShowConsoleToolStripMenuItem"
		Me.ShowConsoleToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9
		Me.ShowConsoleToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
		Me.ShowConsoleToolStripMenuItem.Text = "Show Console"
		'
		'SettingsForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(441, 569)
		Me.Controls.Add(Me.PropertyGrid1)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.MenuStrip1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MainMenuStrip = Me.MenuStrip1
		Me.MaximizeBox = False
		Me.Name = "SettingsForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Settings"
		CType(Me.ConfigWatcher, System.ComponentModel.ISupportInitialize).EndInit()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		Me.PropertiesContextMenu.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents ConfigWatcher As IO.FileSystemWatcher
	Friend WithEvents ToolTip1 As ToolTip
	Friend WithEvents StatusStrip1 As StatusStrip
	Friend WithEvents PropertyGrid1 As PropertyGrid
	Friend WithEvents PropertiesContextMenu As ContextMenuStrip
	Friend WithEvents ResetValueButton As ToolStripMenuItem
	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents ShowConsoleToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ReloadConfigButton As ToolStripSplitButton
	Friend WithEvents ServiceRestartReqd As ToolStripStatusLabel
End Class
