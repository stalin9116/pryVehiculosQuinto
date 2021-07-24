using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logicEmail
    {

        private static dcVehiculoDataContext dc = new dcVehiculoDataContext();
        public static MAILCONFIGURATION getServerConfigEmail()
        {
            try
            {
                var resultMailConfig = dc.MAILCONFIGURATION.FirstOrDefault(users => users.mco_status == 'A');

                return resultMailConfig;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
