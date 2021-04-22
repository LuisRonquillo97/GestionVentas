using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Interfaces;

namespace Vista.Vistas.Clientes
{
    public partial class FrmClientes : Form, IFormClosable
    {
        public string Key { get; set; }
        public FrmClientes()
        {
            InitializeComponent();
            Key = "clientes";
        }

        
    }
}
