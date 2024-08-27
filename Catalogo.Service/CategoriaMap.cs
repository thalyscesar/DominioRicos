
using Catalogo.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Catalogo.Service
{
    public class CategoriaMap : ClassMapper<Categoria>
    {
        public CategoriaMap()
        {
            Table("categoria");
            Schema("catalogo");
            Map(c => c.Id).Column("id").Key(KeyType.Identity);
            Map(c => c.Nome).Column("nome");
        }
    }
}
