Public Class Fournisseur
    Private Sub Fournisseur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
    End Sub
    Private Sub ResetItems()
        ' Créer des listes pour regrouper les contrôles selon leurs états
        Dim invisiblesEtInactives As Control() = {TextBox1, TextBox2, TextBox3, ComboBox2, Button1, Button2,
                                                  Label4, Label10, Label11, Label13}

        ' Rendre invisibles et désactiver les contrôles listés dans invisiblesEtInactives
        For Each ctrl In invisiblesEtInactives
            ctrl.Visible = False
            ctrl.Enabled = False
        Next

        ' Réinitialiser le texte des contrôles nécessaires
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter un Fournisseur"
                ' Créer des listes pour regrouper les contrôles selon leurs états
                Dim visiblesEtActives As Control() = {TextBox1, TextBox2, TextBox3, ComboBox2, Button1, Button2,
                                                       Label1, Label4, Label10, Label11, Label13}

                ' Rendre visibles et activer les contrôles listés dans visiblesEtActives
                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                ' Réinitialiser le texte des contrôles nécessaires
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                ComboBox2.Text = ""
            Case "Supprimer un Fournisseur"
                ' Créer des listes pour regrouper les contrôles selon leurs états
                Dim visiblesEtActives As Control() = {TextBox1, Button1, Button2, Label1, Label4, Label10, Label11, Label13}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, ComboBox2}

                ' Rendre visibles et activer les contrôles listés dans visiblesEtActives
                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                ' Rendre visibles mais désactiver les contrôles listés dans visiblesEtInactives
                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next

                ' Réinitialiser les textes des contrôles nécessaires
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                ComboBox2.Text = ""
            Case "Rechercher un Fournisseur"
                ' Groupes de contrôles selon leurs propriétés
                Dim visiblesEtActives As Control() = {TextBox1, Label1, Label4, Label10, Label11, Label13, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, ComboBox2}

                ' Rendre visibles et actives les contrôles dans visiblesEtActives
                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                ' Rendre visibles mais inactives les contrôles dans visiblesEtInactives
                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next

                ' Réinitialisation des textes
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                ComboBox2.Text = ""
            Case "Modifier un Fournisseur"
                ' Créer une liste pour les contrôles à rendre visibles et activés
                Dim visiblesEtActives As Control() = {TextBox1, TextBox2, TextBox3, ComboBox2, Button1, Button2,
                                       Label1, Label4, Label10, Label11, Label13}

                ' Boucle pour rendre tous les contrôles visibles et activés
                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                ' Réinitialiser les textes des contrôles nécessaires
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                ComboBox2.Text = ""
            Case Else
                ' Gérer les autres cas ou aucune sélection
                ResetItems()
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Ajouter un Fournisseur" Then

                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                    MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ' Open connection
                    ouvrir_connection()

                    sql = "SELECT COUNT(*) FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce Fournisseur est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "INSERT INTO Fournisseur (ID_fournisseur, Nom, Num_tel, Adresse ) VALUES (@ID_FR, @Name, @NMTE, @ADR)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NMTE", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ADR", ComboBox2.Text.Trim())

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Fournisseur ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    fermer_connection()
                End If
            End If
        End If



        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer un Fournisseur" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Fournisseur has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Fournisseur not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If selectedItem = "Rechercher un Fournisseur" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If (dr.HasRows = True) Then
                        MessageBox.Show(" Fournisseur existe .")
                        dr.Read()
                        TextBox1.Text = dr.Item("ID_fournisseur").ToString()
                        TextBox2.Text = dr.Item("Nom").ToString()
                        TextBox3.Text = dr.Item("Num_tel").ToString()
                        ComboBox2.Text = dr.Item("Adresse").ToString()

                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If






        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier un Fournisseur" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("Please enter the Fournisseur ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                        ' Build SET clause only for non-empty fields
                        If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                            updates.Add("Nom = @Name")
                            Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Num_tel = @NU_TE")
                            Cmd.Parameters.AddWithValue("@NU_TE", TextBox3.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                            If IsNumeric(ComboBox2.Text) Then
                                updates.Add("Adresse = @ADR")
                                Cmd.Parameters.AddWithValue("@adr", ComboBox2.Text.Trim())
                            Else
                                MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If


                        ' Check if there is at least one field to update
                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Fournisseur SET " & String.Join(", ", updates) & " WHERE ID_fournisseur = @ID_FR"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Fournisseur updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        fermer_connection()
                    End Try
                End If
            End If
        End If


    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Fournisseur" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Fournisseur est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Fournisseur (ID_fournisseur, Nom, Num_tel, Adresse ) VALUES (@ID_FR, @Name, @NMTE, @ADR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NMTE", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ADR", ComboBox2.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Fournisseur ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Fournisseur has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Fournisseur not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If (dr.HasRows = True) Then
                            MessageBox.Show(" Fournisseur existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_fournisseur").ToString()
                            TextBox2.Text = dr.Item("Nom").ToString()
                            TextBox3.Text = dr.Item("Num_tel").ToString()
                            ComboBox2.Text = dr.Item("Adresse").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If






            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Fournisseur ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Num_tel = @NU_TE")
                                Cmd.Parameters.AddWithValue("@NU_TE", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Adresse = @ADR")
                                    Cmd.Parameters.AddWithValue("@adr", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Fournisseur SET " & String.Join(", ", updates) & " WHERE ID_fournisseur = @ID_FR"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Fournisseur updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            fermer_connection()
                        End Try
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Fournisseur" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Fournisseur est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Fournisseur (ID_fournisseur, Nom, Num_tel, Adresse ) VALUES (@ID_FR, @Name, @NMTE, @ADR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NMTE", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ADR", ComboBox2.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Fournisseur ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Fournisseur has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Fournisseur not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If (dr.HasRows = True) Then
                            MessageBox.Show(" Fournisseur existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_fournisseur").ToString()
                            TextBox2.Text = dr.Item("Nom").ToString()
                            TextBox3.Text = dr.Item("Num_tel").ToString()
                            ComboBox2.Text = dr.Item("Adresse").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If






            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Fournisseur ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Num_tel = @NU_TE")
                                Cmd.Parameters.AddWithValue("@NU_TE", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Adresse = @ADR")
                                    Cmd.Parameters.AddWithValue("@adr", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Fournisseur SET " & String.Join(", ", updates) & " WHERE ID_fournisseur = @ID_FR"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Fournisseur updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            fermer_connection()
                        End Try
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Fournisseur" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Fournisseur est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Fournisseur (ID_fournisseur, Nom, Num_tel, Adresse ) VALUES (@ID_FR, @Name, @NMTE, @ADR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NMTE", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ADR", ComboBox2.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Fournisseur ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Fournisseur has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Fournisseur not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If (dr.HasRows = True) Then
                            MessageBox.Show(" Fournisseur existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_fournisseur").ToString()
                            TextBox2.Text = dr.Item("Nom").ToString()
                            TextBox3.Text = dr.Item("Num_tel").ToString()
                            ComboBox2.Text = dr.Item("Adresse").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If






            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Fournisseur ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Num_tel = @NU_TE")
                                Cmd.Parameters.AddWithValue("@NU_TE", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Adresse = @ADR")
                                    Cmd.Parameters.AddWithValue("@adr", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Fournisseur SET " & String.Join(", ", updates) & " WHERE ID_fournisseur = @ID_FR"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Fournisseur updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            fermer_connection()
                        End Try
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub ComboBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Fournisseur" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Fournisseur est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Fournisseur (ID_fournisseur, Nom, Num_tel, Adresse ) VALUES (@ID_FR, @Name, @NMTE, @ADR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NMTE", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ADR", ComboBox2.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Fournisseur ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Fournisseur has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Fournisseur not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Fournisseur WHERE ID_fournisseur = @ID_FR"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If (dr.HasRows = True) Then
                            MessageBox.Show(" Fournisseur existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_fournisseur").ToString()
                            TextBox2.Text = dr.Item("Nom").ToString()
                            TextBox3.Text = dr.Item("Num_tel").ToString()
                            ComboBox2.Text = dr.Item("Adresse").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If






            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Fournisseur" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Fournisseur ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FR", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Num_tel = @NU_TE")
                                Cmd.Parameters.AddWithValue("@NU_TE", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Adresse = @ADR")
                                    Cmd.Parameters.AddWithValue("@adr", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Fournisseur SET " & String.Join(", ", updates) & " WHERE ID_fournisseur = @ID_FR"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Fournisseur updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Finally
                            fermer_connection()
                        End Try
                    End If
                End If
            End If

        End If

    End Sub
End Class