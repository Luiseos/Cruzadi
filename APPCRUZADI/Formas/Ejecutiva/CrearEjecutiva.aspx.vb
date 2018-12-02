Public Class CrearEjecutiva
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            SelectGrillaEjecutiva()
            lblEjecutivatotales()

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Error al cargar la pagina.');</script>")


        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub


    Private Sub btnguardar_ServerClick(sender As Object, e As EventArgs) Handles btnguardar.ServerClick
        Try
            If Txtejecutiva.Value <> Nothing And txtemail.Value <> Nothing And txtsiglas.Value <> Nothing And Txttel.Value <> Nothing Then
                fila4 = Cls_Query.dt("SELECT count(Nombre_ejecutiva),Count(Siglas) FROM Cruzadi.tbl_ejecutiva where nombre_ejecutiva='" & Txtejecutiva.Value & "' and Siglas ='" & txtsiglas.Value & "'")
                comparador = fila4.Rows.Item(0).Item(0).ToString
                comparador2 = fila4.Rows.Item(0).Item(1).ToString
                If CInt(comparador) = 1 Or CInt(comparador2) = 1 Then
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Esta informacion de Ejecutiva esta repetido intenta ingresar una nueva Ejecutiva ');</script>")

                Else

                    Insert("Cruzadi.tbl_email(email)", "'" & UCase(txtemail.Value) & "'")
                    Insert("cruzadi.tbl_telefono", "'" & UCase(Txttel.Value) & "'")
                    fila = Cls_Query.dt("select max(email_id) from Cruzadi.tbl_email")
                    emailid = CInt(fila.Rows.Item(0).Item(0).ToString)
                    fila2 = Cls_Query.dt("select max(telefono_id) from Cruzadi.tbl_telefono")
                    telid = CInt(fila2.Rows.Item(0).Item(0).ToString)
                    Insert("Cruzadi.tbl_ejecutiva(nombre_ejecutiva,siglas,email_id,telefono_id)", "'" & UCase(Txtejecutiva.Value) & "' ,'" & UCase(txtsiglas.Value) & "','" & emailid & "', '" & telid & "'")
                    event_bitacora(CInt(ID_Usuario), 7, "AGREGO LA EJECUTIVA: '" & Txtejecutiva.Value & "'")
                    mytrans("C")
                    Conexion.Cerrar_BD()
                    Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se ha registrado una nueva Ejecutiva de Ventas ');</script>")

                End If
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tiene Campos por rellenar, favor verificar. ');</script>")

            End If
            SelectGrillaEjecutiva()
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub

    Private Sub BtnModificar_ServerClick(sender As Object, e As EventArgs) Handles BtnModificar.ServerClick
        Try
            fila3 = Cls_Query.dt("SELECT em.email_id,tel.telefono_id FROM Cruzadi.tbl_ejecutiva eje, Cruzadi.tbl_email em, Cruzadi.tbl_telefono tel WHERE eje.email_id =em.email_id and eje.telefono_id=tel.telefono_id and eje.ejecutiva_id='" & GVCrearEjecutiva.SelectedRow.Cells(0).Text & "'")
            emailid = CInt(fila3.Rows.Item(0).Item(0).ToString)
            telid = CInt(fila3.Rows.Item(0).Item(1).ToString)

            If txtemail.Value <> Nothing And txtsiglas.Value <> Nothing And Txttel.Value <> Nothing Then
                If GVCrearEjecutiva.SelectedRow.Cells(3).Text <> txtemail.Value Then
                    Actualizar("Cruzadi.TBL_EMAIL", "EMAIL='" & UCase(txtemail.Value) & "'", "EMAIL_ID='" & emailid.ToString & "'")
                    ' event_bitacora(CInt(ID_Usuario), 7, "MODIFICO EL CORREO: '" & GVCrearEjecutiva.SelectedRow.Cells(4).Text & "'  AL :'" & txtemail.Value & "'")

                End If
                If GVCrearEjecutiva.SelectedRow.Cells(4).Text <> Txttel.Value Then
                    Actualizar("Cruzadi.Tbl_Telefono", "Telefono='" & UCase(Txttel.Value) & "'", "telefono_id='" & telid.ToString & "'")
                    ' event_bitacora(CInt(ID_Usuario), 7, "MODIFICO EL TELEFONO: '" & GVCrearEjecutiva.SelectedRow.Cells(5).Text & "'  AL :'" & Txttel.Value & "'")

                End If

                If GVCrearEjecutiva.SelectedRow.Cells(2).Text <> txtsiglas.Value Then
                    Actualizar("Cruzadi.tbl_Ejecutiva", "Siglas='" & txtsiglas.Value & "'", "ejecutiva_id='" & GVCrearEjecutiva.SelectedRow.Cells(0).Text & "'")
                    ' event_bitacora(CInt(ID_Usuario), 7, "MODIFICO LA SIGLA: '" & GVCrearEjecutiva.SelectedRow.Cells(3).Text & "' A LA: '" & txtsiglas.Value & "'")

                End If
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se ha Modificado datos de una Ejecutiva de Ventas ');</script>")
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tiene Campos por rellenar, favor verificar. ');</script>")

            End If
            SelectGrillaEjecutiva()
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub


    '******Paginacion en la Grilla
    Private Sub GVCrearEjecutiva_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVCrearEjecutiva.PageIndexChanging
        Try
            Dim grilla As GridView = CType(sender, GridView)

            With grilla
                .PageIndex = e.NewPageIndex()
            End With


            LblPaginadorEjecutiva.Text = "Página " & CType(CInt(e.NewPageIndex.ToString) + 1, String) & " de " & GVCrearEjecutiva.PageCount.ToString()
            SelectGrillaEjecutiva()

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error en la paginacion');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try

    End Sub



    ''Metodos para poder dar clic en la fila de un gridview
    Private Sub GVCrearEjecutiva_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVCrearEjecutiva.RowCommand
        If e.CommandName = "Select" Then

            Txtejecutiva.Value = GVCrearEjecutiva.Rows(Convert.ToInt32(e.CommandArgument)).Cells(1).Text
            txtsiglas.Value = GVCrearEjecutiva.Rows(Convert.ToInt32(e.CommandArgument)).Cells(2).Text
            txtemail.Value = GVCrearEjecutiva.Rows(Convert.ToInt32(e.CommandArgument)).Cells(3).Text
            Txttel.Value = GVCrearEjecutiva.Rows(Convert.ToInt32(e.CommandArgument)).Cells(4).Text
            Txtejecutiva.Disabled = True
        End If
    End Sub
    Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        For Each row As GridViewRow In GVCrearEjecutiva.Rows

            If row.RowType = DataControlRowType.DataRow Then

                row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(GVCrearEjecutiva, "Select$" & row.RowIndex, True)
            End If
        Next

        MyBase.Render(writer)
    End Sub

    '****** Lbl Estado Tabla Estados IT 
    Function lblEjecutivatotales() As Integer

        Return Cls_Query.dt("SELECT eje.ejecutiva_id, eje.nombre_ejecutiva, eje.siglas, em.email, tel.telefono FROM cruzadi.tbl_ejecutiva eje, cruzadi.tbl_email em,cruzadi.tbl_telefono tel WHERE eje.email_id =em.email_id and eje.telefono_id=tel.telefono_id").Rows.Count
    End Function
    '******Select Estado IT
    Sub SelectGrillaEjecutiva()
        GVCrearEjecutiva.DataSource = Cls_Query.dt("SELECT eje.ejecutiva_id, eje.nombre_ejecutiva, eje.siglas, em.email, tel.telefono FROM cruzadi.tbl_ejecutiva eje, cruzadi.tbl_email em,cruzadi.tbl_telefono tel WHERE eje.email_id =em.email_id and eje.telefono_id=tel.telefono_id")
        GVCrearEjecutiva.DataBind()
    End Sub

End Class