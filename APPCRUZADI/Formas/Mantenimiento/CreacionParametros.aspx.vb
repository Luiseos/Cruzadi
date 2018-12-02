Public Class Parametros
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            obid = 8
            If PA(obid) = True Then

                btnmodificar.Visible = True

            End If
            SelectGrillaParametros()
            lblTotalesParametros.Text = CType(lblparametrostotales(), String)


        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Error al cargar la pagina.');</script>")


        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    'Private Sub btneliminar_ServerClick(sender As Object, e As EventArgs) Handles btneliminar.ServerClick
    '    Try
    '        If txtparametro.Value <> Nothing And txtvalor.Value <> Nothing Then

    '            delete("TBL_Parametros", "Parametros_ID='" & GVParametro1.SelectedRow.Cells(1).Text & "'")
    '            mytrans("C")
    '            Conexion.Cerrar_BD()
    '            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Elimino Correctamente.');</script>")

    '        Else
    '            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


    '        End If

    '        GVParametro1.DataSource = Cls_Query.dt("select * from tbl_Parametros")
    '        GVParametro1.DataBind()

    '    Catch ex As Exception
    '        mytrans("R")
    '        ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
    '        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
    '    Finally
    '        Conexion.Cerrar_BD()

    '    End Try
    'End Sub

    'Private Sub btnguardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick
    '    Try
    '        If txtparametro.Value <> Nothing And txtvalor.Value <> Nothing Then
    '            Insert("TBL_PARAMETROS(parametro,valor,fecha_Creacion,Fecha_Modificacion,usuario_id)", "'" & UCase(txtparametro.Value) & "','" & txtvalor.Value & "',sysdate(),sysdate(),'" & ID_Usuario.ToString & "'")
    '            mytrans("C")
    '            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")
    '            Conexion.Cerrar_BD()

    '        Else
    '            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")

    '        End If
    '        GVParametro1.DataSource = Cls_Query.dt("select * from tbl_Parametros")
    '        GVParametro1.DataBind()
    '    Catch ex As Exception
    '        mytrans("R")
    '        ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
    '        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
    '    Finally
    '        Conexion.Cerrar_BD()

    '    End Try
    'End Sub

    Private Sub btnmodificar_ServerClick(sender As Object, e As EventArgs) Handles btnmodificar.ServerClick
        Try
            If txtparametro.Value <> Nothing And txtvalor.Value <> Nothing Then
                Actualizar("Cruzadi.tbl_Parametros", "valor='" & txtvalor.Value & "',Fecha_Modificacion=sysdate()", "Parametros_ID='" & GVParametro1.SelectedRow.Cells(0).Text & "'")
                event_bitacora(CInt(ID_Usuario), 8, "MODIFICO EL VALOR NUEVO: '" & UCase(txtvalor.Value) & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Modifico Correctamente.');</script>")

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


            End If

            SelectGrillaParametros()
            lblTotalesParametros.Text = CType(lblparametrostotales(), String)


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub



    '******Paginacion en la Grilla
    Private Sub GVParametro1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVParametro1.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorParametros.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVParametro1.PageCount.ToString()
            SelectGrillaParametros()


        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVParametro1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVParametro1.RowCommand
        If e.CommandName = "Select" Then

            txtparametro.Value = GVParametro1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txtvalor.Value = GVParametro1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
        End If
    End Sub

    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVParametro1.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVParametro1, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '****** Lbl Parametro Tabla Parametro
    Function lblparametrostotales() As Integer

        Return Cls_Query.dt("select * from Cruzadi.tbl_Parametros").Rows.Count
    End Function
    '******Select Parametro
    Sub SelectGrillaParametros()
        GVParametro1.DataSource = Cls_Query.dt("select * from Cruzadi.tbl_Parametros")
        GVParametro1.DataBind()
    End Sub
End Class