Imports System.ComponentModel
Imports System.Drawing.Design

' the same color editor, except the value is converted to ARGB
Friend Class ColorEditor
	Inherits UITypeEditor

	Public Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
		Return UITypeEditorEditStyle.Modal
	End Function

	Public Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
		Dim colorDialog As New ColorDialog()

		If value IsNot Nothing Then
			colorDialog.Color = CType(value, Color)
		End If
		If colorDialog.ShowDialog() = DialogResult.OK Then
			Return colorDialog.Color.ToArgb()
		End If
		Return value
	End Function

	Public Overrides Function GetPaintValueSupported(context As ITypeDescriptorContext) As Boolean
		Return True
	End Function

	Public Overrides Sub PaintValue(e As PaintValueEventArgs)
		Dim color As Color = e.Value
		Using brush As New SolidBrush(color)
			e.Graphics.FillRectangle(brush, e.Bounds)
		End Using
	End Sub

	Public Overloads Function GetPaintValueSupported() As Boolean
		Return True
	End Function

	Public Overrides Function ToString() As String
		Return "ColorEditor"
	End Function


End Class
