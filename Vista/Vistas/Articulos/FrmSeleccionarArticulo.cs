using Controladores.Catalogos;
using System.Windows.Forms;

namespace Vista.Vistas.Articulos
{
    public partial class FrmSeleccionarArticulo : Form
    {
        private readonly ArticulosCatalogoController articulosCat;
        public int idSeleccionado{get;set;}
        public FrmSeleccionarArticulo()
        {
            InitializeComponent();
            articulosCat = new ArticulosCatalogoController();
        }
        public void SetDataGrid()
        {
            dgvArticulos.DataSource = null;

            dgvArticulos.DataSource = articulosCat.Listar(txtId.Text, txtDescripcion.Text, "", "", "");
        }
        
    }
}
