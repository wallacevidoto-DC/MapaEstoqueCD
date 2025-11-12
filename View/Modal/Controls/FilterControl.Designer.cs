namespace MapaEstoqueCD.View.Modal.Controls
{
    partial class FilterControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox_columns = new ComboBox();
            textBox_value = new TextBox();
            pictureBox_delete = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_delete).BeginInit();
            SuspendLayout();
            // 
            // comboBox_columns
            // 
            comboBox_columns.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_columns.Font = new Font("Segoe UI", 15F);
            comboBox_columns.FormattingEnabled = true;
            comboBox_columns.Location = new Point(3, 3);
            comboBox_columns.Name = "comboBox_columns";
            comboBox_columns.Size = new Size(248, 36);
            comboBox_columns.TabIndex = 0;
            // 
            // textBox_value
            // 
            textBox_value.Font = new Font("Segoe UI", 15F);
            textBox_value.Location = new Point(257, 5);
            textBox_value.Name = "textBox_value";
            textBox_value.Size = new Size(222, 34);
            textBox_value.TabIndex = 1;
            // 
            // pictureBox_delete
            // 
            pictureBox_delete.Cursor = Cursors.Hand;
            pictureBox_delete.Image = Properties.Resources.cancelar1;
            pictureBox_delete.Location = new Point(485, 5);
            pictureBox_delete.Name = "pictureBox_delete";
            pictureBox_delete.Size = new Size(34, 35);
            pictureBox_delete.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_delete.TabIndex = 2;
            pictureBox_delete.TabStop = false;
            // 
            // FilterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox_delete);
            Controls.Add(textBox_value);
            Controls.Add(comboBox_columns);
            Name = "FilterControl";
            Size = new Size(524, 44);
            ((System.ComponentModel.ISupportInitialize)pictureBox_delete).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_columns;
        private TextBox textBox_value;
        private PictureBox pictureBox_delete;
    }
}
