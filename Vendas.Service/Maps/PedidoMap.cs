
using DapperExtensions.Mapper;
using Vendas.Dominio.Entidades;

namespace Vendas.Service.Maps
{
    public class PedidoMap : ClassMapper<Pedido>
    {
        public PedidoMap()
        {
            Table("pedido");
            Schema("vendas");
            Map(c => c.ValorTotal).Column("valortotal");
            Map(c => c.DataCadastro).Column("datacadastro");
            Map(c => c.Cliente).Ignore();
            Map(c => c.Status).Column("status");
            Map(c => c.IdCliente).Column("idcliente");
            Map(c => c.Id).Column("id").Key(KeyType.Identity);
            Map(c => c.Codigo).Column("codigo");
        }
    }
}
