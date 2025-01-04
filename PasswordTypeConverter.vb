Imports System.ComponentModel

Public Class PasswordTypeConverter
	Inherits StringConverter

	Public Overrides Function CanConvertFrom(context As ITypeDescriptorContext, sourceType As Type) As Boolean
		Return sourceType = GetType(String)
	End Function

	Public Overrides Function ConvertTo(context As ITypeDescriptorContext, culture As Globalization.CultureInfo, value As Object, destinationType As Type) As Object
		If destinationType Is GetType(String) Then
			Return New String("•"c, value.ToString().Length)
		End If
		Return MyBase.ConvertTo(context, culture, value, destinationType)
	End Function
End Class