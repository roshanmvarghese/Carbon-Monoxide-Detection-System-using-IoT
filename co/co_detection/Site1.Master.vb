Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Menu2_MenuItemClick(sender As Object, e As MenuEventArgs) Handles Menu2.MenuItemClick
        Dim s As String
        s = Menu2.SelectedItem.Text
        If s = "Signup" Then
            Response.Redirect("Signup.aspx")

        ElseIf s = "State" Then
            Response.Redirect("State.aspx")
        ElseIf s = "District" Then
            Response.Redirect("District.aspx")

        End If
    End Sub
End Class