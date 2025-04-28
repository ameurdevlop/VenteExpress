Public Class Client

    Private Sub Client_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
    End Sub
    Private Sub ResetItems()
        Dim invisiblesEtInactifs As Control() = {TextBox1, TextBox2, TextBox3, TextBox8, TextBox9,
                                         Label4, Label10, Label11, Label12, Label13,
                                         Button1, Button2}

        For Each ctrl In invisiblesEtInactifs
            ctrl.Visible = False
            ctrl.Enabled = False
        Next

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter un Client"
                Dim visiblesEtActives As Control() = {TextBox1, TextBox2, TextBox3, TextBox8, TextBox9,
                                       Label1, Label4, Label10, Label11, Label12, Label13,
                                       Button1, Button2}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""

            Case "Supprimer un Client"
                Dim visiblesEtActives As Control() = {TextBox1, Label1, Label4, Label10, Label11, Label12, Label13, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, TextBox8, TextBox9}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next

                Dim textBoxesToReset As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox8, TextBox9}
                For Each textBox In textBoxesToReset
                    textBox.Text = ""
                Next

            Case "Rechercher un Client"
                Dim visiblesEtActives As Control() = {TextBox1, Label1, Label4, Label10, Label11, Label12, Label13, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, TextBox8, TextBox9}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next

                Dim textBoxesToReset As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox8, TextBox9}
                For Each textBox In textBoxesToReset
                    textBox.Text = ""
                Next
            Case "Modifier un Client"

                Dim visiblesEtActives As Control() = {TextBox1, TextBox2, TextBox3, TextBox8, TextBox9,
                                       Label1, Label4, Label10, Label11, Label12, Label13,
                                       Button1, Button2}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                Dim textBoxesToReset As TextBox() = {TextBox1, TextBox2, TextBox3, TextBox8, TextBox9}
                For Each textBox In textBoxesToReset
                    textBox.Text = ""
                Next

            Case Else


                ResetItems()
        End Select




    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Ajouter un Client" Then

                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                    MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ' Open connection
                    ouvrir_connection()

                    sql = "SELECT COUNT(*) FROM Client WHERE ID_Client = @ID_CL"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "INSERT INTO Client (ID_Client, Nom, Prenom, Num_tel, Nbr_points) VALUES (@ID_CL, @Name, @Second_name, @Numt, @points)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Numt", TextBox8.Text.Trim())
                        Cmd.Parameters.AddWithValue("@points", TextBox9.Text.Trim())

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Client ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    fermer_connection()
                End If
            End If
        End If


        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer un Client" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Client WHERE ID_Client = @ID_CL"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Client has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Client not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If selectedItem = "Rechercher un Client" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Client WHERE ID_Client = @ID_CL"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Client existe .")
                        dr.Read()
                        TextBox1.Text = dr.Item("ID_Client").ToString()
                        TextBox3.Text = dr.Item("Nom").ToString()
                        TextBox2.Text = dr.Item("Prenom").ToString()
                        TextBox8.Text = dr.Item("Num_tel").ToString()
                        TextBox9.Text = dr.Item("Nbr_points").ToString()

                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If



        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier un Client" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("Please enter the Client ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                        ' Build SET clause only for non-empty fields
                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Nom = @Name")
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                            updates.Add("Prenom = @Second_name")
                            Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                            If IsNumeric(TextBox8.Text) Then
                                updates.Add("Num_tel = @Numt")
                                Cmd.Parameters.AddWithValue("@Numt", Convert.ToInt64(TextBox8.Text.Trim()))
                            Else
                                MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                            If IsNumeric(TextBox9.Text) Then
                                updates.Add("Nbr_points = @points")
                                Cmd.Parameters.AddWithValue("@points", Convert.ToInt32(TextBox9.Text.Trim()))
                            Else
                                MessageBox.Show("Points must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                        End If

                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Client SET " & String.Join(", ", updates) & " WHERE ID_Client = @ID_CL"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        fermer_connection()
                    End Try
                End If
            End If
        End If







    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Client" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Client WHERE ID_Client = @ID_CL"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Client (ID_Client, Nom, Prenom, Num_tel, Nbr_points) VALUES (@ID_CL, @Name, @Second_name, @Numt, @points)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Numt", TextBox8.Text.Trim())
                            Cmd.Parameters.AddWithValue("@points", TextBox9.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Client WHERE ID_Client = @ID_CL"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Client has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Client not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Client WHERE ID_Client = @ID_CL"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Client existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Client").ToString()
                            TextBox3.Text = dr.Item("Nom").ToString()
                            TextBox2.Text = dr.Item("Prenom").ToString()
                            TextBox8.Text = dr.Item("Num_tel").ToString()
                            TextBox9.Text = dr.Item("Nbr_points").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Client ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Prenom = @Second_name")
                                Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                If IsNumeric(TextBox8.Text) Then
                                    updates.Add("Num_tel = @Numt")
                                    Cmd.Parameters.AddWithValue("@Numt", Convert.ToInt64(TextBox8.Text.Trim()))
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                                If IsNumeric(TextBox9.Text) Then
                                    updates.Add("Nbr_points = @points")
                                    Cmd.Parameters.AddWithValue("@points", Convert.ToInt32(TextBox9.Text.Trim()))
                                Else
                                    MessageBox.Show("Points must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Client SET " & String.Join(", ", updates) & " WHERE ID_Client = @ID_CL"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                If selectedItem = "Ajouter un Client" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Client WHERE ID_Client = @ID_CL"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Client (ID_Client, Nom, Prenom, Num_tel, Nbr_points) VALUES (@ID_CL, @Name, @Second_name, @Numt, @points)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Numt", TextBox8.Text.Trim())
                            Cmd.Parameters.AddWithValue("@points", TextBox9.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Client WHERE ID_Client = @ID_CL"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Client has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Client not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Client WHERE ID_Client = @ID_CL"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Client existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Client").ToString()
                            TextBox3.Text = dr.Item("Nom").ToString()
                            TextBox2.Text = dr.Item("Prenom").ToString()
                            TextBox8.Text = dr.Item("Num_tel").ToString()
                            TextBox9.Text = dr.Item("Nbr_points").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Client ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Prenom = @Second_name")
                                Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                If IsNumeric(TextBox8.Text) Then
                                    updates.Add("Num_tel = @Numt")
                                    Cmd.Parameters.AddWithValue("@Numt", Convert.ToInt64(TextBox8.Text.Trim()))
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                                If IsNumeric(TextBox9.Text) Then
                                    updates.Add("Nbr_points = @points")
                                    Cmd.Parameters.AddWithValue("@points", Convert.ToInt32(TextBox9.Text.Trim()))
                                Else
                                    MessageBox.Show("Points must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Client SET " & String.Join(", ", updates) & " WHERE ID_Client = @ID_CL"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                If selectedItem = "Ajouter un Client" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Client WHERE ID_Client = @ID_CL"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Client (ID_Client, Nom, Prenom, Num_tel, Nbr_points) VALUES (@ID_CL, @Name, @Second_name, @Numt, @points)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Numt", TextBox8.Text.Trim())
                            Cmd.Parameters.AddWithValue("@points", TextBox9.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Client WHERE ID_Client = @ID_CL"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Client has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Client not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Client WHERE ID_Client = @ID_CL"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Client existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Client").ToString()
                            TextBox3.Text = dr.Item("Nom").ToString()
                            TextBox2.Text = dr.Item("Prenom").ToString()
                            TextBox8.Text = dr.Item("Num_tel").ToString()
                            TextBox9.Text = dr.Item("Nbr_points").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Client ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Prenom = @Second_name")
                                Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                If IsNumeric(TextBox8.Text) Then
                                    updates.Add("Num_tel = @Numt")
                                    Cmd.Parameters.AddWithValue("@Numt", Convert.ToInt64(TextBox8.Text.Trim()))
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                                If IsNumeric(TextBox9.Text) Then
                                    updates.Add("Nbr_points = @points")
                                    Cmd.Parameters.AddWithValue("@points", Convert.ToInt32(TextBox9.Text.Trim()))
                                Else
                                    MessageBox.Show("Points must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Client SET " & String.Join(", ", updates) & " WHERE ID_Client = @ID_CL"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                If selectedItem = "Ajouter un Client" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Client WHERE ID_Client = @ID_CL"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Client (ID_Client, Nom, Prenom, Num_tel, Nbr_points) VALUES (@ID_CL, @Name, @Second_name, @Numt, @points)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Numt", TextBox8.Text.Trim())
                            Cmd.Parameters.AddWithValue("@points", TextBox9.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Client WHERE ID_Client = @ID_CL"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Client has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Client not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Client WHERE ID_Client = @ID_CL"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Client existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Client").ToString()
                            TextBox3.Text = dr.Item("Nom").ToString()
                            TextBox2.Text = dr.Item("Prenom").ToString()
                            TextBox8.Text = dr.Item("Num_tel").ToString()
                            TextBox9.Text = dr.Item("Nbr_points").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Client ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Prenom = @Second_name")
                                Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                If IsNumeric(TextBox8.Text) Then
                                    updates.Add("Num_tel = @Numt")
                                    Cmd.Parameters.AddWithValue("@Numt", Convert.ToInt64(TextBox8.Text.Trim()))
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                                If IsNumeric(TextBox9.Text) Then
                                    updates.Add("Nbr_points = @points")
                                    Cmd.Parameters.AddWithValue("@points", Convert.ToInt32(TextBox9.Text.Trim()))
                                Else
                                    MessageBox.Show("Points must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Client SET " & String.Join(", ", updates) & " WHERE ID_Client = @ID_CL"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Client" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Client WHERE ID_Client = @ID_CL"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Client (ID_Client, Nom, Prenom, Num_tel, Nbr_points) VALUES (@ID_CL, @Name, @Second_name, @Numt, @points)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Numt", TextBox8.Text.Trim())
                            Cmd.Parameters.AddWithValue("@points", TextBox9.Text.Trim())

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Client WHERE ID_Client = @ID_CL"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show("Client has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Client not found. Please check the ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Client WHERE ID_Client = @ID_CL"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Client existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Client").ToString()
                            TextBox3.Text = dr.Item("Nom").ToString()
                            TextBox2.Text = dr.Item("Prenom").ToString()
                            TextBox8.Text = dr.Item("Num_tel").ToString()
                            TextBox9.Text = dr.Item("Nbr_points").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Client" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please enter the Client ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_CL", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Nom = @Name")
                                Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox2.Text) Then
                                updates.Add("Prenom = @Second_name")
                                Cmd.Parameters.AddWithValue("@Second_name", TextBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                If IsNumeric(TextBox8.Text) Then
                                    updates.Add("Num_tel = @Numt")
                                    Cmd.Parameters.AddWithValue("@Numt", Convert.ToInt64(TextBox8.Text.Trim()))
                                Else
                                    MessageBox.Show("Phone number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                                If IsNumeric(TextBox9.Text) Then
                                    updates.Add("Nbr_points = @points")
                                    Cmd.Parameters.AddWithValue("@points", Convert.ToInt32(TextBox9.Text.Trim()))
                                Else
                                    MessageBox.Show("Points must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Client SET " & String.Join(", ", updates) & " WHERE ID_Client = @ID_CL"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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