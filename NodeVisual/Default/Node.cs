using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace NodeVisual.Default
{
    public class Node : INode
    {
        public short _InPointCount = -1;
        public virtual short InPointCount { get => _InPointCount; set => _InPointCount = value; }

        public short _OutPointCount = -1;
        public virtual short OutPointCount { get => _OutPointCount; set => _OutPointCount = value; }

        public string _NodeName = "";
        public virtual string NodeName { get => _NodeName; set => _NodeName = value; }

        public INodeInField[] _InNodeFields = null;
        public virtual INodeInField[] InNodeFields { get => _InNodeFields; set => _InNodeFields = value; }

        public INodeOutField[] _OutNodeFields = null;
        public virtual INodeOutField[] OutNodeFields { get => _OutNodeFields; set => _OutNodeFields = value; }

        public INode _Source = null;
        public virtual INode Source { get => _Source; set => _Source = value; }

        public INode _Destination = null;
        public virtual INode Destination { get => _Destination; set => _Destination = value; }

        public Point _Position = new Point(-1,-1);
        public virtual Point Position { get => _Position; set => _Position = value; }

        public Point _Size = new Point(-1, -1);
        public virtual Point Size { get => _Size; set => _Size = value; }

        public unsafe Bitmap GetView(PixelFormat pFormat, Pixel24 BC)
        {
            int size = this.Size.X > this.Size.Y ? this.Size.X : this.Size.Y;
            Bitmap View = new Bitmap(size, size, pFormat);
            BitmapData bd = View.LockBits(new Rectangle(0, 0, size, size), ImageLockMode.ReadWrite, pFormat);

            byte* curLine;
            for (int h = 0; h < this.Size.Y; h++)
            {
                curLine = ((byte*)bd.Scan0) + h * bd.Stride;
                for (int w = 0; w < this.Size.X; w++)
                {
                    *(curLine++) = BC.B;
                    *(curLine++) = BC.G;
                    *(curLine++) = BC.R;
                }
            }

            View.UnlockBits(bd);

            return View;
        }
    }

    public class NodeInField : INodeInField
    {
        public short _state = -1;
        public virtual short state { get => _state; set => _state = value; }

        public string _Name = "";
        public virtual string Name { get => _Name; set => _Name = value; }

        public string _Description = "";
        public virtual string Description { get => _Description; set => _Description = value; }

        public INode _Source = null;
        public virtual INode Source { get => _Source; set => _Source = value; }
    }

    public class NodeOutField : INodeOutField
    {
        public short _state = -1;
        public virtual short state { get => _state; set => _state = value; }

        public string _Name = "";
        public virtual string Name { get => _Name; set => _Name = value; }

        public string _Description = "";
        public virtual string Description { get => _Description; set => _Description = value; }

        public INode _Destination = null;
        public virtual INode Destination { get => throw new NotImplementedException(); set => _Destination = value; }
    }

}
