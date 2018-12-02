Imports MySql.Data.MySqlClient
Public Class CreacionPregunta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            obid = 9
            If PI(obid) = True Then

                btnguardar.Visible = True

            End If
            SelectGrillaPregunta()
            lblTotalesPregunta.Text = CType(lblPreguntatotales(), String)

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    'Private Sub btneliminar_ServerClick(sender As Object, e As EventArgs) Handles btneliminar.ServerClick
    '    Try
    '        If txtIDPregunta.Value <> Nothing And txtpregunta.Value <> Nothing Then

    '            delete("TBL_Pregunta", "Pregunta_ID='" & GVPregunta1.SelectedRow.Cells(1).Text & "'")
    '            mytrans("C")
    '            Conexion.Cerrar_BD()
    '            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Elimino Correctamente.');</script>")

    '        Else
    '            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


    '        End If

    '        GVPregunta1.DataSource = Cls_Query.dt("select * from tbl_Pregunta")
    '        GVPregunta1.DataBind()

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

            fila = Cls_Query.dt("Select Count(pregunta) from Cruzadi.tbl_pregunta where pregunta='" & txtpregunta.Value & "'")
            existe = fila.Rows.Item(0).Item(0).ToString

            If CInt(existe) = 1 Then
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Pregunta no puede ser ingresada porque ya existe.');</script>")
            Else

                If txtpregunta.Value <> Nothing Then
                    Insert("Cruzadi.TBL_Pregunta(Pregunta)", "'" & UCase(txtpregunta.Value) & "'")
                    event_bitacora(CInt(ID_Usuario), 9, "INSERTO LA PREGUNTA: '" & UCase(txtpregunta.Value) & "'")
                    mytrans("C")

                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")

                Else
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


                End If

            End If
            SelectGrillaPregunta()
            lblTotalesPregunta.Text = CType(lblPreguntatotales(), String)

        Catch ex As Exception
            mytrans("R")
            ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    'Private Sub btnmodificar_ServerClick(sender As Object, e As EventArgs) Handles btnmodificar.ServerClick

    'Try
    '        If txtIDPregunta.Value <> Nothing And txtpregunta.Value <> Nothing Then
    'Actualizar("tbl_Pregunta", "Pregunta='" & txtpregunta.Value & "'", "Pregunta_ID='" & GVPregunta1.SelectedRow.Cells(1).Text & "'")
    '            mytrans("C")
    '            Conexion.Cerrar_BD()
    '            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Modifico Correctamente.');</script>")

    '        Else
    '            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


    '        End If

    '        GVPregunta1.DataSource = Cls_Query.dt("select * from tbl_Pregunta")
    '        GVPregunta1.DataBind()
    '    Catch ex As Exception
    '        mytrans("R")
    '        ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
    '        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
    '    Finally
    '        Conexion.Cerrar_BD()

    '    End Try


    'End Sub

    '******Paginacion en la Grilla

    Private Sub GVPregunta1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVPregunta1.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With

            LblPaginadorPregunta.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVPregunta1.PageCount.ToString()
            SelectGrillaPregunta()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVPregunta1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVPregunta1.RowCommand
        If e.CommandName = "Select" Then
            txtpregunta.Value = GVPregunta1.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
        End If
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVPregunta1.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVPregunta1, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '****** Lbl Pregunta Totales
    Function lblPreguntatotales() As Integer

        Return Cls_Query.dt("select * from Cruzadi.tbl_Pregunta").Rows.Count
    End Function
    '******Select Pregunta
    Sub SelectGrillaPregunta()
        GVPregunta1.DataSource = Cls_Query.dt("select * from Cruzadi.tbl_Pregunta")
        GVPregunta1.DataBind()
    End Sub

End Class