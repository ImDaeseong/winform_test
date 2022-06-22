using System.Drawing;
using DevExpress.XtraEditors;

namespace WinFormsApp2.DevControls
{
    public class UnderLineLabel : DevExpress.XtraEditors.LabelControl
    {
        public UnderLineLabel()
        {
            this.Appearance.BackColor = Color.Transparent;
            this.AutoSizeMode = LabelAutoSizeMode.None;
            this.LineColor = Color.FromArgb(255, 128, 0);
            this.LineLocation = LineLocation.Bottom;
            this.LineVisible = true;
            this.ShowLineShadow = false;
        }
    }
}
