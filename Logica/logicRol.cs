using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logicRol
    {
        private static dcVehiculoDataContext dc = new dcVehiculoDataContext();

        public static List<ROL> getAllRols()
        {
            try
            {
                var resultROLs = dc.ROL.Where(rols => rols.rol_status == 'A')
                                                     .OrderBy(data => data.rol_descripcion);


                return resultROLs.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
