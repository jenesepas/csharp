namespace Puche
{
    partial class MTasas
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
            this.dgv_tasas = new System.Windows.Forms.DataGridView();
            this.lb_tit_tas = new System.Windows.Forms.Label();
            this.btt_consultar_tas = new System.Windows.Forms.Button();
            this.btt_new_tas = new System.Windows.Forms.Button();
            this.btt_save_tas = new System.Windows.Forms.Button();
            this.btt_del_tas = new System.Windows.Forms.Button();
            this.tb_ejercicio = new System.Windows.Forms.TextBox();
            this.lb_ejercicio = new System.Windows.Forms.Label();
            this.lb_codigo = new System.Windows.Forms.Label();
            this.tb_codigo = new System.Windows.Forms.TextBox();
            this.lb_descri = new System.Windows.Forms.Label();
            this.tb_descri = new System.Windows.Forms.TextBox();
            this.lb_importe = new System.Windows.Forms.Label();
            this.tb_importe = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btt_modif_tas = new System.Windows.Forms.Button();
            this.btt_cancel_tas = new System.Windows.Forms.Button();
            this.btt_buscar_tas = new System.Windows.Forms.Button();
            this.btt_imp_ts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tasas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_tasas
            // 
            this.dgv_tasas.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv_tasas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tasas.Location = new System.Drawing.Point(51, 178);
            this.dgv_tasas.Name = "dgv_tasas";
            this.dgv_tasas.Size = new System.Drawing.Size(595, 332);
            this.dgv_tasas.TabIndex = 0;
            this.dgv_tasas.SelectionChanged += new System.EventHandler(this.dgv_tasas_SelectionChanged);
            // 
            // lb_tit_tas
            // 
            this.lb_tit_tas.AutoSize = true;
            this.lb_tit_tas.BackColor = System.Drawing.Color.LightBlue;
            this.lb_tit_tas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_tit_tas.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tit_tas.ForeColor = System.Drawing.Color.Black;
            this.lb_tit_tas.Location = new System.Drawing.Point(297, 18);
            this.lb_tit_tas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tit_tas.Name = "lb_tit_tas";
            this.lb_tit_tas.Size = new System.Drawing.Size(102, 35);
            this.lb_tit_tas.TabIndex = 2;
            this.lb_tit_tas.Text = "Tasas";
            // 
            // btt_consultar_tas
            // 
            this.btt_consultar_tas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_consultar_tas.Location = new System.Drawing.Point(547, 515);
            this.btt_consultar_tas.Margin = new System.Windows.Forms.Padding(4);
            this.btt_consultar_tas.Name = "btt_consultar_tas";
            this.btt_consultar_tas.Size = new System.Drawing.Size(99, 34);
            this.btt_consultar_tas.TabIndex = 8;
            this.btt_consultar_tas.Text = "Consultar";
            this.btt_consultar_tas.UseVisualStyleBackColor = true;
            this.btt_consultar_tas.Click += new System.EventHandler(this.btt_consultar_tas_Click);
            // 
            // btt_new_tas
            // 
            this.btt_new_tas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_new_tas.Location = new System.Drawing.Point(662, 68);
            this.btt_new_tas.Margin = new System.Windows.Forms.Padding(4);
            this.btt_new_tas.Name = "btt_new_tas";
            this.btt_new_tas.Size = new System.Drawing.Size(99, 34);
            this.btt_new_tas.TabIndex = 9;
            this.btt_new_tas.Text = "Nuevo";
            this.btt_new_tas.UseVisualStyleBackColor = true;
            this.btt_new_tas.Click += new System.EventHandler(this.btt_new_tas_Click);
            // 
            // btt_save_tas
            // 
            this.btt_save_tas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_save_tas.Location = new System.Drawing.Point(662, 126);
            this.btt_save_tas.Margin = new System.Windows.Forms.Padding(4);
            this.btt_save_tas.Name = "btt_save_tas";
            this.btt_save_tas.Size = new System.Drawing.Size(99, 34);
            this.btt_save_tas.TabIndex = 10;
            this.btt_save_tas.Text = "Guardar";
            this.btt_save_tas.UseVisualStyleBackColor = true;
            this.btt_save_tas.Click += new System.EventHandler(this.btt_save_tas_Click);
            // 
            // btt_del_tas
            // 
            this.btt_del_tas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_del_tas.Location = new System.Drawing.Point(662, 393);
            this.btt_del_tas.Margin = new System.Windows.Forms.Padding(4);
            this.btt_del_tas.Name = "btt_del_tas";
            this.btt_del_tas.Size = new System.Drawing.Size(99, 34);
            this.btt_del_tas.TabIndex = 11;
            this.btt_del_tas.Text = "Borrar";
            this.btt_del_tas.UseVisualStyleBackColor = true;
            this.btt_del_tas.Click += new System.EventHandler(this.btt_del_tas_Click);
            // 
            // tb_ejercicio
            // 
            this.tb_ejercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ejercicio.Location = new System.Drawing.Point(183, 75);
            this.tb_ejercicio.Margin = new System.Windows.Forms.Padding(4);
            this.tb_ejercicio.Name = "tb_ejercicio";
            this.tb_ejercicio.Size = new System.Drawing.Size(70, 24);
            this.tb_ejercicio.TabIndex = 1;
            this.tb_ejercicio.Validating += new System.ComponentModel.CancelEventHandler(this.tb_ejercicio_Validating);
            // 
            // lb_ejercicio
            // 
            this.lb_ejercicio.AutoSize = true;
            this.lb_ejercicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ejercicio.Location = new System.Drawing.Point(101, 78);
            this.lb_ejercicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ejercicio.Name = "lb_ejercicio";
            this.lb_ejercicio.Size = new System.Drawing.Size(65, 18);
            this.lb_ejercicio.TabIndex = 12;
            this.lb_ejercicio.Text = "Ejercicio";
            // 
            // lb_codigo
            // 
            this.lb_codigo.AutoSize = true;
            this.lb_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_codigo.Location = new System.Drawing.Point(305, 78);
            this.lb_codigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_codigo.Name = "lb_codigo";
            this.lb_codigo.Size = new System.Drawing.Size(56, 18);
            this.lb_codigo.TabIndex = 14;
            this.lb_codigo.Text = "Código";
            // 
            // tb_codigo
            // 
            this.tb_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_codigo.Location = new System.Drawing.Point(369, 75);
            this.tb_codigo.Margin = new System.Windows.Forms.Padding(4);
            this.tb_codigo.MaxLength = 5;
            this.tb_codigo.Name = "tb_codigo";
            this.tb_codigo.Size = new System.Drawing.Size(44, 24);
            this.tb_codigo.TabIndex = 2;
            this.tb_codigo.Validating += new System.ComponentModel.CancelEventHandler(this.tb_codigo_Validating);
            // 
            // lb_descri
            // 
            this.lb_descri.AutoSize = true;
            this.lb_descri.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_descri.Location = new System.Drawing.Point(28, 61);
            this.lb_descri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_descri.Name = "lb_descri";
            this.lb_descri.Size = new System.Drawing.Size(87, 18);
            this.lb_descri.TabIndex = 16;
            this.lb_descri.Text = "Descripcion";
            // 
            // tb_descri
            // 
            this.tb_descri.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_descri.Location = new System.Drawing.Point(183, 118);
            this.tb_descri.Margin = new System.Windows.Forms.Padding(4);
            this.tb_descri.Name = "tb_descri";
            this.tb_descri.Size = new System.Drawing.Size(434, 24);
            this.tb_descri.TabIndex = 4;
            this.tb_descri.Validating += new System.ComponentModel.CancelEventHandler(this.tb_descri_Validating);
            // 
            // lb_importe
            // 
            this.lb_importe.AutoSize = true;
            this.lb_importe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_importe.Location = new System.Drawing.Point(472, 78);
            this.lb_importe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_importe.Name = "lb_importe";
            this.lb_importe.Size = new System.Drawing.Size(58, 18);
            this.lb_importe.TabIndex = 18;
            this.lb_importe.Text = "Importe";
            // 
            // tb_importe
            // 
            this.tb_importe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_importe.Location = new System.Drawing.Point(535, 75);
            this.tb_importe.Margin = new System.Windows.Forms.Padding(4);
            this.tb_importe.Name = "tb_importe";
            this.tb_importe.Size = new System.Drawing.Size(81, 24);
            this.tb_importe.TabIndex = 3;
            this.tb_importe.Validating += new System.ComponentModel.CancelEventHandler(this.tb_importe_Validating);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_descri);
            this.panel1.Location = new System.Drawing.Point(51, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 112);
            this.panel1.TabIndex = 20;
            // 
            // btt_modif_tas
            // 
            this.btt_modif_tas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_modif_tas.Location = new System.Drawing.Point(662, 178);
            this.btt_modif_tas.Margin = new System.Windows.Forms.Padding(4);
            this.btt_modif_tas.Name = "btt_modif_tas";
            this.btt_modif_tas.Size = new System.Drawing.Size(99, 34);
            this.btt_modif_tas.TabIndex = 21;
            this.btt_modif_tas.Text = "Modificar";
            this.btt_modif_tas.UseVisualStyleBackColor = true;
            this.btt_modif_tas.Click += new System.EventHandler(this.btt_modif_tas_Click);
            // 
            // btt_cancel_tas
            // 
            this.btt_cancel_tas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_cancel_tas.Location = new System.Drawing.Point(662, 450);
            this.btt_cancel_tas.Margin = new System.Windows.Forms.Padding(4);
            this.btt_cancel_tas.Name = "btt_cancel_tas";
            this.btt_cancel_tas.Size = new System.Drawing.Size(99, 34);
            this.btt_cancel_tas.TabIndex = 22;
            this.btt_cancel_tas.Text = "Cancelar";
            this.btt_cancel_tas.UseVisualStyleBackColor = true;
            this.btt_cancel_tas.Click += new System.EventHandler(this.btt_cancel_tas_Click);
            // 
            // btt_buscar_tas
            // 
            this.btt_buscar_tas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_buscar_tas.Location = new System.Drawing.Point(431, 515);
            this.btt_buscar_tas.Margin = new System.Windows.Forms.Padding(4);
            this.btt_buscar_tas.Name = "btt_buscar_tas";
            this.btt_buscar_tas.Size = new System.Drawing.Size(99, 34);
            this.btt_buscar_tas.TabIndex = 23;
            this.btt_buscar_tas.Text = "Buscar";
            this.btt_buscar_tas.UseVisualStyleBackColor = true;
            this.btt_buscar_tas.Click += new System.EventHandler(this.btt_buscar_tas_Click);
            // 
            // btt_imp_ts
            // 
            this.btt_imp_ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_imp_ts.Location = new System.Drawing.Point(662, 276);
            this.btt_imp_ts.Margin = new System.Windows.Forms.Padding(4);
            this.btt_imp_ts.Name = "btt_imp_ts";
            this.btt_imp_ts.Size = new System.Drawing.Size(99, 34);
            this.btt_imp_ts.TabIndex = 24;
            this.btt_imp_ts.Text = "Imprimir";
            this.btt_imp_ts.UseVisualStyleBackColor = true;
            this.btt_imp_ts.Click += new System.EventHandler(this.btt_imp_ts_Click);
            // 
            // MTasas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.btt_imp_ts);
            this.Controls.Add(this.btt_buscar_tas);
            this.Controls.Add(this.btt_cancel_tas);
            this.Controls.Add(this.tb_importe);
            this.Controls.Add(this.btt_modif_tas);
            this.Controls.Add(this.lb_importe);
            this.Controls.Add(this.tb_descri);
            this.Controls.Add(this.tb_codigo);
            this.Controls.Add(this.lb_codigo);
            this.Controls.Add(this.tb_ejercicio);
            this.Controls.Add(this.lb_ejercicio);
            this.Controls.Add(this.btt_del_tas);
            this.Controls.Add(this.btt_save_tas);
            this.Controls.Add(this.btt_new_tas);
            this.Controls.Add(this.btt_consultar_tas);
            this.Controls.Add(this.lb_tit_tas);
            this.Controls.Add(this.dgv_tasas);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MTasas";
            this.Text = "Mantenimiento de Tasas";
            this.Load += new System.EventHandler(this.MTasas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tasas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_tasas;
        private System.Windows.Forms.Label lb_tit_tas;
        private System.Windows.Forms.Button btt_consultar_tas;
        private System.Windows.Forms.Button btt_new_tas;
        private System.Windows.Forms.Button btt_save_tas;
        private System.Windows.Forms.Button btt_del_tas;
        private System.Windows.Forms.TextBox tb_ejercicio;
        private System.Windows.Forms.Label lb_ejercicio;
        private System.Windows.Forms.Label lb_codigo;
        private System.Windows.Forms.TextBox tb_codigo;
        private System.Windows.Forms.Label lb_descri;
        private System.Windows.Forms.TextBox tb_descri;
        private System.Windows.Forms.Label lb_importe;
        private System.Windows.Forms.TextBox tb_importe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btt_modif_tas;
        private System.Windows.Forms.Button btt_cancel_tas;
        private System.Windows.Forms.Button btt_buscar_tas;
        private System.Windows.Forms.Button btt_imp_ts;
    }
}