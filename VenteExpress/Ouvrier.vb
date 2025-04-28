Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports MessagingToolkit.QRCode.Codec
Imports ZXing
Imports ZXing.Windows.Compatibility



Public Class Ouvrier
    Private Sub Ouvrier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetControls()
        Label2.Visible = False
        password.Visible = False
    End Sub
    Private Sub ResetControls()
        id_ouv.Visible = False
        id_ouv.Enabled = False
        password.Visible = False
        PictureBox1.Visible = False
        Label16.Visible = False
        prenom.Visible = False
        prenom.Enabled = False
        nom.Visible = False
        nom.Enabled = False
        age.Visible = False
        age.Enabled = False
        salaire.Visible = False
        salaire.Enabled = False
        etat_civile.Visible = False
        etat_civile.Enabled = False
        contrat.Visible = False
        contrat.Enabled = False
        grade.Visible = False
        grade.Enabled = False
        Label1.Visible = True
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
        Button1.Visible = False
        Button2.Visible = False
        MonthCalendar1.Visible = False
        MonthCalendar1.Enabled = False
        Label9.Visible = False
        Label9.Enabled = False
        Label19.Visible = False
        Label19.Enabled = False
        crédit.Visible = False
        crédit.Enabled = False
        charge.Visible = False
        charge.Enabled = False
        no_cin.Visible = False
        no_cin.Enabled = False
        Label20.Visible = False
        Label20.Visible = False
        id_conje.Visible = False
        id_conje.Enabled = False
        prime.Visible = False
        prime.Enabled = False
        avance.Visible = False
        avance.Enabled = False
        Label3.Visible = False
        Label3.Visible = False
        Label7.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label8.Visible = False
        Label2.Visible = False
        Label2.Enabled = False
        password.Visible = False
        TextBox1.Visible = False
        password.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter un Ouvrier"
                ' Créer des listes pour chaque groupe de contrôles
                Dim visiblesEtActives As Control() = {id_ouv, prenom, nom, age, salaire, etat_civile, contrat, grade,
                                      Label1, Label4, Label5, Label6, Label10, Label11, Label12, Label13, Label14, Label15,
                                      Button1, Button2, MonthCalendar1, Label9, charge, no_cin, Label8, PictureBox1, Label16}

                Dim visiblesEtInactives As Control() = {Label19, crédit, Label20, id_conje, prime, avance, Label3, Label7, TextBox1}

                ' Activer et rendre visibles les contrôles listés dans visiblesEtActives
                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                ' Désactiver et cacher les contrôles listés dans visiblesEtInactives
                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = False
                    ctrl.Enabled = False
                Next
            Case "Supprimer un Ouvrier"
                For Each ctrl As Control In Me.Controls
                    ' Show all controls
                    ctrl.Visible = True

                    ' Enable only Labels and specific controls
                    If TypeOf ctrl Is Label OrElse ctrl Is Label3 OrElse ctrl Is Label7 OrElse ctrl Is Label8 OrElse ctrl Is Label9 OrElse ctrl Is Label19 OrElse ctrl Is Label20 OrElse ctrl Is ComboBox1 Then
                        ctrl.Enabled = True
                    ElseIf ctrl Is Button1 OrElse ctrl Is Button2 Then
                        ctrl.Enabled = True
                    ElseIf ctrl Is id_ouv Then
                        ctrl.Enabled = True
                    Else
                        ctrl.Enabled = False
                    End If
                Next

                ' Hide and disable the calendar explicitly
                MonthCalendar1.Visible = False
                MonthCalendar1.Enabled = False
            Case "Rechercher un Ouvrier"
                For Each ctrl As Control In Me.Controls
                    ' Show all controls
                    ctrl.Visible = True

                    ' Enable only Labels and specific controls
                    If TypeOf ctrl Is Label OrElse ctrl Is Label3 OrElse ctrl Is Label7 OrElse ctrl Is Label8 OrElse ctrl Is Label9 OrElse ctrl Is Label19 OrElse ctrl Is Label20 OrElse ctrl Is ComboBox1 Then
                        ctrl.Enabled = True
                    ElseIf ctrl Is Button1 OrElse ctrl Is Button2 Then
                        ctrl.Enabled = True
                    ElseIf ctrl Is id_ouv Then
                        ctrl.Enabled = True
                    Else
                        ctrl.Enabled = False
                    End If
                Next

                ' Hide and disable the calendar explicitly
                MonthCalendar1.Visible = False
                MonthCalendar1.Enabled = False

            Case "Modifier un Ouvrier"
                ' List of controls to make visible and enabled
                Dim enableAndShowControls As Control() = {
                            id_ouv, prenom, nom, age, salaire, etat_civile, contrat, grade,
                            Button1, Button2, MonthCalendar1, crédit, charge, no_cin,
                            id_conje, prime, avance, Label19, Label9, password, Label2, PictureBox1, Label16
                        }

                ' Enable and show the controls in the list
                For Each ctrl As Control In enableAndShowControls
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                ' List of labels to make visible (no enabling needed for labels usually)
                Dim showLabels As Control() = {
                            Label1, Label4, Label5, Label6, Label10, Label11, Label12,
                            Label13, Label14, Label15, Label9, Label19, Label20,
                            Label3, Label7, Label8
                        }

                For Each lbl As Control In showLabels
                    lbl.Visible = True
                Next

                ' Special case: hide only TextBox1
                TextBox1.Visible = False

            Case Else
                ' Gérer les autres cas ou aucune sélection
                ResetControls()
        End Select
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub
    ' Function to convert PictureBox image to byte array
    Private Function ImageToByteArray(pic As PictureBox) As Byte()
        If pic.Image Is Nothing Then Return Nothing
        Using ms As New MemoryStream()
            pic.Image.Save(ms, Imaging.ImageFormat.Jpeg)
            Return ms.ToArray()
        End Using
    End Function


    Private Function ResizeImageToFit(img As Image, boxSize As Size) As Image
        Dim ratioX As Double = boxSize.Width / img.Width
        Dim ratioY As Double = boxSize.Height / img.Height
        Dim ratio As Double = Math.Min(ratioX, ratioY)

        Dim newWidth As Integer = CInt(img.Width * ratio)
        Dim newHeight As Integer = CInt(img.Height * ratio)

        Dim resized As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(resized)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using

        Return resized
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Ajouter un Ouvrier" Then

                ' Vérification des champs vides
                If String.IsNullOrWhiteSpace(id_ouv.Text) OrElse String.IsNullOrWhiteSpace(nom.Text) OrElse String.IsNullOrWhiteSpace(prenom.Text) OrElse String.IsNullOrWhiteSpace(age.Text) OrElse String.IsNullOrWhiteSpace(grade.Text) OrElse String.IsNullOrWhiteSpace(salaire.Text) OrElse String.IsNullOrWhiteSpace(etat_civile.Text) OrElse String.IsNullOrWhiteSpace(no_cin.Text) OrElse String.IsNullOrWhiteSpace(charge.Text) OrElse String.IsNullOrWhiteSpace(contrat.Text) Then
                    MessageBox.Show("Entrez des valeurs dans les champs requis.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return ' Quitter la sous-routine si des champs sont vides
                End If

                ' Ouvrir la connexion à la base de données
                ouvrir_connection()

                Try
                    ' Vérification de l'unicité de l'ID_ouvrier et du No_CIN
                    Dim sqlCheck As String = "SELECT COUNT(*) FROM Ouvrier WHERE ID_ouvrier = @ID_OUV OR No_CIN = @CIN"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sqlCheck
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_OUV", id_ouv.Text.Trim())
                    Cmd.Parameters.AddWithValue("@CIN", no_cin.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("L'ID ouvrier ou le No_CIN existe déjà dans la base de données. Veuillez vérifier.", "Erreur de Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Générer le code QR basé sur l'ID de l'ouvrier
                        Dim barcodeText As String = id_ouv.Text ' Récupérer le texte pour le code-barres  

                        ' Vérifie si le texte n'est pas vide  
                        If String.IsNullOrEmpty(barcodeText) Then
                            MessageBox.Show("Veuillez entrer un texte pour générer le code-QR.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If

                        ' Créer un barcode writer  
                        Dim barcodeWriter As New BarcodeWriter()
                        barcodeWriter.Format = BarcodeFormat.QR_CODE ' Choisissez le format de code-barres  
                        barcodeWriter.Options.Width = 150 ' Largeur du code-barres  
                        barcodeWriter.Options.Height = 150 ' Hauteur du code-barres  

                        ' Générer le code-barres  
                        Dim result As Bitmap = barcodeWriter.Write(barcodeText)

                        ' Afficher le code-barres dans le PictureBox  
                        PictureBox2.Image = result


                        Dim qrCodeBytes As Byte() = Nothing
                        Using ms As New MemoryStream()
                            result.Save(ms, Imaging.ImageFormat.Png) ' Vous pouvez choisir un autre format comme Jpeg si nécessaire
                            qrCodeBytes = ms.ToArray()
                        End Using


                        ' Insérer les données de l'ouvrier et le code QR
                        Dim sqlInsert As String = "INSERT INTO Ouvrier (ID_ouvrier, Nom, prénom, Age, Grade, Salaire, No_CIN, [Etat civile], Charge, Contrat, [Date embauche], mot_de_passe, Photo, QRCode) VALUES (@ID_OUV, @NAME, @PRE, @AGE, @GRA, @SAL, @CIN, @Etat, @CHARGE, @CONTR, @DateEMB, @MDP, @Photo, @QRCode)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sqlInsert
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_OUV", id_ouv.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NAME", nom.Text.Trim())
                        Cmd.Parameters.AddWithValue("@PRE", prenom.Text.Trim())
                        Cmd.Parameters.AddWithValue("@AGE", age.Text.Trim())
                        Cmd.Parameters.AddWithValue("@GRA", grade.Text.Trim())
                        Cmd.Parameters.AddWithValue("@SAL", salaire.Text.Trim())
                        Cmd.Parameters.AddWithValue("@CIN", no_cin.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Etat", etat_civile.Text.Trim())
                        Cmd.Parameters.AddWithValue("@CHARGE", charge.Text.Trim())
                        Cmd.Parameters.AddWithValue("@CONTR", contrat.Text.Trim())
                        Cmd.Parameters.AddWithValue("@DateEMB", MonthCalendar1.SelectionStart)
                        Cmd.Parameters.AddWithValue("@MDP", password.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Photo", ImageToByteArray(PictureBox1))
                        Cmd.Parameters.AddWithValue("@QRCode", qrCodeBytes)

                        Cmd.ExecuteNonQuery()

                        MessageBox.Show("Ouvrier ajouté avec succès avec un code QR!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        '
                    End If

                Catch ex As Exception
                    MessageBox.Show("Erreur lors de l'ajout de l'ouvrier et de la génération du code QR : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    ' S'assurer que la connexion est fermée dans le bloc Finally
                    fermer_connection()
                End Try
            End If
        End If





        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer un Ouvrier" Then
                If String.IsNullOrWhiteSpace(id_ouv.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Ouvrier WHERE ID_ouvrier = @ID_OUV"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_OUV", id_ouv.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show(" Ouvrier supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("L'ouvrier n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        fermer_connection()
                    End Try
                End If
            End If
        End If

        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Rechercher un Ouvrier" Then
                If String.IsNullOrWhiteSpace(id_ouv.Text) Then
                    MessageBox.Show("Enter a value in the required field.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ' Correct table name to "Ouvrier"
                        sql = "SELECT * FROM Ouvrier WHERE ID_ouvrier = @ID_OUV"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_OUV", id_ouv.Text.Trim())

                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            dr.Read()
                            MessageBox.Show("Ouvrier found.")

                            id_ouv.Text = dr("ID_ouvrier").ToString()
                            nom.Text = dr("Nom").ToString()
                            prenom.Text = dr("prénom").ToString()
                            age.Text = dr("Age").ToString()
                            grade.Text = dr("Grade").ToString()
                            salaire.Text = dr("Salaire").ToString()
                            no_cin.Text = dr("No_CIN").ToString()
                            etat_civile.Text = dr("Etat civile").ToString()
                            charge.Text = dr("Charge").ToString()
                            crédit.Text = dr("Crédits").ToString()
                            id_conje.Text = dr("ID_conjé").ToString()
                            prime.Text = dr("Prime").ToString()
                            avance.Text = dr("Avance").ToString()
                            contrat.Text = dr("Contrat").ToString()
                            TextBox1.Text = dr("Date embauche").ToString()
                            password.Text = dr("mot_de_passe").ToString()

                            ' Load image
                            If Not IsDBNull(dr("Photo")) Then
                                Dim imgBytes() As Byte = CType(dr("Photo"), Byte())
                                Using ms As New MemoryStream(imgBytes)
                                    PictureBox1.Image = Image.FromStream(ms)
                                End Using
                            Else
                                PictureBox1.Image = Nothing
                            End If

                            If Not IsDBNull(dr("QRCode")) Then
                                Dim imgBytes() As Byte = CType(dr("QRCode"), Byte())
                                Using ms As New MemoryStream(imgBytes)
                                    PictureBox2.Image = Image.FromStream(ms)
                                End Using
                            Else
                                PictureBox1.Image = Nothing
                                PictureBox2.Image = Nothing
                            End If

                        Else
                            MessageBox.Show("No result found with this ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                    Catch ex As Exception
                        MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Finally
                        If Not dr Is Nothing AndAlso Not dr.IsClosed Then dr.Close()
                        fermer_connection()
                    End Try
                End If
            End If
        End If




        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier un Ouvrier" Then
                If String.IsNullOrWhiteSpace(id_ouv.Text) Then
                    MessageBox.Show("Entrer l'ID de ouvrier...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_OUV", id_ouv.Text.Trim())

                        ' Build SET clause only for non-empty fields

                        If Not String.IsNullOrWhiteSpace(nom.Text) Then
                            updates.Add("Nom = @NOM")
                            Cmd.Parameters.AddWithValue("@NOM", nom.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(prenom.Text) Then
                            updates.Add("prénom = @PRE")
                            Cmd.Parameters.AddWithValue("@PRE", prenom.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(age.Text) Then
                            updates.Add("Age = @AGE")
                            Cmd.Parameters.AddWithValue("@AGE", age.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(grade.Text) Then
                            updates.Add("Grade = @GRADE")
                            Cmd.Parameters.AddWithValue("@GRADE", grade.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(salaire.Text) Then
                            updates.Add("Salaire = @SAL")
                            Cmd.Parameters.AddWithValue("@SAL", salaire.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(no_cin.Text) Then
                            updates.Add("No_CIN = @CIN")
                            Cmd.Parameters.AddWithValue("@CIN", no_cin.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(etat_civile.Text) Then
                            updates.Add("Etat civile = @CIV")
                            Cmd.Parameters.AddWithValue("@DEP", etat_civile.Text.Trim())
                        End If


                        If Not String.IsNullOrWhiteSpace(charge.Text) Then
                            updates.Add("Charge = @CAH")
                            Cmd.Parameters.AddWithValue("@CAH", charge.Text.Trim())
                        End If
                        'flkfdfldsfds
                        If Not String.IsNullOrWhiteSpace(crédit.Text) Then
                            updates.Add("Crédits = @CRE")
                            Cmd.Parameters.AddWithValue("@CRE", crédit.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(id_conje.Text) Then
                            updates.Add("ID_conjé = @CONJ")
                            Cmd.Parameters.AddWithValue("@CONJ", id_conje.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(prime.Text) Then
                            updates.Add("Prime = @PRIM")
                            Cmd.Parameters.AddWithValue("@PRIM", prime.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(avance.Text) Then
                            updates.Add("Avance = @AVA")
                            Cmd.Parameters.AddWithValue("@AVA", avance.Text.Trim())
                        End If


                        If Not String.IsNullOrWhiteSpace(contrat.Text) Then
                            updates.Add("Contrat = @CONT")
                            Cmd.Parameters.AddWithValue("@CONT", contrat.Text.Trim())
                        End If
                        If Not String.IsNullOrWhiteSpace(id_ouv.Text) Then
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            updates.Add("[Date embauche] = @DATA")
                            Cmd.Parameters.AddWithValue("@DATA", selectedDate)
                        End If

                        If Not String.IsNullOrWhiteSpace(password.Text) Then
                            updates.Add("mot_de_passe = @PASS")
                            Cmd.Parameters.AddWithValue("@PASS", password.Text.Trim())
                        End If

                        If PictureBox1.Image IsNot Nothing Then
                            updates.Add("Photo = @PIC")
                            Cmd.Parameters.AddWithValue("@PIC", ImageToByteArray(PictureBox1))
                        End If

                        ' Check if there is at least one field to update
                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Ouvrier SET " & String.Join(", ", updates) & " WHERE ID_ouvrier = @ID_OUV"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("ouvrier modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        fermer_connection()
                    End Try
                End If
            End If
        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Select an image"
        ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim originalImage As Image = Image.FromFile(ofd.FileName)

            ' Resize image proportionally to fit PictureBox
            Dim resizedImage As Image = ResizeImageToFit(originalImage, PictureBox1.Size)

            ' Display it
            PictureBox1.Image = resizedImage
            PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        id_ouv.Text = ""
        nom.Text = ""
        prenom.Text = ""
        age.Text = ""
        grade.Text = ""
        PictureBox2.Image = Nothing
        salaire.Text = ""
        no_cin.Text = ""
        etat_civile.Text = ""
        charge.Text = ""
        contrat.Text = ""
        password.Text = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub grade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grade.SelectedIndexChanged
        If grade.SelectedItem IsNot Nothing Then
            Dim selectedGrade As String = grade.SelectedItem.ToString()

            ' Example: Show the fields only if the selected grade is "Chef"
            If selectedGrade = "Caissier" Then
                Label2.Visible = True
                password.Visible = True
                Label2.Enabled = True
                password.Enabled = True
            ElseIf selectedGrade = "Administration" Then
                Label2.Visible = True
                password.Visible = True
                Label2.Enabled = True
                password.Enabled = True
            Else
                Label2.Visible = False
                password.Visible = False
                Label2.Visible = False
                password.Visible = False
            End If
        End If
    End Sub


End Class