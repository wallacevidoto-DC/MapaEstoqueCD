namespace MapaEstoqueCD.View
{
    partial class AccessUser
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
            groupBox2 = new GroupBox();
            textBox_pass = new TextBox();
            button1 = new Button();
            button_accept = new Button();
            user = new GroupBox();
            textBox_user = new TextBox();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button_accept);
            groupBox1.Controls.Add(user);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(462, 582);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox_pass);
            groupBox2.Font = new Font("Segoe UI", 20F, FontStyle.Italic);
            groupBox2.Location = new Point(6, 382);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(450, 100);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Senha";
            // 
            // textBox_pass
            // 
            textBox_pass.Dock = DockStyle.Fill;
            textBox_pass.Font = new Font("Segoe UI", 30F);
            textBox_pass.Location = new Point(3, 39);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.PasswordChar = '*';
            textBox_pass.Size = new Size(444, 61);
            textBox_pass.TabIndex = 0;
            textBox_pass.TextAlign = HorizontalAlignment.Center;
            textBox_pass.KeyDown += textBox_pass_KeyDown;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 192, 192);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 20F);
            button1.Location = new Point(261, 488);
            button1.Name = "button1";
            button1.Size = new Size(195, 79);
            button1.TabIndex = 1;
            button1.Text = "Sair";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button_accept
            // 
            button_accept.BackColor = Color.FromArgb(224, 224, 224);
            button_accept.Cursor = Cursors.Hand;
            button_accept.FlatAppearance.BorderSize = 0;
            button_accept.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
            button_accept.FlatStyle = FlatStyle.Flat;
            button_accept.Font = new Font("Segoe UI", 20F);
            button_accept.Location = new Point(9, 488);
            button_accept.Name = "button_accept";
            button_accept.Size = new Size(195, 79);
            button_accept.TabIndex = 0;
            button_accept.Text = "Entrar";
            button_accept.UseVisualStyleBackColor = false;
            button_accept.Click += button_accept_Click;
            // 
            // user
            // 
            user.Controls.Add(textBox_user);
            user.Font = new Font("Segoe UI", 20F, FontStyle.Italic);
            user.Location = new Point(6, 276);
            user.Name = "user";
            user.Size = new Size(450, 100);
            user.TabIndex = 1;
            user.TabStop = false;
            user.Text = "Usuário";
            // 
            // textBox_user
            // 
            textBox_user.Dock = DockStyle.Fill;
            textBox_user.Font = new Font("Segoe UI", 30F);
            textBox_user.Location = new Point(3, 39);
            textBox_user.Name = "textBox_user";
            textBox_user.Size = new Size(444, 61);
            textBox_user.TabIndex = 0;
            textBox_user.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.dc;
            pictureBox1.Location = new Point(6, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(450, 239);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // AccessUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(486, 602);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccessUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AccessUser";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            user.ResumeLayout(false);
            user.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button button_accept;
        private GroupBox user;
        private TextBox textBox_user;
        private PictureBox pictureBox1;
        private GroupBox groupBox2;
        private TextBox textBox_pass;
        private Button button1;
    }
}