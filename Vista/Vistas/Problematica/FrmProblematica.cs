using System.Windows.Forms;
using Vista.Interfaces;

namespace Vista.Vistas.Problematica
{
    public partial class FrmProblematica : Form, IFormClosable
    {
        public FrmProblematica()
        {
            InitializeComponent();
            Key = "Problemática";
        }

        public string Key { get; set; }
    }
}
