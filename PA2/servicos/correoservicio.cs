using PA2.Models;
using MailKit.Security;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace PA2.servicos
{
    public static class correoservicio
    {
        private static string Host = "smtp.gmail.com";
        private static int Puerto = 587;

        private static string NombreEnvia = "AUTOMOTIVE COOLING SERVICES";
        private static string Correo = "veracarlos54321@gmail.com";
        private static string Clave = "auig fzcn qqfl dvjj";

        public static bool enviar (correodts correodts)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(NombreEnvia, Correo));
                email.To.Add(MailboxAddress.Parse(correodts.para));
                email.Subject=correodts.asunto;
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = correodts.contenido
                };
                var smtp = new SmtpClient();
                smtp.Connect(Host, Puerto, SecureSocketOptions.StartTls);

                smtp.Authenticate(Correo,Clave);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
