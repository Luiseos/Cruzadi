Public Class AgregarCLientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        ' Conexion.conectar("SOPORTE\ SQLSERVER2014", "Cruzadi")
        ' Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS01", "Cruzadi")
        'Conexion.Cerrar_BD()
        Try
            If (IsPostBack = False) Then
                cbejecutiva.DataSource = Cls_Query.dt("SELECT * FROM cruzadi.tbl_ejecutiva")
                cbejecutiva.DataTextField = "nombre_ejecutiva"
                cbejecutiva.DataValueField = "ejecutiva_id"
                cbejecutiva.DataBind()

                obid = 2
                Bitacora(CInt(ID_Usuario), obid, "INGRESO AGREGAR CLIENTE")
                If PA(obid) = True Or PI(obid) = True Then
                    btnaceptar.Visible = True
                    btncancelar.Visible = True
                ElseIf PC(obid) = False Then
                    Response.Redirect("/inicio.aspx")

                End If
            End If
            If (IsPostBack = False) Then
                If (Request.Params("RFC") <> Nothing) Or (Request.Params("RFC2") <> Nothing) Then
                    txtAcliente.Enabled = False
                    txtAcliente.Text = Request.Params("Codigo")
                    txtRTN.Value = Request.Params("RTN")
                    txtnombre.Value = Request.Params("RazonSocial")
                    TxttipoCliente.Value = Request.Params("NombreTipo")
                    txtTelefono.Value = Request.Params("Telefono")
                    txtEmail.Value = Request.Params("Email")
                    txtDireccion.Value = Request.Params("Direccion")
                    txtcontacto.Value = Request.Params("Contacto")
                    txtlcredito.Value = Request.Params("limite")
                    txtDcredito.Value = Request.Params("Dias")
                    cbejecutiva.SelectedIndex = CInt(Request.Params("Ejecutiva"))


                    txtAcliente.Text = Request.Params("Codigo2")
                    txtRTN.Value = Request.Params("RTN2")
                    txtnombre.Value = Request.Params("RazonSocial2")
                    TxttipoCliente.Value = Request.Params("NombreTipo2")
                    txtTelefono.Value = Request.Params("Telefono2")
                    txtEmail.Value = Request.Params("Email2")
                    txtDireccion.Value = Request.Params("Direccion2")
                    txtcontacto.Value = Request.Params("Contacto2")
                End If
            End If
            'mostrar()



        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al cargar la pagina');</script>")

        End Try

    End Sub

    Private Sub btnaceptar_ServerClick(sender As Object, e As EventArgs) Handles btnaceptar.ServerClick
        Try
            telefono = txtTelefono.Value
            '  If txtAcliente.Enabled = False Then
            'Actualizar("cruzadi.tbl_cliente", "dias_credito='" & txtDcredito.Value & "',limite_credito='" & txtlcredito.Value & "',contacto='" & txtcontacto.Value & "',ejecutiva_id ='" & cbejecutiva.SelectedIndex + 1 & "'", "cliente_id='" & txtAcliente.Text & "'")
            '    Actualizar("cruzadi.tbl_email", "email='" & txtEmail.Value & "'", "cliente_id='" & txtAcliente.Text & "'")
            '    Actualizar("cruzadi.tbl_telefono", "telefono='" & txtTelefono.Value & "'", "cliente_id='" & txtAcliente.Text & "'")
            'mytrans("C")
            'Conexion.Cerrar_BD()
            '  Else
            'fila = Cls_Query.dt("select count(cliente_id) from cruzadi.tbl_Cliente where cliente_id ='" & txtAcliente.Text & "'")
            '    existe = fila.Rows.Item(0).Item(0).ToString
            If (CInt(Request.Params("Contador")) <> Nothing) Then
                Actualizar("cruzadi.tbl_cliente", "dias_credito='" & txtDcredito.Value & "',limite_credito='" & txtlcredito.Value & "',contacto='" & txtcontacto.Value & "',ejecutiva_id ='" & cbejecutiva.SelectedIndex + 1 & "'", "cliente_id='" & txtAcliente.Text & "'")
                Actualizar("cruzadi.tbl_email", "email='" & txtEmail.Value & "'", "cliente_id='" & txtAcliente.Text & "'")
                Actualizar("cruzadi.tbl_telefono", "telefono='" & txtTelefono.Value & "'", "cliente_id='" & txtAcliente.Text & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se realizo la actualizacion correctamente');</script>")

                'verificar()
            ElseIf (CInt(Request.Params("existe")) <> Nothing) Then
                verificar()
                mytrans("C")
                Conexion.Cerrar_BD()
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Se realizo la actualizacion correctamente');</script>")

            Else


                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al insertar o modificar');</script>")

            End If

        Catch ex As Exception
            mytrans("R")
        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al insertar');</script>")

        End Try

    End Sub

    Public Sub verificar()
        Try
            If txtDcredito.Value = Nothing Then
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('El campo Dias de Credito esta vacio por favor llenelo.');</script>")
                txtDcredito.Focus()
            ElseIf txtlcredito.Value = Nothing Then
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('El campo Limite de Credito esta vacio por favor llenelo.');</script>")
                txtlcredito.Focus()
            Else

                'fila = Cls_Query.dt("select email_id from cruzadi.tbl_email where cliente_id ='" & txtAcliente.Text & "'")
                'correo = fila.Rows.Item(0).Item(0).ToString


                'fila = Cls_Query.dt("select telefono_id from cruzadi.tbl_telefono where cliente_id ='" & txtAcliente.Text & "'")
                'telefono = fila.Rows.Item(0).Item(0).ToString

                Insert("cruzadi.tbl_cliente(cliente_id,dias_credito,limite_credito,ejecutiva_id,contacto)", "'" & txtAcliente.Text & "','" & txtDcredito.Value & "','" & txtlcredito.Value & "','" & CInt(cbejecutiva.Value) & "','" & txtcontacto.Value & "'")
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Cliente agregado exitosamente.');</script>")
                Bitacora(CInt(ID_Usuario), obid, "INSERTO LA INFORMACION DEL CLIENTE '" & txtAcliente.Text & "'")
                Insert("cruzadi.tbl_email(email,cliente_id)", "'" & txtEmail.Value & "','" & txtAcliente.ToString & "'")
                Insert("cruzadi.tbl_telefono(telefono,cliente_id)", "'" & txtTelefono.Value & "','" & txtAcliente.ToString & "'")
                Insert("cruzadi.tbl_telefono(telefono,cliente_id)", "'" & txtTelefono.Value & "','" & txtAcliente.ToString & "'")
                mytrans("C")
                Conexion.Cerrar_BD()
            End If

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al insertar');</script>")

        End Try
    End Sub

    Private Sub btntelmas_ServerClick(sender As Object, e As EventArgs) Handles btntelmas.ServerClick
        Try
            If txtTelefono.Value = Nothing And txtAcliente.Text = Nothing Then
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('llene el campo telefono para poder agregar mas.');</script>")
            Else
                telefono = txtTelefono.Value
                Insert("cruzadi.tbl_telefono(telefono,cliente_id)", "'" & telefono & "','" & txtAcliente.Text & "'")
                Bitacora(CInt(ID_Usuario), obid, "INSERTO TELEFONO A INFORMACION DEL CLIENTE '" & txtAcliente.Text & "'")

                mytrans("C")
            Conexion.Cerrar_BD()

        End If
        Catch ex As Exception
        mytrans("R")
        Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al insertar');</script>")

        End Try
    End Sub

    Private Sub btmmasemail_ServerClick(sender As Object, e As EventArgs) Handles btmmasemail.ServerClick
        Try
            If txtEmail.Value = Nothing And txtAcliente.Text = Nothing Then
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('El campo Email esta vacio por favor llenelo.');</script>")
            Else
                correo = txtEmail.Value
                Insert("cruzadi.tbl_email(email,cliente_id)", "'" & correo & "','" & txtAcliente.ToString & "'")
                Bitacora(CInt(ID_Usuario), obid, "INSERTO EMAIL A INFORMACION DEL CLIENTE '" & txtAcliente.Text & "'")

                mytrans("C")
                Conexion.Cerrar_BD()
            End If
        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Problemas al insertar');</script>")

        End Try
    End Sub


    'Public Sub mostrar()
    '    txtnombre.Disabled = True
    '    txtRTN.Disabled = True
    '    txtDireccion.Disabled = True
    '    'txtEmail.Disabled = True
    '    'txtTelefono.Disabled = True
    '    'txtcontacto.Disabled = True
    'End Sub

    Private Sub txtAcliente_TextChanged(sender As Object, e As EventArgs) Handles txtAcliente.TextChanged
        Try

            If CInt(existe) = 1 Then
                fila2 = Cls_Query.dt("select rtn,Razon_Social,nombre_tipo,telefono,e_mail,direccion,contacto from cruzadi.dbo.view_ClienteCXC where codigo_Cliente = '" & txtAcliente.Text & "'")


                txtnombre.Value = fila2.Rows.Item(0).Item(1).ToString
                TxttipoCliente.Value = fila2.Rows.Item(0).Item(2).ToString
                txtRTN.Value = fila2.Rows.Item(0).Item(0).ToString
                txtTelefono.Value = fila2.Rows.Item(0).Item(3).ToString
                txtEmail.Value = fila2.Rows.Item(0).Item(4).ToString
                txtDireccion.Value = fila2.Rows.Item(0).Item(5).ToString
                txtcontacto.Value = fila2.Rows.Item(0).Item(6).ToString
            Else
                Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('El cliente no existe, Favor ingrese un cliente existente de ARPON.');</script>")
            End If

        Catch ex As Exception
            mytrans("R")
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Tuvo un error al cargar');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub BtnBuscarCliente_ServerClick(sender As Object, e As EventArgs) Handles BtnBuscarCliente.ServerClick
        Response.Redirect("/formas/CC/BusquedaClienteArpon.aspx")
    End Sub
End Class