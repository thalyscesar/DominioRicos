
using DapperExtensions.Mapper;
using Vendas.Dominio.Entidades;

namespace Vendas.Service.Maps
{
    public class ClienteMap : ClassMapper<ClientePedido>
    {
        public ClienteMap()
        {
            Table("cliente");
            Schema("vendas");
            Map(c => c.Id).Column("id").Key(KeyType.Identity);
            Map(c => c.Nome).Column("nome");
            Map(c => c.NumeroDocumento).Column("numerodocumento");
        }
    }
}
