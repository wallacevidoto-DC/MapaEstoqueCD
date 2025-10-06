using global::MapaEstoqueCD.View.Modal;
using MapaEstoqueCD.Controller;
using System.Linq.Expressions;


namespace MapaEstoqueCD.Database.Common
{


    public class QueryGeneric
    {
        

        public static IQueryable<T> FiltrarQuery<T>(List<FiltroItem> filtros) where T : class
        {
            IQueryable<T> query = CacheMP.Instance.Db.Set<T>();

            foreach (var filtro in filtros)
            {
                if (string.IsNullOrWhiteSpace(filtro.Tabela) || string.IsNullOrWhiteSpace(filtro.Valor))
                    continue;

                bool exato = filtro.Tipo.ToLower() == "exato";

                // Cria parâmetro 'entity'
                var param = Expression.Parameter(typeof(T), "entity");

                // Acessa a propriedade
                var prop = Expression.Property(param, filtro.Tabela);

                // Converte a propriedade para string
                Expression propAsString = Expression.Call(
                    prop,
                    typeof(object).GetMethod("ToString", Type.EmptyTypes)!
                );

                // Converte para minúsculas
                Expression propLower = Expression.Call(
                    propAsString,
                    typeof(string).GetMethod("ToLower", Type.EmptyTypes)!
                );

                // Valor do filtro
                var termo = Expression.Constant(filtro.Valor.ToLower());

                Expression body;
                if (exato)
                {
                    // entity.Prop.ToString().ToLower() == termo
                    body = Expression.Equal(propLower, termo);
                }
                else
                {
                    // entity.Prop.ToString().ToLower().Contains(termo)
                    body = Expression.Call(
                        propLower,
                        typeof(string).GetMethod("Contains", new[] { typeof(string) })!,
                        termo
                    );
                }

                var lambda = Expression.Lambda<Func<T, bool>>(body, param);
                query = query.Where(lambda);
            }

            return query;
        }
    }


}
