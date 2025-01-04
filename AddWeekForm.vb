Public Class AddWeekForm

	Public Shared Function SelectTargetDate(year As Integer, weeknumber As Integer) As Date
		Dim frm As New AddWeekForm
		frm.WeekNumber.Value = weeknumber
		frm.Year.Value = year
		frm.TargetDate.Value = GetFirstDayOfWorkWeek(year, weeknumber, Config.Properties.WeekStartDay)
		frm.SelectWeekNumberRadio.Checked = True
		If frm.ShowDialog() = DialogResult.OK Then
			If frm.SelectDateRadio.Checked Then
				Return GetFirstDayOfWorkWeek(frm.TargetDate.Value)
			Else
				Return GetFirstDayOfWorkWeek(frm.Year.Value, frm.WeekNumber.Value, Config.Properties.WeekStartDay)
			End If
		Else
			Return Nothing
		End If

	End Function

	Private Sub AddButton_Click(sender As Object, e As EventArgs) Handles AddButton.Click
		DialogResult = DialogResult.OK
	End Sub

	Private Sub CancelButton1_Click(sender As Object, e As EventArgs) Handles CancelButton1.Click
		DialogResult = DialogResult.Cancel
	End Sub

	Private Sub SelectDateRadio_CheckedChanged(sender As Object, e As EventArgs) Handles SelectDateRadio.CheckedChanged, SelectWeekNumberRadio.CheckedChanged
		If SelectDateRadio.Checked Then
			WeekNumber.Enabled = False
			Year.Enabled = False
			TargetDate.Enabled = True
		Else
			WeekNumber.Enabled = True
			Year.Enabled = True
			TargetDate.Enabled = False
		End If
	End Sub

	Private Sub WeekNumber_mousewheel(sender As NumericUpDown, e As HandledMouseEventArgs) Handles WeekNumber.MouseWheel, Year.MouseWheel
		e.Handled = True
		If e.Delta > 0 Then
			sender.UpButton()
		Else
			sender.DownButton()
		End If

	End Sub

	Private Sub Year_ValueChanged(sender As Object, e As EventArgs) Handles Year.ValueChanged
		If YearContainsWeek53(Year.Value) Then
			WeekNumber.Maximum = 53
			If WeekNumber.Value = 52 Then WeekNumber.Value = 53
		Else
			If WeekNumber.Value = 53 Then WeekNumber.Value = 52
			WeekNumber.Maximum = 52
		End If
	End Sub
End Class