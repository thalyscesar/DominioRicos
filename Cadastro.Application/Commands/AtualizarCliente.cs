
using Cadastro.Service.Services;
using FluentValidation;
using MediatR;

namespace Cadastro.Application.Commands
{
    public class AtualizarCliente : IRequest<bool>
    {
        public Int64 Id { get; set; }
        public string Nome { get; set; }
    }

    public class ValidadorAtualizarCliente : AbstractValidator<AtualizarCliente>
    {
        public ValidadorAtualizarCliente()
        {
            RuleFor(a => a).Must(c => new ClienteService().ClienteExiste(c.Id)).WithMessage("Cliente não existe");
            RuleFor(a => a.Nome).NotEmpty().NotNull().WithMessage("Novo nme não pode ser vazio ou nulo");
            RuleFor(a => a.Nome).MinimumLength(10).MaximumLength(30).WithMessage("O nome deve conter de 10 a 30 caracteres");
        }
    }
}
