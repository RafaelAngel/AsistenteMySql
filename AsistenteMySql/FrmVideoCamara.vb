Public Class FrmVideoCamara
    'Buen codigo para acceder a la camara pero no funciona porque faltan unas dlls de vb6

    Private Sub btnOpciones_Click(sender As Object, e As EventArgs) Handles btnOpciones.Click
        capDlgVideoSource(lwndC)
    End Sub

    Private Sub btnTomarFoto_Click(sender As Object, e As EventArgs) Handles btnTomarFoto.Click
        Dim data As IDataObject
        Dim bmap As Bitmap

        capEditCopy(lwndC)                  ' Llama a copiar la imagen al portapapeles
        data = Clipboard.GetDataObject()    ' Obtiene la imagen del portapapeles
        bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Bitmap) ' Lo comvierte a bmp
        PictureBox1.Image = bmap             ' La copia
    End Sub

    Private Sub FrmVideoCamara_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Esta es la parte del codigo que no funciona.
        'Original:
        ' TryDim lpszName As New VB6.FixedLengthString(100)
        'Dim lpszVer As New VB6.FixedLengthString(100) 

        'Alternativa
        Try
            Dim lpszName As String = "200"
            Dim lpszVer As String = "200"
            ''Llamada directa a la api
            capGetDriverDescriptionA(0, lpszName, 100, lpszVer, 100)
            lwndC = capCreateCaptureWindowA(lpszName, WS_VISIBLE Or WS_CHILD, 15, 28, 320, 242, Me.Handle.ToInt32, 0)
            If capDriverConnect(lwndC, 0) Then
                capPreviewScale(lwndC, True)
                capPreviewRate(lwndC, 50)
                capPreview(lwndC, True)
            End If
        Catch ex As Exception
            MsgBox(ex.GetBaseException.Message)
        End Try
    End Sub

    Private Sub FrmVideoCamara_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        capSetCallbackOnError(lwndC, VariantType.Null)
        capSetCallbackOnStatus(lwndC, VariantType.Null)
        capSetCallbackOnYield(lwndC, VariantType.Null)
        capSetCallbackOnFrame(lwndC, VariantType.Null)
        capSetCallbackOnVideoStream(lwndC, VariantType.Null)
        capSetCallbackOnWaveStream(lwndC, VariantType.Null)
        capSetCallbackOnCapControl(lwndC, VariantType.Null)
    End Sub

    Private Sub btnGuardarImagen_Click(sender As Object, e As EventArgs) Handles btnGuardarImagen.Click
        PictureBox1.Image.Save(My.Application.Info.DirectoryPath & "\imagen.bmp")
    End Sub
End Class