namespace PagoAgilFrba.Forms.MenuPrincipal
{
    partial class FormMenuPrincipal
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
            this.mnsNavbar = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // mnsNavbar
            // 
            this.mnsNavbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsNavbar.Location = new System.Drawing.Point(0, 0);
            this.mnsNavbar.Name = "mnsNavbar";
            this.mnsNavbar.Size = new System.Drawing.Size(1167, 24);
            this.mnsNavbar.TabIndex = 0;
            this.mnsNavbar.Text = "Navbar";
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 361);
            this.Controls.Add(this.mnsNavbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnsNavbar;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenuPrincipal";
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsNavbar;
    }
}