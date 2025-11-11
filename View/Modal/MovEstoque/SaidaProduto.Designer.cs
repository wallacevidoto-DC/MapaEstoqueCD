namespace MapaEstoqueCD.View.Modal
{
    partial class SaidaProduto
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
            button_salvar = new Button();
            groupBox1 = new GroupBox();
            groupBox4 = new GroupBox();
            textBox_decricao = new TextBox();
            groupBox3 = new GroupBox();
            textBox_cod = new TextBox();
            groupBox9 = new GroupBox();
            richTextBox_obs = new RichTextBox();
            groupBox2 = new GroupBox();
            groupBox8 = new GroupBox();
            textBox_lote = new TextBox();
            groupBox6 = new GroupBox();
            maskedTextBox_datef = new TextBox();
            groupBox7 = new GroupBox();
            textBox_semf = new TextBox();
            groupBox5 = new GroupBox();
            textBox_qtd = new TextBox();
            groupBox10 = new GroupBox();
            groupBox11 = new GroupBox();
            textBox_qtd_ret = new TextBox();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox10.SuspendLayout();
            groupBox11.SuspendLayout();
            SuspendLayout();
            // 
            // button_salvar
            // 
            button_salvar.Cursor = Cursors.Hand;
            button_salvar.FlatAppearance.BorderSize = 0;
            button_salvar.FlatStyle = FlatStyle.Flat;
            button_salvar.Image = Properties.Resources.salve;
            button_salvar.Location = new Point(312, 538);
            button_salvar.Name = "button_salvar";
            button_salvar.Size = new Size(103, 103);
            button_salvar.TabIndex = 0;
            button_salvar.Text = "Salvar";
            button_salvar.TextAlign = ContentAlignment.BottomCenter;
            button_salvar.UseVisualStyleBackColor = true;
            button_salvar.Click += button_salvar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 326);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Produto";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(textBox_decricao);
            groupBox4.Location = new Point(6, 128);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(391, 53);
            groupBox4.TabIndex = 5;
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
            groupBox3.TabIndex = 4;
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
            textBox_cod.ReadOnly = true;
            textBox_cod.Size = new Size(385, 78);
            textBox_cod.TabIndex = 0;
            textBox_cod.Text = "999999";
            textBox_cod.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(richTextBox_obs);
            groupBox9.Location = new Point(6, 78);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(391, 100);
            groupBox9.TabIndex = 6;
            groupBox9.TabStop = false;
            groupBox9.Text = "Observação";
            // 
            // richTextBox_obs
            // 
            richTextBox_obs.Dock = DockStyle.Fill;
            richTextBox_obs.Location = new Point(3, 19);
            richTextBox_obs.Name = "richTextBox_obs";
            richTextBox_obs.Size = new Size(385, 78);
            richTextBox_obs.TabIndex = 0;
            richTextBox_obs.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox8);
            groupBox2.Controls.Add(groupBox6);
            groupBox2.Controls.Add(groupBox7);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Location = new Point(12, 196);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(403, 142);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Informações";
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
            textBox_lote.ReadOnly = true;
            textBox_lote.Size = new Size(127, 31);
            textBox_lote.TabIndex = 0;
            textBox_lote.TextAlign = HorizontalAlignment.Center;
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
            maskedTextBox_datef.Multiline = true;
            maskedTextBox_datef.Name = "maskedTextBox_datef";
            maskedTextBox_datef.ReadOnly = true;
            maskedTextBox_datef.Size = new Size(127, 31);
            maskedTextBox_datef.TabIndex = 1;
            maskedTextBox_datef.TextAlign = HorizontalAlignment.Center;
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
            textBox_semf.ReadOnly = true;
            textBox_semf.Size = new Size(127, 31);
            textBox_semf.TabIndex = 0;
            textBox_semf.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBox_qtd);
            groupBox5.Location = new Point(62, 22);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(133, 53);
            groupBox5.TabIndex = 0;
            groupBox5.TabStop = false;
            groupBox5.Text = "Quantidade Atual";
            // 
            // textBox_qtd
            // 
            textBox_qtd.Dock = DockStyle.Fill;
            textBox_qtd.Font = new Font("Segoe UI", 15F);
            textBox_qtd.Location = new Point(3, 19);
            textBox_qtd.Multiline = true;
            textBox_qtd.Name = "textBox_qtd";
            textBox_qtd.ReadOnly = true;
            textBox_qtd.Size = new Size(127, 31);
            textBox_qtd.TabIndex = 0;
            textBox_qtd.Text = "12312";
            textBox_qtd.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(groupBox11);
            groupBox10.Controls.Add(groupBox9);
            groupBox10.Location = new Point(12, 344);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(403, 188);
            groupBox10.TabIndex = 7;
            groupBox10.TabStop = false;
            groupBox10.Text = "Observação";
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(textBox_qtd_ret);
            groupBox11.ImeMode = ImeMode.On;
            groupBox11.Location = new Point(130, 22);
            groupBox11.Name = "groupBox11";
            groupBox11.RightToLeft = RightToLeft.No;
            groupBox11.Size = new Size(133, 53);
            groupBox11.TabIndex = 0;
            groupBox11.TabStop = false;
            groupBox11.Text = "Quantidade Retirada";
            // 
            // textBox_qtd_ret
            // 
            textBox_qtd_ret.Dock = DockStyle.Fill;
            textBox_qtd_ret.Font = new Font("Segoe UI", 15F);
            textBox_qtd_ret.Location = new Point(3, 19);
            textBox_qtd_ret.Multiline = true;
            textBox_qtd_ret.Name = "textBox_qtd_ret";
            textBox_qtd_ret.Size = new Size(127, 31);
            textBox_qtd_ret.TabIndex = 0;
            textBox_qtd_ret.Text = "12312";
            textBox_qtd_ret.TextAlign = HorizontalAlignment.Center;
            textBox_qtd_ret.KeyPress += OnlyNumber;
            // 
            // SaidaProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(427, 646);
            Controls.Add(groupBox10);
            Controls.Add(groupBox2);
            Controls.Add(button_salvar);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaidaProduto";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Saída de Estoque";
            groupBox1.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox10.ResumeLayout(false);
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_salvar;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private TextBox textBox_decricao;
        private GroupBox groupBox3;
        private TextBox textBox_cod;
        private GroupBox groupBox9;
        private RichTextBox richTextBox_obs;
        private GroupBox groupBox2;
        private GroupBox groupBox8;
        private TextBox textBox_lote;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private TextBox textBox_semf;
        private GroupBox groupBox5;
        private TextBox textBox_qtd;
        private GroupBox groupBox10;
        private GroupBox groupBox11;
        private TextBox textBox_qtd_ret;
        private TextBox maskedTextBox_datef;
    }
}