using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace NodeVisual
{
    interface INodeCanvasProvider
    {
        public INodeRendererProvider Renderer { get; set; }
        public bool AddNode(INode node);
        public Bitmap Render();

        public bool RemoveNode(Int32 id);
        public bool RemoveNode(INode node);
        public bool RemoveNode(string name);

        public bool SetLink(Int32 fromID, Int32 toID);
        public bool SetLink(INode from, INode to);
        public bool SetLink(string fromName, string toName);

        public bool RemoveLink(Int32 fromID, Int32 toID);
        public bool RemoveLink(INode from, INode to);
        public bool RemoveLink(string fromName, string toName);

        public bool Clear();

        public bool MoveNode(Int32 id, Int16 x, Int16 y);
        public bool MoveNode(INode node, Int16 x, Int16 y);
        public bool MoveNode(string name, Int16 x, Int16 y);

        public INode GetNode(Int32 id);
        public INode GetNode(string name);

    }
}
