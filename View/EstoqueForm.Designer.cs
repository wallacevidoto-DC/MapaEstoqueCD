namespace MapaEstoqueCD.View
{
    partial class EstoqueForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            toolStripButton_filtrar = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButton_entrada = new ToolStripDropDownButton();
            cOMUMToolStripMenuItem = new ToolStripMenuItem();
            pICKINGToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_remoto = new ToolStripDropDownButton();
            pDFToolStripMenuItem = new ToolStripMenuItem();
            eXCELToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton_importar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton_exportar = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            contextMenuStrip1 = new ContextMenuStrip(components);
            saídaToolStripMenuItem = new ToolStripMenuItem();
            tRANSFERÊNCIAToolStripMenuItem = new ToolStripMenuItem();
            cORREÇÃOToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            Column11 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            toolStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 250, 255);
            toolStrip1.Dock = DockStyle.Right;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_filtrar, toolStripSeparator5, toolStripButton_entrada, toolStripSeparator1, toolStripButton_remoto, toolStripSeparator3, toolStripButton_importar, toolStripSeparator2, toolStripButton_exportar, toolStripSeparator4 });
            toolStrip1.Location = new Point(1218, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(101, 561);
            toolStrip1.TabIndex = 2;
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
            toolStripButton_filtrar.Click += toolStripButton_filtrar_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(98, 6);
            // 
            // toolStripButton_entrada
            // 
            toolStripButton_entrada.AutoSize = false;
            toolStripButton_entrada.DropDownItems.AddRange(new ToolStripItem[] { cOMUMToolStripMenuItem, pICKINGToolStripMenuItem });
            toolStripButton_entrada.Image = Properties.Resources.entrada;
            toolStripButton_entrada.ImageTransparentColor = Color.Magenta;
            toolStripButton_entrada.Name = "toolStripButton_entrada";
            toolStripButton_entrada.RightToLeft = RightToLeft.Yes;
            toolStripButton_entrada.Size = new Size(100, 100);
            toolStripButton_entrada.Text = "Entrada";
            toolStripButton_entrada.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_entrada.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_entrada.ToolTipText = "Cadastrar Nova Entrada";
            // 
            // cOMUMToolStripMenuItem
            // 
            cOMUMToolStripMenuItem.Image = Properties.Resources.caixa1;
            cOMUMToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            cOMUMToolStripMenuItem.Name = "cOMUMToolStripMenuItem";
            cOMUMToolStripMenuItem.Size = new Size(121, 22);
            cOMUMToolStripMenuItem.Text = "COMUM";
            cOMUMToolStripMenuItem.TextAlign = ContentAlignment.MiddleRight;
            cOMUMToolStripMenuItem.Click += toolStripButton_entrada_Click;
            // 
            // pICKINGToolStripMenuItem
            // 
            pICKINGToolStripMenuItem.Image = Properties.Resources.escolha;
            pICKINGToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            pICKINGToolStripMenuItem.Name = "pICKINGToolStripMenuItem";
            pICKINGToolStripMenuItem.Size = new Size(121, 22);
            pICKINGToolStripMenuItem.Text = "PICKING";
            pICKINGToolStripMenuItem.TextAlign = ContentAlignment.MiddleRight;
            pICKINGToolStripMenuItem.Click += pICKINGToolStripMenuItem_Click;
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
            pDFToolStripMenuItem.Click += pDFToolStripMenuItem_Click;
            // 
            // eXCELToolStripMenuItem
            // 
            eXCELToolStripMenuItem.Image = Properties.Resources.xls;
            eXCELToolStripMenuItem.Name = "eXCELToolStripMenuItem";
            eXCELToolStripMenuItem.Size = new Size(107, 22);
            eXCELToolStripMenuItem.Text = "EXCEL";
            eXCELToolStripMenuItem.Click += eXCELToolStripMenuItem_Click;
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
            toolStripButton_exportar.Visible = false;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(98, 6);
            toolStripSeparator4.Visible = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(25, 25);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { saídaToolStripMenuItem, tRANSFERÊNCIAToolStripMenuItem, cORREÇÃOToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(174, 100);
            // 
            // saídaToolStripMenuItem
            // 
            saídaToolStripMenuItem.Image = Properties.Resources.saida;
            saídaToolStripMenuItem.Name = "saídaToolStripMenuItem";
            saídaToolStripMenuItem.Size = new Size(173, 32);
            saídaToolStripMenuItem.Text = "SAÍDA";
            saídaToolStripMenuItem.Click += saídaToolStripMenuItem_Click;
            // 
            // tRANSFERÊNCIAToolStripMenuItem
            // 
            tRANSFERÊNCIAToolStripMenuItem.Image = Properties.Resources.transferencia;
            tRANSFERÊNCIAToolStripMenuItem.Name = "tRANSFERÊNCIAToolStripMenuItem";
            tRANSFERÊNCIAToolStripMenuItem.Size = new Size(173, 32);
            tRANSFERÊNCIAToolStripMenuItem.Text = "TRANSFERÊNCIA";
            tRANSFERÊNCIAToolStripMenuItem.Click += tRANSFERÊNCIAToolStripMenuItem_Click;
            // 
            // cORREÇÃOToolStripMenuItem
            // 
            cORREÇÃOToolStripMenuItem.Image = Properties.Resources.correcao;
            cORREÇÃOToolStripMenuItem.Name = "cORREÇÃOToolStripMenuItem";
            cORREÇÃOToolStripMenuItem.Size = new Size(173, 32);
            cORREÇÃOToolStripMenuItem.Text = "CORREÇÃO";
            cORREÇÃOToolStripMenuItem.Click += cORREÇÃOToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonFace;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(50, 50, 70);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column11, Column1, Column2, Column3, Column7, Column4, Column5, Column6, Column8, Column9 });
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = SystemColors.ScrollBar;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1218, 561);
            dataGridView1.TabIndex = 6;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dataGridView1.MouseDown += dataGridView1_MouseDown;
            // 
            // Column11
            // 
            Column11.HeaderText = "xIndex";
            Column11.Name = "Column11";
            Column11.ReadOnly = true;
            Column11.Visible = false;
            // 
            // Column1
            // 
            Column1.FillWeight = 30F;
            Column1.HeaderText = "Endereco";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.FillWeight = 30F;
            Column2.HeaderText = "Código";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.FillWeight = 200F;
            Column3.HeaderText = "Descrição";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.FillWeight = 20F;
            Column7.HeaderText = "Qtd.";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.FillWeight = 50F;
            Column4.HeaderText = "Data Lan.";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.FillWeight = 50F;
            Column5.HeaderText = "Data Fab.";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.FillWeight = 50F;
            Column6.HeaderText = "Sem. Fab.";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column8
            // 
            Column8.FillWeight = 50F;
            Column8.HeaderText = "Lote";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.FillWeight = 200F;
            Column9.HeaderText = "Observações";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
            // 
            // EstoqueForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1319, 561);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Name = "EstoqueForm";
            Text = "Estoque";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_filtrar;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton toolStripButton_remoto;
        private ToolStripMenuItem pDFToolStripMenuItem;
        private ToolStripMenuItem eXCELToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButton_importar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton_exportar;
        private ToolStripSeparator toolStripSeparator4;
        private ListView listView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem saídaToolStripMenuItem;
        private ToolStripMenuItem tRANSFERÊNCIAToolStripMenuItem;
        private ToolStripMenuItem cORREÇÃOToolStripMenuItem;
        private DataGridView dataGridView1;
        private ToolStripDropDownButton toolStripButton_entrada;
        private ToolStripMenuItem cOMUMToolStripMenuItem;
        private ToolStripMenuItem pICKINGToolStripMenuItem;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
    }
}