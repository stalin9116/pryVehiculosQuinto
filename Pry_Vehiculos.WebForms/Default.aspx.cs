using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Logica;


namespace Pry_Vehiculos.WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                USUARIO datosUsuario = new USUARIO();
                datosUsuario = (USUARIO)Session["Usuario"];
                if (datosUsuario != null)
                {
                    lblUsuario.Text = datosUsuario.usu_nombres + " " + datosUsuario.usu_apellidos;
                    lblRol.Text = datosUsuario.ROL.rol_descripcion;
                }
                else
                {
                    Response.Redirect("/Public/wfmLogin.aspx");
                }
            }
        }
    }
}