Imports System.Data.SQLite

Public Class ChargeCodeReference
	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

	End Sub

	Public Shared Event ChargeCodesChanged As EventHandler

	Private starting As Boolean = True
	Private Sub ChargeCodeReference_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		DataGridView1.Columns.Clear()

		DataGridView1.Columns.Add("ChargeCode", "Charge Code")
		DataGridView1.Columns.Add("Description", "Description")
		DataGridView1.Columns.Add("ID", "ID")

		DataGridView1.Columns("ID").Visible = False
		DataGridView1.Columns("ChargeCode").FillWeight = 40

		Dim cList As List(Of ChargeCode) = GetChargeCodes()
		For Each c As ChargeCode In cList
			DataGridView1.Rows.Add(c.Code, c.Description, c.Id)
		Next

		starting = False
	End Sub


	Private Sub DataGridView1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
		If starting Then Return
		Dim id As Integer = DataGridView1.Rows(e.RowIndex).Cells("ID").Value
		Dim code As String = DataGridView1.Rows(e.RowIndex).Cells("ChargeCode").Value
		Dim desc As String = DataGridView1.Rows(e.RowIndex).Cells("Description").Value

		If id = 0 Then
			Dim cmd As New SQLiteCommand
			cmd.CommandText = "INSERT INTO ChargeCodes (ChargeCode, Description) VALUES (@Code, @Description) RETURNING ID;"

			cmd.Parameters.AddWithValue("@Code", code)
			cmd.Parameters.AddWithValue("@Description", desc)

			Dim _id As Integer = Database.ExecuteScalar(cmd)
			DataGridView1.Rows(e.RowIndex).Cells("ID").Value = _id
		Else
			Dim cmd As New SQLiteCommand
			cmd.CommandText = "UPDATE ChargeCodes SET ChargeCode = @Code, Description = @Description WHERE ID = @ID;"
			cmd.Parameters.AddWithValue("@ID", id)
			cmd.Parameters.AddWithValue("@Code", code)
			cmd.Parameters.AddWithValue("@Description", desc)

			Database.ExecuteNonQuery(cmd)
		End If

		RaiseEvent ChargeCodesChanged(Me, e)

	End Sub

	Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
		For Each row As DataGridViewRow In DataGridView1.SelectedRows
			Dim id As Integer = row.Cells("ID").Value

			Dim cmd As New SQLiteCommand
			cmd.CommandText = "DELETE FROM ChargeCodes WHERE ID = @ID;"

			cmd.Parameters.AddWithValue("@ID", id)

			Database.ExecuteNonQuery(cmd)
			DataGridView1.Rows.Remove(row)
		Next
		RaiseEvent ChargeCodesChanged(Me, e)
	End Sub

	Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
		If DataGridView1.SelectedRows.Count = 0 Then e.Cancel = True
	End Sub
End Class