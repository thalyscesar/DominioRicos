using Catalogo.Service.Services;
using FluentValidation;
using MediatR;

namespace Catalogo.Application.Commands
{
    public class AtualizarQuantidadeEmEstoqueProduto : IRequest<bool>
    {
        public long Id { get; set; }
        public int QuantidadeEmEstoque { get; set; }
    }

    public class ValidadorAtualizarQuantidadeEmEstoqueProduto : AbstractValidator<AtualizarQuantidadeEmEstoqueProduto>
    {
        public ValidadorAtualizarQuantidadeEmEstoqueProduto()
        {
            RuleFor(p => p).Must(a => new ProdutoServices().ProdutoExiste(a.Id)).WithMessage("O produto não existe");
            RuleFor(p => p.QuantidadeEmEstoque).NotNull().NotEmpty().WithMessage("Informe uma nova quantidade de estoque para o estado");
            RuleFor(p => p.QuantidadeEmEstoque).Must(v => v > 0).WithMessage("A quantidade em estoque não pode ser 0");
        }
    }
}
