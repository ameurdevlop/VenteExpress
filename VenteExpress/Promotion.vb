
Imports System
Imports System.Windows.Forms
Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types
Public Class Promotion
    ' Récupère tes informations Twilio depuis ton compte Twilio
    Private Const AccountSid As String = "ACc69bd2210ad207c0736d8dd1893e0ab4"
    Private Const AuthToken As String = "a469878460c94412177bb0e1edf356a5"
    Private Const TwilioPhoneNumber As String = "+14787807530"


    Private Const AccountSid1 As String = "AC95192c63d171a960e426fedb83006d20"
    Private Const AuthToken1 As String = "bcf71e7c03ca15c7bbaf534b633ba47d"
    Private Const TwilioPhoneNumber1 As String = "+14432918328"

    Private Sub Promotion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox4.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ouvrir_connection()

        sql = "INSERT INTO Promotion (ID_produit, DateFinPromotion, Taux) VALUES (@Second_name, @DateParam, @Name)"
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = sql
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@Second_name", TextBox3.Text.Trim())
        Cmd.Parameters.AddWithValue("@Name", TextBox4.Text)
        Dim selectedDate As Date = MonthCalendar1.SelectionStart

        Cmd.Parameters.AddWithValue("@DateParam", selectedDate)
        Cmd.ExecuteNonQuery()
        MessageBox.Show("Promotion ajouter avec success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        fermer_connection()
        Try
            Dim recipientPhoneNumber As String = "+216 99 673 646"

            Dim messageBody As String = " Chere client , nous somme heureux de vous informer que nous organisons une promotion dans des nouveaux produits ,.soyer les bienvenues"


            TwilioClient.Init(AccountSid, AuthToken)


            Dim message = MessageResource.Create(
                body:=messageBody,
                from:=New PhoneNumber(TwilioPhoneNumber),
                to:=New PhoneNumber(recipientPhoneNumber)
            )


            lblResponse.Text = "Message envoyé au clients " ' & recipientPhoneNumber
        Catch ex As Exception

            lblResponse.Text = "Erreur: " & ex.Message
        End Try

    End Sub
End Class