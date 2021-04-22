using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Vista.Interfaces;

namespace Vista.Vistas.NotasVenta
{
    public partial class FrmEncabezadoNota : Form, IFormClosable
    {
        public string Key { get; set; }
        public FrmEncabezadoNota()
        {
            InitializeComponent();
            Key = "encabezadoNota";
        }

        
    }
}
