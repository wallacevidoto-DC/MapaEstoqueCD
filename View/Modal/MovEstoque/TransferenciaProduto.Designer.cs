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
            TextBox textBox2;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            groupBox2 = new GroupBox();
            button1 = new Button();
            groupBox5 = new GroupBox();
            comboBox3 = new ComboBox();
            groupBox4 = new GroupBox();
            comboBox2 = new ComboBox();
            groupBox3 = new GroupBox();
            comboBox1 = new ComboBox();
            groupBox6 = new GroupBox();
            dataGridView1 = new DataGridView();
            cod = new DataGridViewTextBoxColumn();
            dec = new DataGridViewTextBoxColumn();
            Qtd = new DataGridViewTextBoxColumn();
            detaf = new DataGridViewTextBoxColumn();
            semf = new DataGridViewTextBoxColumn();
            groupBox7 = new GroupBox();
            richTextBox1 = new RichTextBox();
            button_salvar = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(408, 19);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(281, 32);
            textBox1.TabIndex = 1;
            textBox1.Text = "TRANSFERÊNCIA DE MERCADORIA";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("Segoe UI", 14F);
            textBox2.Location = new Point(3, 19);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(686, 32);
            textBox2.TabIndex = 2;
            textBox2.Text = "ENDEREÇO ATUAL : A11";
            textBox2.TextAlign = HorizontalAlignment.Center;
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
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(button1);
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
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.busca;
            button1.Location = new Point(520, 61);
            button1.Name = "button1";
            button1.Size = new Size(75, 76);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(comboBox3);
            groupBox5.Location = new Point(390, 69);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(75, 60);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "APT";
            // 
            // comboBox3
            // 
            comboBox3.Dock = DockStyle.Fill;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Font = new Font("Segoe UI", 15F);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox3.Location = new Point(3, 19);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(69, 36);
            comboBox3.TabIndex = 1;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(comboBox2);
            groupBox4.Location = new Point(258, 69);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(75, 60);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "BLOCO";
            // 
            // comboBox2
            // 
            comboBox2.Dock = DockStyle.Fill;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Segoe UI", 15F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox2.Location = new Point(3, 19);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(69, 36);
            comboBox2.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Location = new Point(126, 65);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(75, 60);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "RUA";
            // 
            // comboBox1
            // 
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 15F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "M", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
            comboBox1.Location = new Point(3, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(69, 36);
            comboBox1.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(dataGridView1);
            groupBox6.Location = new Point(12, 213);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(692, 274);
            groupBox6.TabIndex = 2;
            groupBox6.TabStop = false;
            groupBox6.Text = "Dados do Produto";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { cod, dec, Qtd, detaf, semf });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.Gainsboro;
            dataGridView1.Location = new Point(3, 19);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(686, 252);
            dataGridView1.TabIndex = 1;
            // 
            // cod
            // 
            cod.FillWeight = 50F;
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
            Qtd.FillWeight = 50F;
            Qtd.HeaderText = "Qtd";
            Qtd.Name = "Qtd";
            Qtd.ReadOnly = true;
            // 
            // detaf
            // 
            detaf.FillWeight = 50F;
            detaf.HeaderText = "Data Fab";
            detaf.Name = "detaf";
            detaf.ReadOnly = true;
            // 
            // semf
            // 
            semf.FillWeight = 50F;
            semf.HeaderText = "Sem. Fab";
            semf.Name = "semf";
            semf.ReadOnly = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(richTextBox1);
            groupBox7.Location = new Point(12, 487);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(692, 100);
            groupBox7.TabIndex = 3;
            groupBox7.TabStop = false;
            groupBox7.Text = "Observação";
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 19);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(686, 78);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
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
            // TransferenciaProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(716, 689);
            Controls.Add(button_salvar);
            Controls.Add(groupBox7);
            Controls.Add(groupBox6);
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
            groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker1;
        private GroupBox groupBox2;
        private GroupBox groupBox5;
        private GroupBox groupBox4;
        private ComboBox comboBox2;
        private GroupBox groupBox3;
        private ComboBox comboBox1;
        private Button button1;
        private GroupBox groupBox6;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn cod;
        private DataGridViewTextBoxColumn dec;
        private DataGridViewTextBoxColumn Qtd;
        private DataGridViewTextBoxColumn detaf;
        private DataGridViewTextBoxColumn semf;
        private GroupBox groupBox7;
        private RichTextBox richTextBox1;
        private Button button_salvar;
        private ComboBox comboBox3;
    }
}