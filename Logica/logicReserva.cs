using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logicReserva
    {
        private static dcVehiculoDataContext dc = new dcVehiculoDataContext();

        public static bool saveReserva(RESERVA dataRESERVA)
        {
            try
            {
                bool resultado = false;

                dataRESERVA.res_status = 'A';
                dataRESERVA.res_add = DateTime.Now;


                dc.RESERVA.InsertOnSubmit(dataRESERVA);
                //commit
                dc.SubmitChanges();




                resultado = true;

                return resultado;
            }
            catch (Exception)
            {
                throw new ArgumentException("Eror al guardar el RESERVA");
                //Guardar información en un archivo - base de datos - EventLog
            }
        }



        private static string renderHtmltoString(string cliente, DateTime fecha)
        {
            string body = string.Empty;

            using (StreamReader reader = new StreamReader(@"C:\Vehiculos\plantilla.html"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("@Cliente", cliente);
                body = body.Replace("@Fecha", fecha.ToLongDateString());
            }
            return body;
        }


        public static bool sendEmail(string correo, string cliente, DateTime fecha)
        {
            try
            {
                var serverconfig = logicEmail.getServerConfigEmail();
                string asunto = "Reserva Vehiculos Quinto Nocturno";

                bool res = Validaciones.CorreoElectronico.EnviarCorreo(serverconfig, correo, asunto, renderHtmltoString(cliente, fecha));

                return res;
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
