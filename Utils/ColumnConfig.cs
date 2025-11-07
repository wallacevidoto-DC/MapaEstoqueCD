namespace MapaEstoqueCD.Utils
{
    public class ColumnConfig
    {
        public string Titulo { get; set; }      
        public string Propriedade { get; set; }  
        public bool Visivel { get; set; }

        public ColumnConfig(string titulo, string propriedade, bool visivel = true)
        {
            Titulo = titulo;
            Propriedade = propriedade;
            Visivel = visivel;
        }
    }

}
