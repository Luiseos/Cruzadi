Public Class ConfiguracionPregunta
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (IsPostBack = False) Then



            cbPreg.DataSource = Cls_Query.dt("SELECT * FROM  Cruzadi.tbl_pregunta ")
            cbPreg.DataTextField = "Pregunta"
            cbPreg.DataValueField = "Pregunta_id"
            cbPreg.DataBind()
        End If

    End Sub

    'Private Sub btnEliminar1_Click(sender As Object, e As EventArgs) Handles btnEliminar1.Click
    '    Try

    '        If TxtRespuespreg.Value <> Nothing And CInt(cbPreg.Value) > 0 Then
    '            fila = Cls_Query.dt("Select Count(pregunta_id) from tbl_pregunta_usuario where pregunta_id='" & cbPreg.Value & "' and usuario_id='" & ID_Usuario.ToString & "' and respuesta='" & TxtRespuespreg.Value & "'")
    '            existe = fila.Rows.Item(0).Item(0).ToString
    '            If CInt(existe) > 0 Then
    '                delete("TBL_Pregunta_usuario", "pregunta_id='" & cbPreg.Value & "'")
    '                mytrans("C")
    '                Conexion.Cerrar_BD()
    '                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Elimino Correctamente.');</script>")
    '            Else
    '                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se puede eliminar pregunta , Respuesta no Coincide.');</script>")

    '            End If
    '        Else
    '                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


    '        End If



    '    Catch ex As Exception
    '        mytrans("R")
    '        ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
    '        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
    '    Finally
    '        Conexion.Cerrar_BD()

    '    End Try

    'End Sub


    Private Sub btnguardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick
        Try
            If TxtRespuespreg.Value <> Nothing And CInt(cbPreg.Value) >= 0 Then
                fila = Cls_Query.dt("Select Count(pregunta_id) from Cruzadi.tbl_pregunta_usuario where pregunta_id='" & cbPreg.Value & "' and usuario_id='" & ID_Usuario.ToString & "'")
                existe = fila.Rows.Item(0).Item(0).ToString
                If CInt(existe) = 1 Then
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos esta pregunta ya la tienes agregada');</script>")
                Else
                    Insert("Cruzadi.TBL_Pregunta_Usuario(Respuesta,usuario_id,Pregunta_id)", "'" & UCase(TxtRespuespreg.Value) & "','" & ID_Usuario.ToString & "','" & cbPreg.Value & "'")
                    mytrans("C")

                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")

                End If

            Else
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


            End If

        Catch ex As Exception
            mytrans("R")
            Response.Write("Ocurrio un Error de exepcion llama al Administrador")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    Private Sub btnmodificar_ServerClick(sender As Object, e As EventArgs) Handles btnmodificar.ServerClick

        Try
            If TxtRespuespreg.Value <> Nothing And CInt(cbPreg.Value) > 0 Then

                Actualizar("Cruzadi.tbl_Pregunta_Usuario", " Respuesta='" & UCase(TxtRespuespreg.Value) & "'", "pregunta_id='" & cbPreg.Value & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Modifico Correctamente.');</script>")

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