namespace MapaEstoqueCD.View
{
    partial class MovimentacaoForm
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
            toolStrip1 = new ToolStrip();
            toolStripButton_filtrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_remoto = new ToolStripDropDownButton();
            pDFToolStripMenuItem = new ToolStripMenuItem();
            eXCELToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            listView1 = new ListView();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 250, 255);
            toolStrip1.Dock = DockStyle.Right;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_filtrar, toolStripSeparator1, toolStripButton_remoto, toolStripSeparator3 });
            toolStrip1.Location = new Point(1038, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(101, 605);
            toolStrip1.TabIndex = 3;
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
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(1038, 605);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MovimentacaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(1139, 605);
            Controls.Add(listView1);
            Controls.Add(toolStrip1);
            Name = "MovimentacaoForm";
            Text = "Movimentacao";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_filtrar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton toolStripButton_remoto;
        private ToolStripMenuItem pDFToolStripMenuItem;
        private ToolStripMenuItem eXCELToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ListView listView1;
    }
}