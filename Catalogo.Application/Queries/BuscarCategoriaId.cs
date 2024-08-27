
using Catalogo.Service.Services;
using FluentValidation;
using MediatR;

namespace Catalogo.Application.Queries
{
    public class BuscarCategoriaId : IRequest<BuscarCategoria>
    {
        public Int64 Id { get; set; }
    }

    public class ValidadorBuscarCategoriaId : AbstractValidator<BuscarCategoriaId>
    {
        public ValidadorBuscarCategoriaId()
        {
            RuleFor(c => c).Must(b => new CategoriaServices().CategoriaExiste(b.Id)).WithMessage("A categoria não existe");
        }
    }
}
