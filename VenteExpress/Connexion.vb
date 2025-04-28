Imports System.Data
Imports System.Data.SqlClient
Module Connexion
    Public conn As New SqlConnection
    Public Cmd As New SqlCommand
    Public dr As SqlDataReader
    Public sql As String
    Public Sub ouvrir_connection()
        conn.ConnectionString = "Data Source=DESKTOP-C880BVV\SQLEXPRESS02;Initial Catalog=VenteExpress;Integrated Security=True"
        Cmd.Connection = conn
        Try
            conn.Open()
            ' If conn.State = ConnectionState.Open Then
            '  MsgBox("Connection réussie", MsgBoxStyle.Information, "Status")
            'Else
            '   MsgBox("Connection echoué", MsgBoxStyle.Information, "Status")
            '   End If
        Catch ex As Exception
            MsgBox("Erreur de la connection est produit :" & ex.Message)
        End Try
    End Sub
    Public Sub fermer_connection()
        conn.Close()
    End Sub
End Module
