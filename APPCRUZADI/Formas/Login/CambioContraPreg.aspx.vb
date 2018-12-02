Public Class CambioContraPreg
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Atras.Attributes.Add("onclick", "history.back(); return false;")
    End Sub

    Private Sub BtnGuardar_ServerClick(sender As Object, e As EventArgs) Handles BtnGuardar.ServerClick
        Try
            fila = Cls_Query.dt("Select  Valor FROM Cruzadi.tbl_parametros WHERE Parametro='Admin_Parametro_Tamano_Contrasena'")
            TamañoContraseña = CInt(fila.Rows.Item(0).Item(0).ToString)

            If txtccontraseña.Value.Length = CInt(TamañoContraseña.ToString) Then

                Contraseñar = txtccontraseña.Value


                If ValidarContraseña(txtccontraseña.Value) = True Then
                    Actualizar("Cruzadi.tbl_reg_usuario", "contraseña='" & Encriptacion.Encriptar(txtccontraseña.Value) & "',Estado_usuario=1", "Usuario='" & NombreU.ToString & "'")

                    mytrans("C")
                    Conexion.Cerrar_BD()

                    Response.Redirect("/Login.aspx")
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Contraseña Actualizada Exitosamente');</script>")

                Else

                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Compruebe que su nueva contraseña, cumpla con los requerimientos adecuados');</script>")

                End If
            Else
                cstContraseñaPreg.Text = "Contraseña no cumple con el tamaño adecuado, el tamaño adecuado es de :   '" & TamañoContraseña.ToString & "' Caracteres."
                cstContraseñaPreg.IsValid = txtccontraseña.Value = ""
            End If



        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
End Class