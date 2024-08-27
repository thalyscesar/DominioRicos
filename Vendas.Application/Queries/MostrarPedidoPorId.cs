
using FluentValidation;
using MediatR;
using Vendas.Service.Services;

namespace Vendas.Application.Queries
{
    public class MostrarPedidoPorId : IRequest<MostrarPedido>
    {
        public Int64 Id { get; set; }
    }

    public class ValidadorMostrarPedidoPorId : AbstractValidator<MostrarPedidoPorId>
    {
        public ValidadorMostrarPedidoPorId()
        {
            RuleFor(m => m).Must(p => new PedidoServices().PedidoIdExiste(p.Id)).WithMessage("Pedido não existe");
        }
    }
}
