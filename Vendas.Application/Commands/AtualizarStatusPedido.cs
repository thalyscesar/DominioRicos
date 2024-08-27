
using FluentValidation;
using MediatR;
using Vendas.Dominio.Entidades;
using Vendas.Service.Services;

namespace Vendas.Application.Commands
{
    public class AtualizarStatusPedido : IRequest<bool>
    {
        public Int64 Id { get; set; }
        public Status Status { get; set; }
    }

    public class ValidadorAtualizarStatusPedido : AbstractValidator<AtualizarStatusPedido>
    {
        public ValidadorAtualizarStatusPedido()
        {
            RuleFor(p => p).Must(a => new PedidoServices().PedidoIdExiste(a.Id)).WithMessage("Pedido não existe");
            RuleFor(p => p.Status).NotNull().WithMessage("Status não pode ser nulo");
        }
    }
}
