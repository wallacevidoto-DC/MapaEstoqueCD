namespace MapaEstoqueCD.Database.Dto.modal
{
    public class ProdutoSpDto
    {

        public int produtoId { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public int quantidade { get; set; }
        public string dataf { get; set; }
        public int semf { get; set; }
        
        public string lote { get; set; }


        public PropsPST propsPST { get; set; } = new();



        public void SetProps(int qtd, string datafab, int semfab, string lot)
        {
            this.quantidade = qtd;
            this.dataf = datafab;
            this.semf = semfab;
            this.lote = lot;
        }
        public bool IsValid(out string mensagemErro)
        {
            mensagemErro = string.Empty;
            if (string.IsNullOrWhiteSpace(codigo))
            {
                mensagemErro = "O código do produto é obrigatório.";
                return false;
            }
            if (quantidade <= 0)
            {
                mensagemErro = "A quantidade deve ser um número válido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(dataf) ||
                !System.Text.RegularExpressions.Regex.IsMatch(dataf, @"^(0?[1-9]|1[0-2])\/\d{2}$"))
            {
                mensagemErro = "A data de fabricação deve estar no formato MM/AA.";
                return false;
            }

            if (semf <= 0)
            {
                mensagemErro = "O campo 'semf' deve ser maior que zero.";
                return false;
            }
            return true;
        }
    }


    public class PropsPST
    {
        public Origem origem { get; set; }
        public bool isModified { get; set; } = true;
    }

    public enum Origem
    {
        IN, OUT
    }
}
