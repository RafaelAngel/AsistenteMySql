'Autor: Rafael Angel Montero Fernández
'Alias= Angel Continium ADNX
'Segundo alias= Sharkyc12
'Correo= Sharkyc12@gmail.com
'Celular=83942235
'Celuar modo internacional= +50683942235


':::Libreria MySQL
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class CLSImagenesEnMySQL
    ':::Procedimiento para conexion a MySQL
    Private Con2 As New MySqlConnection("Server = localhost; Database = ejemploimagenes; Uid = root; Pwd = root")

    ':::Procedimiento para Cargar los registro de MySQL
    Public Sub Cargar_MySQL(ByVal Sql As String, ByVal Tabla As DataGridView)
        Dim Da As New MySqlDataAdapter(Sql, Con2)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        Try
            ':::Llenamos nuestro DataTable con el resultado de la consulta
            Da.Fill(Dt)
            ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
            Tabla.DataSource = Dt
            ':::Damos color a las filas y formato a la columna hora
            Tabla.RowsDefaultCellStyle.BackColor = Color.LightBlue
            Tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.White
            Tabla.Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
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


End Class

Public Module MdlMysql
    Public ClsImgMySQL As CLSImagenesEnMySQL
End Module