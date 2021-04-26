
namespace Vista.Vistas.NotasVenta
{
    partial class FrmCambio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblTextoCambio = new System.Windows.Forms.Label();
            this.lblCantidadCambio = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Con cuánto dinero está pagando el cliente?";
            // 
            // lblTextoCambio
            // 
            this.lblTextoCambio.AutoSize = true;
            this.lblTextoCambio.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTextoCambio.Location = new System.Drawing.Point(12, 85);
            this.lblTextoCambio.Name = "lblTextoCambio";
            this.lblTextoCambio.Size = new System.Drawing.Size(115, 28);
            this.lblTextoCambio.TabIndex = 2;
            this.lblTextoCambio.Text = "Su cambio:";
            // 
            // lblCantidadCambio
            // 
            this.lblCantidadCambio.AutoSize = true;
            this.lblCantidadCambio.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCantidadCambio.Location = new System.Drawing.Point(195, 85);
            this.lblCantidadCambio.Name = "lblCantidadCambio";
            this.lblCantidadCambio.Size = new System.Drawing.Size(0, 28);
            this.lblCantidadCambio.TabIndex = 3;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(140, 137);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(75, 23);
            this.btnFinalizar.TabIndex = 4;
            this.btnFinalizar.Text = "Finalizar venta";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(12, 43);
            this.txtCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(240, 23);
            this.txtCantidad.TabIndex = 5;
            this.txtCantidad.ValueChanged += new System.EventHandler(this.CalcularDiferencia);
            // 
            // FrmCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 194);
            this.ControlBox = false;
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.lblCantidadCambio);
            this.Controls.Add(this.lblTextoCambio);
            this.Controls.Add(this.label1);
            this.Name = "FrmCambio";
            this.Text = "FrmCambio";
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTextoCambio;
        private System.Windows.Forms.Label lblCantidadCambio;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.NumericUpDown txtCantidad;
    }
}