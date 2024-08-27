
using Cadastro.Dominio.Entidades;
using MediatR;

namespace Cadastro.Application.Queries
{
    public class BuscarCliente : IRequest<List<BuscarCliente>>
    {
        public Int64 Id { get; set; }
        public string? Nome { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string? NumeroDocumento { get; set; }
    }
}
