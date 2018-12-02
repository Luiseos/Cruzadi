Public Class Principal
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS01", "Cruzadi")
        '      Conexion.conectar("SOPORTE\SQLSERVER2014", "Cruzadi")
        Conexion.Cerrar_BD()
    End Sub

End Class