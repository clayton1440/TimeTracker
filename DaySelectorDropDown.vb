Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms.Design

Public Class DaySelectorDropDown
	Inherits UITypeEditor

	Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
		Return UITypeEditorEditStyle.DropDown
	End Function

	Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
		Dim editorService As IWindowsFormsEditorService = CType(provider.GetService(GetType(IWindowsFormsEditorService)), IWindowsFormsEditorService)
		If editorService IsNot Nothing Then
			Dim daySelector As New DaySelector()
			daySelector.Day = CType(value, DayOfWeek)
			editorService.DropDownControl(daySelector)
			Return daySelector.Day
		End If
		Return value
	End Function


End Class

Public Class DaySelector
	Inherits UserControl

	Private days As String() = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
	Private comboBox As New ComboBox()

	Public Sub New()
		comboBox.DropDownStyle = ComboBoxStyle.DropDownList
		comboBox.Items.AddRange(days)
		Controls.Add(comboBox)
	End Sub

	Public Property Day As DayOfWeek
		Get
			Return CType(comboBox.SelectedIndex, DayOfWeek)
		End Get
		Set(value As DayOfWeek)
			comboBox.SelectedIndex = CInt(value)
		End Set
	End Property

End Class
