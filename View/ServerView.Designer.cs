namespace MapaEstoqueCD.View
{
    partial class ServerView
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
            toolStripButton_qr = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_certificado = new ToolStripButton();
            listBoxLogs = new ListBox();
            toolStripButton1 = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.Dock = DockStyle.Right;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_qr, toolStripSeparator1, toolStripButton1, toolStripButton_certificado });
            toolStrip1.Location = new Point(1395, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(101, 727);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_qr
            // 
            toolStripButton_qr.AutoSize = false;
            toolStripButton_qr.Image = Properties.Resources.verificacao_de_codigo_qr;
            toolStripButton_qr.ImageTransparentColor = Color.Magenta;
            toolStripButton_qr.Name = "toolStripButton_qr";
            toolStripButton_qr.RightToLeft = RightToLeft.Yes;
            toolStripButton_qr.Size = new Size(100, 100);
            toolStripButton_qr.Text = "Acessar";
            toolStripButton_qr.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_qr.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_qr.ToolTipText = "Qr code para acessar o sistema";
            toolStripButton_qr.Click += toolStripButton_qr_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(98, 6);
            // 
            // toolStripButton_certificado
            // 
            toolStripButton_certificado.AutoSize = false;
            toolStripButton_certificado.Image = Properties.Resources.certificado_online;
            toolStripButton_certificado.ImageTransparentColor = Color.Magenta;
            toolStripButton_certificado.Name = "toolStripButton_certificado";
            toolStripButton_certificado.RightToLeft = RightToLeft.Yes;
            toolStripButton_certificado.Size = new Size(100, 100);
            toolStripButton_certificado.Text = "R. Certificado";
            toolStripButton_certificado.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_certificado.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_certificado.ToolTipText = "Qr code para acessar o sistema";
            toolStripButton_certificado.Click += toolStripButton_certificado_Click;
            // 
            // listBoxLogs
            // 
            listBoxLogs.BackColor = Color.FromArgb(20, 20, 20);
            listBoxLogs.Dock = DockStyle.Fill;
            listBoxLogs.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxLogs.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBoxLogs.ForeColor = Color.White;
            listBoxLogs.FormattingEnabled = true;
            listBoxLogs.Location = new Point(0, 0);
            listBoxLogs.Name = "listBoxLogs";
            listBoxLogs.SelectionMode = SelectionMode.None;
            listBoxLogs.Size = new Size(1395, 727);
            listBoxLogs.TabIndex = 4;
            listBoxLogs.DrawItem += listBoxLogs_DrawItem;
            // 
            // toolStripButton1
            // 
            toolStripButton1.AutoSize = false;
            toolStripButton1.Image = Properties.Resources.refresh_data;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.RightToLeft = RightToLeft.Yes;
            toolStripButton1.Size = new Size(100, 100);
            toolStripButton1.Text = "Reiniciar";
            toolStripButton1.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton1.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton1.ToolTipText = "Qr code para acessar o sistema";
            toolStripButton1.Click += toolStripButton_reload_Click;
            // 
            // ServerView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1496, 727);
            Controls.Add(listBoxLogs);
            Controls.Add(toolStrip1);
            Name = "ServerView";
            Text = "ServerView";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_certificado;
        private ToolStripSeparator toolStripSeparator1;
        private ListBox listBoxLogs;
        private ToolStripButton toolStripButton_qr;
        private ToolStripButton toolStripButton1;
    }
}