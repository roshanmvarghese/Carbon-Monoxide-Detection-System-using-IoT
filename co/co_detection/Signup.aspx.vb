Imports System.Data.SqlClient
Imports System.Data
Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim co As test = New test

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not Me.IsPostBack Then
            bindState()
            bindgrid()

        End If
        If Not Me.IsPostBack Then

            binddistrict()

        End If
        
    End Sub

    Protected Sub BTC1_Click(sender As Object, e As EventArgs) Handles BTC1.Click
        Dim Instr As String
        Instr = " Insert into user_signup( first_name,last_name,state_id,district_id,phone,email,pass,cpass) Values('" + txtfname.Text + "','" + txtlname.Text + "'," + ddlstate.SelectedValue + "," + ddldistrict.SelectedValue + ",'" + txtphone.Text + "', '" + txtemail.Text + "','" + txtpass.Text + "','" + txtcpass.Text + "')"
        Dim cmpComplaint As SqlCommand = New SqlCommand(Instr, co.connect())
        cmpComplaint.ExecuteNonQuery()
        Response.Write("<script>alert('Data saved successfully');</script>")
        txtfname.Text = " "
        txtlname.Text = " "
        txtphone.Text = " "
        txtemail.Text = " "
        txtpass.Text = " "
        txtcpass.Text = " "
        bindgrid()
    End Sub
    Public Sub bindState()
        Dim str As String
        str = "select state_id,state_name from state"
        Dim com As SqlCommand = New SqlCommand(str, co.connect())
        Dim sqlda As SqlDataAdapter = New SqlDataAdapter(com)
        Dim ds1 As DataTable = New DataTable
        sqlda.Fill(ds1)
        ddlstate.Items.Clear()
        ddlstate.Items.Add("--Select--")
        ddlstate.DataTextField = "state_name"
        ddlstate.DataValueField = "state_id"
        ddlstate.DataSource = ds1
        ddlstate.DataBind()

    End Sub
    Public Sub bindDistrict()
        Dim str As String
        str = "select district_id,state_id,district_name from district where state_id ='" & ddlstate.SelectedValue & "'"
        Dim comn As SqlCommand = New SqlCommand(str, co.connect())
        Dim sqlda As SqlDataAdapter = New SqlDataAdapter(comn)
        Dim ds2 As DataTable = New DataTable
        sqlda.Fill(ds2)
        ddldistrict.Items.Clear()
        ddldistrict.Items.Add("--Select--")
        ddldistrict.DataTextField = "district_name"
        ddldistrict.DataValueField = "district_id"
        ddldistrict.DataSource = ds2
        ddldistrict.DataBind()

    End Sub
 


    Protected Sub ddldistrict_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddldistrict.SelectedIndexChanged

    End Sub

   
    Protected Sub ddlstate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlstate.SelectedIndexChanged
        bindDistrict()
    End Sub
    Public Sub bindgrid()

        Dim ap As DataTable = New DataTable
        Dim str As String
        str = "select first_name,last_name,state_id,district_id,phone,email,pass,cpass from user_signup"
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






