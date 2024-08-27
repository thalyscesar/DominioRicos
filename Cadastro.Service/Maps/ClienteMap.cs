using Cadastro.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Cadastro.Service.Maps
{
    public class ClienteMap : ClassMapper<Cliente>
    {
        public ClienteMap()
        {
            Table("cliente");
            Schema("cadastro");
            Map(c => c.Id).Column("id").Key(KeyType.Identity);
            Map(c => c.Nome).Column("nome");
            Map(c => c.TipoCliente).Column("tipocliente");
            Map(c => c.NumeroDocumento).Column("numerodocumento");
        }
    }
}
