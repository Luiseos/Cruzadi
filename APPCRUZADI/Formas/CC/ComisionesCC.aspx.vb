Public Class EjecutivaCC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ' Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS01", "Cruzadi")
            ' Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
            '  Conexion.conectar("DESKTOP-8PU4GG0\SQLEXPRESS", "Cruzadi")
            'Conexion.Cerrar_BD()
            SelectGrillaComisionesCC()
            lblTotalesComisiones.Text = CType(lblComisionesCCtotales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo cargar la pagina');</script>")

        End Try
    End Sub

    '******Paginacion en la Grilla
    Private Sub GvComisionesCC_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GvComisionesCC.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorComisionesCC.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GvComisionesCC.PageCount.ToString()
            SelectGrillaComisionesCC()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub


    'sI NO SE HARA NADA AL SELECCIONAS SE PUEDE BORRAR LAS LINEAS DE CODIGOS DE ROWCOMMAND Y RENDER
    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GvComisionesCC_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GvComisionesCC.RowCommand
        If e.CommandName = "Select" Then

            ''Datos a pasar a pagos
            '   Response.Redirect("/Formas/IT/RespuestaIT.aspx?Num_ticket=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text + "&Usuario=" + UCase(GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text) + "&Gestion=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text + "&Caso=" + fila.Rows.Item(0).Item(0).ToString + "&Estado=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text + " ")

        End If
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GvComisionesCC.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GvComisionesCC, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '****** Lbl Estado Tabla Estados IT 
    Function lblComisionesCCtotales() As Integer

        Return Cls_Query.dt("").Rows.Count
        'exec COMISION_CREDITO '" & CDate(TxtFechaInicio.Value) & "','" & CDate(TxtFechaFinal.Value) & "';
    End Function
    '******Select Estado IT
    Sub SelectGrillaComisionesCC()
        GvComisionesCC.DataSource = Cls_Query.dt("")
        GvComisionesCC.DataBind()
        'exec COMISION_CREDITO '" & CDate(TxtFechaInicio.Value) & "','" & CDate(TxtFechaFinal.Value) & "';
        '
    End Sub


End Class