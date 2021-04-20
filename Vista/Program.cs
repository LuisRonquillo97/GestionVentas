using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Vistas.InicioSesion;

namespace Vista
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /*
         * nada que modificar aqu�, aqu� se define cu�l es el formulario con el que inicia la aplicaci�n, que es el form FrmIniciarSesi�n.
         */
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmIniciarSesion());
        }
    }
}
