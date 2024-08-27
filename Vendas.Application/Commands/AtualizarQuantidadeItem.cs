
using FluentValidation;
using MediatR;
using Vendas.Service.Services;

namespace Vendas.Application.Commands
{
    public class AtualizarQuantidadeItem : IRequest<bool>
    {
        public Int64 Id { get; set; }
        public int Quantidade { get; set; }
    }

    public class ValidadorAtualizarQuantidadeItem : AbstractValidator<AtualizarQuantidadeItem>
    {
        public ValidadorAtualizarQuantidadeItem()
        {
            RuleFor(i => i).Must(a => new ItemServices().ItemExiste(a.Id)).WithMessage("O item não existe");
            RuleFor(i => i.Quantidade).NotNull().NotEmpty().WithMessage("A quantidade não pode ser nula ou vazia");
            RuleFor(i => i).Must(a => a.Quantidade > 0).WithMessage("A quantidade não pode ser o");
        }
    }
}
