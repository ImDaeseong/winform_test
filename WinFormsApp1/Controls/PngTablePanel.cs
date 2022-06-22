using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1.Controls
{
    public delegate void PngTablePanel_MouseDown(int nIndex, MouseEventArgs e);
    public delegate void PngTablePanel_MouseMove(int nIndex, MouseEventArgs e);
    public delegate void PngTablePanel_MouseUp(int nIndex, MouseEventArgs e);
    public delegate void PngTablePanel_MouseEnter(int nIndex, EventArgs e);
    public delegate void PngTablePanel_MouseLeave(int nIndex, EventArgs e);

    public partial class PngTablePanel : UserControl
    {
        public PngTablePanel_MouseDown delMouseDown;
        public PngTablePanel_MouseMove delMouseMove;
        public PngTablePanel_MouseUp delMouseUp;
        public PngTablePanel_MouseEnter delMouseEnter;
        public PngTablePanel_MouseLeave delMouseLeave;

        private Bitmap m_bBG = null;

        private bool m_bFirst = false;

        private int m_nWidth = 169;//135//85//60//40;
        private int m_nHeight = 134;//107//67//48//32;

        private int m_nIndex;
        public int TabIndex
        {
            get
            {
                return m_nIndex;
            }
            set
            {
                m_nIndex = value;
                this.Refresh();
            }
        }

        private void DrawText(Graphics g)
        {
            string slabel = string.Format("{0}", m_nIndex + 1);

            Brush brText = new SolidBrush(Color.FromArgb(125, 0, 0));

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            Rectangle txtRect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y + 2, this.ClientRectangle.Width, this.ClientRectangle.Height);
            g.DrawString(slabel, base.Font, brText, txtRect, strFormat);
        }

        public PngTablePanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();

            this.Width = m_nWidth;
            this.Height = m_nHeight;

            this.BorderStyle = BorderStyle.None;

            this.DoubleBuffered = true;

            PngDrawTable();
        }

        public void ReSize(int nWidth, int nHeight)
        {
            m_nWidth = nWidth;
            m_nHeight = nHeight;

            this.Width = m_nWidth;
            this.Height = m_nHeight;

            m_bBG = new Bitmap(m_bBG, this.Width, this.Height);

            PngDrawTable();
        }

        private void PngTablePanel_Load(object sender, EventArgs e)
        {

        }

        private void PngTablePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(this.m_bBG, 0, 0);
        }

        private void PngTablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            delMouseDown(m_nIndex, e);
        }

        private void PngTablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            delMouseMove(m_nIndex, e);
        }

        private void PngTablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            delMouseUp(m_nIndex, e);
        }

        private void PngTablePanel_MouseEnter(object sender, EventArgs e)
        {
            //마우스 포인터가 컨트롤 영역 안으로
            delMouseEnter(m_nIndex, e);
        }

        private void PngTablePanel_MouseLeave(object sender, EventArgs e)
        {
            //마우스 포인터가 컨트롤 영역 밖으로
            delMouseLeave(m_nIndex, e);
        }

        private void PngTablePanel_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PngDrawTable()
        {
            this.Invalidate();

            Bitmap bgImg = null;

            SizeF sizePc = new SizeF(0, 0);

            if (!m_bFirst)
            {
                m_bBG = new Bitmap(this.Width, this.Height);
                m_bFirst = true;
            }

            Graphics g = Graphics.FromImage(m_bBG);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //배경 이미지 설정
            bgImg = new Bitmap(Properties.Resources.bg1);

            //이미지 크기 비율
            double ratio = ((double)bgImg.Width / (double)this.Width);
            int nReWidth = (int)((double)bgImg.Width / ratio);
            int nReHeight = (int)((double)bgImg.Height / ratio);

            g.DrawImage(bgImg, 0, 0, nReWidth, nReHeight);//g.DrawImage(bgImg, 0, 0, this.Width, this.Height);

            DrawText(g);

            bgImg.Dispose();
            try
            {
                if (this.Handle != null) this.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            g.Dispose();
        }
    }
}
