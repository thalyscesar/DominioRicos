
using FluentValidation.Results;
using MediatR;
using Vendas.Application.Commands;
using Vendas.Dominio.Entidades;
using Vendas.Service.Interfaces;

namespace Vendas.Application.Control
{
    public class PedidoHandler :    IRequestHandler<AdicionarPedido, bool>,
                                    IRequestHandler<AtualizarStatusPedido, bool>
    {
        private readonly IPedidoServices _pedidoServices;

        public PedidoHandler(IPedidoServices pedidoServices)
        {
            _pedidoServices = pedidoServices;
        }

        // Handlers

        public Task<bool> Handle(AdicionarPedido request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var pedido = _pedidoServices.AdicionarPedido(this.ConverterParaPedido(request));

            return Task.FromResult(pedido);
        }

        public Task<bool> Handle(AtualizarStatusPedido request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(false);

            var pedido = _pedidoServices.AtualizarStatusPedido(request.Id, request.Status);

            return Task.FromResult(pedido);
        }

        // Conversões

        private Pedido ConverterParaPedido(AdicionarPedido adicionarPedido)
        {
            return new Pedido(
                0,
                0,
                adicionarPedido.DataCadastro,
                new ClientePedido(0, adicionarPedido.Cliente.Nome, adicionarPedido.Cliente.NumeroDocumento),
                adicionarPedido.Codigo,
                0
                );
        }

        //Validações

        public ValidationResult ObterResultadoValidacao(AdicionarPedido adicionarPedido)
        {
            return new ValidadorAdicionarPedido().Validate(adicionarPedido);
        }

        public ValidationResult ObterResultadoValidacao(AtualizarStatusPedido atualizarStatusPedido)
        {
            return new ValidadorAtualizarStatusPedido().Validate(atualizarStatusPedido);
        }
    }
}
