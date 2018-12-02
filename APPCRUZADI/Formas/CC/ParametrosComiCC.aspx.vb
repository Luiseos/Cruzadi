Public Class ParametrosComiCC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub BtnModificar_ServerClick(sender As Object, e As EventArgs) Handles BtnModificar.ServerClick
        Try
            If TxtPorComision.Value <> Nothing And TxtPorCredito.Value <> Nothing And TxtPorFacturacion.Value <> Nothing Then
                Actualizar("cruzadi.Tbl_Parametro_Credito", "Porcentaje_Comision_Cre='" & TxtPorComision.Value & "',Porcentaje_Credito='" & TxtPorCredito.Value & "',Porcentaje_facturacion='" & TxtPorFacturacion.Value & "'", "Parametro_credito_id=1")
                event_bitacora(CInt(ID_Usuario), 7, "MODIFICO LOS PARAMETROS DE CREDITO")

                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se ha Modificado Parametros de Creditos.');</script>")
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