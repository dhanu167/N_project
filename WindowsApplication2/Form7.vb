Imports MySql.Data.MySqlClient
Module concrud
    'setting up your connection
    Public Function mysqlconnection() As MySqlConnection
        Return New MySqlConnection("server=localhost;user id=root;database=new_client_info")
    End Function
    Public con As MySqlConnection = MySqlConnection()
End Module


Public Class Form7
    Public result As String

    ''declaring the class 
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public Sub create(ByVal sql As String)

        Try
            'open the connection
            con.Open()
            'holds the data 
            With cmd
                .Connection = con
                .CommandText = sql

                'execute the data
                result = cmd.ExecuteNonQuery

                If result = 0 Then
                    MsgBox("no data save", MsgBoxStyle.Information)
                Else
                    MsgBox("data save to the database")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form6.Show()
       Try
            create("INSERT INTO Client_info (`Client_name`, `Registered_name`, `Phone_no`, `Email_Id`, `D.O.B`, `Date_joining`, `Client_Id`,'Dop','due','amt','payment') VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox6.Text & "','" & TextBox5.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "','" & TextBox7.Text & "','" & DateTimePicker3.Text & "','" & DateTimePicker4.Text & "','" & TextBox8.Text & "','" & ComboBox1.Text & "')")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class