Public Class Pregunta__segurida
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conexion.conectar("127.0.0.1", "Cruzadi")
        Conexion.Cerrar_BD()

        Cb_Pregunta.DataSource = Cls_Query.dt("SELECT * FROM `tbl_preguntas` ")
        'Cb_Pregunta.DisplayMember = "Preguntas"
        'Cb_Pregunta.ValueMember = "Pregunta_ID"

        Cb_Pregunta.DataTextField = "Pregunta"
        Cb_Pregunta.DataValueField = "ID_Pregunta"
        Cb_Pregunta.DataBind()

    End Sub

    Private Sub BtnGuardar_ServerClick(sender As Object, e As EventArgs) Handles BtnGuardar.ServerClick
        'fila = Cls_Query.dt("select COUNT(Usuario) from TBL_REG_USUARIO where USUARIO= '" & TxtUsuario.Value & "' ")
        'SELECT * FROM `tbl_preguntas_usuario`
        MsgBox(Cb_Pregunta.Value)

    End Sub
End Class