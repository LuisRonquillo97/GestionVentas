using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Interfaces;

namespace Vista.Vistas.DetallesNotaVenta
{
    public partial class FrmDetalleNota : Form, IFormClosable
    {
        public string Key { get; set; }
        public FrmDetalleNota(int? idEncabezado=null)
        {
            Key = "DetalleNotas";
            InitializeComponent();
        }

        
    }
}
