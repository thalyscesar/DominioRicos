using Catalogo.Service.Services;
using FluentValidation;
using MediatR;
namespace Catalogo.Application.Queries
{
    public class BuscarProdutoId : IRequest<BuscarProduto>
    {
        public long Id { get; set; }
    }

    public class ValidadorBuscarPorId : AbstractValidator<BuscarProdutoId>
    {
        public ValidadorBuscarPorId()
        {
            RuleFor(p => p).Must(b => new ProdutoServices().ProdutoExiste(b.Id)).WithMessage("O produto não existe");
        }
    }
}
