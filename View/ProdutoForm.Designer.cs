namespace MapaEstoqueCD.View
{
    partial class ProdutoForm
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
            components = new System.ComponentModel.Container();
            toolStrip1 = new ToolStrip();
            toolStripButton_filtrar = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButton_cadastrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_remoto = new ToolStripDropDownButton();
            pDFToolStripMenuItem = new ToolStripMenuItem();
            eXCELToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton_importar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton_exportar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            panel1 = new Panel();
            panel3 = new Panel();
            listView1 = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editarToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.Dock = DockStyle.Right;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_filtrar, toolStripSeparator5, toolStripButton_cadastrar, toolStripSeparator1, toolStripButton_remoto, toolStripSeparator3, toolStripButton_importar, toolStripSeparator2, toolStripButton_exportar, toolStripSeparator4 });
            toolStrip1.Location = new Point(901, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(101, 633);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_filtrar
            // 
            toolStripButton_filtrar.AutoSize = false;
            toolStripButton_filtrar.Image = Properties.Resources.filtro;
            toolStripButton_filtrar.ImageTransparentColor = Color.Magenta;
            toolStripButton_filtrar.Name = "toolStripButton_filtrar";
            toolStripButton_filtrar.RightToLeft = RightToLeft.Yes;
            toolStripButton_filtrar.Size = new Size(100, 100);
            toolStripButton_filtrar.Text = "Filtrar";
            toolStripButton_filtrar.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_filtrar.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_filtrar.ToolTipText = "Filtrar Produtos";
            toolStripButton_filtrar.Click += btnFiltroAvancado_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(98, 6);
            // 
            // toolStripButton_cadastrar
            // 
            toolStripButton_cadastrar.AutoSize = false;
            toolStripButton_cadastrar.Image = Properties.Resources.add_prod;
            toolStripButton_cadastrar.ImageTransparentColor = Color.Magenta;
            toolStripButton_cadastrar.Name = "toolStripButton_cadastrar";
            toolStripButton_cadastrar.RightToLeft = RightToLeft.Yes;
            toolStripButton_cadastrar.Size = new Size(100, 100);
            toolStripButton_cadastrar.Text = "Cadastrar";
            toolStripButton_cadastrar.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_cadastrar.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_cadastrar.ToolTipText = "Cadastrar Novo Produto";
            toolStripButton_cadastrar.Click += toolStripButton_cadastrar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(98, 6);
            // 
            // toolStripButton_remoto
            // 
            toolStripButton_remoto.AutoSize = false;
            toolStripButton_remoto.DropDownItems.AddRange(new ToolStripItem[] { pDFToolStripMenuItem, eXCELToolStripMenuItem });
            toolStripButton_remoto.Image = Properties.Resources.historico;
            toolStripButton_remoto.ImageTransparentColor = Color.Magenta;
            toolStripButton_remoto.Name = "toolStripButton_remoto";
            toolStripButton_remoto.RightToLeft = RightToLeft.Yes;
            toolStripButton_remoto.Size = new Size(100, 100);
            toolStripButton_remoto.Text = "Relatórios";
            toolStripButton_remoto.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_remoto.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_remoto.ToolTipText = "Relátorios";
            // 
            // pDFToolStripMenuItem
            // 
            pDFToolStripMenuItem.Image = Properties.Resources.pdf;
            pDFToolStripMenuItem.Name = "pDFToolStripMenuItem";
            pDFToolStripMenuItem.Size = new Size(107, 22);
            pDFToolStripMenuItem.Text = "PDF";
            // 
            // eXCELToolStripMenuItem
            // 
            eXCELToolStripMenuItem.Image = Properties.Resources.xls;
            eXCELToolStripMenuItem.Name = "eXCELToolStripMenuItem";
            eXCELToolStripMenuItem.Size = new Size(107, 22);
            eXCELToolStripMenuItem.Text = "EXCEL";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(98, 6);
            // 
            // toolStripButton_importar
            // 
            toolStripButton_importar.AutoSize = false;
            toolStripButton_importar.Image = Properties.Resources.importar;
            toolStripButton_importar.ImageTransparentColor = Color.Magenta;
            toolStripButton_importar.Name = "toolStripButton_importar";
            toolStripButton_importar.RightToLeft = RightToLeft.Yes;
            toolStripButton_importar.Size = new Size(100, 100);
            toolStripButton_importar.Text = "Importar";
            toolStripButton_importar.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_importar.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_importar.ToolTipText = "Importar";
            toolStripButton_importar.Click += toolStripButton_importar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(98, 6);
            // 
            // toolStripButton_exportar
            // 
            toolStripButton_exportar.AutoSize = false;
            toolStripButton_exportar.Image = Properties.Resources.exportar;
            toolStripButton_exportar.ImageTransparentColor = Color.Magenta;
            toolStripButton_exportar.Name = "toolStripButton_exportar";
            toolStripButton_exportar.RightToLeft = RightToLeft.Yes;
            toolStripButton_exportar.Size = new Size(100, 100);
            toolStripButton_exportar.Text = "Exportar";
            toolStripButton_exportar.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_exportar.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_exportar.ToolTipText = "Exportar";
            toolStripButton_exportar.Click += toolStripButton_exportar_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(98, 6);
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(901, 633);
            panel1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(listView1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(901, 633);
            panel3.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(901, 633);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(105, 26);
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Image = Properties.Resources.editar_codigo;
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(104, 22);
            editarToolStripMenuItem.Text = "Editar";
            editarToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            // 
            // ProdutoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1002, 633);
            Controls.Add(panel1);
            Controls.Add(toolStrip1);
            Name = "ProdutoForm";
            Text = "Produto";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_cadastrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton_importar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton_exportar;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private Panel panel1;
        private ToolStripDropDownButton toolStripButton_remoto;
        private ToolStripMenuItem pDFToolStripMenuItem;
        private ToolStripMenuItem eXCELToolStripMenuItem;
        private Panel panel3;
        private ListView listView1;
        private Panel panel2;
        private Button button1;
        private ToolStripButton toolStripButton_filtrar;
        private ToolStripSeparator toolStripSeparator5;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editarToolStripMenuItem;
    }
}