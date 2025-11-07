using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MapaEstoqueCD.Utils
{
    public static class Grids
    {
        // Dicionário para armazenar o estado de ordenação por ListView
        private static readonly Dictionary<ListView, SortInfo> SortStates = new();

        private class SortInfo
        {
            public int ColumnIndex { get; set; }
            public SortOrder Order { get; set; } = SortOrder.None;
        }

        public static void SetDefaultListViews(List<ColumnConfig> columns, ref ListView listView)
        {
            // ⚙️ Configuração básica
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.MultiSelect = false;
            listView.HideSelection = false;
            listView.View = System.Windows.Forms.View.Details;
            listView.OwnerDraw = true;

            // 🔁 Remove eventos antigos
            listView.DrawColumnHeader -= ListView_DrawColumnHeader;
            listView.DrawItem -= ListView_DrawItem;
            listView.DrawSubItem -= ListView_DrawSubItem;
            listView.ColumnClick -= ListView_ColumnClick;

            // 🎨 Adiciona eventos
            listView.DrawColumnHeader += ListView_DrawColumnHeader;
            listView.DrawItem += ListView_DrawItem;
            listView.DrawSubItem += ListView_DrawSubItem;
            listView.ColumnClick += ListView_ColumnClick;

            // 🧹 Limpa colunas antigas
            listView.Columns.Clear();

            var visibleColumns = columns.Where(c => c.Visivel).ToList();
            foreach (var coluna in visibleColumns)
                listView.Columns.Add(coluna.Titulo);

            if (listView.Columns.Count == 0) return;

            // 📏 Distribui largura igualmente
            int larguraTotal = listView.ClientSize.Width;
            int larguraPorColuna = larguraTotal / listView.Columns.Count;
            foreach (ColumnHeader col in listView.Columns)
                col.Width = larguraPorColuna;

            // 🔄 Inicializa estado de ordenação
            SortStates[listView] = new SortInfo();
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

            string text = e.Header.Text;

            // 🔽 Mostra o símbolo de ordenação
            if (sender is ListView lv && SortStates.ContainsKey(lv))
            {
                var sortInfo = SortStates[lv];
                if (sortInfo.ColumnIndex == e.ColumnIndex)
                {
                    text += sortInfo.Order == SortOrder.Ascending ? " ▲" :
                            sortInfo.Order == SortOrder.Descending ? " ▼" : "";
                }
            }

            TextRenderer.DrawText(
                e.Graphics,
                text,
                e.Font,
                e.Bounds,
                Color.White,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );
        }

        // 🧭 Ordenação ao clicar no cabeçalho
        private static void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (sender is not ListView listView) return;

            if (!SortStates.ContainsKey(listView))
                SortStates[listView] = new SortInfo();

            var sortInfo = SortStates[listView];

            // Alterna entre Ascendente/Descendente
            if (sortInfo.ColumnIndex == e.Column)
            {
                sortInfo.Order = sortInfo.Order == SortOrder.Ascending
                    ? SortOrder.Descending
                    : SortOrder.Ascending;
            }
            else
            {
                sortInfo.ColumnIndex = e.Column;
                sortInfo.Order = SortOrder.Ascending;
            }

            // Define o sorter customizado
            listView.ListViewItemSorter = new ListViewItemComparer(e.Column, sortInfo.Order);
            listView.Sort();
            listView.Invalidate(); // redesenha o cabeçalho (para o símbolo ▲▼ aparecer)
        }

        private class ListViewItemComparer : System.Collections.IComparer
        {
            private readonly int _col;
            private readonly SortOrder _order;

            public ListViewItemComparer(int column, SortOrder order)
            {
                _col = column;
                _order = order;
            }

            public int Compare(object x, object y)
            {
                if (x is not ListViewItem itemX || y is not ListViewItem itemY)
                    return 0;

                string textX = itemX.SubItems[_col].Text;
                string textY = itemY.SubItems[_col].Text;

                // tenta comparar numericamente ou por data
                if (decimal.TryParse(textX, out decimal numX) && decimal.TryParse(textY, out decimal numY))
                    return _order == SortOrder.Ascending ? numX.CompareTo(numY) : numY.CompareTo(numX);

                if (DateTime.TryParse(textX, out DateTime dateX) && DateTime.TryParse(textY, out DateTime dateY))
                    return _order == SortOrder.Ascending ? dateX.CompareTo(dateY) : dateY.CompareTo(dateX);

                // compara como string
                return _order == SortOrder.Ascending
                    ? string.Compare(textX, textY, StringComparison.OrdinalIgnoreCase)
                    : string.Compare(textY, textX, StringComparison.OrdinalIgnoreCase);
            }
        }

        private static void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // e.DrawDefault = true; // opcional
        }

        private static void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Color backColor = (e.ItemIndex % 2 == 0)
                ? Color.White
                : Color.FromArgb(240, 240, 240);

            using (SolidBrush brush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, e.Bounds);

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
