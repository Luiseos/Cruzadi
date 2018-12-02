Public Class Login
    Inherits System.Web.UI.Page

    Private Sub BtnEntrar_ServerClick(sender As Object, e As EventArgs) Handles BtnEntrar.ServerClick
        Try


            fila = Cls_Query.dt("select COUNT(Usuario),usuario ,usuario_id from Cruzadi.TBL_REG_USUARIO where USUARIO= '" & TxtUsuario.Value & "' GROUP BY usuario_id,usuario  ")
            fila2 = Cls_Query.dt(" select count(Contraseña)  from Cruzadi.TBL_REG_USUARIO where Contraseña= '" & Encriptacion.Encriptar(TxtContraseña.Value) & "'")
            fila3 = Cls_Query.dt(" select Estado_Usuario from Cruzadi.TBL_REG_USUARIO  where Usuario= '" & TxtUsuario.Value & "'")
            fila4 = Cls_Query.dt("SELECT Valor FROM Cruzadi.TBL_PARAMETROS WHERE Parametro='ADMIN_INTENTO_VALIDOS'")
            Pr_Intento = CInt(fila4.Rows.Item(0).Item(0).ToString)
            Usuario = fila.Rows.Item(0).Item(0).ToString
            NombreU = fila.Rows.Item(0).Item(1).ToString
            ID_Usuario = fila.Rows.Item(0).Item(2).ToString
            Contraseña = fila2.Rows.Item(0).Item(0).ToString()
            Estado = CInt(fila3.Rows.Item(0).Item(0).ToString())


            If CInt(Usuario) = 1 And CInt(Contraseña) >= 1 And CInt(Estado) = 1 Then
                fila = Cls_Query.dt("SELECT DATEDIFF(day,SYSDATETIME(),fecha_Vencimiento) from Cruzadi.tbl_reg_usuario where usuario_id='" & ID_Usuario.ToString & "'")
                vencimiento = CInt(fila.Rows.Item(0).Item(0).ToString)

                If vencimiento <= 0 Then
                    Actualizar("Cruzadi.tbl_reg_usuario", "Estado_usuario=0", "usuario_id='" & ID_Usuario.ToString & "'")
                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo Sentimos su usuario se ha vencido y bloqueado favor llamar al Administrador');</script>")
                Else
                    ultima_conexion()
                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Response.Redirect("/Inicio.aspx")
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Bien Bienvenido a Cruzadi : " & TxtUsuario.Value & " ');</script>")

                End If


                'Else
                '    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Bien Bienvenido a Cruzadi : " & TxtUsuario.Value & " ');</script>")
                '    ultima_conexion()
                '    mytrans("C")
                '    Response.Redirect("/Formas\Login\Perfil\CambiarContraseña.aspx")
                '    Conexion.Cerrar_BD()
                'End If
            Else

                If CInt(Usuario) = 1 And CInt(Contraseña) >= 1 And CInt(Estado) = 0 Then

                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos el usuario : " & TxtUsuario.Value & " lo tiene Bloqueado contactese con el Administrador' );</script>")
                    Conexion.Cerrar_BD()

                Else
                    If CInt(Usuario) = 1 And CInt(Contraseña) >= 1 And CInt(Estado) = 2 Then
                        Actualizar("Cruzadi.TBL_REG_Usuario", "Primer_Ingreso=getdate()", "usuario_id='" & ID_Usuario.ToString & "'")
                        ultima_conexion()
                        mytrans("C")
                        Conexion.Cerrar_BD()
                        Response.Redirect("Formas/Login/Pregunta_seguridad.aspx")

                    ElseIf CInt(Usuario) = 1 And CInt(Contraseña) >= 1 And CInt(Estado) = 3 Then
                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos el usuario : " & TxtUsuario.Value & " lo tiene inactivo contactese con el Administrador' );</script>")
                    ElseIf CInt(Usuario) = 1 And CInt(Contraseña) >= 1 And CInt(Estado) = 4 Then
                        Response.Redirect("/formas/Login/CambioContrapreg.aspx")

                    ElseIf CInt(Usuario) = 1 And CInt(Contraseña) = 0 Then

                        If contador < Pr_Intento Then

                            ' Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Error en la contraseña, Intento : " & contador + 1 & "');</script>")
                            CstContraseña.Text = "Error en la contraseña, Intento " & contador + 1 & ""
                            CstContraseña.IsValid = TxtContraseña.Value = ""
                            Conexion.Cerrar_BD()
                            contador = contador + 1
                        Else
                            Actualizar("Cruzadi.tbl_reg_usuario", "Estado_Usuario =0", "Usuario='" & TxtUsuario.Value & "'")
                            mytrans("C")
                            '            Limpiartxt(Me)
                            contador = 0
                            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos te Exedistes el limite de intentos, Usuario Bloqueado , favor contacte con el administrador.');</script>")
                            Conexion.Cerrar_BD()
                        End If


                    Else
                        contador = contador + 1

                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('!!!!Usuario y Contraseña Incorrecta!!!!');</script>")

                        Conexion.Cerrar_BD()
                    End If
                End If
            End If



        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If ParametroAutoregistro() = 1 Then
                AutoRegistro.Visible = True
            Else
                AutoRegistro.Visible = False

            End If
        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador problema en parametro de autoregistro');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

End Class