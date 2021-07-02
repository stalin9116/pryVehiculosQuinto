using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Logica;

namespace PryVehiculos_StalinMejia.Formularios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            string user = txtCorreo.Text.TrimStart().TrimEnd();
            string clave = txtClave.Text;

            if (!string.IsNullOrEmpty(user))
            {
                if (!string.IsNullOrEmpty(clave))
                {
                    try
                    {
                        USUARIO dataUsuario = new USUARIO();
                        dataUsuario = logicUsuarios.getUserxLogin(user, Logica.Validaciones.Encriptar.GetMD5Hash(clave));
                        if (dataUsuario != null)
                        {
                            MessageBox.Show("Bienvenido al sistema " + dataUsuario.usu_nombres + " "
                                            + dataUsuario.usu_apellidos + " - "
                                            + dataUsuario.ROL.rol_descripcion);

                            FrmPrincipal frmPrincipal = new FrmPrincipal();
                            frmPrincipal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o clave Incorrecta");
                            //Contador 3 Bloquee el usuario
                            

                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error en cuminicación con el servidor " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Clave Campo Obligatorio");

                }

            }
            else
            {
                MessageBox.Show("Correo Campo Obligatorio");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
