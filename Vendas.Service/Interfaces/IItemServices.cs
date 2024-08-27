
using Vendas.Dominio.Entidades;

namespace Vendas.Service.Interfaces
{
    public interface IItemServices
    {
        Item MostrarItemPorId(Int64 id);
        List<Item> MostrarItensPedido(Int64 idPedido);
        Item MostrarItemPorPedidoEProduto(Int64 idPedido, Int64 idProduto);
        bool Adicionar(Item item);
        bool Adicionar(Int64 idPedido, Int64 idProduto, int quantidade);
        bool AtualizarQuantidadeItem(Int64 id, int quantidade);
        bool Remover(Int64 id);
        void AtualizarEstoque(Int64 id, int quantidade, bool tipo);
    }
}
