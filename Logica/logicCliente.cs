using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logicCliente
    {
        private static dcVehiculoDataContext dc = new dcVehiculoDataContext();

        public static List<CLIENTE> getAllClients()
        {
            try
            {
                var resultCLIENTEs = dc.CLIENTE.Where(users => users.cli_status == 'A')
                                                     .OrderBy(data => data.cli_apellidos);



                return resultCLIENTEs.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static CLIENTE getClientxId(int clientId)
        {
            try
            {
                var resultCLIENTE = dc.CLIENTE.Where(users => users.cli_status == 'A'
                                                     && users.cli_id.Equals(clientId)).FirstOrDefault();

                return resultCLIENTE;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool saveClient(CLIENTE dataCLIENTE)
        {
            try
            {
                bool resultado = false;

                dataCLIENTE.cli_status = 'A';
                dataCLIENTE.cli_add = DateTime.Now;
                

                dc.CLIENTE.InsertOnSubmit(dataCLIENTE);
                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception )
            {
                throw new ArgumentException("Eror al guardar el CLIENTE");
                //Guardar información en un archivo - base de datos - EventLog
            }
        }

        public static bool updateClient(CLIENTE dataCLIENTE)
        {
            try
            {
                bool resultado = false;

                dataCLIENTE.cli_status = 'A';
                dataCLIENTE.cli_add = DateTime.Now;

                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool deleteClient(CLIENTE dataCLIENTE)
        {
            try
            {
                bool resultado = false;

                dataCLIENTE.cli_status = 'I';
                dataCLIENTE.cli_add = DateTime.Now;

                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
