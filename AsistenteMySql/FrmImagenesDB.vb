Public Class FrmImagenesDB
    Private ClsImagenes As New CLS_ConectorMySQL

    Private Sub FrmImagenesDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsImagenes.EnlazarDataGridView("Select imagen, nombres from Clientes", DataGridView1)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        PictureBox1.Image = DataGridView1.CurrentRow.Cells("imagen").FormattedValue
    End Sub
End Class