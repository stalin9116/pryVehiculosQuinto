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

namespace PryVehiculos_StalinMejia.Formularios.Reserva
{
    public partial class FrmReserva : Form
    {
        private CLIENTE cliente = new CLIENTE();

        public FrmReserva()
        {
            InitializeComponent();
        }

        private void buscarCliente()
        {
            string identificación = txtIdentificacion.Text.TrimEnd().TrimStart();

            if (!string.IsNullOrEmpty(identificación))
            {
                
                cliente = logicCliente.getClientxIdentificacion(identificación);
                if (cliente != null)
                {
                    lblNombre.Text = cliente.cli_apellidos + " " + cliente.cli_nombres;
                }
                else
                {
                    MessageBox.Show("Cliente no existe", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Formularios.Clietnes.FrmClientes frmClientes = new Clietnes.FrmClientes(identificación);
                    frmClientes.Show();


                }
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarCliente();
        }

        private void save()
        {
            try
            {
                RESERVA reserva = new RESERVA();
                reserva.cli_id = cliente.cli_id;
                reserva.res_observacion = txtObservacion.Text.ToUpper();
                reserva.res_fecha = dateTimePicker1.Value;
                reserva.res_numero = 1;
                //reserva.res_numero = int.Parse(lblNumero.Text);
                logicReserva.saveReserva(reserva);
                MessageBox.Show("Reserva guardada correctamente", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool resEmail = logicReserva.sendEmail(cliente.cli_correo, cliente.cli_apellidos + " " + cliente.cli_nombres, reserva.res_fecha);
                if (resEmail)
                {
                    MessageBox.Show("Correo enviado correctamente", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al guardar la reserva", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}
