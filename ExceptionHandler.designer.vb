<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExceptionHandler
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExceptionHandler))
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ContinueButton = New System.Windows.Forms.Button()
		Me.ExitButton = New System.Windows.Forms.Button()
		Me.SendExceptionButton = New System.Windows.Forms.Button()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.SuspendLayout()
		'
		'TextBox1
		'
		Me.TextBox1.Location = New System.Drawing.Point(12, 56)
		Me.TextBox1.Multiline = True
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.ReadOnly = True
		Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.TextBox1.Size = New System.Drawing.Size(584, 140)
		Me.TextBox1.TabIndex = 4
		Me.TextBox1.TabStop = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(382, 39)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "An unexpected error has occurred." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click 'Restart' to restart TimeTracker, or c" &
	"lick 'Continue' to ignore this exception."
		'
		'ContinueButton
		'
		Me.ContinueButton.DialogResult = System.Windows.Forms.DialogResult.Ignore
		Me.ContinueButton.Location = New System.Drawing.Point(318, 204)
		Me.ContinueButton.Name = "ContinueButton"
		Me.ContinueButton.Size = New System.Drawing.Size(75, 23)
		Me.ContinueButton.TabIndex = 2
		Me.ContinueButton.Text = "Continue"
		Me.ContinueButton.UseVisualStyleBackColor = True
		'
		'ExitButton
		'
		Me.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Abort
		Me.ExitButton.Location = New System.Drawing.Point(214, 204)
		Me.ExitButton.Name = "ExitButton"
		Me.ExitButton.Size = New System.Drawing.Size(75, 23)
		Me.ExitButton.TabIndex = 0
		Me.ExitButton.Text = "Restart"
		Me.ExitButton.UseVisualStyleBackColor = True
		'
		'SendExceptionButton
		'
		Me.SendExceptionButton.Location = New System.Drawing.Point(24, 204)
		Me.SendExceptionButton.Name = "SendExceptionButton"
		Me.SendExceptionButton.Size = New System.Drawing.Size(75, 23)
		Me.SendExceptionButton.TabIndex = 0
		Me.SendExceptionButton.Text = "Send"
		Me.ToolTip1.SetToolTip(Me.SendExceptionButton, "Display an email which you can send to TimeTracker support")
		Me.SendExceptionButton.UseVisualStyleBackColor = True
		'
		'ExceptionHandler
		'
		Me.AcceptButton = Me.SendExceptionButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(608, 235)
		Me.Controls.Add(Me.SendExceptionButton)
		Me.Controls.Add(Me.ExitButton)
		Me.Controls.Add(Me.ContinueButton)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.TextBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ExceptionHandler"
		Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Unhandled Exception"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ContinueButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents SendExceptionButton As Button
	Friend WithEvents ToolTip1 As ToolTip
End Class
