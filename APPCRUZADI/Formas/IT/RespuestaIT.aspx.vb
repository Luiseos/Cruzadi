Public Class RespuestaIT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
            ' Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
            ' Conexion.Cerrar_BD()
            If (IsPostBack = False) Then


                If (Request.Params("Num_ticket") <> Nothing) And (Request.Params("Usuario") <> Nothing) And (Request.Params("Gestion") <> Nothing) And (Request.Params("Caso") <> Nothing) And (Request.Params("Estado") <> Nothing) Then
                    TxtTicket.Value = Request.Params("Num_ticket")
                    txtnombreusuario.Value = Request.Params("Usuario")
                    txtgestion.Value = Request.Params("Gestion")
                    TxtDescripcion.Value = Request.Params("Caso")
                    TxtEstado.Value = Request.Params("Estado")

                End If
                If TxtEstado.Value = "PENDIENTE" Then
                    btnProceso.Visible = True
                Else
                    btnProceso.Visible = False

                End If
                fila = Cls_Query.dt("select email from cruzadi.tbl_reg_usuario where  nombre_usuario='" & txtnombreusuario.Value & "' ")
                fila2 = Cls_Query.dt("select count(email) from cruzadi.tbl_reg_usuario where  nombre_usuario='" & txtnombreusuario.Value & "' ")


            End If

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnEnviar_ServerClick(sender As Object, e As EventArgs) Handles btnEnviar.ServerClick
        Try
            existe = fila2.Rows.Item(0).Item(0).ToString
            If CInt(existe) >= 1 Then
                correo = fila.Rows.Item(0).Item(0).ToString
                correousuario = correo
                vacorreoparametro = Parametro_Correo()
                vapuertocorreo = Parametroemailpuerto()
                vaemailcontraseña = Parametro_Email_contraseña()
                vaemailserver = PARAMETRO_SERVER_CORREO()
                If correousuario <> Nothing And vacorreoparametro <> Nothing And vapuertocorreo <> Nothing And vaemailcontraseña <> Nothing And vaemailserver <> Nothing And txtgestion.Value <> Nothing And TxtRespuesta.Value <> Nothing Then
                    enviocorreo.enviarcorreoSoporte(correousuario, vacorreoparametro, vapuertocorreo, vaemailcontraseña, vaemailserver, txtgestion.Value, TxtRespuesta.Value)
                    If errorserver <> "N" Then
                        Actualizar("cruzadi.tbl_it_soporte", "Estado_it_id=3,usuario_id_2='" & ID_Usuario & "',fecha_salida=getdate(),respuesta_soporte='" & UCase(TxtRespuesta.Value) & "'", "soporte_id='" & TxtTicket.Value & "'")
                        'evento
                        mytrans("C")
                        Conexion.Cerrar_BD()
                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Su Ticket Esta Finalizado.');</script>")
                        Response.Redirect("/Formas/IT/ITPrincipal.aspx")
                    End If

                End If

                Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Su ticket no puede estar en proceso ya que el usuario no tiene correo.');</script>")

            End If
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo enviar el correo');</script>")

        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnProceso_ServerClick(sender As Object, e As EventArgs) Handles btnProceso.ServerClick
        Try

            existe = fila2.Rows.Item(0).Item(0).ToString
            If CInt(existe) >= 1 Then
                correo = fila.Rows.Item(0).Item(0).ToString
                correousuario = correo
                vacorreoparametro = Parametro_Correo()
                vapuertocorreo = Parametroemailpuerto()
                vaemailcontraseña = Parametro_Email_contraseña()
                vaemailserver = PARAMETRO_SERVER_CORREO()
                If correousuario <> Nothing And vacorreoparametro <> Nothing And vapuertocorreo <> Nothing And vaemailcontraseña <> Nothing And vaemailserver <> Nothing And txtgestion.Value <> Nothing And TxtRespuesta.Value <> Nothing Then
                    enviocorreo.enviarcorreoSoporte(correousuario, vacorreoparametro, vapuertocorreo, vaemailcontraseña, vaemailserver, txtgestion.Value, TxtRespuesta.Value)
                    If errorserver <> "N" Then
                        Actualizar("cruzadi.tbl_it_soporte", "Estado_it_id=2,usuario_id_2='" & ID_Usuario & "',fecha_salida=getdate(),respuesta_soporte='" & UCase(TxtRespuesta.Value) & "'", "soporte_id='" & TxtTicket.Value & "'")
                        'evento
                        mytrans("C")
                        Conexion.Cerrar_BD()
                        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Su Ticket Esta en Proceso.');</script>")
                        Response.Redirect("/Formas/IT/ITPrincipal.aspx")
                    End If
                End If

                Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Su ticket no puede estar en proceso ya que el usuario no tiene correo.');</script>")

            End If
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo enviar el correo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub


End Class