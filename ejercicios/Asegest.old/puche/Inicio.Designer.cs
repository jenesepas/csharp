namespace Asegest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.lb_deleg = new System.Windows.Forms.Label();
            this.gb_del = new System.Windows.Forms.GroupBox();
            this.rb_del_a = new System.Windows.Forms.RadioButton();
            this.rb_del_m = new System.Windows.Forms.RadioButton();
            this.rb_del_y = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btt_entrar = new System.Windows.Forms.Button();
            this.gb_usu = new System.Windows.Forms.GroupBox();
            this.lb_cod = new System.Windows.Forms.Label();
            this.tb_cod = new System.Windows.Forms.TextBox();
            this.tb_clave = new System.Windows.Forms.TextBox();
            this.lb_clave = new System.Windows.Forms.Label();
            this.gb_del.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gb_usu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_deleg
            // 
            this.lb_deleg.AutoSize = true;
            this.lb_deleg.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lb_deleg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_deleg.Location = new System.Drawing.Point(170, 0);
            this.lb_deleg.Name = "lb_deleg";
            this.lb_deleg.Size = new System.Drawing.Size(91, 20);
            this.lb_deleg.TabIndex = 0;
            this.lb_deleg.Text = "Introducir:";
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
            this.gb_del.Text = "Delegación";
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
            this.panel1.Controls.Add(this.gb_usu);
            this.panel1.Controls.Add(this.lb_deleg);
            this.panel1.Location = new System.Drawing.Point(25, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 155);
            this.panel1.TabIndex = 2;
            // 
            // btt_entrar
            // 
            this.btt_entrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_entrar.Location = new System.Drawing.Point(186, 174);
            this.btt_entrar.Margin = new System.Windows.Forms.Padding(4);
            this.btt_entrar.Name = "btt_entrar";
            this.btt_entrar.Size = new System.Drawing.Size(99, 34);
            this.btt_entrar.TabIndex = 9;
            this.btt_entrar.Text = "Entrar";
            this.btt_entrar.UseVisualStyleBackColor = true;
            this.btt_entrar.Click += new System.EventHandler(this.btt_entrar_Click);
            // 
            // gb_usu
            // 
            this.gb_usu.BackColor = System.Drawing.Color.LightBlue;
            this.gb_usu.Controls.Add(this.tb_clave);
            this.gb_usu.Controls.Add(this.lb_clave);
            this.gb_usu.Controls.Add(this.tb_cod);
            this.gb_usu.Controls.Add(this.lb_cod);
            this.gb_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_usu.Location = new System.Drawing.Point(187, 35);
            this.gb_usu.Name = "gb_usu";
            this.gb_usu.Size = new System.Drawing.Size(209, 110);
            this.gb_usu.TabIndex = 3;
            this.gb_usu.TabStop = false;
            this.gb_usu.Text = "Usuario";
            // 
            // lb_cod
            // 
            this.lb_cod.AutoSize = true;
            this.lb_cod.Location = new System.Drawing.Point(17, 17);
            this.lb_cod.Name = "lb_cod";
            this.lb_cod.Size = new System.Drawing.Size(56, 15);
            this.lb_cod.TabIndex = 0;
            this.lb_cod.Text = "Código:";
            // 
            // tb_cod
            // 
            this.tb_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_cod.Location = new System.Drawing.Point(17, 35);
            this.tb_cod.Name = "tb_cod";
            this.tb_cod.Size = new System.Drawing.Size(177, 21);
            this.tb_cod.TabIndex = 1;
            this.tb_cod.Validating += new System.ComponentModel.CancelEventHandler(this.tb_cod_Validating);
            // 
            // tb_clave
            // 
            this.tb_clave.Location = new System.Drawing.Point(17, 81);
            this.tb_clave.Name = "tb_clave";
            this.tb_clave.PasswordChar = '*';
            this.tb_clave.Size = new System.Drawing.Size(177, 21);
            this.tb_clave.TabIndex = 3;
            this.tb_clave.Validating += new System.ComponentModel.CancelEventHandler(this.tb_clave_Validating);
            // 
            // lb_clave
            // 
            this.lb_clave.AutoSize = true;
            this.lb_clave.Location = new System.Drawing.Point(17, 63);
            this.lb_clave.Name = "lb_clave";
            this.lb_clave.Size = new System.Drawing.Size(46, 15);
            this.lb_clave.TabIndex = 2;
            this.lb_clave.Text = "Clave:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 211);
            this.Controls.Add(this.btt_entrar);
            this.Controls.Add(this.gb_del);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenidos a Asegest Yecmur";
            this.gb_del.ResumeLayout(false);
            this.gb_del.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gb_usu.ResumeLayout(false);
            this.gb_usu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_deleg;
        private System.Windows.Forms.GroupBox gb_del;
        private System.Windows.Forms.RadioButton rb_del_a;
        private System.Windows.Forms.RadioButton rb_del_m;
        private System.Windows.Forms.RadioButton rb_del_y;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btt_entrar;
        private System.Windows.Forms.GroupBox gb_usu;
        private System.Windows.Forms.TextBox tb_clave;
        private System.Windows.Forms.Label lb_clave;
        private System.Windows.Forms.TextBox tb_cod;
        private System.Windows.Forms.Label lb_cod;
    }
}