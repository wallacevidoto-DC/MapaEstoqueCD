namespace MapaEstoqueCD.View.Modal
{
    partial class AdicionarProduto
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
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            textBox_decricao = new TextBox();
            groupBox3 = new GroupBox();
            textBox_cod = new TextBox();
            button_salvar = new Button();
            groupBox5 = new GroupBox();
            textBox_qtd = new TextBox();
            groupBox7 = new GroupBox();
            textBox_semf = new TextBox();
            groupBox6 = new GroupBox();
            maskedTextBox_datef = new MaskedTextBox();
            groupBox8 = new GroupBox();
            textBox_lote = new TextBox();
            groupBox2 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 206);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Produto";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox_decricao);
            groupBox4.Location = new Point(6, 128);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(391, 53);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Descrição";
            // 
            // textBox_decricao
            // 
            textBox_decricao.Dock = DockStyle.Fill;
            textBox_decricao.Font = new Font("Segoe UI", 9F);
            textBox_decricao.Location = new Point(3, 19);
            textBox_decricao.Multiline = true;
            textBox_decricao.Name = "textBox_decricao";
            textBox_decricao.ReadOnly = true;
            textBox_decricao.Size = new Size(385, 31);
            textBox_decricao.TabIndex = 0;
            textBox_decricao.Text = "Gelelé Slime Pote 180g 1x24 Hot Wheels";
            textBox_decricao.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox_cod);
            groupBox3.Location = new Point(6, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(391, 100);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Código do produto";
            // 
            // textBox_cod
            // 
            textBox_cod.Dock = DockStyle.Fill;
            textBox_cod.Font = new Font("Segoe UI", 40F);
            textBox_cod.Location = new Point(3, 19);
            textBox_cod.Multiline = true;
            textBox_cod.Name = "textBox_cod";
            textBox_cod.Size = new Size(385, 78);
            textBox_cod.TabIndex = 0;
            textBox_cod.Text = "999999";
            textBox_cod.TextAlign = HorizontalAlignment.Center;
            textBox_cod.KeyPress += textBox_cod_KeyPress;
            // 
            // button_salvar
            // 
            button_salvar.Cursor = Cursors.Hand;
            button_salvar.FlatAppearance.BorderSize = 0;
            button_salvar.FlatStyle = FlatStyle.Flat;
            button_salvar.Image = Properties.Resources.salve;
            button_salvar.Location = new Point(303, 355);
            button_salvar.Name = "button_salvar";
            button_salvar.Size = new Size(103, 103);
            button_salvar.TabIndex = 2;
            button_salvar.Text = "Salvar";
            button_salvar.TextAlign = ContentAlignment.BottomCenter;
            button_salvar.UseVisualStyleBackColor = true;
            button_salvar.Click += button_salvar_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBox_qtd);
            groupBox5.Location = new Point(62, 22);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(133, 53);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Quantidade";
            // 
            // textBox_qtd
            // 
            textBox_qtd.Dock = DockStyle.Fill;
            textBox_qtd.Font = new Font("Segoe UI", 15F);
            textBox_qtd.Location = new Point(3, 19);
            textBox_qtd.Multiline = true;
            textBox_qtd.Name = "textBox_qtd";
            textBox_qtd.Size = new Size(127, 31);
            textBox_qtd.TabIndex = 0;
            textBox_qtd.Text = "12312";
            textBox_qtd.TextAlign = HorizontalAlignment.Center;
            textBox_qtd.KeyPress += OnlyNumber;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(textBox_semf);
            groupBox7.Location = new Point(62, 81);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(133, 53);
            groupBox7.TabIndex = 2;
            groupBox7.TabStop = false;
            groupBox7.Text = "Semana Fab";
            // 
            // textBox_semf
            // 
            textBox_semf.Dock = DockStyle.Fill;
            textBox_semf.Font = new Font("Segoe UI", 15F);
            textBox_semf.Location = new Point(3, 19);
            textBox_semf.Multiline = true;
            textBox_semf.Name = "textBox_semf";
            textBox_semf.Size = new Size(127, 31);
            textBox_semf.TabIndex = 0;
            textBox_semf.TextAlign = HorizontalAlignment.Center;
            textBox_semf.KeyPress += OnlyNumber;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(maskedTextBox_datef);
            groupBox6.Location = new Point(201, 22);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(133, 53);
            groupBox6.TabIndex = 1;
            groupBox6.TabStop = false;
            groupBox6.Text = "Data Fab. (MM/YY)";
            // 
            // maskedTextBox_datef
            // 
            maskedTextBox_datef.Dock = DockStyle.Fill;
            maskedTextBox_datef.Font = new Font("Segoe UI", 15F);
            maskedTextBox_datef.Location = new Point(3, 19);
            maskedTextBox_datef.Mask = "00/00";
            maskedTextBox_datef.Name = "maskedTextBox_datef";
            maskedTextBox_datef.PromptChar = '0';
            maskedTextBox_datef.Size = new Size(127, 34);
            maskedTextBox_datef.TabIndex = 0;
            maskedTextBox_datef.TextAlign = HorizontalAlignment.Center;
            maskedTextBox_datef.Leave += maskedTextBox_datef_Leave;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(textBox_lote);
            groupBox8.Location = new Point(201, 81);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(133, 53);
            groupBox8.TabIndex = 3;
            groupBox8.TabStop = false;
            groupBox8.Text = "Lote";
            // 
            // textBox_lote
            // 
            textBox_lote.Dock = DockStyle.Fill;
            textBox_lote.Font = new Font("Segoe UI", 15F);
            textBox_lote.Location = new Point(3, 19);
            textBox_lote.Multiline = true;
            textBox_lote.Name = "textBox_lote";
            textBox_lote.Size = new Size(127, 31);
            textBox_lote.TabIndex = 0;
            textBox_lote.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox8);
            groupBox2.Controls.Add(groupBox6);
            groupBox2.Controls.Add(groupBox7);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Location = new Point(12, 207);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(403, 142);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informações";
            // 
            // AdicionarProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(427, 467);
            Controls.Add(button_salvar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdicionarProduto";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adicionar Produto";
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private TextBox textBox_decricao;
        private GroupBox groupBox3;
        private TextBox textBox_cod;
        private Button button_salvar;
        private GroupBox groupBox5;
        private TextBox textBox_qtd;
        private GroupBox groupBox7;
        private TextBox textBox_semf;
        private GroupBox groupBox6;
        private MaskedTextBox maskedTextBox_datef;
        private GroupBox groupBox8;
        private TextBox textBox_lote;
        private GroupBox groupBox2;
    }
}