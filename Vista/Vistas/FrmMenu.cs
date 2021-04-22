using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vista.Interfaces;
using Vista.Vistas.Articulos;
using Vista.Vistas.Clientes;
using Vista.Vistas.Usuarios;
using System.Reflection;
using System.Linq;

namespace Vista.Vistas
{
    public partial class FrmMenu : Form
    {
        /*
         * Este es el menú principal del sistema.
         * llegaremos aquí una vez iniciemos sesión.
         * utilizamos el formato MDI que mostró el instructor del curso.
         */
        private readonly Dictionary<string, Form> formularios;
        public FrmMenu()
        {
            InitializeComponent();
            tsmiDetalles.Click += Tsmi_Click;
            tsmiEncabezados.Click += Tsmi_Click;
            tsmiUsuario.Click += Tsmi_Click;
            tsmiClientes.Click += Tsmi_Click;
            tsmiArticulos.Click += Tsmi_Click;
            //cuando se abra esta ventana, le decimos que se maximice.
            this.WindowState = FormWindowState.Maximized;
            formularios = new Dictionary<string, Form>();
        }

        #region Abrir/Cerrar Forms
        /*
         * ToolStripMenuItemClick genérico para todos los items del frmMenu.
         * Utilizando reflection.
         * Este método obtiene desde el ToolStripMenuItem que se dispara el evento, su propiedad tag
         * y en base a ese tag abre el form correspondiente.
         */

        private void Tsmi_Click(object sender, EventArgs e)
        {
            //primero, obtenemos la propiedad Tag, que tiene el nombre del form que debe de abrir.
            PropertyInfo tagName = sender.GetType().GetProperty("Tag");
            //segundo, obtenemos el valor de la propiedad tag, del objeto que disparó el evento (por eso el cast a sender).
            string tagValue = tagName.GetValue(sender).ToString();
            //si el tagValue no tiene valor, disparamos una excepción
            if (string.IsNullOrEmpty(tagValue))
                throw new Exception($"el objeto {sender.GetType().GetProperty("name")} no tiene un tag.");

            /*
             * Una vez tenemos el valor, vamos a su ensamblado, enlistamos los tipos que tenga, y buscamos 
             * por el nombre del form que vayamos a utilizar.
             * El nombre del form lo tenemos en tagValue.
             * el StringComparison.CurrentCultureIgnoreCase, elimina el sensible a mayúsculas.
             */
            var type = this.GetType().Assembly.GetTypes().ToList().FirstOrDefault(t => t.Name.Equals(tagValue, StringComparison.CurrentCultureIgnoreCase));
            //si no encuentra el nombre del form que queremos abrir con el tag, disparamos una excepción
            if (type == null)
                throw new Exception($"No se encuenta la ventana {tagName}.");
            /*
             * con el nombre del form que utilizaremos, ya podemos instanciarlo.
             * casteamos a form porque sabemos que lo que vamos a crear es un objeto de tipo form.
             */
            Form formInstance = (Form)Activator.CreateInstance(type);
            /*
             * como todos los forms implementan la interfaz IFormClosable, obtenemos la la propiedad key de la 
             * interfaz, que se implementó en la instancia de nuestro formulario, en este caso es formInstance.
             */
            string key = ((IFormClosable)formInstance).Key;
            /*
             * finalmente, asignamos el método que elimina el form del dictionary de forms, que evita crear
             * múltiples instancias de un sólo formulario. (se hace para que el form se pueda volver a abrir).
             */
            formInstance.FormClosed += Child_FormClosed;
            //una vez todo el form está listo, lo mandamos a abrir.
            AbrirForm(key, formInstance);
        }
        /*
         * recordemos que el form de iniciar sesión está oculto. Si cerramos el form menú, la aplicación no termina.
         * para solucionar esto, haremos que cuando se presione el botón de cerrar del form de menú, se termine la aplicación.
         */
        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        /*
         * El formulario MDI permite abrir múltiples formularios a la vez, pero nosotros no queremos eso
         * así que esta función valida que sólo haya un form activo.
         * utilizamos un diccionario de tipo <string key, Form>, así que siempre debemos pasar estos dos parámetros.
         * TODA FORMA QUE SE ABRA DESDE EL MENÚ DEBE TENER UNA KEY, que obtiene de implementar la interfaz
         * IFormClosable.
         */
        private void AbrirForm(string key, Form form)
        {
            //revisamos si el diccionario ya tiene una instancia de este form, buscando su key.
            if (formularios.ContainsKey(key))
            {
                //si tiene una instancia activa, la obtenemos y la resaltamos en pantalla para el usuario.
                formularios.GetValueOrDefault(key).Focus();
            }
            else
            {
                //si no tiene una instancia, lo agregamos al diccionario y mostramos el formulario.
                formularios.Add(key, form);
                form.Show();
            }
        }
        /*
         * método genérico para cerrar los formularios hijos.
         * para cada form que se abra en el MDI, se le debe decir que en su método on close debe ser este método.
         * esto ya se hace si se usa el método genérico para abrir formularios llamado AbrirForm() en esta misma clase.
         */
        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*
             * obtenemos la llave del formulario que se cerró.
             * como el formulario debe implementar la interfaz IFormClosable, le decimos que nos dé
             * la propiedad key de la interfaz, desde el form donde se implementa.
             */
            var key = ((IFormClosable)sender).Key;
            //eliminamos del diccionario el formulario.
            formularios.Remove(key);
        }
        #endregion
    }
}
