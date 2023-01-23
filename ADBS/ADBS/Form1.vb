Imports System.Data.SqlClient

Public Class Form1
    Dim cmd As SqlCommand
    Dim conn As SqlConnection
    Dim cnstr As String = "data source = MARNS; user = ADBS; password = 123; database = reserve"
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(999) As String



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ref As Integer

        Randomize()
        ref = Int((313773 * Rnd()) + 15)
        refnum.Text = Convert.ToString(ref)
        Call loadlist()

    End Sub

  
    Private Sub S1_Click(sender As Object, e As EventArgs) Handles S1.Click
        Seatnum.Text = S1.Text
    End Sub

    Private Sub rbtn_Click(sender As Object, e As EventArgs) Handles rbtn.Click

        Try
            conn = New SqlConnection(cnstr)
            conn.Open()
            Dim sql As String = "INSERT INTO reserve_tbl (reserve_id, seat_num, name, contact_num, status)values(@resid, @seatnum, @fname, @num, @stat)"
            cmd = New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("resid", refnum.Text)
            cmd.Parameters.AddWithValue("seatnum", Seatnum.Text)
            cmd.Parameters.AddWithValue("fname", TextBox1.Text)
            cmd.Parameters.AddWithValue("num", TextBox2.Text)
            cmd.Parameters.AddWithValue("stat", "RESERVED")


            Dim i As Integer = cmd.ExecuteNonQuery

            If i > 0 Then

                MsgBox("Seat Reserved")

            Else

                MsgBox("Reservation Failed")
            End If
        Catch ex As Exception
            MsgBox("Seat is already reserved. Please pick other seats", MsgBoxStyle.Critical)
        End Try
        Call loadlist()
        Call Cleardata()
        Dim ref As Integer

        Randomize()
        ref = Int((313773 * Rnd()) + 15)
        refnum.Text = Convert.ToString(ref)
        conn.Close()
    End Sub

    Private Sub S2_Click(sender As Object, e As EventArgs) Handles S2.Click
        Seatnum.Text = S2.Text
    End Sub

    Private Sub S3_Click(sender As Object, e As EventArgs) Handles S3.Click
        Seatnum.Text = S3.Text
    End Sub

    Private Sub S4_Click(sender As Object, e As EventArgs) Handles S4.Click
        Seatnum.Text = S4.Text
    End Sub

    Private Sub S5_Click(sender As Object, e As EventArgs) Handles S5.Click
        Seatnum.Text = S5.Text
    End Sub

    Private Sub S6_Click(sender As Object, e As EventArgs) Handles S6.Click
        Seatnum.Text = S6.Text
    End Sub

    Private Sub S7_Click(sender As Object, e As EventArgs) Handles S7.Click
        Seatnum.Text = S7.Text
    End Sub

    Private Sub S8_Click(sender As Object, e As EventArgs) Handles S8.Click
        Seatnum.Text = S8.Text
    End Sub

    Private Sub S9_Click(sender As Object, e As EventArgs) Handles S9.Click
        Seatnum.Text = S9.Text
    End Sub

    Private Sub S10_Click(sender As Object, e As EventArgs) Handles S10.Click
        Seatnum.Text = S10.Text
    End Sub

    Private Sub S11_Click(sender As Object, e As EventArgs) Handles S11.Click
        Seatnum.Text = S11.Text
    End Sub

    Private Sub S12_Click(sender As Object, e As EventArgs) Handles S12.Click
        Seatnum.Text = S12.Text
    End Sub

    Private Sub S13_Click(sender As Object, e As EventArgs) Handles S13.Click
        Seatnum.Text = S13.Text
    End Sub

    Private Sub S14_Click(sender As Object, e As EventArgs) Handles S14.Click
        Seatnum.Text = S14.Text
    End Sub

    Private Sub S15_Click(sender As Object, e As EventArgs) Handles S15.Click
        Seatnum.Text = S15.Text
    End Sub

    Private Sub S16_Click(sender As Object, e As EventArgs) Handles S16.Click
        Seatnum.Text = S16.Text
    End Sub

    Private Sub S17_Click(sender As Object, e As EventArgs) Handles S17.Click
        Seatnum.Text = S17.Text
    End Sub

    Private Sub S18_Click(sender As Object, e As EventArgs) Handles S18.Click
        Seatnum.Text = S18.Text
    End Sub

    Private Sub S19_Click(sender As Object, e As EventArgs) Handles S19.Click
        Seatnum.Text = S19.Text
    End Sub

    Private Sub S20_Click(sender As Object, e As EventArgs) Handles S20.Click
        Seatnum.Text = S20.Text
    End Sub

    Private Sub S21_Click(sender As Object, e As EventArgs) Handles S21.Click
        Seatnum.Text = S21.Text
    End Sub

    Private Sub S22_Click(sender As Object, e As EventArgs) Handles S22.Click
        Seatnum.Text = S22.Text
    End Sub

    Private Sub S23_Click(sender As Object, e As EventArgs) Handles S23.Click
        Seatnum.Text = S23.Text
    End Sub

    Private Sub S24_Click(sender As Object, e As EventArgs) Handles S24.Click
        Seatnum.Text = S24.Text
    End Sub

    Private Sub S25_Click(sender As Object, e As EventArgs) Handles S25.Click
        Seatnum.Text = S25.Text
    End Sub
    Public Sub loadlist()

        Try
            ListView1.Items.Clear()
            conn = New SqlConnection(cnstr)
            conn.Open()
            Dim sql As String = "select reserve_id, seat_num, name, contact_num, status  from reserve_tbl"
            cmd = New SqlCommand(sql, conn)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "tables")

            For r = 0 To ds.Tables(0).Rows.Count - 1

                For c = 0 To ds.Tables(0).Columns.Count - 1
                    itemcoll(c) = ds.Tables(0).Rows(r)(c).ToString

                Next
                Dim litems As New ListViewItem(itemcoll)
                ListView1.Items.Add(litems)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        conn.Close()

    End Sub
    Public Sub Cleardata()
        TextBox1.Clear()
        TextBox2.Clear()
        refnum.Clear()
        Seatnum.Clear()


    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            refnum.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(0).Text
            Seatnum.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(1).Text
            TextBox1.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(2).Text
            TextBox2.Text = ListView1.Items(ListView1.SelectedIndices(0)).SubItems(3).Text

        End If
    End Sub

    Private Sub ubtn_Click(sender As Object, e As EventArgs) Handles ubtn.Click

        Try
            conn = New SqlConnection(cnstr)
            conn.Open()
            Dim sql As String = "update reserve_tbl set seat_num = @seatnum, name = @fname, contact_num = @num, status = @stat where reserve_id = @resid "
            cmd = New SqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@resid", refnum.Text)
            cmd.Parameters.AddWithValue("@seatnum", Seatnum.Text)
            cmd.Parameters.AddWithValue("@fname", TextBox1.Text)
            cmd.Parameters.AddWithValue("@num", TextBox2.Text)
            cmd.Parameters.AddWithValue("@stat", "RESERVED")


            Dim i As Integer = cmd.ExecuteNonQuery

            If i > 0 Then

                MsgBox("Seat Reservation Updated")

            Else

                MsgBox("Update Failed")
            End If
        Catch ex As Exception
            MsgBox("Seat is already reserved. Please pick other seats")
        End Try
        Call loadlist()
        Call Cleardata()
        conn.Close()
    End Sub
   
    Private Sub sbtn_Click(sender As Object, e As EventArgs) Handles sbtn.Click
        conn.Open()
        Dim cmd As New SqlCommand("Select * From reserve_tbl Where name Like '' +@fname+ '%'", conn)
        cmd.Parameters.AddWithValue("fname", TextBox3.Text.Trim)
        Dim da As SqlDataReader = cmd.ExecuteReader
        ListView1.Items.Clear()

        Do While da.Read()
            Dim list1 = ListView1.Items.Add(da(0))
            list1.SubItems.Add(da(1))
            list1.SubItems.Add(da(2))
            list1.SubItems.Add(da(3))
            list1.SubItems.Add(da(4))
        Loop
        conn.Close()
    End Sub
End Class
