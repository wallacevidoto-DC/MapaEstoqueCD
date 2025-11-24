namespace MapaEstoqueCD.View.Modal
{
    partial class CreateUser
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
            groupBox3 = new GroupBox();
            textBox_user = new TextBox();
            groupBox1 = new GroupBox();
            textBox_pass = new TextBox();
            groupBox2 = new GroupBox();
            comboBox_acesso = new ComboBox();
            button_salvar = new Button();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox_user);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(390, 100);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Usuário";
            // 
            // textBox_user
            // 
            textBox_user.Dock = DockStyle.Fill;
            textBox_user.Font = new Font("Segoe UI", 40F);
            textBox_user.Location = new Point(3, 19);
            textBox_user.Multiline = true;
            textBox_user.Name = "textBox_user";
            textBox_user.Size = new Size(384, 78);
            textBox_user.TabIndex = 0;
            textBox_user.Text = "999999";
            textBox_user.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox_pass);
            groupBox1.Location = new Point(12, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(390, 100);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Senha";
            // 
            // textBox_pass
            // 
            textBox_pass.Dock = DockStyle.Fill;
            textBox_pass.Font = new Font("Segoe UI", 40F);
            textBox_pass.Location = new Point(3, 19);
            textBox_pass.Multiline = true;
            textBox_pass.Name = "textBox_pass";
            textBox_pass.Size = new Size(384, 78);
            textBox_pass.TabIndex = 0;
            textBox_pass.Text = "999999";
            textBox_pass.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox_acesso);
            groupBox2.Location = new Point(12, 212);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(390, 100);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nivel de Acesso";
            // 
            // comboBox_acesso
            // 
            comboBox_acesso.Dock = DockStyle.Fill;
            comboBox_acesso.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_acesso.FlatStyle = FlatStyle.Popup;
            comboBox_acesso.Font = new Font("Segoe UI", 40F);
            comboBox_acesso.FormattingEnabled = true;
            comboBox_acesso.Items.AddRange(new object[] { "DEV", "ADMIN", "USER" });
            comboBox_acesso.Location = new Point(3, 19);
            comboBox_acesso.Name = "comboBox_acesso";
            comboBox_acesso.Size = new Size(384, 79);
            comboBox_acesso.TabIndex = 0;
            // 
            // button_salvar
            // 
            button_salvar.Cursor = Cursors.Hand;
            button_salvar.FlatAppearance.BorderSize = 0;
            button_salvar.FlatStyle = FlatStyle.Flat;
            button_salvar.Image = Properties.Resources.salve;
            button_salvar.Location = new Point(299, 321);
            button_salvar.Name = "button_salvar";
            button_salvar.Size = new Size(103, 103);
            button_salvar.TabIndex = 3;
            button_salvar.Text = "Salvar";
            button_salvar.TextAlign = ContentAlignment.BottomCenter;
            button_salvar.UseVisualStyleBackColor = true;
            button_salvar.Click += button_salvar_Click;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(414, 436);
            Controls.Add(button_salvar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Criar Usuário";
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private TextBox textBox_user;
        private GroupBox groupBox1;
        private TextBox textBox_pass;
        private GroupBox groupBox2;
        private ComboBox comboBox_acesso;
        private Button button_salvar;
    }
}