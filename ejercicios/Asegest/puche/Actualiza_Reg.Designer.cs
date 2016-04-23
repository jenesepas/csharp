namespace Asegest
{
    partial class Actualiza_Reg
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
            this.btt_imp_ts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btt_cancelar_ts
            // 
            this.btt_cancelar_ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_cancelar_ts.Location = new System.Drawing.Point(143, 40);
            this.btt_cancelar_ts.Name = "btt_cancelar_ts";
            this.btt_cancelar_ts.Size = new System.Drawing.Size(89, 34);
            this.btt_cancelar_ts.TabIndex = 14;
            this.btt_cancelar_ts.Text = "Cancelar";
            this.btt_cancelar_ts.UseVisualStyleBackColor = true;
            this.btt_cancelar_ts.Click += new System.EventHandler(this.btt_cancelar_ts_Click_1);
            // 
            // btt_imp_ts
            // 
            this.btt_imp_ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_imp_ts.Location = new System.Drawing.Point(23, 40);
            this.btt_imp_ts.Name = "btt_imp_ts";
            this.btt_imp_ts.Size = new System.Drawing.Size(92, 34);
            this.btt_imp_ts.TabIndex = 13;
            this.btt_imp_ts.Text = "Actualizar";
            this.btt_imp_ts.UseVisualStyleBackColor = true;
            this.btt_imp_ts.Click += new System.EventHandler(this.btt_imp_ts_Click_1);
            // 
            // Actualiza_Reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 115);
            this.Controls.Add(this.btt_cancelar_ts);
            this.Controls.Add(this.btt_imp_ts);
            this.Name = "Actualiza_Reg";
            this.Text = "Actualiza Num. Reg.";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btt_cancelar_ts;
        private System.Windows.Forms.Button btt_imp_ts;
    }
}