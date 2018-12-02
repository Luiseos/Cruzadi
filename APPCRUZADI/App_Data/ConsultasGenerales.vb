Public Class ConsultasGenerales
    Public Sub select_Objetos()
        Try

            ' creacionobjetos.gvobjetos.datasource = Cls_Query.dt("")
            'Principal.creacionobjetos.gvobjetos.datasource = Cls_Query.dt("")

            'Sala.dtg_Salas.DataSource = Cls_Query.dt("Select * From sala")
            'Sala.dtg_Salas.ClearSelection()
            Conexion.Cerrar_BD()

        Catch ex As Exception
            'MessageBox.Show("Error al actualizar el datagridview")
        Finally
            Conexion.Cerrar_BD()
        End Try
    End Sub
End Class
