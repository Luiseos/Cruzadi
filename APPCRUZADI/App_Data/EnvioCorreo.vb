Imports System.Net.Mail
Public Class enviocorreo
    Inherits System.Web.UI.Page


    Public Shared Sub enviarcorreo(ByVal correousuario As String, ByVal Recu As String, ByVal fvacorreoparametro As String, ByVal fvapuertocorreo As String, ByVal fvaemailcontraseña As String, ByVal fvaemailserver As String)
        Try
            Dim mail As New MailMessage



            mail.From = New MailAddress(fvacorreoparametro, "Recuperacion Cruzadi")
            mail.To.Add(correousuario)
            mail.Subject = ("CAMBIO DE CONTRASEÑA")

            mail.Body = ("Buen Dia Estimad@ 

se le envia su nueva contraseña: '" & Recu.ToString & "'
        
sin mas que decir, 
saludos Cordiales")
            mail.Priority = MailPriority.High
            Dim servidor As New SmtpClient(fvaemailserver)
            servidor.Port = CInt(fvapuertocorreo.ToString)
            servidor.EnableSsl = False

            servidor.Host = (fvaemailserver)
            servidor.Credentials = New System.Net.NetworkCredential(fvacorreoparametro, fvaemailcontraseña)
            servidor.Send(mail)

        Catch ex As Exception
            errorserver = "N"
            MsgBox("Ha Surgido un problema en el receptor del correo")

        End Try
    End Sub

    Public Shared Sub enviarcorreoSoporte(ByVal correousuario As String, ByVal fvacorreoparametro As String, ByVal fvapuertocorreo As String, ByVal fvaemailcontraseña As String, ByVal fvaemailserver As String, ByVal Asunto As String, ByVal Respuesta As String)
        Try
            Dim mail As New MailMessage



            mail.From = New MailAddress(fvacorreoparametro, "SOPORTE")
            mail.To.Add(correousuario)
            mail.Subject = (Asunto)

            mail.Body = (Respuesta)
            mail.Priority = MailPriority.High
            Dim servidor As New SmtpClient(fvaemailserver)
            servidor.Port = CInt(fvapuertocorreo.ToString)
            servidor.EnableSsl = False

            servidor.Host = (fvaemailserver)
            servidor.Credentials = New System.Net.NetworkCredential(fvacorreoparametro, fvaemailcontraseña)
            servidor.Send(mail)

        Catch ex As Exception
            errorserver = "N"
            MsgBox("Ha Surgido un problema en el receptor del correo")
        End Try
    End Sub


End Class
