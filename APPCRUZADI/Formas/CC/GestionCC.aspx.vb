Public Class GestionCC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '    Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        ' Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
        'Conexion.conectar("DESKTOP-8PU4GG0\SQLEXPRESS", "Cruzadi")
        'Conexion.Cerrar_BD()
        Try
            If (IsPostBack = False) Then


                obid = 4

                Bitacora(CInt(ID_Usuario), obid, "INGRESO A GESTION CC")



                cbtipodGestionmodal.DataSource = Cls_Query.dt("  select * from cruzadi.tbl_tipo_gestion")
                cbtipodGestionmodal.DataTextField = "Descripcion_gestion"
                cbtipodGestionmodal.DataValueField = "Tipo_Gestion_ID"
                cbtipodGestionmodal.DataBind()

                If (Request.Params("ClienteID") <> Nothing) And (Request.Params("Razon") <> Nothing) Then
                    TxtNombreCuenta.Value = Request.Params("Razon")
                    txtACliente.Value = Request.Params("ClienteID")
                End If
                'If PA(obid) = True Or PI(obid) = True Then
                '    btnguardar.Visible = True
                'ElseIf PC(obid) = False Then
                '    Response.Redirect("/inicio.aspx")

                'End If
            End If


            If txtACliente.Value <> Nothing Then
                selectGrillaGestionados()
                selectGrillapagados()
                SelectgrillaGestionar()
                lblGestionartotal.Text = CType(lblGestionar(), String)
                lblGestionadostotal.Text = CType(lblGestionados(), String)
                LblTotalpagados.Text = CType(lblPagados(), String)

                fila = Cls_Query.dt("SELECT  CLI.cliente_id,CXC.Nombre_Tipo, CLI.dias_credito, CLI.limite_credito, CXC.Telefono, CXC.E_Mail, EJE.ejecutiva_id, CS.SALDO
FROM view_Clientes CXC INNER JOIN view_cliente_saldo CS ON CXC.Cliente_Id = CS.Cliente_CXC
INNER JOIN cruzadi.tbl_cliente CLI ON CLI.cliente_id =CXC.Cliente_Id
INNER JOIN cruzadi.tbl_ejecutiva EJE ON EJE.ejecutiva_id = CLI.ejecutiva_id  where cli.cliente_id='" & txtACliente.Value & "'")
               
                txttipocliente.Value = fila.Rows.Item(0).Item(1).ToString
                txtdcredito.Value = fila.Rows.Item(0).Item(2).ToString
                txtlcredito.Value = fila.Rows.Item(0).Item(3).ToString
                txttelefono.Value = fila.Rows.Item(0).Item(4).ToString
                txtemail.Value = fila.Rows.Item(0).Item(5).ToString
                txtejecutiva.Value = fila.Rows.Item(0).Item(6).ToString
                txtsaldo.Value = fila.Rows.Item(0).Item(7).ToString
                ' txtClientemodal.Value = fila.Rows.Item(0).Item(0).ToString

            End If


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub


    ''*******Paginacion  de la grilla

    Private Sub GVGestionar_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVGestionar.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With

            lblPaginadorGestionar.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVGestionar.PageCount.ToString()
            SelectgrillaGestionar()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()
        End Try
    End Sub
    Private Sub GVGestionados_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVGestionados.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With

            LblPaginadorGestionados.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVGestionados.PageCount.ToString()
            selectGrillaGestionados()
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()
        End Try

    End Sub

    Private Sub GVPAgados_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVPAgados.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With

            LblPaginadorpagos.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVPAgados.PageCount.ToString()
            selectGrillapagados()
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()
        End Try

    End Sub

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVGestionar.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVGestionar, "Select$" & row.RowIndex, True)
            End If
        Next
        For Each row As GridViewRow In GVGestionados.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVGestionados, "Select$" & row.RowIndex, True)
            End If
        Next
        For Each row As GridViewRow In GVPAgados.Rows
            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVPAgados, "Select$" & row.RowIndex, True)
            End If
        Next


        MyBase.Render(writer)
    End Sub


    ''Metodos para poder dar clic en la fila de un gridview 

    Private Sub GVGestionar_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVGestionar.RowCommand
        If e.CommandName = "Select" Then
            ' SAcar el modal de la informacion facturas de acuerdo al cliente
            fila = Cls_Query.dt(" exec FACTURA_DETALLADA '" & GVGestionar.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text & "','" & GVGestionar.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text & "'")
            ' MsgBox()
            Txtserie.Value = fila.Rows.Item(0).Item(0).ToString
            Txtfactura.Value = fila.Rows.Item(0).Item(1).ToString
            TXTFolio.Value = fila.Rows.Item(0).Item(2).ToString
            TxtRtn.Value = fila.Rows.Item(0).Item(3).ToString
            TxtRazonSocial.Value = fila.Rows.Item(0).Item(4).ToString
            Txtfechages.Value = fila.Rows.Item(0).Item(5).ToString
            TxtClienteges.Value = fila.Rows.Item(0).Item(6).ToString
            TxtCodCliente.Value = fila.Rows.Item(0).Item(7).ToString
            TxtFpago.Value = fila.Rows.Item(0).Item(8).ToString
            TxtSubTotalges.Value = fila.Rows.Item(0).Item(9).ToString
            TxtDescquince.Value = fila.Rows.Item(0).Item(10).ToString
            Txtdesdieciocho.Value = fila.Rows.Item(0).Item(11).ToString
            TxtISV15.Value = fila.Rows.Item(0).Item(12).ToString
            TxtISV18.Value = fila.Rows.Item(0).Item(13).ToString
            TxtTotal.Value = fila.Rows.Item(0).Item(14).ToString

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "FActDetallada", "$('#FActDetallada').modal();", True)

        End If
    End Sub

    Private Sub GVGestionados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVGestionados.RowCommand
        If e.CommandName = "Select" Then
            'Sacar informacion del detalle de las gestiones
            txtidclienteGes.Value = GVGestionados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text
            txtusuarioges.Value = GVGestionados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txttipogestionges.Value = GVGestionados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            txtfechaemisionges.Value = GVGestionados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text
            txtfechaprogramacionges.Value = GVGestionados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text
            txtdescripcionges.Value = GVGestionados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(5).Text
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "GestionRealizadas", "$('#GestionRealizadas').modal();", True)
        End If


    End Sub

    Private Sub GVPAgados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVPAgados.RowCommand
        If e.CommandName = "Select" Then
            'Talvez sacar la descripcion del pago posteado no es relevante
            txtseriemo.Value = GVPAgados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text
            txtfacturamo.Value = GVPAgados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txtfoliomo.Value = GVPAgados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            txtfechapagomo.Value = GVPAgados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text
            txttpagomo.Value = GVPAgados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text
            txttpagomo.Value = GVPAgados.Rows(Convert.ToInt32(e.CommandArgument)).Cells(5).Text
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "DetallePago", "$('#DetallePago').modal();", True)
        End If



    End Sub


    '000-004-01','5867'

    '****** Lbl Gestionar
    Function lblGestionar() As Integer

        Return Cls_Query.dt("exec FACTURAS_GESTIONES '" & txtACliente.Value & "'").Rows.Count
    End Function

    '******Grilla de Gestionar
    Sub SelectgrillaGestionar()

        GVGestionar.DataSource = Cls_Query.dt("exec FACTURAS_GESTIONES '" & txtACliente.Value & "'")
        GVGestionar.DataBind()
    End Sub


    '****** Lbl GEstionados
    Function lblGestionados() As Integer

        Return Cls_Query.dt("select g.cliente_id as CLIENTE_ID,u.usuario AS USUARIO,ges.descripcion_gestion as 'TIPO DE GESTION' ,g.fecha_emision AS 'FECHA DE EMISION', g.fecha_programacion AS 'FECHA DE PROGRAMACION', 
 g.descripcion as DESCRIPCION
from cruzadi.tbl_gestion g, cruzadi.tbl_reg_usuario u , cruzadi.tbl_tipo_gestion ges where u.usuario_id=g.usuario_id and g.tipo_gestion_id=ges.tipo_gestion_id and g.fecha_emision >=getdate() -1  and g.cliente_id='" & txtACliente.Value & "'").Rows.Count
    End Function

    '******Grilla de GEstionados
    Sub selectGrillaGestionados()

        GVGestionados.DataSource = Cls_Query.dt("  select g.cliente_id as CLIENTE_ID,u.usuario AS USUARIO,ges.descripcion_gestion as 'TIPO DE GESTION' ,g.fecha_emision AS 'FECHA DE EMISION', g.fecha_programacion AS 'FECHA DE PROGRAMACION', 
 g.descripcion as DESCRIPCION
from cruzadi.tbl_gestion g, cruzadi.tbl_reg_usuario u , cruzadi.tbl_tipo_gestion ges where u.usuario_id=g.usuario_id and g.tipo_gestion_id=ges.tipo_gestion_id and g.fecha_emision >=getdate() -1  and g.cliente_id='" & txtACliente.Value & "' order by g.fecha_emision asc")
        GVGestionados.DataBind()
    End Sub


    '****** Lbl Pagados
    Function lblPagados() As Integer

        Return Cls_Query.dt("select P.Serie as SERIE,P.Fac AS FACTURA,p.folio AS FOLIO,p.fecha_de_pago AS 'FECHA DE PAGO', tp.descripcion_pago AS 'TIPO DE PAGO',p.total_pagado AS 'TOTAL PAGADO'
 from cruzadi.tbl_pago P, cruzadi.tbl_tipo_de_pago TP Where p.tipo_pago_id=tp.tipo_pago_id and p.cliente_id='" & txtACliente.Value & "' order by p.fecha_de_pago asc").Rows.Count
    End Function

    '******Grilla de Pagados
    Sub selectGrillapagados()

        GVPAgados.DataSource = Cls_Query.dt("select P.Serie as SERIE,P.Fac AS FACTURA,p.folio AS FOLIO,p.fecha_de_pago AS 'FECHA DE PAGO', tp.descripcion_pago AS 'TIPO DE PAGO',p.total_pagado AS 'TOTAL PAGADO'
 from cruzadi.tbl_pago P, cruzadi.tbl_tipo_de_pago TP Where p.tipo_pago_id=tp.tipo_pago_id and p.cliente_id='" & txtACliente.Value & "' order by p.fecha_de_pago asc")
        GVPAgados.DataBind()
    End Sub

    Private Sub BtnBuscarCliente_ServerClick(sender As Object, e As EventArgs) Handles BtnBuscarCliente.ServerClick
        Response.Redirect("/Formas/CC/BuscarCXC.aspx")
    End Sub

    Private Sub BtnGestionar_ServerClick(sender As Object, e As EventArgs) Handles BtnGestionar.ServerClick
        txtClientemodal.Value = txtACliente.Value
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "GESTION", "$('#GESTION').modal();", True)
    End Sub

    Private Sub btnguardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick
        Try
            If txtdesripcion.Value <> Nothing And txtClientemodal.Value <> Nothing And txtfechaprogramadas.Value <> Nothing Then
                Insert("cruzadi.tbl_gestion", "'" & UCase(txtdesripcion.Value) & "',getdate(),'" & txtfechaprogramadas.Value & "','" & txtClientemodal.Value & "','" & cbtipodGestionmodal.SelectedIndex + 1 & "','" & ID_Usuario.ToString & "'")
                'Insert("Cruzadi.Tbl_gestion", "'" & UCase(txtdesripcion.Value) & "',getdate(),'" & txtfechaprogramadas.Value & "','" & txtACliente.Value & "','" & cbtipodGestionmodal.SelectedIndex + 1 & "','" & ID_Usuario.ToString & "'")
                Bitacora(CInt(ID_Usuario), obid, "INSERTO UNA GESTION DEL CLIENTE: '" & UCase(txtClientemodal.Value) & "'")

                mytrans("C")
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")
                Conexion.Cerrar_BD()

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")

            End If

        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
End Class