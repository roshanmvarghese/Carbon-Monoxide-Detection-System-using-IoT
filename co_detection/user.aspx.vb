

Public Class user
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub fname_TextChanged(sender As Object, e As EventArgs) Handles fname.TextChanged
        If fname.Text = "" Then
            fname.Text = "First Name"

        End If
    End Sub
End Class