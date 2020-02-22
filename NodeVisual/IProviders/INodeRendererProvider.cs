using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace NodeVisual
{
    public interface INodeRendererProvider
    {
        public unsafe Bitmap GetImage(INode[] nodes, int width, int height, PixelFormat pFormat);
    }
}
