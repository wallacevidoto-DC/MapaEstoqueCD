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
        public static string FormatarData(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return "00/00";

            // Aceita separador '/' ou ';'
            char separador = valor.Contains('/') ? '/' :
                             valor.Contains(';') ? ';' : '/';

            string[] partes = valor.Split(separador);

            if (partes.Length != 2)
                return "00/00";

            // Tenta converter para número e aplica formatação 00
            bool ok1 = int.TryParse(partes[0], out int p1);
            bool ok2 = int.TryParse(partes[1], out int p2);

            if (!ok1 || !ok2)
                return "00/00";

            return $"{p1:00}/{p2:00}";
        }


    }
}
