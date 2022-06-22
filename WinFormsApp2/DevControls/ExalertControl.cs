using System;
using DevExpress.XtraBars.Alerter;
using System.Windows.Forms;

namespace WinFormsApp2.DevControls
{
    public class ExalertControl : DevExpress.XtraBars.Alerter.AlertControl
    {
        public ExalertControl()
        {
            this.AllowHtmlText = true;
            this.AutoFormDelay = 5000;
            this.FormLocation = AlertFormLocation.TopRight;
            this.ShowCloseButton = true;
            this.ShowPinButton = false;
            this.ShowToolTips = false;

            this.AlertClick += new AlertClickEventHandler(this.ExalertControl_AlertClick);
            this.FormClosing += new AlertFormClosingEventHandler(this.ExalertControl_FormClosing);
        }
        public void Show(Form form, string sTitle, string sMessage)
        {
            Show(form, sTitle, sMessage, Properties.Resources.close);
        }

        private void ExalertControl_AlertClick(object sender, AlertClickEventArgs e)
        {
            Console.WriteLine("ExalertControl_AlertClick");
        }

        private void ExalertControl_FormClosing(object sender, AlertFormClosingEventArgs e)
        {
            Console.WriteLine("ExalertControl_FormClosing");
        }
    }
}
