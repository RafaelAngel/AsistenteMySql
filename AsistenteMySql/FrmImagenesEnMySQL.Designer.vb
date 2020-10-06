<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImagenesEnMySQL
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.DGTablaClientes = New System.Windows.Forms.DataGridView()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PtbImagen = New System.Windows.Forms.PictureBox()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DGTablaClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PtbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(473, 160)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(102, 56)
        Me.btnCargar.TabIndex = 0
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'DGTablaClientes
        '
        Me.DGTablaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGTablaClientes.Location = New System.Drawing.Point(12, 106)
        Me.DGTablaClientes.Name = "DGTablaClientes"
        Me.DGTablaClientes.Size = New System.Drawing.Size(437, 217)
        Me.DGTablaClientes.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(21, 367)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(851, 122)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(146, 20)
        Me.TxtNombres.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(851, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre"
        '
        'PtbImagen
        '
        Me.PtbImagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PtbImagen.Location = New System.Drawing.Point(851, 179)
        Me.PtbImagen.Name = "PtbImagen"
        Me.PtbImagen.Size = New System.Drawing.Size(146, 109)
        Me.PtbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PtbImagen.TabIndex = 6
        Me.PtbImagen.TabStop = False
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(139, 366)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 7
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(323, 367)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(660, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmImagenesEnMySQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1099, 425)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.PtbImagen)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNombres)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.DGTablaClientes)
        Me.Controls.Add(Me.btnCargar)
        Me.Name = "FrmImagenesEnMySQL"
        Me.Text = "FrmImagenesEnMySQL"
        CType(Me.DGTablaClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PtbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCargar As Button
    Friend WithEvents DGTablaClientes As DataGridView
    Friend WithEvents btnAgregar As Button
    Friend WithEvents TxtNombres As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PtbImagen As PictureBox
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents Button1 As Button
End Class
