Imports System.ComponentModel
Imports System.ComponentModel.TypeConverter

Public Class BooleanTypeConverter
	Inherits BooleanConverter

	Public Overrides Function GetStandardValuesSupported(context As ITypeDescriptorContext) As Boolean
		Return True
	End Function

	Public Overrides Function GetStandardValues(context As ITypeDescriptorContext) As StandardValuesCollection
		Return New StandardValuesCollection(New Boolean() {True, False})
	End Function

	Public Overrides Function GetStandardValuesExclusive(context As ITypeDescriptorContext) As Boolean
		Return True
	End Function
End Class