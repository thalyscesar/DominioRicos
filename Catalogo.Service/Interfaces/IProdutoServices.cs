using Catalogo.Dominio.Entidades;

namespace Catalogo.Service.Interfaces
{
    public interface IProdutoServices
    {
        bool Adicionar(Produto produto);
        List<Produto> ObterTodos();
        Produto ObterPorId(Int64 id);
        bool Deletar(Int64 id);
        bool AtualizarDescricaoProduto(Int64 id, string descricao);
        bool AtualizarAtivoProduto(Int64 id, bool ativo);
        bool AtualizarValorProduto(Int64 id, decimal valor);
        bool AtualizarQuantidadeEmEstoque(Int64 id, int quantidadeEmEstoque);
        bool AtualizarProduto(Int64 id, string descricao, bool ativo, decimal valor, int quantidadeEmEstoque);
    }
}
