<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ouvrier
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ouvrier))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.grade = New System.Windows.Forms.ComboBox()
        Me.contrat = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.etat_civile = New System.Windows.Forms.ComboBox()
        Me.age = New System.Windows.Forms.TextBox()
        Me.salaire = New System.Windows.Forms.TextBox()
        Me.nom = New System.Windows.Forms.TextBox()
        Me.prenom = New System.Windows.Forms.TextBox()
        Me.id_ouv = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.avance = New System.Windows.Forms.TextBox()
        Me.id_conje = New System.Windows.Forms.TextBox()
        Me.prime = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.charge = New System.Windows.Forms.TextBox()
        Me.no_cin = New System.Windows.Forms.TextBox()
        Me.crédit = New System.Windows.Forms.TextBox()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.password = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label17 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1164, 933)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(168, 39)
        Me.Button2.TabIndex = 59
        Me.Button2.Text = "Annuler"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(682, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(197, 34)
        Me.Label5.TabIndex = 58
        Me.Label5.Text = "Charge (CNSS)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(682, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(197, 34)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Etat Civile"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(138, 731)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(218, 34)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "No-CIN"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(138, 637)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(218, 34)
        Me.Label15.TabIndex = 55
        Me.Label15.Text = "Salaire"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(138, 540)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(218, 34)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Grade"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(138, 443)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(218, 34)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Age"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(138, 354)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(218, 34)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Prénom"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(138, 257)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(218, 34)
        Me.Label11.TabIndex = 51
        Me.Label11.Text = "Nom"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grade
        '
        Me.grade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.grade.FormattingEnabled = True
        Me.grade.Items.AddRange(New Object() {"Caissier", "Responsable", "Administration", "Magasinier"})
        Me.grade.Location = New System.Drawing.Point(419, 547)
        Me.grade.Name = "grade"
        Me.grade.Size = New System.Drawing.Size(167, 24)
        Me.grade.TabIndex = 49
        '
        'contrat
        '
        Me.contrat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.contrat.FormattingEnabled = True
        Me.contrat.Items.AddRange(New Object() {"Contrat à Durée Indéterminée (CDI)", "Contrat à Durée Déterminée (CDD)", "Contrat d'Initiation à la Vie Professionnelle (CIVP)"})
        Me.contrat.Location = New System.Drawing.Point(1494, 173)
        Me.contrat.Name = "contrat"
        Me.contrat.Size = New System.Drawing.Size(393, 24)
        Me.contrat.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(138, 163)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(218, 34)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Id-Ouvrier"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'etat_civile
        '
        Me.etat_civile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.etat_civile.FormattingEnabled = True
        Me.etat_civile.Items.AddRange(New Object() {"Marié", "Célébtaire"})
        Me.etat_civile.Location = New System.Drawing.Point(942, 173)
        Me.etat_civile.Name = "etat_civile"
        Me.etat_civile.Size = New System.Drawing.Size(167, 24)
        Me.etat_civile.TabIndex = 46
        '
        'age
        '
        Me.age.Location = New System.Drawing.Point(419, 443)
        Me.age.Multiline = True
        Me.age.Name = "age"
        Me.age.Size = New System.Drawing.Size(167, 35)
        Me.age.TabIndex = 44
        '
        'salaire
        '
        Me.salaire.Location = New System.Drawing.Point(419, 637)
        Me.salaire.Multiline = True
        Me.salaire.Name = "salaire"
        Me.salaire.Size = New System.Drawing.Size(167, 35)
        Me.salaire.TabIndex = 45
        '
        'nom
        '
        Me.nom.Location = New System.Drawing.Point(419, 257)
        Me.nom.Multiline = True
        Me.nom.Name = "nom"
        Me.nom.Size = New System.Drawing.Size(167, 35)
        Me.nom.TabIndex = 43
        '
        'prenom
        '
        Me.prenom.Location = New System.Drawing.Point(419, 353)
        Me.prenom.Multiline = True
        Me.prenom.Name = "prenom"
        Me.prenom.Size = New System.Drawing.Size(167, 35)
        Me.prenom.TabIndex = 42
        '
        'id_ouv
        '
        Me.id_ouv.Location = New System.Drawing.Point(419, 162)
        Me.id_ouv.Multiline = True
        Me.id_ouv.Name = "id_ouv"
        Me.id_ouv.Size = New System.Drawing.Size(167, 35)
        Me.id_ouv.TabIndex = 41
        '
        'ComboBox1
        '
        Me.ComboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Ajouter un Ouvrier", "Modifier un Ouvrier", "Supprimer un Ouvrier", "Rechercher un Ouvrier"})
        Me.ComboBox1.Location = New System.Drawing.Point(1507, 71)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(390, 30)
        Me.ComboBox1.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.Label1.Location = New System.Drawing.Point(1141, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(336, 26)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Gerer les Ouvriers"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(464, 933)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 39)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(682, 645)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(197, 34)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Avance"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(683, 542)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(196, 34)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Prime"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1196, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(179, 34)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Contrat"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1196, 353)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(179, 34)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "Date Embauche"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'avance
        '
        Me.avance.Location = New System.Drawing.Point(942, 644)
        Me.avance.Multiline = True
        Me.avance.Name = "avance"
        Me.avance.Size = New System.Drawing.Size(167, 35)
        Me.avance.TabIndex = 63
        '
        'id_conje
        '
        Me.id_conje.Location = New System.Drawing.Point(942, 449)
        Me.id_conje.Multiline = True
        Me.id_conje.Name = "id_conje"
        Me.id_conje.Size = New System.Drawing.Size(167, 35)
        Me.id_conje.TabIndex = 64
        '
        'prime
        '
        Me.prime.Location = New System.Drawing.Point(942, 547)
        Me.prime.Multiline = True
        Me.prime.Name = "prime"
        Me.prime.Size = New System.Drawing.Size(167, 35)
        Me.prime.TabIndex = 61
        '
        'Label19
        '
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(682, 354)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(197, 34)
        Me.Label19.TabIndex = 76
        Me.Label19.Text = "Crédits"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(682, 444)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(197, 34)
        Me.Label20.TabIndex = 75
        Me.Label20.Text = "Id-Congé"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'charge
        '
        Me.charge.Location = New System.Drawing.Point(942, 256)
        Me.charge.Multiline = True
        Me.charge.Name = "charge"
        Me.charge.Size = New System.Drawing.Size(167, 35)
        Me.charge.TabIndex = 73
        '
        'no_cin
        '
        Me.no_cin.Location = New System.Drawing.Point(419, 731)
        Me.no_cin.Multiline = True
        Me.no_cin.Name = "no_cin"
        Me.no_cin.Size = New System.Drawing.Size(167, 35)
        Me.no_cin.TabIndex = 74
        '
        'crédit
        '
        Me.crédit.Location = New System.Drawing.Point(942, 353)
        Me.crédit.Multiline = True
        Me.crédit.Name = "crédit"
        Me.crédit.Size = New System.Drawing.Size(167, 35)
        Me.crédit.TabIndex = 70
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(1494, 234)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 77
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1197, 535)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(179, 34)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Mot de passe"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'password
        '
        Me.password.Location = New System.Drawing.Point(1494, 535)
        Me.password.Multiline = True
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(214, 35)
        Me.password.TabIndex = 78
        '
        'Label16
        '
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(1197, 662)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(179, 34)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "Image"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(1494, 609)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(167, 134)
        Me.PictureBox1.TabIndex = 80
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1494, 264)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(214, 35)
        Me.TextBox1.TabIndex = 82
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PictureBox2.Location = New System.Drawing.Point(1494, 783)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(167, 149)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 83
        Me.PictureBox2.TabStop = False
        '
        'Label17
        '
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1196, 815)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(179, 34)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "QR Code"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Ouvrier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1046)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.charge)
        Me.Controls.Add(Me.no_cin)
        Me.Controls.Add(Me.crédit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.avance)
        Me.Controls.Add(Me.id_conje)
        Me.Controls.Add(Me.prime)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.grade)
        Me.Controls.Add(Me.contrat)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.etat_civile)
        Me.Controls.Add(Me.age)
        Me.Controls.Add(Me.salaire)
        Me.Controls.Add(Me.nom)
        Me.Controls.Add(Me.prenom)
        Me.Controls.Add(Me.id_ouv)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Ouvrier"
        Me.Text = "Ouvrier"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents grade As ComboBox
    Friend WithEvents contrat As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents etat_civile As ComboBox
    Friend WithEvents age As TextBox
    Friend WithEvents salaire As TextBox
    Friend WithEvents nom As TextBox
    Friend WithEvents prenom As TextBox
    Friend WithEvents id_ouv As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents avance As TextBox
    Friend WithEvents id_conje As TextBox
    Friend WithEvents prime As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents charge As TextBox
    Friend WithEvents no_cin As TextBox
    Friend WithEvents crédit As TextBox
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents Label2 As Label
    Friend WithEvents password As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label17 As Label
End Class
