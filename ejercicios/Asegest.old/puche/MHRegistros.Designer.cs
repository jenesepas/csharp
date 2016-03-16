namespace Asegest
{
    partial class MHRegistros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MHRegistros));
            this.dgv_hregs = new System.Windows.Forms.DataGridView();
            this.lb_tit_hreg = new System.Windows.Forms.Label();
            this.btt_consultar_hreg = new System.Windows.Forms.Button();
            this.btt_cancel_hreg = new System.Windows.Forms.Button();
            this.rb_a_hrg = new System.Windows.Forms.RadioButton();
            this.gb_del_hrg = new System.Windows.Forms.GroupBox();
            this.rb_m_hrg = new System.Windows.Forms.RadioButton();
            this.rb_y_hrg = new System.Windows.Forms.RadioButton();
            this.pan_bus = new System.Windows.Forms.Panel();
            this.lb_h_usu = new System.Windows.Forms.Label();
            this.tb_h_usu = new System.Windows.Forms.TextBox();
            this.lb_h_n_rg = new System.Windows.Forms.Label();
            this.tb_h_n_rg = new System.Windows.Forms.TextBox();
            this.btt_buscar_hreg = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hregs)).BeginInit();
            this.gb_del_hrg.SuspendLayout();
            this.pan_bus.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_hregs
            // 
            this.dgv_hregs.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv_hregs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hregs.Location = new System.Drawing.Point(54, 68);
            this.dgv_hregs.Name = "dgv_hregs";
            this.dgv_hregs.Size = new System.Drawing.Size(595, 404);
            this.dgv_hregs.TabIndex = 0;
            // 
            // lb_tit_hreg
            // 
            this.lb_tit_hreg.AutoSize = true;
            this.lb_tit_hreg.BackColor = System.Drawing.Color.LightBlue;
            this.lb_tit_hreg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_tit_hreg.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tit_hreg.ForeColor = System.Drawing.Color.Black;
            this.lb_tit_hreg.Location = new System.Drawing.Point(188, 18);
            this.lb_tit_hreg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tit_hreg.Name = "lb_tit_hreg";
            this.lb_tit_hreg.Size = new System.Drawing.Size(326, 35);
            this.lb_tit_hreg.TabIndex = 2;
            this.lb_tit_hreg.Text = "Histórico de Registros";
            // 
            // btt_consultar_hreg
            // 
            this.btt_consultar_hreg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_consultar_hreg.Location = new System.Drawing.Point(550, 477);
            this.btt_consultar_hreg.Margin = new System.Windows.Forms.Padding(4);
            this.btt_consultar_hreg.Name = "btt_consultar_hreg";
            this.btt_consultar_hreg.Size = new System.Drawing.Size(99, 34);
            this.btt_consultar_hreg.TabIndex = 8;
            this.btt_consultar_hreg.Text = "Consultar";
            this.btt_consultar_hreg.UseVisualStyleBackColor = true;
            this.btt_consultar_hreg.Click += new System.EventHandler(this.btt_consultar_hreg_Click_1);
            // 
            // btt_cancel_hreg
            // 
            this.btt_cancel_hreg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_cancel_hreg.Location = new System.Drawing.Point(662, 429);
            this.btt_cancel_hreg.Margin = new System.Windows.Forms.Padding(4);
            this.btt_cancel_hreg.Name = "btt_cancel_hreg";
            this.btt_cancel_hreg.Size = new System.Drawing.Size(99, 34);
            this.btt_cancel_hreg.TabIndex = 22;
            this.btt_cancel_hreg.Text = "Cancelar";
            this.btt_cancel_hreg.UseVisualStyleBackColor = true;
            this.btt_cancel_hreg.Click += new System.EventHandler(this.btt_cancel_hreg_Click);
            // 
            // rb_a_hrg
            // 
            this.rb_a_hrg.AutoSize = true;
            this.rb_a_hrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_a_hrg.Location = new System.Drawing.Point(134, 20);
            this.rb_a_hrg.Name = "rb_a_hrg";
            this.rb_a_hrg.Size = new System.Drawing.Size(80, 19);
            this.rb_a_hrg.TabIndex = 26;
            this.rb_a_hrg.Text = "Albacete";
            this.rb_a_hrg.UseVisualStyleBackColor = true;
            // 
            // gb_del_hrg
            // 
            this.gb_del_hrg.BackColor = System.Drawing.Color.LightBlue;
            this.gb_del_hrg.Controls.Add(this.rb_a_hrg);
            this.gb_del_hrg.Controls.Add(this.rb_m_hrg);
            this.gb_del_hrg.Controls.Add(this.rb_y_hrg);
            this.gb_del_hrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_del_hrg.Location = new System.Drawing.Point(3, 5);
            this.gb_del_hrg.Name = "gb_del_hrg";
            this.gb_del_hrg.Size = new System.Drawing.Size(219, 47);
            this.gb_del_hrg.TabIndex = 36;
            this.gb_del_hrg.TabStop = false;
            this.gb_del_hrg.Text = "Delegacion";
            // 
            // rb_m_hrg
            // 
            this.rb_m_hrg.AutoSize = true;
            this.rb_m_hrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_m_hrg.Location = new System.Drawing.Point(65, 20);
            this.rb_m_hrg.Name = "rb_m_hrg";
            this.rb_m_hrg.Size = new System.Drawing.Size(69, 19);
            this.rb_m_hrg.TabIndex = 25;
            this.rb_m_hrg.Text = "Murcia";
            this.rb_m_hrg.UseVisualStyleBackColor = true;
            // 
            // rb_y_hrg
            // 
            this.rb_y_hrg.AutoSize = true;
            this.rb_y_hrg.Checked = true;
            this.rb_y_hrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_y_hrg.Location = new System.Drawing.Point(6, 20);
            this.rb_y_hrg.Name = "rb_y_hrg";
            this.rb_y_hrg.Size = new System.Drawing.Size(60, 19);
            this.rb_y_hrg.TabIndex = 24;
            this.rb_y_hrg.TabStop = true;
            this.rb_y_hrg.Text = "Yecla";
            this.rb_y_hrg.UseVisualStyleBackColor = true;
            // 
            // pan_bus
            // 
            this.pan_bus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_bus.Controls.Add(this.lb_h_usu);
            this.pan_bus.Controls.Add(this.tb_h_usu);
            this.pan_bus.Controls.Add(this.lb_h_n_rg);
            this.pan_bus.Controls.Add(this.tb_h_n_rg);
            this.pan_bus.Controls.Add(this.gb_del_hrg);
            this.pan_bus.Location = new System.Drawing.Point(54, 478);
            this.pan_bus.Name = "pan_bus";
            this.pan_bus.Size = new System.Drawing.Size(489, 70);
            this.pan_bus.TabIndex = 37;
            // 
            // lb_h_usu
            // 
            this.lb_h_usu.AutoSize = true;
            this.lb_h_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_h_usu.Location = new System.Drawing.Point(237, 36);
            this.lb_h_usu.Name = "lb_h_usu";
            this.lb_h_usu.Size = new System.Drawing.Size(55, 16);
            this.lb_h_usu.TabIndex = 39;
            this.lb_h_usu.Text = "Usuario";
            // 
            // tb_h_usu
            // 
            this.tb_h_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_h_usu.Location = new System.Drawing.Point(298, 36);
            this.tb_h_usu.Name = "tb_h_usu";
            this.tb_h_usu.Size = new System.Drawing.Size(139, 22);
            this.tb_h_usu.TabIndex = 40;
            // 
            // lb_h_n_rg
            // 
            this.lb_h_n_rg.AutoSize = true;
            this.lb_h_n_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_h_n_rg.Location = new System.Drawing.Point(237, 11);
            this.lb_h_n_rg.Name = "lb_h_n_rg";
            this.lb_h_n_rg.Size = new System.Drawing.Size(55, 16);
            this.lb_h_n_rg.TabIndex = 37;
            this.lb_h_n_rg.Text = "Nº Reg.";
            // 
            // tb_h_n_rg
            // 
            this.tb_h_n_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_h_n_rg.Location = new System.Drawing.Point(298, 11);
            this.tb_h_n_rg.Name = "tb_h_n_rg";
            this.tb_h_n_rg.Size = new System.Drawing.Size(139, 22);
            this.tb_h_n_rg.TabIndex = 38;
            // 
            // btt_buscar_hreg
            // 
            this.btt_buscar_hreg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_buscar_hreg.Location = new System.Drawing.Point(550, 514);
            this.btt_buscar_hreg.Margin = new System.Windows.Forms.Padding(4);
            this.btt_buscar_hreg.Name = "btt_buscar_hreg";
            this.btt_buscar_hreg.Size = new System.Drawing.Size(99, 34);
            this.btt_buscar_hreg.TabIndex = 38;
            this.btt_buscar_hreg.Text = "Buscar";
            this.btt_buscar_hreg.UseVisualStyleBackColor = true;
            this.btt_buscar_hreg.Click += new System.EventHandler(this.btt_buscar_hreg_Click_1);
            // 
            // MHRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btt_buscar_hreg);
            this.Controls.Add(this.pan_bus);
            this.Controls.Add(this.btt_cancel_hreg);
            this.Controls.Add(this.btt_consultar_hreg);
            this.Controls.Add(this.lb_tit_hreg);
            this.Controls.Add(this.dgv_hregs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MHRegistros";
            this.Text = "Histórico de Registros";
            this.Load += new System.EventHandler(this.MHRegistros_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hregs)).EndInit();
            this.gb_del_hrg.ResumeLayout(false);
            this.gb_del_hrg.PerformLayout();
            this.pan_bus.ResumeLayout(false);
            this.pan_bus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_hregs;
        private System.Windows.Forms.Label lb_tit_hreg;
        private System.Windows.Forms.Button btt_consultar_hreg;
        private System.Windows.Forms.Button btt_cancel_hreg;
        private System.Windows.Forms.RadioButton rb_a_hrg;
        private System.Windows.Forms.GroupBox gb_del_hrg;
        private System.Windows.Forms.RadioButton rb_m_hrg;
        private System.Windows.Forms.RadioButton rb_y_hrg;
        private System.Windows.Forms.Panel pan_bus;
        private System.Windows.Forms.Label lb_h_usu;
        private System.Windows.Forms.TextBox tb_h_usu;
        private System.Windows.Forms.Label lb_h_n_rg;
        private System.Windows.Forms.TextBox tb_h_n_rg;
        private System.Windows.Forms.Button btt_buscar_hreg;
    }
}