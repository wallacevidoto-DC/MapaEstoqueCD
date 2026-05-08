using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using System.Text.RegularExpressions;

namespace MapaEstoqueCD.Controller
{
    public class CifsController
    {
        private readonly CifsService _cifsService = new();

        public List<Cifs> GetAllCifs()
        {
            return _cifsService.ListarTodos();
        }

        public void SaveCif(string cod, int id = 0)
        {
            if (string.IsNullOrWhiteSpace(cod))
            {
                MessageBox.Show("O código da CIF não pode estar vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarFormatoCif(cod))
            {
                MessageBox.Show("O código da CIF deve seguir o padrão A000/YY (Ex: A001/26).", "Padrão Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_cifsService.ExisteCif(cod, id))
            {
                MessageBox.Show("Este código de CIF já existe no sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cifs cif;
            if (id == 0)
            {
                cif = new Cifs { CifCod = cod };
            }
            else
            {
                cif = _cifsService.ObterPorId(id);
                if (cif != null)
                {
                    cif.CifCod = cod;
                }
                else
                {
                    MessageBox.Show("CIF não encontrada para edição.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _cifsService.Salvar(cif);
            MessageBox.Show("CIF salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string GerarProximoCif()
        {
            var ultimo = _cifsService.ObterUltimoCif();
            int proximoNumero = 1;
            string anoAtual = DateTime.Now.ToString("yy");

            if (ultimo != null && !string.IsNullOrEmpty(ultimo.CifCod))
            {
                try
                {
                    // Modelo A999/26
                    // Remove 'A' e o '/YY'
                    string cod = ultimo.CifCod;
                    if (cod.StartsWith("A"))
                    {
                        int indexBarra = cod.IndexOf('/');
                        string numeroParte = "";

                        if (indexBarra > 1)
                        {
                            numeroParte = cod.Substring(1, indexBarra - 1);
                        }
                        else
                        {
                            numeroParte = cod.Substring(1);
                        }

                        if (int.TryParse(numeroParte, out int ultimoNumero))
                        {
                            proximoNumero = ultimoNumero + 1;
                        }
                    }
                }
                catch
                {
                    proximoNumero = 1;
                }
            }

            return $"A{proximoNumero:D3}/{anoAtual}";
        }

        public string CreateNextCif()
        {
            string novoCod = GerarProximoCif();
            Cifs cif = new Cifs { CifCod = novoCod };
            _cifsService.Salvar(cif);
            return novoCod;
        }

        public bool ExisteCif(string cod)
        {
            return _cifsService.ExisteCif(cod);
        }

        public bool ValidarFormatoCif(string cod)
        {
            if (string.IsNullOrWhiteSpace(cod)) return false;
            return Regex.IsMatch(cod, @"^A\d{3}/\d{2}$");
        }

        public void ExcluirCif(int id)
        {
            if (_cifsService.TemVinculos(id))
            {
                MessageBox.Show("Não é possível excluir esta CIF pois ela possui vínculos com entradas no sistema.", "Exclusão Não Permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmacao = MessageBox.Show("Tem certeza que deseja excluir esta CIF?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacao == DialogResult.Yes)
            {
                _cifsService.Excluir(id);
                MessageBox.Show("CIF excluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
