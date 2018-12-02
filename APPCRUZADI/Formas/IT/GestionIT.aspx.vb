Public Class GestionIT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
            'Conexion.conectar("DESKTOP-I0V7P0T \ SQLEXPRESS", "Cruzadi")
            'Conexion.Cerrar_BD()
            selectgestionit()
            lblgestion.Text = CType(lblgestiontotales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnguardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick
        Try
            If TxtDescripcion.Value <> Nothing Then
                fila = Cls_Query.dt("SELECT COUNT(descripcion_pago) FROM Cruzadi.tbl_tipo_de_pago WHERE descripcion_pago='" & TxtDescripcion.Value & "'")
                existe = fila.Rows.Item(0).Item(0).ToString
                If CInt(existe) = 1 Then
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Gestion  ya existe en la base.');</script>")
                Else

                    Insert("Cruzadi.tbl_gestion_it(descripcion_gestion)", "'" & UCase(TxtDescripcion.Value) & "'")
                    event_bitacora(CInt(ID_Usuario), 7, "AGREGO LA DESCRIPCION DE LA GESTION IT: '" & UCase(TxtDescripcion.Value) & "'")
                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")
                End If
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos sin completar');</script>")


            End If
            selectgestionit()
            lblgestion.Text = CType(lblgestiontotales(), String)

        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub


    Private Sub BtnModificar_ServerClick(sender As Object, e As EventArgs) Handles BtnModificar.ServerClick
        Try
            If TxtDescripcion.Value <> GVGestionIT.SelectedRow.Cells(1).Text Then
                Actualizar("Cruzadi.tbl_gestion_it", "descripcion_gestion='" & UCase(TxtDescripcion.Value) & "'", "Gestion_IT_ID='" & GVGestionIT.SelectedRow.Cells(0).Text & "'")
                event_bitacora(CInt(ID_Usuario), 7, "MODIFICO LA DESCRIPCION DE LA GESTION IT: '" & UCase(TxtDescripcion.Value) & "'")

                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Modifico Correctamente.');</script>")

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos sin completar');</script>")

            End If
            selectgestionit()
            lblgestion.Text = CType(lblgestiontotales(), String)
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub


    '****** Lbl Estado Tabla Gestion
    Function lblgestiontotales() As Integer

        Return Cls_Query.dt("select * from Cruzadi.tbl_gestion_it").Rows.Count
    End Function
    '****Select Gestion

    Sub selectgestionit()
        GVGestionIT.DataSource = Cls_Query.dt("select * from Cruzadi.tbl_gestion_it")
        GVGestionIT.DataBind()
    End Sub

    Private Sub GVGestionIT_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVGestionIT.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            ' lblgestion.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVGestionIT.PageCount.ToString()
            selectgestionit()


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVGestionIT_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVGestionIT.RowCommand
        If e.CommandName = "Select" Then
            TxtDescripcion.Value = GVGestionIT.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
        End If


    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVGestionIT.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVGestionIT, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

End Class