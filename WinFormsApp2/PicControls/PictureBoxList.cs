using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.PicControls
{
    public class PictureBoxList : FlowLayoutPanel
    {
        private int m_nMaxCount = 10;

        public int MaxCount
        {
            get { return m_nMaxCount; }
            set
            {
                m_nMaxCount = value;
            }
        }        

        public PictureBoxList()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.AutoScroll = true;
            this.WrapContents = false;
            FlowDirection = FlowDirection.LeftToRight;
            AutoScrollMargin = new Size(0, 100);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        void ClearControl()
        {
            this.Controls.Clear();
        }

        public void Add(Bitmap bImage, string sTagName)
        {
            PictureBoxItem mPicture = new PictureBoxItem(this);
            mPicture.Add(bImage, sTagName);
            this.Controls.Add(mPicture);
            this.Controls.SetChildIndex(mPicture, 0);

            if (Controls.Count > m_nMaxCount)
                Controls.RemoveAt(m_nMaxCount);
        }

        public void Select(string sTagName)
        {
            for (int i = 0; i < Controls.Count; ++i)
            {
                PictureBoxItem mPicture = Controls[i] as PictureBoxItem;
                if (mPicture != null)
                {
                    if (mPicture.TagName == sTagName)
                        mPicture.Selected = true;
                    else
                        mPicture.Selected = false;
                }
            }
        }

        public void UnSelect()
        {
            for (int i = 0; i < Controls.Count; ++i)
            {
                PictureBoxItem mPicture = Controls[i] as PictureBoxItem;
                if (mPicture != null)
                {
                    mPicture.Selected = false;
                }
            }
        }

    }
}
