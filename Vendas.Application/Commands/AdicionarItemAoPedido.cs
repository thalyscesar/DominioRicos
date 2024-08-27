
using FluentValidation;
using MediatR;
using Vendas.Service.Services;

namespace Vendas.Application.Commands
{
    public class AdicionarItemAoPedido : IRequest<bool>
    {
        public Int64 IdPedido { get; set; }
        public Int64 IdProduto { get; set; }
        public int Quantidade { get; set; }
    }

    public class ValidadorAdicionarItemAoPedido : AbstractValidator<AdicionarItemAoPedido>
    {
        public ValidadorAdicionarItemAoPedido()
        {
            RuleFor(i => i.IdPedido).NotEmpty().NotNull().WithMessage("id do pedido não pode ser nulo ou vazio");
            RuleFor(i => i).Must(a => new PedidoServices().PedidoIdExiste(a.IdPedido)).WithMessage("Pedido não existe");
            RuleFor(i => i.IdProduto).NotEmpty().NotNull().WithMessage("id do produto não pode ser nulo ou vazio");
            RuleFor(i => i).Must(a => new ItemServices().ProdutoCadastrado(a.IdProduto)).WithMessage("Produto não existe");
            RuleFor(i => i.Quantidade).NotEmpty().NotNull().WithMessage("A quantidade não pode ser nula ou vazia");
            RuleFor(i => i).Must(i => i.Quantidade > 0).WithMessage("A quantidade não pode ser 0");
        }
    }
}
