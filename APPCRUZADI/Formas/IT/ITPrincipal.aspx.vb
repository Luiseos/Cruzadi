Imports System.Data
Imports System.Data.SqlClient


Public Class ITPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
            ' Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
            Conexion.Cerrar_BD()
            'Para Cargar los pendientes o recibidos
            TicketRecibidos()
            lblRecibidos.Text = CType(lblpendiente(), String)
            lblProceso.Text = CType(lblProcesos(), String)
            TicketProcesos()


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try


    End Sub



    ''Metodos para poder dar clic en la fila de un gridview de Recibidos
    Private Sub GVRecibidosTicket_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVRecibidosTicket.RowCommand
        If e.CommandName = "Select" Then
            fila = Cls_Query.dt("   select caso_it from cruzadi.tbl_it_soporte where soporte_id='" & GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text & "'")
            Response.Redirect("/Formas/IT/RespuestaIT.aspx?Num_ticket=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text + "&Usuario=" + UCase(GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text) + "&Gestion=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text + "&Caso=" + fila.Rows.Item(0).Item(0).ToString + "&Estado=" + GVRecibidosTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text + " ")

        End If


    End Sub

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVRecibidosTicket.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVRecibidosTicket, "Select$" & row.RowIndex, True)
            End If
        Next
        For Each row As GridViewRow In GVProcesoTicket.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVProcesoTicket, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub


    ''Metodos para poder dar clic en la fila de un gridview de Procesos

    Private Sub GVProcesoTicket_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVProcesoTicket.RowCommand
        If e.CommandName = "Select" Then
            fila = Cls_Query.dt("   select caso_it from cruzadi.tbl_it_soporte where soporte_id='" & GVProcesoTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text & "'")
            Response.Redirect("/Formas/IT/RespuestaIT.aspx?Num_ticket=" + GVProcesoTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text + "&Usuario=" + UCase(GVProcesoTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text) + "&Gestion=" + GVProcesoTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text + "&Caso=" + fila.Rows.Item(0).Item(0).ToString + "&Estado=" + GVProcesoTicket.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text + " ")

        End If


    End Sub

    '****** Lbl Pendiente
    Function lblpendiente() As Integer

        Return Cls_Query.dt("Select soporte_id as Num_Ticket, FECHA_ENTRADA , g.descripcion_gestion as ASUNTO,us.Nombre_Usuario as SOLICITANTE , es.descripcion_estado as  ESTADO
  from cruzadi.tbl_it_soporte s, cruzadi.tbl_gestion_it g, cruzadi.tbl_reg_usuario us, cruzadi.tbl_estado_it es
   where s.usuario_id=us.usuario_id and  s.gestion_IT_id=g.gestion_IT_id and s.estado_IT_id=es.estado_IT_id and s.estado_IT_id=1").Rows.Count
    End Function
    '******Grilla de Recibidos
    Sub TicketRecibidos()
        GVRecibidosTicket.DataSource = Cls_Query.dt("  Select soporte_id as NUM_TICKET, FECHA_ENTRADA , g.descripcion_gestion as ASUNTO,us.Nombre_Usuario as SOLICITANTE , es.descripcion_estado as  ESTADO
  from cruzadi.tbl_it_soporte s, cruzadi.tbl_gestion_it g, cruzadi.tbl_reg_usuario us, cruzadi.tbl_estado_it es
   where s.usuario_id=us.usuario_id and  s.gestion_IT_id=g.gestion_IT_id and s.estado_IT_id=es.estado_IT_id and s.estado_IT_id=1")
        GVRecibidosTicket.DataBind()
    End Sub

    '****** Lbl Proceso
    Function lblProcesos() As Integer

        Return Cls_Query.dt("Select soporte_id as Num_Ticket, FECHA_ENTRADA , g.descripcion_gestion as ASUNTO,us.Nombre_Usuario as SOLICITANTE , es.descripcion_estado as  ESTADO
  from cruzadi.tbl_it_soporte s, cruzadi.tbl_gestion_it g, cruzadi.tbl_reg_usuario us, cruzadi.tbl_estado_it es
   where s.usuario_id=us.usuario_id and  s.gestion_IT_id=g.gestion_IT_id and s.estado_IT_id=es.estado_IT_id and s.estado_IT_id=2").Rows.Count
    End Function

    '******Grilla de Proceso
    Sub TicketProcesos()

        GVProcesoTicket.DataSource = Cls_Query.dt("Select soporte_id as NUM_TICKET, FECHA_ENTRADA , g.descripcion_gestion as ASUNTO,us.Nombre_Usuario as SOLICITANTE , es.descripcion_estado as  ESTADO
  from cruzadi.tbl_it_soporte s, cruzadi.tbl_gestion_it g, cruzadi.tbl_reg_usuario us, cruzadi.tbl_estado_it es
   where s.usuario_id=us.usuario_id and  s.gestion_IT_id=g.gestion_IT_id and s.estado_IT_id=es.estado_IT_id and s.estado_IT_id=2")
        GVProcesoTicket.DataBind()
    End Sub

    ''*******Paginacion  de la grilla

    Private Sub GVRecibidosTicket_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVRecibidosTicket.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

        With grilla
            .PageIndex = e.NewPageIndex()
        End With


        lblPaginadorRecibidos.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVRecibidosTicket.PageCount.ToString()
        TicketRecibidos()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    Private Sub GVProcesoTicket_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVProcesoTicket.PageIndexChanging

        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorProceso.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVProcesoTicket.PageCount.ToString()
            TicketProcesos()
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
End Class