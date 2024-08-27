
using FluentValidation;
using MediatR;
using Vendas.Service.Services;

namespace Vendas.Application.Queries
{
    public class MostrarItemPorPedidoEProduto : IRequest<MostrarItem>
    {
        public Int64 IdPedido { get; set; }
        public Int64 IdProduto { get; set; }
    }

    public class ValidadorMostrarItemPorPedidoEProduto : AbstractValidator<MostrarItemPorPedidoEProduto>
    {
        public ValidadorMostrarItemPorPedidoEProduto()
        {
            RuleFor(pe => pe.IdPedido).NotEmpty().NotNull().WithMessage("O id do pedido não pode ser nulo");
            RuleFor(pe => pe).Must(p => new ItemServices().PedidoExiste(p.IdPedido)).WithMessage("Pedido não existe");
            RuleFor(pr => pr.IdProduto).NotEmpty().NotNull().WithMessage("O id do produto não pode ser nulo");
            RuleFor(pr => pr).Must(p => new ItemServices().ProdutoExiste(p.IdProduto)).WithMessage("O produto não existe");
        }
    }
}
