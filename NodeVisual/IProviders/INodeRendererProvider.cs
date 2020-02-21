using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NodeVisual
{
    public interface INodeRendererProvider
    {
        public Bitmap GetImage(INode[] nodes, int width, int height);
    }
}
