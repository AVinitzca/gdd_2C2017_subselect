namespace PagoAgilFrba.Forms.AbmEmpresa
{
    partial class FormEmpresas
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
            this.dgvEmpresas = new System.Windows.Forms.DataGridView();
            this.gpbIngreso = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.lblFiltroNombre = new System.Windows.Forms.Label();
            this.txtFiltroCuit = new System.Windows.Forms.TextBox();
            this.lblFiltroCuit = new System.Windows.Forms.Label();
            this.cmbFiltroRubro = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label_dia = new System.Windows.Forms.Label();
            this.numDiasRend = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).BeginInit();
            this.gpbIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasRend)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpresas
            // 
            this.dgvEmpresas.AllowUserToAddRows = false;
            this.dgvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresas.Location = new System.Drawing.Point(320, 124);
            this.dgvEmpresas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvEmpresas.Name = "dgvEmpresas";
            this.dgvEmpresas.ReadOnly = true;
            this.dgvEmpresas.RowTemplate.Height = 24;
            this.dgvEmpresas.Size = new System.Drawing.Size(570, 343);
            this.dgvEmpresas.TabIndex = 3;
            this.dgvEmpresas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpresas_CellContentClick);
            // 
            // gpbIngreso
            // 
            this.gpbIngreso.Controls.Add(this.numDiasRend);
            this.gpbIngreso.Controls.Add(this.label_dia);
            this.gpbIngreso.Controls.Add(this.txtDireccion);
            this.gpbIngreso.Controls.Add(this.lblDireccion);
            this.gpbIngreso.Controls.Add(this.txtCuit);
            this.gpbIngreso.Controls.Add(this.lblCuit);
            this.gpbIngreso.Controls.Add(this.cmbRubro);
            this.gpbIngreso.Controls.Add(this.btnCancelar);
            this.gpbIngreso.Controls.Add(this.btnModificar);
            this.gpbIngreso.Controls.Add(this.btnCrear);
            this.gpbIngreso.Controls.Add(this.txtNombre);
            this.gpbIngreso.Controls.Add(this.lblNombre);
            this.gpbIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbIngreso.Location = new System.Drawing.Point(39, 97);
            this.gpbIngreso.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpbIngreso.Name = "gpbIngreso";
            this.gpbIngreso.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gpbIngreso.Size = new System.Drawing.Size(276, 370);
            this.gpbIngreso.TabIndex = 2;
            this.gpbIngreso.TabStop = false;
            this.gpbIngreso.Text = "Nueva Empresa";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(95, 137);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(153, 26);
            this.txtDireccion.TabIndex = 10;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(21, 140);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(75, 20);
            this.lblDireccion.TabIndex = 9;
            this.lblDireccion.Text = "Direccion";
            // 
            // txtCuit
            // 
            this.txtCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuit.Location = new System.Drawing.Point(70, 97);
            this.txtCuit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(179, 26);
            this.txtCuit.TabIndex = 8;
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuit.Location = new System.Drawing.Point(21, 99);
            this.lblCuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(46, 20);
            this.lblCuit.TabIndex = 7;
            this.lblCuit.Text = "CUIT";
            // 
            // cmbRubro
            // 
            this.cmbRubro.DisplayMember = "Descripcion";
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(25, 219);
            this.cmbRubro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(224, 33);
            this.cmbRubro.TabIndex = 6;
            this.cmbRubro.Text = "Rubro";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(144, 299);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 55);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(25, 299);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(106, 55);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(76, 299);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(112, 55);
            this.btnCrear.TabIndex = 3;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(86, 57);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(162, 26);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(21, 59);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroNombre.Location = new System.Drawing.Point(385, 94);
            this.txtFiltroNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(118, 26);
            this.txtFiltroNombre.TabIndex = 12;
            this.txtFiltroNombre.TextChanged += new System.EventHandler(this.txtFiltroNombre_TextChanged);
            // 
            // lblFiltroNombre
            // 
            this.lblFiltroNombre.AutoSize = true;
            this.lblFiltroNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroNombre.Location = new System.Drawing.Point(320, 97);
            this.lblFiltroNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroNombre.Name = "lblFiltroNombre";
            this.lblFiltroNombre.Size = new System.Drawing.Size(65, 20);
            this.lblFiltroNombre.TabIndex = 11;
            this.lblFiltroNombre.Text = "Nombre";
            // 
            // txtFiltroCuit
            // 
            this.txtFiltroCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroCuit.Location = new System.Drawing.Point(546, 94);
            this.txtFiltroCuit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFiltroCuit.Name = "txtFiltroCuit";
            this.txtFiltroCuit.Size = new System.Drawing.Size(118, 26);
            this.txtFiltroCuit.TabIndex = 14;
            this.txtFiltroCuit.TextChanged += new System.EventHandler(this.txtFiltroCuit_TextChanged);
            // 
            // lblFiltroCuit
            // 
            this.lblFiltroCuit.AutoSize = true;
            this.lblFiltroCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroCuit.Location = new System.Drawing.Point(506, 97);
            this.lblFiltroCuit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltroCuit.Name = "lblFiltroCuit";
            this.lblFiltroCuit.Size = new System.Drawing.Size(37, 20);
            this.lblFiltroCuit.TabIndex = 13;
            this.lblFiltroCuit.Text = "Cuit";
            // 
            // cmbFiltroRubro
            // 
            this.cmbFiltroRubro.DisplayMember = "Descripcion";
            this.cmbFiltroRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroRubro.FormattingEnabled = true;
            this.cmbFiltroRubro.Location = new System.Drawing.Point(680, 92);
            this.cmbFiltroRubro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbFiltroRubro.Name = "cmbFiltroRubro";
            this.cmbFiltroRubro.Size = new System.Drawing.Size(142, 28);
            this.cmbFiltroRubro.TabIndex = 15;
            this.cmbFiltroRubro.Text = "Rubro";
            this.cmbFiltroRubro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroRubro_SelectedIndexChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnVolver.Location = new System.Drawing.Point(39, 28);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(131, 46);
            this.btnVolver.TabIndex = 11;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label_dia
            // 
            this.label_dia.AutoSize = true;
            this.label_dia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dia.Location = new System.Drawing.Point(21, 181);
            this.label_dia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_dia.Name = "label_dia";
            this.label_dia.Size = new System.Drawing.Size(108, 20);
            this.label_dia.TabIndex = 11;
            this.label_dia.Text = "Dia Rendicion";
            // 
            // numDiasRend
            // 
            this.numDiasRend.Location = new System.Drawing.Point(144, 175);
            this.numDiasRend.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.numDiasRend.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDiasRend.Name = "numDiasRend";
            this.numDiasRend.Size = new System.Drawing.Size(104, 32);
            this.numDiasRend.TabIndex = 12;
            this.numDiasRend.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDiasRend.ValueChanged += new System.EventHandler(this.numDiasRend_ValueChanged);
            // 
            // FormEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 519);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cmbFiltroRubro);
            this.Controls.Add(this.txtFiltroCuit);
            this.Controls.Add(this.lblFiltroCuit);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.lblFiltroNombre);
            this.Controls.Add(this.dgvEmpresas);
            this.Controls.Add(this.gpbIngreso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEmpresas";
            this.Text = "Empresas";
            this.Load += new System.EventHandler(this.Empresas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresas)).EndInit();
            this.gpbIngreso.ResumeLayout(false);
            this.gpbIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiasRend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpresas;
        private System.Windows.Forms.GroupBox gpbIngreso;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label lblFiltroNombre;
        private System.Windows.Forms.TextBox txtFiltroCuit;
        private System.Windows.Forms.Label lblFiltroCuit;
        private System.Windows.Forms.ComboBox cmbFiltroRubro;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.NumericUpDown numDiasRend;
        private System.Windows.Forms.Label label_dia;
    }
}