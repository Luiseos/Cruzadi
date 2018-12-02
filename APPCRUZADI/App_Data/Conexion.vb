
Imports System.IO
Imports System.Security.Cryptography
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.SqlServer

'Imports MySql.Data.MySqlClient



Public Class Conexion
    '' MySqlConnection
    'Public Shared conn As New SqlClient.SqlConnection  'para sql server

    'Public Shared Function conectar(ByVal x As String, ByVal y As String) As Boolean
    '    ' para sql server ' 
    '    Dim String_Conection As String = ("server=" & x & ";INITIAL catalog=" & y & ";Integrated security=true")
    '    ' Dim String_conection As String = ("server=" & x & "; database=" & y & "; Uid=root; pwd=;  SslMode=none;  Convert Zero Datetime=True;") ''ultimas dos motivos de abrir base y date
    Public Shared conn As New SqlClient.SqlConnection
    Public Shared Function conectar(ByVal x As String, ByVal y As String) As Boolean
        Dim String_Conection As String = ("server=" & x & ";INITIAL catalog=" & y & ";Integrated security=true")
        Try
            conn.ConnectionString = String_Conection
            If conn.State = ConnectionState.Open Then
                conectar = True
            Else
                conn.Open()
                conectar = True

            End If
        Catch ex As Exception
            conectar = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al conectar a la BD")
        End Try
    End Function
    Public Shared Sub Abrir_BD()
        If conn.State = ConnectionState.Open Then
        Else
            conn.Open()
        End If
    End Sub
    Public Shared Sub Cerrar_BD()
        If conn.State = ConnectionState.Closed Then
        Else
            conn.Close()
        End If
    End Sub

End Class
Public Class Cls_Query

    'Funcion que retorna en DataTable apartir de una Consulta(select)
    Public Shared Function dt(ByVal query As String) As DataTable

        Dim adapter As New SqlClient.SqlDataAdapter(query, Conexion.conn)
        Dim table As New DataTable

        'Limpiar la Tabla
        table.Clear()

        'Establecer el tipo de tabla
        table.Locale = System.Globalization.CultureInfo.InvariantCulture

        'Llenar Tabla
        adapter.Fill(table)

        'Retorna la tabla
        Return table
    End Function


    'Public Shared Function Prom(ByVal procedimiento As String) As String




    '    Dim comando As New MySqlCommand




    '    Try
    '        comando.CommandText = procedimiento
    '        comando.CommandType = CommandType.StoredProcedure
    '        comando.Connection = Conexion.conn
    '        comando.ExecuteReader()
    '        Conexion.Cerrar_BD()
    '        Return Nothing
    '    Catch ex As Exception
    '        MsgBox(ex.Message.ToString)
    '        Return Nothing
    '    End Try
    'End Function


End Class





