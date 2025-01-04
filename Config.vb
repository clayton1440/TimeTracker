Imports System.Environment
Imports System.IO

Public Class Config
	Public Class Properties
		Public Shared Property DatabasePath As String
			Get
				Dim value As String = ReadConfig("DatabasePath").ToString.Trim(""""c, "'"c, vbCrLf, vbCr, vbLf, " "c)
				If String.IsNullOrWhiteSpace(value) OrElse value = "%" Then
					value = $"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}.db"
				End If
				Return value
			End Get
			Set(value As String)
				WriteConfig("DatabasePath", value)
			End Set
		End Property

		Public Shared Property BackupDays As Integer
			Get
				Return CType(ReadConfig("BackupDays"), Integer)
			End Get
			Set(value As Integer)
				WriteConfig("BackupDays", value.ToString)
			End Set
		End Property

		Public Shared Property StartMaximized As Boolean
			Get
				Return CType(ReadConfig("StartMaximized"), Boolean)
			End Get
			Set(value As Boolean)
				WriteConfig("StartMaximized", value.ToString)
			End Set
		End Property

		Public Shared Property FontSize As Integer
			Get
				Return CType(ReadConfig("FontSize"), Integer)
			End Get
			Set(value As Integer)
				WriteConfig("FontSize", value.ToString)
			End Set
		End Property

		Public Shared Property RowHeight As Integer
			Get
				Return CType(ReadConfig("RowHeight"), Integer)
			End Get
			Set(value As Integer)
				WriteConfig("RowHeight", value.ToString)
			End Set
		End Property

		Public Shared Event ShowNodeToolTipsValueChanged As EventHandler
		Public Shared Property ShowNodeToolTips As Boolean
			Get
				Return CType(ReadConfig("ShowNodeToolTips"), Boolean)
			End Get
			Set(value As Boolean)
				WriteConfig("ShowNodeToolTips", value.ToString)
				RaiseEvent ShowNodeToolTipsValueChanged(Nothing, New EventArgs())
			End Set
		End Property

		Public Shared Property FormHeight As Integer
			Get
				Return CType(ReadConfig("FormHeight"), Integer)
			End Get
			Set(value As Integer)
				WriteConfig("FonFormHeighttSize", value.ToString)
			End Set
		End Property

		Public Shared Property FormWidth As Integer
			Get
				Return CType(ReadConfig("FormWidth"), Integer)
			End Get
			Set(value As Integer)
				WriteConfig("FormWidth", value.ToString)
			End Set
		End Property

		Public Shared Property FormX As Integer
			Get
				Return CType(ReadConfig("FormX"), Integer)
			End Get
			Set(value As Integer)
				WriteConfig("FormX", value.ToString)
			End Set
		End Property

		Public Shared Property FormY As Integer
			Get
				Return CType(ReadConfig("FormY"), Integer)
			End Get
			Set(value As Integer)
				WriteConfig("FormY", value.ToString)
			End Set
		End Property

		Public Shared Property FormSize As Size
			Get
				Return New Size(CType(ReadConfig("FormWidth"), Integer), CType(ReadConfig("FormHeight"), Integer))
			End Get
			Set(value As Size)
				WriteConfig("FormHeight", value.Height.ToString)
				WriteConfig("FormWidth", value.Width.ToString)
			End Set
		End Property

		Public Shared Property FormLocation As Point
			Get
				Return New Point(CType(ReadConfig("FormX"), Integer), CType(ReadConfig("FormY"), Integer))
			End Get
			Set(value As Point)
				WriteConfig("FormX", value.X.ToString)
				WriteConfig("FormY", value.Y.ToString)
			End Set
		End Property



		'Public Shared Property HeaderBackColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("HeaderBackColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("HeaderBackColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property HeaderForeColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("HeaderForeColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("HeaderForeColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property EntryBackColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("EntryBackColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("EntryBackColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property EntryForeColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("EntryForeColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("EntryForeColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property DayBarrierBackColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("DayBarrierBackColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("DayBarrierBackColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property DayBarrierForeColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("DayBarrierForeColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("DayBarrierForeColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property TodayBarrierBackColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("TodayBarrierBackColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("TodayBarrierBackColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property TodayBarrierForeColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("TodayBarrierForeColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("TodayBarrierForeColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property TotalBackColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("TotalBackColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("TotalBackColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property TotalForeColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("TotalForeColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("TotalForeColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		'Public Shared Property BorderColor As Color
		'	Get
		'		Return Color.FromArgb(255, Color.FromArgb(CType(ReadConfig("BorderColor"), Integer)))
		'	End Get
		'	Set(value As Color)
		'		WriteConfig("BorderColor", value.ToArgb.ToString)
		'	End Set
		'End Property

		Public Shared Event WeekStartDayChanged As EventHandler
		Public Shared Property WeekStartDay As DayOfWeek
			Get
				Dim d As String = ReadConfig("WeekStartDay")
				If d = "Sunday" Then
					Return DayOfWeek.Sunday
				ElseIf d = "Monday" Then
					Return DayOfWeek.Monday
				ElseIf d = "Tuesday" Then
					Return DayOfWeek.Tuesday
				ElseIf d = "Wednesday" Then
					Return DayOfWeek.Wednesday
				ElseIf d = "Thursday" Then
					Return DayOfWeek.Thursday
				ElseIf d = "Friday" Then
					Return DayOfWeek.Friday
				Else
					Return DayOfWeek.Saturday
				End If
			End Get
			Set(value As DayOfWeek)
				WriteConfig("WeekStartDay", value.ToString)
				RaiseEvent WeekStartDayChanged(Nothing, New EventArgs)
			End Set
		End Property


	End Class


	Public Shared Function ReadConfig(Optional Key As String = "")
		Console.WriteLine($"ReadConfig: {Key}")

		Dim ConfigString = File.ReadAllText($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}.cfg")
		If Key = "" OrElse Key.ToLower = "fullconfigstring" Then
			Return ConfigString
			Exit Function
		End If

		Dim ConfigTemp() = ConfigString.Split(vbCrLf)
		Dim KeyValue As String = ""
		For i = 0 To ConfigTemp.Length() - 1
			ConfigTemp(i) = ConfigTemp(i).Trim(vbCrLf, vbCr, vbLf)
			If ConfigTemp(i).StartsWith($"{Key}=") Then
				KeyValue = ConfigTemp(i).Substring(ConfigTemp(i).IndexOf("=") + 1)
				Exit For
			End If
		Next

		KeyValue = KeyValue.Trim(vbCrLf, vbCr, vbLf, " ")
		Return KeyValue
	End Function

	Public Shared Sub Create()
		Console.WriteLine($"Create Config")

		If Not File.Exists($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}.cfg") Then
			IO.Directory.CreateDirectory($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}")
			IO.File.WriteAllText($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}.cfg", My.Resources.DefaultConfig)
		End If
	End Sub

	Public Shared Sub Update()
		Console.WriteLine($"Update Config")

		If File.Exists($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}.cfg") Then
			Dim existingValues As Dictionary(Of String, String()) = CreateDictionary(File.ReadAllText($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}.cfg"))
			Dim defaultValues As Dictionary(Of String, String()) = CreateDictionary(My.Resources.DefaultConfig)

			If existingValues.Count <> defaultValues.Count Then
				File.WriteAllText($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}_temp.cfg", My.Resources.DefaultConfig)
				For Each key As String In existingValues.Keys
					WriteConfig($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}_temp.cfg", key, existingValues(key)(0))
				Next
				File.Copy($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}_temp.cfg", $"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}.cfg", True)
				File.Delete($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}_temp.cfg")
			End If
		Else
			Create()
		End If
	End Sub

	Private Shared Function CountKeys(ConfigText As String) As Integer
		Dim ConfigLines As String() = ConfigText.Split(vbCrLf)
		Dim Count As Integer = 0
		For Each Line As String In ConfigLines
			If Line.Contains("=") And Not Line.StartsWith("!") Then Count += 1
		Next
		Return Count
	End Function

	Shared Function WriteConfig(Key As String, NewValue As String) As Boolean
		Return WriteConfig($"{GetFolderPath(SpecialFolder.ApplicationData)}\{My.Application.Info.AssemblyName}\{My.Application.Info.AssemblyName}.cfg", Key, NewValue)
	End Function

	Private Shared Function WriteConfig(FilePath As String, Key As String, NewValue As String) As Boolean
		Console.WriteLine($"WriteConfig: {Key}={NewValue}")

		Dim Success As Boolean = False
		If File.Exists(FilePath) Then
			Dim ConfigString = File.ReadAllText(FilePath)
			Dim ConfigTemp() = ConfigString.Split(vbCrLf) 'disassemble config string into a parsable list

			For i = 0 To ConfigTemp.Length() - 1
				If ConfigTemp(i).Contains(Key) And Not ConfigTemp(i).StartsWith("!") Then
					Dim OldValue As String = ConfigTemp(i).Substring(ConfigTemp(i).IndexOf("=") + 1)
					ConfigTemp(i) = ConfigTemp(i).Substring(0, ConfigTemp(i).IndexOf("=") + 1) & NewValue 'if this key/value pair contains the correct key and is not a comment, replace the old value with the new value
				End If
			Next
			ConfigString = ""
			For i = 0 To ConfigTemp.Length() - 1
				ConfigTemp(i) = ConfigTemp(i).Trim(vbCrLf, vbCr, vbLf, " ")

				ConfigString &= ConfigTemp(i) & vbCrLf 'reassemble config string to write back to config file.
			Next

			ConfigString = ConfigString.Trim(vbCrLf, vbCr, vbLf, " ")

			Dim ConfigVerify() As String = ConfigString.Split(vbCrLf) 'disassemble reassembled config string again to verify that the key was changed
			'GoTo Test1
			For i = 0 To ConfigVerify.Length() - 1
				If ConfigVerify(i).Contains(Key) And Not ConfigTemp(i).StartsWith("!") Then
					If ConfigVerify(i).Substring(ConfigVerify(i).IndexOf("=") + 1) = NewValue Then 'value was changed
						File.Delete(FilePath) 'delete the old config
						My.Computer.FileSystem.WriteAllText(FilePath, ConfigString, False) 'write the new config back 
						Success = True
						Exit For
					End If
				End If
			Next
		End If
		Return Success
	End Function

	''' <summary>
	''' Creates a Dictionary from the specified config file to be used in the interactive options interface.
	''' </summary>
	''' <param name="FullConfigString">The full text of the config file, with correct formatting.</param>
	''' <returns></returns>
	Public Shared Function CreateDictionary(FullConfigString As String) As Dictionary(Of String, String())
		'Key       = Key
		'Value(0)  = Value
		'Value(1)  = Display Name
		'Value(2)  = Key Group
		'Value(3)  = Default Value
		'Value(4)  = Data Type
		'Value(5)  = Restart Required (Listener, Service, or empty string
		'Value(>=6) = Description (can use multiple lines)
		';
		'

		Dim ConfigDict As New Dictionary(Of String, String())
		Dim ConfigLines As String() = FullConfigString.Split(New String(";").ToCharArray, StringSplitOptions.RemoveEmptyEntries)

		For Each entry As String In ConfigLines
			'split each entry in the config by line
			Dim Parts As String() = entry.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)

			'skip entry if is a comment or not correct format.
			If Parts(0).StartsWith("!") Or Not Parts(0).Contains("=") Then Continue For

			'split Parts(0) into a distinct key and value.
			Dim Key As String = Parts(0).Substring(0, Parts(0).IndexOf("="))
			Dim Value As String = Parts(0).Substring(Parts(0).IndexOf("=") + 1, Parts(0).Length - (Parts(0).IndexOf("=") + 1))

			'trim the key and value
			Key = Key.Trim(vbCr, vbLf, vbCrLf, vbTab, "!", " ")
			Value = Value.Trim(vbCr, vbLf, vbCrLf, vbTab, "!", " ")

			'set Part(0) back as the value only. 
			Parts(0) = Value

			'trim all the parts of whitespace, line feeds, bangs, etc.
			For i = 1 To Parts.Count - 1
				Dim TrimmedPart As String = Parts(i).Trim(vbCr, vbLf, vbCrLf, vbTab, "!", " ")
				Parts(i) = TrimmedPart
			Next

			'add the entry to the dictionary.
			ConfigDict.Add(Key, Parts)
		Next

		Return ConfigDict
	End Function
End Class