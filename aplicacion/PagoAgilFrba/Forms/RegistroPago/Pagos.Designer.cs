namespace PagoAgilFrba.RegistroPago
{
    partial class FormPagos
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
            this.lstFacturas = new System.Windows.Forms.ListBox();
            this.lblFacturas = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.cmbEmpresas = new System.Windows.Forms.ComboBox();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCiente = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFacturas
            // 
            this.lstFacturas.DisplayMember = "NumeroFactura";
            this.lstFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lstFacturas.FormattingEnabled = true;
            this.lstFacturas.ItemHeight = 25;
            this.lstFacturas.Location = new System.Drawing.Point(14, 117);
            this.lstFacturas.Name = "lstFacturas";
            this.lstFacturas.Size = new System.Drawing.Size(325, 204);
            this.lstFacturas.TabIndex = 0;
            this.lstFacturas.SelectedIndexChanged += new System.EventHandler(this.lstFacturas_SelectedIndexChanged);
            // 
            // lblFacturas
            // 
            this.lblFacturas.AutoSize = true;
            this.lblFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFacturas.Location = new System.Drawing.Point(14, 83);
            this.lblFacturas.Name = "lblFacturas";
            this.lblFacturas.Size = new System.Drawing.Size(88, 25);
            this.lblFacturas.TabIndex = 1;
            this.lblFacturas.Text = "Facturas";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEmpresa.Location = new System.Drawing.Point(12, 9);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(90, 25);
            this.lblEmpresa.TabIndex = 2;
            this.lblEmpresa.Text = "Empresa";
            // 
            // cmbEmpresas
            // 
            this.cmbEmpresas.DisplayMember = "Nombre";
            this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbEmpresas.FormattingEnabled = true;
            this.cmbEmpresas.Location = new System.Drawing.Point(17, 38);
            this.cmbEmpresas.Name = "cmbEmpresas";
            this.cmbEmpresas.Size = new System.Drawing.Size(320, 33);
            this.cmbEmpresas.TabIndex = 3;
            this.cmbEmpresas.Text = "Empresa";
            this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresas_SelectedIndexChanged);
            // 
            // cmbCliente
            // 
            this.cmbCliente.DisplayMember = "NombreCompleto";
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(14, 363);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(320, 33);
            this.cmbCliente.TabIndex = 5;
            this.cmbCliente.Text = "Cliente";
            // 
            // lblCiente
            // 
            this.lblCiente.AutoSize = true;
            this.lblCiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCiente.Location = new System.Drawing.Point(9, 334);
            this.lblCiente.Name = "lblCiente";
            this.lblCiente.Size = new System.Drawing.Size(73, 25);
            this.lblCiente.TabIndex = 4;
            this.lblCiente.Text = "Cliente";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.DisplayMember = "Descripcion";
            this.cmbFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(12, 441);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(320, 33);
            this.cmbFormaPago.TabIndex = 7;
            this.cmbFormaPago.Text = "Forma de Pago";
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblFormaPago.Location = new System.Drawing.Point(9, 413);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(146, 25);
            this.lblFormaPago.TabIndex = 6;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblImporte.Location = new System.Drawing.Point(12, 499);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(88, 25);
            this.lblImporte.TabIndex = 8;
            this.lblImporte.Text = "Importe: ";
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnPagar.Location = new System.Drawing.Point(68, 538);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(204, 60);
            this.btnPagar.TabIndex = 9;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // FormPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 610);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.cmbFormaPago);
            this.Controls.Add(this.lblFormaPago);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.lblCiente);
            this.Controls.Add(this.cmbEmpresas);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.lblFacturas);
            this.Controls.Add(this.lstFacturas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.FormPagos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFacturas;
        private System.Windows.Forms.Label lblFacturas;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresas;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblCiente;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Button btnPagar;
    }
}