Public Class Moyen_de_Transport
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Designation.Text = ""
        Matricule.Text = ""
        Etat.Text = ""
        Assurance.Text = ""
        Vignette.Text = ""
        Dat_achat.Text = ""
        Dat_reparation.Text = ""
    End Sub
    Private Sub ResetItems()
        Dim invisiblesEtInactives As Control() = {Vignette, Designation, Matricule, Etat, Assurance,
                                          MonthCalendar1, MonthCalendar2, Label4, Label5, Label11,
                                          Label12, Label13, Button1, Button2, Dat_reparation,
                                          Dat_achat, Label2, Label3}

        For Each ctrl In invisiblesEtInactives
            ctrl.Visible = False
            ctrl.Enabled = False
        Next
    End Sub

    Private Sub Moyen_de_Transport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter un Matériel de Transport"
                Dim visiblesEtActives As Control() = {Vignette, Designation, Matricule, Etat, Assurance,
                                       MonthCalendar1, MonthCalendar2, Label5, Label2, Label1,
                                       Label3, Label4, Label11, Label12, Label13, Button1, Button2}

                Dim invisiblesEtInactives As Control() = {Dat_achat, Dat_reparation}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In invisiblesEtInactives
                    ctrl.Visible = False
                    ctrl.Enabled = False
                Next
            Case "Supprimer un Matériel de Transport"
                Dim visiblesEtActives As Control() = {Dat_reparation, Dat_achat, MonthCalendar1, MonthCalendar2, Label2,
                                       Label1, Label3, Label4, Label11, Label12, Label13, Button1, Button2}

                Dim visiblesEtInactives As Control() = {Vignette, Designation, Matricule, Etat, Assurance}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In visiblesEtInactives
                    ctrl.Visible = True
                    ctrl.Enabled = False
                Next
            Case "Rechercher un Matériel de Transport"
                Dim visiblesEtActives As Control() = {Matricule, Label5, Label1, Label3, Label4, Label11, Label12, Label13, Button1, Button2, Label2}
                Dim visiblesEtInactives As Control() = {Vignette, Dat_reparation, Dat_achat, Designation, Etat, Assurance}
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
            Case "Modifier un Matériel de Transport"
                Dim visiblesEtActives As Control() = {Vignette, Designation, Matricule, Etat, Assurance,
                                       Label1, Label3, Label4, Label11, Label12, Label13,
                                       Button1, MonthCalendar1, MonthCalendar2, Label5, Label2}

                Dim invisiblesEtInactives As Control() = {Dat_achat, Dat_reparation}

                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next

                For Each ctrl In invisiblesEtInactives
                    ctrl.Visible = False
                    ctrl.Enabled = False
                Next
            Case Else
                ResetItems()
        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Ajouter un Matériel de Transport" Then

                If String.IsNullOrWhiteSpace(Matricule.Text) OrElse String.IsNullOrWhiteSpace(Designation.Text) OrElse String.IsNullOrWhiteSpace(Etat.Text) OrElse String.IsNullOrWhiteSpace(Assurance.Text) OrElse String.IsNullOrWhiteSpace(Vignette.Text) Then
                    MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    ouvrir_connection()

                    sql = "SELECT COUNT(*) FROM Moyen_Transport WHERE Matricule = @MAT"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce Matériel est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "INSERT INTO Moyen_Transport (Matricule, Désignation, Etat, Assurance, Vignette, Date_achat, Date_réparation) VALUES (@MAT, @DES, @ETAT, @ASS, @VIGN, @D_ACH, @D_REP)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                        Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ETAT", Etat.Text.Trim())
                        Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                        Cmd.Parameters.AddWithValue("@VIGN", Vignette.Text.Trim())
                        Dim selectedDate As Date = MonthCalendar1.SelectionStart
                        Cmd.Parameters.AddWithValue("@D_ACH", selectedDate)
                        Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                        Cmd.Parameters.AddWithValue("@D_REP", selectedDate1)
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Materiel ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    fermer_connection()
                End If
            End If
        End If




        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer un Matériel de Transport" Then
                If String.IsNullOrWhiteSpace(Matricule.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Moyen_Transport WHERE Matricule = @MAT"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show(" Materiel supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Le Materiel n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If selectedItem = "Rechercher un Matériel de Transport" Then
                If String.IsNullOrWhiteSpace(Matricule.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Moyen_Transport WHERE Matricule = @MAT"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Materiel  existe .")
                        dr.Read()
                        Matricule.Text = dr.Item("Matricule").ToString()
                        Designation.Text = dr.Item("Désignation").ToString()
                        Etat.Text = dr.Item("Etat").ToString()
                        Vignette.Text = dr.Item("Vignette").ToString()
                        Assurance.Text = dr.Item("Assurance").ToString()
                        Dat_achat.Text = dr.Item("Date_achat").ToString()
                        Dat_reparation.Text = dr.Item("Date_réparation").ToString()
                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If


        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier un Matériel de Transport" Then
                If String.IsNullOrWhiteSpace(Matricule.Text) Then
                    MessageBox.Show("Entrer le matricule de Matériel...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                        ' Build SET clause only for non-empty fields
                        If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                            updates.Add("Date_achat = @date")
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@Date", selectedDate)
                        End If
                        If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                            updates.Add("Date_réparation = @da_re")
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@da_re", selectedDate)
                        End If

                        If Not String.IsNullOrWhiteSpace(Designation.Text) Then
                            updates.Add("Désignation = @DES")
                            Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(Etat.Text) Then
                            updates.Add("Etat = @ETAT")
                            Cmd.Parameters.AddWithValue("ETAT", Etat.Text.Trim())
                        End If
                        If Not String.IsNullOrWhiteSpace(Assurance.Text) Then
                            updates.Add("Assurance = @ASS")
                            Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                        End If
                        If Not String.IsNullOrWhiteSpace(Vignette.Text) Then
                            updates.Add("Vignette = @VIG")
                            Cmd.Parameters.AddWithValue("@VIG", Vignette.Text.Trim())
                        End If
                        ' Check if there is at least one field to update
                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Moyen_Transport SET " & String.Join(", ", updates) & " WHERE Matricule = @MAT"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Matériel modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        fermer_connection()
                    End Try
                End If
            End If
        End If




    End Sub

    Private Sub Matricule_TextChanged(sender As Object, e As EventArgs) Handles Matricule.TextChanged

    End Sub

    Private Sub Matricule_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Matricule.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Matériel de Transport" Then

                    If String.IsNullOrWhiteSpace(Matricule.Text) OrElse String.IsNullOrWhiteSpace(Designation.Text) OrElse String.IsNullOrWhiteSpace(Etat.Text) OrElse String.IsNullOrWhiteSpace(Assurance.Text) OrElse String.IsNullOrWhiteSpace(Vignette.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Moyen_Transport WHERE Matricule = @MAT"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Matériel est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Moyen_Transport (Matricule, Désignation, Etat, Assurance, Vignette, Date_achat, Date_réparation) VALUES (@MAT, @DES, @ETAT, @ASS, @VIGN, @D_ACH, @D_REP)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ETAT", Etat.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            Cmd.Parameters.AddWithValue("@VIGN", Vignette.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_ACH", selectedDate)
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_REP", selectedDate1)
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Materiel ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Moyen_Transport WHERE Matricule = @MAT"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Materiel supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Materiel n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Moyen_Transport WHERE Matricule = @MAT"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Materiel  existe .")
                            dr.Read()
                            Matricule.Text = dr.Item("Matricule").ToString()
                            Designation.Text = dr.Item("Désignation").ToString()
                            Etat.Text = dr.Item("Etat").ToString()
                            Vignette.Text = dr.Item("Vignette").ToString()
                            Assurance.Text = dr.Item("Assurance").ToString()
                            Dat_achat.Text = dr.Item("Date_achat").ToString()
                            Dat_reparation.Text = dr.Item("Date_réparation").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("Entrer le matricule de Matériel...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_achat = @date")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@Date", selectedDate)
                            End If
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_réparation = @da_re")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@da_re", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(Designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Etat.Text) Then
                                updates.Add("Etat = @ETAT")
                                Cmd.Parameters.AddWithValue("ETAT", Etat.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Assurance.Text) Then
                                updates.Add("Assurance = @ASS")
                                Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Vignette.Text) Then
                                updates.Add("Vignette = @VIG")
                                Cmd.Parameters.AddWithValue("@VIG", Vignette.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Moyen_Transport SET " & String.Join(", ", updates) & " WHERE Matricule = @MAT"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Matériel modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Designation_TextChanged(sender As Object, e As EventArgs) Handles Designation.TextChanged

    End Sub

    Private Sub Designation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Designation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Matériel de Transport" Then

                    If String.IsNullOrWhiteSpace(Matricule.Text) OrElse String.IsNullOrWhiteSpace(Designation.Text) OrElse String.IsNullOrWhiteSpace(Etat.Text) OrElse String.IsNullOrWhiteSpace(Assurance.Text) OrElse String.IsNullOrWhiteSpace(Vignette.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Moyen_Transport WHERE Matricule = @MAT"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Matériel est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Moyen_Transport (Matricule, Désignation, Etat, Assurance, Vignette, Date_achat, Date_réparation) VALUES (@MAT, @DES, @ETAT, @ASS, @VIGN, @D_ACH, @D_REP)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ETAT", Etat.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            Cmd.Parameters.AddWithValue("@VIGN", Vignette.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_ACH", selectedDate)
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_REP", selectedDate1)
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Materiel ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Moyen_Transport WHERE Matricule = @MAT"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Materiel supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Materiel n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Moyen_Transport WHERE Matricule = @MAT"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Materiel  existe .")
                            dr.Read()
                            Matricule.Text = dr.Item("Matricule").ToString()
                            Designation.Text = dr.Item("Désignation").ToString()
                            Etat.Text = dr.Item("Etat").ToString()
                            Vignette.Text = dr.Item("Vignette").ToString()
                            Assurance.Text = dr.Item("Assurance").ToString()
                            Dat_achat.Text = dr.Item("Date_achat").ToString()
                            Dat_reparation.Text = dr.Item("Date_réparation").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("Entrer le matricule de Matériel...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_achat = @date")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@Date", selectedDate)
                            End If
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_réparation = @da_re")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@da_re", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(Designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Etat.Text) Then
                                updates.Add("Etat = @ETAT")
                                Cmd.Parameters.AddWithValue("ETAT", Etat.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Assurance.Text) Then
                                updates.Add("Assurance = @ASS")
                                Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Vignette.Text) Then
                                updates.Add("Vignette = @VIG")
                                Cmd.Parameters.AddWithValue("@VIG", Vignette.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Moyen_Transport SET " & String.Join(", ", updates) & " WHERE Matricule = @MAT"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Matériel modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Etat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Etat.SelectedIndexChanged

    End Sub

    Private Sub Etat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Etat.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Matériel de Transport" Then

                    If String.IsNullOrWhiteSpace(Matricule.Text) OrElse String.IsNullOrWhiteSpace(Designation.Text) OrElse String.IsNullOrWhiteSpace(Etat.Text) OrElse String.IsNullOrWhiteSpace(Assurance.Text) OrElse String.IsNullOrWhiteSpace(Vignette.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Moyen_Transport WHERE Matricule = @MAT"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Matériel est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Moyen_Transport (Matricule, Désignation, Etat, Assurance, Vignette, Date_achat, Date_réparation) VALUES (@MAT, @DES, @ETAT, @ASS, @VIGN, @D_ACH, @D_REP)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ETAT", Etat.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            Cmd.Parameters.AddWithValue("@VIGN", Vignette.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_ACH", selectedDate)
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_REP", selectedDate1)
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Materiel ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Moyen_Transport WHERE Matricule = @MAT"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Materiel supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Materiel n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Moyen_Transport WHERE Matricule = @MAT"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Materiel  existe .")
                            dr.Read()
                            Matricule.Text = dr.Item("Matricule").ToString()
                            Designation.Text = dr.Item("Désignation").ToString()
                            Etat.Text = dr.Item("Etat").ToString()
                            Vignette.Text = dr.Item("Vignette").ToString()
                            Assurance.Text = dr.Item("Assurance").ToString()
                            Dat_achat.Text = dr.Item("Date_achat").ToString()
                            Dat_reparation.Text = dr.Item("Date_réparation").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("Entrer le matricule de Matériel...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_achat = @date")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@Date", selectedDate)
                            End If
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_réparation = @da_re")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@da_re", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(Designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Etat.Text) Then
                                updates.Add("Etat = @ETAT")
                                Cmd.Parameters.AddWithValue("ETAT", Etat.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Assurance.Text) Then
                                updates.Add("Assurance = @ASS")
                                Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Vignette.Text) Then
                                updates.Add("Vignette = @VIG")
                                Cmd.Parameters.AddWithValue("@VIG", Vignette.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Moyen_Transport SET " & String.Join(", ", updates) & " WHERE Matricule = @MAT"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Matériel modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Assurance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Assurance.SelectedIndexChanged

    End Sub

    Private Sub Assurance_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Assurance.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Matériel de Transport" Then

                    If String.IsNullOrWhiteSpace(Matricule.Text) OrElse String.IsNullOrWhiteSpace(Designation.Text) OrElse String.IsNullOrWhiteSpace(Etat.Text) OrElse String.IsNullOrWhiteSpace(Assurance.Text) OrElse String.IsNullOrWhiteSpace(Vignette.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Moyen_Transport WHERE Matricule = @MAT"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Matériel est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Moyen_Transport (Matricule, Désignation, Etat, Assurance, Vignette, Date_achat, Date_réparation) VALUES (@MAT, @DES, @ETAT, @ASS, @VIGN, @D_ACH, @D_REP)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ETAT", Etat.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            Cmd.Parameters.AddWithValue("@VIGN", Vignette.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_ACH", selectedDate)
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_REP", selectedDate1)
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Materiel ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Moyen_Transport WHERE Matricule = @MAT"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Materiel supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Materiel n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Moyen_Transport WHERE Matricule = @MAT"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Materiel  existe .")
                            dr.Read()
                            Matricule.Text = dr.Item("Matricule").ToString()
                            Designation.Text = dr.Item("Désignation").ToString()
                            Etat.Text = dr.Item("Etat").ToString()
                            Vignette.Text = dr.Item("Vignette").ToString()
                            Assurance.Text = dr.Item("Assurance").ToString()
                            Dat_achat.Text = dr.Item("Date_achat").ToString()
                            Dat_reparation.Text = dr.Item("Date_réparation").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("Entrer le matricule de Matériel...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_achat = @date")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@Date", selectedDate)
                            End If
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_réparation = @da_re")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@da_re", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(Designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Etat.Text) Then
                                updates.Add("Etat = @ETAT")
                                Cmd.Parameters.AddWithValue("ETAT", Etat.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Assurance.Text) Then
                                updates.Add("Assurance = @ASS")
                                Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Vignette.Text) Then
                                updates.Add("Vignette = @VIG")
                                Cmd.Parameters.AddWithValue("@VIG", Vignette.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Moyen_Transport SET " & String.Join(", ", updates) & " WHERE Matricule = @MAT"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Matériel modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Vignette_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Vignette.SelectedIndexChanged

    End Sub

    Private Sub Vignette_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Vignette.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Matériel de Transport" Then

                    If String.IsNullOrWhiteSpace(Matricule.Text) OrElse String.IsNullOrWhiteSpace(Designation.Text) OrElse String.IsNullOrWhiteSpace(Etat.Text) OrElse String.IsNullOrWhiteSpace(Assurance.Text) OrElse String.IsNullOrWhiteSpace(Vignette.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Moyen_Transport WHERE Matricule = @MAT"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Matériel est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Moyen_Transport (Matricule, Désignation, Etat, Assurance, Vignette, Date_achat, Date_réparation) VALUES (@MAT, @DES, @ETAT, @ASS, @VIGN, @D_ACH, @D_REP)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ETAT", Etat.Text.Trim())
                            Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            Cmd.Parameters.AddWithValue("@VIGN", Vignette.Text.Trim())
                            Dim selectedDate As Date = MonthCalendar1.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_ACH", selectedDate)
                            Dim selectedDate1 As Date = MonthCalendar2.SelectionStart
                            Cmd.Parameters.AddWithValue("@D_REP", selectedDate1)
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Materiel ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If




            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Moyen_Transport WHERE Matricule = @MAT"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Materiel supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Materiel n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Moyen_Transport WHERE Matricule = @MAT"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Materiel  existe .")
                            dr.Read()
                            Matricule.Text = dr.Item("Matricule").ToString()
                            Designation.Text = dr.Item("Désignation").ToString()
                            Etat.Text = dr.Item("Etat").ToString()
                            Vignette.Text = dr.Item("Vignette").ToString()
                            Assurance.Text = dr.Item("Assurance").ToString()
                            Dat_achat.Text = dr.Item("Date_achat").ToString()
                            Dat_reparation.Text = dr.Item("Date_réparation").ToString()
                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If


            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Matériel de Transport" Then
                    If String.IsNullOrWhiteSpace(Matricule.Text) Then
                        MessageBox.Show("Entrer le matricule de Matériel...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@MAT", Matricule.Text.Trim())

                            ' Build SET clause only for non-empty fields
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_achat = @date")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@Date", selectedDate)
                            End If
                            If Not String.IsNullOrWhiteSpace(Matricule.Text) Then
                                updates.Add("Date_réparation = @da_re")
                                Dim selectedDate As Date = MonthCalendar1.SelectionStart
                                Cmd.Parameters.AddWithValue("@da_re", selectedDate)
                            End If

                            If Not String.IsNullOrWhiteSpace(Designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", Designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Etat.Text) Then
                                updates.Add("Etat = @ETAT")
                                Cmd.Parameters.AddWithValue("ETAT", Etat.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Assurance.Text) Then
                                updates.Add("Assurance = @ASS")
                                Cmd.Parameters.AddWithValue("@ASS", Assurance.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Vignette.Text) Then
                                updates.Add("Vignette = @VIG")
                                Cmd.Parameters.AddWithValue("@VIG", Vignette.Text.Trim())
                            End If
                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Moyen_Transport SET " & String.Join(", ", updates) & " WHERE Matricule = @MAT"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Matériel modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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