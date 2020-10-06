Public Class ClsusoDeMatrices


    Public Sub MatrizConDelimitador()
        'Se cargan dos matrices con los datos de la primera, pero por medio de un delimitador que las divide.
        Dim rnd As New Random
        'Matriz con 100 elementos desde el cero al 99.
        Dim mMatrizCon99(99) As String
        'Poblando la matriz con datos.
        For contador As Integer = 0 To mMatrizCon99.GetUpperBound(0)
            mMatrizCon99(contador) = ChrW(rnd.Next(&H21, &H7F))
        Next
        'Insertando el delimitador dentro de la matriz.
        mMatrizCon99(rnd.Next(0, mMatrizCon99.GetUpperBound(0))) = "Rafa"
        'Obteniendo el delimitador
        Dim vDelimitador = Array.FindIndex(mMatrizCon99, Function(r) r = "Rafa")

        'Creando las dos matrices que almacenaran las partes divididas de la matriz original.
        Dim m1(vDelimitador - 1) As String
        Dim m2(mMatrizCon99.GetUpperBound(0 - vDelimitador - 1)) As String
        'Poblando las dos matrices.
        Array.Copy(mMatrizCon99, 0, m1, 0, vDelimitador)
        Array.Copy(mMatrizCon99, vDelimitador + 1, m2, 0, mMatrizCon99.GetUpperBound(0) - vDelimitador)

        'Lo anterior fue una demostracion de manejo de amtrices.
        'Puede ser util en algoritmos geneticos.
    End Sub

    Public Sub MatrizDivisible()
        Dim m99(99) As Integer
        'Generador de numero aleatorios
        Dim rnd As New Random
        For i As Integer = 0 To m99.GetUpperBound(0)
            m99(i) = rnd.Next
        Next
        'Cantidad de items en cada matriz.
        Dim divisor As Integer = 2
        Dim re As Integer
        Dim b As Integer = Math.DivRem(m99.GetLength(0), divisor, re)
        'Copiando items en las matrices secundarias.
        Dim m1(b - 1 + re), m2(b - 1) As Integer
        Array.Copy(m99, 0, m1, 0, b + re)
        Array.Copy(m99, 0, m2, 0, m99.Length - b)
        'Lo anterior fue un ejemplo de como dividir los datos de una matriz en dos matrices.
    End Sub

    Public Sub MatrizEscalonada()
        Const SALTO_DE_LINEA As String = Chr(13)
        'Demostracion del uso de una matriz escalonada. Basado en la version en ingles del ejemplo, en el sitio:
        'Obtenido de https://docs.microsoft.com/es-es/dotnet/visual-basic/programming-guide/language-features/arrays/
        'O sea anidar matrices dentro de otras matrices.
        'El siguiente ejemplo usa los dias, semanas y meces para representarse.
        Dim mVentas(11)() As Double

        For mes As Integer = 0 To 11
            'Obteniendo los dias de cada mes de acuerdo al tamaño...
            Dim diasDelMes As Integer = DateTime.DaysInMonth(Year(Now), mes + 1)
            mVentas(mes) = New Double(diasDelMes - 1) {}
        Next
        'Llenando la matriz con datos.
        For mes As Integer = 0 To 11
            For DiasDelMes As Integer = 0 To mVentas(mes).GetUpperBound(0)
                mVentas(mes)(DiasDelMes) = (mes * 100) + DiasDelMes
            Next
        Next
        'Obteniendo los nombres de los meces colocandolos de una ves en la matriz.
        Dim nombresDeLosMeces() As String = Globalization.DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames
        'Variable en la que se cargaran los nombres de los meces para luego mostrarla con un msgbox.
        Dim vLista As String = "" 'Se debe inicializar la variable, porque se esta usando el operador += antes que le entre informacion.
        For contador As Integer = 0 To mVentas.GetUpperBound(0)
            vLista += nombresDeLosMeces(contador) & SALTO_DE_LINEA
        Next
        MsgBox(vLista)
        'Mostrando la informacion de cada dia de cada mes.
        'Variable para almacenar los datos de la interaccion para luego mostrar todo con un msgbox.
        Dim vDatos As String = "" 'Se debe inicializar la variable, porque se esta usando el operador += antes que le entre informacion.
        For diaDelMes As Integer = 0 To 30
            vDatos += "Numero del dia del mes " & (diaDelMes + 1)
            For numeroDelMes As Integer = 0 To mVentas.GetUpperBound(0)
                If diaDelMes > mVentas(numeroDelMes).GetUpperBound(0) Then
                    vDatos += SALTO_DE_LINEA + "Nuevo mes." + SALTO_DE_LINEA + SALTO_DE_LINEA
                Else
                    vDatos += "Datos de este dia: " + mVentas(numeroDelMes)(diaDelMes) + SALTO_DE_LINEA
                End If
            Next
            vDatos += SALTO_DE_LINEA
        Next
        MsgBox(vDatos)
    End Sub

End Class
