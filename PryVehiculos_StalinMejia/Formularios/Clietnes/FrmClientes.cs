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

namespace PryVehiculos_StalinMejia.Formularios.Clietnes
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            lblId.Text = ".";
            txtIdentificacion.Clear();
            txtApellidos.Clear();
            txtNombres.Clear();
            TxtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            cmbTipoIdentificacion.SelectedIndex = 0;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            saveCliente();
        }

        private void validaciones()
        {


        }

        private void saveCliente()
        {
            try
            {
                CLIENTE datacliente = new CLIENTE();

                datacliente.cli_tipoidentificacion = cmbTipoIdentificacion.Text == "Cedula" ? "CE" :
                                                     cmbTipoIdentificacion.Text == "Ruc" ? "RU" :
                                                     cmbTipoIdentificacion.Text == "Pasaporte" ? "PA" :
                                                     cmbTipoIdentificacion.Text == "Consumidor Final" ? "CF" :
                                                     cmbTipoIdentificacion.Text == "Otros" ? "OT" : null;


                datacliente.cli_identiticacion = txtIdentificacion.Text;
                datacliente.cli_apellidos = txtApellidos.Text.ToUpper();
                datacliente.cli_nombres = txtNombres.Text.ToUpper();
                datacliente.cli_direccion = TxtDireccion.Text.ToUpper();
                datacliente.cli_telefono = txtTelefono.Text.ToUpper();
                datacliente.cli_correo = txtCorreo.Text;
                datacliente.cli_fechanacimiento = dtpFechaNacimiento.Value;

                bool result = logicCliente.saveClient(datacliente);
                if (result)
                {
                    limpiar();
                    MessageBox.Show("Cliente Guardado correctamente", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception )
            {

                MessageBox.Show("Error al guardar el cliente", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            ValidarCedula(e);
        }

        private void ValidarCedula(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string identificacion = txtIdentificacion.Text;
                string tipoIdentificacion = cmbTipoIdentificacion.Text;

                if (!string.IsNullOrEmpty(identificacion))
                {
                    bool validacionIdentificacion = false;

                    switch (tipoIdentificacion)
                    {
                        case "Cedula":
                            validacionIdentificacion = Logica.Validaciones.DigitoVerificador.VerificarCedula(identificacion);
                            break;

                        case "Ruc":
                            validacionIdentificacion = Logica.Validaciones.DigitoVerificador.VerificarRUC(identificacion);
                            break;

                        default:
                            validacionIdentificacion = true;

                            break;
                    }
                    if (!validacionIdentificacion)
                    {
                        MessageBox.Show("Error identificacion invalida", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtApellidos.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Error cedula invalida", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saltoLinea(TextBox text)
        {
            text.Focus();

        }

        private void txtApellidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saltoLinea(txtNombres);
            }
        }

        private void txtNombres_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saltoLinea(TxtDireccion);
            }
        }
    }
}
