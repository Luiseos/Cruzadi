Public Class GestionUsuario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'obid = 10
            'If PA(obid) = True Then

            '    BtnModificar.Visible = True

            'End If
            SelectGrillaGestionUsuario()
            lblGestiontotales()

            CbRol.DataSource = Cls_Query.dt("SELECT * FROM  Cruzadi.tbl_roles ")
            CbRol.DataTextField = "Rol"
            CbRol.DataValueField = "Rol_id"
            CbRol.DataBind()
        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Error al cargar la pagina.');</script>")


        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    Private Sub BtnModificar_ServerClick(sender As Object, e As EventArgs) Handles BtnModificar.ServerClick
        Try
            combobox = CType(CbRol.SelectedIndex + 1, String)
            fila = Cls_Query.dt("select pregunta_contestada from Cruzadi.tbl_reg_usuario  where usuario_id='" & GVGU.SelectedRow.Cells(5).Text & "'")
            nuevo = fila.Rows.Item(0).Item(0).ToString

            If CbEstado.SelectedIndex >= 0 And CInt(combobox) >= 0 And Vencimiento.Value <> Nothing Then

                If CbEstado.SelectedIndex = 2 Then

                    Actualizar("Cruzadi.TBL_Reg_Usuario", "email='" & TxtEmail.Value & "', Estado_Usuario='" & CbEstado.SelectedIndex + 1 & "', rol_id='" & combobox.ToString & "', Fecha_Vencimiento ='" & Vencimiento.Value & "'", "usuario_id='" & GVGU.SelectedRow.Cells(5).Text & "'")
                    event_bitacora(CInt(ID_Usuario), 10, "GESTIONO EL ESTADO DEL USUARIO A '" & UCase(CbEstado.Value) & "'")
                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Registro Modificado Exitosamente');</script>")


                ElseIf CInt(GVGU.SelectedRow.Cells(5).Text) = 3 And nuevo = Nothing Then
                    Actualizar("Cruzadi.TBL_Reg_Usuario", "email='" & TxtEmail.Value & "', Estado_Usuario='" & CbEstado.SelectedIndex + 1 & "', rol_id='" & combobox.ToString & "', Fecha_Vencimiento ='" & Vencimiento.Value & "'", "usuario_id='" & GVGU.SelectedRow.Cells(5).Text & "'")
                    event_bitacora(CInt(ID_Usuario), 10, "GESTIONO EL ESTADO DEL USUARIO A : '" & UCase(CbEstado.Value) & "'")

                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Registro Modificado Exitosamente');</script>")

                Else

                    Actualizar("Cruzadi.TBL_Reg_Usuario", "email='" & TxtEmail.Value & "', Estado_Usuario='" & CbEstado.SelectedIndex & "',rol_id='" & combobox.ToString & "',
            Fecha_Vencimiento='" & Vencimiento.Value & "'", "usuario_id='" & GVGU.SelectedRow.Cells(5).Text & "'")
                    event_bitacora(CInt(ID_Usuario), 10, "GESTIONO EL ESTADO DEL USUARIO A : '" & UCase(CbEstado.Value) & "'")

                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Registro Modificado Exitosamente');</script>")


                End If

            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Debe de seleccionar Rol, Estado, Fecha de vencimiento ');</script>")

            End If

            SelectGrillaGestionUsuario()
            lblGestiontotales()

        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub



    '******Paginacion en la Grilla
    Private Sub GVGU_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVGU.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorGestionn.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVGU.PageCount.ToString()
            SelectGrillaGestionUsuario()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVGU_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVGU.RowCommand
        If e.CommandName = "Select" Then

            Try
                TxtUsuarioR.Value = GVGU.SelectedRow.Cells(0).Text
                TxtNombre.Value = GVGU.SelectedRow.Cells(1).Text
                Vencimiento.Value = CType(CDate(GVGU.SelectedRow.Cells(2).Text), String)



                TxtEmail.Value = GVGU.SelectedRow.Cells(3).Text

                If CInt(GVGU.SelectedRow.Cells(4).Text) = 3 Then
                    CbEstado.SelectedIndex = CInt(CInt(GVGU.SelectedRow.Cells(4).Text) - 1)
                Else
                    CbEstado.SelectedIndex = CInt(GVGU.SelectedRow.Cells(4).Text)

                End If
            Catch ex As Exception
                mytrans("R")

                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
            Finally
                Conexion.Cerrar_BD()

            End Try
        End If
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVGU.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVGU, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '****** Lbl Estado Tabla Estados IT 
    Function lblGestiontotales() As Integer

        Return Cls_Query.dt("  SELECT usuario,nombre_usuario, convert(varchar, fecha_vencimiento, 105)as fecha_vencimiento,email,Estado_Usuario ,usuario_id  FROM Cruzadi.tbl_reg_usuario").Rows.Count
    End Function
    '******Select Estado IT
    Sub SelectGrillaGestionUsuario()
        GVGU.DataSource = Cls_Query.dt("  SELECT usuario,nombre_usuario, convert(varchar, fecha_vencimiento, 105)as fecha_vencimiento,email,Estado_Usuario ,usuario_id  FROM Cruzadi.tbl_reg_usuario")
        GVGU.DataBind()
    End Sub
End Class