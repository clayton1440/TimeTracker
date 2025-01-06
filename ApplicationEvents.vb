Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
	' The following events are available for MyApplication:
	' Startup: Raised when the application starts, before the startup form is created.
	' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
	' UnhandledException: Raised if the application encounters an unhandled exception.
	' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
	' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
	Partial Friend Class MyApplication
		Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
			Dim dr As DialogResult = ExceptionHandler.DisplayException(e.Exception)
			If dr = DialogResult.Ignore Then
				e.ExitApplication = False
			ElseIf dr = DialogResult.Abort Then
				e.ExitApplication = True
			ElseIf dr = DialogResult.Retry Then
				e.ExitApplication = True
				Process.Start($"{My.Application.Info.DirectoryPath}\{My.Application.Info.AssemblyName}.exe")
			Else
				e.ExitApplication = True
			End If
		End Sub
	End Class
End Namespace
