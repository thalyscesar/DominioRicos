using MediatR;

namespace Catalogo.Application.Queries
{
    public class BuscarCategoria : IRequest<List<BuscarCategoria>>
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
    }
}
