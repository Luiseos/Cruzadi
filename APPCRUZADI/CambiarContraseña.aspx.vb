Public Class CambiarContraseña
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conexion.conectar("127.0.0.1", "Cruzadi")
        Conexion.Cerrar_BD()
    End Sub

    Private Sub Btnguardar_ServerClick(sender As Object, e As EventArgs) Handles Btnguardar.ServerClick
        fila = Cls_Query.dt("select COUNT(Usuario) from TBL_REG_USUARIO where USUARIO= '" & txtusuario.Value & "' ")
        Usuario = fila.Rows.Item(0).Item(0).ToString

        If CInt(Usuario) = 0 Then

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Usuario no existe ');</script>")
        Else
            If ValidarContraseña(txtncontraseña.Value) = True Then
                Actualizar("tbl_reg_usuario", "contrasena='" & txtncontraseña.Value & "'", "Usuario='" & txtusuario.Value & "'")
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Campo Actualizado Exitosamente');</script>")
            Else
                'MsgBox("Compruebe que su nueva contraseña cumple con los requerimientos adecuados")
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Compruebe que su nueva contraseña cumple con los requerimientos adecuados');</script>")

            End If
        End If
    End Sub

End Class