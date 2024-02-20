Imports System.Data.SqlClient
Imports System.Data
Public Class state
    Inherits System.Web.UI.Page
    Dim co As test = New test


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then

            bindgrid()

        End If

    End Sub

    Protected Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        Dim instr As String
        instr = "Insert INTO state(state_name) Values('" + txtstate.Text + "')"
        Dim cmdo As SqlCommand = New SqlCommand(instr, co.connect)
        cmdo.ExecuteNonQuery()
        Response.Write("<script>alert('data saved');</script>")
    End Sub

    Public Sub bindgrid()

        Dim ap As DataTable = New DataTable
        Dim str As String
        str = "select state_name from state"
        Dim cmd As SqlCommand = New SqlCommand(str, co.connect())
        Dim ad As SqlDataAdapter = New SqlDataAdapter(cmd)
        ad.Fill(ap)
        GridView1.DataSource = ap
        GridView1.DataBind()

    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        Me.bindgrid()
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class



