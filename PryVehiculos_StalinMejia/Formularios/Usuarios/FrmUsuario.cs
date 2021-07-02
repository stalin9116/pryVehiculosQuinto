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

namespace PryVehiculos_StalinMejia.Formularios.Usuarios
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();

        }
        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            loadUsers();
            loadRols();
        }

        private void loadRols()
        {
            List<ROL> listaRol = new List<ROL>();
            listaRol = logicRol.getAllRols();
            if (listaRol.Count > 0 && listaRol != null)
            {
                listaRol.Insert(0, new ROL
                {
                    rol_id = 0,
                    rol_descripcion = "SELECCIONE ROL"

                }); ;

                cmbRol.DataSource = listaRol;
                cmbRol.DisplayMember = "rol_descripcion";
                cmbRol.ValueMember = "rol_id";
            }
        }

        private void loadUsers()
        {
            try
            {
                List<USUARIO> listaUsuaruarios = new List<USUARIO>();
                listaUsuaruarios = logicUsuarios.getAllUser();
                if (listaUsuaruarios.Count > 0 && listaUsuaruarios != null)
                {
                    dgvUsuarios.DataSource = listaUsuaruarios.Select(data => new
                    {
                        CODIGO = data.usu_id,
                        APELLIDOS = data.usu_apellidos,
                        NOMBRES = data.usu_nombres,
                        CORREO = data.usu_correo,
                        ROL = data.ROL.rol_descripcion
                    }).ToList();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al obtener usuarios", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadUsers2(List<USUARIO> listaUsuaruarios)
        {
            try
            {
                if (listaUsuaruarios.Count > 0 && listaUsuaruarios != null)
                {
                    dgvUsuarios.DataSource = listaUsuaruarios.Select(data => new
                    {
                        CODIGO = data.usu_id,
                        APELLIDOS = data.usu_apellidos,
                        NOMBRES = data.usu_nombres,
                        CORREO = data.usu_correo,
                        ROL = data.ROL.rol_descripcion
                    }).ToList();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al obtener usuarios", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            lblId.Text = "";
            txtApellidos.Text = "";
            txtNombres.Text = "";
            txtCorreo.Text = "";
            txtPassword.Text = "";
            txtConfirmarPassword.Text = "";
            cmbRol.SelectedIndex = 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void saveUser()
        {
            try
            {
                if (validacionCamposObligarios())
                {
                    return;
                }

                USUARIO dataUsuario = new USUARIO();
                dataUsuario.usu_correo = txtCorreo.Text;
                dataUsuario.usu_password = txtPassword.Text;
                dataUsuario.usu_apellidos = txtApellidos.Text.TrimStart().TrimEnd().ToUpper();
                dataUsuario.usu_nombres = txtNombres.Text.TrimStart().TrimEnd().ToUpper();
                dataUsuario.rol_id = Convert.ToInt32(cmbRol.SelectedValue);

                bool result = logicUsuarios.saveUser(dataUsuario);
                if (result)
                {
                    loadUsers();
                    limpiar();
                    MessageBox.Show("Usuario Guardado correctamente", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar el usuario", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateUser()
        {
            try
            {
                if (validacionCamposObligarios())
                {
                    return;
                }

                USUARIO dataUsuario = new USUARIO();
                dataUsuario.usu_id = Convert.ToInt32(lblId.Text);
                dataUsuario.usu_correo = txtCorreo.Text;
                dataUsuario.usu_password = txtPassword.Text;
                dataUsuario.usu_apellidos = txtApellidos.Text.TrimStart().TrimEnd().ToUpper();
                dataUsuario.usu_nombres = txtNombres.Text.TrimStart().TrimEnd().ToUpper();
                dataUsuario.rol_id = Convert.ToInt32(cmbRol.SelectedValue);

                bool result = logicUsuarios.updateUser3(dataUsuario);
                if (result)
                {
                    loadUsers();
                    limpiar();
                    MessageBox.Show("Usuario Modificado correctamente", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar el usuario", "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validacionCamposObligarios()
        {
            bool result = false;

            string messageError = "";

            if (String.IsNullOrEmpty(txtCorreo.Text))
            {
                messageError += "Correo campo obligatorio.\n";
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                messageError += "Password campo obligatorio.\n";
            }
            if (String.IsNullOrEmpty(txtConfirmarPassword.Text))
            {
                messageError += "Confirmar Password campo obligatorio.\n";
            }
            if (String.IsNullOrEmpty(txtNombres.Text))
            {
                messageError += "Nombres campo obligatorio.\n";
            }
            if (String.IsNullOrEmpty(txtApellidos.Text))
            {
                messageError += "Apellidos campo obligatorio.\n";
            }
            if (cmbRol.SelectedIndex == 0)
            {
                messageError += "Seleccione Rol\n";
            }
            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                messageError += "Conntraseña no son iguales\n";
            }


            if (!String.IsNullOrWhiteSpace(messageError))
            {
                result = true;
                MessageBox.Show(messageError, "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                updateUser();
            }
            else
            {
                saveUser();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void Eliminar()
        {
            if (!String.IsNullOrEmpty(lblId.Text))
            {
                var resMessage = MessageBox.Show("Desea eliminar el registro ?", "Sistema Vehicular", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resMessage.ToString() == "Yes")
                {
                    try
                    {
                        USUARIO dataUsuario = new USUARIO();
                        dataUsuario = logicUsuarios.getUserxId(Convert.ToInt32(lblId.Text));
                        if (dataUsuario != null)
                        {
                            if (logicUsuarios.deleteUser(dataUsuario))
                            {
                                MessageBox.Show("Registrado eliminado correctamente jajaja");
                                loadUsers();
                                limpiar();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Sistema Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvUsuarios_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var codigoUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["CODIGO"].Value;
            var correoUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["CORREO"].Value;
            var apellidosUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["APELLIDOS"].Value;
            var nombresUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["NOMBRES"].Value;
            var rolUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["ROL"].Value;

            if (!String.IsNullOrEmpty(codigoUsuario.ToString()))
            {
                lblId.Text = codigoUsuario.ToString();
                txtCorreo.Text = correoUsuario.ToString();
                txtApellidos.Text = apellidosUsuario.ToString();
                txtNombres.Text = nombresUsuario.ToString();
                cmbRol.SelectedIndex = cmbRol.FindString(rolUsuario.ToString());

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            search(cmbFiltro.Text);
        }

        private void search(string op)
        {
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                List<USUARIO> _listaUsuario = new List<USUARIO>();
                string datoaBuscar = txtBuscar.Text.TrimEnd();

                switch (op)
                {
                    case "Todos":
                        _listaUsuario = logicUsuarios.getAllUser();
                        loadUsers2(_listaUsuario);
                        break;
                    case "Apellidos":
                        _listaUsuario = logicUsuarios.getAllUserXApellido(datoaBuscar);
                        loadUsers2(_listaUsuario);
                        break;
                    case "Nombres":
                        _listaUsuario = logicUsuarios.getAllUserXNombre(datoaBuscar);
                        loadUsers2(_listaUsuario);
                        break;
                    case "Correo":
                        _listaUsuario = logicUsuarios.getAllUserXCorreo(datoaBuscar);
                        loadUsers2(_listaUsuario);
                        break;
                    case "Rol":
                        _listaUsuario = logicUsuarios.getAllUserXRol(datoaBuscar);
                        loadUsers2(_listaUsuario);
                        break;
                }

            }

        }

    }
}
