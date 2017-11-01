namespace PagoAgilFrba.Rendicion
{
    partial class FormRendiciones
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
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.cmbEmpresas = new System.Windows.Forms.ComboBox();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.btnRendir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEmpresa.Location = new System.Drawing.Point(12, 9);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(90, 25);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Empresa";
            // 
            // cmbEmpresas
            // 
            this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbEmpresas.FormattingEnabled = true;
            this.cmbEmpresas.Location = new System.Drawing.Point(15, 48);
            this.cmbEmpresas.Name = "cmbEmpresas";
            this.cmbEmpresas.Size = new System.Drawing.Size(248, 33);
            this.cmbEmpresas.TabIndex = 1;
            this.cmbEmpresas.Text = "Empresas";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPorcentaje.Location = new System.Drawing.Point(12, 103);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(214, 25);
            this.lblPorcentaje.TabIndex = 2;
            this.lblPorcentaje.Text = "Porcentaje de comision";
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPorcentaje.Location = new System.Drawing.Point(15, 147);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(215, 30);
            this.txtPorcentaje.TabIndex = 3;
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
            // 
            // btnRendir
            // 
            this.btnRendir.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnRendir.Location = new System.Drawing.Point(116, 204);
            this.btnRendir.Name = "btnRendir";
            this.btnRendir.Size = new System.Drawing.Size(147, 54);
            this.btnRendir.TabIndex = 4;
            this.btnRendir.Text = "Rendir";
            this.btnRendir.UseVisualStyleBackColor = true;
            this.btnRendir.Click += new System.EventHandler(this.btnRendir_Click);
            // 
            // FormRendiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 293);
            this.Controls.Add(this.btnRendir);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.cmbEmpresas);
            this.Controls.Add(this.lblEmpresa);
            this.Name = "FormRendiciones";
            this.Text = "Rendiciones";
            this.Load += new System.EventHandler(this.FormRendiciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresas;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Button btnRendir;
    }
}