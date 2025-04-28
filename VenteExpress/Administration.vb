Public Class Administration
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        Me.IsMdiContainer = True
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub
    Private currentChildForm As Form

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs)
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = "C:\Users\LENOVO\Downloads\test\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe" ' Ton projet .NET 8 compilé
        Process.Start(startInfo)
        Me.Close()
    End Sub

    Private Sub Administration_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Authentification.Show()
    End Sub

    Private Sub Administration_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.P Then
            Dim startInfo As New ProcessStartInfo()
            startInfo.FileName = "C:\Users\LENOVO\Downloads\test\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"
            Process.Start(startInfo)
            Me.Hide()
        End If

        If e.Shift AndAlso e.KeyCode = Keys.Down Then
            ComboBox1.DroppedDown = True
            e.Handled = True
        End If

        If e.Control AndAlso e.Shift AndAlso e.KeyCode = Keys.D Then
            Me.Hide()
            Auth.Show()
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        Auth.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
            currentChildForm = Nothing
        End If

        If ComboBox1.SelectedItem IsNot Nothing Then
            Dim selectedItem As String = ComboBox1.SelectedItem.ToString()

            If selectedItem = "Gestion des Clients" Then
                Dim frmChild As New Client()
                frmChild.MdiParent = Me
                frmChild.WindowState = FormWindowState.Maximized
                frmChild.Show()
                currentChildForm = frmChild
            ElseIf selectedItem = "Gestion des Produits" Then
                Dim frmChild As New Produit()
                frmChild.MdiParent = Me
                frmChild.WindowState = FormWindowState.Maximized
                frmChild.Show()
                currentChildForm = frmChild
            ElseIf selectedItem = "Gestion des Fournisseurs" Then
                Dim frmChild3 As New Fournisseur()
                frmChild3.MdiParent = Me
                frmChild3.WindowState = FormWindowState.Maximized
                frmChild3.Show()
                currentChildForm = frmChild3
            ElseIf selectedItem = "Gestion des Ouvriers" Then
                Dim frmChild4 As New Ouvrier()
                frmChild4.MdiParent = Me
                frmChild4.WindowState = FormWindowState.Maximized
                frmChild4.Show()
                currentChildForm = frmChild4
            ElseIf selectedItem = "Gestion des Congés" Then
                Dim frmChild5 As New Congé()
                frmChild5.MdiParent = Me
                frmChild5.WindowState = FormWindowState.Maximized
                frmChild5.Show()
                currentChildForm = frmChild5
            ElseIf selectedItem = "Gestion des Factures" Then
                Dim frmChild6 As New Facture()
                frmChild6.MdiParent = Me
                frmChild6.WindowState = FormWindowState.Maximized
                frmChild6.Show()
                currentChildForm = frmChild6
            ElseIf selectedItem = "Gestion des modes de payement" Then
                Dim frmChild7 As New Méthode_payement()
                frmChild7.MdiParent = Me
                frmChild7.WindowState = FormWindowState.Maximized
                frmChild7.Show()
                currentChildForm = frmChild7
            ElseIf selectedItem = "Gestion des Caisses" Then
                Dim frmChild8 As New Caisse()
                frmChild8.MdiParent = Me
                frmChild8.WindowState = FormWindowState.Maximized
                frmChild8.Show()
                currentChildForm = frmChild8
            ElseIf selectedItem = "Gestion des moyens de transports" Then
                Dim frmChild9 As New Moyen_de_Transport()
                frmChild9.MdiParent = Me
                frmChild9.WindowState = FormWindowState.Maximized
                frmChild9.Show()
                currentChildForm = frmChild9
            ElseIf selectedItem = "Gestion des retours" Then
                Dim frmChild10 As New Retour()
                frmChild10.MdiParent = Me
                frmChild10.WindowState = FormWindowState.Maximized
                frmChild10.Show()
                currentChildForm = frmChild10
            ElseIf selectedItem = "Gestion des Depôts" Then
                Dim frmChild11 As New Dépot()
                frmChild11.MdiParent = Me
                frmChild11.WindowState = FormWindowState.Maximized
                frmChild11.Show()
                currentChildForm = frmChild11
            ElseIf selectedItem = "Gestion des Promotions" Then
                Dim frmChild12 As New Promotion()
                frmChild12.MdiParent = Me
                frmChild12.WindowState = FormWindowState.Maximized
                frmChild12.Show()
                currentChildForm = frmChild12
            ElseIf selectedItem = "Gestion des Promotions" Then
                Dim startInfo As New ProcessStartInfo()
                startInfo.FileName = "C:\Users\LENOVO\Downloads\test\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"
                Process.Start(startInfo)
                Me.Hide()
            ElseIf selectedItem = "Analyse d'amélioration" Then
                Dim startInfo As New ProcessStartInfo()
                startInfo.FileName = "C:\Users\LENOVO\Downloads\dash\dashboard\dashboard\bin\Debug\net8.0-windows\dashboard.exe"
                Process.Start(startInfo)
                Me.Close()
            Else
                MsgBox("choix invalide ")
            End If
        End If

    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click
        Dim startInfo As New ProcessStartInfo()
        startInfo.FileName = "C:\Users\LENOVO\Downloads\test\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"
        Process.Start(startInfo)
        Me.Close()
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Auth.Show()
    End Sub
End Class