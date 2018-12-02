Imports DevExpress.Web.Data

Public Class Objetos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If (IsPostBack = False) Then
                obid = 7
                If PA(obid) = True Then

                    btnmodificar.Visible = True

                End If
            End If

            SelectGrillaobjetos()
            lblTotalesEjecutiva.Text = CType(lblobjetostotales(), String)
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Error al cargar la pagina.');</script>")


        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnguardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick
        Try
            If txtdescrpcionob.Value <> Nothing And txtob.Value <> Nothing And Txttipodescriocion.Value <> Nothing Then
                Insert("Cruzadi.tbl_objetos(objeto,Descripcion ,tipo_Descripcion)", "'" & UCase(txtob.Value) & "','" & UCase(txtdescrpcionob.Value) & "','" & UCase(Txttipodescriocion.Value) & "'")

                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Registro Correctamente.');</script>")

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")


            End If
            SelectGrillaobjetos()
            lblobjetostotales()
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btnmodificar_ServerClick(sender As Object, e As EventArgs) Handles btnmodificar.ServerClick
        Try
            If txtdescrpcionob.Value <> Nothing And txtob.Value <> Nothing And Txttipodescriocion.Value <> Nothing Then
                Actualizar("Cruzadi.tbl_objetos", "descripcion='" & UCase(txtdescrpcionob.Value) & "',Tipo_descripcion='" & UCase(Txttipodescriocion.Value) & "'", "objeto_ID='" & GVObjeto.SelectedRow.Cells(0).Text & "'")
                Bitacora(CInt(ID_Usuario), 7, "MODIFICO LA DESCRIPCION DEL OBJETO: '" & GVObjeto.SelectedRow.Cells(1).Text & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se Modifico Correctamente.');</script>")
                txtdescrpcionob.Value = Nothing
                txtob.Value = Nothing
                Txttipodescriocion.Value = Nothing
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos tiene campos por rellenar');</script>")

            End If
            SelectGrillaobjetos()
            lblobjetostotales()
        Catch ex As Exception
            mytrans("R")
            ' Response.Write("Ocurrio un Error de exepcion llama al Administrador")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub


    '******Paginacion en la Grilla
    Private Sub GVObjeto_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVObjeto.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorObjeto.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVObjeto.PageCount.ToString()
            SelectGrillaobjetos()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVObjeto_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVObjeto.RowCommand
        If e.CommandName = "Select" Then

            txtob.Value = GVObjeto.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txtdescrpcionob.Value = GVObjeto.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            Txttipodescriocion.Value = GVObjeto.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text
            txtob.Disabled = True
        End If
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVObjeto.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVObjeto, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '****** Lbl totales objetos
    Function lblobjetostotales() As Integer

        Return Cls_Query.dt("select * from Cruzadi.tbl_Objetos").Rows.Count
    End Function
    '******Select Objeto
    Sub SelectGrillaobjetos()

        GVObjeto.DataSource = Cls_Query.dt("select * from Cruzadi.tbl_Objetos")
        GVObjeto.DataBind()
    End Sub


End Class