<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVideoCamara
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnOpciones = New System.Windows.Forms.Button()
        Me.btnTomarFoto = New System.Windows.Forms.Button()
        Me.btnGuardarImagen = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(241, 189)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnOpciones
        '
        Me.btnOpciones.Location = New System.Drawing.Point(704, 27)
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(75, 23)
        Me.btnOpciones.TabIndex = 1
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.UseVisualStyleBackColor = True
        '
        'btnTomarFoto
        '
        Me.btnTomarFoto.Location = New System.Drawing.Point(704, 91)
        Me.btnTomarFoto.Name = "btnTomarFoto"
        Me.btnTomarFoto.Size = New System.Drawing.Size(75, 23)
        Me.btnTomarFoto.TabIndex = 2
        Me.btnTomarFoto.Text = "Tomar foto"
        Me.btnTomarFoto.UseVisualStyleBackColor = True
        '
        'btnGuardarImagen
        '
        Me.btnGuardarImagen.Location = New System.Drawing.Point(704, 137)
        Me.btnGuardarImagen.Name = "btnGuardarImagen"
        Me.btnGuardarImagen.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardarImagen.TabIndex = 3
        Me.btnGuardarImagen.Text = "Guardar imagen"
        Me.btnGuardarImagen.UseVisualStyleBackColor = True
        '
        'FrmVideoCamara
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 244)
        Me.Controls.Add(Me.btnGuardarImagen)
        Me.Controls.Add(Me.btnTomarFoto)
        Me.Controls.Add(Me.btnOpciones)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FrmVideoCamara"
        Me.Text = "FrmVideoCamara"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnOpciones As Button
    Friend WithEvents btnTomarFoto As Button
    Friend WithEvents btnGuardarImagen As Button
End Class
