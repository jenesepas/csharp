namespace Asegest
{
    partial class MUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MUsuarios));
            this.dgv_usuarios = new System.Windows.Forms.DataGridView();
            this.lb_tit_tas = new System.Windows.Forms.Label();
            this.btt_consultar_usu = new System.Windows.Forms.Button();
            this.btt_new_usu = new System.Windows.Forms.Button();
            this.btt_save_usu = new System.Windows.Forms.Button();
            this.btt_del_usu = new System.Windows.Forms.Button();
            this.tb_codigo = new System.Windows.Forms.TextBox();
            this.lb_codigo = new System.Windows.Forms.Label();
            this.lb_clave = new System.Windows.Forms.Label();
            this.tb_clave = new System.Windows.Forms.TextBox();
            this.lb_nombre = new System.Windows.Forms.Label();
            this.tb_nombre = new System.Windows.Forms.TextBox();
            this.lb_acceso = new System.Windows.Forms.Label();
            this.tb_acceso = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btt_modif_usu = new System.Windows.Forms.Button();
            this.btt_cancel_usu = new System.Windows.Forms.Button();
            this.lb_tit_usu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuarios)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_usuarios
            // 
            this.dgv_usuarios.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgv_usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_usuarios.Location = new System.Drawing.Point(51, 178);
            this.dgv_usuarios.Name = "dgv_usuarios";
            this.dgv_usuarios.Size = new System.Drawing.Size(595, 332);
            this.dgv_usuarios.TabIndex = 0;
            this.dgv_usuarios.SelectionChanged += new System.EventHandler(this.dgv_usuarios_SelectionChanged_1);
            // 
            // lb_tit_tas
            // 
            this.lb_tit_tas.Location = new System.Drawing.Point(0, 0);
            this.lb_tit_tas.Name = "lb_tit_tas";
            this.lb_tit_tas.Size = new System.Drawing.Size(100, 23);
            this.lb_tit_tas.TabIndex = 28;
            // 
            // btt_consultar_usu
            // 
            this.btt_consultar_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_consultar_usu.Location = new System.Drawing.Point(547, 515);
            this.btt_consultar_usu.Margin = new System.Windows.Forms.Padding(4);
            this.btt_consultar_usu.Name = "btt_consultar_usu";
            this.btt_consultar_usu.Size = new System.Drawing.Size(99, 34);
            this.btt_consultar_usu.TabIndex = 8;
            this.btt_consultar_usu.Text = "Consultar";
            this.btt_consultar_usu.UseVisualStyleBackColor = true;
            this.btt_consultar_usu.Click += new System.EventHandler(this.btt_consultar_usu_Click_1);
            // 
            // btt_new_usu
            // 
            this.btt_new_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_new_usu.Location = new System.Drawing.Point(662, 68);
            this.btt_new_usu.Margin = new System.Windows.Forms.Padding(4);
            this.btt_new_usu.Name = "btt_new_usu";
            this.btt_new_usu.Size = new System.Drawing.Size(99, 34);
            this.btt_new_usu.TabIndex = 9;
            this.btt_new_usu.Text = "Nuevo";
            this.btt_new_usu.UseVisualStyleBackColor = true;
            this.btt_new_usu.Click += new System.EventHandler(this.btt_new_usu_Click_1);
            // 
            // btt_save_usu
            // 
            this.btt_save_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_save_usu.Location = new System.Drawing.Point(662, 126);
            this.btt_save_usu.Margin = new System.Windows.Forms.Padding(4);
            this.btt_save_usu.Name = "btt_save_usu";
            this.btt_save_usu.Size = new System.Drawing.Size(99, 34);
            this.btt_save_usu.TabIndex = 10;
            this.btt_save_usu.Text = "Guardar";
            this.btt_save_usu.UseVisualStyleBackColor = true;
            this.btt_save_usu.Click += new System.EventHandler(this.btt_save_usu_Click_1);
            // 
            // btt_del_usu
            // 
            this.btt_del_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_del_usu.Location = new System.Drawing.Point(662, 393);
            this.btt_del_usu.Margin = new System.Windows.Forms.Padding(4);
            this.btt_del_usu.Name = "btt_del_usu";
            this.btt_del_usu.Size = new System.Drawing.Size(99, 34);
            this.btt_del_usu.TabIndex = 11;
            this.btt_del_usu.Text = "Borrar";
            this.btt_del_usu.UseVisualStyleBackColor = true;
            this.btt_del_usu.Click += new System.EventHandler(this.btt_del_usu_Click_1);
            // 
            // tb_codigo
            // 
            this.tb_codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_codigo.Location = new System.Drawing.Point(166, 75);
            this.tb_codigo.Margin = new System.Windows.Forms.Padding(4);
            this.tb_codigo.MaxLength = 50;
            this.tb_codigo.Name = "tb_codigo";
            this.tb_codigo.Size = new System.Drawing.Size(157, 24);
            this.tb_codigo.TabIndex = 1;
            this.tb_codigo.Enter += new System.EventHandler(this.tb_codigo_Enter);
            this.tb_codigo.Leave += new System.EventHandler(this.tb_codigo_Leave);
            this.tb_codigo.Validating += new System.ComponentModel.CancelEventHandler(this.tb_codigo_Validating_1);
            // 
            // lb_codigo
            // 
            this.lb_codigo.AutoSize = true;
            this.lb_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_codigo.Location = new System.Drawing.Point(84, 78);
            this.lb_codigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_codigo.Name = "lb_codigo";
            this.lb_codigo.Size = new System.Drawing.Size(56, 18);
            this.lb_codigo.TabIndex = 12;
            this.lb_codigo.Text = "Código";
            // 
            // lb_clave
            // 
            this.lb_clave.AutoSize = true;
            this.lb_clave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_clave.Location = new System.Drawing.Point(339, 78);
            this.lb_clave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_clave.Name = "lb_clave";
            this.lb_clave.Size = new System.Drawing.Size(45, 18);
            this.lb_clave.TabIndex = 14;
            this.lb_clave.Text = "Clave";
            // 
            // tb_clave
            // 
            this.tb_clave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_clave.Location = new System.Drawing.Point(393, 75);
            this.tb_clave.Margin = new System.Windows.Forms.Padding(4);
            this.tb_clave.MaxLength = 50;
            this.tb_clave.Name = "tb_clave";
            this.tb_clave.Size = new System.Drawing.Size(121, 24);
            this.tb_clave.TabIndex = 2;
            this.tb_clave.Validating += new System.ComponentModel.CancelEventHandler(this.tb_clave_Validating);
            // 
            // lb_nombre
            // 
            this.lb_nombre.AutoSize = true;
            this.lb_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombre.Location = new System.Drawing.Point(26, 60);
            this.lb_nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_nombre.Name = "lb_nombre";
            this.lb_nombre.Size = new System.Drawing.Size(62, 18);
            this.lb_nombre.TabIndex = 16;
            this.lb_nombre.Text = "Nombre";
            // 
            // tb_nombre
            // 
            this.tb_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nombre.Location = new System.Drawing.Point(166, 118);
            this.tb_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.tb_nombre.MaxLength = 100;
            this.tb_nombre.Name = "tb_nombre";
            this.tb_nombre.Size = new System.Drawing.Size(454, 24);
            this.tb_nombre.TabIndex = 4;
            this.tb_nombre.Validating += new System.ComponentModel.CancelEventHandler(this.tb_nombre_Validating_1);
            // 
            // lb_acceso
            // 
            this.lb_acceso.AutoSize = true;
            this.lb_acceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_acceso.Location = new System.Drawing.Point(534, 78);
            this.lb_acceso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_acceso.Name = "lb_acceso";
            this.lb_acceso.Size = new System.Drawing.Size(58, 18);
            this.lb_acceso.TabIndex = 18;
            this.lb_acceso.Text = "Acceso";
            // 
            // tb_acceso
            // 
            this.tb_acceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_acceso.Location = new System.Drawing.Point(595, 75);
            this.tb_acceso.Margin = new System.Windows.Forms.Padding(4);
            this.tb_acceso.MaxLength = 1;
            this.tb_acceso.Name = "tb_acceso";
            this.tb_acceso.Size = new System.Drawing.Size(25, 24);
            this.tb_acceso.TabIndex = 3;
            this.tb_acceso.Validating += new System.ComponentModel.CancelEventHandler(this.tb_acceso_Validating_1);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_nombre);
            this.panel1.Location = new System.Drawing.Point(51, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(595, 112);
            this.panel1.TabIndex = 0;
            // 
            // btt_modif_usu
            // 
            this.btt_modif_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_modif_usu.Location = new System.Drawing.Point(662, 178);
            this.btt_modif_usu.Margin = new System.Windows.Forms.Padding(4);
            this.btt_modif_usu.Name = "btt_modif_usu";
            this.btt_modif_usu.Size = new System.Drawing.Size(99, 34);
            this.btt_modif_usu.TabIndex = 21;
            this.btt_modif_usu.Text = "Modificar";
            this.btt_modif_usu.UseVisualStyleBackColor = true;
            this.btt_modif_usu.Click += new System.EventHandler(this.btt_modif_usu_Click_1);
            // 
            // btt_cancel_usu
            // 
            this.btt_cancel_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_cancel_usu.Location = new System.Drawing.Point(662, 476);
            this.btt_cancel_usu.Margin = new System.Windows.Forms.Padding(4);
            this.btt_cancel_usu.Name = "btt_cancel_usu";
            this.btt_cancel_usu.Size = new System.Drawing.Size(99, 34);
            this.btt_cancel_usu.TabIndex = 29;
            this.btt_cancel_usu.Text = "Cancelar";
            this.btt_cancel_usu.UseVisualStyleBackColor = true;
            this.btt_cancel_usu.Click += new System.EventHandler(this.btt_cancel_usu_Click);
            // 
            // lb_tit_usu
            // 
            this.lb_tit_usu.AutoSize = true;
            this.lb_tit_usu.BackColor = System.Drawing.Color.LightBlue;
            this.lb_tit_usu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_tit_usu.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tit_usu.ForeColor = System.Drawing.Color.Black;
            this.lb_tit_usu.Location = new System.Drawing.Point(278, 9);
            this.lb_tit_usu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_tit_usu.Name = "lb_tit_usu";
            this.lb_tit_usu.Size = new System.Drawing.Size(141, 35);
            this.lb_tit_usu.TabIndex = 30;
            this.lb_tit_usu.Text = "Usuarios";
            // 
            // MUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lb_tit_usu);
            this.Controls.Add(this.btt_cancel_usu);
            this.Controls.Add(this.tb_acceso);
            this.Controls.Add(this.btt_modif_usu);
            this.Controls.Add(this.lb_acceso);
            this.Controls.Add(this.tb_nombre);
            this.Controls.Add(this.tb_clave);
            this.Controls.Add(this.lb_clave);
            this.Controls.Add(this.tb_codigo);
            this.Controls.Add(this.lb_codigo);
            this.Controls.Add(this.btt_del_usu);
            this.Controls.Add(this.btt_save_usu);
            this.Controls.Add(this.btt_new_usu);
            this.Controls.Add(this.btt_consultar_usu);
            this.Controls.Add(this.lb_tit_tas);
            this.Controls.Add(this.dgv_usuarios);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MUsuarios";
            this.Text = "Mantenimiento de Usuarios";
            this.Load += new System.EventHandler(this.MUsuarios_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_usuarios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //private void SuspendLayout()
        //{
        //    throw new System.NotImplementedException();
        //}

        #endregion

        private System.Windows.Forms.DataGridView dgv_usuarios;
        private System.Windows.Forms.Label lb_tit_tas;
        private System.Windows.Forms.Button btt_consultar_usu;
        private System.Windows.Forms.Button btt_new_usu;
        private System.Windows.Forms.Button btt_save_usu;
        private System.Windows.Forms.Button btt_del_usu;
        private System.Windows.Forms.TextBox tb_codigo;
        private System.Windows.Forms.Label lb_codigo;
        private System.Windows.Forms.Label lb_clave;
        private System.Windows.Forms.TextBox tb_clave;
        private System.Windows.Forms.Label lb_nombre;
        private System.Windows.Forms.TextBox tb_nombre;
        private System.Windows.Forms.Label lb_acceso;
        private System.Windows.Forms.TextBox tb_acceso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btt_modif_usu;
        private System.Windows.Forms.Button btt_cancel_usu;
        private System.Windows.Forms.Label lb_tit_usu;
    }
}