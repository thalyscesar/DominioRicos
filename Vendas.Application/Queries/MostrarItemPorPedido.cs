using FluentValidation;
using MediatR;
using Vendas.Service.Services;

namespace Vendas.Application.Queries
{
    public class MostrarItemPorPedido : IRequest<List<MostrarItem>>
    {
        public Int64 IdPedido { get; set; }
    }

    public class ValidadorMostrarItemPorPedido : AbstractValidator<MostrarItemPorPedido>
    {
        public ValidadorMostrarItemPorPedido()
        {
            RuleFor(i => i.IdPedido).NotEmpty().NotNull().WithMessage("O id do pedido não pode ser nulo");
            RuleFor(i => i).Must(p => new ItemServices().ItemPedidoExiste(p.IdPedido)).WithMessage("Item não existe");
        }
    }
}
