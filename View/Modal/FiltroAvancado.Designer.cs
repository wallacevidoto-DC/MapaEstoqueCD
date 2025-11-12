namespace MapaEstoqueCD.View.Modal
{
    partial class FiltroAvancado
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
            panel_central = new Panel();
            pictureBox_aplicar = new PictureBox();
            pictureBox_delete = new PictureBox();
            pictureBox_add = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_aplicar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_delete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_add).BeginInit();
            SuspendLayout();
            // 
            // panel_central
            // 
            panel_central.AutoScroll = true;
            panel_central.BackColor = Color.FromArgb(224, 224, 224);
            panel_central.Location = new Point(12, 12);
            panel_central.Name = "panel_central";
            panel_central.Size = new Size(541, 353);
            panel_central.TabIndex = 0;
            // 
            // pictureBox_aplicar
            // 
            pictureBox_aplicar.Cursor = Cursors.Hand;
            pictureBox_aplicar.Image = Properties.Resources.motor_de_busca;
            pictureBox_aplicar.Location = new Point(556, 305);
            pictureBox_aplicar.Name = "pictureBox_aplicar";
            pictureBox_aplicar.Size = new Size(60, 60);
            pictureBox_aplicar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_aplicar.TabIndex = 1;
            pictureBox_aplicar.TabStop = false;
            pictureBox_aplicar.Click += btnAplicar_Click;
            // 
            // pictureBox_delete
            // 
            pictureBox_delete.Cursor = Cursors.Hand;
            pictureBox_delete.Image = Properties.Resources.filtro_limpo;
            pictureBox_delete.Location = new Point(556, 140);
            pictureBox_delete.Name = "pictureBox_delete";
            pictureBox_delete.Size = new Size(60, 60);
            pictureBox_delete.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_delete.TabIndex = 2;
            pictureBox_delete.TabStop = false;
            pictureBox_delete.Click += btnDeleteAll_Click;
            // 
            // pictureBox_add
            // 
            pictureBox_add.Cursor = Cursors.Hand;
            pictureBox_add.Image = Properties.Resources.adicionar_ficheiro;
            pictureBox_add.Location = new Point(556, 12);
            pictureBox_add.Name = "pictureBox_add";
            pictureBox_add.Size = new Size(60, 60);
            pictureBox_add.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_add.TabIndex = 2;
            pictureBox_add.TabStop = false;
            pictureBox_add.Click += btnAdicionarFiltro_Click;
            // 
            // FiltroAvancado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 378);
            Controls.Add(pictureBox_add);
            Controls.Add(pictureBox_delete);
            Controls.Add(pictureBox_aplicar);
            Controls.Add(panel_central);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FiltroAvancado";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Filtro Avançado";
            Load += FiltroAvançado_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_aplicar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_delete).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_add).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_central;
        private PictureBox pictureBox_aplicar;
        private PictureBox pictureBox_delete;
        private PictureBox pictureBox_add;
    }
}