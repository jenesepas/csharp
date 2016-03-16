namespace Puche
{
    partial class Rpt_Tasas
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
            this.btt_cancelar_ts = new System.Windows.Forms.Button();
            this.tb_h_cod = new System.Windows.Forms.TextBox();
            this.lb_h_cod = new System.Windows.Forms.Label();
            this.tb_d_cod = new System.Windows.Forms.TextBox();
            this.lb_d_cod = new System.Windows.Forms.Label();
            this.btt_imp_ts = new System.Windows.Forms.Button();
            this.tb_h_ej = new System.Windows.Forms.TextBox();
            this.lb_h_ej = new System.Windows.Forms.Label();
            this.tb_d_ej = new System.Windows.Forms.TextBox();
            this.lb_d_ej = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btt_cancelar_ts
            // 
            this.btt_cancelar_ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_cancelar_ts.Location = new System.Drawing.Point(180, 142);
            this.btt_cancelar_ts.Name = "btt_cancelar_ts";
            this.btt_cancelar_ts.Size = new System.Drawing.Size(89, 34);
            this.btt_cancelar_ts.TabIndex = 10;
            this.btt_cancelar_ts.Text = "Cancelar";
            this.btt_cancelar_ts.UseVisualStyleBackColor = true;
            this.btt_cancelar_ts.Click += new System.EventHandler(this.btt_cancelar_ts_Click);
            // 
            // tb_h_cod
            // 
            this.tb_h_cod.Location = new System.Drawing.Point(210, 83);
            this.tb_h_cod.MaxLength = 5;
            this.tb_h_cod.Name = "tb_h_cod";
            this.tb_h_cod.Size = new System.Drawing.Size(41, 20);
            this.tb_h_cod.TabIndex = 7;
            // 
            // lb_h_cod
            // 
            this.lb_h_cod.AutoSize = true;
            this.lb_h_cod.Location = new System.Drawing.Point(150, 84);
            this.lb_h_cod.Name = "lb_h_cod";
            this.lb_h_cod.Size = new System.Drawing.Size(54, 13);
            this.lb_h_cod.TabIndex = 51;
            this.lb_h_cod.Text = "H. Codigo";
            // 
            // tb_d_cod
            // 
            this.tb_d_cod.Location = new System.Drawing.Point(210, 57);
            this.tb_d_cod.MaxLength = 5;
            this.tb_d_cod.Name = "tb_d_cod";
            this.tb_d_cod.Size = new System.Drawing.Size(41, 20);
            this.tb_d_cod.TabIndex = 5;
            // 
            // lb_d_cod
            // 
            this.lb_d_cod.AutoSize = true;
            this.lb_d_cod.Location = new System.Drawing.Point(150, 60);
            this.lb_d_cod.Name = "lb_d_cod";
            this.lb_d_cod.Size = new System.Drawing.Size(54, 13);
            this.lb_d_cod.TabIndex = 49;
            this.lb_d_cod.Text = "D. Codigo";
            // 
            // btt_imp_ts
            // 
            this.btt_imp_ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_imp_ts.Location = new System.Drawing.Point(24, 142);
            this.btt_imp_ts.Name = "btt_imp_ts";
            this.btt_imp_ts.Size = new System.Drawing.Size(89, 34);
            this.btt_imp_ts.TabIndex = 9;
            this.btt_imp_ts.Text = "Imprimir";
            this.btt_imp_ts.UseVisualStyleBackColor = true;
            this.btt_imp_ts.Click += new System.EventHandler(this.btt_imp_lrg_Click);
            // 
            // tb_h_ej
            // 
            this.tb_h_ej.Location = new System.Drawing.Point(86, 84);
            this.tb_h_ej.MaxLength = 4;
            this.tb_h_ej.Name = "tb_h_ej";
            this.tb_h_ej.Size = new System.Drawing.Size(46, 20);
            this.tb_h_ej.TabIndex = 3;
            // 
            // lb_h_ej
            // 
            this.lb_h_ej.AutoSize = true;
            this.lb_h_ej.Location = new System.Drawing.Point(39, 84);
            this.lb_h_ej.Name = "lb_h_ej";
            this.lb_h_ej.Size = new System.Drawing.Size(40, 13);
            this.lb_h_ej.TabIndex = 46;
            this.lb_h_ej.Text = "H. Año";
            // 
            // tb_d_ej
            // 
            this.tb_d_ej.Location = new System.Drawing.Point(86, 57);
            this.tb_d_ej.MaxLength = 4;
            this.tb_d_ej.Name = "tb_d_ej";
            this.tb_d_ej.Size = new System.Drawing.Size(46, 20);
            this.tb_d_ej.TabIndex = 1;
            // 
            // lb_d_ej
            // 
            this.lb_d_ej.AutoSize = true;
            this.lb_d_ej.Location = new System.Drawing.Point(39, 60);
            this.lb_d_ej.Name = "lb_d_ej";
            this.lb_d_ej.Size = new System.Drawing.Size(40, 13);
            this.lb_d_ej.TabIndex = 44;
            this.lb_d_ej.Text = "D. Año";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(24, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 92);
            this.panel1.TabIndex = 54;
            // 
            // Rpt_Tasas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 196);
            this.Controls.Add(this.btt_cancelar_ts);
            this.Controls.Add(this.tb_h_cod);
            this.Controls.Add(this.lb_h_cod);
            this.Controls.Add(this.tb_d_cod);
            this.Controls.Add(this.lb_d_cod);
            this.Controls.Add(this.btt_imp_ts);
            this.Controls.Add(this.tb_h_ej);
            this.Controls.Add(this.lb_h_ej);
            this.Controls.Add(this.tb_d_ej);
            this.Controls.Add(this.lb_d_ej);
            this.Controls.Add(this.panel1);
            this.Name = "Rpt_Tasas";
            this.Text = "Listado de Tasas";
            this.Load += new System.EventHandler(this.Rpt_Tasas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btt_cancelar_ts;
        private System.Windows.Forms.TextBox tb_h_cod;
        private System.Windows.Forms.Label lb_h_cod;
        private System.Windows.Forms.TextBox tb_d_cod;
        private System.Windows.Forms.Label lb_d_cod;
        private System.Windows.Forms.Button btt_imp_ts;
        private System.Windows.Forms.TextBox tb_h_ej;
        private System.Windows.Forms.Label lb_h_ej;
        private System.Windows.Forms.TextBox tb_d_ej;
        private System.Windows.Forms.Label lb_d_ej;
        private System.Windows.Forms.Panel panel1;
    }
}