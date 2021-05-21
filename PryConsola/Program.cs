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

                Vehiculo vehiculo = new Vehiculo();
                vehiculo.codigo = 1;
                vehiculo.placa = "PCW5065";
                vehiculo.color = "Plomo";
                vehiculo.modelo = "Toyota";

                _listaVehiculos.Add(vehiculo);

                Vehiculo vehiculo2 = new Vehiculo();
                vehiculo2.codigo = 2;
                vehiculo2.placa = "PCW8090";
                vehiculo2.color = "Negro";
                vehiculo2.modelo = "VW";
                _listaVehiculos.Add(vehiculo2);

                //Vehiculo vehiculo = new Vehiculo();

                //Console.WriteLine("Ingrese Codigo: ");
                //vehiculo.codigo = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Ingrese Placa: ");
                //vehiculo.placa = Console.ReadLine();
                //Console.WriteLine("Ingrese Color: ");
                //vehiculo.color = Console.ReadLine();
                //Console.WriteLine("Ingrese Chasis: ");
                //vehiculo.chasis = Console.ReadLine();
                //Console.WriteLine("Ingrese Modelo: ");
                //vehiculo.modelo = Console.ReadLine();

                //_listaVehiculos.Add(vehiculo);

                foreach (var item in _listaVehiculos.Where(data => data.codigo == 1
                                                           && data.modelo.Equals("VW")))
                {
                    Console.WriteLine("Codigo: " + item.codigo);
                    Console.WriteLine("Placa: " + item.placa);
                    Console.WriteLine("Color: " + item.color);
                    Console.WriteLine("Modelo: " + item.modelo);
                }

                Console.ReadLine();
            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}
