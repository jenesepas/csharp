namespace Formulario2
{
    partial class Form2
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
            this.f2_lab_nombre = new System.Windows.Forms.Label();
            this.f2_g2_usuario = new System.Windows.Forms.GroupBox();
            this.f2_tb_nombre = new System.Windows.Forms.TextBox();
            this.f2_lab_apellido = new System.Windows.Forms.Label();
            this.f2_tb_apellidos = new System.Windows.Forms.TextBox();
            this.f2_bot_aceptar = new System.Windows.Forms.Button();
            this.f2_g2_usuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // f2_lab_nombre
            // 
            this.f2_lab_nombre.AutoSize = true;
            this.f2_lab_nombre.Location = new System.Drawing.Point(78, 32);
            this.f2_lab_nombre.Name = "f2_lab_nombre";
            this.f2_lab_nombre.Size = new System.Drawing.Size(44, 13);
            this.f2_lab_nombre.TabIndex = 0;
            this.f2_lab_nombre.Text = "Nombre";
            // 
            // f2_g2_usuario
            // 
            this.f2_g2_usuario.Controls.Add(this.f2_tb_apellidos);
            this.f2_g2_usuario.Controls.Add(this.f2_lab_apellido);
            this.f2_g2_usuario.Controls.Add(this.f2_tb_nombre);
            this.f2_g2_usuario.Controls.Add(this.f2_lab_nombre);
            this.f2_g2_usuario.Location = new System.Drawing.Point(46, 33);
            this.f2_g2_usuario.Name = "f2_g2_usuario";
            this.f2_g2_usuario.Size = new System.Drawing.Size(200, 170);
            this.f2_g2_usuario.TabIndex = 1;
            this.f2_g2_usuario.TabStop = false;
            // 
            // f2_tb_nombre
            // 
            this.f2_tb_nombre.Location = new System.Drawing.Point(35, 48);
            this.f2_tb_nombre.Name = "f2_tb_nombre";
            this.f2_tb_nombre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.f2_tb_nombre.Size = new System.Drawing.Size(135, 20);
            this.f2_tb_nombre.TabIndex = 1;
            // 
            // f2_lab_apellido
            // 
            this.f2_lab_apellido.AutoSize = true;
            this.f2_lab_apellido.Location = new System.Drawing.Point(78, 102);
            this.f2_lab_apellido.Name = "f2_lab_apellido";
            this.f2_lab_apellido.Size = new System.Drawing.Size(49, 13);
            this.f2_lab_apellido.TabIndex = 0;
            this.f2_lab_apellido.Text = "Apellidos";
            // 
            // f2_tb_apellidos
            // 
            this.f2_tb_apellidos.Location = new System.Drawing.Point(35, 118);
            this.f2_tb_apellidos.Name = "f2_tb_apellidos";
            this.f2_tb_apellidos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.f2_tb_apellidos.Size = new System.Drawing.Size(135, 20);
            this.f2_tb_apellidos.TabIndex = 3;
            // 
            // f2_bot_aceptar
            // 
            this.f2_bot_aceptar.Location = new System.Drawing.Point(96, 209);
            this.f2_bot_aceptar.Name = "f2_bot_aceptar";
            this.f2_bot_aceptar.Size = new System.Drawing.Size(86, 30);
            this.f2_bot_aceptar.TabIndex = 2;
            this.f2_bot_aceptar.Text = "Aceptar";
            this.f2_bot_aceptar.UseVisualStyleBackColor = true;
            this.f2_bot_aceptar.Click += new System.EventHandler(this.f2_bot_aceptar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.f2_bot_aceptar);
            this.Controls.Add(this.f2_g2_usuario);
            this.Name = "Form2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Introduce Usuario";
            this.TopMost = true;
            this.f2_g2_usuario.ResumeLayout(false);
            this.f2_g2_usuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label f2_lab_nombre;
        private System.Windows.Forms.GroupBox f2_g2_usuario;
        private System.Windows.Forms.TextBox f2_tb_nombre;
        private System.Windows.Forms.TextBox f2_tb_apellidos;
        private System.Windows.Forms.Label f2_lab_apellido;
        private System.Windows.Forms.Button f2_bot_aceptar;

    }
}