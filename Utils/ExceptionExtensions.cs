using System.Reflection;
using System.Text.Json;

namespace MapaEstoqueCD.Utils
{
    public static class ExceptionExtensions
    {
        private static readonly string LogFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs\\erros_log.el");

        public static void GetErro(this Exception ex, object objeto,bool msgbox =true)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {
                    sw.WriteLine("==============================================");
                    sw.WriteLine($"Data/Hora: {DateTime.Now}");
                    sw.WriteLine($"Erro: {ex.Message}");
                    sw.WriteLine($"StackTrace: {ex.StackTrace}");
                    sw.WriteLine("---- Dados do DTO ----");

                    if (objeto != null)
                    {
                        GravarDetalhesPropriedades(sw, objeto, 0);
                        //Type t = objeto.GetType();
                        //sw.WriteLine($"Classe: {t.Name}" + "{");

                        //// Pega TODAS as propriedades e seus valores
                        //PropertyInfo[] props = t.GetProperties();
                        //foreach (var prop in t.GetProperties())
                        //{
                        //    object? valor = prop.GetValue(objeto);
                        //    string tipo = prop.PropertyType.Name; 

                        //    sw.WriteLine($"      {prop.Name} ({tipo}): {valor}");
                        //}

                        //sw.WriteLine("}");
                    }

                    sw.WriteLine("==============================================");
                    sw.WriteLine();
                }

                if(!msgbox)
                    return;

                MessageBox.Show(
                $"Ocorreu um erro:\n\n{ex.Message}\n\n" +
                "O erro completo foi salvo no arquivo de log.",
                "Erro no Sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            }
            catch
            {
                MessageBox.Show(
               "Erro crítico ao tentar registrar o log.",
               "Falha ao Registrar Erro",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning
           );
            }
        }

        public static void GetErroSr(this Exception ex, object objeto, bool msgbox = true)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {
                    sw.WriteLine("==============================================");
                    sw.WriteLine($"Data/Hora: {DateTime.Now}");
                    sw.WriteLine($"Erro: {ex.Message}");
                    sw.WriteLine($"StackTrace: {ex.StackTrace}");
                    sw.WriteLine("---- Dados do DTO ----");

                    if (objeto != null)
                    {
                        Type t = objeto.GetType();
                        sw.WriteLine($"Classe: {t.Name}");
                        sw.WriteLine("{");

                        // 🔥 SE FOR JSON ELEMENT, SERIALIZA DIRETO
                        if (objeto is JsonElement je)
                        {
                            try
                            {
                                string jsonBonito = JsonSerializer.Serialize(je, new JsonSerializerOptions
                                {
                                    WriteIndented = true
                                });

                                sw.WriteLine(jsonBonito);
                            }
                            catch
                            {
                                sw.WriteLine(je.ToString());
                            }

                            sw.WriteLine("}");
                            sw.WriteLine("==============================================");
                            return;
                        }

                        // 🔥 Se for outro tipo normal, usa reflexão
                        foreach (var prop in t.GetProperties())
                        {
                            try
                            {
                                object? valor = prop.GetValue(objeto);
                                string tipo = prop.PropertyType.Name;

                                // JsonElement dentro de propriedades → salvar JSON
                                if (valor is JsonElement json)
                                {
                                    try
                                    {
                                        valor = JsonSerializer.Serialize(json, new JsonSerializerOptions
                                        {
                                            WriteIndented = false
                                        });

                                        tipo = "JsonElement";
                                    }
                                    catch
                                    {
                                        valor = json.ToString();
                                    }
                                }

                                if (valor == null)
                                    valor = "NULL";

                                sw.WriteLine($"   {prop.Name} ({tipo}): {valor}");
                            }
                            catch (Exception propEx)
                            {
                                sw.WriteLine($"   {prop.Name}: ERRO ao ler propriedade ({propEx.Message})");
                            }
                        }

                        sw.WriteLine("}");
                    }

                    sw.WriteLine("==============================================");
                    sw.WriteLine();
                }

                if (msgbox)
                {
                    MessageBox.Show(
                        $"Ocorreu um erro:\n\n{ex.Message}\n\n" +
                        "O erro completo foi salvo no arquivo de log.",
                        "Erro no Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception exx)
            {
                exx.GetErro(exx,false);
                return;
                MessageBox.Show(
                   "Erro crítico ao tentar registrar o log.",
                   "Falha ao Registrar Erro",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
        }

        private static void GravarDetalhesPropriedades(StreamWriter sw, object objeto, int nivel)
        {
            if (objeto == null) return;

            Type t = objeto.GetType();
            string indentacao = new string(' ', nivel * 4); // 4 espaços por nível

            // Se for uma string (que também é IEnumerable, mas queremos tratar como valor)
            if (objeto is string)
            {
                // Se for chamado de forma recursiva, imprime o valor da string.
                if (nivel > 0)
                {
                    sw.WriteLine($"{indentacao}{objeto}");
                }
                return;
            }

            // 💡 TRATAMENTO PRINCIPAL PARA COLEÇÕES
            if (objeto is System.Collections.IEnumerable enumerable && !(objeto is System.Collections.IDictionary))
            {
                int indice = 0;
                // Pega o tipo de argumento genérico, ex: T em List<T>
                string nomeTipoItem = t.IsGenericType ? t.GetGenericArguments()[0].Name : t.Name.Replace("[]", "");

                sw.WriteLine($"{indentacao}{t.Name} ({nomeTipoItem}) [");

                foreach (var item in enumerable)
                {
                    if (item != null)
                    {
                        // Se for um tipo primitivo/simples (int, string, DateTime, etc.)
                        if (item.GetType().IsPrimitive || item is ValueType || item is string)
                        {
                            sw.WriteLine($"{indentacao}  [{indice}]: {item}");
                        }
                        else // Se for um objeto complexo (DTO)
                        {
                            sw.WriteLine($"{indentacao}  [{indice}] (Tipo: {item.GetType().Name}) {{");
                            // Chamada recursiva para inspecionar as propriedades do item
                            GravarDetalhesPropriedades(sw, item, nivel + 1);
                            sw.WriteLine($"{indentacao}  }}");
                        }
                    }
                    else
                    {
                        sw.WriteLine($"{indentacao}  [{indice}]: null");
                    }
                    indice++;
                }
                sw.WriteLine($"{indentacao}]");
                return;
            }

            // 💡 TRATAMENTO PARA OBJETOS NORMAIS (DTOs)
            sw.WriteLine($"Classe: {t.Name}" + " {");

            // Pega TODAS as propriedades e seus valores
            PropertyInfo[] props = t.GetProperties();
            foreach (var prop in props)
            {
                object? valor = prop.GetValue(objeto);
                string tipo = prop.PropertyType.Name;

                // Se o valor for null ou um tipo primitivo/simples, imprime diretamente
                if (valor == null || prop.PropertyType.IsPrimitive || prop.PropertyType.IsValueType || prop.PropertyType == typeof(string))
                {
                    sw.WriteLine($"{indentacao}  {prop.Name} ({tipo}): {valor}");
                }
                else // Se for um objeto complexo ou uma coleção
                {
                    sw.Write($"{indentacao}  {prop.Name} ({tipo}): ");
                    // Chamada recursiva para inspecionar o valor
                    GravarDetalhesPropriedades(sw, valor, nivel + 1);
                }
            }

            if (nivel == 0) // Fecha a chave apenas para o objeto DTO principal
            {
                sw.WriteLine("}");
            }
        }
    }
}
