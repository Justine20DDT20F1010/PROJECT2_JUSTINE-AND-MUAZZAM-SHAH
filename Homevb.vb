'Project 2 DFP40223 Visual Basic Programming

' Name : Justine Nanggai
' No Matrik : 20DDT20F1010
' Class : DDT5A

' Name : Muazzam Shah 
' No Matrik :  20DDT19F1802
' Class : DDT6A

Public Class Homevb
    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        User.Show()
        Me.Close()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        Inventory.Show()
        Me.Close()

    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        SplashScreen1.Show()

    End Sub
End Class