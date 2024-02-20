Imports System.Data.SqlClient
Imports System.Data
Public Class District
    Inherits System.Web.UI.Page
    Dim co As test = New test
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Not Me.IsPostBack Then
            state()
            bindgrid()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim instr As String
        instr = "Insert INTO district(district_name,state_id) Values('" + txtdist.Text + "'," + ddistst.SelectedValue + ")"
        Dim cmdo As SqlCommand = New SqlCommand(instr, co.connect)
        cmdo.ExecuteNonQuery()
        Response.Write("<script>alert('data saved');</script>")

    End Sub
    Public Sub state()
        Dim str As String
        str = "select state_id,state_name from state"
        Dim com As SqlCommand = New SqlCommand(str, co.connect)
        Dim sqlda As SqlDataAdapter = New SqlDataAdapter(com)
        Dim ds1 As DataTable = New DataTable
        sqlda.Fill(ds1)
        ddistst.Items.Clear()
        ddistst.Items.Add("--Select--")
        ddistst.DataTextField = "state_name"
        ddistst.DataValueField = "state_id"
        ddistst.DataSource = ds1
        ddistst.DataBind()
    End Sub

    Protected Sub ddistst_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddistst.SelectedIndexChanged

    End Sub

    Protected Sub txtdist_TextChanged(sender As Object, e As EventArgs) Handles txtdist.TextChanged

    End Sub
    Public Sub bindgrid()

        Dim ap As DataTable = New DataTable
        Dim str As String
        str = "select district_name,state_id from district"
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
End Class


