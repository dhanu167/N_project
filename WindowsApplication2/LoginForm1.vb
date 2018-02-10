Public Class LoginForm1
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = My.Settings.Username And PasswordTextBox.Text = My.Settings.Password Then
            Form6.Show()
            Form6.Label2.Text = "Welcome admin"
        Else
            MsgBox("Username or Password incorrect")
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
