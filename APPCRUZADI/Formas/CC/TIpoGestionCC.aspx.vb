Public Class TIpoGestionCC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
            '' Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
            'Conexion.Cerrar_BD()
            selectgestionCXC()
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
                fila = Cls_Query.dt("SELECT COUNT(descripcion_pago) FROM cruzadi.tbl_tipo_gestion WHERE descripcion_pago='" & TxtDescripcion.Value & "'")
                existe = fila.Rows.Item(0).Item(0).ToString
                If CInt(existe) = 1 Then
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Gestion  ya existe en la base.');</script>")
                Else

                    Insert("cruzadi.tbl_tipo_gestion(descripcion_gestion)", "'" & UCase(TxtDescripcion.Value) & "'")
                    event_bitacora(CInt(ID_Usuario), 7, "AGREGO LA DESCRIPCION DE TIPO GESTIONCXC: '" & UCase(TxtDescripcion.Value) & "'")
                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")
                End If
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos sin completar');</script>")


            End If
            selectgestionCXC()
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
            If TxtDescripcion.Value <> GVGestionCXC.SelectedRow.Cells(1).Text Then
                Actualizar("cruzadi.tbl_tipo_gestion", "descripcion_gestion='" & UCase(TxtDescripcion.Value) & "'", "tipo_Gestion_ID='" & GVGestionCXC.SelectedRow.Cells(0).Text & "'")
                event_bitacora(CInt(ID_Usuario), 7, "MODIFICO LA DESCRIPCION DE TIPO GESTIONCXC: '" & UCase(TxtDescripcion.Value) & "'")

                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Modifico Correctamente.');</script>")

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos sin completar');</script>")

            End If
            selectgestionCXC()
            lblgestion.Text = CType(lblgestiontotales(), String)
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub GVGestionCXC_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVGestionCXC.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            ' lblgestion.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVGestionIT.PageCount.ToString()
            selectgestionCXC()


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVGestionCXC_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVGestionCXC.RowCommand
        If e.CommandName = "Select" Then
            TxtDescripcion.Value = GVGestionCXC.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
        End If


    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVGestionCXC.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVGestionCXC, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub


    '****** Lbl Estado Tabla Gestion
    Function lblgestiontotales() As Integer

        Return Cls_Query.dt("Select * From cruzadi.tbl_tipo_gestion").Rows.Count
    End Function
    '****Select Gestion

    Sub selectgestionCXC()
        GVGestionCXC.DataSource = Cls_Query.dt("Select * From cruzadi.tbl_tipo_gestion")
        GVGestionCXC.DataBind()
    End Sub

End Class