namespace WinFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLine = new System.Windows.Forms.Panel();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLine.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnlLine.Controls.Add(this.xtraScrollableControl1);
            this.pnlLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLine.ForeColor = System.Drawing.Color.White;
            this.pnlLine.Location = new System.Drawing.Point(0, 0);
            this.pnlLine.Margin = new System.Windows.Forms.Padding(10);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLine.Size = new System.Drawing.Size(800, 450);
            this.pnlLine.TabIndex = 0;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.xtraScrollableControl1.Controls.Add(this.pnlMain);
            this.xtraScrollableControl1.FireScrollEventOnMouseWheel = true;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(10, 10);
            this.xtraScrollableControl1.LookAndFeel.SkinName = "Black";
            this.xtraScrollableControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.xtraScrollableControl1.Margin = new System.Windows.Forms.Padding(0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(166, 80);
            this.xtraScrollableControl1.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(10, 10);
            this.pnlMain.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlLine);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResizeEnd += new System.EventHandler(this.Form2_ResizeEnd);
            this.pnlLine.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLine;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private System.Windows.Forms.Panel pnlMain;
    }
}