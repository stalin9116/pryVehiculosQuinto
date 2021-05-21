using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryConsola
{
    public class Vehiculo : TipoVehiculo
    {
        public int codigo { get; set; }
        public string placa { get; set; }
        public string chasis { get; set; }
        public string color { get; set; }
        public string modelo { get; set; }
        public Vehiculo()
        {

        }
    }
}
