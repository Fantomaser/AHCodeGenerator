using System;
using System.Collections.Generic;
using System.Drawing;
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
