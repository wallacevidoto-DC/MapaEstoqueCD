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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            toolStrip_menu = new ToolStrip();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripButton_movimentacao = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripButton_estoque = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton_entrada = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_produto = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton_remoto = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButton_adm = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButton_logoff = new ToolStripButton();
            statusStrip_sub = new StatusStrip();
            toolStripStatusLabel_infoUser = new ToolStripStatusLabel();
            paneL_center = new Panel();
            toolStrip_menu.SuspendLayout();
            statusStrip_sub.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip_menu
            // 
            toolStrip_menu.BackColor = Color.FromArgb(248, 250, 255);
            toolStrip_menu.BackgroundImageLayout = ImageLayout.None;
            toolStrip_menu.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip_menu.ImageScalingSize = new Size(60, 65);
            toolStrip_menu.Items.AddRange(new ToolStripItem[] { toolStripSeparator6, toolStripButton_movimentacao, toolStripSeparator7, toolStripButton_estoque, toolStripSeparator2, toolStripButton_entrada, toolStripSeparator1, toolStripButton_produto, toolStripSeparator3, toolStripButton_remoto, toolStripSeparator4, toolStripButton_adm, toolStripSeparator5, toolStripButton_logoff });
            toolStrip_menu.Location = new Point(0, 0);
            toolStrip_menu.Name = "toolStrip_menu";
            toolStrip_menu.RenderMode = ToolStripRenderMode.System;
            toolStrip_menu.Size = new Size(1326, 103);
            toolStrip_menu.TabIndex = 0;
            toolStrip_menu.Text = "toolStrip1";
            toolStrip_menu.Visible = false;
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
            toolStripButton_movimentacao.BackgroundImageLayout = ImageLayout.Stretch;
            toolStripButton_movimentacao.Image = Properties.Resources.movimentacao;
            toolStripButton_movimentacao.ImageTransparentColor = Color.Magenta;
            toolStripButton_movimentacao.Name = "toolStripButton_movimentacao";
            toolStripButton_movimentacao.RightToLeft = RightToLeft.Yes;
            toolStripButton_movimentacao.Size = new Size(100, 100);
            toolStripButton_movimentacao.Text = "Movimentação";
            toolStripButton_movimentacao.TextAlign = ContentAlignment.TopCenter;
            toolStripButton_movimentacao.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_movimentacao.ToolTipText = "Todas as movimentações do CD";
            toolStripButton_movimentacao.Click += toolStripButton_movimentacao_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 103);
            // 
            // toolStripButton_estoque
            // 
            toolStripButton_estoque.AutoSize = false;
            toolStripButton_estoque.BackColor = Color.WhiteSmoke;
            toolStripButton_estoque.BackgroundImageLayout = ImageLayout.Stretch;
            toolStripButton_estoque.Image = Properties.Resources.armazem;
            toolStripButton_estoque.ImageTransparentColor = Color.Magenta;
            toolStripButton_estoque.Name = "toolStripButton_estoque";
            toolStripButton_estoque.RightToLeft = RightToLeft.Yes;
            toolStripButton_estoque.Size = new Size(100, 100);
            toolStripButton_estoque.Text = "Estoque";
            toolStripButton_estoque.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_estoque.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_estoque.ToolTipText = "Onde da entrada, picking, saída, transferência e correção";
            toolStripButton_estoque.Click += toolStripButton_estoque_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 103);
            // 
            // toolStripButton_entrada
            // 
            toolStripButton_entrada.AutoSize = false;
            toolStripButton_entrada.BackColor = Color.WhiteSmoke;
            toolStripButton_entrada.BackgroundImageLayout = ImageLayout.Stretch;
            toolStripButton_entrada.Image = Properties.Resources.mercadorias;
            toolStripButton_entrada.ImageTransparentColor = Color.Magenta;
            toolStripButton_entrada.Name = "toolStripButton_entrada";
            toolStripButton_entrada.RightToLeft = RightToLeft.Yes;
            toolStripButton_entrada.Size = new Size(100, 100);
            toolStripButton_entrada.Text = "Entrada/CIF";
            toolStripButton_entrada.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_entrada.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_entrada.ToolTipText = "Entrada de mercadoria da fabrica para o CD";
            toolStripButton_entrada.Click += toolStripButton_entrada_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 103);
            // 
            // toolStripButton_produto
            // 
            toolStripButton_produto.AutoSize = false;
            toolStripButton_produto.BackColor = Color.WhiteSmoke;
            toolStripButton_produto.BackgroundImageLayout = ImageLayout.Stretch;
            toolStripButton_produto.Image = Properties.Resources.produtos;
            toolStripButton_produto.ImageTransparentColor = Color.Magenta;
            toolStripButton_produto.Name = "toolStripButton_produto";
            toolStripButton_produto.RightToLeft = RightToLeft.Yes;
            toolStripButton_produto.Size = new Size(100, 100);
            toolStripButton_produto.Text = "Produtos";
            toolStripButton_produto.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_produto.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_produto.ToolTipText = "Produtos cadastrados";
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
            toolStripButton_remoto.BackgroundImageLayout = ImageLayout.Stretch;
            toolStripButton_remoto.Image = Properties.Resources.smartphone;
            toolStripButton_remoto.ImageTransparentColor = Color.Magenta;
            toolStripButton_remoto.Name = "toolStripButton_remoto";
            toolStripButton_remoto.RightToLeft = RightToLeft.Yes;
            toolStripButton_remoto.Size = new Size(100, 100);
            toolStripButton_remoto.Text = "Remoto";
            toolStripButton_remoto.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_remoto.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_remoto.ToolTipText = "Acesso remoto";
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
            toolStripButton_adm.BackgroundImageLayout = ImageLayout.Stretch;
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
            // toolStripButton_logoff
            // 
            toolStripButton_logoff.AutoSize = false;
            toolStripButton_logoff.BackColor = Color.WhiteSmoke;
            toolStripButton_logoff.BackgroundImageLayout = ImageLayout.Stretch;
            toolStripButton_logoff.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            toolStripButton_logoff.Image = Properties.Resources.sair;
            toolStripButton_logoff.ImageTransparentColor = Color.Magenta;
            toolStripButton_logoff.Name = "toolStripButton_logoff";
            toolStripButton_logoff.RightToLeft = RightToLeft.Yes;
            toolStripButton_logoff.Size = new Size(100, 100);
            toolStripButton_logoff.Text = "DESLOGAR";
            toolStripButton_logoff.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_logoff.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_logoff.ToolTipText = "Administrador";
            toolStripButton_logoff.Click += toolStripButton_logoff_Click;
            // 
            // statusStrip_sub
            // 
            statusStrip_sub.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel_infoUser });
            statusStrip_sub.Location = new Point(0, 599);
            statusStrip_sub.Name = "statusStrip_sub";
            statusStrip_sub.Size = new Size(1326, 22);
            statusStrip_sub.TabIndex = 1;
            statusStrip_sub.Text = "statusStrip1";
            statusStrip_sub.Visible = false;
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
            paneL_center.BackgroundImage = Properties.Resources.imgestoque;
            paneL_center.BackgroundImageLayout = ImageLayout.Stretch;
            paneL_center.Dock = DockStyle.Fill;
            paneL_center.Location = new Point(0, 0);
            paneL_center.Name = "paneL_center";
            paneL_center.Size = new Size(1326, 621);
            paneL_center.TabIndex = 2;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(1326, 621);
            Controls.Add(paneL_center);
            Controls.Add(statusStrip_sub);
            Controls.Add(toolStrip_menu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mapa de Estoque DC";
            WindowState = FormWindowState.Maximized;
            Load += MainWindow_Load;
            toolStrip_menu.ResumeLayout(false);
            toolStrip_menu.PerformLayout();
            statusStrip_sub.ResumeLayout(false);
            statusStrip_sub.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip_menu;
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
        public StatusStrip statusStrip_sub;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton toolStripButton_entrada;
        private ToolStripButton toolStripButton_logoff;
    }
}
