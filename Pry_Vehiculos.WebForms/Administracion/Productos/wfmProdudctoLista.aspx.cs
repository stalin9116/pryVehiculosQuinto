using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Logica;


namespace Pry_Vehiculos.WebForms.Administracion.Productos
{
    public partial class wfmProdudctoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadProducts();
            }
        }

        private void loadProducts()
        {
            List<PRODUCTO> listaProductos = new List<PRODUCTO>();
            listaProductos = logicProducto.getAllProducts();
            if (listaProductos.Count > 0 && listaProductos != null)
            {
                gdvProductos.DataSource = listaProductos.Select(data => new
                {
                    ID = data.pro_id,
                    CODIGO = data.pro_codigo,
                    NOMBRE = data.pro_nombre,
                    PRECIO = data.pro_precio,
                    CATEGORIA = data.CATEGORIA.cat_descripcion,
                    STOCKMIN = data.pro_stockminimo,
                    STOCKMAX = data.pro_stokcmaximo
                }).ToList();

                gdvProductos.DataBind();
            }


            //dgvUsuarios.DataSource = listaUsuaruarios.Select(data => new
            //{
            //    CODIGO = data.usu_id,
            //    APELLIDOS = data.usu_apellidos,
            //    NOMBRES = data.usu_nombres,
            //    CORREO = data.usu_correo,
            //    ROL = data.ROL.rol_descripcion
            //}).ToList();
        }

        protected void gdvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Modificar")
            {
                //codigo 

                Response.Redirect("wfmProductoNuevo.aspx?cod=" + codigo);

                //Modificar
            }
            else if (e.CommandName == "Eliminar")
            {
                try
                {
                    //Eliminar
                    PRODUCTO producto = new PRODUCTO();
                    producto = logicProducto.getProdctxId(int.Parse(codigo));
                    if (producto != null)
                    {
                        if (logicProducto.deleteProduct(producto))
                        {
                            loadProducts();
                        }
                    }
                }
                catch (Exception ex)
                {

                    //Log de la eliminacion
                }


            }


        }

        private void newProduct()
        {
            Response.Redirect("wfmProductoNuevo.aspx");
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            newProduct();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            newProduct();
        }
    }
}