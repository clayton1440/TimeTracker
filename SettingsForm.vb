Imports System.ComponentModel
Imports System.IO
Imports System.Reflection

Public Class SettingsForm

	'Public IsAdmin As Boolean = False
	Private _displayScale As Double = DisplayScale(Me)


	'Shared ListenerThread As Thread

	Shared Function DisplayScale(Form As Object) As Double
		Dim graphics As Graphics = Form.CreateGraphics()
		Dim DpiX As Single = graphics.DpiX
		Dim DpiY As Single = graphics.DpiY
		Dim ScaleX As Double = DpiX / 96.0
		Dim ScaleY As Double = DpiY / 96.0

		Return ScaleX
	End Function 'returns the scale of the display. 150% = 1.5

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

		StatusStrip1.ImageScalingSize = New Size(Math.Round(StatusStrip1.ImageScalingSize.Width * _displayScale), Math.Round(StatusStrip1.ImageScalingSize.Height * _displayScale))


		LoadConfig()
		SetPropertyGridColumnWidth(PropertyGrid1, Math.Round(_displayScale * 190))


	End Sub


	Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing


	End Sub



	Private Sub LoadConfig()
		ConfigWatcher.EnableRaisingEvents = False

		Dim ConfigDictionary As Dictionary(Of String, String())
		'Dim ConfigGroups As List(Of String)

		ConfigDictionary = Config.CreateDictionary(Config.ReadConfig())
		'ConfigGroups = GetConfigGroups(ConfigDictionary)

		Dim CfgView As PropertyGrid = PropertyGrid1

		' Create a dynamic object to hold the properties
		Dim configObject As New DynamicConfig(ConfigDictionary)

		' Populate the dynamic object with properties from the dictionary
		For Each key As String In ConfigDictionary.Keys
			Dim parts As String() = ConfigDictionary(key)
			If parts.Length < 6 Then Continue For
			Dim value As String = parts(0)
			Dim displayName As String = parts(1)
			Dim group As String = parts(2)
			Dim defaultValue As String = parts(3)
			Dim dataType As String = parts(4)
			Dim restartRequired As String = parts(5)

			Dim description As String = ""
			If parts.Length > 6 Then
				For i = 6 To parts.Length - 1
					description &= parts(i) & vbCrLf
				Next
			End If
			description = description.TrimEnd(vbCrLf)

			configObject.AddProperty(group, displayName, description, value, defaultValue, dataType, restartRequired)
		Next

		' Assign the dynamic object to the PropertyGrid
		CfgView.SelectedObject = configObject

		' Allow FileSystemWatcher to raise events
		ConfigWatcher.Path = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\"
		ConfigWatcher.Filter = $"{My.Application.Info.AssemblyName}.cfg"
		ConfigWatcher.EnableRaisingEvents = True

		' Handle the PropertyValueChanged event
		AddHandler CfgView.PropertyValueChanged, AddressOf PropertyGrid1_PropertyValueChanged
	End Sub

	Private Sub ConfigChangedExternally(sender As Object, e As FileSystemEventArgs) Handles ConfigWatcher.Changed
		ReloadConfigButton.Visible = True
	End Sub

	Private Sub ReloadConfigButton_Click(sender As Object, e As EventArgs) Handles ReloadConfigButton.ButtonClick
		LoadConfig()
		ReloadConfigButton.Visible = False
	End Sub

	Private Sub SetPropertyGridColumnWidth(pg As PropertyGrid, width As Integer)
		Dim gridViewField As FieldInfo = pg.GetType().GetField("gridView", BindingFlags.NonPublic Or BindingFlags.Instance)
		Dim gridView As Control = DirectCast(gridViewField.GetValue(pg), Control)
		Dim type As Type = gridView.[GetType]()
		Dim method As MethodInfo = type.GetMethod("MoveSplitterTo", BindingFlags.NonPublic Or BindingFlags.Instance)
		method.Invoke(gridView, New Object() {width})
	End Sub

	Private Sub PropertyGrid1_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
		Dim changedProp As DynamicPropertyDescriptor = e.ChangedItem.PropertyDescriptor
		Dim newValue As String
		If e.ChangedItem.Value.GetType Is GetType(System.Drawing.Color) Then
			Dim c As Color = CType(e.ChangedItem.Value, Color)
			newValue = c.ToArgb
		Else
			newValue = e.ChangedItem.Value.ToString()
		End If

		Dim configObject As DynamicConfig = DirectCast(PropertyGrid1.SelectedObject, DynamicConfig)

		' Update the configuration
		Dim key As String = configObject.GetKeyByPropertyName(changedProp.Name)


		ConfigWatcher.EnableRaisingEvents = False

		If key = "ShowNodeToolTips" Then
			Config.Properties.ShowNodeToolTips = newValue
		ElseIf key = "WeekStartDay" Then
			Config.Properties.WeekStartDay = e.ChangedItem.Value
		Else
			Config.WriteConfig(key, newValue)
		End If

		ConfigWatcher.EnableRaisingEvents = True

		' Check if a restart is required and set error accordingly
		If changedProp.RestartRequired.Equals("True", StringComparison.OrdinalIgnoreCase) Then
			'ServiceRestEP.SetError(StatusStrip1, "Service restart required.")
			ServiceRestartReqd.Visible = True
		End If
	End Sub


	Private Sub PropertyGrid1_Resize(sender As Object, e As EventArgs) Handles PropertyGrid1.Resize
		SetPropertyGridColumnWidth(PropertyGrid1, Math.Round(_displayScale * 190))
	End Sub

	Private Sub ShowConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowConsoleToolStripMenuItem.Click

	End Sub




	Private Function GetConfigGroups(ConfigDictionary As Dictionary(Of String, String())) As List(Of String)
		If ConfigDictionary Is Nothing Then Return Nothing
		Dim GroupList As New List(Of String)
		For Each cfg As KeyValuePair(Of String, String()) In ConfigDictionary
			If Not GroupList.Contains(cfg.Value(2).Trim(vbCr, vbLf, vbCrLf, vbTab, "!", " ")) Then GroupList.Add(cfg.Value(2).Trim(vbCr, vbLf, vbCrLf, vbTab, "!", " "))
		Next
		Return GroupList
	End Function

	Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles PropertiesContextMenu.Opening
		Dim grid As PropertyGrid = PropertyGrid1
		Dim selectedGridItem As GridItem = grid.SelectedGridItem

		' Check if the selected item can be reset
		If selectedGridItem IsNot Nothing AndAlso selectedGridItem.PropertyDescriptor IsNot Nothing Then
			Dim propDesc As DynamicPropertyDescriptor = selectedGridItem.PropertyDescriptor
			If propDesc.CanResetValue(selectedGridItem) Then
				Dim defaultValue As String = If(String.IsNullOrWhiteSpace(propDesc.DefaultValue), "N/A", propDesc.DefaultValue)
				ResetValueButton.Enabled = True
				ResetValueButton.ToolTipText = $"Default:
{defaultValue}"
			Else
				ResetValueButton.Enabled = False
				ResetValueButton.ToolTipText = Nothing
			End If
		Else
			ResetValueButton.Enabled = False
			ResetValueButton.ToolTipText = Nothing
		End If
	End Sub

	Private Sub ResetValueButton_Click(sender As Object, e As EventArgs) Handles ResetValueButton.Click
		Dim grid As PropertyGrid = PropertyGrid1
		Dim selectedGridItem As GridItem = grid.SelectedGridItem

		' Reset the selected property's value to its default
		If selectedGridItem IsNot Nothing AndAlso selectedGridItem.PropertyDescriptor IsNot Nothing Then
			selectedGridItem.PropertyDescriptor.ResetValue(selectedGridItem)
			Dim configObject As DynamicConfig = DirectCast(grid.SelectedObject, DynamicConfig)
			Dim key As String = configObject.GetKeyByPropertyName(selectedGridItem.Label)
			Dim defaultValue As String = configObject.GetDefaultValueByPropertyName(selectedGridItem.Label)

			ConfigWatcher.EnableRaisingEvents = False
			Config.WriteConfig(key, defaultValue)
			ConfigWatcher.EnableRaisingEvents = True

			' Check if a restart is required and set error accordingly
			Dim propDesc As DynamicPropertyDescriptor = selectedGridItem.PropertyDescriptor
			If propDesc.RestartRequired.Equals("True", StringComparison.OrdinalIgnoreCase) Then
				'ServiceRestEP.SetError(StatusStrip1, "Service restart required.")
				ServiceRestartReqd.Visible = True
			End If

			grid.Refresh() ' Refresh the PropertyGrid to reflect the reset value
		End If
	End Sub



	Private Sub ServerInterface_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
		If e.KeyCode = Keys.Menu Then
			MenuStrip1.Visible = Not MenuStrip1.Visible
		End If

		If e.KeyCode = Keys.F9 Then
			ShowConsoleToolStripMenuItem.PerformClick()
		End If
	End Sub

	Private Sub ServiceRestartReqd_Click(sender As Object, e As EventArgs) Handles ServiceRestartReqd.Click
		If MessageBox.Show("Restart TimeTracker?", "Restart Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Process.Start($"{My.Application.Info.DirectoryPath}\{My.Application.Info.AssemblyName}.exe")
			Application.Exit()
		End If
	End Sub
End Class

'Public Class Status
'	Public Const Stopped As Integer = 0 'neutral
'	Public Const Running As Integer = 1 'good
'	Public Const Warning As Integer = 2 'attention
'	Public Const ListenerError As Integer = 3 'error
'	Public Const ConfigError As Integer = 4 'noncompliant
'	Public Const Unbound As Integer = 5 'trusted
'	Public Const LicenseError As Integer = 6 'noncompliant
'End Class




'' Custom editor for numeric values
'Public Class NumericUpDownEditor
'	Inherits UITypeEditor

'	Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
'		Return UITypeEditorEditStyle.DropDown
'	End Function

'	Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
'		Dim editorService As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
'		If editorService IsNot Nothing Then
'			Dim numericUpDown As New NumericUpDown()
'			numericUpDown.Minimum = Integer.MinValue
'			numericUpDown.Maximum = Integer.MaxValue
'			numericUpDown.Value = Convert.ToDecimal(value)
'			AddHandler numericUpDown.ValueChanged, Sub(s, e) editorService.CloseDropDown()
'			editorService.DropDownControl(numericUpDown)
'			Return numericUpDown.Value
'		End If
'		Return value
'	End Function
'End Class