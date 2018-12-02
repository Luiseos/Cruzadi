Public Class RecuperacionViaPregunta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            If (IsPostBack = False) Then

                cbPreg.DataSource = Cls_Query.dt("SELECT * FROM Cruzadi.tbl_pregunta")
                cbPreg.DataTextField = "Pregunta"
                cbPreg.DataValueField = "pregunta_id"
                cbPreg.DataBind()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRecuperarPreg_ServerClick(sender As Object, e As EventArgs) Handles btnRecuperarPreg.ServerClick
        Try
            If cbPreg.SelectedIndex >= 0 And TxtRespuespreg.Value <> Nothing Then

                If (Request.Params("usuario") <> Nothing) Then

                    NombreU = Request.Params("usuario")


                End If

                fila = Cls_Query.dt("select count(usuario) from Cruzadi.TBL_REG_USUARIO where USUARIO= '" & NombreU.ToString & "' ")
                Usuario = fila.Rows.Item(0).Item(0).ToString

                If CInt(Usuario) = 1 Then


                    fila3 = Cls_Query.dt("select count(Respuesta) from Cruzadi.tbl_pregunta_usuario pu , Cruzadi.tbl_reg_usuario u, Cruzadi.tbl_pregunta pr where  pu.pregunta_id=pr.pregunta_id and pu.usuario_id=u.usuario_id and respuesta='" & TxtRespuespreg.Value & "' and u.usuario='" & NombreU.ToString & "'")
                    Respuesta = fila3.Rows.Item(0).Item(0).ToString
                    If CInt(Respuesta) = 1 Then
                        Response.Redirect("/formas/Login/CambioContrapreg.aspx") 'mandar a cambiar contraseña
                    Else
                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos, esta Respuesta no existe.');</script>")

                    End If



                Else
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos, Este usuario no existe.');</script>")

                End If
            End If
        Catch ex As Exception
            mytrans("R")
            ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
End Class