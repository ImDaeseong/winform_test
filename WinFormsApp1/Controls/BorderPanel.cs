using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1.Controls
{
    public class BorderPanel : Panel
    {
        private Color m_clrBorderColor = Color.Black;
        private Color m_clrContentColor = Color.White;

        public BorderPanel()
        {
            BorderStyle = BorderStyle.None;

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //첫번째
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(m_clrBorderColor), 2), e.ClipRectangle);

            //두번째
            /*
            e.Graphics.FillRectangle(new SolidBrush(m_clrContentColor), 1, 1, Size.Width - 2, Size.Height - 2);
            e.Graphics.DrawRectangle(new Pen(m_clrBorderColor), 0, 0, Size.Width - 1, Size.Height - 1);
            */           

            Pen pPen = new Pen(m_clrBorderColor, 2);
            pPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            e.Graphics.DrawRectangle(pPen, rect);            
        }
    }
}
