
using DapperExtensions.Mapper;
using Vendas.Dominio.Entidades;

namespace Vendas.Service.Maps
{
    public class ItemMap : ClassMapper<Item>
    {
        public ItemMap()
        {
            Table("item");
            Schema("vendas");
            Map(c => c.Id).Column("id").Key(KeyType.Identity);
            Map(c => c.IdProduto).Column("idproduto");
            Map(c => c.ValorItem).Column("valoritem");
            Map(c => c.Quantidade).Column("quantidade");
            Map(c => c.IdPedido).Column("idpedido");
            Map(c => c.Produto).Ignore();
            Map(c => c.Pedido).Ignore();
        }
    }
}
