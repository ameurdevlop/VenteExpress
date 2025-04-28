<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Produit
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Produit))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.id_prod = New System.Windows.Forms.TextBox()
        Me.quantité = New System.Windows.Forms.TextBox()
        Me.designation = New System.Windows.Forms.TextBox()
        Me.Code = New System.Windows.Forms.TextBox()
        Me.Prix = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Stock = New System.Windows.Forms.ComboBox()
        Me.Type = New System.Windows.Forms.ComboBox()
        Me.DEpot = New System.Windows.Forms.ComboBox()
        Me.Four = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(596, 918)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 39)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.Label1.Location = New System.Drawing.Point(1168, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 30)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Gerer les Produits"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Ajouter un Produit", "Modifier un Produit", "Supprimer un Produit", "Rechercher un Produit"})
        Me.ComboBox1.Location = New System.Drawing.Point(1524, 133)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(390, 30)
        Me.ComboBox1.TabIndex = 3
        '
        'id_prod
        '
        Me.id_prod.Location = New System.Drawing.Point(557, 259)
        Me.id_prod.Multiline = True
        Me.id_prod.Name = "id_prod"
        Me.id_prod.Size = New System.Drawing.Size(167, 35)
        Me.id_prod.TabIndex = 4
        '
        'quantité
        '
        Me.quantité.Location = New System.Drawing.Point(557, 450)
        Me.quantité.Multiline = True
        Me.quantité.Name = "quantité"
        Me.quantité.Size = New System.Drawing.Size(167, 35)
        Me.quantité.TabIndex = 5
        '
        'designation
        '
        Me.designation.Location = New System.Drawing.Point(557, 354)
        Me.designation.Multiline = True
        Me.designation.Name = "designation"
        Me.designation.Size = New System.Drawing.Size(167, 35)
        Me.designation.TabIndex = 5
        '
        'Code
        '
        Me.Code.Location = New System.Drawing.Point(557, 540)
        Me.Code.Multiline = True
        Me.Code.Name = "Code"
        Me.Code.Size = New System.Drawing.Size(167, 35)
        Me.Code.TabIndex = 8
        '
        'Prix
        '
        Me.Prix.Location = New System.Drawing.Point(557, 636)
        Me.Prix.Multiline = True
        Me.Prix.Name = "Prix"
        Me.Prix.Size = New System.Drawing.Size(167, 35)
        Me.Prix.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(261, 260)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(233, 34)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Id-produit"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(261, 354)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(233, 34)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Désignation"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(261, 541)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(233, 34)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Code"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(261, 451)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(233, 34)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Quantité"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(261, 637)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(233, 34)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Prix"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1108, 622)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(248, 34)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Fournisseur"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1108, 502)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(248, 34)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "No-Dépôt"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1108, 381)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(248, 34)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Type"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(1108, 256)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(248, 34)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Etat de  Stock"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1296, 918)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(168, 39)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "Annuler"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Stock
        '
        Me.Stock.FormattingEnabled = True
        Me.Stock.Items.AddRange(New Object() {"Disponible", "Rupture"})
        Me.Stock.Location = New System.Drawing.Point(1429, 263)
        Me.Stock.Name = "Stock"
        Me.Stock.Size = New System.Drawing.Size(167, 24)
        Me.Stock.TabIndex = 38
        '
        'Type
        '
        Me.Type.FormattingEnabled = True
        Me.Type.Items.AddRange(New Object() {"Produit Alimentaire", "Produit netoyage", "equipement cuisine"})
        Me.Type.Location = New System.Drawing.Point(1429, 388)
        Me.Type.Name = "Type"
        Me.Type.Size = New System.Drawing.Size(167, 24)
        Me.Type.TabIndex = 39
        '
        'DEpot
        '
        Me.DEpot.FormattingEnabled = True
        Me.DEpot.Items.AddRange(New Object() {"Dépot 1", "Dépot 2"})
        Me.DEpot.Location = New System.Drawing.Point(1429, 509)
        Me.DEpot.Name = "DEpot"
        Me.DEpot.Size = New System.Drawing.Size(167, 24)
        Me.DEpot.TabIndex = 40
        '
        'Four
        '
        Me.Four.FormattingEnabled = True
        Me.Four.Items.AddRange(New Object() {"F1", "F2"})
        Me.Four.Location = New System.Drawing.Point(1429, 629)
        Me.Four.Name = "Four"
        Me.Four.Size = New System.Drawing.Size(167, 24)
        Me.Four.TabIndex = 41
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1108, 714)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(248, 34)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Barcode"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1429, 713)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(167, 35)
        Me.TextBox1.TabIndex = 42
        '
        'Produit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1942, 989)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Four)
        Me.Controls.Add(Me.DEpot)
        Me.Controls.Add(Me.Type)
        Me.Controls.Add(Me.Stock)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Code)
        Me.Controls.Add(Me.Prix)
        Me.Controls.Add(Me.designation)
        Me.Controls.Add(Me.quantité)
        Me.Controls.Add(Me.id_prod)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Produit"
        Me.Text = "Gestion des Clients"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents id_prod As TextBox
    Friend WithEvents quantité As TextBox
    Friend WithEvents designation As TextBox
    Friend WithEvents Code As TextBox
    Friend WithEvents Prix As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Stock As ComboBox
    Friend WithEvents Type As ComboBox
    Friend WithEvents DEpot As ComboBox
    Friend WithEvents Four As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
End Class
