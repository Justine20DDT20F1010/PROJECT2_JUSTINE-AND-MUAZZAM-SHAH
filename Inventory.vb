'Project 2 DFP40223 Visual Basic Programming

' Name : Justine Nanggai
' No Matrik : 20DDT20F1010
' Class : DDT5A

' Name : Muazzam Shah 
' No Matrik :  20DDT19F1802
' Class : DDT6A

Imports System.Data.SqlClient

Public Class Inventory
    Dim con = New SqlConnection("Data Source=DESKTOP-D46HQFR;Initial Catalog=JMSystem;User=sa;Password=P@ssw0rd")
    Dim Inventory As New DataTable

    Sub Refresh_Form()
        'TODO: This line of code loads data into the 'BundleClothingDBDataSet.Inventory' table. You can move, or remove it, as needed.
        Me.InventoryTableAdapter.Fill(Me.JMSystemDataSet1.Inventory)
        Inventory.Clear()
        Dim searchquery As String = "select * from Inventory"
        Dim cmd As New SqlCommand(searchquery, con)
        Dim ta As New SqlDataAdapter(cmd)
        ta.Fill(Inventory)

    End Sub
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Refresh_Form()
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'if user not insert a data
        If (txt_no.Text = "" Or txtaddress.Text = "" Or txt_weight.Text = "" Or txtquantity.Text = "" Or
            Cbx_Catogories.SelectedItem = "" Or DateTimePicker1.Text = "") Then
            MsgBox("Please insert the data!")
        Else
            Dim i As Integer
            Dim duplicate As Boolean = False
            While (i < Inventory.Rows.Count)
                If (Inventory.Rows(i)(0) = txt_no.Text) Then
                    duplicate = True
                End If
                i += 1
            End While
            If (duplicate = True) Then
                MsgBox("This product ID already exist!")
            Else
                Dim insertquery As String = "insert into Inventory(NoTracking, Address, Weight, Quantity, Category, DateReceive) values ('" & txt_no.Text & "' , '" & txtaddress.Text & "' , '" & txt_weight.Text & "','" & Val(txtquantity.Text) & "','" & Cbx_Catogories.SelectedItem & "','" & DateTimePicker1.Text & "')"
                Dim cmd As New SqlCommand(insertquery, con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Refresh_Form()
                MsgBox("New record added successfully!")
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'clear textbox
        txt_weight.Clear()
        txt_no.Clear()
        txtaddress.Clear()
        txtquantity.Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'delete record
        Dim NoTracking As String = InputBox("Please enter the NoTracking of the product")
        Dim i As Integer
        While (i < Inventory.Rows.Count)
            If (Inventory.Rows(i)(0) = NoTracking) Then
                Exit While
            End If
            i += 1
        End While
        If (i = Inventory.Rows.Count) Then
            MsgBox("Incorrect product ID!")
        Else
            Dim deletquery As String = "delete from Inventory where NoTracking ='" & txt_no.Text & "' "
            Dim cmd As New SqlCommand(deletquery, con)
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
            Refresh_Form()
            MsgBox("Selected record deleted successfully!")
        End If



    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim NoTracking As String = InputBox("Please enter the NoTracking of the product")
        Dim i As Integer
        If (txt_no.Text = "" Or txtaddress.Text = "" Or txt_weight.Text = "" Or txtquantity.Text = "" Or
            Cbx_Catogories.SelectedItem = "" Or DateTimePicker1.Text = "") Then
            MsgBox("Please insert the data!")
        Else
            While (i < Inventory.Rows.Count)
                If (Inventory.Rows(i)(0) = NoTracking) Then
                    Exit While
                End If
                i += 1
            End While
            If (i = Inventory.Rows.Count) Then
                MsgBox("Incorrect No Tracking!")
            Else
                Dim updatequery As String = "update Inventory set Address='" & txtaddress.Text & "', Weight='" & Val(txt_weight.Text) & "', Quantity='" & Val(txtquantity.Text) & "', Category='" & Cbx_Catogories.SelectedItem & "' where NoTracking= '" & txt_no.Text & "'"
                Dim cmd As New SqlCommand(updatequery, con)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
                Refresh_Form()
                MsgBox("Selected record updated successfully!")
            End If

        End If

        Me.InventoryTableAdapter.Fill(Me.JMSystemDataSet1.Inventory)
        Dim bs As New BindingSource
        bs.DataSource = JMSystemDataSet1.Tables(0).DefaultView
        DataGridView1.DataSource = bs
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'user search based on no tracking
        If txt_no.Text = "" Then
            MsgBox("Please insert No Tracking")
            Exit Sub
        End If

        Dim searchquery As String = "select * from Inventory where NoTracking='" & txt_no.Text & "'"
        Dim cmd As New SqlCommand(searchquery, con)
        Dim ta As New SqlDataAdapter(cmd)
        Dim table As New DataTable
        ta.Fill(table)

        If table.Rows.Count > 0 Then
            txtaddress.Text = table.Rows(0)(1).ToString
            txt_weight.Text = table.Rows(0)(2).ToString
            txtquantity.Text = table.Rows(0)(3).ToString
            Cbx_Catogories.SelectedItem = table.Rows(0)(4).ToString
            DateTimePicker1.Text = table.Rows(0)(5).ToString

        Else
            MsgBox("No product found ")
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Homevb.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        SaveFileDialog1.ShowDialog()
    End Sub
End Class
