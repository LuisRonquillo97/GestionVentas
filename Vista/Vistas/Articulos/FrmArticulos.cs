using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Interfaces;

namespace Vista.Vistas.Articulos
{
    public partial class FrmArticulos : Form, IFormClosable
    {
        public string Key { get; set; }
        public FrmArticulos()
        {
            InitializeComponent();
            Key = "articulos";
        }

        
    }
}
