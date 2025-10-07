namespace MapaEstoqueCD.View.Modal
{

    partial class PrintPreviewForm
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
            toolStrip_menu = new ToolStrip();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_save = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton_print = new ToolStripButton();
            panel2 = new Panel();
            ePictureBox_nextPage = new PictureBox();
            ePictureBox_previus = new PictureBox();
            textBox_viewCountPages = new TextBox();
            printPreviewControl_preview = new PrintPreviewControl();
            toolStrip_menu.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ePictureBox_nextPage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ePictureBox_previus).BeginInit();
            SuspendLayout();
            // 
            // toolStrip_menu
            // 
            toolStrip_menu.Items.AddRange(new ToolStripItem[] { toolStripSeparator1, toolStripButton_save, toolStripSeparator2, toolStripButton_print });
            toolStrip_menu.Location = new Point(0, 0);
            toolStrip_menu.Name = "toolStrip_menu";
            toolStrip_menu.RenderMode = ToolStripRenderMode.Professional;
            toolStrip_menu.Size = new Size(1147, 93);
            toolStrip_menu.TabIndex = 4;
            toolStrip_menu.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 93);
            // 
            // toolStripButton_save
            // 
            toolStripButton_save.AutoSize = false;
            toolStripButton_save.Font = new Font("Segoe UI", 7F);
            toolStripButton_save.Image = Properties.Resources.pdf;
            toolStripButton_save.ImageAlign = ContentAlignment.BottomCenter;
            toolStripButton_save.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton_save.ImageTransparentColor = Color.Magenta;
            toolStripButton_save.Name = "toolStripButton_save";
            toolStripButton_save.Size = new Size(90, 90);
            toolStripButton_save.Tag = "";
            toolStripButton_save.Text = "SALVAR PDF";
            toolStripButton_save.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_save.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton_save.ToolTipText = "SALVAR PDF";
            toolStripButton_save.Click += toolStripButton_save_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 93);
            // 
            // toolStripButton_print
            // 
            toolStripButton_print.AutoSize = false;
            toolStripButton_print.Font = new Font("Segoe UI", 7F);
            toolStripButton_print.Image = Properties.Resources.download;
            toolStripButton_print.ImageAlign = ContentAlignment.BottomCenter;
            toolStripButton_print.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton_print.ImageTransparentColor = Color.Magenta;
            toolStripButton_print.Name = "toolStripButton_print";
            toolStripButton_print.Size = new Size(90, 90);
            toolStripButton_print.Tag = "";
            toolStripButton_print.Text = "IMPRIMIR";
            toolStripButton_print.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_print.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton_print.ToolTipText = "IMPRIMIR";
            toolStripButton_print.Click += toolStripButton_print_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(ePictureBox_nextPage);
            panel2.Controls.Add(ePictureBox_previus);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 34);
            panel2.Name = "panel2";
            panel2.Size = new Size(106, 50);
            panel2.TabIndex = 1;
            // 
            // ePictureBox_nextPage
            // 
            ePictureBox_nextPage.Dock = DockStyle.Right;
            ePictureBox_nextPage.Location = new Point(56, 0);
            ePictureBox_nextPage.Name = "ePictureBox_nextPage";
            ePictureBox_nextPage.Size = new Size(50, 50);
            ePictureBox_nextPage.SizeMode = PictureBoxSizeMode.StretchImage;
            ePictureBox_nextPage.TabIndex = 1;
            ePictureBox_nextPage.TabStop = false;
            // 
            // ePictureBox_previus
            // 
            ePictureBox_previus.Dock = DockStyle.Left;
            ePictureBox_previus.Location = new Point(0, 0);
            ePictureBox_previus.Name = "ePictureBox_previus";
            ePictureBox_previus.Size = new Size(50, 50);
            ePictureBox_previus.SizeMode = PictureBoxSizeMode.StretchImage;
            ePictureBox_previus.TabIndex = 0;
            ePictureBox_previus.TabStop = false;
            // 
            // textBox_viewCountPages
            // 
            textBox_viewCountPages.Dock = DockStyle.Top;
            textBox_viewCountPages.Font = new Font("Segoe UI", 15F);
            textBox_viewCountPages.Location = new Point(0, 0);
            textBox_viewCountPages.Name = "textBox_viewCountPages";
            textBox_viewCountPages.Size = new Size(106, 34);
            textBox_viewCountPages.TabIndex = 0;
            textBox_viewCountPages.Text = "0/0";
            textBox_viewCountPages.TextAlign = HorizontalAlignment.Center;
            // 
            // printPreviewControl_preview
            // 
            printPreviewControl_preview.AccessibleRole = AccessibleRole.Grip;
            printPreviewControl_preview.Dock = DockStyle.Fill;
            printPreviewControl_preview.Location = new Point(0, 93);
            printPreviewControl_preview.Name = "printPreviewControl_preview";
            printPreviewControl_preview.Size = new Size(1147, 486);
            printPreviewControl_preview.TabIndex = 6;
            printPreviewControl_preview.Click += printPreviewControl_preview_Click;
            // 
            // PrintPreviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 579);
            Controls.Add(printPreviewControl_preview);
            Controls.Add(toolStrip_menu);
            Name = "PrintPreviewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VISUALIZAÇÃO DE IMPRESSÃO";
            WindowState = FormWindowState.Maximized;
            toolStrip_menu.ResumeLayout(false);
            toolStrip_menu.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ePictureBox_nextPage).EndInit();
            ((System.ComponentModel.ISupportInitialize)ePictureBox_previus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip_menu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton_save;
        private ToolStripButton toolStripButton_print;
        private ToolStripSeparator toolStripSeparator2;
        private PrintPreviewControl printPreviewControl_preview;
        private TextBox textBox_viewCountPages;
        private Panel panel2;
        private PictureBox ePictureBox_previus;
        private PictureBox ePictureBox_nextPage;
    }

}