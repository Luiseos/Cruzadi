Public Class Pregunta__segurida
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Cb_Pregunta.DataSource = Cls_Query.dt("SELECT * FROM Cruzadi.tbl_pregunta ")
        Cb_Pregunta.DataTextField = "Pregunta"
        Cb_Pregunta.DataValueField = "Pregunta_id"
        Cb_Pregunta.DataBind()

    End Sub

    Private Sub BtnGuardar_ServerClick(sender As Object, e As EventArgs) Handles BtnGuardar.ServerClick
        Try
            If Estado = 1 Then
                If (Request.Params("usuario") <> Nothing) Then

                    NombreU = Request.Params("Usuario")


                End If
                fila = Cls_Query.dt("select max(pregunta_contestada) from Cruzadi.tbl_reg_usuario")
                max = CInt(fila.Rows.Item(0).Item(0).ToString)

                Insert("Cruzadi.tbl_pregunta_usuario(Pregunta_id,Usuario_ID,Respuesta)", "'" & Cb_Pregunta.SelectedIndex + 1 & "' ,'" & ID_Usuario.ToString & "','" & TxtRespuesta.Value & "'")
                Actualizar("Cruzadi.tbl_reg_usuario", "Pregunta_contestada='" & max.ToString & "'+1", "usuario='" & NombreU.ToString & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se ha registrado su pregunta de seguridad Correctamente ');</script>")

            Else
                Insert("Cruzadi.tbl_pregunta_usuario(Pregunta_id,Usuario_ID,Respuesta)", "'" & Cb_Pregunta.SelectedIndex + 1 & "' ,'" & ID_Usuario.ToString & "','" & TxtRespuesta.Value & "'")
                Actualizar("Cruzadi.tbl_Reg_Usuario", "Estado_Usuario=1,Pregunta_contestada=1", "usuario='" & NombreU.ToString & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se ha registrado su pregunta de seguridad Correctamente ');</script>")
                Response.Redirect("/Inicio.aspx")
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