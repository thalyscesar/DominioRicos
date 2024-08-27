using Shared.Data;
using Vendas.Dominio.Entidades;
using Vendas.Service.Maps;

namespace Vendas.Service.Repositorios
{
    public class RepositorioPedido : RepositorioBase<Pedido, PedidoMap>
    {
        public List<Pedido> PedidoPorClienteExiste(Int64 id)
        {
            var query = $"select * from vendas.pedido where idcliente = '{id}';";

            return DBHelper<Pedido>.InstanciaNpgsql.GetQuery(query);
        }

        public bool AtualizarStatusPedido(Int64 id, Status status)
        {
            var query = $"UPDATE vendas.pedido SET status = '{status}' WHERE id = {id};";

            return DBHelper<Pedido>.InstanciaNpgsql.Get(query) != null;
        }

        public Int64 PedidoPorCodigoExiste(string codigo)
        {
            var query = $"select * from vendas.pedido where codigo = '{codigo}';";

            return DBHelper<Pedido>.InstanciaNpgsql.Get(query);
        }

        public bool AtualizarValorTotal(Int64 id, decimal valor)
        {
            var query = $"UPDATE vendas.pedido SET valortotal = {valor} WHERE id = {id};";

            return DBHelper<Pedido>.InstanciaNpgsql.Get(query) != null;
        }
        
    }
}
