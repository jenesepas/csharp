namespace Puche
{
    partial class Inicio
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
            this.lb_deleg = new System.Windows.Forms.Label();
            this.gb_del = new System.Windows.Forms.GroupBox();
            this.rb_del_a = new System.Windows.Forms.RadioButton();
            this.rb_del_m = new System.Windows.Forms.RadioButton();
            this.rb_del_y = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btt_entrar = new System.Windows.Forms.Button();
            this.gb_del.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_deleg
            // 
            this.lb_deleg.AutoSize = true;
            this.lb_deleg.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lb_deleg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_deleg.Location = new System.Drawing.Point(40, 20);
            this.lb_deleg.Name = "lb_deleg";
            this.lb_deleg.Size = new System.Drawing.Size(175, 20);
            this.lb_deleg.TabIndex = 0;
            this.lb_deleg.Text = "Seleccione Delegación:";
            // 
            // gb_del
            // 
            this.gb_del.BackColor = System.Drawing.Color.LightBlue;
            this.gb_del.Controls.Add(this.rb_del_a);
            this.gb_del.Controls.Add(this.rb_del_m);
            this.gb_del.Controls.Add(this.rb_del_y);
            this.gb_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_del.Location = new System.Drawing.Point(58, 48);
            this.gb_del.Name = "gb_del";
            this.gb_del.Size = new System.Drawing.Size(138, 110);
            this.gb_del.TabIndex = 1;
            this.gb_del.TabStop = false;
            // 
            // rb_del_a
            // 
            this.rb_del_a.AutoSize = true;
            this.rb_del_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_del_a.Location = new System.Drawing.Point(22, 81);
            this.rb_del_a.Name = "rb_del_a";
            this.rb_del_a.Size = new System.Drawing.Size(88, 20);
            this.rb_del_a.TabIndex = 2;
            this.rb_del_a.Text = "Albacete";
            this.rb_del_a.UseVisualStyleBackColor = true;
            // 
            // rb_del_m
            // 
            this.rb_del_m.AutoSize = true;
            this.rb_del_m.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_del_m.Location = new System.Drawing.Point(22, 51);
            this.rb_del_m.Name = "rb_del_m";
            this.rb_del_m.Size = new System.Drawing.Size(72, 20);
            this.rb_del_m.TabIndex = 1;
            this.rb_del_m.Text = "Murcia";
            this.rb_del_m.UseVisualStyleBackColor = true;
            // 
            // rb_del_y
            // 
            this.rb_del_y.AutoSize = true;
            this.rb_del_y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_del_y.Location = new System.Drawing.Point(22, 21);
            this.rb_del_y.Name = "rb_del_y";
            this.rb_del_y.Size = new System.Drawing.Size(66, 20);
            this.rb_del_y.TabIndex = 0;
            this.rb_del_y.Text = "Yecla";
            this.rb_del_y.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(25, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 155);
            this.panel1.TabIndex = 2;
            // 
            // btt_entrar
            // 
            this.btt_entrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_entrar.Location = new System.Drawing.Point(78, 174);
            this.btt_entrar.Margin = new System.Windows.Forms.Padding(4);
            this.btt_entrar.Name = "btt_entrar";
            this.btt_entrar.Size = new System.Drawing.Size(99, 34);
            this.btt_entrar.TabIndex = 9;
            this.btt_entrar.Text = "Entrar";
            this.btt_entrar.UseVisualStyleBackColor = true;
            this.btt_entrar.Click += new System.EventHandler(this.btt_entrar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 211);
            this.Controls.Add(this.btt_entrar);
            this.Controls.Add(this.gb_del);
            this.Controls.Add(this.lb_deleg);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenidos a Asegest Yecmur";
            this.gb_del.ResumeLayout(false);
            this.gb_del.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_deleg;
        private System.Windows.Forms.GroupBox gb_del;
        private System.Windows.Forms.RadioButton rb_del_a;
        private System.Windows.Forms.RadioButton rb_del_m;
        private System.Windows.Forms.RadioButton rb_del_y;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btt_entrar;
    }
}