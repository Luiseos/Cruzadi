Public Class ModificarCliente
    Inherits System.Web.UI.Page

    ' Dim dcredito, lcredito, ejecutiva As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '   Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        '  Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
        'Conexion.conectar("DESKTOP-8PU4GG0\SQLEXPRESS", "Cruzadi")
        'Conexion.Cerrar_BD()
        Try
            If (IsPostBack = False) Then
                obid = 3
                If PC(obid) = False Then
                    Response.Redirect("/inicio.aspx")

                End If
                Bitacora(CInt(ID_Usuario), obid, "INGRESO A MODIFICAR CLIENTE")

            End If


            selectcliente()
            lblTotalesCliente.Text = CType(lblClientetotales(), String)


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo cargar la pagina');</script>")

        End Try
    End Sub

    'Grilla seleccionar fila

    Private Sub Gvbuscarcliente_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles Gvbuscarcliente.RowCommand
        If e.CommandName = "Select" Then
            contador = 1
            Response.Redirect("/Formas/CC/AgregarClientes.aspx?RFC=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(0).Text +
                              "&Codigo=" + UCase(Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text) +
                              "&RTN=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text +
                              "&RazonSocial=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text +
                              "&NombreTipo=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text +
                              "&Contacto=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(5).Text +
                              " &Direccion=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(6).Text +
                              "&Email=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(7).Text +
                              " &Telefono=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(8).Text +
                                "&Dias=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(9).Text + "&limite=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(10).Text + "&contador=" + contador.ToString + "")
            '"&Ejecutiva=" + Gvbuscarcliente.Rows(Convert.ToInt32(e.CommandArgument)).Cells(11).Text +


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

    '****** Lbl Estado Tabla Estados IT 

    Function lblClientetotales() As Integer

        Return Cls_Query.dt("  select a.rfc,a.Codigo_Cliente,a.RTN,a.Razon_Social,a.Nombre_Tipo,b.contacto,a.Direccion,a.E_Mail,a.Telefono ,b.dias_credito,b.limite_credito,b.ejecutiva_id from view_ClienteCXC_MOD a,cruzadi.tbl_cliente b  where a.Codigo_Cliente=b.cliente_id").Rows.Count
    End Function

    'Select Cliente

    Sub selectcliente()
        Gvbuscarcliente.DataSource = Cls_Query.dt("  select a.rfc,a.Codigo_Cliente,a.RTN,a.Razon_Social,a.Nombre_Tipo,b.contacto,a.Direccion,a.E_Mail,a.Telefono ,b.dias_credito,b.limite_credito,b.ejecutiva_id from view_ClienteCXC_MOD a,cruzadi.tbl_cliente b  where a.Codigo_Cliente=b.cliente_id")
        Gvbuscarcliente.DataBind()
    End Sub

    Private Sub TXtBuscar1_TextChanged(sender As Object, e As EventArgs) Handles TXtBuscar1.TextChanged
        Try
            selectcliente()

            Gvbuscarcliente.DataSource = Cls_Query.dt("  select a.rfc,a.Codigo_Cliente,a.RTN,a.Razon_Social,a.Nombre_Tipo,b.contacto,a.Direccion,a.E_Mail,a.Telefono ,b.dias_credito,b.limite_credito,b.ejecutiva_id from view_ClienteCXC_MOD a,cruzadi.tbl_cliente b  where a.Codigo_Cliente=b.cliente_id and 
a.Codigo_Cliente Like '%" & TXtBuscar1.Text & "'")
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