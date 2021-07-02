using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PryConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehiculo> _listaVehiculos = new List<Vehiculo>();

            try
            {
                Persona persona = new Persona();

                Console.WriteLine("Ingrese Identificacion: ");
                persona.identificacion = Console.ReadLine();
                Console.WriteLine("Ingrese Nombres: ");
                persona.nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Sueldo: ");
                persona.sueldo = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Ingrese Dias Trabajados: ");
                persona.dias = Convert.ToInt32(Console.ReadLine());

                decimal totalSueldo = calculos.calcularSueldo(persona.sueldo, persona.dias);
                decimal iess = calculos.calcularIess(totalSueldo);


                decimal netoaRecibir = totalSueldo - iess;


                Console.WriteLine("Iess: " + iess.ToString("0.##"));
                Console.WriteLine("Sueldo a recibir: " + netoaRecibir);

                Console.ReadLine();
            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}
