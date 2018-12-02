Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms
Imports System.Data
Imports System.Configuration
Public Class REPORTE_RPT
    Inherits System.Web.UI.Page

    Private Function GetData(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As DataTable
        Conexion.conectar("DESKTOP-BDNFVTG\WITTO", "cruzadi")
        ' Try
        Dim dt As DataTable = New DataTable()
        Dim cmd As SqlCommand = New SqlCommand("PAGOS_RPT", Conexion.conn)
        Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FECHA_INI", SqlDbType.DateTime).Value = FECHA_INI
        cmd.Parameters.Add("@FECHA_FIN", SqlDbType.DateTime).Value = FECHA_FIN

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
        Try
            rpt_pago.Reset()

            Dim dt As DataTable
            Dim rds As ReportDataSource
            dt = GetData(DateTime.Parse(txtfechaini.Text), DateTime.Parse(txtfechafin.Text))
            rds = New ReportDataSource("cruzadiDataSetpago", dt)
            rpt_pago.LocalReport.DataSources.Add(rds)
            rpt_pago.LocalReport.ReportPath = "PAGO REPORTE.rdlc"

            Dim rptParams As ReportParameter = New ReportParameter("FECHA_INI", txtfechaini.Text)
            Dim rptParams2 As ReportParameter = New ReportParameter("FECHA_FIN", txtfechafin.Text)

            rpt_pago.LocalReport.SetParameters(rptParams)
            rpt_pago.LocalReport.SetParameters(rptParams2)

            rpt_pago.LocalReport.Refresh()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al insertar');</script>")
        End Try
    End Sub
End Class