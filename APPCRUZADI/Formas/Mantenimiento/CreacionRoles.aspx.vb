Public Class Roles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            SelectGrillaRoles()
            lblTotalesRoles.Text = CType(lblRolestotales(), String)
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnguardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick

        Try
            If txtrol.Value <> Nothing And txtdescrpcionrol.Value <> Nothing Then
                Insert("Cruzadi.tbl_Roles(rol,Descripcion)", "'" & UCase(txtrol.Value) & "','" & UCase(txtdescrpcionrol.Value) & "'")
                event_bitacora(CInt(ID_Usuario), 14, "INSERTO EL ROL: '" & UCase(txtrol.Value) & "'")

                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


            End If

            SelectGrillaRoles()
            lblTotalesRoles.Text = CType(lblRolestotales(), String)
        Catch ex As Exception
            mytrans("R")
            ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnmodificar_ServerClick(sender As Object, e As EventArgs) Handles btnmodificar.ServerClick
        Try
            If txtrol.Value <> Nothing And txtdescrpcionrol.Value <> Nothing Then
                Actualizar("Cruzadi.tbl_roles", "rol='" & UCase(txtrol.Value) & "',Descripcion='" & UCase(txtdescrpcionrol.Value) & "'", "Rol_id='" & GVRol.SelectedRow.Cells(0).Text & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Modifico Correctamente.');</script>")

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


            End If

            SelectGrillaRoles()
            lblTotalesRoles.Text = CType(lblRolestotales(), String)
        Catch ex As Exception
            mytrans("R")
            ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    '******Paginacion en la Grilla
    Private Sub GVRol_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVRol.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            SelectGrillaRoles()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVRol_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVRol.RowCommand
        If e.CommandName = "Select" Then

            txtrol.Value = GVRol.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txtdescrpcionrol.Value = GVRol.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text

        End If
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVRol.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVRol, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '****** Lbl Roles Totales
    Function lblRolestotales() As Integer

        Return Cls_Query.dt("select * from Cruzadi.tbl_Roles").Rows.Count
    End Function
    '******Select Roles
    Sub SelectGrillaRoles()
        GVRol.DataSource = Cls_Query.dt("select * from Cruzadi.tbl_Roles")
        GVRol.DataBind()
    End Sub
End Class