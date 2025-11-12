using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal.Controls;
using System.Data;

namespace MapaEstoqueCD.View.Modal
{
    public partial class FiltroAvancado : Form
    {
        private readonly List<ColumnConfig> columns;
        private readonly List<FiltroItem> filtrosAtivos;
        public List<FiltroItem> Resultado { get; private set; } = new();

        public FiltroAvancado(List<ColumnConfig> Columns, List<FiltroItem> filtrosAtivos)
        {
            InitializeComponent();
            this.columns = Columns;
            this.filtrosAtivos = filtrosAtivos ?? new List<FiltroItem>();
        }

        private void FiltroAvançado_Load(object sender, EventArgs e)
        {
            if (filtrosAtivos != null && filtrosAtivos.Any())
            {
                foreach (var f in filtrosAtivos)
                {
                    AdicionarFiltro(f);
                }
            }
        }

        private void AdicionarFiltro(FiltroItem? filtroExistente = null)
        {
            var filtro = new FilterControl();
            filtro.SetComboItems(columns.Where(c => c.Visivel).ToList());

            if (filtroExistente != null)
            {
                filtro.SetSelectedProperty(filtroExistente.Coluna);
                filtro.SetText(filtroExistente.Valor);
            }

            filtro.ValueChanged += (s, e) =>
            {
                var f = (FilterControl)s;
                Console.WriteLine($"Filtro alterado: {f.SelectedItem} = {f.InputText}");
            };

            filtro.DeleteClicked += (s, e) =>
            {
                var f = (FilterControl)s;
                panel_central.Controls.Remove(f);
                f.Dispose();
            };


            filtro.Dock = DockStyle.Top;
            panel_central.Controls.Add(filtro);
            panel_central.Controls.SetChildIndex(filtro, 0); 
        }

        public List<FiltroItem> GetFiltrosSelecionados()
        {
            var lista = new List<FiltroItem>();

            foreach (FilterControl filtro in panel_central.Controls.OfType<FilterControl>())
            {
                if (!string.IsNullOrEmpty(filtro.SelectedProperty) && !string.IsNullOrEmpty(filtro.InputText))
                {
                    lista.Add(new FiltroItem
                    {
                        Coluna = filtro.SelectedProperty,
                        Valor = filtro.InputText
                    });
                }
            }

            return lista;
        }
        private void btnAdicionarFiltro_Click(object sender, EventArgs e)
        {
            AdicionarFiltro();
        }

        private List<FiltroItem> ColetarFiltros()
        {
            var lista = new List<FiltroItem>();

            foreach (FilterControl filtro in panel_central.Controls.OfType<FilterControl>())
            {
                if (!string.IsNullOrWhiteSpace(filtro.SelectedProperty) &&
                    !string.IsNullOrWhiteSpace(filtro.InputText))
                {
                    lista.Add(new FiltroItem
                    {
                        Coluna = filtro.SelectedProperty,
                        Valor = filtro.InputText
                    });
                }
            }

            return lista;
        }
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Resultado = ColetarFiltros();
            DialogResult = DialogResult.OK;
            Close();
            return;
            var filtros = GetFiltrosSelecionados();

            // Aqui você pode retornar a lista ou aplicar diretamente
            Console.WriteLine("Filtros selecionados:");
            foreach (var f in filtros)
            {
                Console.WriteLine($"• {f.Coluna} = {f.Valor}");
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        public static List<FiltroItem> ShowDialogAndReturn(List<ColumnConfig> columns, List<FiltroItem> filtrosAtivos)
        {
            using var form = new FiltroAvancado(columns, filtrosAtivos);
            var result = form.ShowDialog();

            return result == DialogResult.OK ? form.Resultado: form.Resultado;
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            panel_central.Controls.Clear();
            Resultado = ColetarFiltros();
            Resultado.Clear();
            DialogResult = DialogResult.OK;
            Close();
            return;
            
        }
    }
}
