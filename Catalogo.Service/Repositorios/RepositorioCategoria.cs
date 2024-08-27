
using Catalogo.Dominio.Entidades;
using Shared.Data;
using System.Globalization;
using System.Text;

namespace Catalogo.Service.Repositorios
{
    public class RepositorioCategoria : RepositorioBase<Categoria, CategoriaMap>
    {
        public List<Categoria> BuscarCategorias()
        {
            string querySelect = String.Format("SELECT id, nome FROM catalogo.categoria;");
            return DBHelper<Categoria>.InstanciaNpgsql.GetQuery(querySelect);
        }

        public Int64 BuscarCategoria(string? nome)
        {
            string querySelect = String.Format("select * from catalogo.categoria where UNACCENT(UPPER(nome)) = '{0}';", this.RemoverAcentos(nome.ToUpper()));
            var categoria = DBHelper<Categoria>.InstanciaNpgsql.Get(querySelect, null);

            return categoria;
        }

        public string RemoverAcentos(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letra in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letra) != UnicodeCategory.NonSpacingMark)
                {
                    sbReturn.Append(letra);
                }
            }
            return sbReturn.ToString();
        }
    }
}
