using Catalogo.Dominio.Entidades;
using Catalogo.Service.Interfaces;
using Catalogo.Service.Repositorios;

namespace Catalogo.Service.Services
{
    public class CategoriaServices : ICategoriaServices
    {
        private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

        public bool Atualizar(Int64 id, string nome)
        {
            return repositorioCategoria.Atualizar(new Categoria(id, nome));
        }

        public Categoria ObterPorId(long id)
        {
            return repositorioCategoria.BuscarPorId(id);
        }

        public List<Categoria> ObterTodas()
        {
            return repositorioCategoria.BuscarCategorias();
        }

        public bool BuscarCategoria(string? nome)
        {
            return repositorioCategoria.BuscarCategoria(nome) > 0;
        }

        public bool CategoriaExiste(Int64 id)
        {
            var resultadoCategoria = repositorioCategoria.BuscarPorId(id);

            if (resultadoCategoria == null) return false;

            return resultadoCategoria.Id > 0;
        }
    }
}
