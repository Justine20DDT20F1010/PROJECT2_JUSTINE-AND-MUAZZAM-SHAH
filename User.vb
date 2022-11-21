'Project 2 DFP40223 Visual Basic Programming

' Name : Justine Nanggai
' No Matrik : 20DDT20F1010
' Class : DDT5A

' Name : Muazzam Shah 
' No Matrik :  20DDT19F1802
' Class : DDT6A

Imports System.Data.SqlClient

Public Class User
    Dim con = New SqlConnection("Data Source=DESKTOP-D46HQFR;Initial Catalog=JMSystem;User=sa;Password=P@ssw0rd")
    Dim UserData As New DataTable

    Private Sub LoadDataInGrid()
        Dim command As New SqlCommand("select * from UserData ", con)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        DataGridView1.DataSource = dt
    End Sub


    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'JMSystemDataSet2.UserData' table. You can move, or remove it, as needed.
        Me.UserDataTableAdapter.Fill(Me.JMSystemDataSet2.UserData)

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim insertquery As String = "insert into UserData(Id,Username,Password) values ('" & txtUser.Text & "','" & txtUsername.Text & "',
'" & txtPassword.Text & "') "
        Dim cmd As New SqlCommand(insertquery, con)
        'connection open
        con.Open()
        cmd.ExecuteNonQuery()
        'connection close
        con.Close()
        'messagges box
        MsgBox("User insert")
        LoadDataInGrid()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ' if form not complete
        If (txtUser.Text = "") Then
            MsgBox("Please enter the user ID")
        Else
            Dim deletequery As String = "update UserData set Username ='" & txtUsername.Text & "',
Password ='" & txtPassword.Text & "' where id='" & txtUser.Text & "'"
            Dim cmd As New SqlCommand(deletequery, con)
            'connection open
            con.Open()
            cmd.ExecuteNonQuery()
            'connection close
            con.Close()
            'messagges box
            MsgBox("Congrats, data berjaya kemaskini")
            LoadDataInGrid()
        End If
    End Sub

    Private Sub Clear()
        'clear the textbox
        txtUser.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' if user not complete the form
        If (txtUser.Text = "") Then
            MsgBox("Please enter the user ID")
        Else
            'connection open
            con.open()
            'remove user based on the userdata id
            Dim command As New SqlCommand("delete UserData where id= '" & txtUser.Text & "'", con)
            command.ExecuteNonQuery()
            'messagges box
            MsgBox("Successfully Remove User")
            'connection close
            con.close()
            LoadDataInGrid()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'if the textbox not complete
        If txtUser.Text = "" Then
            'messagess box appear
            MsgBox("Please insert User ID")
            Exit Sub
        End If
        'search the user based on their id
        Dim searchquery As String = "select * from UserData where id='" & txtUser.Text & "'"
        Dim cmd As New SqlCommand(searchquery, con)
        Dim ta As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        ta.Fill(table)

        If table.Rows.Count > 0 Then
            txtUser.Text = table.Rows(0)(0).ToString
            txtUsername.Text = table.Rows(0)(1).ToString
            txtPassword.Text = table.Rows(0)(2).ToString
        Else
            MsgBox("No product found ")
        End If
        LoadDataInGrid()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Homevb.Show()
        Me.Close()

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'save dialog
        SaveFileDialog1.ShowDialog()
    End Sub
End Class