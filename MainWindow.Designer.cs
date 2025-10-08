namespace MapaEstoqueCD
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStrip1 = new ToolStrip();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripButton_movimentacao = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_estoque = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton_produto = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton_remoto = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButton_adm = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel_infoUser = new ToolStripStatusLabel();
            paneL_center = new Panel();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.WhiteSmoke;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator6, toolStripButton_movimentacao, toolStripSeparator1, toolStripButton_estoque, toolStripSeparator2, toolStripButton_produto, toolStripSeparator3, toolStripButton_remoto, toolStripSeparator4, toolStripButton_adm, toolStripSeparator5 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(1326, 103);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 103);
            // 
            // toolStripButton_movimentacao
            // 
            toolStripButton_movimentacao.AutoSize = false;
            toolStripButton_movimentacao.BackColor = Color.WhiteSmoke;
            toolStripButton_movimentacao.BackgroundImageLayout = ImageLayout.None;
            toolStripButton_movimentacao.Image = Properties.Resources.movimentacao;
            toolStripButton_movimentacao.ImageTransparentColor = Color.Magenta;
            toolStripButton_movimentacao.Name = "toolStripButton_movimentacao";
            toolStripButton_movimentacao.RightToLeft = RightToLeft.Yes;
            toolStripButton_movimentacao.Size = new Size(100, 100);
            toolStripButton_movimentacao.Text = "Movimentação";
            toolStripButton_movimentacao.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_movimentacao.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_movimentacao.ToolTipText = "Movimentação";
            toolStripButton_movimentacao.Click += toolStripButton_movimentacao_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 103);
            // 
            // toolStripButton_estoque
            // 
            toolStripButton_estoque.AutoSize = false;
            toolStripButton_estoque.BackColor = Color.WhiteSmoke;
            toolStripButton_estoque.BackgroundImageLayout = ImageLayout.None;
            toolStripButton_estoque.Image = Properties.Resources.armazem;
            toolStripButton_estoque.ImageTransparentColor = Color.Magenta;
            toolStripButton_estoque.Name = "toolStripButton_estoque";
            toolStripButton_estoque.RightToLeft = RightToLeft.Yes;
            toolStripButton_estoque.Size = new Size(100, 100);
            toolStripButton_estoque.Text = "Estoque";
            toolStripButton_estoque.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_estoque.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_estoque.ToolTipText = "Estoque";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 103);
            // 
            // toolStripButton_produto
            // 
            toolStripButton_produto.AutoSize = false;
            toolStripButton_produto.BackColor = Color.WhiteSmoke;
            toolStripButton_produto.BackgroundImageLayout = ImageLayout.None;
            toolStripButton_produto.Image = Properties.Resources.produtos;
            toolStripButton_produto.ImageTransparentColor = Color.Magenta;
            toolStripButton_produto.Name = "toolStripButton_produto";
            toolStripButton_produto.RightToLeft = RightToLeft.Yes;
            toolStripButton_produto.Size = new Size(100, 100);
            toolStripButton_produto.Text = "Produtos";
            toolStripButton_produto.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_produto.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_produto.ToolTipText = "Produtos";
            toolStripButton_produto.Click += toolStripButton_produto_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 103);
            // 
            // toolStripButton_remoto
            // 
            toolStripButton_remoto.AutoSize = false;
            toolStripButton_remoto.BackColor = Color.WhiteSmoke;
            toolStripButton_remoto.BackgroundImageLayout = ImageLayout.None;
            toolStripButton_remoto.Image = Properties.Resources.smartphone;
            toolStripButton_remoto.ImageTransparentColor = Color.Magenta;
            toolStripButton_remoto.Name = "toolStripButton_remoto";
            toolStripButton_remoto.RightToLeft = RightToLeft.Yes;
            toolStripButton_remoto.Size = new Size(100, 100);
            toolStripButton_remoto.Text = "Remoto";
            toolStripButton_remoto.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_remoto.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_remoto.ToolTipText = "Remoto";
            toolStripButton_remoto.Click += toolStripButton_remoto_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 103);
            // 
            // toolStripButton_adm
            // 
            toolStripButton_adm.AutoSize = false;
            toolStripButton_adm.BackColor = Color.WhiteSmoke;
            toolStripButton_adm.BackgroundImageLayout = ImageLayout.None;
            toolStripButton_adm.Image = Properties.Resources.administrador;
            toolStripButton_adm.ImageTransparentColor = Color.Magenta;
            toolStripButton_adm.Name = "toolStripButton_adm";
            toolStripButton_adm.RightToLeft = RightToLeft.Yes;
            toolStripButton_adm.Size = new Size(100, 100);
            toolStripButton_adm.Text = "Administrador";
            toolStripButton_adm.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_adm.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_adm.ToolTipText = "Administrador";
            toolStripButton_adm.Click += toolStripButton_adm_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 103);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel_infoUser });
            statusStrip1.Location = new Point(0, 599);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1326, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_infoUser
            // 
            toolStripStatusLabel_infoUser.LinkBehavior = LinkBehavior.AlwaysUnderline;
            toolStripStatusLabel_infoUser.Name = "toolStripStatusLabel_infoUser";
            toolStripStatusLabel_infoUser.RightToLeftAutoMirrorImage = true;
            toolStripStatusLabel_infoUser.Size = new Size(34, 17);
            toolStripStatusLabel_infoUser.Text = "USER";
            // 
            // paneL_center
            // 
            paneL_center.BackColor = Color.White;
            paneL_center.Dock = DockStyle.Fill;
            paneL_center.Location = new Point(0, 103);
            paneL_center.Name = "paneL_center";
            paneL_center.Size = new Size(1326, 496);
            paneL_center.TabIndex = 2;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1326, 621);
            Controls.Add(paneL_center);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mapa de Estoque DC";
            WindowState = FormWindowState.Maximized;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_movimentacao;
        private ToolStripSeparator toolStripSeparator1;
        private Panel paneL_center;
        private ToolStripButton toolStripButton_estoque;
        private ToolStripButton toolStripButton_produto;
        private ToolStripButton toolStripButton_remoto;
        private ToolStripButton toolStripButton_adm;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripStatusLabel toolStripStatusLabel_infoUser;
        public StatusStrip statusStrip1;
    }
}
