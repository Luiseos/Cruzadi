Public Class Roles1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            If (IsPostBack = False) Then


                cbobjetos.DataSource = Cls_Query.dt("SELECT * FROM  Cruzadi.tbl_objetos ")
                cbobjetos.DataTextField = "objeto"
                cbobjetos.DataValueField = "objeto_id"
                cbobjetos.DataBind()
                CbRol.DataSource = Cls_Query.dt("SELECT * FROM  Cruzadi.tbl_Roles ")
                CbRol.DataTextField = "rol"
                CbRol.DataValueField = "rol_id"
                CbRol.DataBind()
            End If

        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub


    Private Sub btnagregar_ServerClick(sender As Object, e As EventArgs) Handles btnagregar.ServerClick
        Try
            checkedPermisos(CInt(cbobjetos.Value), CInt(CbRol.Value))
            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Permiso Agregado Exitosamente');</script>")
            event_bitacora(CInt(ID_Usuario), CInt(cbobjetos.Value), "AGREGO PERMISO A: '" & cbobjetos.Items.Item(CInt(CInt(cbobjetos.Value.ToString) - 1)).Text & "'")
        Catch ex As Exception
            mytrans("R")

            Page.ClientScript.RegisterStartupScript(GetType(String), "Scripts", " <script>alert('Ocurrio un Error de exepcion llama al Administrador o intente de nuevo');</script>")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    Private Sub btncancelarpermiso_ServerClick(sender As Object, e As EventArgs) Handles btncancelarpermiso.ServerClick
        If ckconsulta.Checked = True Or ckinsertar.Checked = True Or ckmodificar.Checked = True Then
            ckconsulta.Checked = False
            '  ckeliminar.Checked = False  ckeliminar.Checked = True Or
            ckinsertar.Checked = False
            ckmodificar.Checked = False
        Else
            ckconsulta.Checked = False
            ' ckeliminar.Checked = False
            ckinsertar.Checked = False
            ckmodificar.Checked = False
        End If
    End Sub


    Function checkedPermisos(ByVal obid As Integer, ByVal rolid As Integer) As DataTable

        Dim consulta, insertar, eliminar, actualizar As Integer
            consulta = 0 : insertar = 0 : eliminar = 0 : actualizar = 0

            If ckconsulta.Checked = True Then
                consulta = 1
            Else
                consulta = 0
            End If


            If ckinsertar.Checked = True Then
                insertar = 1
            Else
                insertar = 0
            End If

        'If ckeliminar.Checked = True Then
        '    eliminar = 1
        'Else
        '    eliminar = 0
        'End If
        If ckmodificar.Checked = True Then
                actualizar = 1
            Else
                actualizar = 0
            End If
            Return Insert("Cruzadi.tbl_permisos(Objeto_id,rol_id,permiso_insercion,permiso_eliminacion,permiso_actualizacion,permiso_consulta)",
                      "" & obid.ToString & "," & rolid.ToString & "," & insertar.ToString & "," & eliminar.ToString & ", " & actualizar.ToString & "," & consulta.ToString & "")

    End Function

    'If ckconsulta.Checked And ckinsertar.Checked And ckmodificar.Checked And ckeliminar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '1','1','1','1' ")
    'ElseIf ckconsulta.Checked And ckinsertar.Checked And ckmodificar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '1','0','1','1' ")
    'ElseIf ckconsulta.Checked And ckinsertar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '1','0','0','1' ")
    'ElseIf ckconsulta.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '0','0','0','1' ")
    'ElseIf ckinsertar.Checked And ckmodificar.Checked And ckeliminar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '1','1','1','0' ")
    'ElseIf ckmodificar.Checked And ckeliminar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '0','1','1','0' ")
    'ElseIf ckeliminar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '0','1','0','0' ")
    'ElseIf ckinsertar.Checked And ckmodificar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '1','0','0','1' ")
    'ElseIf ckinsertar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '1','0','0','0' ")
    'ElseIf ckmodificar.Checked Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '0','0','1','0' ")
    'ElseIf ckconsulta.Checked = False And ckinsertar.Checked = False And ckmodificar.Checked = False And ckeliminar.Checked = False Then
    '    Insert("`tbl_permisos`(`permiso_insercion`,`permiso_eliminacion`,`permiso_actualizacion`,`permiso_consulta`)", " '0','0','0','0' ")
    'End If

End Class