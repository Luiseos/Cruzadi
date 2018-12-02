Public Class BuscarFacturas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        'Conexion.conectar("DESKTOP-8PU4GG0\SQLEXPRESS", "Cruzadi")
        'Conexion.conectar("DESKTOP-8PU4GG0\SQLEXPRESS", "Cruzadi")
        ' Conexion.Cerrar_BD()
        Try

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo cargar la pagina');</script>")

        End Try
    End Sub

    Private Sub BtnGenerar_ServerClick(sender As Object, e As EventArgs) Handles BtnGenerar.ServerClick
        Try
            If TxtFechaInicio.Value <> Nothing And TxtFechaFinal.Value <> Nothing Then
                SelectGrillaPagos()
                lblPagos.Text = CType(lblPagostotales(), String)
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tienes Campos por rellenas');</script>")

            End If
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    '******Paginacion en la Grilla
    Private Sub GVFacturasPagos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVFacturasPagos.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            lblPaginadorPagos.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVFacturasPagos.PageCount.ToString()
            SelectGrillaPagos()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVFacturasPagos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVFacturasPagos.RowCommand
        If e.CommandName = "Select" Then

            ''Datos a pasar a pagos
            '   Response.Redirect("/Formas/IT/RespuestaIT.aspx?Num_ticket=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text + "&Usuario=" + UCase(GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text) + "&Gestion=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text + "&Caso=" + fila.Rows.Item(0).Item(0).ToString + "&Estado=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text + " ")

        End If
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVFacturasPagos.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVFacturasPagos, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '****** Lbl Estado Tabla Estados IT 
    Function lblPagostotales() As Integer

        Return Cls_Query.dt("exec FACTURA_EVENTOS '" & CDate(TxtFechaInicio.Value) & "','" & CDate(TxtFechaFinal.Value) & "';").Rows.Count
    End Function
    '******Select Estado IT
    Sub SelectGrillaPagos()
        GVFacturasPagos.DataSource = Cls_Query.dt("exec FACTURA_EVENTOS '" & CDate(TxtFechaInicio.Value) & "','" & CDate(TxtFechaFinal.Value) & "';")
        GVFacturasPagos.DataBind()
    End Sub

End Class