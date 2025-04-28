Public Class Méthode_payement
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""

        TextBox3.Text = ""

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter une Méthode"
                TextBox1.Visible = True
                TextBox1.Enabled = True
                TextBox1.Text = ""
                TextBox3.Visible = True
                TextBox3.Enabled = True
                TextBox3.Text = ""
                Label1.Visible = True

                Label10.Visible = True
                Label11.Visible = True

                Button1.Visible = True
                Button2.Visible = True
            Case "Supprimer une Méthode"
                TextBox1.Visible = True
                TextBox1.Enabled = True
                TextBox1.Text = ""
                TextBox3.Text = ""
                TextBox3.Visible = True
                TextBox3.Enabled = False

                Label1.Visible = True

                Label10.Visible = True
                Label11.Visible = True

                Button1.Visible = True
                Button2.Visible = True
            Case "Rechercher une Méthode"
                TextBox1.Visible = True
                TextBox1.Enabled = True
                TextBox1.Text = ""
                TextBox3.Visible = True
                TextBox3.Enabled = False
                TextBox3.Text = ""
                Label1.Visible = True

                Label10.Visible = True
                Label11.Visible = True

                Button1.Visible = True
                Button2.Visible = True
            Case "Modifier une Méthode"
                TextBox1.Visible = True
                TextBox1.Enabled = True
                TextBox1.Text = ""
                TextBox3.Visible = True
                TextBox3.Enabled = True
                TextBox3.Text = ""
                Label1.Visible = True

                Label10.Visible = True
                Label11.Visible = True

                Button1.Visible = True
                Button2.Visible = True
            Case Else
                ' Gérer les autres cas ou aucune sélection
                ResetItems()
        End Select

    End Sub
    Private Sub ResetItems()
        TextBox1.Visible = False
        TextBox1.Enabled = False

        TextBox3.Visible = False
        TextBox3.Enabled = False

        Label10.Visible = False
        Label11.Visible = False

        Button1.Visible = False
        Button2.Visible = False
    End Sub

    Private Sub Méthode_payement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Ajouter une Méthode" Then

                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ' Open connection
                    ouvrir_connection()

                    ' Check if the method already exists in the table based on ID_Mode (primary key)
                    sql = "SELECT COUNT(*) FROM Mode_payement WHERE ID_Mode = @ID_Mode"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())

                    ' Execute the query to check if the method already exists
                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        ' If count > 0, it means the method already exists (primary key violation)
                        MessageBox.Show("Ce mode de payement est deja existant , choisisser un nouveau ID..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' If the method does not exist, proceed with the insert operation
                        sql = "INSERT INTO Mode_payement (ID_Mode, Désignation) VALUES (@ID_Mode, @Désignation)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Mode payement ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If


                    fermer_connection()
                End If
            End If

        End If

        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Supprimer une Méthode" Then

                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("ID non valide.veiller entrer une valeur valide .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Dim idMode As String = TextBox1.Text.Trim()

                ouvrir_connection()
                sql = "SELECT COUNT(*) FROM Mode_payement WHERE LTRIM(RTRIM(ID_Mode)) = @ID_Mode"
                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = sql
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("@ID_Mode", idMode)

                Dim recordExists As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                If recordExists > 0 Then
                    sql = "DELETE FROM Mode_payement WHERE LTRIM(RTRIM(ID_Mode)) = @ID_Mode"
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_Mode", idMode)

                    Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Le mode a ete bien supprimer ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("suppression échoué , veiller reillaisser.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Aucun Resultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                fermer_connection()
            End If
        End If


        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Rechercher une Méthode" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Mode_payement WHERE ID_Mode = @ID_Mode"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Méthode existe .")
                        dr.Read()
                        TextBox1.Text = dr.Item("ID_Mode").ToString()
                        TextBox3.Text = dr.Item("Désignation").ToString()
                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If


        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier une Méthode" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ouvrir_connection()
                    sql = "UPDATE Mode_payement SET Désignation = @Désignation WHERE ID_Mode = @ID_Mode"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                    Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                    Cmd.ExecuteNonQuery()
                    MessageBox.Show("Methode Bien modifier !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    fermer_connection()
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

                If selectedItem = "Ajouter une Méthode" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        ' Check if the method already exists in the table based on ID_Mode (primary key)
                        sql = "SELECT COUNT(*) FROM Mode_payement WHERE ID_Mode = @ID_Mode"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())

                        ' Execute the query to check if the method already exists
                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            ' If count > 0, it means the method already exists (primary key violation)
                            MessageBox.Show("Ce mode de payement est deja existant , choisisser un nouveau ID..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            ' If the method does not exist, proceed with the insert operation
                            sql = "INSERT INTO Mode_payement (ID_Mode, Désignation) VALUES (@ID_Mode, @Désignation)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Mode payement ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If


                        fermer_connection()
                    End If
                End If

            End If

            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Supprimer une Méthode" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("ID non valide.veiller entrer une valeur valide .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Dim idMode As String = TextBox1.Text.Trim()

                    ouvrir_connection()
                    sql = "SELECT COUNT(*) FROM Mode_payement WHERE LTRIM(RTRIM(ID_Mode)) = @ID_Mode"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_Mode", idMode)

                    Dim recordExists As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If recordExists > 0 Then
                        sql = "DELETE FROM Mode_payement WHERE LTRIM(RTRIM(ID_Mode)) = @ID_Mode"
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", idMode)

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Le mode a ete bien supprimer ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("suppression échoué , veiller reillaisser.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Aucun Resultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    fermer_connection()
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Rechercher une Méthode" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Mode_payement WHERE ID_Mode = @ID_Mode"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Méthode existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Mode").ToString()
                            TextBox3.Text = dr.Item("Désignation").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier une Méthode" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ouvrir_connection()
                        sql = "UPDATE Mode_payement SET Désignation = @Désignation WHERE ID_Mode = @ID_Mode"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Methode Bien modifier !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        fermer_connection()
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

                If selectedItem = "Ajouter une Méthode" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        ' Check if the method already exists in the table based on ID_Mode (primary key)
                        sql = "SELECT COUNT(*) FROM Mode_payement WHERE ID_Mode = @ID_Mode"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())

                        ' Execute the query to check if the method already exists
                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            ' If count > 0, it means the method already exists (primary key violation)
                            MessageBox.Show("Ce mode de payement est deja existant , choisisser un nouveau ID..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            ' If the method does not exist, proceed with the insert operation
                            sql = "INSERT INTO Mode_payement (ID_Mode, Désignation) VALUES (@ID_Mode, @Désignation)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Mode payement ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If


                        fermer_connection()
                    End If
                End If

            End If

            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Supprimer une Méthode" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("ID non valide.veiller entrer une valeur valide .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    Dim idMode As String = TextBox1.Text.Trim()

                    ouvrir_connection()
                    sql = "SELECT COUNT(*) FROM Mode_payement WHERE LTRIM(RTRIM(ID_Mode)) = @ID_Mode"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_Mode", idMode)

                    Dim recordExists As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If recordExists > 0 Then
                        sql = "DELETE FROM Mode_payement WHERE LTRIM(RTRIM(ID_Mode)) = @ID_Mode"
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", idMode)

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Le mode a ete bien supprimer ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("suppression échoué , veiller reillaisser.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        MessageBox.Show("Aucun Resultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                    fermer_connection()
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Rechercher une Méthode" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Mode_payement WHERE ID_Mode = @ID_Mode"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Méthode existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Mode").ToString()
                            TextBox3.Text = dr.Item("Désignation").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier une Méthode" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ouvrir_connection()
                        sql = "UPDATE Mode_payement SET Désignation = @Désignation WHERE ID_Mode = @ID_Mode"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Methode Bien modifier !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        fermer_connection()
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class