Public Class Congé
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Private Sub ResetItems()
        Dim invisiblesEtInactifs As Control() = {TextBox1, TextBox2, TextBox3, TextBox8, TextBox9,
                                                 Button1, Button2, Label4, Label10, Label11, Label12, Label13,
                                                 MonthCalendar1, MonthCalendar2}

        For Each ctrl In invisiblesEtInactifs
            ctrl.Visible = False
            ctrl.Enabled = False
        Next

    End Sub

    Private Sub Congé_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter un Congé"
                Dim visiblesEtActives As Control() = {TextBox1, TextBox8, TextBox9, Label1, Label4, Label10, Label11, Label12, Label13, Button1, Button2, MonthCalendar1, MonthCalendar2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3}

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
                TextBox9.Text = ""
            Case "Supprimer un Congé"

                Dim visiblesEtActives As Control() = {TextBox1, Label1, Label4, Label10, Label11, Label12, Label13, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, TextBox8, TextBox9}
                Dim invisibles As Control() = {MonthCalendar1, MonthCalendar2}

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
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""

            Case "Rechercher un Congé"

                Dim visiblesEtActives As Control() = {TextBox1, Label1, Label4, Label10, Label11, Label12, Label13, Button1, Button2}
                Dim visiblesEtInactives As Control() = {TextBox2, TextBox3, TextBox8, TextBox9}
                Dim invisibles As Control() = {MonthCalendar1, MonthCalendar2}

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
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""

            Case "Modifier un Congé"

                Dim visiblesEtActives As Control() = {TextBox1, TextBox8, TextBox9, MonthCalendar1, MonthCalendar2,
                                       Label1, Label4, Label10, Label11, Label12, Label13, Button1, Button2}
                Dim invisiblesEtInactives As Control() = {TextBox2, TextBox3}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In invisiblesEtInactives
                    ctrl.Visible = False
                    ctrl.Enabled = False
                Next

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""

            Case Else
                ResetItems()
        End Select
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Ajouter un Congé" Then

                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox8.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                    MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    ouvrir_connection()

                    sql = "SELECT COUNT(*) FROM Conjé WHERE ID_Conjé = @ID_C"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Cette demande est deja existante , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "INSERT INTO Conjé (ID_Conjé, Date_début, Date_fin, Durée, ID_ouvrier) VALUES (@ID_C, @D_DE, @D_FN, @DUR, @ID_OV)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@DUR", TextBox8.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ID_OV", TextBox9.Text.Trim())
                        Dim selectedDate As Date = MonthCalendar1.SelectionStart
                        Cmd.Parameters.AddWithValue("@D_DE", selectedDate)
                        Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                        Cmd.Parameters.AddWithValue("@D_FN", selectedDate1)
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Demande ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    fermer_connection()
                End If
            End If
        End If





        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer un Congé" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Conjé WHERE ID_Conjé = @ID_C"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show(" Demande supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("La Demande n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If selectedItem = "Rechercher un Congé" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Conjé WHERE ID_Conjé = @ID_C"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Demande existe .")
                        dr.Read()
                        TextBox1.Text = dr.Item("ID_Conjé").ToString()
                        TextBox3.Text = dr.Item("Date_début").ToString()
                        TextBox2.Text = dr.Item("Date_fin").ToString()
                        TextBox8.Text = dr.Item("Durée").ToString()
                        TextBox9.Text = dr.Item("ID_ouvrier").ToString()
                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If





        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier un Congé" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("Enter the leave request ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Step 1: Check current start date in database
                        sql = "SELECT Date_début FROM Conjé WHERE ID_Conjé = @ID_C"
                        Cmd.Parameters.Clear()
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                        Dim dbStartDate As Date = Convert.ToDateTime(Cmd.ExecuteScalar())
                        Dim today As Date = Date.Today

                        ' Step 2: Prevent modification if date is today
                        If dbStartDate.Date = today Then
                            MessageBox.Show("You cannot modify this leave request because it starts today.", "Modification Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        ' Step 3: Build update
                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Date_début = @D_DE")
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_DE", selectedDate)
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                            updates.Add("Date_fin = @D_FI")
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_FI", selectedDate1)
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                            updates.Add("Durée = @DUR")
                            Cmd.Parameters.AddWithValue("@DUR", TextBox8.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                            updates.Add("ID_ouvrier = @ID_OV")
                            Cmd.Parameters.AddWithValue("@ID_OV", TextBox9.Text.Trim())
                        End If

                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Conjé SET " & String.Join(", ", updates) & " WHERE ID_Conjé = @ID_C"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Leave request updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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
                If selectedItem = "Ajouter un Congé" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox8.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Conjé WHERE ID_Conjé = @ID_C"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Cette demande est deja existante , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Conjé (ID_Conjé, Date_début, Date_fin, Durée, ID_ouvrier) VALUES (@ID_C, @D_DE, @D_FN, @DUR, @ID_OV)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DUR", TextBox8.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ID_OV", TextBox9.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_DE", selectedDate)
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_FN", selectedDate1)
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Demande ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Conjé WHERE ID_Conjé = @ID_C"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Demande supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("La Demande n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Conjé WHERE ID_Conjé = @ID_C"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Demande existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Conjé").ToString()
                            TextBox3.Text = dr.Item("Date_début").ToString()
                            TextBox2.Text = dr.Item("Date_fin").ToString()
                            TextBox8.Text = dr.Item("Durée").ToString()
                            TextBox9.Text = dr.Item("ID_ouvrier").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Enter the leave request ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Step 1: Check current start date in database
                            sql = "SELECT Date_début FROM Conjé WHERE ID_Conjé = @ID_C"
                            Cmd.Parameters.Clear()
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            Dim dbStartDate As Date = Convert.ToDateTime(Cmd.ExecuteScalar())
                            Dim today As Date = Date.Today

                            ' Step 2: Prevent modification if date is today
                            If dbStartDate.Date = today Then
                                MessageBox.Show("You cannot modify this leave request because it starts today.", "Modification Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            ' Step 3: Build update
                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_début = @D_DE")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@D_DE", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_fin = @D_FI")
                                Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                                Cmd.Parameters.AddWithValue("@D_FI", selectedDate1)
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                updates.Add("Durée = @DUR")
                                Cmd.Parameters.AddWithValue("@DUR", TextBox8.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                                updates.Add("ID_ouvrier = @ID_OV")
                                Cmd.Parameters.AddWithValue("@ID_OV", TextBox9.Text.Trim())
                            End If

                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Conjé SET " & String.Join(", ", updates) & " WHERE ID_Conjé = @ID_C"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Leave request updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Congé" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox8.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Conjé WHERE ID_Conjé = @ID_C"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Cette demande est deja existante , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Conjé (ID_Conjé, Date_début, Date_fin, Durée, ID_ouvrier) VALUES (@ID_C, @D_DE, @D_FN, @DUR, @ID_OV)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DUR", TextBox8.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ID_OV", TextBox9.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_DE", selectedDate)
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_FN", selectedDate1)
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Demande ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Conjé WHERE ID_Conjé = @ID_C"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Demande supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("La Demande n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Conjé WHERE ID_Conjé = @ID_C"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Demande existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Conjé").ToString()
                            TextBox3.Text = dr.Item("Date_début").ToString()
                            TextBox2.Text = dr.Item("Date_fin").ToString()
                            TextBox8.Text = dr.Item("Durée").ToString()
                            TextBox9.Text = dr.Item("ID_ouvrier").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Enter the leave request ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Step 1: Check current start date in database
                            sql = "SELECT Date_début FROM Conjé WHERE ID_Conjé = @ID_C"
                            Cmd.Parameters.Clear()
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            Dim dbStartDate As Date = Convert.ToDateTime(Cmd.ExecuteScalar())
                            Dim today As Date = Date.Today

                            ' Step 2: Prevent modification if date is today
                            If dbStartDate.Date = today Then
                                MessageBox.Show("You cannot modify this leave request because it starts today.", "Modification Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            ' Step 3: Build update
                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_début = @D_DE")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@D_DE", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_fin = @D_FI")
                                Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                                Cmd.Parameters.AddWithValue("@D_FI", selectedDate1)
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                updates.Add("Durée = @DUR")
                                Cmd.Parameters.AddWithValue("@DUR", TextBox8.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                                updates.Add("ID_ouvrier = @ID_OV")
                                Cmd.Parameters.AddWithValue("@ID_OV", TextBox9.Text.Trim())
                            End If

                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Conjé SET " & String.Join(", ", updates) & " WHERE ID_Conjé = @ID_C"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Leave request updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Congé" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox8.Text) OrElse String.IsNullOrWhiteSpace(TextBox9.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Conjé WHERE ID_Conjé = @ID_C"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Cette demande est deja existante , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Conjé (ID_Conjé, Date_début, Date_fin, Durée, ID_ouvrier) VALUES (@ID_C, @D_DE, @D_FN, @DUR, @ID_OV)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DUR", TextBox8.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ID_OV", TextBox9.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_DE", selectedDate)
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_FN", selectedDate1)
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Demande ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Conjé WHERE ID_Conjé = @ID_C"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Demande supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("La Demande n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Conjé WHERE ID_Conjé = @ID_C"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Demande existe .")
                            dr.Read()
                            TextBox1.Text = dr.Item("ID_Conjé").ToString()
                            TextBox3.Text = dr.Item("Date_début").ToString()
                            TextBox2.Text = dr.Item("Date_fin").ToString()
                            TextBox8.Text = dr.Item("Durée").ToString()
                            TextBox9.Text = dr.Item("ID_ouvrier").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Congé" Then
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Enter the leave request ID...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Step 1: Check current start date in database
                            sql = "SELECT Date_début FROM Conjé WHERE ID_Conjé = @ID_C"
                            Cmd.Parameters.Clear()
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            Dim dbStartDate As Date = Convert.ToDateTime(Cmd.ExecuteScalar())
                            Dim today As Date = Date.Today

                            ' Step 2: Prevent modification if date is today
                            If dbStartDate.Date = today Then
                                MessageBox.Show("You cannot modify this leave request because it starts today.", "Modification Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            ' Step 3: Build update
                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_C", TextBox1.Text.Trim())

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_début = @D_DE")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@D_DE", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox3.Text) Then
                                updates.Add("Date_fin = @D_FI")
                                Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                                Cmd.Parameters.AddWithValue("@D_FI", selectedDate1)
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox8.Text) Then
                                updates.Add("Durée = @DUR")
                                Cmd.Parameters.AddWithValue("@DUR", TextBox8.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(TextBox9.Text) Then
                                updates.Add("ID_ouvrier = @ID_OV")
                                Cmd.Parameters.AddWithValue("@ID_OV", TextBox9.Text.Trim())
                            End If

                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Conjé SET " & String.Join(", ", updates) & " WHERE ID_Conjé = @ID_C"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Leave request updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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