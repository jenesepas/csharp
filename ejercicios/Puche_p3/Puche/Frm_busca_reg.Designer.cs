namespace Puche
{
    partial class Frm_busca_reg
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
            this.btt_b_buscar = new System.Windows.Forms.Button();
            this.gb_b_t_cte_rg = new System.Windows.Forms.GroupBox();
            this.rb_titular_rg = new System.Windows.Forms.RadioButton();
            this.rb_cte_rg = new System.Windows.Forms.RadioButton();
            this.tb_b_n_rg = new System.Windows.Forms.TextBox();
            this.lb_b_n_rg = new System.Windows.Forms.Label();
            this.tb_b_nombre_rg = new System.Windows.Forms.TextBox();
            this.p_b_rg = new System.Windows.Forms.Panel();
            this.bt_b_limpiar = new System.Windows.Forms.Button();
            this.gb_del_rg = new System.Windows.Forms.GroupBox();
            this.rb_a_rg = new System.Windows.Forms.RadioButton();
            this.rb_m_rg = new System.Windows.Forms.RadioButton();
            this.rb_y_rg = new System.Windows.Forms.RadioButton();
            this.tb_exp_rg = new System.Windows.Forms.TextBox();
            this.lb_exp_rg = new System.Windows.Forms.Label();
            this.lb_n_cte_rg = new System.Windows.Forms.Label();
            this.tb_fra_rg = new System.Windows.Forms.TextBox();
            this.lb_fra_rg = new System.Windows.Forms.Label();
            this.btt_b_cancelar_rg = new System.Windows.Forms.Button();
            this.btt_b_aceptar_rg = new System.Windows.Forms.Button();
            this.dgv_regs = new System.Windows.Forms.DataGridView();
            this.lb_matri_rg = new System.Windows.Forms.Label();
            this.tb_matri_rg = new System.Windows.Forms.TextBox();
            this.lb_vehi_rg = new System.Windows.Forms.Label();
            this.tb_vehi_rg = new System.Windows.Forms.TextBox();
            this.gb_b_t_cte_rg.SuspendLayout();
            this.p_b_rg.SuspendLayout();
            this.gb_del_rg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_regs)).BeginInit();
            this.SuspendLayout();
            // 
            // btt_b_buscar
            // 
            this.btt_b_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_b_buscar.Location = new System.Drawing.Point(475, 36);
            this.btt_b_buscar.Name = "btt_b_buscar";
            this.btt_b_buscar.Size = new System.Drawing.Size(89, 34);
            this.btt_b_buscar.TabIndex = 50;
            this.btt_b_buscar.Text = "Buscar";
            this.btt_b_buscar.UseVisualStyleBackColor = true;
            this.btt_b_buscar.Click += new System.EventHandler(this.btt_b_buscar_Click);
            // 
            // gb_b_t_cte_rg
            // 
            this.gb_b_t_cte_rg.BackColor = System.Drawing.Color.LightBlue;
            this.gb_b_t_cte_rg.Controls.Add(this.rb_titular_rg);
            this.gb_b_t_cte_rg.Controls.Add(this.rb_cte_rg);
            this.gb_b_t_cte_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_b_t_cte_rg.Location = new System.Drawing.Point(117, 31);
            this.gb_b_t_cte_rg.Name = "gb_b_t_cte_rg";
            this.gb_b_t_cte_rg.Size = new System.Drawing.Size(185, 47);
            this.gb_b_t_cte_rg.TabIndex = 34;
            this.gb_b_t_cte_rg.TabStop = false;
            this.gb_b_t_cte_rg.Text = "Tipo";
            // 
            // rb_titular_rg
            // 
            this.rb_titular_rg.AutoSize = true;
            this.rb_titular_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_titular_rg.Location = new System.Drawing.Point(107, 20);
            this.rb_titular_rg.Name = "rb_titular_rg";
            this.rb_titular_rg.Size = new System.Drawing.Size(70, 20);
            this.rb_titular_rg.TabIndex = 25;
            this.rb_titular_rg.Text = "Titular";
            this.rb_titular_rg.UseVisualStyleBackColor = true;
            // 
            // rb_cte_rg
            // 
            this.rb_cte_rg.AutoSize = true;
            this.rb_cte_rg.Checked = true;
            this.rb_cte_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_cte_rg.Location = new System.Drawing.Point(27, 20);
            this.rb_cte_rg.Name = "rb_cte_rg";
            this.rb_cte_rg.Size = new System.Drawing.Size(74, 20);
            this.rb_cte_rg.TabIndex = 24;
            this.rb_cte_rg.TabStop = true;
            this.rb_cte_rg.Text = "Cliente";
            this.rb_cte_rg.UseVisualStyleBackColor = true;
            // 
            // tb_b_n_rg
            // 
            this.tb_b_n_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_b_n_rg.Location = new System.Drawing.Point(296, 34);
            this.tb_b_n_rg.Name = "tb_b_n_rg";
            this.tb_b_n_rg.Size = new System.Drawing.Size(170, 22);
            this.tb_b_n_rg.TabIndex = 33;
            // 
            // lb_b_n_rg
            // 
            this.lb_b_n_rg.AutoSize = true;
            this.lb_b_n_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_b_n_rg.Location = new System.Drawing.Point(235, 34);
            this.lb_b_n_rg.Name = "lb_b_n_rg";
            this.lb_b_n_rg.Size = new System.Drawing.Size(55, 16);
            this.lb_b_n_rg.TabIndex = 32;
            this.lb_b_n_rg.Text = "Nº Reg.";
            // 
            // tb_b_nombre_rg
            // 
            this.tb_b_nombre_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_b_nombre_rg.Location = new System.Drawing.Point(296, 8);
            this.tb_b_nombre_rg.Name = "tb_b_nombre_rg";
            this.tb_b_nombre_rg.Size = new System.Drawing.Size(267, 22);
            this.tb_b_nombre_rg.TabIndex = 31;
            // 
            // p_b_rg
            // 
            this.p_b_rg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_b_rg.Controls.Add(this.tb_vehi_rg);
            this.p_b_rg.Controls.Add(this.lb_vehi_rg);
            this.p_b_rg.Controls.Add(this.tb_matri_rg);
            this.p_b_rg.Controls.Add(this.lb_matri_rg);
            this.p_b_rg.Controls.Add(this.bt_b_limpiar);
            this.p_b_rg.Controls.Add(this.gb_del_rg);
            this.p_b_rg.Controls.Add(this.tb_exp_rg);
            this.p_b_rg.Controls.Add(this.lb_exp_rg);
            this.p_b_rg.Controls.Add(this.lb_n_cte_rg);
            this.p_b_rg.Controls.Add(this.tb_fra_rg);
            this.p_b_rg.Controls.Add(this.lb_fra_rg);
            this.p_b_rg.Controls.Add(this.lb_b_n_rg);
            this.p_b_rg.Controls.Add(this.tb_b_nombre_rg);
            this.p_b_rg.Controls.Add(this.btt_b_buscar);
            this.p_b_rg.Controls.Add(this.tb_b_n_rg);
            this.p_b_rg.Location = new System.Drawing.Point(94, 22);
            this.p_b_rg.Name = "p_b_rg";
            this.p_b_rg.Size = new System.Drawing.Size(579, 171);
            this.p_b_rg.TabIndex = 36;
            // 
            // bt_b_limpiar
            // 
            this.bt_b_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_b_limpiar.Location = new System.Drawing.Point(475, 76);
            this.bt_b_limpiar.Name = "bt_b_limpiar";
            this.bt_b_limpiar.Size = new System.Drawing.Size(89, 34);
            this.bt_b_limpiar.TabIndex = 52;
            this.bt_b_limpiar.Text = "Limpiar";
            this.bt_b_limpiar.UseVisualStyleBackColor = true;
            this.bt_b_limpiar.Click += new System.EventHandler(this.bt_b_limpiar_Click);
            // 
            // gb_del_rg
            // 
            this.gb_del_rg.BackColor = System.Drawing.Color.LightBlue;
            this.gb_del_rg.Controls.Add(this.rb_a_rg);
            this.gb_del_rg.Controls.Add(this.rb_m_rg);
            this.gb_del_rg.Controls.Add(this.rb_y_rg);
            this.gb_del_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_del_rg.Location = new System.Drawing.Point(4, 62);
            this.gb_del_rg.Name = "gb_del_rg";
            this.gb_del_rg.Size = new System.Drawing.Size(219, 47);
            this.gb_del_rg.TabIndex = 35;
            this.gb_del_rg.TabStop = false;
            this.gb_del_rg.Text = "Delegacion";
            // 
            // rb_a_rg
            // 
            this.rb_a_rg.AutoSize = true;
            this.rb_a_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_a_rg.Location = new System.Drawing.Point(134, 20);
            this.rb_a_rg.Name = "rb_a_rg";
            this.rb_a_rg.Size = new System.Drawing.Size(80, 19);
            this.rb_a_rg.TabIndex = 26;
            this.rb_a_rg.Text = "Albacete";
            this.rb_a_rg.UseVisualStyleBackColor = true;
            // 
            // rb_m_rg
            // 
            this.rb_m_rg.AutoSize = true;
            this.rb_m_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_m_rg.Location = new System.Drawing.Point(65, 20);
            this.rb_m_rg.Name = "rb_m_rg";
            this.rb_m_rg.Size = new System.Drawing.Size(69, 19);
            this.rb_m_rg.TabIndex = 25;
            this.rb_m_rg.Text = "Murcia";
            this.rb_m_rg.UseVisualStyleBackColor = true;
            // 
            // rb_y_rg
            // 
            this.rb_y_rg.AutoSize = true;
            this.rb_y_rg.Checked = true;
            this.rb_y_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_y_rg.Location = new System.Drawing.Point(6, 20);
            this.rb_y_rg.Name = "rb_y_rg";
            this.rb_y_rg.Size = new System.Drawing.Size(60, 19);
            this.rb_y_rg.TabIndex = 24;
            this.rb_y_rg.TabStop = true;
            this.rb_y_rg.Text = "Yecla";
            this.rb_y_rg.UseVisualStyleBackColor = true;
            // 
            // tb_exp_rg
            // 
            this.tb_exp_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_exp_rg.Location = new System.Drawing.Point(296, 143);
            this.tb_exp_rg.Name = "tb_exp_rg";
            this.tb_exp_rg.Size = new System.Drawing.Size(170, 22);
            this.tb_exp_rg.TabIndex = 47;
            // 
            // lb_exp_rg
            // 
            this.lb_exp_rg.AutoSize = true;
            this.lb_exp_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_exp_rg.Location = new System.Drawing.Point(238, 143);
            this.lb_exp_rg.Name = "lb_exp_rg";
            this.lb_exp_rg.Size = new System.Drawing.Size(52, 16);
            this.lb_exp_rg.TabIndex = 39;
            this.lb_exp_rg.Text = "Nº Exp.";
            // 
            // lb_n_cte_rg
            // 
            this.lb_n_cte_rg.AutoSize = true;
            this.lb_n_cte_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_n_cte_rg.Location = new System.Drawing.Point(233, 8);
            this.lb_n_cte_rg.Name = "lb_n_cte_rg";
            this.lb_n_cte_rg.Size = new System.Drawing.Size(57, 16);
            this.lb_n_cte_rg.TabIndex = 38;
            this.lb_n_cte_rg.Text = "Nombre";
            // 
            // tb_fra_rg
            // 
            this.tb_fra_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_fra_rg.Location = new System.Drawing.Point(296, 62);
            this.tb_fra_rg.Name = "tb_fra_rg";
            this.tb_fra_rg.Size = new System.Drawing.Size(170, 22);
            this.tb_fra_rg.TabIndex = 37;
            // 
            // lb_fra_rg
            // 
            this.lb_fra_rg.AutoSize = true;
            this.lb_fra_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fra_rg.Location = new System.Drawing.Point(241, 62);
            this.lb_fra_rg.Name = "lb_fra_rg";
            this.lb_fra_rg.Size = new System.Drawing.Size(49, 16);
            this.lb_fra_rg.TabIndex = 36;
            this.lb_fra_rg.Text = "Nº Fra.";
            // 
            // btt_b_cancelar_rg
            // 
            this.btt_b_cancelar_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_b_cancelar_rg.Location = new System.Drawing.Point(673, 506);
            this.btt_b_cancelar_rg.Name = "btt_b_cancelar_rg";
            this.btt_b_cancelar_rg.Size = new System.Drawing.Size(99, 34);
            this.btt_b_cancelar_rg.TabIndex = 39;
            this.btt_b_cancelar_rg.Text = "Cancelar";
            this.btt_b_cancelar_rg.UseVisualStyleBackColor = true;
            this.btt_b_cancelar_rg.Click += new System.EventHandler(this.btt_b_cancelar_rg_Click);
            // 
            // btt_b_aceptar_rg
            // 
            this.btt_b_aceptar_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_b_aceptar_rg.Location = new System.Drawing.Point(19, 506);
            this.btt_b_aceptar_rg.Name = "btt_b_aceptar_rg";
            this.btt_b_aceptar_rg.Size = new System.Drawing.Size(99, 34);
            this.btt_b_aceptar_rg.TabIndex = 38;
            this.btt_b_aceptar_rg.Text = "Aceptar";
            this.btt_b_aceptar_rg.UseVisualStyleBackColor = true;
            this.btt_b_aceptar_rg.Click += new System.EventHandler(this.btt_b_aceptar_rg_Click);
            // 
            // dgv_regs
            // 
            this.dgv_regs.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv_regs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_regs.Location = new System.Drawing.Point(19, 206);
            this.dgv_regs.Name = "dgv_regs";
            this.dgv_regs.Size = new System.Drawing.Size(753, 294);
            this.dgv_regs.TabIndex = 37;
            // 
            // lb_matri_rg
            // 
            this.lb_matri_rg.AutoSize = true;
            this.lb_matri_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_matri_rg.Location = new System.Drawing.Point(228, 88);
            this.lb_matri_rg.Name = "lb_matri_rg";
            this.lb_matri_rg.Size = new System.Drawing.Size(62, 16);
            this.lb_matri_rg.TabIndex = 42;
            this.lb_matri_rg.Text = "Matrícula";
            // 
            // tb_matri_rg
            // 
            this.tb_matri_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_matri_rg.Location = new System.Drawing.Point(296, 88);
            this.tb_matri_rg.Name = "tb_matri_rg";
            this.tb_matri_rg.Size = new System.Drawing.Size(170, 22);
            this.tb_matri_rg.TabIndex = 43;
            // 
            // lb_vehi_rg
            // 
            this.lb_vehi_rg.AutoSize = true;
            this.lb_vehi_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_vehi_rg.Location = new System.Drawing.Point(230, 117);
            this.lb_vehi_rg.Name = "lb_vehi_rg";
            this.lb_vehi_rg.Size = new System.Drawing.Size(60, 16);
            this.lb_vehi_rg.TabIndex = 44;
            this.lb_vehi_rg.Text = "Vehículo";
            // 
            // tb_vehi_rg
            // 
            this.tb_vehi_rg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_vehi_rg.Location = new System.Drawing.Point(296, 117);
            this.tb_vehi_rg.Name = "tb_vehi_rg";
            this.tb_vehi_rg.Size = new System.Drawing.Size(267, 22);
            this.tb_vehi_rg.TabIndex = 45;
            // 
            // Frm_busca_reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.btt_b_cancelar_rg);
            this.Controls.Add(this.btt_b_aceptar_rg);
            this.Controls.Add(this.dgv_regs);
            this.Controls.Add(this.gb_b_t_cte_rg);
            this.Controls.Add(this.p_b_rg);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Frm_busca_reg";
            this.Text = "Buscador de Registros";
            this.Load += new System.EventHandler(this.Frm_busca_reg_Load);
            this.gb_b_t_cte_rg.ResumeLayout(false);
            this.gb_b_t_cte_rg.PerformLayout();
            this.p_b_rg.ResumeLayout(false);
            this.p_b_rg.PerformLayout();
            this.gb_del_rg.ResumeLayout(false);
            this.gb_del_rg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_regs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btt_b_buscar;
        private System.Windows.Forms.GroupBox gb_b_t_cte_rg;
        private System.Windows.Forms.RadioButton rb_titular_rg;
        private System.Windows.Forms.RadioButton rb_cte_rg;
        private System.Windows.Forms.TextBox tb_b_n_rg;
        private System.Windows.Forms.Label lb_b_n_rg;
        private System.Windows.Forms.TextBox tb_b_nombre_rg;
        private System.Windows.Forms.Panel p_b_rg;
        private System.Windows.Forms.Button btt_b_cancelar_rg;
        private System.Windows.Forms.Button btt_b_aceptar_rg;
        private System.Windows.Forms.DataGridView dgv_regs;
        private System.Windows.Forms.TextBox tb_exp_rg;
        private System.Windows.Forms.Label lb_exp_rg;
        private System.Windows.Forms.Label lb_n_cte_rg;
        private System.Windows.Forms.TextBox tb_fra_rg;
        private System.Windows.Forms.Label lb_fra_rg;
        private System.Windows.Forms.GroupBox gb_del_rg;
        private System.Windows.Forms.RadioButton rb_a_rg;
        private System.Windows.Forms.RadioButton rb_m_rg;
        private System.Windows.Forms.RadioButton rb_y_rg;
        private System.Windows.Forms.Button bt_b_limpiar;
        private System.Windows.Forms.TextBox tb_vehi_rg;
        private System.Windows.Forms.Label lb_vehi_rg;
        private System.Windows.Forms.TextBox tb_matri_rg;
        private System.Windows.Forms.Label lb_matri_rg;
    }
}