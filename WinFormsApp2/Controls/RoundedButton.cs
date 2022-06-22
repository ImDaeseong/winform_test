using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.Controls
{
    public class RoundedButton : Button
    {
        Brush b = new SolidBrush(Color.Violet);
        Brush hover = new SolidBrush(Color.YellowGreen);
        StringFormat sf;

        public RoundedButton()
        {
            SetStyle(ControlStyles.UserPaint, true);
            sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }

        public RoundedButton(Color col, Color hoverCol) : this()
        {
            b = new SolidBrush(col);
            hover = new SolidBrush(hoverCol);
        }

        public enum RoundedCorners
        {
            None = 0x00,
            TopLeft = 0x02,
            TopRight = 0x04,
            BottomLeft = 0x08,
            BottomRight = 0x10,
            All = 0x1F
        }

        private static void DrawRoundedRectangle(Graphics g, Rectangle rec, int radius, RoundedCorners corners, Brush b)
        {
            int x = rec.X;
            int y = rec.Y;
            int diameter = radius * 2;
            var horiz = new Rectangle(x, y + radius, rec.Width, rec.Height - diameter);
            var vert = new Rectangle(x + radius, y, rec.Width - diameter, rec.Height);

            g.FillRectangle(b, horiz);
            g.FillRectangle(b, vert);

            if ((corners & RoundedCorners.TopLeft) == RoundedCorners.TopLeft)
                g.FillEllipse(b, x, y, diameter, diameter);
            else
                g.FillRectangle(b, x, y, diameter, diameter);

            if ((corners & RoundedCorners.TopRight) == RoundedCorners.TopRight)
                g.FillEllipse(b, x + rec.Width - (diameter + 1), y, diameter, diameter);
            else
                g.FillRectangle(b, x + rec.Width - (diameter + 1), y, diameter, diameter);

            if ((corners & RoundedCorners.BottomLeft) == RoundedCorners.BottomLeft)
                g.FillEllipse(b, x, y + rec.Height - (diameter + 1), diameter, diameter);
            else
                g.FillRectangle(b, x, y + rec.Height - (diameter + 1), diameter, diameter);

            if ((corners & RoundedCorners.BottomRight) == RoundedCorners.BottomRight)
                g.FillEllipse(b, x + rec.Width - (diameter + 1), y + rec.Height - (diameter + 1), diameter, diameter);
            else
                g.FillRectangle(b, x + rec.Width - (diameter + 1), y + rec.Height - (diameter + 1), diameter, diameter);
        }

        private static void DrawRoundedRectangle(Graphics g, Rectangle r, int d, Brush b)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawRoundedRectangle(g, r, d, RoundedCorners.All, b);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), pevent.ClipRectangle);

            if (Enabled && Bounds.Contains(Parent.PointToClient(Cursor.Position)))
                DrawRoundedRectangle(pevent.Graphics, pevent.ClipRectangle, 4, hover);
            else
                DrawRoundedRectangle(pevent.Graphics, pevent.ClipRectangle, 4, b);

            // text
            pevent.Graphics.DrawString(this.Text, this.Font, Brushes.Black, pevent.ClipRectangle, sf);
        }
    }
}
