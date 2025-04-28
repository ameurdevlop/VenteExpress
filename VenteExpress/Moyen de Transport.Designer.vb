<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Moyen_de_Transport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Moyen_de_Transport))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Matricule = New System.Windows.Forms.TextBox()
        Me.Designation = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.MonthCalendar2 = New System.Windows.Forms.MonthCalendar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dat_achat = New System.Windows.Forms.TextBox()
        Me.Dat_reparation = New System.Windows.Forms.TextBox()
        Me.Assurance = New System.Windows.Forms.ComboBox()
        Me.Vignette = New System.Windows.Forms.ComboBox()
        Me.Etat = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1330, 863)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(186, 39)
        Me.Button2.TabIndex = 69
        Me.Button2.Text = "Annuler"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(440, 598)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(274, 34)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Assurance"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(440, 505)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(274, 34)
        Me.Label4.TabIndex = 67
        Me.Label4.Text = "Etat"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(440, 409)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(274, 34)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "Désignation"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(440, 302)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(274, 34)
        Me.Label11.TabIndex = 65
        Me.Label11.Text = "Matricule"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Matricule
        '
        Me.Matricule.Location = New System.Drawing.Point(763, 300)
        Me.Matricule.Multiline = True
        Me.Matricule.Name = "Matricule"
        Me.Matricule.Size = New System.Drawing.Size(167, 35)
        Me.Matricule.TabIndex = 61
        '
        'Designation
        '
        Me.Designation.Location = New System.Drawing.Point(763, 408)
        Me.Designation.Multiline = True
        Me.Designation.Name = "Designation"
        Me.Designation.Size = New System.Drawing.Size(167, 35)
        Me.Designation.TabIndex = 60
        '
        'ComboBox1
        '
        Me.ComboBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Ajouter un Matériel de Transport", "Modifier un Matériel de Transport", "Supprimer un Matériel de Transport", "Rechercher un Matériel de Transport"})
        Me.ComboBox1.Location = New System.Drawing.Point(1515, 83)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(390, 30)
        Me.ComboBox1.TabIndex = 58
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!)
        Me.Label1.Location = New System.Drawing.Point(1040, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(459, 33)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Gerer le Matériel de Transport"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(440, 863)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 39)
        Me.Button1.TabIndex = 56
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(440, 693)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(274, 34)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Vignette"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1050, 352)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(242, 34)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Data Achat"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(1346, 276)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 73
        '
        'MonthCalendar2
        '
        Me.MonthCalendar2.Location = New System.Drawing.Point(1346, 526)
        Me.MonthCalendar2.Name = "MonthCalendar2"
        Me.MonthCalendar2.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1050, 554)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(249, 34)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "Data Réparation"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dat_achat
        '
        Me.Dat_achat.Location = New System.Drawing.Point(1395, 350)
        Me.Dat_achat.Multiline = True
        Me.Dat_achat.Name = "Dat_achat"
        Me.Dat_achat.Size = New System.Drawing.Size(167, 35)
        Me.Dat_achat.TabIndex = 77
        '
        'Dat_reparation
        '
        Me.Dat_reparation.Location = New System.Drawing.Point(1395, 553)
        Me.Dat_reparation.Multiline = True
        Me.Dat_reparation.Name = "Dat_reparation"
        Me.Dat_reparation.Size = New System.Drawing.Size(167, 35)
        Me.Dat_reparation.TabIndex = 76
        '
        'Assurance
        '
        Me.Assurance.FormattingEnabled = True
        Me.Assurance.Items.AddRange(New Object() {"Payer", "Non Payer"})
        Me.Assurance.Location = New System.Drawing.Point(763, 605)
        Me.Assurance.Name = "Assurance"
        Me.Assurance.Size = New System.Drawing.Size(167, 24)
        Me.Assurance.TabIndex = 78
        '
        'Vignette
        '
        Me.Vignette.FormattingEnabled = True
        Me.Vignette.Items.AddRange(New Object() {"Payer", "Non Payer"})
        Me.Vignette.Location = New System.Drawing.Point(763, 700)
        Me.Vignette.Name = "Vignette"
        Me.Vignette.Size = New System.Drawing.Size(167, 24)
        Me.Vignette.TabIndex = 79
        '
        'Etat
        '
        Me.Etat.FormattingEnabled = True
        Me.Etat.Items.AddRange(New Object() {"En Marche", "En Panne", "En Reparation"})
        Me.Etat.Location = New System.Drawing.Point(763, 512)
        Me.Etat.Name = "Etat"
        Me.Etat.Size = New System.Drawing.Size(167, 24)
        Me.Etat.TabIndex = 80
        '
        'Moyen_de_Transport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.Etat)
        Me.Controls.Add(Me.Vignette)
        Me.Controls.Add(Me.Assurance)
        Me.Controls.Add(Me.Dat_achat)
        Me.Controls.Add(Me.Dat_reparation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.MonthCalendar2)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Matricule)
        Me.Controls.Add(Me.Designation)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Moyen_de_Transport"
        Me.Text = "Moyen_de_Transport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Matricule As TextBox
    Friend WithEvents Designation As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents MonthCalendar2 As MonthCalendar
    Friend WithEvents Label5 As Label
    Friend WithEvents Dat_achat As TextBox
    Friend WithEvents Dat_reparation As TextBox
    Friend WithEvents Assurance As ComboBox
    Friend WithEvents Vignette As ComboBox
    Friend WithEvents Etat As ComboBox
End Class
