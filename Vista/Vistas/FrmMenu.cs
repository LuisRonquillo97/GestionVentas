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
        public FrmMenu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ms1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Cat. Usuarios":
                    FrmUsuarios frmUsuarios = new FrmUsuarios();
                    frmUsuarios.MdiParent = this;
                    frmUsuarios.Show();
                    break;
            }
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
