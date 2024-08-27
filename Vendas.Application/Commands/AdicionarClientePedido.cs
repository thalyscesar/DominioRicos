
using FluentValidation;
using MediatR;

namespace Vendas.Application.Commands
{
    public class AdicionarClientePedido : IRequest<bool>
    {
        public string? Nome { get; set; }
        public string? NumeroDocumento { get; set; }
    }

    public class ValidadorAdicionarClientePedido : AbstractValidator<AdicionarClientePedido>
    {
        public ValidadorAdicionarClientePedido()
        {
            RuleFor(c => c.Nome).NotEmpty().NotNull().WithMessage("O nome do cliente  não pode ser nulo o vazio");
            RuleFor(c => c.Nome).MinimumLength(10).MaximumLength(30).WithMessage("O nome do cliente deve ser de 10 a 30 caracteres");
            RuleFor(c => c.NumeroDocumento).NotNull().NotEmpty().WithMessage("O numero de documento não pode ser nulo ou vazio");
            RuleFor(c => c.NumeroDocumento).MinimumLength(11).MaximumLength(15).WithMessage("O numero do documento deve ter 11 ou 15 caracteres");
        }
    }
}
