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
                        Type t = objeto.GetType();
                        sw.WriteLine($"Classe: {t.Name}" + "{");

                        // Pega TODAS as propriedades e seus valores
                        PropertyInfo[] props = t.GetProperties();
                        foreach (var prop in t.GetProperties())
                        {
                            object? valor = prop.GetValue(objeto);
                            string tipo = prop.PropertyType.Name; 

                            sw.WriteLine($"      {prop.Name} ({tipo}): {valor}");
                        }

                        sw.WriteLine("}");
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

    }
}
