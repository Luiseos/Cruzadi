Public Class Modal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub BtnGuardar_ServerClick(sender As Object, e As EventArgs) Handles BtnGuardar.ServerClick
        Try
            TxtContraseñaR.MaxLength = 8
            Contraseñar = TxtContraseñaR.Value


            If ValidarContraseña(Contraseñar) = True Then

                'CstContraseñaR.Text = "Contraseña Valida"
                'CstContraseñaR.IsValid = CBool(TxtContraseñaR.Value)
                'Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Contraseña Correcta ');</script>")
                fila = Cls_Query.dt("select count(Usuario) from tbl_Reg_Usuario where Usuario='" & TxtUsuarioR.Value & "'")
                existe = fila.Rows.Item(0).Item(0).ToString


                If CInt(existe) = 1 Then
                    ' MessageBox.Show("Lo sentimos Este Correo ya esta registrado", "Correo Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Limpiartxt(Me)
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos este Correo ya esta registrado ');</script>")
                    TxtNombre.Focus()
                    Conexion.Cerrar_BD()

                Else



                    '' Toma el numero de usuario de la tabla usuario
                    'max = Cls_Query.dt("select Max(Usuario_ID)+1 from usuario")
                    'Num_Usuario = max.Rows.Item(0).Item(0).ToString

                    ' Insert("Usuario (Num_Usuario,Correo,Contraseña,Fecha_Creacion,Estado)", "'" & Num_Usuario.ToString & "','" & Txt_Correo.Text & "','" & Encriptacion.Encriptar(Txt_Contraseña.Text) & "',SYSDATETIME (),'ACTIVO'")
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('!!!!Felicidades has sido registrado!!! ');</script>")

                    '  mytrans("C")
                    ' MessageBox.Show("!!!!Felicidades has sido registrado en nuestras Salas de Cine!!!!", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Conexion.Cerrar_BD()

                    'Limpiartxt(Me)
                    'EP_Correo.SetError(Txt_Correo, "")
                    'EP_Contraseña.SetError(Txt_Contraseña, "")
                    'EP_Confirmar.SetError(Txt_Confirmar, "")

                    'Pb_3.Visible = False

                    TxtNombre.Focus()
                End If
            Else
                CstContraseñaR.Text = "Contraseña Invalida"
                CstContraseñaR.IsValid = TxtContraseñaR.Value = ""
                CstContraseñaR.IsValid = TxtContraseñaConfirmar.Value = ""
                ' Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Contraseña Invalida favor verificar que tenga Mayuscula,Minuscula,Numero y un caracter especial, la contraseña debe de ser de 8 Caracteres. ');</script>")

            End If

            ' Else
            ' Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tienes errores en los datos favor verificar');</script>")



        Catch ex As Exception
            mytrans("R")
            '  MessageBox.Show("Ocurrio un Error de exepcion llama al Administrador")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador');</script>")

            Conexion.Cerrar_BD()
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

End Class