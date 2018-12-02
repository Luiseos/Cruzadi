Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Data
Imports System.Diagnostics
Imports Microsoft.SqlServer
Imports System.Data.SqlClient

Module Procedimientos


    ''Metodos DML

    'Insertar
    Public Function Insert(ByVal tabla As String, ByVal valores As String) As DataTable

        Conexion.Cerrar_BD()
        Return Cls_Query.dt("Insert into " & tabla & " values(" & valores & ")")
    End Function

    'Actualizar
    Public Function Actualizar(ByVal Tabla As String, ByVal columna As String, ByVal condicion As String) As DataTable
        Conexion.Cerrar_BD()
        Return Cls_Query.dt("update " & Tabla & " set " & columna & " where " & condicion & "")
    End Function
    'Eliminar
    Public Function delete(ByVal Tabla As String, ByVal condicion As String) As DataTable
        Conexion.Cerrar_BD()
        Return Cls_Query.dt(" delete from " & Tabla & " where " & condicion & " ")

    End Function

    Public Sub Bitacora(ByVal iduser As Integer, ByVal objeto As Integer, ByVal descripcion As String)
        event_bitacora(iduser, objeto, descripcion.ToString)
    End Sub




    ''Limpiar los Textbox
    'Public Sub Limpiartxt(ByVal Control As WebControl)
    '    Dim TXT As Object
    '    Dim txttemporal As HtmlInputText
    '    For Each TXT In Control.Controls
    '        If TypeOf TXT Is HtmlInputText Then
    '            txttemporal = CType(TXT, HtmlInputText)
    '            txttemporal.Value = Nothing

    '        End If
    '    Next

    'End Sub

    ''Limpiar textbox de un groupbox
    'Public Sub Limpiartxtgroup(ByVal Control As GroupBox)
    '    Dim TXT As Object
    '    Dim txttemporal As TextBox
    '    For Each TXT In Control.Controls
    '        If TypeOf TXT Is TextBox Then
    '            txttemporal = CType(TXT, TextBox)
    '            txttemporal.Clear()

    '        End If

    '    Next
    'End Sub
    '******************************
    'Funcion Para validar el correo
    Public Function validar_Mail(ByVal smail As String) As Boolean

        Return Regex.IsMatch(smail, "^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")

    End Function
    '******************************
    ' Funcion para validar la contraseña
    Public Function ValidarContraseña(ByVal pwd As String) As Boolean
        Try
            fila = Cls_Query.dt("select valor from cruzadi.tbl_parametros WHERE parametro='Parametro_contrasena_Mayusculas'")
            fila2 = Cls_Query.dt("select valor from cruzadi.tbl_parametros WHERE  parametro ='Parametro_contrasena_Caracter'")
            fila3 = Cls_Query.dt("select valor from cruzadi.tbl_parametros WHERE parametro ='Parametro_contrasena_Minuscula'")
            fila4 = Cls_Query.dt("select valor from cruzadi.tbl_parametros WHERE parametro ='Parametro_contrasena_Numero'")
            parametroMayus = CInt(fila.Rows.Item(0).Item(0).ToString)
            parametroCaracter = CInt(fila2.Rows.Item(0).Item(0).ToString)
            ParametroMinus = CInt(fila3.Rows.Item(0).Item(0).ToString)
            ParametroNumeros = CInt(fila4.Rows.Item(0).Item(0).ToString)
            Dim tamaño As Integer
            tamaño = CInt(TamañoContraseña.ToString)


            ' Check the length.
            If Len(pwd) < tamaño Then Return False
            ' Check for minimum number of occurrences.
            If Mayuscula.Matches(pwd).Count < parametroMayus Then Return False
            If Minuscula.Matches(pwd).Count < ParametroMinus Then Return False
            If Numeroregex.Matches(pwd).Count < ParametroNumeros Then Return False
            If Especial.Matches(pwd).Count < parametroCaracter Then Return False

            ' Passed all checks.
            Return True
        Finally
            Conexion.Cerrar_BD()
        End Try
    End Function



    '******************************
    'Confirmar con commit

    Public Sub mytrans(ByVal query As String)
        'Try
        '    If query = "C" Then
        '        Cls_Query.dt("Commit")
        '    Else
        '        Cls_Query.dt("Rollback")

        '    End If

        'Catch ex As Exception
        '    MsgBox("Transaccion incompleta no fue realizada ")
        '    Cls_Query.dt("Rollback")
        'Finally
        '    Conexion.Cerrar_BD()
        'End Try

        Try
            If query = "C" Then
                Cls_Query.dt("begin transaction commit")
            Else
                Cls_Query.dt("begin transaction rollback")

            End If

        Catch ex As Exception
            MsgBox("Transaccion incompleta no fue realizada ")
            Cls_Query.dt("begin transaction rollback")
        Finally
            Conexion.Cerrar_BD()
        End Try





    End Sub

    '******************************

    ''Aleatorio
    Public Function crearpassword(longitud As Integer) As String

        Dim caracteras As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@#$%&/?¡¿*+-.,;"
        Dim res As New StringBuilder()
        Dim rnd As New Random()
        While 0 < System.Math.Max(System.Threading.Interlocked.Decrement(longitud), longitud + 1)
            res.Append(caracteras(rnd.Next(caracteras.Length)))
        End While
        Return res.ToString()
    End Function
    '******************************
    'Ultima Conexion
    Public Function ultima_conexion() As DataTable
        Conexion.Cerrar_BD()
        Return Actualizar("cruzadi.TBL_Reg_Usuario", "Fecha_Ultima_conexion=SYSDATETIME()", "usuario_id='" & ID_Usuario.ToString & "'")
    End Function

    '******************************
    'Parametros de correo 
    Public Function Parametro_Correo() As String
        fila = Cls_Query.dt("SELECT valor FROM cruzadi.tbl_parametros WHERE parametro ='Parametro_correo'")
        correoparametro = fila.Rows.Item(0).Item(0).ToString
        Return correoparametro
    End Function
    Public Function Parametroemailpuerto() As String
        fila = Cls_Query.dt("SELECT valor FROM cruzadi.tbl_parametros WHERE parametro='Parametro_Email_Puerto'")
        puertocorreo = fila.Rows.Item(0).Item(0).ToString

        Return CType(puertocorreo, String)
    End Function
    Public Function Parametro_Email_contraseña() As String
        fila = Cls_Query.dt("SELECT valor FROM cruzadi.tbl_parametros WHERE parametro='Parametro_Email_CONTRASENA'")
        emailcontraseña = fila.Rows.Item(0).Item(0).ToString

        Return emailcontraseña
    End Function
    Public Function PARAMETRO_SERVER_CORREO() As String
        fila = Cls_Query.dt("SELECT valor FROM cruzadi.tbl_parametros WHERE parametro='PARAMETRO_SERVER_CORREO'")
        Emailserver = fila.Rows.Item(0).Item(0).ToString

        Return Emailserver
    End Function
    '******************************
    'Parametro Tamaño COntraseña
    Public Function ParametroTamañoContraseña() As String
        fila = Cls_Query.dt("Select  Valor FROM cruzadi.tbl_parametros WHERE Parametro='Admin_Parametro_Tamano_ContraseNa'")
        TamañoContraseña = CInt(fila.Rows.Item(0).Item(0).ToString)

        Return CType(TamañoContraseña, String)
    End Function
    '******************************
    ' Parametro de Autoregistro
    Public Function ParametroAutoregistro() As Integer
        '    Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
        '  Conexion.conectar(" SOPORTE\ SQLSERVER2014", "Cruzadi")
        Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS01", "Cruzadi")

        fila = Cls_Query.dt("select valor from cruzadi.tbl_parametros where parametro='Parametro_AutoRegistro'")
        existe = fila.Rows.Item(0).Item(0).ToString
        Return CInt(existe)
    End Function

    '******************************
    'Evento de bitacora procedimiento funcional
    Public Sub event_bitacora(ByVal id_usuario As Integer, ByVal id_objeto As Integer, ByVal Accion As String)
        Try
            ' Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS", "Cruzadi")
            'DESKTOP-8PU4GG0\SQLEXPRESS
            'Conexion.conectar(" SOPORTE\ SQLSERVER2014", "Cruzadi")
            Conexion.conectar("DESKTOP-I0V7P0T\SQLEXPRESS01", "Cruzadi")

            Dim sqlCmd = New SqlClient.SqlCommand("insert_bitacora", Conexion.conn)
            sqlCmd.CommandType = System.Data.CommandType.StoredProcedure
            sqlCmd.Parameters.AddWithValue("_id_usuario", Convert.ToInt32(id_usuario))
            sqlCmd.Parameters.AddWithValue("_id_objeto", Convert.ToInt32(id_objeto))
            sqlCmd.Parameters.AddWithValue("_Accion", Accion.ToString)
            sqlCmd.ExecuteNonQuery()
        Catch ex As Exception
            mytrans("R")
            MsgBox("Error En Bitacora")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub

    '******************************


    'Permisos
    '*********************
    Sub Mypermision(ByVal obidV As Integer)
        Try


            fila3 = Cls_Query.dt("Select p.permiso_insercion, p.permiso_Consulta, p.permiso_actualizacion from cruzadi.tbl_permisos p , cruzadi.tbl_reg_usuario u, cruzadi.tbl_roles r, cruzadi.tbl_objetos ob 
        where u.rol_id=r.rol_id and r.rol_id=p.rol_id and p.objeto_id=ob.objeto_id and  u.usuario='" & NombreU.ToString & "' and ob.objeto_id='" & obidV.ToString & "'")
            insercion = CInt(fila3.Rows.Item(0).Item(0).ToString)
            consulta = CInt(fila3.Rows.Item(0).Item(1).ToString)
            actualizacion = CInt(fila3.Rows.Item(0).Item(2).ToString)
        Catch ex As Exception
            mytrans("R")
            MsgBox("Error en los permisos")
        Finally
            Conexion.Cerrar_BD()

        End Try
    End Sub
    Public Function PI(ByVal obidC As Integer) As Boolean
        Mypermision(obidC)
        If permisosI = insercion Then
            bpermisosI = False

        Else
            bpermisosI = True
        End If
        Return bpermisosI
    End Function
    Public Function PC(ByVal obidC As Integer) As Boolean
        Mypermision(obidC)
        If permisosC = consulta Then
            bpermisosC = False

        Else
            bpermisosC = True
        End If

        Return bpermisosC
    End Function
    Public Function PA(ByVal obidC As Integer) As Boolean
        Mypermision(obidC)

        If permisosA = actualizacion Then
            bpermisosA = False

        Else
            bpermisosA = True
        End If
        Return bpermisosA
    End Function
    '********************

End Module
