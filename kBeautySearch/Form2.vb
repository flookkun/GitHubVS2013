Imports System.Data.SqlClient
Imports kBeautySearch.Form1
Public Class Form2

    Dim con2 As SqlConnection = Form1.con
    Dim command As SqlCommand
    Dim adapter As SqlDataAdapter
    Dim str As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If PB1.Visible = True Then PB1.Visible = False
            str = "EXEC MP_RL_2_CMD"
            command = New SqlCommand(str, con2)
            command.ExecuteNonQuery()
            MsgBox("OK!!", MsgBoxStyle.Information)
            PB1.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' ProgressBar1.MarqueeAnimationSpeed = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If PB1.Visible = True Then PB1.Visible = False
            str = "exec pp_import_to_2_csmile"
            command = New SqlCommand(str, con2)
            command.ExecuteNonQuery()
            'MsgBox(con2.ToString)
            MsgBox("OK!!", MsgBoxStyle.Information)
            PB1.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label1.Text = Form1.l1.Text
        ' ProgressBar1.Style = ProgressBarStyle.Marquee
        ' ProgressBar1.MarqueeAnimationSpeed = 50
    End Sub

End Class