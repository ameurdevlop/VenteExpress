<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pointage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pointage))
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.ComboBoxWebcams = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.PictureBoxWebcam = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBoxWebcam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Location = New System.Drawing.Point(815, 43)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(51, 17)
        Me.LabelStatus.TabIndex = 16
        Me.LabelStatus.Text = "Label1"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1383, 556)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(121, 33)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Close"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(1383, 318)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(121, 33)
        Me.ButtonStop.TabIndex = 14
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ComboBoxWebcams
        '
        Me.ComboBoxWebcams.FormattingEnabled = True
        Me.ComboBoxWebcams.Location = New System.Drawing.Point(380, 606)
        Me.ComboBoxWebcams.Name = "ComboBoxWebcams"
        Me.ComboBoxWebcams.Size = New System.Drawing.Size(181, 24)
        Me.ComboBoxWebcams.TabIndex = 13
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(178, 464)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(512, 22)
        Me.TextBox1.TabIndex = 12
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(1383, 113)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(121, 33)
        Me.ButtonStart.TabIndex = 10
        Me.ButtonStart.Text = "Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'PictureBoxWebcam
        '
        Me.PictureBoxWebcam.Location = New System.Drawing.Point(187, 83)
        Me.PictureBoxWebcam.Name = "PictureBoxWebcam"
        Me.PictureBoxWebcam.Size = New System.Drawing.Size(430, 271)
        Me.PictureBoxWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxWebcam.TabIndex = 11
        Me.PictureBoxWebcam.TabStop = False
        '
        'Pointage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.LabelStatus)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ButtonStop)
        Me.Controls.Add(Me.ComboBoxWebcams)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBoxWebcam)
        Me.Controls.Add(Me.ButtonStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Pointage"
        Me.Text = "Pointage"
        CType(Me.PictureBoxWebcam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelStatus As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents ButtonStop As Button
    Friend WithEvents ComboBoxWebcams As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBoxWebcam As PictureBox
    Friend WithEvents ButtonStart As Button
End Class
