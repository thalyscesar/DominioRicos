using DapperExtensions.Mapper;
using Vendas.Dominio.Entidades;

namespace Vendas.Service.Maps
{
    public class ProdutoMap : ClassMapper<Produto>
    {
        public ProdutoMap()
        {
            Table("produto");
            Schema("vendas");
            Map(c => c.Id).Column("id").Key(KeyType.Identity);
            Map(c => c.Nome).Column("nome");
            Map(c => c.QuantidadeEmEstoque).Column("quantidadeemestoque");
            Map(c => c.Valor).Column("valor");
            Map(c => c.Codigo).Column("codigo");
        }
    }
}
