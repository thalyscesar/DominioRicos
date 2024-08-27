using Catalogo.Dominio.Entidades;
using Catalogo.Service.Interfaces;
using Catalogo.Service.Repositorios;

namespace Catalogo.Service.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private RepositorioProduto repositorioProduto = new RepositorioProduto();
        private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

        public bool Deletar(Int64 id)
        {
            var produtoParaDeletar = repositorioProduto.BuscarPorId(id);

            return repositorioProduto.Excluir(produtoParaDeletar);
        }

        public Produto ObterPorId(Int64 id)
        {
            return repositorioProduto.BuscarPorId(id);
        }

        public List<Produto> ObterTodos()
        {
            return repositorioProduto.BuscarProdutos();
        }

        public bool Adicionar(Produto produto)
        {
            Int64 idDaCategoria = 0;
            var resultadoBuscaCategoria = repositorioCategoria.BuscarCategoria(produto.Categoria.Nome);

            if (resultadoBuscaCategoria > 0)
            {
                idDaCategoria = resultadoBuscaCategoria;
            }
            else
            {
                idDaCategoria = repositorioCategoria.Inserir(produto.Categoria);
            }

            produto.SetCategoriaId(idDaCategoria);

            return repositorioProduto.Inserir(produto) > 0;
        }

        public bool ProdutoExiste(Int64 id)
        {
            var resultadoDaBusca = repositorioProduto.BuscarPorId(id);

            if (resultadoDaBusca == null) return false;

            return resultadoDaBusca.Id > 0;
        }

        public bool AtualizarDescricaoProduto(long id, string descricao)
        {
            return repositorioProduto.AtualizarDescricaoProduto(id, descricao);
        }

        public bool AtualizarAtivoProduto(long id, bool ativo)
        {
            return repositorioProduto.AtualizarAtivoProduto(id, ativo);
        }

        public bool AtualizarValorProduto(long id, decimal valor)
        {
            return repositorioProduto.AtualizarValorProduto(id, valor);
        }

        public bool AtualizarQuantidadeEmEstoque(long id, int quantidadeEmEstoque)
        {
            return repositorioProduto.AtualizarQuantidadeEmEstoqueProduto(id, quantidadeEmEstoque);
        }

        public bool AtualizarProduto(long id, string descricao, bool ativo, decimal valor, int quantidadeEmEstoque)
        {
            return repositorioProduto.AtualizarProduto(id, descricao, ativo, valor, quantidadeEmEstoque);
        }
    }
}
