namespace Asegest
{
    partial class Rpt_Desfactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rpt_Desfactura));
            this.lb_nfac = new System.Windows.Forms.Label();
            this.tb_nfac = new System.Windows.Forms.TextBox();
            this.btt_cancelar_ts = new System.Windows.Forms.Button();
            this.btt_imp_ts = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_nfac
            // 
            this.lb_nfac.AutoSize = true;
            this.lb_nfac.Location = new System.Drawing.Point(33, 12);
            this.lb_nfac.Name = "lb_nfac";
            this.lb_nfac.Size = new System.Drawing.Size(139, 13);
            this.lb_nfac.TabIndex = 0;
            this.lb_nfac.Text = "Num. Factura a desfacturar:";
            // 
            // tb_nfac
            // 
            this.tb_nfac.Location = new System.Drawing.Point(52, 30);
            this.tb_nfac.Name = "tb_nfac";
            this.tb_nfac.Size = new System.Drawing.Size(100, 20);
            this.tb_nfac.TabIndex = 1;
            this.tb_nfac.Validating += new System.ComponentModel.CancelEventHandler(this.tb_nfac_Validating);
            // 
            // btt_cancelar_ts
            // 
            this.btt_cancelar_ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_cancelar_ts.Location = new System.Drawing.Point(132, 80);
            this.btt_cancelar_ts.Name = "btt_cancelar_ts";
            this.btt_cancelar_ts.Size = new System.Drawing.Size(89, 34);
            this.btt_cancelar_ts.TabIndex = 12;
            this.btt_cancelar_ts.Text = "Cancelar";
            this.btt_cancelar_ts.UseVisualStyleBackColor = true;
            this.btt_cancelar_ts.Click += new System.EventHandler(this.btt_cancelar_ts_Click);
            // 
            // btt_imp_ts
            // 
            this.btt_imp_ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_imp_ts.Location = new System.Drawing.Point(12, 80);
            this.btt_imp_ts.Name = "btt_imp_ts";
            this.btt_imp_ts.Size = new System.Drawing.Size(92, 34);
            this.btt_imp_ts.TabIndex = 11;
            this.btt_imp_ts.Text = "Actualizar";
            this.btt_imp_ts.UseVisualStyleBackColor = true;
            this.btt_imp_ts.Click += new System.EventHandler(this.btt_imp_ts_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_nfac);
            this.panel1.Controls.Add(this.tb_nfac);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 65);
            this.panel1.TabIndex = 13;
            // 
            // Rpt_Desfactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 126);
            this.Controls.Add(this.btt_cancelar_ts);
            this.Controls.Add(this.btt_imp_ts);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Rpt_Desfactura";
            this.Text = "Desfacturar una factura";
            this.Load += new System.EventHandler(this.Rpt_Desfactura_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_nfac;
        private System.Windows.Forms.TextBox tb_nfac;
        private System.Windows.Forms.Button btt_cancelar_ts;
        private System.Windows.Forms.Button btt_imp_ts;
        private System.Windows.Forms.Panel panel1;
    }
}