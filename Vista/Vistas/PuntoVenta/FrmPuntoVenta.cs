using Controladores.Catalogos;
using Datos.Data;
using Datos.Helpers;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Vista.Interfaces;
using Vista.Vistas.Articulos;
using Vista.Vistas.Clientes;

namespace Vista.Vistas.PuntoVenta
{
    public partial class FrmPuntoVenta : Form, IFormClosable
    {
        #region Variables del form
        private readonly ArticulosCatalogoController articulosCat;
        private readonly EncabezadosNotaCatalogoController encabezadosCat;
        private readonly TiposPagoCatalogoController tiposPagoCat;
        private readonly ClientesCatalogoController clientesCat;
        private readonly BindingList<DgvDetalleNota> DetallesNotas;
        private decimal Total = 0;
        private int ExistenciaArticulo = 0;
        #endregion
        public string Key { get; set; }

        public FrmPuntoVenta()
        {
            articulosCat = new ArticulosCatalogoController();
            encabezadosCat = new EncabezadosNotaCatalogoController();
            tiposPagoCat = new TiposPagoCatalogoController();
            clientesCat = new ClientesCatalogoController();
            Key = "Ventas";
            DetallesNotas = new BindingList<DgvDetalleNota>();
            DetallesNotas.AllowNew = true;
            DetallesNotas.AllowEdit = true;
            DetallesNotas.AllowRemove = true;
            DetallesNotas.ListChanged += DetallesNotas_ListChanged;
            InitializeComponent();
            SetDgv();
            SetCmbTipoPago();

        }

        private void DetallesNotas_ListChanged(object sender, ListChangedEventArgs e)
        {
            SetDgv();
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
                ExistenciaArticulo = articulo.Existencia;
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
            txtComentarios.Text = "";
            cmbFormaPago.SelectedItem = null;
        }
        private void LimpiarTodo(bool completo = false)
        {
            LimpiarArticulo();
            LimpiarCliente();
            EliminarArticulo(completo);
        }
        private void EliminarArticulo(bool completo = false)
        {
            if (completo)
            {
                foreach (var detalle in DetallesNotas.ToList())
                {
                    DetallesNotas.Remove(detalle);
                }
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
            Total = 0;
            foreach (DgvDetalleNota detalle in DetallesNotas)
            {
                Total += detalle.Total;
            }
            lblTotal.Text = "$" + Total.ToString("###,###.##");
        }
        private void FinalizarVenta()
        {
            var selectedItem = cmbFormaPago.SelectedItem as ComboBoxItem;
            if (int.TryParse(txtIdCliente.Text, out int idCliente) && int.TryParse(selectedItem.Value.ToString(), out int idTipoPago))
            {
                EncabezadosNotaData encabezado = new EncabezadosNotaData()
                {
                    Comentario = txtComentarios.Text,
                    IdCliente = idCliente,
                    FechaCreado = DateTime.Now,
                    IdTipoPago = idTipoPago,
                    Status = "Creado",
                };
                MessageBox.Show(encabezadosCat.AgregarEntidad(encabezado, DetallesNotas.ToList()));
                LimpiarTodo(true);
            }
        }
        private bool ValidarDatos()
        {
            CalcularTotal();
            if (Total <= 0)
            {
                MessageBox.Show("El total no puede ser menor a cero.", "Alerta de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!(cmbFormaPago.SelectedItem is ComboBoxItem))
            {
                MessageBox.Show("Debe seleccionar un modo de venta.", "Alerta de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (int.TryParse(txtIdCliente.Text, out _) == false)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Alerta de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion
        #region Eventos del form
        private void BtnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmSeleccionarArticulo selArt = new FrmSeleccionarArticulo();
            selArt.FormClosing += ObtenerArticulo;
            selArt.ShowDialog();

        }

        private void BtnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtCantidad.Text, out int cantidad))
            {
                if (cantidad > ExistenciaArticulo)
                {
                    MessageBox.Show($"No contamos con la cantidad indicada de artículos en existencia.\n la cantidad actual del artículo es: {ExistenciaArticulo}");
                    txtCantidad.Text = ExistenciaArticulo.ToString();
                }
                else
                {
                    var detalleNota = DetallesNotas.FirstOrDefault(x => x.IdArticulo.ToString() == txtIdArticulo.Text);
                    if (detalleNota != null)
                    {
                        detalleNota.Cantidad = cantidad;
                    }
                    else
                    {

                        DgvDetalleNota data = DetallesNotas.AddNew();
                        data.Cantidad = cantidad;
                        data.IdArticulo = Convert.ToInt32(txtIdArticulo.Text);
                        data.Articulo = txtDescripcionArticulo.Text;
                        data.PrecioVenta = Convert.ToDecimal(txtPrecioUnitario.Text);
                        data.Total = data.Cantidad * data.PrecioVenta;
                        DetallesNotas.EndNew(DetallesNotas.IndexOf(data));
                    }
                    LimpiarArticulo();
                }

            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida.");
            }

        }

        private void BtnRemoverArticulo_Click(object sender, EventArgs e)
        {
            var detalle = DetallesNotas.FirstOrDefault(x => x.IdArticulo.ToString() == txtIdArticulo.Text);
            if (detalle != null)
                DetallesNotas.Remove(detalle);
            LimpiarArticulo();
        }

        private void BtnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var selectedItem = cmbFormaPago.SelectedItem as ComboBoxItem;
                if (selectedItem.Text.Equals("Efectivo", StringComparison.InvariantCultureIgnoreCase))
                {
                    FrmCambio cambio = new FrmCambio(Total);
                    cambio.FormClosing += Cambio_FormClosing;
                    cambio.ShowDialog();
                }
                else
                {
                    FinalizarVenta();
                }
            }
        }

        private void Cambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalizarVenta();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmSeleccionarCliente frmCliente = new FrmSeleccionarCliente();
            frmCliente.FormClosing += ObtenerCliente;
            frmCliente.ShowDialog();
        }
        #endregion

        private void DgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgvVentas.Rows[e.RowIndex];
            txtIdArticulo.Text = row.Cells["IdArticulo"].Value.ToString();
            txtPrecioUnitario.Text = row.Cells["PrecioVenta"].Value.ToString();
            txtDescripcionArticulo.Text = row.Cells["Articulo"].Value.ToString();
            txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
            ExistenciaArticulo = articulosCat.BuscarPorId(Convert.ToInt32(txtIdArticulo.Text)).Existencia;
        }
    }
}
