
using Vendas.Dominio.Entidades;

namespace Vendas.Service.Interfaces
{
    public interface IPedidoServices
    {
        Pedido MostrarPedidoPorId(Int64 id);
        List<Pedido> MostrarPedidoPorCliente(Int64 idCliente);
        bool AdicionarPedido(Pedido pedido);
        bool AtualizarStatusPedido(Int64 id, Status status);
    }
}
