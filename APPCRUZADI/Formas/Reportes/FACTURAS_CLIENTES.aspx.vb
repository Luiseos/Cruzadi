Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.Configuration
Public Class FACTURAS_CLIENTES
    Inherits System.Web.UI.Page
    Private Function GetData(ByVal CLIENTE As Integer) As DataTable
        Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS01", "cruzadi")
        ' Try
        Dim dt As DataTable = New DataTable()
        Dim cmd As SqlCommand = New SqlCommand("FACTURAS_GESTIONES", Conexion.conn)
        Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@CLIENTE", SqlDbType.Int).Value = CLIENTE


        adp.Fill(dt)

        Return dt
        'Catch ex As Exception
        '    mytrans("R")
        '    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al insertar');</script>")

        'End Try

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnshow_Click(sender As Object, e As EventArgs) Handles btnshow.Click
        ' Try
        rptfactura_cliente.Reset()

        Dim dt As DataTable
        Dim rds As ReportDataSource
        dt = GetData(Integer.Parse(txtcliente.Text))
        rds = New ReportDataSource("DataSetCLIENTE", dt)
        rptfactura_cliente.LocalReport.DataSources.Add(rds)
        rptfactura_cliente.LocalReport.ReportPath = "FACTURAS CLIENTES.rdlc"

        Dim rptParams As ReportParameter = New ReportParameter("CLIENTE", txtcliente.Text)
        rptfactura_cliente.LocalReport.SetParameters(rptParams)


        rptfactura_cliente.LocalReport.Refresh()

        'Catch ex As Exception
        '    mytrans("R")
        '    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al insertar');</script>")
        'End Try

    End Sub
End Class