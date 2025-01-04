Imports System.ComponentModel
Imports System.Drawing.Design

Public Class DynamicPropertyDescriptor
	Inherits PropertyDescriptor

	Private propType As Type
	Private propValue As Object
	Private propDefaultValue As Object
	Private propDescription As String
	Private propCategory As String
	Private propConverter As TypeConverter
	Private propEditor As UITypeEditor
	Private propRestartRequired As String

	Public Sub New(name As String, propType As Type, description As String, value As Object, defaultValue As Object, category As String, restartRequired As String)
		MyBase.New(name, Nothing)
		Me.propType = propType
		Me.propValue = value
		Me.propDescription = description
		Me.propCategory = category
		Me.propRestartRequired = restartRequired
		Me.propDefaultValue = defaultValue

		' Assign custom type converter and editor based on property type
		If propType Is GetType(Boolean) Then
			Me.propConverter = New BooleanTypeConverter()
			'ElseIf propType Is GetType(Integer) OrElse propType Is GetType(Double) Then
			'	Me.propEditor = New NumericUpDownEditor()
		End If

		If propType Is GetType(DayOfWeek) Then
			Me.propEditor = New DaySelectorDropDown()
		End If

		If propType Is GetType(System.Drawing.Color) Then
			Me.propEditor = New ColorEditor()
		End If

		If name.ToLower().Contains("password") Then
			Me.propConverter = New PasswordTypeConverter()
		End If
	End Sub

	Public Overrides ReadOnly Property ComponentType As Type
		Get
			Return GetType(DynamicConfig)
		End Get
	End Property

	Public Overrides ReadOnly Property IsReadOnly As Boolean
		Get
			Return False
		End Get
	End Property

	Public Overrides ReadOnly Property PropertyType As Type
		Get
			Return propType
		End Get
	End Property

	Public Overrides Function CanResetValue(component As Object) As Boolean
		If propValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(propDefaultValue) Then
			If propType = GetType(System.DayOfWeek) Then
				Return Not propValue.Equals([Enum].Parse(GetType(DayOfWeek), propDefaultValue))
			Else
				Return Not propValue = propDefaultValue
			End If
		Else
			Return False
		End If
	End Function

	Public Overrides Function GetValue(component As Object) As Object
		Return propValue
	End Function

	Public ReadOnly Property DefaultValue As Object
		Get
			Return propDefaultValue
		End Get
	End Property

	Public Overrides Sub ResetValue(component As Object)
		propValue = propDefaultValue
	End Sub

	Public Overrides Sub SetValue(component As Object, value As Object)
		propValue = value
	End Sub

	Public Overrides Function ShouldSerializeValue(component As Object) As Boolean
		Return True
	End Function

	Public Overrides ReadOnly Property Description As String
		Get
			Return propDescription
		End Get
	End Property

	Public Overrides ReadOnly Property Category As String
		Get
			Return propCategory
		End Get
	End Property

	Public ReadOnly Property RestartRequired As String
		Get
			Return propRestartRequired
		End Get
	End Property

	Public Overrides ReadOnly Property Converter As TypeConverter
		Get
			Return If(propConverter, MyBase.Converter)
		End Get
	End Property

	Public Overrides Function GetEditor(editorBaseType As Type) As Object
		Return If(propEditor, MyBase.GetEditor(editorBaseType))
	End Function
End Class