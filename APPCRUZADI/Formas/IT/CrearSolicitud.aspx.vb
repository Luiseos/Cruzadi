Public Class CrearSolicitud
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (IsPostBack = False) Then
                cbtipogestion.DataSource = Cls_Query.dt("SELECT * FROM Cruzadi.tbl_gestion_it ")
                cbtipogestion.DataTextField = "descripcion_gestion"
                cbtipogestion.DataValueField = "gestion_IT_id"
                cbtipogestion.DataBind()
                txtnombreusuario.Value = NombreU.ToString
            End If
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    Private Sub btnAgregar_ServerClick(sender As Object, e As EventArgs) Handles btnAgregar.ServerClick
        Try
            If TxtDescripcion.Value <> Nothing Then
                Insert("cruzadi.tbl_it_soporte(fecha_entrada,estado_IT_id,caso_it,gestion_IT_id,usuario_id)",
"GETDATE(),1,'" & UCase(TxtDescripcion.Value) & "','" & cbtipogestion.SelectedIndex + 1 & "','" & ID_Usuario.ToString & "'")
                event_bitacora(CInt(ID_Usuario), 7, "AGREGO LA DESCRIPCION DE EL CASO  IT: '" & UCase(TxtDescripcion.Value) & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")
                TxtDescripcion.Value = Nothing
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos sin completar');</script>")
            End If


        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
End Class