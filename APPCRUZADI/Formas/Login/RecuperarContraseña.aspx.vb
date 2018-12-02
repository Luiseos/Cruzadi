Public Class RecuperarContraseña
    Inherits System.Web.UI.Page
    Private Sub btncorreo_ServerClick(sender As Object, e As EventArgs) Handles BtnCorreo.ServerClick
        Response.Redirect("RecuperacionViaCorreo.aspx?usuario=" + txtusuario.Value)
    End Sub

    Private Sub btnpregunta_ServerClick(sender As Object, e As EventArgs) Handles btnpregunta.ServerClick
        Response.Redirect("RecuperacionViaPregunta.aspx?Usuario=" + txtusuario.Value)

    End Sub
End Class