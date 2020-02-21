using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.IO;

namespace NodeVisual.Default
{
    public class NodeRendererProvider : INodeRendererProvider
    {
        public Bitmap GetImage(INode[] nodes, int width, int height)
        {
            if (nodes.Length == 0)
                return new Bitmap(System.IO.Directory.GetCurrentDirectory() + @"\start.jpg");
            Bitmap canvas = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            return canvas;
        }
    }
}
