using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NodeVisual.Default;

namespace AHCG
{
    static class Program
    {

        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NodeRendererProvider renderer = new NodeRendererProvider();
            NodeCanvas canvas = new NodeCanvas(renderer);

            Application.Run(new Form1(canvas));
        }
    }
}
