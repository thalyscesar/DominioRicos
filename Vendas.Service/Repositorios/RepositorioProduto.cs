using Shared.Data;
using Vendas.Dominio.Entidades;
using Vendas.Service.Maps;

namespace Vendas.Service.Repositorios
{
    public class RepositorioProduto : RepositorioBase<Produto, ProdutoMap>
    {
        public Int64 ProdutoPorCodigoExiste(string codigo)
        {
            var query = $"select * from vendas.produto where codigo = '{codigo}';";

            return DBHelper<Produto>.InstanciaNpgsql.Get(query);
        }

        public bool ProdutoExiste(Int64 id)
        {
            var query = $"select * from vendas.produto where id = '{id}';";

            return DBHelper<Produto>.InstanciaNpgsql.Get(query) > 0;
        }

        public void AtualizarEstoque(Int64 id, int quantidade)
        {
            var query = $"UPDATE vendas.produto SET quantidadeemestoque = {quantidade} WHERE id = {id};";

            DBHelper<Produto>.InstanciaNpgsql.Get(query);
        }
    }
}
