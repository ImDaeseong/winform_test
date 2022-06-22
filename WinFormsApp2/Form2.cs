using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        private DevControls.ExalertControl exalert;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exalert = new DevControls.ExalertControl();
            exalert.Show(this, "제목", "내용");
        }
    }
}
