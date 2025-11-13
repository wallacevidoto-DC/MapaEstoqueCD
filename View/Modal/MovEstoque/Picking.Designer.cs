namespace MapaEstoqueCD.View.Modal
{
    partial class Picking
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
            TextBox textBox1;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dateTimePicker_dataEntrada = new DateTimePicker();
            groupBox6 = new GroupBox();
            dataGridView_produtos = new DataGridView();
            idIndex = new DataGridViewTextBoxColumn();
            cod = new DataGridViewTextBoxColumn();
            dec = new DataGridViewTextBoxColumn();
            Qtd = new DataGridViewTextBoxColumn();
            detaf = new DataGridViewTextBoxColumn();
            semf = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            acao = new DataGridViewButtonColumn();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            button_addProd = new Button();
            groupBox7 = new GroupBox();
            richTextBox_obs = new RichTextBox();
            button_salvar = new Button();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_produtos).BeginInit();
            panel1.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Segoe UI", 15F);
            textBox1.Location = new Point(408, 19);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(281, 34);
            textBox1.TabIndex = 1;
            textBox1.Text = "PICKING DE MERCADORIA";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(dateTimePicker_dataEntrada);
            groupBox1.Location = new Point(12, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(692, 60);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informação";
            // 
            // dateTimePicker_dataEntrada
            // 
            dateTimePicker_dataEntrada.Dock = DockStyle.Left;
            dateTimePicker_dataEntrada.Font = new Font("Segoe UI", 15F);
            dateTimePicker_dataEntrada.Location = new Point(3, 19);
            dateTimePicker_dataEntrada.Name = "dateTimePicker_dataEntrada";
            dateTimePicker_dataEntrada.Size = new Size(405, 34);
            dateTimePicker_dataEntrada.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dataGridView_produtos);
            groupBox6.Controls.Add(panel1);
            groupBox6.Location = new Point(12, 72);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(692, 274);
            groupBox6.TabIndex = 2;
            groupBox6.TabStop = false;
            groupBox6.Text = "Dados do Produto";
            // 
            // dataGridView_produtos
            // 
            dataGridView_produtos.AllowUserToAddRows = false;
            dataGridView_produtos.AllowUserToDeleteRows = false;
            dataGridView_produtos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_produtos.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView_produtos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(50, 50, 70);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView_produtos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView_produtos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_produtos.Columns.AddRange(new DataGridViewColumn[] { idIndex, cod, dec, Qtd, detaf, semf, Column1, acao });
            dataGridView_produtos.Dock = DockStyle.Fill;
            dataGridView_produtos.EnableHeadersVisualStyles = false;
            dataGridView_produtos.GridColor = Color.DarkGray;
            dataGridView_produtos.Location = new Point(3, 19);
            dataGridView_produtos.MultiSelect = false;
            dataGridView_produtos.Name = "dataGridView_produtos";
            dataGridView_produtos.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView_produtos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView_produtos.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_produtos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView_produtos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_produtos.Size = new Size(686, 188);
            dataGridView_produtos.TabIndex = 1;
            dataGridView_produtos.CellContentClick += dataGridView_produtos_CellContentClick;
            // 
            // idIndex
            // 
            idIndex.HeaderText = "idIndex";
            idIndex.Name = "idIndex";
            idIndex.ReadOnly = true;
            idIndex.Visible = false;
            // 
            // cod
            // 
            cod.FillWeight = 20F;
            cod.HeaderText = "Código";
            cod.Name = "cod";
            cod.ReadOnly = true;
            // 
            // dec
            // 
            dec.HeaderText = "Descrição";
            dec.Name = "dec";
            dec.ReadOnly = true;
            // 
            // Qtd
            // 
            Qtd.FillWeight = 15F;
            Qtd.HeaderText = "Qtd";
            Qtd.Name = "Qtd";
            Qtd.ReadOnly = true;
            // 
            // detaf
            // 
            detaf.FillWeight = 25F;
            detaf.HeaderText = "Data Fab";
            detaf.Name = "detaf";
            detaf.ReadOnly = true;
            // 
            // semf
            // 
            semf.FillWeight = 25F;
            semf.HeaderText = "Sem. Fab";
            semf.Name = "semf";
            semf.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.FillWeight = 20F;
            Column1.HeaderText = "Lote";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // acao
            // 
            acao.FillWeight = 10F;
            acao.HeaderText = "";
            acao.Name = "acao";
            acao.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button_addProd);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 207);
            panel1.Name = "panel1";
            panel1.Size = new Size(686, 64);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 40);
            label2.Name = "label2";
            label2.Size = new Size(134, 15);
            label2.TabIndex = 10;
            label2.Text = "PRODUTO A REGISTRAR";
            label2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 10);
            label1.Name = "label1";
            label1.Size = new Size(216, 15);
            label1.TabIndex = 10;
            label1.Text = "PRODUTOS EXISTENTES NO ENDEREÇO";
            label1.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(204, 229, 255);
            panel3.Location = new Point(3, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(23, 23);
            panel3.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(204, 255, 204);
            panel2.Location = new Point(3, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(23, 23);
            panel2.TabIndex = 9;
            // 
            // button_addProd
            // 
            button_addProd.Cursor = Cursors.Hand;
            button_addProd.FlatAppearance.BorderSize = 0;
            button_addProd.FlatStyle = FlatStyle.Flat;
            button_addProd.Image = Properties.Resources.caixa;
            button_addProd.Location = new Point(619, 3);
            button_addProd.Name = "button_addProd";
            button_addProd.Size = new Size(64, 58);
            button_addProd.TabIndex = 8;
            button_addProd.TextAlign = ContentAlignment.BottomCenter;
            button_addProd.UseVisualStyleBackColor = true;
            button_addProd.Click += button_addProd_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(richTextBox_obs);
            groupBox7.Location = new Point(12, 352);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(692, 100);
            groupBox7.TabIndex = 3;
            groupBox7.TabStop = false;
            groupBox7.Text = "Observação";
            // 
            // richTextBox_obs
            // 
            richTextBox_obs.Dock = DockStyle.Fill;
            richTextBox_obs.Location = new Point(3, 19);
            richTextBox_obs.Name = "richTextBox_obs";
            richTextBox_obs.Size = new Size(686, 78);
            richTextBox_obs.TabIndex = 0;
            richTextBox_obs.Text = "";
            // 
            // button_salvar
            // 
            button_salvar.Cursor = Cursors.Hand;
            button_salvar.FlatAppearance.BorderSize = 0;
            button_salvar.FlatStyle = FlatStyle.Flat;
            button_salvar.Image = Properties.Resources.salve;
            button_salvar.Location = new Point(601, 451);
            button_salvar.Name = "button_salvar";
            button_salvar.Size = new Size(103, 103);
            button_salvar.TabIndex = 7;
            button_salvar.Text = "Salvar";
            button_salvar.TextAlign = ContentAlignment.BottomCenter;
            button_salvar.UseVisualStyleBackColor = true;
            button_salvar.Click += button_salvar_Click;
            // 
            // Picking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(716, 560);
            Controls.Add(button_salvar);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Picking";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Novo Picking";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_produtos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker_dataEntrada;
        private GroupBox groupBox6;
        private DataGridView dataGridView_produtos;
        private Panel panel1;
        private GroupBox groupBox7;
        private RichTextBox richTextBox_obs;
        private Button button_salvar;
        private Button button_addProd;
        private Label label1;
        private Panel panel3;
        private Panel panel2;
        private Label label2;
        private DataGridViewTextBoxColumn idIndex;
        private DataGridViewTextBoxColumn cod;
        private DataGridViewTextBoxColumn dec;
        private DataGridViewTextBoxColumn Qtd;
        private DataGridViewTextBoxColumn detaf;
        private DataGridViewTextBoxColumn semf;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewButtonColumn acao;
    }
}