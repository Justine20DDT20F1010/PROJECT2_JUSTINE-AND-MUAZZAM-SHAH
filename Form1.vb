'Project 2 DFP40223 Visual Basic Programming

' Name : Justine Nanggai
' No Matrik : 20DDT20F1010
' Class : DDT5A

' Name : Muazzam Shah 
' No Matrik :  20DDT19F1802
' Class : DDT6A

' import sql
Imports System.Data.SqlClient

Public Class Login
    Public Conn As SqlConnection
    Public sql As String
    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dt As DataTable
    Public dr As SqlDataReader
    Public security As String

    Sub ConnectDatabase()
        'using try and catch
        Try
            Conn = New SqlConnection
            Conn.ConnectionString = "Data Source=DESKTOP-D46HQFR;Initial Catalog=JMSystem;User=sa;Password=P@ssw0rd"
            Conn.Open()
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
    Sub LoginSystem()
        ' if user do not complete the form 
        If txtUsername.Text = "" Then
            'this messaggesbox will appear
            MsgBox("user name is required!", MsgBoxStyle.Critical)
            txtUsername.Focus()
            Me.Close()
            'else if the password not match this messagges box will appear
        ElseIf txtPassword.Text = "" Then
            MsgBox("password is required!", MsgBoxStyle.Critical)
            txtPassword.Focus()
            Me.Close()

        Else
            'using try and catch
            Try
                ConnectDatabase()
                sql = "Select * From UserData where username =@username and password= @password"
                cmd = New SqlCommand
                With cmd
                    .Connection = Conn
                    .CommandText = sql
                    .Parameters.AddWithValue("@username", txtUsername.Text)
                    .Parameters.AddWithValue("@password", txtPassword.Text)
                End With

                da = New SqlDataAdapter
                dt = New DataTable
                da.SelectCommand = cmd
                da.Fill(dt)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Conn.Close()
                da.Dispose()
                If dt.Rows.Count > 0 Then
                    Dim username, password As String
                    username = dt.Rows(0).Item("Username")
                    password = dt.Rows(0).Item("Password")
                    'if the username and password match
                    If txtUsername.Text = username And txtPassword.Text = password Then
                        MsgBox("Welcome" & txtUsername.Text)
                        Homevb.Show()
                        'if the username is not match
                    ElseIf txtUsername.Text <> username Then
                        MsgBox("No user found", MsgBoxStyle.Critical)

                        ' if the txtpassword is not macth
                    ElseIf txtPassword.Text <> password Then
                        MsgBox("password doesn't match", MsgBoxStyle.Critical)

                        ' if the username adn password not macth
                    Else
                        MsgBox("Username and password is invalid", MsgBoxStyle.Critical)

                    End If
                End If
            End Try
        End If
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        LoginSystem()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub
End Class
