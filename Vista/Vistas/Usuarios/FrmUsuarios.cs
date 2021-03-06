using Controladores.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Interfaces;

namespace Vista.Vistas.Usuarios
{
    public partial class FrmUsuarios : Form, IFormClosable
    {
        public string Key { get; set; }
        public UsuariosCatalogoController usuariosCat;
        public FrmUsuarios()
        {
            InitializeComponent();
            usuariosCat = new UsuariosCatalogoController();
            BotonesNuevo();
            SetDatagrid();
            Key = "usuarios";
            this.MaximizeBox = false;
        }
        public void SetDatagrid()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = usuariosCat.Listar(txtId.Text, txtNombre.Text, txtUsuario.Text, txtContraseña.Text);
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsuarios.Columns[dgvUsuarios.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(usuariosCat.Agregar(txtNombre.Text, txtUsuario.Text, txtContraseña.Text));
            LimpiarCampos();
            SetDatagrid();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(usuariosCat.Modificar(txtId.Text, txtNombre.Text, txtUsuario.Text, txtContraseña.Text));
            LimpiarCampos();
            SetDatagrid();

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(usuariosCat.Desactivar(txtId.Text));
                LimpiarCampos();
                SetDatagrid();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            SetDatagrid();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            BotonesNuevo();
        }

        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                txtId.Text = dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNombre.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtContraseña.Text = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                BotonesEdicion();
            }
            
        }
    }
}
