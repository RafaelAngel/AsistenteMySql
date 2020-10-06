Public Class FrmPrincipal


    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.PrTexto = "hola " & Chr(13) & "adios"
    End Sub

    Public Property PrTexto As String
        'Permite agregarle texto al control RichTextBox
        Get
            Return Me.RichTextBox1.Text
        End Get
        Set(value As String)
            RichTextBox1.Text = value
        End Set
    End Property
End Class
