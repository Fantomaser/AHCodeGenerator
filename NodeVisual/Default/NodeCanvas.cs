using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace NodeVisual.Default
{
    public class NodeCanvas : INodeCanvasProvider
    {

        public INodeRendererProvider _Renderer;
        public virtual INodeRendererProvider Renderer { get => _Renderer; set => _Renderer = value; }

        public NodeCanvas(INodeRendererProvider renderer)
        {
            Renderer = renderer;
        }

        public virtual bool AddNode(INode node)
        {
            this.NodeСollection.Add(node);
            return true;
        }

        public virtual bool Clear()
        {
            this.NodeСollection.Clear();
            return true;
        }
        public virtual Bitmap Render(Int32 width, Int32 height, PixelFormat pFormat)
        {
            
            return _Renderer.GetImage(this.NodeСollection.ToArray(), width, height, pFormat); ;
        }

        public virtual INode GetNode(Int32 id)
        {
            return NodeСollection[id];
        }
        public virtual INode GetNode(string name)
        {   
            return this.NodeСollection.Find(c => c.NodeName == name);
        }

        public virtual bool MoveNode(int id, short x, short y)
        {
            this.NodeСollection[id].Position = new Point(x, y);
            return true;
        }
        public virtual bool MoveNode(INode node, short x, short y)
        {
            this.NodeСollection.Find(c => c == node).Position = new Point(x, y);
            return true;
        }
        public virtual bool MoveNode(string name, short x, short y)
        {
            this.NodeСollection.Find(c => c.NodeName == name).Position = new Point(x, y);
            return true;
        }

        public virtual bool RemoveLink(Int32 fromID, Int32 toID)
        {
            try
            {
                this.NodeСollection[fromID].Destination = new Node();
                this.NodeСollection[toID].Source = new Node();
                return true;
            }
            catch
            {
                return false;
            } 
        }
        public virtual bool RemoveLink(INode from, INode to)
        {
            try
            {
                from.Destination = new Node();
                to.Source = new Node();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public virtual bool RemoveLink(string fromName, string toName)
        {
            try
            {
                (this.NodeСollection.Find(c => c.NodeName == fromName)).Destination = new Node();
                (this.NodeСollection.Find(c => c.NodeName == toName)).Source = new Node();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool RemoveNode(int id)
        {
            if (this.NodeСollection.Count <= id)
                return false;

            this.NodeСollection.RemoveAt(id);
            return true;
        }
        public virtual bool RemoveNode(INode node)
        {
            return this.NodeСollection.Remove(node);
        }
        public virtual bool RemoveNode(string name)
        {
            try
            {
                this.NodeСollection.Remove(this.NodeСollection.Find(c => c.NodeName == name));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool SetLink(int fromID, int toID)
        {
            try
            {
                this.NodeСollection[fromID].Destination = this.NodeСollection[toID];
                this.NodeСollection[toID].Source = this.NodeСollection[fromID];
                return true;
            }
            catch
            {
                return false;
            }
        }
        public virtual bool SetLink(INode from, INode to)
        {
            try
            {
                from.Destination = to;
                to.Source = from;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public virtual bool SetLink(string fromName, string toName)
        {
            try
            {
                this.NodeСollection.Find(c=>c.NodeName == fromName).Destination = this.NodeСollection.Find(c => c.NodeName == toName);
                this.NodeСollection.Find(c => c.NodeName == toName).Source = this.NodeСollection.Find(c => c.NodeName == fromName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<INode> NodeСollection = new List<INode>();
    }
}
