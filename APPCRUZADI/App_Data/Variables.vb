Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Imports System.Text.RegularExpressions
Public Module Variables
    '******************************
    '++++Variables del Loogin
    Public contador As Integer = 0
    Public conexion As New Conexion
    'Obtiene la fila del la consulta resaltando que fila se utiliza en regitro y login
    Public fila, fila2, fila3, fila4 As DataTable

    'Variables a utilizar la confirmacion login nombreU para pregunta
    Public Usuario, Contraseña, NombreU, ID_Usuario As String
    Public Estado, Pr_Intento, max, estadoRegistro, vencimiento As Integer
    Public vencimiento1 As Date
    '++++Variables de Registro
    Public existe, Num_Usuario, Contraseñar As String 'num_Usuario, contraseñar hasta solucionar los modales
    Public TamañoContraseña As Integer
    Public confirmar As String '  Confirmar no utilizada

    'Via Pregunta

    'Correo
    Public correoparametro, correo, puertocorreo, emailcontraseña, Recualeatoria, Emailserver As String
    Public vacorreoparametro, vapuertocorreo, vaemailcontraseña, vaemailserver, errorserver As String

    Public preguntas, Respuesta As String
    Public correousuario As String
    Public correoadmin As String

    Public palabra As String

    'Public palabra As String

    '******************************
    Public envio As New enviocorreo

    '******************************
    Public combobox, nuevo As String
    '*******

    ' ************
    'Site1 Para los permisos de acuerdo a las pantallas

    'Capta las filas.
    Public obid, insercion, eliminacion, actualizacion, consulta As Integer
    'Compara los valores con los de la fila
    Public permisosI, permisosE, permisosA, permisosC As Integer
    'Valores que son permitidos true o false
    Public bpermisosI, bpermisosE, bpermisosA, bpermisosC As Boolean

    ' ************
    'Crear Ejecutiva
    Public emailid, telid As Integer
    Public comparador, comparador2 As String
    'Crear CLiente
    Public telefono As String


    '+++ Variables de Funcionalidad de la funcion de verificar contraseña
    Public parametroCaracter, parametroMayus, ParametroMinus, ParametroNumeros As Integer
    Public Mayuscula As New System.Text.RegularExpressions.Regex("[A-Z]")
    Public Minuscula As New System.Text.RegularExpressions.Regex("[a-z]")
    Public Numeroregex As New System.Text.RegularExpressions.Regex("[0-9]")
    Public Especial As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

End Module
