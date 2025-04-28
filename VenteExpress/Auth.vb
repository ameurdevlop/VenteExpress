Public Class Auth
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
            MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ouvrir_connection()

            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = sql
            ' Cmd.Connection = con
            Cmd.CommandText = "SELECT * FROM Ouvrier WHERE ID_ouvrier = @ID AND mot_de_passe = @MDP"
            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@ID", TextBox1.Text.Trim())
            Cmd.Parameters.AddWithValue("@MDP", TextBox2.Text.Trim())

            dr = Cmd.ExecuteReader()

            If dr.HasRows Then
                dr.Read()
                Dim grade As String = dr("Grade").ToString().ToLower()

                Select Case grade
                    Case "caissier"
                        MessageBox.Show("Bienvenue, Caissier.")
                        Commande.Show()
                        Me.Hide()

                    Case "administration"
                        MessageBox.Show("Bienvenue, Administration.")
                        Administration.Show()
                        Me.Hide()
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                    Case Else
                        MessageBox.Show("Vous n'avez pas les droits d'accès.", "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
            Else
                MessageBox.Show("ID ou mot de passe incorrect.", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        Finally
            fermer_connection()
        End Try
    End Sub

    Private Sub Auth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Auth_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.M Then
            Dim startInfo As New ProcessStartInfo()
            startInfo.FileName = "C:\Users\LENOVO\Downloads\test\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"
            Process.Start(startInfo)
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                ouvrir_connection()

                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = sql
                ' Cmd.Connection = con
                Cmd.CommandText = "SELECT * FROM Ouvrier WHERE ID_ouvrier = @ID AND mot_de_passe = @MDP"
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("@ID", TextBox1.Text.Trim())
                Cmd.Parameters.AddWithValue("@MDP", TextBox2.Text.Trim())

                dr = Cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    Dim grade As String = dr("Grade").ToString().ToLower()

                    Select Case grade
                        Case "caissier"
                            MessageBox.Show("Bienvenue, Caissier.")
                            Commande.Show()
                            Me.Hide()
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                        Case "administration"
                            MessageBox.Show("Bienvenue, Administration.")
                            Administration.Show()
                            Me.Hide()
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                        Case Else
                            MessageBox.Show("Vous n'avez pas les droits d'accès.", "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Select
                Else
                    MessageBox.Show("ID ou mot de passe incorrect.", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Erreur : " & ex.Message)
            Finally
                fermer_connection()
            End Try
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If String.IsNullOrWhiteSpace(TextBox1.Text) OrElse String.IsNullOrWhiteSpace(TextBox2.Text) Then
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Try
                ouvrir_connection()

                Cmd.CommandType = CommandType.Text
                Cmd.CommandText = sql
                ' Cmd.Connection = con
                Cmd.CommandText = "SELECT * FROM Ouvrier WHERE ID_ouvrier = @ID AND mot_de_passe = @MDP"
                Cmd.Parameters.Clear()
                Cmd.Parameters.AddWithValue("@ID", TextBox1.Text.Trim())
                Cmd.Parameters.AddWithValue("@MDP", TextBox2.Text.Trim())

                dr = Cmd.ExecuteReader()

                If dr.HasRows Then
                    dr.Read()
                    Dim grade As String = dr("Grade").ToString().ToLower()

                    Select Case grade
                        Case "caissier"
                            MessageBox.Show("Bienvenue, Caissier.")
                            Commande.Show()
                            Me.Hide()
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                        Case "administration"
                            MessageBox.Show("Bienvenue, Administration.")
                            Administration.Show()
                            Me.Hide()
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                        Case Else
                            MessageBox.Show("Vous n'avez pas les droits d'accès.", "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Select
                Else
                    MessageBox.Show("ID ou mot de passe incorrect.", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Erreur : " & ex.Message)
            Finally
                fermer_connection()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class