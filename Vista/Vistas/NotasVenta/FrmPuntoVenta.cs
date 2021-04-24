﻿using Controladores.Catalogos;
using Datos.Data;
using Datos.Helpers;
using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vista.Interfaces;
using Vista.Vistas.Articulos;
using Vista.Vistas.Clientes;

namespace Vista.Vistas.NotasVenta
{
    public partial class FrmPuntoVenta : Form,IFormClosable
    {
        #region Variables del form
        private readonly ArticulosCatalogoController articulosCat;
        private readonly EncabezadosNotaCatalogoController encabezadosCat;
        private readonly TiposPagoCatalogoController tiposPagoCat;
        private readonly ClientesCatalogoController clientesCat;
        private readonly List<DetalleNotaEntity> DetallesNotas;
        #endregion
        public string Key { get; set; }

        public FrmPuntoVenta()
        {
            articulosCat = new ArticulosCatalogoController();
            encabezadosCat = new EncabezadosNotaCatalogoController();
            tiposPagoCat = new TiposPagoCatalogoController();
            clientesCat = new ClientesCatalogoController();
            Key = "Ventas";
            DetallesNotas = new List<DetalleNotaEntity>();
            InitializeComponent();
            SetDgv();
            SetCmbTipoPago();
            
        }
        #region Metodos del form
        public void ObtenerArticulo(object sender, EventArgs e)
        {
            FrmSeleccionarArticulo frmSelArt = sender as FrmSeleccionarArticulo;
            ArticulosData articulo = articulosCat.BuscarPorId(frmSelArt.idSeleccionado);
            if (articulo != null)
            {
                txtIdArticulo.Text = articulo.Id.ToString();
                txtDescripcionArticulo.Text = articulo.Descripcion;
                txtCantidad.Text = "1";
                txtPrecioUnitario.Text = articulo.PrecioVenta.ToString();
            }

        }
        public void ObtenerCliente(object sender, EventArgs e)
        {
            FrmSeleccionarCliente frmSelCli = sender as FrmSeleccionarCliente;
            ClientesData cliente = clientesCat.BuscarPorId(frmSelCli.idSeleccionado);
            if (cliente != null)
            {
                txtIdCliente.Text = cliente.Id.ToString();
                txtRfc.Text = cliente.Rfc;
                txtNombreCliente.Text = cliente.NombreCompleto;
                txtDireccion.Text = cliente.Direccion;
            }

        }

        private void SetDgv()
        {
            dgvVentas.DataSource = null;
            dgvVentas.DataSource = DetallesNotas;
            if (dgvVentas.RowCount > 0)
            {
                dgvVentas.Columns["Activo"].Visible = false;
                dgvVentas.Columns["Articulo"].Visible = false;
                dgvVentas.Columns["EncabezadoNota"].Visible = false;
                dgvVentas.Columns["Id"].Visible = false;
                dgvVentas.Columns["IdEncabezadoNota"].Visible = false;
            }
            CalcularTotal();
        }
        private void SetCmbTipoPago()
        {
            cmbFormaPago.Items.Clear();
            var comboBoxItems = tiposPagoCat.ListarItemsComboBoxTipoPago();
            cmbFormaPago.Items.AddRange(comboBoxItems.ToArray());
        }
        private void LimpiarArticulo()
        {
            txtIdArticulo.Text = "";
            txtPrecioUnitario.Text = "";
            txtDescripcionArticulo.Text = "";
            txtCantidad.Text = "";
        }
        private void LimpiarCliente()
        {
            txtIdCliente.Text = "";
            txtRfc.Text = "";
            txtNombreCliente.Text = "";
            txtDireccion.Text = "";
        }
        private void LimpiarTodo(bool completo = false)
        {
            LimpiarArticulo();
            LimpiarCliente();
            EliminarArticulo(true);
        }
        private void EliminarArticulo(bool completo = false)
        {
            if (completo)
            {
                DetallesNotas.RemoveAll(x => x.IdArticulo > 0);
                SetDgv();
                CalcularTotal();
            }
            var detalleNota = DetallesNotas.FirstOrDefault(x => x.IdArticulo.ToString() == txtIdArticulo.Text);
            if (detalleNota != null)
            {
                DetallesNotas.Remove(detalleNota);
                SetDgv();
                CalcularTotal();
            }
        }
        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DetalleNotaEntity detalle in DetallesNotas)
            {
                total += detalle.PrecioVenta.Value * detalle.Cantidad.Value;
            }
            lblTotal.Text = "$" + total.ToString("###,###.##");
        }
        #endregion
        #region Eventos del form
        private void BtnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmSeleccionarArticulo selArt = new FrmSeleccionarArticulo();
            selArt.FormClosing += ObtenerArticulo;
            selArt.ShowDialog();

        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtCantidad.Text, out int cantidad))
            {
                var detalleNota = DetallesNotas.FirstOrDefault(x => x.IdArticulo.Value.ToString() == txtIdArticulo.Text);
                if (detalleNota!=null)
                {
                    detalleNota.Cantidad = cantidad;
                }
                else
                {
                    DetalleNotaEntity data = new DetalleNotaEntity()
                    {
                        Cantidad = cantidad,
                        IdArticulo = Convert.ToInt32(txtIdArticulo.Text),
                        PrecioVenta = Convert.ToDecimal(txtPrecioUnitario.Text),
                        Activo=true,
                    };
                    DetallesNotas.Add(data);
                }
                SetDgv();
                LimpiarArticulo();
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida.");
            }
            
        }

        private void BtnRemoverArticulo_Click(object sender, EventArgs e)
        {
            LimpiarArticulo();
        }

        private void BtnFinalizarVenta_Click(object sender, EventArgs e)
        {
            var selectedItem = cmbFormaPago.SelectedItem as ComboBoxItem;
            if (int.TryParse(txtIdCliente.Text, out int idCliente) && int.TryParse(selectedItem.Value.ToString(),out int idTipoPago))
            {
                EncabezadoNotaEntity encabezado = new EncabezadoNotaEntity()
                {
                    Comentario = txtComentarios.Text,
                    DetalleNotas = DetallesNotas,
                    IdCliente = idCliente,
                    FechaCreado = DateTime.Now,
                    IdTipoPago = idTipoPago,
                    Status = "Creado",
                };
                MessageBox.Show(encabezadosCat.AgregarEntidad(encabezado));
                LimpiarTodo(true);
            }
            
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmSeleccionarCliente frmCliente = new FrmSeleccionarCliente();
            frmCliente.FormClosing +=ObtenerCliente;
            frmCliente.ShowDialog();
        }
        #endregion
    }
}
