namespace Formulario2
{
    partial class Form1
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
            this.etiq_01 = new System.Windows.Forms.Label();
            this.campo_01 = new System.Windows.Forms.TextBox();
            this.Pulsar = new System.Windows.Forms.Button();
            this.Insertar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // etiq_01
            // 
            this.etiq_01.AutoSize = true;
            this.etiq_01.Location = new System.Drawing.Point(59, 38);
            this.etiq_01.Name = "etiq_01";
            this.etiq_01.Size = new System.Drawing.Size(140, 13);
            this.etiq_01.TabIndex = 0;
            this.etiq_01.Text = "Introduzca cadena de texto:\r\n";
            // 
            // campo_01
            // 
            this.campo_01.BackColor = System.Drawing.SystemColors.Control;
            this.campo_01.Location = new System.Drawing.Point(42, 55);
            this.campo_01.Name = "campo_01";
            this.campo_01.Size = new System.Drawing.Size(167, 20);
            this.campo_01.TabIndex = 1;
            // 
            // Pulsar
            // 
            this.Pulsar.Location = new System.Drawing.Point(226, 55);
            this.Pulsar.Name = "Pulsar";
            this.Pulsar.Size = new System.Drawing.Size(75, 23);
            this.Pulsar.TabIndex = 2;
            this.Pulsar.Text = "Pulsar";
            this.Pulsar.UseVisualStyleBackColor = true;
            this.Pulsar.Click += new System.EventHandler(this.Pulsar_Click);
            // 
            // Insertar
            // 
            this.Insertar.Location = new System.Drawing.Point(226, 84);
            this.Insertar.Name = "Insertar";
            this.Insertar.Size = new System.Drawing.Size(75, 23);
            this.Insertar.TabIndex = 3;
            this.Insertar.Text = "Insertar";
            this.Insertar.UseVisualStyleBackColor = true;
            this.Insertar.Click += new System.EventHandler(this.Insertar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 400);
            this.Controls.Add(this.Insertar);
            this.Controls.Add(this.Pulsar);
            this.Controls.Add(this.campo_01);
            this.Controls.Add(this.etiq_01);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label etiq_01;
        private System.Windows.Forms.TextBox campo_01;
        private System.Windows.Forms.Button Pulsar;
        private System.Windows.Forms.Button Insertar;

    }
}

