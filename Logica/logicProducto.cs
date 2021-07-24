using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Logica
{
    public class logicProducto
    {

        private static dcVehiculoDataContext dc = new dcVehiculoDataContext();

        public static PRODUCTO getProdctxCode(string codeProducto)
        {
            try
            {
                var resultPRODUCTO = dc.PRODUCTO.Where(products => products.pro_status == 'A'
                                                     && products.pro_codigo.Equals(codeProducto)).FirstOrDefault();

                return resultPRODUCTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static PRODUCTO getProdctxName(string nameProducto)
        {
            try
            {
                var resultPRODUCTO = dc.PRODUCTO.Where(products => products.pro_status == 'A'
                                                     && products.pro_nombre.Equals(nameProducto)).FirstOrDefault();

                return resultPRODUCTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool saveProduct(PRODUCTO dataProducto)
        {
            try
            {
                bool resultado = false;

                dataProducto.pro_status = 'A';
                dataProducto.pro_add = DateTime.Now;


                dc.PRODUCTO.InsertOnSubmit(dataProducto);
                //commit
                dc.SubmitChanges();

                resultado = true;

                return resultado;
            }
            catch (Exception)
            {
                throw new ArgumentException("Eror al guardar el PRODUCTO");
                //Guardar información en un archivo - base de datos - EventLog
            }
        }


        public static bool saveProduct2(List<PRODUCTO> ListadataProducto)
        {
            using (TransactionScope tran= new TransactionScope())
            {
                try
                {
                    bool resultado = false;

                    foreach (var dataProducto in ListadataProducto)
                    {

                        dataProducto.pro_status = 'A';
                        dataProducto.pro_add = DateTime.Now;

                        var existeProducto = Logica.logicProducto.getProdctxName(dataProducto.pro_nombre);
                        if (existeProducto != null)
                        {
                            throw new ArgumentException("Eror al guardar el PRODUCTO ya existe");
                        }

                        dc.PRODUCTO.InsertOnSubmit(dataProducto);
                        
                        dc.SubmitChanges(); 
                    }

                    resultado = true;
                    //commit
                    tran.Complete();

                    return resultado;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Eror al guardar el PRODUCTO");
                    //Guardar información en un archivo - base de datos - EventLog
                } 
            }
        }

    }
}
