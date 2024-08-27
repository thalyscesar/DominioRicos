
using Cadastro.Dominio.Entidades;
using Cadastro.Service.Services;
using FluentValidation;
using MediatR;

namespace Cadastro.Application.Commands
{
    public class AdicionarCliente : IRequest<bool>
    {
        public string? Nome { get; set; }
        public TipoCliente TipoCliente { get; set; }
        public string? NumeroDocumento { get; set; }
    }

    public class ValidadorAdicionarCliente : AbstractValidator<AdicionarCliente>
    {
        public ValidadorAdicionarCliente()
        {   
            RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("Informe um valor para nome");
            RuleFor(p => p.Nome).MinimumLength(10).MaximumLength(30).WithMessage("O tamanho deve ser de 10 a 30 caracteres");
            RuleFor(p => p.TipoCliente).NotNull().WithMessage("Inorme o tipo do cliente");
            RuleFor(p => p.NumeroDocumento).NotNull().NotEmpty().WithMessage("Informe um valor para o numero da conta");
            RuleFor(p => p.NumeroDocumento).MinimumLength(11).MaximumLength(15).WithMessage("Tamanho deve ser entre 11 e 15 números");
        }
    }
}
