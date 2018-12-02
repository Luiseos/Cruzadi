Public Class CambiarContraseña
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Atras.Attributes.Add("onclick", "history.back(); return false;")
    End Sub

    Private Sub Btnguardar_ServerClick(sender As Object, e As EventArgs) Handles BtnGuardar.ServerClick
        Try
            fila = Cls_Query.dt("select COUNT(Usuario),count(Contraseña) from Cruzadi.TBL_REG_USUARIO where USUARIO='" & NombreU.ToString & "' and Contraseña='" & Encriptacion.Encriptar(txtcontraseña.Value) & "'")
            Usuario = fila.Rows.Item(0).Item(0).ToString
            fila2 = Cls_Query.dt("Select  Valor FROM Cruzadi.tbl_parametros WHERE Parametro='Admin_Parametro_Tamano_Contrasena'")
            TamañoContraseña = CInt(fila2.Rows.Item(0).Item(0).ToString)

            If txtccontraseña.Value.Length = CInt(TamañoContraseña.ToString) Then

                Contraseñar = txtccontraseña.Value

                If CInt(Usuario) = 0 Then

                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Contraseña de usuario no existe ');</script>")
                Else
                    If ValidarContraseña(txtccontraseña.Value) = True Then
                        Actualizar("Cruzadi.tbl_reg_usuario", "contraseña='" & Encriptacion.Encriptar(txtccontraseña.Value) & "'", "Usuario='" & NombreU.ToString & "'")

                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Contraseña Actualizada Exitosamente');</script>")

                        mytrans("C")
                        Conexion.Cerrar_BD()

                        Response.Redirect("/Login.aspx")

                    Else

                        ' Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Compruebe que su nueva contraseña, cumpla con los requerimientos adecuados');</script>")
                        ' minimos Caracteres especiales:'" & parametroCaracter.ToString & "' Mayusculas minimo: '" & parametroMayus.ToString & "' Minuscula minimo: '" & parametroMayus.ToString & "' Numeros: '" & ParametroNumeros.ToString & "' con el tamaño adecuado de: '" & TamañoContraseña.ToString & "'
                        CstContraseñaRecu.Text = " Compruebe que su nueva contraseña, tenga al menos '" & parametroCaracter.ToString & "' Caracter especiales, '" & parametroMayus.ToString & "' Mayusculas , '" & parametroMayus.ToString & "' Minuscula ,  '" & ParametroNumeros.ToString & "' Numeros, con el tamaño adecuado de: '" & TamañoContraseña.ToString & "'"
                        CstContraseñaRecu.IsValid = txtccontraseña.Value = ""
                    End If
                End If
            Else
                CstContraseñaRecu.Text = "Contraseña no cumple con el tamaño adecuado, el tamaño adecuado es de :   '" & TamañoContraseña.ToString & "' Caracteres."
                CstContraseñaRecu.IsValid = txtccontraseña.Value = ""
            End If

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub


End Class