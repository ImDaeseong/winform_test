using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int nGap = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitBorderPanel()
        {
            borderPanel1.Location = new Point(nGap, nGap);
            borderPanel1.Height = (ClientRectangle.Height - (nGap * 2));
            borderPanel1.Width = (ClientRectangle.Width - (nGap * 2));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitBorderPanel();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            InitBorderPanel();
        }
    }
}
