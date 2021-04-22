
namespace Vista.Vistas
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiArticulos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEncabezados = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDetalles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArticulos,
            this.tsmiClientes,
            this.tsmiNotas,
            this.tsmiUsuario});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiArticulos
            // 
            this.tsmiArticulos.Name = "tsmiArticulos";
            this.tsmiArticulos.Size = new System.Drawing.Size(66, 20);
            this.tsmiArticulos.Tag = "FrmArticulos";
            this.tsmiArticulos.Text = "Articulos";
            // 
            // tsmiClientes
            // 
            this.tsmiClientes.Name = "tsmiClientes";
            this.tsmiClientes.Size = new System.Drawing.Size(61, 20);
            this.tsmiClientes.Tag = "FrmClientes";
            this.tsmiClientes.Text = "Clientes";
            // 
            // tsmiNotas
            // 
            this.tsmiNotas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEncabezados,
            this.tsmiDetalles});
            this.tsmiNotas.Name = "tsmiNotas";
            this.tsmiNotas.Size = new System.Drawing.Size(98, 20);
            this.tsmiNotas.Text = "Notas de venta";
            // 
            // tsmiEncabezados
            // 
            this.tsmiEncabezados.Name = "tsmiEncabezados";
            this.tsmiEncabezados.Size = new System.Drawing.Size(142, 22);
            this.tsmiEncabezados.Tag = "FrmEncabezadoNota";
            this.tsmiEncabezados.Text = "Encabezados";
            // 
            // tsmiDetalles
            // 
            this.tsmiDetalles.Name = "tsmiDetalles";
            this.tsmiDetalles.Size = new System.Drawing.Size(142, 22);
            this.tsmiDetalles.Tag = "FrmDetalleNota";
            this.tsmiDetalles.Text = "Detalles";
            // 
            // tsmiUsuario
            // 
            this.tsmiUsuario.Name = "tsmiUsuario";
            this.tsmiUsuario.Size = new System.Drawing.Size(64, 20);
            this.tsmiUsuario.Tag = "FrmUsuarios";
            this.tsmiUsuario.Text = "Usuarios";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenu_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsmiNotas;
        private System.Windows.Forms.ToolStripMenuItem tsmiEncabezados;
        private System.Windows.Forms.ToolStripMenuItem tsmiDetalles;
        private System.Windows.Forms.ToolStripMenuItem tsmiClientes;
        private System.Windows.Forms.ToolStripMenuItem tsmiArticulos;
    }
}