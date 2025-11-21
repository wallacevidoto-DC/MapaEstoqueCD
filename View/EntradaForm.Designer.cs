namespace MapaEstoqueCD.View
{
    partial class EntradaForm
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
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_remoto = new ToolStripDropDownButton();
            pDFToolStripMenuItem = new ToolStripMenuItem();
            eXCELToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            dataGridView1 = new DataGridView();
            xIndex = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            contextMenuStrip1 = new ContextMenuStrip(components);
            entrdaToolStripMenuItem = new ToolStripMenuItem();
            cORREÇÃOToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 250, 255);
            toolStrip1.Dock = DockStyle.Right;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_filtrar, toolStripSeparator1, toolStripButton_remoto, toolStripSeparator3 });
            toolStrip1.Location = new Point(1341, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(101, 643);
            toolStrip1.TabIndex = 4;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { xIndex, Column1, Column2, Column3, Column4, Column7, Column9, Column5, Column6, Column8, Column10 });
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
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1341, 643);
            dataGridView1.TabIndex = 6;
            dataGridView1.MouseDown += dataGridView1_MouseDown;
            // 
            // xIndex
            // 
            xIndex.HeaderText = "xIndex";
            xIndex.Name = "xIndex";
            xIndex.ReadOnly = true;
            xIndex.Visible = false;
            // 
            // Column1
            // 
            Column1.FillWeight = 30F;
            Column1.HeaderText = "Usuário";
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
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.FillWeight = 50F;
            Column4.HeaderText = "Tipo";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.FillWeight = 50F;
            Column7.HeaderText = "Qtd. Conf.";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column9
            // 
            Column9.FillWeight = 50F;
            Column9.HeaderText = "Qtd. Ent.";
            Column9.Name = "Column9";
            Column9.ReadOnly = true;
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
            Column8.FillWeight = 75F;
            Column8.HeaderText = "Lote";
            Column8.Name = "Column8";
            Column8.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.FillWeight = 75F;
            Column10.HeaderText = "Data de Criação";
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(25, 25);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { entrdaToolStripMenuItem, cORREÇÃOToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(190, 90);
            // 
            // entrdaToolStripMenuItem
            // 
            entrdaToolStripMenuItem.Image = Properties.Resources.entrada;
            entrdaToolStripMenuItem.Name = "entrdaToolStripMenuItem";
            entrdaToolStripMenuItem.Size = new Size(189, 32);
            entrdaToolStripMenuItem.Text = "ENTRADA";
            entrdaToolStripMenuItem.Click += entrdaToolStripMenuItem_Click;
            // 
            // cORREÇÃOToolStripMenuItem
            // 
            cORREÇÃOToolStripMenuItem.Image = Properties.Resources.correcao;
            cORREÇÃOToolStripMenuItem.Name = "cORREÇÃOToolStripMenuItem";
            cORREÇÃOToolStripMenuItem.Size = new Size(189, 32);
            cORREÇÃOToolStripMenuItem.Text = "CORREÇÃO";
            cORREÇÃOToolStripMenuItem.Click += cORREÇÃOToolStripMenuItem_Click;
            // 
            // EntradaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1442, 643);
            Controls.Add(dataGridView1);
            Controls.Add(toolStrip1);
            Name = "EntradaForm";
            Text = "EntradaForm";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_filtrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton toolStripButton_remoto;
        private ToolStripMenuItem pDFToolStripMenuItem;
        private ToolStripMenuItem eXCELToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn xIndex;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column10;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem entrdaToolStripMenuItem;
        private ToolStripMenuItem cORREÇÃOToolStripMenuItem;
    }
}