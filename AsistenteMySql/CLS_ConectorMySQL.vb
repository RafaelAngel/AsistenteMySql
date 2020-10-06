
Imports System.Drawing
Imports MySql.Data.MySqlClient

Public Class CLS_ConectorMySQL

    Public Sub Decir(nuevo As String)
        MsgBox(nuevo)
    End Sub

    Private dt As DataTable
    Private conn As MySqlConnection
    Private comando As MySqlCommand
    Private drd As MySqlDataReader

    Protected Sub Conectar(ConsultaEnMySQL As String, Optional nombre_de_la_base_de_datos As String = "ejemploimagenes")
        Try
            dt = New DataTable
            conn = New MySqlConnection("server=localhost;database=" & nombre_de_la_base_de_datos & ";user id='rafael';password=rafael;")
            Dim consulta As String = ConsultaEnMySQL
            'conn.Open()
            comando = New MySqlCommand(consulta, conn)
            conn.Open()

            'Response.Redirect("Opciones.aspx?idu=" & drd.Item("idu").ToString)
            ' Response.Redirect("Opciones.aspx")
        Catch
            MsgBox("El servidor MySQL no esta activo, por favor inicie el servidor MySQL e intente de nuevo iniciar este programa.")

        End Try
    End Sub

    Public Function ContarRegistros(nombre_de_la_tabla As String, nombre_de_algun_campo As String) As String
        'Permite contar cuantos registros tiene una tabla.
        Conectar("select count(" & nombre_de_algun_campo & ")'total'  from " & nombre_de_la_tabla & ";")
        drd = comando.ExecuteReader
        If drd.Read = True Then
            Return drd.Item("total").ToString
        End If
        Return ""
    End Function

    Public Sub Llamar_procedimiento_almacenado(call_procedimiento As String)
        'Permite realizar una llamada a un procedimiento almacenado.
        'Con call nombre_del_procedimiento.
        Conectar(call_procedimiento)
        comando.ExecuteNonQuery()
    End Sub

    Public Sub ConsultaUpdate(consulta_sql_update As String)
        'Permite realizar consultas update.
        Conectar(consulta_sql_update)
        comando.ExecuteNonQuery()
    End Sub

    Public Function ConsultarDatos(consultaMySql As String, nombre_del_campo_a_mostrar As String) As String
        'Permite consultar datos desde cualquier parte del programa.
        'En el parametro nombre_del_campo_a_mostrar se debe escribir el nombre de columna (campo) para el cual se mostraran datos.
        ConsultarDatos = ConsultarDatos(consultaMySql).Item(nombre_del_campo_a_mostrar).ToString
    End Function

    Public Function ConsultarDatos(consultaMySql As String) As MySqlDataReader
        'Permite consultar cada item desde el lado del form.
        'Pero hay que usar: ConsultarDatos(consultaMySql).Item(nombre_del_campo_a_mostrar).ToString
        'Sin embargo permite enlazarlo a algun control enlazado.
        Conectar(consultaMySql)
        drd = comando.ExecuteReader
        If drd.Read = True Then
            Return drd
        End If
        Return Nothing
    End Function

    Public Function Add(Consulta_insert As String) As Integer
        Conectar(Consulta_insert)
        Dim i As Integer = comando.ExecuteNonQuery
        If i > 0 Then
            MsgBox("Datos registrados con exito.")
        Else
            MsgBox("No se pudo registrar la informacion.")
        End If
        Return i
    End Function

    Private datos As DataSet
    Private adaptador As MySqlDataAdapter

    Private middl As ListBox

    Public ReadOnly Property ListaDesplegable() As ListBox
        Get
            Return middl
        End Get
    End Property

    Public Function EnlazarDropDownList(consultaMySql As String, NombreDeLaTabla As String, campo_enlazado As String, drop As ListBox) As ListBox
        Conectar(consultaMySql)
        adaptador = New MySqlDataAdapter(consultaMySql, conn)
        datos = New DataSet
        datos.Tables.Add(NombreDeLaTabla)
        adaptador.Fill(datos.Tables(NombreDeLaTabla))
        With drop
            .DataSource = datos.Tables(NombreDeLaTabla)
            '.DataTextField = campo_enlazado
        End With
        'drop.DataBind()
        Return drop
    End Function

    Public Function EnlazarDataGridView(consultaMySql As String, NuevoDataGridView As DataGridView) As DataGridView
        Conectar(consultaMySql)
        Dim Da As New MySqlDataAdapter(consultaMySql, conn)
        ':::Creamos nuestro DataTable para almacenar el resultado
        Dim Dt As New DataTable
        Try
            ':::Llenamos nuestro DataTable con el resultado de la consulta
            Da.Fill(Dt)
            ':::Asignamos a nuestro DataGridView el DataTable para mostrar los registros
            NuevoDataGridView.DataSource = Dt
            'NuevoDataGridView.DataBind()
            ':::Damos color a las filas y formato a la columna hora
            'Tabla.RowsDefaultCellStyle.BackColor = Color.LightBlue
            'Tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.White
            'Tabla.Columns("Fecha").DefaultCellStyle.Format = "dd/MM/yyyy"
        Catch ex As Exception
            MsgBox("No se puede realizar la consulta por: " & ex.Message)
        End Try
        Return (NuevoDataGridView)
    End Function

End Class

