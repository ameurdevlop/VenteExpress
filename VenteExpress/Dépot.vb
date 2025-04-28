Public Class Dépot
    Private Sub Dépot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub
    Private Sub ResetItems()
        Dim invisiblesEtInactifs As Control() = {TextBox1, TextBox2, TextBox3, TextBox8, Label4, Label10,
                                         Label11, Label12, Label13, Button1, Button2, ComboBox2}

        For Each ctrl In invisiblesEtInactifs
            ctrl.Visible = False
            ctrl.Enabled = False
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox8.Text = ""
        ComboBox2.Text = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter un Dépot"
                Dim visiblesEtActives As Control() = {TextBox1, TextBox2, TextBox3, TextBox8, ComboBox2, Button1, Button2,
                                       Label1, Label4, Label10, Label11, Label12, Label13}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox8.Text = ""
                ComboBox2.Text = ""

            Case "Supprimer un Dépot"
                Dim visiblesEtActives As Control() = {TextBox1, Label1, Label4, Label10, Label11, Label12, Label13, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, TextBox8, ComboBox2}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox8.Text = ""
                ComboBox2.Text = ""

            Case "Rechercher un Dépot"
                Dim visiblesEtActives As Control() = {TextBox1, Label1, Label4, Label10, Label11, Label12, Label13, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, TextBox8, ComboBox2}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox8.Text = ""
                ComboBox2.Text = ""

            Case "Modifier un Dépot"
                Dim visiblesEtActives As Control() = {TextBox1, TextBox2, TextBox3, TextBox8, ComboBox2, Label1, Label4,
                                       Label10, Label11, Label12, Label13, Button1, Button2}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox8.Text = ""
                ComboBox2.Text = ""
            Case Else
                ResetItems()
        End Select
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Ajouter un Dépot" Then

                ' Validate required fields
                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
               String.IsNullOrWhiteSpace(ComboBox2.Text) Then

                    MessageBox.Show("Veuillez entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' Open connection
                ouvrir_connection()

                ' Check if the depot already exists
                sql = "SELECT COUNT(*) FROM Dépôt WHERE Num_depo = @NO_DE"
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = sql
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                If count > 0 Then
                    MessageBox.Show("Ce dépôt existe déjà. Veuillez choisir un nouvel ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ' Validate that Nbre_ouvrier is a valid integer
                    Dim nboValue As Integer
                    If Not Integer.TryParse(TextBox2.Text.Trim(), nboValue) Then
                        MessageBox.Show("Veuillez entrer un nombre valide pour le nombre d'ouvriers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        fermer_connection()
                        Exit Sub
                    End If

                    ' Prepare the insert query
                    sql = "INSERT INTO Dépôt (Num_depo, Adresse, Nbre_ouvrier, Responsable, Type_produits) " &
                      "VALUES (@NO_DE, @ADR, @NBO, @RES, @TPD)"
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                    Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                    Cmd.Parameters.AddWithValue("@NBO", nboValue)
                    Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                    Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())

                    Cmd.ExecuteNonQuery()
                    MessageBox.Show("Dépôt ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' Close connection
                fermer_connection()
            End If
        Else
            MessageBox.Show("Veuillez sélectionner une action dans le menu déroulant.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If




        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer un Dépot" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Dépôt WHERE Num_depo = @NO_DE"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show(" Dépôt supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Dépôt n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If selectedItem = "Rechercher un Dépot" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Dépôt WHERE Num_depo = @NO_DE"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Dépôt existe .")
                        dr.Read()
                        TextBox1.Text = dr.Item("Num_depo").ToString()
                        TextBox3.Text = dr.Item("Adresse").ToString()
                        TextBox2.Text = dr.Item("Nbre_ouvrier").ToString()
                        TextBox8.Text = dr.Item("Responsable").ToString()
                        ComboBox2.Text = dr.Item("Type_produits").ToString()

                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If




        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier un Dépot" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                        ' Build SET clause only for non-empty fields
                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Adresse = @ADR")
                            Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                            updates.Add("Responsable = @RES")
                            Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                            If IsNumeric(TextBox2.Text) Then
                                updates.Add("Nbre_ouvrier = @NBO")
                                Cmd.Parameters.AddWithValue("@NBO", Convert.ToInt64(TextBox2.Text.Trim()))
                            Else
                                MessageBox.Show("Nombre d'ouvrier doit être numérique...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If


                        If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                            If IsNumeric(ComboBox2.Text) Then
                                updates.Add("Type_produits = @TPD")
                                Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())
                            Else
                                MessageBox.Show("choisisser une valeur de la liste ...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If

                        ' Check if there is at least one field to update
                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Dépôt SET " & String.Join(", ", updates) & " WHERE Num_depo = @NO_DE"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Dépot modifier avec success ..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        fermer_connection()
                    End Try
                End If
            End If
        End If




    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Ajouter un Dépot" Then

                    ' Validate required fields
                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
               String.IsNullOrWhiteSpace(ComboBox2.Text) Then

                        MessageBox.Show("Veuillez entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    ' Open connection
                    ouvrir_connection()

                    ' Check if the depot already exists
                    sql = "SELECT COUNT(*) FROM Dépôt WHERE Num_depo = @NO_DE"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce dépôt existe déjà. Veuillez choisir un nouvel ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Validate that Nbre_ouvrier is a valid integer
                        Dim nboValue As Integer
                        If Not Integer.TryParse(TextBox2.Text.Trim(), nboValue) Then
                            MessageBox.Show("Veuillez entrer un nombre valide pour le nombre d'ouvriers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            fermer_connection()
                            Exit Sub
                        End If

                        ' Prepare the insert query
                        sql = "INSERT INTO Dépôt (Num_depo, Adresse, Nbre_ouvrier, Responsable, Type_produits) " &
                      "VALUES (@NO_DE, @ADR, @NBO, @RES, @TPD)"
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NBO", nboValue)
                        Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                        Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Dépôt ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ' Close connection
                    fermer_connection()
                End If
            Else
                MessageBox.Show("Veuillez sélectionner une action dans le menu déroulant.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Dépôt WHERE Num_depo = @NO_DE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Dépôt supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Dépôt n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Dépôt WHERE Num_depo = @NO_DE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Dépôt existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("Num_depo").ToString()
                            TextBox3.Text = dr.Item("Adresse").ToString()
                            TextBox2.Text = dr.Item("Nbre_ouvrier").ToString()
                            TextBox8.Text = dr.Item("Responsable").ToString()
                            ComboBox2.Text = dr.Item("Type_produits").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Adresse = @ADR")
                                Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                updates.Add("Responsable = @RES")
                                Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                If IsNumeric(TextBox2.Text) Then
                                    updates.Add("Nbre_ouvrier = @NBO")
                                    Cmd.Parameters.AddWithValue("@NBO", Convert.ToInt64(TextBox2.Text.Trim()))
                                Else
                                    MessageBox.Show("Nombre d'ouvrier doit être numérique...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Type_produits = @TPD")
                                    Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("choisisser une valeur de la liste ...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Dépôt SET " & String.Join(", ", updates) & " WHERE Num_depo = @NO_DE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Dépot modifier avec success ..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Ajouter un Dépot" Then

                    ' Validate required fields
                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
               String.IsNullOrWhiteSpace(ComboBox2.Text) Then

                        MessageBox.Show("Veuillez entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    ' Open connection
                    ouvrir_connection()

                    ' Check if the depot already exists
                    sql = "SELECT COUNT(*) FROM Dépôt WHERE Num_depo = @NO_DE"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce dépôt existe déjà. Veuillez choisir un nouvel ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Validate that Nbre_ouvrier is a valid integer
                        Dim nboValue As Integer
                        If Not Integer.TryParse(TextBox2.Text.Trim(), nboValue) Then
                            MessageBox.Show("Veuillez entrer un nombre valide pour le nombre d'ouvriers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            fermer_connection()
                            Exit Sub
                        End If

                        ' Prepare the insert query
                        sql = "INSERT INTO Dépôt (Num_depo, Adresse, Nbre_ouvrier, Responsable, Type_produits) " &
                      "VALUES (@NO_DE, @ADR, @NBO, @RES, @TPD)"
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NBO", nboValue)
                        Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                        Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Dépôt ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ' Close connection
                    fermer_connection()
                End If
            Else
                MessageBox.Show("Veuillez sélectionner une action dans le menu déroulant.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Dépôt WHERE Num_depo = @NO_DE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Dépôt supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Dépôt n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Dépôt WHERE Num_depo = @NO_DE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Dépôt existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("Num_depo").ToString()
                            TextBox3.Text = dr.Item("Adresse").ToString()
                            TextBox2.Text = dr.Item("Nbre_ouvrier").ToString()
                            TextBox8.Text = dr.Item("Responsable").ToString()
                            ComboBox2.Text = dr.Item("Type_produits").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Adresse = @ADR")
                                Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                updates.Add("Responsable = @RES")
                                Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                If IsNumeric(TextBox2.Text) Then
                                    updates.Add("Nbre_ouvrier = @NBO")
                                    Cmd.Parameters.AddWithValue("@NBO", Convert.ToInt64(TextBox2.Text.Trim()))
                                Else
                                    MessageBox.Show("Nombre d'ouvrier doit être numérique...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Type_produits = @TPD")
                                    Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("choisisser une valeur de la liste ...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Dépôt SET " & String.Join(", ", updates) & " WHERE Num_depo = @NO_DE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Dépot modifier avec success ..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Ajouter un Dépot" Then

                    ' Validate required fields
                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
               String.IsNullOrWhiteSpace(ComboBox2.Text) Then

                        MessageBox.Show("Veuillez entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    ' Open connection
                    ouvrir_connection()

                    ' Check if the depot already exists
                    sql = "SELECT COUNT(*) FROM Dépôt WHERE Num_depo = @NO_DE"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce dépôt existe déjà. Veuillez choisir un nouvel ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Validate that Nbre_ouvrier is a valid integer
                        Dim nboValue As Integer
                        If Not Integer.TryParse(TextBox2.Text.Trim(), nboValue) Then
                            MessageBox.Show("Veuillez entrer un nombre valide pour le nombre d'ouvriers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            fermer_connection()
                            Exit Sub
                        End If

                        ' Prepare the insert query
                        sql = "INSERT INTO Dépôt (Num_depo, Adresse, Nbre_ouvrier, Responsable, Type_produits) " &
                      "VALUES (@NO_DE, @ADR, @NBO, @RES, @TPD)"
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NBO", nboValue)
                        Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                        Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Dépôt ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ' Close connection
                    fermer_connection()
                End If
            Else
                MessageBox.Show("Veuillez sélectionner une action dans le menu déroulant.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Dépôt WHERE Num_depo = @NO_DE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Dépôt supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Dépôt n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Dépôt WHERE Num_depo = @NO_DE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Dépôt existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("Num_depo").ToString()
                            TextBox3.Text = dr.Item("Adresse").ToString()
                            TextBox2.Text = dr.Item("Nbre_ouvrier").ToString()
                            TextBox8.Text = dr.Item("Responsable").ToString()
                            ComboBox2.Text = dr.Item("Type_produits").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Adresse = @ADR")
                                Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                updates.Add("Responsable = @RES")
                                Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                If IsNumeric(TextBox2.Text) Then
                                    updates.Add("Nbre_ouvrier = @NBO")
                                    Cmd.Parameters.AddWithValue("@NBO", Convert.ToInt64(TextBox2.Text.Trim()))
                                Else
                                    MessageBox.Show("Nombre d'ouvrier doit être numérique...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Type_produits = @TPD")
                                    Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("choisisser une valeur de la liste ...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Dépôt SET " & String.Join(", ", updates) & " WHERE Num_depo = @NO_DE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Dépot modifier avec success ..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Ajouter un Dépot" Then

                    ' Validate required fields
                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
               String.IsNullOrWhiteSpace(ComboBox2.Text) Then

                        MessageBox.Show("Veuillez entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    ' Open connection
                    ouvrir_connection()

                    ' Check if the depot already exists
                    sql = "SELECT COUNT(*) FROM Dépôt WHERE Num_depo = @NO_DE"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce dépôt existe déjà. Veuillez choisir un nouvel ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Validate that Nbre_ouvrier is a valid integer
                        Dim nboValue As Integer
                        If Not Integer.TryParse(TextBox2.Text.Trim(), nboValue) Then
                            MessageBox.Show("Veuillez entrer un nombre valide pour le nombre d'ouvriers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            fermer_connection()
                            Exit Sub
                        End If

                        ' Prepare the insert query
                        sql = "INSERT INTO Dépôt (Num_depo, Adresse, Nbre_ouvrier, Responsable, Type_produits) " &
                      "VALUES (@NO_DE, @ADR, @NBO, @RES, @TPD)"
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NBO", nboValue)
                        Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                        Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Dépôt ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ' Close connection
                    fermer_connection()
                End If
            Else
                MessageBox.Show("Veuillez sélectionner une action dans le menu déroulant.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Dépôt WHERE Num_depo = @NO_DE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Dépôt supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Dépôt n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Dépôt WHERE Num_depo = @NO_DE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Dépôt existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("Num_depo").ToString()
                            TextBox3.Text = dr.Item("Adresse").ToString()
                            TextBox2.Text = dr.Item("Nbre_ouvrier").ToString()
                            TextBox8.Text = dr.Item("Responsable").ToString()
                            ComboBox2.Text = dr.Item("Type_produits").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Adresse = @ADR")
                                Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                updates.Add("Responsable = @RES")
                                Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                If IsNumeric(TextBox2.Text) Then
                                    updates.Add("Nbre_ouvrier = @NBO")
                                    Cmd.Parameters.AddWithValue("@NBO", Convert.ToInt64(TextBox2.Text.Trim()))
                                Else
                                    MessageBox.Show("Nombre d'ouvrier doit être numérique...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Type_produits = @TPD")
                                    Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("choisisser une valeur de la liste ...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Dépôt SET " & String.Join(", ", updates) & " WHERE Num_depo = @NO_DE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Dépot modifier avec success ..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

                If selectedItem = "Ajouter un Dépot" Then

                    ' Validate required fields
                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox2.Text) OrElse
               String.IsNullOrWhiteSpace(TextBox3.Text) OrElse
               String.IsNullOrWhiteSpace(ComboBox2.Text) Then

                        MessageBox.Show("Veuillez entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    ' Open connection
                    ouvrir_connection()

                    ' Check if the depot already exists
                    sql = "SELECT COUNT(*) FROM Dépôt WHERE Num_depo = @NO_DE"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce dépôt existe déjà. Veuillez choisir un nouvel ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Validate that Nbre_ouvrier is a valid integer
                        Dim nboValue As Integer
                        If Not Integer.TryParse(TextBox2.Text.Trim(), nboValue) Then
                            MessageBox.Show("Veuillez entrer un nombre valide pour le nombre d'ouvriers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            fermer_connection()
                            Exit Sub
                        End If

                        ' Prepare the insert query
                        sql = "INSERT INTO Dépôt (Num_depo, Adresse, Nbre_ouvrier, Responsable, Type_produits) " &
                      "VALUES (@NO_DE, @ADR, @NBO, @RES, @TPD)"
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NBO", nboValue)
                        Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                        Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Dépôt ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    ' Close connection
                    fermer_connection()
                End If
            Else
                MessageBox.Show("Veuillez sélectionner une action dans le menu déroulant.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Dépôt WHERE Num_depo = @NO_DE"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Dépôt supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Dépôt n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Dépôt WHERE Num_depo = @NO_DE"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Dépôt existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("Num_depo").ToString()
                            TextBox3.Text = dr.Item("Adresse").ToString()
                            TextBox2.Text = dr.Item("Nbre_ouvrier").ToString()
                            TextBox8.Text = dr.Item("Responsable").ToString()
                            ComboBox2.Text = dr.Item("Type_produits").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Dépot" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@NO_DE", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Adresse = @ADR")
                                Cmd.Parameters.AddWithValue("@ADR", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                updates.Add("Responsable = @RES")
                                Cmd.Parameters.AddWithValue("@RES", TextBox8.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                If IsNumeric(TextBox2.Text) Then
                                    updates.Add("Nbre_ouvrier = @NBO")
                                    Cmd.Parameters.AddWithValue("@NBO", Convert.ToInt64(TextBox2.Text.Trim()))
                                Else
                                    MessageBox.Show("Nombre d'ouvrier doit être numérique...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If


                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                If IsNumeric(ComboBox2.Text) Then
                                    updates.Add("Type_produits = @TPD")
                                    Cmd.Parameters.AddWithValue("@TPD", ComboBox2.Text.Trim())
                                Else
                                    MessageBox.Show("choisisser une valeur de la liste ...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Dépôt SET " & String.Join(", ", updates) & " WHERE Num_depo = @NO_DE"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Dépot modifier avec success ..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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