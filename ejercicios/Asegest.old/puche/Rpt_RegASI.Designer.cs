namespace Asegest
{
    partial class Rpt_RegASI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_secc_int = new System.Windows.Forms.Label();
            this.tb_year = new System.Windows.Forms.TextBox();
            this.cb_secc_int = new System.Windows.Forms.ComboBox();
            this.lb_year = new System.Windows.Forms.Label();
            this.gb_del_lrg = new System.Windows.Forms.GroupBox();
            this.rb_a_lrg = new System.Windows.Forms.RadioButton();
            this.rb_m_lrg = new System.Windows.Forms.RadioButton();
            this.rb_y_lrg = new System.Windows.Forms.RadioButton();
            this.btt_imp_ac_rg_s = new System.Windows.Forms.Button();
            this.btt_cancelar_ac_rg_s = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gb_del_lrg.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_secc_int);
            this.panel1.Controls.Add(this.tb_year);
            this.panel1.Controls.Add(this.cb_secc_int);
            this.panel1.Controls.Add(this.lb_year);
            this.panel1.Controls.Add(this.gb_del_lrg);
            this.panel1.Location = new System.Drawing.Point(23, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 137);
            this.panel1.TabIndex = 65;
            // 
            // lb_secc_int
            // 
            this.lb_secc_int.AutoSize = true;
            this.lb_secc_int.Location = new System.Drawing.Point(13, 99);
            this.lb_secc_int.Name = "lb_secc_int";
            this.lb_secc_int.Size = new System.Drawing.Size(53, 13);
            this.lb_secc_int.TabIndex = 66;
            this.lb_secc_int.Text = "Secc_Int.";
            // 
            // tb_year
            // 
            this.tb_year.Location = new System.Drawing.Point(74, 70);
            this.tb_year.Name = "tb_year";
            this.tb_year.Size = new System.Drawing.Size(53, 20);
            this.tb_year.TabIndex = 49;
            // 
            // cb_secc_int
            // 
            this.cb_secc_int.FormattingEnabled = true;
            this.cb_secc_int.Items.AddRange(new object[] {
            "GESTASER",
            "EX",
            "AVPO",
            "A"});
            this.cb_secc_int.Location = new System.Drawing.Point(74, 96);
            this.cb_secc_int.Name = "cb_secc_int";
            this.cb_secc_int.Size = new System.Drawing.Size(116, 21);
            this.cb_secc_int.TabIndex = 67;
            // 
            // lb_year
            // 
            this.lb_year.AutoSize = true;
            this.lb_year.Location = new System.Drawing.Point(33, 73);
            this.lb_year.Name = "lb_year";
            this.lb_year.Size = new System.Drawing.Size(26, 13);
            this.lb_year.TabIndex = 48;
            this.lb_year.Text = "Año";
            // 
            // gb_del_lrg
            // 
            this.gb_del_lrg.BackColor = System.Drawing.Color.LightBlue;
            this.gb_del_lrg.Controls.Add(this.rb_a_lrg);
            this.gb_del_lrg.Controls.Add(this.rb_m_lrg);
            this.gb_del_lrg.Controls.Add(this.rb_y_lrg);
            this.gb_del_lrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_del_lrg.Location = new System.Drawing.Point(9, 9);
            this.gb_del_lrg.Name = "gb_del_lrg";
            this.gb_del_lrg.Size = new System.Drawing.Size(219, 47);
            this.gb_del_lrg.TabIndex = 39;
            this.gb_del_lrg.TabStop = false;
            this.gb_del_lrg.Text = "Delegacion";
            // 
            // rb_a_lrg
            // 
            this.rb_a_lrg.AutoSize = true;
            this.rb_a_lrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_a_lrg.Location = new System.Drawing.Point(134, 20);
            this.rb_a_lrg.Name = "rb_a_lrg";
            this.rb_a_lrg.Size = new System.Drawing.Size(80, 19);
            this.rb_a_lrg.TabIndex = 26;
            this.rb_a_lrg.Text = "Albacete";
            this.rb_a_lrg.UseVisualStyleBackColor = true;
            // 
            // rb_m_lrg
            // 
            this.rb_m_lrg.AutoSize = true;
            this.rb_m_lrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_m_lrg.Location = new System.Drawing.Point(65, 20);
            this.rb_m_lrg.Name = "rb_m_lrg";
            this.rb_m_lrg.Size = new System.Drawing.Size(69, 19);
            this.rb_m_lrg.TabIndex = 25;
            this.rb_m_lrg.Text = "Murcia";
            this.rb_m_lrg.UseVisualStyleBackColor = true;
            // 
            // rb_y_lrg
            // 
            this.rb_y_lrg.AutoSize = true;
            this.rb_y_lrg.Checked = true;
            this.rb_y_lrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_y_lrg.Location = new System.Drawing.Point(6, 20);
            this.rb_y_lrg.Name = "rb_y_lrg";
            this.rb_y_lrg.Size = new System.Drawing.Size(60, 19);
            this.rb_y_lrg.TabIndex = 24;
            this.rb_y_lrg.TabStop = true;
            this.rb_y_lrg.Text = "Yecla";
            this.rb_y_lrg.UseVisualStyleBackColor = true;
            // 
            // btt_imp_ac_rg_s
            // 
            this.btt_imp_ac_rg_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_imp_ac_rg_s.Location = new System.Drawing.Point(23, 150);
            this.btt_imp_ac_rg_s.Name = "btt_imp_ac_rg_s";
            this.btt_imp_ac_rg_s.Size = new System.Drawing.Size(89, 34);
            this.btt_imp_ac_rg_s.TabIndex = 66;
            this.btt_imp_ac_rg_s.Text = "Imprimir";
            this.btt_imp_ac_rg_s.UseVisualStyleBackColor = true;
            this.btt_imp_ac_rg_s.Click += new System.EventHandler(this.btt_imp_ac_rg_si_Click);
            // 
            // btt_cancelar_ac_rg_s
            // 
            this.btt_cancelar_ac_rg_s.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_cancelar_ac_rg_s.Location = new System.Drawing.Point(173, 150);
            this.btt_cancelar_ac_rg_s.Name = "btt_cancelar_ac_rg_s";
            this.btt_cancelar_ac_rg_s.Size = new System.Drawing.Size(89, 34);
            this.btt_cancelar_ac_rg_s.TabIndex = 67;
            this.btt_cancelar_ac_rg_s.Text = "Cancelar";
            this.btt_cancelar_ac_rg_s.UseVisualStyleBackColor = true;
            this.btt_cancelar_ac_rg_s.Click += new System.EventHandler(this.btt_cancelar_ac_rg_si_Click);
            // 
            // Rpt_RegASI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 191);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btt_imp_ac_rg_s);
            this.Controls.Add(this.btt_cancelar_ac_rg_s);
            this.Name = "Rpt_RegASI";
            this.Text = "List. Reg. Mensual x Secc_Int.";
            this.Load += new System.EventHandler(this.Rpt_RegASI_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gb_del_lrg.ResumeLayout(false);
            this.gb_del_lrg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_secc_int;
        private System.Windows.Forms.TextBox tb_year;
        private System.Windows.Forms.ComboBox cb_secc_int;
        private System.Windows.Forms.Label lb_year;
        private System.Windows.Forms.GroupBox gb_del_lrg;
        private System.Windows.Forms.RadioButton rb_a_lrg;
        private System.Windows.Forms.RadioButton rb_m_lrg;
        private System.Windows.Forms.RadioButton rb_y_lrg;
        private System.Windows.Forms.Button btt_imp_ac_rg_s;
        private System.Windows.Forms.Button btt_cancelar_ac_rg_s;
    }
}