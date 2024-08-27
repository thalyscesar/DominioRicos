
using Catalogo.Dominio.Entidades;
using Shared.Data;

namespace Catalogo.Service.Repositorios
{
    public class RepositorioProduto : RepositorioBase<Produto, ProdutoMap>
    {
        public List<Produto> BuscarProdutos()
        {
            string querySelect = String.Format("SELECT id, categoriaid, nome, descricao, ativo, " +
                                                "valor, datacadastro, quantidadeestoque, altura, largura," +
                                                " profundidade FROM catalogo.produto; ");
            return DBHelper<Produto>.InstanciaNpgsql.GetQuery(querySelect);
        }

        public bool AtualizarDescricaoProduto(Int64 id, string descricao)
        {
            string queryUpdate = $"UPDATE catalogo.produto SET descricao = '{descricao}' WHERE id = {id}; ";
            var resultadoAtualizacao = DBHelper<Produto>.InstanciaNpgsql.Get(queryUpdate);

            return resultadoAtualizacao != null;
        }

        public bool AtualizarAtivoProduto(Int64 id, bool ativo)
        {
            string queryUpdate = $"UPDATE catalogo.produto SET ativo = '{ativo}' WHERE id = {id}; ";

            return DBHelper<Produto>.InstanciaNpgsql.Get(queryUpdate) != null;
        }

        public bool AtualizarValorProduto(Int64 id, decimal valor)
        {
            string queryUpdate = $"UPDATE catalogo.produto SET valor= '{valor}' WHERE id = {id};";

            return DBHelper<Produto>.InstanciaNpgsql.Get(queryUpdate) != null;
        }

        public bool AtualizarQuantidadeEmEstoqueProduto(Int64 id, decimal quantidadeEmEstoque)
        {
            string queryUpdate = $"UPDATE catalogo.produto SET quantidadeestoque= '{quantidadeEmEstoque}' WHERE id = {id};";

            return DBHelper<Produto>.InstanciaNpgsql.Get(queryUpdate) != null;
        }

        public bool AtualizarProduto(long id, string descricao, bool ativo, decimal valor, int quantidadeEmEstoque)
        {
            string queryUpdate = $"UPDATE catalogo.produto " +
                                 $"SET descricao = '{descricao}', ativo = '{ativo}', valor = '{valor}', quantidadeestoque = '{quantidadeEmEstoque}' " +
                                 $"WHERE id = {id}; ";

            return DBHelper<Produto>.InstanciaNpgsql.Get(queryUpdate) != null;
        }
    }
}
