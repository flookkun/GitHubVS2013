Imports System.Data.SqlClient


Public Class Form1

    Public con As SqlConnection 'ตัวแปรเชื่อมต่อ DB
    Dim ds As DataSet
    Dim query As String
    Dim server As String
    Dim adepter As SqlDataAdapter
    Dim command As SqlCommand
    Dim swicth As Integer

    Dim nameC() As String = {"เลขที่เอกสาร", "วันที่สร้างเอกสาร", "วันที่ยืนยันเอกสาร", "สถานะเอกสาร", "สถานะเอกสารหน้าร้าน", "รายละเอียด", "รหัสพิเศษ"}

    Public status() As String = {"BeautyBuffet", "BeautyCottage", "BeautyMarket"}

    Private Sub showInlistView(ByVal data As DataTable, ByVal lvw As ListView)

        lvw.View = View.Details

        lvw.GridLines = True

        lvw.Columns.Clear()

        lvw.Items.Clear()


        Dim lvitm As New ListViewItem

        lvitm = ltv1.Items.Add(txtb1.Text)

        'วนเอาข้อมูลใส่
        For i As Integer = 1 To ds.Tables("doc_st_tr").Columns.Count - 1
            Dim idx As Integer = ltv1.Items.IndexOf(lvitm)
            ltv1.Items(idx).SubItems.Add(ds.Tables("doc_st_tr").Rows(0)(i).ToString)
        Next

        ''วน For ให้เปลี่ยนชื่อหัว Columns
        For a As Integer = 0 To ds.Tables("doc_st_tr").Columns.Count - 1
            lvw.Columns.Insert(a, nameC(a), width:=120)
        Next

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Form2.Show()
        Form2.PB1.Visible = False
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If txtb1.Text = "" Then
            MsgBox("ใส่เลขที่เอกสารก่อน !!!", 48)
        Else
            Try
                query = "select DOCNO,convert(varchar,DOCDATE,103),convert(varchar,DOCDATE_TR,103),DOCSTATUS,DOCSTATUS_TR,REMARK,GENCODE_IN " & _
                        "from doc_st_tr " & _
                        "where docno = @docno "
                ' & _ <<<<<< เชื่อมแถว
                command = New SqlCommand(query, con)
                command.Parameters.AddWithValue("docno",txtb1.text)
                adepter = New SqlDataAdapter(command)
                ds = New DataSet
                adepter.Fill(ds, "doc_st_tr")
                showInlistView(ds.Tables("doc_st_tr"), ltv1)

            Catch ex As Exception
                MsgBox("ไม่พบเลขที่เอกสาร", 48)
            End Try
        End If
    End Sub

    Private Sub txtb1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtb1.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBox2_Click(sender, e)
        End If

    End Sub

    Private Sub Form1_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Text = "Offline"
        swicth = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Offline" Then
            Button1.Text = "Online"
            swicth = 1
        ElseIf Button1.Text = "Online" Then
            Button1.Text = "Offline"
            swicth = 0
        End If
    End Sub

    Private Sub BeautyBuffetToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BeautyBuffetToolStripMenuItem.Click

        If swicth = 0 Then
            server = "Data Source=192.168.1.220;Initial Catalog=CMD-BX;Persist Security Info=True;User ID=sa;Password=0211"
        ElseIf swicth = 1 Then
            server = "Data Source=testmona.homeunix.com,1433;Initial Catalog=CMD-BX;Persist Security Info=True;User ID=sa;Password=0211"
        End If

        l1.Text = status(0)

        Try
            con = New SqlConnection
            con.ConnectionString = server
            con.Open()
            MsgBox("Connecting to Server.", 64)
            ' MsgBox(server)
        Catch ex As Exception
            MsgBox(ex.Message, 48)
        End Try
    End Sub

    Private Sub BeautyCottageToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BeautyCottageToolStripMenuItem.Click

        If swicth = 0 Then
            server = "Data Source=192.168.1.24,1833;Initial Catalog=CMD-BX;Persist Security Info=True;User ID=sa;Password=0211"
        ElseIf swicth = 1 Then
            server = "Data Source=5cosmeda.homeunix.com,1833;Initial Catalog=CMD-BX;Persist Security Info=True;User ID=sa;Password=0211"
        End If

        l1.Text = status(1)

        Try

            con = New SqlConnection
            con.ConnectionString = server
            con.Open()
            MsgBox("Connecting to Server.", 64)

        Catch ex As Exception
            MsgBox(ex.Message, 48)
        End Try
    End Sub

    Private Sub BeautyMarketToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles BeautyMarketToolStripMenuItem.Click

        If swicth = 0 Then
            server = "Data Source=192.168.1.53,1733;Initial Catalog=CMD-BX;Persist Security Info=True;User ID=sa;Password=0211"
        ElseIf swicth = 1 Then
            server = "Data Source=5cosmeda.homeunix.com,1733;Initial Catalog=CMD-BX;Persist Security Info=True;User ID=sa;Password=0211"
        End If

        l1.Text = status(2)

        Try

            con = New SqlConnection
            con.ConnectionString = server
            con.Open()
            MsgBox("Connecting to Server.", 64)

        Catch ex As Exception
            MsgBox(ex.Message, 48)
        End Try
    End Sub

End Class
