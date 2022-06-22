using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2.PicControls
{
    public partial class PictureBox_UserControl : UserControl
    {
        public PictureBox_UserControl()
        {
            InitializeComponent();
        }

        private void PictureBox_UserControl_Load(object sender, EventArgs e)
        {
            pictureBoxList1.MaxCount = 20;

            pictureBoxList1.Add(Properties.Resources.bg1, "bg1");
            pictureBoxList1.Add(Properties.Resources.bg2, "bg2");
            pictureBoxList1.Add(Properties.Resources.bg3, "bg3");
            pictureBoxList1.Add(Properties.Resources.bg4, "bg4");
            pictureBoxList1.Add(Properties.Resources.bg5, "bg5");
        }

        private void PictureBox_UserControl_MouseDown(object sender, MouseEventArgs e)
        {
            //선택된 이미지 이외는 전부 비선택으로
            pictureBoxList1.UnSelect();
        }


        private void pictureBoxList1_MouseDown(object sender, MouseEventArgs e)
        {
            //선택된 이미지 이외는 전부 비선택으로
            pictureBoxList1.UnSelect();
        }

        public void Add(Bitmap bImage, string sTagName)
        {
            pictureBoxList1.Add(bImage, sTagName);
        }

    }
}
