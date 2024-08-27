using Catalogo.Service.Services;
using FluentValidation;
using MediatR;

namespace Catalogo.Application.Commands
{
    public class AtualizarAtivoProduto : IRequest<bool>
    {
        public long Id { get; set; }
        public bool Ativo { get; set; }
    }

    public class ValidadorAtualizarAtivoProduto : AbstractValidator<AtualizarAtivoProduto>
    {
        public ValidadorAtualizarAtivoProduto()
        {
            RuleFor(p => p).Must(a => new ProdutoServices().ProdutoExiste(a.Id)).WithMessage("O produto não existe");
            RuleFor(p => p.Ativo).NotNull().WithMessage("Informe um novo valor para o estado");
        }
    }
}
