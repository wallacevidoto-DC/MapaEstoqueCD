using System.Globalization;

namespace MapaEstoqueCD.Utils
{
    public static class DataFormatter
    {
        public static string FormatarMesAno(string dataStr)
        {
            if (string.IsNullOrWhiteSpace(dataStr))
                return "";

            try
            {
                var formatos = new[] { "M/yy", "MM/yy" }; 
                var cultura = CultureInfo.InvariantCulture;

                if (DateTime.TryParseExact(dataStr, formatos, cultura, DateTimeStyles.None, out DateTime data))
                {
                    var culturaPt = new CultureInfo("pt-BR");
                    var resultado = data.ToString("MMM-yy", culturaPt).ToUpper();
                    return resultado.Replace(".", "");
                }
                else
                {
                    Console.WriteLine($"Atenção: Data inválida para formatação: '{dataStr}'.");
                    return dataStr;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao formatar data: {ex.Message}");
                return dataStr;
            }
        }
    }
}
