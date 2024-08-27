
using FluentValidation.Results;
using MediatR;
using Vendas.Application.Queries;
using Vendas.Dominio.Entidades;
using Vendas.Service.Interfaces;

namespace Vendas.Application.Control
{
    public class PedidoQueryHandler :   IRequestHandler<MostrarPedidoPorId, MostrarPedido>,
                                        IRequestHandler<MostrarPedidoPorCliente, List<MostrarPedido>>  
    {
        private readonly IPedidoServices _pedidoServices;

        public PedidoQueryHandler(IPedidoServices pedidoServices)
        {
            _pedidoServices = pedidoServices;
        }

        public Task<MostrarPedido> Handle(MostrarPedidoPorId request, CancellationToken cancellationToken)
        {
            if (!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(new MostrarPedido());

            var pedido = _pedidoServices.MostrarPedidoPorId(request.Id);

            return Task.FromResult(ConverterParaMostrarPedido(pedido));
        }

        public Task<List<MostrarPedido>> Handle(MostrarPedidoPorCliente request, CancellationToken cancellationToken)
        {
            if(!this.ObterResultadoValidacao(request).IsValid) return Task.FromResult(new List<MostrarPedido> { new MostrarPedido() });

            var listaPedidos = _pedidoServices.MostrarPedidoPorCliente(request.IdCliente);
            List<MostrarPedido> listaMostrarpedido = new List<MostrarPedido>();

            foreach(var pedido in listaPedidos)
            {
                listaMostrarpedido.Add(ConverterParaMostrarPedido(pedido));
            }

            return Task.FromResult(listaMostrarpedido);
        }

        // Conversões

        private MostrarPedido ConverterParaMostrarPedido(Pedido pedido)
        {
            return new MostrarPedido()
            {
                Id = pedido.Id,
                IdCliente = pedido.IdCliente,
                ValorTotal = pedido.ValorTotal,
                DataCadastro = pedido.DataCadastro,
                Status = pedido.Status
            };
        }

        // Validações

        public ValidationResult ObterResultadoValidacao(MostrarPedidoPorId mostrarPedidoPorId)
        {
            return new ValidadorMostrarPedidoPorId().Validate(mostrarPedidoPorId);
        }

        public ValidationResult ObterResultadoValidacao(MostrarPedidoPorCliente mostrarPedidoPorCliente)
        {
            return new ValidadorMostrarPedidoPorCliente().Validate(mostrarPedidoPorCliente);
        }
    }
}
