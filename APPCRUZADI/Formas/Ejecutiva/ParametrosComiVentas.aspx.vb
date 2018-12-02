Public Class ParametrosComiVentas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub BtnModificar_ServerClick(sender As Object, e As EventArgs) Handles BtnModificar.ServerClick
        Try
            If txtPorcentajeVentas.Value <> Nothing And txtPorcentajeAceptable.Value <> Nothing Then
                Actualizar("Cruzadi.tbl_Parametro_venta", "Porcentaje_venta='" & txtPorcentajeVentas.Value & "',Nota_aceptable='" & txtPorcentajeAceptable.Value & "'", "parametro_venta_id=1")
                event_bitacora(CInt(ID_Usuario), 7, "MODIFICO LOS PARAMETROS DE VENTAS")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se ha Modificado Parametros de Ventas.');</script>")
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tiene Campos por rellenar, favor verificar. ');</script>")

            End If

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
End Class