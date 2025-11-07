namespace MapaEstoqueCD.Utils
{
    public static class Grids
    {
        public static void SetDefaultListViews(List<ColumnConfig> columns, ref ListView listView)
        {
            // ⚙️ Configuração básica do ListView
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.MultiSelect = false;
            listView.HideSelection = false;
            listView.View =  System.Windows.Forms.View.Details;
            listView.OwnerDraw = true;

            // Remove event handlers antigos (evita adicionar duplicados)
            listView.DrawColumnHeader -= ListView_DrawColumnHeader;
            listView.DrawItem -= ListView_DrawItem;
            listView.DrawSubItem -= ListView_DrawSubItem;

            // Adiciona event handlers
            listView.DrawColumnHeader += ListView_DrawColumnHeader;
            listView.DrawItem += ListView_DrawItem;
            listView.DrawSubItem += ListView_DrawSubItem;

            // 🧹 Limpa colunas antigas
            listView.Columns.Clear();

            // 🧩 Adiciona colunas visíveis
            var visibleColumns = columns.Where(c => c.Visivel).ToList();

            foreach (var coluna in visibleColumns)
            {
                listView.Columns.Add(coluna.Titulo);
            }

            if (listView.Columns.Count == 0)
                return;

            // 📏 Distribui largura igualmente
            int larguraTotal = listView.ClientSize.Width;
            int larguraPorColuna = larguraTotal / listView.Columns.Count;

            foreach (ColumnHeader col in listView.Columns)
            {
                col.Width = larguraPorColuna;
            }
        }

        // 🎨 Cabeçalho customizado
        private static void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(Color.FromArgb(50, 50, 70)))
            using (Pen borderPen = new Pen(Color.Black))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawRectangle(borderPen, e.Bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                e.Header.Text,
                e.Font,
                e.Bounds,
                Color.White,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );
        }

        // (opcional) Se quiser alternar fundo das linhas
        private static void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // e.DrawDefault = true; // descomente se quiser comportamento padrão
        }

        private static void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Color backColor = (e.ItemIndex % 2 == 0)
                ? Color.White
                : Color.FromArgb(240, 240, 240);

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            if (e.Item.Selected)
            {
                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                    e.Graphics.FillRectangle(brush, e.Bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                e.SubItem.Text,
                e.Item.Font,
                e.Bounds,
                Color.Black,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );
        }
    }
}
