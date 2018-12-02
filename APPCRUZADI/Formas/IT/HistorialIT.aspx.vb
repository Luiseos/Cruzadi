Public Class HistorialIT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
            'Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
            'Conexion.Cerrar_BD()
            TicketFinalizados()
            lblFinalizados.Text = CType(lbltotalfinalizados(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try


    End Sub
    Private Sub TXtBuscar1_TextChanged(sender As Object, e As EventArgs) Handles TXtBuscar1.TextChanged
        Try
            GVFinalizadosTicket.DataSource = Cls_Query.dt(" select s.soporte_id as Ticket ,u.usuario As Solicitante,s.caso_it as Caso , es.descripcion_estado As Estado ,g.descripcion_gestion as gestion
 , s.fecha_salida as Fecha_Realizado
 from cruzadi.tbl_it_soporte s, cruzadi.tbl_estado_it es , cruzadi.tbl_gestion_it g, cruzadi.tbl_reg_usuario u
 where  es.estado_IT_id=s.estado_IT_id and g.gestion_IT_id=s.gestion_IT_id and u.usuario_id=s.usuario_id
   and s.estado_IT_id=3 and ( s.soporte_id like '%" & TXtBuscar1.Text & "' or u.usuario like '%" & TXtBuscar1.Text & "%' or g.descripcion_gestion like '%" & TXtBuscar1.Text & "%' or s.caso_it like'% " & TXtBuscar1.Text & " %')")
        GVFinalizadosTicket.DataBind()
            lblFinalizados.Text = CType(lbltotalfinalizados(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
    Private Sub GVFinalizadosTicket_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVFinalizadosTicket.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
            .PageIndex = e.NewPageIndex()
        End With


        lblPaginadorFinalizados.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVFinalizadosTicket.PageCount.ToString()
            TicketFinalizados()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    '   ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Historial", "$('#Historial').modal();", True)



    ''Metodos para poder dar clic en la fila de un gridview de Recibidos
    Private Sub GVFinalizadosTicket_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVFinalizadosTicket.RowCommand
        If e.CommandName = "Select" Then

            fila = Cls_Query.dt(" select s.soporte_id as Ticket ,u.usuario As Solicitante,g.descripcion_gestion as gestion,s.caso_it as Caso ,s.Respuesta_Soporte as Respuesta
    from cruzadi.tbl_it_soporte s, cruzadi.tbl_gestion_it g, cruzadi.tbl_reg_usuario u where   g.gestion_IT_id=s.gestion_IT_id and u.usuario_id=s.usuario_id and s.soporte_id='" & GVFinalizadosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text & "'")
            TxtTicket.Value = fila.Rows.Item(0).Item(0).ToString
            TxtUsuario.Value = fila.Rows.Item(0).Item(1).ToString
            TXTGESTION.Value = fila.Rows.Item(0).Item(2).ToString
            TxtmsjRecibido.Value = fila.Rows.Item(0).Item(3).ToString
            TxtmsjEnviado.Value = fila.Rows.Item(0).Item(4).ToString
            fila2 = Cls_Query.dt("select u.usuario from cruzadi.tbl_reg_usuario u , cruzadi.tbl_it_soporte it  where u.usuario_id=it.usuario_id_2 and it.soporte_id='" & GVFinalizadosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text & "'")
            TXTASIGNADO.Value = fila2.Rows.Item(0).Item(0).ToString
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Historial", "$('#Historial').modal();", True)
        End If

    End Sub

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVFinalizadosTicket.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVFinalizadosTicket, "Select$" & row.RowIndex, True)
            End If
        Next


        MyBase.Render(writer)
    End Sub




    Sub TicketFinalizados()

        GVFinalizadosTicket.DataSource = Cls_Query.dt(" select s.soporte_id as Ticket ,u.usuario As Solicitante,s.caso_it as Caso , es.descripcion_estado As Estado ,g.descripcion_gestion as gestion
 , s.fecha_salida as Fecha_Realizado
 from cruzadi.tbl_it_soporte s, cruzadi.tbl_estado_it es , cruzadi.tbl_gestion_it g, cruzadi.tbl_reg_usuario u
 where  es.estado_IT_id=s.estado_IT_id and g.gestion_IT_id=s.gestion_IT_id and u.usuario_id=s.usuario_id
   and s.estado_IT_id=3 ")
        GVFinalizadosTicket.DataBind()
    End Sub
    Function lbltotalfinalizados() As Integer

        Return Cls_Query.dt(" select s.soporte_id as Ticket ,u.usuario As Solicitante,s.caso_it as Caso , es.descripcion_estado As Estado ,g.descripcion_gestion as gestion
 , s.fecha_salida as Fecha_Realizado
 from cruzadi.tbl_it_soporte s, cruzadi.tbl_estado_it es , cruzadi.tbl_gestion_it g, cruzadi.tbl_reg_usuario u
 where  es.estado_IT_id=s.estado_IT_id and g.gestion_IT_id=s.gestion_IT_id and u.usuario_id=s.usuario_id
   and s.estado_IT_id=3 ").Rows.Count
    End Function


End Class