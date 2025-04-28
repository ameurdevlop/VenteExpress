Public Class Facture
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
    End Sub
    Private Sub ResetItems()
        Dim invisiblesEtInactives As Control() = {TextBox1, MonthCalendar1, TextBox3, Label4, Label10, Label11, Label12,
                                                  Button1, Button2, ComboBox2, TextBox2}

        For Each ctrl In invisiblesEtInactives
            ctrl.Visible = False
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is ComboBox Then
                ctrl.Enabled = False
            End If
        Next
    End Sub

    Private Sub Facture_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter une Facture"
                Dim visiblesEtActives As Control() = {TextBox1, ComboBox2, MonthCalendar1, TextBox3, Button1, Button2,
                                       Label1, Label4, Label10, Label11, Label12}
                Dim visiblesEtInactives As Control() = {TextBox2}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = False
                    ctrl.Enabled = False
                Next

                TextBox1.Text = ""
                TextBox3.Text = ""
                ComboBox2.Text = ""
            Case "Supprimer une Facture"
                Dim visiblesEtActives As Control() = {TextBox1, Button1, Button2, Label1, Label4, Label10, Label11, Label12, MonthCalendar1}
                Dim visiblesEtInactives As Control() = {TextBox3, ComboBox2}
                Dim invisibles As Control() = {TextBox2}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next

                For Each ctrl In invisibles
                    ctrl.Visible = False
                Next

                TextBox1.Text = ""
                TextBox3.Text = ""
                ComboBox2.Text = ""

            Case "Rechercher une Facture"

                Dim visiblesEtActives As Control() = {TextBox1, Label1, Label4, Label10, Label11, Label12, Button1, Button2, TextBox2}
                Dim visiblesEtInactives As Control() = {TextBox3, ComboBox2}
                Dim invisibles As Control() = {MonthCalendar1}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next

                For Each ctrl In invisibles
                    ctrl.Visible = False
                Next

                TextBox1.Text = ""
                TextBox3.Text = ""
                ComboBox2.Text = ""

            Case "Modifier une Facture"
                Dim visiblesEtActives As Control() = {TextBox1, TextBox3, ComboBox2, MonthCalendar1, Label1, Label4,
                                       Label10, Label11, Label12, Button1, Button2}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                TextBox1.Text = ""
                TextBox3.Text = ""
                ComboBox2.Text = ""
            Case Else
                ResetItems()
        End Select


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Ajouter une Facture" Then

                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                    MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    ouvrir_connection()

                    sql = "SELECT COUNT(*) FROM Facture WHERE Num_facture = @ID_FA"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "INSERT INTO Facture (Num_facture, Date, [Méthode payement], Responsable) VALUES (@ID_FA, @DateParam, @Second_name, @Name)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Second_name", ComboBox2.Text.Trim())
                        Dim selectedDate As Date = MonthCalendar1.SelectionStart

                        Cmd.Parameters.AddWithValue("@DateParam", selectedDate)

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Facture ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    fermer_connection()
                End If
            End If

        End If




        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer une Facture" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Facture WHERE Num_facture = @ID_FA"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show(" Facture supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Facture n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If selectedItem = "Rechercher une Facture" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Facture WHERE Num_facture = @ID_FA"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Facture existe .")
                        dr.Read()
                        TextBox1.Text = dr.Item("Num_facture").ToString()
                        TextBox3.Text = dr.Item("Responsable").ToString()
                        TextBox2.Text = dr.Item("Date").ToString()
                        ComboBox2.Text = dr.Item("Méthode payement").ToString()

                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If



        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier une Facture" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("Entrer l'ID de Facture...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                        ' Build SET clause only for non-empty fields
                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Date = @date")
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@Date", selectedDate)
                        End If

                        If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                            updates.Add("[Méthode payement] = @MET")
                            Cmd.Parameters.AddWithValue("MET", ComboBox2.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Responsable = @RES")
                            Cmd.Parameters.AddWithValue("RES", TextBox3.Text.Trim())
                        End If
                        ' Check if there is at least one field to update
                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Facture SET " & String.Join(", ", updates) & " WHERE Num_facture = @ID_FA"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Facture modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                If selectedItem = "Ajouter une Facture" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Facture WHERE Num_facture = @ID_FA"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Facture (Num_facture, Date, [Méthode payement], Responsable) VALUES (@ID_FA, @DateParam, @Second_name, @Name)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Second_name", ComboBox2.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart

                            Cmd.Parameters.AddWithValue("@DateParam", selectedDate)

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Facture ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Facture WHERE Num_facture = @ID_FA"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Facture supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Facture n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Facture WHERE Num_facture = @ID_FA"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Facture existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("Num_facture").ToString()
                            TextBox3.Text = dr.Item("Responsable").ToString()
                            TextBox2.Text = dr.Item("Date").ToString()
                            ComboBox2.Text = dr.Item("Méthode payement").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Entrer l'ID de Facture...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date = @date")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@Date", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                updates.Add("[Méthode payement] = @MET")
                                Cmd.Parameters.AddWithValue("MET", ComboBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Responsable = @RES")
                                Cmd.Parameters.AddWithValue("RES", TextBox3.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Facture SET " & String.Join(", ", updates) & " WHERE Num_facture = @ID_FA"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Facture modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                If selectedItem = "Ajouter une Facture" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Facture WHERE Num_facture = @ID_FA"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Facture (Num_facture, Date, [Méthode payement], Responsable) VALUES (@ID_FA, @DateParam, @Second_name, @Name)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Second_name", ComboBox2.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart

                            Cmd.Parameters.AddWithValue("@DateParam", selectedDate)

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Facture ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Facture WHERE Num_facture = @ID_FA"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Facture supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Facture n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Facture WHERE Num_facture = @ID_FA"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Facture existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("Num_facture").ToString()
                            TextBox3.Text = dr.Item("Responsable").ToString()
                            TextBox2.Text = dr.Item("Date").ToString()
                            ComboBox2.Text = dr.Item("Méthode payement").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Entrer l'ID de Facture...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date = @date")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@Date", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                updates.Add("[Méthode payement] = @MET")
                                Cmd.Parameters.AddWithValue("MET", ComboBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Responsable = @RES")
                                Cmd.Parameters.AddWithValue("RES", TextBox3.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Facture SET " & String.Join(", ", updates) & " WHERE Num_facture = @ID_FA"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Facture modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                If selectedItem = "Ajouter une Facture" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(ComboBox2.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Facture WHERE Num_facture = @ID_FA"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Client est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Facture (Num_facture, Date, [Méthode payement], Responsable) VALUES (@ID_FA, @DateParam, @Second_name, @Name)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Second_name", ComboBox2.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@DateParam", selectedDate)

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Facture ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If

            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Facture WHERE Num_facture = @ID_FA"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Facture supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Facture n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Facture WHERE Num_facture = @ID_FA"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Facture existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("Num_facture").ToString()
                            TextBox3.Text = dr.Item("Responsable").ToString()
                            TextBox2.Text = dr.Item("Date").ToString()
                            ComboBox2.Text = dr.Item("Méthode payement").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier une Facture" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Entrer l'ID de Facture...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_FA", TextBox1.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date = @date")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@Date", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(ComboBox2.Text) Then
                                updates.Add("[Méthode payement] = @MET")
                                Cmd.Parameters.AddWithValue("MET", ComboBox2.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Responsable = @RES")
                                Cmd.Parameters.AddWithValue("RES", TextBox3.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Facture SET " & String.Join(", ", updates) & " WHERE Num_facture = @ID_FA"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Facture modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged

    End Sub
End Class