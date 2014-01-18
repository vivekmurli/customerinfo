Public Class Form1

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a, b, c As Integer
        a = TextBox1.Text
        b = TextBox2.Text
        c = a + b
        TextBox3.Text = c
    End Sub
End Class
