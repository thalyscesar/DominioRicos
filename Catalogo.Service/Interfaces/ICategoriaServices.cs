
using Catalogo.Dominio.Entidades;

namespace Catalogo.Service.Interfaces
{
    public interface ICategoriaServices
    {
        List<Categoria> ObterTodas();
        Categoria ObterPorId(Int64 id);
        bool Atualizar(Int64 id, string nome);
    }
}
