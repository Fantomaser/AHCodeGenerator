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

namespace AHCG
{
    public partial class Form1 : Form
    {
        SplitContainer split;
        PictureBox Picture;
        Panel panel;
        TreeView tree;
        int PanelSize = 15;

        public Form1(NodeCanvas pict)
        {
            InitializeComponent();
            this.Size = new Size(1000, 800);

            split = new SplitContainer();
            split.Panel1.BackColor = Color.FromArgb(68, 68, 68);
            split.Panel1MinSize = 2;
            split.SplitterDistance = PanelSize;
            split.Dock = DockStyle.Fill;
            this.Controls.Add(split);

            tree = new TreeView();
            tree.Location = new Point(0, 0);
            tree.Dock = DockStyle.Fill;
            tree.BackColor = Color.FromArgb(68, 68, 68);
            split.Panel1.Controls.Add(tree);

            Picture = new PictureBox();
            Picture.Image = pict.Render();
            Picture.Dock = DockStyle.Fill;
            Picture.Location = new Point(0, 0);
            split.Panel2.Controls.Add(Picture);



        }

    }
}
