Imports MySql.Data.MySqlClient


Public Class Form5
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()

        Try
            create("INSERT INTO `emp_login`(`name`, `email`, `designation`, `dob`, `doj`, `phno`, `Username`, `Password`) VALUES ('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox1.Text & "')")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class