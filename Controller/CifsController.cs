using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
    }
}
