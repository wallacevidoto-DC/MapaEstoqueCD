namespace MapaEstoqueCD.View.Modal
{
    partial class TransferenciaProduto
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
            textBox_atualx = new TextBox();
            groupBox1 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            groupBox2 = new GroupBox();
            button_bucar_end = new Button();
            groupBox5 = new GroupBox();
            comboBox_apt = new ComboBox();
            groupBox4 = new GroupBox();
            comboBox_bloco = new ComboBox();
            groupBox3 = new GroupBox();
            comboBox_rua = new ComboBox();
            groupBox7 = new GroupBox();
            richTextBox_obs = new RichTextBox();
            button_salvar = new Button();
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
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_produtos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Segoe UI", 13F);
            textBox1.Location = new Point(408, 19);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(281, 31);
            textBox1.TabIndex = 1;
            textBox1.Text = "TRANSFERÊNCIA DE MERCADORIA";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_atualx
            // 
            textBox_atualx.Dock = DockStyle.Fill;
            textBox_atualx.Font = new Font("Segoe UI", 14F);
            textBox_atualx.Location = new Point(3, 19);
            textBox_atualx.Name = "textBox_atualx";
            textBox_atualx.ReadOnly = true;
            textBox_atualx.Size = new Size(686, 32);
            textBox_atualx.TabIndex = 2;
            textBox_atualx.Text = "ENDEREÇO ATUAL : A11";
            textBox_atualx.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Location = new Point(12, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(692, 60);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informação";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Dock = DockStyle.Left;
            dateTimePicker1.Font = new Font("Segoe UI", 15F);
            dateTimePicker1.Location = new Point(3, 19);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(405, 34);
            dateTimePicker1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button_bucar_end);
            groupBox2.Controls.Add(textBox_atualx);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(12, 70);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(692, 143);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Localização";
            // 
            // button_bucar_end
            // 
            button_bucar_end.Cursor = Cursors.Hand;
            button_bucar_end.FlatAppearance.BorderSize = 0;
            button_bucar_end.FlatStyle = FlatStyle.Flat;
            button_bucar_end.Image = Properties.Resources.busca;
            button_bucar_end.Location = new Point(507, 64);
            button_bucar_end.Name = "button_bucar_end";
            button_bucar_end.Size = new Size(75, 76);
            button_bucar_end.TabIndex = 11;
            button_bucar_end.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(comboBox_apt);
            groupBox5.Location = new Point(377, 68);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(75, 60);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "APT";
            // 
            // comboBox_apt
            // 
            comboBox_apt.Dock = DockStyle.Fill;
            comboBox_apt.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_apt.Font = new Font("Segoe UI", 15F);
            comboBox_apt.FormattingEnabled = true;
            comboBox_apt.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_apt.Location = new Point(3, 19);
            comboBox_apt.Name = "comboBox_apt";
            comboBox_apt.Size = new Size(69, 36);
            comboBox_apt.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBox_bloco);
            groupBox4.Location = new Point(245, 68);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(75, 60);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "BLOCO";
            // 
            // comboBox_bloco
            // 
            comboBox_bloco.Dock = DockStyle.Fill;
            comboBox_bloco.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_bloco.Font = new Font("Segoe UI", 15F);
            comboBox_bloco.FormattingEnabled = true;
            comboBox_bloco.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox_bloco.Location = new Point(3, 19);
            comboBox_bloco.Name = "comboBox_bloco";
            comboBox_bloco.Size = new Size(69, 36);
            comboBox_bloco.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBox_rua);
            groupBox3.Location = new Point(113, 68);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(75, 60);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "RUA";
            // 
            // comboBox_rua
            // 
            comboBox_rua.Dock = DockStyle.Fill;
            comboBox_rua.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_rua.Font = new Font("Segoe UI", 15F);
            comboBox_rua.FormattingEnabled = true;
            comboBox_rua.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "M", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
            comboBox_rua.Location = new Point(3, 19);
            comboBox_rua.Name = "comboBox_rua";
            comboBox_rua.Size = new Size(69, 36);
            comboBox_rua.TabIndex = 0;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(richTextBox_obs);
            groupBox7.Location = new Point(12, 487);
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
            button_salvar.Location = new Point(601, 590);
            button_salvar.Name = "button_salvar";
            button_salvar.Size = new Size(103, 101);
            button_salvar.TabIndex = 7;
            button_salvar.Text = "Salvar";
            button_salvar.TextAlign = ContentAlignment.BottomCenter;
            button_salvar.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dataGridView_produtos);
            groupBox6.Controls.Add(panel1);
            groupBox6.Location = new Point(12, 216);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(692, 274);
            groupBox6.TabIndex = 8;
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
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 10);
            label1.Name = "label1";
            label1.Size = new Size(216, 15);
            label1.TabIndex = 10;
            label1.Text = "PRODUTOS EXISTENTES NO ENDEREÇO";
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
            // 
            // TransferenciaProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(716, 689);
            Controls.Add(groupBox6);
            Controls.Add(button_salvar);
            Controls.Add(groupBox7);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TransferenciaProduto";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nova Tranferência";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_produtos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox2;
        private GroupBox groupBox7;
        private RichTextBox richTextBox_obs;
        private Button button_salvar;
        private Button button_bucar_end;
        private GroupBox groupBox5;
        private ComboBox comboBox_apt;
        private GroupBox groupBox4;
        private ComboBox comboBox_bloco;
        private GroupBox groupBox3;
        private ComboBox comboBox_rua;
        private GroupBox groupBox6;
        private DataGridView dataGridView_produtos;
        private DataGridViewTextBoxColumn idIndex;
        private DataGridViewTextBoxColumn cod;
        private DataGridViewTextBoxColumn dec;
        private DataGridViewTextBoxColumn Qtd;
        private DataGridViewTextBoxColumn detaf;
        private DataGridViewTextBoxColumn semf;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewButtonColumn acao;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel panel3;
        private Panel panel2;
        private Button button_addProd;
        private TextBox textBox_atualx;
    }
}