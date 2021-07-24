using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryVehiculos_StalinMejia.Formularios.Productos
{
    public partial class FrmUploadCsv : Form
    {
        public FrmUploadCsv()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            uploadFile();
        }


        private void uploadFile()
        {
            try
            {
                var res = File.ReadAllLines(@"C:\Csv\test.csv").
                       Select(x => x.Split(';'))
                           .Select(x =>
                               new PRODUCTO
                               {
                                   pro_codigo = x[0],
                                   pro_nombre = x[1],
                                   pro_precio = Convert.ToDecimal(x[2]),
                                   pro_stockminimo = Convert.ToInt32(x[3]),
                                   pro_stokcmaximo = Convert.ToInt32(x[4]),
                                   pro_original = Convert.ToBoolean(x[5]),
                                   pro_observacion = x[6],
                                   cat_id = Convert.ToByte(x[7])
                               });

                int i = 1;
                bool validacion = true;

                if (validacion)
                {

                    Logica.logicProducto.saveProduct2(res.ToList());

                }



                //VALIDACION
                foreach (var producto in res)
                {
                    var existeProducto = Logica.logicProducto.getProdctxName(producto.pro_nombre);
                    if (existeProducto != null)
                    {
                        MessageBox.Show("Producto ya existe por favor validar\nVerifique linea " + i +
                                        "\nNombre Producto " + existeProducto.pro_nombre);
                        validacion = false;
                        return;
                    }
                    i = i + 1;
                }

                //VALIDACION




            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
