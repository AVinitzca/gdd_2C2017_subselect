﻿namespace PagoAgilFrba.AbmFactura
{
    partial class FormAltaFactura
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
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.dgvColumnItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColumnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblItems = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.gpbIngreso = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.gpbIngreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(6, 70);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(73, 25);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DisplayMember = "NombreCompleto";
            this.cmbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(221, 67);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(236, 33);
            this.cmbCliente.TabIndex = 1;
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DisplayMember = "Nombre";
            this.cmbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(221, 114);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(236, 33);
            this.cmbEmpresa.TabIndex = 3;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(6, 117);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(90, 25);
            this.lblEmpresa.TabIndex = 2;
            this.lblEmpresa.Text = "Empresa";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(221, 162);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(236, 30);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(221, 202);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(235, 30);
            this.dtpFechaVencimiento.TabIndex = 7;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(6, 163);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(67, 25);
            this.lblFecha.TabIndex = 8;
            this.lblFecha.Text = "Fecha";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaVencimiento.Location = new System.Drawing.Point(6, 204);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(207, 25);
            this.lblFechaVencimiento.TabIndex = 9;
            this.lblFechaVencimiento.Text = "Fecha de Vencimiento";
            // 
            // dgvItems
            // 
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColumnItems,
            this.dgvColumnMonto,
            this.dgvColumnCantidad,
            this.dgvColumnTotal});
            this.dgvItems.Location = new System.Drawing.Point(11, 298);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowTemplate.Height = 24;
            this.dgvItems.Size = new System.Drawing.Size(445, 178);
            this.dgvItems.TabIndex = 10;
            this.dgvItems.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValidated);
            this.dgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItems_EditingControlShowing);
            // 
            // dgvColumnItems
            // 
            this.dgvColumnItems.HeaderText = "Items";
            this.dgvColumnItems.Name = "dgvColumnItems";
            // 
            // dgvColumnMonto
            // 
            this.dgvColumnMonto.HeaderText = "Monto";
            this.dgvColumnMonto.Name = "dgvColumnMonto";
            // 
            // dgvColumnCantidad
            // 
            this.dgvColumnCantidad.HeaderText = "Cantidad";
            this.dgvColumnCantidad.Name = "dgvColumnCantidad";
            // 
            // dgvColumnTotal
            // 
            this.dgvColumnTotal.HeaderText = "Total";
            this.dgvColumnTotal.Name = "dgvColumnTotal";
            this.dgvColumnTotal.ReadOnly = true;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.Location = new System.Drawing.Point(6, 256);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(59, 25);
            this.lblItems.TabIndex = 11;
            this.lblItems.Text = "Items";
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnCrear.Location = new System.Drawing.Point(132, 504);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(175, 84);
            this.btnCrear.TabIndex = 12;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(367, 270);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(78, 25);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total: 0";
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnVolver.Location = new System.Drawing.Point(50, 34);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(175, 84);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(542, 136);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.RowTemplate.Height = 24;
            this.dgvFacturas.Size = new System.Drawing.Size(1074, 604);
            this.dgvFacturas.TabIndex = 15;
            // 
            // gpbIngreso
            // 
            this.gpbIngreso.Controls.Add(this.dtpFechaVencimiento);
            this.gpbIngreso.Controls.Add(this.lblCliente);
            this.gpbIngreso.Controls.Add(this.cmbCliente);
            this.gpbIngreso.Controls.Add(this.lblTotal);
            this.gpbIngreso.Controls.Add(this.lblEmpresa);
            this.gpbIngreso.Controls.Add(this.btnCrear);
            this.gpbIngreso.Controls.Add(this.cmbEmpresa);
            this.gpbIngreso.Controls.Add(this.lblItems);
            this.gpbIngreso.Controls.Add(this.dateTimePicker1);
            this.gpbIngreso.Controls.Add(this.dgvItems);
            this.gpbIngreso.Controls.Add(this.lblFecha);
            this.gpbIngreso.Controls.Add(this.lblFechaVencimiento);
            this.gpbIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gpbIngreso.Location = new System.Drawing.Point(50, 136);
            this.gpbIngreso.Name = "gpbIngreso";
            this.gpbIngreso.Size = new System.Drawing.Size(463, 604);
            this.gpbIngreso.TabIndex = 16;
            this.gpbIngreso.TabStop = false;
            this.gpbIngreso.Text = "Nueva Factura";
            // 
            // FormAltaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1745, 801);
            this.Controls.Add(this.gpbIngreso);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.btnVolver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAltaFactura";
            this.Text = "Registro de Facturas";
            this.Load += new System.EventHandler(this.FormFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.gpbIngreso.ResumeLayout(false);
            this.gpbIngreso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColumnTotal;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.GroupBox gpbIngreso;
    }
}