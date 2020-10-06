
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class FrmImagenesEnMySQL

    ':::Creamos una varible para almacenar el valor del Id del registro
    Public id As Integer = 0
    Private Sub FrmImagenesEnMySQL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        ':::Creamos una variable de tipo string que guardara nuestra consulta SQL
        Dim sql As String = "Select * From clientes"
        ':::Llamamos la funcion para cargar los registros de SQLite
        Cargar_MySQL(sql, DGTablaClientes)


    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ':::Creamos nuestras variables para almacenar los datos a ingresar
        Dim nombres As String = TxtNombres.Text
        'Dim apellidos As String = TxtApellidos.Text
        'Dim fecha As String = DtpFecha.Value.ToString("yyyy-MM-dd")

        ':::Creamos una varible que almacenara nuestra consulta SQL
        ':::Como podemos observar pasamos todos los valores menos el de la imagen, el cual le indicamos que es un parametro
        ':::Esto debido a que la imagen es de tipo Byte y la consulta SQL solo admite valores String, por esto debemos
        ':::Pasarlo como un parametro
        Dim sql As String = "Insert Into clientes (Nombres, Imagen) Values ('" & nombres & "', @imagen)"
        ':::Llamamos la funcion para agregar un nuevo registro en MySQL y le pasamos el objeto PictureBox que llamamos PtbImagen
        Operaciones_MySQL(sql, PtbImagen)
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        ':::Creamos una varible que almacenara nuestra consulta SQL
        ':::Como podemos observar pasamos todos los valores menos el de la imagen, el cual le indicamos que es un parametro
        ':::Esto debido a que la imagen es de tipo Byte y la consulta SQL solo admite valores String, por esto debemos
        ':::Pasarlo como un parametro
        Dim sql As String = "Update clientes Set Nombres='" & TxtNombres.Text & "', Imagen=@imagen Where Id=" & id & ""
        ':::Llamamos la funcion para modificarun registro en MySQL y le pasamos el objeto PictureBox que llamamos PtbImagen
        Operaciones_MySQL(sql, PtbImagen)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ':::Creamos una varible que almacenara nuestra consulta SQL
        Dim sql As String = "Delete From clientes Where Id=" & id & ""
        Operaciones_MySQL(sql, PtbImagen)
    End Sub

    Private Sub PtbImagen_Click(sender As Object, e As EventArgs) Handles PtbImagen.Click
        ':::Creamos un nuevo objeto de tipo OpenFileDialog
        Dim Open As New OpenFileDialog
        Open.Title = "Seleccione una imagen"
        ':::Le asignamos un filtro para que solo admita arhivos de imagen con extension jpg, jpeg y png
        Open.Filter = "Imagenes JPG|*.jpg|Imagenes JPEG|*.jpeg|Imagenes PNG|*.png"

        If Open.ShowDialog = DialogResult.OK Then
            ':::Pasamos la imagen seleccionada al PictureBox
            PtbImagen.ImageLocation = Open.FileName
            ':::Le indicamos que ajuste la imagen al tamaño del control
            PtbImagen.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    Private Sub DGTablaClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTablaClientes.CellContentClick
        id = DGTablaClientes.CurrentRow.Cells("Id").Value
    End Sub

    Private Sub DGTablaClientes_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGTablaClientes.CellContentDoubleClick
        id = DGTablaClientes.CurrentRow.Cells("Id").Value
        TxtNombres.Text = DGTablaClientes.CurrentRow.Cells("nombres").Value
        'TxtApellidos.Text = DGTablaClientes.CurrentRow.Cells("Apellidos").Value
        'DtpFecha.Value = DGTablaClientes.CurrentRow.Cells("Fecha").Value
        PtbImagen.Image = DGTablaClientes.CurrentRow.Cells("imagen").FormattedValue

    End Sub
    ':::Procedimiento para conexion a MySQL
    Private Con2 As New MySqlConnection("Server = localhost; Database = ejemploimagenes; Uid = root; Pwd = ''")

    ':::Procedimiento para Cargar los registro de MySQL
    Public Sub Cargar_MySQL(ByVal Sql As String, ByVal Tabla As DataGridView)
        Dim Da As New MySqlDataAdapter(Sql, Con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        Try
            ':::Llenamos nuestro DataTable con el resultado de la consulta
            Da.Fill(Dt)
            ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
            DGTablaClientes.DataSource = Dt
            'Datos.DataSource = Dt

            ':::Damos color a las filas y formato a la columna hora
            'DGTablaClientes.RowsDefaultCellStyle.BackColor = Color.LightBlue
            'DGTablaClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.White
            'DGTablaClientes.Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
        Catch ex As Exception
            MsgBox("No se puede realizar la consulta por: " & ex.Message)
        End Try
    End Sub



    ':::Procedimiento para agregar, modificar y eliminar en MySQL
    Public Sub Operaciones_MySQL(ByVal sql As String, ByVal imagen As PictureBox)
        ':::Creamos una variable de tipo MemoryStram
        Dim MS As New MemoryStream
        ':::Guardamos en la variable MS el contenido del PictureBox
        imagen.Image.Save(MS, imagen.Image.RawFormat)
        ':::Pasamos a Byte nuestra imagen
        Dim Imagenes() As Byte = MS.GetBuffer

        ':::Declaramos nuestro objeto de tipo SQLiteCommand para ejecutar la consulta
        Dim cmd As New MySqlCommand(sql, Con2)
        ':::Agregamos el parametro de nuestra varible imagenes que es de tipo Byte
        cmd.Parameters.AddWithValue("@imagen", Imagenes)
        Try
            ':::Abrimos nuestra conexion
            Con2.Open()
            ':::Ejecutamos la consulta
            cmd.ExecuteNonQuery()
            ':::Cerramos nuestra conexion
            Con2.Close()
            MsgBox("Operación realizada con exito", MsgBoxStyle.Information, ":::Aprendamos de programación:::")
        Catch ex As Exception
            MsgBox("No se pueden guardar los registro por: " & ex.Message, MsgBoxStyle.Critical, ":::Aprendamos de Programación:::")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim m(5) As String
        For i As Integer = 0 To 5
            m(i) = "Indice " & i
            MsgBox(m(i))
        Next
        MsgBox(m(5))
    End Sub

End Class