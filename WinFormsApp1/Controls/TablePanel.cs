using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1.Controls
{
    public delegate void TablePanel_MouseDown(int nIndex, MouseEventArgs e);
    public delegate void TablePanel_MouseMove(int nIndex, MouseEventArgs e);
    public delegate void TablePanel_MouseUp(int nIndex, MouseEventArgs e);
    public delegate void TablePanel_MouseEnter(int nIndex, EventArgs e);
    public delegate void TablePanel_MouseLeave(int nIndex, EventArgs e);

    public partial class TablePanel : UserControl
    {
        public TablePanel_MouseDown delMouseDown;
        public TablePanel_MouseMove delMouseMove;
        public TablePanel_MouseUp delMouseUp;
        public TablePanel_MouseEnter delMouseEnter;
        public TablePanel_MouseLeave delMouseLeave;

        private Color m_clrBorderColor = Color.Black;
        private Color m_clrContentColor = Color.White;

        public Color BorderColor
        {
            get { return m_clrBorderColor; }
            set
            {
                m_clrBorderColor = value;
                this.BackColor = m_clrBorderColor;
                this.Refresh();
            }
        }

        public Color ContentColor
        {
            get { return m_clrContentColor; }
            set
            {
                m_clrContentColor = value;
                this.Refresh();
            }
        }

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

        private void DrawText(PaintEventArgs e)
        {
            string slabel = string.Format("{0}", m_nIndex + 1);

            Brush brText = new SolidBrush(Color.FromArgb(125, 0, 0));

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            Rectangle txtRect = new Rectangle(this.ClientRectangle.X, this.ClientRectangle.Y + 2, this.ClientRectangle.Width, this.ClientRectangle.Height);
            e.Graphics.DrawString(slabel, base.Font, brText, txtRect, strFormat);
        }

        private GraphicsPath RoundedRectangle(Rectangle boundingRect, int cornerRadius, int margin)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2, boundingRect.Y + margin, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddArc(boundingRect.X + boundingRect.Width - margin - cornerRadius * 2, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddArc(boundingRect.X + margin, boundingRect.Y + boundingRect.Height - margin - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.CloseFigure();
            return roundedRect;
        }

        public TablePanel()
        {
            InitializeComponent();

            base.BackColor = Color.Transparent;
           
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, false);
            UpdateStyles();
        }

        public void ReSize(int nWidth, int nHeight)
        {
            this.Width = nWidth;
            this.Height = nHeight;

            OnResize(null);
        }

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            //배경처리
            using (SolidBrush backgroundBrush = new SolidBrush(BorderColor))
            {
                g.FillRectangle(backgroundBrush, this.ClientRectangle);
            }

            //라운드 박스 처리
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle outerRect = new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

            int margin = 1;
            int cornerRadius = 6;
            if (ClientRectangle.Width < 50)
            {
                cornerRadius = 1;
                margin = 0;
            }

            using (GraphicsPath outerPath = RoundedRectangle(outerRect, cornerRadius, margin))
            {
                Brush brNormal = new SolidBrush(ContentColor);
                g.FillPath(brNormal, outerPath);
            }

            DrawText(e);
        }

        private void TablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            delMouseDown(m_nIndex, e);
        }

        private void TablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            delMouseUp(m_nIndex, e);
        }

        private void TablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            delMouseMove(m_nIndex, e);
        }

        private void TablePanel_MouseEnter(object sender, EventArgs e)
        {
            //마우스 포인터가 컨트롤 영역 안으로
            delMouseEnter(m_nIndex, e);
        }

        private void TablePanel_MouseLeave(object sender, EventArgs e)
        {
            //마우스 포인터가 컨트롤 영역 밖으로
            delMouseLeave(m_nIndex, e);
        }
    }
}
