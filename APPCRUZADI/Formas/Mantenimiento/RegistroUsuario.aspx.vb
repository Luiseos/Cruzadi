Public Class RegistroManual
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (IsPostBack = False) Then
                obid = 1
                Bitacora(CInt(ID_Usuario), obid, "INGRESO A REGISTRO DE USUARIO")

                CbRol.DataSource = Cls_Query.dt("select * from Cruzadi.tbl_Roles")
                CbRol.DataTextField = "Rol"
                CbRol.DataValueField = "rol_ID"
                CbRol.DataBind()
                CbEstado.SelectedIndex = 2

                If PA(obid) = True Or PI(obid) = True Then
                    BtnGuardar.Visible = True
                    BtnCancelar.Visible = True
                ElseIf PC(obid) = False Then
                    Response.Redirect("/inicio.aspx")

                End If

            End If

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Error al cargar la pagina.');</script>")


        Finally
            Conexion.Cerrar_BD()

        End Try



    End Sub

    Private Sub BtnGuardar_ServerClick(sender As Object, e As EventArgs) Handles BtnGuardar.ServerClick
        Try
            fila = Cls_Query.dt("Select  Valor FROM Cruzadi.tbl_parametros WHERE Parametro='Admin_Parametro_Tamano_Contrasena'")
            TamañoContraseña = CInt(fila.Rows.Item(0).Item(0).ToString)

            If CbEstado.SelectedIndex >= 0 And TxtUsuarioR.Value <> Nothing And TxtNombre.Value <> Nothing And TxtContraseñaConfirmar.Value <> Nothing And
                TxtEmail.Value <> Nothing And CbRol.SelectedIndex >= 0 And Vencimiento.Value <> Nothing Then

                If TxtContraseñaConfirmar.Value.Length = CInt(TamañoContraseña.ToString) Then

                    Contraseñar = TxtContraseñaR.Value


                    If ValidarContraseña(Contraseñar) = True Then
                        fila = Cls_Query.dt("select count(Usuario) from Cruzadi.tbl_Reg_Usuario where Usuario='" & TxtUsuarioR.Value & "'")
                        existe = fila.Rows.Item(0).Item(0).ToString

                        If CInt(existe) = 1 Then


                            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos este Usuario ya esta registrado Intente con otro');</script>")

                            TxtNombre.Focus()
                            Conexion.Cerrar_BD()
                        Else
                            Insert("Cruzadi.TBL_Reg_Usuario(usuario,Nombre_Usuario,Estado_Usuario,Contraseña,Fecha_Vencimiento,Email,Rol_id)", "'" & UCase(TxtUsuarioR.Value) & "',
                              '" & UCase(TxtNombre.Value) & "','" & CbEstado.SelectedIndex & "','" & Encriptacion.Encriptar(TxtContraseñaR.Value) & "','" & Vencimiento.Value & "','" & UCase(TxtEmail.Value) & "', '" & CbRol.SelectedIndex + 1 & "'")

                            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Usuario Registrado Correctamente.');</script>")
                            Bitacora(CInt(ID_Usuario), obid, "INSERTO EL USUARIO: '" & TxtUsuarioR.Value & "'")
                            mytrans("C")
                            Conexion.Cerrar_BD()
                            TxtContraseñaConfirmar.Value = Nothing
                            TxtContraseñaR.Value = Nothing
                            TxtEmail.Value = Nothing
                            TxtNombre.Value = Nothing
                            TxtUsuarioR.Value = Nothing

                        End If

                    Else
                        CstContraseñaR.Text = "Contraseña Invalida no cumple con los requerimientos adecuados. "
                        CstContraseñaR.IsValid = TxtContraseñaR.Value = ""
                        CstContraseñaR.IsValid = TxtContraseñaConfirmar.Value = ""

                    End If

                Else
                    '   Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Contraseña no cumple con el tamaño adecuado, el tamaño adecuado es de :   '" & TamañoContraseña.ToString & "' Caracteres. ');</script>")
                    CstContraseñaR.Text = "Contraseña no cumple con el tamaño adecuado, el tamaño adecuado es de :   '" & TamañoContraseña.ToString & "' Caracteres."
                    CstContraseñaR.IsValid = TxtContraseñaR.Value = ""
                End If
            Else

                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


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