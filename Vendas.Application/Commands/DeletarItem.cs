
using FluentValidation;
using MediatR;
using Vendas.Service.Services;

namespace Vendas.Application.Commands
{
    public class DeletarItem : IRequest<bool>
    {
        public Int64 Id { get; set; }
    }

    public class ValidadorDeletarItem : AbstractValidator<DeletarItem>
    {
        public ValidadorDeletarItem()
        {
            RuleFor(i => i).Must(d => new ItemServices().ItemExiste(d.Id)).WithMessage("Item não existe");
        }
    }
}
