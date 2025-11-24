namespace MapaEstoqueCD.View
{
    partial class Administrador
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
            toolStripButton_cadastrar = new ToolStripButton();
            listView1 = new ListView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editarToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.FromArgb(248, 250, 255);
            toolStrip1.Dock = DockStyle.Right;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(60, 60);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton_cadastrar });
            toolStrip1.Location = new Point(1228, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(101, 698);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_cadastrar
            // 
            toolStripButton_cadastrar.AutoSize = false;
            toolStripButton_cadastrar.Image = Properties.Resources.adicionar_usuario;
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
            // listView1
            // 
            listView1.ContextMenuStrip = contextMenuStrip1;
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(1228, 698);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editarToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(229, 96);
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editarToolStripMenuItem.Image = Properties.Resources.editar_codigo;
            editarToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(228, 70);
            editarToolStripMenuItem.Text = "Editar";
            editarToolStripMenuItem.Click += editarToolStripMenuItem_Click;
            // 
            // Administrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 255);
            ClientSize = new Size(1329, 698);
            Controls.Add(listView1);
            Controls.Add(toolStrip1);
            Name = "Administrador";
            Text = "Administrador";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_cadastrar;
        private ListView listView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editarToolStripMenuItem;
    }
}