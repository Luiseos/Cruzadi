Public Class WebForm4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conexion.conectar("127.0.0.1", "Cruzadi")
        Conexion.Cerrar_BD()


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        GridView1.DataSource = Cls_Query.dt("select * from TBL_REG_USUARIO")
        GridView1.DataBind()



    End Sub
End Class