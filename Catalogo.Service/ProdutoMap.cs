using Catalogo.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Catalogo.Service
{
    public class ProdutoMap : ClassMapper<Produto>
    {
        public ProdutoMap()
        {
            Table("produto");
            Schema("catalogo");
            Map(p => p.Id).Column("id").Key(KeyType.Identity);
            Map(p => p.CategoriaId).Column("categoriaid");
            Map(p => p.Nome).Column("nome");
            Map(p => p.Descricao).Column("descricao");
            Map(p => p.Ativo).Column("ativo");
            Map(p => p.Valor).Column("valor");
            Map(p => p.DataCadastro).Column("datacadastro");
            Map(p => p.QuantidadeEstoque).Column("quantidadeestoque");
            Map(p => p.Altura).Column("altura");
            Map(p => p.Largura).Column("largura");
            Map(p => p.Profundidade).Column("profundidade");
            Map(p => p.Categoria).Ignore();
        }
    }
}
