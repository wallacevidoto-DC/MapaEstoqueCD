using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Utils
{
    public class Grids
    {



        public static void SetDefaultListViews(Dictionary<string, string> docs, ref ListView listView)
        {
            listView.FullRowSelect =true;
            listView.GridLines=true;
            listView.MultiSelect = false;
            listView.HideSelection = false;
            listView.View = System.Windows.Forms.View.Details;
            listView.OwnerDraw = true;

            listView.DrawColumnHeader += ListView_DrawColumnHeader; ;
            listView.DrawItem += ListViewProdutos_DrawItem;
            listView.DrawSubItem += ListViewProdutos_DrawSubItem;

            listView.Columns.Clear();

            foreach (var coluna in docs.Keys)
            {
                listView.Columns.Add(coluna);
            }

            if (listView.Columns.Count == 0)
                return;

            int larguraTotal = listView.ClientSize.Width;
            int larguraPorColuna = larguraTotal / listView.Columns.Count;

            foreach (ColumnHeader col in listView.Columns)
            {
                col.Width = larguraPorColuna;
            }
        }


        private static void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(Color.FromArgb(50, 50, 70))) 
            using (Pen borderPen = new Pen(Color.Black))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawRectangle(borderPen, e.Bounds);
            }

            TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font,
                e.Bounds, Color.White, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        private static void ListViewProdutos_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawDefault = true;
        }

        private static void ListViewProdutos_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            Color backColor = (e.ItemIndex % 2 == 0) ? Color.White : Color.FromArgb(240, 240, 240);
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            if (e.Item.Selected)
            {
                using (SolidBrush brush = new SolidBrush(Color.LightBlue))
                    e.Graphics.FillRectangle(brush, e.Bounds);
            }

            // Texto
            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.Item.Font, e.Bounds, Color.Black,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

           
        }
    }
}
