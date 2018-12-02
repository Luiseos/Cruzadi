Public Class EstadoIT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Conexion.conectar(" SOPORTE\ SQLSERVER2014", "Cruzadi")
            '    Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")

            'Conexion.Cerrar_BD()

            If (IsPostBack = False) Then
                SelectGrillaEstadoIt()
            End If
            lblEstados.Text = CType(lblestadostotales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('No se pudo cargar bien los datos.');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnguardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick
        Try
            If txtDescripcion.Value <> Nothing Then
                fila = Cls_Query.dt("SELECT COUNT(descripcion_estado) FROM Cruzadi.tbl_estado_it WHERE descripcion_estado='" & txtDescripcion.Value & "'")
                existe = fila.Rows.Item(0).Item(0).ToString
                If CInt(existe) = 1 Then
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Estado ya existe en la base.');</script>")
                Else

                    Insert("Cruzadi.tbl_estado_it(descripcion_estado)", "'" & UCase(txtDescripcion.Value) & "'")
                    event_bitacora(CInt(ID_Usuario), 7, "AGREGO LA DESCRIPCION DEL ESTADO IT: '" & UCase(txtDescripcion.Value) & "'")
                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")
                End If
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos sin completar');</script>")
            End If
            SelectGrillaEstadoIt()
            lblEstados.Text = CType(lblestadostotales(), String)



        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub BtnModificar_ServerClick(sender As Object, e As EventArgs) Handles BtnModificar.ServerClick
        Try
            If txtDescripcion.Value <> Nothing Then
                Actualizar("Cruzadi.tbl_estado_it", "Descripcion_Estado='" & UCase(txtDescripcion.Value) & "'", "Estado_IT_ID='" & GVEstadoIT.SelectedRow.Cells(1).Text & "'")
                event_bitacora(CInt(ID_Usuario), 7, "MODIFICO LA DESCRIPCION DEL ESTADO IT: '" & UCase(txtDescripcion.Value) & "'")

                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Modifico Correctamente.');</script>")

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos sin completar');</script>")

            End If
            SelectGrillaEstadoIt()
            lblEstados.Text = CType(lblestadostotales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    '******Paginacion en la Grilla
    Private Sub GVEstadoIT_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVEstadoIT.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

        With grilla
            .PageIndex = e.NewPageIndex()
        End With


        CurrentPageLabel.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVEstadoIT.PageCount.ToString()
        SelectGrillaEstadoIt()


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVEstadoIT_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVEstadoIT.RowCommand
        If e.CommandName = "Select" Then
            txtDescripcion.Value = GVEstadoIT.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
        End If


    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVEstadoIT.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVEstadoIT, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub




    '****** Lbl Estado Tabla Estados IT 
    Function lblestadostotales() As Integer

        Return Cls_Query.dt("SELECT * FROM Cruzadi.tbl_estado_it").Rows.Count
    End Function
    '******Select Estado IT
    Sub SelectGrillaEstadoIt()
        GVEstadoIT.DataSource = Cls_Query.dt("SELECT * FROM Cruzadi.tbl_estado_it")
        GVEstadoIT.DataBind()
    End Sub

End Class