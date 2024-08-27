using Catalogo.Service.Services;
using FluentValidation;
using MediatR;

namespace Catalogo.Application.Commands
{
    public class DeletarProduto : IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class ValidadorDeletarProduto : AbstractValidator<DeletarProduto>
    {
        public ValidadorDeletarProduto()
        {
            RuleFor(p => p).Must(p => new ProdutoServices().ProdutoExiste(p.Id)).WithMessage("Produto não existe");
        }
    }
}
