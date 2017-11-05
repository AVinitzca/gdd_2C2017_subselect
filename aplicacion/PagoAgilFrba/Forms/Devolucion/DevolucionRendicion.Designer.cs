namespace PagoAgilFrba.Forms.Devolucion
{
    partial class FormDevolucionRendicion
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
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.lblFactura = new System.Windows.Forms.Label();
            this.cmbRendiciones = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtMotivo.Location = new System.Drawing.Point(17, 148);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(360, 30);
            this.txtMotivo.TabIndex = 9;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMotivo.Location = new System.Drawing.Point(12, 107);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(70, 25);
            this.lblMotivo.TabIndex = 8;
            this.lblMotivo.Text = "Motivo";
            // 
            // btnDevolver
            // 
            this.btnDevolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnDevolver.Location = new System.Drawing.Point(111, 235);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(173, 61);
            this.btnDevolver.TabIndex = 7;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFactura.Location = new System.Drawing.Point(12, 9);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(193, 25);
            this.lblFactura.TabIndex = 6;
            this.lblFactura.Text = "Rendicion a devolver";
            // 
            // cmbRendiciones
            // 
            this.cmbRendiciones.DisplayMember = "Detalle";
            this.cmbRendiciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbRendiciones.FormattingEnabled = true;
            this.cmbRendiciones.Location = new System.Drawing.Point(17, 50);
            this.cmbRendiciones.Name = "cmbRendiciones";
            this.cmbRendiciones.Size = new System.Drawing.Size(360, 33);
            this.cmbRendiciones.TabIndex = 5;
            this.cmbRendiciones.Text = "Rendicion";
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnVolver.Location = new System.Drawing.Point(111, 314);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(173, 61);
            this.btnVolver.TabIndex = 10;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormDevolucionRendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 387);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.lblFactura);
            this.Controls.Add(this.cmbRendiciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDevolucionRendicion";
            this.Text = "DevolucionRendicion";
            this.Load += new System.EventHandler(this.DevolucionRendicion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.ComboBox cmbRendiciones;
        private System.Windows.Forms.Button btnVolver;
    }
}