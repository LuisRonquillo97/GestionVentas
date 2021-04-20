using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Controladores.Catalogos;

namespace Vista.Vistas.InicioSesion
{
    public partial class FrmIniciarSesion : Form
    {
        private UsuariosCatalogoController usuariosCat;
        public FrmIniciarSesion()
        {
            InitializeComponent();
            usuariosCat = new UsuariosCatalogoController();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string result=usuariosCat.IniciarSesion(txtUsuario.Text, txtContraseña.Text);
            if (string.IsNullOrEmpty(result))
            {
                FrmMenu menu = new FrmMenu();
                menu.Show();
                this.Visible=false;
            }
            else
            {
                MessageBox.Show(result);
            }
        }
    }
}
