using FluentValidation;
using MediatR;
using Vendas.Service.Services;

namespace Vendas.Application.Queries
{
    public class MostrarItemPorId : IRequest<MostrarItem>
    {
        public Int64 Id { get; set; }
    }

    public class ValidadorMostrarItemPorId : AbstractValidator<MostrarItemPorId>
    {
        public ValidadorMostrarItemPorId()
        {
            RuleFor(i => i.Id).NotEmpty().NotNull().WithMessage("O id não pode ser nulo ou vazio");
            RuleFor(i => i).Must(e => new ItemServices().ItemExiste(e.Id)).WithMessage("O item não existe");
        }
    }
}
