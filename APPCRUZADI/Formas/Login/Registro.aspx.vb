Public Class Registro
    Inherits System.Web.UI.Page


    Private Sub BtnGuardar_ServerClick(sender As Object, e As EventArgs) Handles BtnGuardar.ServerClick

        Try
            fila = Cls_Query.dt("Select  Valor FROM Cruzadi.tbl_parametros WHERE Parametro='Admin_Parametro_Tamano_Contrasena'")
            TamañoContraseña = CInt(fila.Rows.Item(0).Item(0).ToString)

            If TxtContraseñaConfirmar.Value.Length = CInt(TamañoContraseña.ToString) Then

                Contraseñar = TxtContraseñaR.Value


                If ValidarContraseña(Contraseñar) = True Then
                    fila = Cls_Query.dt("select count(Usuario) from Cruzadi.tbl_Reg_Usuario where Usuario='" & TxtUsuarioR.Value & "'")
                    existe = fila.Rows.Item(0).Item(0).ToString


                    If CInt(existe) = 1 Then
                        'Limpiartxt(Me)

                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos este Usuario ya esta registrado');</script>")

                        TxtNombre.Focus()
                        Conexion.Cerrar_BD()

                    Else
                        fila2 = Cls_Query.dt("SELECT DATEADD(day,cast((select valor from Cruzadi.tbl_parametros where parametro ='Parametro_Vencimiento_usuario') as int),GETDATE()), getdate()")
                        vencimiento1 = CDate(fila2.Rows.Item(0).Item(0).ToString)
                        Insert("Cruzadi.tbl_reg_usuario(Nombre_Usuario,Usuario,Email,Contraseña,Estado_Usuario,Fecha_vencimiento)", "'" & UCase(TxtNombre.Value) & "',
                       '" & UCase(TxtUsuarioR.Value) & "','" & TxtEmail.Value & "','" & Encriptacion.Encriptar(TxtContraseñaConfirmar.Value) & "','3','" & vencimiento1.ToString & "'")
                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('!!!!Felicidades has sido registrado!!! ');</script>")

                        mytrans("C")
                        Conexion.Cerrar_BD()
                        Response.Redirect("/Login.aspx")
                        'Limpiartxt(Me)
                        TxtNombre.Focus()
                    End If
                Else
                    CstContraseñaR.Text = "Contraseña Invalida no cumple con los requerimientos adecuados. "
                    CstContraseñaR.IsValid = TxtContraseñaR.Value = ""
                    CstContraseñaR.IsValid = TxtContraseñaConfirmar.Value = ""
                    '  Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Contraseña Invalida favor verificar que tenga Mayuscula,Minuscula,Numero y caracter especial, la contraseña debe de ser de '" & TamañoContraseña.ToString & "' Caracteres. ');</script>")

                End If
            Else
                '   Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Contraseña no cumple con el tamaño adecuado, el tamaño adecuado es de :   '" & TamañoContraseña.ToString & "' Caracteres. ');</script>")
                CstContraseñaR.Text = "Contraseña no cumple con el tamaño adecuado, el tamaño adecuado es de :   '" & TamañoContraseña.ToString & "' Caracteres."
                CstContraseñaR.IsValid = TxtContraseñaR.Value = ""
            End If

            ' Else
            ' Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tienes errores en los datos favor verificar');</script>")



        Catch ex As Exception
            mytrans("R")
            ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub


End Class