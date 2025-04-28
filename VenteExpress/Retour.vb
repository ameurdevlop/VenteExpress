Public Class Retour
    Private Sub Retour_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub
    Private Sub ResetItems()
        ' Créer une liste pour regrouper les contrôles à rendre invisibles et désactivés
        Dim invisiblesEtInactives As Control() = {TextBox1, TextBox2, TextBox3, TextBox4, MonthCalendar1,
                                          Label4, Label10, Label11, Label12, ComboBox2,
                                          Button1, Button2, Label2}

        ' Parcourir la liste et modifier les propriétés Visible et Enabled
        For Each ctrl In invisiblesEtInactives
            ctrl.Visible = False
            ctrl.Enabled = False
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        MonthCalendar1.ResetText()
        ComboBox2.Text = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter un Avis de Retour"
                ' Créer des listes pour regrouper les contrôles similaires
                Dim visiblesEtActives As Control() = {TextBox1, TextBox2, TextBox3, MonthCalendar1, Label2, Label1, Label4,
                                      Label10, Label11, Label12, ComboBox2, Button1, Button2}

                Dim visiblesMaisInactives As Control() = {TextBox4}

                Dim textesAReinitialiser As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox4}
                Dim comboBoxTextesAReinitialiser As ComboBox() = {ComboBox2}

                ' Rendre visibles et activer les contrôles listés dans visiblesEtActives
                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                ' Rendre visibles mais désactiver les contrôles listés dans visiblesMaisInactives
                For Each ctrl In visiblesMaisInactives
                    ctrl.Visible = False
                    ctrl.Enabled = False
                Next

                ' Réinitialiser les textes des TextBox
                For Each txtBox In textesAReinitialiser
                    txtBox.Text = ""
                Next

                ' Réinitialiser les textes des ComboBox
                For Each cmbBox In comboBoxTextesAReinitialiser
                    cmbBox.Text = ""
                Next
            Case "Supprimer un Avis de Retour"
                ' Créer des listes pour regrouper les contrôles similaires
                Dim visiblesEtActives As Control() = {TextBox1, ComboBox2, Label2, Label1, Label4, Label10, Label11, Label12, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, TextBox4, ComboBox2}
                Dim invisibles As Control() = {MonthCalendar1}
                Dim textesAReinitialiser As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox4}
                Dim comboBoxTextesAReinitialiser As ComboBox() = {ComboBox2}

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

                ' Rendre invisibles les contrôles listés dans invisibles
                For Each ctrl In invisibles
                    ctrl.Visible = False
                Next

                ' Réinitialiser les textes des TextBox
                For Each txtBox In textesAReinitialiser
                    txtBox.Text = ""
                Next

                ' Réinitialiser les textes des ComboBox
                For Each cmbBox In comboBoxTextesAReinitialiser
                    cmbBox.Text = ""
                Next
            Case "Rechercher un Avis de Retour"
                ' Créer des listes pour regrouper les contrôles similaires
                Dim visiblesEtActives As Control() = {TextBox1, Label2, Label1, Label4, Label10, Label11, Label12,
                                      ComboBox2, Button1, Button2}

                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, TextBox4, ComboBox2}
                Dim invisibles As Control() = {MonthCalendar1}

                Dim textesAReinitialiser As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox4}
                Dim comboBoxTextesAReinitialiser As ComboBox() = {ComboBox2}

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

                ' Rendre invisibles les contrôles listés dans invisibles
                For Each ctrl In invisibles
                    ctrl.Visible = False
                Next

                ' Réinitialiser les textes des TextBox
                For Each txtBox In textesAReinitialiser
                    txtBox.Text = ""
                Next

                ' Réinitialiser les textes des ComboBox
                For Each cmbBox In comboBoxTextesAReinitialiser
                    cmbBox.Text = ""
                Next
            Case "Modifier un Avis de Retour"
                ' Créer des listes pour regrouper les contrôles similaires
                Dim visiblesEtActives As Control() = {TextBox1, TextBox2, TextBox3, Label2, MonthCalendar1, Label1, Label4,
                                      Label10, Label11, Label12, ComboBox2, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox4}
                Dim invisibles As Control() = {TextBox4}

                Dim textesAReinitialiser As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox4}
                Dim comboBoxTextesAReinitialiser As ComboBox() = {ComboBox2}

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

                ' Rendre invisibles les contrôles listés dans invisibles
                For Each ctrl In invisibles
                    ctrl.Visible = False
                Next

                ' Réinitialiser les textes des TextBox
                For Each txtBox In textesAReinitialiser
                    txtBox.Text = ""
                Next

                ' Réinitialiser les textes des ComboBox
                For Each cmbBox In comboBoxTextesAReinitialiser
                    cmbBox.Text = ""
                Next
            Case Else
                ' Gérer les autres cas ou aucune sélection
                ResetItems()
        End Select

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Ajouter un Avis de Retour" Then

                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                    MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    ouvrir_connection()

                    sql = "SELECT COUNT(*) FROM Retour WHERE [No-retour] = @NO_RE"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce Retour est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "INSERT INTO Retour ([No-retour], No_commande, Id_produit, Situation, Date_retour) VALUES (@NO_RE, @NO_CO, @PD_ID, @SI, @Date)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NO_CO", TextBox2.Text.Trim())
                        Cmd.Parameters.AddWithValue("@PD_ID", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@SI", ComboBox2.Text.Trim())

                        Dim selectedDate As Date = MonthCalendar1.SelectionStart

                        Cmd.Parameters.AddWithValue("@Date", selectedDate)

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Retour ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    fermer_connection()
                End If
            End If

        End If




        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer un Avis de Retour" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Facture WHERE [No-retour] = @NO_RE"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show(" Retour supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Avis de Retour n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If selectedItem = "Rechercher un Avis de Retour" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Retour WHERE [No-retour] = @NO_RE"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Avis existe .")
                        dr.Read()
                        TextBox1.Text = dr.Item("No-retour").ToString()
                        TextBox2.Text = dr.Item("No_commande").ToString()
                        TextBox3.Text = dr.Item("Id_produit").ToString()
                        ComboBox2.Text = dr.Item("Situation").ToString()
                        TextBox4.Text = dr.Item("Date_retour").ToString()
                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If







        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier un Avis de Retour" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("Entrer l'ID de l'avis de retour...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                        ' Build SET clause only for non-empty fields
                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Date_retour = @DA_RT")
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@DA_RT", selectedDate)
                        End If

                        If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                            updates.Add("Situation = @SIT")
                            Cmd.Parameters.AddWithValue("@SIT", ComboBox2.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Id_produit = @IPD")
                            Cmd.Parameters.AddWithValue("@IPD", TextBox3.Text.Trim())
                        End If
                        If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                            updates.Add("No_commande = @NO_COM")
                            Cmd.Parameters.AddWithValue("@NO_COM", TextBox2.Text.Trim())
                        End If
                        ' Check if there is at least one field to update
                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Retour SET " & String.Join(", ", updates) & " WHERE [No-retour] = @NO_RE"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Avis de Retour modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        fermer_connection()
                    End Try
                End If
            End If
        End If



    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Avis de Retour" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Retour WHERE [No-retour] = @NO_RE"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Retour est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Retour ([No-retour], No_commande, Id_produit, Situation, Date_retour) VALUES (@NO_RE, @NO_CO, @PD_ID, @SI, @Date)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NO_CO", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PD_ID", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@SI", ComboBox2.Text.Trim())

                            Dim selectedDate As Date = MonthCalendar1.SelectionStart

                            Cmd.Parameters.AddWithValue("@Date", selectedDate)

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Retour ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Facture WHERE [No-retour] = @NO_RE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Retour supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Avis de Retour n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Retour WHERE [No-retour] = @NO_RE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Avis existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("No-retour").ToString()
                            TextBox2.Text = dr.Item("No_commande").ToString()
                            TextBox3.Text = dr.Item("Id_produit").ToString()
                            ComboBox2.Text = dr.Item("Situation").ToString()
                            TextBox4.Text = dr.Item("Date_retour").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If







            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Entrer l'ID de l'avis de retour...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_retour = @DA_RT")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@DA_RT", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                updates.Add("Situation = @SIT")
                                Cmd.Parameters.AddWithValue("@SIT", ComboBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Id_produit = @IPD")
                                Cmd.Parameters.AddWithValue("@IPD", TextBox3.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("No_commande = @NO_COM")
                                Cmd.Parameters.AddWithValue("@NO_COM", TextBox2.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Retour SET " & String.Join(", ", updates) & " WHERE [No-retour] = @NO_RE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Avis de Retour modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Avis de Retour" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Retour WHERE [No-retour] = @NO_RE"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Retour est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Retour ([No-retour], No_commande, Id_produit, Situation, Date_retour) VALUES (@NO_RE, @NO_CO, @PD_ID, @SI, @Date)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NO_CO", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PD_ID", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@SI", ComboBox2.Text.Trim())

                            Dim selectedDate As Date = MonthCalendar1.SelectionStart

                            Cmd.Parameters.AddWithValue("@Date", selectedDate)

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Retour ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Facture WHERE [No-retour] = @NO_RE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Retour supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Avis de Retour n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Retour WHERE [No-retour] = @NO_RE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Avis existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("No-retour").ToString()
                            TextBox2.Text = dr.Item("No_commande").ToString()
                            TextBox3.Text = dr.Item("Id_produit").ToString()
                            ComboBox2.Text = dr.Item("Situation").ToString()
                            TextBox4.Text = dr.Item("Date_retour").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If







            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Entrer l'ID de l'avis de retour...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_retour = @DA_RT")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@DA_RT", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                updates.Add("Situation = @SIT")
                                Cmd.Parameters.AddWithValue("@SIT", ComboBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Id_produit = @IPD")
                                Cmd.Parameters.AddWithValue("@IPD", TextBox3.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("No_commande = @NO_COM")
                                Cmd.Parameters.AddWithValue("@NO_COM", TextBox2.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Retour SET " & String.Join(", ", updates) & " WHERE [No-retour] = @NO_RE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Avis de Retour modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub TextBox3_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Avis de Retour" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Retour WHERE [No-retour] = @NO_RE"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Retour est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Retour ([No-retour], No_commande, Id_produit, Situation, Date_retour) VALUES (@NO_RE, @NO_CO, @PD_ID, @SI, @Date)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NO_CO", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PD_ID", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@SI", ComboBox2.Text.Trim())

                            Dim selectedDate As Date = MonthCalendar1.SelectionStart

                            Cmd.Parameters.AddWithValue("@Date", selectedDate)

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Retour ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Facture WHERE [No-retour] = @NO_RE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Retour supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Avis de Retour n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Retour WHERE [No-retour] = @NO_RE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Avis existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("No-retour").ToString()
                            TextBox2.Text = dr.Item("No_commande").ToString()
                            TextBox3.Text = dr.Item("Id_produit").ToString()
                            ComboBox2.Text = dr.Item("Situation").ToString()
                            TextBox4.Text = dr.Item("Date_retour").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If







            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Entrer l'ID de l'avis de retour...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_retour = @DA_RT")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@DA_RT", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                updates.Add("Situation = @SIT")
                                Cmd.Parameters.AddWithValue("@SIT", ComboBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Id_produit = @IPD")
                                Cmd.Parameters.AddWithValue("@IPD", TextBox3.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("No_commande = @NO_COM")
                                Cmd.Parameters.AddWithValue("@NO_COM", TextBox2.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Retour SET " & String.Join(", ", updates) & " WHERE [No-retour] = @NO_RE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Avis de Retour modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                If selectedItem = "Ajouter un Avis de Retour" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Retour WHERE [No-retour] = @NO_RE"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Retour est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Retour ([No-retour], No_commande, Id_produit, Situation, Date_retour) VALUES (@NO_RE, @NO_CO, @PD_ID, @SI, @Date)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NO_CO", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PD_ID", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@SI", ComboBox2.Text.Trim())

                            Dim selectedDate As Date = MonthCalendar1.SelectionStart

                            Cmd.Parameters.AddWithValue("@Date", selectedDate)

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Retour ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Facture WHERE [No-retour] = @NO_RE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Retour supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Avis de Retour n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Retour WHERE [No-retour] = @NO_RE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Avis existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("No-retour").ToString()
                            TextBox2.Text = dr.Item("No_commande").ToString()
                            TextBox3.Text = dr.Item("Id_produit").ToString()
                            ComboBox2.Text = dr.Item("Situation").ToString()
                            TextBox4.Text = dr.Item("Date_retour").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If







            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Avis de Retour" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Entrer l'ID de l'avis de retour...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_RE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_retour = @DA_RT")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@DA_RT", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                updates.Add("Situation = @SIT")
                                Cmd.Parameters.AddWithValue("@SIT", ComboBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Id_produit = @IPD")
                                Cmd.Parameters.AddWithValue("@IPD", TextBox3.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("No_commande = @NO_COM")
                                Cmd.Parameters.AddWithValue("@NO_COM", TextBox2.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Retour SET " & String.Join(", ", updates) & " WHERE [No-retour] = @NO_RE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Avis de Retour modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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