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

        public unsafe virtual Bitmap GetImage(INode[] nodes, int width, int height, PixelFormat pFormat)
        {

            if (nodes.Length == 0)
                return  new Bitmap(System.IO.Directory.GetCurrentDirectory() + @"\start.jpg");

            int CanvasSize = width > height ? width : height;
            Bitmap NodeView = new Bitmap(CanvasSize, CanvasSize, pFormat);
            BitmapData bd = NodeView.LockBits(new Rectangle(0, 0, CanvasSize, CanvasSize),
                                                ImageLockMode.ReadWrite,
                                                pFormat);

            byte* curLine;
            foreach (INode node in nodes)
            {
                Bitmap NodeVisual = node.GetView(pFormat, new Pixel24() { R = 255, G = 127, B = 80 });
                int size = node.Size.X > node.Size.Y ? node.Size.X : node.Size.Y;
                BitmapData bdNode = NodeVisual.LockBits(new Rectangle(0, 0, size, size),
                                                ImageLockMode.ReadWrite,
                                                pFormat);
                byte* curLineNode;

                for (int h = 0; h < node.Size.Y; h++)
                {
                    /*if ((h + node.Position.Y) >= height)------------------------
                        continue;*/
                    curLine = ((byte*)bd.Scan0) + (h + node.Position.Y) * bd.Stride + node.Position.X;
                    curLineNode = ((byte*)bdNode.Scan0) + h * bdNode.Stride;
                    for (int w = 0; w < node.Size.X; w++)
                    {
                        /*if ((w + node.Position.X) >= width)-----------------------
                            continue;*/
                        *(curLine++) = *(curLineNode++);
                        *(curLine++) = *(curLineNode++);
                        *(curLine++) = *(curLineNode++);
                    }
                }
                NodeVisual.UnlockBits(bdNode);
            }

            NodeView.UnlockBits(bd);


            return NodeView;
        }

    }
}
