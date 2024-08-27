using Catalogo.Service.Services;
using FluentValidation;
using MediatR;

namespace Catalogo.Application.Commands
{
    public class AtualizarValorProduto : IRequest<bool>
    {
        public long Id { get; set; }
        public decimal Valor { get; set; }
    }

    public class ValidadorAtualizarValorProduto : AbstractValidator<AtualizarValorProduto>
    {
        public ValidadorAtualizarValorProduto()
        {
            RuleFor(p => p).Must(a => new ProdutoServices().ProdutoExiste(a.Id)).WithMessage("O produto não existe");
            RuleFor(p => p.Valor).NotNull().NotEmpty().WithMessage("Informe um novo valor para o estado");
            RuleFor(p => p.Valor).Must(v => v >= 0.05M).WithMessage("O valor não pode ser menor que R$0.05 centavos");
        }
    }
}
