﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
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

	Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents LabelProductName As System.Windows.Forms.Label
	Friend WithEvents LabelVersion As System.Windows.Forms.Label
	Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
	Friend WithEvents OKButton As System.Windows.Forms.Button
	Friend WithEvents LabelCopyright As System.Windows.Forms.Label

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox1))
		Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
		Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
		Me.LabelProductName = New System.Windows.Forms.Label()
		Me.LabelVersion = New System.Windows.Forms.Label()
		Me.LabelCopyright = New System.Windows.Forms.Label()
		Me.TextBoxDescription = New System.Windows.Forms.TextBox()
		Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
		Me.OKButton = New System.Windows.Forms.Button()
		Me.TableLayoutPanel.SuspendLayout()
		Me.SuspendLayout()
		'
		'TableLayoutPanel
		'
		Me.TableLayoutPanel.ColumnCount = 2
		Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172.0!))
		Me.TableLayoutPanel.Controls.Add(Me.LinkLabel2, 1, 3)
		Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 0, 0)
		Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 0, 1)
		Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 0, 2)
		Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 0, 4)
		Me.TableLayoutPanel.Controls.Add(Me.LinkLabel1, 0, 3)
		Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 5)
		Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 9)
		Me.TableLayoutPanel.Name = "TableLayoutPanel"
		Me.TableLayoutPanel.RowCount = 6
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
		Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32.0!))
		Me.TableLayoutPanel.Size = New System.Drawing.Size(271, 164)
		Me.TableLayoutPanel.TabIndex = 0
		'
		'LinkLabel2
		'
		Me.LinkLabel2.AutoSize = True
		Me.LinkLabel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LinkLabel2.Location = New System.Drawing.Point(105, 66)
		Me.LinkLabel2.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LinkLabel2.Name = "LinkLabel2"
		Me.LinkLabel2.Size = New System.Drawing.Size(163, 22)
		Me.LinkLabel2.TabIndex = 2
		Me.LinkLabel2.TabStop = True
		Me.LinkLabel2.Text = "Request Features"
		Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'LabelProductName
		'
		Me.TableLayoutPanel.SetColumnSpan(Me.LabelProductName, 2)
		Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LabelProductName.Location = New System.Drawing.Point(6, 0)
		Me.LabelProductName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 17)
		Me.LabelProductName.Name = "LabelProductName"
		Me.LabelProductName.Size = New System.Drawing.Size(262, 17)
		Me.LabelProductName.TabIndex = 0
		Me.LabelProductName.Text = "Product Name"
		Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'LabelVersion
		'
		Me.TableLayoutPanel.SetColumnSpan(Me.LabelVersion, 2)
		Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LabelVersion.Location = New System.Drawing.Point(6, 22)
		Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 17)
		Me.LabelVersion.Name = "LabelVersion"
		Me.LabelVersion.Size = New System.Drawing.Size(262, 17)
		Me.LabelVersion.TabIndex = 0
		Me.LabelVersion.Text = "Version"
		Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'LabelCopyright
		'
		Me.TableLayoutPanel.SetColumnSpan(Me.LabelCopyright, 2)
		Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LabelCopyright.Location = New System.Drawing.Point(6, 44)
		Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 17)
		Me.LabelCopyright.Name = "LabelCopyright"
		Me.LabelCopyright.Size = New System.Drawing.Size(262, 17)
		Me.LabelCopyright.TabIndex = 0
		Me.LabelCopyright.Text = "Copyright"
		Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'TextBoxDescription
		'
		Me.TextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TableLayoutPanel.SetColumnSpan(Me.TextBoxDescription, 2)
		Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TextBoxDescription.Location = New System.Drawing.Point(9, 97)
		Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(9)
		Me.TextBoxDescription.Multiline = True
		Me.TextBoxDescription.Name = "TextBoxDescription"
		Me.TextBoxDescription.ReadOnly = True
		Me.TextBoxDescription.Size = New System.Drawing.Size(253, 26)
		Me.TextBoxDescription.TabIndex = 0
		Me.TextBoxDescription.TabStop = False
		Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
		'
		'LinkLabel1
		'
		Me.LinkLabel1.AutoSize = True
		Me.LinkLabel1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.LinkLabel1.Location = New System.Drawing.Point(6, 66)
		Me.LinkLabel1.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
		Me.LinkLabel1.Name = "LinkLabel1"
		Me.LinkLabel1.Size = New System.Drawing.Size(90, 22)
		Me.LinkLabel1.TabIndex = 1
		Me.LinkLabel1.TabStop = True
		Me.LinkLabel1.Text = "Support"
		Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'OKButton
		'
		Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.OKButton.Location = New System.Drawing.Point(193, 139)
		Me.OKButton.Name = "OKButton"
		Me.OKButton.Size = New System.Drawing.Size(75, 22)
		Me.OKButton.TabIndex = 0
		Me.OKButton.Text = "&OK"
		'
		'AboutBox1
		'
		Me.AcceptButton = Me.OKButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.OKButton
		Me.ClientSize = New System.Drawing.Size(289, 182)
		Me.Controls.Add(Me.TableLayoutPanel)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "AboutBox1"
		Me.Padding = New System.Windows.Forms.Padding(9)
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "AboutBox1"
		Me.TableLayoutPanel.ResumeLayout(False)
		Me.TableLayoutPanel.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents LinkLabel2 As LinkLabel
	Friend WithEvents LinkLabel1 As LinkLabel
End Class
