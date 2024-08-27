
using Cadastro.Service.Services;
using FluentValidation;
using MediatR;

namespace Cadastro.Application.Queries
{
    public class BuscarClientePorId : IRequest<BuscarCliente>
    {
        public Int64 Id { get; set; }
    }

    public class ValidadorBuscarClientePorId : AbstractValidator<BuscarClientePorId>
    {
        public ValidadorBuscarClientePorId()
        {
            RuleFor(a => a).Must(c => new ClienteService().ClienteExiste(c.Id)).WithMessage("Cliente não existe");
        }
    }
}
