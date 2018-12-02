
Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try


            '   visualizacionpantallaprincipal()

            permisosI = 0 : permisosE = 0 : permisosA = 0 : permisosC = 0
            'Contador de las columnas permitidas de acuerdo al usuario
            fila2 = Cls_Query.dt("select count(ob.objeto_id) from Cruzadi.tbl_permisos p ,Cruzadi.tbl_reg_usuario u, Cruzadi.tbl_roles r, Cruzadi.tbl_objetos ob where u.rol_id=r.rol_id 
        and r.rol_id=p.rol_id and p.objeto_id=ob.objeto_id and  u.usuario='" & NombreU.ToString & "'")
            contador = CInt(fila2.Rows.Item(0).Item(0).ToString)
            'Los objetos y permisos de acuerdo al usuario
            fila3 = Cls_Query.dt("select ob.objeto_id,p.permiso_insercion,p.permiso_consulta,p.permiso_eliminacion,
        p.permiso_actualizacion from Cruzadi.tbl_permisos p ,Cruzadi.tbl_reg_usuario u,Cruzadi.tbl_roles r, Cruzadi.tbl_objetos ob    where
        u.rol_id=r.rol_id and r.rol_id=p.rol_id and p.objeto_id=ob.objeto_id and  u.usuario='" & NombreU.ToString & "'")


            For cols As Integer = 0 To contador - 1

                obid = CInt(fila3.Rows.Item(cols).Item(0).ToString)
                insercion = CInt(fila3.Rows.Item(cols).Item(1).ToString)
                consulta = CInt(fila3.Rows.Item(cols).Item(2).ToString)
                eliminacion = CInt(fila3.Rows.Item(cols).Item(3).ToString)
                actualizacion = CInt(fila3.Rows.Item(cols).Item(4).ToString)

                If permisosC = consulta Then

                    bpermisosC = False
                Else
                    bpermisosC = True

                End If

                permisosConsulta(obid, bpermisosC)
            Next


        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos se presento errores en la carga favor llama al administrador.');</script>")
            mytrans("R")
            Conexion.Cerrar_BD()
        End Try
    End Sub

    Sub visualizacionpantallaprincipal()
        Try

            ''Clientes
            AgregarC.Visible = False
            ModificarC.Visible = False
            GestionarC.Visible = False
            btnClientes.Visible = False
            ParameComisionesC.Visible = False



            'Comisiones
            btnComisiones.Visible = False
            comisionesCC.Visible = False
            comisionesV.Visible = False

            'Ejecutiva
            EjeCrearEje.Visible = False
            EjeParameComiVentas.Visible = False
            BtnEjecutiva.Visible = False

            'Forma de Pago
            BtnPago.Visible = False
            FTipopago.Visible = False
            FTipoPOS.Visible = False
            FPagos.Visible = False


            'Inicio
            Inicio.Visible = False

            'Reportes
            Reportes.Visible = False

            'Perfil
            'PCambioContraseña.Visible = False
            'PConfigPregunta.Visible = False

            'Mantenimiento
            MObjetos.Visible = False
            MParametros.Visible = False
            MPreguntas.Visible = False
            MRoles.Visible = False
            MGestionU.Visible = False
            MRegistrarU.Visible = False
            btnMantenimiento.Visible = False
            MRPermisos.Visible = False

            'IT

            ITEstado.Visible = False
            ITGestion.Visible = False
            ITPrincipal.Visible = False


        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos se presento errores en los permisos llama al administrador.');</script>")

        Conexion.Cerrar_BD()
        End Try
    End Sub



    Sub permisosConsulta(ByVal obid As Integer, ByVal confirmacion As Boolean)
        Try

            Select Case obid
                Case 1
                    'REGISTRAR USUARIO MANTENIMIENTO
                    MRegistrarU.Visible = confirmacion
                Case 2
                    'AGREGAR CLIENTE
                    AgregarC.Visible = confirmacion

                Case 3
                    'MODIFICAR CLIENTE
                    ModificarC.Visible = confirmacion
                Case 4
                    'GESTIONAR CLIENTE
                    GestionarC.Visible = confirmacion
                Case 5
                    'COMISIONES VENTAS
                    comisionesV.Visible = confirmacion
                Case 6
                    'COMISIONES CREDITO
                    comisionesCC.Visible = confirmacion
                Case 7
                    'MANTENIMIENTO DE OBJETOS
                    MObjetos.Visible = confirmacion
                Case 8
                    'MANTENIMIENTO DE PARAMETROS
                    MParametros.Visible = confirmacion
                Case 9
                    'MANTENIMIENTO DE  PREGUNTAS
                    MPreguntas.Visible = confirmacion
                Case 10
                    'MANTENIMIENTO DE GESTION DE USUARIO
                    MGestionU.Visible = confirmacion
                Case 11
                    'PERFIL CAMBIO CONTRASEÑA
                    PCambioContraseña.Visible = confirmacion
                Case 12
                    'CONFIGURACION DE PREGEUNTA PERSONAL
                    PConfigPregunta.Visible = confirmacion
                Case 13


                Case 14
                Case 15
                Case 16
                Case 17
                Case 18
                Case 19
                Case 20

            End Select

            'Cliente
            If obid = 2 Or obid = 3 Or obid = 4 Then
                btnClientes.Visible = confirmacion
            End If

            'Comisiones
            If obid = 5 Or obid = 6 Then
                btnComisiones.Visible = confirmacion
            End If

            'Reportes

            'Perfil
            If obid = 11 And obid = 12 Then
                btnPerfil.Visible = confirmacion
            End If


            'IT
            'Mantenimiento
            If obid = 1 Or obid >= 7 Or obid <= 10 Then
                btnMantenimiento.Visible = confirmacion
            End If

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos se presento errores en los permisos llama al administrador.');</script>")
        End Try

    End Sub
    Private Sub CerraSesion_ServerClick(sender As Object, e As EventArgs) Handles CerraSesion.ServerClick
        Try
            ultima_conexion()
            mytrans("C")
            Conexion.Cerrar_BD()

            Response.Redirect("Login.aspx")
            Response.Cookies.Clear()

        Catch ex As Exception
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Lo sentimos no se puede cerrar sesion correctamente intenta de nuevo.');</script>")
            mytrans("R")
            Conexion.Cerrar_BD()
        End Try

    End Sub

    'Private Sub ITMSJ_ServerClick(sender As Object, e As EventArgs) Handles ITMSJ.ServerClick

    'End Sub
End Class