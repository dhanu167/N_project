Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class Form9
    Public result As String
    Public dt As New DataTable
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Public datardr As MySqlDataReader
    Dim con As MySqlConnection = jokenconn()
    Public Function jokenconn() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;password=;database=new_client_info")
    End Function

    Public Sub reload(ByVal sql As String)
        Try
            dt = New DataTable
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        da.Dispose()
    End Sub
    Public Sub updates(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("no updated data", MsgBoxStyle.Information)
                Else
                    MsgBox("data in the database has been updated")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub

    'deleting the data from the database
    Public Sub delete(ByVal sql As String)
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = sql

                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox("Error query for deleting a data.", MsgBoxStyle.Critical)
                Else
                    MsgBox("data in the database has been deleted")
                End If

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub




    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Hide()
        Label2.Hide()
        TextBox1.Hide()
        TextBox10.Hide()
        Button1.Hide()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form6.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sql As String
        Dim publictable As New DataTable
        Try
            'check if the textbox is equal to nothing then it will display the message below!.
            sql = "select * from client_info where Registered_name ='" & TextBox1.Text & "' or Client_Id = '" & TextBox2.Text & "'"
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

                datardr = cmd.ExecuteReader

                If datardr.HasRows Then
                    datardr.Read()
                    TextBox3.Text = datardr("Client_name")
                    TextBox2.Text = datardr("Registered_name")
                    DateTimePicker1.Text = datardr("Date_joining")
                    DateTimePicker2.Text = datardr("D.O.B")
                    TextBox5.Text = datardr("Email_Id")
                    TextBox6.Text = datardr("Phone_no")
                    TextBox7.Text = datardr("Client_Id")
                    DateTimePicker3.Text = datardr("Dop")
                    DateTimePicker4.Text = datardr("due")
                    TextBox8.Text = datardr("amt")
                    ComboBox2.Text = datardr("payment")
                End If

            End If

            da.Dispose()
             
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        con.Clone()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "Name" Then
            Label2.Show()
            TextBox1.Show()
            Button1.Show()

        End If
        If ComboBox1.Text = "Registered ID" Then
            Label1.Show()
            TextBox10.Show()
            Button1.Show()

        End If
    End Sub
End Class