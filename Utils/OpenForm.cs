using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Utils
{
    public class OpenForm
    {

        public static void OpenFormToForm(Form form, ref Panel panel_center)
        {
            try
            {
                if (panel_center.Controls.Count > 0)
                {
                    panel_center.Controls.RemoveAt(0);
                }
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;

                panel_center.Controls.Clear();
                panel_center.Controls.Add(form);
                form?.Show();
            }
            catch (Exception ex)
            {
                //ex.ErrorGet();

            }
        }


    }
}
