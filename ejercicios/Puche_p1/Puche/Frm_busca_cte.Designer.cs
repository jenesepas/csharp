namespace Puche
{
    partial class Frm_busca_cte
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
        	this.lb_b_nombre = new System.Windows.Forms.Label();
        	this.tb_b_nombre = new System.Windows.Forms.TextBox();
        	this.lb_b_docu = new System.Windows.Forms.Label();
        	this.tb_b_docu = new System.Windows.Forms.TextBox();
        	this.gb_b_t_cte = new System.Windows.Forms.GroupBox();
        	this.rb_titular = new System.Windows.Forms.RadioButton();
        	this.rb_cte = new System.Windows.Forms.RadioButton();
        	this.btt_b_buscar = new System.Windows.Forms.Button();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.dgv_ctes = new System.Windows.Forms.DataGridView();
        	this.btt_b_aceptar = new System.Windows.Forms.Button();
        	this.btt_b_cancelar = new System.Windows.Forms.Button();
        	this.gb_b_t_cte.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgv_ctes)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// lb_b_nombre
        	// 
        	this.lb_b_nombre.AutoSize = true;
        	this.lb_b_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lb_b_nombre.Location = new System.Drawing.Point(296, 44);
        	this.lb_b_nombre.Name = "lb_b_nombre";
        	this.lb_b_nombre.Size = new System.Drawing.Size(65, 20);
        	this.lb_b_nombre.TabIndex = 0;
        	this.lb_b_nombre.Text = "Nombre";
        	// 
        	// tb_b_nombre
        	// 
        	this.tb_b_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tb_b_nombre.Location = new System.Drawing.Point(367, 44);
        	this.tb_b_nombre.Name = "tb_b_nombre";
        	this.tb_b_nombre.Size = new System.Drawing.Size(267, 26);
        	this.tb_b_nombre.TabIndex = 1;
        	// 
        	// lb_b_docu
        	// 
        	this.lb_b_docu.AutoSize = true;
        	this.lb_b_docu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lb_b_docu.Location = new System.Drawing.Point(269, 91);
        	this.lb_b_docu.Name = "lb_b_docu";
        	this.lb_b_docu.Size = new System.Drawing.Size(92, 20);
        	this.lb_b_docu.TabIndex = 2;
        	this.lb_b_docu.Text = "Documento";
        	// 
        	// tb_b_docu
        	// 
        	this.tb_b_docu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tb_b_docu.Location = new System.Drawing.Point(367, 91);
        	this.tb_b_docu.Name = "tb_b_docu";
        	this.tb_b_docu.Size = new System.Drawing.Size(170, 26);
        	this.tb_b_docu.TabIndex = 3;
        	// 
        	// gb_b_t_cte
        	// 
        	this.gb_b_t_cte.BackColor = System.Drawing.Color.LightBlue;
        	this.gb_b_t_cte.Controls.Add(this.rb_titular);
        	this.gb_b_t_cte.Controls.Add(this.rb_cte);
        	this.gb_b_t_cte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.gb_b_t_cte.Location = new System.Drawing.Point(125, 24);
        	this.gb_b_t_cte.Name = "gb_b_t_cte";
        	this.gb_b_t_cte.Size = new System.Drawing.Size(138, 100);
        	this.gb_b_t_cte.TabIndex = 27;
        	this.gb_b_t_cte.TabStop = false;
        	this.gb_b_t_cte.Text = "Tipo";
        	// 
        	// rb_titular
        	// 
        	this.rb_titular.AutoSize = true;
        	this.rb_titular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.rb_titular.Location = new System.Drawing.Point(27, 57);
        	this.rb_titular.Name = "rb_titular";
        	this.rb_titular.Size = new System.Drawing.Size(77, 24);
        	this.rb_titular.TabIndex = 25;
        	this.rb_titular.Text = "Titular";
        	this.rb_titular.UseVisualStyleBackColor = true;
        	// 
        	// rb_cte
        	// 
        	this.rb_cte.AutoSize = true;
        	this.rb_cte.Checked = true;
        	this.rb_cte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.rb_cte.Location = new System.Drawing.Point(27, 27);
        	this.rb_cte.Name = "rb_cte";
        	this.rb_cte.Size = new System.Drawing.Size(83, 24);
        	this.rb_cte.TabIndex = 24;
        	this.rb_cte.TabStop = true;
        	this.rb_cte.Text = "Cliente";
        	this.rb_cte.UseVisualStyleBackColor = true;
        	// 
        	// btt_b_buscar
        	// 
        	this.btt_b_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.btt_b_buscar.Location = new System.Drawing.Point(560, 83);
        	this.btt_b_buscar.Name = "btt_b_buscar";
        	this.btt_b_buscar.Size = new System.Drawing.Size(99, 34);
        	this.btt_b_buscar.TabIndex = 28;
        	this.btt_b_buscar.Text = "Buscar";
        	this.btt_b_buscar.UseVisualStyleBackColor = true;
        	this.btt_b_buscar.Click += new System.EventHandler(this.btt_b_buscar_Click);
        	// 
        	// panel1
        	// 
        	this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.panel1.Location = new System.Drawing.Point(99, 15);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(579, 123);
        	this.panel1.TabIndex = 29;
        	// 
        	// dgv_ctes
        	// 
        	this.dgv_ctes.BackgroundColor = System.Drawing.Color.LightSteelBlue;
        	this.dgv_ctes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgv_ctes.Location = new System.Drawing.Point(12, 144);
        	this.dgv_ctes.Name = "dgv_ctes";
        	this.dgv_ctes.Size = new System.Drawing.Size(753, 349);
        	this.dgv_ctes.TabIndex = 30;
        	// 
        	// btt_b_aceptar
        	// 
        	this.btt_b_aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.btt_b_aceptar.Location = new System.Drawing.Point(12, 499);
        	this.btt_b_aceptar.Name = "btt_b_aceptar";
        	this.btt_b_aceptar.Size = new System.Drawing.Size(99, 34);
        	this.btt_b_aceptar.TabIndex = 31;
        	this.btt_b_aceptar.Text = "Aceptar";
        	this.btt_b_aceptar.UseVisualStyleBackColor = true;
        	this.btt_b_aceptar.Click += new System.EventHandler(this.btt_b_aceptar_Click);
        	// 
        	// btt_b_cancelar
        	// 
        	this.btt_b_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.btt_b_cancelar.Location = new System.Drawing.Point(666, 499);
        	this.btt_b_cancelar.Name = "btt_b_cancelar";
        	this.btt_b_cancelar.Size = new System.Drawing.Size(99, 34);
        	this.btt_b_cancelar.TabIndex = 32;
        	this.btt_b_cancelar.Text = "Cancelar";
        	this.btt_b_cancelar.UseVisualStyleBackColor = true;
        	this.btt_b_cancelar.Click += new System.EventHandler(this.btt_b_cancelar_Click);
        	// 
        	// Frm_busca_cte
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(784, 562);
        	this.Controls.Add(this.btt_b_cancelar);
        	this.Controls.Add(this.btt_b_aceptar);
        	this.Controls.Add(this.dgv_ctes);
        	this.Controls.Add(this.btt_b_buscar);
        	this.Controls.Add(this.gb_b_t_cte);
        	this.Controls.Add(this.tb_b_docu);
        	this.Controls.Add(this.lb_b_docu);
        	this.Controls.Add(this.tb_b_nombre);
        	this.Controls.Add(this.lb_b_nombre);
        	this.Controls.Add(this.panel1);
        	this.MaximumSize = new System.Drawing.Size(800, 600);
        	this.MinimumSize = new System.Drawing.Size(800, 600);
        	this.Name = "Frm_busca_cte";
        	this.Text = "Buscador de Clientes";
        	this.gb_b_t_cte.ResumeLayout(false);
        	this.gb_b_t_cte.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgv_ctes)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lb_b_nombre;
        private System.Windows.Forms.TextBox tb_b_nombre;
        private System.Windows.Forms.Label lb_b_docu;
        private System.Windows.Forms.TextBox tb_b_docu;
        private System.Windows.Forms.GroupBox gb_b_t_cte;
        private System.Windows.Forms.RadioButton rb_titular;
        private System.Windows.Forms.RadioButton rb_cte;
        private System.Windows.Forms.Button btt_b_buscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_ctes;
        private System.Windows.Forms.Button btt_b_aceptar;
        private System.Windows.Forms.Button btt_b_cancelar;
    }
}