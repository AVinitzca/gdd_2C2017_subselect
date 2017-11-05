namespace PagoAgilFrba.ListadoEstadistico
{
    partial class FormListadoEstadistico
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
            this.numTrimestre = new System.Windows.Forms.NumericUpDown();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblTrimestre = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbListado = new System.Windows.Forms.ComboBox();
            this.lblListado = new System.Windows.Forms.Label();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.numAnio = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numTrimestre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // numTrimestre
            // 
            this.numTrimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numTrimestre.Location = new System.Drawing.Point(398, 83);
            this.numTrimestre.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numTrimestre.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTrimestre.Name = "numTrimestre";
            this.numTrimestre.Size = new System.Drawing.Size(110, 34);
            this.numTrimestre.TabIndex = 1;
            this.numTrimestre.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTrimestre.ValueChanged += new System.EventHandler(this.numTrimestre_ValueChanged);
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblAnio.Location = new System.Drawing.Point(325, 39);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(67, 29);
            this.lblAnio.TabIndex = 2;
            this.lblAnio.Text = "Anio:";
            // 
            // lblTrimestre
            // 
            this.lblTrimestre.AutoSize = true;
            this.lblTrimestre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTrimestre.Location = new System.Drawing.Point(269, 88);
            this.lblTrimestre.Name = "lblTrimestre";
            this.lblTrimestre.Size = new System.Drawing.Size(123, 29);
            this.lblTrimestre.TabIndex = 3;
            this.lblTrimestre.Text = "Trimestre:";
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnVolver.Location = new System.Drawing.Point(73, 39);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(146, 81);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbListado
            // 
            this.cmbListado.DisplayMember = "Nombre";
            this.cmbListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmbListado.FormattingEnabled = true;
            this.cmbListado.Location = new System.Drawing.Point(555, 80);
            this.cmbListado.Name = "cmbListado";
            this.cmbListado.Size = new System.Drawing.Size(526, 37);
            this.cmbListado.TabIndex = 5;
            this.cmbListado.Text = "Tipo de listado";
            this.cmbListado.SelectedIndexChanged += new System.EventHandler(this.cmbListado_SelectedIndexChanged);
            // 
            // lblListado
            // 
            this.lblListado.AutoSize = true;
            this.lblListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblListado.Location = new System.Drawing.Point(550, 41);
            this.lblListado.Name = "lblListado";
            this.lblListado.Size = new System.Drawing.Size(189, 29);
            this.lblListado.TabIndex = 6;
            this.lblListado.Text = "Listado (TOP 5):";
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(73, 136);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowTemplate.Height = 24;
            this.dgvListado.Size = new System.Drawing.Size(1008, 346);
            this.dgvListado.TabIndex = 7;
            // 
            // numAnio
            // 
            this.numAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numAnio.Location = new System.Drawing.Point(398, 37);
            this.numAnio.Maximum = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.numAnio.Minimum = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            this.numAnio.Name = "numAnio";
            this.numAnio.Size = new System.Drawing.Size(110, 34);
            this.numAnio.TabIndex = 8;
            this.numAnio.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            this.numAnio.ValueChanged += new System.EventHandler(this.numAnio_ValueChanged);
            // 
            // FormListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 529);
            this.Controls.Add(this.numAnio);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.lblListado);
            this.Controls.Add(this.cmbListado);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.lblTrimestre);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.numTrimestre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.FormListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTrimestre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numTrimestre;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblTrimestre;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cmbListado;
        private System.Windows.Forms.Label lblListado;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.NumericUpDown numAnio;
    }
}