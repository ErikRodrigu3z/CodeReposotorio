namespace CodeRepositorio
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBorrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGuardar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuActualizar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.lenguajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtAgrLenguaje = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.modificarLenguajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtIdLenguaje = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtIdCodigo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(12, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(397, 578);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(415, 90);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCodigo.Size = new System.Drawing.Size(490, 542);
            this.txtCodigo.TabIndex = 2;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(412, 74);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 5;
            this.lblCodigo.Text = "Codigo";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBuscar,
            this.menuCopiar,
            this.menuBorrar,
            this.menuGuardar,
            this.menuActualizar,
            this.menuAgregar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuBuscar
            // 
            this.menuBuscar.Name = "menuBuscar";
            this.menuBuscar.Size = new System.Drawing.Size(54, 20);
            this.menuBuscar.Text = "&Buscar";
            this.menuBuscar.Click += new System.EventHandler(this.buscarToolStripMenuItem_Click);
            // 
            // menuCopiar
            // 
            this.menuCopiar.Name = "menuCopiar";
            this.menuCopiar.Size = new System.Drawing.Size(54, 20);
            this.menuCopiar.Text = "&Copiar";
            this.menuCopiar.Click += new System.EventHandler(this.menuCopiar_Click);
            // 
            // menuBorrar
            // 
            this.menuBorrar.Name = "menuBorrar";
            this.menuBorrar.Size = new System.Drawing.Size(59, 20);
            this.menuBorrar.Text = "&Limpiar";
            this.menuBorrar.Click += new System.EventHandler(this.borrarToolStripMenuItem_Click);
            // 
            // menuGuardar
            // 
            this.menuGuardar.Name = "menuGuardar";
            this.menuGuardar.Size = new System.Drawing.Size(61, 20);
            this.menuGuardar.Text = "&Guardar";
            this.menuGuardar.Click += new System.EventHandler(this.menuGuardar_Click);
            // 
            // menuActualizar
            // 
            this.menuActualizar.Name = "menuActualizar";
            this.menuActualizar.Size = new System.Drawing.Size(71, 20);
            this.menuActualizar.Text = "&Actualizar";
            this.menuActualizar.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // menuAgregar
            // 
            this.menuAgregar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lenguajeToolStripMenuItem,
            this.modificarLenguajeToolStripMenuItem});
            this.menuAgregar.Name = "menuAgregar";
            this.menuAgregar.Size = new System.Drawing.Size(61, 20);
            this.menuAgregar.Text = "Agregar";
            // 
            // lenguajeToolStripMenuItem
            // 
            this.lenguajeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lenguajeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.txtAgrLenguaje,
            this.toolStripSeparator2});
            this.lenguajeToolStripMenuItem.Name = "lenguajeToolStripMenuItem";
            this.lenguajeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.lenguajeToolStripMenuItem.Text = "Lenguaje";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // txtAgrLenguaje
            // 
            this.txtAgrLenguaje.BackColor = System.Drawing.Color.Gainsboro;
            this.txtAgrLenguaje.Name = "txtAgrLenguaje";
            this.txtAgrLenguaje.Size = new System.Drawing.Size(150, 23);
            this.txtAgrLenguaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgrLenguaje_KeyPress);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // modificarLenguajeToolStripMenuItem
            // 
            this.modificarLenguajeToolStripMenuItem.Name = "modificarLenguajeToolStripMenuItem";
            this.modificarLenguajeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.modificarLenguajeToolStripMenuItem.Text = "Modificar Lenguaje";
            this.modificarLenguajeToolStripMenuItem.Click += new System.EventHandler(this.modificarLenguajeToolStripMenuItem_Click);
            // 
            // txtIdLenguaje
            // 
            this.txtIdLenguaje.Location = new System.Drawing.Point(533, 29);
            this.txtIdLenguaje.Name = "txtIdLenguaje";
            this.txtIdLenguaje.Size = new System.Drawing.Size(43, 20);
            this.txtIdLenguaje.TabIndex = 29;
            this.txtIdLenguaje.Visible = false;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(415, 53);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(490, 20);
            this.txtTitulo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(412, 37);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(33, 13);
            this.lblTitulo.TabIndex = 31;
            this.lblTitulo.Text = "Titulo";
            // 
            // txtIdCodigo
            // 
            this.txtIdCodigo.Location = new System.Drawing.Point(582, 29);
            this.txtIdCodigo.Name = "txtIdCodigo";
            this.txtIdCodigo.Size = new System.Drawing.Size(43, 20);
            this.txtIdCodigo.TabIndex = 32;
            this.txtIdCodigo.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(931, 650);
            this.Controls.Add(this.txtIdCodigo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtIdLenguaje);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing_1);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuGuardar;
        private System.Windows.Forms.ToolStripMenuItem menuActualizar;
        private System.Windows.Forms.ToolStripMenuItem menuCopiar;
        private System.Windows.Forms.ToolStripMenuItem menuBorrar;
        private System.Windows.Forms.ToolStripMenuItem menuAgregar;
        private System.Windows.Forms.ToolStripMenuItem lenguajeToolStripMenuItem;
        private System.Windows.Forms.TextBox txtIdLenguaje;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox txtAgrLenguaje;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtIdCodigo;
        private System.Windows.Forms.ToolStripMenuItem menuBuscar;
        private System.Windows.Forms.ToolStripMenuItem modificarLenguajeToolStripMenuItem;
    }
}

