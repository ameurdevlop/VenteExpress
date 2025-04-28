Public Class Caisse
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox3.Text = ""
    End Sub
    Private Sub ResetItems()
        TextBox1.Visible = False
        TextBox1.Enabled = False
        TextBox1.Text = ""
        TextBox3.Visible = False
        TextBox3.Enabled = False
        TextBox3.Text = ""
        Label10.Visible = False
        Label11.Visible = False

        Button1.Visible = False
        Button2.Visible = False
    End Sub

    Private Sub Caisse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetItems()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetItems()
        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter une Caisse"
                TextBox1.Visible = True
                TextBox1.Enabled = True

                TextBox3.Visible = True
                TextBox3.Enabled = True

                Label1.Visible = True

                Label10.Visible = True
                Label11.Visible = True

                Button1.Visible = True
                Button2.Visible = True
            Case "Supprimer une Caisse"
                TextBox1.Visible = True
                TextBox1.Enabled = True
                ' reste 

                TextBox3.Visible = True
                TextBox3.Enabled = False

                Label1.Visible = True

                Label10.Visible = True
                Label11.Visible = True

                Button1.Visible = True
                Button2.Visible = True
            Case "Rechercher une Caisse"
                TextBox1.Visible = True
                TextBox1.Enabled = True

                TextBox3.Visible = True
                TextBox3.Enabled = False

                Label1.Visible = True

                Label10.Visible = True
                Label11.Visible = True

                Button1.Visible = True
                Button2.Visible = True
            Case "Modifier une Caisse"
                TextBox1.Visible = True
                TextBox1.Enabled = True

                TextBox3.Visible = True
                TextBox3.Enabled = True

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()


            If selectedItem = "Ajouter une Caisse" Then

                If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                    MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ' Open connection
                    ouvrir_connection()

                    sql = "SELECT COUNT(*) FROM Caisse WHERE No_caisse = @ID_Mode"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Cette caisse est deja existante , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "INSERT INTO Caisse (No_caisse, Id_ouvrier) VALUES (@ID_Mode, @Désignation)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Caisse ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If


                    fermer_connection()
                End If
            End If



        End If

        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer une Caisse" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ouvrir_connection()
                    sql = "delete from Caisse where No_caisse=  '" & Val(TextBox1.Text) & "' "
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.ExecuteNonQuery()
                    MessageBox.Show("Caisse est supprime avec succes")
                    fermer_connection()
                End If
            End If
        End If




        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Rechercher une Caisse" Then
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Mode_payement WHERE No_caisse = @ID_Cais"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_Cais", TextBox1.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Caisse existe .")
                        dr.Read()
                        TextBox1.Text = dr.Item("No_caisse").ToString()
                        TextBox3.Text = dr.Item("Id_ouvrier").ToString()
                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If





        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Modifier une Caisse" Then
                ' Check if TextBox1 and TextBox3 are not empty
                If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ouvrir_connection()
                    sql = "update Caisse  set  Id_ouvrier='" & TextBox3.Text & "' where No_caisse='" & TextBox1.Text & "'"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.ExecuteNonQuery()
                    MessageBox.Show(" Caisse modifier avec succes")
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
                If selectedItem = "Rechercher une Caisse" Then
                    ' Check if TextBox1 and TextBox3 are not empty
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "select * from Caisse where No_caisse='" & Val(TextBox1.Text) & "'"
                        ouvrir_connection()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        dr = Cmd.ExecuteReader()
                        If (dr.HasRows = True) Then
                            MessageBox.Show("cette caisse existe:")
                            dr.Read()
                            TextBox1.Text = dr.Item("No_caisse")
                            TextBox3.Text = dr.Item("Id_ouvrier")
                        End If
                        fermer_connection()
                    End If
                End If
            End If

            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer une Caisse" Then
                    ' Check if TextBox1 and TextBox3 are not empty
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ouvrir_connection()
                        sql = "delete from Caisse where No_caisse=  '" & Val(TextBox1.Text) & "' "
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Caisse est supprime avec succes")
                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Modifier une Caisse" Then
                    ' Check if TextBox1 and TextBox3 are not empty
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ouvrir_connection()
                        sql = "update Caisse  set  Id_ouvrier='" & TextBox3.Text & "' where No_caisse='" & TextBox1.Text & "'"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show(" Caisse modifier avec succes")
                        fermer_connection()
                    End If
                End If
            End If



            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter une Caisse" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Caisse WHERE No_caisse = @ID_Mode"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Cette caisse est deja existante , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Caisse (No_caisse, Id_ouvrier) VALUES (@ID_Mode, @Désignation)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Caisse ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If


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
                If selectedItem = "Ajouter une Caisse" Then

                    If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox3.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ' Open connection
                        ouvrir_connection()

                        sql = "SELECT COUNT(*) FROM Caisse WHERE No_caisse = @ID_Mode"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Cette caisse est deja existante , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Caisse (No_caisse, Id_ouvrier) VALUES (@ID_Mode, @Désignation)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_Mode", TextBox1.Text.Trim())
                            Cmd.Parameters.AddWithValue("@Désignation", TextBox3.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Caisse ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If


                        fermer_connection()
                    End If
                End If

            End If

            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer une Caisse" Then
                    ' Check if TextBox1 and TextBox3 are not empty
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ouvrir_connection()
                        sql = "delete from Caisse where No_caisse=  '" & Val(TextBox1.Text) & "' "
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Caisse est supprime avec succes")
                        fermer_connection()
                    End If
                End If
            End If

            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Rechercher une Caisse" Then
                    ' Check if TextBox1 and TextBox3 are not empty
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "select * from Caisse where No_caisse='" & Val(TextBox1.Text) & "'"
                        ouvrir_connection()
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        dr = Cmd.ExecuteReader()
                        If (dr.HasRows = True) Then
                            MessageBox.Show("cette caisse existe:")
                            dr.Read()
                            TextBox1.Text = dr.Item("No_caisse")
                            TextBox3.Text = dr.Item("Id_ouvrier")
                        End If
                        fermer_connection()
                    End If
                End If
            End If

            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Modifier une Caisse" Then
                    ' Check if TextBox1 and TextBox3 are not empty
                    If String.IsNullOrWhiteSpace(TextBox1.Text) Then
                        MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        ouvrir_connection()
                        sql = "update Caisse  set  Id_ouvrier='" & TextBox3.Text & "' where No_caisse='" & TextBox1.Text & "'"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show(" Caisse modifier avec succes")
                        fermer_connection()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Caisse_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            TextBox1.Text = ""
            TextBox3.Text = ""
        End If
    End Sub
End Class