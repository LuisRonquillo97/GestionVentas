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
    /*
     * No hay nada más que mover aquí. 
     * Sólo contiene el método para iniciar sesión, y si accede, ocultamos este form y abrimos el siguiente.
     */
    public partial class FrmIniciarSesion : Form
    {
        private UsuariosCatalogoController usuariosCat;
        public FrmIniciarSesion()
        {
            InitializeComponent();
            usuariosCat = new UsuariosCatalogoController();
        }
        public void IniciarSesion()
        {
            string result = usuariosCat.IniciarSesion(txtUsuario.Text, txtContraseña.Text);
            //si iniciar sesión no nos devuelve ningun mensaje, dejamos que el usuario entre al sistema.
            if (string.IsNullOrEmpty(result))
            {
                //inicializamos el menú, 
                FrmMenu menu = new FrmMenu();
                menu.Show();
                this.Visible = false;
            }
            else
            {
                //si devuelve mensaje, se lo mostramos al usuario.
                MessageBox.Show(result);
            }
        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IniciarSesion();
            }
        }
    }
}
