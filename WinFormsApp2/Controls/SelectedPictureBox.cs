using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp2.Controls
{
    public class SelectedPictureBox : PictureBox
    {
        private bool ispressed, hover, pressed;

        public SelectedPictureBox()
        {
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.Margin = new Padding(0);
            this.Size = new Size(64, 48);
            this.ispressed = false;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.AutoSize = false;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.pressed = true;
            this.Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.hover = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.hover = false;
            this.Invalidate();
        }

        private static void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rectangle, float radius)
        {
            float size = radius * 2f;

            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rectangle.X, rectangle.Y, size, size, 180, 90);
            gp.AddArc(rectangle.X + rectangle.Width - size, rectangle.Y, size, size, 270, 90);
            gp.AddArc(rectangle.X + rectangle.Width - size, rectangle.Y + rectangle.Height - size, size, size, 0, 90);
            gp.AddArc(rectangle.X, rectangle.Y + rectangle.Height - size, size, size, 90, 90);
            gp.CloseFigure();
            g.DrawPath(pen, gp);
            gp.Dispose();
        }
        private static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rectangle, float radius)
        {
            float size = radius * 2f;

            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rectangle.X, rectangle.Y, size, size, 180, 90);
            gp.AddArc(rectangle.X + rectangle.Width - size, rectangle.Y, size, size, 270, 90);
            gp.AddArc(rectangle.X + rectangle.Width - size, rectangle.Y + rectangle.Height - size, size, size, 0, 90);
            gp.AddArc(rectangle.X, rectangle.Y + rectangle.Height - size, size, size, 90, 90);
            gp.CloseFigure();
            g.FillPath(brush, gp);
            gp.Dispose();
        }
        private static void FillTopRoundRectangle(Graphics g, Brush brush, Rectangle rectangle, float radius)
        {
            float size = radius * 2f;

            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(rectangle.X, rectangle.Y, size, size, 180, 90);
            gp.AddArc(rectangle.X + rectangle.Width - size, rectangle.Y, size, size, 270, 90);
            gp.AddLine(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height, rectangle.X, rectangle.Y + rectangle.Height);
            gp.CloseFigure();
            g.FillPath(brush, gp);
            gp.Dispose();
        }
        private static void RenderSelection(Graphics g, Rectangle rectangle, float radius, bool pressed)
        {
            if (pressed)
            {
                Color[] col = new Color[] { Color.FromArgb(254, 216, 170), Color.FromArgb(251, 181, 101), Color.FromArgb(250, 157, 52), Color.FromArgb(253, 238, 170) };

                float[] pos = new float[] { 0.0f, 0.4f, 0.4f, 1.0f };

                ColorBlend blend = new ColorBlend();
                blend.Colors = col;
                blend.Positions = pos;
                LinearGradientBrush brush = new LinearGradientBrush(rectangle, Color.Transparent, Color.Transparent, LinearGradientMode.Vertical);
                brush.InterpolationColors = blend;

                FillRoundRectangle(g, brush, rectangle, 2f);

                DrawRoundRectangle(g, new Pen(Color.FromArgb(171, 161, 140)), rectangle, radius);
                rectangle.Offset(1, 1);
                rectangle.Width -= 2;
                rectangle.Height -= 2;
                DrawRoundRectangle(g, new Pen(new LinearGradientBrush(rectangle, Color.FromArgb(223, 183, 136), Color.Transparent, LinearGradientMode.ForwardDiagonal)), rectangle, radius);
            }
            else
            {
                Color[] col = new Color[] { Color.FromArgb(255, 254, 227), Color.FromArgb(255, 231, 151), Color.FromArgb(255, 215, 80), Color.FromArgb(255, 231, 150) };
                float[] pos = new float[] { 0.0f, 0.4f, 0.4f, 1.0f };

                ColorBlend blend = new ColorBlend();
                blend.Colors = col;
                blend.Positions = pos;
                LinearGradientBrush brush = new LinearGradientBrush(rectangle, Color.Transparent, Color.Transparent, LinearGradientMode.Vertical);
                brush.InterpolationColors = blend;

                FillRoundRectangle(g, brush, rectangle, 2f);

                DrawRoundRectangle(g, new Pen(Color.FromArgb(210, 192, 141)), rectangle, radius);
                rectangle.Offset(1, 1);
                rectangle.Width -= 2;
                rectangle.Height -= 2;
                DrawRoundRectangle(g, new Pen(new LinearGradientBrush(rectangle, Color.FromArgb(255, 255, 247), Color.Transparent, LinearGradientMode.ForwardDiagonal)), rectangle, 2f);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            if (rect.IntersectsWith(e.ClipRectangle))
            {
                if (this.hover)
                    RenderSelection(e.Graphics, rect, 2f, this.pressed);
                else if (this.ispressed)
                    RenderSelection(e.Graphics, rect, 2f, true);

                if (this.Enabled && this.Image != null)
                    e.Graphics.DrawImage(this.Image, 4, 4, this.Width - 8, this.Height - 8);
            }
        }

        public bool IsPressed
        {
            get { return this.ispressed; }
            set
            {
                this.ispressed = value;

                this.Invalidate();
            }
        }
    }
}
