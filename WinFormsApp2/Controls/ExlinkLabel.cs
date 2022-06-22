using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2.Controls
{
    public class ExlinkLabel : System.Windows.Forms.LinkLabel
    {
        public ExlinkLabel()
        {
            this.AutoSize = true;

            this.BackColor = Color.Transparent;
            this.Cursor = Cursors.Hand;
            this.TextAlign = ContentAlignment.MiddleCenter;

            this.LinkBehavior = LinkBehavior.AlwaysUnderline;//LinkBehavior.HoverUnderline;

            this.LinkColor = Color.FromArgb(0, 0, 0);
            this.ActiveLinkColor = Color.FromArgb(255, 0, 0);
                        
            this.LinkVisited = false;
            this.VisitedLinkColor = System.Drawing.Color.Blue;

            this.MouseEnter += new System.EventHandler(this.ExlinkLabel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ExlinkLabel_MouseLeave);
        }

        private void ExlinkLabel_MouseEnter(object sender, EventArgs e)
        {
           this.BackColor = Color.Gray;
        }

        private void ExlinkLabel_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}
