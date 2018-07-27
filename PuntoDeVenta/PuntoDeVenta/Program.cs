using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación. es olo una prueba
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin frmLogin = new FormLogin();
            frmLogin.Show();
            Application.Run();
        
        }
    }
}
