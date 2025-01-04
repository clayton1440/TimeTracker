<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddWeekForm
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
		Me.TargetDate = New System.Windows.Forms.DateTimePicker()
		Me.SelectDateRadio = New System.Windows.Forms.RadioButton()
		Me.SelectWeekNumberRadio = New System.Windows.Forms.RadioButton()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.WeekNumber = New System.Windows.Forms.NumericUpDown()
		Me.Year = New System.Windows.Forms.NumericUpDown()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.AddButton = New System.Windows.Forms.Button()
		Me.CancelButton1 = New System.Windows.Forms.Button()
		CType(Me.WeekNumber, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Year, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'TargetDate
		'
		Me.TargetDate.Enabled = False
		Me.TargetDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
		Me.TargetDate.Location = New System.Drawing.Point(43, 135)
		Me.TargetDate.Name = "TargetDate"
		Me.TargetDate.Size = New System.Drawing.Size(105, 20)
		Me.TargetDate.TabIndex = 0
		'
		'SelectDateRadio
		'
		Me.SelectDateRadio.AutoSize = True
		Me.SelectDateRadio.Location = New System.Drawing.Point(12, 93)
		Me.SelectDateRadio.Name = "SelectDateRadio"
		Me.SelectDateRadio.Size = New System.Drawing.Size(63, 17)
		Me.SelectDateRadio.TabIndex = 1
		Me.SelectDateRadio.Text = "By Date"
		Me.SelectDateRadio.UseVisualStyleBackColor = True
		'
		'SelectWeekNumberRadio
		'
		Me.SelectWeekNumberRadio.AutoSize = True
		Me.SelectWeekNumberRadio.Checked = True
		Me.SelectWeekNumberRadio.Location = New System.Drawing.Point(12, 14)
		Me.SelectWeekNumberRadio.Name = "SelectWeekNumberRadio"
		Me.SelectWeekNumberRadio.Size = New System.Drawing.Size(109, 17)
		Me.SelectWeekNumberRadio.TabIndex = 3
		Me.SelectWeekNumberRadio.TabStop = True
		Me.SelectWeekNumberRadio.Text = "By Week Number"
		Me.SelectWeekNumberRadio.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(40, 119)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(64, 13)
		Me.Label1.TabIndex = 4
		Me.Label1.Text = "Target Date"
		'
		'WeekNumber
		'
		Me.WeekNumber.Location = New System.Drawing.Point(43, 56)
		Me.WeekNumber.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
		Me.WeekNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.WeekNumber.Name = "WeekNumber"
		Me.WeekNumber.Size = New System.Drawing.Size(38, 20)
		Me.WeekNumber.TabIndex = 5
		Me.WeekNumber.Value = New Decimal(New Integer() {1, 0, 0, 0})
		'
		'Year
		'
		Me.Year.Location = New System.Drawing.Point(87, 56)
		Me.Year.Maximum = New Decimal(New Integer() {2999, 0, 0, 0})
		Me.Year.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
		Me.Year.Name = "Year"
		Me.Year.Size = New System.Drawing.Size(61, 20)
		Me.Year.TabIndex = 6
		Me.Year.Value = New Decimal(New Integer() {2000, 0, 0, 0})
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(40, 41)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(36, 13)
		Me.Label2.TabIndex = 7
		Me.Label2.Text = "Week"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(87, 41)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(29, 13)
		Me.Label3.TabIndex = 8
		Me.Label3.Text = "Year"
		'
		'AddButton
		'
		Me.AddButton.Location = New System.Drawing.Point(104, 177)
		Me.AddButton.Name = "AddButton"
		Me.AddButton.Size = New System.Drawing.Size(64, 23)
		Me.AddButton.TabIndex = 9
		Me.AddButton.Text = "Add"
		Me.AddButton.UseVisualStyleBackColor = True
		'
		'CancelButton1
		'
		Me.CancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.CancelButton1.Location = New System.Drawing.Point(20, 177)
		Me.CancelButton1.Name = "CancelButton1"
		Me.CancelButton1.Size = New System.Drawing.Size(64, 23)
		Me.CancelButton1.TabIndex = 10
		Me.CancelButton1.Text = "Cancel"
		Me.CancelButton1.UseVisualStyleBackColor = True
		'
		'AddWeekForm
		'
		Me.AcceptButton = Me.AddButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.CancelButton1
		Me.ClientSize = New System.Drawing.Size(189, 213)
		Me.Controls.Add(Me.CancelButton1)
		Me.Controls.Add(Me.AddButton)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Year)
		Me.Controls.Add(Me.WeekNumber)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.SelectWeekNumberRadio)
		Me.Controls.Add(Me.SelectDateRadio)
		Me.Controls.Add(Me.TargetDate)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "AddWeekForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Add Week"
		CType(Me.WeekNumber, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Year, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents TargetDate As DateTimePicker
	Friend WithEvents SelectDateRadio As RadioButton
	Friend WithEvents SelectWeekNumberRadio As RadioButton
	Friend WithEvents Label1 As Label
	Friend WithEvents WeekNumber As NumericUpDown
	Friend WithEvents Year As NumericUpDown
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents AddButton As Button
	Friend WithEvents CancelButton1 As Button
End Class
