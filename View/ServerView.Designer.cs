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
            toolStripButton_cadastrar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            listBoxLogs = new ListBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.Dock = DockStyle.Right;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_cadastrar, toolStripSeparator1 });
            toolStrip1.Location = new Point(1395, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(101, 727);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_cadastrar
            // 
            toolStripButton_cadastrar.AutoSize = false;
            toolStripButton_cadastrar.Image = Properties.Resources.verificacao_de_codigo_qr;
            toolStripButton_cadastrar.ImageTransparentColor = Color.Magenta;
            toolStripButton_cadastrar.Name = "toolStripButton_cadastrar";
            toolStripButton_cadastrar.RightToLeft = RightToLeft.Yes;
            toolStripButton_cadastrar.Size = new Size(100, 100);
            toolStripButton_cadastrar.Text = "Acessar";
            toolStripButton_cadastrar.TextAlign = ContentAlignment.BottomCenter;
            toolStripButton_cadastrar.TextImageRelation = TextImageRelation.Overlay;
            toolStripButton_cadastrar.ToolTipText = "Qr code para acessar o sistema";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(98, 6);
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
        private ToolStripButton toolStripButton_cadastrar;
        private ToolStripSeparator toolStripSeparator1;
        private ListBox listBoxLogs;
    }
}