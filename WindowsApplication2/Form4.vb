Imports MySql.Data.MySqlClient
Public Class Form4
    ''declaring a string 
    Public result As String

    ''declaring the class 
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox6.Text = "" Then
            MsgBox("Fields cant be empty!", MsgBoxStyle.Information)
        End If
        If TextBox1.Text = My.Settings.Username And TextBox2.Text = My.Settings.Password And TextBox4.Text = TextBox6.Text Then
            My.Settings.Username = TextBox3.Text
            My.Settings.Password = TextBox4.Text
        Else
            MsgBox("Old username or password dont match! or new password dont match!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form2.Show()
    End Sub
End Class