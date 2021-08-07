using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logica.Validaciones
{
    public class CorreoElectronico
    {
        public static bool EnviarCorreo(MAILCONFIGURATION dataConfiguration, string correo, string asunto, string mensaje)
        {

            #region CuerpoMensaje
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.IsBodyHtml = true;

            //A quien se envía
            msg.To.Add(correo);

            //Asunto del correo

            msg.Subject = asunto;

            //Cuerpo del mensaje
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mensaje, null, MediaTypeNames.Text.Html);

            LinkedResource imageHtmlBanner1 = new LinkedResource(@"C:\Vehiculos\imagen1.jpg", MediaTypeNames.Image.Jpeg);
            imageHtmlBanner1.ContentId = "idBanner1";

            LinkedResource imageHtmlBanner2 = new LinkedResource(@"C:\Vehiculos\imagen2.jpg", MediaTypeNames.Image.Jpeg);
            imageHtmlBanner2.ContentId = "idBanner2";

            htmlView.LinkedResources.Add(imageHtmlBanner1);
            htmlView.LinkedResources.Add(imageHtmlBanner2);

            msg.AlternateViews.Add(htmlView);

            msg.From = new MailAddress(dataConfiguration.mco_username); 
            #endregion

            SmtpClient cliente = new SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential(dataConfiguration.mco_username, dataConfiguration.mco_password);
            cliente.Port = dataConfiguration.mco_port;

            cliente.EnableSsl = true;

            cliente.Host = dataConfiguration.mco_server;

            try
            {
                cliente.Send(msg);
                msg.Dispose();

                return true;

            }
            catch 
            {
                msg.Dispose();
                return false;

            }

        }


    }
}
