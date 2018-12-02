Public Class TipoPOS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SelectTipos()
            lblTipopos.Text = CType(lblTipopostotales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo cargar bien los datos.');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnGuardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick
        Try
            If txtDescripcion.Value <> Nothing Then

                fila = Cls_Query.dt("SELECT COUNT(bancos_pos) FROM Cruzadi.tbl_tipo_de_pago WHERE bancos_pos='" & txtDescripcion.Value & "'")
                existe = fila.Rows.Item(0).Item(0).ToString
                If CInt(existe) = 1 Then
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tipo de POS ya existe en la base.');</script>")
                Else

                    Insert("Cruzadi.tbl_POS(Banco_POS,Tasa_Cobro)", "'" & UCase(txtDescripcion.Value) & "','" & UCase(TxtTasacobro.Value) & "'")
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se agrego correctamente.');</script>")
                    event_bitacora(CInt(ID_Usuario), 8, "AGREGO EL TIPO POS: '" & UCase(txtDescripcion.Value) & "'")
                    mytrans("C")
                    Conexion.Cerrar_BD()
                End If
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Llene el campo requerido.');</script>")

            End If

            SelectTipos()
            lblTipopos.Text = CType(lblTipopostotales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    Private Sub btnModificar_ServerClick(sender As Object, e As EventArgs) Handles btnModificar.ServerClick
        Try

            If txtDescripcion.Value <> GVPOS.SelectedRow.Cells(2).Text Then
                Actualizar("Cruzadi.tbl_POS", "Bancos_pos='" & UCase(txtDescripcion.Value) & "',tasa_Cobro='" & TxtTasacobro.Value & "'", "POS_id='" & GVPOS.SelectedRow.Cells(1).Text & "'")
                event_bitacora(CInt(ID_Usuario), 8, "MODIFICO LA DESCRIPCION DE POS '" & GVPOS.SelectedRow.Cells(1).Text & "' A '" & UCase(txtDescripcion.Value) & "'")

                mytrans("C")
                Conexion.Cerrar_BD()
                txtDescripcion.Value = " "
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se ha Modificado El Tipo de POS ');</script>")
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tiene Campos por rellenar, favor verificar. ');</script>")

            End If
            SelectTipos()
            lblTipopos.Text = CType(lblTipopostotales(), String)
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    '****** Lbl Tipo Pago
    Function lblTipopostotales() As Integer

        Return Cls_Query.dt("SELECT * FROM Cruzadi.tbl_POS").Rows.Count
    End Function

    '*****Select Tipo Pago
    Sub SelectTipos()
        GVPOS.DataSource = Cls_Query.dt("select * from Cruzadi.tbl_POS")
        GVPOS.DataBind()
    End Sub
    '******PAginador Index
    Private Sub GVPOS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVPOS.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With

            SelectTipos()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
    '**Seleccionar una fila del gridview
    Private Sub GVPOS_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVPOS.RowCommand
        If e.CommandName = "Select" Then

            txtDescripcion.Value = GVPOS.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            TxtTasacobro.Value = GVPOS.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
        End If


    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVPOS.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVPOS, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub
End Class