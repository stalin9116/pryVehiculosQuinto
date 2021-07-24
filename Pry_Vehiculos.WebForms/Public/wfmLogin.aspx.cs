using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Logica;

namespace Pry_Vehiculos.WebForms.Public
{
    public partial class wfmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            loginUser();
        }

        private void loginUser()
        {
            try
            {
                string usuario = txtCorreo.Text.Trim();
                string clave = txtClave.Text;

                USUARIO datosUsuario = new USUARIO();
                datosUsuario = logicUsuarios.getUserxLogin(usuario, Logica.Validaciones.Encriptar.GetMD5Hash(clave));
                if (datosUsuario != null)
                {
                    Session["Usuario"] = datosUsuario;

                    Response.Redirect("../Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Usuario o clave incorrectat');</script>");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}