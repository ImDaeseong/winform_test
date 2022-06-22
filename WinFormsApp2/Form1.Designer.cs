namespace WinFormsApp2
{
    partial class Form1
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
            this.selectedPictureBox1 = new WinFormsApp2.Controls.SelectedPictureBox();
            this.roundedButton1 = new WinFormsApp2.Controls.RoundedButton();
            this.underLineLabel1 = new WinFormsApp2.DevControls.UnderLineLabel();
            this.exlinkLabel2 = new WinFormsApp2.Controls.ExlinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedPictureBox1
            // 
            this.selectedPictureBox1.Image = global::WinFormsApp2.Properties.Resources.bg1;
            this.selectedPictureBox1.IsPressed = false;
            this.selectedPictureBox1.Location = new System.Drawing.Point(161, 296);
            this.selectedPictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.selectedPictureBox1.Name = "selectedPictureBox1";
            this.selectedPictureBox1.Size = new System.Drawing.Size(146, 105);
            this.selectedPictureBox1.TabIndex = 3;
            this.selectedPictureBox1.TabStop = false;
            // 
            // roundedButton1
            // 
            this.roundedButton1.Location = new System.Drawing.Point(161, 195);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(100, 56);
            this.roundedButton1.TabIndex = 2;
            this.roundedButton1.Text = "roundedButton1";
            this.roundedButton1.UseVisualStyleBackColor = true;
            // 
            // underLineLabel1
            // 
            this.underLineLabel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.underLineLabel1.Appearance.Options.UseBackColor = true;
            this.underLineLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.underLineLabel1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.underLineLabel1.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.underLineLabel1.LineVisible = true;
            this.underLineLabel1.Location = new System.Drawing.Point(161, 109);
            this.underLineLabel1.Name = "underLineLabel1";
            this.underLineLabel1.ShowLineShadow = false;
            this.underLineLabel1.Size = new System.Drawing.Size(254, 29);
            this.underLineLabel1.TabIndex = 1;
            this.underLineLabel1.Text = "underLineLabel1";
            // 
            // exlinkLabel2
            // 
            this.exlinkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exlinkLabel2.AutoSize = true;
            this.exlinkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.exlinkLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exlinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.exlinkLabel2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.exlinkLabel2.Location = new System.Drawing.Point(159, 49);
            this.exlinkLabel2.Name = "exlinkLabel2";
            this.exlinkLabel2.Size = new System.Drawing.Size(75, 12);
            this.exlinkLabel2.TabIndex = 0;
            this.exlinkLabel2.TabStop = true;
            this.exlinkLabel2.Text = "exlinkLabel2";
            this.exlinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exlinkLabel2.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.selectedPictureBox1);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.underLineLabel1);
            this.Controls.Add(this.exlinkLabel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectedPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ExlinkLabel exlinkLabel1;
        private Controls.ExlinkLabel exlinkLabel2;
        private DevControls.UnderLineLabel underLineLabel1;
        private Controls.RoundedButton roundedButton1;
        private Controls.SelectedPictureBox selectedPictureBox1;
    }
}