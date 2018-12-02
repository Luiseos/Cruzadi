Public Class RecuperarContraseña
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conexion.conectar("127.0.0.1", "Cruzadi")
        Conexion.Cerrar_BD()


    End Sub

    Private Sub Btnaceptar1_ServerClick(sender As Object, e As EventArgs) Handles Btnaceptar1.ServerClick
        Try
            fila = Cls_Query.dt("select * from TBL_PREGUNTAs")
            preguntas = fila.Rows.Item(0).Item(0).ToString
            Cbpregunta.Value = preguntas
            With Cbpregunta

                Cbpregunta.DataTextField = "Pregunta"
                Cbpregunta.DataValueField = "ID_Pregunta"
                Cbpregunta.DataBind()


            End With
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos, favor contacte con el administrador o vuelva a intentarlo.');</script>")

        End Try
    End Sub

    Private Sub Btnaceptar_ServerClick(sender As Object, e As EventArgs) Handles Btnaceptar.ServerClick
        Try
            fila = Cls_Query.dt("select email from TBL_REG_USUARIO where USUARIO= '" & txtusuario1.Value & "' ")
            correo = fila.Rows.Item(0).Item(0).ToString
            txtcorreo.Value = correo
        Catch ex As Exception

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos, favor contacte con el administrador o vuelva a intentarlo.');</script>")

        End Try
        'aqui el codigo del correo pasar de parametro la variable correo
    End Sub

    Private Sub txtusuario_ServerChange(sender As Object, e As EventArgs) Handles txtusuario.ServerChange

        If txtusuario.Value = Nothing Then
            Btncorreo.Disabled = True
            Btnpregunta.Disabled = True
        Else
            Btncorreo.Disabled = False
            Btnpregunta.Disabled = False
        End If
    End Sub
End Class