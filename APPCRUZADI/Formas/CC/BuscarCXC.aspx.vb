Public Class BuscarCXC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '   Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        ' Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
        'Conexion.conectar("DESKTOP-8PU4GG0\SQLEXPRESS", "Cruzadi")
        'Conexion.Cerrar_BD()
        Try

            selectcliente()
            lblTotalesCliente.Text = CType(lblClientetotales(), String)


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo cargar la pagina');</script>")

        End Try
    End Sub
    ' 
    'Grilla seleccionar fila

    Private Sub Gvbuscarcliente_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles Gvbuscarcliente.RowCommand
        If e.CommandName = "Select" Then

            ''Solo pasar los datos de cliente id y nombre a gestion
            'informacion va a Gestion CC
            Response.Redirect("/Formas/CC/GestionCC.aspx?CLienteID=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text + "&Razon=" + UCase(Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text))

        End If

    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In Gvbuscarcliente.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Gvbuscarcliente, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '******Paginacion en la Grilla
    Private Sub Gvbuscarcliente_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles Gvbuscarcliente.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorCliente.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & Gvbuscarcliente.PageCount.ToString()
            selectcliente()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    '****** Lbl total cliente totales

    Function lblClientetotales() As Integer

        Return Cls_Query.dt("select * from view_cliente_saldo").Rows.Count
    End Function

    'Select Cliente

    Sub selectcliente()
        Gvbuscarcliente.DataSource = Cls_Query.dt("select * from view_cliente_saldo")
        Gvbuscarcliente.DataBind()
    End Sub

    Private Sub TXtBuscar1_TextChanged(sender As Object, e As EventArgs) Handles TXtBuscar1.TextChanged
        Try
            selectcliente()
            Conexion.Cerrar_BD()
            Gvbuscarcliente.DataSource = Cls_Query.dt("  select * from cruzadi.dbo.view_Cliente_saldo where Cliente_CXC Like '% " & TXtBuscar1.Text & " %'")
            Gvbuscarcliente.DataBind()
            lblTotalesCliente.Text = CType(lblClientetotales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

End Class