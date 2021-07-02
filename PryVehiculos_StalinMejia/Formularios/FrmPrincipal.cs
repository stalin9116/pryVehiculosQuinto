using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryVehiculos_StalinMejia.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formularios.Usuarios.FrmUsuario frmUsuario = new Usuarios.FrmUsuario();
            frmUsuario.Show();
        }
    }
}
