using Catalogo.Service.Services;
using FluentValidation;
using MediatR;

namespace Catalogo.Application.Commands
{
    public class AtualizarDescricaoProduto : IRequest<bool>
    {
        public long Id { get; set; }
        public string? Descricao { get; set; }
    }

    public class ValidadorAtualizarDescricaoProduto : AbstractValidator<AtualizarDescricaoProduto>
    {
        public ValidadorAtualizarDescricaoProduto()
        {
            RuleFor(p => p).Must(e => new ProdutoServices().ProdutoExiste(e.Id)).WithMessage("O produto não existe");
            RuleFor(p => p.Descricao).NotEmpty().NotNull().WithMessage("Informe um novo valor para descrição");
            RuleFor(p => p.Descricao).MinimumLength(10).MaximumLength(100).WithMessage("O tamanho deve ser de 10 a 100 caracteres");
        }
    }
}
