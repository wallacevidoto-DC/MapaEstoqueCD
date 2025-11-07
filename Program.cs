using MapaEstoqueCD.Controller;
using MapaEstoqueCD.View.Modal;

namespace MapaEstoqueCD
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow());
            //Application.Run(new EntradaProduto());
        }
    }
}