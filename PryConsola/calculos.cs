using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryConsola
{
    public class calculos
    {

        public static decimal calcularSueldo(decimal sueldo, int numeroDias)
        {
            return (numeroDias * sueldo) / 30;
        }

        public static decimal calcularIess(decimal sueldo)
        {
            decimal resultadoIess = 0;
            resultadoIess = (sueldo * Convert.ToDecimal("9.45"))/100;
            return resultadoIess;
        }


        public void test()
        { 
        
        }


    }
}
