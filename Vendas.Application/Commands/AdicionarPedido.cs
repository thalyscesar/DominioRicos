using FluentValidation;
using MediatR;
using Vendas.Dominio.Entidades;

namespace Vendas.Application.Commands
{
    public class AdicionarPedido : IRequest<bool>
    {
        public DateTime DataCadastro { get; set; }
        public AdicionarClientePedido Cliente { get; set; }
        public string? Codigo { get; set; }
    }

    public class ValidadorAdicionarPedido : AbstractValidator<AdicionarPedido>
    {
        public ValidadorAdicionarPedido()
        {
            RuleFor(p => p.DataCadastro).NotEmpty().NotNull().WithMessage("A data não pode ser nula ou vazia");
            RuleFor(p => p.Codigo).NotNull().NotEmpty().WithMessage("O codigo não pode ser vazio ou nulo");
            RuleFor(p => p.Codigo).MinimumLength(1).MaximumLength(10).WithMessage("O codigo deve ter de 1 a 10 caractetres");
        }
    }
}
