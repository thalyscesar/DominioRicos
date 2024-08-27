using FluentValidation;
using MediatR;
using Vendas.Service.Services;

namespace Vendas.Application.Queries
{
    public class MostrarPedidoPorCliente : IRequest<List<MostrarPedido>>
    {
        public Int64 IdCliente { get; set; }
    }

    public class ValidadorMostrarPedidoPorCliente : AbstractValidator<MostrarPedidoPorCliente>
    {
        public ValidadorMostrarPedidoPorCliente()
        {
            RuleFor(c => c).Must(p => new PedidoServices().PedidoClienteExiste(p.IdCliente));
        }
    }
}
