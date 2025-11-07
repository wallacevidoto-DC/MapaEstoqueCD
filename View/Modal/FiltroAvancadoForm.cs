using MapaEstoqueCD.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MapaEstoqueCD.View.Modal
{
    public partial class FiltroAvancadoForm : Form
    {
        public List<FiltroItem> Resultado { get; private set; } = new();
        private readonly List<ColumnConfig> _colunasFiltro;
        private readonly List<FiltroLinha> _linhas = new();
        private FlowLayoutPanel _panelFiltros;

        public FiltroAvancadoForm(List<ColumnConfig> colunasFiltro, List<FiltroItem>? filtrosExistentes = null)
        {
            InitializeComponent();
            _colunasFiltro = colunasFiltro.Where(c => c.Visivel).ToList();

            // Primeiro cria o layout
            MontarLayout();

            // Adiciona filtros depois do Load
            Load += (s, e) =>
            {
                _panelFiltros.SuspendLayout();

                if (filtrosExistentes != null && filtrosExistentes.Any())
                {
                    foreach (var f in filtrosExistentes)
                        AdicionarLinha(f.Coluna, f.Valor, f.Tipo, f.Tabela);
                }
                else
                {
                    AdicionarLinha();
                }

                _panelFiltros.ResumeLayout();
                _panelFiltros.PerformLayout();
                _panelFiltros.Refresh();
            };
        }

        private void MontarLayout()
        {
            Text = "Filtro Avançado";
            Size = new Size(520, 470);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Label lblTitulo = new Label
            {
                Text = "Filtros Avançados",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(lblTitulo);

            // Painel com scroll
            Panel pnlScroll = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            Controls.Add(pnlScroll);

            _panelFiltros = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
            pnlScroll.Controls.Add(_panelFiltros);

            // Botão adicionar linha
            Button btnAdd = new Button
            {
                Text = "Adicionar Filtro",
                Dock = DockStyle.Bottom,
                Height = 35,
                BackColor = Color.Gainsboro
            };
            btnAdd.Click += (s, e) => AdicionarLinha();
            Controls.Add(btnAdd);

            // Botões inferiores
            FlowLayoutPanel panelBtns = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 45
            };

            Button btnAplicar = new Button
            {
                Text = "Aplicar",
                Width = 100,
                BackColor = Color.LightGreen
            };
            btnAplicar.Click += (s, e) => Aplicar();

            Button btnCancelar = new Button
            {
                Text = "Cancelar",
                Width = 100,
                BackColor = Color.LightCoral
            };
            btnCancelar.Click += (s, e) => Close();

            panelBtns.Controls.Add(btnAplicar);
            panelBtns.Controls.Add(btnCancelar);
            Controls.Add(panelBtns);
        }

        private void AdicionarLinha(string? coluna = null, string valor = "", string tipo = "contém", string tabela = "")
        {
            var linha = new FiltroLinha(_colunasFiltro, coluna, valor, tipo, tabela);
            linha.OnRemover += () =>
            {
                _panelFiltros.Controls.Remove(linha.Container);
                _linhas.Remove(linha);
            };

            _panelFiltros.Controls.Add(linha.Container);
            _linhas.Add(linha);

            _panelFiltros.ResumeLayout();
            _panelFiltros.PerformLayout();
            _panelFiltros.Refresh();
            linha.Container.BringToFront();
        }

        private void Aplicar()
        {
            Resultado = _linhas
                .Select(l => l.ObterFiltro())
                .Where(f => !string.IsNullOrWhiteSpace(f.Valor))
                .ToList();

            DialogResult = DialogResult.OK;
            Close();
        }
    }

    internal class FiltroLinha
    {
        public Panel Container { get; private set; }
        public event Action? OnRemover;

        private ComboBox comboColuna;
        private TextBox txtValor;
        private RadioButton radioContem;
        private RadioButton radioExato;
        private readonly List<ColumnConfig> _colunas;

        public FiltroLinha(List<ColumnConfig> colunas, string? coluna = null, string valor = "", string tipo = "contém", string tabela = "")
        {
            _colunas = colunas;
            Container = new Panel { Height = 35, Width = 460 };

            comboColuna = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 120,
                Left = 5,
                Top = 5
            };

            // Adiciona títulos visíveis
            comboColuna.Items.AddRange(colunas.Select(c => c.Titulo).ToArray());

            comboColuna.SelectedIndex = 0;
            if (coluna != null && colunas.Any(c => c.Titulo == coluna))
                comboColuna.SelectedItem = coluna;

            txtValor = new TextBox { Left = 130, Top = 5, Width = 130, Text = valor };

            radioContem = new RadioButton { Left = 270, Top = 8, Text = "Contém", Checked = tipo == "contém" };
            radioExato = new RadioButton { Left = 340, Top = 8, Text = "Exato", Checked = tipo == "exato" };

            Button btnRemover = new Button
            {
                Left = 410,
                Top = 4,
                Width = 30,
                Height = 25,
                Text = "✖"
            };
            btnRemover.Click += (s, e) => OnRemover?.Invoke();

            Container.Controls.AddRange(new Control[] { comboColuna, txtValor, radioContem, radioExato, btnRemover });
        }

        public FiltroItem ObterFiltro()
        {
            string colunaExibicao = comboColuna.SelectedItem?.ToString() ?? "";
            var colunaObj = _colunas.FirstOrDefault(c => c.Titulo == colunaExibicao);

            return new FiltroItem
            {
                Coluna = colunaExibicao,
                Valor = txtValor.Text.Trim(),
                Tipo = radioExato.Checked ? "exato" : "contém",
                Tabela = colunaObj?.Propriedade ?? ""
            };
        }
    }
    public class FiltroItem
    {
        public string Coluna { get; set; } = "";
        public string Valor { get; set; } = "";
        public string Tipo { get; set; } = "contém";
        public string Tabela { get; set; } = "";
    }
}
