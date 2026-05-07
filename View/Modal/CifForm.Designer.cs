namespace MapaEstoqueCD.View.Modal
{
    partial class CifForm
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox3 = new GroupBox();
            button_gerar = new Button();
            button_salvar = new Button();
            textBox_cod = new TextBox();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            Column11 = new DataGridViewTextBoxColumn();
            COD = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editarToolStripMenuItem = new ToolStripMenuItem();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button_gerar);
            groupBox3.Controls.Add(button_salvar);
            groupBox3.Controls.Add(textBox_cod);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(391, 100);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Código da CIF";
            // 
            // button_gerar
            // 
            button_gerar.Cursor = Cursors.Hand;
            button_gerar.Dock = DockStyle.Right;
            button_gerar.FlatAppearance.BorderSize = 0;
            button_gerar.FlatStyle = FlatStyle.Flat;
            button_gerar.Image = Properties.Resources.gerenciar1;
            button_gerar.Location = new Point(240, 19);
            button_gerar.Name = "button_gerar";
            button_gerar.Size = new Size(74, 78);
            button_gerar.TabIndex = 6;
            button_gerar.TextAlign = ContentAlignment.BottomCenter;
            button_gerar.UseVisualStyleBackColor = true;
            button_gerar.Click += button_gerar_Click;
            // 
            // button_salvar
            // 
            button_salvar.Cursor = Cursors.Hand;
            button_salvar.Dock = DockStyle.Right;
            button_salvar.FlatAppearance.BorderSize = 0;
            button_salvar.FlatStyle = FlatStyle.Flat;
            button_salvar.Image = Properties.Resources.adicionar_ficheiro;
            button_salvar.Location = new Point(314, 19);
            button_salvar.Name = "button_salvar";
            button_salvar.Size = new Size(74, 78);
            button_salvar.TabIndex = 7;
            button_salvar.TextAlign = ContentAlignment.BottomCenter;
            button_salvar.UseVisualStyleBackColor = true;
            button_salvar.Click += button_salvar_Click;
            // 
            // textBox_cod
            // 
            textBox_cod.BackColor = Color.White;
            textBox_cod.Dock = DockStyle.Left;
            textBox_cod.Font = new Font("Segoe UI", 40F);
            textBox_cod.Location = new Point(3, 19);
            textBox_cod.Name = "textBox_cod";
            textBox_cod.Size = new Size(231, 78);
            textBox_cod.TabIndex = 0;
            textBox_cod.Text = "999999";
            textBox_cod.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Location = new Point(12, 118);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(391, 546);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lista de CIF";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonFace;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(50, 50, 70);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column11, COD, Date });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = SystemColors.ScrollBar;
            dataGridView1.Location = new Point(3, 19);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(385, 524);
            dataGridView1.TabIndex = 7;
            // 
            // Column11
            // 
            Column11.HeaderText = "xIndex";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Visible = false;
            // 
            // COD
            // 
            COD.FillWeight = 50F;
            COD.HeaderText = "COD";
            COD.Name = "COD";
            COD.ReadOnly = true;
            // 
            // Date
            // 
            Date.HeaderText = "DATA";
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(25, 25);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(114, 36);
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Image = Properties.Resources.editar_codigo;
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(113, 32);
            editarToolStripMenuItem.Text = "Editar";
            editarToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            // 
            // CifForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(415, 676);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CifForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciamento de CIF";
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private TextBox textBox_cod;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button button_gerar;
        private Button button_salvar;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn COD;
        private DataGridViewTextBoxColumn Date;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editarToolStripMenuItem;
    }
}