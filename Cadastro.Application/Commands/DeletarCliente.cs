
using Cadastro.Service.Services;
using FluentValidation;
using MediatR;

namespace Cadastro.Application.Commands
{
    public class DeletarCliente : IRequest<bool>
    {
        public Int64 Id { get; set; } 
    }

    public class ValidadorDeletarCliente : AbstractValidator<DeletarCliente>
    {
        public ValidadorDeletarCliente()
        {
            RuleFor(d => d).Must(c => new ClienteService().ClienteExiste(c.Id)).WithMessage("Cliente não existe");
        }
    }
}
