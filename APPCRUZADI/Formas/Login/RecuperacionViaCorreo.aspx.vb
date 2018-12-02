
Public Class RecuperacionViaCorreo
    Inherits System.Web.UI.Page

    Private Sub btnRecuperarcorreo_ServerClick(sender As Object, e As EventArgs) Handles btnRecuperarcorreo.ServerClick
        Try
            If (Request.Params("usuario") <> Nothing) Then

                NombreU = Request.Params("usuario")


            End If
            fila = Cls_Query.dt("select count(usuario) from Cruzadi.TBL_REG_USUARIO where USUARIO= '" & NombreU.ToString & "' ")
            Usuario = fila.Rows.Item(0).Item(0).ToString


            If CInt(Usuario) = 1 Then
                Try
                    fila = Cls_Query.dt("select count(email) from Cruzadi.TBL_REG_USUARIO where email= '" & txtcorreo.Value & "' ")
                    correo = fila.Rows.Item(0).Item(0).ToString

                    If CInt(correo) >= 1 Then
                        correousuario = txtcorreo.Value

                        Recualeatoria = crearpassword(CInt(ParametroTamañoContraseña()))
                        vacorreoparametro = Parametro_Correo()
                        vapuertocorreo = Parametroemailpuerto()
                        vaemailcontraseña = Parametro_Email_contraseña()
                        vaemailserver = PARAMETRO_SERVER_CORREO()
                        If Recualeatoria <> Nothing And vacorreoparametro <> Nothing And vapuertocorreo <> Nothing And vaemailcontraseña <> Nothing And vaemailserver <> Nothing Then
                            enviocorreo.enviarcorreo(correousuario, Recualeatoria, vacorreoparametro, vapuertocorreo, vaemailcontraseña, vaemailserver)
                            If errorserver <> "N" Then
                                ' Actualizar("cruzadi.Tbl_Reg_Usuario", "Contraseña='" & Encriptacion.Encriptar(Recualeatoria.ToString) & "'", "usuario='" & NombreU.ToString & "'")
                                Actualizar("cruzadi.tbl_reg_usuario", "Contraseña='" & Encriptacion.Encriptar(Recualeatoria.ToString) & "', Estado_usuario=4", "usuario='" & NombreU.ToString & "'")
                                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Su nueva contraseña ha sido enviado a su correo.');</script>")
                                mytrans("C")
                                Conexion.Cerrar_BD()
                                Response.Redirect("/login.aspx")
                            End If
                        Else
                                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Parametros de correo invalidos, favor contactese con el administrador');</script>")


                        End If

                    Else

                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos, direccion de correo erroneo.');</script>")

                    End If

                Catch ex As Exception

                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos, favor contacte con el administrador o vuelva a intentarlo.');</script>")

            End Try

        Else
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos, Este usuario no existe.');</script>")

               End If

        Catch ex As Exception
        mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
        Conexion.Cerrar_BD()

        End Try
    End Sub
End Class