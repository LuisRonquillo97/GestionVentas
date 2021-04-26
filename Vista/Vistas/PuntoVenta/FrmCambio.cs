using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vista.Vistas.PuntoVenta
{
    public partial class FrmCambio : Form
    {
        private readonly decimal DineroAPagar = 0;
        public FrmCambio(decimal dineroAPagar)
        {
            this.DineroAPagar = dineroAPagar;
            InitializeComponent();
            txtCantidad.KeyUp += CalcularDiferencia;
            CalcularDiferencia(this, new EventArgs());
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalcularDiferencia(object sender, EventArgs e)
        {
            decimal diferencia = DineroAPagar - txtCantidad.Value;
            if (diferencia > 0)
            {
                lblTextoCambio.Text = "Faltan:";
                lblCantidadCambio.Text = "$" + diferencia.ToString("###,###.##");
                lblTextoCambio.ForeColor = Color.Red;
                lblCantidadCambio.ForeColor = Color.Red;
                btnFinalizar.Enabled = false;
            }
            else
            {
                lblTextoCambio.Text = "Da de cambio:";
                lblCantidadCambio.Text = "$" + diferencia.ToString("###,###.##");
                lblTextoCambio.ForeColor = Color.Green;
                lblCantidadCambio.ForeColor = Color.Green;
                btnFinalizar.Enabled = true;
            }
            
        }
    }
}
