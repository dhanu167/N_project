
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class Form2
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim con As MySqlConnection = jokenconn()
    Public Function jokenconn() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;password=;database=new_client_info")
    End Function
  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        Dim publictable As New DataTable
        Try
            'check if the textbox is equal to nothing then it will display the message below!.
            If TextBox1.Text = "" And TextBox2.Text = "" Then
                MsgBox("Password or Username Incorrect!")

            Else
                sql = "select Username, Password from emp_login where Username ='" & TextBox2.Text & "' and Password = '" & TextBox1.Text & "'"
                'bind the connection and query
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                da.SelectCommand = cmd
                da.Fill(publictable)
                'check if theres a result by getting the count number of rows
                If publictable.Rows.Count > 0 Then
                    'check if the type of user is admin
                    MsgBox("Your loged in now")
                    Form6.Show()
                    Me.Hide()
                    Form6.Label2.Text = "Welcome " & TextBox2.Text & "."
                Else
                    MsgBox("Contact administrator to register!")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                End If

                da.Dispose()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        con.Clone()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Focus()

    End Sub
End Class