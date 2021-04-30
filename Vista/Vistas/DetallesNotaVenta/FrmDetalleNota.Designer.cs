
namespace Vista.Vistas.DetallesNotaVenta
{
    partial class FrmDetalleNota
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtIdDetalleNota = new System.Windows.Forms.TextBox();
            this.lblIdDetalleNota = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTotalArticulo = new System.Windows.Forms.Label();
            this.lblTituloTotalArticulo = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripción = new System.Windows.Forms.Label();
            this.txtIdArticulo = new System.Windows.Forms.TextBox();
            this.lblIdArticulo = new System.Windows.Forms.Label();
            this.lblTituloArtículos = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTituloStatus = new System.Windows.Forms.Label();
            this.lblTipoPago = new System.Windows.Forms.Label();
            this.lblTituloTipoPago = new System.Windows.Forms.Label();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.lblTituloFechaCreacion = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.btnBuscarNotaVenta = new System.Windows.Forms.Button();
            this.lblTituloNombreCliente = new System.Windows.Forms.Label();
            this.lblTituloNotaVenta = new System.Windows.Forms.Label();
            this.txtIdNotaVenta = new System.Windows.Forms.TextBox();
            this.lblIdNotaVenta = new System.Windows.Forms.Label();
            this.dgvDetalleNota = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleNota)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtIdDetalleNota);
            this.splitContainer1.Panel1.Controls.Add(this.lblIdDetalleNota);
            this.splitContainer1.Panel1.Controls.Add(this.btnLimpiar);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel1.Controls.Add(this.btnEliminar);
            this.splitContainer1.Panel1.Controls.Add(this.btnModificar);
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscar);
            this.splitContainer1.Panel1.Controls.Add(this.lblTotalArticulo);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloTotalArticulo);
            this.splitContainer1.Panel1.Controls.Add(this.lblCantidad);
            this.splitContainer1.Panel1.Controls.Add(this.txtCantidad);
            this.splitContainer1.Panel1.Controls.Add(this.txtPrecioVenta);
            this.splitContainer1.Panel1.Controls.Add(this.lblPrecioVenta);
            this.splitContainer1.Panel1.Controls.Add(this.txtDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.lblDescripción);
            this.splitContainer1.Panel1.Controls.Add(this.txtIdArticulo);
            this.splitContainer1.Panel1.Controls.Add(this.lblIdArticulo);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloArtículos);
            this.splitContainer1.Panel1.Controls.Add(this.txtComentario);
            this.splitContainer1.Panel1.Controls.Add(this.lblComentario);
            this.splitContainer1.Panel1.Controls.Add(this.lblStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloStatus);
            this.splitContainer1.Panel1.Controls.Add(this.lblTipoPago);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloTipoPago);
            this.splitContainer1.Panel1.Controls.Add(this.lblFechaCreacion);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloFechaCreacion);
            this.splitContainer1.Panel1.Controls.Add(this.lblNombreCliente);
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscarNotaVenta);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloNombreCliente);
            this.splitContainer1.Panel1.Controls.Add(this.lblTituloNotaVenta);
            this.splitContainer1.Panel1.Controls.Add(this.txtIdNotaVenta);
            this.splitContainer1.Panel1.Controls.Add(this.lblIdNotaVenta);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetalleNota);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtIdDetalleNota
            // 
            this.txtIdDetalleNota.Location = new System.Drawing.Point(501, 42);
            this.txtIdDetalleNota.Name = "txtIdDetalleNota";
            this.txtIdDetalleNota.Size = new System.Drawing.Size(148, 23);
            this.txtIdDetalleNota.TabIndex = 31;
            // 
            // lblIdDetalleNota
            // 
            this.lblIdDetalleNota.AutoSize = true;
            this.lblIdDetalleNota.Location = new System.Drawing.Point(472, 45);
            this.lblIdDetalleNota.Name = "lblIdDetalleNota";
            this.lblIdDetalleNota.Size = new System.Drawing.Size(21, 15);
            this.lblIdDetalleNota.TabIndex = 30;
            this.lblIdDetalleNota.Text = "ID:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(274, 41);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 23);
            this.btnLimpiar.TabIndex = 29;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(712, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(635, 210);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 27;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(554, 210);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 26;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(473, 210);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // lblTotalArticulo
            // 
            this.lblTotalArticulo.AutoSize = true;
            this.lblTotalArticulo.Location = new System.Drawing.Point(676, 158);
            this.lblTotalArticulo.Name = "lblTotalArticulo";
            this.lblTotalArticulo.Size = new System.Drawing.Size(75, 15);
            this.lblTotalArticulo.TabIndex = 24;
            this.lblTotalArticulo.Text = "$###,###.##";
            // 
            // lblTituloTotalArticulo
            // 
            this.lblTituloTotalArticulo.AutoSize = true;
            this.lblTituloTotalArticulo.Location = new System.Drawing.Point(592, 158);
            this.lblTituloTotalArticulo.Name = "lblTituloTotalArticulo";
            this.lblTituloTotalArticulo.Size = new System.Drawing.Size(78, 15);
            this.lblTituloTotalArticulo.TabIndex = 23;
            this.lblTituloTotalArticulo.Text = "Total artículo:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(437, 158);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(58, 15);
            this.lblCantidad.TabIndex = 22;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(501, 155);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(85, 23);
            this.txtCantidad.TabIndex = 21;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(655, 71);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(132, 23);
            this.txtPrecioVenta.TabIndex = 20;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(558, 74);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(91, 15);
            this.lblPrecioVenta.TabIndex = 19;
            this.lblPrecioVenta.Text = "Precio de venta:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(501, 100);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(286, 49);
            this.txtDescripcion.TabIndex = 18;
            // 
            // lblDescripción
            // 
            this.lblDescripción.AutoSize = true;
            this.lblDescripción.Location = new System.Drawing.Point(423, 100);
            this.lblDescripción.Name = "lblDescripción";
            this.lblDescripción.Size = new System.Drawing.Size(72, 15);
            this.lblDescripción.TabIndex = 17;
            this.lblDescripción.Text = "Descripción:";
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Location = new System.Drawing.Point(501, 71);
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.Size = new System.Drawing.Size(51, 23);
            this.txtIdArticulo.TabIndex = 16;
            // 
            // lblIdArticulo
            // 
            this.lblIdArticulo.AutoSize = true;
            this.lblIdArticulo.Location = new System.Drawing.Point(431, 74);
            this.lblIdArticulo.Name = "lblIdArticulo";
            this.lblIdArticulo.Size = new System.Drawing.Size(64, 15);
            this.lblIdArticulo.TabIndex = 15;
            this.lblIdArticulo.Text = "ID articulo:";
            // 
            // lblTituloArtículos
            // 
            this.lblTituloArtículos.AutoSize = true;
            this.lblTituloArtículos.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloArtículos.Location = new System.Drawing.Point(566, 9);
            this.lblTituloArtículos.Name = "lblTituloArtículos";
            this.lblTituloArtículos.Size = new System.Drawing.Size(98, 28);
            this.lblTituloArtículos.TabIndex = 14;
            this.lblTituloArtículos.Text = "Artículos";
            // 
            // txtComentario
            // 
            this.txtComentario.Enabled = false;
            this.txtComentario.Location = new System.Drawing.Point(12, 137);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(391, 96);
            this.txtComentario.TabIndex = 13;
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(12, 119);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(73, 15);
            this.lblComentario.TabIndex = 12;
            this.lblComentario.Text = "Comentario:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(322, 95);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 15);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "-Status-";
            // 
            // lblTituloStatus
            // 
            this.lblTituloStatus.AutoSize = true;
            this.lblTituloStatus.Location = new System.Drawing.Point(274, 95);
            this.lblTituloStatus.Name = "lblTituloStatus";
            this.lblTituloStatus.Size = new System.Drawing.Size(42, 15);
            this.lblTituloStatus.TabIndex = 10;
            this.lblTituloStatus.Text = "Status:";
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.AutoSize = true;
            this.lblTipoPago.Location = new System.Drawing.Point(322, 73);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.Size = new System.Drawing.Size(81, 15);
            this.lblTipoPago.TabIndex = 9;
            this.lblTipoPago.Text = "-TipoDePago-";
            // 
            // lblTituloTipoPago
            // 
            this.lblTituloTipoPago.AutoSize = true;
            this.lblTituloTipoPago.Location = new System.Drawing.Point(237, 73);
            this.lblTituloTipoPago.Name = "lblTituloTipoPago";
            this.lblTituloTipoPago.Size = new System.Drawing.Size(79, 15);
            this.lblTituloTipoPago.TabIndex = 8;
            this.lblTituloTipoPago.Text = "Tipo de pago:";
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Location = new System.Drawing.Point(115, 95);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(65, 15);
            this.lblFechaCreacion.TabIndex = 7;
            this.lblFechaCreacion.Text = "12/12/2021";
            // 
            // lblTituloFechaCreacion
            // 
            this.lblTituloFechaCreacion.AutoSize = true;
            this.lblTituloFechaCreacion.Location = new System.Drawing.Point(12, 95);
            this.lblTituloFechaCreacion.Name = "lblTituloFechaCreacion";
            this.lblTituloFechaCreacion.Size = new System.Drawing.Size(105, 15);
            this.lblTituloFechaCreacion.TabIndex = 6;
            this.lblTituloFechaCreacion.Text = "Fecha de creación:";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(65, 70);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(115, 15);
            this.lblNombreCliente.TabIndex = 5;
            this.lblNombreCliente.Text = "-Nombre de cliente-";
            // 
            // btnBuscarNotaVenta
            // 
            this.btnBuscarNotaVenta.Location = new System.Drawing.Point(175, 40);
            this.btnBuscarNotaVenta.Name = "btnBuscarNotaVenta";
            this.btnBuscarNotaVenta.Size = new System.Drawing.Size(90, 23);
            this.btnBuscarNotaVenta.TabIndex = 4;
            this.btnBuscarNotaVenta.Text = "Buscar nota";
            this.btnBuscarNotaVenta.UseVisualStyleBackColor = true;
            this.btnBuscarNotaVenta.Click += new System.EventHandler(this.BtnBuscarNotaVenta_Click);
            // 
            // lblTituloNombreCliente
            // 
            this.lblTituloNombreCliente.AutoSize = true;
            this.lblTituloNombreCliente.Location = new System.Drawing.Point(12, 70);
            this.lblTituloNombreCliente.Name = "lblTituloNombreCliente";
            this.lblTituloNombreCliente.Size = new System.Drawing.Size(47, 15);
            this.lblTituloNombreCliente.TabIndex = 3;
            this.lblTituloNombreCliente.Text = "Cliente:";
            // 
            // lblTituloNotaVenta
            // 
            this.lblTituloNotaVenta.AutoSize = true;
            this.lblTituloNotaVenta.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloNotaVenta.Location = new System.Drawing.Point(158, 9);
            this.lblTituloNotaVenta.Name = "lblTituloNotaVenta";
            this.lblTituloNotaVenta.Size = new System.Drawing.Size(147, 28);
            this.lblTituloNotaVenta.TabIndex = 2;
            this.lblTituloNotaVenta.Text = "Nota de venta";
            // 
            // txtIdNotaVenta
            // 
            this.txtIdNotaVenta.Location = new System.Drawing.Point(63, 38);
            this.txtIdNotaVenta.Name = "txtIdNotaVenta";
            this.txtIdNotaVenta.Size = new System.Drawing.Size(106, 23);
            this.txtIdNotaVenta.TabIndex = 1;
            this.txtIdNotaVenta.Leave += new System.EventHandler(this.TxtIdNotaVenta_Leave);
            // 
            // lblIdNotaVenta
            // 
            this.lblIdNotaVenta.AutoSize = true;
            this.lblIdNotaVenta.Location = new System.Drawing.Point(36, 41);
            this.lblIdNotaVenta.Name = "lblIdNotaVenta";
            this.lblIdNotaVenta.Size = new System.Drawing.Size(21, 15);
            this.lblIdNotaVenta.TabIndex = 0;
            this.lblIdNotaVenta.Text = "ID:";
            // 
            // dgvDetalleNota
            // 
            this.dgvDetalleNota.AllowUserToAddRows = false;
            this.dgvDetalleNota.AllowUserToDeleteRows = false;
            this.dgvDetalleNota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalleNota.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalleNota.Name = "dgvDetalleNota";
            this.dgvDetalleNota.ReadOnly = true;
            this.dgvDetalleNota.RowTemplate.Height = 25;
            this.dgvDetalleNota.Size = new System.Drawing.Size(800, 180);
            this.dgvDetalleNota.TabIndex = 0;
            this.dgvDetalleNota.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalleNota_CellDoubleClick);
            // 
            // FrmDetalleNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmDetalleNota";
            this.Text = "Detalle de notas de venta";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleNota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnBuscarNotaVenta;
        private System.Windows.Forms.Label lblTituloNombreCliente;
        private System.Windows.Forms.Label lblTituloNotaVenta;
        private System.Windows.Forms.TextBox txtIdNotaVenta;
        private System.Windows.Forms.Label lblIdNotaVenta;
        private System.Windows.Forms.DataGridView dgvDetalleNota;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblTipoPago;
        private System.Windows.Forms.Label lblTituloTipoPago;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblTituloFechaCreacion;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTituloStatus;
        private System.Windows.Forms.Label lblTituloArtículos;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.TextBox txtIdArticulo;
        private System.Windows.Forms.Label lblIdArticulo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripción;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTotalArticulo;
        private System.Windows.Forms.Label lblTituloTotalArticulo;
        private System.Windows.Forms.Label I;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtIdDetalleNota;
        private System.Windows.Forms.Label lblIdDetalleNota;
    }
}