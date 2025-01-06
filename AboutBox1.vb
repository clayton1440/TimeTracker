Public NotInheritable Class AboutBox1

	Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Set the title of the form.
		Dim ApplicationTitle As String
		If My.Application.Info.Title <> "" Then
			ApplicationTitle = My.Application.Info.Title
		Else
			ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
		End If
		Me.Text = String.Format("About {0}", ApplicationTitle)
		' Initialize all of the text displayed on the About Box.
		' TODO: Customize the application's assembly information in the "Application" pane of the project 
		'    properties dialog (under the "Project" menu).
		Me.LabelProductName.Text = My.Application.Info.ProductName
		Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
		Me.LabelCopyright.Text = My.Application.Info.Copyright
		Me.TextBoxDescription.Text = My.Application.Info.Description
	End Sub

	Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
		Me.Close()
	End Sub

	Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
		Process.Start("mailto:TimeTracker@claytongross.net?subject=Support%20Request&body=Please%20provide%20details%20of%20your%20support%20request%20here.")
	End Sub

	Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
		Process.Start("mailto:TimeTracker@claytongross.net?subject=Feature%20Request&body=Please%20provide%20details%20of%20your%20feature%20request%20here.")
	End Sub
End Class
