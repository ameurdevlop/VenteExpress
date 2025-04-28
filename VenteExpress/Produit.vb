Public Class Produit
    Private Sub Administration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResetControls()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Ajouter un Produit" Then

                If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) OrElse String.IsNullOrWhiteSpace(TextBox1.Text) Then
                    MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else

                    ouvrir_connection()
                    sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                    Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur ) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                        Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                        Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                        Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())
                        '  Cmd.Parameters.AddWithValue("@BR_COD", TextBox1.Text.Trim())
                        Cmd.Parameters.AddWithValue("@STK", stock.Text.Trim())
                        Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                        Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                        Cmd.Parameters.AddWithValue("@FEUR", fournisseur.Text.Trim())
                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    fermer_connection()
                End If
            End If
        End If





        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
            If selectedItem = "Supprimer un Produit" Then
                If String.IsNullOrWhiteSpace(id_prod.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        ' Correct use of parameterized query
                        sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            If selectedItem = "Rechercher un Produit" Then
                If String.IsNullOrWhiteSpace(id_prod.Text) Then
                    MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                    ouvrir_connection()

                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = sql
                    Cmd.Parameters.Clear()
                    Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                    dr = Cmd.ExecuteReader()

                    If dr.HasRows Then
                        MessageBox.Show(" Produit existe .")
                        dr.Read()
                        id_prod.Text = dr.Item("ID_produit").ToString()
                        designation.Text = dr.Item("Désignation").ToString()
                        quantité.Text = dr.Item("Quantite").ToString()
                        Code.Text = dr.Item("Code").ToString()
                        Prix.Text = dr.Item("Prix").ToString()
                        Stock.Text = dr.Item("Etat stock").ToString()
                        Type.Text = dr.Item("Type").ToString()
                        DEpot.Text = dr.Item("No_dépot").ToString()
                        Four.Text = dr.Item("ID_fournisseur").ToString()

                    Else
                        MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    fermer_connection()
                End If
            End If
        End If





        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Modifier un Produit" Then
                If String.IsNullOrWhiteSpace(id_prod.Text) Then
                    MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Try
                        ouvrir_connection()

                        Dim updates As New List(Of String)()
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                        ' Build SET clause only for non-empty fields

                        If Not String.IsNullOrWhiteSpace(designation.Text) Then
                            updates.Add("Désignation = @DES")
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                            updates.Add("Quantite = @QTE")
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                        End If
                        If Not String.IsNullOrWhiteSpace(Code.Text) Then
                            updates.Add("Code = @COD")
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                        End If
                        If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                            updates.Add("Prix = @PRX")
                            Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                            updates.Add("Etat stock = @STK")
                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(Type.Text) Then
                            updates.Add("Type = @TYP")
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                        End If

                        If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                            updates.Add("No_dépot = @DEP")
                            Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                        End If


                        If Not String.IsNullOrWhiteSpace(Four.Text) Then
                            updates.Add("ID_fournisseur = @FOR")
                            Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                        End If

                        ' Check if there is at least one field to update
                        If updates.Count = 0 Then
                            MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If

                        sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                        Cmd.CommandText = sql
                        Cmd.CommandType = CommandType.Text

                        Cmd.ExecuteNonQuery()
                        MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        fermer_connection()
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        id_prod.Focus()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        designation.Focus()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        quantité.Focus()
    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click
        Code.Focus()
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Prix.Focus()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        stock.Focus()
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Type.Focus()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        DEpot.Focus()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Four.Focus()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        id_prod.Text = ""
        quantité.Text = ""
        designation.Text = ""
        Code.Text = ""
        Prix.Text = ""
        Four.Text = ""
        DEpot.Text = ""
        Type.Text = ""
        stock.Text = ""
        fournisseur.Text = ""


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ResetControls()

        Select Case ComboBox1.SelectedItem.ToString()
            Case "Ajouter un Produit"
                ' Créer une liste pour regrouper les contrôles à rendre visibles et activés
                Dim visiblesEtActives As Control() = {id_prod, quantité, designation, Code, Prix, Type, Stock, Four,
                                                      Label1, Label4, Label5, Label6, Label10, Label11, Label12,
                                                      Label13, Label14, Label15}

                ' Rendre visibles et activer les contrôles listés
                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next
                id_prod.Text = ""
                quantité.Text = ""
                designation.Text = ""
                Code.Text = ""
                Prix.Text = ""
                Four.Text = ""
                DEpot.Text = ""
                Type.Text = ""
                Stock.Text = ""
                Fournisseur.Text = ""
            Case "Supprimer un Produit"
                ' Créer deux listes pour regrouper les contrôles selon leurs états
                Dim visiblesEtActives As Control() = {id_prod, Label1, Label4, Label5, Label6, Label10, Label11, Label12, Label13, Label14, Label15}
                Dim visiblesEtInactives As Control() = {quantité, designation, Code, Prix, Type, Stock, Four}

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
                id_prod.Text = ""
                quantité.Text = ""
                designation.Text = ""
                Code.Text = ""
                Prix.Text = ""
                Four.Text = ""
                DEpot.Text = ""
                Type.Text = ""
                Stock.Text = ""
                Fournisseur.Text = ""

            Case "Rechercher un Produit"
                ' Créer deux listes pour regrouper les contrôles selon leurs états
                Dim visiblesEtActives As Control() = {id_prod, Label1, Label4, Label5, Label6, Label10, Label11, Label12,
                                       Label13, Label14, Label15}

                Dim visiblesEtInactives As Control() = {quantité, designation, Code, Prix, DEpot, Type, Stock, Four}

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
                id_prod.Text = ""
                quantité.Text = ""
                designation.Text = ""
                Code.Text = ""
                Prix.Text = ""
                Four.Text = ""
                DEpot.Text = ""
                Type.Text = ""
                Stock.Text = ""
                Fournisseur.Text = ""

            Case "Modifier un Produit"
                id_prod.Text = ""
                quantité.Text = ""
                designation.Text = ""
                Code.Text = ""
                Prix.Text = ""
                Four.Text = ""
                DEpot.Text = ""
                Type.Text = ""
                Stock.Text = ""
                Fournisseur.Text = ""
                ' Créer une liste pour regrouper les contrôles à rendre visibles et activés
                Dim visiblesEtActives As Control() = {id_prod, quantité, designation, Code, Prix, Type, Stock, Four,
                                                      Label1, Label4, Label5, Label6, Label10, Label11, Label12,
                                                      Label13, Label14, Label15}

                ' Rendre visibles et activer les contrôles listés
                For Each ctrl In visiblesEtActives
                    ctrl.Visible = True
                    ctrl.Enabled = True
                Next
            Case Else
                ' Gérer les autres cas ou aucune sélection
                ResetControls()
        End Select
    End Sub

    Private Sub ResetControls()
        id_prod.Visible = False
        id_prod.Enabled = False
        quantité.Visible = False
        quantité.Enabled = False
        designation.Visible = False
        designation.Enabled = False
        Code.Visible = False
        Code.Enabled = False
        Prix.Visible = False
        Prix.Enabled = False
        DEpot.Visible = False
        DEpot.Enabled = False
        Four.Visible = False
        Four.Enabled = False
        Type.Visible = False
        Type.Enabled = False
        stock.Visible = False
        stock.Enabled = False
        fournisseur.Visible = False
        fournisseur.Enabled = False
        Label1.Visible = True
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label15.Visible = False
    End Sub

    Private Sub Stock_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Stock.SelectedIndexChanged

    End Sub

    Private Sub id_prod_TextChanged(sender As Object, e As EventArgs) Handles id_prod.TextChanged

    End Sub

    Private Sub id_prod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles id_prod.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub designation_TextChanged(sender As Object, e As EventArgs) Handles designation.TextChanged

    End Sub

    Private Sub designation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles designation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub quantité_TextChanged(sender As Object, e As EventArgs) Handles quantité.TextChanged

    End Sub

    Private Sub quantité_KeyPress(sender As Object, e As KeyPressEventArgs) Handles quantité.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Code_TextChanged(sender As Object, e As EventArgs) Handles Code.TextChanged

    End Sub

    Private Sub Code_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Code.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Prix_TextChanged(sender As Object, e As EventArgs) Handles Prix.TextChanged

    End Sub

    Private Sub Prix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Prix.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Stock_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Stock.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Type.SelectedIndexChanged

    End Sub

    Private Sub Type_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Type.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub DEpot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DEpot.SelectedIndexChanged

    End Sub

    Private Sub DEpot_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DEpot.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub Four_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Four.SelectedIndexChanged

    End Sub

    Private Sub Four_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Four.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Ajouter un Produit" Then

                    If String.IsNullOrWhiteSpace(id_prod.Text) OrElse String.IsNullOrWhiteSpace(designation.Text) OrElse String.IsNullOrWhiteSpace(quantité.Text) OrElse String.IsNullOrWhiteSpace(Code.Text) OrElse String.IsNullOrWhiteSpace(Prix.Text) OrElse String.IsNullOrWhiteSpace(Stock.Text) OrElse String.IsNullOrWhiteSpace(Type.Text) OrElse String.IsNullOrWhiteSpace(DEpot.Text) OrElse String.IsNullOrWhiteSpace(Fournisseur.Text) Then
                        MessageBox.Show(" entrer des valeurs dans les champs requis.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        ouvrir_connection()
                        sql = "SELECT COUNT(*) FROM Produit WHERE ID_produit = @ID_POD"
                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                        Dim count As Integer = Convert.ToInt32(Cmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Ce Produit est deja existant , choisisser un nouveau ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            sql = "INSERT INTO Produit (ID_produit, Désignation, Quantite, Code, Prix, [Etat stock], Type, No_dépot, ID_fournisseur) VALUES (@ID_POD, @DES, @QTE, @COD, @PR, @STK, @TYP, @NDEPT, @FEUR)"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                            Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            Cmd.Parameters.AddWithValue("@PR", Prix.Text.Trim())

                            Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            Cmd.Parameters.AddWithValue("@NDEPT", DEpot.Text.Trim())
                            Cmd.Parameters.AddWithValue("@FEUR", Fournisseur.Text.Trim())
                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()
                If selectedItem = "Supprimer un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            ' Correct use of parameterized query
                            sql = "DELETE FROM Produit WHERE ID_produit = @ID_POD"
                            Cmd.CommandType = CommandType.Text
                            Cmd.CommandText = sql
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())

                            Dim rowsAffected As Integer = Cmd.ExecuteNonQuery()

                            If rowsAffected > 0 Then
                                MessageBox.Show(" Produit supprimer avec success .", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Le Produit n'est pas trouvé, verifier l'ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

                If selectedItem = "Rechercher un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("entrer des valeurs dans les champs requis..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sql = "SELECT * FROM Produit WHERE ID_produit = @ID_POD"
                        ouvrir_connection()

                        Cmd.CommandType = CommandType.Text
                        Cmd.CommandText = sql
                        Cmd.Parameters.Clear()
                        Cmd.Parameters.AddWithValue("@ID_POD", id_prod.Text.Trim())
                        dr = Cmd.ExecuteReader()

                        If dr.HasRows Then
                            MessageBox.Show(" Produit existe .")
                            dr.Read()
                            id_prod.Text = dr.Item("ID_produit").ToString()
                            designation.Text = dr.Item("Désignation").ToString()
                            quantité.Text = dr.Item("Quantite").ToString()
                            Code.Text = dr.Item("Code").ToString()
                            Prix.Text = dr.Item("Prix").ToString()
                            Stock.Text = dr.Item("Etat stock").ToString()
                            Type.Text = dr.Item("Type").ToString()
                            DEpot.Text = dr.Item("No_dépot").ToString()
                            Four.Text = dr.Item("ID_fournisseur").ToString()

                        Else
                            MessageBox.Show("aucun résultat trouver avec cet ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        fermer_connection()
                    End If
                End If
            End If





            If ComboBox1.SelectedItem IsNot Nothing Then
                Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

                If selectedItem = "Modifier un Produit" Then
                    If String.IsNullOrWhiteSpace(id_prod.Text) Then
                        MessageBox.Show("Entrer l'ID de produit...", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Try
                            ouvrir_connection()

                            Dim updates As New List(Of String)()
                            Cmd.Parameters.Clear()
                            Cmd.Parameters.AddWithValue("@PROD", id_prod.Text.Trim())

                            ' Build SET clause only for non-empty fields

                            If Not String.IsNullOrWhiteSpace(designation.Text) Then
                                updates.Add("Désignation = @DES")
                                Cmd.Parameters.AddWithValue("@DES", designation.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(quantité.Text) Then
                                updates.Add("Quantite = @QTE")
                                Cmd.Parameters.AddWithValue("@QTE", quantité.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Code.Text) Then
                                updates.Add("Code = @COD")
                                Cmd.Parameters.AddWithValue("@COD", Code.Text.Trim())
                            End If
                            If Not String.IsNullOrWhiteSpace(Prix.Text) Then
                                updates.Add("Prix = @PRX")
                                Cmd.Parameters.AddWithValue("@PRX", Prix.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Stock.Text) Then
                                updates.Add("Etat stock = @STK")
                                Cmd.Parameters.AddWithValue("@STK", Stock.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(Type.Text) Then
                                updates.Add("Type = @TYP")
                                Cmd.Parameters.AddWithValue("@TYP", Type.Text.Trim())
                            End If

                            If Not String.IsNullOrWhiteSpace(DEpot.Text) Then
                                updates.Add("No_dépot = @DEP")
                                Cmd.Parameters.AddWithValue("@DEP", DEpot.Text.Trim())
                            End If


                            If Not String.IsNullOrWhiteSpace(Four.Text) Then
                                updates.Add("ID_fournisseur = @FOR")
                                Cmd.Parameters.AddWithValue("@FOR", Four.Text.Trim())
                            End If

                            ' Check if there is at least one field to update
                            If updates.Count = 0 Then
                                MessageBox.Show("Please fill in at least one field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If

                            sql = "UPDATE Produit SET " & String.Join(", ", updates) & " WHERE ID_produit = @PROD"
                            Cmd.CommandText = sql
                            Cmd.CommandType = CommandType.Text

                            Cmd.ExecuteNonQuery()
                            MessageBox.Show("Produit modifier avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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