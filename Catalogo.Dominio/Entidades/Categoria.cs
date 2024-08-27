

namespace Catalogo.Dominio.Entidades
{
    public class Categoria
    {
        public Categoria()
        {

        }

        public Categoria(Int64 id, string? nome)
        {
            Id = id;
            this.Nome = nome;
        }

        public Int64 Id { get; private set; }
        public string? Nome { get; private set; }
    }
}
