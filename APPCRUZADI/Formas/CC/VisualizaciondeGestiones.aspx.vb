Public Class VisualizaciondeGestiones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '  Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        'Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
        'Conexion.conectar("DESKTOP-8PU4GG0\SQLEXPRESS", "Cruzadi")
        'Conexion.Cerrar_BD()
        Try

            selectpromesascxc()
            selectLlamadasCXC()
            selectVisitas()
            lbltotlapromesas.Text = CType(lblPromesascxc(), String)
            lblLlamadas.Text = CType(lblLlamadasCXC(), String)
            LblVisitas.Text = CType(lblVisitasCXC(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo cargar la pagina');</script>")

        End Try
    End Sub



    'Metodo de Render para la seleccion
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVPromesas.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVPromesas, "Select$" & row.RowIndex, True)
            End If
        Next
        For Each row As GridViewRow In GVLlamadas.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVLlamadas, "Select$" & row.RowIndex, True)
            End If
        Next

        For Each row As GridViewRow In GVVisitas.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVVisitas, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub


    ''Metodos para poder dar clic en la fila de un gridview de Promesas

    Private Sub GVPromesas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVPromesas.RowCommand
        If e.CommandName = "Select" Then
            'Sacar el modal de acuerdo a la informacion
            txtidclienteGes.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text
            txtusuarioges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txttipogestionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            txtfechaemisionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text
            txtfechaprogramacionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text
            txtdescripcionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(5).Text
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "GestionRealizadas", "$('#GestionRealizadas').modal();", True)
        End If

    End Sub

    ''Metodos para poder dar clic en la fila de un gridview de Llamadas
    Private Sub GVLlamadas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVLlamadas.RowCommand
        If e.CommandName = "Select" Then
            'Sacar el modal de acuerdo a la informacion
            txtidclienteGes.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text
            txtusuarioges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txttipogestionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            txtfechaemisionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text
            txtfechaprogramacionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text
            txtdescripcionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(5).Text
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "GestionRealizadas", "$('#GestionRealizadas').modal();", True)
        End If
    End Sub

    ''Metodos para poder dar clic en la fila de un gridview de Visitas
    Private Sub GVVisitas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVVisitas.RowCommand
        If e.CommandName = "Select" Then
            'Sacar el modal de acuerdo a la informacion
            txtidclienteGes.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text
            txtusuarioges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txttipogestionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            txtfechaemisionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text
            txtfechaprogramacionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text
            txtdescripcionges.Value = GVVisitas.Rows(Convert.ToInt32(e.CommandArgument)).Cells(5).Text
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "GestionRealizadas", "$('#GestionRealizadas').modal();", True)
        End If
    End Sub


    ''*******Paginacion  de la grilla

    Private Sub GVPromesas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVPromesas.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            lblPaginadorCXCPromesas.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVPromesas.PageCount.ToString()
            selectpromesascxc()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    Private Sub GVLlamadas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVLlamadas.PageIndexChanging

        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorLlamadas.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVLlamadas.PageCount.ToString()
            selectLlamadasCXC()
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub GVVisitas_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVVisitas.PageIndexChanging

        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorVisitas.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVVisitas.PageCount.ToString()
            selectVisitas()
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    '****** Lbl Promesas
    Function lblPromesascxc() As Integer

        Return Cls_Query.dt("  select g.cliente_id as CLIENTE_ID,u.usuario AS USUARIO,ges.descripcion_gestion as 'TIPO DE GESTION' ,g.fecha_emision AS 'FECHA DE EMISION', g.fecha_programacion AS 'FECHA DE PROGRAMACION', 
 g.descripcion as DESCRIPCION
from cruzadi.tbl_gestion g, cruzadi.tbl_reg_usuario u , cruzadi.tbl_tipo_gestion ges where u.usuario_id=g.usuario_id and g.tipo_gestion_id=ges.tipo_gestion_id and g.fecha_emision >=getdate() -1  and ges.descripcion_gestion='Promesas'").Rows.Count
    End Function
    '******Grilla de Promesas
    Sub selectpromesascxc()
        GVPromesas.DataSource = Cls_Query.dt("  select g.cliente_id as CLIENTE_ID,u.usuario AS USUARIO,ges.descripcion_gestion as 'TIPO DE GESTION' ,g.fecha_emision AS 'FECHA DE EMISION', g.fecha_programacion AS 'FECHA DE PROGRAMACION', 
 g.descripcion as DESCRIPCION
from cruzadi.tbl_gestion g, cruzadi.tbl_reg_usuario u , cruzadi.tbl_tipo_gestion ges where u.usuario_id=g.usuario_id and g.tipo_gestion_id=ges.tipo_gestion_id and g.fecha_emision >=getdate() -1  and ges.descripcion_gestion='Promesas'")
        GVPromesas.DataBind()
    End Sub

    '****** Lbl Llamadas
    Function lblLlamadasCXC() As Integer

        Return Cls_Query.dt("  select g.cliente_id as CLIENTE_ID,u.usuario AS USUARIO,ges.descripcion_gestion as 'TIPO DE GESTION' ,g.fecha_emision AS 'FECHA DE EMISION', g.fecha_programacion AS 'FECHA DE PROGRAMACION', 
 g.descripcion as DESCRIPCION
from cruzadi.tbl_gestion g, cruzadi.tbl_reg_usuario u , cruzadi.tbl_tipo_gestion ges where u.usuario_id=g.usuario_id and g.tipo_gestion_id=ges.tipo_gestion_id and g.fecha_emision >=getdate() -1  and ges.descripcion_gestion='LLAMADAS'").Rows.Count
    End Function
    '******Grilla de Llamadas
    Sub selectLlamadasCXC()
        GVLlamadas.DataSource = Cls_Query.dt("select g.cliente_id as CLIENTE_ID,u.usuario AS USUARIO,ges.descripcion_gestion as 'TIPO DE GESTION' ,g.fecha_emision AS 'FECHA DE EMISION', g.fecha_programacion AS 'FECHA DE PROGRAMACION', 
 g.descripcion as DESCRIPCION
from cruzadi.tbl_gestion g, cruzadi.tbl_reg_usuario u , cruzadi.tbl_tipo_gestion ges where u.usuario_id=g.usuario_id and g.tipo_gestion_id=ges.tipo_gestion_id and g.fecha_emision >=getdate() -1  and ges.descripcion_gestion='LLAMADAS'")
        GVLlamadas.DataBind()
    End Sub

    '****** Lbl Visitas
    Function lblVisitasCXC() As Integer

        Return Cls_Query.dt(" select g.cliente_id as CLIENTE_ID,u.usuario AS USUARIO,ges.descripcion_gestion as 'TIPO DE GESTION' ,g.fecha_emision AS 'FECHA DE EMISION', g.fecha_programacion AS 'FECHA DE PROGRAMACION', 
 g.descripcion as DESCRIPCION
from cruzadi.tbl_gestion g, cruzadi.tbl_reg_usuario u , cruzadi.tbl_tipo_gestion ges where u.usuario_id=g.usuario_id and g.tipo_gestion_id=ges.tipo_gestion_id and g.fecha_emision >=getdate() -1  and ges.descripcion_gestion='VISITAS'").Rows.Count
    End Function

    '******Grilla de Visitas
    Sub selectVisitas()

        GVVisitas.DataSource = Cls_Query.dt("select g.cliente_id as CLIENTE_ID,u.usuario AS USUARIO,ges.descripcion_gestion as 'TIPO DE GESTION' ,g.fecha_emision AS 'FECHA DE EMISION', g.fecha_programacion AS 'FECHA DE PROGRAMACION', 
 g.descripcion as DESCRIPCION
from cruzadi.tbl_gestion g, cruzadi.tbl_reg_usuario u , cruzadi.tbl_tipo_gestion ges where u.usuario_id=g.usuario_id and g.tipo_gestion_id=ges.tipo_gestion_id and g.fecha_emision >=getdate() -1  and ges.descripcion_gestion='VISITAS'")
        GVVisitas.DataBind()
    End Sub
End Class