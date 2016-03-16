namespace Cab_Lin
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.btt_consultar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_cte = new System.Windows.Forms.TextBox();
            this.btt_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_base = new System.Windows.Forms.TextBox();
            this.n_cte = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dat_f_fra = new System.Windows.Forms.DateTimePicker();
            this.tb_n_fra = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_tasas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_iva = new System.Windows.Forms.TextBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.btt_del = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btt_save = new System.Windows.Forms.Button();
            this.btt_new = new System.Windows.Forms.Button();
            this.dgv_lf = new System.Windows.Forms.DataGridView();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // btt_consultar
            // 
            this.btt_consultar.Location = new System.Drawing.Point(635, 58);
            this.btt_consultar.Name = "btt_consultar";
            this.btt_consultar.Size = new System.Drawing.Size(75, 23);
            this.btt_consultar.TabIndex = 15;
            this.btt_consultar.Text = "Consultar";
            this.btt_consultar.UseVisualStyleBackColor = true;
            this.btt_consultar.Click += new System.EventHandler(this.btt_consultar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(501, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 125);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // tb_cte
            // 
            this.tb_cte.Location = new System.Drawing.Point(103, 108);
            this.tb_cte.Name = "tb_cte";
            this.tb_cte.Size = new System.Drawing.Size(100, 20);
            this.tb_cte.TabIndex = 19;
            // 
            // btt_cancel
            // 
            this.btt_cancel.Location = new System.Drawing.Point(635, 103);
            this.btt_cancel.Name = "btt_cancel";
            this.btt_cancel.Size = new System.Drawing.Size(75, 23);
            this.btt_cancel.TabIndex = 16;
            this.btt_cancel.Text = "Cancelar";
            this.btt_cancel.UseVisualStyleBackColor = true;
            this.btt_cancel.Click += new System.EventHandler(this.btt_cancel_Click_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(43, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Num.Fra.";
            // 
            // tb_base
            // 
            this.tb_base.Location = new System.Drawing.Point(103, 149);
            this.tb_base.Name = "tb_base";
            this.tb_base.Size = new System.Drawing.Size(100, 20);
            this.tb_base.TabIndex = 21;
            // 
            // n_cte
            // 
            this.n_cte.Location = new System.Drawing.Point(220, 65);
            this.n_cte.Name = "n_cte";
            this.n_cte.Size = new System.Drawing.Size(259, 23);
            this.n_cte.TabIndex = 6;
            this.n_cte.Text = "N_Cliente";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(43, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Base";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(43, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Cliente";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(324, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tasas";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(245, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha";
            // 
            // dat_f_fra
            // 
            this.dat_f_fra.Location = new System.Drawing.Point(309, 66);
            this.dat_f_fra.Name = "dat_f_fra";
            this.dat_f_fra.Size = new System.Drawing.Size(200, 20);
            this.dat_f_fra.TabIndex = 16;
            // 
            // tb_n_fra
            // 
            this.tb_n_fra.Location = new System.Drawing.Point(103, 70);
            this.tb_n_fra.Name = "tb_n_fra";
            this.tb_n_fra.Size = new System.Drawing.Size(100, 20);
            this.tb_n_fra.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btt_cancel);
            this.groupBox1.Controls.Add(this.btt_consultar);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.n_cte);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_tasas);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_iva);
            this.groupBox1.Location = new System.Drawing.Point(25, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 150);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabecera Fra.";
            // 
            // tb_tasas
            // 
            this.tb_tasas.Location = new System.Drawing.Point(379, 106);
            this.tb_tasas.Name = "tb_tasas";
            this.tb_tasas.Size = new System.Drawing.Size(100, 20);
            this.tb_tasas.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(220, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "P.Iva";
            // 
            // tb_iva
            // 
            this.tb_iva.Location = new System.Drawing.Point(280, 106);
            this.tb_iva.Name = "tb_iva";
            this.tb_iva.Size = new System.Drawing.Size(38, 20);
            this.tb_iva.TabIndex = 10;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.delete,
            this.save});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(771, 25);
            this.bindingNavigator1.TabIndex = 23;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(38, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // save
            // 
            this.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.save.Image = global::Cab_Lin.Properties.Resources.Rectangle_Green;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(23, 22);
            this.save.Text = "toolStripButton1";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // delete
            // 
            this.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delete.Image = global::Cab_Lin.Properties.Resources.Delete;
            this.delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.Text = "delete";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // btt_del
            // 
            this.btt_del.Location = new System.Drawing.Point(618, 194);
            this.btt_del.Name = "btt_del";
            this.btt_del.Size = new System.Drawing.Size(75, 23);
            this.btt_del.TabIndex = 18;
            this.btt_del.Text = "Borrar";
            this.btt_del.UseVisualStyleBackColor = true;
            this.btt_del.Click += new System.EventHandler(this.btt_del_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btt_del);
            this.groupBox2.Controls.Add(this.btt_save);
            this.groupBox2.Controls.Add(this.btt_new);
            this.groupBox2.Controls.Add(this.dgv_lf);
            this.groupBox2.Location = new System.Drawing.Point(25, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(716, 249);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle Fra.";
            // 
            // btt_save
            // 
            this.btt_save.Location = new System.Drawing.Point(532, 194);
            this.btt_save.Name = "btt_save";
            this.btt_save.Size = new System.Drawing.Size(75, 23);
            this.btt_save.TabIndex = 17;
            this.btt_save.Text = "Guardar";
            this.btt_save.UseVisualStyleBackColor = true;
            this.btt_save.Click += new System.EventHandler(this.btt_save_Click_1);
            // 
            // btt_new
            // 
            this.btt_new.Location = new System.Drawing.Point(439, 194);
            this.btt_new.Name = "btt_new";
            this.btt_new.Size = new System.Drawing.Size(75, 23);
            this.btt_new.TabIndex = 16;
            this.btt_new.Text = "Alta/Edit";
            this.btt_new.UseVisualStyleBackColor = true;
            this.btt_new.Click += new System.EventHandler(this.btt_new_Click_1);
            // 
            // dgv_lf
            // 
            this.dgv_lf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lf.Location = new System.Drawing.Point(21, 28);
            this.dgv_lf.Name = "dgv_lf";
            this.dgv_lf.Size = new System.Drawing.Size(672, 160);
            this.dgv_lf.TabIndex = 15;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 452);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.tb_cte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_base);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dat_f_fra);
            this.Controls.Add(this.tb_n_fra);
            this.Controls.Add(this.groupBox1);
            this.Name = "Principal";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btt_consultar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_cte;
        private System.Windows.Forms.Button btt_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_base;
        private System.Windows.Forms.Label n_cte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dat_f_fra;
        private System.Windows.Forms.TextBox tb_n_fra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_tasas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_iva;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.Button btt_del;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btt_save;
        private System.Windows.Forms.Button btt_new;
        private System.Windows.Forms.DataGridView dgv_lf;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.ToolStripButton delete;
    }
}