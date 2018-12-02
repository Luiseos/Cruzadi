Public Class Pagos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        ' Conexion.conectar("SOPORTE\SQLSERVER2014", "Cruzadi")
        Conexion.conectar("DESKTOP-8PU4GG0\SQLEXPRESS", "Cruzadi")
        Conexion.Cerrar_BD()
        'datos de recibir de Buscar FActuras
        Try
            'If (Request.Params("Num_ticket") <> Nothing) And (Request.Params("Usuario") <> Nothing) And (Request.Params("Gestion") <> Nothing) And (Request.Params("Caso") <> Nothing) And (Request.Params("Estado") <> Nothing) Then
            '    TxtTicket.Value = Request.Params("Num_ticket")
            '    txtnombreusuario.Value = Request.Params("Usuario")
            '    txtgestion.Value = Request.Params("Gestion")
            '    TxtDescripcion.Value = Request.Params("Caso")
            '    TxtEstado.Value = Request.Params("Estado")

            'End If



        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try


    End Sub

    Private Sub BtnGuardar_ServerClick(sender As Object, e As EventArgs) Handles BtnGuardar.ServerClick
        Try
            If txtfactura.Value <> Nothing And txtfolio.Value <> Nothing And txtSerie.Value <> Nothing Then
                'cbfpago.SelectedIndex
                'cbpos.SelectedIndex
                'txtSubtotalBd.Value
                'txtisv15BD.Value
                'txtisv18.Value
                'txtRetenciones.Value
                'txtdescuento8.Value
                'txtTotalBD.Value


            End If


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    Private Sub cbfpago_ServerChange(sender As Object, e As EventArgs) Handles cbfpago.ServerChange
        If cbfpago.SelectedIndex = 1 Then
            cbpos.Disabled = False

        End If
    End Sub
End Class