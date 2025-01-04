Imports System.ComponentModel

Public Class DynamicConfig
	Implements ICustomTypeDescriptor


	Private properties As New Dictionary(Of String, DynamicPropertyDescriptor)
	Private keyMap As New Dictionary(Of String, String)

	Public Sub New(configDictionary As Dictionary(Of String, String()))
		For Each key As String In configDictionary.Keys
			Dim parts As String() = configDictionary(key)
			If parts.Length < 6 Then Continue For
			keyMap.Add(parts(1), key)
		Next
	End Sub

	Public Sub AddProperty(group As String, displayName As String, description As String, value As String, defaultValue As String, dataType As String, restartRequired As String)
		Dim propType As Type = Nothing
		If dataType.ToLower = "system.drawing.color" Then
			propType = GetType(System.Drawing.Color)
		Else
			propType = Type.GetType(dataType)
		End If
		Dim propValue As Object = Nothing
		If propType = GetType(DayOfWeek) Then
			propValue = [Enum].Parse(GetType(DayOfWeek), value)
		ElseIf propType = GetType(System.Drawing.Color) Then
			propValue = System.Drawing.Color.FromArgb(255, Color.FromArgb(value))
		Else
			propValue = Convert.ChangeType(value, propType)
		End If


		Dim prop As New DynamicPropertyDescriptor(displayName, propType, description, propValue, defaultValue, group, restartRequired)
		properties.Add(displayName, prop)
	End Sub


	Public Function GetKeyByPropertyName(propertyName As String) As String
		If keyMap.ContainsKey(propertyName) Then
			Return keyMap(propertyName)
		End If
		Return Nothing
	End Function

	Public Function GetDefaultValueByPropertyName(propertyName As String) As Object
		If properties.ContainsKey(propertyName) Then
			Return properties(propertyName).DefaultValue
		End If
		Return Nothing
	End Function

	Public Function GetAttributes() As AttributeCollection Implements ICustomTypeDescriptor.GetAttributes
		Return AttributeCollection.Empty
	End Function

	Public Function GetClassName() As String Implements ICustomTypeDescriptor.GetClassName
		Return Me.GetType().Name
	End Function

	Public Function GetComponentName() As String Implements ICustomTypeDescriptor.GetComponentName
		Return Me.GetType().Name
	End Function

	Public Function GetConverter() As TypeConverter Implements ICustomTypeDescriptor.GetConverter
		Return Nothing
	End Function

	Public Function GetDefaultEvent() As EventDescriptor Implements ICustomTypeDescriptor.GetDefaultEvent
		Return Nothing
	End Function

	Public Function GetDefaultProperty() As PropertyDescriptor Implements ICustomTypeDescriptor.GetDefaultProperty
		Return Nothing
	End Function

	Public Function GetEditor(editorBaseType As Type) As Object Implements ICustomTypeDescriptor.GetEditor
		Return Nothing
	End Function

	Public Function GetEvents() As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
		Return EventDescriptorCollection.Empty
	End Function

	Public Function GetEvents(attributes() As Attribute) As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
		Return EventDescriptorCollection.Empty
	End Function

	Public Function GetProperties() As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
		Return New PropertyDescriptorCollection(properties.Values.ToArray())
	End Function

	Public Function GetProperties(attributes() As Attribute) As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
		Return GetProperties()
	End Function

	Public Function GetPropertyOwner(pd As PropertyDescriptor) As Object Implements ICustomTypeDescriptor.GetPropertyOwner
		Return Me
	End Function
End Class