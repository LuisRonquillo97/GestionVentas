using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Vistas.Usuarios;

namespace Vista.Vistas
{
    public partial class FrmMenu : Form
    {
        /*
         * Este es el menú principal del sistema.
         * llegaremos aquí una vez iniciemos sesión.
         * utilizamos el formato MDI que mostró el instructor del curso.
         */
        public FrmMenu()
        {
            InitializeComponent();
            //cuando se abra esta ventana, le decimos que se maximice.
            this.WindowState = FormWindowState.Maximized;
        }
        /*
         * Método que sirve para saber que item del menu fué clickeado.
         */
        private void ms1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //hacemos un swich para comparar todos los posibles botones del menú que hay.
            switch (e.ClickedItem.Text)
            {
                case "Cat. Usuarios":
                    //inicializamos el formulario
                    FrmUsuarios frmUsuarios = new FrmUsuarios();
                    //le decimos al formulario que debe abrirse en el MDI del menú.
                    frmUsuarios.MdiParent = this;
                    //mostramos el formulario y salimos del switch.
                    frmUsuarios.Show();
                    break;
            }
        }
        /*
         * recordemos que el form de iniciar sesión está oculto. Si cerramos el form menú, la aplicación no termina.
         * para solucionar esto, haremos que cuando se presione el botón de cerrar del form de menú, se termine la aplicación.
         */
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
