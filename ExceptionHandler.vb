
Public Class ExceptionHandler
    Public ThisException As Exception
    Private Sub New(ex As Exception)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ThisException = ex
        DialogResult = DialogResult.Abort
        TextBox1.Text = ThisException.Message & vbCrLf & vbCrLf & ThisException.StackTrace


    End Sub

    Public Shared Function DisplayException(ex As Exception) As DialogResult
        Dim frm As New ExceptionHandler(ex)
        Return frm.ShowDialog()
    End Function

    Private Sub SendExceptionButton_Click(sender As Object, e As EventArgs) Handles SendExceptionButton.Click
        Dim t As String = TextBox1.Text & vbCrLf & vbCrLf & $"Version: {My.Application.Info.Version}"
        't = t.Replace(vbCrLf, "%0D%0A").Replace(vbCr, "%0D%0A").Replace(vbLf, "%0D%0A")
        t = Uri.EscapeDataString(t)

        Process.Start($"mailto:TimeTracker@claytongross.net?Subject=Unhandled%20Exception&Body={t}")
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.DialogResult = DialogResult.Retry
        Me.Close()
    End Sub

    Private Sub ContinueButton_Click(sender As Object, e As EventArgs) Handles ContinueButton.Click
        Me.DialogResult = DialogResult.Ignore
        Me.Close()
    End Sub



End Class