
using Shared.Data;
using Vendas.Dominio.Entidades;
using Vendas.Service.Maps;

namespace Vendas.Service.Repositorios
{
    public class RepositorioItem : RepositorioBase<Item, ItemMap>
    {
        public bool AtualizarQuantidadeItem(Int64 id, int quantidade)
        {
            var query = $"UPDATE vendas.item SET quantidade = {quantidade} WHERE id = {id}";

            return DBHelper<Item>.InstanciaNpgsql.Get(query) != null;
        }

        public List<Item> MostrarItensPorPedido(Int64 idPedido)
        {
            var query = $"select * from vendas.item where idpedido = {idPedido};";

            return DBHelper<Item>.InstanciaNpgsql.GetQuery(query);
        }

        public bool ProdutoExiste(Int64 id)
        {
            var query = $"select * from vendas.item where idproduto = {id};";

            return DBHelper<Item>.InstanciaNpgsql.Get(query) > 0;
        }

        public bool PedidoExiste(Int64 id)
        {
            var query = $"select * from vendas.item where idpedido = {id};";

            return DBHelper<Item>.InstanciaNpgsql.Get(query) > 0;
        }

        public Item ItemPorPedidoEProduto(Int64 idPedido, Int64 idproduto)
        {
            var query = $"select * from vendas.item where idpedido = {idPedido} and idproduto = {idproduto};";

            var lista = DBHelper<Item>.InstanciaNpgsql.GetQuery(query);

            if (lista.Count == 0) return null;

            var item = lista.FirstOrDefault();

            return item;
        }

        public bool AtualizarValorItem(Int64 id, decimal valor)
        {
            var query = $"UPDATE vendas.item SET valoritem = '{valor}' WHERE id = {id};";

            return DBHelper<Item>.InstanciaNpgsql.Get(query) != null;
        }
    }
}
