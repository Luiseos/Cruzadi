Public Class TipoPago
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SelectTipopago()
            lbltipopago.Text = CType(lblTipopagototales(), String)
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo cargar bien los datos.');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnGuardar_ServerClick(sender As Object, e As EventArgs) Handles btnGuardar.ServerClick
        Try
            If txtDescripcion.Value <> Nothing Then
                fila = Cls_Query.dt("SELECT COUNT(descripcion_pago) FROM Cruzadi.tbl_tipo_de_pago WHERE descripcion_pago='" & txtDescripcion.Value & "'")
                existe = fila.Rows.Item(0).Item(0).ToString
                If CInt(existe) = 1 Then
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tipo de Pago ya existe en la base.');</script>")

                Else
                    Insert("Cruzadi.tbl_tipo_de_pago(descripcion_pago)", "'" & UCase(txtDescripcion.Value) & "'")
                    event_bitacora(CInt(ID_Usuario), 8, "AGREGO EL TIPO DE PAGO: '" & UCase(txtDescripcion.Value) & "'")

                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se agrego correctamente.');</script>")
                    txtDescripcion.Value = " "
                End If
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Llene el campo requerido.');</script>")

            End If

            SelectTipopago()
            lbltipopago.Text = CType(lblTipopagototales(), String)

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un error al tratar de guardar, Por favor intente de Nuevo.');</script>")
        End Try

    End Sub

    Private Sub BtnModificar_ServerClick(sender As Object, e As EventArgs) Handles BtnModificar.ServerClick
        Try

            If txtDescripcion.Value <> GVPagos.SelectedRow.Cells(2).Text Then
                Actualizar("Cruzadi.tbl_tipo_de_pago", "Descripcion_pago='" & UCase(txtDescripcion.Value) & "'", "tipo_pago_id='" & UCase(GVPagos.SelectedRow.Cells(1).Text) & "'")
                event_bitacora(CInt(ID_Usuario), 8, "MODIFICO LA DESCRIPCION DE PAGO '" & UCase(GVPagos.SelectedRow.Cells(1).Text) & "' A '" & UCase(txtDescripcion.Value) & "'")

                mytrans("C")
                Conexion.Cerrar_BD()
                txtDescripcion.Value = " "
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se ha Modificado el Tipo de Pago ');</script>")
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tiene Campos por rellenar, favor verificar. ');</script>")

            End If
            SelectTipopago()
            lbltipopago.Text = CType(lblTipopagototales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    '****** Lbl Tipo Pago
    Function lblTipopagototales() As Integer

        Return Cls_Query.dt("SELECT * FROM Cruzadi.tbl_tipo_de_pago").Rows.Count
    End Function

    '*****Select Tipo Pago
    Sub SelectTipopago()
        GVPagos.DataSource = Cls_Query.dt("select * from Cruzadi.tbl_tipo_de_pago")
        GVPagos.DataBind()
    End Sub
    '******PAginador Index
    Private Sub GVPagos_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVPagos.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With

            SelectTipopago()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
    '**Seleccionar una fila del gridview
    Private Sub GVPagos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVPagos.RowCommand
        If e.CommandName = "Select" Then

            txtDescripcion.Value = GVPagos.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
        End If


    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVPagos.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVPagos, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub
End Class