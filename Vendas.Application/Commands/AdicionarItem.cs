
using FluentValidation;
using MediatR;
using Vendas.Dominio.Entidades;

namespace Vendas.Application.Commands
{
    public class AdicionarItem : IRequest<bool>
    {
        public AdicionarPedido Pedido { get; set; }
        public AdicionarProduto Produto { get; set; }
        public int Quantidade { get; set; }
    }

    public class ValidadorAdicionarItem : AbstractValidator<AdicionarItem>
    {
        public ValidadorAdicionarItem()
        {
            RuleFor(i => i.Quantidade).NotEmpty().NotNull().WithMessage("a Quantidade não pode ser nula ou vazia");
            RuleFor(i => i).Must(q => q.Quantidade > 0).WithMessage("Quantidade não pode ser zero");
        }
    }
}
