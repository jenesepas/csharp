using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tao.FreeGlut;
using OpenTK;
using OpenTK.Graphics.OpenGL;



namespace grafico
{
    static class Program
    {        
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            MainWindow doMain = new MainWindow();
            doMain.Run();
            
           
        }

       
    }
}
