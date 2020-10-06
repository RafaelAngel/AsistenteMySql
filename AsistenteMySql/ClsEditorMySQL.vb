'Autor: Rafael Angel Montero Fernández
'Alias= Angel Continium ADNX
'Segundo alias= Sharkyc12
'Correo= Sharkyc12@gmail.com
'Celular=83942235
'Celuar modo internacional= +50683942235


Public Class ClsEditorMySQL

    Public Enum EnTiposDeDatos
        'Ya no es necesario ponerle valores al enum, basta con declararlo y el mismo se enumera.
        'Solo se le ponen valores en casos especificos.
        'Pero mejor si para no tener pronleas con el ListBox
        entChar = 0
        entInt = 1
        enVarChar = 2
        enDouble = 3
        enDate = 4
        enBoolean = 5
        enPrimaryKey = 6
        enBlobImagenArchivoPequeño = 7
        enTime = 8
        enDateTime = 9
        enForeignKey = 10
        enLongBlobImagenArchivoGrande = 11
    End Enum

    Public Structure TiposDeDatos
        'Tipos de datos de MySql, los que yo más uso.
        Public Const ConstChar As String = "Char"
        Public Const ConstInt As String = "int"
        Public Const ConstVarChar As String = "VarChar"
        Public Const ConstDouble As String = "Double"
        Public Const ConstDate As String = "Date"
        Public Const ConstBoolean As String = "boolean"
        Public Const ConstPrimaryKey As String = "Primary Key"
        Public Const ConstBlobImagenArchivoPequeño As String = "Blob(imagen o archivo)"
        Public Const ConstTime As String = "Time"
        Public Const ConstDateTime As String = "DateTime"
        Public Const ConstForeignKey As String = "Foreign Key"
        Public Const ConstLongBlobImagenArchivoGrande As String = "LongBlob(imagenes o archivos grandes)"
    End Structure

    Protected Function GenerarTipoDeDatos(elija_el_tipo_de_datos As EnTiposDeDatos) As String
        Select Case elija_el_tipo_de_datos
            Case EnTiposDeDatos.enBlobImagenArchivoPequeño
                Return TiposDeDatos.ConstBlobImagenArchivoPequeño
            Case EnTiposDeDatos.enBoolean
                Return TiposDeDatos.ConstBoolean
            Case EnTiposDeDatos.enDate
                Return TiposDeDatos.ConstDate
            Case EnTiposDeDatos.enDateTime
                Return TiposDeDatos.ConstDateTime
            Case EnTiposDeDatos.enDouble
                Return TiposDeDatos.ConstDouble
            Case EnTiposDeDatos.enForeignKey
                Return TiposDeDatos.ConstForeignKey
            Case EnTiposDeDatos.enLongBlobImagenArchivoGrande
                Return TiposDeDatos.ConstLongBlobImagenArchivoGrande
            Case EnTiposDeDatos.enPrimaryKey
                Return TiposDeDatos.ConstPrimaryKey
            Case EnTiposDeDatos.entChar
                Return TiposDeDatos.ConstChar '& DefinirTamañoDelChar()
            Case EnTiposDeDatos.enTime
                Return TiposDeDatos.ConstTime
            Case EnTiposDeDatos.entInt
                Return TiposDeDatos.ConstInt
            Case EnTiposDeDatos.enVarChar
                Return TiposDeDatos.ConstVarChar '& DefinirTamañoDelChar()
        End Select
        Return ""
    End Function

    Public Function DefinirTamañoDelChar() As String
        Try
            Return "(" & Conversion.Int(InputBox("Anote un tamaño.", "Tamaño del char", "0")) & ")"
        Catch ex As Exception
            '
        End Try
        Return "(" & 0 & ")"
    End Function

    Public Structure StructCampos_y_datos
        'Por si los datos estan en un ListBox o se usa split para un texto plano.
        Public Lista_de_campos() As String
        Public Lista_de_datos() As String
    End Structure

    Public Function CrearConsultaSelect(ByVal lista_de_campos_con_datos As StructCampos_y_datos, ByVal nombre_de_la_tabla As String, ByVal Optional condiciones_where As String = "") As String
        Dim vNombreDelCsmpo As String = "" 'Para evitar problemas con null
        For i As Integer = 0 To lista_de_campos_con_datos.Lista_de_campos.Length - 1
            If i < lista_de_campos_con_datos.Lista_de_campos.Length - 1 Then
                vNombreDelCsmpo += lista_de_campos_con_datos.Lista_de_campos(i) & ", "
            ElseIf i = lista_de_campos_con_datos.Lista_de_campos.Length - 1 Then
                'Si el maximo es un solo campo entonces de una vez lo lanza aqui.
                vNombreDelCsmpo += lista_de_campos_con_datos.Lista_de_campos(i)
            End If
        Next
        'La consulta select puede ir anidada, asi que no termina en punto y coma.
        Return "Select " & vNombreDelCsmpo & " from " & nombre_de_la_tabla & CrearWhere(condiciones_where)
    End Function

    Public Function CrearConsultaUpdate(ByVal lista_de_campos_con_datos As StructCampos_y_datos, ByVal nombre_de_la_tabla As String, ByVal Optional condiciones_where As String = "") As String
        Dim declaracion_set As String = "" 'Para evitar problemas con null
        For i As Integer = 0 To lista_de_campos_con_datos.Lista_de_campos.Length - 1
            If i < lista_de_campos_con_datos.Lista_de_campos.Length - 1 Then
                declaracion_set += "set " & lista_de_campos_con_datos.Lista_de_campos(i) & "='" & lista_de_campos_con_datos.Lista_de_datos(i) & "', "
            ElseIf i = lista_de_campos_con_datos.Lista_de_campos.Length - 1 Then
                'Si el maximo es un solo campo entonces de una vez lo lanza aqui.
                declaracion_set += "set " & lista_de_campos_con_datos.Lista_de_campos(i) & "='" & lista_de_campos_con_datos.Lista_de_datos(i) & "' "
            End If
        Next
        Return "Update " & nombre_de_la_tabla & "  " & declaracion_set & CrearWhere(condiciones_where) & ";"
    End Function

    Public Function CrearConsultaInsert(ByVal lista_de_campos_con_datos As StructCampos_y_datos, ByVal nombre_de_la_tabla As String) As String
        Dim vNombresDeLosCampos As String = "" 'Para evitar problemas con null
        For i As Integer = 0 To lista_de_campos_con_datos.Lista_de_campos.Length - 1
            If i < lista_de_campos_con_datos.Lista_de_campos.Length - 1 Then
                vNombresDeLosCampos += "set " & lista_de_campos_con_datos.Lista_de_campos(i) & "='" & lista_de_campos_con_datos.Lista_de_datos(i) & "', "
            ElseIf i = lista_de_campos_con_datos.Lista_de_campos.Length - 1 Then
                'Si el maximo es un solo campo entonces de una vez lo lanza aqui.
                vNombresDeLosCampos += "set " & lista_de_campos_con_datos.Lista_de_campos(i) & "='" & lista_de_campos_con_datos.Lista_de_datos(i) & "' "
            End If
        Next
        Return "insert into " & nombre_de_la_tabla & " " & vNombresDeLosCampos & ";"
    End Function

    Public Function CrearConsultaDelete(ByVal nombre_de_la_tabla As String, ByVal Optional condiciones_where As String = "") As String
        Return "Delete form " & nombre_de_la_tabla & CrearWhere(condiciones_where) & ";"
    End Function

    Protected Function CrearWhere(condiciones_where As String) As String
        'Se usa protecte para poderse heredar con inherit y poderse modificar con Override, o como se dice en vbnet (Poderse invalidar), o en c++ (redefinir).
        If condiciones_where <> "" Then
            Return " Where " & condiciones_where
        End If
        Return ""
    End Function

    Private Function Salto()
        'Salto de linea
        Return Chr(13)
    End Function

    Public Function CrearBase(ByVal nombre_de_la_base As String) As String
        Return "Drop DataBase if exists " & nombre_de_la_base & ";" & Salto() & "Create Database if not exists " & nombre_de_la_base & ";"
    End Function

    Public Function CrearProcedimientoAlmacenado(ByVal nombre_del_procedimiento_almacenado As String, ByVal Optional lista_de_parametros As String = "", ByVal Optional codigo_de_contenido As String = "") As String
        Return "DELIMITER $$" & Salto() & "Drop procedure if exists " & nombre_del_procedimiento_almacenado & " $$" & Salto() & "Create Procedure " & nombre_del_procedimiento_almacenado & "(" & lista_de_parametros & ")" & Salto() & "Beggin" & Salto() & codigo_de_contenido & Salto() & "End $$" & Salto() & "Delimiter ;"
    End Function

    Public Function CrearFuncionAlmacenada(ByVal nombre_del_procedimiento_almacenado As String, ByVal Optional lista_de_parametros As String = "", ByVal Optional codigo_de_contenido As String = "") As String
        Dim contenido As String
        If codigo_de_contenido = "" Then
            contenido = codigo_de_contenido
        Else
            contenido = "return Select 'Nueva funcion';"
        End If
        Return "DELIMITER $$" & Salto() & "Drop function if exists " & nombre_del_procedimiento_almacenado & " $$" & Salto() & "Create function " & nombre_del_procedimiento_almacenado & "(" & lista_de_parametros & ")" & Salto() & "Beggin" & Salto() & contenido & Salto() & "End $$" & Salto() & "Delimiter ;"
    End Function

    Public Function CrearVariableMySql(ByVal nombre_de_la_variable As String, ByVal Optional tipo_de_datos_de_la_variable As String = "Char(50)") As String
        Return "Declare " & nombre_de_la_variable & " as " & tipo_de_datos_de_la_variable
    End Function

    Public Function CrearVariableMySql(ByVal nombre_de_la_variable As String, ByVal tipo_de_datos_de_la_variable As EnTiposDeDatos) As String
        Return CrearVariableMySql(nombre_de_la_variable, Me.GenerarTipoDeDatos(tipo_de_datos_de_la_variable))
    End Function

    Public Function CrearCursor(ByVal nombre_del_cursor As String, ByVal nombre_de_la_tabla As String) As String

        Dim Variables As String = "Declare vid int default (0);" & Salto() & "Declare final int default(0);"

        'Declare hay_datos boolean default(false);
        Dim vCursor As String = "Declare cursor" & nombre_del_cursor & " cursor for " & "select id from " & nombre_de_la_tabla & ";"

        Const ErrSinDefaultValue As String = "Declare continue ()handler For 1364 Set @errCamposSinDefaultValue= 'Cuando la tabla se creó la tabla, no se le asignó un valor por defecto a los campos.';"

        Const errNotFound As String = "Declare continue ()handler For Not found Set final = 1; #Para el final del cursor."
        Dim vOpen As String = "open cursor" & nombre_del_cursor & ";"
        Dim vBucle As String = "Loop" & nombre_del_cursor & ": Loop" & Salto() & "fetch cursor" & nombre_del_cursor & " into vid; #Poniendo una fila a la vez." & Salto() & "If final = 1 Then" & Salto() & "leave Loop" & nombre_del_cursor & ";#Salir del bucle While con la etiqueta whileRutas" & Salto() & "End If;" & Salto() & "#Codigo para realizar alguna tarea." & Salto() & "End Loop Loop" & nombre_del_cursor & ";" & Salto()
        '
        '    If hay_datos = False Then
        '		#Al suceder el Error porque podria no tener datos la tabla entonces.
        '		insert into RutasAsignadas(idCarro)values(New.idCarro);
        '	End If;
        '
        '
        '#Asignando todas las rutas existentes para el nuevo carro. Solo con cursores se puede hacer esto.
        'insert into RutasAsignadas(idCarro, idRuta)values(New.idCarro,vidRuta);
        'Set hay_datos=True;#Si tan solo hay un registro entonces se activa.
        '
        Return "#Declaracion basica de un cursor." & Salto() & Variables & Salto() & vCursor & Salto() & ErrSinDefaultValue & Salto() & errNotFound & Salto() & vOpen & vBucle
    End Function

    Public Function ObtenerPlantillaCondicional() As String
        'Permite crear una plantilla de condicional.
        Return "#Plantilla de condicional." & Salto() & "If hay_datos = False Then" & Salto() & "#Escriba el codigo aqui." & Salto() & "End If;" & Salto()
    End Function

End Class

