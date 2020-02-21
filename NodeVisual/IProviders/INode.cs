using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NodeVisual
{
    public interface INode
    {
        public Int16 InPointCount { get; set; }
        public Int16 OutPointCount { get; set; }
        public string NodeName { get; set; }
        public INodeInField[] InNodeFields { get; set; }
        public INodeOutField[] OutNodeFields { get; set; }
        public INode Source { get; set; }
        public INode Destination { get; set; }
        public Point Position { get; set; }
    }

    public interface INodeInField
    {
        public Int16 state { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public INode Source { get; set; }
    }

    public interface INodeOutField
    {
        public Int16 state { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public INode Destination { get; set; }
    }
}
