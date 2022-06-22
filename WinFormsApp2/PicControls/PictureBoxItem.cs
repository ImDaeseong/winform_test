using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.PicControls
{
    public class PictureBoxItem : PictureBox
    {
        private PictureBoxList mParent;

        private int nImageWidth = 100;
        private int nImageHeight = 90;

        private bool m_bSelected = false;
        private string m_sTagName;

        internal PictureBoxItem(PictureBoxList Parent)
        {
            mParent = Parent;

            SetStyle(ControlStyles.Selectable, true);
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public string TagName
        {
            get { return m_sTagName; }
        }

        public bool Selected
        {
            get { return m_bSelected; }
            set
            {
                m_bSelected = value;
                Invalidate();
            }
        }

        public void Add(Bitmap bImage, string sTagName)
        {
            Image = ResizeImage(bImage, new Size(nImageWidth, nImageHeight));
            m_sTagName = sTagName;
        }

        public Image ResizeImage(Image iImage, Size size)
        {
            return (Image)(new Bitmap(iImage, size));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (mParent != null)
                mParent.Select(m_sTagName);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics grfx = pe.Graphics;

            if (Image != null)
            {
                //ImageAttributes attr = new ImageAttributes();
                //Color lowerColor = Color.FromArgb(245, 0, 0);
                //Color upperColor = Color.FromArgb(255, 0, 0);
                //attr.SetColorKey(lowerColor, upperColor);
                //grfx.DrawImage(Image, new Rectangle(0, 0, Image.Width, Image.Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, attr);
                grfx.DrawImage(Image, 0, 0, Image.Width, Image.Height);
            }
            else
            {
                base.OnPaint(pe);
            }

            //선택 이미지 사각라인 그리기
            if (m_bSelected)
            {
                Pen pPen = new Pen(Brushes.Red);
                grfx.DrawRectangle(pPen, new Rectangle(0, 0, Image.Width - 1, Image.Height - 1));
            }
        }

    }
}
