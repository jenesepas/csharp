namespace cartera
{
    partial class frmCartera
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRejillaDatos = new System.Windows.Forms.DataGridView();
            this.btObtenerDatos = new System.Windows.Forms.Button();
            this.btInsertarLinea = new System.Windows.Forms.Button();
            this.tbImporteAgrupado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCodigoCliente = new System.Windows.Forms.TextBox();
            this.btGuardarDatos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRejillaDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dgvRejillaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRejillaDatos.Location = new System.Drawing.Point(12, 70);
            this.dgvRejillaDatos.Name = "dataGridView1";
            this.dgvRejillaDatos.Size = new System.Drawing.Size(1089, 329);
            this.dgvRejillaDatos.TabIndex = 0;
            // 
            // btObtenerDatos
            // 
            this.btObtenerDatos.Location = new System.Drawing.Point(12, 12);
            this.btObtenerDatos.Name = "btObtenerDatos";
            this.btObtenerDatos.Size = new System.Drawing.Size(104, 23);
            this.btObtenerDatos.TabIndex = 1;
            this.btObtenerDatos.Text = "Obtener datos";
            this.btObtenerDatos.UseVisualStyleBackColor = true;
            this.btObtenerDatos.Click += new System.EventHandler(this.btObtenerDatos_Click);
            // 
            // btInsertarLinea
            // 
            this.btInsertarLinea.Location = new System.Drawing.Point(12, 41);
            this.btInsertarLinea.Name = "btInsertarLinea";
            this.btInsertarLinea.Size = new System.Drawing.Size(104, 23);
            this.btInsertarLinea.TabIndex = 2;
            this.btInsertarLinea.Text = "Insertar línea";
            this.btInsertarLinea.UseVisualStyleBackColor = true;
            this.btInsertarLinea.Click += new System.EventHandler(this.btInsertarLinea_Click);
            // 
            // tbImporteAgrupado
            // 
            this.tbImporteAgrupado.Location = new System.Drawing.Point(776, 41);
            this.tbImporteAgrupado.Name = "tbImporteAgrupado";
            this.tbImporteAgrupado.Size = new System.Drawing.Size(159, 20);
            this.tbImporteAgrupado.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Importe agrupado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(680, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha anotación";
            // 
            // tbFecha
            // 
            this.tbFecha.Location = new System.Drawing.Point(776, 12);
            this.tbFecha.Name = "tbFecha";
            this.tbFecha.Size = new System.Drawing.Size(159, 20);
            this.tbFecha.TabIndex = 5;
            this.tbFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Codigo cliente";
            // 
            // tbCodigoCliente
            // 
            this.tbCodigoCliente.Location = new System.Drawing.Point(222, 15);
            this.tbCodigoCliente.Name = "tbCodigoCliente";
            this.tbCodigoCliente.Size = new System.Drawing.Size(182, 20);
            this.tbCodigoCliente.TabIndex = 7;
            // 
            // btGuardarDatos
            // 
            this.btGuardarDatos.Location = new System.Drawing.Point(122, 41);
            this.btGuardarDatos.Name = "btGuardarDatos";
            this.btGuardarDatos.Size = new System.Drawing.Size(104, 23);
            this.btGuardarDatos.TabIndex = 9;
            this.btGuardarDatos.Text = "Guardar datos";
            this.btGuardarDatos.UseVisualStyleBackColor = true;
            this.btGuardarDatos.Click += new System.EventHandler(this.btGuardarDatos_Click);
            // 
            // frmCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 411);
            this.Controls.Add(this.btGuardarDatos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCodigoCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbImporteAgrupado);
            this.Controls.Add(this.btInsertarLinea);
            this.Controls.Add(this.btObtenerDatos);
            this.Controls.Add(this.dgvRejillaDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmCartera";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRejillaDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRejillaDatos;
        private System.Windows.Forms.Button btObtenerDatos;
        private System.Windows.Forms.Button btInsertarLinea;
        private System.Windows.Forms.TextBox tbImporteAgrupado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCodigoCliente;
        private System.Windows.Forms.Button btGuardarDatos;
    }
}

