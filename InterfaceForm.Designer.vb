<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InterfaceForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterfaceForm))
		Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
		Me.TreeView1 = New System.Windows.Forms.TreeView()
		Me.TimesheetControl1 = New TimesheetControl.TimesheetControl()
		Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
		Me.RefreshButton3 = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
		Me.BackButton1 = New System.Windows.Forms.ToolStripButton()
		Me.WeekComboBox = New System.Windows.Forms.ToolStripComboBox()
		Me.ForwardButton1 = New System.Windows.Forms.ToolStripButton()
		Me.DaySeparator = New System.Windows.Forms.ToolStripSeparator()
		Me.DayComboBox = New System.Windows.Forms.ToolStripComboBox()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.NewTimeSheetEntryButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
		Me.PrintButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.PrintPreviewButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
		Me.ExitButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.AllEntiresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.DaySummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
		Me.RefreshButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
		Me.BackButton2 = New System.Windows.Forms.ToolStripMenuItem()
		Me.ForwardButton2 = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.SettingsButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
		Me.ChargeCodesButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.HelpButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.InfoButton1 = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainer2.Panel1MinSize = 100
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.TimesheetControl1)
        Me.SplitContainer2.Panel2MinSize = 500
        Me.SplitContainer2.Size = New System.Drawing.Size(1013, 507)
        Me.SplitContainer2.SplitterDistance = 250
        Me.SplitContainer2.SplitterWidth = 5
        Me.SplitContainer2.TabIndex = 9
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.HideSelection = False
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(250, 507)
        Me.TreeView1.TabIndex = 0
        '
        'TimesheetControl1
        '
        Me.TimesheetControl1.BorderColor = System.Drawing.Color.Black
        Me.TimesheetControl1.ChargeCodes = Nothing
        Me.TimesheetControl1.DayBarrierBackColor = System.Drawing.Color.LightSteelBlue
        Me.TimesheetControl1.DayBarrierForeColor = System.Drawing.Color.Black
        Me.TimesheetControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TimesheetControl1.EntryRowBackColor = System.Drawing.Color.White
        Me.TimesheetControl1.EntryRowForeColor = System.Drawing.Color.Black
        Me.TimesheetControl1.HeaderRowBackColor = System.Drawing.Color.LightGray
        Me.TimesheetControl1.HeaderRowForeColor = System.Drawing.Color.Black
        Me.TimesheetControl1.ListDays = 7
        Me.TimesheetControl1.Location = New System.Drawing.Point(0, 0)
        Me.TimesheetControl1.Name = "TimesheetControl1"
        Me.TimesheetControl1.RowHeight = 18
        Me.TimesheetControl1.Size = New System.Drawing.Size(758, 507)
        Me.TimesheetControl1.StartDate = New Date(2024, 12, 30, 0, 0, 0, 0)
        Me.TimesheetControl1.SummaryView = False
        Me.TimesheetControl1.SummaryViewDay = 0
        Me.TimesheetControl1.TabIndex = 1
        Me.TimesheetControl1.Text = "TimesheetControl1"
        Me.TimesheetControl1.TodayDayBarrierBackColor = System.Drawing.Color.DarkSeaGreen
        Me.TimesheetControl1.TodayDayBarrierForeColor = System.Drawing.Color.Black
        Me.TimesheetControl1.TotalRowBackColor = System.Drawing.Color.Black
        Me.TimesheetControl1.TotalRowForeColor = System.Drawing.Color.WhiteSmoke
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshButton3, Me.ToolStripSeparator14, Me.BackButton1, Me.WeekComboBox, Me.ForwardButton1, Me.DaySeparator, Me.DayComboBox})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1013, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'RefreshButton3
        '
        Me.RefreshButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RefreshButton3.Image = Global.TimeTracker.My.Resources.Resources.refresh
        Me.RefreshButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshButton3.Name = "RefreshButton3"
        Me.RefreshButton3.Size = New System.Drawing.Size(23, 22)
        Me.RefreshButton3.Text = "ToolStripButton1"
        Me.RefreshButton3.Visible = False
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(6, 25)
        Me.ToolStripSeparator14.Visible = False
        '
        'BackButton1
        '
        Me.BackButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BackButton1.Image = Global.TimeTracker.My.Resources.Resources.back
        Me.BackButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BackButton1.Name = "BackButton1"
        Me.BackButton1.Size = New System.Drawing.Size(23, 22)
        Me.BackButton1.Text = "Back"
        '
        'WeekComboBox
        '
        Me.WeekComboBox.AutoSize = False
        Me.WeekComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.WeekComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.WeekComboBox.Name = "WeekComboBox"
        Me.WeekComboBox.Size = New System.Drawing.Size(121, 23)
        '
        'ForwardButton1
        '
        Me.ForwardButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ForwardButton1.Image = Global.TimeTracker.My.Resources.Resources.forward
        Me.ForwardButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ForwardButton1.Name = "ForwardButton1"
        Me.ForwardButton1.Size = New System.Drawing.Size(23, 22)
        Me.ForwardButton1.Text = "Forward"
        '
        'DaySeparator
        '
        Me.DaySeparator.Name = "DaySeparator"
        Me.DaySeparator.Size = New System.Drawing.Size(6, 25)
        Me.DaySeparator.Visible = False
        '
        'DayComboBox
        '
        Me.DayComboBox.AutoSize = False
        Me.DayComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.DayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DayComboBox.Items.AddRange(New Object() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"})
        Me.DayComboBox.Name = "DayComboBox"
        Me.DayComboBox.Size = New System.Drawing.Size(121, 23)
        Me.DayComboBox.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1013, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewTimeSheetEntryButton1, Me.ToolStripSeparator2, Me.PrintButton1, Me.PrintPreviewButton1, Me.ToolStripSeparator3, Me.ExitButton1})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(36, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewTimeSheetEntryButton1
        '
        Me.NewTimeSheetEntryButton1.Image = Global.TimeTracker.My.Resources.Resources._new
        Me.NewTimeSheetEntryButton1.Name = "NewTimeSheetEntryButton1"
        Me.NewTimeSheetEntryButton1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewTimeSheetEntryButton1.Size = New System.Drawing.Size(219, 22)
        Me.NewTimeSheetEntryButton1.Text = "&New"
        Me.NewTimeSheetEntryButton1.ToolTipText = "New Week" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold SHIFT to add automatically"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(216, 6)
        Me.ToolStripSeparator2.Visible = False
        '
        'PrintButton1
        '
        Me.PrintButton1.Image = Global.TimeTracker.My.Resources.Resources.printer
        Me.PrintButton1.Name = "PrintButton1"
        Me.PrintButton1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintButton1.Size = New System.Drawing.Size(219, 22)
        Me.PrintButton1.Text = "&Print"
        Me.PrintButton1.Visible = False
        '
        'PrintPreviewButton1
        '
        Me.PrintPreviewButton1.Image = Global.TimeTracker.My.Resources.Resources.document
        Me.PrintPreviewButton1.Name = "PrintPreviewButton1"
        Me.PrintPreviewButton1.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintPreviewButton1.Size = New System.Drawing.Size(219, 22)
        Me.PrintPreviewButton1.Text = "Print Pre&view"
        Me.PrintPreviewButton1.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(216, 6)
        Me.ToolStripSeparator3.Visible = False
        '
        'ExitButton1
        '
        Me.ExitButton1.Image = Global.TimeTracker.My.Resources.Resources.close
        Me.ExitButton1.Name = "ExitButton1"
        Me.ExitButton1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.ExitButton1.Size = New System.Drawing.Size(219, 22)
        Me.ExitButton1.Text = "E&xit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllEntiresToolStripMenuItem, Me.DaySummaryToolStripMenuItem, Me.ToolStripSeparator13, Me.RefreshButton1, Me.ToolStripSeparator4, Me.BackButton2, Me.ForwardButton2})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'AllEntiresToolStripMenuItem
        '
        Me.AllEntiresToolStripMenuItem.Checked = True
        Me.AllEntiresToolStripMenuItem.CheckOnClick = True
        Me.AllEntiresToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AllEntiresToolStripMenuItem.Name = "AllEntiresToolStripMenuItem"
        Me.AllEntiresToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.AllEntiresToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AllEntiresToolStripMenuItem.Text = "All Entires"
        Me.AllEntiresToolStripMenuItem.ToolTipText = "Timesheet Entry mode. Allows entries to be added."
        '
        'DaySummaryToolStripMenuItem
        '
        Me.DaySummaryToolStripMenuItem.CheckOnClick = True
        Me.DaySummaryToolStripMenuItem.Name = "DaySummaryToolStripMenuItem"
        Me.DaySummaryToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.DaySummaryToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.DaySummaryToolStripMenuItem.Text = "Day Summary"
        Me.DaySummaryToolStripMenuItem.ToolTipText = "Summarizes the selected day, allowing easy entry into Costpoint." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This view is re" &
    "ad-only."
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(165, 6)
        '
        'RefreshButton1
        '
        Me.RefreshButton1.Image = Global.TimeTracker.My.Resources.Resources.refresh
        Me.RefreshButton1.Name = "RefreshButton1"
        Me.RefreshButton1.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RefreshButton1.Size = New System.Drawing.Size(168, 22)
        Me.RefreshButton1.Text = "&Refresh"
        Me.RefreshButton1.ToolTipText = "Refresh"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(165, 6)
        '
        'BackButton2
        '
        Me.BackButton2.Image = Global.TimeTracker.My.Resources.Resources.back
        Me.BackButton2.Name = "BackButton2"
        Me.BackButton2.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.BackButton2.Size = New System.Drawing.Size(168, 22)
        Me.BackButton2.Text = "&Back"
        Me.BackButton2.ToolTipText = "Move backward one week"
        '
        'ForwardButton2
        '
        Me.ForwardButton2.Image = Global.TimeTracker.My.Resources.Resources.forward
        Me.ForwardButton2.Name = "ForwardButton2"
        Me.ForwardButton2.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.ForwardButton2.Size = New System.Drawing.Size(168, 22)
        Me.ForwardButton2.Text = "&Forward"
        Me.ForwardButton2.ToolTipText = "Move forward one week"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsButton1, Me.ToolStripSeparator5, Me.ChargeCodesButton1})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'SettingsButton1
        '
        Me.SettingsButton1.Image = Global.TimeTracker.My.Resources.Resources.settings
        Me.SettingsButton1.Name = "SettingsButton1"
        Me.SettingsButton1.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.SettingsButton1.Size = New System.Drawing.Size(181, 22)
        Me.SettingsButton1.Text = "&Settings..."
        Me.SettingsButton1.ToolTipText = "User Settings"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(178, 6)
        '
        'ChargeCodesButton1
        '
        Me.ChargeCodesButton1.Image = Global.TimeTracker.My.Resources.Resources.dollar
        Me.ChargeCodesButton1.Name = "ChargeCodesButton1"
        Me.ChargeCodesButton1.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.ChargeCodesButton1.Size = New System.Drawing.Size(181, 22)
        Me.ChargeCodesButton1.Text = "Charge Codes..."
        Me.ChargeCodesButton1.ToolTipText = "Charge code reference. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TimeTracker automatically adds charge codes from the las" &
    "t two weeks worth of entries."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpButton1, Me.InfoButton1})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'HelpButton1
        '
        Me.HelpButton1.Image = Global.TimeTracker.My.Resources.Resources.help
        Me.HelpButton1.Name = "HelpButton1"
        Me.HelpButton1.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HelpButton1.Size = New System.Drawing.Size(118, 22)
        Me.HelpButton1.Text = "&Help"
        Me.HelpButton1.ToolTipText = "Load the TimeTracker webpage"
        '
        'InfoButton1
        '
        Me.InfoButton1.Image = Global.TimeTracker.My.Resources.Resources.info
        Me.InfoButton1.Name = "InfoButton1"
        Me.InfoButton1.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.InfoButton1.Size = New System.Drawing.Size(118, 22)
        Me.InfoButton1.Text = "&Info"
        Me.InfoButton1.ToolTipText = "Show information about this application"
        '
        'InterfaceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 556)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MinimumSize = New System.Drawing.Size(900, 450)
        Me.Name = "InterfaceForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TimeTracker"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer2 As SplitContainer
	Friend WithEvents TreeView1 As TreeView
	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents NewTimeSheetEntryButton1 As ToolStripMenuItem
	Friend WithEvents PrintButton1 As ToolStripMenuItem
	Friend WithEvents PrintPreviewButton1 As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
	Friend WithEvents ExitButton1 As ToolStripMenuItem
	Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents SettingsButton1 As ToolStripMenuItem
	Friend WithEvents InfoButton1 As ToolStripMenuItem
	Friend WithEvents HelpButton1 As ToolStripMenuItem
	Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
	Friend WithEvents ChargeCodesButton1 As ToolStripMenuItem
	Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents AllEntiresToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents DaySummaryToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ToolTip1 As ToolTip
	Friend WithEvents ToolStripSeparator13 As ToolStripSeparator
	Friend WithEvents RefreshButton1 As ToolStripMenuItem
	Friend WithEvents ToolStrip2 As ToolStrip
	Friend WithEvents BackButton1 As ToolStripButton
	Friend WithEvents WeekComboBox As ToolStripComboBox
	Friend WithEvents ForwardButton1 As ToolStripButton
	Friend WithEvents RefreshButton3 As ToolStripButton
	Friend WithEvents ToolStripSeparator14 As ToolStripSeparator
	Friend WithEvents TimesheetControl1 As TimesheetControl.TimesheetControl
	Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
	Friend WithEvents BackButton2 As ToolStripMenuItem
	Friend WithEvents ForwardButton2 As ToolStripMenuItem
	Friend WithEvents DaySeparator As ToolStripSeparator
	Friend WithEvents DayComboBox As ToolStripComboBox
	Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
