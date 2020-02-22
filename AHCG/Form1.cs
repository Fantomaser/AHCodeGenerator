using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NodeVisual.Default;
using System.Drawing.Imaging;

namespace AHCG
{
    public partial class Form1 : Form
    {
        SplitContainer split;
        PictureBox Picture;
        Panel panel;
        TreeView tree;
        int PanelSize = 100;
        NodeCanvas pict;
        NodeRendererProvider renderer;

        public Form1(NodeCanvas _pict, NodeRendererProvider _renderer)
        {
            pict = _pict;
            renderer = _renderer;

            InitializeComponent();
            this.Size = new Size(1000, 800);

            split = new SplitContainer();
            split.Panel1.BackColor = Color.FromArgb(68, 68, 68);
            split.Panel1MinSize = 2;
            split.SplitterDistance = PanelSize;
            split.FixedPanel = FixedPanel.Panel1;
            split.Dock = DockStyle.Fill;
            split.SplitterMoved += win_Resize;
            

            tree = new TreeView();
            tree.Location = new Point(0, 0);
            tree.Dock = DockStyle.Fill;
            tree.BackColor = Color.FromArgb(68, 68, 68);
            split.Panel1.Controls.Add(tree);

            Picture = new PictureBox();
            Picture.Dock = DockStyle.Fill;
            Picture.Location = new Point(0, 0);
            split.Panel2.Controls.Add(Picture);

            this.Controls.Add(split);

            //Picture.Image = pict.Render(Picture.Width, Picture.Height, PixelFormat.Format24bppRgb);
            /*Node node = new Node();
            node.Position = new Point(20, 20);
            node.Size = new Point(50, 150);*/

            Node node2 = new Node();
            node2.Position = new Point(100, 100);
            node2.Size = new Point(50, 50);

            Node node3 = new Node();
            node3.Position = new Point(100, 220);
            node3.Size = new Point(50, 150);


            //pict.AddNode(node);
            pict.AddNode(node2);
            pict.AddNode(node3);

            Picture.Image = pict.Render(Picture.Width, Picture.Height, PixelFormat.Format24bppRgb);

            
            this.ClientSizeChanged += win_Resize;

        }

        public void win_Resize(object sender, EventArgs e)
        {
            Picture.Image = pict.Render(Picture.Width, Picture.Height, PixelFormat.Format24bppRgb);
        }

    }
}
