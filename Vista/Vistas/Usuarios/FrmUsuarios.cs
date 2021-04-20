using Controladores.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista.Vistas.Usuarios
{
    public partial class FrmUsuarios : Form
    {
        public UsuariosCatalogoController usuariosCat;
        public FrmUsuarios()
        {
            InitializeComponent();
            usuariosCat = new UsuariosCatalogoController();
            BotonesNuevo();
            SetDatagrid();
        }
        public void SetDatagrid()
        {
            dgvUsuarios.DataSource = null;
            if(int.TryParse(txtId.Text, out int id))
            {
                dgvUsuarios.DataSource = usuariosCat.ListarUsuarios(id, txtNombre.Text, txtUsuario.Text, txtContraseña.Text);
            }
            else
            {
                dgvUsuarios.DataSource = usuariosCat.ListarUsuarios(null, txtNombre.Text, txtUsuario.Text, txtContraseña.Text);
            }
            
        }
        public void BotonesEdicion()
        {
            txtId.Enabled = false;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnBuscar.Enabled = false;
        }
        public void BotonesNuevo()
        {
            txtId.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnBuscar.Enabled = true;
        }
        public void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            BotonesNuevo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(usuariosCat.Agregar(txtNombre.Text, txtUsuario.Text, txtContraseña.Text));
            LimpiarCampos();
            SetDatagrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(usuariosCat.Modificar(id, txtNombre.Text, txtUsuario.Text, txtContraseña.Text));
                LimpiarCampos();
                SetDatagrid();
            }
            else
            {
                MessageBox.Show("ID inválido.");
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show(usuariosCat.Desactivar(id));
                    LimpiarCampos();
                    SetDatagrid();
                }
                else
                {
                    MessageBox.Show("ID inválido.");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SetDatagrid();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            BotonesNuevo();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNombre.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtContraseña.Text = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
            BotonesEdicion();
        }
    }
}
