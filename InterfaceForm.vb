

Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class InterfaceForm

	Private Function DisplayScale() As Double
		Dim scale As Double = 1.0
		Dim graphics As Graphics = Me.CreateGraphics()
		Dim DpiX As Single = graphics.DpiX
		Dim ScaleX As Double = DpiX / 96

		Return ScaleX
	End Function
	Private Function NewSizeFromScale(SizeInput As Size) As Size
		Return New Size(Math.Round(SizeInput.Width * DisplayScale()), Math.Round(SizeInput.Height * DisplayScale()))
	End Function

	Private Function ResizeToDefault(ScaledInput As Size) As Size
		Return New Size(Math.Round(ScaledInput.Width / DisplayScale()), Math.Round(ScaledInput.Height / DisplayScale()))
	End Function

	''' <summary>
	''' Checks if the proposed location is valid for the current screen.
	''' </summary>
	''' <param name="ProposedLocation"></param>
	''' <param name="Size"></param>
	''' <returns>True if the entire form can fit in the proposed location on the screen. Checks all screens, not just primary.</returns>
	Private Function FormLocationIsValid(ProposedLocation As Point, Size As Size) As Boolean
		Dim ProposedRectangle As New Rectangle(ProposedLocation, Size)
		For Each screen As Screen In Screen.AllScreens
			If screen.WorkingArea.Contains(New Point(ProposedRectangle.Left, ProposedRectangle.Top)) And
					screen.WorkingArea.Contains(New Point(ProposedRectangle.Right, ProposedRectangle.Bottom)) Then
				Return True
			End If
			'If screen.WorkingArea.IntersectsWith(ProposedRectangle) Then
			'	Return True
			'End If
		Next
		Return False
	End Function

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Config.Create()
		Config.Update()
		Database.Create()
		Database.Update()

		ToolStrip2.ImageScalingSize = NewSizeFromScale(New Drawing.Size(16, 16))
		MenuStrip1.ImageScalingSize = NewSizeFromScale(New Drawing.Size(16, 16))
		Me.Size = NewSizeFromScale(Config.Properties.FormSize)
		Dim fLoc As Point = Config.Properties.FormLocation
		If FormLocationIsValid(fLoc, Me.Size) Then
			Me.StartPosition = FormStartPosition.Manual
			Me.Location = fLoc
		Else
			Me.StartPosition = FormStartPosition.CenterScreen
		End If

		moveTimer.Interval = 500
		moveTimer.AutoReset = False
		Me.MinimumSize = NewSizeFromScale(Me.MinimumSize)
		SplitContainer2.SplitterDistance = Math.Round(150 * DisplayScale())
		WeekComboBox.Width = Math.Round(110 * DisplayScale())
		DayComboBox.Width = Math.Round(110 * DisplayScale())
		TimesheetControl1.RowHeight = Math.Round(Config.Properties.RowHeight * DisplayScale())
		Me.Font = New Font("Tahoma", Config.Properties.FontSize, FontStyle.Regular)

		If Config.Properties.StartMaximized Then
			WindowState = FormWindowState.Maximized
		End If

		LoadTreeView()
		LoadSelectedEntries()

		AddHandler Config.Properties.ShowNodeToolTipsValueChanged, AddressOf SetToolTipConfig
		AddHandler Config.Properties.WeekStartDayChanged, AddressOf RefreshButton_Click
		AddHandler ChargeCodeReference.ChargeCodesChanged, AddressOf ReloadChargeCodes
		AddHandler moveTimer.Elapsed, AddressOf SaveFormLocation
	End Sub


#Region "Form Events"

	Private Sub InterfaceForm_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
		If Me.WindowState = FormWindowState.Maximized Then Exit Sub
		Config.Properties.FormSize = ResizeToDefault(Me.Size)
	End Sub

	Private moveTimer As New System.Timers.Timer
	Private Sub InterfaceForm_Move(sender As Object, e As EventArgs) Handles Me.Move
		moveTimer.Stop()
		moveTimer.Start()
	End Sub
	Private Sub SaveFormLocation()
		If Me.WindowState = FormWindowState.Maximized Then Exit Sub
		Config.Properties.FormLocation = Me.Location
		moveTimer.Stop()
	End Sub

	Private Sub NewTimeSheetEntryButton_Click(sender As Object, e As EventArgs) Handles NewTimeSheetEntryButton1.Click
		Dim latestYear As Integer = TreeView1.Nodes(TreeView1.Nodes.Count - 1).Tag
		Dim yNode As TreeNode = FindNode(latestYear.ToString)
		Dim latestWeek As Integer = yNode.Nodes(yNode.Nodes.Count - 1).Tag
		If latestWeek = 52 Then
			latestYear += 1
			latestWeek = 1
		Else
			latestWeek += 1
		End If
		Dim aDate As Date = Nothing
		If My.Computer.Keyboard.ShiftKeyDown Then
			aDate = GetFirstDayOfWorkWeek(latestYear, latestWeek, Config.Properties.WeekStartDay)
		Else
			aDate = AddWeekForm.SelectTargetDate(latestYear, latestWeek)
		End If
		If aDate <> Nothing Then
			Dim year As Integer = Timesheet.GetYear(aDate)
			Dim week As Integer = Timesheet.GetWeekNumber(aDate, Config.Properties.WeekStartDay)
			Dim tn As TreeNode = FindNode($"Week {week}, {year}")
			If tn Is Nothing Then
				Dim yearNode As TreeNode = FindNode(year.ToString)
				If yearNode Is Nothing Then
					yearNode = TreeView1.Nodes.Add(year.ToString)
					yearNode.Tag = year
				End If
				tn = yearNode.Nodes.Add($"Week {week}, {year}")
				tn.Tag = week
				tn.ToolTipText = $"{aDate:yyyy-MM-dd} - {aDate.AddDays(6):yyyy-MM-dd}"
				WeekComboBox.Items.Add(tn.Text)
			End If
			TreeView1.SelectedNode = tn
			WeekComboBox.SelectedItem = tn.Text
			selectedEntries = Timesheet.GetWorkWeekEntries(year, week)
			LoadSelectedEntries()
		End If
	End Sub

	Private Sub PrintButton1_Click(sender As Object, e As EventArgs) Handles PrintButton1.Click

	End Sub

	Private Sub PrintPreviewButton1_Click(sender As Object, e As EventArgs) Handles PrintPreviewButton1.Click

	End Sub

	Private Sub ExitButton1_Click(sender As Object, e As EventArgs) Handles ExitButton1.Click
		Close()
	End Sub

	Private Sub SettingsButton1_Click(sender As Object, e As EventArgs) Handles SettingsButton1.Click
		SettingsForm.Show()
	End Sub

	Private Sub InfoButton1_Click(sender As Object, e As EventArgs) Handles InfoButton1.Click
		AboutBox1.Show()
	End Sub

	Private Sub HelpButton1_Click(sender As Object, e As EventArgs) Handles HelpButton1.Click
		Process.Start("https://www.claytongross.net/TimeTracker/help.html")
	End Sub
	Private Sub ChargeCodesButton1_Click(sender As Object, e As EventArgs) Handles ChargeCodesButton1.Click
		ChargeCodeReference.Show()
	End Sub
	Private Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton1.Click, RefreshButton3.Click
		Console.WriteLine("Refresh")
		Dim sWeek As String = WeekComboBox.SelectedItem
		TreeView1.Nodes.Clear()
		LoadTreeView()
		LoadSelectedEntries()
		TreeView1.SelectedNode = FindNode(sWeek)
	End Sub

	Private Sub BackButton1_Click(sender As Object, e As EventArgs) Handles BackButton1.Click, BackButton2.Click
		WeekComboBox.SelectedIndex = Math.Max(0, WeekComboBox.SelectedIndex - 1)
	End Sub

	Private Sub ForwardButton1_Click(sender As Object, e As EventArgs) Handles ForwardButton1.Click, ForwardButton2.Click
		WeekComboBox.SelectedIndex = Math.Min(WeekComboBox.Items.Count - 1, WeekComboBox.SelectedIndex + 1)
	End Sub

	Private autoselectingWeek As Boolean = False
	Private Sub WeekComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles WeekComboBox.SelectedIndexChanged
		If Not autoselectingWeek Then
			Dim node As TreeNode = FindNode(WeekComboBox.SelectedItem)
			If node IsNot Nothing Then TreeView1.SelectedNode = node
		End If
	End Sub

	Private Function FindNode(Text As String) As TreeNode
		For Each node As TreeNode In TreeView1.Nodes
			If node.Text = Text Then
				Return node
			End If
			For Each subNode As TreeNode In node.Nodes
				If subNode.Text = Text Then
					Return subNode
				End If
			Next
		Next
		Return Nothing
	End Function

	Private Sub SetToolTipConfig()

		TreeView1.ShowNodeToolTips = Config.Properties.ShowNodeToolTips
	End Sub


	Private Sub AllEntiresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllEntiresToolStripMenuItem.Click
		AllEntiresToolStripMenuItem.Checked = True
		DaySummaryToolStripMenuItem.Checked = False

		DaySeparator.Visible = False
		DayComboBox.Visible = False

		TimesheetControl1.SummaryView = False

		LoadSelectedEntries()
	End Sub

	Private Sub DaySummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaySummaryToolStripMenuItem.Click
		AllEntiresToolStripMenuItem.Checked = False
		DaySummaryToolStripMenuItem.Checked = True


		DaySeparator.Visible = True
		DayComboBox.Visible = True
		DayComboBox.SelectedItem = Date.Today.DayOfWeek.ToString

		TimesheetControl1.SummaryView = True

		LoadSelectedEntries()
	End Sub

	Dim selectedEntries As List(Of TimesheetEntry)
	Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
		If e.Node.Level = 1 Then
			Dim year As Integer = e.Node.Parent.Tag
			Dim week As Integer = e.Node.Tag

			selectedEntries = Timesheet.GetWorkWeekEntries(year, week)
			LoadSelectedEntries()

			autoselectingWeek = True
			WeekComboBox.SelectedItem = e.Node.Text
			autoselectingWeek = False
		End If
	End Sub
	Private Sub DayComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DayComboBox.SelectedIndexChanged
		TimesheetControl1.SummaryViewDay = DaysSinceStartDay(DayComboBox.SelectedIndex, TimesheetControl1.StartDate.DayOfWeek)
	End Sub

#End Region

	Private Sub LoadTreeView()
		Dim Years As List(Of Integer) = Timesheet.GetYears
		Dim selectNode As TreeNode = Nothing
		Dim weekStartDay As DayOfWeek = Config.Properties.WeekStartDay
		SetToolTipConfig()

		autoselectingWeek = True
		WeekComboBox.Items.Clear()

		For Each year As Integer In Years
			Dim yearNode As TreeNode = TreeView1.Nodes.Add(year.ToString)
			yearNode.Tag = year
			Dim Weeks As List(Of Integer) = Timesheet.GetWeeks(year)
			For Each week As Integer In Weeks
				Dim weekNode As TreeNode = yearNode.Nodes.Add($"Week {week}, {year}")
				Dim weekStart As Date = Timesheet.GetFirstDayOfWorkWeek(year, week, weekStartDay)
				weekNode.Tag = week
				weekNode.ToolTipText = $"{weekStart:d} - {weekStart.AddDays(6):d}"

				WeekComboBox.Items.Add(weekNode.Text)
				selectNode = weekNode
			Next
		Next

		'make sure today's week is present in the list even if there are no entries yet
		Dim today As Date = Date.Today
		Dim todayWeek As Integer = Timesheet.GetWeekNumber(today, weekStartDay)
		If todayWeek = 0 Then todayWeek = 52
		Dim todayYear As Integer = Timesheet.GetYear(today)

		If Not WeekComboBox.Items.Contains($"Week {todayWeek}, {todayYear}") Then
			Dim yearNode As TreeNode = FindNode(todayYear.ToString)
			selectNode = yearNode.Nodes.Add($"Week {todayWeek}, {todayYear}")
			Dim weekStart As Date = Timesheet.GetFirstDayOfWorkWeek(todayYear, todayWeek, weekStartDay)
			selectNode.Tag = todayWeek
			selectNode.ToolTipText = $"{weekStart:d} - {weekStart.AddDays(6):d}"

			WeekComboBox.Items.Add(selectNode.Text)
		End If



		If selectNode IsNot Nothing Then
			TreeView1.SelectedNode = selectNode
			WeekComboBox.SelectedItem = selectNode.Text
			selectedEntries = Timesheet.GetWorkWeekEntries(selectNode.Parent.Tag, selectNode.Tag)
		End If

		autoselectingWeek = False
	End Sub

	Private Sub LoadSelectedEntries()
		TimesheetControl1.StartDate = GetFirstDayOfWorkWeek(TreeView1.SelectedNode.Parent.Tag, TreeView1.SelectedNode.Tag, Config.Properties.WeekStartDay)
		ReloadChargeCodes()
		'TimeEntryControl1.Entries = selectedEntries
		TimesheetControl1.Clear()
		For Each entry As TimesheetEntry In selectedEntries
			TimesheetControl1.AddRow(entry.Day, entry.ChargeCode, entry.Comment, entry.StartTime, entry.EndTime, entry.Id)
		Next
	End Sub

	Private Sub ReloadChargeCodes()
		TimesheetControl1.ChargeCodes = GetChargeCodesEnumerable().ToList
	End Sub

	Private Sub TimesheetControl1_EntryAdded(sender As TimesheetControl.TimesheetControl, e As TimesheetControl.TimesheetEntryEventArgs) Handles TimesheetControl1.EntryAdded
		Dim te As New TimesheetEntry(e.Day, e.StartTime, e.EndTime, e.Comment, e.ChargeCode)
		Dim id As Integer = te.AddToDatabase
		te.Id = id
		e.Id = id
		selectedEntries.Add(te)
		Database.UpdateChargeCodes()
	End Sub

	Private Sub TimesheetControl1_EntryChanged(sender As TimesheetControl.TimesheetControl, e As TimesheetControl.TimesheetEntryEventArgs) Handles TimesheetControl1.EntryChanged
		Dim te As New TimesheetEntry(e.Day, e.StartTime, e.EndTime, e.Comment, e.ChargeCode, e.Id)
		Select Case e.ChangedColumn
			Case 0
				te.ChargeCode = e.ChargeCode
				Database.UpdateChargeCodes()
			Case 1
				te.Comment = e.Comment
			Case 2
				te.StartTime = e.StartTime
			Case 3
				te.EndTime = e.EndTime
			Case Else

		End Select
		For i = 0 To selectedEntries.Count - 1
			If selectedEntries(i).Id = te.Id Then
				selectedEntries(i) = te
				Exit For
			End If
		Next
	End Sub

	Private Sub TimesheetControl1_EntryDeleted(sender As TimesheetControl.TimesheetControl, e As TimesheetControl.TimesheetEntryEventArgs) Handles TimesheetControl1.EntryDeleted
		Dim te As New TimesheetEntry(e.Day, e.StartTime, e.EndTime, e.Comment, e.ChargeCode, e.Id)
		te.Delete()
		selectedEntries.Remove(te)
	End Sub

	Private Sub InterfaceForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
		Config.Properties.StartMaximized = Me.WindowState = FormWindowState.Maximized
	End Sub
End Class
